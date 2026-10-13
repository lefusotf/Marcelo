using Modelos;
using pagina_principal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vistass;

namespace Gestion_de_personal
{
    public partial class frmGestionPersonal : Form
    {
        private DataTable dtEmpleados;
        private DataView vista;
        private bool cargando = false;   // evita filtrar mientras se llena la lista de cargos
        private bool esAdmin = false;

        public frmGestionPersonal()
        {
            InitializeComponent();
        }

        private void frmGestionPersonal_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnAgregarPersonal, "Registrar un nuevo empleado");
            toolTip1.SetToolTip(btnActualizarPersonal, "Editar los datos del empleado seleccionado");
            toolTip1.SetToolTip(btnExpediente, "Ver el expediente completo (también con doble clic en la fila)");
            toolTip1.SetToolTip(btnEliminarPersonal, "Dar de baja al empleado seleccionado");
            toolTip1.SetToolTip(btnNuevoCargo, "Crear un cargo nuevo");
            toolTip1.SetToolTip(btnExportarPdf, "Exportar el listado que se está viendo (PDF o Excel)");
            toolTip1.SetToolTip(btnAusencias, "Faltas, permisos e incapacidades del personal (afectan el descuento de la planilla)");
            toolTip1.SetToolTip(btnCargaAcademica, "Horas y grupos de cada docente, y qué docentes atienden cada grado y sección");

            esAdmin = Sesion.Rol != null && Sesion.Rol.Trim().Equals("Administrador", StringComparison.OrdinalIgnoreCase);
            btnAgregarPersonal.Enabled = esAdmin;

            CargarCargos();
            MostrarEmpleados();
            ActualizarBotones();
        }

        // ---------------------------------------------------------------
        //  Buscador: lupa, borde que se vuelve amarillo al enfocarse y texto de ayuda
        // ---------------------------------------------------------------
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

        // ---------------------------------------------------------------
        //  Tabla
        // ---------------------------------------------------------------
        private void CargarCargos()
        {
            DataTable t = Datos.Tabla("SELECT IdCargo, NombreCargo FROM Cargos ORDER BY NombreCargo");
            DataRow r = t.NewRow();
            r["IdCargo"] = 0; r["NombreCargo"] = "Todos los cargos";
            t.Rows.InsertAt(r, 0);

            cargando = true;
            cmbCargo.DataSource = t;
            cmbCargo.DisplayMember = "NombreCargo";
            cmbCargo.ValueMember = "IdCargo";
            cargando = false;
        }

        private void MostrarEmpleados()
        {
            try
            {
                // sin los empleados dados de baja (Inactivo); las columnas ocultas se usan en el expediente
                dtEmpleados = Datos.Tabla(
                    @"SELECT e.IdEmpleado, e.Nombre, c.NombreCargo AS Cargo, est.NombreEstado AS Estado,
                             e.FechaContratacion, p.SalarioNeto AS [Salario Neto], e.Telefono, e.Correo,
                             e.IdCargo, e.IdPlanilla, p.SalarioBase AS [Salario Base],
                             e.FechaNacimiento, e.EstadoCivil, e.Religion, e.Direccion
                      FROM Empleados e
                      INNER JOIN Cargos c ON e.IdCargo = c.IdCargo
                      INNER JOIN EstadosEmpleado est ON e.IdEstado = est.IdEstado
                      LEFT JOIN Planillas p ON e.IdPlanilla = p.IdPlanilla
                      WHERE est.NombreEstado != 'Inactivo'
                      ORDER BY e.Nombre");

                vista = new DataView(dtEmpleados);
                dgvEmpleados.DataSource = vista;
                FormatearGrid();
                AplicarFiltro();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el personal: " + ex.Message, "Error SQL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatearGrid()
        {
            if (dgvEmpleados.Columns.Count == 0) return;

            // los títulos nunca se parten en dos líneas
            dgvEmpleados.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

            // datos que no van en el listado (quedan cargados para el expediente)
            foreach (string oculta in new[] { "IdCargo", "IdPlanilla", "Salario Base", "FechaNacimiento",
                                              "EstadoCivil", "Religion", "Direccion" })
                if (dgvEmpleados.Columns.Contains(oculta)) dgvEmpleados.Columns[oculta].Visible = false;

            // pesos: el correo y el nombre son las columnas más largas y se llevan más espacio
            Columna("IdEmpleado", "ID", 5);
            Columna("Nombre", "Nombre", 24);
            Columna("Cargo", "Cargo", 16);
            Columna("Estado", "Estado", 11);
            Columna("FechaContratacion", "Contratación", 11);
            Columna("Salario Neto", "Salario neto", 13);
            Columna("Telefono", "Teléfono", 11);
            Columna("Correo", "Correo electrónico", 23);

            if (dgvEmpleados.Columns.Contains("FechaContratacion"))
                dgvEmpleados.Columns["FechaContratacion"].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (dgvEmpleados.Columns.Contains("Salario Neto"))
                dgvEmpleados.Columns["Salario Neto"].DefaultCellStyle.Format = "N2";

            // ID: discreto, para que el nombre sea lo que destaque
            if (dgvEmpleados.Columns.Contains("IdEmpleado"))
                dgvEmpleados.Columns["IdEmpleado"].DefaultCellStyle.ForeColor = PaletaSistema.Tenue;

            // salario: a la derecha (también su título) para comparar cifras de un vistazo
            if (dgvEmpleados.Columns.Contains("Salario Neto"))
            {
                DataGridViewColumn s = dgvEmpleados.Columns["Salario Neto"];
                s.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                s.DefaultCellStyle.Padding = new Padding(8, 0, 16, 0);
                s.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                s.HeaderCell.Style.Padding = new Padding(8, 0, 16, 0);
            }

            // fecha y teléfono: centrados
            foreach (string c in new[] { "FechaContratacion", "Telefono" })
                if (dgvEmpleados.Columns.Contains(c))
                {
                    dgvEmpleados.Columns[c].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvEmpleados.Columns[c].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
        }

        private void Columna(string nombre, string encabezado, float peso)
        {
            if (!dgvEmpleados.Columns.Contains(nombre)) return;
            dgvEmpleados.Columns[nombre].HeaderText = encabezado;
            dgvEmpleados.Columns[nombre].FillWeight = peso;
        }

        // El estado se dibuja como una cápsula: verde si está activo, ámbar en cualquier otro caso
        private void dgvEmpleados_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || dgvEmpleados.Columns[e.ColumnIndex].Name != "Estado") return;

            // fondo, selección, resaltado y borde de la celda, pero sin el texto
            e.Paint(e.CellBounds, e.PaintParts & ~DataGridViewPaintParts.ContentForeground);
            e.Handled = true;

            string estado = Convert.ToString(e.Value);
            if (estado.Length == 0) return;

            bool activo = estado == "Activo";
            Color baseColor = activo ? Color.FromArgb(34, 197, 94) : Color.FromArgb(245, 158, 11);
            Color letra = activo ? Color.FromArgb(134, 239, 172) : Color.FromArgb(252, 211, 77);

            using (System.Drawing.Font f = new System.Drawing.Font("Segoe UI Semibold", 9F, FontStyle.Bold))
            {
                Size t = TextRenderer.MeasureText(e.Graphics, estado, f, new Size(int.MaxValue, int.MaxValue),
                                                  TextFormatFlags.NoPadding);
                int alto = 22;
                System.Drawing.Rectangle r = new System.Drawing.Rectangle(
                    e.CellBounds.Left + 8, e.CellBounds.Top + (e.CellBounds.Height - alto) / 2, t.Width + 22, alto);

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath p = Pastilla(r))
                using (SolidBrush b = new SolidBrush(Color.FromArgb(55, baseColor)))
                    e.Graphics.FillPath(b, p);

                TextRenderer.DrawText(e.Graphics, estado, f, r, letra,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
            }
        }

        private static GraphicsPath Pastilla(System.Drawing.Rectangle r)
        {
            int d = r.Height;
            GraphicsPath p = new GraphicsPath();
            p.AddArc(r.X, r.Y, d, d, 90, 180);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 180);
            p.CloseFigure();
            return p;
        }

        // ---------------------------------------------------------------
        //  Búsqueda y filtro (en vivo, sin ir a la base de datos)
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
                cond.Add("(Nombre LIKE '%" + esc + "%' OR Cargo LIKE '%" + esc +
                         "%' OR Convert(IdEmpleado, 'System.String') LIKE '%" + esc + "%')");
            }

            int idCargo;
            if (cmbCargo.SelectedValue != null &&
                int.TryParse(cmbCargo.SelectedValue.ToString(), out idCargo) && idCargo > 0)
                cond.Add("IdCargo = " + idCargo);

            vista.RowFilter = string.Join(" AND ", cond);
            ActualizarTarjetas();
            ActualizarBotones();
        }

        // Las dos tarjetas siguen a la búsqueda y al filtro de cargo
        private void ActualizarTarjetas()
        {
            int n = vista.Count;
            int docentes = 0, conSalario = 0;
            decimal nomina = 0;

            foreach (DataRowView r in vista)
            {
                // se cuentan como docentes los cargos que empiezan con "Docente"
                if (Convert.ToString(r["Cargo"]).StartsWith("Docente", StringComparison.OrdinalIgnoreCase)) docentes++;
                if (r["Salario Neto"] != DBNull.Value) { nomina += Convert.ToDecimal(r["Salario Neto"]); conSalario++; }
            }
            int otros = n - docentes;

            lblEmpleadosValor.Text = n.ToString();
            string reparto = docentes + (docentes == 1 ? " docente" : " docentes") + "  ·  " +
                             otros + (otros == 1 ? " administrativo o de apoyo" : " administrativos o de apoyo");
            lblEmpleadosDetalle.Text = n == dtEmpleados.Rows.Count
                ? reparto
                : "De " + dtEmpleados.Rows.Count + " en total  ·  " + reparto;

            lblNominaValor.Text = "$" + nomina.ToString("N2");
            lblNominaDetalle.Text = "Promedio $" + (conSalario > 0 ? nomina / conSalario : 0).ToString("N2") + " por empleado";
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            lblBuscarHint.Visible = txtBuscar.Text.Length == 0;
            AplicarFiltro();
        }

        private void cmbCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargando) return;
            AplicarFiltro();
        }

        // ---------------------------------------------------------------
        //  Selección y botones
        // ---------------------------------------------------------------
        private void dgvEmpleados_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarBotones();
        }

        private void ActualizarBotones()
        {
            bool haySeleccion = dgvEmpleados.CurrentRow != null && vista != null && vista.Count > 0;
            btnActualizarPersonal.Enabled = esAdmin && haySeleccion;
            btnEliminarPersonal.Enabled = esAdmin && haySeleccion;
            btnExpediente.Enabled = haySeleccion;
        }

        private void dgvEmpleados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) AbrirExpediente();
        }

        // ---------------------------------------------------------------
        //  Acciones
        // ---------------------------------------------------------------
        private void btnAgregarPersonal_Click(object sender, EventArgs e)
        {
            frmAgregarPersonal frm = new frmAgregarPersonal();
            if (frm.ShowDialog(this) == DialogResult.OK) MostrarEmpleados();
        }

        private void btnActualizarPersonal_Click(object sender, EventArgs e)
        {
            EditarSeleccionado();
        }

        private void EditarSeleccionado()
        {
            if (dgvEmpleados.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un empleado de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int idEmpleado = Convert.ToInt32(dgvEmpleados.CurrentRow.Cells["IdEmpleado"].Value);

            frmAgregarPersonal frm = new frmAgregarPersonal(idEmpleado);
            if (frm.ShowDialog(this) == DialogResult.OK) MostrarEmpleados();
        }

        private void btnExpediente_Click(object sender, EventArgs e)
        {
            AbrirExpediente();
        }

        private void AbrirExpediente()
        {
            if (dgvEmpleados.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un empleado de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int idEmpleado = Convert.ToInt32(dgvEmpleados.CurrentRow.Cells["IdEmpleado"].Value);

            using (frmExpedienteEmpleado frm = new frmExpedienteEmpleado(idEmpleado, esAdmin))
            {
                frm.ShowDialog(this);
                if (frm.HuboCambios) MostrarEmpleados();
            }
        }

        private void btnEliminarPersonal_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un empleado de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idEmpleado = Convert.ToInt32(dgvEmpleados.CurrentRow.Cells["IdEmpleado"].Value);
            string nombre = Convert.ToString(dgvEmpleados.CurrentRow.Cells["Nombre"].Value);

            // Revisión previa: qué deja pendiente esta baja
            var avisos = new List<string>();
            try
            {
                DataRow r = Datos.Tabla(
                    @"SELECT
                        (SELECT COUNT(*) FROM Salones WHERE IdResponsable = @id AND Activo = 1) AS Salones,
                        (SELECT COUNT(*) FROM PagosPlanilla WHERE IdEmpleado = @id AND Anulado = 0 AND EstadoPago = 'Pendiente') AS Pagos,
                        (SELECT COUNT(*) FROM AsignacionesDocente WHERE IdEmpleado = @id AND AnioLectivo = YEAR(GETDATE())) AS Grupos,
                        (SELECT COUNT(*) FROM Prestamos WHERE Estado = 'Activo' AND (IdEmpleado = @id OR Responsable = @nom)) AS Prestamos",
                    Datos.P("@id", idEmpleado), Datos.P("@nom", nombre)).Rows[0];

                int salones = Convert.ToInt32(r["Salones"]), pagos = Convert.ToInt32(r["Pagos"]);
                int grupos = Convert.ToInt32(r["Grupos"]), prestamos = Convert.ToInt32(r["Prestamos"]);

                if (salones > 0) avisos.Add("• Es responsable de " + salones + (salones == 1 ? " salón" : " salones") + " (quedará sin responsable).");
                if (pagos > 0) avisos.Add("• Tiene " + pagos + (pagos == 1 ? " pago de planilla pendiente." : " pagos de planilla pendientes."));
                if (grupos > 0) avisos.Add("• Tiene " + grupos + (grupos == 1 ? " grupo asignado" : " grupos asignados") + " este año lectivo.");
                if (prestamos > 0) avisos.Add("• Tiene " + prestamos + (prestamos == 1 ? " préstamo de equipo activo." : " préstamos de equipo activos."));
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo revisar la situación del empleado: " + ex.Message, "Error SQL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string pregunta = avisos.Count == 0
                ? "¿Dar de baja a " + nombre + "?\n\nDejará de aparecer en la lista; su historial se conserva."
                : nombre + " tiene asuntos pendientes:\n\n" + string.Join("\n", avisos) + "\n\n¿Dar de baja de todas formas?";

            if (MessageBox.Show(pregunta, "Confirmar baja", MessageBoxButtons.YesNo,
                    avisos.Count == 0 ? MessageBoxIcon.Question : MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;

            try
            {
                // baja lógica: el empleado pasa a Inactivo (IdEstado = 2) y deja de verse en la lista
                Datos.Ejecutar("UPDATE Empleados SET IdEstado = 2 WHERE IdEmpleado = @id", Datos.P("@id", idEmpleado));
                MessageBox.Show(nombre + " fue dado de baja.", "Baja registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarEmpleados();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al dar de baja: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevoCargo_Click(object sender, EventArgs e)
        {
            frmAsignarCargo frm = new frmAsignarCargo();
            if (frm.ShowDialog(this) == DialogResult.OK) CargarCargos();
        }

        private void btnAusencias_Click(object sender, EventArgs e)
        {
            using (frmAusencias frm = new frmAusencias())
                frm.ShowDialog(this);
        }

        private void btnCargaAcademica_Click(object sender, EventArgs e)
        {
            using (frmCargaAcademica frm = new frmCargaAcademica())
                frm.ShowDialog(this);
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
                DataTable dt = vista.ToTable(false, "IdEmpleado", "Nombre", "Cargo", "Estado",
                                             "FechaContratacion", "Telefono", "Correo");
                dt.Columns["IdEmpleado"].ColumnName = "ID";
                dt.Columns["FechaContratacion"].ColumnName = "Contratación";
                dt.Columns["Telefono"].ColumnName = "Teléfono";
                dt.Columns["Correo"].ColumnName = "Correo electrónico";
                ExportadorPdf.Exportar("Listado de personal", dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}