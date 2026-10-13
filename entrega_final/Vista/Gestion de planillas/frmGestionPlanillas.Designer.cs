namespace Vistass
{
    partial class frmGestionPlanillas
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
            this.lblTituloPlanillas = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.pnlResumen = new System.Windows.Forms.Panel();
            this.flpResumen = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlBarra = new Vistass.PanelTarjeta();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.pnlBuscador = new System.Windows.Forms.Panel();
            this.lblBuscarHint = new System.Windows.Forms.Label();
            this.pnlLupa = new System.Windows.Forms.Panel();
            this.cmbPeriodo = new Vistass.ComboOscuro();
            this.cmbEstadoPago = new Vistass.ComboOscuro();
            this.lblEstadoPeriodo = new System.Windows.Forms.Label();
            this.btnNuevoPago = new Vistass.BotonTema();
            this.btnGenerarPlanilla = new Vistass.BotonTema();
            this.btnEditarPago = new Vistass.BotonTema();
            this.btnMarcarPagado = new Vistass.BotonTema();
            this.btnAnularPago = new Vistass.BotonTema();
            this.btnBoleta = new Vistass.BotonTema();
            this.btnExportarPdf = new Vistass.BotonTema();
            this.btnCierrePeriodo = new Vistass.BotonTema();
            this.pnlTabla = new System.Windows.Forms.Panel();
            this.dgvPagos = new Vistass.GridOscuro();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlEncabezado.SuspendLayout();
            this.pnlResumen.SuspendLayout();
            this.pnlBarra.SuspendLayout();
            this.pnlTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.pnlEncabezado.Controls.Add(this.lblSubtitulo);
            this.pnlEncabezado.Controls.Add(this.lblTituloPlanillas);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Location = new System.Drawing.Point(24, 0);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(1200, 84);
            this.pnlEncabezado.TabIndex = 3;
            // 
            // lblTituloPlanillas
            // 
            this.lblTituloPlanillas.AutoSize = true;
            this.lblTituloPlanillas.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTituloPlanillas.ForeColor = System.Drawing.Color.FromArgb(240, 244, 252);
            this.lblTituloPlanillas.Location = new System.Drawing.Point(0, 12);
            this.lblTituloPlanillas.Name = "lblTituloPlanillas";
            this.lblTituloPlanillas.Size = new System.Drawing.Size(300, 37);
            this.lblTituloPlanillas.TabIndex = 0;
            this.lblTituloPlanillas.Text = "Gestión de planillas";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(170, 180, 200);
            this.lblSubtitulo.Location = new System.Drawing.Point(2, 52);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(290, 19);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Pagos mensuales del personal, por período";
            // 
            // pnlResumen
            // 
            this.pnlResumen.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.pnlResumen.Controls.Add(this.flpResumen);
            this.pnlResumen.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlResumen.Location = new System.Drawing.Point(24, 84);
            this.pnlResumen.Name = "pnlResumen";
            this.pnlResumen.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.pnlResumen.Size = new System.Drawing.Size(1200, 44);
            this.pnlResumen.TabIndex = 2;
            // 
            // flpResumen
            // 
            this.flpResumen.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.flpResumen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpResumen.Name = "flpResumen";
            this.flpResumen.WrapContents = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // pnlBarra
            // 
            this.pnlBarra.BackColor = System.Drawing.Color.FromArgb(27, 29, 38);
            this.pnlBarra.Controls.Add(this.pnlBuscador);
            this.pnlBarra.Controls.Add(this.cmbPeriodo);
            this.pnlBarra.Controls.Add(this.cmbEstadoPago);
            this.pnlBarra.Controls.Add(this.lblEstadoPeriodo);
            this.pnlBarra.Controls.Add(this.btnNuevoPago);
            this.pnlBarra.Controls.Add(this.btnGenerarPlanilla);
            this.pnlBarra.Controls.Add(this.btnEditarPago);
            this.pnlBarra.Controls.Add(this.btnMarcarPagado);
            this.pnlBarra.Controls.Add(this.btnAnularPago);
            this.pnlBarra.Controls.Add(this.btnBoleta);
            this.pnlBarra.Controls.Add(this.btnExportarPdf);
            this.pnlBarra.Controls.Add(this.btnCierrePeriodo);
            this.pnlBarra.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarra.Location = new System.Drawing.Point(24, 188);
            this.pnlBarra.Name = "pnlBarra";
            this.pnlBarra.Size = new System.Drawing.Size(1200, 112);
            this.pnlBarra.TabIndex = 1;
            // 
            // pnlBuscador
            // 
            this.pnlBuscador.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.pnlBuscador.Controls.Add(this.lblBuscarHint);
            this.pnlBuscador.Controls.Add(this.txtBuscar);
            this.pnlBuscador.Controls.Add(this.pnlLupa);
            this.pnlBuscador.Location = new System.Drawing.Point(16, 16);
            this.pnlBuscador.Name = "pnlBuscador";
            this.pnlBuscador.Padding = new System.Windows.Forms.Padding(1);
            this.pnlBuscador.Size = new System.Drawing.Size(300, 28);
            this.pnlBuscador.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBuscador_Paint);
            // 
            // lblBuscarHint
            // 
            this.lblBuscarHint.AutoSize = true;
            this.lblBuscarHint.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.lblBuscarHint.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblBuscarHint.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblBuscarHint.ForeColor = System.Drawing.Color.FromArgb(140, 150, 176);
            this.lblBuscarHint.Location = new System.Drawing.Point(33, 4);
            this.lblBuscarHint.Name = "lblBuscarHint";
            this.lblBuscarHint.Text = "Buscar por empleado o cargo...";
            this.lblBuscarHint.Click += new System.EventHandler(this.lblBuscarHint_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtBuscar.ForeColor = System.Drawing.Color.FromArgb(240, 244, 252);
            this.txtBuscar.Location = new System.Drawing.Point(32, 4);
            this.txtBuscar.MaxLength = 100;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(258, 19);
            this.txtBuscar.TabIndex = 0;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar.Enter += new System.EventHandler(this.txtBuscar_FocoCambiado);
            this.txtBuscar.Leave += new System.EventHandler(this.txtBuscar_FocoCambiado);
            // 
            // pnlLupa
            // 
            this.pnlLupa.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.pnlLupa.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLupa.Name = "pnlLupa";
            this.pnlLupa.Size = new System.Drawing.Size(28, 26);
            this.pnlLupa.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlLupa_Paint);
            // 
            // cmbPeriodo
            // 
            this.cmbPeriodo.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.cmbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPeriodo.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cmbPeriodo.ForeColor = System.Drawing.Color.FromArgb(240, 244, 252);
            this.cmbPeriodo.FormattingEnabled = true;
            this.cmbPeriodo.Location = new System.Drawing.Point(332, 16);
            this.cmbPeriodo.Name = "cmbPeriodo";
            this.cmbPeriodo.Size = new System.Drawing.Size(200, 27);
            this.cmbPeriodo.TabIndex = 1;
            this.cmbPeriodo.SelectedIndexChanged += new System.EventHandler(this.cmbPeriodo_SelectedIndexChanged);
            // 
            // cmbEstadoPago
            // 
            this.cmbEstadoPago.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.cmbEstadoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEstadoPago.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cmbEstadoPago.ForeColor = System.Drawing.Color.FromArgb(240, 244, 252);
            this.cmbEstadoPago.FormattingEnabled = true;
            this.cmbEstadoPago.Location = new System.Drawing.Point(548, 16);
            this.cmbEstadoPago.Name = "cmbEstadoPago";
            this.cmbEstadoPago.Size = new System.Drawing.Size(180, 27);
            this.cmbEstadoPago.TabIndex = 2;
            this.cmbEstadoPago.SelectedIndexChanged += new System.EventHandler(this.cmbEstadoPago_SelectedIndexChanged);
            // 
            // lblEstadoPeriodo
            // 
            this.lblEstadoPeriodo.AutoSize = true;
            this.lblEstadoPeriodo.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblEstadoPeriodo.ForeColor = System.Drawing.Color.FromArgb(74, 222, 128);
            this.lblEstadoPeriodo.Location = new System.Drawing.Point(748, 19);
            this.lblEstadoPeriodo.Name = "lblEstadoPeriodo";
            this.lblEstadoPeriodo.Size = new System.Drawing.Size(0, 19);
            this.lblEstadoPeriodo.TabIndex = 3;
            // 
            // btnNuevoPago
            // 
            this.btnNuevoPago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoPago.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNuevoPago.Location = new System.Drawing.Point(16, 58);
            this.btnNuevoPago.Name = "btnNuevoPago";
            this.btnNuevoPago.Size = new System.Drawing.Size(120, 38);
            this.btnNuevoPago.TabIndex = 4;
            this.btnNuevoPago.Text = "Nuevo pago";
            this.btnNuevoPago.Tipo = Vistass.TipoBoton.Principal;
            this.btnNuevoPago.Click += new System.EventHandler(this.btnNuevoPago_Click);
            // 
            // btnGenerarPlanilla
            // 
            this.btnGenerarPlanilla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerarPlanilla.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGenerarPlanilla.Location = new System.Drawing.Point(144, 58);
            this.btnGenerarPlanilla.Name = "btnGenerarPlanilla";
            this.btnGenerarPlanilla.Size = new System.Drawing.Size(150, 38);
            this.btnGenerarPlanilla.TabIndex = 5;
            this.btnGenerarPlanilla.Text = "Generar planilla";
            this.btnGenerarPlanilla.Tipo = Vistass.TipoBoton.Secundario;
            this.btnGenerarPlanilla.Click += new System.EventHandler(this.btnGenerarPlanilla_Click);
            // 
            // btnEditarPago
            // 
            this.btnEditarPago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarPago.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditarPago.Location = new System.Drawing.Point(302, 58);
            this.btnEditarPago.Name = "btnEditarPago";
            this.btnEditarPago.Size = new System.Drawing.Size(90, 38);
            this.btnEditarPago.TabIndex = 6;
            this.btnEditarPago.Text = "Editar";
            this.btnEditarPago.Tipo = Vistass.TipoBoton.Secundario;
            this.btnEditarPago.Click += new System.EventHandler(this.btnEditarPago_Click);
            // 
            // btnMarcarPagado
            // 
            this.btnMarcarPagado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMarcarPagado.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMarcarPagado.Location = new System.Drawing.Point(400, 58);
            this.btnMarcarPagado.Name = "btnMarcarPagado";
            this.btnMarcarPagado.Size = new System.Drawing.Size(140, 38);
            this.btnMarcarPagado.TabIndex = 7;
            this.btnMarcarPagado.Text = "Marcar pagado";
            this.btnMarcarPagado.Tipo = Vistass.TipoBoton.Secundario;
            this.btnMarcarPagado.Click += new System.EventHandler(this.btnMarcarPagado_Click);
            // 
            // btnAnularPago
            // 
            this.btnAnularPago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnularPago.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAnularPago.Location = new System.Drawing.Point(548, 58);
            this.btnAnularPago.Name = "btnAnularPago";
            this.btnAnularPago.Size = new System.Drawing.Size(100, 38);
            this.btnAnularPago.TabIndex = 8;
            this.btnAnularPago.Text = "Anular";
            this.btnAnularPago.Tipo = Vistass.TipoBoton.Peligro;
            this.btnAnularPago.Click += new System.EventHandler(this.btnAnularPago_Click);
            // 
            // btnBoleta
            // 
            this.btnBoleta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBoleta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBoleta.Location = new System.Drawing.Point(788, 58);
            this.btnBoleta.Name = "btnBoleta";
            this.btnBoleta.Size = new System.Drawing.Size(120, 38);
            this.btnBoleta.TabIndex = 9;
            this.btnBoleta.Text = "Boleta PDF";
            this.btnBoleta.Tipo = Vistass.TipoBoton.Secundario;
            this.btnBoleta.Click += new System.EventHandler(this.btnBoleta_Click);
            // 
            // btnExportarPdf
            // 
            this.btnExportarPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportarPdf.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportarPdf.Location = new System.Drawing.Point(916, 58);
            this.btnExportarPdf.Name = "btnExportarPdf";
            this.btnExportarPdf.Size = new System.Drawing.Size(130, 38);
            this.btnExportarPdf.TabIndex = 10;
            this.btnExportarPdf.Text = "Exportar";
            this.btnExportarPdf.Tipo = Vistass.TipoBoton.Secundario;
            this.btnExportarPdf.Click += new System.EventHandler(this.btnExportarPdf_Click);
            // 
            // btnCierrePeriodo
            // 
            this.btnCierrePeriodo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCierrePeriodo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCierrePeriodo.Location = new System.Drawing.Point(1054, 58);
            this.btnCierrePeriodo.Name = "btnCierrePeriodo";
            this.btnCierrePeriodo.Size = new System.Drawing.Size(130, 38);
            this.btnCierrePeriodo.TabIndex = 11;
            this.btnCierrePeriodo.Text = "Cerrar mes";
            this.btnCierrePeriodo.Tipo = Vistass.TipoBoton.Peligro;
            this.btnCierrePeriodo.Click += new System.EventHandler(this.btnCierrePeriodo_Click);
            // 
            // pnlTabla
            // 
            this.pnlTabla.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.pnlTabla.Controls.Add(this.dgvPagos);
            this.pnlTabla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTabla.Location = new System.Drawing.Point(24, 300);
            this.pnlTabla.Name = "pnlTabla";
            this.pnlTabla.Padding = new System.Windows.Forms.Padding(0, 16, 0, 0);
            this.pnlTabla.Size = new System.Drawing.Size(1200, 444);
            this.pnlTabla.TabIndex = 0;
            // 
            // dgvPagos
            // 
            this.dgvPagos.AllowUserToAddRows = false;
            this.dgvPagos.AllowUserToDeleteRows = false;
            this.dgvPagos.AllowUserToResizeRows = false;
            this.dgvPagos.ColumnHeadersHeight = 40;
            this.dgvPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPagos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPagos.Location = new System.Drawing.Point(0, 16);
            this.dgvPagos.MultiSelect = false;
            this.dgvPagos.Name = "dgvPagos";
            this.dgvPagos.ReadOnly = true;
            this.dgvPagos.RowTemplate.Height = 36;
            this.dgvPagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPagos.Size = new System.Drawing.Size(1200, 428);
            this.dgvPagos.TabIndex = 0;
            this.dgvPagos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPagos_CellDoubleClick);
            this.dgvPagos.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvPagos_CellPainting);
            this.dgvPagos.SelectionChanged += new System.EventHandler(this.dgvPagos_SelectionChanged);
            // 
            // frmGestionPlanillas
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.ClientSize = new System.Drawing.Size(1248, 760);
            this.Controls.Add(this.pnlTabla);
            this.Controls.Add(this.pnlBarra);
            this.Controls.Add(this.pnlResumen);
            this.Controls.Add(this.pnlEncabezado);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "frmGestionPlanillas";
            this.Padding = new System.Windows.Forms.Padding(24, 0, 24, 16);
            this.Text = "Gestión de planillas";
            this.Load += new System.EventHandler(this.frmGestionPlanillas_Load);
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.pnlResumen.ResumeLayout(false);
            this.pnlBarra.ResumeLayout(false);
            this.pnlBarra.PerformLayout();
            this.pnlTabla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label lblTituloPlanillas;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel pnlResumen;
        private System.Windows.Forms.FlowLayoutPanel flpResumen;
        private Vistass.PanelTarjeta pnlBarra;
        private System.Windows.Forms.TextBox txtBuscar;
        private Vistass.ComboOscuro cmbPeriodo;
        private Vistass.ComboOscuro cmbEstadoPago;
        private System.Windows.Forms.Label lblEstadoPeriodo;
        private Vistass.BotonTema btnNuevoPago;
        private Vistass.BotonTema btnGenerarPlanilla;
        private Vistass.BotonTema btnEditarPago;
        private Vistass.BotonTema btnMarcarPagado;
        private Vistass.BotonTema btnAnularPago;
        private Vistass.BotonTema btnBoleta;
        private Vistass.BotonTema btnExportarPdf;
        private Vistass.BotonTema btnCierrePeriodo;
        private System.Windows.Forms.Panel pnlTabla;
        private Vistass.GridOscuro dgvPagos;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel pnlBuscador;
        private System.Windows.Forms.Label lblBuscarHint;
        private System.Windows.Forms.Panel pnlLupa;
    }
}