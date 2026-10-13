using Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Vistass
{
    public partial class frmReportarDaño : Form
    {
        private DataTable dtReportes;    
        private DataView vistaReportes;    
        private DataTable dtEquipos;       
        private DataView vistaEquipos;     

        private bool cargando;            
        private bool esAdmin;            
        private Font fuenteNegrita;
        private Font fuentePastilla;      

        private static readonly Color Rojo = Color.FromArgb(248, 113, 113);
        private static readonly Color Verde = Color.FromArgb(74, 222, 128);
        private static readonly Color Ambar = Color.FromArgb(251, 191, 36);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        public frmReportarDaño()
        {
            InitializeComponent();
        }

        private void frmReportarDaño_Load(object sender, EventArgs e)
        {
            cargando = true;   

            fuenteNegrita = new Font("Segoe UI", 10F, FontStyle.Bold);

            fuentePastilla = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dgvReportes.CellPainting += dgvReportes_CellPainting;

            SendMessage(txtBuscarEquipo.Handle, EM_SETCUEBANNER, 1, "Buscar equipo o código...");
            SendMessage(txtBuscar.Handle, EM_SETCUEBANNER, 1, "Buscar por equipo, código, salón o quién reportó...");

            cmbPrioridad.Items.AddRange(new object[] { "Baja", "Media", "Alta" });
            cmbPrioridad.SelectedIndex = 1;                    

            cmbFiltroEstado.Items.AddRange(new object[] { "Abiertos", "Cerrados", "Todos" });
            cmbFiltroEstado.SelectedIndex = 0;                    
            cmbFiltroPrioridad.Items.AddRange(new object[] { "Todas las prioridades", "Alta", "Media", "Baja" });
            cmbFiltroPrioridad.SelectedIndex = 0;

            CargarSalones();
            cargando = false;

            ConfigurarPermisos();
            ConfigurarAyudas();
            CargarReportes();
            ActualizarSeleccion();
        }

        private static bool EsAdministrador()
        {
            return Sesion.Rol != null &&
                   Sesion.Rol.Trim().Equals("Administrador", StringComparison.OrdinalIgnoreCase);
        }

        private string UsuarioActual()
        {
            return string.IsNullOrWhiteSpace(Sesion.Usuario) ? Environment.UserName : Sesion.Usuario;
        }

        private void ConfigurarPermisos()
        {
            esAdmin = EsAdministrador();
            lblAvisoAdmin.Visible = !esAdmin;
        }

        private void ConfigurarAyudas()
        {
            toolTip1.SetToolTip(cmbSalon, "Elija el salón donde está el equipo dañado");
            toolTip1.SetToolTip(dgvEquipos, "Marque la casilla de cada equipo dañado (puede marcar varios a la vez)");
            toolTip1.SetToolTip(btnReportar, "Registra un reporte por cada equipo marcado y los pasa a 'Mantenimiento Pendiente'");
            toolTip1.SetToolTip(btnResolver, "Cierra el reporte: registra qué se hizo, el costo y el estado final del equipo");
            toolTip1.SetToolTip(btnBaja, "El equipo no tiene arreglo: queda con estado 'Dado de baja'");
            toolTip1.SetToolTip(btnExportar, "Exporta la lista tal como está filtrada (PDF o Excel)");
        }

        private static void Columna(DataGridView g, string nombre, string encabezado, float peso)
        {
            if (!g.Columns.Contains(nombre)) return;
            g.Columns[nombre].HeaderText = encabezado;
            g.Columns[nombre].FillWeight = peso;
        }


        private void CargarSalones()
        {
            try
            {
              
                DataTable activos = Datos.Tabla("SELECT IdSalon, NombreSalon FROM Salones WHERE Activo = 1 ORDER BY NombreSalon");
                cmbSalon.DisplayMember = "NombreSalon";
                cmbSalon.ValueMember = "IdSalon";
                cmbSalon.DataSource = activos;
                cmbSalon.SelectedIndex = -1;                    

             
                cmbFiltroSalon.Items.Clear();
                cmbFiltroSalon.Items.Add("Todos los salones");
                foreach (DataRow r in Datos.Tabla("SELECT NombreSalon FROM Salones ORDER BY NombreSalon").Rows)
                    cmbFiltroSalon.Items.Add(Convert.ToString(r["NombreSalon"]));
                cmbFiltroSalon.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los salones: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarReportes()
        {
            int idSeleccionado = IdReporteSeleccionado();   

            try
            {
                dtReportes = ReportaDaño.ListarTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los reportes: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            vistaReportes = new DataView(dtReportes);
            dgvReportes.DataSource = vistaReportes;
            ConfigurarColumnasReportes();
            AplicarFiltros();
            ActualizarKpis();
            Reseleccionar(idSeleccionado);
            ActualizarDetalle();
        }

        private void ConfigurarColumnasReportes()
        {
            foreach (string c in new[] { "IdReporte", "IdUnidad", "IdSalon", "IdActivo", "Categoria", "Estado",
                                         "FechaReparacion", "ReparadoPor", "ObservacionReparacion", "Costo" })
                if (dgvReportes.Columns.Contains(c)) dgvReportes.Columns[c].Visible = false;

            Columna(dgvReportes, "Prioridad", "Prioridad", 13);
            Columna(dgvReportes, "Codigo", "Código", 13);
            Columna(dgvReportes, "Equipo", "Equipo", 17);
            Columna(dgvReportes, "Salon", "Salón", 13);
            Columna(dgvReportes, "Descripcion", "Descripción", 23);
            Columna(dgvReportes, "ReportadoPor", "Reportó", 13);
            Columna(dgvReportes, "FechaReporte", "Fecha", 12);
            Columna(dgvReportes, "Dias", "Días", 8);
            Columna(dgvReportes, "Situacion", "Estado", 12);

            dgvReportes.Columns["FechaReporte"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvReportes.Columns["Dias"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReportes.Columns["Prioridad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            Dictionary<string, float> pesos = new Dictionary<string, float>
            {
                { "Prioridad", 11 }, { "Código", 16 }, { "Equipo", 20 }, { "Salón", 16 },
                { "Reportó", 14 }, { "Fecha", 12 }, { "Días", 6 }, { "Estado", 11 }
            };
            foreach (DataGridViewColumn c in dgvReportes.Columns)
            {
                if (c.HeaderText == "Descripción") { c.Visible = false; continue; }
                float p;
                if (pesos.TryGetValue(c.HeaderText, out p)) c.FillWeight = p;
                if (c.HeaderText == "Fecha") c.DefaultCellStyle.Format = "dd/MM/yy";
            }
        }

        private void Filtro_Changed(object sender, EventArgs e)
        {
            if (cargando) return;
            AplicarFiltros();
            ActualizarDetalle();
        }

        private void AplicarFiltros()
        {
            if (vistaReportes == null) return;

            var partes = new List<string>();

            if (cmbFiltroEstado.SelectedIndex == 0) partes.Add("Estado = 'Abierto'");
            else if (cmbFiltroEstado.SelectedIndex == 1) partes.Add("Estado = 'Reparado'");   

            if (cmbFiltroSalon.SelectedIndex > 0)
                partes.Add("Salon = '" + cmbFiltroSalon.Text.Replace("'", "''") + "'");

            if (cmbFiltroPrioridad.SelectedIndex > 0)
                partes.Add("Prioridad = '" + cmbFiltroPrioridad.Text + "'");

            string t = EscaparLike(txtBuscar.Text.Trim());
            if (t.Length > 0)
                partes.Add("(Codigo LIKE '%" + t + "%' OR Equipo LIKE '%" + t + "%' OR Salon LIKE '%" + t +
                           "%' OR ReportadoPor LIKE '%" + t + "%' OR Descripcion LIKE '%" + t + "%')");

            vistaReportes.RowFilter = string.Join(" AND ", partes);
            lblListaTitulo.Text = "REPORTES  ·  " + vistaReportes.Count;
        }

        private static string EscaparLike(string s)
        {
            var sb = new StringBuilder();
            foreach (char c in s)
            {
                if (c == '\'') sb.Append("''");
                else if (c == '*' || c == '%' || c == '[' || c == ']') sb.Append('[').Append(c).Append(']');
                else sb.Append(c);
            }
            return sb.ToString();
        }

        private void ActualizarKpis()
        {
            int abiertos = 0, altas = 0, masAntiguo = -1, cerradosMes = 0;
            DateTime inicioMes = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

            foreach (DataRow r in dtReportes.Rows)
            {
                if (Convert.ToString(r["Estado"]) == "Abierto")
                {
                    abiertos++;
                    if (Convert.ToString(r["Prioridad"]) == "Alta") altas++;
                    int dias = Convert.ToInt32(r["Dias"]);
                    if (dias > masAntiguo) masAntiguo = dias;
                }
                else if (r["FechaReparacion"] != DBNull.Value && Convert.ToDateTime(r["FechaReparacion"]) >= inicioMes)
                {
                    cerradosMes++;
                }
            }

            lblKpiAbiertosValor.Text = abiertos.ToString();
            lblKpiAbiertosValor.ForeColor = abiertos > 0 ? Ambar : Verde;
            lblKpiAbiertosDetalle.Text = abiertos == 0 ? "Sin pendientes" : "Pendientes de reparación";

            lblKpiAltasValor.Text = altas.ToString();
            lblKpiAltasValor.ForeColor = altas > 0 ? Rojo : Verde;
            lblKpiAltasDetalle.Text = altas > 0 ? "Requieren atención ya" : "Nada urgente";

            lblKpiAntiguoValor.Text = masAntiguo < 0 ? "—" : masAntiguo + (masAntiguo == 1 ? " día" : " días");
            lblKpiAntiguoValor.ForeColor = masAntiguo >= 14 ? Rojo : masAntiguo >= 7 ? Ambar : Color.White;
            lblKpiAntiguoDetalle.Text = masAntiguo < 0 ? "No hay reportes abiertos" : "Reporte abierto más viejo";

            lblKpiMesValor.Text = cerradosMes.ToString();
            lblKpiMesValor.ForeColor = Verde;
            lblKpiMesDetalle.Text = "Reparados o dados de baja en " +
                                    DateTime.Today.ToString("MMMM", new CultureInfo("es-ES"));
        }

        private DataRowView ReporteActual()
        {
            return dgvReportes.SelectedRows.Count == 1
                ? dgvReportes.SelectedRows[0].DataBoundItem as DataRowView
                : null;
        }

        private int IdReporteSeleccionado()
        {
            DataRowView r = ReporteActual();
            return r == null ? 0 : Convert.ToInt32(r["IdReporte"]);
        }

        private void Reseleccionar(int idReporte)
        {
            dgvReportes.ClearSelection();
            if (idReporte <= 0) return;

            foreach (DataGridViewRow fila in dgvReportes.Rows)
            {
                DataRowView v = fila.DataBoundItem as DataRowView;
                if (v != null && Convert.ToInt32(v["IdReporte"]) == idReporte)
                {
                    dgvReportes.CurrentCell = fila.Cells["Codigo"];
                    fila.Selected = true;
                    break;
                }
            }
        }

        private void dgvReportes_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarDetalle();
        }

        private void ActualizarDetalle()
        {
            DataRowView r = ReporteActual();

            if (r == null)
            {
                lblDetalleTitulo.Text = "Detalle del reporte";
                txtDetalle.Text = "Seleccione un reporte de la lista para ver su detalle y poder cerrarlo.";
            }
            else
            {
                bool abierto = Convert.ToString(r["Estado"]) == "Abierto";
                string codigo = Convert.ToString(r["Codigo"]);

                lblDetalleTitulo.Text = (codigo.Length > 0 ? codigo + "  ·  " : "") +
                                        Convert.ToString(r["Equipo"]) + "  —  " + Convert.ToString(r["Salon"]);

                var sb = new StringBuilder();
                int dias = Convert.ToInt32(r["Dias"]);
                sb.AppendLine("Prioridad: " + r["Prioridad"] + "     Estado: " + r["Situacion"] + "     " +
                              dias + (dias == 1 ? " día" : " días") + (abierto ? " abierto" : " hasta el cierre"));
                sb.AppendLine("Reportado por " + r["ReportadoPor"] + " el " +
                              Convert.ToDateTime(r["FechaReporte"]).ToString("dd/MM/yyyy HH:mm"));
                sb.AppendLine();
                sb.AppendLine(Convert.ToString(r["Descripcion"]));

                if (!abierto)
                {
                    sb.AppendLine();
                    sb.Append("Cerrado");
                    if (r["ReparadoPor"] != DBNull.Value) sb.Append(" por " + r["ReparadoPor"]);
                    if (r["FechaReparacion"] != DBNull.Value)
                        sb.Append(" el " + Convert.ToDateTime(r["FechaReparacion"]).ToString("dd/MM/yyyy HH:mm"));
                    sb.AppendLine();
                    if (r["ObservacionReparacion"] != DBNull.Value)
                        sb.AppendLine("Trabajo realizado: " + r["ObservacionReparacion"]);
                    if (Convert.ToDecimal(r["Costo"]) > 0)
                        sb.AppendLine("Costo: $" + Convert.ToDecimal(r["Costo"]).ToString("N2", CultureInfo.InvariantCulture));
                }

                if (r["IdUnidad"] != DBNull.Value)
                    sb.AppendLine().Append(HistorialUnidad(Convert.ToInt32(r["IdUnidad"])));

                txtDetalle.Text = sb.ToString().TrimEnd();
                txtDetalle.SelectionStart = 0;
            }

            bool puedeActuar = esAdmin && r != null && Convert.ToString(r["Estado"]) == "Abierto";
            btnResolver.Enabled = puedeActuar;
            btnBaja.Enabled = puedeActuar;
            btnPrioridad.Enabled = puedeActuar;
        }

        private string HistorialUnidad(int idUnidad)
        {
            try
            {
                int reportes = Convert.ToInt32(Datos.Escalar(
                    "SELECT COUNT(*) FROM ReportesDanio WHERE IdUnidad = @u", Datos.P("@u", idUnidad)));
                DataRow m = Datos.Tabla(
                    "SELECT COUNT(*) AS N, ISNULL(SUM(Costo), 0) AS Total FROM MantenimientosActivo WHERE IdUnidad = @u",
                    Datos.P("@u", idUnidad)).Rows[0];
                return "Historial de la unidad: " + reportes + (reportes == 1 ? " reporte" : " reportes") + ", " +
                       m["N"] + " mantenimiento(s), $" + Convert.ToDecimal(m["Total"]).ToString("N2", CultureInfo.InvariantCulture) +
                       " en reparaciones.";
            }
            catch
            {
                return "";   
            }
        }

        private void dgvReportes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataRowView r = dgvReportes.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (r == null) return;

            string col = dgvReportes.Columns[e.ColumnIndex].Name;
            bool cerrado = Convert.ToString(r["Estado"]) != "Abierto";

            if (cerrado) e.CellStyle.ForeColor = Color.FromArgb(135, 143, 165);

            if (col == "Dias" && !cerrado && Convert.ToInt32(e.Value) >= 7)
            {
                e.CellStyle.Font = fuenteNegrita;
                e.CellStyle.ForeColor = Rojo;
            }
        }

        // Prioridad y Estado se dibujan como cápsulas (igual que en Personal y Planillas)
        private void dgvReportes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            string col = dgvReportes.Columns[e.ColumnIndex].Name;
            if (col != "Prioridad" && col != "Situacion") return;

            DataRowView r = dgvReportes.Rows[e.RowIndex].DataBoundItem as DataRowView;
            string texto = Convert.ToString(e.Value);
            if (r == null || texto.Length == 0) return;

            // fondo, selección y borde de la celda, pero sin el texto
            e.Paint(e.CellBounds, e.PaintParts & ~DataGridViewPaintParts.ContentForeground);
            e.Handled = true;

            bool cerrado = Convert.ToString(r["Estado"]) != "Abierto";
            Color rojoB = Color.FromArgb(239, 68, 68), rojoL = Color.FromArgb(252, 165, 165);
            Color ambarB = Color.FromArgb(245, 158, 11), ambarL = Color.FromArgb(252, 211, 77);
            Color verdeB = Color.FromArgb(34, 197, 94), verdeL = Color.FromArgb(134, 239, 172);
            Color grisB = Color.FromArgb(148, 163, 184), grisL = Color.FromArgb(165, 172, 190);

            Color baseColor, letra;
            if (col == "Prioridad")
            {
                if (cerrado) { baseColor = grisB; letra = grisL; }
                else if (texto == "Alta") { baseColor = rojoB; letra = rojoL; }
                else if (texto == "Media") { baseColor = ambarB; letra = ambarL; }
                else { baseColor = verdeB; letra = verdeL; }
            }
            else
            {
                if (texto == "Abierto") { baseColor = rojoB; letra = rojoL; }
                else if (texto == "Reparado") { baseColor = verdeB; letra = verdeL; }
                else { baseColor = grisB; letra = grisL; }
            }

            Size t = TextRenderer.MeasureText(e.Graphics, texto, fuentePastilla, new Size(int.MaxValue, int.MaxValue),
                                              TextFormatFlags.NoPadding);
            int alto = 22;
            int ancho = Math.Min(t.Width + 22, e.CellBounds.Width - 8);
            Rectangle rect = new Rectangle(e.CellBounds.Left + (e.CellBounds.Width - ancho) / 2,
                                           e.CellBounds.Top + (e.CellBounds.Height - alto) / 2, ancho, alto);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath p = new GraphicsPath())
            {
                int d = rect.Height;
                p.AddArc(rect.X, rect.Y, d, d, 90, 180);
                p.AddArc(rect.Right - d, rect.Y, d, d, 270, 180);
                p.CloseFigure();
                using (SolidBrush b = new SolidBrush(Color.FromArgb(55, baseColor)))
                    e.Graphics.FillPath(b, p);
            }

            TextRenderer.DrawText(e.Graphics, texto, fuentePastilla, rect, letra,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
        }
        // ---------------------------------------------------------------
        //  Acciones sobre un reporte (solo administrador)
        // ---------------------------------------------------------------
        private void btnResolver_Click(object sender, EventArgs e) { CerrarReporte(false); }
        private void btnBaja_Click(object sender, EventArgs e) { CerrarReporte(true); }

        // Reparar y dar de baja usan la MISMA ventana (frmResolverReporte); cambia el estado final.
        private void CerrarReporte(bool darDeBaja)
        {
            DataRowView r = ReporteActual();
            if (r == null || Convert.ToString(r["Estado"]) != "Abierto") return;

            int idReporte = Convert.ToInt32(r["IdReporte"]);
            int idUnidad = r["IdUnidad"] == DBNull.Value ? 0 : Convert.ToInt32(r["IdUnidad"]);
            string etiqueta = (Convert.ToString(r["Codigo"]).Length > 0 ? r["Codigo"] + " · " : "") +
                              r["Equipo"] + " — " + r["Salon"];

            using (frmResolverReporte dlg = new frmResolverReporte(
                       darDeBaja ? "Dar de baja el equipo" : "Marcar como reparado", etiqueta, darDeBaja))
            {
                if (dlg.ShowDialog(this) != DialogResult.OK) return;

                try
                {
                    if (idUnidad > 0)
                        ReportaDaño.Cerrar(idReporte, idUnidad, dlg.IdEstado, dlg.Costo, dlg.Texto, UsuarioActual());
                    else
                        ReportaDaño.Resolver(idReporte, dlg.Texto, UsuarioActual());   // reportes antiguos sin unidad vinculada

                    MessageBox.Show(darDeBaja ? "El equipo quedó dado de baja y el reporte se cerró."
                                              : "El equipo quedó reparado y el reporte se cerró.",
                                    "Reporte cerrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarReportes();
                    CargarEquipos();   // el estado de las unidades del panel izquierdo cambio
                }
                catch (SqlException ex) { MostrarErrorSql(ex); }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo cerrar el reporte: " + ex.Message, "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // El boton despliega un menu pequeño (Alta / Media / Baja) construido al momento
        private void btnPrioridad_Click(object sender, EventArgs e)
        {
            DataRowView r = ReporteActual();
            if (r == null) return;

            int idReporte = Convert.ToInt32(r["IdReporte"]);
            string actual = Convert.ToString(r["Prioridad"]);

            ContextMenuStrip menu = new ContextMenuStrip();
            foreach (string p in new[] { "Alta", "Media", "Baja" })
            {
                string prioridad = p;                       // copia local para que el lambda use el valor correcto
                ToolStripItem item = menu.Items.Add(prioridad);
                item.Enabled = prioridad != actual;
                item.Click += (s, a) =>
                {
                    try
                    {
                        ReportaDaño.CambiarPrioridad(idReporte, prioridad);
                        CargarReportes();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo cambiar la prioridad: " + ex.Message, "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };
            }
            menu.Show(btnPrioridad, new Point(0, btnPrioridad.Height));
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarReportes();
            CargarEquipos();
        }

        // Exporta EXACTAMENTE lo que se ve en la tabla (respeta los filtros)
        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (vistaReportes == null || vistaReportes.Count == 0)
            {
                MessageBox.Show("No hay reportes para exportar con los filtros actuales.", "Exportar",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                DataTable t = vistaReportes.ToTable(false, "Prioridad", "Codigo", "Equipo", "Salon",
                                                    "Descripcion", "ReportadoPor", "FechaReporte", "Dias", "Situacion");
                t.Columns["Codigo"].ColumnName = "Código";
                t.Columns["Salon"].ColumnName = "Salón";
                t.Columns["Descripcion"].ColumnName = "Descripción";
                t.Columns["ReportadoPor"].ColumnName = "Reportó";
                t.Columns["FechaReporte"].ColumnName = "Fecha";
                t.Columns["Dias"].ColumnName = "Días";
                t.Columns["Situacion"].ColumnName = "Estado";
                ExportadorPdf.Exportar("Reportes de daño - " + cmbFiltroEstado.Text, t);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo exportar: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===============================================================
        //  PANEL IZQUIERDO: nuevo reporte
        // ===============================================================

        private void cmbSalon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargando) return;
            errorProvider.SetError(cmbSalon, "");
            CargarEquipos();
        }

        // Muestra las unidades del salon elegido, cada una con una casilla para marcarla
        private void CargarEquipos()
        {
            int idSalon;
            if (cmbSalon.SelectedIndex < 0 || !int.TryParse(Convert.ToString(cmbSalon.SelectedValue), out idSalon))
            {
                dgvEquipos.DataSource = null;
                dtEquipos = null; vistaEquipos = null;
                ActualizarSeleccion();
                return;
            }

            try
            {
                dtEquipos = ReportaDaño.UnidadesDeSalon(idSalon);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los equipos del salón: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            vistaEquipos = new DataView(dtEquipos);
            dgvEquipos.DataSource = vistaEquipos;

            // La tabla es editable SOLO en la columna de la casilla; el resto de columnas son de lectura
            dgvEquipos.ReadOnly = false;
            foreach (DataGridViewColumn c in dgvEquipos.Columns) c.ReadOnly = c.Name != "Sel";

            dgvEquipos.Columns["IdUnidad"].Visible = false;
            dgvEquipos.Columns["Reportada"].Visible = false;
            Columna(dgvEquipos, "Sel", "", 9);
            Columna(dgvEquipos, "Codigo", "Código", 27);
            Columna(dgvEquipos, "Equipo", "Equipo", 42);
            Columna(dgvEquipos, "Estado", "Estado", 22);

            cargando = true;
            chkTodas.Checked = false;
            cargando = false;

            FiltrarEquipos();
            ActualizarSeleccion();
        }

        private void txtBuscarEquipo_TextChanged(object sender, EventArgs e) { FiltrarEquipos(); }

        private void FiltrarEquipos()
        {
            if (vistaEquipos == null) return;
            string t = EscaparLike(txtBuscarEquipo.Text.Trim());
            vistaEquipos.RowFilter = t.Length == 0 ? ""
                : "Codigo LIKE '%" + t + "%' OR Equipo LIKE '%" + t + "%' OR Estado LIKE '%" + t + "%'";
        }

        // ---- Casillas de seleccion ----

        // Una casilla de DataGridView solo "confirma" su valor al salir de la celda.
        // Con esto se confirma al instante, para que el contador se actualice al marcar.
        private void dgvEquipos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvEquipos.IsCurrentCellDirty)
                dgvEquipos.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvEquipos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvEquipos.Columns[e.ColumnIndex].Name == "Sel")
                ActualizarSeleccion();
        }

        // Las unidades que YA tienen un reporte abierto no se pueden marcar
        private void dgvEquipos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataRowView v = dgvEquipos.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (v != null && Convert.ToInt32(v["Reportada"]) == 1) e.Cancel = true;
        }

        // Comodidad: hacer clic en cualquier parte de la fila tambien marca/desmarca la casilla
        private void dgvEquipos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvEquipos.Columns[e.ColumnIndex].Name == "Sel") return;
            DataRowView v = dgvEquipos.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (v == null || Convert.ToInt32(v["Reportada"]) == 1) return;
            v["Sel"] = !Convert.ToBoolean(v["Sel"]);
        }

        private void dgvEquipos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataRowView v = dgvEquipos.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (v != null && Convert.ToInt32(v["Reportada"]) == 1)
                e.CellStyle.ForeColor = Color.FromArgb(120, 128, 150);   // ya reportada: en gris, no se puede marcar
        }

        // "Seleccionar todas": marca solo lo que se ve (respeta el buscador) y salta las ya reportadas
        private void chkTodas_CheckedChanged(object sender, EventArgs e)
        {
            if (cargando || vistaEquipos == null) return;

            // Se copia a una lista antes de recorrer, porque cambiar valores mientras se recorre la vista da problemas
            foreach (DataRowView v in vistaEquipos.Cast<DataRowView>().ToList())
                if (Convert.ToInt32(v["Reportada"]) == 0)
                    v["Sel"] = chkTodas.Checked;

            dgvEquipos.Refresh();
            ActualizarSeleccion();
        }

        // Ids de las unidades marcadas (aunque el buscador las oculte en este momento)
        private List<int> IdsSeleccionados()
        {
            var ids = new List<int>();
            if (dtEquipos == null) return ids;
            foreach (DataRow r in dtEquipos.Rows)
                if (r["Sel"] != DBNull.Value && Convert.ToBoolean(r["Sel"]))
                    ids.Add(Convert.ToInt32(r["IdUnidad"]));
            return ids;
        }

        private void ActualizarSeleccion()
        {
            int n = IdsSeleccionados().Count;
            lblSeleccion.Text = n == 0 ? "Ninguna seleccionada"
                              : n + (n == 1 ? " seleccionada" : " seleccionadas");
            if (n > 0) errorProvider.SetError(dgvEquipos, "");
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            lblDescripcion.Text = "3. Descripción del daño  (" + txtDescripcion.TextLength + "/500)";
            if (txtDescripcion.Text.Trim().Length >= 5) errorProvider.SetError(txtDescripcion, "");
        }

        // ---- Guardar ----
        private void btnReportar_Click(object sender, EventArgs e)
        {
            // 1) Validar y mostrar el error JUNTO al campo que falta (icono rojo)
            errorProvider.Clear();
            avisoTip.Hide(this);
            primerError = false;
            bool error = false;
            List<int> ids = IdsSeleccionados();

            if (cmbSalon.SelectedIndex < 0)
            { MarcarError(cmbSalon, "Elija el salón donde está el equipo."); error = true; }
            else if (ids.Count == 0)
            { MarcarError(dgvEquipos, "Marque al menos un equipo dañado."); error = true; }

            if (txtDescripcion.Text.Trim().Length < 5)
            { MarcarError(txtDescripcion, "Describa el daño (mínimo 5 caracteres)."); error = true; }

            if (error) return;
            // 2) Guardar: un reporte por unidad marcada, todo en una transaccion (ver ReportaDaño.RegistrarVarias)
            try
            {
                int n = ReportaDaño.RegistrarVarias(ids, cmbPrioridad.Text, txtDescripcion.Text, UsuarioActual());

                MessageBox.Show(n == 1
                        ? "Reporte registrado. La unidad pasó a «Mantenimiento Pendiente»."
                        : n + " reportes registrados. Las unidades pasaron a «Mantenimiento Pendiente».",
                    "Reporte registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario(false);   // conserva el salón por si va a reportar más equipos del mismo
                CargarReportes();
                CargarEquipos();
            }
            catch (SqlException ex) { MostrarErrorSql(ex); }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el reporte: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e) { LimpiarFormulario(true); }

        private void LimpiarFormulario(bool todo)
        {
            errorProvider.Clear();
            txtDescripcion.Clear();
            txtBuscarEquipo.Clear();
            cmbPrioridad.SelectedIndex = 1;

            if (todo)
            {
                cmbSalon.SelectedIndex = -1;      // dispara CargarEquipos(): deja la lista vacia
            }
            else if (dtEquipos != null)
            {
                foreach (DataRow r in dtEquipos.Rows) r["Sel"] = false;
                ActualizarSeleccion();
            }
        }

        // ---------------------------------------------------------------
        //  Errores de SQL en lenguaje claro
        // ---------------------------------------------------------------
        private void MostrarErrorSql(SqlException ex)
        {
            string msg;
            if (ex.Number == 2601 || ex.Number == 2627)
                msg = "Alguna de las unidades ya tiene un reporte abierto. No se guardó ningún reporte.";
            else if (ex.Number >= 50000)
                msg = ex.Message;      // mensajes propios de los procedimientos (THROW 5xxxx): ya vienen en español
            else
                msg = "Error de base de datos: " + ex.Message;

            MessageBox.Show(msg, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

                    // Aviso visible al validar: globo con el mensaje junto al primer campo que falta
        private readonly ToolTip avisoTip = new ToolTip
        {
            IsBalloon = true,
            ToolTipIcon = ToolTipIcon.Warning,
            ToolTipTitle = "Falta información",
            ShowAlways = true
        };
        private bool primerError;

        private void MarcarError(Control campo, string mensaje)
        {
            errorProvider.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
            errorProvider.SetIconPadding(campo, -24);          // el icono queda dentro del campo
            errorProvider.SetError(campo, mensaje);

            if (!primerError)
            {
                primerError = true;
                campo.Focus();
                avisoTip.Show(mensaje, campo, 16, campo.Height, 4000);
            }
        }
    }
}
