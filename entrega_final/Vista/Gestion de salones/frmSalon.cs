using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Modelos;

namespace Vistass
{
    public partial class frmSalon : Form
    {
        private static readonly string[] Tipos = { "Aula", "Laboratorio", "Biblioteca", "Oficina", "Bodega", "Auditorio", "Otro" };

        private readonly int idSalon;      // 0 = salón nuevo, > 0 = edición

        // salón guardado: la lista lo deja seleccionado al volver
        public int IdGuardado { get; private set; }

        public frmSalon() : this(0) { }

        public frmSalon(int idSalon)
        {
            InitializeComponent();
            BarrasOscuras.Aplicar(txtObservacion);      // barra de desplazamiento oscura
            this.idSalon = idSalon;
        }

        private void frmSalon_Load(object sender, EventArgs e)
        {
            bool edicion = idSalon > 0;
            lblTituloForm.Text = edicion ? "Editar salón" : "Nuevo salón";
            lblSubtituloForm.Text = edicion ? "Modifique los datos del espacio" : "Complete los datos del espacio";
            this.Text = lblTituloForm.Text;
            btnGuardar.Text = edicion ? "Guardar cambios" : "Guardar salón";

            cmbTipo.Items.AddRange(Tipos);
            cmbTipo.SelectedIndex = 0;

            DataRow salon = null;
            int idResponsableActual = 0;
            if (edicion)
            {
                DataTable ds = Datos.Tabla(
                    @"SELECT NombreSalon, Tipo, Capacidad, Edificio, IdResponsable, Observacion
                      FROM Salones WHERE IdSalon = @id", Datos.P("@id", idSalon));
                if (ds.Rows.Count == 0)
                {
                    MessageBox.Show("El salón ya no existe.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.Cancel;
                    return;
                }
                salon = ds.Rows[0];
                if (salon["IdResponsable"] != DBNull.Value) idResponsableActual = Convert.ToInt32(salon["IdResponsable"]);
            }

            // responsables: empleados activos (y el actual, aunque ya esté inactivo)
            DataTable resp = Datos.Tabla(
                @"SELECT IdEmpleado, Nombre FROM Empleados
                  WHERE IdEstado <> 2 OR IdEmpleado = @r
                  ORDER BY Nombre", Datos.P("@r", idResponsableActual));
            DataRow vacio = resp.NewRow();
            vacio["IdEmpleado"] = 0;
            vacio["Nombre"] = "— Sin responsable —";
            resp.Rows.InsertAt(vacio, 0);

            cmbResponsable.DataSource = resp;
            cmbResponsable.DisplayMember = "Nombre";
            cmbResponsable.ValueMember = "IdEmpleado";
            cmbResponsable.SelectedIndex = 0;

            if (edicion)
            {
                txtNombre.Text = Convert.ToString(salon["NombreSalon"]);
                string tipo = salon["Tipo"] == DBNull.Value ? "Otro" : Convert.ToString(salon["Tipo"]);
                int idx = Array.IndexOf(Tipos, tipo);
                cmbTipo.SelectedIndex = idx >= 0 ? idx : Tipos.Length - 1;
                nudCapacidad.Value = salon["Capacidad"] == DBNull.Value ? 0 : Convert.ToInt32(salon["Capacidad"]);
                txtEdificio.Text = salon["Edificio"] == DBNull.Value ? "" : Convert.ToString(salon["Edificio"]);
                if (idResponsableActual > 0) cmbResponsable.SelectedValue = idResponsableActual;
                txtObservacion.Text = salon["Observacion"] == DBNull.Value ? "" : Convert.ToString(salon["Observacion"]);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            bool hayError = false;

            string nombre = txtNombre.Text.Trim();
            if (nombre.Length < 3)
            { errorProvider.SetError(txtNombre, "El nombre es obligatorio (mínimo 3 caracteres)."); hayError = true; }
            if (cmbTipo.SelectedIndex < 0)
            { errorProvider.SetError(cmbTipo, "Seleccione un tipo."); hayError = true; }

            if (hayError)
            {
                MessageBox.Show("Revise los campos marcados.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idResp = cmbResponsable.SelectedValue == null ? 0 : Convert.ToInt32(cmbResponsable.SelectedValue);
            int capacidad = (int)nudCapacidad.Value;

            try
            {
                object r = Datos.Escalar(
                    @"EXEC dbo.sp_GuardarSalon @IdSalon = @id, @NombreSalon = @n, @Tipo = @t, @Capacidad = @c,
                                              @Edificio = @e, @IdResponsable = @r, @Observacion = @o",
                    Datos.P("@id", idSalon > 0 ? (object)idSalon : null),
                    Datos.P("@n", nombre),
                    Datos.P("@t", cmbTipo.SelectedItem.ToString()),
                    Datos.P("@c", capacidad > 0 ? (object)capacidad : null),
                    Datos.PTexto("@e", txtEdificio.Text),
                    Datos.P("@r", idResp > 0 ? (object)idResp : null),
                    Datos.PTexto("@o", txtObservacion.Text));

                IdGuardado = Convert.ToInt32(r);
                DialogResult = DialogResult.OK;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 50404 || ex.Number == 2601 || ex.Number == 2627)
                {
                    errorProvider.SetError(txtNombre, "Ya existe un salón con este nombre.");
                    MessageBox.Show("Ya existe un salón llamado \"" + nombre + "\".\n\nUse otro nombre o edite el salón existente.",
                        "Nombre repetido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNombre.Focus();
                }
                else
                {
                    MessageBox.Show(ex.Message, "No se pudo guardar el salón", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el salón: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}