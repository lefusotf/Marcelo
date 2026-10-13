namespace Vistass
{
    partial class frmAltaUnidades
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
            this.lblSecAlta = new System.Windows.Forms.Label();
            this.lblEquipo = new System.Windows.Forms.Label();
            this.cmbEquipo = new Vistass.ComboOscuro();
            this.lblInfoEquipo = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new Vistass.ComboOscuro();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblDestino = new System.Windows.Forms.Label();
            this.pnlPie = new System.Windows.Forms.Panel();
            this.lblObligatorios = new System.Windows.Forms.Label();
            this.btnGuardar = new Vistass.BotonTema();
            this.btnVolver = new Vistass.BotonTema();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            this.pnlPie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTituloForm
            // 
            this.lblTituloForm.AutoSize = true;
            this.lblTituloForm.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloForm.ForeColor = System.Drawing.Color.White;
            this.lblTituloForm.Location = new System.Drawing.Point(24, 14);
            this.lblTituloForm.Name = "lblTituloForm";
            this.lblTituloForm.Size = new System.Drawing.Size(122, 23);
            this.lblTituloForm.TabIndex = 0;
            this.lblTituloForm.Text = "Alta de equipo";
            // 
            // lblSubtituloForm
            // 
            this.lblSubtituloForm.AutoSize = true;
            this.lblSubtituloForm.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtituloForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblSubtituloForm.Location = new System.Drawing.Point(26, 46);
            this.lblSubtituloForm.Name = "lblSubtituloForm";
            this.lblSubtituloForm.Size = new System.Drawing.Size(362, 23);
            this.lblSubtituloForm.TabIndex = 1;
            this.lblSubtituloForm.Text = "Registre equipo nuevo que entra al inventario";
            // 
            // pnlDatos
            // 
            this.pnlDatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.pnlDatos.Controls.Add(this.lblSecAlta);
            this.pnlDatos.Controls.Add(this.lblEquipo);
            this.pnlDatos.Controls.Add(this.cmbEquipo);
            this.pnlDatos.Controls.Add(this.lblInfoEquipo);
            this.pnlDatos.Controls.Add(this.lblCantidad);
            this.pnlDatos.Controls.Add(this.nudCantidad);
            this.pnlDatos.Controls.Add(this.lblEstado);
            this.pnlDatos.Controls.Add(this.cmbEstado);
            this.pnlDatos.Controls.Add(this.lblCodigo);
            this.pnlDatos.Controls.Add(this.txtCodigo);
            this.pnlDatos.Controls.Add(this.lblDestino);
            this.pnlDatos.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlDatos.Location = new System.Drawing.Point(24, 80);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(452, 322);
            this.pnlDatos.TabIndex = 2;
            // 
            // lblSecAlta
            // 
            this.lblSecAlta.AutoSize = true;
            this.lblSecAlta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSecAlta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(204)))), ((int)(((byte)(21)))));
            this.lblSecAlta.Location = new System.Drawing.Point(24, 16);
            this.lblSecAlta.Name = "lblSecAlta";
            this.lblSecAlta.Size = new System.Drawing.Size(145, 23);
            this.lblSecAlta.TabIndex = 0;
            this.lblSecAlta.Text = "ALTA DE EQUIPO";
            // 
            // lblEquipo
            // 
            this.lblEquipo.AutoSize = true;
            this.lblEquipo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblEquipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblEquipo.Location = new System.Drawing.Point(24, 52);
            this.lblEquipo.Name = "lblEquipo";
            this.lblEquipo.Size = new System.Drawing.Size(69, 21);
            this.lblEquipo.TabIndex = 1;
            this.lblEquipo.Text = "Equipo *";
            // 
            // cmbEquipo
            // 
            this.cmbEquipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEquipo.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbEquipo.FormattingEnabled = true;
            this.cmbEquipo.Location = new System.Drawing.Point(24, 76);
            this.cmbEquipo.Name = "cmbEquipo";
            this.cmbEquipo.Size = new System.Drawing.Size(404, 33);
            this.cmbEquipo.TabIndex = 0;
            this.cmbEquipo.SelectedIndexChanged += new System.EventHandler(this.cmbEquipo_SelectedIndexChanged);
            // 
            // lblInfoEquipo
            // 
            this.lblInfoEquipo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblInfoEquipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblInfoEquipo.Location = new System.Drawing.Point(24, 108);
            this.lblInfoEquipo.Name = "lblInfoEquipo";
            this.lblInfoEquipo.Size = new System.Drawing.Size(404, 34);
            this.lblInfoEquipo.TabIndex = 3;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCantidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblCantidad.Location = new System.Drawing.Point(24, 152);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(83, 21);
            this.lblCantidad.TabIndex = 4;
            this.lblCantidad.Text = "Cantidad *";
            // 
            // nudCantidad
            // 
            this.nudCantidad.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.nudCantidad.Location = new System.Drawing.Point(24, 176);
            this.nudCantidad.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidad.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.nudCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudCantidad.ForeColor = System.Drawing.Color.FromArgb(240, 244, 252);
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(120, 32);
            this.nudCantidad.TabIndex = 1;
            this.nudCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidad.ValueChanged += new System.EventHandler(this.nudCantidad_ValueChanged);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblEstado.Location = new System.Drawing.Point(164, 152);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(111, 21);
            this.lblEstado.TabIndex = 6;
            this.lblEstado.Text = "Estado inicial *";
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(164, 176);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(264, 31);
            this.cmbEstado.TabIndex = 2;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblCodigo.Location = new System.Drawing.Point(24, 212);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(296, 21);
            this.lblCodigo.TabIndex = 8;
            this.lblCodigo.Text = "Código de inventario (puede cambiarlo) *";
            this.lblCodigo.Visible = false;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(24, 236);
            this.txtCodigo.MaxLength = 50;
            this.txtCodigo.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.ForeColor = System.Drawing.Color.FromArgb(240, 244, 252);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(404, 30);
            this.txtCodigo.TabIndex = 3;
            this.txtCodigo.Visible = false;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // lblDestino
            // 
            this.lblDestino.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblDestino.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblDestino.Location = new System.Drawing.Point(24, 276);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(404, 34);
            this.lblDestino.TabIndex = 10;
            // 
            // pnlPie
            // 
            this.pnlPie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.pnlPie.Controls.Add(this.lblObligatorios);
            this.pnlPie.Controls.Add(this.btnGuardar);
            this.pnlPie.Controls.Add(this.btnVolver);
            this.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPie.Location = new System.Drawing.Point(0, 416);
            this.pnlPie.Name = "pnlPie";
            this.pnlPie.Size = new System.Drawing.Size(500, 62);
            this.pnlPie.TabIndex = 3;
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
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(206, 13);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(160, 36);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Registrar unidades";
            this.btnGuardar.Tipo = Vistass.TipoBoton.Principal;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVolver.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnVolver.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(376, 13);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(100, 34);
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
            // frmAltaUnidades
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.CancelButton = this.btnVolver;
            this.ClientSize = new System.Drawing.Size(500, 478);
            this.Controls.Add(this.lblTituloForm);
            this.Controls.Add(this.lblSubtituloForm);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.pnlPie);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAltaUnidades";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alta de equipo";
            this.Load += new System.EventHandler(this.frmAltaUnidades_Load);
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
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
        private System.Windows.Forms.Label lblSecAlta;
        private System.Windows.Forms.Label lblEquipo;
        private Vistass.ComboOscuro cmbEquipo;
        private System.Windows.Forms.Label lblInfoEquipo;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Label lblEstado;
        private Vistass.ComboOscuro cmbEstado;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblDestino;
        private System.Windows.Forms.Panel pnlPie;
        private System.Windows.Forms.Label lblObligatorios;
        private Vistass.BotonTema btnGuardar;
        private Vistass.BotonTema btnVolver;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}