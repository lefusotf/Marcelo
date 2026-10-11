using Modelos;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Vistass
{
    // Historial de cambios y reportes de daño de UN tipo de activo
    public partial class frmHistorialActivo : Form
    {
        private readonly int idActivo;
        private readonly string nombreActivo;

        public frmHistorialActivo(int idActivo, string nombreActivo)
        {
            InitializeComponent();
            this.idActivo = idActivo;
            this.nombreActivo = nombreActivo;
            EstilizarGrid(dgvHistorial);
            EstilizarGrid(dgvDanos);
        }

        private void frmHistorialActivo_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = "Historial de: " + nombreActivo;
            Cargar();
        }

        private void Cargar()
        {
            try
            {
                // cambios del catálogo (nombre) + cambios de estado/salón de cada unidad
                DataTable hist = Datos.Tabla(
                    @"SELECT Fecha, Accion, Codigo, Antes, Despues, Usuario FROM (
                        SELECT Fecha, Accion, CAST(NULL AS VARCHAR(50)) AS Codigo,
                               CAST(NombreAnterior AS NVARCHAR(200)) AS Antes, CAST(NombreNuevo AS NVARCHAR(200)) AS Despues, Usuario
                        FROM vw_AuditoriaActivosDetalle
                        WHERE IdActivo = @id AND (Accion <> 'UPDATE' OR ISNULL(NombreAnterior,'') <> ISNULL(NombreNuevo,''))
                        UNION ALL
                        SELECT Fecha, Accion, CodigoInventario,
                               CAST(ISNULL(EstadoAnterior,'') + ISNULL(' · ' + SalonAnterior,'') AS NVARCHAR(200)),
                               CAST(ISNULL(EstadoNuevo,'')    + ISNULL(' · ' + SalonNuevo,'')    AS NVARCHAR(200)), Usuario
                        FROM vw_AuditoriaUnidadesDetalle
                        WHERE IdActivo = @id
                      ) h ORDER BY Fecha DESC", Datos.P("@id", idActivo));

                DataTable danos = Datos.Tabla(
                    @"SELECT FechaReporte, Estado, Prioridad, Salon, CodigoInventario, Descripcion,
                             ReportadoPor, FechaReparacion, ObservacionReparacion
                      FROM vw_ReportesDanio WHERE IdActivo = @id ORDER BY FechaReporte DESC", Datos.P("@id", idActivo));

                dgvHistorial.DataSource = hist;
                dgvDanos.DataSource = danos;

                Encabezado(dgvHistorial, "Fecha", "Fecha", 16);
                Encabezado(dgvHistorial, "Accion", "Acción", 10);
                Encabezado(dgvHistorial, "Codigo", "Unidad", 16);
                Encabezado(dgvHistorial, "Antes", "Antes", 24);
                Encabezado(dgvHistorial, "Despues", "Después", 24);
                Encabezado(dgvHistorial, "Usuario", "Usuario", 14);

                Encabezado(dgvDanos, "FechaReporte", "Reportado", 12);
                Encabezado(dgvDanos, "Estado", "Estado", 8);
                Encabezado(dgvDanos, "Prioridad", "Prioridad", 8);
                Encabezado(dgvDanos, "Salon", "Salón", 12);
                Encabezado(dgvDanos, "CodigoInventario", "Unidad", 11);
                Encabezado(dgvDanos, "Descripcion", "Descripción", 22);
                Encabezado(dgvDanos, "ReportadoPor", "Reportó", 9);
                Encabezado(dgvDanos, "FechaReparacion", "Reparado", 12);
                Encabezado(dgvDanos, "ObservacionReparacion", "Observación", 18);

                int abiertos = danos.Select("Estado = 'Abierto'").Length;
                lblResumen.Text = hist.Rows.Count + (hist.Rows.Count == 1 ? " cambio registrado" : " cambios registrados") +
                                  "   ·   " + danos.Rows.Count + (danos.Rows.Count == 1 ? " reporte de daño" : " reportes de daño") +
                                  " (" + abiertos + (abiertos == 1 ? " abierto)" : " abiertos)");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el historial: " + ex.Message, "Error SQL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void Encabezado(DataGridView g, string columna, string texto, float peso)
        {
            if (!g.Columns.Contains(columna)) return;
            g.Columns[columna].HeaderText = texto;
            g.Columns[columna].FillWeight = peso;
            if (columna.StartsWith("Fecha"))
                g.Columns[columna].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
        }

        // Tabla con el tema oscuro del sistema
        private static void EstilizarGrid(DataGridView g)
        {
            g.AllowUserToAddRows = false; g.AllowUserToDeleteRows = false; g.AllowUserToResizeRows = false;
            g.ReadOnly = true; g.RowHeadersVisible = false; g.MultiSelect = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            g.ColumnHeadersHeight = 36; g.RowTemplate.Height = 30;
        }

        // Pestañas con tema oscuro
        private void tabHist_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tab = (TabControl)sender;
            bool activa = e.Index == tab.SelectedIndex;
            using (SolidBrush fondo = new SolidBrush(activa ? Color.FromArgb(0, 120, 212) : Color.FromArgb(40, 40, 40)))
                e.Graphics.FillRectangle(fondo, e.Bounds);
            TextRenderer.DrawText(e.Graphics, tab.TabPages[e.Index].Text, tab.Font, e.Bounds, Color.White,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        // Reportes abiertos en rojo, reparados en verde
        private void dgvDanos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null || dgvDanos.Columns[e.ColumnIndex].Name != "Estado") return;
            string estado = e.Value.ToString();
            if (estado == "Abierto") e.CellStyle.ForeColor = Color.FromArgb(252, 165, 165);
            else if (estado == "Reparado") e.CellStyle.ForeColor = Color.FromArgb(134, 239, 172);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}