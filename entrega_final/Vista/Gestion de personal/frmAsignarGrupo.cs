using Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Vistass
{
    // Asigna un grupo (grado + sección), una materia y sus horas semanales a un docente
    public partial class frmAsignarGrupo : Form
    {
        private const int MaxHoras = 40;

        private readonly int idEmpleado;
        private readonly string nombreDocente;
        private readonly int anio;

        private int idMateria = 0;          // materia que se asignará (si el docente imparte una sola)
        private ComboBox cmbMateria;        // solo existe cuando el docente imparte varias materias

        public frmAsignarGrupo(int idEmpleado, string nombreDocente, int anio)
        {
            InitializeComponent();
            this.idEmpleado = idEmpleado;
            this.nombreDocente = nombreDocente;
            this.anio = anio;
        }

        private void frmAsignarGrupo_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = "Asignar grupo   ·   Año lectivo " + anio;
            lblDocente.Text = nombreDocente;

            // primero DisplayMember/ValueMember y después DataSource, para que SelectedValue sea el Id
            cmbGrado.DisplayMember = "NombreGrado";
            cmbGrado.ValueMember = "IdGrado";
            cmbGrado.DataSource = Datos.Tabla("SELECT IdGrado, NombreGrado FROM Grados ORDER BY Orden");

            // horas que le quedan al docente en ese año (cuenta TODAS sus materias)
            int asignadas = Convert.ToInt32(Datos.Escalar(
                "SELECT ISNULL(SUM(HorasSemanales), 0) FROM AsignacionesDocente WHERE IdEmpleado = @e AND AnioLectivo = @a",
                Datos.P("@e", idEmpleado), Datos.P("@a", anio)));
            int disponibles = MaxHoras - asignadas;

            if (disponibles <= 0)
            {
                lblDisponibles.Text = "Ya tiene " + MaxHoras + " de " + MaxHoras + " horas";
                numHoras.Enabled = false;
                btnGuardar.Enabled = false;
            }
            else
            {
                lblDisponibles.Text = "Disponibles: " + disponibles + " de " + MaxHoras + " h";
                numHoras.Maximum = disponibles;
                NumericoLimitado.Aplicar(numHoras, errorProvider,
                    () => "El docente solo tiene " + numHoras.Maximum.ToString("0") + " horas disponibles.");
            }

            CargarSecciones();
            PrepararMateria();
        }

        // ---------------------------------------------------------------
        //  Materia del docente
        // ---------------------------------------------------------------
        private void PrepararMateria()
        {
            DataTable materias = Datos.Tabla(
                @"SELECT m.IdMateria, m.NombreMateria
                  FROM EmpleadoMaterias em
                  JOIN Materias m ON m.IdMateria = em.IdMateria
                  WHERE em.IdEmpleado = @e
                  ORDER BY m.NombreMateria", Datos.P("@e", idEmpleado));

            // Sin materias: no se puede asignar. Se orienta al usuario.
            if (materias.Rows.Count == 0)
            {
                MessageBox.Show("Este docente todavía no tiene materias registradas.\n\n" +
                                "Edite su ficha en Gestión de personal y elija las materias que imparte.",
                                "Faltan las materias", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnGuardar.Enabled = false;
                return;
            }

            if (materias.Rows.Count == 1)
            {
                idMateria = Convert.ToInt32(materias.Rows[0]["IdMateria"]);
                lblDocente.Text += "   ·   " + Convert.ToString(materias.Rows[0]["NombreMateria"]);
                return;
            }
            const int alto = 70;
            Control padre = cmbSeccion.Parent;
            int y = cmbSeccion.Bottom + 10;

            foreach (Control c in padre.Controls.Cast<Control>().ToList())
                if (c.Top >= y) c.Top += alto;

            this.Height += alto;
            if (padre != this && padre.Dock == DockStyle.None) padre.Height += alto;

            Label lbl = new Label
            {
                Text = "Materia",
                AutoSize = true,
                Location = new Point(cmbSeccion.Left, y),
                Font = lblDocente.Font,
                ForeColor = lblDocente.ForeColor
            };

            cmbMateria = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(cmbSeccion.Left, y + 24),
                Width = cmbSeccion.Width,
                Font = cmbSeccion.Font,
                FlatStyle = cmbSeccion.FlatStyle,
                BackColor = cmbSeccion.BackColor,
                ForeColor = cmbSeccion.ForeColor
            };
            cmbMateria.DisplayMember = "NombreMateria";
            cmbMateria.ValueMember = "IdMateria";
            cmbMateria.DataSource = materias;

            padre.Controls.Add(lbl);
            padre.Controls.Add(cmbMateria);
        }

        private void cmbGrado_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarSecciones();
        }

        private void CargarSecciones()
        {
            int idGrado;
            if (cmbGrado.SelectedValue == null || !int.TryParse(cmbGrado.SelectedValue.ToString(), out idGrado)) return;

            cmbSeccion.DisplayMember = "NombreSeccion";
            cmbSeccion.ValueMember = "IdSeccion";
            cmbSeccion.DataSource = Datos.Tabla(
                "SELECT IdSeccion, NombreSeccion FROM Secciones WHERE IdGrado = @g ORDER BY NombreSeccion",
                Datos.P("@g", idGrado));
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

         
            errorProvider.Clear();
            if (cmbGrado.SelectedValue == null) { errorProvider.SetError(cmbGrado, "Seleccione el grado."); return; }
            if (cmbSeccion.SelectedValue == null) { errorProvider.SetError(cmbSeccion, "Seleccione la sección."); return; }

            int materiaElegida = cmbMateria != null && cmbMateria.SelectedValue != null
                ? Convert.ToInt32(cmbMateria.SelectedValue)
                : idMateria;
            if (materiaElegida == 0) { MessageBox.Show("Seleccione la materia.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            try
            {
                Datos.Procedimiento("sp_AsignarDocente",
                    Datos.P("@IdEmpleado", idEmpleado),
                    Datos.P("@IdSeccion", Convert.ToInt32(cmbSeccion.SelectedValue)),
                    Datos.P("@AnioLectivo", anio),
                    Datos.P("@Horas", HorasElegidas()),
                    Datos.P("@IdMateria", materiaElegida));

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "No se pudo asignar el grupo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int HorasElegidas()
        {
            numHoras.Validate();                       
            int horas;
            if (!int.TryParse(numHoras.Text.Trim(), out horas)) horas = (int)numHoras.Value;
        
            return Math.Max((int)numHoras.Minimum, Math.Min(horas, (int)numHoras.Maximum));
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}