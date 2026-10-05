using Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vistass
{
    public partial class frmReportarDaño : Form
    {
        private ReportaDaño objReporte = new ReportaDaño();
        private int idActivoSeleccionadoGlobal = 0;        
        private int idActivoDañadoSeleccionadoGlobal = 0;  
        private int idReporteSeleccionado = 0;
        private bool mostrandoActivosSalon = false;

        public frmReportarDaño()
        {
            InitializeComponent();

  


            this.cmbSalonesReporte.SelectedIndexChanged += new EventHandler(this.cmbSalonesReporte_SelectedIndexChanged);
            this.dgvEquiposDañados.CellClick += new DataGridViewCellEventHandler(this.dgvEquiposDañados_CellClick);
        }

        private void frmReportarDaño_Load(object sender, EventArgs e)
        {
            CargarSalones();
            CargarTablaEquiposDañados();
        }

        private string UsuarioActual()
        {
          
            return Environment.UserName;
        }

        private void OcultarColumnas(params string[] nombres)
        {
            foreach (string nombre in nombres)
            {
                if (dgvEquiposDañados.Columns[nombre] != null)
                    dgvEquiposDañados.Columns[nombre].Visible = false;
            }
        }

        private void ActualizarBotones()
        {
            btnReportar.Enabled = mostrandoActivosSalon && idActivoSeleccionadoGlobal != 0;
            btnMarcarReparado.Enabled = !mostrandoActivosSalon && idReporteSeleccionado != 0;
        }


        private void CargarTablaEquiposDañados()
        {
            try
            {
                dgvEquiposDañados.DataSource = ReportaDaño.ListarAbiertos();
                mostrandoActivosSalon = false;

                OcultarColumnas("IdReporte", "IdSalon", "IdActivo");
                dgvEquiposDañados.ClearSelection();

                idActivoDañadoSeleccionadoGlobal = 0;
                idReporteSeleccionado = 0;
                lblTituloTabla.Text = "Reportes abiertos";
                ActualizarBotones();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los reportes abiertos: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarSalones()
        {
            try
            {
                using (SqlConnection conexion = Conexion.Conectar())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT IdSalon, NombreSalon FROM Salones", conexion);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbSalonesReporte.SelectedIndexChanged -= new EventHandler(this.cmbSalonesReporte_SelectedIndexChanged);

                    cmbSalonesReporte.DataSource = dt;
                    cmbSalonesReporte.DisplayMember = "NombreSalon";
                    cmbSalonesReporte.ValueMember = "IdSalon";
                    cmbSalonesReporte.SelectedIndex = -1;

                    cmbSalonesReporte.SelectedIndexChanged += new EventHandler(this.cmbSalonesReporte_SelectedIndexChanged);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los salones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbSalonesReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSalonesReporte.SelectedIndex != -1)
            {
                errorProvider.SetError(cmbSalonesReporte, string.Empty);
            }

            if (cmbSalonesReporte.SelectedIndex != -1 && cmbSalonesReporte.SelectedValue != null)
            {
                if (int.TryParse(cmbSalonesReporte.SelectedValue.ToString(), out int idSalon))
                {
                    CargarActivosDelSalon(idSalon);
                }
            }
        }

      
        private void CargarActivosDelSalon(int idSalon)
        {
            try
            {
                using (SqlConnection conexion = Conexion.Conectar())
                {
                    string query = @"
                    SELECT A.IdActivo, A.Nombre AS Activo, C.NombreCategoria AS Categoria, 1 AS Cantidad,
                           U.CodigoInventario, ES.NombreEstado AS Estado
                    FROM UnidadesActivo U
                    INNER JOIN GestionActivos A ON U.IdActivo = A.IdActivo
                    INNER JOIN Estados ES ON ES.IdEstado = U.IdEstado
                    LEFT JOIN Categorias C ON A.IdCategoria = C.IdCategoria
                    WHERE U.IdSalon = @IdSalon
                    ORDER BY A.Nombre, U.CodigoInventario";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@IdSalon", idSalon);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvEquiposDañados.DataSource = dt;
                        mostrandoActivosSalon = true;

                        OcultarColumnas("IdActivo");
                        dgvEquiposDañados.ClearSelection();

                        idActivoSeleccionadoGlobal = 0;
                        txtActivoSeleccionado.Clear();
                        lblTituloTabla.Text = "Equipos del salón: " + cmbSalonesReporte.Text;
                        ActualizarBotones();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los activos del salón: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEquiposDañados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvEquiposDañados.Rows[e.RowIndex];
            if (fila.Cells["Activo"].Value == null) return;

            if (mostrandoActivosSalon)
            {
                idActivoSeleccionadoGlobal = Convert.ToInt32(fila.Cells["IdActivo"].Value);
                txtActivoSeleccionado.Text = fila.Cells["Activo"].Value.ToString();
                errorProvider.SetError(txtActivoSeleccionado, string.Empty);
            }
            else
            {
                idActivoDañadoSeleccionadoGlobal = Convert.ToInt32(fila.Cells["IdActivo"].Value);
                idReporteSeleccionado = Convert.ToInt32(fila.Cells["IdReporte"].Value);
            }

            ActualizarBotones();
        }

        private void btnReportar_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            bool hayError = false;

            if (cmbSalonesReporte.SelectedIndex == -1 || cmbSalonesReporte.SelectedValue == null)
            {
                errorProvider.SetError(cmbSalonesReporte, "Debe seleccionar un salón.");
                hayError = true;
            }

            if (idActivoSeleccionadoGlobal == 0 || string.IsNullOrWhiteSpace(txtActivoSeleccionado.Text))
            {
                errorProvider.SetError(txtActivoSeleccionado, "Debe seleccionar un activo de la tabla para reportar.");
                hayError = true;
            }

            if (hayError) return;

            int idSalonActual = Convert.ToInt32(cmbSalonesReporte.SelectedValue);
            string nombreActivo = txtActivoSeleccionado.Text;

            string codigoInventarioSeleccionado = "";
            int cantidadDisponible = 1;

            if (dgvEquiposDañados.CurrentRow != null)
            {
                if (dgvEquiposDañados.Columns["CodigoInventario"] != null)
                    codigoInventarioSeleccionado = dgvEquiposDañados.CurrentRow.Cells["CodigoInventario"].Value?.ToString() ?? "";

                if (dgvEquiposDañados.Columns["Cantidad"] != null && dgvEquiposDañados.CurrentRow.Cells["Cantidad"].Value != null)
                    cantidadDisponible = Convert.ToInt32(dgvEquiposDañados.CurrentRow.Cells["Cantidad"].Value);
            }

            string etiqueta = nombreActivo
                + (string.IsNullOrEmpty(codigoInventarioSeleccionado) ? "" : " - " + codigoInventarioSeleccionado)
                + " - " + cmbSalonesReporte.Text;

            using (frmDialogoDaño dlg = new frmDialogoDaño("Reportar daño", etiqueta, true, cantidadDisponible))
            {
                if (dlg.ShowDialog(this) != DialogResult.OK) return;

                try
                {

              
                    ReportaDaño.Registrar(idSalonActual, idActivoSeleccionadoGlobal, codigoInventarioSeleccionado,
                                           dlg.Cantidad, dlg.Prioridad, dlg.Texto, UsuarioActual());

                  
                    if (!objReporte.CambiarEstadoMantenimientoPorSalon(idActivoSeleccionadoGlobal, idSalonActual, codigoInventarioSeleccionado))
                    {
                        MessageBox.Show("El reporte se guardó, pero no se pudo actualizar el estado del equipo. Avise al administrador.",
                                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("El daño fue reportado y el equipo pasó a mantenimiento.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    CargarTablaEquiposDañados();
                    CargarActivosDelSalon(idSalonActual);

                    txtActivoSeleccionado.Clear();
                    idActivoSeleccionadoGlobal = 0;
                    errorProvider.Clear();
                    ActualizarBotones();
                }
                catch (SqlException ex) when (ex.Number == 2601 || ex.Number == 2627)
                {
                    MessageBox.Show("Ese equipo ya tiene un reporte abierto. Ciérrelo antes de reportarlo de nuevo.",
                                    "Reporte duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnMarcarReparado_Click(object sender, EventArgs e)
        {
            if (idReporteSeleccionado == 0) return;

            string nombreActivo = "Equipo";
            string codigoInventarioSeleccionado = "";
            string nombreSalonSeleccionado = "";

            if (dgvEquiposDañados.CurrentRow != null)
            {
                DataGridViewRow fila = dgvEquiposDañados.CurrentRow;

                if (fila.Cells["Activo"].Value != null)
                    nombreActivo = fila.Cells["Activo"].Value.ToString();

                if (dgvEquiposDañados.Columns["CodigoInventario"] != null && fila.Cells["CodigoInventario"].Value != null)
                    codigoInventarioSeleccionado = fila.Cells["CodigoInventario"].Value.ToString();

                if (dgvEquiposDañados.Columns["Salon"] != null && fila.Cells["Salon"].Value != null)
                    nombreSalonSeleccionado = fila.Cells["Salon"].Value.ToString();
            }

            string etiqueta = nombreActivo
                + (string.IsNullOrEmpty(codigoInventarioSeleccionado) ? "" : " - " + codigoInventarioSeleccionado)
                + (string.IsNullOrEmpty(nombreSalonSeleccionado) ? "" : " - " + nombreSalonSeleccionado);

            using(frmDialogoDaño dlg = new frmDialogoDaño("Marcar como reparado", etiqueta, false, 1))

            {
                if (dlg.ShowDialog(this) != DialogResult.OK) return;

                int idAReparar = idActivoDañadoSeleccionadoGlobal;
                int idReporte = idReporteSeleccionado;

                try
                {
                    if (objReporte.CambiarEstadoABueno(idAReparar, codigoInventarioSeleccionado, nombreSalonSeleccionado))
                    {
                        ReportaDaño.Resolver(idReporte, dlg.Texto, UsuarioActual());
                        CargarTablaEquiposDañados();
                        MessageBox.Show("El equipo fue marcado como reparado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el estado del equipo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo cerrar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

  
        private void btnVerReportes_Click(object sender, EventArgs e)
        {
            cmbSalonesReporte.SelectedIndexChanged -= new EventHandler(this.cmbSalonesReporte_SelectedIndexChanged);
            cmbSalonesReporte.SelectedIndex = -1;
            cmbSalonesReporte.SelectedIndexChanged += new EventHandler(this.cmbSalonesReporte_SelectedIndexChanged);

            txtActivoSeleccionado.Clear();
            idActivoSeleccionadoGlobal = 0;
            errorProvider.Clear();
            CargarTablaEquiposDañados();
        }

        private void frmReportarDaño_Load_1(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(txtActivoSeleccionado, "Equipo elegido en la tabla.");
            toolTip1.SetToolTip(cmbSalonesReporte, "Seleccione un salón para ver sus equipos.");
            toolTip1.SetToolTip(btnReportar, "Reportar el equipo seleccionado como dañado.");
            toolTip1.SetToolTip(btnMarcarReparado, "Cerrar el reporte seleccionado como reparado.");
            toolTip1.SetToolTip(btnVerReportes, "Volver a la lista de reportes abiertos.");
            EstilizarGrid();          
            CargarSalones();
            CargarTablaEquiposDañados();
        }
        private void EstilizarGrid()
        {
            dgvEquiposDañados.EnableHeadersVisualStyles = false;

            dgvEquiposDañados.DefaultCellStyle.BackColor = Color.White;
            dgvEquiposDañados.DefaultCellStyle.ForeColor = Color.Black;
            dgvEquiposDañados.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgvEquiposDañados.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

            dgvEquiposDañados.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 212);
            dgvEquiposDañados.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvEquiposDañados.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            dgvEquiposDañados.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void pnlEncabezado_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}