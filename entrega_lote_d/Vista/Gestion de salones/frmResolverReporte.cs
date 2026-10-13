using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Modelos;

namespace Vistass
{
    // Ventana pequeña para CERRAR un reporte. Se usa de dos maneras:
    //   - Marcar reparado: el usuario elige el estado final (Bueno, Excelente...), el costo y que se hizo.
    //   - Dar de baja:     el estado queda fijo en 'Dado de baja'; solo se pide el motivo.
    public class frmResolverReporte : Form
    {
        // Lo que el formulario principal lee cuando el usuario acepta
        public int IdEstado { get; private set; }
        public decimal Costo { get; private set; }
        public string Texto { get; private set; }

        private readonly ComboOscuro cmbEstado = new ComboOscuro();
        private readonly NumericUpDown numCosto = new NumericUpDown();
        private readonly TextBox txtDescripcion = new TextBox();
        private readonly ErrorProvider ep = new ErrorProvider();
        private readonly bool darDeBaja;

        public frmResolverReporte(string titulo, string equipo, bool darDeBaja)
        {
            Text = titulo;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false; MinimizeBox = false; ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.FromArgb(27, 29, 38);
            ForeColor = Color.White;
            Font = new Font("Segoe UI", 9.5F);
            ClientSize = new Size(480, darDeBaja ? 330 : 410);
            ep.ContainerControl = this;

            int y = 16;

            // Que equipo se esta cerrando (en amarillo para que no haya dudas)
            Controls.Add(new Label
            {
                Text = equipo,
                AutoSize = false,
                Location = new Point(20, y),
                Size = new Size(440, 26),
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(250, 204, 21)
            });
            y += 44;

            // ---- Estado final de la unidad ----
            Controls.Add(Etiqueta(darDeBaja ? "Estado final de la unidad" : "Estado en que queda la unidad", y));
            y += 24;
            ConfigurarEntrada(cmbEstado, y);
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.FlatStyle = FlatStyle.Flat;
            Controls.Add(cmbEstado);

            // Los estados se cargan cuando la ventana ya está lista (evento Load).
            // Si se cargan en el constructor, el combo todavía no puede enlazar sus datos.
            this.darDeBaja = darDeBaja;
            Load += (s, e) => CargarEstados(this.darDeBaja);
            y += 48;

            // ---- Costo (solo al reparar) ----
            if (!darDeBaja)
            {
                Controls.Add(Etiqueta("Costo del servicio ($)", y));
                y += 24;
                ConfigurarEntrada(numCosto, y);
                numCosto.DecimalPlaces = 2;
                numCosto.Maximum = 1000000;
                numCosto.ThousandsSeparator = true;
                numCosto.BorderStyle = BorderStyle.FixedSingle;
                Controls.Add(numCosto);
                y += 48;
            }

            // ---- Descripcion ----
            Controls.Add(Etiqueta(darDeBaja ? "Motivo de la baja" : "¿Qué se hizo para repararlo?", y));
            y += 24;
            ConfigurarEntrada(txtDescripcion, y);
            txtDescripcion.Multiline = true;
            txtDescripcion.Height = 90;
            txtDescripcion.MaxLength = 500;
            txtDescripcion.ScrollBars = ScrollBars.Vertical;
            BarrasOscuras.Aplicar(txtDescripcion);
            Controls.Add(txtDescripcion);
            y += 106;

            // ---- Botones ----
            Button btnAceptar = new Button
            {
                Text = darDeBaja ? "Dar de baja" : "Marcar reparado",
                Location = new Point(20, y),
                Size = new Size(200, 38),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                BackColor = darDeBaja ? Color.FromArgb(220, 38, 38) : Color.FromArgb(250, 204, 21),
                ForeColor = darDeBaja ? Color.White : Color.Black
            };
            btnAceptar.FlatAppearance.BorderSize = 0;
            btnAceptar.Click += Aceptar;

            Button btnCancelar = new Button
            {
                Text = "Cancelar",
                DialogResult = DialogResult.Cancel,
                Location = new Point(230, y),
                Size = new Size(110, 38),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                BackColor = Color.FromArgb(60, 63, 80),
                ForeColor = Color.White
            };
            btnCancelar.FlatAppearance.BorderSize = 0;

            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            CancelButton = btnCancelar;       // Esc cierra la ventana
        }

        private Label Etiqueta(string texto, int y)
        {
            return new Label
            {
                Text = texto,
                AutoSize = false,
                Location = new Point(20, y),
                Size = new Size(440, 22),
                ForeColor = Color.FromArgb(170, 180, 200)
            };
        }

        private static void ConfigurarEntrada(Control c, int y)
        {
            c.Location = new Point(20, y);
            c.Width = 440;
            c.BackColor = Color.FromArgb(40, 42, 58);
            c.ForeColor = Color.White;
            c.Font = new Font("Segoe UI", 10.5F);
        }

        // Al reparar solo se ofrecen estados "buenos": una unidad reparada no puede quedar en 'Malo'.
        // Al dar de baja el unico estado posible es 'Dado de baja'.
        private void CargarEstados(bool darDeBaja)
        {
            DataTable dt = Datos.Tabla(darDeBaja
                ? "SELECT IdEstado, NombreEstado FROM Estados WHERE NombreEstado = 'Dado de baja'"
                : @"SELECT IdEstado, NombreEstado FROM Estados
                    WHERE NombreEstado NOT IN ('Malo', 'En reparación', 'Mantenimiento Pendiente', 'Dado de baja')
                    ORDER BY IdEstado");

            cmbEstado.DisplayMember = "NombreEstado";
            cmbEstado.ValueMember = "IdEstado";
            cmbEstado.DataSource = dt;

            if (cmbEstado.Items.Count == 0)
            {
                // No hay estados que ofrecer: se avisa junto al combo en lugar de fallar
                ep.SetError(cmbEstado, "No hay estados disponibles en la tabla Estados.");
                return;
            }

            int bueno = cmbEstado.FindStringExact("Bueno");   // 'Bueno' preseleccionado al reparar
            cmbEstado.SelectedIndex = bueno >= 0 ? bueno : 0;
            cmbEstado.Enabled = !darDeBaja;                   // en la baja no hay nada que elegir
        }
        private void Aceptar(object sender, EventArgs e)
        {
            ep.Clear();

            if (txtDescripcion.Text.Trim().Length < 5)
            {
                ep.SetError(txtDescripcion, "Escriba una descripción (mínimo 5 caracteres).");
                return;
            }
            if (cmbEstado.SelectedValue == null)
            {
                ep.SetError(cmbEstado, "Seleccione el estado final.");
                return;
            }

            // Se guardan los valores en propiedades: el formulario principal las lee al cerrarse la ventana
            IdEstado = Convert.ToInt32(cmbEstado.SelectedValue);
            Costo = numCosto.Value;
            Texto = txtDescripcion.Text.Trim();
            DialogResult = DialogResult.OK;
        }
    }
}