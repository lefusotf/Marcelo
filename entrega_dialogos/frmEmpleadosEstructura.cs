using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Vistass
{
    public partial class frmEmpleadosEstructura : Form
    {
        private static readonly CultureInfo Inv = CultureInfo.InvariantCulture;
        private readonly int idPlanilla;

        public frmEmpleadosEstructura() : this(0) { }

        public frmEmpleadosEstructura(int idPlanilla)
        {
            InitializeComponent();
            this.idPlanilla = idPlanilla;
        }

        private void frmEmpleadosEstructura_Load(object sender, EventArgs e)
        {
            lblTituloForm.Text = "Estructura N° " + idPlanilla;
            EstilizarGrid();

            try
            {
                // montos de la estructura
                DataTable est = Datos.Tabla(
                    "SELECT SalarioBase, Bono, Descuento, SalarioNeto FROM Planillas WHERE IdPlanilla = @id",
                    Datos.P("@id", idPlanilla));
                if (est.Rows.Count > 0)
                {
                    DataRow r = est.Rows[0];
                    lblSubtituloForm.Text =
                        "Base $" + Convert.ToDecimal(r["SalarioBase"]).ToString("N2", Inv) +
                        "   ·   Bono $" + Convert.ToDecimal(r["Bono"]).ToString("N2", Inv) +
                        "   ·   Descuento $" + Convert.ToDecimal(r["Descuento"]).ToString("N2", Inv) +
                        "   ·   Neto $" + Convert.ToDecimal(r["SalarioNeto"]).ToString("N2", Inv);
                }

                // todos los empleados con esta estructura; los dados de baja van al final
                DataTable dt = Datos.Tabla(
                    @"SELECT e.IdEmpleado, e.Nombre, c.NombreCargo AS Cargo, est.NombreEstado AS Estado,
                             e.FechaContratacion
                      FROM Empleados e
                      INNER JOIN Cargos c ON c.IdCargo = e.IdCargo
                      INNER JOIN EstadosEmpleado est ON est.IdEstado = e.IdEstado
                      WHERE e.IdPlanilla = @id
                      ORDER BY CASE WHEN e.IdEstado = 2 THEN 1 ELSE 0 END, e.Nombre",
                    Datos.P("@id", idPlanilla));

                dgvEmpleados.DataSource = dt;
                FormatearGrid();

                int total = dt.Rows.Count;
                int bajas = 0;
                foreach (DataRow r in dt.Rows)
                    if (Convert.ToString(r["Estado"]) == "Inactivo") bajas++;
                int activos = total - bajas;

                if (total == 0)
                    lblResumen.Text = "Ningún empleado tiene asignada esta estructura.";
                else
                    lblResumen.Text = total + (total == 1 ? " empleado" : " empleados") + "   ·   " +
                                      activos + (activos == 1 ? " activo" : " activos") +
                                      (bajas > 0 ? "   ·   " + bajas + " dado(s) de baja" : "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los empleados: " + ex.Message, "Error SQL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EstilizarGrid()
        {
            DataGridView g = dgvEmpleados;
            g.AllowUserToAddRows = false; g.AllowUserToDeleteRows = false; g.AllowUserToResizeRows = false;
            g.ReadOnly = true; g.RowHeadersVisible = false; g.MultiSelect = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            g.ColumnHeadersHeight = 40; g.RowTemplate.Height = 36;


        }

        private void FormatearGrid()
        {
            if (dgvEmpleados.Columns.Count == 0) return;
            Columna("IdEmpleado", "ID", 7);
            Columna("Nombre", "Nombre", 32);
            Columna("Cargo", "Cargo", 24);
            Columna("Estado", "Estado", 13);
            Columna("FechaContratacion", "Contratación", 16);
            dgvEmpleados.Columns["FechaContratacion"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void Columna(string nombre, string encabezado, float peso)
        {
            if (!dgvEmpleados.Columns.Contains(nombre)) return;
            dgvEmpleados.Columns[nombre].HeaderText = encabezado;
            dgvEmpleados.Columns[nombre].FillWeight = peso;
        }

        // activo en verde; el dado de baja se ve completo en gris
        private void dgvEmpleados_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string estado = Convert.ToString(dgvEmpleados.Rows[e.RowIndex].Cells["Estado"].Value);

            if (estado == "Inactivo")
            {
                e.CellStyle.ForeColor = Color.FromArgb(150, 155, 170);
                e.CellStyle.SelectionForeColor = Color.White;
            }
            else if (dgvEmpleados.Columns[e.ColumnIndex].Name == "Estado")
            {
                e.CellStyle.ForeColor = estado == "Activo" ? Color.FromArgb(134, 239, 172) : Color.FromArgb(252, 211, 77);
                e.CellStyle.SelectionForeColor = Color.White;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}