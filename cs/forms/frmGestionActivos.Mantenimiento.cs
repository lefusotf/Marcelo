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
        private int idReporteVinculado = 0;

        private void InicializarMantenimiento()
        {
            cmbMantTipo.Items.AddRange(new object[] { "Preventivo", "Correctivo" });
            cmbMantTipo.SelectedIndex = 0;
            cmbMantEstado.SelectedIndex = cmbMantEstado.FindStringExact("Bueno");
            dtpMantFecha.Value = DateTime.Today;
            CargarMantenimiento();
        }

        private void CargarMantenimiento()
        {
            try
            {
                dgvMantReportes.DataSource = Datos.Tabla(
                    @"SELECT IdReporte, IdActivo, Activo, Salon, CodigoInventario, Prioridad, Descripcion, FechaReporte
                      FROM vw_ReportesDanio WHERE Estado = 'Abierto'
                      ORDER BY CASE Prioridad WHEN 'Alta' THEN 0 WHEN 'Media' THEN 1 ELSE 2 END, FechaReporte");
                dgvMantReportes.ClearSelection();
                dgvMantReportes.Columns["IdReporte"].Visible = false;
                dgvMantReportes.Columns["IdActivo"].Visible = false;
                Encabezado(dgvMantReportes, "Activo", "Equipo", 18);
                Encabezado(dgvMantReportes, "Salon", "Salón", 14);
                Encabezado(dgvMantReportes, "CodigoInventario", "Código", 12);
                Encabezado(dgvMantReportes, "Prioridad", "Prioridad", 9);
                Encabezado(dgvMantReportes, "Descripcion", "Descripción del daño", 33);
                Encabezado(dgvMantReportes, "FechaReporte", "Reportado", 14);

                dgvMantenimientos.DataSource = Datos.Tabla(
                    @"SELECT TOP 300 Fecha, Activo, CodigoInventario, Tipo, Descripcion, Costo, EstadoResultante, RealizadoPor
                      FROM vw_Mantenimientos ORDER BY IdMantenimiento DESC");
                Encabezado(dgvMantenimientos, "Fecha", "Fecha", 11);
                Encabezado(dgvMantenimientos, "Activo", "Equipo", 16);
                Encabezado(dgvMantenimientos, "CodigoInventario", "Código", 10);
                Encabezado(dgvMantenimientos, "Tipo", "Tipo", 10);
                Encabezado(dgvMantenimientos, "Descripcion", "Descripción", 28);
                Encabezado(dgvMantenimientos, "Costo", "Costo", 8);
                Encabezado(dgvMantenimientos, "EstadoResultante", "Estado resultante", 12);
                Encabezado(dgvMantenimientos, "RealizadoPor", "Registrado por", 10);
                if (dgvMantenimientos.Columns.Contains("Costo"))
                    dgvMantenimientos.Columns["Costo"].DefaultCellStyle.Format = "N2";
                if (dgvMantenimientos.Columns.Contains("Fecha"))
                    dgvMantenimientos.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el mantenimiento: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Al elegir un reporte abierto se pre-llena el formulario y se vincula
        private void dgvMantReportes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataRowView f = dgvMantReportes.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (f == null) return;

            idReporteVinculado = Convert.ToInt32(f["IdReporte"]);
            cmbMantActivo.SelectedValue = Convert.ToInt32(f["IdActivo"]);
            txtMantCodigo.Text = Convert.ToString(f["CodigoInventario"]);
            cmbMantTipo.SelectedIndex = 1;   // Correctivo
            lblMantVinculo.Text = "Al guardar se cerrará el reporte de daño N° " + idReporteVinculado + " (" + f["Activo"] + ")";
        }

        private void btnMantLimpiar_Click(object sender, EventArgs e)
        {
            idReporteVinculado = 0;
            errorProvider.Clear();
            txtMantCodigo.Clear(); txtMantDesc.Clear(); numMantCosto.Value = 0;
            cmbMantTipo.SelectedIndex = 0;
            dtpMantFecha.Value = DateTime.Today;
            dgvMantReportes.ClearSelection();
            lblMantVinculo.Text = "Sin reporte de daño vinculado (seleccione uno de la tabla para cerrarlo al guardar)";
        }

        private void btnMantRegistrar_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            bool error = false;
            if (cmbMantActivo.SelectedValue == null) { errorProvider.SetError(cmbMantActivo, "Seleccione el equipo."); error = true; }
            if (cmbMantEstado.SelectedValue == null) { errorProvider.SetError(cmbMantEstado, "Seleccione el estado resultante."); error = true; }
            if (string.IsNullOrWhiteSpace(txtMantCodigo.Text)) { errorProvider.SetError(txtMantCodigo, "Indique el código de la unidad."); error = true; }
            if (string.IsNullOrWhiteSpace(txtMantDesc.Text)) { errorProvider.SetError(txtMantDesc, "Describa el servicio realizado."); error = true; }
            if (error) return;

            try
            {
                int idUnidad = Datos.IdUnidad(Convert.ToInt32(cmbMantActivo.SelectedValue), txtMantCodigo.Text);
                Datos.Procedimiento("sp_RegistrarMantenimiento",
                    Datos.P("@IdUnidad", idUnidad),
                    Datos.P("@Fecha", dtpMantFecha.Value.Date),
                    Datos.P("@Tipo", cmbMantTipo.Text),
                    Datos.P("@Descripcion", txtMantDesc.Text.Trim()),
                    Datos.P("@Costo", numMantCosto.Value),
                    Datos.P("@IdEstadoResultante", Convert.ToInt32(cmbMantEstado.SelectedValue)),
                    Datos.P("@IdReporte", idReporteVinculado > 0 ? (object)idReporteVinculado : null),
                    Datos.P("@Usuario", UsuarioActual()));

                MessageBox.Show("Mantenimiento registrado y estado de la unidad actualizado.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnMantLimpiar_Click(null, EventArgs.Empty);
                CargarActivos();        // estado del activo, indicadores y marcas de daño
                CargarMantenimiento();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo registrar el mantenimiento: " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
