using Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Vistass
{
    // Gestión de las unidades individuales de UN tipo de activo (cada pupitre/equipo con su estado)
    public partial class frmUnidadesActivo : Form
    {
        private readonly int idActivo;
        private readonly string nombreActivo;
        private readonly bool esAdmin;
        private DataTable dtUnidades;
        private DataView vista;
        private bool cargando = false;

        public frmUnidadesActivo(int idActivo, string nombreActivo, bool esAdministrador)
        {
            InitializeComponent();
            this.idActivo = idActivo;
            this.nombreActivo = nombreActivo;
            this.esAdmin = esAdministrador;
            EstilizarGrid();
        }

        private void frmUnidadesActivo_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = "Unidades de: " + nombreActivo;

            cargando = true;
            DataTable estados = Datos.Tabla("SELECT IdEstado, NombreEstado FROM Estados ORDER BY IdEstado");
            LlenarCombo(cmbFSalon, Datos.Tabla("SELECT IdSalon, NombreSalon FROM Salones ORDER BY NombreSalon"),
                        "IdSalon", "NombreSalon", "Todos los salones");
            LlenarCombo(cmbFEstado, estados, "IdEstado", "NombreEstado", "Todos los estados");
            LlenarCombo(cmbNuevoEstado, estados, "IdEstado", "NombreEstado", null);
            cargando = false;

            cmbNuevoEstado.Enabled = esAdmin;
            btnAplicar.Enabled = false;
            if (!esAdmin) lblAccion.Text = "Solo el administrador puede cambiar estados.";

            CargarUnidades();
        }

        // ---------------------------------------------------------------
        //  Estilo de la tabla (mismo tema oscuro del resto del sistema)
        // ---------------------------------------------------------------
        private void EstilizarGrid()
        {
            DataGridView g = dgvUnidades;
            g.AllowUserToAddRows = false; g.AllowUserToDeleteRows = false; g.AllowUserToResizeRows = false;
            g.ReadOnly = true; g.RowHeadersVisible = false;
            g.MultiSelect = true;                                   // varias unidades a la vez
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            g.ColumnHeadersHeight = 36; g.RowTemplate.Height = 30;
        }

        private static void LlenarCombo(ComboBox c, DataTable dt, string id, string texto, string primera)
        {
            DataTable t = dt.Copy();
            if (primera != null)
            {
                DataRow r = t.NewRow();
                r[id] = 0; r[texto] = primera;
                t.Rows.InsertAt(r, 0);
            }
            c.DataSource = t; c.DisplayMember = texto; c.ValueMember = id;
        }

        // ---------------------------------------------------------------
        //  Carga y filtros
        // ---------------------------------------------------------------
        private void CargarUnidades()
        {
            try
            {
                dtUnidades = Datos.Tabla(
                    @"SELECT IdUnidad, IdSalon, IdEstado, CodigoInventario, Ubicacion AS Salon, Estado
                      FROM vw_UnidadesDetalle WHERE IdActivo = @id ORDER BY Ubicacion, CodigoInventario",
                    Datos.P("@id", idActivo));

                vista = new DataView(dtUnidades);
                dgvUnidades.DataSource = vista;
                dgvUnidades.Columns["IdUnidad"].Visible = false;
                dgvUnidades.Columns["IdSalon"].Visible = false;
                dgvUnidades.Columns["IdEstado"].Visible = false;
                dgvUnidades.Columns["CodigoInventario"].HeaderText = "Código de inventario";
                dgvUnidades.Columns["CodigoInventario"].FillWeight = 40;
                dgvUnidades.Columns["Salon"].HeaderText = "Salón";
                dgvUnidades.Columns["Salon"].FillWeight = 35;
                dgvUnidades.Columns["Estado"].HeaderText = "Estado";
                dgvUnidades.Columns["Estado"].FillWeight = 25;

                AplicarFiltro();
                dgvUnidades.ClearSelection();
                ActualizarSeleccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar las unidades: " + ex.Message, "Error SQL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string Escapar(string t)
        {
            return t.Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("*", "[*]");
        }

        private void AplicarFiltro()
        {
            if (vista == null) return;
            var cond = new List<string>();

            int idSalon;
            if (cmbFSalon.SelectedValue != null && int.TryParse(cmbFSalon.SelectedValue.ToString(), out idSalon) && idSalon > 0)
                cond.Add("IdSalon = " + idSalon);
            int idEstado;
            if (cmbFEstado.SelectedValue != null && int.TryParse(cmbFEstado.SelectedValue.ToString(), out idEstado) && idEstado > 0)
                cond.Add("IdEstado = " + idEstado);
            string t = txtFBuscar.Text.Trim();
            if (t.Length > 0)
                cond.Add("CodigoInventario LIKE '%" + Escapar(t) + "%'");

            vista.RowFilter = string.Join(" AND ", cond);
            ActualizarResumen();
        }

        // "11 unidades · Bueno: 8 · Regular: 3   |   mostrando 11"
        private void ActualizarResumen()
        {
            var grupos = dtUnidades.AsEnumerable()
                .GroupBy(r => Convert.ToString(r["Estado"]))
                .OrderBy(g => g.Key)
                .Select(g => g.Key + ": " + g.Count());
            lblResumen.Text = dtUnidades.Rows.Count + (dtUnidades.Rows.Count == 1 ? " unidad" : " unidades") +
                              "   ·   " + string.Join("   ·   ", grupos) +
                              "      |      mostrando " + vista.Count;
        }

        private void Filtro_Changed(object sender, EventArgs e)
        {
            if (cargando) return;
            AplicarFiltro();
            ActualizarSeleccion();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cargando = true;
            cmbFSalon.SelectedIndex = 0;
            cmbFEstado.SelectedIndex = 0;
            txtFBuscar.Clear();
            cargando = false;
            AplicarFiltro();
            ActualizarSeleccion();
        }

        // ---------------------------------------------------------------
        //  Selección y cambio de estado (una o varias unidades)
        // ---------------------------------------------------------------
        private void dgvUnidades_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarSeleccion();
        }

        private void ActualizarSeleccion()
        {
            int n = dgvUnidades.SelectedRows.Count;
            lblSeleccion.Text = n + (n == 1 ? " unidad seleccionada" : " unidades seleccionadas");
            btnAplicar.Enabled = esAdmin && n > 0;
        }

        private void btnSeleccionarTodo_Click(object sender, EventArgs e)
        {
            dgvUnidades.SelectAll();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (dgvUnidades.SelectedRows.Count == 0 || cmbNuevoEstado.SelectedValue == null) return;

            int idEstado = Convert.ToInt32(cmbNuevoEstado.SelectedValue);
            List<int> ids = dgvUnidades.SelectedRows.Cast<DataGridViewRow>()
                .Select(r => Convert.ToInt32(r.Cells["IdUnidad"].Value)).ToList();

            string texto = ids.Count == 1 ? "1 unidad" : ids.Count + " unidades";
            if (MessageBox.Show("Se cambiará el estado de " + texto + " a '" + cmbNuevoEstado.Text + "'.\n\n¿Continuar?",
                "Confirmar cambio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                // los ids son enteros leídos de la tabla; se envían en una sola instrucción (todo o nada)
                Datos.Ejecutar(
                    "UPDATE UnidadesActivo SET IdEstado = @e WHERE IdActivo = @a AND IdUnidad IN (" + string.Join(",", ids) + ")",
                    Datos.P("@e", idEstado), Datos.P("@a", idActivo));

                CargarUnidades();
                MessageBox.Show("Estado actualizado en " + texto + ".", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cambiar el estado: " + ex.Message, "Error SQL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Color del texto según el estado
        private void dgvUnidades_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null || dgvUnidades.Columns[e.ColumnIndex].Name != "Estado") return;
            string estado = e.Value.ToString();
            Color? color = null;
            if (estado == "Nuevo" || estado == "Excelente") color = Color.FromArgb(134, 239, 172);
            else if (estado == "Bueno") color = Color.FromArgb(190, 242, 100);
            else if (estado == "Regular") color = Color.FromArgb(252, 211, 77);
            else if (estado == "Malo" || estado == "Dado de baja" || estado == "En reparación" ||
                     estado.StartsWith("Mantenimiento")) color = Color.FromArgb(252, 165, 165);
            if (color == null) return;
            e.CellStyle.ForeColor = color.Value;
            e.CellStyle.SelectionForeColor = Color.White;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}