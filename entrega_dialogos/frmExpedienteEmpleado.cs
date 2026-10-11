using Modelos;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Vistass
{
    public partial class frmExpedienteEmpleado : Form
    {
        private readonly int idEmpleado;
        private readonly bool esAdmin;
        private string iniciales = "?";
        private bool esDocente = false;
        private string materia = "";          // materias que imparte (texto), para el resumen de carga
        private string nombreEmpleado = "";
        private Image fotoEmpleado = null;     // foto del empleado (null = se dibujan las iniciales)

        public bool HuboCambios { get; private set; }

        public frmExpedienteEmpleado(int idEmpleado, bool esAdministrador)
        {
            InitializeComponent();
            this.idEmpleado = idEmpleado;
            this.esAdmin = esAdministrador;
            EstilizarGrid(dgvAsignaciones);
        }

        private void frmExpedienteEmpleado_Load(object sender, EventArgs e)
        {
            btnEditar.Visible = esAdmin;

            // El DUI es un dato sensible: solo lo ve el administrador
            lblCapDui.Visible = esAdmin;
            lblValDui.Visible = esAdmin;

            Cargar();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (fotoEmpleado != null) { fotoEmpleado.Dispose(); fotoEmpleado = null; }
            base.OnFormClosed(e);
        }

        private void Cargar()
        {
            try
            {
                // EstadoPago sale del pago REAL de este mes (PagosPlanilla); si no hay, 'Sin registrar'
                DataTable dt = Datos.Tabla(
                    @"SELECT e.Nombre, e.FechaContratacion, e.FechaNacimiento, e.EstadoCivil, e.Religion,
                             e.Telefono, e.Correo, e.Direccion, e.IdPlanilla,
                             e.DUI, e.Especialidad,
                             e.ContactoEmergenciaNombre, e.ContactoEmergenciaParentesco, e.ContactoEmergenciaTelefono,
                             c.NombreCargo AS Cargo, est.NombreEstado AS Estado,
                             p.SalarioBase, p.Descuento, p.Bono, p.SalarioNeto,
                             ISNULL(pg.EstadoPago, 'Sin registrar') AS EstadoPago
                      FROM Empleados e
                      INNER JOIN Cargos c ON e.IdCargo = c.IdCargo
                      INNER JOIN EstadosEmpleado est ON e.IdEstado = est.IdEstado
                      LEFT JOIN Planillas p ON p.IdPlanilla = e.IdPlanilla
                      OUTER APPLY (SELECT TOP 1 x.EstadoPago
                                   FROM PagosPlanilla x
                                   WHERE x.IdEmpleado = e.IdEmpleado AND x.Anulado = 0
                                     AND x.Periodo = DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1)
                                   ORDER BY x.IdPago DESC) pg
                      WHERE e.IdEmpleado = @id", Datos.P("@id", idEmpleado));

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontró el empleado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                    return;
                }
                DataRow r = dt.Rows[0];

                string nombre = Convert.ToString(r["Nombre"]).Trim();
                lblNombre.Text = nombre;
                iniciales = Iniciales(nombre);

                CargarFoto();               // la foto se dibuja en el círculo del encabezado
                string materiasTxt = TextoMaterias();

                string estado = Convert.ToString(r["Estado"]);
                string subtitulo = Convert.ToString(r["Cargo"]);
                if (materiasTxt.Length > 0) subtitulo += "  ·  " + materiasTxt;
                if (r["FechaContratacion"] != DBNull.Value)
                    subtitulo += "   ·   Contratado el " + Convert.ToDateTime(r["FechaContratacion"]).ToString("dd/MM/yyyy");
                lblSubtitulo.Text = subtitulo;

                lblBadgeEstado.Text = estado;
                lblBadgeEstado.BackColor = estado == "Activo" ? Color.FromArgb(22, 163, 74) : Color.FromArgb(217, 119, 6);

                // --- Datos personales ---
                lblValTelefono.Text = Txt(r["Telefono"]);
                lblValCorreo.Text = Txt(r["Correo"]);
                lblValEstadoCivil.Text = Txt(r["EstadoCivil"]);
                lblValReligion.Text = Txt(r["Religion"]);
                lblValDireccion.Text = Txt(r["Direccion"]);
                lblValDui.Text = Txt(r["DUI"]);

                string emgNombre = Txt(r["ContactoEmergenciaNombre"]);
                string emgParentesco = Txt(r["ContactoEmergenciaParentesco"]);
                string emgTelefono = Txt(r["ContactoEmergenciaTelefono"]);
                lblValEmergencia.Text = emgNombre == "—" ? "—"
                    : emgNombre + (emgParentesco != "—" ? " (" + emgParentesco + ")" : "") +
                      (emgTelefono != "—" ? "  ·  " + emgTelefono : "");

                if (r["FechaNacimiento"] != DBNull.Value)
                {
                    DateTime nac = Convert.ToDateTime(r["FechaNacimiento"]);
                    lblValNacimiento.Text = nac.ToString("dd/MM/yyyy") + "   (" + Edad(nac) + " años)";
                }
                else lblValNacimiento.Text = "—";

                // --- Datos laborales ---
                lblValCargo.Text = Txt(r["Cargo"]);
                nombreEmpleado = nombre;
                materia = materiasTxt.Length > 0 ? materiasTxt : Convert.ToString(r["Cargo"]).Trim();
                lblValEspecialidad.Text = Txt(r["Especialidad"]);
                lblValMaterias.Text = materiasTxt.Length > 0 ? materiasTxt : "—";
                ConfigurarAsignaciones(Convert.ToString(r["Cargo"]).Trim());
                lblValEstado.Text = Txt(r["Estado"]);
                if (r["FechaContratacion"] != DBNull.Value)
                {
                    DateTime cont = Convert.ToDateTime(r["FechaContratacion"]);
                    lblValContratacion.Text = cont.ToString("dd/MM/yyyy");
                    lblValAntiguedad.Text = Antiguedad(cont);
                }
                else { lblValContratacion.Text = "—"; lblValAntiguedad.Text = "—"; }

                // --- Planilla ---
                lblValSalarioBase.Text = Dinero(r["SalarioBase"]);
                lblValDescuento.Text = Dinero(r["Descuento"]);
                lblValBono.Text = Dinero(r["Bono"]);
                lblValSalarioNeto.Text = Dinero(r["SalarioNeto"]);
                lblValEstadoPago.Text = Txt(r["EstadoPago"]);
                lblValPlanilla.Text = Txt(r["IdPlanilla"]);

                this.Text = "Expediente · " + nombre;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el expediente: " + ex.Message, "Error SQL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Foto del empleado (tabla EmpleadoFotos). Si no tiene, se muestran las iniciales.
        private void CargarFoto()
        {
            if (fotoEmpleado != null) { fotoEmpleado.Dispose(); fotoEmpleado = null; }
            try
            {
                byte[] datos = Datos.Escalar("SELECT Foto FROM EmpleadoFotos WHERE IdEmpleado = @id",
                                             Datos.P("@id", idEmpleado)) as byte[];
                if (datos != null)
                {
                    using (MemoryStream ms = new MemoryStream(datos))
                    using (Image temporal = Image.FromStream(ms))
                        fotoEmpleado = new Bitmap(temporal);   // copia: el stream se puede cerrar
                }
            }
            catch { fotoEmpleado = null; }
            pnlAvatar.Invalidate();
        }

        // Materias del docente, separadas por coma ("" si no tiene)
        private string TextoMaterias()
        {
            try
            {
                return string.Join(", ", Datos.Tabla(
                    @"SELECT m.NombreMateria FROM EmpleadoMaterias em
                      JOIN Materias m ON m.IdMateria = em.IdMateria
                      WHERE em.IdEmpleado = @id ORDER BY m.NombreMateria", Datos.P("@id", idEmpleado))
                    .Rows.Cast<DataRow>().Select(x => Convert.ToString(x["NombreMateria"])));
            }
            catch { return ""; }
        }

        private static string Txt(object v)
        {
            string s = (v == null || v == DBNull.Value) ? "" : Convert.ToString(v).Trim();
            return s.Length == 0 ? "—" : s;
        }

        private static string Dinero(object v)
        {
            return (v == null || v == DBNull.Value) ? "—" : Convert.ToDecimal(v).ToString("N2");
        }

        private static string Iniciales(string nombre)
        {
            string[] partes = nombre.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (partes.Length == 0) return "?";
            if (partes.Length == 1) return partes[0].Substring(0, 1).ToUpper();
            return (partes[0].Substring(0, 1) + partes[1].Substring(0, 1)).ToUpper();
        }

        private static int Edad(DateTime nacimiento)
        {
            int edad = DateTime.Today.Year - nacimiento.Year;
            if (nacimiento.Date > DateTime.Today.AddYears(-edad)) edad--;
            return edad;
        }

        private static string Antiguedad(DateTime desde)
        {
            DateTime hoy = DateTime.Today;
            if (desde > hoy) return "Aún no inicia";

            int meses = (hoy.Year - desde.Year) * 12 + hoy.Month - desde.Month;
            if (hoy.Day < desde.Day) meses--;
            int anios = meses / 12, resto = meses % 12;
            if (anios == 0 && resto == 0) return "Menos de un mes";

            string a = anios > 0 ? anios + (anios == 1 ? " año" : " años") : "";
            string m = resto > 0 ? resto + (resto == 1 ? " mes" : " meses") : "";
            return (a.Length > 0 && m.Length > 0) ? a + " y " + m : a + m;
        }

        // El círculo del encabezado: foto recortada en círculo, o las iniciales si no hay foto
        private void pnlAvatar_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (fotoEmpleado != null)
            {
                using (GraphicsPath circulo = new GraphicsPath())
                {
                    circulo.AddEllipse(0, 0, pnlAvatar.Width - 1, pnlAvatar.Height - 1);
                    e.Graphics.SetClip(circulo);

                    // se recorta un cuadrado centrado de la foto para que no se deforme
                    int lado = Math.Min(fotoEmpleado.Width, fotoEmpleado.Height);
                    Rectangle origen = new Rectangle((fotoEmpleado.Width - lado) / 2, (fotoEmpleado.Height - lado) / 2, lado, lado);
                    e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    e.Graphics.DrawImage(fotoEmpleado, new Rectangle(0, 0, pnlAvatar.Width, pnlAvatar.Height),
                                         origen, GraphicsUnit.Pixel);
                    e.Graphics.ResetClip();
                }
                using (Pen borde = new Pen(Color.FromArgb(0, 120, 212), 2))
                    e.Graphics.DrawEllipse(borde, 1, 1, pnlAvatar.Width - 3, pnlAvatar.Height - 3);
                return;
            }

            using (SolidBrush fondo = new SolidBrush(Color.FromArgb(0, 120, 212)))
                e.Graphics.FillEllipse(fondo, 0, 0, pnlAvatar.Width - 1, pnlAvatar.Height - 1);

            using (Font f = new Font("Segoe UI", 24F, FontStyle.Bold))
            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(iniciales, f, Brushes.White,
                    new RectangleF(0, 0, pnlAvatar.Width, pnlAvatar.Height), sf);
            }
        }

        private void tabExp_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tab = (TabControl)sender;
            bool activa = e.Index == tab.SelectedIndex;
            using (SolidBrush fondo = new SolidBrush(activa ? Color.FromArgb(0, 120, 212) : Color.FromArgb(40, 40, 40)))
                e.Graphics.FillRectangle(fondo, e.Bounds);
            TextRenderer.DrawText(e.Graphics, tab.TabPages[e.Index].Text, tab.Font, e.Bounds, Color.White,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            using (frmAgregarPersonal frm = new frmAgregarPersonal(idEmpleado))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    HuboCambios = true;
                    Cargar();
                }
            }
        }

        // Ficha del empleado en PDF. El DUI y el salario solo salen si quien imprime es administrador.
        private void btnFicha_Click(object sender, EventArgs e)
        {
            DocumentosPdf.FichaEmpleado(idEmpleado, esAdmin);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        // ---------------------------------------------------------------
        //  Asignaciones académicas (solo docentes)
        // ---------------------------------------------------------------
        private void ConfigurarAsignaciones(string cargo)
        {
            esDocente = cargo.StartsWith("Docente", StringComparison.OrdinalIgnoreCase);
            if (!esDocente)
            {
                // los empleados que no son docentes no muestran esta pestaña
                if (tabExp.TabPages.Contains(tabAsignaciones)) tabExp.TabPages.Remove(tabAsignaciones);
                return;
            }

            if (!tabExp.TabPages.Contains(tabAsignaciones)) tabExp.TabPages.Add(tabAsignaciones);
            pnlAcciones.Visible = esAdmin;

            if (cmbAnio.Items.Count == 0)
            {
                int actual = DateTime.Today.Year;
                for (int a = actual - 2; a <= actual + 1; a++) cmbAnio.Items.Add(a);
                cmbAnio.SelectedItem = actual;      // al elegirlo se cargan las asignaciones
            }
            else CargarAsignaciones();
        }

        private void CargarAsignaciones()
        {
            if (!esDocente || cmbAnio.SelectedItem == null) return;
            int anio = Convert.ToInt32(cmbAnio.SelectedItem);
            try
            {
                DataTable dt = Datos.Tabla(
                    @"SELECT IdAsignacion, Grado, Seccion, Materia, HorasSemanales
                      FROM vw_AsignacionesDetalle
                      WHERE IdEmpleado = @e AND AnioLectivo = @a
                      ORDER BY OrdenGrado, Seccion, Materia",
                    Datos.P("@e", idEmpleado), Datos.P("@a", anio));

                dgvAsignaciones.DataSource = dt;
                dgvAsignaciones.Columns["IdAsignacion"].Visible = false;
                dgvAsignaciones.Columns["Grado"].HeaderText = "Grado";
                dgvAsignaciones.Columns["Seccion"].HeaderText = "Sección";
                dgvAsignaciones.Columns["Materia"].HeaderText = "Materia";
                dgvAsignaciones.Columns["HorasSemanales"].HeaderText = "Horas semanales";
                dgvAsignaciones.ClearSelection();

                int horas = 0;
                foreach (DataRow f in dt.Rows) horas += Convert.ToInt32(f["HorasSemanales"]);

                lblCarga.Text = materia + "   ·   " + horas + " de 40 horas semanales   ·   " +
                                dt.Rows.Count + (dt.Rows.Count == 1 ? " grupo" : " grupos");
                lblCarga.ForeColor = horas >= 40 ? Color.FromArgb(250, 204, 21) : Color.White;
                pbCarga.Value = Math.Min(horas, 40);

                btnAsignar.Enabled = horas < 40;
                btnQuitarAsig.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar las asignaciones: " + ex.Message, "Error SQL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarAsignaciones();
        }

        private void dgvAsignaciones_SelectionChanged(object sender, EventArgs e)
        {
            btnQuitarAsig.Enabled = dgvAsignaciones.CurrentRow != null && dgvAsignaciones.SelectedRows.Count > 0;
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            int anio = Convert.ToInt32(cmbAnio.SelectedItem);
            using (frmAsignarGrupo frm = new frmAsignarGrupo(idEmpleado, nombreEmpleado, anio))
            {
                if (frm.ShowDialog(this) == DialogResult.OK) CargarAsignaciones();
            }
        }

        private void btnQuitarAsig_Click(object sender, EventArgs e)
        {
            if (dgvAsignaciones.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un grupo de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int id = Convert.ToInt32(dgvAsignaciones.CurrentRow.Cells["IdAsignacion"].Value);
            string grupo = Convert.ToString(dgvAsignaciones.CurrentRow.Cells["Grado"].Value) + " " +
                           Convert.ToString(dgvAsignaciones.CurrentRow.Cells["Seccion"].Value) + " (" +
                           Convert.ToString(dgvAsignaciones.CurrentRow.Cells["Materia"].Value) + ")";

            if (MessageBox.Show("¿Quitar el grupo \"" + grupo + "\" a " + nombreEmpleado + "?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                Datos.Ejecutar("DELETE FROM AsignacionesDocente WHERE IdAsignacion = @id", Datos.P("@id", id));
                CargarAsignaciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo quitar la asignación: " + ex.Message, "Error SQL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void EstilizarGrid(DataGridView g)
        {
            g.AllowUserToAddRows = false; g.AllowUserToDeleteRows = false; g.AllowUserToResizeRows = false;
            g.ReadOnly = true; g.RowHeadersVisible = false; g.MultiSelect = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            g.ColumnHeadersHeight = 36; g.RowTemplate.Height = 32;
        }

        private void pnlCabecera_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvAsignaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pbCarga_Click(object sender, EventArgs e)
        {

        }
    }
}