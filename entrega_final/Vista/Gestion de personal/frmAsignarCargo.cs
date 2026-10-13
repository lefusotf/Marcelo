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
using System.Runtime.InteropServices;

namespace Vistass
{
    public partial class frmAsignarCargo : Form
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);
        private const int EM_SETCUEBANNER = 0x1501;




        private int idCargoEditando;          // 0 = cargo nuevo; otro valor = se está renombrando ese cargo
        private string nombreOriginal = "";

        public frmAsignarCargo()
        {
            InitializeComponent();
        }

        // Modo edición: cambia el nombre de un cargo que ya existe
        public frmAsignarCargo(int idCargo, string nombreActual) : this()
        {
            idCargoEditando = idCargo;
            nombreOriginal = nombreActual ?? "";
            Text = "Editar cargo";
            lblTitulo.Text = "Editar cargo";
            btnGuardarCargo.Text = "Guardar";
            txtNombreCargo.Text = nombreOriginal;
        }

        // El sistema reconoce a los docentes por el nombre del cargo (empieza con "Docente")
        private static bool EsCargoDocente(string nombre)
        {
            return (nombre ?? "").Trim().StartsWith("Docente", StringComparison.OrdinalIgnoreCase);
        }


  

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnGuardarCargo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreCargo.Text))
            {
                errorProvider.SetError(txtNombreCargo, "Ingrese un nombre de cargo válido.");
                MessageBox.Show("Por favor, ingrese el nombre del cargo.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreCargo.Focus();
                return;
            }

            string nombreCargo = txtNombreCargo.Text.Trim();

            if (idCargoEditando != 0)
            {
                if (nombreCargo == nombreOriginal) { DialogResult = DialogResult.Cancel; Close(); return; }

                if (EsCargoDocente(nombreOriginal) != EsCargoDocente(nombreCargo))
                {
                    errorProvider.SetError(txtNombreCargo, "No se puede.");
                    MessageBox.Show(EsCargoDocente(nombreOriginal)
                        ? "El cargo '" + nombreOriginal + "' no puede dejar de empezar con \"Docente\": el sistema reconoce a los docentes por ese nombre."
                        : "Un cargo que no es de docentes no puede empezar con \"Docente\": el sistema lo tomaría como docente.",
                        "Nombre no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombreCargo.Focus();
                    return;
                }

                if (MessageBox.Show("El nombre cambiará para todos los empleados que tienen este cargo.\n\n'" +
                        nombreOriginal + "'  →  '" + nombreCargo + "'\n\n¿Guardar el cambio?", "Confirmar",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            }

            try
            {
                using (SqlConnection con = Conexion.Conectar())
                {
                    con.Open();

                    // 2. Validar si ya existe otro cargo con el mismo nombre (ignora mayúsculas/minúsculas)
                    string checkQuery = "SELECT COUNT(*) FROM Cargos WHERE LOWER(NombreCargo) = LOWER(@NombreCargo) AND IdCargo <> @IdCargo";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue("@NombreCargo", nombreCargo);
                        checkCmd.Parameters.AddWithValue("@IdCargo", idCargoEditando);
                        int existe = (int)checkCmd.ExecuteScalar();

                        if (existe > 0)
                        {
                            MessageBox.Show($"El cargo '{nombreCargo}' ya existe en la base de datos.",
                                            "Cargo Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtNombreCargo.Focus();
                            txtNombreCargo.SelectAll();
                            return; // Cancela la inserción
                        }
                    }

                    // 3. Insertar (cargo nuevo) o actualizar (edición)
                    string sql = idCargoEditando == 0
                        ? "INSERT INTO Cargos (NombreCargo) VALUES (@NombreCargo)"
                        : "UPDATE Cargos SET NombreCargo = @NombreCargo WHERE IdCargo = @IdCargo";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@NombreCargo", nombreCargo);
                        if (idCargoEditando != 0) cmd.Parameters.AddWithValue("@IdCargo", idCargoEditando);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(idCargoEditando == 0 ? "Cargo registrado correctamente." : "Cargo actualizado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el cargo: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNombreCargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void frmAsignarCargo_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(txtNombreCargo, idCargoEditando == 0 ? "Ingrese el nombre del cargo que desea crear." : "Escriba el nuevo nombre del cargo.");
            toolTip1.SetToolTip(btnGuardarCargo, "Haga clic para guardar el cargo.");
            toolTip1.SetToolTip(btnCancelar, "Haga clic para cancelar y cerrar el formulario.");
            SendMessage(txtNombreCargo.Handle, EM_SETCUEBANNER, 1, "Ej. Coordinador de Disciplina");


        }
    }
}