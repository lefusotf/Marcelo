namespace Vistass
{
    partial class frmAsignarGrupo
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDocente = new System.Windows.Forms.Label();
            this.lblGrado = new System.Windows.Forms.Label();
            this.cmbGrado = new Vistass.ComboOscuro();
            this.lblSeccion = new System.Windows.Forms.Label();
            this.cmbSeccion = new Vistass.ComboOscuro();
            this.lblHoras = new System.Windows.Forms.Label();
            this.lblDisponibles = new System.Windows.Forms.Label();
            this.btnGuardar = new Vistass.BotonTema();
            this.btnCancelar = new Vistass.BotonTema();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.button1 = new Vistass.BotonTema();
            this.numHoras = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHoras)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(24, 18);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(118, 23);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Asignar grupo";
            // 
            // lblDocente
            // 
            this.lblDocente.AutoEllipsis = true;
            this.lblDocente.AutoSize = false;
            this.lblDocente.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblDocente.Location = new System.Drawing.Point(26, 52);
            this.lblDocente.Name = "lblDocente";
            this.lblDocente.Size = new System.Drawing.Size(390, 23);
            this.lblDocente.TabIndex = 1;
            this.lblDocente.Text = "Docente";
            // 
            // lblGrado
            // 
            this.lblGrado.AutoSize = true;
            this.lblGrado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblGrado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblGrado.Location = new System.Drawing.Point(26, 94);
            this.lblGrado.Name = "lblGrado";
            this.lblGrado.Size = new System.Drawing.Size(64, 21);
            this.lblGrado.TabIndex = 2;
            this.lblGrado.Text = "Grado *";
            // 
            // cmbGrado
            // 
            this.cmbGrado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrado.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGrado.FormattingEnabled = true;
            this.cmbGrado.Location = new System.Drawing.Point(24, 118);
            this.cmbGrado.Name = "cmbGrado";
            this.cmbGrado.Size = new System.Drawing.Size(392, 31);
            this.cmbGrado.TabIndex = 0;
            this.cmbGrado.SelectedIndexChanged += new System.EventHandler(this.cmbGrado_SelectedIndexChanged);
            // 
            // lblSeccion
            // 
            this.lblSeccion.AutoSize = true;
            this.lblSeccion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSeccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblSeccion.Location = new System.Drawing.Point(26, 164);
            this.lblSeccion.Name = "lblSeccion";
            this.lblSeccion.Size = new System.Drawing.Size(74, 21);
            this.lblSeccion.TabIndex = 3;
            this.lblSeccion.Text = "Sección *";
            // 
            // cmbSeccion
            // 
            this.cmbSeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSeccion.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSeccion.FormattingEnabled = true;
            this.cmbSeccion.Location = new System.Drawing.Point(24, 188);
            this.cmbSeccion.Name = "cmbSeccion";
            this.cmbSeccion.Size = new System.Drawing.Size(392, 31);
            this.cmbSeccion.TabIndex = 1;
            // 
            // lblHoras
            // 
            this.lblHoras.AutoSize = true;
            this.lblHoras.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblHoras.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblHoras.Location = new System.Drawing.Point(26, 234);
            this.lblHoras.Name = "lblHoras";
            this.lblHoras.Size = new System.Drawing.Size(139, 21);
            this.lblHoras.TabIndex = 4;
            this.lblHoras.Text = "Horas semanales *";
            // 
            // lblDisponibles
            // 
            this.lblDisponibles.AutoSize = true;
            this.lblDisponibles.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisponibles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(204)))), ((int)(((byte)(21)))));
            this.lblDisponibles.Location = new System.Drawing.Point(160, 262);
            this.lblDisponibles.Name = "lblDisponibles";
            this.lblDisponibles.Size = new System.Drawing.Size(97, 23);
            this.lblDisponibles.TabIndex = 5;
            this.lblDisponibles.Text = "Disponibles";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(206, 336);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 36);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Asignar";
            this.btnGuardar.Tipo = Vistass.TipoBoton.Principal;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(316, 336);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 36);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Tipo = Vistass.TipoBoton.Secundario;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(316, 336);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 36);
            this.button1.TabIndex = 4;
            this.button1.Text = "Cancelar";
            this.button1.Tipo = Vistass.TipoBoton.Secundario;
            this.button1.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // numHoras
            // 
            this.numHoras.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.numHoras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numHoras.ForeColor = System.Drawing.Color.FromArgb(240, 244, 252);
            this.numHoras.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numHoras.Location = new System.Drawing.Point(24, 258);
            this.numHoras.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numHoras.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHoras.Name = "numHoras";
            this.numHoras.Size = new System.Drawing.Size(120, 30);
            this.numHoras.TabIndex = 2;
            this.numHoras.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // frmAsignarGrupo
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(440, 392);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblDocente);
            this.Controls.Add(this.lblGrado);
            this.Controls.Add(this.cmbGrado);
            this.Controls.Add(this.lblSeccion);
            this.Controls.Add(this.cmbSeccion);
            this.Controls.Add(this.lblHoras);
            this.Controls.Add(this.numHoras);
            this.Controls.Add(this.lblDisponibles);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAsignarGrupo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Asignar grupo";
            this.Load += new System.EventHandler(this.frmAsignarGrupo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHoras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDocente;
        private System.Windows.Forms.Label lblGrado;
        private Vistass.ComboOscuro cmbGrado;
        private System.Windows.Forms.Label lblSeccion;
        private Vistass.ComboOscuro cmbSeccion;
        private System.Windows.Forms.Label lblHoras;
        private System.Windows.Forms.Label lblDisponibles;
        private Vistass.BotonTema btnGuardar;
        private Vistass.BotonTema btnCancelar;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.NumericUpDown numHoras;
        private Vistass.BotonTema button1;
    }
}