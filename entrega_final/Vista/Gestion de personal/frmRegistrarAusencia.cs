using Modelos;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Vistass
{
    // Ventana para registrar una falta, permiso o incapacidad.
    // Las reglas son las mismas que valida sp_RegistrarAusencia en la base de datos.
    public class frmRegistrarAusencia : Form
    {
        private static readonly CultureInfo Inv = CultureInfo.InvariantCulture;
        private static readonly Color Soft = Color.FromArgb(170, 180, 200);

        private readonly ComboOscuro cmbEmpleado = new ComboOscuro();
        private readonly ComboOscuro cmbTipo = new ComboOscuro();
        private readonly FechaOscura dtpDesde = new FechaOscura();
        private readonly FechaOscura dtpHasta = new FechaOscura();
        private readonly CheckBox chkJustificada = new CheckBox();
        private readonly CheckBox chkConGoce = new CheckBox();
        private readonly TextBox txtMotivo = new TextBox();
        private readonly Label lblResumen = new Label();
        private readonly ErrorProvider ep = new ErrorProvider();

        private bool cargando = true;

        public frmRegistrarAusencia()
        {
            Text = "Registrar ausencia";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false; MinimizeBox = false; ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.FromArgb(27, 29, 38);
            ForeColor = Color.White;
            Font = new Font("Segoe UI", 9.5F);
            ClientSize = new Size(500, 610);
            ep.ContainerControl = this;

            int y = 16;
            Controls.Add(new Label
            {
                Text = "Registrar ausencia o permiso",
                AutoSize = false,
                Location = new Point(20, y),
                Size = new Size(460, 28),
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.FromArgb(250, 204, 21)
            });
            y += 46;

            Controls.Add(Etiqueta("Empleado *", y)); y += 24;
            Entrada(cmbEmpleado, y); cmbEmpleado.DropDownStyle = ComboBoxStyle.DropDownList; cmbEmpleado.FlatStyle = FlatStyle.Flat;
            Controls.Add(cmbEmpleado); y += 50;

            Controls.Add(Etiqueta("Tipo *", y)); y += 24;
            Entrada(cmbTipo, y); cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList; cmbTipo.FlatStyle = FlatStyle.Flat;
            cmbTipo.Items.AddRange(new object[] { "Falta", "Permiso", "Incapacidad" });
            Controls.Add(cmbTipo); y += 50;

            Controls.Add(Etiqueta("Desde *", y));
            Controls.Add(new Label { Text = "Hasta *", AutoSize = false, Location = new Point(260, y), Size = new Size(200, 22), ForeColor = Soft });
            y += 24;
            Fecha(dtpDesde, 20, y); Fecha(dtpHasta, 260, y);
            Controls.Add(dtpDesde); Controls.Add(dtpHasta); y += 46;

            chkJustificada.Text = "Justificada (tiene comprobante o autorización)";
            chkJustificada.Location = new Point(20, y); chkJustificada.Size = new Size(460, 24);
            chkJustificada.ForeColor = Color.White;
            Controls.Add(chkJustificada); y += 28;

            chkConGoce.Text = "Con goce de sueldo (solo permisos: si no se marca, se descuenta)";
            chkConGoce.Location = new Point(20, y); chkConGoce.Size = new Size(460, 24);
            chkConGoce.ForeColor = Color.White;
            Controls.Add(chkConGoce); y += 40;

            Controls.Add(Etiqueta("Motivo (opcional)", y)); y += 24;
            Entrada(txtMotivo, y); txtMotivo.Multiline = true; txtMotivo.Height = 64; txtMotivo.MaxLength = 300;
            txtMotivo.ScrollBars = ScrollBars.Vertical;
            BarrasOscuras.Aplicar(txtMotivo);
            Controls.Add(txtMotivo); y += 80;

            // Resumen en vivo: cuántos días hábiles son y si se descuentan
            lblResumen.Location = new Point(20, y); lblResumen.Size = new Size(460, 44);
            lblResumen.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblResumen.ForeColor = Soft;
            Controls.Add(lblResumen); y += 56;

            Button btnGuardar = Boton("Registrar", 20, y, 200, 38, Color.FromArgb(250, 204, 21), Color.Black);
            btnGuardar.Click += Guardar;
            Controls.Add(btnGuardar);

            Button btnCancelar = Boton("Cancelar", 230, y, 110, 38, Color.FromArgb(60, 63, 80), Color.White);
            btnCancelar.DialogResult = DialogResult.Cancel;
            Controls.Add(btnCancelar);
            CancelButton = btnCancelar;

            // Los combos se llenan en Load (con la ventana ya lista, el enlace de datos funciona bien)
            Load += (s, e) => Iniciar();
        }

        private void Iniciar()
        {
            DataTable emp = Datos.Tabla(
                @"SELECT e.IdEmpleado, e.Nombre + N' · ' + c.NombreCargo AS Descripcion, ISNULL(p.SalarioBase, 0) AS SalarioBase
                  FROM Empleados e
                  JOIN Cargos c         ON c.IdCargo = e.IdCargo
                  LEFT JOIN Planillas p ON p.IdPlanilla = e.IdPlanilla
                  WHERE e.IdEstado <> 2
                  ORDER BY e.Nombre");
            cmbEmpleado.DisplayMember = "Descripcion";
            cmbEmpleado.ValueMember = "IdEmpleado";
            cmbEmpleado.DataSource = emp;
            cmbEmpleado.SelectedIndex = -1;

            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today;
            cmbTipo.SelectedIndex = 0;          // Falta

            cmbEmpleado.SelectedIndexChanged += (s, e) => { ep.SetError(cmbEmpleado, ""); ActualizarResumen(); };
            cmbTipo.SelectedIndexChanged += (s, e) => AjustarReglas();
            chkJustificada.CheckedChanged += (s, e) => ActualizarResumen();
            chkConGoce.CheckedChanged += (s, e) => ActualizarResumen();
            dtpDesde.ValueChanged += (s, e) =>
            {
                if (dtpHasta.Value.Date < dtpDesde.Value.Date) dtpHasta.Value = dtpDesde.Value;   // Hasta nunca antes que Desde
                ActualizarResumen();
            };
            dtpHasta.ValueChanged += (s, e) => ActualizarResumen();

            cargando = false;
            AjustarReglas();
        }

        // Qué casillas se pueden tocar según el tipo (igual que en la base de datos):
        //  - Falta:        se elige si es justificada; nunca tiene goce de sueldo
        //  - Permiso:      siempre es una ausencia autorizada; se elige si es con goce
        //  - Incapacidad:  siempre justificada y con goce
        private void AjustarReglas()
        {
            string tipo = cmbTipo.Text;
            if (tipo == "Falta")
            {
                chkJustificada.Enabled = true;
                chkConGoce.Checked = false; chkConGoce.Enabled = false;
            }
            else if (tipo == "Permiso")
            {
                chkJustificada.Checked = true; chkJustificada.Enabled = false;
                chkConGoce.Enabled = true;
            }
            else
            {
                chkJustificada.Checked = true; chkJustificada.Enabled = false;
                chkConGoce.Checked = true; chkConGoce.Enabled = false;
            }
            ActualizarResumen();
        }

        private bool Descuenta()
        {
            string tipo = cmbTipo.Text;
            return (tipo == "Falta" && !chkJustificada.Checked) || (tipo == "Permiso" && !chkConGoce.Checked);
        }

        private void ActualizarResumen()
        {
            if (cargando) return;
            if (cmbEmpleado.SelectedIndex < 0) { lblResumen.ForeColor = Soft; lblResumen.Text = "Seleccione un empleado."; return; }

            try
            {
                // Los días hábiles (lunes a viernes) los calcula la misma función que usa la planilla
                int dias = Convert.ToInt32(Datos.Escalar("SELECT dbo.fn_DiasHabiles(@i, @f)",
                    Datos.P("@i", dtpDesde.Value.Date), Datos.P("@f", dtpHasta.Value.Date)));
                string txt = dias + (dias == 1 ? " día hábil" : " días hábiles") + " (lunes a viernes)";

                if (Descuenta())
                {
                    decimal salario = Convert.ToDecimal(((DataRowView)cmbEmpleado.SelectedItem)["SalarioBase"]);
                    DateTime iniMes = new DateTime(dtpDesde.Value.Year, dtpDesde.Value.Month, 1);
                    int habilesMes = Convert.ToInt32(Datos.Escalar("SELECT dbo.fn_DiasHabiles(@i, EOMONTH(@i))",
                        Datos.P("@i", iniMes)));
                    decimal valorDia = Math.Round(salario / Math.Max(1, habilesMes), 2, MidpointRounding.AwayFromZero);
                    txt += "\nSe descuenta del salario: aprox. $" + (valorDia * dias).ToString("N2", Inv) +
                           " (valor del día $" + valorDia.ToString("N2", Inv) + ")";
                    lblResumen.ForeColor = Color.FromArgb(251, 191, 36);
                }
                else
                {
                    txt += "\nNo se descuenta del salario.";
                    lblResumen.ForeColor = Color.FromArgb(74, 222, 128);
                }
                lblResumen.Text = txt;
            }
            catch
            {
                lblResumen.ForeColor = Soft;
                lblResumen.Text = "";
            }
        }

        private void Guardar(object sender, EventArgs e)
        {
            ep.Clear();
            if (cmbEmpleado.SelectedIndex < 0) { ep.SetError(cmbEmpleado, "Seleccione un empleado."); return; }
            if (dtpHasta.Value.Date < dtpDesde.Value.Date) { ep.SetError(dtpHasta, "La fecha final no puede ser anterior a la inicial."); return; }

            try
            {
                string usuario = string.IsNullOrWhiteSpace(Sesion.Usuario) ? Environment.UserName : Sesion.Usuario;
                Datos.Procedimiento("sp_RegistrarAusencia",
                    Datos.P("@IdEmpleado", Convert.ToInt32(cmbEmpleado.SelectedValue)),
                    Datos.P("@Tipo", cmbTipo.Text),
                    Datos.P("@FechaInicio", dtpDesde.Value.Date),
                    Datos.P("@FechaFin", dtpHasta.Value.Date),
                    Datos.P("@Justificada", chkJustificada.Checked),
                    Datos.P("@ConGoce", chkConGoce.Checked),
                    Datos.PTexto("@Motivo", txtMotivo.Text),
                    Datos.P("@Usuario", usuario));

                DialogResult = DialogResult.OK;
            }
            catch (SqlException ex)
            {
                // Los mensajes del procedimiento ya vienen en español (fechas cruzadas, empleado inactivo, etc.)
                MessageBox.Show(ex.Message, "No se pudo registrar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---- ayudas de diseño ----
        private Label Etiqueta(string texto, int y)
        {
            return new Label { Text = texto, AutoSize = false, Location = new Point(20, y), Size = new Size(220, 22), ForeColor = Soft };
        }

        private static void Entrada(Control c, int y)
        {
            c.Location = new Point(20, y);
            c.Width = 460;
            c.BackColor = Color.FromArgb(40, 42, 58);
            c.ForeColor = Color.White;
            c.Font = new Font("Segoe UI", 10.5F);
        }

        private static void Fecha(DateTimePicker d, int x, int y)
        {
            d.Location = new Point(x, y);
            d.Width = 220;
            d.Format = DateTimePickerFormat.Short;
            d.Font = new Font("Segoe UI", 10.5F);
        }

        private static Button Boton(string texto, int x, int y, int w, int h, Color fondo, Color letra)
        {
            Button b = new Button
            {
                Text = texto,
                Location = new Point(x, y),
                Size = new Size(w, h),
                FlatStyle = FlatStyle.Flat,
                BackColor = fondo,
                ForeColor = letra,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold)
            };
            b.FlatAppearance.BorderSize = 0;
            return b;
        }
    }
}