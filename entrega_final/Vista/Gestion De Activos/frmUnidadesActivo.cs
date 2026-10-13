using Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Vistass
{
    public partial class frmUnidadesActivo : Form
    {
        private readonly int idActivo;
        private readonly string nombreActivo;
        private readonly bool esAdmin;
        private DataTable dtUnidades;
        private DataView vista;
        private bool cargando = false;
        private Font fuenteEstado;      // la letra de la tabla en negrita (se crea una sola vez)

        public frmUnidadesActivo(int idActivo, string nombreActivo, bool esAdministrador)
        {
            InitializeComponent();
            this.idActivo = idActivo;
            this.nombreActivo = nombreActivo;
            this.esAdmin = esAdministrador;
            EstilizarGrid();
            CrearBotonAlta();
        }

        // Botón "+ Alta de unidades": registra más unidades de este mismo equipo (entran a la bodega)
        private void CrearBotonAlta()
        {
            bool esAdmin = Modelos.Sesion.Rol != null &&
                           Modelos.Sesion.Rol.Trim().Equals("Administrador", StringComparison.OrdinalIgnoreCase);
            if (!esAdmin) return;

            BotonTema alta = new BotonTema();
            alta.Text = "+ Alta de unidades";
            alta.Tipo = TipoBoton.Secundario;
            alta.Size = new Size(160, btnAplicar.Height);
            alta.Location = new Point(btnAplicar.Right + 12, btnAplicar.Top);
            alta.Click += (s, e) =>
            {
                using (frmAltaUnidades frm = new frmAltaUnidades(idActivo))
                    if (frm.ShowDialog(this) == DialogResult.OK) CargarUnidades();
            };
            btnCerrar.Parent.Controls.Add(alta);
        }

        private void frmUnidadesActivo_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = "Unidades de: " + nombreActivo;
            dgvUnidades.MultiSelect = true;

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

        private void EstilizarGrid()
        {
            DataGridView g = dgvUnidades;
            g.AllowUserToAddRows = false; g.AllowUserToDeleteRows = false; g.AllowUserToResizeRows = false;
            g.ReadOnly = true; g.RowHeadersVisible = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            g.ColumnHeadersHeight = 40; g.RowTemplate.Height = 36;
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
                                        @"SELECT IdUnidad, IdSalon, IdEstado, CodigoInventario, Ubicacion AS Salon, Estado,
                             CostoUnitario, FechaAdquisicion, Proveedor, FechaBaja, MotivoBaja
                      FROM vw_UnidadesDetalle WHERE IdActivo = @id ORDER BY Ubicacion, CodigoInventario",
                    Datos.P("@id", idActivo));

                // fecha y motivo de baja van juntos en una sola columna (vacía si la unidad no está dada de baja)
                dtUnidades.Columns.Add("Baja", typeof(string));
                bool hayBajas = false;
                foreach (DataRow r in dtUnidades.Rows)
                {
                    if (r["FechaBaja"] == DBNull.Value) continue;
                    string motivo = r["MotivoBaja"] == DBNull.Value ? "" : "  ·  " + r["MotivoBaja"];
                    r["Baja"] = ((DateTime)r["FechaBaja"]).ToString("dd/MM/yy") + motivo;
                    hayBajas = true;
                }

                vista = new DataView(dtUnidades);
                dgvUnidades.DataSource = vista;
                dgvUnidades.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;   // títulos en una sola línea
                foreach (string oculta in new[] { "IdUnidad", "IdSalon", "IdEstado", "FechaBaja", "MotivoBaja" })
                    dgvUnidades.Columns[oculta].Visible = false;

                Col("CodigoInventario", "Código", 20, null, 140);
                Col("Salon", "Salón", 18, null, 110);
                Col("Estado", "Estado", 13, null, 120);
                Col("CostoUnitario", "Costo", 9, "N2", 75);
                Col("FechaAdquisicion", "Compra", 10, "dd/MM/yy", 85);
                Col("Proveedor", "Proveedor", 18, null, 110);
                Col("Baja", "Baja y motivo", 28, null, 150);
                dgvUnidades.Columns["Baja"].Visible = hayBajas;       // sin unidades dadas de baja no hace falta la columna

                // el costo se lee mejor alineado a la derecha, la fecha centrada
                dgvUnidades.Columns["CostoUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvUnidades.Columns["CostoUnitario"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvUnidades.Columns["FechaAdquisicion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvUnidades.Columns["FechaAdquisicion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
        private void Col(string nombre, string titulo, float peso, string formato, int anchoMinimo)
        {
            if (!dgvUnidades.Columns.Contains(nombre)) return;
            DataGridViewColumn c = dgvUnidades.Columns[nombre];
            c.HeaderText = titulo;
            c.FillWeight = peso;
            c.MinimumWidth = anchoMinimo;
            if (formato != null) c.DefaultCellStyle.Format = formato;
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
                string motivo = null;
                if (cmbNuevoEstado.Text == "Dado de baja")
                {
                    motivo = PedirMotivoBaja(texto);
                    if (motivo == null) return;                      
                }

                Datos.Procedimiento("sp_CambiarEstadoUnidades",
                    Datos.P("@IdActivo", idActivo),
                    Datos.P("@IdEstado", idEstado),
                    Datos.P("@Ids", string.Join(",", ids)),
                    Datos.PTexto("@Motivo", motivo));

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



        // Pide el motivo de la baja; devuelve null si se cancela
        private string PedirMotivoBaja(string descripcion)
        {
            string resultado = null;
            using (Form f = new Form())
            {
                f.Text = "Motivo de la baja";
                f.FormBorderStyle = FormBorderStyle.FixedDialog;
                f.MaximizeBox = false; f.MinimizeBox = false; f.ShowInTaskbar = false;
                f.StartPosition = FormStartPosition.CenterParent;
                f.ClientSize = new Size(440, 230);
                f.BackColor = Color.FromArgb(27, 29, 38);
                f.ForeColor = Color.FromArgb(240, 244, 252);
                f.Font = new Font("Segoe UI", 10F);

                Label lbl = new Label();
                lbl.Text = "Se dará de baja " + descripcion + ".\nIndique el motivo (queda registrado):";
                lbl.AutoSize = false; lbl.Location = new Point(20, 16); lbl.Size = new Size(400, 44);
                f.Controls.Add(lbl);

                TextBox txt = new TextBox();
                txt.Multiline = true; txt.MaxLength = 300;
                txt.Location = new Point(20, 66); txt.Size = new Size(400, 90);
                txt.BackColor = Color.FromArgb(38, 42, 58); txt.ForeColor = Color.FromArgb(240, 244, 252);
                txt.BorderStyle = BorderStyle.FixedSingle;
                f.Controls.Add(txt);

                BotonTema ok = new BotonTema();
                ok.Text = "Dar de baja"; ok.Tipo = TipoBoton.Peligro;
                ok.Location = new Point(20, 176); ok.Size = new Size(150, 38);
                BotonTema cancelar = new BotonTema();
                cancelar.Text = "Cancelar"; cancelar.Tipo = TipoBoton.Secundario;
                cancelar.Location = new Point(182, 176); cancelar.Size = new Size(110, 38);
                cancelar.DialogResult = DialogResult.Cancel;
                f.Controls.Add(ok); f.Controls.Add(cancelar);
                f.CancelButton = cancelar;

                ok.Click += (s, e) =>
                {
                    if (txt.Text.Trim().Length < 5)
                    {
                        MessageBox.Show("Escriba el motivo (mínimo 5 caracteres).", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    resultado = txt.Text.Trim();
                    f.DialogResult = DialogResult.OK;
                };
                f.ShowDialog(this);
            }
            return resultado;
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

            if (color.HasValue)
            {
                e.CellStyle.ForeColor = color.Value;
                if (fuenteEstado == null) fuenteEstado = new Font(dgvUnidades.Font, FontStyle.Bold);
                e.CellStyle.Font = fuenteEstado;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}