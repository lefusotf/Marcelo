namespace Vistass
{
    partial class frmExpedienteEmpleado
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
            this.pnlCabecera = new System.Windows.Forms.Panel();
            this.pnlAvatar = new System.Windows.Forms.Panel();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblBadgeEstado = new System.Windows.Forms.Label();
            this.tabExp = new System.Windows.Forms.TabControl();
            this.tabPersonal = new System.Windows.Forms.TabPage();
            this.lblCapTelefono = new System.Windows.Forms.Label();
            this.lblValTelefono = new System.Windows.Forms.Label();
            this.lblCapCorreo = new System.Windows.Forms.Label();
            this.lblValCorreo = new System.Windows.Forms.Label();
            this.lblCapNacimiento = new System.Windows.Forms.Label();
            this.lblValNacimiento = new System.Windows.Forms.Label();
            this.lblCapEstadoCivil = new System.Windows.Forms.Label();
            this.lblValEstadoCivil = new System.Windows.Forms.Label();
            this.lblCapReligion = new System.Windows.Forms.Label();
            this.lblValReligion = new System.Windows.Forms.Label();
            this.lblCapDireccion = new System.Windows.Forms.Label();
            this.lblValDireccion = new System.Windows.Forms.Label();
            this.tabLaboral = new System.Windows.Forms.TabPage();
            this.lblCapCargo = new System.Windows.Forms.Label();
            this.lblValCargo = new System.Windows.Forms.Label();
            this.lblCapEstado = new System.Windows.Forms.Label();
            this.lblValEstado = new System.Windows.Forms.Label();
            this.lblCapContratacion = new System.Windows.Forms.Label();
            this.lblValContratacion = new System.Windows.Forms.Label();
            this.lblCapAntiguedad = new System.Windows.Forms.Label();
            this.lblValAntiguedad = new System.Windows.Forms.Label();
            this.tabPlanilla = new System.Windows.Forms.TabPage();
            this.lblCapSalarioBase = new System.Windows.Forms.Label();
            this.lblValSalarioBase = new System.Windows.Forms.Label();
            this.lblCapDescuento = new System.Windows.Forms.Label();
            this.lblValDescuento = new System.Windows.Forms.Label();
            this.lblCapBono = new System.Windows.Forms.Label();
            this.lblValBono = new System.Windows.Forms.Label();
            this.lblCapSalarioNeto = new System.Windows.Forms.Label();
            this.lblValSalarioNeto = new System.Windows.Forms.Label();
            this.lblCapEstadoPago = new System.Windows.Forms.Label();
            this.lblValEstadoPago = new System.Windows.Forms.Label();
            this.lblCapPlanilla = new System.Windows.Forms.Label();
            this.lblValPlanilla = new System.Windows.Forms.Label();
            this.tabAsignaciones = new System.Windows.Forms.TabPage();
            this.dgvAsignaciones = new Vistass.GridOscuro();
            this.pnlAcciones = new System.Windows.Forms.Panel();
            this.btnAsignar = new Vistass.BotonTema();
            this.btnQuitarAsig = new Vistass.BotonTema();
            this.pnlCarga = new System.Windows.Forms.Panel();
            this.lblCarga = new System.Windows.Forms.Label();
            this.pbCarga = new System.Windows.Forms.ProgressBar();
            this.lblAnio = new System.Windows.Forms.Label();
            this.cmbAnio = new Vistass.ComboOscuro();
            this.pnlPie = new System.Windows.Forms.Panel();
            this.btnEditar = new Vistass.BotonTema();
            this.btnCerrar = new Vistass.BotonTema();
            this.lblCapDui = new System.Windows.Forms.Label();
            this.lblValDui = new System.Windows.Forms.Label();
            this.lblCapEmergencia = new System.Windows.Forms.Label();
            this.lblValEmergencia = new System.Windows.Forms.Label();
            this.lblCapEspecialidad = new System.Windows.Forms.Label();
            this.lblValEspecialidad = new System.Windows.Forms.Label();
            this.lblCapMaterias = new System.Windows.Forms.Label();
            this.lblValMaterias = new System.Windows.Forms.Label();
            this.btnFicha = new Vistass.BotonTema();
            this.pnlCabecera.SuspendLayout();
            this.tabExp.SuspendLayout();
            this.tabPersonal.SuspendLayout();
            this.tabLaboral.SuspendLayout();
            this.tabPlanilla.SuspendLayout();
            this.tabAsignaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignaciones)).BeginInit();
            this.pnlAcciones.SuspendLayout();
            this.pnlCarga.SuspendLayout();
            this.pnlPie.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.pnlCabecera.Controls.Add(this.pnlAvatar);
            this.pnlCabecera.Controls.Add(this.lblNombre);
            this.pnlCabecera.Controls.Add(this.lblSubtitulo);
            this.pnlCabecera.Controls.Add(this.lblBadgeEstado);
            this.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCabecera.Location = new System.Drawing.Point(0, 0);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(900, 130);
            this.pnlCabecera.TabIndex = 2;
            this.pnlCabecera.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCabecera_Paint);
            // 
            // pnlAvatar
            // 
            this.pnlAvatar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.pnlAvatar.Location = new System.Drawing.Point(28, 25);
            this.pnlAvatar.Name = "pnlAvatar";
            this.pnlAvatar.Size = new System.Drawing.Size(80, 80);
            this.pnlAvatar.TabIndex = 0;
            this.pnlAvatar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlAvatar_Paint);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(128, 22);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(377, 46);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre del empleado";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(131, 64);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(63, 25);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Cargo";
            // 
            // lblBadgeEstado
            // 
            this.lblBadgeEstado.AutoSize = true;
            this.lblBadgeEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.lblBadgeEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBadgeEstado.ForeColor = System.Drawing.Color.White;
            this.lblBadgeEstado.Location = new System.Drawing.Point(132, 93);
            this.lblBadgeEstado.Name = "lblBadgeEstado";
            this.lblBadgeEstado.Padding = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.lblBadgeEstado.Size = new System.Drawing.Size(70, 26);
            this.lblBadgeEstado.TabIndex = 3;
            this.lblBadgeEstado.Text = "Activo";
            // 
            // tabExp
            // 
            this.tabExp.Controls.Add(this.tabPersonal);
            this.tabExp.Controls.Add(this.tabLaboral);
            this.tabExp.Controls.Add(this.tabPlanilla);
            this.tabExp.Controls.Add(this.tabAsignaciones);
            this.tabExp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabExp.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabExp.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabExp.ItemSize = new System.Drawing.Size(220, 36);
            this.tabExp.Location = new System.Drawing.Point(0, 130);
            this.tabExp.Name = "tabExp";
            this.tabExp.SelectedIndex = 0;
            this.tabExp.Size = new System.Drawing.Size(900, 410);
            this.tabExp.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabExp.TabIndex = 0;
            this.tabExp.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabExp_DrawItem);
            // 
            // tabPersonal
            // 
            this.tabPersonal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.tabPersonal.Controls.Add(this.lblCapTelefono);
            this.tabPersonal.Controls.Add(this.lblValTelefono);
            this.tabPersonal.Controls.Add(this.lblCapCorreo);
            this.tabPersonal.Controls.Add(this.lblValCorreo);
            this.tabPersonal.Controls.Add(this.lblCapNacimiento);
            this.tabPersonal.Controls.Add(this.lblValNacimiento);
            this.tabPersonal.Controls.Add(this.lblCapEstadoCivil);
            this.tabPersonal.Controls.Add(this.lblValEstadoCivil);
            this.tabPersonal.Controls.Add(this.lblCapReligion);
            this.tabPersonal.Controls.Add(this.lblValReligion);
            this.tabPersonal.Controls.Add(this.lblCapDireccion);
            this.tabPersonal.Controls.Add(this.lblValDireccion);
            this.tabPersonal.Controls.Add(this.lblCapDui);
            this.tabPersonal.Controls.Add(this.lblValDui);
            this.tabPersonal.Controls.Add(this.lblCapEmergencia);
            this.tabPersonal.Controls.Add(this.lblValEmergencia);
            this.tabPersonal.Location = new System.Drawing.Point(4, 40);
            this.tabPersonal.Name = "tabPersonal";
            this.tabPersonal.Size = new System.Drawing.Size(892, 366);
            this.tabPersonal.TabIndex = 0;
            this.tabPersonal.Text = "Datos personales";
            // 
            // lblCapTelefono
            // 
            this.lblCapTelefono.AutoSize = true;
            this.lblCapTelefono.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblCapTelefono.Location = new System.Drawing.Point(36, 32);
            this.lblCapTelefono.Name = "lblCapTelefono";
            this.lblCapTelefono.Size = new System.Drawing.Size(75, 23);
            this.lblCapTelefono.TabIndex = 0;
            this.lblCapTelefono.Text = "Teléfono";
            // 
            // lblValTelefono
            // 
            this.lblValTelefono.AutoSize = true;
            this.lblValTelefono.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValTelefono.ForeColor = System.Drawing.Color.White;
            this.lblValTelefono.Location = new System.Drawing.Point(36, 54);
            this.lblValTelefono.Name = "lblValTelefono";
            this.lblValTelefono.Size = new System.Drawing.Size(27, 23);
            this.lblValTelefono.TabIndex = 1;
            this.lblValTelefono.Text = "—";
            // 
            // lblCapCorreo
            // 
            this.lblCapCorreo.AutoSize = true;
            this.lblCapCorreo.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapCorreo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblCapCorreo.Location = new System.Drawing.Point(464, 32);
            this.lblCapCorreo.Name = "lblCapCorreo";
            this.lblCapCorreo.Size = new System.Drawing.Size(151, 23);
            this.lblCapCorreo.TabIndex = 2;
            this.lblCapCorreo.Text = "Correo electrónico";
            // 
            // lblValCorreo
            // 
            this.lblValCorreo.AutoSize = true;
            this.lblValCorreo.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValCorreo.ForeColor = System.Drawing.Color.White;
            this.lblValCorreo.Location = new System.Drawing.Point(464, 54);
            this.lblValCorreo.Name = "lblValCorreo";
            this.lblValCorreo.Size = new System.Drawing.Size(27, 23);
            this.lblValCorreo.TabIndex = 3;
            this.lblValCorreo.Text = "—";
            // 
            // lblCapNacimiento
            // 
            this.lblCapNacimiento.AutoSize = true;
            this.lblCapNacimiento.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapNacimiento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblCapNacimiento.Location = new System.Drawing.Point(36, 104);
            this.lblCapNacimiento.Name = "lblCapNacimiento";
            this.lblCapNacimiento.Size = new System.Drawing.Size(169, 23);
            this.lblCapNacimiento.TabIndex = 4;
            this.lblCapNacimiento.Text = "Fecha de nacimiento";
            // 
            // lblValNacimiento
            // 
            this.lblValNacimiento.AutoSize = true;
            this.lblValNacimiento.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValNacimiento.ForeColor = System.Drawing.Color.White;
            this.lblValNacimiento.Location = new System.Drawing.Point(36, 126);
            this.lblValNacimiento.Name = "lblValNacimiento";
            this.lblValNacimiento.Size = new System.Drawing.Size(27, 23);
            this.lblValNacimiento.TabIndex = 5;
            this.lblValNacimiento.Text = "—";
            // 
            // lblCapEstadoCivil
            // 
            this.lblCapEstadoCivil.AutoSize = true;
            this.lblCapEstadoCivil.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapEstadoCivil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblCapEstadoCivil.Location = new System.Drawing.Point(464, 104);
            this.lblCapEstadoCivil.Name = "lblCapEstadoCivil";
            this.lblCapEstadoCivil.Size = new System.Drawing.Size(95, 23);
            this.lblCapEstadoCivil.TabIndex = 6;
            this.lblCapEstadoCivil.Text = "Estado civil";
            // 
            // lblValEstadoCivil
            // 
            this.lblValEstadoCivil.AutoSize = true;
            this.lblValEstadoCivil.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValEstadoCivil.ForeColor = System.Drawing.Color.White;
            this.lblValEstadoCivil.Location = new System.Drawing.Point(464, 126);
            this.lblValEstadoCivil.Name = "lblValEstadoCivil";
            this.lblValEstadoCivil.Size = new System.Drawing.Size(27, 23);
            this.lblValEstadoCivil.TabIndex = 7;
            this.lblValEstadoCivil.Text = "—";
            // 
            // lblCapReligion
            // 
            this.lblCapReligion.AutoSize = true;
            this.lblCapReligion.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapReligion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblCapReligion.Location = new System.Drawing.Point(36, 176);
            this.lblCapReligion.Name = "lblCapReligion";
            this.lblCapReligion.Size = new System.Drawing.Size(72, 23);
            this.lblCapReligion.TabIndex = 8;
            this.lblCapReligion.Text = "Religión";
            // 
            // lblValReligion
            // 
            this.lblValReligion.AutoSize = true;
            this.lblValReligion.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValReligion.ForeColor = System.Drawing.Color.White;
            this.lblValReligion.Location = new System.Drawing.Point(36, 198);
            this.lblValReligion.Name = "lblValReligion";
            this.lblValReligion.Size = new System.Drawing.Size(27, 23);
            this.lblValReligion.TabIndex = 9;
            this.lblValReligion.Text = "—";
            // 
            // lblCapDireccion
            // 
            this.lblCapDireccion.AutoSize = true;
            this.lblCapDireccion.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapDireccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblCapDireccion.Location = new System.Drawing.Point(36, 248);
            this.lblCapDireccion.Name = "lblCapDireccion";
            this.lblCapDireccion.Size = new System.Drawing.Size(81, 23);
            this.lblCapDireccion.TabIndex = 10;
            this.lblCapDireccion.Text = "Dirección";
            // 
            // lblValDireccion
            // 
            this.lblValDireccion.AutoSize = true;
            this.lblValDireccion.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValDireccion.ForeColor = System.Drawing.Color.White;
            this.lblValDireccion.Location = new System.Drawing.Point(36, 270);
            this.lblValDireccion.MaximumSize = new System.Drawing.Size(400, 0);
            this.lblValDireccion.Name = "lblValDireccion";
            this.lblValDireccion.Size = new System.Drawing.Size(27, 23);
            this.lblValDireccion.TabIndex = 11;
            this.lblValDireccion.Text = "—";
            // 
            // tabLaboral
            // 
            this.tabLaboral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.tabLaboral.Controls.Add(this.lblCapCargo);
            this.tabLaboral.Controls.Add(this.lblValCargo);
            this.tabLaboral.Controls.Add(this.lblCapEstado);
            this.tabLaboral.Controls.Add(this.lblValEstado);
            this.tabLaboral.Controls.Add(this.lblCapContratacion);
            this.tabLaboral.Controls.Add(this.lblValContratacion);
            this.tabLaboral.Controls.Add(this.lblCapAntiguedad);
            this.tabLaboral.Controls.Add(this.lblValAntiguedad);
            this.tabLaboral.Controls.Add(this.lblCapEspecialidad);
            this.tabLaboral.Controls.Add(this.lblValEspecialidad);
            this.tabLaboral.Controls.Add(this.lblCapMaterias);
            this.tabLaboral.Controls.Add(this.lblValMaterias);
            this.tabLaboral.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabLaboral.Location = new System.Drawing.Point(4, 40);
            this.tabLaboral.Name = "tabLaboral";
            this.tabLaboral.Size = new System.Drawing.Size(892, 366);
            this.tabLaboral.TabIndex = 1;
            this.tabLaboral.Text = "Datos laborales";
            // 
            // lblCapCargo
            // 
            this.lblCapCargo.AutoSize = true;
            this.lblCapCargo.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapCargo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblCapCargo.Location = new System.Drawing.Point(36, 32);
            this.lblCapCargo.Name = "lblCapCargo";
            this.lblCapCargo.Size = new System.Drawing.Size(56, 23);
            this.lblCapCargo.TabIndex = 0;
            this.lblCapCargo.Text = "Cargo";
            // 
            // lblValCargo
            // 
            this.lblValCargo.AutoSize = true;
            this.lblValCargo.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValCargo.ForeColor = System.Drawing.Color.White;
            this.lblValCargo.Location = new System.Drawing.Point(36, 54);
            this.lblValCargo.Name = "lblValCargo";
            this.lblValCargo.Size = new System.Drawing.Size(27, 23);
            this.lblValCargo.TabIndex = 1;
            this.lblValCargo.Text = "—";
            // 
            // lblCapEstado
            // 
            this.lblCapEstado.AutoSize = true;
            this.lblCapEstado.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblCapEstado.Location = new System.Drawing.Point(464, 32);
            this.lblCapEstado.Name = "lblCapEstado";
            this.lblCapEstado.Size = new System.Drawing.Size(61, 23);
            this.lblCapEstado.TabIndex = 2;
            this.lblCapEstado.Text = "Estado";
            // 
            // lblValEstado
            // 
            this.lblValEstado.AutoSize = true;
            this.lblValEstado.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValEstado.ForeColor = System.Drawing.Color.White;
            this.lblValEstado.Location = new System.Drawing.Point(464, 54);
            this.lblValEstado.Name = "lblValEstado";
            this.lblValEstado.Size = new System.Drawing.Size(27, 23);
            this.lblValEstado.TabIndex = 3;
            this.lblValEstado.Text = "—";
            // 
            // lblCapContratacion
            // 
            this.lblCapContratacion.AutoSize = true;
            this.lblCapContratacion.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapContratacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblCapContratacion.Location = new System.Drawing.Point(36, 104);
            this.lblCapContratacion.Name = "lblCapContratacion";
            this.lblCapContratacion.Size = new System.Drawing.Size(180, 23);
            this.lblCapContratacion.TabIndex = 4;
            this.lblCapContratacion.Text = "Fecha de contratación";
            // 
            // lblValContratacion
            // 
            this.lblValContratacion.AutoSize = true;
            this.lblValContratacion.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValContratacion.ForeColor = System.Drawing.Color.White;
            this.lblValContratacion.Location = new System.Drawing.Point(36, 126);
            this.lblValContratacion.Name = "lblValContratacion";
            this.lblValContratacion.Size = new System.Drawing.Size(27, 23);
            this.lblValContratacion.TabIndex = 5;
            this.lblValContratacion.Text = "—";
            // 
            // lblCapAntiguedad
            // 
            this.lblCapAntiguedad.AutoSize = true;
            this.lblCapAntiguedad.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapAntiguedad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblCapAntiguedad.Location = new System.Drawing.Point(464, 104);
            this.lblCapAntiguedad.Name = "lblCapAntiguedad";
            this.lblCapAntiguedad.Size = new System.Drawing.Size(99, 23);
            this.lblCapAntiguedad.TabIndex = 6;
            this.lblCapAntiguedad.Text = "Antigüedad";
            // 
            // lblValAntiguedad
            // 
            this.lblValAntiguedad.AutoSize = true;
            this.lblValAntiguedad.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValAntiguedad.ForeColor = System.Drawing.Color.White;
            this.lblValAntiguedad.Location = new System.Drawing.Point(464, 126);
            this.lblValAntiguedad.Name = "lblValAntiguedad";
            this.lblValAntiguedad.Size = new System.Drawing.Size(27, 23);
            this.lblValAntiguedad.TabIndex = 7;
            this.lblValAntiguedad.Text = "—";
            // 
            // tabPlanilla
            // 
            this.tabPlanilla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.tabPlanilla.Controls.Add(this.lblCapSalarioBase);
            this.tabPlanilla.Controls.Add(this.lblValSalarioBase);
            this.tabPlanilla.Controls.Add(this.lblCapDescuento);
            this.tabPlanilla.Controls.Add(this.lblValDescuento);
            this.tabPlanilla.Controls.Add(this.lblCapBono);
            this.tabPlanilla.Controls.Add(this.lblValBono);
            this.tabPlanilla.Controls.Add(this.lblCapSalarioNeto);
            this.tabPlanilla.Controls.Add(this.lblValSalarioNeto);
            this.tabPlanilla.Controls.Add(this.lblCapEstadoPago);
            this.tabPlanilla.Controls.Add(this.lblValEstadoPago);
            this.tabPlanilla.Controls.Add(this.lblCapPlanilla);
            this.tabPlanilla.Controls.Add(this.lblValPlanilla);
            this.tabPlanilla.Location = new System.Drawing.Point(4, 40);
            this.tabPlanilla.Name = "tabPlanilla";
            this.tabPlanilla.Size = new System.Drawing.Size(892, 366);
            this.tabPlanilla.TabIndex = 2;
            this.tabPlanilla.Text = "Planilla";
            // 
            // lblCapSalarioBase
            // 
            this.lblCapSalarioBase.AutoSize = true;
            this.lblCapSalarioBase.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapSalarioBase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblCapSalarioBase.Location = new System.Drawing.Point(36, 32);
            this.lblCapSalarioBase.Name = "lblCapSalarioBase";
            this.lblCapSalarioBase.Size = new System.Drawing.Size(106, 23);
            this.lblCapSalarioBase.TabIndex = 0;
            this.lblCapSalarioBase.Text = "Salario base";
            // 
            // lblValSalarioBase
            // 
            this.lblValSalarioBase.AutoSize = true;
            this.lblValSalarioBase.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValSalarioBase.ForeColor = System.Drawing.Color.White;
            this.lblValSalarioBase.Location = new System.Drawing.Point(36, 54);
            this.lblValSalarioBase.Name = "lblValSalarioBase";
            this.lblValSalarioBase.Size = new System.Drawing.Size(27, 23);
            this.lblValSalarioBase.TabIndex = 1;
            this.lblValSalarioBase.Text = "—";
            // 
            // lblCapDescuento
            // 
            this.lblCapDescuento.AutoSize = true;
            this.lblCapDescuento.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapDescuento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblCapDescuento.Location = new System.Drawing.Point(464, 32);
            this.lblCapDescuento.Name = "lblCapDescuento";
            this.lblCapDescuento.Size = new System.Drawing.Size(93, 23);
            this.lblCapDescuento.TabIndex = 2;
            this.lblCapDescuento.Text = "Descuento";
            // 
            // lblValDescuento
            // 
            this.lblValDescuento.AutoSize = true;
            this.lblValDescuento.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValDescuento.ForeColor = System.Drawing.Color.White;
            this.lblValDescuento.Location = new System.Drawing.Point(464, 54);
            this.lblValDescuento.Name = "lblValDescuento";
            this.lblValDescuento.Size = new System.Drawing.Size(27, 23);
            this.lblValDescuento.TabIndex = 3;
            this.lblValDescuento.Text = "—";
            // 
            // lblCapBono
            // 
            this.lblCapBono.AutoSize = true;
            this.lblCapBono.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapBono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblCapBono.Location = new System.Drawing.Point(36, 104);
            this.lblCapBono.Name = "lblCapBono";
            this.lblCapBono.Size = new System.Drawing.Size(51, 23);
            this.lblCapBono.TabIndex = 4;
            this.lblCapBono.Text = "Bono";
            // 
            // lblValBono
            // 
            this.lblValBono.AutoSize = true;
            this.lblValBono.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValBono.ForeColor = System.Drawing.Color.White;
            this.lblValBono.Location = new System.Drawing.Point(36, 126);
            this.lblValBono.Name = "lblValBono";
            this.lblValBono.Size = new System.Drawing.Size(27, 23);
            this.lblValBono.TabIndex = 5;
            this.lblValBono.Text = "—";
            // 
            // lblCapSalarioNeto
            // 
            this.lblCapSalarioNeto.AutoSize = true;
            this.lblCapSalarioNeto.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapSalarioNeto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblCapSalarioNeto.Location = new System.Drawing.Point(464, 104);
            this.lblCapSalarioNeto.Name = "lblCapSalarioNeto";
            this.lblCapSalarioNeto.Size = new System.Drawing.Size(106, 23);
            this.lblCapSalarioNeto.TabIndex = 6;
            this.lblCapSalarioNeto.Text = "Salario neto";
            // 
            // lblValSalarioNeto
            // 
            this.lblValSalarioNeto.AutoSize = true;
            this.lblValSalarioNeto.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValSalarioNeto.ForeColor = System.Drawing.Color.White;
            this.lblValSalarioNeto.Location = new System.Drawing.Point(464, 126);
            this.lblValSalarioNeto.Name = "lblValSalarioNeto";
            this.lblValSalarioNeto.Size = new System.Drawing.Size(27, 23);
            this.lblValSalarioNeto.TabIndex = 7;
            this.lblValSalarioNeto.Text = "—";
            // 
            // lblCapEstadoPago
            // 
            this.lblCapEstadoPago.AutoSize = true;
            this.lblCapEstadoPago.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapEstadoPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblCapEstadoPago.Location = new System.Drawing.Point(36, 176);
            this.lblCapEstadoPago.Name = "lblCapEstadoPago";
            this.lblCapEstadoPago.Size = new System.Drawing.Size(134, 23);
            this.lblCapEstadoPago.TabIndex = 8;
            this.lblCapEstadoPago.Text = "Estado de pago";
            // 
            // lblValEstadoPago
            // 
            this.lblValEstadoPago.AutoSize = true;
            this.lblValEstadoPago.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValEstadoPago.ForeColor = System.Drawing.Color.White;
            this.lblValEstadoPago.Location = new System.Drawing.Point(36, 198);
            this.lblValEstadoPago.Name = "lblValEstadoPago";
            this.lblValEstadoPago.Size = new System.Drawing.Size(27, 23);
            this.lblValEstadoPago.TabIndex = 9;
            this.lblValEstadoPago.Text = "—";
            // 
            // lblCapPlanilla
            // 
            this.lblCapPlanilla.AutoSize = true;
            this.lblCapPlanilla.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapPlanilla.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblCapPlanilla.Location = new System.Drawing.Point(464, 176);
            this.lblCapPlanilla.Name = "lblCapPlanilla";
            this.lblCapPlanilla.Size = new System.Drawing.Size(118, 23);
            this.lblCapPlanilla.TabIndex = 10;
            this.lblCapPlanilla.Text = "N° de planilla";
            // 
            // lblValPlanilla
            // 
            this.lblValPlanilla.AutoSize = true;
            this.lblValPlanilla.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValPlanilla.ForeColor = System.Drawing.Color.White;
            this.lblValPlanilla.Location = new System.Drawing.Point(464, 198);
            this.lblValPlanilla.Name = "lblValPlanilla";
            this.lblValPlanilla.Size = new System.Drawing.Size(27, 23);
            this.lblValPlanilla.TabIndex = 11;
            this.lblValPlanilla.Text = "—";
            // 
            // tabAsignaciones
            // 
            this.tabAsignaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.tabAsignaciones.Controls.Add(this.dgvAsignaciones);
            this.tabAsignaciones.Controls.Add(this.pnlAcciones);
            this.tabAsignaciones.Controls.Add(this.pnlCarga);
            this.tabAsignaciones.Location = new System.Drawing.Point(4, 40);
            this.tabAsignaciones.Name = "tabAsignaciones";
            this.tabAsignaciones.Size = new System.Drawing.Size(892, 366);
            this.tabAsignaciones.TabIndex = 3;
            this.tabAsignaciones.Text = "Asignaciones académicas";
            // 
            // dgvAsignaciones
            // 
            this.dgvAsignaciones.ColumnHeadersHeight = 29;
            this.dgvAsignaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAsignaciones.Location = new System.Drawing.Point(0, 78);
            this.dgvAsignaciones.Name = "dgvAsignaciones";
            this.dgvAsignaciones.RowHeadersWidth = 51;
            this.dgvAsignaciones.Size = new System.Drawing.Size(892, 232);
            this.dgvAsignaciones.TabIndex = 0;
            this.dgvAsignaciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAsignaciones_CellContentClick);
            this.dgvAsignaciones.SelectionChanged += new System.EventHandler(this.dgvAsignaciones_SelectionChanged);
            // 
            // pnlAcciones
            // 
            this.pnlAcciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.pnlAcciones.Controls.Add(this.btnAsignar);
            this.pnlAcciones.Controls.Add(this.btnQuitarAsig);
            this.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAcciones.Location = new System.Drawing.Point(0, 310);
            this.pnlAcciones.Name = "pnlAcciones";
            this.pnlAcciones.Size = new System.Drawing.Size(892, 56);
            this.pnlAcciones.TabIndex = 1;
            // 
            // btnAsignar
            // 
            this.btnAsignar.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignar.Location = new System.Drawing.Point(36, 10);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(160, 36);
            this.btnAsignar.TabIndex = 0;
            this.btnAsignar.Text = "+ Asignar grupo";
            this.btnAsignar.Tipo = Vistass.TipoBoton.Principal;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // btnQuitarAsig
            // 
            this.btnQuitarAsig.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarAsig.Location = new System.Drawing.Point(206, 10);
            this.btnQuitarAsig.Name = "btnQuitarAsig";
            this.btnQuitarAsig.Size = new System.Drawing.Size(120, 36);
            this.btnQuitarAsig.TabIndex = 1;
            this.btnQuitarAsig.Text = "Quitar";
            this.btnQuitarAsig.Tipo = Vistass.TipoBoton.Secundario;
            this.btnQuitarAsig.Click += new System.EventHandler(this.btnQuitarAsig_Click);
            // 
            // pnlCarga
            // 
            this.pnlCarga.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.pnlCarga.Controls.Add(this.lblCarga);
            this.pnlCarga.Controls.Add(this.pbCarga);
            this.pnlCarga.Controls.Add(this.lblAnio);
            this.pnlCarga.Controls.Add(this.cmbAnio);
            this.pnlCarga.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCarga.Location = new System.Drawing.Point(0, 0);
            this.pnlCarga.Name = "pnlCarga";
            this.pnlCarga.Size = new System.Drawing.Size(892, 78);
            this.pnlCarga.TabIndex = 2;
            // 
            // lblCarga
            // 
            this.lblCarga.AutoSize = true;
            this.lblCarga.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCarga.ForeColor = System.Drawing.Color.White;
            this.lblCarga.Location = new System.Drawing.Point(36, 14);
            this.lblCarga.Name = "lblCarga";
            this.lblCarga.Size = new System.Drawing.Size(133, 25);
            this.lblCarga.TabIndex = 0;
            this.lblCarga.Text = "Carga horaria";
            // 
            // pbCarga
            // 
            this.pbCarga.Location = new System.Drawing.Point(36, 46);
            this.pbCarga.Maximum = 40;
            this.pbCarga.Name = "pbCarga";
            this.pbCarga.Size = new System.Drawing.Size(520, 14);
            this.pbCarga.TabIndex = 1;
            this.pbCarga.Click += new System.EventHandler(this.pbCarga_Click);
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAnio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblAnio.Location = new System.Drawing.Point(700, 14);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(84, 20);
            this.lblAnio.TabIndex = 2;
            this.lblAnio.Text = "Año lectivo";
            // 
            // cmbAnio
            // 
            this.cmbAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbAnio.FormattingEnabled = true;
            this.cmbAnio.Location = new System.Drawing.Point(700, 36);
            this.cmbAnio.Name = "cmbAnio";
            this.cmbAnio.Size = new System.Drawing.Size(130, 31);
            this.cmbAnio.TabIndex = 3;
            this.cmbAnio.SelectedIndexChanged += new System.EventHandler(this.cmbAnio_SelectedIndexChanged);
            // 
            // lblCapDui
            // 
            this.lblCapDui.AutoSize = true;
            this.lblCapDui.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapDui.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblCapDui.Location = new System.Drawing.Point(464, 176);
            this.lblCapDui.Name = "lblCapDui";
            this.lblCapDui.Size = new System.Drawing.Size(36, 23);
            this.lblCapDui.TabIndex = 12;
            this.lblCapDui.Text = "DUI";
            // 
            // lblValDui
            // 
            this.lblValDui.AutoSize = true;
            this.lblValDui.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValDui.ForeColor = System.Drawing.Color.White;
            this.lblValDui.Location = new System.Drawing.Point(464, 198);
            this.lblValDui.Name = "lblValDui";
            this.lblValDui.Size = new System.Drawing.Size(27, 23);
            this.lblValDui.TabIndex = 13;
            this.lblValDui.Text = "—";
            // 
            // lblCapEmergencia
            // 
            this.lblCapEmergencia.AutoSize = true;
            this.lblCapEmergencia.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapEmergencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblCapEmergencia.Location = new System.Drawing.Point(464, 248);
            this.lblCapEmergencia.Name = "lblCapEmergencia";
            this.lblCapEmergencia.Size = new System.Drawing.Size(188, 23);
            this.lblCapEmergencia.TabIndex = 14;
            this.lblCapEmergencia.Text = "Contacto de emergencia";
            // 
            // lblValEmergencia
            // 
            this.lblValEmergencia.AutoSize = true;
            this.lblValEmergencia.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValEmergencia.ForeColor = System.Drawing.Color.White;
            this.lblValEmergencia.Location = new System.Drawing.Point(464, 270);
            this.lblValEmergencia.MaximumSize = new System.Drawing.Size(400, 0);
            this.lblValEmergencia.Name = "lblValEmergencia";
            this.lblValEmergencia.Size = new System.Drawing.Size(27, 23);
            this.lblValEmergencia.TabIndex = 15;
            this.lblValEmergencia.Text = "—";
            // 
            // lblCapEspecialidad
            // 
            this.lblCapEspecialidad.AutoSize = true;
            this.lblCapEspecialidad.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapEspecialidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblCapEspecialidad.Location = new System.Drawing.Point(36, 176);
            this.lblCapEspecialidad.Name = "lblCapEspecialidad";
            this.lblCapEspecialidad.Size = new System.Drawing.Size(180, 23);
            this.lblCapEspecialidad.TabIndex = 8;
            this.lblCapEspecialidad.Text = "Especialidad / formación";
            // 
            // lblValEspecialidad
            // 
            this.lblValEspecialidad.AutoSize = true;
            this.lblValEspecialidad.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValEspecialidad.ForeColor = System.Drawing.Color.White;
            this.lblValEspecialidad.Location = new System.Drawing.Point(36, 198);
            this.lblValEspecialidad.MaximumSize = new System.Drawing.Size(400, 0);
            this.lblValEspecialidad.Name = "lblValEspecialidad";
            this.lblValEspecialidad.Size = new System.Drawing.Size(27, 23);
            this.lblValEspecialidad.TabIndex = 9;
            this.lblValEspecialidad.Text = "—";
            // 
            // lblCapMaterias
            // 
            this.lblCapMaterias.AutoSize = true;
            this.lblCapMaterias.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapMaterias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblCapMaterias.Location = new System.Drawing.Point(464, 176);
            this.lblCapMaterias.Name = "lblCapMaterias";
            this.lblCapMaterias.Size = new System.Drawing.Size(150, 23);
            this.lblCapMaterias.TabIndex = 10;
            this.lblCapMaterias.Text = "Materias que imparte";
            // 
            // lblValMaterias
            // 
            this.lblValMaterias.AutoSize = true;
            this.lblValMaterias.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValMaterias.ForeColor = System.Drawing.Color.White;
            this.lblValMaterias.Location = new System.Drawing.Point(464, 198);
            this.lblValMaterias.MaximumSize = new System.Drawing.Size(400, 0);
            this.lblValMaterias.Name = "lblValMaterias";
            this.lblValMaterias.Size = new System.Drawing.Size(27, 23);
            this.lblValMaterias.TabIndex = 11;
            this.lblValMaterias.Text = "—";
            // 
            // btnFicha
            // 
            this.btnFicha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFicha.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFicha.Location = new System.Drawing.Point(466, 12);
            this.btnFicha.Name = "btnFicha";
            this.btnFicha.Size = new System.Drawing.Size(160, 36);
            this.btnFicha.TabIndex = 2;
            this.btnFicha.Text = "Imprimir ficha";
            this.btnFicha.Tipo = Vistass.TipoBoton.Secundario;
            this.btnFicha.Click += new System.EventHandler(this.btnFicha_Click);
            // 
            // pnlPie
            // 
            this.pnlPie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.pnlPie.Controls.Add(this.btnFicha);
            this.pnlPie.Controls.Add(this.btnEditar);
            this.pnlPie.Controls.Add(this.btnCerrar);
            this.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPie.Location = new System.Drawing.Point(0, 540);
            this.pnlPie.Name = "pnlPie";
            this.pnlPie.Size = new System.Drawing.Size(900, 60);
            this.pnlPie.TabIndex = 1;
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Location = new System.Drawing.Point(636, 12);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(130, 36);
            this.btnEditar.TabIndex = 0;
            this.btnEditar.Text = "Editar datos";
            this.btnEditar.Tipo = Vistass.TipoBoton.Secundario;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.Location = new System.Drawing.Point(776, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 36);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Tipo = Vistass.TipoBoton.Secundario;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // frmExpedienteEmpleado
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.tabExp);
            this.Controls.Add(this.pnlPie);
            this.Controls.Add(this.pnlCabecera);
            this.MinimumSize = new System.Drawing.Size(860, 540);
            this.Name = "frmExpedienteEmpleado";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Expediente del empleado";
            this.Load += new System.EventHandler(this.frmExpedienteEmpleado_Load);
            this.pnlCabecera.ResumeLayout(false);
            this.pnlCabecera.PerformLayout();
            this.tabExp.ResumeLayout(false);
            this.tabPersonal.ResumeLayout(false);
            this.tabPersonal.PerformLayout();
            this.tabLaboral.ResumeLayout(false);
            this.tabLaboral.PerformLayout();
            this.tabPlanilla.ResumeLayout(false);
            this.tabPlanilla.PerformLayout();
            this.tabAsignaciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignaciones)).EndInit();
            this.pnlAcciones.ResumeLayout(false);
            this.pnlCarga.ResumeLayout(false);
            this.pnlCarga.PerformLayout();
            this.pnlPie.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCabecera;
        private System.Windows.Forms.Panel pnlAvatar;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblBadgeEstado;
        private System.Windows.Forms.TabControl tabExp;
        private System.Windows.Forms.TabPage tabPersonal;
        private System.Windows.Forms.TabPage tabLaboral;
        private System.Windows.Forms.TabPage tabPlanilla;
        private System.Windows.Forms.Label lblCapTelefono;
        private System.Windows.Forms.Label lblValTelefono;
        private System.Windows.Forms.Label lblCapCorreo;
        private System.Windows.Forms.Label lblValCorreo;
        private System.Windows.Forms.Label lblCapNacimiento;
        private System.Windows.Forms.Label lblValNacimiento;
        private System.Windows.Forms.Label lblCapEstadoCivil;
        private System.Windows.Forms.Label lblValEstadoCivil;
        private System.Windows.Forms.Label lblCapReligion;
        private System.Windows.Forms.Label lblValReligion;
        private System.Windows.Forms.Label lblCapDireccion;
        private System.Windows.Forms.Label lblValDireccion;
        private System.Windows.Forms.Label lblCapCargo;
        private System.Windows.Forms.Label lblValCargo;
        private System.Windows.Forms.Label lblCapEstado;
        private System.Windows.Forms.Label lblValEstado;
        private System.Windows.Forms.Label lblCapContratacion;
        private System.Windows.Forms.Label lblValContratacion;
        private System.Windows.Forms.Label lblCapAntiguedad;
        private System.Windows.Forms.Label lblValAntiguedad;
        private System.Windows.Forms.Label lblCapSalarioBase;
        private System.Windows.Forms.Label lblValSalarioBase;
        private System.Windows.Forms.Label lblCapDescuento;
        private System.Windows.Forms.Label lblValDescuento;
        private System.Windows.Forms.Label lblCapBono;
        private System.Windows.Forms.Label lblValBono;
        private System.Windows.Forms.Label lblCapSalarioNeto;
        private System.Windows.Forms.Label lblValSalarioNeto;
        private System.Windows.Forms.Label lblCapEstadoPago;
        private System.Windows.Forms.Label lblValEstadoPago;
        private System.Windows.Forms.Label lblCapPlanilla;
        private System.Windows.Forms.Label lblValPlanilla;
        private System.Windows.Forms.Panel pnlPie;
        private Vistass.BotonTema btnEditar;
        private Vistass.BotonTema btnCerrar;
        private System.Windows.Forms.TabPage tabAsignaciones;
        private Vistass.GridOscuro dgvAsignaciones;
        private System.Windows.Forms.Panel pnlCarga;
        private System.Windows.Forms.Label lblCarga;
        private System.Windows.Forms.ProgressBar pbCarga;
        private System.Windows.Forms.Label lblAnio;
        private Vistass.ComboOscuro cmbAnio;
        private System.Windows.Forms.Panel pnlAcciones;
        private Vistass.BotonTema btnAsignar;
        private Vistass.BotonTema btnQuitarAsig;
        private System.Windows.Forms.Label lblCapDui;
        private System.Windows.Forms.Label lblValDui;
        private System.Windows.Forms.Label lblCapEmergencia;
        private System.Windows.Forms.Label lblValEmergencia;
        private System.Windows.Forms.Label lblCapEspecialidad;
        private System.Windows.Forms.Label lblValEspecialidad;
        private System.Windows.Forms.Label lblCapMaterias;
        private System.Windows.Forms.Label lblValMaterias;
        private Vistass.BotonTema btnFicha;
    }
}