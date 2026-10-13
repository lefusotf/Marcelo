 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Modelos;
using System.Data;
using System.Windows.Forms;

namespace Vistass
{
    public partial class frmGestionActivos
    {
        private ComboOscuro cmbMantUnidad;      // lista de unidades del equipo elegido (reemplaza al cuadro de texto del código)

        // El mantenimiento se registra sobre UNA unidad. En vez de pedir que se escriba su código, se elige de una lista
        // con las unidades del equipo (sin las dadas de baja ni las que tienen un reporte de daño abierto).
        private void CrearSelectorUnidadMant()
        {
            cmbMantUnidad = new ComboOscuro();
            cmbMantUnidad.Location = txtMantCodigo.Location;
            cmbMantUnidad.Size = new System.Drawing.Size(340, txtMantCodigo.Height);
            cmbMantUnidad.TabIndex = txtMantCodigo.TabIndex;
            txtMantCodigo.Visible = false;                       // el cuadro de texto ya no se usa
            txtMantCodigo.Parent.Controls.Add(cmbMantUnidad);
            lblMantCodigo.Text = "Unidad";

            // la lista de unidades usa todo el ancho, así que el resto de los campos se acomoda en dos columnas
            lblMantFecha.Location = new System.Drawing.Point(20, 172);
            dtpMantFecha.Location = new System.Drawing.Point(20, 194);
            dtpMantFecha.Size = new System.Drawing.Size(164, dtpMantFecha.Height);
            lblMantTipo.Location = new System.Drawing.Point(196, 172);
            cmbMantTipo.Location = new System.Drawing.Point(196, 194);
            cmbMantTipo.Size = new System.Drawing.Size(164, cmbMantTipo.Height);
            lblMantCosto.Location = new System.Drawing.Point(20, 234);
            numMantCosto.Location = new System.Drawing.Point(20, 256);
            numMantCosto.Size = new System.Drawing.Size(120, numMantCosto.Height);
            lblMantEstado.Location = new System.Drawing.Point(156, 234);
            lblMantEstado.Text = "Estado resultante";
            cmbMantEstado.Location = new System.Drawing.Point(156, 256);
            cmbMantEstado.Size = new System.Drawing.Size(204, cmbMantEstado.Height);

            cmbMantActivo.SelectedIndexChanged += (s, e) => CargarUnidadesMant();
            // en una pestaña que aún no se ha mostrado el combo no entrega su valor: se recarga al abrir la pestaña
            cmbMantActivo.VisibleChanged += (s, e) => { if (cmbMantActivo.Visible) CargarUnidadesMant(); };
            cmbMantUnidad.SelectedIndexChanged += (s, e) =>
            {
                if (IdSeleccionado(cmbMantUnidad) == null) return;
                errorProvider.SetError(cmbMantUnidad, "");
                // el estado resultante parte del estado actual de la unidad (un preventivo normalmente no lo cambia)
                ElementoLista el = cmbMantUnidad.SelectedItem as ElementoLista;
                int idEstado;
                if (el != null && int.TryParse(el.Extra, out idEstado))
                {
                    try { cmbMantEstado.SelectedValue = idEstado; } catch { }
                }
            };
        }

        private void CargarUnidadesMant()
        {
            if (cmbMantUnidad == null) return;

            cmbMantUnidad.Items.Clear();
            cmbMantUnidad.SelectedIndex = -1;

            int idActivo;
            if (cmbMantActivo.SelectedValue == null ||
                !int.TryParse(Convert.ToString(cmbMantActivo.SelectedValue), out idActivo))
            {
                cmbMantUnidad.Enabled = false;
                lblMantCodigo.Text = "Unidad";
                return;
            }

            try
            {
                DataTable dt = Datos.Tabla(
                    @"SELECT u.IdUnidad, u.IdEstado,
                             ISNULL(u.CodigoInventario, 'Unidad ' + CAST(u.IdUnidad AS VARCHAR(10)))
                                 + '  ·  ' + s.NombreSalon + '  ·  ' + e.NombreEstado AS Texto
                      FROM UnidadesActivo u
                      JOIN Salones s ON s.IdSalon = u.IdSalon
                      JOIN Estados e ON e.IdEstado = u.IdEstado
                      WHERE u.IdActivo = @a
                        AND e.NombreEstado <> 'Dado de baja'
                        AND NOT EXISTS (SELECT 1 FROM ReportesDanio r WHERE r.IdUnidad = u.IdUnidad AND r.Estado = 'Abierto')
                      ORDER BY u.CodigoInventario, u.IdUnidad", Datos.P("@a", idActivo));

                foreach (DataRow r in dt.Rows)
                    cmbMantUnidad.Items.Add(new ElementoLista(Convert.ToInt32(r["IdUnidad"]), Convert.ToString(r["Texto"]),
                                                              Convert.ToString(r["IdEstado"])));

                cmbMantUnidad.Enabled = dt.Rows.Count > 0;
                lblMantCodigo.Text = dt.Rows.Count == 0 ? "Unidad  (no hay unidades disponibles)"
                                   : "Unidad  (" + dt.Rows.Count + (dt.Rows.Count == 1 ? " disponible)" : " disponibles)");

                if (dt.Rows.Count == 1) cmbMantUnidad.SelectedIndex = 0;      // si hay una sola, se elige sola
            }
            catch (Exception ex)
            {
                cmbMantUnidad.Enabled = false;
                MessageBox.Show("No se pudieron cargar las unidades: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InicializarMantenimiento()
        {
            CrearSelectorUnidadMant();

            cmbMantTipo.Items.AddRange(new object[] { "Preventivo", "Correctivo" });
            cmbMantTipo.SelectedIndex = 0;
            cmbMantEstado.SelectedIndex = cmbMantEstado.FindStringExact("Bueno");
            dtpMantFecha.Value = DateTime.Today;

           
            lblMantVinculo.Text = "Los reportes de daño se cierran desde «Reportar equipo dañado».";

            CargarMantenimiento();
        }

        private void CargarMantenimiento()
        {
            try
            {
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

        private void btnMantLimpiar_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            txtMantDesc.Clear(); numMantCosto.Value = 0;
            if (cmbMantUnidad != null && cmbMantUnidad.Items.Count != 1) cmbMantUnidad.SelectedIndex = -1;
            cmbMantTipo.SelectedIndex = 0;
            dtpMantFecha.Value = DateTime.Today;
        }

        private void btnMantRegistrar_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            bool error = false;
            if (cmbMantActivo.SelectedValue == null) { errorProvider.SetError(cmbMantActivo, "Seleccione el equipo."); error = true; }
            if (cmbMantEstado.SelectedValue == null) { errorProvider.SetError(cmbMantEstado, "Seleccione el estado resultante."); error = true; }
            int? unidadElegida = IdSeleccionado(cmbMantUnidad);
            if (unidadElegida == null) { errorProvider.SetError(cmbMantUnidad, "Elija la unidad a la que se le hizo el servicio."); error = true; }
            if (txtMantDesc.Text.Trim().Length < 5) { errorProvider.SetError(txtMantDesc, "Describa el servicio realizado (mínimo 5 caracteres)."); error = true; }
            if (error) return;

            try
            {
                int idUnidad = unidadElegida.Value;

                int abiertos = Convert.ToInt32(Datos.Escalar(
                    "SELECT COUNT(*) FROM ReportesDanio WHERE IdUnidad = @u AND Estado = 'Abierto'",
                    Datos.P("@u", idUnidad)));
                if (abiertos > 0)
                {
                    MessageBox.Show("Esta unidad tiene un reporte de daño abierto.\n\n" +
                                    "Ciérrelo desde «Reportar equipo dañado» (Marcar reparado o Dar de baja). " +
                                    "Ahí queda registrado el mantenimiento y se actualiza el estado de la unidad.",
                                    "Reporte abierto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Datos.Procedimiento("sp_RegistrarMantenimiento",
                    Datos.P("@IdUnidad", idUnidad),
                    Datos.P("@Fecha", dtpMantFecha.Value.Date),
                    Datos.P("@Tipo", cmbMantTipo.Text),
                    Datos.P("@Descripcion", txtMantDesc.Text.Trim()),
                    Datos.P("@Costo", numMantCosto.Value),
                    Datos.P("@IdEstadoResultante", Convert.ToInt32(cmbMantEstado.SelectedValue)),
                    Datos.P("@Usuario", UsuarioActual()));

                MessageBox.Show("Mantenimiento registrado y estado de la unidad actualizado.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnMantLimpiar_Click(null, EventArgs.Empty);
                CargarActivos();      
                CargarMantenimiento();
                CargarUnidadesMant();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo registrar el mantenimiento: " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}