using Modelos;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Vistass
{
    // Ventana para generar la planilla de un mes: muestra una vista previa
    // (cuántos pagos se crearán) y luego los crea con sp_GenerarPlanilla.
    public class frmGenerarPlanilla : Form
    {
        private static readonly CultureInfo Es = new CultureInfo("es-ES");
        private static readonly CultureInfo Inv = CultureInfo.InvariantCulture;
        private static readonly Color Soft = Color.FromArgb(170, 180, 200);

        private readonly ComboOscuro cmbMes = new ComboOscuro();
        private readonly Label lblResumen = new Label();
        private readonly Button btnGenerar;
        private readonly string claveInicial;     // "yyyy-MM" del mes que se estaba viendo (puede ser null)
        private bool cargando = true;

        // Mes que se generó ("yyyy-MM"): la pantalla de planillas lo usa para mostrarlo al volver
        public string ClavePeriodo { get; private set; }

        public frmGenerarPlanilla(string claveInicial)
        {
            this.claveInicial = claveInicial;

            Text = "Generar planilla";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false; MinimizeBox = false; ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.FromArgb(27, 29, 38);
            ForeColor = Color.White;
            Font = new Font("Segoe UI", 9.5F);
            ClientSize = new Size(500, 400);

            Controls.Add(new Label
            {
                Text = "Generar planilla del mes",
                AutoSize = false,
                Location = new Point(20, 16),
                Size = new Size(460, 28),
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.FromArgb(250, 204, 21)
            });
            Controls.Add(new Label
            {
                Text = "Crea un pago Pendiente por cada empleado activo, con su salario, bono y descuentos " +
                       "de ley, más el descuento por ausencias de ese mes.",
                AutoSize = false,
                Location = new Point(20, 52),
                Size = new Size(460, 40),
                ForeColor = Soft
            });

            Controls.Add(new Label { Text = "Mes *", AutoSize = false, Location = new Point(20, 104), Size = new Size(200, 22), ForeColor = Soft });
            cmbMes.Font = new Font("Segoe UI", 10.5F);
            cmbMes.Location = new Point(20, 128); cmbMes.Size = new Size(460, 30);
            Controls.Add(cmbMes);

            // Resumen en vivo (vista previa)
            lblResumen.Location = new Point(20, 176); lblResumen.Size = new Size(460, 150);
            lblResumen.Font = new Font("Segoe UI", 10F);
            lblResumen.ForeColor = Color.White;
            Controls.Add(lblResumen);

            btnGenerar = Boton("Generar planilla", 20, 340, 200, 38, Color.FromArgb(250, 204, 21), Color.Black);
            btnGenerar.Click += Generar;
            Controls.Add(btnGenerar);

            Button btnCancelar = Boton("Cancelar", 230, 340, 110, 38, Color.FromArgb(60, 63, 80), Color.White);
            btnCancelar.DialogResult = DialogResult.Cancel;
            Controls.Add(btnCancelar);
            CancelButton = btnCancelar;

            // El combo se llena en Load (con la ventana lista, el enlace de datos funciona bien)
            Load += (s, e) => Iniciar();
        }

        private void Iniciar()
        {
            // Mes actual y los 11 anteriores (no se generan meses futuros)
            DataTable t = new DataTable();
            t.Columns.Add("Fecha", typeof(DateTime));
            t.Columns.Add("Texto", typeof(string));
            DateTime actual = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            for (int i = 0; i < 12; i++)
            {
                DateTime m = actual.AddMonths(-i);
                string s = m.ToString("MMMM yyyy", Es);
                t.Rows.Add(m, char.ToUpper(s[0]) + s.Substring(1));
            }
            cmbMes.DisplayMember = "Texto";
            cmbMes.ValueMember = "Fecha";
            cmbMes.DataSource = t;

            // Si en la pantalla se estaba viendo un mes concreto, se propone ese
            int idx = 0;
            if (!string.IsNullOrEmpty(claveInicial))
                for (int i = 0; i < t.Rows.Count; i++)
                    if (((DateTime)t.Rows[i]["Fecha"]).ToString("yyyy-MM", Inv) == claveInicial) { idx = i; break; }
            cmbMes.SelectedIndex = idx;

            cmbMes.SelectedIndexChanged += (s, e) => VistaPrevia();
            cargando = false;
            VistaPrevia();
        }

        private DateTime MesElegido()
        {
            return (DateTime)((DataRowView)cmbMes.SelectedItem)["Fecha"];
        }

        private static string Usuario()
        {
            return string.IsNullOrWhiteSpace(Sesion.Usuario) ? "sistema" : Sesion.Usuario;
        }

        // Pregunta al procedimiento (en modo simulación) qué pasaría, sin crear nada
        private void VistaPrevia()
        {
            if (cargando || cmbMes.SelectedItem == null) return;
            try
            {
                DataRow r = Datos.Tabla(
                    "EXEC dbo.sp_GenerarPlanilla @Periodo = @p, @Usuario = @u, @Simular = 1",
                    Datos.P("@p", MesElegido()), Datos.P("@u", Usuario())).Rows[0];

                int gen = Convert.ToInt32(r["Generados"]);
                int ya = Convert.ToInt32(r["YaExistian"]);
                int sin = Convert.ToInt32(r["SinSalario"]);
                bool cerrado = Convert.ToInt32(r["Cerrado"]) == 1;
                string nombres = Convert.ToString(r["NombresSinSalario"]);

                string txt = "Se generarán:  " + gen + (gen == 1 ? " pago" : " pagos") + "\n" +
                             "Ya tenían pago ese mes (no se tocan):  " + ya;
                if (sin > 0)
                {
                    if (nombres.Length > 150) nombres = nombres.Substring(0, 150) + "…";
                    txt += "\nSin salario asignado (se omiten):  " + sin + "\n" + nombres;
                }

                if (cerrado)
                {
                    txt = "Este mes está CERRADO: no se puede generar.\n\n" + txt;
                    lblResumen.ForeColor = Color.FromArgb(248, 113, 113);
                }
                else lblResumen.ForeColor = Color.White;

                lblResumen.Text = txt;
                btnGenerar.Enabled = !cerrado && gen > 0;
            }
            catch (Exception ex)
            {
                lblResumen.ForeColor = Color.FromArgb(248, 113, 113);
                lblResumen.Text = "No se pudo calcular la vista previa:\n" + ex.Message;
                btnGenerar.Enabled = false;
            }
        }

        private void Generar(object sender, EventArgs e)
        {
            DateTime mes = MesElegido();
            string texto = cmbMes.Text;

            if (MessageBox.Show("¿Generar la planilla de " + texto + "?\n\n" +
                                "Se crearán los pagos pendientes. Podrá editarlos uno por uno antes de pagarlos.",
                                "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                DataRow r = Datos.Tabla(
                    "EXEC dbo.sp_GenerarPlanilla @Periodo = @p, @Usuario = @u, @Simular = 0",
                    Datos.P("@p", mes), Datos.P("@u", Usuario())).Rows[0];

                int gen = Convert.ToInt32(r["Generados"]);
                int ya = Convert.ToInt32(r["YaExistian"]);
                int sin = Convert.ToInt32(r["SinSalario"]);

                string msg = "Planilla de " + texto + " generada.\n\n" +
                             "Pagos creados:  " + gen + "\n" +
                             "Ya existían:  " + ya;
                if (sin > 0) msg += "\nOmitidos por no tener salario asignado:  " + sin;

                MessageBox.Show(msg, "Planilla generada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClavePeriodo = mes.ToString("yyyy-MM", Inv);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "No se pudo generar la planilla", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static Button Boton(string texto, int x, int y, int ancho, int alto, Color fondo, Color letra)
        {
            Button b = new Button
            {
                Text = texto,
                Location = new Point(x, y),
                Size = new Size(ancho, alto),
                FlatStyle = FlatStyle.Flat,
                BackColor = fondo,
                ForeColor = letra,
                Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            b.FlatAppearance.BorderSize = 0;
            return b;
        }
    }
}