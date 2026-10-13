namespace Vistass
{
    partial class frmAgregarPersonal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTituloForm = new System.Windows.Forms.Label();
            this.lblSubtituloForm = new System.Windows.Forms.Label();
            this.pnlLaboral = new System.Windows.Forms.Panel();
            this.lblSecLaboral = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblCargo = new System.Windows.Forms.Label();
            this.lblPlanilla = new System.Windows.Forms.Label();
            this.lblContratacion = new System.Windows.Forms.Label();
            this.txtNombreEmpleado = new System.Windows.Forms.TextBox();
            this.cmbCargo = new Vistass.ComboOscuro();
            this.cmbPlanilla = new Vistass.ComboOscuro();
            this.dtpFechaContratacion = new Vistass.FechaOscura();
            this.pnlPersonal = new System.Windows.Forms.Panel();
            this.lblSecPersonal = new System.Windows.Forms.Label();
            this.lblNacimiento = new System.Windows.Forms.Label();
            this.lblEstadoCivil = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblReligion = new System.Windows.Forms.Label();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.dtpFechaNacimiento = new Vistass.FechaOscura();
            this.cmbEstadoCivil = new Vistass.ComboOscuro();
            this.txtNumeroTelefono = new System.Windows.Forms.TextBox();
            this.txtReligion = new System.Windows.Forms.TextBox();
            this.txtCorreoEmpleado = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.pnlFoto = new System.Windows.Forms.Panel();
            this.lblSecFoto = new System.Windows.Forms.Label();
            this.picFoto = new System.Windows.Forms.PictureBox();
            this.btnElegirFoto = new Vistass.BotonTema();
            this.btnQuitarFoto = new Vistass.BotonTema();
            this.pnlFicha = new System.Windows.Forms.Panel();
            this.lblSecFicha = new System.Windows.Forms.Label();
            this.lblDui = new System.Windows.Forms.Label();
            this.txtDui = new System.Windows.Forms.TextBox();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.txtEspecialidad = new System.Windows.Forms.TextBox();
            this.lblMaterias = new System.Windows.Forms.Label();
            this.btnMaterias = new Vistass.BotonTema();
            this.lblMateriasValor = new System.Windows.Forms.Label();
            this.pnlEmergencia = new System.Windows.Forms.Panel();
            this.lblSecEmergencia = new System.Windows.Forms.Label();
            this.lblEmgNombre = new System.Windows.Forms.Label();
            this.txtEmgNombre = new System.Windows.Forms.TextBox();
            this.lblEmgParentesco = new System.Windows.Forms.Label();
            this.txtEmgParentesco = new System.Windows.Forms.TextBox();
            this.lblEmgTelefono = new System.Windows.Forms.Label();
            this.txtEmgTelefono = new System.Windows.Forms.TextBox();
            this.pnlPie = new System.Windows.Forms.Panel();
            this.lblObligatorios = new System.Windows.Forms.Label();
            this.btnGuardar = new Vistass.BotonTema();
            this.btnVolver = new Vistass.BotonTema();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlLaboral.SuspendLayout();
            this.pnlPersonal.SuspendLayout();
            this.pnlFoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.pnlFicha.SuspendLayout();
            this.pnlEmergencia.SuspendLayout();
            this.pnlPie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTituloForm
            // 
            this.lblTituloForm.AutoSize = true;
            this.lblTituloForm.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTituloForm.ForeColor = System.Drawing.Color.White;
            this.lblTituloForm.Location = new System.Drawing.Point(24, 14);
            this.lblTituloForm.Name = "lblTituloForm";
            this.lblTituloForm.Size = new System.Drawing.Size(237, 37);
            this.lblTituloForm.TabIndex = 0;
            this.lblTituloForm.Text = "Nuevo empleado";
            // 
            // lblSubtituloForm
            // 
            this.lblSubtituloForm.AutoSize = true;
            this.lblSubtituloForm.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtituloForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblSubtituloForm.Location = new System.Drawing.Point(26, 46);
            this.lblSubtituloForm.Name = "lblSubtituloForm";
            this.lblSubtituloForm.Size = new System.Drawing.Size(266, 23);
            this.lblSubtituloForm.TabIndex = 1;
            this.lblSubtituloForm.Text = "Complete los datos del empleado";
            // 
            // pnlLaboral
            // 
            this.pnlLaboral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.pnlLaboral.Controls.Add(this.lblSecLaboral);
            this.pnlLaboral.Controls.Add(this.lblNombre);
            this.pnlLaboral.Controls.Add(this.lblCargo);
            this.pnlLaboral.Controls.Add(this.lblPlanilla);
            this.pnlLaboral.Controls.Add(this.lblContratacion);
            this.pnlLaboral.Controls.Add(this.txtNombreEmpleado);
            this.pnlLaboral.Controls.Add(this.cmbCargo);
            this.pnlLaboral.Controls.Add(this.cmbPlanilla);
            this.pnlLaboral.Controls.Add(this.dtpFechaContratacion);
            this.pnlLaboral.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlLaboral.Location = new System.Drawing.Point(24, 80);
            this.pnlLaboral.Name = "pnlLaboral";
            this.pnlLaboral.Size = new System.Drawing.Size(432, 360);
            this.pnlLaboral.TabIndex = 2;
            // 
            // lblSecLaboral
            // 
            this.lblSecLaboral.AutoSize = true;
            this.lblSecLaboral.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSecLaboral.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(204)))), ((int)(((byte)(21)))));
            this.lblSecLaboral.Location = new System.Drawing.Point(24, 16);
            this.lblSecLaboral.Name = "lblSecLaboral";
            this.lblSecLaboral.Size = new System.Drawing.Size(167, 23);
            this.lblSecLaboral.TabIndex = 0;
            this.lblSecLaboral.Text = "DATOS LABORALES";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblNombre.Location = new System.Drawing.Point(24, 52);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(148, 21);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre completo *";
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCargo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblCargo.Location = new System.Drawing.Point(24, 128);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(63, 21);
            this.lblCargo.TabIndex = 2;
            this.lblCargo.Text = "Cargo *";
            // 
            // lblPlanilla
            // 
            this.lblPlanilla.AutoSize = true;
            this.lblPlanilla.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPlanilla.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblPlanilla.Location = new System.Drawing.Point(24, 204);
            this.lblPlanilla.Name = "lblPlanilla";
            this.lblPlanilla.Size = new System.Drawing.Size(71, 21);
            this.lblPlanilla.TabIndex = 3;
            this.lblPlanilla.Text = "Planilla *";
            // 
            // lblContratacion
            // 
            this.lblContratacion.AutoSize = true;
            this.lblContratacion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblContratacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblContratacion.Location = new System.Drawing.Point(24, 280);
            this.lblContratacion.Name = "lblContratacion";
            this.lblContratacion.Size = new System.Drawing.Size(172, 21);
            this.lblContratacion.TabIndex = 4;
            this.lblContratacion.Text = "Fecha de contratación *";
            // 
            // txtNombreEmpleado
            // 
            this.txtNombreEmpleado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.txtNombreEmpleado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreEmpleado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNombreEmpleado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.txtNombreEmpleado.Location = new System.Drawing.Point(24, 76);
            this.txtNombreEmpleado.MaxLength = 200;
            this.txtNombreEmpleado.Name = "txtNombreEmpleado";
            this.txtNombreEmpleado.Size = new System.Drawing.Size(384, 29);
            this.txtNombreEmpleado.TabIndex = 5;
            this.txtNombreEmpleado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreEmpleado_KeyPress);
            // 
            // cmbCargo
            // 
            this.cmbCargo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.cmbCargo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCargo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCargo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbCargo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.cmbCargo.FormattingEnabled = true;
            this.cmbCargo.ItemHeight = 20;
            this.cmbCargo.Location = new System.Drawing.Point(24, 152);
            this.cmbCargo.Name = "cmbCargo";
            this.cmbCargo.Size = new System.Drawing.Size(384, 26);
            this.cmbCargo.TabIndex = 6;
            // 
            // cmbPlanilla
            // 
            this.cmbPlanilla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.cmbPlanilla.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPlanilla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlanilla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPlanilla.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbPlanilla.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.cmbPlanilla.FormattingEnabled = true;
            this.cmbPlanilla.ItemHeight = 20;
            this.cmbPlanilla.Location = new System.Drawing.Point(24, 228);
            this.cmbPlanilla.Name = "cmbPlanilla";
            this.cmbPlanilla.Size = new System.Drawing.Size(384, 26);
            this.cmbPlanilla.TabIndex = 7;
            // 
            // dtpFechaContratacion
            // 
            this.dtpFechaContratacion.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.dtpFechaContratacion.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.dtpFechaContratacion.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(204)))), ((int)(((byte)(21)))));
            this.dtpFechaContratacion.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.dtpFechaContratacion.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(140)))));
            this.dtpFechaContratacion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpFechaContratacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaContratacion.Location = new System.Drawing.Point(24, 304);
            this.dtpFechaContratacion.MinimumSize = new System.Drawing.Size(0, 26);
            this.dtpFechaContratacion.Name = "dtpFechaContratacion";
            this.dtpFechaContratacion.Size = new System.Drawing.Size(384, 26);
            this.dtpFechaContratacion.TabIndex = 8;
            // 
            // pnlPersonal
            // 
            this.pnlPersonal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.pnlPersonal.Controls.Add(this.lblSecPersonal);
            this.pnlPersonal.Controls.Add(this.lblNacimiento);
            this.pnlPersonal.Controls.Add(this.lblEstadoCivil);
            this.pnlPersonal.Controls.Add(this.lblTelefono);
            this.pnlPersonal.Controls.Add(this.lblReligion);
            this.pnlPersonal.Controls.Add(this.lblCorreo);
            this.pnlPersonal.Controls.Add(this.lblDireccion);
            this.pnlPersonal.Controls.Add(this.dtpFechaNacimiento);
            this.pnlPersonal.Controls.Add(this.cmbEstadoCivil);
            this.pnlPersonal.Controls.Add(this.txtNumeroTelefono);
            this.pnlPersonal.Controls.Add(this.txtReligion);
            this.pnlPersonal.Controls.Add(this.txtCorreoEmpleado);
            this.pnlPersonal.Controls.Add(this.txtDireccion);
            this.pnlPersonal.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlPersonal.Location = new System.Drawing.Point(472, 80);
            this.pnlPersonal.Name = "pnlPersonal";
            this.pnlPersonal.Size = new System.Drawing.Size(424, 360);
            this.pnlPersonal.TabIndex = 3;
            // 
            // lblSecPersonal
            // 
            this.lblSecPersonal.AutoSize = true;
            this.lblSecPersonal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSecPersonal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(204)))), ((int)(((byte)(21)))));
            this.lblSecPersonal.Location = new System.Drawing.Point(24, 16);
            this.lblSecPersonal.Name = "lblSecPersonal";
            this.lblSecPersonal.Size = new System.Drawing.Size(177, 23);
            this.lblSecPersonal.TabIndex = 0;
            this.lblSecPersonal.Text = "DATOS PERSONALES";
            // 
            // lblNacimiento
            // 
            this.lblNacimiento.AutoSize = true;
            this.lblNacimiento.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNacimiento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblNacimiento.Location = new System.Drawing.Point(24, 52);
            this.lblNacimiento.Name = "lblNacimiento";
            this.lblNacimiento.Size = new System.Drawing.Size(163, 21);
            this.lblNacimiento.TabIndex = 1;
            this.lblNacimiento.Text = "Fecha de nacimiento *";
            // 
            // lblEstadoCivil
            // 
            this.lblEstadoCivil.AutoSize = true;
            this.lblEstadoCivil.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblEstadoCivil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblEstadoCivil.Location = new System.Drawing.Point(216, 52);
            this.lblEstadoCivil.Name = "lblEstadoCivil";
            this.lblEstadoCivil.Size = new System.Drawing.Size(98, 21);
            this.lblEstadoCivil.TabIndex = 2;
            this.lblEstadoCivil.Text = "Estado civil *";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblTelefono.Location = new System.Drawing.Point(24, 128);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(79, 21);
            this.lblTelefono.TabIndex = 3;
            this.lblTelefono.Text = "Teléfono *";
            // 
            // lblReligion
            // 
            this.lblReligion.AutoSize = true;
            this.lblReligion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblReligion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblReligion.Location = new System.Drawing.Point(216, 128);
            this.lblReligion.Name = "lblReligion";
            this.lblReligion.Size = new System.Drawing.Size(78, 21);
            this.lblReligion.TabIndex = 4;
            this.lblReligion.Text = "Religión *";
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCorreo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblCorreo.Location = new System.Drawing.Point(24, 204);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(149, 21);
            this.lblCorreo.TabIndex = 5;
            this.lblCorreo.Text = "Correo electrónico *";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDireccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblDireccion.Location = new System.Drawing.Point(24, 280);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(86, 21);
            this.lblDireccion.TabIndex = 6;
            this.lblDireccion.Text = "Dirección *";
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.dtpFechaNacimiento.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.dtpFechaNacimiento.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(204)))), ((int)(((byte)(21)))));
            this.dtpFechaNacimiento.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.dtpFechaNacimiento.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(140)))));
            this.dtpFechaNacimiento.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(24, 76);
            this.dtpFechaNacimiento.MinimumSize = new System.Drawing.Size(0, 26);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(176, 26);
            this.dtpFechaNacimiento.TabIndex = 7;
            // 
            // cmbEstadoCivil
            // 
            this.cmbEstadoCivil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.cmbEstadoCivil.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbEstadoCivil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoCivil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEstadoCivil.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbEstadoCivil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.cmbEstadoCivil.FormattingEnabled = true;
            this.cmbEstadoCivil.ItemHeight = 20;
            this.cmbEstadoCivil.Items.AddRange(new object[] {
            "Soltero/a",
            "Casado/a",
            "Divorciado/a",
            "Viudo/a"});
            this.cmbEstadoCivil.Location = new System.Drawing.Point(216, 76);
            this.cmbEstadoCivil.Name = "cmbEstadoCivil";
            this.cmbEstadoCivil.Size = new System.Drawing.Size(184, 26);
            this.cmbEstadoCivil.TabIndex = 8;
            // 
            // txtNumeroTelefono
            // 
            this.txtNumeroTelefono.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.txtNumeroTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumeroTelefono.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNumeroTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.txtNumeroTelefono.Location = new System.Drawing.Point(24, 152);
            this.txtNumeroTelefono.MaxLength = 20;
            this.txtNumeroTelefono.Name = "txtNumeroTelefono";
            this.txtNumeroTelefono.Size = new System.Drawing.Size(176, 29);
            this.txtNumeroTelefono.TabIndex = 9;
            this.txtNumeroTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroTelefono_KeyPress);
            // 
            // txtReligion
            // 
            this.txtReligion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.txtReligion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReligion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtReligion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.txtReligion.Location = new System.Drawing.Point(216, 152);
            this.txtReligion.MaxLength = 50;
            this.txtReligion.Name = "txtReligion";
            this.txtReligion.Size = new System.Drawing.Size(184, 29);
            this.txtReligion.TabIndex = 10;
            // 
            // txtCorreoEmpleado
            // 
            this.txtCorreoEmpleado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.txtCorreoEmpleado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCorreoEmpleado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCorreoEmpleado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.txtCorreoEmpleado.Location = new System.Drawing.Point(24, 228);
            this.txtCorreoEmpleado.MaxLength = 100;
            this.txtCorreoEmpleado.Name = "txtCorreoEmpleado";
            this.txtCorreoEmpleado.Size = new System.Drawing.Size(376, 29);
            this.txtCorreoEmpleado.TabIndex = 11;
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDireccion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDireccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.txtDireccion.Location = new System.Drawing.Point(24, 304);
            this.txtDireccion.MaxLength = 255;
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(376, 44);
            this.txtDireccion.TabIndex = 12;
            // 
            // pnlFoto
            // 
            this.pnlFoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.pnlFoto.Controls.Add(this.lblSecFoto);
            this.pnlFoto.Controls.Add(this.picFoto);
            this.pnlFoto.Controls.Add(this.btnElegirFoto);
            this.pnlFoto.Controls.Add(this.btnQuitarFoto);
            this.pnlFoto.Location = new System.Drawing.Point(912, 80);
            this.pnlFoto.Name = "pnlFoto";
            this.pnlFoto.Size = new System.Drawing.Size(244, 592);
            this.pnlFoto.TabIndex = 5;
            // 
            // lblSecFoto
            // 
            this.lblSecFoto.AutoSize = true;
            this.lblSecFoto.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSecFoto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(204)))), ((int)(((byte)(21)))));
            this.lblSecFoto.Location = new System.Drawing.Point(22, 16);
            this.lblSecFoto.Name = "lblSecFoto";
            this.lblSecFoto.Size = new System.Drawing.Size(114, 23);
            this.lblSecFoto.TabIndex = 0;
            this.lblSecFoto.Text = "FOTOGRAFÍA";
            // 
            // picFoto
            // 
            this.picFoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.picFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFoto.Location = new System.Drawing.Point(22, 56);
            this.picFoto.Name = "picFoto";
            this.picFoto.Size = new System.Drawing.Size(200, 240);
            this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFoto.TabIndex = 1;
            this.picFoto.TabStop = false;
            // 
            // btnElegirFoto
            // 
            this.btnElegirFoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(204)))), ((int)(((byte)(21)))));
            this.btnElegirFoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnElegirFoto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(192)))), ((int)(((byte)(9)))));
            this.btnElegirFoto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(39)))));
            this.btnElegirFoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnElegirFoto.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnElegirFoto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.btnElegirFoto.Location = new System.Drawing.Point(22, 312);
            this.btnElegirFoto.Name = "btnElegirFoto";
            this.btnElegirFoto.Size = new System.Drawing.Size(200, 36);
            this.btnElegirFoto.TabIndex = 20;
            this.btnElegirFoto.Text = "Elegir foto";
            this.btnElegirFoto.UseVisualStyleBackColor = false;
            this.btnElegirFoto.Click += new System.EventHandler(this.btnElegirFoto_Click);
            // 
            // btnQuitarFoto
            // 
            this.btnQuitarFoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.btnQuitarFoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitarFoto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(48)))), ((int)(((byte)(68)))));
            this.btnQuitarFoto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(78)))), ((int)(((byte)(98)))));
            this.btnQuitarFoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarFoto.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnQuitarFoto.ForeColor = System.Drawing.Color.White;
            this.btnQuitarFoto.Location = new System.Drawing.Point(22, 356);
            this.btnQuitarFoto.Name = "btnQuitarFoto";
            this.btnQuitarFoto.Size = new System.Drawing.Size(200, 36);
            this.btnQuitarFoto.TabIndex = 21;
            this.btnQuitarFoto.Text = "Quitar foto";
            this.btnQuitarFoto.Tipo = Vistass.TipoBoton.Secundario;
            this.btnQuitarFoto.UseVisualStyleBackColor = false;
            this.btnQuitarFoto.Click += new System.EventHandler(this.btnQuitarFoto_Click);
            // 
            // pnlFicha
            // 
            this.pnlFicha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.pnlFicha.Controls.Add(this.lblSecFicha);
            this.pnlFicha.Controls.Add(this.lblDui);
            this.pnlFicha.Controls.Add(this.txtDui);
            this.pnlFicha.Controls.Add(this.lblEspecialidad);
            this.pnlFicha.Controls.Add(this.txtEspecialidad);
            this.pnlFicha.Controls.Add(this.lblMaterias);
            this.pnlFicha.Controls.Add(this.btnMaterias);
            this.pnlFicha.Controls.Add(this.lblMateriasValor);
            this.pnlFicha.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.pnlFicha.Location = new System.Drawing.Point(24, 452);
            this.pnlFicha.Name = "pnlFicha";
            this.pnlFicha.Size = new System.Drawing.Size(432, 220);
            this.pnlFicha.TabIndex = 6;
            // 
            // lblSecFicha
            // 
            this.lblSecFicha.AutoSize = true;
            this.lblSecFicha.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSecFicha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(204)))), ((int)(((byte)(21)))));
            this.lblSecFicha.Location = new System.Drawing.Point(24, 16);
            this.lblSecFicha.Name = "lblSecFicha";
            this.lblSecFicha.Size = new System.Drawing.Size(179, 23);
            this.lblSecFicha.TabIndex = 0;
            this.lblSecFicha.Text = "FICHA PROFESIONAL";
            // 
            // lblDui
            // 
            this.lblDui.AutoSize = true;
            this.lblDui.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDui.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblDui.Location = new System.Drawing.Point(24, 52);
            this.lblDui.Name = "lblDui";
            this.lblDui.Size = new System.Drawing.Size(109, 21);
            this.lblDui.TabIndex = 1;
            this.lblDui.Text = "DUI (opcional)";
            // 
            // txtDui
            // 
            this.txtDui.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.txtDui.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDui.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDui.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.txtDui.Location = new System.Drawing.Point(24, 76);
            this.txtDui.MaxLength = 10;
            this.txtDui.Name = "txtDui";
            this.txtDui.Size = new System.Drawing.Size(176, 29);
            this.txtDui.TabIndex = 13;
            this.txtDui.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDui_KeyPress);
            this.txtDui.Leave += new System.EventHandler(this.txtDui_Leave);
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblEspecialidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblEspecialidad.Location = new System.Drawing.Point(216, 52);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(180, 21);
            this.lblEspecialidad.TabIndex = 14;
            this.lblEspecialidad.Text = "Especialidad / formación";
            // 
            // txtEspecialidad
            // 
            this.txtEspecialidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.txtEspecialidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEspecialidad.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtEspecialidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.txtEspecialidad.Location = new System.Drawing.Point(216, 76);
            this.txtEspecialidad.MaxLength = 150;
            this.txtEspecialidad.Name = "txtEspecialidad";
            this.txtEspecialidad.Size = new System.Drawing.Size(192, 29);
            this.txtEspecialidad.TabIndex = 14;
            // 
            // lblMaterias
            // 
            this.lblMaterias.AutoSize = true;
            this.lblMaterias.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblMaterias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblMaterias.Location = new System.Drawing.Point(24, 128);
            this.lblMaterias.Name = "lblMaterias";
            this.lblMaterias.Size = new System.Drawing.Size(169, 21);
            this.lblMaterias.TabIndex = 15;
            this.lblMaterias.Text = "Materias que imparte *";
            // 
            // btnMaterias
            // 
            this.btnMaterias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.btnMaterias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaterias.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(48)))), ((int)(((byte)(68)))));
            this.btnMaterias.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(78)))), ((int)(((byte)(98)))));
            this.btnMaterias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaterias.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnMaterias.ForeColor = System.Drawing.Color.White;
            this.btnMaterias.Location = new System.Drawing.Point(24, 152);
            this.btnMaterias.Name = "btnMaterias";
            this.btnMaterias.Size = new System.Drawing.Size(150, 32);
            this.btnMaterias.TabIndex = 15;
            this.btnMaterias.Text = "Elegir materias...";
            this.btnMaterias.Tipo = Vistass.TipoBoton.Secundario;
            this.btnMaterias.UseVisualStyleBackColor = false;
            this.btnMaterias.Click += new System.EventHandler(this.btnMaterias_Click);
            // 
            // lblMateriasValor
            // 
            this.lblMateriasValor.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblMateriasValor.ForeColor = System.Drawing.Color.White;
            this.lblMateriasValor.Location = new System.Drawing.Point(186, 152);
            this.lblMateriasValor.Name = "lblMateriasValor";
            this.lblMateriasValor.Size = new System.Drawing.Size(222, 56);
            this.lblMateriasValor.TabIndex = 16;
            this.lblMateriasValor.Text = "Ninguna";
            // 
            // pnlEmergencia
            // 
            this.pnlEmergencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.pnlEmergencia.Controls.Add(this.lblSecEmergencia);
            this.pnlEmergencia.Controls.Add(this.lblEmgNombre);
            this.pnlEmergencia.Controls.Add(this.txtEmgNombre);
            this.pnlEmergencia.Controls.Add(this.lblEmgParentesco);
            this.pnlEmergencia.Controls.Add(this.txtEmgParentesco);
            this.pnlEmergencia.Controls.Add(this.lblEmgTelefono);
            this.pnlEmergencia.Controls.Add(this.txtEmgTelefono);
            this.pnlEmergencia.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.pnlEmergencia.Location = new System.Drawing.Point(472, 452);
            this.pnlEmergencia.Name = "pnlEmergencia";
            this.pnlEmergencia.Size = new System.Drawing.Size(424, 220);
            this.pnlEmergencia.TabIndex = 7;
            // 
            // lblSecEmergencia
            // 
            this.lblSecEmergencia.AutoSize = true;
            this.lblSecEmergencia.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSecEmergencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(204)))), ((int)(((byte)(21)))));
            this.lblSecEmergencia.Location = new System.Drawing.Point(24, 16);
            this.lblSecEmergencia.Name = "lblSecEmergencia";
            this.lblSecEmergencia.Size = new System.Drawing.Size(240, 23);
            this.lblSecEmergencia.TabIndex = 0;
            this.lblSecEmergencia.Text = "CONTACTO DE EMERGENCIA";
            // 
            // lblEmgNombre
            // 
            this.lblEmgNombre.AutoSize = true;
            this.lblEmgNombre.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblEmgNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblEmgNombre.Location = new System.Drawing.Point(24, 52);
            this.lblEmgNombre.Name = "lblEmgNombre";
            this.lblEmgNombre.Size = new System.Drawing.Size(156, 21);
            this.lblEmgNombre.TabIndex = 1;
            this.lblEmgNombre.Text = "Nombre del contacto";
            // 
            // txtEmgNombre
            // 
            this.txtEmgNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.txtEmgNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmgNombre.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtEmgNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.txtEmgNombre.Location = new System.Drawing.Point(24, 76);
            this.txtEmgNombre.MaxLength = 100;
            this.txtEmgNombre.Name = "txtEmgNombre";
            this.txtEmgNombre.Size = new System.Drawing.Size(376, 29);
            this.txtEmgNombre.TabIndex = 16;
            this.txtEmgNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreEmpleado_KeyPress);
            // 
            // lblEmgParentesco
            // 
            this.lblEmgParentesco.AutoSize = true;
            this.lblEmgParentesco.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblEmgParentesco.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblEmgParentesco.Location = new System.Drawing.Point(24, 128);
            this.lblEmgParentesco.Name = "lblEmgParentesco";
            this.lblEmgParentesco.Size = new System.Drawing.Size(85, 21);
            this.lblEmgParentesco.TabIndex = 17;
            this.lblEmgParentesco.Text = "Parentesco";
            // 
            // txtEmgParentesco
            // 
            this.txtEmgParentesco.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.txtEmgParentesco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmgParentesco.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtEmgParentesco.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.txtEmgParentesco.Location = new System.Drawing.Point(24, 152);
            this.txtEmgParentesco.MaxLength = 50;
            this.txtEmgParentesco.Name = "txtEmgParentesco";
            this.txtEmgParentesco.Size = new System.Drawing.Size(176, 29);
            this.txtEmgParentesco.TabIndex = 17;
            this.txtEmgParentesco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreEmpleado_KeyPress);
            // 
            // lblEmgTelefono
            // 
            this.lblEmgTelefono.AutoSize = true;
            this.lblEmgTelefono.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblEmgTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblEmgTelefono.Location = new System.Drawing.Point(216, 128);
            this.lblEmgTelefono.Name = "lblEmgTelefono";
            this.lblEmgTelefono.Size = new System.Drawing.Size(68, 21);
            this.lblEmgTelefono.TabIndex = 18;
            this.lblEmgTelefono.Text = "Teléfono";
            // 
            // txtEmgTelefono
            // 
            this.txtEmgTelefono.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.txtEmgTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmgTelefono.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtEmgTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.txtEmgTelefono.Location = new System.Drawing.Point(216, 152);
            this.txtEmgTelefono.MaxLength = 20;
            this.txtEmgTelefono.Name = "txtEmgTelefono";
            this.txtEmgTelefono.Size = new System.Drawing.Size(184, 29);
            this.txtEmgTelefono.TabIndex = 18;
            this.txtEmgTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroTelefono_KeyPress);
            // 
            // pnlPie
            // 
            this.pnlPie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.pnlPie.Controls.Add(this.lblObligatorios);
            this.pnlPie.Controls.Add(this.btnGuardar);
            this.pnlPie.Controls.Add(this.btnVolver);
            this.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPie.Location = new System.Drawing.Point(0, 680);
            this.pnlPie.Name = "pnlPie";
            this.pnlPie.Size = new System.Drawing.Size(1180, 62);
            this.pnlPie.TabIndex = 4;
            // 
            // lblObligatorios
            // 
            this.lblObligatorios.AutoSize = true;
            this.lblObligatorios.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblObligatorios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblObligatorios.Location = new System.Drawing.Point(26, 22);
            this.lblObligatorios.Name = "lblObligatorios";
            this.lblObligatorios.Size = new System.Drawing.Size(151, 21);
            this.lblObligatorios.TabIndex = 0;
            this.lblObligatorios.Text = "* Campo obligatorio";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(204)))), ((int)(((byte)(21)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(192)))), ((int)(((byte)(9)))));
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(39)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.btnGuardar.Location = new System.Drawing.Point(896, 13);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(150, 36);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Registrar empleado";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.btnVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVolver.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnVolver.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(48)))), ((int)(((byte)(68)))));
            this.btnVolver.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(78)))), ((int)(((byte)(98)))));
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.Location = new System.Drawing.Point(1056, 13);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(100, 36);
            this.btnVolver.TabIndex = 2;
            this.btnVolver.Text = "Cancelar";
            this.btnVolver.Tipo = Vistass.TipoBoton.Secundario;
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // frmAgregarPersonal
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.CancelButton = this.btnVolver;
            this.ClientSize = new System.Drawing.Size(1180, 742);
            this.Controls.Add(this.lblTituloForm);
            this.Controls.Add(this.lblSubtituloForm);
            this.Controls.Add(this.pnlLaboral);
            this.Controls.Add(this.pnlPersonal);
            this.Controls.Add(this.pnlFoto);
            this.Controls.Add(this.pnlFicha);
            this.Controls.Add(this.pnlEmergencia);
            this.Controls.Add(this.pnlPie);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAgregarPersonal";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registrar nuevo empleado";
            this.Load += new System.EventHandler(this.frmAgregarPersonal_Load);
            this.pnlLaboral.ResumeLayout(false);
            this.pnlLaboral.PerformLayout();
            this.pnlPersonal.ResumeLayout(false);
            this.pnlPersonal.PerformLayout();
            this.pnlFoto.ResumeLayout(false);
            this.pnlFoto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            this.pnlFicha.ResumeLayout(false);
            this.pnlFicha.PerformLayout();
            this.pnlEmergencia.ResumeLayout(false);
            this.pnlEmergencia.PerformLayout();
            this.pnlPie.ResumeLayout(false);
            this.pnlPie.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTituloForm;
        private System.Windows.Forms.Label lblSubtituloForm;
        private System.Windows.Forms.Panel pnlLaboral;
        private System.Windows.Forms.Label lblSecLaboral;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.Label lblPlanilla;
        private System.Windows.Forms.Label lblContratacion;
        private System.Windows.Forms.TextBox txtNombreEmpleado;
        private Vistass.ComboOscuro cmbCargo;
        private Vistass.ComboOscuro cmbPlanilla;
        private Vistass.FechaOscura dtpFechaContratacion;
        private System.Windows.Forms.Panel pnlPersonal;
        private System.Windows.Forms.Label lblSecPersonal;
        private System.Windows.Forms.Label lblNacimiento;
        private System.Windows.Forms.Label lblEstadoCivil;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblReligion;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblDireccion;
        private Vistass.FechaOscura dtpFechaNacimiento;
        private Vistass.ComboOscuro cmbEstadoCivil;
        private System.Windows.Forms.TextBox txtNumeroTelefono;
        private System.Windows.Forms.TextBox txtReligion;
        private System.Windows.Forms.TextBox txtCorreoEmpleado;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Panel pnlFoto;
        private System.Windows.Forms.Label lblSecFoto;
        private System.Windows.Forms.PictureBox picFoto;
        private Vistass.BotonTema btnElegirFoto;
        private Vistass.BotonTema btnQuitarFoto;
        private System.Windows.Forms.Panel pnlFicha;
        private System.Windows.Forms.Label lblSecFicha;
        private System.Windows.Forms.Label lblDui;
        private System.Windows.Forms.TextBox txtDui;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.TextBox txtEspecialidad;
        private System.Windows.Forms.Label lblMaterias;
        private Vistass.BotonTema btnMaterias;
        private System.Windows.Forms.Label lblMateriasValor;
        private System.Windows.Forms.Panel pnlEmergencia;
        private System.Windows.Forms.Label lblSecEmergencia;
        private System.Windows.Forms.Label lblEmgNombre;
        private System.Windows.Forms.TextBox txtEmgNombre;
        private System.Windows.Forms.Label lblEmgParentesco;
        private System.Windows.Forms.TextBox txtEmgParentesco;
        private System.Windows.Forms.Label lblEmgTelefono;
        private System.Windows.Forms.TextBox txtEmgTelefono;
        private System.Windows.Forms.Panel pnlPie;
        private System.Windows.Forms.Label lblObligatorios;
        private Vistass.BotonTema btnGuardar;
        private Vistass.BotonTema btnVolver;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}