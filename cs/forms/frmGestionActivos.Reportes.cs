using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace Vistass
{
    public partial class frmGestionActivos
    {
        private DataTable dtReporte;

        private void InicializarReportes()
        {
            cmbRepTipo.Items.AddRange(new object[]
            {
                "Inventario por aula o departamento",
                "Activos en mal estado / candidatos a baja",
                "Historial de movimientos por rango de fechas"
            });
            cmbRepTipo.SelectedIndex = 0;
            dtpRepDesde.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpRepHasta.Value = DateTime.Today;
        }

        // Cada reporte habilita solo los filtros que usa
        private void cmbRepTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int t = cmbRepTipo.SelectedIndex;
            cmbRepSalon.Enabled = t == 0;
            dtpRepDesde.Enabled = t == 2;
            dtpRepHasta.Enabled = t == 2;
            dgvReporte.DataSource = null;
            dtReporte = null;
            lblRepInfo.Text = "Presione Generar para ver el reporte";
        }

        private void btnRepGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                int salon = cmbRepSalon.SelectedValue == null ? 0 : Convert.ToInt32(cmbRepSalon.SelectedValue);

                switch (cmbRepTipo.SelectedIndex)
                {
                    case 0:
                        dtReporte = Datos.Tabla(
                            @"SELECT Ubicacion AS [Aula / departamento], Activo AS [Activo], Categoria AS [Categoría],
                                     CodigoInventario AS [Código], Estado AS [Estado]
                              FROM vw_UnidadesDetalle
                              WHERE (@s = 0 OR IdSalon = @s)
                              ORDER BY Ubicacion, Activo, CodigoInventario", Datos.P("@s", salon));
                        break;

                    case 1:
                        dtReporte = Datos.Tabla(
                            @"SELECT d.CodigoInventario AS [Código], d.Activo AS [Activo], d.Categoria AS [Categoría],
                                     d.Estado AS [Estado físico], d.Ubicacion AS [Ubicación],
                                     (SELECT COUNT(*) FROM vw_ReportesDanio r WHERE r.IdUnidad = d.IdUnidad) AS [Reportes de daño]
                              FROM vw_UnidadesDetalle d
                              WHERE d.Estado IN ('Malo', 'En reparación', 'Mantenimiento Pendiente')
                                 OR (SELECT COUNT(*) FROM vw_ReportesDanio r WHERE r.IdUnidad = d.IdUnidad) >= 2
                              ORDER BY d.Estado, d.Activo, d.CodigoInventario");
                        break;

                    default:
                        if (dtpRepDesde.Value.Date > dtpRepHasta.Value.Date)
                        {
                            MessageBox.Show("La fecha inicial no puede ser posterior a la final.", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        dtReporte = Datos.Tabla(
                            @"SELECT Fecha, Tipo, Detalle, Responsable, RegistradoPor AS [Registrado por]
                              FROM vw_HistorialMovimientos
                              WHERE Fecha >= @d AND Fecha < DATEADD(DAY, 1, @h)
                              ORDER BY Fecha DESC",
                            Datos.P("@d", dtpRepDesde.Value.Date), Datos.P("@h", dtpRepHasta.Value.Date));
                        break;
                }

                dgvReporte.DataSource = dtReporte;
                if (dgvReporte.Columns.Contains("Fecha"))
                    dgvReporte.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

                int n = dtReporte.Rows.Count;
                lblRepInfo.Text = n + (n == 1 ? " registro" : " registros") + " · " + cmbRepTipo.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo generar el reporte: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRepPdf_Click(object sender, EventArgs e)
        {
            if (dtReporte == null || dtReporte.Rows.Count == 0)
            {
                MessageBox.Show("Genere primero un reporte con datos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string titulo = cmbRepTipo.Text;
            if (cmbRepTipo.SelectedIndex == 2)
                titulo += " (" + dtpRepDesde.Value.ToString("dd-MM-yyyy") + " al " + dtpRepHasta.Value.ToString("dd-MM-yyyy") + ")";
            ExportadorPdf.Exportar(titulo, dtReporte);
        }
    }
}