using iTextSharp.text;
using iTextSharp.text.pdf;
using Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vistass
{
    public partial class frmSalones : Form
    {
        private Salon objSalon = new Salon();
        private ErrorProvider errorProvider1 = new ErrorProvider();

        public frmSalones()
        {
            InitializeComponent();
            this.dgvSalonClases.SelectionChanged += new System.EventHandler(this.dgvSalonClases_SelectionChanged);
            this.Load += new EventHandler(frmSalones_Load);
            this.cmbSalones.SelectedIndexChanged += new EventHandler(cmbSalones_SelectedIndexChanged);
            this.cmbActivosDisponibles.SelectedIndexChanged += new EventHandler(cmbActivosDisponibles_SelectedIndexChanged);
            this.btnAsignarActivo.Click += new EventHandler(btnAsignar_Click);
            this.btnQuitarActivo.Click += new EventHandler(btnQuitar_Click);
        }

        private void frmSalones_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnAsignarActivo, "Asignar activo al salón");
            toolTip1.SetToolTip(btnQuitarActivo, "Quitar activo del salón");
            toolTip1.SetToolTip(btnBuscarActivoSalones, "Buscar activo en el salón");
            toolTip1.SetToolTip(txtNombreActivoSalon, "Ingrese el nombre del activo a buscar");
            toolTip1.SetToolTip(cmbSalones, "Seleccione un salón para gestionar su equipo");
            toolTip1.SetToolTip(cmbActivosDisponibles, "Seleccione un activo disponible para asignar");
            toolTip1.SetToolTip(btnExportarPdf, "Exportar la tabla de activos del salón a PDF");

            dgvSalonClases.DefaultCellStyle.BackColor = Color.White;
            dgvSalonClases.DefaultCellStyle.ForeColor = Color.Black;
            dgvSalonClases.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgvSalonClases.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            dgvSalonClases.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 212);
            dgvSalonClases.DefaultCellStyle.SelectionForeColor = Color.White;
            


            CargarSalones();
            CargarActivosDisponibles();

            if (cmbSalones.SelectedValue != null && int.TryParse(cmbSalones.SelectedValue.ToString(), out int idSalon))
            {
                CargarTablaActivosSalon(idSalon);
            }

            ActualizarInterfazYCodigo();
        }

        private void CargarSalones()
        {
            try
            {
                DataTable dt = objSalon.ObtenerSalones();
                cmbSalones.DataSource = dt;
                cmbSalones.ValueMember = "IdSalon";
                cmbSalones.DisplayMember = "NombreSalon";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar salones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarActivosDisponibles()
        {
            try
            {
                DataTable dt = objSalon.ObtenerActivosDisponibles();
                cmbActivosDisponibles.DataSource = dt;
                cmbActivosDisponibles.ValueMember = "IdActivo";
                cmbActivosDisponibles.DisplayMember = "Nombre";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar activos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarTablaActivosSalon(int idSalon)
        {
            try
            {
                DataTable dt = objSalon.ObtenerActivosPorSalon(idSalon);

                dgvSalonClases.DataSource = null;
                dgvSalonClases.DataSource = dt;

                if (dgvSalonClases.Columns["IdSalon"] != null)
                    dgvSalonClases.Columns["IdSalon"].Visible = false;

                if (dgvSalonClases.Columns["IdActivo"] != null)
                    dgvSalonClases.Columns["IdActivo"].Visible = false;

                if (dgvSalonClases.Columns["CodigoInventario"] != null)
                {
                    dgvSalonClases.Columns["CodigoInventario"].Visible = true;
                    dgvSalonClases.Columns["CodigoInventario"].HeaderText = "Código de Inventario";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar activos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbSalones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSalones.SelectedValue != null && int.TryParse(cmbSalones.SelectedValue.ToString(), out int idSalon))
            {
                CargarTablaActivosSalon(idSalon);
                ActualizarInterfazYCodigo();
            }
        }

        private void cmbActivosDisponibles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarInterfazYCodigo();
        }

        private string GenerarCodigoCorto(int idActivo, int idSalon)
        {
            string prefijoActivo = "";

            using (SqlConnection conexion = Conexion.Conectar())
            {
                conexion.Open();
                string queryPrefijo = "SELECT Nombre FROM GestionActivos WHERE IdActivo = @IdActivo";
                using (SqlCommand cmdPrefijo = new SqlCommand(queryPrefijo, conexion))
                {
                    cmdPrefijo.Parameters.AddWithValue("@IdActivo", idActivo);
                    object resultado = cmdPrefijo.ExecuteScalar();
                    if (resultado != null)
                    {
                        string nombreActivo = resultado.ToString().Trim();
                        prefijoActivo = nombreActivo.Substring(0, Math.Min(3, nombreActivo.Length)).ToUpper();
                    }
                    else
                    {
                        prefijoActivo = "ACT";
                    }
                }
            }

            int correlativo = 1;
            string codigoGenerado = "";
            bool existe = true;

            using (SqlConnection conexion = Conexion.Conectar())
            {
                conexion.Open();

                while (existe)
                {
                    codigoGenerado = $"{prefijoActivo}-S{idSalon}-{correlativo:D3}";

                    string queryVerificar = "SELECT COUNT(*) FROM UnidadesActivo WHERE CodigoInventario = @Codigo";
                    using (SqlCommand cmd = new SqlCommand(queryVerificar, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Codigo", codigoGenerado);
                        int cantidad = Convert.ToInt32(cmd.ExecuteScalar());

                        if (cantidad == 0)
                        {
                            existe = false;
                        }
                        else
                        {
                            correlativo++;
                        }
                    }
                }
            }

            return codigoGenerado;
        }

        private void ActualizarInterfazYCodigo()
        {
            if (cmbActivosDisponibles.SelectedValue != null && cmbSalones.SelectedValue != null &&
                int.TryParse(cmbActivosDisponibles.SelectedValue.ToString(), out int idActivo) &&
                int.TryParse(cmbSalones.SelectedValue.ToString(), out int idSalon))
            {
                bool requiereSerial = false;

                using (SqlConnection conexion = Conexion.Conectar())
                {
                    conexion.Open();
                    string query = "SELECT C.RequiereSerial FROM GestionActivos A INNER JOIN Categorias C ON A.IdCategoria = C.IdCategoria WHERE A.IdActivo = @IdActivo";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@IdActivo", idActivo);
                        object resultado = cmd.ExecuteScalar();
                        if (resultado != null && resultado != DBNull.Value)
                        {
                            requiereSerial = Convert.ToBoolean(resultado);
                        }
                    }
                }

                if (requiereSerial)
                {
                    numCantidad.Visible = false;
                    txtCodigoInventario.Visible = true;
                    if (lblCodigoInventario != null) lblCodigoInventario.Visible = true;

                    if (lblCantidadAgregar != null)
                    {
                        lblCantidadAgregar.Text = "Código de inventario:";
                    }
                    else
                    {
                        if (lblCodigoInventario != null) lblCodigoInventario.Text = "Código de inventario:";
                    }

                    txtCodigoInventario.Text = GenerarCodigoCorto(idActivo, idSalon);
                    errorProvider1.SetError(txtCodigoInventario, string.Empty);
                }
                else
                {
                    numCantidad.Visible = true;
                    numCantidad.Value = 1;
                    txtCodigoInventario.Visible = false;
                    if (lblCodigoInventario != null) lblCodigoInventario.Visible = false;
                    errorProvider1.SetError(txtCodigoInventario, string.Empty);

                    if (lblCantidadAgregar != null)
                    {
                        lblCantidadAgregar.Text = "Ingrese la cantidad";
                    }
                }
            }
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (cmbSalones.SelectedValue == null || cmbActivosDisponibles.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un salón y un activo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idSalon = Convert.ToInt32(cmbSalones.SelectedValue);
            int idActivo = Convert.ToInt32(cmbActivosDisponibles.SelectedValue);

            try
            {
                if (txtCodigoInventario.Visible)
                {
                    string codigoInventario = txtCodigoInventario.Text.Trim();

                    if (string.IsNullOrEmpty(codigoInventario))
                    {
                        errorProvider1.SetError(txtCodigoInventario, "El código de inventario no puede estar vacío.");
                        MessageBox.Show("Por favor, ingresa un código de inventario válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        errorProvider1.SetError(txtCodigoInventario, string.Empty);
                    }

                    int estadoPorDefecto = objSalon.ObtenerIdEstadoInicial();
                    string queryInsert = "INSERT INTO UnidadesActivo (IdSalon, IdActivo, CodigoInventario, IdEstado) VALUES (@IdSalon, @IdActivo, @Codigo, @IdEstado)";

                    using (SqlConnection conexion = Conexion.Conectar())
                    {
                        conexion.Open();
                        using (SqlCommand cmd = new SqlCommand(queryInsert, conexion))
                        {
                            cmd.Parameters.AddWithValue("@IdSalon", idSalon);
                            cmd.Parameters.AddWithValue("@IdActivo", idActivo);
                            cmd.Parameters.AddWithValue("@Codigo", codigoInventario);
                            cmd.Parameters.AddWithValue("@IdEstado", estadoPorDefecto);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("¡Equipo individual asignado al salón correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarTablaActivosSalon(idSalon);
                    ActualizarInterfazYCodigo();
                }
                else
                {
                    int cantidad = (int)numCantidad.Value;

                    if (objSalon.AsignarActivo(idSalon, idActivo, cantidad))
                    {
                        MessageBox.Show("Activo asignado o actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarTablaActivosSalon(idSalon);
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    errorProvider1.SetError(txtCodigoInventario, "Este código ya existe.");
                    MessageBox.Show("El código de inventario generado ya existe. Intente de nuevo.", "Error de duplicidad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Error de base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (cmbSalones.SelectedValue == null)
            {
                MessageBox.Show("Por favor, selecciona un salón.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvSalonClases.SelectedRows.Count == 0 && dgvSalonClases.CurrentRow == null)
            {
                MessageBox.Show("Por favor, selecciona un activo de la tabla para quitar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idSalon = Convert.ToInt32(cmbSalones.SelectedValue);
                DataGridViewRow filaSeleccionada = dgvSalonClases.CurrentRow;
                int idActivo = Convert.ToInt32(filaSeleccionada.Cells["IdActivo"].Value);
                string codigoInventario = string.Empty;

                if (dgvSalonClases.Columns.Contains("CodigoInventario") && filaSeleccionada.Cells["CodigoInventario"].Value != null)
                {
                    codigoInventario = filaSeleccionada.Cells["CodigoInventario"].Value.ToString();
                }

                using (SqlConnection conexion = Conexion.Conectar())
                {
                    conexion.Open();

                    if (!string.IsNullOrEmpty(codigoInventario))
                    {
                        string queryDeleteIndividual = "DELETE FROM UnidadesActivo WHERE IdSalon = @IdSalon AND IdActivo = @IdActivo AND CodigoInventario = @Codigo";
                        using (SqlCommand cmd = new SqlCommand(queryDeleteIndividual, conexion))
                        {
                            cmd.Parameters.AddWithValue("@IdSalon", idSalon);
                            cmd.Parameters.AddWithValue("@IdActivo", idActivo);
                            cmd.Parameters.AddWithValue("@Codigo", codigoInventario);

                            int borradas;
                            try { borradas = cmd.ExecuteNonQuery(); }
                            catch (SqlException ex) when (ex.Number == 547)
                            {
                                MessageBox.Show("Esa unidad tiene préstamos, mantenimientos o reportes de daño registrados y no se puede eliminar.\n\n" +
                                                "Para retirarla del uso cambie su estado a 'Dado de baja' (Gestión de activos > ficha > Ubicación).",
                                                "Operación cancelada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            if (borradas > 0)
                            {
                                MessageBox.Show($"La unidad con código '{codigoInventario}' fue retirada del salón correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("El activo seleccionado no se encuentra registrado en este salón.", "Restricción de inventario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Seleccione en la tabla la unidad (código de inventario) que desea retirar del salón.",
                                        "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                CargarTablaActivosSalon(idSalon);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al quitar el activo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSalonClases_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnBuscarActivoSalones_Click(object sender, EventArgs e)
        {
            if (cmbSalones.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un salón primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string criterio = txtNombreActivoSalon.Text.Trim();
            int idSalon = Convert.ToInt32(cmbSalones.SelectedValue);

            if (string.IsNullOrWhiteSpace(criterio))
            {
                errorProvider1.SetError(txtNombreActivoSalon, "Ingrese un nombre para buscar.");
                MessageBox.Show("Por favor, ingresa el nombre de un activo para realizar la búsqueda.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                errorProvider1.SetError(txtNombreActivoSalon, string.Empty);
            }

            try
            {
                DataTable dt = objSalon.BuscarActivosEnSalon(idSalon, criterio);
                dgvSalonClases.DataSource = dt;

                if (dgvSalonClases.Columns["IdSalon"] != null) dgvSalonClases.Columns["IdSalon"].Visible = false;
                if (dgvSalonClases.Columns["IdActivo"] != null) dgvSalonClases.Columns["IdActivo"].Visible = false;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron activos que coincidan con la búsqueda en este salón.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSalonClases_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSalonClases.CurrentRow != null)
            {
                bool esEquipoIndividual = dgvSalonClases.Columns.Contains("CodigoInventario") &&
                                          dgvSalonClases.CurrentRow.Cells["CodigoInventario"].Value != null &&
                                          !string.IsNullOrEmpty(dgvSalonClases.CurrentRow.Cells["CodigoInventario"].Value.ToString());

                if (esEquipoIndividual)
                {
                    numCantidadQuitar.Value = 1;
                    numCantidadQuitar.Enabled = false;
                }
                else
                {
                    numCantidadQuitar.Enabled = true;
                }
            }
        }

        private void txtCodigoInventario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
                errorProvider1.SetError(txtCodigoInventario, "Solo se permiten letras, números y guiones.");
            }
            else
            {
                errorProvider1.SetError(txtCodigoInventario, string.Empty);
            }
        }

        private void txtNombreActivoSalon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtNombreActivoSalon, "Solo se permiten letras y espacios.");
            }
            else
            {
                errorProvider1.SetError(txtNombreActivoSalon, string.Empty);
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnExportarPdf_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = Vistas.Consultar("SELECT * FROM vw_ResumenActivosPorSalon ORDER BY NombreSalon");
                ExportadorPdf.Exportar("Resumen de activos por salón", dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar la vista: " + ex.Message);
            }
        }
    }
}
