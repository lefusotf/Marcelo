namespace Vistass
{
    partial class frmAusencias
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
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblResultados = new System.Windows.Forms.Label();
            this.pnlBarra = new System.Windows.Forms.Panel();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.cmbTipo = new Vistass.ComboOscuro();
            this.cmbPeriodo = new Vistass.ComboOscuro();
            this.chkAnuladas = new System.Windows.Forms.CheckBox();
            this.btnRegistrar = new Vistass.BotonTema();
            this.btnAnular = new Vistass.BotonTema();
            this.btnExportar = new Vistass.BotonTema();
            this.pnlTabla = new System.Windows.Forms.Panel();
            this.dgvAusencias = new Vistass.GridOscuro();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlEncabezado.SuspendLayout();
            this.pnlBarra.SuspendLayout();
            this.pnlTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAusencias)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.pnlEncabezado.Controls.Add(this.lblTitulo);
            this.pnlEncabezado.Controls.Add(this.lblSubtitulo);
            this.pnlEncabezado.Controls.Add(this.lblResultados);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Location = new System.Drawing.Point(0, 0);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(1200, 84);
            this.pnlEncabezado.TabIndex = 2;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(24, 8);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(330, 46);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Ausencias y permisos";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(170, 180, 200);
            this.lblSubtitulo.Location = new System.Drawing.Point(27, 52);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(500, 23);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Las faltas injustificadas y los permisos sin goce se descuentan de la planilla";
            // 
            // lblResultados
            // 
            this.lblResultados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResultados.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblResultados.ForeColor = System.Drawing.Color.FromArgb(170, 180, 200);
            this.lblResultados.Location = new System.Drawing.Point(656, 52);
            this.lblResultados.Name = "lblResultados";
            this.lblResultados.Size = new System.Drawing.Size(520, 24);
            this.lblResultados.TabIndex = 2;
            this.lblResultados.Text = "0 ausencias";
            this.lblResultados.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlBarra
            // 
            this.pnlBarra.BackColor = System.Drawing.Color.FromArgb(27, 29, 38);
            this.pnlBarra.Controls.Add(this.txtBuscar);
            this.pnlBarra.Controls.Add(this.cmbTipo);
            this.pnlBarra.Controls.Add(this.cmbPeriodo);
            this.pnlBarra.Controls.Add(this.chkAnuladas);
            this.pnlBarra.Controls.Add(this.btnRegistrar);
            this.pnlBarra.Controls.Add(this.btnAnular);
            this.pnlBarra.Controls.Add(this.btnExportar);
            this.pnlBarra.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarra.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.pnlBarra.Location = new System.Drawing.Point(0, 84);
            this.pnlBarra.Name = "pnlBarra";
            this.pnlBarra.Size = new System.Drawing.Size(1200, 116);
            this.pnlBarra.TabIndex = 1;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.txtBuscar.Location = new System.Drawing.Point(24, 19);
            this.txtBuscar.MaxLength = 100;
            this.txtBuscar.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.ForeColor = System.Drawing.Color.FromArgb(240, 244, 252);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(320, 30);
            this.txtBuscar.TabIndex = 0;
            this.txtBuscar.TextChanged += new System.EventHandler(this.Filtro_Changed);
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(360, 19);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(180, 31);
            this.cmbTipo.TabIndex = 1;
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.Filtro_Changed);
            // 
            // cmbPeriodo
            // 
            this.cmbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriodo.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.cmbPeriodo.FormattingEnabled = true;
            this.cmbPeriodo.Location = new System.Drawing.Point(556, 19);
            this.cmbPeriodo.Name = "cmbPeriodo";
            this.cmbPeriodo.Size = new System.Drawing.Size(200, 31);
            this.cmbPeriodo.TabIndex = 2;
            this.cmbPeriodo.SelectedIndexChanged += new System.EventHandler(this.Filtro_Changed);
            // 
            // chkAnuladas
            // 
            this.chkAnuladas.AutoSize = true;
            this.chkAnuladas.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkAnuladas.ForeColor = System.Drawing.Color.FromArgb(170, 180, 200);
            this.chkAnuladas.Location = new System.Drawing.Point(776, 23);
            this.chkAnuladas.Name = "chkAnuladas";
            this.chkAnuladas.Size = new System.Drawing.Size(160, 25);
            this.chkAnuladas.TabIndex = 3;
            this.chkAnuladas.Text = "Mostrar anuladas";
            this.chkAnuladas.UseVisualStyleBackColor = true;
            this.chkAnuladas.CheckedChanged += new System.EventHandler(this.Filtro_Changed);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnRegistrar.Location = new System.Drawing.Point(24, 66);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(200, 36);
            this.btnRegistrar.TabIndex = 4;
            this.btnRegistrar.Text = "+ Registrar ausencia";
            this.btnRegistrar.Tipo = Vistass.TipoBoton.Principal;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnAnular
            // 
            this.btnAnular.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAnular.Location = new System.Drawing.Point(240, 66);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(120, 36);
            this.btnAnular.TabIndex = 5;
            this.btnAnular.Text = "Anular";
            this.btnAnular.Tipo = Vistass.TipoBoton.Peligro;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnExportar.Location = new System.Drawing.Point(376, 66);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(130, 36);
            this.btnExportar.TabIndex = 6;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.Tipo = Vistass.TipoBoton.Secundario;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // pnlTabla
            // 
            this.pnlTabla.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.pnlTabla.Controls.Add(this.dgvAusencias);
            this.pnlTabla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTabla.Location = new System.Drawing.Point(0, 200);
            this.pnlTabla.Name = "pnlTabla";
            this.pnlTabla.Padding = new System.Windows.Forms.Padding(24, 16, 24, 24);
            this.pnlTabla.Size = new System.Drawing.Size(1200, 500);
            this.pnlTabla.TabIndex = 0;
            // 
            // dgvAusencias
            // 
            this.dgvAusencias.ColumnHeadersHeight = 29;
            this.dgvAusencias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAusencias.Location = new System.Drawing.Point(24, 16);
            this.dgvAusencias.Name = "dgvAusencias";
            this.dgvAusencias.RowHeadersWidth = 51;
            this.dgvAusencias.Size = new System.Drawing.Size(1152, 460);
            this.dgvAusencias.TabIndex = 0;
            this.dgvAusencias.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvAusencias_CellFormatting);
            this.dgvAusencias.SelectionChanged += new System.EventHandler(this.dgvAusencias_SelectionChanged);
            // 
            // frmAusencias
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.pnlTabla);
            this.Controls.Add(this.pnlBarra);
            this.Controls.Add(this.pnlEncabezado);
            this.MinimumSize = new System.Drawing.Size(980, 560);
            this.Name = "frmAusencias";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ausencias y permisos";
            this.Load += new System.EventHandler(this.frmAusencias_Load);
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.pnlBarra.ResumeLayout(false);
            this.pnlBarra.PerformLayout();
            this.pnlTabla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAusencias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblResultados;
        private System.Windows.Forms.Panel pnlBarra;
        private System.Windows.Forms.TextBox txtBuscar;
        private Vistass.ComboOscuro cmbTipo;
        private Vistass.ComboOscuro cmbPeriodo;
        private System.Windows.Forms.CheckBox chkAnuladas;
        private Vistass.BotonTema btnRegistrar;
        private Vistass.BotonTema btnAnular;
        private Vistass.BotonTema btnExportar;
        private System.Windows.Forms.Panel pnlTabla;
        private Vistass.GridOscuro dgvAusencias;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}