using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Vistass
{
    public partial class frmGestionActivos
    {
        private void InicializarPrestamos()
        {
            bool previo = cargando; cargando = true;
            cmbPrestTipo.Items.AddRange(new object[] { "Docente", "Alumno", "Personal administrativo" });
            cmbPrestTipo.SelectedIndex = 0;
            cmbPrestVer.Items.AddRange(new object[] { "Activos", "Atrasados", "Por vencer", "Devueltos", "Todos" });
            cmbPrestVer.SelectedIndex = 0;
            cmbDevEstado.SelectedIndex = cmbDevEstado.FindStringExact("Bueno");
            numPrestCant.Value = 1; numPrestCant.Maximum = 1; numPrestCant.Enabled = false;   // se presta una unidad a la vez
            dtpPrestLimite.Value = DateTime.Now.AddDays(1);
            cargando = previo;
            CargarPrestamos();
        }

        private void cmbPrestVer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargando) return;
            CargarPrestamos();
        }

        private void CargarPrestamos()
        {
            try
            {
                string donde;
                switch (cmbPrestVer.Text)
                {
                    case "Atrasados": donde = "Alerta = 'Atrasado'"; break;
                    case "Por vencer": donde = "Alerta = 'Por vencer'"; break;
                    case "Devueltos": donde = "Estado = 'Devuelto'"; break;
                    case "Todos": donde = "1 = 1"; break;
                    default: donde = "Estado = 'Activo'"; break;
                }

                DataTable dt = Datos.Tabla(
                    @"SELECT IdPrestamo, Activo, CodigoInventario, Cantidad, Responsable, TipoResponsable, AulaDestino,
                             FechaEntrega, FechaLimite, Alerta, FechaDevolucion, EstadoDevolucion
                      FROM vw_Prestamos WHERE " + donde + @"
                      ORDER BY CASE Alerta WHEN 'Atrasado' THEN 0 WHEN 'Por vencer' THEN 1 WHEN 'En curso' THEN 2 ELSE 3 END,
                               FechaLimite");

                bool previo = cargando; cargando = true;
                dgvPrestamos.DataSource = dt;
                dgvPrestamos.ClearSelection();
                cargando = previo;

                Encabezado(dgvPrestamos, "IdPrestamo", "N°", 5);
                Encabezado(dgvPrestamos, "Activo", "Equipo", 14);
                Encabezado(dgvPrestamos, "CodigoInventario", "Código", 9);
                Encabezado(dgvPrestamos, "Cantidad", "Cant.", 5);
                Encabezado(dgvPrestamos, "Responsable", "Responsable", 13);
                Encabezado(dgvPrestamos, "TipoResponsable", "Tipo", 10);
                Encabezado(dgvPrestamos, "AulaDestino", "Aula destino", 10);
                Encabezado(dgvPrestamos, "FechaEntrega", "Entrega", 11);
                Encabezado(dgvPrestamos, "FechaLimite", "Límite", 11);
                Encabezado(dgvPrestamos, "Alerta", "Alerta", 8);
                Encabezado(dgvPrestamos, "FechaDevolucion", "Devuelto", 11);
                Encabezado(dgvPrestamos, "EstadoDevolucion", "Estado al devolver", 10);

                DataTable resumen = Datos.Tabla(
                    @"SELECT ISNULL(SUM(CASE WHEN Alerta = 'Atrasado' THEN 1 ELSE 0 END), 0) AS Atr,
                             ISNULL(SUM(CASE WHEN Alerta = 'Por vencer' THEN 1 ELSE 0 END), 0) AS Pv
                      FROM vw_Prestamos WHERE Estado = 'Activo'");
                lblPrestAlertas.Text = resumen.Rows[0]["Atr"] + " atrasados  ·  " + resumen.Rows[0]["Pv"] +
                                       " por vencer (próximas 48 h)";
                ActualizarDevSel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los préstamos: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Color por alerta: rojo atrasado, ámbar por vencer, gris devuelto
        private void dgvPrestamos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || !dgvPrestamos.Columns.Contains("Alerta")) return;
            string alerta = Convert.ToString(dgvPrestamos.Rows[e.RowIndex].Cells["Alerta"].Value);

            if (alerta == "Atrasado") { e.CellStyle.BackColor = Color.FromArgb(254, 226, 226); e.CellStyle.ForeColor = Color.FromArgb(153, 27, 27); }
            else if (alerta == "Por vencer") { e.CellStyle.BackColor = Color.FromArgb(254, 243, 199); e.CellStyle.ForeColor = Color.FromArgb(146, 64, 14); }
            else if (alerta == "Devuelto") { e.CellStyle.ForeColor = Color.Gray; }
        }

        private DataRowView PrestamoSeleccionado()
        {
            if (dgvPrestamos.SelectedRows.Count == 0) return null;
            return dgvPrestamos.SelectedRows[0].DataBoundItem as DataRowView;
        }

        private void dgvPrestamos_SelectionChanged(object sender, EventArgs e)
        {
            if (cargando) return;
            ActualizarDevSel();
        }

        private void ActualizarDevSel()
        {
            DataRowView f = PrestamoSeleccionado();
            lblDevSel.Text = f == null
                ? "Seleccione un préstamo para devolverlo o imprimir su hoja"
                : "Préstamo N° " + f["IdPrestamo"] + "  ·  " + f["Activo"] + "  ·  " + f["Responsable"];
        }

        // ---------------------------------------------------------------
        //  Salida
        // ---------------------------------------------------------------
        private void btnPrestar_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            bool error = false;

            if (cmbPrestActivo.SelectedValue == null) { errorProvider.SetError(cmbPrestActivo, "Seleccione el equipo."); error = true; }
            if (string.IsNullOrWhiteSpace(txtPrestCodigo.Text)) { errorProvider.SetError(txtPrestCodigo, "Indique el código de la unidad (ver ficha del activo > Ubicación)."); error = true; }
            if (string.IsNullOrWhiteSpace(txtPrestResp.Text)) { errorProvider.SetError(txtPrestResp, "El responsable es obligatorio."); error = true; }
            if (dtpPrestLimite.Value <= DateTime.Now) { errorProvider.SetError(dtpPrestLimite, "La fecha límite debe ser posterior a la actual."); error = true; }
            if (error) return;

            int aula = cmbPrestAula.SelectedValue == null ? 0 : Convert.ToInt32(cmbPrestAula.SelectedValue);
            try
            {
                int idUnidad = Datos.IdUnidad(Convert.ToInt32(cmbPrestActivo.SelectedValue), txtPrestCodigo.Text);
                Datos.Procedimiento("sp_RegistrarPrestamo",
                    Datos.P("@IdUnidad", idUnidad),
                    Datos.P("@TipoResponsable", cmbPrestTipo.Text),
                    Datos.P("@Responsable", txtPrestResp.Text.Trim()),
                    Datos.P("@IdSalonDestino", aula > 0 ? (object)aula : null),
                    Datos.P("@FechaLimite", dtpPrestLimite.Value),
                    Datos.PTexto("@Observacion", txtPrestObs.Text),
                    Datos.P("@EntregadoPor", UsuarioActual()));

                MessageBox.Show("Salida registrada. Puede imprimir la hoja de resguardo para la firma del responsable.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtPrestCodigo.Clear(); txtPrestResp.Clear(); txtPrestObs.Clear(); numPrestCant.Value = 1;
                dtpPrestLimite.Value = DateTime.Now.AddDays(1);
                CargarPrestamos();
                ActualizarIndicadores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo registrar la salida: " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ---------------------------------------------------------------
        //  Devolución (sp_RegistrarDevolucion: préstamo + estado del activo en una transacción)
        // ---------------------------------------------------------------
        private void btnDevolver_Click(object sender, EventArgs e)
        {
            DataRowView f = PrestamoSeleccionado();
            if (f == null)
            {
                MessageBox.Show("Seleccione un préstamo de la tabla.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Convert.ToString(f["Alerta"]) == "Devuelto")
            {
                MessageBox.Show("Ese préstamo ya fue devuelto.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cmbDevEstado.SelectedValue == null)
            {
                errorProvider.SetError(cmbDevEstado, "Seleccione el estado físico al devolver.");
                return;
            }
            errorProvider.Clear();

            string estado = cmbDevEstado.Text;
            if (MessageBox.Show("Se registrará la devolución y la unidad pasará a estado '" + estado + "'. ¿Continuar?",
                "Confirmar devolución", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                Datos.Procedimiento("sp_RegistrarDevolucion",
                    Datos.P("@IdPrestamo", Convert.ToInt32(f["IdPrestamo"])),
                    Datos.P("@IdEstadoDevolucion", Convert.ToInt32(cmbDevEstado.SelectedValue)),
                    Datos.PTexto("@Observacion", txtDevObs.Text));

                bool danado = estado == "Malo" || estado == "En reparación" || estado == "Dado de baja" ||
                              estado.StartsWith("Mantenimiento");
                MessageBox.Show(danado
                    ? "Devolución registrada. El equipo volvió en mal estado: registre el servicio en la pestaña Mantenimiento."
                    : "Devolución registrada correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtDevObs.Clear();
                CargarPrestamos();
                CargarActivos();   // cambió el estado de la unidad
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo registrar la devolución: " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHoja_Click(object sender, EventArgs e)
        {
            DataRowView f = PrestamoSeleccionado();
            if (f == null)
            {
                MessageBox.Show("Seleccione un préstamo de la tabla.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                DataTable dt = Datos.Tabla("SELECT * FROM vw_Prestamos WHERE IdPrestamo = @id",
                    Datos.P("@id", Convert.ToInt32(f["IdPrestamo"])));
                if (dt.Rows.Count > 0) HojaResguardoPdf.Generar(dt.Rows[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo generar la hoja: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}