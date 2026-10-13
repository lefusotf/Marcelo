
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Modelos;

namespace Vistass
{
    public partial class frmGestionPlanillas : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        private static readonly CultureInfo Es = new CultureInfo("es-ES");

        private DataTable dtPagos;
        private DataView vista;
        private bool cargando = false;
        private bool esAdmin = false;

        public frmGestionPlanillas()
        {
            InitializeComponent();
        }

        private void frmGestionPlanillas_Load(object sender, EventArgs e)
        {

            esAdmin = Sesion.Rol != null && Sesion.Rol.Trim().Equals("Administrador", StringComparison.OrdinalIgnoreCase);

            toolTip1.SetToolTip(btnGenerarPlanilla, "Crear de una vez los pagos pendientes de todos los empleados activos del mes");
            toolTip1.SetToolTip(btnCierrePeriodo, "Cerrar el mes (bloquea pagos y ausencias) o reabrirlo (solo administrador)");
            toolTip1.SetToolTip(btnNuevoPago, "Registrar el pago de un empleado");
            toolTip1.SetToolTip(btnEditarPago, "Editar el pago seleccionado (solo pagos pendientes)");
            toolTip1.SetToolTip(btnMarcarPagado, "Marcar como pagado el pago seleccionado");
            toolTip1.SetToolTip(btnAnularPago, "Anular el pago seleccionado (queda en el historial)");
            toolTip1.SetToolTip(btnExportarPdf, "Exportar lo que se está viendo (PDF o Excel)");
            toolTip1.SetToolTip(cmbPeriodo, "Filtrar por mes de pago");
            toolTip1.SetToolTip(cmbEstadoPago, "Filtrar por estado de pago");
            toolTip1.SetToolTip(btnBoleta, "Genera la boleta de pago (comprobante) del pago seleccionado en PDF");



            cargando = true;
            cmbEstadoPago.Items.AddRange(new object[] { "Todos los estados", "Pendiente", "Pagado" });
            cmbEstadoPago.SelectedIndex = 0;
            cargando = false;

            MostrarPagos(null);
            ActualizarBotones();
        }


        private void MostrarPagos(string forzarClave)
        {
            try
            {
                dtPagos = Datos.Tabla(
                    @"SELECT IdPago, IdEmpleado, Empleado, Cargo, Periodo, PeriodoClave, SalarioBase, Bono,
                                                         Descuento, SalarioNeto, EstadoPago, FechaPago, Observacion, PeriodoCerrado
                      FROM vw_PagosPlanillaDetalle
                      WHERE Anulado = 0
                      ORDER BY Periodo DESC, Empleado");

                CargarPeriodos(forzarClave);

                vista = new DataView(dtPagos);
                dgvPagos.DataSource = vista;
                FormatearGrid();
                AplicarFiltro();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar las planillas: " + ex.Message, "Error SQL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // meses que tienen pagos; al abrir se elige el mes actual si existe
        private void CargarPeriodos(string forzarClave)
        {
            string previo = cmbPeriodo.SelectedValue as string;
            string actual = DateTime.Today.ToString("yyyy-MM", CultureInfo.InvariantCulture);

            DataTable t = new DataTable();
            t.Columns.Add("Clave", typeof(string));
            t.Columns.Add("Texto", typeof(string));
            t.Rows.Add("", "Todos los períodos");

            HashSet<string> vistos = new HashSet<string>();
            foreach (DataRow r in dtPagos.Rows)
            {
                string clave = Convert.ToString(r["PeriodoClave"]);
                if (!vistos.Add(clave)) continue;
                t.Rows.Add(clave, TextoPeriodo((DateTime)r["Periodo"]));
            }

            string quiero = forzarClave ?? previo ?? actual;
            if (quiero != "" && !vistos.Contains(quiero)) quiero = "";

            cargando = true;
            cmbPeriodo.DataSource = t;
            cmbPeriodo.DisplayMember = "Texto";
            cmbPeriodo.ValueMember = "Clave";
            cmbPeriodo.SelectedValue = quiero;
            cargando = false;
        }

        private static string TextoPeriodo(DateTime d)
        {
            string s = d.ToString("MMMM yyyy", Es);
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        private void FormatearGrid()
        {
            if (dgvPagos.Columns.Count == 0) return;

            dgvPagos.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

            foreach (string oculta in new[] { "IdEmpleado", "PeriodoClave", "PeriodoCerrado" })
                if (dgvPagos.Columns.Contains(oculta)) dgvPagos.Columns[oculta].Visible = false;

            // Anchos fijos para que ningún título se parta ni se corte; "Observación" absorbe el espacio sobrante
            dgvPagos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            Columna("IdPago", "N°", 45);
            Columna("Empleado", "Empleado", 200);
            Columna("Cargo", "Cargo", 135);
            Columna("Periodo", "Período", 125);
            Columna("SalarioBase", "Base", 85);
            Columna("Bono", "Bono", 70);
            Columna("Descuento", "Descuento", 95);
            Columna("SalarioNeto", "Neto", 85);
            Columna("EstadoPago", "Estado", 95);
            Columna("FechaPago", "Fecha pago", 110);
            Columna("Observacion", "Observación", 120);

            DataGridViewColumn obs = dgvPagos.Columns["Observacion"];
            obs.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            obs.MinimumWidth = 100;

            DataGridViewColumn per = dgvPagos.Columns["Periodo"];
            per.DefaultCellStyle.Format = "MMMM yyyy";
            per.DefaultCellStyle.FormatProvider = Es;
            dgvPagos.Columns["FechaPago"].DefaultCellStyle.Format = "dd/MM/yyyy";

            // montos alineados a la derecha
            foreach (string m in new[] { "SalarioBase", "Bono", "Descuento", "SalarioNeto" })
            {
                DataGridViewColumn c = dgvPagos.Columns[m];
                c.DefaultCellStyle.Format = "N2";
                c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            dgvPagos.Columns["SalarioNeto"].DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        }

        private void Columna(string nombre, string encabezado, int ancho)
        {
            if (!dgvPagos.Columns.Contains(nombre)) return;
            dgvPagos.Columns[nombre].HeaderText = encabezado;
            dgvPagos.Columns[nombre].Width = ancho;
        }

        // El estado se dibuja como una cápsula: verde si está pagado, ámbar si está pendiente
        private void dgvPagos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || dgvPagos.Columns[e.ColumnIndex].Name != "EstadoPago") return;

            e.Paint(e.CellBounds, e.PaintParts & ~DataGridViewPaintParts.ContentForeground);
            e.Handled = true;

            string estado = Convert.ToString(e.Value);
            if (estado.Length == 0) return;

            bool pagado = estado == "Pagado";
            Color baseColor = pagado ? Color.FromArgb(34, 197, 94) : Color.FromArgb(245, 158, 11);
            Color letra = pagado ? Color.FromArgb(134, 239, 172) : Color.FromArgb(252, 211, 77);

            using (Font f = new Font("Segoe UI Semibold", 9F, FontStyle.Bold))
            {
                Size t = TextRenderer.MeasureText(e.Graphics, estado, f, new Size(int.MaxValue, int.MaxValue), TextFormatFlags.NoPadding);
                int alto = 22;
                Rectangle r = new Rectangle(e.CellBounds.Left + 8, e.CellBounds.Top + (e.CellBounds.Height - alto) / 2, t.Width + 22, alto);

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath p = Pastilla(r))
                using (SolidBrush b = new SolidBrush(Color.FromArgb(55, baseColor)))
                    e.Graphics.FillPath(b, p);

                TextRenderer.DrawText(e.Graphics, estado, f, r, letra,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
            }
        }

        private static GraphicsPath Pastilla(Rectangle r)
        {
            int d = r.Height;
            GraphicsPath p = new GraphicsPath();
            p.AddArc(r.X, r.Y, d, d, 90, 180);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 180);
            p.CloseFigure();
            return p;
        }

        // Etiqueta redondeada de la franja de resumen
        private sealed class Chip : Control
        {
            private readonly Color baseColor;
            private readonly Color letra;

            public Chip(string texto, Color baseColor, Color letra)
            {
                this.baseColor = baseColor;
                this.letra = letra;
                SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                         ControlStyles.SupportsTransparentBackColor, true);
                BackColor = Color.Transparent;
                Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
                Text = texto;
                Size t = TextRenderer.MeasureText(texto, Font, new Size(int.MaxValue, int.MaxValue), TextFormatFlags.NoPadding);
                Size = new Size(t.Width + 26, 28);
                Margin = new Padding(0, 0, 8, 6);
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle r = new Rectangle(0, 0, Width - 1, Height - 1);
                using (GraphicsPath p = Pastilla(r))
                {
                    using (SolidBrush b = new SolidBrush(Color.FromArgb(55, baseColor)))
                        e.Graphics.FillPath(b, p);
                    using (Pen borde = new Pen(Color.FromArgb(90, baseColor)))
                        e.Graphics.DrawPath(borde, p);
                }
                TextRenderer.DrawText(e.Graphics, Text, Font, new Rectangle(0, 0, Width, Height), letra,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
            }
        }

        private void AgregarChip(string texto, Color baseColor, Color letra)
        {
            flpResumen.Controls.Add(new Chip(texto, baseColor, letra));
        }

        private static void VaciarChips(FlowLayoutPanel panel)
        {
            while (panel.Controls.Count > 0)
            {
                Control c = panel.Controls[0];
                panel.Controls.RemoveAt(0);
                c.Dispose();
            }
        }

        // ---------------------------------------------------------------
        //  Búsqueda y filtros (en vivo, sin ir a la base de datos)
        // ---------------------------------------------------------------
        private static string Escapar(string t)
        {
            return t.Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("*", "[*]");
        }

        private void AplicarFiltro()
        {
            if (vista == null) return;
            var cond = new List<string>();

            string t = txtBuscar.Text.Trim();
            if (t.Length > 0)
            {
                string esc = Escapar(t);
                cond.Add("(Empleado LIKE '%" + esc + "%' OR Cargo LIKE '%" + esc + "%')");
            }

            string clave = cmbPeriodo.SelectedValue as string;
            if (!string.IsNullOrEmpty(clave)) cond.Add("PeriodoClave = '" + clave + "'");

            if (cmbEstadoPago.SelectedIndex > 0) cond.Add("EstadoPago = '" + cmbEstadoPago.SelectedItem + "'");

            vista.RowFilter = string.Join(" AND ", cond);
            // Totales de lo que se está viendo (siguen a los filtros) para las tarjetas de resumen
            decimal total = 0, pendiente = 0;
            int nPendientes = 0;
            foreach (DataRowView r in vista)
            {
                decimal neto = Convert.ToDecimal(r["SalarioNeto"]);
                total += neto;
                if (Convert.ToString(r["EstadoPago"]) == "Pendiente") { pendiente += neto; nPendientes++; }
            }
            int nPagados = vista.Count - nPendientes;

            // Franja de resumen (sigue a los filtros): solo lo que ayuda a decidir
            flpResumen.SuspendLayout();
            VaciarChips(flpResumen);
            AgregarChip(vista.Count + (vista.Count == 1 ? " pago" : " pagos"), Color.FromArgb(96, 165, 250), Color.FromArgb(147, 197, 253));
            AgregarChip(nPagados + (nPagados == 1 ? " pagado" : " pagados"), Color.FromArgb(34, 197, 94), Color.FromArgb(134, 239, 172));
            if (nPendientes > 0)
                AgregarChip(nPendientes + (nPendientes == 1 ? " pendiente" : " pendientes"), Color.FromArgb(245, 158, 11), Color.FromArgb(252, 211, 77));
            AgregarChip("Neto $" + total.ToString("N2"), Color.FromArgb(148, 163, 184), Color.FromArgb(203, 213, 225));
            if (pendiente > 0)
                AgregarChip("Por pagar $" + pendiente.ToString("N2"), Color.FromArgb(245, 158, 11), Color.FromArgb(252, 211, 77));
            else
                AgregarChip("Todo al día", Color.FromArgb(34, 197, 94), Color.FromArgb(134, 239, 172));
            flpResumen.ResumeLayout();

            ActualizarBotones();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            lblBuscarHint.Visible = txtBuscar.Text.Length == 0;
            AplicarFiltro();
        }

        // lupa dibujada dentro del buscador
        private void pnlLupa_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen p = new Pen(PaletaSistema.Tenue, 1.8f))
            {
                p.StartCap = LineCap.Round;
                p.EndCap = LineCap.Round;
                e.Graphics.DrawEllipse(p, 8, 6, 9, 9);
                e.Graphics.DrawLine(p, 15.5f, 13.5f, 19f, 17f);
            }
        }

        // borde del buscador: amarillo al enfocarse
        private void pnlBuscador_Paint(object sender, PaintEventArgs e)
        {
            Color borde = txtBuscar.Focused ? PaletaSistema.Amarillo : Color.FromArgb(60, 66, 88);
            using (Pen p = new Pen(borde))
                e.Graphics.DrawRectangle(p, 0, 0, pnlBuscador.Width - 1, pnlBuscador.Height - 1);
        }

        private void txtBuscar_FocoCambiado(object sender, EventArgs e)
        {
            pnlBuscador.Invalidate();
        }

        // el texto de ayuda está encima de la caja: un clic sobre él enfoca la caja
        private void lblBuscarHint_Click(object sender, EventArgs e)
        {
            txtBuscar.Focus();
        }
        private void cmbPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargando) return;
            AplicarFiltro();
        }

        private void cmbEstadoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargando) return;
            AplicarFiltro();
        }

        // ---------------------------------------------------------------
        //  Selección y botones
        // ---------------------------------------------------------------
        private void dgvPagos_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarBotones();
        }

        private void ActualizarBotones()
        {
            bool haySeleccion = dgvPagos.CurrentRow != null && vista != null && vista.Count > 0;
            bool pagado = haySeleccion && Convert.ToString(dgvPagos.CurrentRow.Cells["EstadoPago"].Value) == "Pagado";

            // un pago de un mes cerrado no se puede tocar (la base de datos también lo impide)
            bool filaCerrada = haySeleccion && dgvPagos.Columns.Contains("PeriodoCerrado") &&
                               Convert.ToInt32(dgvPagos.CurrentRow.Cells["PeriodoCerrado"].Value) == 1;

            btnEditarPago.Enabled = haySeleccion && !pagado && !filaCerrada;
            btnMarcarPagado.Enabled = haySeleccion && !pagado && !filaCerrada;
            btnAnularPago.Enabled = haySeleccion && !filaCerrada;
            btnBoleta.Enabled = haySeleccion;

            ActualizarEstadoPeriodo();
        }

        private void dgvPagos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) EditarSeleccionado();
        }

        // ---------------------------------------------------------------
        //  Acciones
        // ---------------------------------------------------------------

        // Boleta de pago del pago seleccionado (un comprobante por empleado y período)
        private void btnBoleta_Click(object sender, EventArgs e)
        {
            if (dgvPagos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un pago de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int idPago = Convert.ToInt32(dgvPagos.CurrentRow.Cells["IdPago"].Value);
            DocumentosPdf.BoletaPago(idPago);
        }
        private void btnNuevoPago_Click(object sender, EventArgs e)
        {
            using (frmRegistrarPago frm = new frmRegistrarPago())
            {
                if (frm.ShowDialog(this) == DialogResult.OK) MostrarPagos(frm.ClavePeriodo);
            }
        }

        private void btnEditarPago_Click(object sender, EventArgs e)
        {
            EditarSeleccionado();
        }

        private void EditarSeleccionado()
        {
            if (dgvPagos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un pago de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Convert.ToString(dgvPagos.CurrentRow.Cells["EstadoPago"].Value) == "Pagado")
            {
                MessageBox.Show("Un pago ya pagado no se puede modificar.\nSi hay un error, anúlelo y regístrelo de nuevo.",
                    "Pago pagado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idPago = Convert.ToInt32(dgvPagos.CurrentRow.Cells["IdPago"].Value);
            using (frmRegistrarPago frm = new frmRegistrarPago(idPago))
            {
                if (frm.ShowDialog(this) == DialogResult.OK) MostrarPagos(frm.ClavePeriodo);
            }
        }

        private void btnMarcarPagado_Click(object sender, EventArgs e)
        {
            if (dgvPagos.CurrentRow == null) return;

            DataGridViewRow fila = dgvPagos.CurrentRow;
            int idPago = Convert.ToInt32(fila.Cells["IdPago"].Value);
            string empleado = Convert.ToString(fila.Cells["Empleado"].Value);
            decimal neto = Convert.ToDecimal(fila.Cells["SalarioNeto"].Value);

            if (MessageBox.Show("¿Marcar como pagado el salario de " + empleado + " ($" + neto.ToString("N2") + ")?",
                "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                Datos.Procedimiento("sp_MarcarPagado", Datos.P("@IdPago", idPago));
                MostrarPagos(null);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "No se pudo marcar como pagado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnularPago_Click(object sender, EventArgs e)
        {
            if (dgvPagos.CurrentRow == null) return;

            DataGridViewRow fila = dgvPagos.CurrentRow;
            int idPago = Convert.ToInt32(fila.Cells["IdPago"].Value);
            string empleado = Convert.ToString(fila.Cells["Empleado"].Value);
            string periodo = TextoPeriodo((DateTime)fila.Cells["Periodo"].Value);

            if (MessageBox.Show("¿Anular el pago de " + empleado + " de " + periodo + "?\n\n" +
                "El pago dejará de verse en la lista, pero quedará registrado como anulado en la base de datos.",
                "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            try
            {
                Datos.Procedimiento("sp_AnularPago", Datos.P("@IdPago", idPago));
                MostrarPagos(null);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "No se pudo anular", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------------------------------------------------------------
        //  Generar planilla y cierre de mes
        // ---------------------------------------------------------------

        // ¿El mes elegido en el filtro "Período" está cerrado? (se deduce de los pagos cargados)
        private bool PeriodoSeleccionadoCerrado()
        {
            string clave = cmbPeriodo.SelectedValue as string;
            if (string.IsNullOrEmpty(clave) || dtPagos == null) return false;
            return dtPagos.Select("PeriodoClave = '" + clave + "' AND PeriodoCerrado = 1").Length > 0;
        }

        // Muestra "MES CERRADO / Mes abierto" y ajusta el botón Cerrar / Reabrir
        private void ActualizarEstadoPeriodo()
        {
            string clave = cmbPeriodo.SelectedValue as string;
            if (string.IsNullOrEmpty(clave))            // "Todos los períodos": no hay un mes concreto
            {
                lblEstadoPeriodo.Text = "";
                btnCierrePeriodo.Text = "Cerrar mes";
                btnCierrePeriodo.Enabled = false;
                return;
            }

            bool cerrado = PeriodoSeleccionadoCerrado();
            lblEstadoPeriodo.Text = cerrado ? "MES CERRADO" : "Mes abierto";
            lblEstadoPeriodo.ForeColor = cerrado ? Color.FromArgb(248, 113, 113) : Color.FromArgb(74, 222, 128);
            btnCierrePeriodo.Text = cerrado ? "Reabrir mes" : "Cerrar mes";
            btnCierrePeriodo.Enabled = !cerrado || esAdmin;     // reabrir: solo administrador
            btnNuevoPago.Enabled = !cerrado;
        }

        private void btnGenerarPlanilla_Click(object sender, EventArgs e)
        {
            using (frmGenerarPlanilla frm = new frmGenerarPlanilla(cmbPeriodo.SelectedValue as string))
            {
                if (frm.ShowDialog(this) == DialogResult.OK) MostrarPagos(frm.ClavePeriodo);
            }
        }

        // Un solo botón: "Cerrar mes" si está abierto, "Reabrir mes" si está cerrado
        private void btnCierrePeriodo_Click(object sender, EventArgs e)
        {
            string clave = cmbPeriodo.SelectedValue as string;
            if (string.IsNullOrEmpty(clave))
            {
                MessageBox.Show("Elija un mes en el filtro \"Período\".", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime periodo = DateTime.ParseExact(clave + "-01", "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string texto = TextoPeriodo(periodo);
            string usuario = string.IsNullOrWhiteSpace(Sesion.Usuario) ? "sistema" : Sesion.Usuario;

            try
            {
                if (!PeriodoSeleccionadoCerrado())
                {
                    if (MessageBox.Show("¿Cerrar la planilla de " + texto + "?\n\n" +
                        "Después no se podrán registrar, modificar ni anular pagos ni ausencias de ese mes, " +
                        "a menos que un administrador lo reabra.",
                        "Cerrar mes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

                    // el procedimiento valida que no queden pagos pendientes
                    Datos.Procedimiento("sp_CerrarPeriodo", Datos.P("@Periodo", periodo), Datos.P("@Usuario", usuario));
                }
                else
                {
                    if (!esAdmin) return;
                    string motivo = PedirMotivo("Reabrir " + texto);
                    if (motivo == null) return;              // canceló

                    Datos.Procedimiento("sp_ReabrirPeriodo", Datos.P("@Periodo", periodo),
                        Datos.P("@Usuario", usuario), Datos.P("@Motivo", motivo));
                }
                MostrarPagos(clave);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "No se pudo completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private string PedirMotivo(string titulo)
        {
            using (Form f = new Form())
            {
                f.Text = titulo;
                f.FormBorderStyle = FormBorderStyle.FixedDialog;
                f.MaximizeBox = false; f.MinimizeBox = false; f.ShowInTaskbar = false;
                f.StartPosition = FormStartPosition.CenterParent;
                f.BackColor = Color.FromArgb(27, 29, 38); f.ForeColor = Color.White;
                f.Font = new Font("Segoe UI", 9.5F);
                f.ClientSize = new Size(440, 230);

                f.Controls.Add(new Label
                {
                    Text = "Motivo de la reapertura (queda en el historial)",
                    AutoSize = false,
                    Location = new Point(20, 16),
                    Size = new Size(400, 22),
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(250, 204, 21)
                });

                TextBox txt = new TextBox
                {
                    Location = new Point(20, 46),
                    Size = new Size(400, 100),
                    Multiline = true,
                    MaxLength = 200,
                    ScrollBars = ScrollBars.Vertical
                };
                f.Controls.Add(txt);

                Button ok = new Button
                {
                    Text = "Reabrir",
                    Location = new Point(20, 168),
                    Size = new Size(150, 38),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.FromArgb(250, 204, 21),
                    ForeColor = Color.Black,
                    Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold)
                };
                ok.FlatAppearance.BorderSize = 0;
                ok.Click += (s, ev) =>
                {
                    if (txt.Text.Trim().Length < 5)
                    {
                        MessageBox.Show("Escriba el motivo (mínimo 5 caracteres).", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    f.DialogResult = DialogResult.OK;
                };
                f.Controls.Add(ok);

                Button cancel = new Button
                {
                    Text = "Cancelar",
                    Location = new Point(180, 168),
                    Size = new Size(110, 38),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.FromArgb(60, 63, 80),
                    ForeColor = Color.White,
                    DialogResult = DialogResult.Cancel,
                    Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold)
                };
                cancel.FlatAppearance.BorderSize = 0;
                f.Controls.Add(cancel);
                f.CancelButton = cancel;

                return f.ShowDialog(this) == DialogResult.OK ? txt.Text.Trim() : null;
            }
        }
        private void btnExportarPdf_Click(object sender, EventArgs e)
        {
            if (vista == null || vista.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                DataTable dt = new DataTable();
                foreach (string c in new[] { "N°", "Empleado", "Cargo", "Período", "Salario base", "Bono",
                                             "Descuento", "Salario neto", "Estado", "Fecha de pago" })
                    dt.Columns.Add(c);

                decimal sBase = 0, sBono = 0, sDesc = 0, sNeto = 0;
                foreach (DataRowView r in vista)
                {
                    decimal b = Convert.ToDecimal(r["SalarioBase"]), bo = Convert.ToDecimal(r["Bono"]);
                    decimal d = Convert.ToDecimal(r["Descuento"]), n = Convert.ToDecimal(r["SalarioNeto"]);
                    sBase += b; sBono += bo; sDesc += d; sNeto += n;

                    string fechaPago = r["FechaPago"] == DBNull.Value ? "" : ((DateTime)r["FechaPago"]).ToString("dd/MM/yyyy");
                    dt.Rows.Add(r["IdPago"], r["Empleado"], r["Cargo"], TextoPeriodo((DateTime)r["Periodo"]),
                                b.ToString("N2"), bo.ToString("N2"), d.ToString("N2"), n.ToString("N2"),
                                r["EstadoPago"], fechaPago);
                }
                dt.Rows.Add("", "TOTAL", "", "", sBase.ToString("N2"), sBono.ToString("N2"),
                            sDesc.ToString("N2"), sNeto.ToString("N2"), "", "");

                string titulo = cmbPeriodo.SelectedIndex > 0 ? "Planilla de " + cmbPeriodo.Text : "Planilla de pagos";
                ExportadorPdf.Exportar(titulo, dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}