using Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Vistass
{
    public partial class frmCatalogoSalarios : Form
    {
        private DataTable dtEstructuras;
        private DataView vista;
        private bool esAdmin = false;

        public frmCatalogoSalarios()
        {
            InitializeComponent();
        }

        private void frmCatalogoSalarios_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnNuevaEstructura, "Crear una estructura salarial nueva");
            toolTip1.SetToolTip(btnEditarEstructura, "Editar la estructura seleccionada (también con doble clic)");
            toolTip1.SetToolTip(btnEliminarEstructura, "Eliminar la estructura seleccionada (solo si ningún empleado la usa)");
            toolTip1.SetToolTip(btnExportarPdf, "Exportar a PDF lo que se está viendo");
            toolTip1.SetToolTip(btnVerEmpleados, "Ver los empleados que tienen asignada la estructura seleccionada");

            esAdmin = Sesion.Rol != null && Sesion.Rol.Trim().Equals("Administrador", StringComparison.OrdinalIgnoreCase);
            btnNuevaEstructura.Enabled = esAdmin;

            MostrarEstructuras(0);
            ActualizarBotones();
        }

        // ---------------------------------------------------------------
        //  Buscador: lupa, borde que se vuelve amarillo al enfocarse y texto de ayuda
        // ---------------------------------------------------------------
        private void pnlLupa_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen p = new Pen(PaletaSistema.Tenue, 1.8f))
            {
                p.StartCap = LineCap.Round;
                p.EndCap = LineCap.Round;
                e.Graphics.DrawEllipse(p, 8, 6, 9, 9);
                e.Graphics.DrawLine(p, 15.5f, 13.5f, 19f, 17f);
            }
        }

        private void pnlBuscador_Paint(object sender, PaintEventArgs e)
        {
            Color borde = txtBuscar.Focused ? PaletaSistema.Amarillo : Color.FromArgb(60, 66, 88);
            using (Pen p = new Pen(borde))
                e.Graphics.DrawRectangle(p, 0, 0, pnlBuscador.Width - 1, pnlBuscador.Height - 1);
        }

        private void txtBuscar_FocoCambiado(object sender, EventArgs e)
        {
            pnlBuscador.Invalidate();
        }

        // el texto de ayuda está encima de la caja: un clic sobre él enfoca la caja
        private void lblBuscarHint_Click(object sender, EventArgs e)
        {
            txtBuscar.Focus();
        }

        // ---------------------------------------------------------------
        //  Tabla
        // ---------------------------------------------------------------
        private void MostrarEstructuras(int idSeleccionar)
        {
            try
            {
                dtEstructuras = Datos.Tabla(
                    @"SELECT p.IdPlanilla, p.SalarioBase, p.Bono, p.Descuento, p.SalarioNeto,
                             (SELECT COUNT(*) FROM Empleados e
                              WHERE e.IdPlanilla = p.IdPlanilla AND e.IdEstado <> 2) AS Empleados
                      FROM Planillas p
                      WHERE ISNULL(p.Estado, 1) = 1
                         OR EXISTS (SELECT 1 FROM Empleados e WHERE e.IdPlanilla = p.IdPlanilla)
                      ORDER BY p.IdPlanilla");

                vista = new DataView(dtEstructuras);
                dgvEstructuras.DataSource = vista;
                FormatearGrid();
                AplicarFiltro();
                if (idSeleccionar > 0) SeleccionarFila(idSeleccionar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el catálogo: " + ex.Message, "Error SQL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SeleccionarFila(int idPlanilla)
        {
            foreach (DataGridViewRow r in dgvEstructuras.Rows)
            {
                if (Convert.ToInt32(r.Cells["IdPlanilla"].Value) == idPlanilla)
                {
                    dgvEstructuras.CurrentCell = r.Cells["IdPlanilla"];
                    break;
                }
            }
        }

        private void FormatearGrid()
        {
            if (dgvEstructuras.Columns.Count == 0) return;

            // los títulos nunca se parten en dos líneas
            dgvEstructuras.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

            Columna("IdPlanilla", "N°", 8);
            Columna("SalarioBase", "Salario base", 18);
            Columna("Bono", "Bono", 16);
            Columna("Descuento", "Descuento", 16);
            Columna("SalarioNeto", "Salario neto", 18);
            Columna("Empleados", "Empleados asignados", 20);

            // el N° es discreto: lo que destaca son los montos
            dgvEstructuras.Columns["IdPlanilla"].DefaultCellStyle.ForeColor = PaletaSistema.Tenue;

            // montos a la derecha (también sus títulos) para compararlos de un vistazo
            foreach (string m in new[] { "SalarioBase", "Bono", "Descuento", "SalarioNeto" })
            {
                DataGridViewColumn c = dgvEstructuras.Columns[m];
                c.DefaultCellStyle.Format = "N2";
                c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                c.DefaultCellStyle.Padding = new Padding(8, 0, 24, 0);
                c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                c.HeaderCell.Style.Padding = new Padding(8, 0, 24, 0);
            }
            dgvEstructuras.Columns["SalarioNeto"].DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvEstructuras.Columns["Empleados"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEstructuras.Columns["Empleados"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void Columna(string nombre, string encabezado, float peso)
        {
            if (!dgvEstructuras.Columns.Contains(nombre)) return;
            dgvEstructuras.Columns[nombre].HeaderText = encabezado;
            dgvEstructuras.Columns[nombre].FillWeight = peso;
        }

        private void dgvEstructuras_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null || dgvEstructuras.Columns[e.ColumnIndex].Name != "Empleados") return;
            int n = Convert.ToInt32(e.Value);
            if (n == 0)
            {
                e.Value = "Sin asignar";
                e.FormattingApplied = true;
                e.CellStyle.ForeColor = Color.FromArgb(150, 160, 182);
                e.CellStyle.SelectionForeColor = Color.White;
            }
        }

        // ---------------------------------------------------------------
        //  Búsqueda en vivo
        // ---------------------------------------------------------------
        private static string Escapar(string t)
        {
            return t.Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("*", "[*]");
        }

        private void AplicarFiltro()
        {
            if (vista == null) return;

            string t = txtBuscar.Text.Trim();
            if (t.Length > 0)
            {
                string esc = Escapar(t);
                vista.RowFilter = "Convert(IdPlanilla, 'System.String') LIKE '%" + esc + "%'" +
                                  " OR Convert(SalarioBase, 'System.String') LIKE '%" + esc + "%'" +
                                  " OR Convert(Bono, 'System.String') LIKE '%" + esc + "%'" +
                                  " OR Convert(Descuento, 'System.String') LIKE '%" + esc + "%'" +
                                  " OR Convert(SalarioNeto, 'System.String') LIKE '%" + esc + "%'";
            }
            else vista.RowFilter = "";

            ActualizarTarjetas();
            ActualizarBotones();
        }

        // Las tarjetas se calculan con lo que se ve en la tabla (siguen a la búsqueda).
        // Se asume que base, bono y descuento son montos mensuales por empleado.
        private void ActualizarTarjetas()
        {
            decimal costo = 0, netoTotal = 0, descTotal = 0;
            int asignados = 0, sinUso = 0;
            decimal minNeto = 0, maxNeto = 0;
            int idMin = 0, idMax = 0, idTop = 0, empTop = 0;
            bool hay = false;

            foreach (DataRowView r in vista)
            {
                int id = Convert.ToInt32(r["IdPlanilla"]);
                decimal b = Convert.ToDecimal(r["SalarioBase"]);
                decimal bo = Convert.ToDecimal(r["Bono"]);
                decimal d = Convert.ToDecimal(r["Descuento"]);
                decimal n = Convert.ToDecimal(r["SalarioNeto"]);
                int emp = Convert.ToInt32(r["Empleados"]);

                costo += (b + bo) * emp;          // lo que le cuesta al colegio (el descuento lo retiene del empleado)
                netoTotal += n * emp;
                descTotal += d * emp;
                asignados += emp;
                if (emp == 0) sinUso++;

                if (!hay || n < minNeto) { minNeto = n; idMin = id; }
                if (!hay || n > maxNeto) { maxNeto = n; idMax = id; }
                hay = true;

                if (emp > empTop) { empTop = emp; idTop = id; }
            }

            // 1. Costo mensual
            lblCostoValor.Text = "$" + costo.ToString("N2");
            lblCostoDetalle.Text = hay
                ? "Neto $" + netoTotal.ToString("N2") + "  ·  Descuentos $" + descTotal.ToString("N2")
                : "Sin estructuras";

            // 2. Estructuras sin empleados activos: verde si todas se usan, ámbar si alguna está libre
            lblSinUsoValor.Text = sinUso.ToString();
            lblSinUsoDetalle.Text = sinUso == 0 ? "Todas están en uso" : "Sin empleados activos";
            Color color = sinUso == 0 ? Color.FromArgb(134, 239, 172) : Color.FromArgb(252, 211, 77);
            lblSinUsoValor.ForeColor = color;
            pnlAcSinUso.BackColor = sinUso == 0 ? Color.FromArgb(74, 222, 128) : Color.FromArgb(251, 191, 36);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            lblBuscarHint.Visible = txtBuscar.Text.Length == 0;
            AplicarFiltro();
        }

        // ---------------------------------------------------------------
        //  Selección y botones
        // ---------------------------------------------------------------
        private void dgvEstructuras_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarBotones();
        }

        private void ActualizarBotones()
        {
            bool haySeleccion = dgvEstructuras.CurrentRow != null && vista != null && vista.Count > 0;
            btnEditarEstructura.Enabled = esAdmin && haySeleccion;
            btnEliminarEstructura.Enabled = esAdmin && haySeleccion;

            // ver empleados: solo si la estructura tiene empleados activos asignados (cualquier rol puede verlos)
            btnVerEmpleados.Enabled = haySeleccion &&
                Convert.ToInt32(dgvEstructuras.CurrentRow.Cells["Empleados"].Value) > 0;
        }

        // doble clic en "Empleados asignados" abre la lista de empleados; en cualquier otra celda, edita
        private void dgvEstructuras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvEstructuras.Columns[e.ColumnIndex].Name == "Empleados") VerEmpleados();
            else if (esAdmin) EditarSeleccionada();
        }

        // ---------------------------------------------------------------
        //  Acciones
        // ---------------------------------------------------------------
        private void btnNuevaEstructura_Click(object sender, EventArgs e)
        {
            using (frmEstructuraSalarial frm = new frmEstructuraSalarial())
            {
                if (frm.ShowDialog(this) == DialogResult.OK) MostrarEstructuras(frm.IdGuardado);
            }
        }

        private void btnEditarEstructura_Click(object sender, EventArgs e)
        {
            EditarSeleccionada();
        }

        private void EditarSeleccionada()
        {
            if (dgvEstructuras.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una estructura de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int id = Convert.ToInt32(dgvEstructuras.CurrentRow.Cells["IdPlanilla"].Value);
            using (frmEstructuraSalarial frm = new frmEstructuraSalarial(id))
            {
                if (frm.ShowDialog(this) == DialogResult.OK) MostrarEstructuras(frm.IdGuardado);
            }
        }

        private void btnVerEmpleados_Click(object sender, EventArgs e)
        {
            VerEmpleados();
        }

        private void VerEmpleados()
        {
            if (dgvEstructuras.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvEstructuras.CurrentRow.Cells["IdPlanilla"].Value);
            using (frmEmpleadosEstructura frm = new frmEmpleadosEstructura(id))
            {
                frm.ShowDialog(this);
            }
        }

        private void btnEliminarEstructura_Click(object sender, EventArgs e)
        {
            if (dgvEstructuras.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una estructura de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int id = Convert.ToInt32(dgvEstructuras.CurrentRow.Cells["IdPlanilla"].Value);

            try
            {
                int asignados = Convert.ToInt32(Datos.Escalar(
                    "SELECT COUNT(*) FROM Empleados WHERE IdPlanilla = @id", Datos.P("@id", id)));

                if (asignados > 0)
                {
                    MessageBox.Show("La estructura N° " + id + " no se puede eliminar porque está asignada a " + asignados +
                        (asignados == 1 ? " empleado" : " empleados") + " (incluidos los dados de baja).\n\n" +
                        "Para eliminarla, primero asigne otra estructura a esos empleados desde Gestión de personal.",
                        "Estructura en uso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("¿Está seguro de eliminar la estructura N° " + id + "?", "Confirmación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

                Datos.Ejecutar("DELETE FROM Planillas WHERE IdPlanilla = @id", Datos.P("@id", id));
                MostrarEstructuras(0);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    MessageBox.Show("La estructura N° " + id + " está en uso y no se puede eliminar.",
                        "Estructura en uso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportarPdf_Click(object sender, EventArgs e)
        {
            if (vista == null || vista.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                DataTable dt = new DataTable();
                foreach (string c in new[] { "N°", "Salario base", "Bono", "Descuento", "Salario neto", "Empleados asignados" })
                    dt.Columns.Add(c);

                foreach (DataRowView r in vista)
                {
                    dt.Rows.Add(r["IdPlanilla"],
                                Convert.ToDecimal(r["SalarioBase"]).ToString("N2"),
                                Convert.ToDecimal(r["Bono"]).ToString("N2"),
                                Convert.ToDecimal(r["Descuento"]).ToString("N2"),
                                Convert.ToDecimal(r["SalarioNeto"]).ToString("N2"),
                                r["Empleados"]);
                }
                ExportadorPdf.Exportar("Catalogo de salarios", dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}