namespace Vistass
{
    partial class frmSalon
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
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.lblSecDatos = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipo = new Vistass.ComboOscuro();
            this.lblCapacidad = new System.Windows.Forms.Label();
            this.nudCapacidad = new System.Windows.Forms.NumericUpDown();
            this.lblEdificio = new System.Windows.Forms.Label();
            this.txtEdificio = new System.Windows.Forms.TextBox();
            this.lblResponsable = new System.Windows.Forms.Label();
            this.cmbResponsable = new Vistass.ComboOscuro();
            this.lblObservacion = new System.Windows.Forms.Label();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.pnlPie = new System.Windows.Forms.Panel();
            this.lblObligatorios = new System.Windows.Forms.Label();
            this.btnGuardar = new Vistass.BotonTema();
            this.btnVolver = new Vistass.BotonTema();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapacidad)).BeginInit();
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
            this.lblTituloForm.Size = new System.Drawing.Size(200, 30);
            this.lblTituloForm.TabIndex = 0;
            this.lblTituloForm.Text = "Nuevo salón";
            // 
            // lblSubtituloForm
            // 
            this.lblSubtituloForm.AutoSize = true;
            this.lblSubtituloForm.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtituloForm.ForeColor = System.Drawing.Color.FromArgb(170, 180, 200);
            this.lblSubtituloForm.Location = new System.Drawing.Point(26, 46);
            this.lblSubtituloForm.Name = "lblSubtituloForm";
            this.lblSubtituloForm.Size = new System.Drawing.Size(300, 19);
            this.lblSubtituloForm.TabIndex = 1;
            this.lblSubtituloForm.Text = "Complete los datos del espacio";
            // 
            // pnlDatos
            // 
            this.pnlDatos.BackColor = System.Drawing.Color.FromArgb(27, 29, 38);
            this.pnlDatos.Controls.Add(this.lblSecDatos);
            this.pnlDatos.Controls.Add(this.lblNombre);
            this.pnlDatos.Controls.Add(this.txtNombre);
            this.pnlDatos.Controls.Add(this.lblTipo);
            this.pnlDatos.Controls.Add(this.cmbTipo);
            this.pnlDatos.Controls.Add(this.lblCapacidad);
            this.pnlDatos.Controls.Add(this.nudCapacidad);
            this.pnlDatos.Controls.Add(this.lblEdificio);
            this.pnlDatos.Controls.Add(this.txtEdificio);
            this.pnlDatos.Controls.Add(this.lblResponsable);
            this.pnlDatos.Controls.Add(this.cmbResponsable);
            this.pnlDatos.Controls.Add(this.lblObservacion);
            this.pnlDatos.Controls.Add(this.txtObservacion);
            this.pnlDatos.Location = new System.Drawing.Point(24, 80);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(472, 450);
            this.pnlDatos.TabIndex = 2;
            // 
            // lblSecDatos
            // 
            this.lblSecDatos.AutoSize = true;
            this.lblSecDatos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSecDatos.ForeColor = System.Drawing.Color.FromArgb(250, 204, 21);
            this.lblSecDatos.Location = new System.Drawing.Point(24, 16);
            this.lblSecDatos.Name = "lblSecDatos";
            this.lblSecDatos.Size = new System.Drawing.Size(130, 19);
            this.lblSecDatos.TabIndex = 0;
            this.lblSecDatos.Text = "DATOS DEL SALÓN";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(170, 180, 200);
            this.lblNombre.Location = new System.Drawing.Point(24, 52);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(100, 17);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre del salón *";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtNombre.Location = new System.Drawing.Point(24, 76);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.ForeColor = System.Drawing.Color.FromArgb(240, 244, 252);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(424, 27);
            this.txtNombre.TabIndex = 0;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTipo.ForeColor = System.Drawing.Color.FromArgb(170, 180, 200);
            this.lblTipo.Location = new System.Drawing.Point(24, 128);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(50, 17);
            this.lblTipo.TabIndex = 3;
            this.lblTipo.Text = "Tipo *";
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(24, 152);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(200, 28);
            this.cmbTipo.TabIndex = 1;
            // 
            // lblCapacidad
            // 
            this.lblCapacidad.AutoSize = true;
            this.lblCapacidad.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCapacidad.ForeColor = System.Drawing.Color.FromArgb(170, 180, 200);
            this.lblCapacidad.Location = new System.Drawing.Point(248, 128);
            this.lblCapacidad.Name = "lblCapacidad";
            this.lblCapacidad.Size = new System.Drawing.Size(180, 17);
            this.lblCapacidad.TabIndex = 5;
            this.lblCapacidad.Text = "Capacidad (0 = sin definir)";
            // 
            // nudCapacidad
            // 
            this.nudCapacidad.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.nudCapacidad.Location = new System.Drawing.Point(248, 152);
            this.nudCapacidad.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            this.nudCapacidad.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.nudCapacidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudCapacidad.ForeColor = System.Drawing.Color.FromArgb(240, 244, 252);
            this.nudCapacidad.Name = "nudCapacidad";
            this.nudCapacidad.Size = new System.Drawing.Size(200, 27);
            this.nudCapacidad.TabIndex = 2;
            // 
            // lblEdificio
            // 
            this.lblEdificio.AutoSize = true;
            this.lblEdificio.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblEdificio.ForeColor = System.Drawing.Color.FromArgb(170, 180, 200);
            this.lblEdificio.Location = new System.Drawing.Point(24, 204);
            this.lblEdificio.Name = "lblEdificio";
            this.lblEdificio.Size = new System.Drawing.Size(150, 17);
            this.lblEdificio.TabIndex = 7;
            this.lblEdificio.Text = "Edificio o ubicación";
            // 
            // txtEdificio
            // 
            this.txtEdificio.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtEdificio.Location = new System.Drawing.Point(24, 228);
            this.txtEdificio.MaxLength = 100;
            this.txtEdificio.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.txtEdificio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEdificio.ForeColor = System.Drawing.Color.FromArgb(240, 244, 252);
            this.txtEdificio.Name = "txtEdificio";
            this.txtEdificio.Size = new System.Drawing.Size(424, 27);
            this.txtEdificio.TabIndex = 3;
            // 
            // lblResponsable
            // 
            this.lblResponsable.AutoSize = true;
            this.lblResponsable.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblResponsable.ForeColor = System.Drawing.Color.FromArgb(170, 180, 200);
            this.lblResponsable.Location = new System.Drawing.Point(24, 280);
            this.lblResponsable.Name = "lblResponsable";
            this.lblResponsable.Size = new System.Drawing.Size(180, 17);
            this.lblResponsable.TabIndex = 9;
            this.lblResponsable.Text = "Responsable del salón";
            // 
            // cmbResponsable
            // 
            this.cmbResponsable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResponsable.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbResponsable.FormattingEnabled = true;
            this.cmbResponsable.Location = new System.Drawing.Point(24, 304);
            this.cmbResponsable.Name = "cmbResponsable";
            this.cmbResponsable.Size = new System.Drawing.Size(424, 28);
            this.cmbResponsable.TabIndex = 4;
            // 
            // lblObservacion
            // 
            this.lblObservacion.AutoSize = true;
            this.lblObservacion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblObservacion.ForeColor = System.Drawing.Color.FromArgb(170, 180, 200);
            this.lblObservacion.Location = new System.Drawing.Point(24, 356);
            this.lblObservacion.Name = "lblObservacion";
            this.lblObservacion.Size = new System.Drawing.Size(140, 17);
            this.lblObservacion.TabIndex = 11;
            this.lblObservacion.Text = "Observación (opcional)";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtObservacion.Location = new System.Drawing.Point(24, 380);
            this.txtObservacion.MaxLength = 300;
            this.txtObservacion.Multiline = true;
            this.txtObservacion.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.txtObservacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservacion.ForeColor = System.Drawing.Color.FromArgb(240, 244, 252);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacion.Size = new System.Drawing.Size(424, 52);
            this.txtObservacion.TabIndex = 5;
            // 
            // pnlPie
            // 
            this.pnlPie.BackColor = System.Drawing.Color.FromArgb(27, 29, 38);
            this.pnlPie.Controls.Add(this.lblObligatorios);
            this.pnlPie.Controls.Add(this.btnGuardar);
            this.pnlPie.Controls.Add(this.btnVolver);
            this.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPie.Location = new System.Drawing.Point(0, 546);
            this.pnlPie.Name = "pnlPie";
            this.pnlPie.Size = new System.Drawing.Size(520, 62);
            this.pnlPie.TabIndex = 3;
            // 
            // lblObligatorios
            // 
            this.lblObligatorios.AutoSize = true;
            this.lblObligatorios.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblObligatorios.ForeColor = System.Drawing.Color.FromArgb(170, 180, 200);
            this.lblObligatorios.Location = new System.Drawing.Point(26, 22);
            this.lblObligatorios.Name = "lblObligatorios";
            this.lblObligatorios.Size = new System.Drawing.Size(120, 17);
            this.lblObligatorios.TabIndex = 0;
            this.lblObligatorios.Text = "* Campo obligatorio";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.Location = new System.Drawing.Point(236, 13);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(150, 36);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar salón";
            this.btnGuardar.Tipo = Vistass.TipoBoton.Principal;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVolver.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnVolver.Location = new System.Drawing.Point(396, 13);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(100, 36);
            this.btnVolver.TabIndex = 2;
            this.btnVolver.Text = "Cancelar";
            this.btnVolver.Tipo = Vistass.TipoBoton.Secundario;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // frmSalon
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.CancelButton = this.btnVolver;
            this.ClientSize = new System.Drawing.Size(520, 608);
            this.Controls.Add(this.lblTituloForm);
            this.Controls.Add(this.lblSubtituloForm);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.pnlPie);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSalon";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Salón";
            this.Load += new System.EventHandler(this.frmSalon_Load);
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapacidad)).EndInit();
            this.pnlPie.ResumeLayout(false);
            this.pnlPie.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTituloForm;
        private System.Windows.Forms.Label lblSubtituloForm;
        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.Label lblSecDatos;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblTipo;
        private Vistass.ComboOscuro cmbTipo;
        private System.Windows.Forms.Label lblCapacidad;
        private System.Windows.Forms.NumericUpDown nudCapacidad;
        private System.Windows.Forms.Label lblEdificio;
        private System.Windows.Forms.TextBox txtEdificio;
        private System.Windows.Forms.Label lblResponsable;
        private Vistass.ComboOscuro cmbResponsable;
        private System.Windows.Forms.Label lblObservacion;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Panel pnlPie;
        private System.Windows.Forms.Label lblObligatorios;
        private Vistass.BotonTema btnGuardar;
        private Vistass.BotonTema btnVolver;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}