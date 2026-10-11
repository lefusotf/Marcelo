namespace Vistass
{
    partial class frmEmpleadosEstructura
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
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblTituloForm = new System.Windows.Forms.Label();
            this.lblSubtituloForm = new System.Windows.Forms.Label();
            this.pnlTabla = new System.Windows.Forms.Panel();
            this.dgvEmpleados = new Vistass.GridOscuro();
            this.pnlPie = new System.Windows.Forms.Panel();
            this.lblResumen = new System.Windows.Forms.Label();
            this.btnCerrar = new Vistass.BotonTema();
            this.pnlEncabezado.SuspendLayout();
            this.pnlTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).BeginInit();
            this.pnlPie.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.pnlEncabezado.Controls.Add(this.lblTituloForm);
            this.pnlEncabezado.Controls.Add(this.lblSubtituloForm);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Location = new System.Drawing.Point(0, 0);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(760, 76);
            this.pnlEncabezado.TabIndex = 2;
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
            this.lblTituloForm.Text = "Empleados asignados";
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
            this.lblSubtituloForm.Text = "Base 0.00";
            // 
            // pnlTabla
            // 
            this.pnlTabla.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.pnlTabla.Controls.Add(this.dgvEmpleados);
            this.pnlTabla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTabla.Location = new System.Drawing.Point(0, 76);
            this.pnlTabla.Name = "pnlTabla";
            this.pnlTabla.Padding = new System.Windows.Forms.Padding(24, 8, 24, 16);
            this.pnlTabla.Size = new System.Drawing.Size(760, 362);
            this.pnlTabla.TabIndex = 0;
            // 
            // dgvEmpleados
            // 
            this.dgvEmpleados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmpleados.Location = new System.Drawing.Point(24, 8);
            this.dgvEmpleados.Name = "dgvEmpleados";
            this.dgvEmpleados.RowHeadersWidth = 51;
            this.dgvEmpleados.Size = new System.Drawing.Size(712, 338);
            this.dgvEmpleados.TabIndex = 0;
            this.dgvEmpleados.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvEmpleados_CellFormatting);
            // 
            // pnlPie
            // 
            this.pnlPie.BackColor = System.Drawing.Color.FromArgb(27, 29, 38);
            this.pnlPie.Controls.Add(this.lblResumen);
            this.pnlPie.Controls.Add(this.btnCerrar);
            this.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPie.Location = new System.Drawing.Point(0, 438);
            this.pnlPie.Name = "pnlPie";
            this.pnlPie.Size = new System.Drawing.Size(760, 62);
            this.pnlPie.TabIndex = 1;
            // 
            // lblResumen
            // 
            this.lblResumen.AutoSize = true;
            this.lblResumen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblResumen.ForeColor = System.Drawing.Color.FromArgb(170, 180, 200);
            this.lblResumen.Location = new System.Drawing.Point(26, 21);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Size = new System.Drawing.Size(120, 19);
            this.lblResumen.TabIndex = 0;
            this.lblResumen.Text = "0 empleados";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.Location = new System.Drawing.Point(636, 13);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 36);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Tipo = Vistass.TipoBoton.Secundario;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // frmEmpleadosEstructura
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(760, 500);
            this.Controls.Add(this.pnlTabla);
            this.Controls.Add(this.pnlPie);
            this.Controls.Add(this.pnlEncabezado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEmpleadosEstructura";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Empleados de la estructura";
            this.Load += new System.EventHandler(this.frmEmpleadosEstructura_Load);
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.pnlTabla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).EndInit();
            this.pnlPie.ResumeLayout(false);
            this.pnlPie.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label lblTituloForm;
        private System.Windows.Forms.Label lblSubtituloForm;
        private System.Windows.Forms.Panel pnlTabla;
        private Vistass.GridOscuro dgvEmpleados;
        private System.Windows.Forms.Panel pnlPie;
        private System.Windows.Forms.Label lblResumen;
        private Vistass.BotonTema btnCerrar;
    }
}