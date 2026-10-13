namespace Vistass
{
    partial class frmCatalogoSalarios
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
            this.lblTituloCatalogo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.pnlResumen = new System.Windows.Forms.Panel();
            this.tlpResumen = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTarjCosto = new Vistass.PanelTarjeta();
            this.lblCostoDetalle = new System.Windows.Forms.Label();
            this.lblCostoValor = new System.Windows.Forms.Label();
            this.lblCostoTitulo = new System.Windows.Forms.Label();
            this.pnlAcCosto = new System.Windows.Forms.Panel();
            this.pnlTarjSinUso = new Vistass.PanelTarjeta();
            this.lblSinUsoDetalle = new System.Windows.Forms.Label();
            this.lblSinUsoValor = new System.Windows.Forms.Label();
            this.lblSinUsoTitulo = new System.Windows.Forms.Label();
            this.pnlAcSinUso = new System.Windows.Forms.Panel();
            this.pnlBarra = new Vistass.PanelTarjeta();
            this.pnlBuscador = new System.Windows.Forms.Panel();
            this.lblBuscarHint = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.pnlLupa = new System.Windows.Forms.Panel();
            this.pnlAcciones = new System.Windows.Forms.Panel();
            this.btnVerEmpleados = new Vistass.BotonTema();
            this.btnNuevaEstructura = new Vistass.BotonTema();
            this.btnEditarEstructura = new Vistass.BotonTema();
            this.btnEliminarEstructura = new Vistass.BotonTema();
            this.btnExportarPdf = new Vistass.BotonTema();
            this.pnlTabla = new System.Windows.Forms.Panel();
            this.dgvEstructuras = new Vistass.GridOscuro();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlEncabezado.SuspendLayout();
            this.pnlResumen.SuspendLayout();
            this.tlpResumen.SuspendLayout();
            this.pnlTarjCosto.SuspendLayout();
            this.pnlTarjSinUso.SuspendLayout();
            this.pnlBarra.SuspendLayout();
            this.pnlBuscador.SuspendLayout();
            this.pnlAcciones.SuspendLayout();
            this.pnlTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstructuras)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.pnlEncabezado.Controls.Add(this.lblTituloCatalogo);
            this.pnlEncabezado.Controls.Add(this.lblSubtitulo);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Location = new System.Drawing.Point(24, 0);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(1200, 84);
            this.pnlEncabezado.TabIndex = 3;
            // 
            // lblTituloCatalogo
            // 
            this.lblTituloCatalogo.AutoSize = true;
            this.lblTituloCatalogo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTituloCatalogo.ForeColor = System.Drawing.Color.FromArgb(240, 244, 252);
            this.lblTituloCatalogo.Location = new System.Drawing.Point(0, 12);
            this.lblTituloCatalogo.Name = "lblTituloCatalogo";
            this.lblTituloCatalogo.Text = "Catálogo de salarios";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(170, 180, 200);
            this.lblSubtitulo.Location = new System.Drawing.Point(2, 52);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Text = "Estructuras salariales que se asignan a los empleados";
            // 
            // pnlResumen
            // 
            this.pnlResumen.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.pnlResumen.Controls.Add(this.tlpResumen);
            this.pnlResumen.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlResumen.Location = new System.Drawing.Point(24, 84);
            this.pnlResumen.Name = "pnlResumen";
            this.pnlResumen.Padding = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.pnlResumen.Size = new System.Drawing.Size(1200, 88);
            this.pnlResumen.TabIndex = 2;
            // 
            // tlpResumen
            // 
            this.tlpResumen.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.tlpResumen.ColumnCount = 2;
            this.tlpResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpResumen.Controls.Add(this.pnlTarjCosto, 0, 0);
            this.tlpResumen.Controls.Add(this.pnlTarjSinUso, 1, 0);
            this.tlpResumen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpResumen.Margin = new System.Windows.Forms.Padding(0);
            this.tlpResumen.Name = "tlpResumen";
            this.tlpResumen.RowCount = 1;
            this.tlpResumen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpResumen.Size = new System.Drawing.Size(1200, 76);
            this.tlpResumen.TabIndex = 0;
            // 
            // pnlTarjCosto
            // 
            this.pnlTarjCosto.BackColor = System.Drawing.Color.FromArgb(27, 29, 38);
            this.pnlTarjCosto.Controls.Add(this.lblCostoDetalle);
            this.pnlTarjCosto.Controls.Add(this.lblCostoValor);
            this.pnlTarjCosto.Controls.Add(this.lblCostoTitulo);
            this.pnlTarjCosto.Controls.Add(this.pnlAcCosto);
            this.pnlTarjCosto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTarjCosto.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.pnlTarjCosto.Name = "pnlTarjCosto";
            // 
            // pnlAcCosto
            // 
            this.pnlAcCosto.BackColor = System.Drawing.Color.FromArgb(96, 165, 250);
            this.pnlAcCosto.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAcCosto.Name = "pnlAcCosto";
            this.pnlAcCosto.Size = new System.Drawing.Size(4, 76);
            // 
            // lblCostoTitulo
            // 
            this.lblCostoTitulo.AutoSize = true;
            this.lblCostoTitulo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCostoTitulo.ForeColor = System.Drawing.Color.FromArgb(170, 180, 200);
            this.lblCostoTitulo.Location = new System.Drawing.Point(20, 8);
            this.lblCostoTitulo.Name = "lblCostoTitulo";
            this.lblCostoTitulo.Text = "COSTO MENSUAL DE LA PLANILLA";
            // 
            // lblCostoValor
            // 
            this.lblCostoValor.AutoSize = true;
            this.lblCostoValor.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblCostoValor.ForeColor = System.Drawing.Color.FromArgb(147, 197, 253);
            this.lblCostoValor.Location = new System.Drawing.Point(18, 22);
            this.lblCostoValor.Name = "lblCostoValor";
            this.lblCostoValor.Text = "$0.00";
            // 
            // lblCostoDetalle
            // 
            this.lblCostoDetalle.AutoSize = true;
            this.lblCostoDetalle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCostoDetalle.ForeColor = System.Drawing.Color.FromArgb(170, 180, 200);
            this.lblCostoDetalle.Location = new System.Drawing.Point(20, 56);
            this.lblCostoDetalle.Name = "lblCostoDetalle";
            this.lblCostoDetalle.Text = "...";
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
            // pnlTarjSinUso
            // 
            this.pnlTarjSinUso.BackColor = System.Drawing.Color.FromArgb(27, 29, 38);
            this.pnlTarjSinUso.Controls.Add(this.lblSinUsoDetalle);
            this.pnlTarjSinUso.Controls.Add(this.lblSinUsoValor);
            this.pnlTarjSinUso.Controls.Add(this.lblSinUsoTitulo);
            this.pnlTarjSinUso.Controls.Add(this.pnlAcSinUso);
            this.pnlTarjSinUso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTarjSinUso.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTarjSinUso.Name = "pnlTarjSinUso";
            // 
            // pnlAcSinUso
            // 
            this.pnlAcSinUso.BackColor = System.Drawing.Color.FromArgb(74, 222, 128);
            this.pnlAcSinUso.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAcSinUso.Name = "pnlAcSinUso";
            this.pnlAcSinUso.Size = new System.Drawing.Size(4, 76);
            // 
            // lblSinUsoTitulo
            // 
            this.lblSinUsoTitulo.AutoSize = true;
            this.lblSinUsoTitulo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSinUsoTitulo.ForeColor = System.Drawing.Color.FromArgb(170, 180, 200);
            this.lblSinUsoTitulo.Location = new System.Drawing.Point(20, 8);
            this.lblSinUsoTitulo.Name = "lblSinUsoTitulo";
            this.lblSinUsoTitulo.Text = "ESTRUCTURAS SIN USO";
            // 
            // lblSinUsoValor
            // 
            this.lblSinUsoValor.AutoSize = true;
            this.lblSinUsoValor.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblSinUsoValor.ForeColor = System.Drawing.Color.FromArgb(134, 239, 172);
            this.lblSinUsoValor.Location = new System.Drawing.Point(18, 22);
            this.lblSinUsoValor.Name = "lblSinUsoValor";
            this.lblSinUsoValor.Text = "0";
            // 
            // lblSinUsoDetalle
            // 
            this.lblSinUsoDetalle.AutoSize = true;
            this.lblSinUsoDetalle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSinUsoDetalle.ForeColor = System.Drawing.Color.FromArgb(170, 180, 200);
            this.lblSinUsoDetalle.Location = new System.Drawing.Point(20, 56);
            this.lblSinUsoDetalle.Name = "lblSinUsoDetalle";
            this.lblSinUsoDetalle.Text = "...";
            // 
            // pnlBarra
            // 
            this.pnlBarra.BackColor = System.Drawing.Color.FromArgb(27, 29, 38);
            this.pnlBarra.Controls.Add(this.pnlBuscador);
            this.pnlBarra.Controls.Add(this.pnlAcciones);
            this.pnlBarra.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarra.Location = new System.Drawing.Point(24, 172);
            this.pnlBarra.Name = "pnlBarra";
            this.pnlBarra.Size = new System.Drawing.Size(1200, 68);
            this.pnlBarra.TabIndex = 1;
            // 
            // pnlBuscador  (caja con lupa; el borde se dibuja en el .cs)
            // 
            this.pnlBuscador.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.pnlBuscador.Controls.Add(this.lblBuscarHint);
            this.pnlBuscador.Controls.Add(this.txtBuscar);
            this.pnlBuscador.Controls.Add(this.pnlLupa);
            this.pnlBuscador.Location = new System.Drawing.Point(16, 20);
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
            this.lblBuscarHint.Text = "Buscar por N° o por monto...";
            this.lblBuscarHint.Click += new System.EventHandler(this.lblBuscarHint_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtBuscar.ForeColor = System.Drawing.Color.FromArgb(240, 244, 252);
            this.txtBuscar.Location = new System.Drawing.Point(32, 4);
            this.txtBuscar.MaxLength = 20;
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
            // pnlAcciones  (grupo de botones pegado a la derecha, sin anclajes)
            // 
            this.pnlAcciones.BackColor = System.Drawing.Color.FromArgb(27, 29, 38);
            this.pnlAcciones.Controls.Add(this.btnVerEmpleados);
            this.pnlAcciones.Controls.Add(this.btnNuevaEstructura);
            this.pnlAcciones.Controls.Add(this.btnEditarEstructura);
            this.pnlAcciones.Controls.Add(this.btnEliminarEstructura);
            this.pnlAcciones.Controls.Add(this.btnExportarPdf);
            this.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlAcciones.Name = "pnlAcciones";
            this.pnlAcciones.Size = new System.Drawing.Size(660, 68);
            // 
            // btnVerEmpleados
            // 
            this.btnVerEmpleados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerEmpleados.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnVerEmpleados.Location = new System.Drawing.Point(0, 15);
            this.btnVerEmpleados.Name = "btnVerEmpleados";
            this.btnVerEmpleados.Size = new System.Drawing.Size(130, 38);
            this.btnVerEmpleados.TabIndex = 5;
            this.btnVerEmpleados.Text = "Ver empleados";
            this.btnVerEmpleados.Tipo = Vistass.TipoBoton.Secundario;
            this.btnVerEmpleados.Click += new System.EventHandler(this.btnVerEmpleados_Click);
            // 
            // btnNuevaEstructura
            // 
            this.btnNuevaEstructura.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevaEstructura.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNuevaEstructura.Location = new System.Drawing.Point(138, 15);
            this.btnNuevaEstructura.Name = "btnNuevaEstructura";
            this.btnNuevaEstructura.Size = new System.Drawing.Size(180, 38);
            this.btnNuevaEstructura.TabIndex = 1;
            this.btnNuevaEstructura.Text = "+ Nueva estructura";
            this.btnNuevaEstructura.Tipo = Vistass.TipoBoton.Principal;
            this.btnNuevaEstructura.Click += new System.EventHandler(this.btnNuevaEstructura_Click);
            // 
            // btnEditarEstructura
            // 
            this.btnEditarEstructura.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarEstructura.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditarEstructura.Location = new System.Drawing.Point(326, 15);
            this.btnEditarEstructura.Name = "btnEditarEstructura";
            this.btnEditarEstructura.Size = new System.Drawing.Size(90, 38);
            this.btnEditarEstructura.TabIndex = 2;
            this.btnEditarEstructura.Text = "Editar";
            this.btnEditarEstructura.Tipo = Vistass.TipoBoton.Secundario;
            this.btnEditarEstructura.Click += new System.EventHandler(this.btnEditarEstructura_Click);
            // 
            // btnEliminarEstructura
            // 
            this.btnEliminarEstructura.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarEstructura.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEliminarEstructura.Location = new System.Drawing.Point(424, 15);
            this.btnEliminarEstructura.Name = "btnEliminarEstructura";
            this.btnEliminarEstructura.Size = new System.Drawing.Size(100, 38);
            this.btnEliminarEstructura.TabIndex = 3;
            this.btnEliminarEstructura.Text = "Eliminar";
            this.btnEliminarEstructura.Tipo = Vistass.TipoBoton.Peligro;
            this.btnEliminarEstructura.Click += new System.EventHandler(this.btnEliminarEstructura_Click);
            // 
            // btnExportarPdf
            // 
            this.btnExportarPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportarPdf.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportarPdf.Location = new System.Drawing.Point(532, 15);
            this.btnExportarPdf.Name = "btnExportarPdf";
            this.btnExportarPdf.Size = new System.Drawing.Size(120, 38);
            this.btnExportarPdf.TabIndex = 4;
            this.btnExportarPdf.Text = "Exportar";
            this.btnExportarPdf.Tipo = Vistass.TipoBoton.Secundario;
            this.btnExportarPdf.Click += new System.EventHandler(this.btnExportarPdf_Click);
            // 
            // pnlTabla
            // 
            this.pnlTabla.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.pnlTabla.Controls.Add(this.dgvEstructuras);
            this.pnlTabla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTabla.Location = new System.Drawing.Point(24, 240);
            this.pnlTabla.Name = "pnlTabla";
            this.pnlTabla.Padding = new System.Windows.Forms.Padding(0, 16, 0, 0);
            this.pnlTabla.Size = new System.Drawing.Size(1200, 504);
            this.pnlTabla.TabIndex = 0;
            // 
            // dgvEstructuras
            // 
            this.dgvEstructuras.ColumnHeadersHeight = 40;
            this.dgvEstructuras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEstructuras.Name = "dgvEstructuras";
            this.dgvEstructuras.RowHeadersWidth = 51;
            this.dgvEstructuras.RowTemplate.Height = 36;
            this.dgvEstructuras.TabIndex = 0;
            this.dgvEstructuras.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEstructuras_CellDoubleClick);
            this.dgvEstructuras.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvEstructuras_CellFormatting);
            this.dgvEstructuras.SelectionChanged += new System.EventHandler(this.dgvEstructuras_SelectionChanged);
            // 
            // frmCatalogoSalarios
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.ClientSize = new System.Drawing.Size(1248, 760);
            this.Controls.Add(this.pnlTabla);
            this.Controls.Add(this.pnlBarra);
            this.Controls.Add(this.pnlResumen);
            this.Controls.Add(this.pnlEncabezado);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "frmCatalogoSalarios";
            this.Padding = new System.Windows.Forms.Padding(24, 0, 24, 16);
            this.Text = "Catálogo de salarios";
            this.Load += new System.EventHandler(this.frmCatalogoSalarios_Load);
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.pnlResumen.ResumeLayout(false);
            this.tlpResumen.ResumeLayout(false);
            this.pnlTarjCosto.ResumeLayout(false);
            this.pnlTarjCosto.PerformLayout();
            this.pnlTarjSinUso.ResumeLayout(false);
            this.pnlTarjSinUso.PerformLayout();
            this.pnlBarra.ResumeLayout(false);
            this.pnlBuscador.ResumeLayout(false);
            this.pnlBuscador.PerformLayout();
            this.pnlAcciones.ResumeLayout(false);
            this.pnlTabla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstructuras)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label lblTituloCatalogo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel pnlResumen;
        private System.Windows.Forms.TableLayoutPanel tlpResumen;
        private Vistass.PanelTarjeta pnlTarjCosto;
        private System.Windows.Forms.Panel pnlAcCosto;
        private System.Windows.Forms.Label lblCostoTitulo;
        private System.Windows.Forms.Label lblCostoValor;
        private System.Windows.Forms.Label lblCostoDetalle;
        private Vistass.PanelTarjeta pnlTarjSinUso;
        private System.Windows.Forms.Panel pnlAcSinUso;
        private System.Windows.Forms.Label lblSinUsoTitulo;
        private System.Windows.Forms.Label lblSinUsoValor;
        private System.Windows.Forms.Label lblSinUsoDetalle;
        private Vistass.PanelTarjeta pnlBarra;
        private System.Windows.Forms.Panel pnlBuscador;
        private System.Windows.Forms.Label lblBuscarHint;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Panel pnlLupa;
        private System.Windows.Forms.Panel pnlAcciones;
        private Vistass.BotonTema btnVerEmpleados;
        private Vistass.BotonTema btnNuevaEstructura;
        private Vistass.BotonTema btnEditarEstructura;
        private Vistass.BotonTema btnEliminarEstructura;
        private Vistass.BotonTema btnExportarPdf;
        private System.Windows.Forms.Panel pnlTabla;
        private Vistass.GridOscuro dgvEstructuras;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}