using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Modelos;
namespace Vistass
{
    public partial class frmGestionActivos
    {
        private void InicializarPrestamos()
        {
            bool previo = cargando; cargando = true;
            cmbPrestTipo.Items.AddRange(new object[] { "Docente", "Alumno", "Personal administrativo" });
            cmbPrestTipo.SelectedIndex = 0;
            CrearSelectorEmpleado();
            CrearSelectorUnidad();
            cmbPrestVer.Items.AddRange(new object[] { "Activos", "Atrasados", "Por vencer", "Devueltos", "Todos" });
            cmbPrestVer.SelectedIndex = 0;
            cmbDevEstado.SelectedIndex = cmbDevEstado.FindStringExact("Bueno");
            numPrestCant.Value = 1; numPrestCant.Maximum = 1; numPrestCant.Enabled = false;  
            dtpPrestLimite.Value = DateTime.Now.AddDays(1);
            cargando = previo;
            AplicarTipoResponsable();
            CargarUnidadesPrestamo();
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

                Encabezado(dgvPrestamos, "IdPrestamo", "N°", 4);
                Encabezado(dgvPrestamos, "Activo", "Equipo", 17);
                Encabezado(dgvPrestamos, "CodigoInventario", "Código", 12);
                Encabezado(dgvPrestamos, "Cantidad", "Cant.", 5);
                Encabezado(dgvPrestamos, "Responsable", "Responsable", 15);
                Encabezado(dgvPrestamos, "TipoResponsable", "Tipo", 12);
                Encabezado(dgvPrestamos, "AulaDestino", "Aula", 11);
                Encabezado(dgvPrestamos, "FechaEntrega", "Entrega", 12);
                Encabezado(dgvPrestamos, "FechaLimite", "Límite", 12);
                Encabezado(dgvPrestamos, "Alerta", "Alerta", 10);
                Encabezado(dgvPrestamos, "FechaDevolucion", "Devuelto", 12);
                Encabezado(dgvPrestamos, "EstadoDevolucion", "Estado dev.", 11);

                // Fecha y hora completas: ancho mínimo para que la hora no se corte
                foreach (string c in new[] { "FechaEntrega", "FechaLimite", "FechaDevolucion" })
                    if (dgvPrestamos.Columns.Contains(c))
                    {
                        dgvPrestamos.Columns[c].DefaultCellStyle.Format = "dd/MM/yy HH:mm";
                        dgvPrestamos.Columns[c].MinimumWidth = 135;
                    }

                bool verDevueltos = cmbPrestVer.Text == "Devueltos" || cmbPrestVer.Text == "Todos";
                foreach (string c in new[] { "FechaDevolucion", "EstadoDevolucion" })
                    if (dgvPrestamos.Columns.Contains(c)) dgvPrestamos.Columns[c].Visible = verDevueltos;
                if (dgvPrestamos.Columns.Contains("Cantidad")) dgvPrestamos.Columns["Cantidad"].Visible = false;

                DataTable resumen = Datos.Tabla(
                    @"SELECT ISNULL(SUM(CASE WHEN Alerta = 'Atrasado' THEN 1 ELSE 0 END), 0) AS Atr,
                             ISNULL(SUM(CASE WHEN Alerta = 'Por vencer' THEN 1 ELSE 0 END), 0) AS Pv
                      FROM vw_Prestamos WHERE Estado = 'Activo'");
                lblPrestAlertas.Text = resumen.Rows[0]["Atr"] + " atrasados  ·  " + resumen.Rows[0]["Pv"] +
                                       " por vencer (próximas 48 h)";
                ActualizarDevSel();
                CargarUnidadesPrestamo();        
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los préstamos: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPrestamos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || !dgvPrestamos.Columns.Contains("Alerta")) return;
            string alerta = Convert.ToString(dgvPrestamos.Rows[e.RowIndex].Cells["Alerta"].Value);

            if (alerta == "Atrasado") { e.CellStyle.BackColor = Color.FromArgb(72, 32, 42); e.CellStyle.ForeColor = Color.FromArgb(252, 165, 165); }
            else if (alerta == "Por vencer") { e.CellStyle.BackColor = Color.FromArgb(66, 50, 18); e.CellStyle.ForeColor = Color.FromArgb(252, 211, 77); }
            else if (alerta == "Devuelto") { e.CellStyle.ForeColor = Color.FromArgb(140, 150, 176); }
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
        private ComboOscuro cmbPrestEmpleado;
        private ComboOscuro cmbPrestUnidad;
        private DataTable dtEmpleadosPrestamo;

        private sealed class ElementoLista
        {
            public readonly int Id;
            public readonly string Texto;
            public readonly string Extra;
            public ElementoLista(int id, string texto, string extra = null) { Id = id; Texto = texto; Extra = extra; }
            public override string ToString() { return Texto; }
        }

        private static int? IdSeleccionado(ComboBox combo, string columnaNoUsada = null)
        {
            ElementoLista e = combo.SelectedItem as ElementoLista;
            return e == null ? (int?)null : e.Id;
        }

        private void CrearSelectorEmpleado()
        {
            cmbPrestEmpleado = new ComboOscuro();
            cmbPrestEmpleado.Location = txtPrestResp.Location;
            cmbPrestEmpleado.Size = txtPrestResp.Size;
            cmbPrestEmpleado.TabIndex = txtPrestResp.TabIndex;
            cmbPrestEmpleado.Visible = false;
            txtPrestResp.Parent.Controls.Add(cmbPrestEmpleado);

            cmbPrestTipo.SelectedIndexChanged += (s, e) => AplicarTipoResponsable();
            cmbPrestEmpleado.SelectedIndexChanged += (s, e) =>
            {
                if (IdSeleccionado(cmbPrestEmpleado) != null) errorProvider.SetError(cmbPrestEmpleado, "");
            };
        }

        private void CrearSelectorUnidad()
        {
            cmbPrestUnidad = new ComboOscuro();
            cmbPrestUnidad.Location = txtPrestCodigo.Location;
            cmbPrestUnidad.Size = txtPrestCodigo.Size;
            cmbPrestUnidad.TabIndex = txtPrestCodigo.TabIndex;
            txtPrestCodigo.Visible = false;                      // el cuadro de texto ya no se usa
            txtPrestCodigo.Parent.Controls.Add(cmbPrestUnidad);
            lblPrestCodigo.Text = "Unidad a prestar";

            cmbPrestActivo.SelectedIndexChanged += (s, e) => CargarUnidadesPrestamo();
            cmbPrestUnidad.SelectedIndexChanged += (s, e) =>
            {
                if (IdSeleccionado(cmbPrestUnidad) != null) errorProvider.SetError(cmbPrestUnidad, "");
            };
        }

        private void CargarEmpleadosPrestamo()
        {
            try
            {
                dtEmpleadosPrestamo = Datos.Tabla(
                    @"SELECT e.IdEmpleado, e.Nombre,
                             e.Nombre + ISNULL('  ·  ' + c.NombreCargo, '') AS Texto,
                             CASE WHEN LOWER(ISNULL(c.NombreCargo, '')) LIKE 'docente%' THEN 1 ELSE 0 END AS EsDocente
                      FROM Empleados e
                      LEFT JOIN Cargos c ON c.IdCargo = e.IdCargo
                      WHERE e.IdEstado <> 2
                      ORDER BY e.Nombre");
            }
            catch (Exception ex)
            {
                dtEmpleadosPrestamo = null;
                MessageBox.Show("No se pudo cargar la lista de empleados: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarTipoResponsable()
        {
            if (cmbPrestEmpleado == null) return;
            string tipo = cmbPrestTipo.Text;
            bool esEmpleado = tipo == "Docente" || tipo == "Personal administrativo";

            lblPrestResp.Text = tipo == "Docente" ? "Docente responsable"
                              : tipo == "Personal administrativo" ? "Empleado responsable"
                              : "Nombre del alumno";
            errorProvider.SetError(txtPrestResp, "");
            errorProvider.SetError(cmbPrestEmpleado, "");

            if (esEmpleado)
            {
                CargarEmpleadosPrestamo();                    // por si se agregó o dio de baja a alguien
                cmbPrestEmpleado.Items.Clear();
                cmbPrestEmpleado.SelectedIndex = -1;
                if (dtEmpleadosPrestamo != null)
                {
                    int filtro = tipo == "Docente" ? 1 : 0;
                    foreach (DataRow r in dtEmpleadosPrestamo.Rows)
                        if (Convert.ToInt32(r["EsDocente"]) == filtro)
                            cmbPrestEmpleado.Items.Add(new ElementoLista(
                                Convert.ToInt32(r["IdEmpleado"]), Convert.ToString(r["Texto"]), Convert.ToString(r["Nombre"])));
                }
            }

            txtPrestResp.Visible = !esEmpleado;
            cmbPrestEmpleado.Visible = esEmpleado;
        }

        private void CargarUnidadesPrestamo()
        {
            if (cmbPrestUnidad == null) return;

            int? previa = IdSeleccionado(cmbPrestUnidad);
            cmbPrestUnidad.Items.Clear();
            cmbPrestUnidad.SelectedIndex = -1;

            int idActivo;
            if (cmbPrestActivo.SelectedValue == null ||
                !int.TryParse(Convert.ToString(cmbPrestActivo.SelectedValue), out idActivo))
            {
                cmbPrestUnidad.Enabled = false;
                lblPrestCodigo.Text = "Unidad a prestar";
                return;
            }

            try
            {
                DataTable dt = Datos.Tabla(
                    @"SELECT u.IdUnidad,
                             ISNULL(u.CodigoInventario, 'Unidad ' + CAST(u.IdUnidad AS VARCHAR(10)))
                                 + '  ·  ' + s.NombreSalon + '  ·  ' + e.NombreEstado AS Texto
                      FROM UnidadesActivo u
                      JOIN Salones s ON s.IdSalon = u.IdSalon
                      JOIN Estados e ON e.IdEstado = u.IdEstado
                      WHERE u.IdActivo = @a
                        AND e.NombreEstado NOT IN ('Dado de baja', 'En reparación', 'Malo', 'Mantenimiento Pendiente')
                        AND NOT EXISTS (SELECT 1 FROM Prestamos p WHERE p.IdUnidad = u.IdUnidad AND p.Estado = 'Activo')
                      ORDER BY u.CodigoInventario, u.IdUnidad", Datos.P("@a", idActivo));

                foreach (DataRow r in dt.Rows)
                    cmbPrestUnidad.Items.Add(new ElementoLista(Convert.ToInt32(r["IdUnidad"]), Convert.ToString(r["Texto"])));

                cmbPrestUnidad.Enabled = dt.Rows.Count > 0;
                if (dt.Rows.Count == 0)
                {
                    lblPrestCodigo.Text = "Unidad a prestar  (no hay unidades disponibles)";
                    return;
                }

                lblPrestCodigo.Text = "Unidad a prestar  (" + dt.Rows.Count + (dt.Rows.Count == 1 ? " disponible)" : " disponibles)");

                // se conserva la elección anterior si sigue disponible; si hay una sola, se elige sola
                int indice = -1;
                if (previa != null)
                    for (int i = 0; i < cmbPrestUnidad.Items.Count; i++)
                        if (((ElementoLista)cmbPrestUnidad.Items[i]).Id == previa.Value) { indice = i; break; }
                if (indice < 0 && dt.Rows.Count == 1) indice = 0;
                cmbPrestUnidad.SelectedIndex = indice;
                cmbPrestUnidad.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar las unidades: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    
        private void btnPrestar_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            bool error = false;

            if (cmbPrestActivo.SelectedValue == null) { errorProvider.SetError(cmbPrestActivo, "Seleccione el equipo."); error = true; }
            if (IdSeleccionado(cmbPrestUnidad) == null) { errorProvider.SetError(cmbPrestUnidad, "Elija la unidad que se va a prestar."); error = true; }
            bool esEmpleado = cmbPrestEmpleado.Visible;
            if (esEmpleado)
            {
                if (IdSeleccionado(cmbPrestEmpleado) == null) { errorProvider.SetError(cmbPrestEmpleado, "Elija al empleado responsable de la lista."); error = true; }
            }
            else if (string.IsNullOrWhiteSpace(txtPrestResp.Text)) { errorProvider.SetError(txtPrestResp, "El responsable es obligatorio."); error = true; }
            if (dtpPrestLimite.Value <= DateTime.Now) { errorProvider.SetError(dtpPrestLimite, "La fecha límite debe ser posterior a la actual."); error = true; }
            if (error) return;

            int aula = cmbPrestAula.SelectedValue == null ? 0 : Convert.ToInt32(cmbPrestAula.SelectedValue);

            object idEmpleado = null;
            string responsable = txtPrestResp.Text.Trim();
            if (esEmpleado)
            {
                idEmpleado = IdSeleccionado(cmbPrestEmpleado);
                responsable = ((ElementoLista)cmbPrestEmpleado.SelectedItem).Extra;
            }
            try
            {
                int idUnidad = IdSeleccionado(cmbPrestUnidad).Value;
                Datos.Procedimiento("sp_RegistrarPrestamo",
                    Datos.P("@IdUnidad", idUnidad),
                    Datos.P("@TipoResponsable", cmbPrestTipo.Text),
                    Datos.P("@Responsable", responsable),
                    Datos.P("@IdEmpleado", idEmpleado),
                    Datos.P("@IdSalonDestino", aula > 0 ? (object)aula : null),
                    Datos.P("@FechaLimite", dtpPrestLimite.Value),
                    Datos.PTexto("@Observacion", txtPrestObs.Text),
                    Datos.P("@EntregadoPor", UsuarioActual()));

                MessageBox.Show("Salida registrada. Puede imprimir la hoja de resguardo para la firma del responsable.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtPrestCodigo.Clear(); txtPrestResp.Clear(); cmbPrestEmpleado.SelectedIndex = -1;
                txtPrestObs.Clear(); numPrestCant.Value = 1;
                dtpPrestLimite.Value = DateTime.Now.AddDays(1);
                CargarPrestamos();
                ActualizarIndicadores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo registrar la salida: " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

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
            if (MessageBox.Show("Se registrará la devolución y el activo pasará a estado '" + estado + "'. ¿Continuar?",
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
                CargarActivos();   // el estado del activo cambió
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