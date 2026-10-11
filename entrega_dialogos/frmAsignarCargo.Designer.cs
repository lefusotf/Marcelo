namespace Vistass
{
    partial class frmAsignarCargo
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
            this.lblCargoCrear = new System.Windows.Forms.Label();
            this.txtNombreCargo = new System.Windows.Forms.TextBox();
            this.btnGuardarCargo = new Vistass.BotonTema();
            this.btnCancelar = new Vistass.BotonTema();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(18, 18);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(109, 23);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Nuevo cargo";
            // 
            // lblCargoCrear
            // 
            this.lblCargoCrear.AutoSize = true;
            this.lblCargoCrear.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargoCrear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblCargoCrear.Location = new System.Drawing.Point(20, 64);
            this.lblCargoCrear.Name = "lblCargoCrear";
            this.lblCargoCrear.Size = new System.Drawing.Size(149, 23);
            this.lblCargoCrear.TabIndex = 1;
            this.lblCargoCrear.Text = "Nombre del cargo";
            // 
            // txtNombreCargo
            // 
            this.txtNombreCargo.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreCargo.Location = new System.Drawing.Point(18, 90);
            this.txtNombreCargo.MaxLength = 100;
            this.txtNombreCargo.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.txtNombreCargo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreCargo.ForeColor = System.Drawing.Color.FromArgb(240, 244, 252);
            this.txtNombreCargo.Name = "txtNombreCargo";
            this.txtNombreCargo.Size = new System.Drawing.Size(392, 30);
            this.txtNombreCargo.TabIndex = 0;
            this.txtNombreCargo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreCargo_KeyPress);
            // 
            // btnGuardarCargo
            // 
            this.btnGuardarCargo.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarCargo.Location = new System.Drawing.Point(200, 160);
            this.btnGuardarCargo.Name = "btnGuardarCargo";
            this.btnGuardarCargo.Size = new System.Drawing.Size(100, 36);
            this.btnGuardarCargo.TabIndex = 1;
            this.btnGuardarCargo.Text = "Guardar";
            this.btnGuardarCargo.Tipo = Vistass.TipoBoton.Principal;
            this.btnGuardarCargo.Click += new System.EventHandler(this.btnGuardarCargo_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(316, 160);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 36);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Tipo = Vistass.TipoBoton.Secundario;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_1);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmAsignarCargo
            // 
            this.AcceptButton = this.btnGuardarCargo;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(440, 220);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblCargoCrear);
            this.Controls.Add(this.txtNombreCargo);
            this.Controls.Add(this.btnGuardarCargo);
            this.Controls.Add(this.btnCancelar);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAsignarCargo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nuevo cargo";
            this.Load += new System.EventHandler(this.frmAsignarCargo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblCargoCrear;
        private System.Windows.Forms.TextBox txtNombreCargo;
        private Vistass.BotonTema btnGuardarCargo;
        private Vistass.BotonTema btnCancelar;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}