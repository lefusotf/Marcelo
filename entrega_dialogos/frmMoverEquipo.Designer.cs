namespace Vistass
{
    partial class frmMoverEquipo
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
            this.lblSecTraslado = new System.Windows.Forms.Label();
            this.lblQue = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblDestino = new System.Windows.Forms.Label();
            this.cmbDestino = new Vistass.ComboOscuro();
            this.pnlPie = new System.Windows.Forms.Panel();
            this.lblObligatorios = new System.Windows.Forms.Label();
            this.btnMover = new Vistass.BotonTema();
            this.btnVolver = new Vistass.BotonTema();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlDatos.SuspendLayout();
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
            this.lblTituloForm.Text = "Mover equipo";
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
            this.lblSubtituloForm.Text = "Desde:";
            // 
            // pnlDatos
            // 
            this.pnlDatos.BackColor = System.Drawing.Color.FromArgb(27, 29, 38);
            this.pnlDatos.Controls.Add(this.lblSecTraslado);
            this.pnlDatos.Controls.Add(this.lblQue);
            this.pnlDatos.Controls.Add(this.lblDescripcion);
            this.pnlDatos.Controls.Add(this.lblDestino);
            this.pnlDatos.Controls.Add(this.cmbDestino);
            this.pnlDatos.Location = new System.Drawing.Point(24, 80);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(432, 220);
            this.pnlDatos.TabIndex = 2;
            // 
            // lblSecTraslado
            // 
            this.lblSecTraslado.AutoSize = true;
            this.lblSecTraslado.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSecTraslado.ForeColor = System.Drawing.Color.FromArgb(250, 204, 21);
            this.lblSecTraslado.Location = new System.Drawing.Point(24, 16);
            this.lblSecTraslado.Name = "lblSecTraslado";
            this.lblSecTraslado.Size = new System.Drawing.Size(80, 19);
            this.lblSecTraslado.TabIndex = 0;
            this.lblSecTraslado.Text = "TRASLADO";
            // 
            // lblQue
            // 
            this.lblQue.AutoSize = true;
            this.lblQue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblQue.ForeColor = System.Drawing.Color.FromArgb(170, 180, 200);
            this.lblQue.Location = new System.Drawing.Point(24, 52);
            this.lblQue.Name = "lblQue";
            this.lblQue.Size = new System.Drawing.Size(120, 17);
            this.lblQue.TabIndex = 1;
            this.lblQue.Text = "Equipo a mover";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblDescripcion.ForeColor = System.Drawing.Color.White;
            this.lblDescripcion.Location = new System.Drawing.Point(24, 74);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(384, 62);
            this.lblDescripcion.TabIndex = 2;
            // 
            // lblDestino
            // 
            this.lblDestino.AutoSize = true;
            this.lblDestino.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDestino.ForeColor = System.Drawing.Color.FromArgb(170, 180, 200);
            this.lblDestino.Location = new System.Drawing.Point(24, 148);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(100, 17);
            this.lblDestino.TabIndex = 3;
            this.lblDestino.Text = "Salón destino *";
            // 
            // cmbDestino
            // 
            this.cmbDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDestino.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbDestino.FormattingEnabled = true;
            this.cmbDestino.Location = new System.Drawing.Point(24, 172);
            this.cmbDestino.Name = "cmbDestino";
            this.cmbDestino.Size = new System.Drawing.Size(384, 28);
            this.cmbDestino.TabIndex = 0;
            // 
            // pnlPie
            // 
            this.pnlPie.BackColor = System.Drawing.Color.FromArgb(27, 29, 38);
            this.pnlPie.Controls.Add(this.lblObligatorios);
            this.pnlPie.Controls.Add(this.btnMover);
            this.pnlPie.Controls.Add(this.btnVolver);
            this.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPie.Location = new System.Drawing.Point(0, 316);
            this.pnlPie.Name = "pnlPie";
            this.pnlPie.Size = new System.Drawing.Size(480, 62);
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
            // btnMover
            // 
            this.btnMover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMover.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnMover.Location = new System.Drawing.Point(206, 13);
            this.btnMover.Name = "btnMover";
            this.btnMover.Size = new System.Drawing.Size(140, 36);
            this.btnMover.TabIndex = 1;
            this.btnMover.Text = "Mover equipo";
            this.btnMover.Tipo = Vistass.TipoBoton.Secundario;
            this.btnMover.Click += new System.EventHandler(this.btnMover_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVolver.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnVolver.Location = new System.Drawing.Point(356, 13);
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
            // frmMoverEquipo
            // 
            this.AcceptButton = this.btnMover;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.CancelButton = this.btnVolver;
            this.ClientSize = new System.Drawing.Size(480, 378);
            this.Controls.Add(this.lblTituloForm);
            this.Controls.Add(this.lblSubtituloForm);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.pnlPie);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMoverEquipo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mover equipo";
            this.Load += new System.EventHandler(this.frmMoverEquipo_Load);
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
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
        private System.Windows.Forms.Label lblSecTraslado;
        private System.Windows.Forms.Label lblQue;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblDestino;
        private Vistass.ComboOscuro cmbDestino;
        private System.Windows.Forms.Panel pnlPie;
        private System.Windows.Forms.Label lblObligatorios;
        private Vistass.BotonTema btnMover;
        private Vistass.BotonTema btnVolver;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}