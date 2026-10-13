using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Modelos;
namespace Vistass
{
    public partial class frmAsignarEquipo : Form
    {
        private readonly int idSalon;
        private readonly string nombreSalon;
        private bool cargando = true;

        public frmAsignarEquipo() : this(0, "") { }

        public frmAsignarEquipo(int idSalon, string nombreSalon)
        {
            InitializeComponent();
            this.idSalon = idSalon;
            this.nombreSalon = nombreSalon;
        }

        private void frmAsignarEquipo_Load(object sender, EventArgs e)
        {
            lblSubtituloForm.Text = "Destino: " + nombreSalon;

            // solo se puede asignar lo que ya existe y está disponible en la bodega
            DataTable stock = Datos.Tabla(
                @"SELECT IdActivo,
                         Activo + N'   ·   ' + CAST(Disponibles AS VARCHAR(10)) + N' disponibles' AS Texto,
                         Categoria, Disponibles
                  FROM vw_StockBodega
                  WHERE Disponibles > 0
                  ORDER BY Activo");

            cmbEquipo.DataSource = stock;
            cmbEquipo.DisplayMember = "Texto";
            cmbEquipo.ValueMember = "IdActivo";
            cmbEquipo.SelectedIndex = -1;

            // la cantidad no puede pasar de lo que hay en la bodega (ni escribiéndola a mano)
            nudCantidad.Maximum = 1;
            nudCantidad.Enabled = false;
            NumericoLimitado.Aplicar(nudCantidad, errorProvider,
                () => "En la bodega solo hay " + nudCantidad.Maximum.ToString("0") + " disponibles.");

            if (stock.Rows.Count == 0)
            {
                lblInfoEquipo.Text = "No hay equipo disponible en la bodega.";
                btnGuardar.Enabled = false;
                MessageBox.Show("No hay equipo disponible en la bodega para asignar.\n\n" +
                                "Primero regístrelo con \"Alta de equipo\" (al elegir la bodega en Gestión de salones).",
                                "Bodega sin equipo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                lblInfoEquipo.Text = "Elija el equipo. La cantidad máxima es lo disponible en la bodega.";
            }

            cargando = false;
        }

        private void cmbEquipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargando) return;
            DataRowView fila = cmbEquipo.SelectedItem as DataRowView;
            if (fila == null) return;

            int disponibles = Convert.ToInt32(fila["Disponibles"]);
            nudCantidad.Enabled = true;
            nudCantidad.Maximum = Math.Max(1, disponibles);
            nudCantidad.Value = 1;
            lblInfoEquipo.Text = "Categoría: " + Convert.ToString(fila["Categoria"]) + ".  Disponibles en la bodega: " + disponibles + ".";
            errorProvider.Clear();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            DataRowView fila = cmbEquipo.SelectedItem as DataRowView;
            if (fila == null)
            {
                errorProvider.SetError(cmbEquipo, "Seleccione el equipo que desea asignar.");
                MessageBox.Show("Seleccione el equipo que desea asignar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nudCantidad.Value > Convert.ToInt32(fila["Disponibles"]))
            {
                errorProvider.SetError(nudCantidad, "En la bodega solo hay " + fila["Disponibles"] + " disponibles.");
                return;
            }

            try
            {
                Datos.Tabla("EXEC dbo.sp_AsignarUnidades @IdActivo = @a, @IdSalonDestino = @s, @Cantidad = @c",
                    Datos.P("@a", Convert.ToInt32(fila["IdActivo"])),
                    Datos.P("@s", idSalon),
                    Datos.P("@c", (int)nudCantidad.Value));
                DialogResult = DialogResult.OK;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "No se pudo asignar el equipo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al asignar el equipo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}