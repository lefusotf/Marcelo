using Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vistass
{
    public partial class frmAgregarPersonal : Form
    {
        private int idEmpleadoEditar = 0; // Si es 0, es un nuevo registro. Si tiene valor, es edición.

        private string origNombre = "";
        private DateTime origFechaContratacion;
        private int origIdCargo = 0;
        private int origIdPlanilla = 0;
        private DateTime origFechaNacimiento;
        private string origEstadoCivil = "";
        private string origReligion = "";
        private string origTelefono = "";
        private string origCorreo = "";
        private string origDireccion = "";

        // --- Campos nuevos de la ficha ---
        private string origDui = "";
        private string origEspecialidad = "";
        private string origEmgNombre = "";
        private string origEmgParentesco = "";
        private string origEmgTelefono = "";

        private bool esAdmin;                                   // el DUI solo lo ve y edita el administrador
        private byte[] fotoActual = null;                       // foto que se muestra (JPEG ya reducido); null = sin foto
        private bool fotoModificada = false;                    // true si el usuario eligió o quitó la foto
        private List<int> materiasSel = new List<int>();        // materias que imparte (solo cargo Docente)
        private string materiasOrig = "";                       // ids originales ("2,5") para detectar cambios

        public frmAgregarPersonal()
        {
            InitializeComponent();
        }

        public frmAgregarPersonal(int idEmpleado)
        {
            InitializeComponent();
            idEmpleadoEditar = idEmpleado;   // los datos se cargan en el evento Load, cuando los combos ya existen
        }

        private void CargarDatosCombos()
        {
            try
            {
                DataTable dtCargos = Empleado.ObtenerCargos();
                cmbCargo.DataSource = dtCargos;
                cmbCargo.DisplayMember = "NombreCargo";
                cmbCargo.ValueMember = "IdCargo";

                DataTable dtPlanillas = Datos.Tabla(
      @"SELECT IdPlanilla,
                             'Planilla N° ' + CAST(IdPlanilla AS VARCHAR(10)) +
                             '  ·  Base ' + CONVERT(VARCHAR(20), SalarioBase) +
                             '  ·  Neto ' + CONVERT(VARCHAR(20), SalarioNeto) AS Descripcion
                      FROM Planillas ORDER BY IdPlanilla");
                cmbPlanilla.DataSource = dtPlanillas;
                cmbPlanilla.DisplayMember = "Descripcion";
                cmbPlanilla.ValueMember = "IdPlanilla";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las opciones desplegables: " + ex.Message, "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAgregarPersonal_Load(object sender, EventArgs e)
        {
            esAdmin = Sesion.Rol != null &&
                      Sesion.Rol.Trim().Equals("Administrador", StringComparison.OrdinalIgnoreCase);

            // El DUI es un dato sensible: solo el administrador lo ve y lo edita
            lblDui.Visible = esAdmin;
            txtDui.Visible = esAdmin;

            CargarDatosCombos();
            CargarCargos();
            cmbPlanilla.SelectedIndex = -1;

            if (idEmpleadoEditar > 0)
            {
                this.Text = "Editar empleado";
                lblTituloForm.Text = "Editar empleado";
                lblSubtituloForm.Text = "Modifique los datos y guarde los cambios";
                btnGuardar.Text = "Guardar cambios";

                CargarDatosParaEditar(idEmpleadoEditar);
            }
            else
            {
                this.Text = "Nuevo empleado";
                lblTituloForm.Text = "Nuevo empleado";
                lblSubtituloForm.Text = "Complete los datos del nuevo empleado";
                btnGuardar.Text = "Registrar empleado";
                dtpFechaNacimiento.Value = DateTime.Today.AddYears(-30);   // fecha de partida razonable
            }

            // Cuando el cargo cambia, se muestra u oculta la selección de materias.
            // Se conecta aquí (y no en el Designer) para que no se dispare mientras se cargan los datos.
            cmbCargo.SelectedIndexChanged += cmbCargo_SelectedIndexChanged;
            picFoto.Paint += picFoto_Paint;
            ActualizarVisibilidadMaterias();

            toolTip1.SetToolTip(txtNombreEmpleado, "Ingrese un nombre y un apellido del empleado");
            toolTip1.SetToolTip(cmbCargo, "Seleccione el cargo que le quiere asignar al empleado");
            toolTip1.SetToolTip(cmbPlanilla, "Seleccione la estructura de planilla que le quiere asignar al empleado");
            toolTip1.SetToolTip(dtpFechaContratacion, "Seleccione la fecha de contratación del empleado");
            toolTip1.SetToolTip(txtDui, "Formato 00000000-0. Es opcional; el sistema verifica el dígito final");
            toolTip1.SetToolTip(btnMaterias, "Materias que el docente puede impartir. Luego se asignan a grupos desde su expediente");
        }

        private bool YaExisteDirector(int idEmpleadoExcluido)
        {
            using (SqlConnection conexion = Conexion.Conectar())
            {
                string query = @"SELECT COUNT(*) 
                    FROM Empleados e 
                    INNER JOIN Cargos c ON e.IdCargo = c.IdCargo 
                    WHERE LOWER(c.NombreCargo) LIKE '%director%' 
                      AND LOWER(c.NombreCargo) NOT LIKE '%sub%'
                      AND e.IdEmpleado <> @idEmpleadoExcluido";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@idEmpleadoExcluido", idEmpleadoExcluido);

                conexion.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        public bool YaExisteSubdirectora(int idEmpleadoExcluido)
        {
            using (SqlConnection conexion = Conexion.Conectar())
            {
                string query = @"SELECT COUNT(*) 
                    FROM Empleados e 
                    INNER JOIN Cargos c ON e.IdCargo = c.IdCargo 
                    WHERE LOWER(c.NombreCargo) LIKE '%subdirectora%'
                      AND e.IdEmpleado <> @idEmpleadoExcluido";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@idEmpleadoExcluido", idEmpleadoExcluido);

                conexion.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ===============================================================
        //  Guardar
        // ===============================================================
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (idEmpleadoEditar > 0 && !HuboCambios())
            {
                MessageBox.Show("No se detectaron cambios en la información del empleado.", "Sin Cambios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            errorProvider.Clear();
            bool hayError = false;

            string nombre = txtNombreEmpleado.Text.Trim();
            if (nombre.Length == 0)
            { errorProvider.SetError(txtNombreEmpleado, "El nombre completo es obligatorio."); hayError = true; }
            else if (nombre.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length < 2)
            { errorProvider.SetError(txtNombreEmpleado, "Escriba al menos un nombre y un apellido."); hayError = true; }

            if (cmbCargo.SelectedIndex == -1 || cmbCargo.SelectedValue == null)
            { errorProvider.SetError(cmbCargo, "Seleccione un cargo."); hayError = true; }

            if (cmbPlanilla.SelectedIndex == -1 || cmbPlanilla.SelectedValue == null)
            { errorProvider.SetError(cmbPlanilla, "Seleccione una planilla."); hayError = true; }

            if (dtpFechaContratacion.Value.Date > DateTime.Today)
            { errorProvider.SetError(dtpFechaContratacion, "La fecha de contratación no puede ser futura."); hayError = true; }

            if (CalcularEdad(dtpFechaNacimiento.Value) < 18)
            { errorProvider.SetError(dtpFechaNacimiento, "El empleado debe ser mayor de 18 años."); hayError = true; }

            if (cmbEstadoCivil.SelectedIndex == -1 || string.IsNullOrWhiteSpace(cmbEstadoCivil.Text))
            { errorProvider.SetError(cmbEstadoCivil, "Seleccione el estado civil."); hayError = true; }

            if (txtNumeroTelefono.Text.Count(char.IsDigit) < 7)
            { errorProvider.SetError(txtNumeroTelefono, "Ingrese un teléfono válido (mínimo 7 dígitos)."); hayError = true; }

            if (string.IsNullOrWhiteSpace(txtReligion.Text))
            { errorProvider.SetError(txtReligion, "La religión es obligatoria."); hayError = true; }

            if (!CorreoValido(txtCorreoEmpleado.Text))
            { errorProvider.SetError(txtCorreoEmpleado, "Ingrese un correo válido (ejemplo: nombre@dominio.com)."); hayError = true; }

            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            { errorProvider.SetError(txtDireccion, "La dirección de residencia es obligatoria."); hayError = true; }

            // --- Campos nuevos ---
            // DUI: opcional, pero si se escribe debe tener formato y dígito verificador correctos
            string dui = txtDui.Text.Trim();
            if (esAdmin && dui.Length > 0 && !DuiValido(dui))
            { errorProvider.SetError(txtDui, "DUI no válido. Use el formato 00000000-0 con su dígito verificador."); hayError = true; }

            // Contacto de emergencia: si se llena una parte, deben estar el nombre y un teléfono válido
            bool algunContacto = txtEmgNombre.Text.Trim().Length > 0 ||
                                 txtEmgParentesco.Text.Trim().Length > 0 ||
                                 txtEmgTelefono.Text.Trim().Length > 0;
            if (algunContacto)
            {
                if (txtEmgNombre.Text.Trim().Length == 0)
                { errorProvider.SetError(txtEmgNombre, "Indique el nombre del contacto de emergencia."); hayError = true; }
                if (txtEmgTelefono.Text.Count(char.IsDigit) < 7)
                { errorProvider.SetError(txtEmgTelefono, "Ingrese un teléfono válido (mínimo 7 dígitos)."); hayError = true; }
            }

            // Un docente necesita al menos una materia (si no, no se le podrán asignar grupos)
            if (EsDocente() && materiasSel.Count == 0)
            { errorProvider.SetError(btnMaterias, "Elija al menos una materia que imparte este docente."); hayError = true; }

            if (hayError)
            {
                MessageBox.Show("Revise los campos marcados con el icono rojo.", "Campos incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- REGLAS DE NEGOCIO ---
            string nombreCargo = cmbCargo.Text;

            if (nombreCargo.ToLower().Contains("subdirectora") && YaExisteSubdirectora(idEmpleadoEditar))
            {
                MessageBox.Show("Ya existe una Subdirectora registrada en el sistema.", "Restricción de Cargo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nombreCargo.ToLower().Contains("director") && !nombreCargo.ToLower().Contains("sub") && YaExisteDirector(idEmpleadoEditar))
            {
                MessageBox.Show("Ya existe un Director registrado en el sistema.", "Restricción de Cargo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- GUARDADO EN BD ---
            // Empleado, foto y materias se guardan en UNA transacción: o se guarda todo o no se guarda nada.
            try
            {
                using (SqlConnection con = Conexion.Conectar())
                {
                    con.Open();
                    using (SqlTransaction tx = con.BeginTransaction())
                    {
                        try
                        {
                            int idEmp = GuardarEmpleado(con, tx);
                            GuardarFoto(con, tx, idEmp);
                            GuardarMaterias(con, tx, idEmp);
                            tx.Commit();
                        }
                        catch
                        {
                            tx.Rollback();
                            throw;
                        }
                    }
                }

                string mensaje = (idEmpleadoEditar == 0) ? "Empleado registrado correctamente." : "Empleado actualizado correctamente.";
                MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (SqlException ex)
            {
                // Mensajes claros para los errores más comunes
                if (ex.Message.Contains("UX_Empleados_DUI"))
                    errorProvider.SetError(txtDui, "Ese DUI ya está registrado en otro empleado.");
                else if (ex.Message.Contains("UQ_Empleados_Nombre"))
                    errorProvider.SetError(txtNombreEmpleado, "Ya existe un empleado con ese nombre.");
                else if (ex.Number >= 50000)
                    MessageBox.Show(ex.Message, "No se pudo guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);   // mensajes de los procedimientos
                else
                    MessageBox.Show("Error al guardar en la base de datos: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Inserta o actualiza el empleado y devuelve su Id
        private int GuardarEmpleado(SqlConnection con, SqlTransaction tx)
        {
            string query;
            if (idEmpleadoEditar == 0)
            {
                query = @"INSERT INTO Empleados 
                      (Nombre, FechaContratacion, IdCargo, IdEstado, IdPlanilla, FechaNacimiento, EstadoCivil, Religion, Telefono, Correo, Direccion,
                       DUI, Especialidad, ContactoEmergenciaNombre, ContactoEmergenciaParentesco, ContactoEmergenciaTelefono) 
                      VALUES 
                      (@nombre, @fecha, @idCargo, @idEstado, @idPlanilla, @fechaNac, @estadoCivil, @religion, @telefono, @correo, @direccion,
                       @dui, @especialidad, @emgNombre, @emgParentesco, @emgTelefono);
                      SELECT CAST(SCOPE_IDENTITY() AS INT);";
            }
            else
            {
                // El DUI solo se modifica si quien edita es administrador (los demás ni siquiera lo ven)
                query = @"UPDATE Empleados SET 
                      Nombre = @nombre, 
                      FechaContratacion = @fecha, 
                      IdCargo = @idCargo, 
                      IdPlanilla = @idPlanilla, 
                      FechaNacimiento = @fechaNac, 
                      EstadoCivil = @estadoCivil, 
                      Religion = @religion, 
                      Telefono = @telefono, 
                      Correo = @correo, 
                      Direccion = @direccion,
                      Especialidad = @especialidad,
                      ContactoEmergenciaNombre = @emgNombre,
                      ContactoEmergenciaParentesco = @emgParentesco,
                      ContactoEmergenciaTelefono = @emgTelefono"
                      + (esAdmin ? ", DUI = @dui" : "") + @"
                      WHERE IdEmpleado = @idEmpleado";
            }

            using (SqlCommand cmd = new SqlCommand(query, con, tx))
            {
                cmd.Parameters.AddWithValue("@nombre", txtNombreEmpleado.Text.Trim());
                cmd.Parameters.AddWithValue("@fecha", dtpFechaContratacion.Value);
                cmd.Parameters.AddWithValue("@idCargo", Convert.ToInt32(cmbCargo.SelectedValue));
                cmd.Parameters.AddWithValue("@idPlanilla", Convert.ToInt32(cmbPlanilla.SelectedValue));

                cmd.Parameters.AddWithValue("@fechaNac", dtpFechaNacimiento.Value);
                cmd.Parameters.AddWithValue("@estadoCivil", cmbEstadoCivil.Text.Trim());
                cmd.Parameters.AddWithValue("@religion", txtReligion.Text.Trim());
                cmd.Parameters.AddWithValue("@telefono", txtNumeroTelefono.Text.Trim());
                cmd.Parameters.AddWithValue("@correo", txtCorreoEmpleado.Text.Trim());
                cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text.Trim());

                cmd.Parameters.AddWithValue("@especialidad", Nulo(txtEspecialidad.Text));
                cmd.Parameters.AddWithValue("@emgNombre", Nulo(txtEmgNombre.Text));
                cmd.Parameters.AddWithValue("@emgParentesco", Nulo(txtEmgParentesco.Text));
                cmd.Parameters.AddWithValue("@emgTelefono", Nulo(txtEmgTelefono.Text));
                if (idEmpleadoEditar == 0 || esAdmin)
                    cmd.Parameters.AddWithValue("@dui", esAdmin ? Nulo(txtDui.Text) : DBNull.Value);

                if (idEmpleadoEditar == 0)
                {
                    cmd.Parameters.AddWithValue("@idEstado", 1); // Estado Activo por defecto
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }

                cmd.Parameters.AddWithValue("@idEmpleado", idEmpleadoEditar);
                cmd.ExecuteNonQuery();
                return idEmpleadoEditar;
            }
        }

        // La foto vive en su propia tabla (EmpleadoFotos): se inserta, se reemplaza o se borra
        private void GuardarFoto(SqlConnection con, SqlTransaction tx, int idEmp)
        {
            if (!fotoModificada) return;

            if (fotoActual == null)
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM EmpleadoFotos WHERE IdEmpleado = @id", con, tx))
                {
                    cmd.Parameters.AddWithValue("@id", idEmp);
                    cmd.ExecuteNonQuery();
                }
                return;
            }

            using (SqlCommand cmd = new SqlCommand(
                @"IF EXISTS (SELECT 1 FROM EmpleadoFotos WHERE IdEmpleado = @id)
                      UPDATE EmpleadoFotos SET Foto = @foto, FechaActualizacion = GETDATE() WHERE IdEmpleado = @id
                  ELSE
                      INSERT INTO EmpleadoFotos (IdEmpleado, Foto) VALUES (@id, @foto)", con, tx))
            {
                cmd.Parameters.AddWithValue("@id", idEmp);
                cmd.Parameters.Add("@foto", SqlDbType.VarBinary, -1).Value = fotoActual;
                cmd.ExecuteNonQuery();
            }
        }

        // Las materias las guarda el procedimiento sp_GuardarMateriasEmpleado.
        // Si el cargo NO es Docente se manda una lista vacía (así se limpian las materias que tuviera).
        private void GuardarMaterias(SqlConnection con, SqlTransaction tx, int idEmp)
        {
            using (SqlCommand cmd = new SqlCommand("sp_GuardarMateriasEmpleado", con, tx))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdEmpleado", idEmp);
                cmd.Parameters.AddWithValue("@Ids", EsDocente() ? string.Join(",", materiasSel) : "");
                cmd.ExecuteNonQuery();
            }
        }

        // ===============================================================
        //  Cargar datos al editar
        // ===============================================================
        private void CargarDatosParaEditar(int idEmpleado)
        {
            try
            {
                using (SqlConnection con = Conexion.Conectar())
                {
                    con.Open();
                    string query = "SELECT * FROM Empleados WHERE IdEmpleado = @id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", idEmpleado);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // 1. Llenar controles visuales
                                txtNombreEmpleado.Text = reader["Nombre"].ToString();
                                dtpFechaContratacion.Value = Convert.ToDateTime(reader["FechaContratacion"]);
                                cmbCargo.SelectedValue = Convert.ToInt32(reader["IdCargo"]);

                                // Un empleado creado sin planilla trae NULL: el combo queda vacio y hay que elegirla
                                if (reader["IdPlanilla"] != DBNull.Value)
                                    cmbPlanilla.SelectedValue = Convert.ToInt32(reader["IdPlanilla"]);

                                if (reader["FechaNacimiento"] != DBNull.Value)
                                    dtpFechaNacimiento.Value = Convert.ToDateTime(reader["FechaNacimiento"]);

                                cmbEstadoCivil.Text = reader["EstadoCivil"] != DBNull.Value ? reader["EstadoCivil"].ToString() : "";
                                txtReligion.Text = reader["Religion"] != DBNull.Value ? reader["Religion"].ToString() : "";
                                txtNumeroTelefono.Text = reader["Telefono"] != DBNull.Value ? reader["Telefono"].ToString() : "";
                                txtCorreoEmpleado.Text = reader["Correo"] != DBNull.Value ? reader["Correo"].ToString() : "";
                                txtDireccion.Text = reader["Direccion"] != DBNull.Value ? reader["Direccion"].ToString() : "";

                                // Campos nuevos de la ficha
                                txtDui.Text = Texto(reader["DUI"]);
                                txtEspecialidad.Text = Texto(reader["Especialidad"]);
                                txtEmgNombre.Text = Texto(reader["ContactoEmergenciaNombre"]);
                                txtEmgParentesco.Text = Texto(reader["ContactoEmergenciaParentesco"]);
                                txtEmgTelefono.Text = Texto(reader["ContactoEmergenciaTelefono"]);

                                // 2. GUARDAR VALORES ORIGINALES EN VARIABLES
                                origNombre = txtNombreEmpleado.Text.Trim();
                                origFechaContratacion = dtpFechaContratacion.Value;
                                origIdCargo = Convert.ToInt32(cmbCargo.SelectedValue);
                                origIdPlanilla = Convert.ToInt32(cmbPlanilla.SelectedValue);

                                origFechaNacimiento = dtpFechaNacimiento.Value;
                                origEstadoCivil = cmbEstadoCivil.Text.Trim();
                                origReligion = txtReligion.Text.Trim();
                                origTelefono = txtNumeroTelefono.Text.Trim();
                                origCorreo = txtCorreoEmpleado.Text.Trim();
                                origDireccion = txtDireccion.Text.Trim();

                                origDui = txtDui.Text.Trim();
                                origEspecialidad = txtEspecialidad.Text.Trim();
                                origEmgNombre = txtEmgNombre.Text.Trim();
                                origEmgParentesco = txtEmgParentesco.Text.Trim();
                                origEmgTelefono = txtEmgTelefono.Text.Trim();
                            }
                        }
                    }
                }

                CargarFotoYMaterias(idEmpleado);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // La foto y las materias salen de sus propias tablas
        private void CargarFotoYMaterias(int idEmpleado)
        {
            object f = Datos.Escalar("SELECT Foto FROM EmpleadoFotos WHERE IdEmpleado = @id", Datos.P("@id", idEmpleado));
            fotoActual = f as byte[];
            fotoModificada = false;
            MostrarFoto(fotoActual);

            materiasSel = Datos.Tabla("SELECT IdMateria FROM EmpleadoMaterias WHERE IdEmpleado = @id", Datos.P("@id", idEmpleado))
                               .Rows.Cast<DataRow>().Select(r => Convert.ToInt32(r["IdMateria"])).ToList();
            materiasOrig = string.Join(",", materiasSel.OrderBy(x => x));
            RefrescarTextoMaterias();
        }

        private bool HuboCambios()
        {
            // Compara cada control actual contra su variable original
            bool cambioNombre = txtNombreEmpleado.Text.Trim() != origNombre;
            bool cambioFechaContratacion = dtpFechaContratacion.Value.Date != origFechaContratacion.Date;
            bool cambioCargo = Convert.ToInt32(cmbCargo.SelectedValue) != origIdCargo;
            bool cambioPlanilla = Convert.ToInt32(cmbPlanilla.SelectedValue) != origIdPlanilla;

            bool cambioFechaNacimiento = dtpFechaNacimiento.Value.Date != origFechaNacimiento.Date;
            bool cambioEstadoCivil = cmbEstadoCivil.Text.Trim() != origEstadoCivil;
            bool cambioReligion = txtReligion.Text.Trim() != origReligion;
            bool cambioTelefono = txtNumeroTelefono.Text.Trim() != origTelefono;
            bool cambioCorreo = txtCorreoEmpleado.Text.Trim() != origCorreo;
            bool cambioDireccion = txtDireccion.Text.Trim() != origDireccion;

            // Campos nuevos
            bool cambioFicha = (esAdmin && txtDui.Text.Trim() != origDui) ||
                               txtEspecialidad.Text.Trim() != origEspecialidad ||
                               txtEmgNombre.Text.Trim() != origEmgNombre ||
                               txtEmgParentesco.Text.Trim() != origEmgParentesco ||
                               txtEmgTelefono.Text.Trim() != origEmgTelefono;
            bool cambioMaterias = string.Join(",", materiasSel.OrderBy(x => x)) != materiasOrig;

            // Devuelve true si AL MENOS UN campo cambió
            return cambioNombre || cambioFechaContratacion || cambioCargo || cambioPlanilla ||
                   cambioFechaNacimiento || cambioEstadoCivil || cambioReligion ||
                   cambioTelefono || cambioCorreo || cambioDireccion ||
                   cambioFicha || cambioMaterias || fotoModificada;
        }

        private void CargarCargos()
        {
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string query = "SELECT IdCargo, NombreCargo FROM Cargos";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbCargo.DataSource = dt;
                cmbCargo.DisplayMember = "NombreCargo";
                cmbCargo.ValueMember = "IdCargo";
                cmbCargo.SelectedIndex = -1; // Inicia deseleccionado
            }
        }

        private void tbpDatosLaborales_Click(object sender, EventArgs e)
        {

        }

        private void txtNombreEmpleado_TextChanged(object sender, EventArgs e)
        {

        }

        // ===============================================================
        //  Materias (solo para el cargo Docente)
        // ===============================================================
        private bool EsDocente()
        {
            return cmbCargo.SelectedIndex >= 0 &&
                   cmbCargo.Text.StartsWith("Docente", StringComparison.OrdinalIgnoreCase);
        }

        private void cmbCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarVisibilidadMaterias();
            errorProvider.SetError(btnMaterias, "");
        }

        private void ActualizarVisibilidadMaterias()
        {
            bool docente = EsDocente();
            lblMaterias.Visible = docente;
            btnMaterias.Visible = docente;
            lblMateriasValor.Visible = docente;
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            using (frmMateriasDocente dlg = new frmMateriasDocente(materiasSel))
            {
                if (dlg.ShowDialog(this) != DialogResult.OK) return;
                materiasSel = dlg.IdsSeleccionados;
                errorProvider.SetError(btnMaterias, "");
                RefrescarTextoMaterias();
            }
        }

        // Muestra los nombres de las materias elegidas (los ids son enteros, no hay riesgo de inyección)
        private void RefrescarTextoMaterias()
        {
            if (materiasSel.Count == 0) { lblMateriasValor.Text = "Ninguna"; return; }
            try
            {
                DataTable dt = Datos.Tabla("SELECT NombreMateria FROM Materias WHERE IdMateria IN (" +
                                           string.Join(",", materiasSel) + ") ORDER BY NombreMateria");
                lblMateriasValor.Text = string.Join(", ", dt.Rows.Cast<DataRow>().Select(r => Convert.ToString(r["NombreMateria"])));
            }
            catch { lblMateriasValor.Text = materiasSel.Count + " materia(s)"; }
        }

        // ===============================================================
        //  Foto
        // ===============================================================
        private void btnElegirFoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Seleccionar fotografía";
                dlg.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp";
                if (dlg.ShowDialog(this) != DialogResult.OK) return;

                try
                {
                    byte[] datos = ReducirImagen(dlg.FileName, 300);
                    fotoActual = datos;
                    fotoModificada = true;
                    MostrarFoto(datos);
                }
                catch
                {
                    MessageBox.Show("No se pudo abrir la imagen. Elija un archivo JPG, PNG o BMP válido.",
                                    "Imagen no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnQuitarFoto_Click(object sender, EventArgs e)
        {
            if (fotoActual == null) return;
            fotoActual = null;
            fotoModificada = true;
            MostrarFoto(null);
        }

        // Reduce la imagen a un máximo de 'lado' píxeles y la convierte a JPEG (calidad 85).
        // Una foto de cámara pesa varios MB; así queda en unos 20-40 KB.
        private static byte[] ReducirImagen(string ruta, int lado)
        {
            using (MemoryStream origen = new MemoryStream(File.ReadAllBytes(ruta)))
            using (Image original = Image.FromStream(origen))
            {
                double escala = Math.Min(1.0, (double)lado / Math.Max(original.Width, original.Height));
                int w = Math.Max(1, (int)(original.Width * escala));
                int h = Math.Max(1, (int)(original.Height * escala));

                using (Bitmap bmp = new Bitmap(w, h))
                {
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.Clear(Color.White);                       // fondo blanco para PNG con transparencia
                        g.DrawImage(original, 0, 0, w, h);
                    }

                    ImageCodecInfo jpeg = ImageCodecInfo.GetImageEncoders().First(c => c.FormatID == ImageFormat.Jpeg.Guid);
                    using (EncoderParameters parametros = new EncoderParameters(1))
                    using (MemoryStream salida = new MemoryStream())
                    {
                        // 'Encoder' se escribe completo porque System.Text también tiene una clase con ese nombre
                        parametros.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 85L);
                        bmp.Save(salida, jpeg, parametros);
                        return salida.ToArray();
                    }
                }
            }
        }

        private void MostrarFoto(byte[] datos)
        {
            Image anterior = picFoto.Image;
            if (datos == null)
            {
                picFoto.Image = null;
            }
            else
            {
                using (MemoryStream ms = new MemoryStream(datos))
                using (Image temporal = Image.FromStream(ms))
                    picFoto.Image = new Bitmap(temporal);   // copia: el stream se puede cerrar
            }
            if (anterior != null) anterior.Dispose();
            picFoto.Invalidate();
        }

        // Sin foto: se dibuja un texto centrado en el recuadro
        private void picFoto_Paint(object sender, PaintEventArgs e)
        {
            if (picFoto.Image != null) return;
            using (Font f = new Font("Segoe UI", 10F))
            using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                e.Graphics.DrawString("Sin fotografía", f, Brushes.Gray, picFoto.ClientRectangle, sf);
        }

        // ===============================================================
        //  Utilidades
        // ===============================================================
        private static int CalcularEdad(DateTime nacimiento)
        {
            int edad = DateTime.Today.Year - nacimiento.Year;
            if (nacimiento.Date > DateTime.Today.AddYears(-edad)) edad--;
            return edad;
        }

        private static bool CorreoValido(string correo)
        {
            correo = (correo ?? "").Trim();
            if (correo.Length == 0) return false;
            try
            {
                System.Net.Mail.MailAddress m = new System.Net.Mail.MailAddress(correo);
                return m.Address == correo;
            }
            catch { return false; }
        }

        // Texto vacío -> NULL en la base de datos
        private static object Nulo(string s)
        {
            s = (s ?? "").Trim();
            return s.Length == 0 ? (object)DBNull.Value : s;
        }

        private static string Texto(object v)
        {
            return v == null || v == DBNull.Value ? "" : Convert.ToString(v).Trim();
        }

        // DUI salvadoreño: 8 dígitos + guion + dígito verificador.
        // Los 8 primeros dígitos se multiplican por 9,8,7,6,5,4,3,2 y se suman;
        // el verificador es (10 - suma % 10), y si da 10 vale 0.
        private static bool DuiValido(string dui)
        {
            if (dui.Length != 10 || dui[8] != '-') return false;
            string d = dui.Substring(0, 8) + dui.Substring(9, 1);
            if (!d.All(char.IsDigit)) return false;

            int suma = 0;
            for (int i = 0; i < 8; i++) suma += (d[i] - '0') * (9 - i);
            int verificador = (10 - (suma % 10)) % 10;
            return verificador == d[8] - '0';
        }

        private void txtNombreEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        // el teléfono solo admite números, +, - y espacio
        private void txtNumeroTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '+' && e.KeyChar != '-' && e.KeyChar != ' ')
                e.Handled = true;
        }

        // el DUI solo admite números y el guion
        private void txtDui_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
                e.Handled = true;
        }

        // Si se escriben los 9 dígitos seguidos, se coloca el guion solo
        private void txtDui_Leave(object sender, EventArgs e)
        {
            string soloDigitos = new string(txtDui.Text.Where(char.IsDigit).ToArray());
            if (soloDigitos.Length == 9)
                txtDui.Text = soloDigitos.Substring(0, 8) + "-" + soloDigitos.Substring(8, 1);
        }
    }
}