namespace Vistass
{
    partial class frmHistorialActivo
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
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblResumen = new System.Windows.Forms.Label();
            this.tabHist = new System.Windows.Forms.TabControl();
            this.tabHistorial = new System.Windows.Forms.TabPage();
            this.dgvHistorial = new Vistass.GridOscuro();
            this.tabDanos = new System.Windows.Forms.TabPage();
            this.dgvDanos = new Vistass.GridOscuro();
            this.pnlPie = new System.Windows.Forms.Panel();
            this.btnCerrar = new Vistass.BotonTema();
            this.pnlTitulo.SuspendLayout();
            this.tabHist.SuspendLayout();
            this.tabHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.tabDanos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanos)).BeginInit();
            this.pnlPie.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.BackColor = System.Drawing.Color.FromArgb(27, 29, 38);
            this.pnlTitulo.Controls.Add(this.lblTitulo);
            this.pnlTitulo.Controls.Add(this.lblResumen);
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(1000, 74);
            this.pnlTitulo.TabIndex = 2;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(16, 8);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(150, 28);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Historial del activo";
            // 
            // lblResumen
            // 
            this.lblResumen.AutoSize = true;
            this.lblResumen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblResumen.ForeColor = System.Drawing.Color.FromArgb(170, 180, 200);
            this.lblResumen.Location = new System.Drawing.Point(18, 44);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Size = new System.Drawing.Size(60, 19);
            this.lblResumen.TabIndex = 1;
            this.lblResumen.Text = "Resumen";
            // 
            // tabHist
            // 
            this.tabHist.Controls.Add(this.tabHistorial);
            this.tabHist.Controls.Add(this.tabDanos);
            this.tabHist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabHist.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabHist.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.tabHist.ItemSize = new System.Drawing.Size(210, 34);
            this.tabHist.Location = new System.Drawing.Point(0, 74);
            this.tabHist.Name = "tabHist";
            this.tabHist.SelectedIndex = 0;
            this.tabHist.Size = new System.Drawing.Size(1000, 506);
            this.tabHist.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabHist.TabIndex = 0;
            this.tabHist.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabHist_DrawItem);
            // 
            // tabHistorial
            // 
            this.tabHistorial.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.tabHistorial.Controls.Add(this.dgvHistorial);
            this.tabHistorial.Location = new System.Drawing.Point(4, 38);
            this.tabHistorial.Name = "tabHistorial";
            this.tabHistorial.Size = new System.Drawing.Size(992, 464);
            this.tabHistorial.TabIndex = 0;
            this.tabHistorial.Text = "Historial de cambios";
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistorial.Location = new System.Drawing.Point(0, 0);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.RowHeadersWidth = 51;
            this.dgvHistorial.Size = new System.Drawing.Size(992, 464);
            this.dgvHistorial.TabIndex = 0;
            // 
            // tabDanos
            // 
            this.tabDanos.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.tabDanos.Controls.Add(this.dgvDanos);
            this.tabDanos.Location = new System.Drawing.Point(4, 38);
            this.tabDanos.Name = "tabDanos";
            this.tabDanos.Size = new System.Drawing.Size(992, 464);
            this.tabDanos.TabIndex = 1;
            this.tabDanos.Text = "Reportes de daño";
            // 
            // dgvDanos
            // 
            this.dgvDanos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDanos.Location = new System.Drawing.Point(0, 0);
            this.dgvDanos.Name = "dgvDanos";
            this.dgvDanos.RowHeadersWidth = 51;
            this.dgvDanos.Size = new System.Drawing.Size(992, 464);
            this.dgvDanos.TabIndex = 0;
            this.dgvDanos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDanos_CellFormatting);
            // 
            // pnlPie
            // 
            this.pnlPie.BackColor = System.Drawing.Color.FromArgb(27, 29, 38);
            this.pnlPie.Controls.Add(this.btnCerrar);
            this.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPie.Location = new System.Drawing.Point(0, 580);
            this.pnlPie.Name = "pnlPie";
            this.pnlPie.Size = new System.Drawing.Size(1000, 50);
            this.pnlPie.TabIndex = 1;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCerrar.Location = new System.Drawing.Point(874, 10);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(110, 30);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Tipo = Vistass.TipoBoton.Secundario;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // frmHistorialActivo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.ClientSize = new System.Drawing.Size(1000, 630);
            this.Controls.Add(this.tabHist);
            this.Controls.Add(this.pnlPie);
            this.Controls.Add(this.pnlTitulo);
            this.MinimumSize = new System.Drawing.Size(900, 520);
            this.Name = "frmHistorialActivo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Historial del activo";
            this.Load += new System.EventHandler(this.frmHistorialActivo_Load);
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.tabHist.ResumeLayout(false);
            this.tabHistorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.tabDanos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanos)).EndInit();
            this.pnlPie.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblResumen;
        private System.Windows.Forms.TabControl tabHist;
        private System.Windows.Forms.TabPage tabHistorial;
        private Vistass.GridOscuro dgvHistorial;
        private System.Windows.Forms.TabPage tabDanos;
        private Vistass.GridOscuro dgvDanos;
        private System.Windows.Forms.Panel pnlPie;
        private Vistass.BotonTema btnCerrar;
    }
}