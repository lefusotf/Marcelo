using System.Drawing;
using System.Windows.Forms;

namespace Vistass
{
    partial class frmGestionActivos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.tlpKpis = new System.Windows.Forms.TableLayoutPanel();
            this.pnlKpi1 = new System.Windows.Forms.Panel();
            this.lblKpi1Txt = new System.Windows.Forms.Label();
            this.lblKpi1 = new System.Windows.Forms.Label();
            this.pnlKpi2 = new System.Windows.Forms.Panel();
            this.lblKpi2Txt = new System.Windows.Forms.Label();
            this.lblKpi2 = new System.Windows.Forms.Label();
            this.pnlKpi3 = new System.Windows.Forms.Panel();
            this.lblKpi3Txt = new System.Windows.Forms.Label();
            this.lblKpi3 = new System.Windows.Forms.Label();
            this.pnlKpi4 = new System.Windows.Forms.Panel();
            this.lblKpi4Txt = new System.Windows.Forms.Label();
            this.lblKpi4 = new System.Windows.Forms.Label();
            this.pnlKpi5 = new System.Windows.Forms.Panel();
            this.lblKpi5Txt = new System.Windows.Forms.Label();
            this.lblKpi5 = new System.Windows.Forms.Label();
            this.tabPrincipal = new System.Windows.Forms.TabControl();
            this.tabCatalogo = new System.Windows.Forms.TabPage();
            this.pnlLista = new System.Windows.Forms.Panel();
            this.dgvActivos = new System.Windows.Forms.DataGridView();
            this.pnlSeparador = new System.Windows.Forms.Panel();
            this.pnlFicha = new System.Windows.Forms.Panel();
            this.tabFicha = new System.Windows.Forms.TabControl();
            this.tabUbicacion = new System.Windows.Forms.TabPage();
            this.dgvUbicacion = new System.Windows.Forms.DataGridView();
            this.pnlEstadoUnidad = new System.Windows.Forms.Panel();
            this.lblEstadoUnidad = new System.Windows.Forms.Label();
            this.cmbEstadoUnidad = new System.Windows.Forms.ComboBox();
            this.btnCambiarEstadoUnidad = new System.Windows.Forms.Button();
            this.tabHistorial = new System.Windows.Forms.TabPage();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.tabDanos = new System.Windows.Forms.TabPage();
            this.dgvDanos = new System.Windows.Forms.DataGridView();
            this.lblFichaTitulo = new System.Windows.Forms.Label();
            this.pnlBusqueda = new System.Windows.Forms.Panel();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.cmbFiltroCategoria = new System.Windows.Forms.ComboBox();
            this.cmbFiltroEstado = new System.Windows.Forms.ComboBox();
            this.lblResultados = new System.Windows.Forms.Label();
            this.btnExportarPdf = new System.Windows.Forms.Button();
            this.pnlFormulario = new System.Windows.Forms.Panel();
            this.lblModo = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.lblUbicacion = new System.Windows.Forms.Label();
            this.cmbUbicacion = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.tabPrestamos = new System.Windows.Forms.TabPage();
            this.pnlPrestLista = new System.Windows.Forms.Panel();
            this.dgvPrestamos = new System.Windows.Forms.DataGridView();
            this.pnlDevolucion = new System.Windows.Forms.Panel();
            this.lblDevSel = new System.Windows.Forms.Label();
            this.lblDevEstado = new System.Windows.Forms.Label();
            this.cmbDevEstado = new System.Windows.Forms.ComboBox();
            this.lblDevObs = new System.Windows.Forms.Label();
            this.txtDevObs = new System.Windows.Forms.TextBox();
            this.btnDevolver = new System.Windows.Forms.Button();
            this.btnHoja = new System.Windows.Forms.Button();
            this.pnlPrestFiltro = new System.Windows.Forms.Panel();
            this.lblPrestVer = new System.Windows.Forms.Label();
            this.cmbPrestVer = new System.Windows.Forms.ComboBox();
            this.lblPrestAlertas = new System.Windows.Forms.Label();
            this.pnlPrestForm = new System.Windows.Forms.Panel();
            this.lblPrestTitulo = new System.Windows.Forms.Label();
            this.lblPrestActivo = new System.Windows.Forms.Label();
            this.cmbPrestActivo = new System.Windows.Forms.ComboBox();
            this.lblPrestCodigo = new System.Windows.Forms.Label();
            this.txtPrestCodigo = new System.Windows.Forms.TextBox();
            this.lblPrestCant = new System.Windows.Forms.Label();
            this.numPrestCant = new System.Windows.Forms.NumericUpDown();
            this.lblPrestTipo = new System.Windows.Forms.Label();
            this.cmbPrestTipo = new System.Windows.Forms.ComboBox();
            this.lblPrestResp = new System.Windows.Forms.Label();
            this.txtPrestResp = new System.Windows.Forms.TextBox();
            this.lblPrestAula = new System.Windows.Forms.Label();
            this.cmbPrestAula = new System.Windows.Forms.ComboBox();
            this.lblPrestLimite = new System.Windows.Forms.Label();
            this.dtpPrestLimite = new System.Windows.Forms.DateTimePicker();
            this.lblPrestObs = new System.Windows.Forms.Label();
            this.txtPrestObs = new System.Windows.Forms.TextBox();
            this.btnPrestar = new System.Windows.Forms.Button();
            this.tabConsumibles = new System.Windows.Forms.TabPage();
            this.pnlConsLista = new System.Windows.Forms.Panel();
            this.dgvKardex = new System.Windows.Forms.DataGridView();
            this.pnlKardexBarra = new System.Windows.Forms.Panel();
            this.lblKardexTitulo = new System.Windows.Forms.Label();
            this.btnKardexTodos = new System.Windows.Forms.Button();
            this.pnlStock = new System.Windows.Forms.Panel();
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.lblStockTitulo = new System.Windows.Forms.Label();
            this.pnlConsForm = new System.Windows.Forms.Panel();
            this.lblConsNuevo = new System.Windows.Forms.Label();
            this.lblConsNombre = new System.Windows.Forms.Label();
            this.txtConsNombre = new System.Windows.Forms.TextBox();
            this.lblConsUnidad = new System.Windows.Forms.Label();
            this.txtConsUnidad = new System.Windows.Forms.TextBox();
            this.lblConsMin = new System.Windows.Forms.Label();
            this.numConsMin = new System.Windows.Forms.NumericUpDown();
            this.btnConsCrear = new System.Windows.Forms.Button();
            this.lblMovTitulo = new System.Windows.Forms.Label();
            this.lblMovCons = new System.Windows.Forms.Label();
            this.cmbMovCons = new System.Windows.Forms.ComboBox();
            this.lblMovTipo = new System.Windows.Forms.Label();
            this.cmbMovTipo = new System.Windows.Forms.ComboBox();
            this.lblMovCant = new System.Windows.Forms.Label();
            this.numMovCant = new System.Windows.Forms.NumericUpDown();
            this.lblMovMotivo = new System.Windows.Forms.Label();
            this.cmbMovMotivo = new System.Windows.Forms.ComboBox();
            this.lblMovDestino = new System.Windows.Forms.Label();
            this.txtMovDestino = new System.Windows.Forms.TextBox();
            this.btnMovimiento = new System.Windows.Forms.Button();
            this.tabMantenimiento = new System.Windows.Forms.TabPage();
            this.pnlMantLista = new System.Windows.Forms.Panel();
            this.dgvMantenimientos = new System.Windows.Forms.DataGridView();
            this.lblMantHistTitulo = new System.Windows.Forms.Label();
            this.pnlMantReportes = new System.Windows.Forms.Panel();
            this.dgvMantReportes = new System.Windows.Forms.DataGridView();
            this.lblMantReportesTitulo = new System.Windows.Forms.Label();
            this.pnlMantForm = new System.Windows.Forms.Panel();
            this.lblMantTitulo = new System.Windows.Forms.Label();
            this.lblMantActivo = new System.Windows.Forms.Label();
            this.cmbMantActivo = new System.Windows.Forms.ComboBox();
            this.lblMantCodigo = new System.Windows.Forms.Label();
            this.txtMantCodigo = new System.Windows.Forms.TextBox();
            this.lblMantFecha = new System.Windows.Forms.Label();
            this.dtpMantFecha = new System.Windows.Forms.DateTimePicker();
            this.lblMantTipo = new System.Windows.Forms.Label();
            this.cmbMantTipo = new System.Windows.Forms.ComboBox();
            this.lblMantCosto = new System.Windows.Forms.Label();
            this.numMantCosto = new System.Windows.Forms.NumericUpDown();
            this.lblMantEstado = new System.Windows.Forms.Label();
            this.cmbMantEstado = new System.Windows.Forms.ComboBox();
            this.lblMantDesc = new System.Windows.Forms.Label();
            this.txtMantDesc = new System.Windows.Forms.TextBox();
            this.lblMantVinculo = new System.Windows.Forms.Label();
            this.btnMantRegistrar = new System.Windows.Forms.Button();
            this.btnMantLimpiar = new System.Windows.Forms.Button();
            this.tabReportes = new System.Windows.Forms.TabPage();
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            this.pnlRepFiltros = new System.Windows.Forms.Panel();
            this.lblRepTipo = new System.Windows.Forms.Label();
            this.cmbRepTipo = new System.Windows.Forms.ComboBox();
            this.lblRepSalon = new System.Windows.Forms.Label();
            this.cmbRepSalon = new System.Windows.Forms.ComboBox();
            this.lblRepDesde = new System.Windows.Forms.Label();
            this.dtpRepDesde = new System.Windows.Forms.DateTimePicker();
            this.lblRepHasta = new System.Windows.Forms.Label();
            this.dtpRepHasta = new System.Windows.Forms.DateTimePicker();
            this.btnRepGenerar = new System.Windows.Forms.Button();
            this.btnRepPdf = new System.Windows.Forms.Button();
            this.lblRepInfo = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlEncabezado.SuspendLayout();
            this.tlpKpis.SuspendLayout();
            this.pnlKpi1.SuspendLayout();
            this.pnlKpi2.SuspendLayout();
            this.pnlKpi3.SuspendLayout();
            this.pnlKpi4.SuspendLayout();
            this.pnlKpi5.SuspendLayout();
            this.tabPrincipal.SuspendLayout();
            this.tabCatalogo.SuspendLayout();
            this.pnlLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivos)).BeginInit();
            this.pnlFicha.SuspendLayout();
            this.tabFicha.SuspendLayout();
            this.tabUbicacion.SuspendLayout();
            this.pnlEstadoUnidad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUbicacion)).BeginInit();
            this.tabHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.tabDanos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanos)).BeginInit();
            this.pnlBusqueda.SuspendLayout();
            this.pnlFormulario.SuspendLayout();
            this.tabPrestamos.SuspendLayout();
            this.pnlPrestLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamos)).BeginInit();
            this.pnlDevolucion.SuspendLayout();
            this.pnlPrestFiltro.SuspendLayout();
            this.pnlPrestForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrestCant)).BeginInit();
            this.tabConsumibles.SuspendLayout();
            this.pnlConsLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKardex)).BeginInit();
            this.pnlKardexBarra.SuspendLayout();
            this.pnlStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            this.pnlConsForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numConsMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMovCant)).BeginInit();
            this.tabMantenimiento.SuspendLayout();
            this.pnlMantLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMantenimientos)).BeginInit();
            this.pnlMantReportes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMantReportes)).BeginInit();
            this.pnlMantForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMantCosto)).BeginInit();
            this.tabReportes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            this.pnlRepFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.Controls.Add(this.lblSubtitulo);
            this.pnlEncabezado.Controls.Add(this.lblTitulo);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Location = new System.Drawing.Point(0, 0);
            this.pnlEncabezado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(1640, 64);
            this.pnlEncabezado.TabIndex = 2;
            this.pnlEncabezado.Tag = "fondo";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.Silver;
            this.lblSubtitulo.Location = new System.Drawing.Point(455, 29);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(707, 23);
            this.lblSubtitulo.TabIndex = 0;
            this.lblSubtitulo.Text = "Catálogo, préstamos, consumibles, mantenimiento y reportes de los bienes de la in" +
    "stitución";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(7, 11);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(401, 41);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Gestión de activos escolares";
            // 
            // tlpKpis
            // 
            this.tlpKpis.ColumnCount = 5;
            this.tlpKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1512F));
            this.tlpKpis.Controls.Add(this.pnlKpi1, 0, 0);
            this.tlpKpis.Controls.Add(this.pnlKpi2, 1, 0);
            this.tlpKpis.Controls.Add(this.pnlKpi3, 2, 0);
            this.tlpKpis.Controls.Add(this.pnlKpi4, 3, 0);
            this.tlpKpis.Controls.Add(this.pnlKpi5, 4, 0);
            this.tlpKpis.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpKpis.Location = new System.Drawing.Point(0, 64);
            this.tlpKpis.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tlpKpis.Name = "tlpKpis";
            this.tlpKpis.Padding = new System.Windows.Forms.Padding(24, 0, 24, 6);
            this.tlpKpis.RowCount = 1;
            this.tlpKpis.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpKpis.Size = new System.Drawing.Size(1640, 80);
            this.tlpKpis.TabIndex = 1;
            this.tlpKpis.Tag = "fondo";
            // 
            // pnlKpi1
            // 
            this.pnlKpi1.Controls.Add(this.lblKpi1Txt);
            this.pnlKpi1.Controls.Add(this.lblKpi1);
            this.pnlKpi1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpi1.Location = new System.Drawing.Point(24, 0);
            this.pnlKpi1.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.pnlKpi1.Name = "pnlKpi1";
            this.pnlKpi1.Padding = new System.Windows.Forms.Padding(18, 6, 10, 5);
            this.pnlKpi1.Size = new System.Drawing.Size(8, 74);
            this.pnlKpi1.TabIndex = 0;
            this.pnlKpi1.Tag = "tarjeta";
            // 
            // lblKpi1Txt
            // 
            this.lblKpi1Txt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKpi1Txt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKpi1Txt.ForeColor = System.Drawing.Color.Silver;
            this.lblKpi1Txt.Location = new System.Drawing.Point(18, 24);
            this.lblKpi1Txt.Name = "lblKpi1Txt";
            this.lblKpi1Txt.Size = new System.Drawing.Size(0, 45);
            this.lblKpi1Txt.TabIndex = 0;
            this.lblKpi1Txt.Text = "Activos registrados";
            // 
            // lblKpi1
            // 
            this.lblKpi1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpi1.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold);
            this.lblKpi1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.lblKpi1.Location = new System.Drawing.Point(18, 6);
            this.lblKpi1.Name = "lblKpi1";
            this.lblKpi1.Size = new System.Drawing.Size(0, 18);
            this.lblKpi1.TabIndex = 1;
            this.lblKpi1.Text = "0";
            // 
            // pnlKpi2
            // 
            this.pnlKpi2.Controls.Add(this.lblKpi2Txt);
            this.pnlKpi2.Controls.Add(this.lblKpi2);
            this.pnlKpi2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpi2.Location = new System.Drawing.Point(44, 0);
            this.pnlKpi2.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.pnlKpi2.Name = "pnlKpi2";
            this.pnlKpi2.Padding = new System.Windows.Forms.Padding(18, 6, 10, 5);
            this.pnlKpi2.Size = new System.Drawing.Size(8, 74);
            this.pnlKpi2.TabIndex = 1;
            this.pnlKpi2.Tag = "tarjeta";
            // 
            // lblKpi2Txt
            // 
            this.lblKpi2Txt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKpi2Txt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKpi2Txt.ForeColor = System.Drawing.Color.Silver;
            this.lblKpi2Txt.Location = new System.Drawing.Point(18, 24);
            this.lblKpi2Txt.Name = "lblKpi2Txt";
            this.lblKpi2Txt.Size = new System.Drawing.Size(0, 45);
            this.lblKpi2Txt.TabIndex = 0;
            this.lblKpi2Txt.Text = "Préstamos activos";
            // 
            // lblKpi2
            // 
            this.lblKpi2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpi2.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold);
            this.lblKpi2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(90)))), ((int)(((byte)(242)))));
            this.lblKpi2.Location = new System.Drawing.Point(18, 6);
            this.lblKpi2.Name = "lblKpi2";
            this.lblKpi2.Size = new System.Drawing.Size(0, 18);
            this.lblKpi2.TabIndex = 1;
            this.lblKpi2.Text = "0";
            // 
            // pnlKpi3
            // 
            this.pnlKpi3.Controls.Add(this.lblKpi3Txt);
            this.pnlKpi3.Controls.Add(this.lblKpi3);
            this.pnlKpi3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpi3.Location = new System.Drawing.Point(64, 0);
            this.pnlKpi3.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.pnlKpi3.Name = "pnlKpi3";
            this.pnlKpi3.Padding = new System.Windows.Forms.Padding(18, 6, 10, 5);
            this.pnlKpi3.Size = new System.Drawing.Size(8, 74);
            this.pnlKpi3.TabIndex = 2;
            this.pnlKpi3.Tag = "tarjeta";
            // 
            // lblKpi3Txt
            // 
            this.lblKpi3Txt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKpi3Txt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKpi3Txt.ForeColor = System.Drawing.Color.Silver;
            this.lblKpi3Txt.Location = new System.Drawing.Point(18, 24);
            this.lblKpi3Txt.Name = "lblKpi3Txt";
            this.lblKpi3Txt.Size = new System.Drawing.Size(0, 45);
            this.lblKpi3Txt.TabIndex = 0;
            this.lblKpi3Txt.Text = "Préstamos atrasados";
            // 
            // lblKpi3
            // 
            this.lblKpi3.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpi3.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold);
            this.lblKpi3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(217)))), ((int)(((byte)(100)))));
            this.lblKpi3.Location = new System.Drawing.Point(18, 6);
            this.lblKpi3.Name = "lblKpi3";
            this.lblKpi3.Size = new System.Drawing.Size(0, 18);
            this.lblKpi3.TabIndex = 1;
            this.lblKpi3.Text = "0";
            // 
            // pnlKpi4
            // 
            this.pnlKpi4.Controls.Add(this.lblKpi4Txt);
            this.pnlKpi4.Controls.Add(this.lblKpi4);
            this.pnlKpi4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpi4.Location = new System.Drawing.Point(84, 0);
            this.pnlKpi4.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.pnlKpi4.Name = "pnlKpi4";
            this.pnlKpi4.Padding = new System.Windows.Forms.Padding(18, 6, 10, 5);
            this.pnlKpi4.Size = new System.Drawing.Size(8, 74);
            this.pnlKpi4.TabIndex = 3;
            this.pnlKpi4.Tag = "tarjeta";
            // 
            // lblKpi4Txt
            // 
            this.lblKpi4Txt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKpi4Txt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKpi4Txt.ForeColor = System.Drawing.Color.Silver;
            this.lblKpi4Txt.Location = new System.Drawing.Point(18, 24);
            this.lblKpi4Txt.Name = "lblKpi4Txt";
            this.lblKpi4Txt.Size = new System.Drawing.Size(0, 45);
            this.lblKpi4Txt.TabIndex = 0;
            this.lblKpi4Txt.Text = "Reportes de daño abiertos";
            // 
            // lblKpi4
            // 
            this.lblKpi4.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpi4.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold);
            this.lblKpi4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(10)))));
            this.lblKpi4.Location = new System.Drawing.Point(18, 6);
            this.lblKpi4.Name = "lblKpi4";
            this.lblKpi4.Size = new System.Drawing.Size(0, 18);
            this.lblKpi4.TabIndex = 1;
            this.lblKpi4.Text = "0";
            // 
            // pnlKpi5
            // 
            this.pnlKpi5.Controls.Add(this.lblKpi5Txt);
            this.pnlKpi5.Controls.Add(this.lblKpi5);
            this.pnlKpi5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpi5.Location = new System.Drawing.Point(104, 0);
            this.pnlKpi5.Margin = new System.Windows.Forms.Padding(0);
            this.pnlKpi5.Name = "pnlKpi5";
            this.pnlKpi5.Padding = new System.Windows.Forms.Padding(18, 6, 10, 5);
            this.pnlKpi5.Size = new System.Drawing.Size(1512, 74);
            this.pnlKpi5.TabIndex = 4;
            this.pnlKpi5.Tag = "tarjeta";
            // 
            // lblKpi5Txt
            // 
            this.lblKpi5Txt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKpi5Txt.ForeColor = System.Drawing.Color.Silver;
            this.lblKpi5Txt.Location = new System.Drawing.Point(21, 28);
            this.lblKpi5Txt.Name = "lblKpi5Txt";
            this.lblKpi5Txt.Size = new System.Drawing.Size(273, 19);
            this.lblKpi5Txt.TabIndex = 2;
            this.lblKpi5Txt.Text = "Consumibles en alerta de stock";
            // 
            // lblKpi5
            // 
            this.lblKpi5.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold);
            this.lblKpi5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(217)))), ((int)(((byte)(100)))));
            this.lblKpi5.Location = new System.Drawing.Point(324, 15);
            this.lblKpi5.Name = "lblKpi5";
            this.lblKpi5.Size = new System.Drawing.Size(68, 44);
            this.lblKpi5.TabIndex = 1;
            this.lblKpi5.Text = "0";
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Controls.Add(this.tabCatalogo);
            this.tabPrincipal.Controls.Add(this.tabPrestamos);
            this.tabPrincipal.Controls.Add(this.tabConsumibles);
            this.tabPrincipal.Controls.Add(this.tabMantenimiento);
            this.tabPrincipal.Controls.Add(this.tabReportes);
            this.tabPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPrincipal.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabPrincipal.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.tabPrincipal.ItemSize = new System.Drawing.Size(190, 36);
            this.tabPrincipal.Location = new System.Drawing.Point(0, 144);
            this.tabPrincipal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.SelectedIndex = 0;
            this.tabPrincipal.Size = new System.Drawing.Size(1640, 544);
            this.tabPrincipal.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabPrincipal.TabIndex = 0;
            this.tabPrincipal.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tab_DrawItem);
            // 
            // tabCatalogo
            // 
            this.tabCatalogo.Controls.Add(this.pnlLista);
            this.tabCatalogo.Controls.Add(this.pnlFormulario);
            this.tabCatalogo.Location = new System.Drawing.Point(4, 40);
            this.tabCatalogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabCatalogo.Name = "tabCatalogo";
            this.tabCatalogo.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.tabCatalogo.Size = new System.Drawing.Size(1632, 500);
            this.tabCatalogo.TabIndex = 0;
            this.tabCatalogo.Text = "1. Catálogo";
            // 
            // pnlLista
            // 
            this.pnlLista.Controls.Add(this.dgvActivos);
            this.pnlLista.Controls.Add(this.pnlSeparador);
            this.pnlLista.Controls.Add(this.pnlFicha);
            this.pnlLista.Controls.Add(this.pnlBusqueda);
            this.pnlLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLista.Location = new System.Drawing.Point(396, 10);
            this.pnlLista.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlLista.Name = "pnlLista";
            this.pnlLista.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.pnlLista.Size = new System.Drawing.Size(1220, 480);
            this.pnlLista.TabIndex = 0;
            // 
            // dgvActivos
            // 
            this.dgvActivos.ColumnHeadersHeight = 29;
            this.dgvActivos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvActivos.Location = new System.Drawing.Point(16, 51);
            this.dgvActivos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvActivos.Name = "dgvActivos";
            this.dgvActivos.RowHeadersWidth = 51;
            this.dgvActivos.Size = new System.Drawing.Size(1204, 237);
            this.dgvActivos.TabIndex = 0;
            this.dgvActivos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvActivos_CellClick);
            this.dgvActivos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvActivos_CellFormatting);
            // 
            // pnlSeparador
            // 
            this.pnlSeparador.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSeparador.Location = new System.Drawing.Point(16, 288);
            this.pnlSeparador.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlSeparador.Name = "pnlSeparador";
            this.pnlSeparador.Size = new System.Drawing.Size(1204, 8);
            this.pnlSeparador.TabIndex = 1;
            // 
            // pnlFicha
            // 
            this.pnlFicha.Controls.Add(this.tabFicha);
            this.pnlFicha.Controls.Add(this.lblFichaTitulo);
            this.pnlFicha.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFicha.Location = new System.Drawing.Point(16, 296);
            this.pnlFicha.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlFicha.Name = "pnlFicha";
            this.pnlFicha.Size = new System.Drawing.Size(1204, 184);
            this.pnlFicha.TabIndex = 2;
            this.pnlFicha.Tag = "tarjeta";
            // 
            // tabFicha
            // 
            this.tabFicha.Controls.Add(this.tabUbicacion);
            this.tabFicha.Controls.Add(this.tabHistorial);
            this.tabFicha.Controls.Add(this.tabDanos);
            this.tabFicha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFicha.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabFicha.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.tabFicha.ItemSize = new System.Drawing.Size(170, 28);
            this.tabFicha.Location = new System.Drawing.Point(0, 29);
            this.tabFicha.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabFicha.Name = "tabFicha";
            this.tabFicha.SelectedIndex = 0;
            this.tabFicha.Size = new System.Drawing.Size(1204, 155);
            this.tabFicha.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabFicha.TabIndex = 0;
            this.tabFicha.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tab_DrawItem);
            // 
            // tabUbicacion
            // 
            this.tabUbicacion.Controls.Add(this.dgvUbicacion);
            this.tabUbicacion.Controls.Add(this.pnlEstadoUnidad);
            this.tabUbicacion.Location = new System.Drawing.Point(4, 32);
            this.tabUbicacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabUbicacion.Name = "tabUbicacion";
            this.tabUbicacion.Size = new System.Drawing.Size(1196, 119);
            this.tabUbicacion.TabIndex = 0;
            this.tabUbicacion.Text = "Ubicación";
            // 
            // dgvUbicacion
            // 
            this.dgvUbicacion.ColumnHeadersHeight = 29;
            this.dgvUbicacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUbicacion.Location = new System.Drawing.Point(0, 0);
            this.dgvUbicacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvUbicacion.Name = "dgvUbicacion";
            this.dgvUbicacion.RowHeadersWidth = 51;
            this.dgvUbicacion.Size = new System.Drawing.Size(1196, 119);
            this.dgvUbicacion.TabIndex = 0;
            // 
            // pnlEstadoUnidad  (cambio de estado de UNA unidad)
            // 
            this.pnlEstadoUnidad.Controls.Add(this.lblEstadoUnidad);
            this.pnlEstadoUnidad.Controls.Add(this.cmbEstadoUnidad);
            this.pnlEstadoUnidad.Controls.Add(this.btnCambiarEstadoUnidad);
            this.pnlEstadoUnidad.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlEstadoUnidad.Location = new System.Drawing.Point(0, 85);
            this.pnlEstadoUnidad.Name = "pnlEstadoUnidad";
            this.pnlEstadoUnidad.Size = new System.Drawing.Size(1196, 34);
            this.pnlEstadoUnidad.TabIndex = 1;
            // 
            // lblEstadoUnidad
            // 
            this.lblEstadoUnidad.AutoSize = true;
            this.lblEstadoUnidad.ForeColor = System.Drawing.Color.White;
            this.lblEstadoUnidad.Location = new System.Drawing.Point(8, 9);
            this.lblEstadoUnidad.Name = "lblEstadoUnidad";
            this.lblEstadoUnidad.Size = new System.Drawing.Size(235, 23);
            this.lblEstadoUnidad.TabIndex = 0;
            this.lblEstadoUnidad.Text = "Estado de la unidad seleccionada:";
            // 
            // cmbEstadoUnidad
            // 
            this.cmbEstadoUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoUnidad.FormattingEnabled = true;
            this.cmbEstadoUnidad.Location = new System.Drawing.Point(280, 4);
            this.cmbEstadoUnidad.Name = "cmbEstadoUnidad";
            this.cmbEstadoUnidad.Size = new System.Drawing.Size(220, 31);
            this.cmbEstadoUnidad.TabIndex = 1;
            // 
            // btnCambiarEstadoUnidad
            // 
            this.btnCambiarEstadoUnidad.Location = new System.Drawing.Point(515, 3);
            this.btnCambiarEstadoUnidad.Name = "btnCambiarEstadoUnidad";
            this.btnCambiarEstadoUnidad.Size = new System.Drawing.Size(150, 28);
            this.btnCambiarEstadoUnidad.TabIndex = 2;
            this.btnCambiarEstadoUnidad.Text = "Cambiar estado";
            this.btnCambiarEstadoUnidad.Click += new System.EventHandler(this.btnCambiarEstadoUnidad_Click);
            // 
            // tabHistorial
            // 
            this.tabHistorial.Controls.Add(this.dgvHistorial);
            this.tabHistorial.Location = new System.Drawing.Point(4, 32);
            this.tabHistorial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabHistorial.Name = "tabHistorial";
            this.tabHistorial.Size = new System.Drawing.Size(1196, 119);
            this.tabHistorial.TabIndex = 1;
            this.tabHistorial.Text = "Historial de cambios";
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.ColumnHeadersHeight = 29;
            this.dgvHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistorial.Location = new System.Drawing.Point(0, 0);
            this.dgvHistorial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.RowHeadersWidth = 51;
            this.dgvHistorial.Size = new System.Drawing.Size(1196, 119);
            this.dgvHistorial.TabIndex = 0;
            // 
            // tabDanos
            // 
            this.tabDanos.Controls.Add(this.dgvDanos);
            this.tabDanos.Location = new System.Drawing.Point(4, 32);
            this.tabDanos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabDanos.Name = "tabDanos";
            this.tabDanos.Size = new System.Drawing.Size(1196, 119);
            this.tabDanos.TabIndex = 2;
            this.tabDanos.Text = "Reportes de daño";
            // 
            // dgvDanos
            // 
            this.dgvDanos.ColumnHeadersHeight = 29;
            this.dgvDanos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDanos.Location = new System.Drawing.Point(0, 0);
            this.dgvDanos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvDanos.Name = "dgvDanos";
            this.dgvDanos.RowHeadersWidth = 51;
            this.dgvDanos.Size = new System.Drawing.Size(1196, 119);
            this.dgvDanos.TabIndex = 0;
            // 
            // lblFichaTitulo
            // 
            this.lblFichaTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFichaTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblFichaTitulo.Name = "lblFichaTitulo";
            this.lblFichaTitulo.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblFichaTitulo.Size = new System.Drawing.Size(1204, 29);
            this.lblFichaTitulo.TabIndex = 1;
            this.lblFichaTitulo.Tag = "barra";
            this.lblFichaTitulo.Text = "Seleccione un activo para ver su ficha";
            this.lblFichaTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlBusqueda
            // 
            this.pnlBusqueda.Controls.Add(this.lblBuscar);
            this.pnlBusqueda.Controls.Add(this.txtBuscar);
            this.pnlBusqueda.Controls.Add(this.cmbFiltroCategoria);
            this.pnlBusqueda.Controls.Add(this.cmbFiltroEstado);
            this.pnlBusqueda.Controls.Add(this.lblResultados);
            this.pnlBusqueda.Controls.Add(this.btnExportarPdf);
            this.pnlBusqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBusqueda.Location = new System.Drawing.Point(16, 0);
            this.pnlBusqueda.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlBusqueda.Name = "pnlBusqueda";
            this.pnlBusqueda.Size = new System.Drawing.Size(1204, 51);
            this.pnlBusqueda.TabIndex = 3;
            this.pnlBusqueda.Tag = "tarjeta";
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(16, 18);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(66, 25);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Tag = "campo";
            this.lblBuscar.Text = "Buscar";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(72, 13);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(220, 31);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // cmbFiltroCategoria
            // 
            this.cmbFiltroCategoria.Location = new System.Drawing.Point(304, 13);
            this.cmbFiltroCategoria.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbFiltroCategoria.Name = "cmbFiltroCategoria";
            this.cmbFiltroCategoria.Size = new System.Drawing.Size(190, 31);
            this.cmbFiltroCategoria.TabIndex = 2;
            this.cmbFiltroCategoria.SelectedIndexChanged += new System.EventHandler(this.cmbFiltro_SelectedIndexChanged);
            // 
            // cmbFiltroEstado
            // 
            this.cmbFiltroEstado.Location = new System.Drawing.Point(506, 13);
            this.cmbFiltroEstado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbFiltroEstado.Name = "cmbFiltroEstado";
            this.cmbFiltroEstado.Size = new System.Drawing.Size(170, 31);
            this.cmbFiltroEstado.TabIndex = 3;
            this.cmbFiltroEstado.SelectedIndexChanged += new System.EventHandler(this.cmbFiltro_SelectedIndexChanged);
            // 
            // lblResultados
            // 
            this.lblResultados.AutoSize = true;
            this.lblResultados.Location = new System.Drawing.Point(692, 18);
            this.lblResultados.Name = "lblResultados";
            this.lblResultados.Size = new System.Drawing.Size(114, 25);
            this.lblResultados.TabIndex = 4;
            this.lblResultados.Tag = "info";
            this.lblResultados.Text = "0 resultados";
            // 
            // btnExportarPdf
            // 
            this.btnExportarPdf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarPdf.Location = new System.Drawing.Point(1044, 10);
            this.btnExportarPdf.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExportarPdf.Name = "btnExportarPdf";
            this.btnExportarPdf.Size = new System.Drawing.Size(150, 32);
            this.btnExportarPdf.TabIndex = 5;
            this.btnExportarPdf.Tag = "secundario";
            this.btnExportarPdf.Text = "Exportar a PDF";
            this.btnExportarPdf.Click += new System.EventHandler(this.btnExportarPdf_Click);
            // 
            // pnlFormulario
            // 
            this.pnlFormulario.AutoScroll = true;
            this.pnlFormulario.Controls.Add(this.lblModo);
            this.pnlFormulario.Controls.Add(this.lblCodigo);
            this.pnlFormulario.Controls.Add(this.txtCodigo);
            this.pnlFormulario.Controls.Add(this.lblNombre);
            this.pnlFormulario.Controls.Add(this.txtNombre);
            this.pnlFormulario.Controls.Add(this.lblCategoria);
            this.pnlFormulario.Controls.Add(this.cmbCategoria);
            this.pnlFormulario.Controls.Add(this.lblEstado);
            this.pnlFormulario.Controls.Add(this.cmbEstado);
            this.pnlFormulario.Controls.Add(this.lblUbicacion);
            this.pnlFormulario.Controls.Add(this.cmbUbicacion);
            this.pnlFormulario.Controls.Add(this.btnGuardar);
            this.pnlFormulario.Controls.Add(this.btnActualizar);
            this.pnlFormulario.Controls.Add(this.btnEliminar);
            this.pnlFormulario.Controls.Add(this.btnLimpiar);
            this.pnlFormulario.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFormulario.Location = new System.Drawing.Point(16, 10);
            this.pnlFormulario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlFormulario.Name = "pnlFormulario";
            this.pnlFormulario.Size = new System.Drawing.Size(380, 480);
            this.pnlFormulario.TabIndex = 1;
            this.pnlFormulario.Tag = "tarjeta";
            // 
            // lblModo
            // 
            this.lblModo.AutoSize = true;
            this.lblModo.Location = new System.Drawing.Point(24, 11);
            this.lblModo.Name = "lblModo";
            this.lblModo.Size = new System.Drawing.Size(121, 25);
            this.lblModo.TabIndex = 0;
            this.lblModo.Tag = "seccion";
            this.lblModo.Text = "Nuevo activo";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(24, 42);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(364, 25);
            this.lblCodigo.TabIndex = 1;
            this.lblCodigo.Tag = "campo";
            this.lblCodigo.Text = "Código de inventario (vacío = automático)";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(24, 59);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCodigo.MaxLength = 50;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(332, 31);
            this.txtCodigo.TabIndex = 0;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(24, 91);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(166, 25);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Tag = "campo";
            this.lblNombre.Text = "Nombre del activo";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(24, 109);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(332, 31);
            this.txtNombre.TabIndex = 1;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(24, 141);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(92, 25);
            this.lblCategoria.TabIndex = 3;
            this.lblCategoria.Tag = "campo";
            this.lblCategoria.Text = "Categoría";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.Location = new System.Drawing.Point(24, 158);
            this.cmbCategoria.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(332, 31);
            this.cmbCategoria.TabIndex = 2;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(24, 190);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(115, 25);
            this.lblEstado.TabIndex = 4;
            this.lblEstado.Tag = "campo";
            this.lblEstado.Text = "Estado físico";
            this.lblEstado.Visible = false;
            // 
            // cmbEstado
            // 
            this.cmbEstado.Location = new System.Drawing.Point(24, 208);
            this.cmbEstado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(332, 31);
            this.cmbEstado.TabIndex = 3;
            this.cmbEstado.Visible = false;
            // 
            // lblUbicacion
            // 
            this.lblUbicacion.AutoSize = true;
            this.lblUbicacion.Location = new System.Drawing.Point(24, 240);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Size = new System.Drawing.Size(232, 25);
            this.lblUbicacion.TabIndex = 5;
            this.lblUbicacion.Tag = "campo";
            this.lblUbicacion.Text = "Ubicación predeterminada";
            // 
            // cmbUbicacion
            // 
            this.cmbUbicacion.Location = new System.Drawing.Point(24, 258);
            this.cmbUbicacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbUbicacion.Name = "cmbUbicacion";
            this.cmbUbicacion.Size = new System.Drawing.Size(332, 31);
            this.cmbUbicacion.TabIndex = 4;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(24, 299);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(332, 34);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Agregar activo";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(24, 339);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(160, 34);
            this.btnActualizar.TabIndex = 6;
            this.btnActualizar.Tag = "ok";
            this.btnActualizar.Text = "Guardar cambios";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(196, 339);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(160, 34);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Tag = "peligro";
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(24, 379);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(332, 30);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Tag = "secundario";
            this.btnLimpiar.Text = "Nuevo / limpiar formulario";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // tabPrestamos
            // 
            this.tabPrestamos.Controls.Add(this.pnlPrestLista);
            this.tabPrestamos.Controls.Add(this.pnlPrestForm);
            this.tabPrestamos.Location = new System.Drawing.Point(4, 40);
            this.tabPrestamos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPrestamos.Name = "tabPrestamos";
            this.tabPrestamos.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.tabPrestamos.Size = new System.Drawing.Size(1632, 500);
            this.tabPrestamos.TabIndex = 1;
            this.tabPrestamos.Text = "2. Préstamos";
            // 
            // pnlPrestLista
            // 
            this.pnlPrestLista.Controls.Add(this.dgvPrestamos);
            this.pnlPrestLista.Controls.Add(this.pnlDevolucion);
            this.pnlPrestLista.Controls.Add(this.pnlPrestFiltro);
            this.pnlPrestLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrestLista.Location = new System.Drawing.Point(396, 10);
            this.pnlPrestLista.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlPrestLista.Name = "pnlPrestLista";
            this.pnlPrestLista.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.pnlPrestLista.Size = new System.Drawing.Size(1220, 480);
            this.pnlPrestLista.TabIndex = 0;
            // 
            // dgvPrestamos
            // 
            this.dgvPrestamos.ColumnHeadersHeight = 29;
            this.dgvPrestamos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPrestamos.Location = new System.Drawing.Point(16, 45);
            this.dgvPrestamos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvPrestamos.Name = "dgvPrestamos";
            this.dgvPrestamos.RowHeadersWidth = 51;
            this.dgvPrestamos.Size = new System.Drawing.Size(1204, 339);
            this.dgvPrestamos.TabIndex = 0;
            this.dgvPrestamos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPrestamos_CellFormatting);
            this.dgvPrestamos.SelectionChanged += new System.EventHandler(this.dgvPrestamos_SelectionChanged);
            // 
            // pnlDevolucion
            // 
            this.pnlDevolucion.Controls.Add(this.lblDevSel);
            this.pnlDevolucion.Controls.Add(this.lblDevEstado);
            this.pnlDevolucion.Controls.Add(this.cmbDevEstado);
            this.pnlDevolucion.Controls.Add(this.lblDevObs);
            this.pnlDevolucion.Controls.Add(this.txtDevObs);
            this.pnlDevolucion.Controls.Add(this.btnDevolver);
            this.pnlDevolucion.Controls.Add(this.btnHoja);
            this.pnlDevolucion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDevolucion.Location = new System.Drawing.Point(16, 384);
            this.pnlDevolucion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlDevolucion.Name = "pnlDevolucion";
            this.pnlDevolucion.Size = new System.Drawing.Size(1204, 96);
            this.pnlDevolucion.TabIndex = 1;
            this.pnlDevolucion.Tag = "tarjeta";
            // 
            // lblDevSel
            // 
            this.lblDevSel.AutoSize = true;
            this.lblDevSel.Location = new System.Drawing.Point(16, 8);
            this.lblDevSel.Name = "lblDevSel";
            this.lblDevSel.Size = new System.Drawing.Size(502, 25);
            this.lblDevSel.TabIndex = 0;
            this.lblDevSel.Tag = "barra";
            this.lblDevSel.Text = "Seleccione un préstamo para devolverlo o imprimir su hoja";
            // 
            // lblDevEstado
            // 
            this.lblDevEstado.AutoSize = true;
            this.lblDevEstado.Location = new System.Drawing.Point(16, 35);
            this.lblDevEstado.Name = "lblDevEstado";
            this.lblDevEstado.Size = new System.Drawing.Size(211, 25);
            this.lblDevEstado.TabIndex = 1;
            this.lblDevEstado.Tag = "campo";
            this.lblDevEstado.Text = "Estado físico al devolver";
            // 
            // cmbDevEstado
            // 
            this.cmbDevEstado.Location = new System.Drawing.Point(16, 53);
            this.cmbDevEstado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbDevEstado.Name = "cmbDevEstado";
            this.cmbDevEstado.Size = new System.Drawing.Size(210, 31);
            this.cmbDevEstado.TabIndex = 2;
            // 
            // lblDevObs
            // 
            this.lblDevObs.AutoSize = true;
            this.lblDevObs.Location = new System.Drawing.Point(246, 35);
            this.lblDevObs.Name = "lblDevObs";
            this.lblDevObs.Size = new System.Drawing.Size(258, 25);
            this.lblDevObs.TabIndex = 3;
            this.lblDevObs.Tag = "campo";
            this.lblDevObs.Text = "Observación de la devolución";
            // 
            // txtDevObs
            // 
            this.txtDevObs.Location = new System.Drawing.Point(246, 53);
            this.txtDevObs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDevObs.MaxLength = 300;
            this.txtDevObs.Name = "txtDevObs";
            this.txtDevObs.Size = new System.Drawing.Size(340, 31);
            this.txtDevObs.TabIndex = 4;
            // 
            // btnDevolver
            // 
            this.btnDevolver.Location = new System.Drawing.Point(606, 48);
            this.btnDevolver.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(170, 34);
            this.btnDevolver.TabIndex = 5;
            this.btnDevolver.Tag = "ok";
            this.btnDevolver.Text = "Registrar devolución";
            this.btnDevolver.Click += new System.EventHandler(this.btnDevolver_Click);
            // 
            // btnHoja
            // 
            this.btnHoja.Location = new System.Drawing.Point(786, 48);
            this.btnHoja.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHoja.Name = "btnHoja";
            this.btnHoja.Size = new System.Drawing.Size(200, 34);
            this.btnHoja.TabIndex = 6;
            this.btnHoja.Tag = "secundario";
            this.btnHoja.Text = "Hoja de resguardo (PDF)";
            this.btnHoja.Click += new System.EventHandler(this.btnHoja_Click);
            // 
            // pnlPrestFiltro
            // 
            this.pnlPrestFiltro.Controls.Add(this.lblPrestVer);
            this.pnlPrestFiltro.Controls.Add(this.cmbPrestVer);
            this.pnlPrestFiltro.Controls.Add(this.lblPrestAlertas);
            this.pnlPrestFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPrestFiltro.Location = new System.Drawing.Point(16, 0);
            this.pnlPrestFiltro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlPrestFiltro.Name = "pnlPrestFiltro";
            this.pnlPrestFiltro.Size = new System.Drawing.Size(1204, 45);
            this.pnlPrestFiltro.TabIndex = 2;
            this.pnlPrestFiltro.Tag = "tarjeta";
            // 
            // lblPrestVer
            // 
            this.lblPrestVer.AutoSize = true;
            this.lblPrestVer.Location = new System.Drawing.Point(16, 14);
            this.lblPrestVer.Name = "lblPrestVer";
            this.lblPrestVer.Size = new System.Drawing.Size(78, 25);
            this.lblPrestVer.TabIndex = 0;
            this.lblPrestVer.Tag = "campo";
            this.lblPrestVer.Text = "Mostrar";
            // 
            // cmbPrestVer
            // 
            this.cmbPrestVer.Location = new System.Drawing.Point(80, 10);
            this.cmbPrestVer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbPrestVer.Name = "cmbPrestVer";
            this.cmbPrestVer.Size = new System.Drawing.Size(170, 31);
            this.cmbPrestVer.TabIndex = 1;
            this.cmbPrestVer.SelectedIndexChanged += new System.EventHandler(this.cmbPrestVer_SelectedIndexChanged);
            // 
            // lblPrestAlertas
            // 
            this.lblPrestAlertas.AutoSize = true;
            this.lblPrestAlertas.Location = new System.Drawing.Point(270, 14);
            this.lblPrestAlertas.Name = "lblPrestAlertas";
            this.lblPrestAlertas.Size = new System.Drawing.Size(0, 25);
            this.lblPrestAlertas.TabIndex = 2;
            this.lblPrestAlertas.Tag = "info";
            // 
            // pnlPrestForm
            // 
            this.pnlPrestForm.AutoScroll = true;
            this.pnlPrestForm.Controls.Add(this.lblPrestTitulo);
            this.pnlPrestForm.Controls.Add(this.lblPrestActivo);
            this.pnlPrestForm.Controls.Add(this.cmbPrestActivo);
            this.pnlPrestForm.Controls.Add(this.lblPrestCodigo);
            this.pnlPrestForm.Controls.Add(this.txtPrestCodigo);
            this.pnlPrestForm.Controls.Add(this.lblPrestCant);
            this.pnlPrestForm.Controls.Add(this.numPrestCant);
            this.pnlPrestForm.Controls.Add(this.lblPrestTipo);
            this.pnlPrestForm.Controls.Add(this.cmbPrestTipo);
            this.pnlPrestForm.Controls.Add(this.lblPrestResp);
            this.pnlPrestForm.Controls.Add(this.txtPrestResp);
            this.pnlPrestForm.Controls.Add(this.lblPrestAula);
            this.pnlPrestForm.Controls.Add(this.cmbPrestAula);
            this.pnlPrestForm.Controls.Add(this.lblPrestLimite);
            this.pnlPrestForm.Controls.Add(this.dtpPrestLimite);
            this.pnlPrestForm.Controls.Add(this.lblPrestObs);
            this.pnlPrestForm.Controls.Add(this.txtPrestObs);
            this.pnlPrestForm.Controls.Add(this.btnPrestar);
            this.pnlPrestForm.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlPrestForm.Location = new System.Drawing.Point(16, 10);
            this.pnlPrestForm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlPrestForm.Name = "pnlPrestForm";
            this.pnlPrestForm.Size = new System.Drawing.Size(380, 480);
            this.pnlPrestForm.TabIndex = 1;
            this.pnlPrestForm.Tag = "tarjeta";
            // 
            // lblPrestTitulo
            // 
            this.lblPrestTitulo.AutoSize = true;
            this.lblPrestTitulo.Location = new System.Drawing.Point(24, 11);
            this.lblPrestTitulo.Name = "lblPrestTitulo";
            this.lblPrestTitulo.Size = new System.Drawing.Size(229, 25);
            this.lblPrestTitulo.TabIndex = 0;
            this.lblPrestTitulo.Tag = "seccion";
            this.lblPrestTitulo.Text = "Registrar salida de equipo";
            // 
            // lblPrestActivo
            // 
            this.lblPrestActivo.AutoSize = true;
            this.lblPrestActivo.Location = new System.Drawing.Point(24, 42);
            this.lblPrestActivo.Name = "lblPrestActivo";
            this.lblPrestActivo.Size = new System.Drawing.Size(148, 25);
            this.lblPrestActivo.TabIndex = 1;
            this.lblPrestActivo.Tag = "campo";
            this.lblPrestActivo.Text = "Equipo a prestar";
            // 
            // cmbPrestActivo
            // 
            this.cmbPrestActivo.Location = new System.Drawing.Point(24, 59);
            this.cmbPrestActivo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbPrestActivo.Name = "cmbPrestActivo";
            this.cmbPrestActivo.Size = new System.Drawing.Size(332, 31);
            this.cmbPrestActivo.TabIndex = 2;
            // 
            // lblPrestCodigo
            // 
            this.lblPrestCodigo.AutoSize = true;
            this.lblPrestCodigo.Location = new System.Drawing.Point(24, 91);
            this.lblPrestCodigo.Name = "lblPrestCodigo";
            this.lblPrestCodigo.Size = new System.Drawing.Size(255, 25);
            this.lblPrestCodigo.TabIndex = 3;
            this.lblPrestCodigo.Tag = "campo";
            this.lblPrestCodigo.Text = "Código del equipo (opcional)";
            // 
            // txtPrestCodigo
            // 
            this.txtPrestCodigo.Location = new System.Drawing.Point(24, 109);
            this.txtPrestCodigo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrestCodigo.MaxLength = 50;
            this.txtPrestCodigo.Name = "txtPrestCodigo";
            this.txtPrestCodigo.Size = new System.Drawing.Size(190, 31);
            this.txtPrestCodigo.TabIndex = 4;
            // 
            // lblPrestCant
            // 
            this.lblPrestCant.AutoSize = true;
            this.lblPrestCant.Location = new System.Drawing.Point(230, 91);
            this.lblPrestCant.Name = "lblPrestCant";
            this.lblPrestCant.Size = new System.Drawing.Size(86, 25);
            this.lblPrestCant.TabIndex = 5;
            this.lblPrestCant.Tag = "campo";
            this.lblPrestCant.Text = "Cantidad";
            // 
            // numPrestCant
            // 
            this.numPrestCant.Location = new System.Drawing.Point(230, 109);
            this.numPrestCant.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numPrestCant.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numPrestCant.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPrestCant.Name = "numPrestCant";
            this.numPrestCant.Size = new System.Drawing.Size(126, 31);
            this.numPrestCant.TabIndex = 6;
            this.numPrestCant.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblPrestTipo
            // 
            this.lblPrestTipo.AutoSize = true;
            this.lblPrestTipo.Location = new System.Drawing.Point(24, 141);
            this.lblPrestTipo.Name = "lblPrestTipo";
            this.lblPrestTipo.Size = new System.Drawing.Size(181, 25);
            this.lblPrestTipo.TabIndex = 7;
            this.lblPrestTipo.Tag = "campo";
            this.lblPrestTipo.Text = "Tipo de responsable";
            // 
            // cmbPrestTipo
            // 
            this.cmbPrestTipo.Location = new System.Drawing.Point(24, 158);
            this.cmbPrestTipo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbPrestTipo.Name = "cmbPrestTipo";
            this.cmbPrestTipo.Size = new System.Drawing.Size(332, 31);
            this.cmbPrestTipo.TabIndex = 8;
            // 
            // lblPrestResp
            // 
            this.lblPrestResp.AutoSize = true;
            this.lblPrestResp.Location = new System.Drawing.Point(24, 190);
            this.lblPrestResp.Name = "lblPrestResp";
            this.lblPrestResp.Size = new System.Drawing.Size(218, 25);
            this.lblPrestResp.TabIndex = 9;
            this.lblPrestResp.Tag = "campo";
            this.lblPrestResp.Text = "Nombre del responsable";
            // 
            // txtPrestResp
            // 
            this.txtPrestResp.Location = new System.Drawing.Point(24, 208);
            this.txtPrestResp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrestResp.MaxLength = 100;
            this.txtPrestResp.Name = "txtPrestResp";
            this.txtPrestResp.Size = new System.Drawing.Size(332, 31);
            this.txtPrestResp.TabIndex = 10;
            // 
            // lblPrestAula
            // 
            this.lblPrestAula.AutoSize = true;
            this.lblPrestAula.Location = new System.Drawing.Point(24, 240);
            this.lblPrestAula.Name = "lblPrestAula";
            this.lblPrestAula.Size = new System.Drawing.Size(143, 25);
            this.lblPrestAula.TabIndex = 11;
            this.lblPrestAula.Tag = "campo";
            this.lblPrestAula.Text = "Aula de destino";
            // 
            // cmbPrestAula
            // 
            this.cmbPrestAula.Location = new System.Drawing.Point(24, 258);
            this.cmbPrestAula.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbPrestAula.Name = "cmbPrestAula";
            this.cmbPrestAula.Size = new System.Drawing.Size(332, 31);
            this.cmbPrestAula.TabIndex = 12;
            // 
            // lblPrestLimite
            // 
            this.lblPrestLimite.AutoSize = true;
            this.lblPrestLimite.Location = new System.Drawing.Point(24, 290);
            this.lblPrestLimite.Name = "lblPrestLimite";
            this.lblPrestLimite.Size = new System.Drawing.Size(290, 25);
            this.lblPrestLimite.TabIndex = 13;
            this.lblPrestLimite.Tag = "campo";
            this.lblPrestLimite.Text = "Fecha y hora límite de devolución";
            // 
            // dtpPrestLimite
            // 
            this.dtpPrestLimite.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpPrestLimite.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPrestLimite.Location = new System.Drawing.Point(24, 307);
            this.dtpPrestLimite.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpPrestLimite.Name = "dtpPrestLimite";
            this.dtpPrestLimite.Size = new System.Drawing.Size(332, 31);
            this.dtpPrestLimite.TabIndex = 14;
            // 
            // lblPrestObs
            // 
            this.lblPrestObs.AutoSize = true;
            this.lblPrestObs.Location = new System.Drawing.Point(24, 339);
            this.lblPrestObs.Name = "lblPrestObs";
            this.lblPrestObs.Size = new System.Drawing.Size(134, 25);
            this.lblPrestObs.TabIndex = 15;
            this.lblPrestObs.Tag = "campo";
            this.lblPrestObs.Text = "Observaciones";
            // 
            // txtPrestObs
            // 
            this.txtPrestObs.Location = new System.Drawing.Point(24, 357);
            this.txtPrestObs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrestObs.MaxLength = 300;
            this.txtPrestObs.Name = "txtPrestObs";
            this.txtPrestObs.Size = new System.Drawing.Size(332, 31);
            this.txtPrestObs.TabIndex = 16;
            // 
            // btnPrestar
            // 
            this.btnPrestar.Location = new System.Drawing.Point(24, 397);
            this.btnPrestar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrestar.Name = "btnPrestar";
            this.btnPrestar.Size = new System.Drawing.Size(332, 35);
            this.btnPrestar.TabIndex = 17;
            this.btnPrestar.Text = "Registrar salida";
            this.btnPrestar.Click += new System.EventHandler(this.btnPrestar_Click);
            // 
            // tabConsumibles
            // 
            this.tabConsumibles.Controls.Add(this.pnlConsLista);
            this.tabConsumibles.Controls.Add(this.pnlConsForm);
            this.tabConsumibles.Location = new System.Drawing.Point(4, 40);
            this.tabConsumibles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabConsumibles.Name = "tabConsumibles";
            this.tabConsumibles.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.tabConsumibles.Size = new System.Drawing.Size(1632, 500);
            this.tabConsumibles.TabIndex = 2;
            this.tabConsumibles.Text = "3. Consumibles";
            // 
            // pnlConsLista
            // 
            this.pnlConsLista.Controls.Add(this.dgvKardex);
            this.pnlConsLista.Controls.Add(this.pnlKardexBarra);
            this.pnlConsLista.Controls.Add(this.pnlStock);
            this.pnlConsLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConsLista.Location = new System.Drawing.Point(396, 10);
            this.pnlConsLista.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlConsLista.Name = "pnlConsLista";
            this.pnlConsLista.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.pnlConsLista.Size = new System.Drawing.Size(1220, 480);
            this.pnlConsLista.TabIndex = 0;
            // 
            // dgvKardex
            // 
            this.dgvKardex.ColumnHeadersHeight = 29;
            this.dgvKardex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKardex.Location = new System.Drawing.Point(16, 232);
            this.dgvKardex.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvKardex.Name = "dgvKardex";
            this.dgvKardex.RowHeadersWidth = 51;
            this.dgvKardex.Size = new System.Drawing.Size(1204, 248);
            this.dgvKardex.TabIndex = 0;
            // 
            // pnlKardexBarra
            // 
            this.pnlKardexBarra.Controls.Add(this.lblKardexTitulo);
            this.pnlKardexBarra.Controls.Add(this.btnKardexTodos);
            this.pnlKardexBarra.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKardexBarra.Location = new System.Drawing.Point(16, 200);
            this.pnlKardexBarra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlKardexBarra.Name = "pnlKardexBarra";
            this.pnlKardexBarra.Size = new System.Drawing.Size(1204, 32);
            this.pnlKardexBarra.TabIndex = 1;
            // 
            // lblKardexTitulo
            // 
            this.lblKardexTitulo.AutoSize = true;
            this.lblKardexTitulo.Location = new System.Drawing.Point(12, 6);
            this.lblKardexTitulo.Name = "lblKardexTitulo";
            this.lblKardexTitulo.Size = new System.Drawing.Size(69, 25);
            this.lblKardexTitulo.TabIndex = 0;
            this.lblKardexTitulo.Tag = "barra";
            this.lblKardexTitulo.Text = "Kardex";
            // 
            // btnKardexTodos
            // 
            this.btnKardexTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKardexTodos.Location = new System.Drawing.Point(1034, 4);
            this.btnKardexTodos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnKardexTodos.Name = "btnKardexTodos";
            this.btnKardexTodos.Size = new System.Drawing.Size(160, 24);
            this.btnKardexTodos.TabIndex = 1;
            this.btnKardexTodos.Tag = "secundario";
            this.btnKardexTodos.Text = "Ver todos los movimientos";
            this.btnKardexTodos.Click += new System.EventHandler(this.btnKardexTodos_Click);
            // 
            // pnlStock
            // 
            this.pnlStock.Controls.Add(this.dgvStock);
            this.pnlStock.Controls.Add(this.lblStockTitulo);
            this.pnlStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStock.Location = new System.Drawing.Point(16, 0);
            this.pnlStock.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlStock.Name = "pnlStock";
            this.pnlStock.Size = new System.Drawing.Size(1204, 200);
            this.pnlStock.TabIndex = 2;
            // 
            // dgvStock
            // 
            this.dgvStock.ColumnHeadersHeight = 29;
            this.dgvStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStock.Location = new System.Drawing.Point(0, 27);
            this.dgvStock.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.RowHeadersWidth = 51;
            this.dgvStock.Size = new System.Drawing.Size(1204, 173);
            this.dgvStock.TabIndex = 0;
            this.dgvStock.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvStock_CellFormatting);
            this.dgvStock.SelectionChanged += new System.EventHandler(this.dgvStock_SelectionChanged);
            // 
            // lblStockTitulo
            // 
            this.lblStockTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStockTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblStockTitulo.Name = "lblStockTitulo";
            this.lblStockTitulo.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblStockTitulo.Size = new System.Drawing.Size(1204, 27);
            this.lblStockTitulo.TabIndex = 1;
            this.lblStockTitulo.Tag = "barra";
            this.lblStockTitulo.Text = "Existencias (clic en una fila para ver su kardex)";
            this.lblStockTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlConsForm
            // 
            this.pnlConsForm.AutoScroll = true;
            this.pnlConsForm.Controls.Add(this.lblConsNuevo);
            this.pnlConsForm.Controls.Add(this.lblConsNombre);
            this.pnlConsForm.Controls.Add(this.txtConsNombre);
            this.pnlConsForm.Controls.Add(this.lblConsUnidad);
            this.pnlConsForm.Controls.Add(this.txtConsUnidad);
            this.pnlConsForm.Controls.Add(this.lblConsMin);
            this.pnlConsForm.Controls.Add(this.numConsMin);
            this.pnlConsForm.Controls.Add(this.btnConsCrear);
            this.pnlConsForm.Controls.Add(this.lblMovTitulo);
            this.pnlConsForm.Controls.Add(this.lblMovCons);
            this.pnlConsForm.Controls.Add(this.cmbMovCons);
            this.pnlConsForm.Controls.Add(this.lblMovTipo);
            this.pnlConsForm.Controls.Add(this.cmbMovTipo);
            this.pnlConsForm.Controls.Add(this.lblMovCant);
            this.pnlConsForm.Controls.Add(this.numMovCant);
            this.pnlConsForm.Controls.Add(this.lblMovMotivo);
            this.pnlConsForm.Controls.Add(this.cmbMovMotivo);
            this.pnlConsForm.Controls.Add(this.lblMovDestino);
            this.pnlConsForm.Controls.Add(this.txtMovDestino);
            this.pnlConsForm.Controls.Add(this.btnMovimiento);
            this.pnlConsForm.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlConsForm.Location = new System.Drawing.Point(16, 10);
            this.pnlConsForm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlConsForm.Name = "pnlConsForm";
            this.pnlConsForm.Size = new System.Drawing.Size(380, 480);
            this.pnlConsForm.TabIndex = 1;
            this.pnlConsForm.Tag = "tarjeta";
            // 
            // lblConsNuevo
            // 
            this.lblConsNuevo.AutoSize = true;
            this.lblConsNuevo.Location = new System.Drawing.Point(24, 11);
            this.lblConsNuevo.Name = "lblConsNuevo";
            this.lblConsNuevo.Size = new System.Drawing.Size(168, 25);
            this.lblConsNuevo.TabIndex = 0;
            this.lblConsNuevo.Tag = "seccion";
            this.lblConsNuevo.Text = "Nuevo consumible";
            // 
            // lblConsNombre
            // 
            this.lblConsNombre.AutoSize = true;
            this.lblConsNombre.Location = new System.Drawing.Point(24, 40);
            this.lblConsNombre.Name = "lblConsNombre";
            this.lblConsNombre.Size = new System.Drawing.Size(299, 25);
            this.lblConsNombre.TabIndex = 1;
            this.lblConsNombre.Tag = "campo";
            this.lblConsNombre.Text = "Nombre (ej. Resma de papel carta)";
            // 
            // txtConsNombre
            // 
            this.txtConsNombre.Location = new System.Drawing.Point(24, 58);
            this.txtConsNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtConsNombre.MaxLength = 100;
            this.txtConsNombre.Name = "txtConsNombre";
            this.txtConsNombre.Size = new System.Drawing.Size(332, 31);
            this.txtConsNombre.TabIndex = 2;
            // 
            // lblConsUnidad
            // 
            this.lblConsUnidad.AutoSize = true;
            this.lblConsUnidad.Location = new System.Drawing.Point(24, 90);
            this.lblConsUnidad.Name = "lblConsUnidad";
            this.lblConsUnidad.Size = new System.Drawing.Size(165, 25);
            this.lblConsUnidad.TabIndex = 3;
            this.lblConsUnidad.Tag = "campo";
            this.lblConsUnidad.Text = "Unidad de medida";
            // 
            // txtConsUnidad
            // 
            this.txtConsUnidad.Location = new System.Drawing.Point(24, 107);
            this.txtConsUnidad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtConsUnidad.MaxLength = 30;
            this.txtConsUnidad.Name = "txtConsUnidad";
            this.txtConsUnidad.Size = new System.Drawing.Size(160, 31);
            this.txtConsUnidad.TabIndex = 4;
            // 
            // lblConsMin
            // 
            this.lblConsMin.AutoSize = true;
            this.lblConsMin.Location = new System.Drawing.Point(200, 90);
            this.lblConsMin.Name = "lblConsMin";
            this.lblConsMin.Size = new System.Drawing.Size(125, 25);
            this.lblConsMin.TabIndex = 5;
            this.lblConsMin.Tag = "campo";
            this.lblConsMin.Text = "Stock mínimo";
            // 
            // numConsMin
            // 
            this.numConsMin.Location = new System.Drawing.Point(200, 107);
            this.numConsMin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numConsMin.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numConsMin.Name = "numConsMin";
            this.numConsMin.Size = new System.Drawing.Size(156, 31);
            this.numConsMin.TabIndex = 6;
            // 
            // btnConsCrear
            // 
            this.btnConsCrear.Location = new System.Drawing.Point(24, 146);
            this.btnConsCrear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConsCrear.Name = "btnConsCrear";
            this.btnConsCrear.Size = new System.Drawing.Size(332, 32);
            this.btnConsCrear.TabIndex = 7;
            this.btnConsCrear.Tag = "ok";
            this.btnConsCrear.Text = "Crear consumible";
            this.btnConsCrear.Click += new System.EventHandler(this.btnConsCrear_Click);
            // 
            // lblMovTitulo
            // 
            this.lblMovTitulo.AutoSize = true;
            this.lblMovTitulo.Location = new System.Drawing.Point(24, 194);
            this.lblMovTitulo.Name = "lblMovTitulo";
            this.lblMovTitulo.Size = new System.Drawing.Size(193, 25);
            this.lblMovTitulo.TabIndex = 8;
            this.lblMovTitulo.Tag = "seccion";
            this.lblMovTitulo.Text = "Registrar movimiento";
            // 
            // lblMovCons
            // 
            this.lblMovCons.AutoSize = true;
            this.lblMovCons.Location = new System.Drawing.Point(24, 224);
            this.lblMovCons.Name = "lblMovCons";
            this.lblMovCons.Size = new System.Drawing.Size(111, 25);
            this.lblMovCons.TabIndex = 9;
            this.lblMovCons.Tag = "campo";
            this.lblMovCons.Text = "Consumible";
            // 
            // cmbMovCons
            // 
            this.cmbMovCons.Location = new System.Drawing.Point(24, 242);
            this.cmbMovCons.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbMovCons.Name = "cmbMovCons";
            this.cmbMovCons.Size = new System.Drawing.Size(332, 31);
            this.cmbMovCons.TabIndex = 10;
            // 
            // lblMovTipo
            // 
            this.lblMovTipo.AutoSize = true;
            this.lblMovTipo.Location = new System.Drawing.Point(24, 274);
            this.lblMovTipo.Name = "lblMovTipo";
            this.lblMovTipo.Size = new System.Drawing.Size(49, 25);
            this.lblMovTipo.TabIndex = 11;
            this.lblMovTipo.Tag = "campo";
            this.lblMovTipo.Text = "Tipo";
            // 
            // cmbMovTipo
            // 
            this.cmbMovTipo.Location = new System.Drawing.Point(24, 291);
            this.cmbMovTipo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbMovTipo.Name = "cmbMovTipo";
            this.cmbMovTipo.Size = new System.Drawing.Size(160, 31);
            this.cmbMovTipo.TabIndex = 12;
            this.cmbMovTipo.SelectedIndexChanged += new System.EventHandler(this.cmbMovTipo_SelectedIndexChanged);
            // 
            // lblMovCant
            // 
            this.lblMovCant.AutoSize = true;
            this.lblMovCant.Location = new System.Drawing.Point(200, 274);
            this.lblMovCant.Name = "lblMovCant";
            this.lblMovCant.Size = new System.Drawing.Size(86, 25);
            this.lblMovCant.TabIndex = 13;
            this.lblMovCant.Tag = "campo";
            this.lblMovCant.Text = "Cantidad";
            // 
            // numMovCant
            // 
            this.numMovCant.Location = new System.Drawing.Point(200, 291);
            this.numMovCant.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numMovCant.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numMovCant.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMovCant.Name = "numMovCant";
            this.numMovCant.Size = new System.Drawing.Size(156, 31);
            this.numMovCant.TabIndex = 14;
            this.numMovCant.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblMovMotivo
            // 
            this.lblMovMotivo.AutoSize = true;
            this.lblMovMotivo.Location = new System.Drawing.Point(24, 323);
            this.lblMovMotivo.Name = "lblMovMotivo";
            this.lblMovMotivo.Size = new System.Drawing.Size(72, 25);
            this.lblMovMotivo.TabIndex = 15;
            this.lblMovMotivo.Tag = "campo";
            this.lblMovMotivo.Text = "Motivo";
            // 
            // cmbMovMotivo
            // 
            this.cmbMovMotivo.Location = new System.Drawing.Point(24, 341);
            this.cmbMovMotivo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbMovMotivo.Name = "cmbMovMotivo";
            this.cmbMovMotivo.Size = new System.Drawing.Size(332, 31);
            this.cmbMovMotivo.TabIndex = 16;
            // 
            // lblMovDestino
            // 
            this.lblMovDestino.AutoSize = true;
            this.lblMovDestino.Location = new System.Drawing.Point(24, 373);
            this.lblMovDestino.Name = "lblMovDestino";
            this.lblMovDestino.Size = new System.Drawing.Size(427, 25);
            this.lblMovDestino.TabIndex = 17;
            this.lblMovDestino.Tag = "campo";
            this.lblMovDestino.Text = "Destino o referencia (aula, departamento, factura)";
            // 
            // txtMovDestino
            // 
            this.txtMovDestino.Location = new System.Drawing.Point(24, 390);
            this.txtMovDestino.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMovDestino.MaxLength = 100;
            this.txtMovDestino.Name = "txtMovDestino";
            this.txtMovDestino.Size = new System.Drawing.Size(332, 31);
            this.txtMovDestino.TabIndex = 18;
            // 
            // btnMovimiento
            // 
            this.btnMovimiento.Location = new System.Drawing.Point(24, 429);
            this.btnMovimiento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMovimiento.Name = "btnMovimiento";
            this.btnMovimiento.Size = new System.Drawing.Size(332, 35);
            this.btnMovimiento.TabIndex = 19;
            this.btnMovimiento.Text = "Registrar movimiento";
            this.btnMovimiento.Click += new System.EventHandler(this.btnMovimiento_Click);
            // 
            // tabMantenimiento
            // 
            this.tabMantenimiento.Controls.Add(this.pnlMantLista);
            this.tabMantenimiento.Controls.Add(this.pnlMantForm);
            this.tabMantenimiento.Location = new System.Drawing.Point(4, 40);
            this.tabMantenimiento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabMantenimiento.Name = "tabMantenimiento";
            this.tabMantenimiento.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.tabMantenimiento.Size = new System.Drawing.Size(1632, 500);
            this.tabMantenimiento.TabIndex = 3;
            this.tabMantenimiento.Text = "4. Mantenimiento";
            // 
            // pnlMantLista
            // 
            this.pnlMantLista.Controls.Add(this.dgvMantenimientos);
            this.pnlMantLista.Controls.Add(this.lblMantHistTitulo);
            this.pnlMantLista.Controls.Add(this.pnlMantReportes);
            this.pnlMantLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMantLista.Location = new System.Drawing.Point(396, 10);
            this.pnlMantLista.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlMantLista.Name = "pnlMantLista";
            this.pnlMantLista.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.pnlMantLista.Size = new System.Drawing.Size(1220, 480);
            this.pnlMantLista.TabIndex = 0;
            // 
            // dgvMantenimientos
            // 
            this.dgvMantenimientos.ColumnHeadersHeight = 29;
            this.dgvMantenimientos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMantenimientos.Location = new System.Drawing.Point(16, 211);
            this.dgvMantenimientos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvMantenimientos.Name = "dgvMantenimientos";
            this.dgvMantenimientos.RowHeadersWidth = 51;
            this.dgvMantenimientos.Size = new System.Drawing.Size(1204, 269);
            this.dgvMantenimientos.TabIndex = 0;
            // 
            // lblMantHistTitulo
            // 
            this.lblMantHistTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMantHistTitulo.Location = new System.Drawing.Point(16, 184);
            this.lblMantHistTitulo.Name = "lblMantHistTitulo";
            this.lblMantHistTitulo.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblMantHistTitulo.Size = new System.Drawing.Size(1204, 27);
            this.lblMantHistTitulo.TabIndex = 1;
            this.lblMantHistTitulo.Tag = "barra";
            this.lblMantHistTitulo.Text = "Bitácora de mantenimiento";
            this.lblMantHistTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlMantReportes
            // 
            this.pnlMantReportes.Controls.Add(this.dgvMantReportes);
            this.pnlMantReportes.Controls.Add(this.lblMantReportesTitulo);
            this.pnlMantReportes.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMantReportes.Location = new System.Drawing.Point(16, 0);
            this.pnlMantReportes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlMantReportes.Name = "pnlMantReportes";
            this.pnlMantReportes.Size = new System.Drawing.Size(1204, 184);
            this.pnlMantReportes.TabIndex = 2;
            // 
            // dgvMantReportes
            // 
            this.dgvMantReportes.ColumnHeadersHeight = 29;
            this.dgvMantReportes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMantReportes.Location = new System.Drawing.Point(0, 27);
            this.dgvMantReportes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvMantReportes.Name = "dgvMantReportes";
            this.dgvMantReportes.RowHeadersWidth = 51;
            this.dgvMantReportes.Size = new System.Drawing.Size(1204, 157);
            this.dgvMantReportes.TabIndex = 0;
            this.dgvMantReportes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMantReportes_CellClick);
            // 
            // lblMantReportesTitulo
            // 
            this.lblMantReportesTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMantReportesTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblMantReportesTitulo.Name = "lblMantReportesTitulo";
            this.lblMantReportesTitulo.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblMantReportesTitulo.Size = new System.Drawing.Size(1204, 27);
            this.lblMantReportesTitulo.TabIndex = 1;
            this.lblMantReportesTitulo.Tag = "barra";
            this.lblMantReportesTitulo.Text = "Reportes de daño abiertos (clic para vincularlos al mantenimiento)";
            this.lblMantReportesTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlMantForm
            // 
            this.pnlMantForm.AutoScroll = true;
            this.pnlMantForm.Controls.Add(this.lblMantTitulo);
            this.pnlMantForm.Controls.Add(this.lblMantActivo);
            this.pnlMantForm.Controls.Add(this.cmbMantActivo);
            this.pnlMantForm.Controls.Add(this.lblMantCodigo);
            this.pnlMantForm.Controls.Add(this.txtMantCodigo);
            this.pnlMantForm.Controls.Add(this.lblMantFecha);
            this.pnlMantForm.Controls.Add(this.dtpMantFecha);
            this.pnlMantForm.Controls.Add(this.lblMantTipo);
            this.pnlMantForm.Controls.Add(this.cmbMantTipo);
            this.pnlMantForm.Controls.Add(this.lblMantCosto);
            this.pnlMantForm.Controls.Add(this.numMantCosto);
            this.pnlMantForm.Controls.Add(this.lblMantEstado);
            this.pnlMantForm.Controls.Add(this.cmbMantEstado);
            this.pnlMantForm.Controls.Add(this.lblMantDesc);
            this.pnlMantForm.Controls.Add(this.txtMantDesc);
            this.pnlMantForm.Controls.Add(this.lblMantVinculo);
            this.pnlMantForm.Controls.Add(this.btnMantRegistrar);
            this.pnlMantForm.Controls.Add(this.btnMantLimpiar);
            this.pnlMantForm.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMantForm.Location = new System.Drawing.Point(16, 10);
            this.pnlMantForm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlMantForm.Name = "pnlMantForm";
            this.pnlMantForm.Size = new System.Drawing.Size(380, 480);
            this.pnlMantForm.TabIndex = 1;
            this.pnlMantForm.Tag = "tarjeta";
            // 
            // lblMantTitulo
            // 
            this.lblMantTitulo.AutoSize = true;
            this.lblMantTitulo.Location = new System.Drawing.Point(24, 11);
            this.lblMantTitulo.Name = "lblMantTitulo";
            this.lblMantTitulo.Size = new System.Drawing.Size(221, 25);
            this.lblMantTitulo.TabIndex = 0;
            this.lblMantTitulo.Tag = "seccion";
            this.lblMantTitulo.Text = "Registrar mantenimiento";
            // 
            // lblMantActivo
            // 
            this.lblMantActivo.AutoSize = true;
            this.lblMantActivo.Location = new System.Drawing.Point(24, 42);
            this.lblMantActivo.Name = "lblMantActivo";
            this.lblMantActivo.Size = new System.Drawing.Size(70, 25);
            this.lblMantActivo.TabIndex = 1;
            this.lblMantActivo.Tag = "campo";
            this.lblMantActivo.Text = "Equipo";
            // 
            // cmbMantActivo
            // 
            this.cmbMantActivo.Location = new System.Drawing.Point(24, 59);
            this.cmbMantActivo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbMantActivo.Name = "cmbMantActivo";
            this.cmbMantActivo.Size = new System.Drawing.Size(332, 31);
            this.cmbMantActivo.TabIndex = 2;
            // 
            // lblMantCodigo
            // 
            this.lblMantCodigo.AutoSize = true;
            this.lblMantCodigo.Location = new System.Drawing.Point(24, 91);
            this.lblMantCodigo.Name = "lblMantCodigo";
            this.lblMantCodigo.Size = new System.Drawing.Size(160, 25);
            this.lblMantCodigo.TabIndex = 3;
            this.lblMantCodigo.Tag = "campo";
            this.lblMantCodigo.Text = "Código (opcional)";
            // 
            // txtMantCodigo
            // 
            this.txtMantCodigo.Location = new System.Drawing.Point(24, 109);
            this.txtMantCodigo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMantCodigo.MaxLength = 50;
            this.txtMantCodigo.Name = "txtMantCodigo";
            this.txtMantCodigo.Size = new System.Drawing.Size(160, 31);
            this.txtMantCodigo.TabIndex = 4;
            // 
            // lblMantFecha
            // 
            this.lblMantFecha.AutoSize = true;
            this.lblMantFecha.Location = new System.Drawing.Point(200, 91);
            this.lblMantFecha.Name = "lblMantFecha";
            this.lblMantFecha.Size = new System.Drawing.Size(158, 25);
            this.lblMantFecha.TabIndex = 5;
            this.lblMantFecha.Tag = "campo";
            this.lblMantFecha.Text = "Fecha del servicio";
            // 
            // dtpMantFecha
            // 
            this.dtpMantFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpMantFecha.Location = new System.Drawing.Point(200, 109);
            this.dtpMantFecha.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpMantFecha.Name = "dtpMantFecha";
            this.dtpMantFecha.Size = new System.Drawing.Size(156, 31);
            this.dtpMantFecha.TabIndex = 6;
            // 
            // lblMantTipo
            // 
            this.lblMantTipo.AutoSize = true;
            this.lblMantTipo.Location = new System.Drawing.Point(24, 141);
            this.lblMantTipo.Name = "lblMantTipo";
            this.lblMantTipo.Size = new System.Drawing.Size(49, 25);
            this.lblMantTipo.TabIndex = 7;
            this.lblMantTipo.Tag = "campo";
            this.lblMantTipo.Text = "Tipo";
            // 
            // cmbMantTipo
            // 
            this.cmbMantTipo.Location = new System.Drawing.Point(24, 158);
            this.cmbMantTipo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbMantTipo.Name = "cmbMantTipo";
            this.cmbMantTipo.Size = new System.Drawing.Size(160, 31);
            this.cmbMantTipo.TabIndex = 8;
            // 
            // lblMantCosto
            // 
            this.lblMantCosto.AutoSize = true;
            this.lblMantCosto.Location = new System.Drawing.Point(200, 141);
            this.lblMantCosto.Name = "lblMantCosto";
            this.lblMantCosto.Size = new System.Drawing.Size(60, 25);
            this.lblMantCosto.TabIndex = 9;
            this.lblMantCosto.Tag = "campo";
            this.lblMantCosto.Text = "Costo";
            // 
            // numMantCosto
            // 
            this.numMantCosto.DecimalPlaces = 2;
            this.numMantCosto.Location = new System.Drawing.Point(200, 158);
            this.numMantCosto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numMantCosto.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numMantCosto.Name = "numMantCosto";
            this.numMantCosto.Size = new System.Drawing.Size(156, 31);
            this.numMantCosto.TabIndex = 10;
            // 
            // lblMantEstado
            // 
            this.lblMantEstado.AutoSize = true;
            this.lblMantEstado.Location = new System.Drawing.Point(24, 190);
            this.lblMantEstado.Name = "lblMantEstado";
            this.lblMantEstado.Size = new System.Drawing.Size(252, 25);
            this.lblMantEstado.TabIndex = 11;
            this.lblMantEstado.Tag = "campo";
            this.lblMantEstado.Text = "Estado resultante del equipo";
            // 
            // cmbMantEstado
            // 
            this.cmbMantEstado.Location = new System.Drawing.Point(24, 208);
            this.cmbMantEstado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbMantEstado.Name = "cmbMantEstado";
            this.cmbMantEstado.Size = new System.Drawing.Size(332, 31);
            this.cmbMantEstado.TabIndex = 12;
            // 
            // lblMantDesc
            // 
            this.lblMantDesc.AutoSize = true;
            this.lblMantDesc.Location = new System.Drawing.Point(24, 240);
            this.lblMantDesc.Name = "lblMantDesc";
            this.lblMantDesc.Size = new System.Drawing.Size(209, 25);
            this.lblMantDesc.TabIndex = 13;
            this.lblMantDesc.Tag = "campo";
            this.lblMantDesc.Text = "Descripción del servicio";
            // 
            // txtMantDesc
            // 
            this.txtMantDesc.Location = new System.Drawing.Point(24, 258);
            this.txtMantDesc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMantDesc.MaxLength = 500;
            this.txtMantDesc.Multiline = true;
            this.txtMantDesc.Name = "txtMantDesc";
            this.txtMantDesc.Size = new System.Drawing.Size(332, 65);
            this.txtMantDesc.TabIndex = 14;
            // 
            // lblMantVinculo
            // 
            this.lblMantVinculo.Location = new System.Drawing.Point(24, 328);
            this.lblMantVinculo.Name = "lblMantVinculo";
            this.lblMantVinculo.Size = new System.Drawing.Size(332, 32);
            this.lblMantVinculo.TabIndex = 15;
            this.lblMantVinculo.Tag = "info";
            this.lblMantVinculo.Text = "Sin reporte de daño vinculado (seleccione uno de la tabla para cerrarlo al guarda" +
    "r)";
            // 
            // btnMantRegistrar
            // 
            this.btnMantRegistrar.Location = new System.Drawing.Point(24, 366);
            this.btnMantRegistrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMantRegistrar.Name = "btnMantRegistrar";
            this.btnMantRegistrar.Size = new System.Drawing.Size(332, 35);
            this.btnMantRegistrar.TabIndex = 16;
            this.btnMantRegistrar.Text = "Registrar mantenimiento";
            this.btnMantRegistrar.Click += new System.EventHandler(this.btnMantRegistrar_Click);
            // 
            // btnMantLimpiar
            // 
            this.btnMantLimpiar.Location = new System.Drawing.Point(24, 408);
            this.btnMantLimpiar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMantLimpiar.Name = "btnMantLimpiar";
            this.btnMantLimpiar.Size = new System.Drawing.Size(332, 30);
            this.btnMantLimpiar.TabIndex = 17;
            this.btnMantLimpiar.Tag = "secundario";
            this.btnMantLimpiar.Text = "Limpiar";
            this.btnMantLimpiar.Click += new System.EventHandler(this.btnMantLimpiar_Click);
            // 
            // tabReportes
            // 
            this.tabReportes.Controls.Add(this.dgvReporte);
            this.tabReportes.Controls.Add(this.pnlRepFiltros);
            this.tabReportes.Location = new System.Drawing.Point(4, 40);
            this.tabReportes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabReportes.Name = "tabReportes";
            this.tabReportes.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.tabReportes.Size = new System.Drawing.Size(1632, 500);
            this.tabReportes.TabIndex = 4;
            this.tabReportes.Text = "5. Reportes";
            // 
            // dgvReporte
            // 
            this.dgvReporte.ColumnHeadersHeight = 29;
            this.dgvReporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReporte.Location = new System.Drawing.Point(16, 98);
            this.dgvReporte.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.RowHeadersWidth = 51;
            this.dgvReporte.Size = new System.Drawing.Size(1600, 392);
            this.dgvReporte.TabIndex = 0;
            // 
            // pnlRepFiltros
            // 
            this.pnlRepFiltros.Controls.Add(this.lblRepTipo);
            this.pnlRepFiltros.Controls.Add(this.cmbRepTipo);
            this.pnlRepFiltros.Controls.Add(this.lblRepSalon);
            this.pnlRepFiltros.Controls.Add(this.cmbRepSalon);
            this.pnlRepFiltros.Controls.Add(this.lblRepDesde);
            this.pnlRepFiltros.Controls.Add(this.dtpRepDesde);
            this.pnlRepFiltros.Controls.Add(this.lblRepHasta);
            this.pnlRepFiltros.Controls.Add(this.dtpRepHasta);
            this.pnlRepFiltros.Controls.Add(this.btnRepGenerar);
            this.pnlRepFiltros.Controls.Add(this.btnRepPdf);
            this.pnlRepFiltros.Controls.Add(this.lblRepInfo);
            this.pnlRepFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRepFiltros.Location = new System.Drawing.Point(16, 10);
            this.pnlRepFiltros.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlRepFiltros.Name = "pnlRepFiltros";
            this.pnlRepFiltros.Size = new System.Drawing.Size(1600, 88);
            this.pnlRepFiltros.TabIndex = 1;
            this.pnlRepFiltros.Tag = "tarjeta";
            // 
            // lblRepTipo
            // 
            this.lblRepTipo.AutoSize = true;
            this.lblRepTipo.Location = new System.Drawing.Point(16, 8);
            this.lblRepTipo.Name = "lblRepTipo";
            this.lblRepTipo.Size = new System.Drawing.Size(80, 25);
            this.lblRepTipo.TabIndex = 0;
            this.lblRepTipo.Tag = "campo";
            this.lblRepTipo.Text = "Reporte";
            // 
            // cmbRepTipo
            // 
            this.cmbRepTipo.Location = new System.Drawing.Point(16, 26);
            this.cmbRepTipo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbRepTipo.Name = "cmbRepTipo";
            this.cmbRepTipo.Size = new System.Drawing.Size(390, 31);
            this.cmbRepTipo.TabIndex = 1;
            this.cmbRepTipo.SelectedIndexChanged += new System.EventHandler(this.cmbRepTipo_SelectedIndexChanged);
            // 
            // lblRepSalon
            // 
            this.lblRepSalon.AutoSize = true;
            this.lblRepSalon.Location = new System.Drawing.Point(426, 8);
            this.lblRepSalon.Name = "lblRepSalon";
            this.lblRepSalon.Size = new System.Drawing.Size(190, 25);
            this.lblRepSalon.TabIndex = 2;
            this.lblRepSalon.Tag = "campo";
            this.lblRepSalon.Text = "Aula o departamento";
            // 
            // cmbRepSalon
            // 
            this.cmbRepSalon.Location = new System.Drawing.Point(426, 26);
            this.cmbRepSalon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbRepSalon.Name = "cmbRepSalon";
            this.cmbRepSalon.Size = new System.Drawing.Size(230, 31);
            this.cmbRepSalon.TabIndex = 3;
            // 
            // lblRepDesde
            // 
            this.lblRepDesde.AutoSize = true;
            this.lblRepDesde.Location = new System.Drawing.Point(676, 8);
            this.lblRepDesde.Name = "lblRepDesde";
            this.lblRepDesde.Size = new System.Drawing.Size(64, 25);
            this.lblRepDesde.TabIndex = 4;
            this.lblRepDesde.Tag = "campo";
            this.lblRepDesde.Text = "Desde";
            // 
            // dtpRepDesde
            // 
            this.dtpRepDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRepDesde.Location = new System.Drawing.Point(676, 26);
            this.dtpRepDesde.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpRepDesde.Name = "dtpRepDesde";
            this.dtpRepDesde.Size = new System.Drawing.Size(140, 31);
            this.dtpRepDesde.TabIndex = 5;
            // 
            // lblRepHasta
            // 
            this.lblRepHasta.AutoSize = true;
            this.lblRepHasta.Location = new System.Drawing.Point(836, 8);
            this.lblRepHasta.Name = "lblRepHasta";
            this.lblRepHasta.Size = new System.Drawing.Size(58, 25);
            this.lblRepHasta.TabIndex = 6;
            this.lblRepHasta.Tag = "campo";
            this.lblRepHasta.Text = "Hasta";
            // 
            // dtpRepHasta
            // 
            this.dtpRepHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRepHasta.Location = new System.Drawing.Point(836, 26);
            this.dtpRepHasta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpRepHasta.Name = "dtpRepHasta";
            this.dtpRepHasta.Size = new System.Drawing.Size(140, 31);
            this.dtpRepHasta.TabIndex = 7;
            // 
            // btnRepGenerar
            // 
            this.btnRepGenerar.Location = new System.Drawing.Point(996, 22);
            this.btnRepGenerar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRepGenerar.Name = "btnRepGenerar";
            this.btnRepGenerar.Size = new System.Drawing.Size(130, 32);
            this.btnRepGenerar.TabIndex = 8;
            this.btnRepGenerar.Text = "Generar";
            this.btnRepGenerar.Click += new System.EventHandler(this.btnRepGenerar_Click);
            // 
            // btnRepPdf
            // 
            this.btnRepPdf.Location = new System.Drawing.Point(1136, 22);
            this.btnRepPdf.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRepPdf.Name = "btnRepPdf";
            this.btnRepPdf.Size = new System.Drawing.Size(140, 32);
            this.btnRepPdf.TabIndex = 9;
            this.btnRepPdf.Tag = "secundario";
            this.btnRepPdf.Text = "Exportar a PDF";
            this.btnRepPdf.Click += new System.EventHandler(this.btnRepPdf_Click);
            // 
            // lblRepInfo
            // 
            this.lblRepInfo.AutoSize = true;
            this.lblRepInfo.Location = new System.Drawing.Point(16, 62);
            this.lblRepInfo.Name = "lblRepInfo";
            this.lblRepInfo.Size = new System.Drawing.Size(305, 25);
            this.lblRepInfo.TabIndex = 10;
            this.lblRepInfo.Tag = "info";
            this.lblRepInfo.Text = "Elija un reporte y presione Generar";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmGestionActivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1640, 688);
            this.Controls.Add(this.tabPrincipal);
            this.Controls.Add(this.tlpKpis);
            this.Controls.Add(this.pnlEncabezado);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmGestionActivos";
            this.Text = "Gestión de activos";
            this.Load += new System.EventHandler(this.frmGestionActivos_Load);
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.tlpKpis.ResumeLayout(false);
            this.pnlKpi1.ResumeLayout(false);
            this.pnlKpi2.ResumeLayout(false);
            this.pnlKpi3.ResumeLayout(false);
            this.pnlKpi4.ResumeLayout(false);
            this.pnlKpi5.ResumeLayout(false);
            this.tabPrincipal.ResumeLayout(false);
            this.tabCatalogo.ResumeLayout(false);
            this.pnlLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivos)).EndInit();
            this.pnlFicha.ResumeLayout(false);
            this.tabFicha.ResumeLayout(false);
            this.pnlEstadoUnidad.ResumeLayout(false);
            this.pnlEstadoUnidad.PerformLayout();
            this.tabUbicacion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUbicacion)).EndInit();
            this.tabHistorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.tabDanos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanos)).EndInit();
            this.pnlBusqueda.ResumeLayout(false);
            this.pnlBusqueda.PerformLayout();
            this.pnlFormulario.ResumeLayout(false);
            this.pnlFormulario.PerformLayout();
            this.tabPrestamos.ResumeLayout(false);
            this.pnlPrestLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamos)).EndInit();
            this.pnlDevolucion.ResumeLayout(false);
            this.pnlDevolucion.PerformLayout();
            this.pnlPrestFiltro.ResumeLayout(false);
            this.pnlPrestFiltro.PerformLayout();
            this.pnlPrestForm.ResumeLayout(false);
            this.pnlPrestForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrestCant)).EndInit();
            this.tabConsumibles.ResumeLayout(false);
            this.pnlConsLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKardex)).EndInit();
            this.pnlKardexBarra.ResumeLayout(false);
            this.pnlKardexBarra.PerformLayout();
            this.pnlStock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            this.pnlConsForm.ResumeLayout(false);
            this.pnlConsForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numConsMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMovCant)).EndInit();
            this.tabMantenimiento.ResumeLayout(false);
            this.pnlMantLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMantenimientos)).EndInit();
            this.pnlMantReportes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMantReportes)).EndInit();
            this.pnlMantForm.ResumeLayout(false);
            this.pnlMantForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMantCosto)).EndInit();
            this.tabReportes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.pnlRepFiltros.ResumeLayout(false);
            this.pnlRepFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private Panel pnlEncabezado; private Label lblTitulo; private Label lblSubtitulo;
        private TableLayoutPanel tlpKpis;
        private Panel pnlKpi1; private Label lblKpi1; private Label lblKpi1Txt;
        private Panel pnlKpi2; private Label lblKpi2; private Label lblKpi2Txt;
        private Panel pnlKpi3; private Label lblKpi3; private Label lblKpi3Txt;
        private Panel pnlKpi4; private Label lblKpi4; private Label lblKpi4Txt;
        private Panel pnlKpi5; private Label lblKpi5;         private TabControl tabPrincipal;
        private TabPage tabCatalogo; private TabPage tabPrestamos; private TabPage tabConsumibles;
        private TabPage tabMantenimiento; private TabPage tabReportes;

        private Panel pnlFormulario; private Label lblModo; private Label lblCodigo; private TextBox txtCodigo;
        private Label lblNombre; private TextBox txtNombre; private Label lblCategoria; private ComboBox cmbCategoria;
        private Label lblEstado; private ComboBox cmbEstado; private Label lblUbicacion; private ComboBox cmbUbicacion;
        private Button btnGuardar; private Button btnActualizar; private Button btnEliminar; private Button btnLimpiar;
        private Panel pnlLista; private Panel pnlBusqueda; private Label lblBuscar; private TextBox txtBuscar;
        private ComboBox cmbFiltroCategoria; private ComboBox cmbFiltroEstado; private Label lblResultados; private Button btnExportarPdf;
        private DataGridView dgvActivos; private Panel pnlSeparador; private Panel pnlFicha; private Label lblFichaTitulo;
        private TabControl tabFicha; private TabPage tabUbicacion; private TabPage tabHistorial; private TabPage tabDanos;
        private DataGridView dgvUbicacion; private DataGridView dgvHistorial; private DataGridView dgvDanos;

        private Panel pnlPrestForm; private Label lblPrestTitulo; private Label lblPrestActivo; private ComboBox cmbPrestActivo;
        private Label lblPrestCodigo; private TextBox txtPrestCodigo; private Label lblPrestCant; private NumericUpDown numPrestCant;
        private Label lblPrestTipo; private ComboBox cmbPrestTipo; private Label lblPrestResp; private TextBox txtPrestResp;
        private Label lblPrestAula; private ComboBox cmbPrestAula; private Label lblPrestLimite; private DateTimePicker dtpPrestLimite;
        private Label lblPrestObs; private TextBox txtPrestObs; private Button btnPrestar;
        private Panel pnlPrestLista; private Panel pnlPrestFiltro; private Label lblPrestVer; private ComboBox cmbPrestVer;
        private Label lblPrestAlertas; private DataGridView dgvPrestamos; private Panel pnlDevolucion;
        private Label lblDevSel; private Label lblDevEstado; private ComboBox cmbDevEstado; private Label lblDevObs;
        private TextBox txtDevObs; private Button btnDevolver; private Button btnHoja;

        private Panel pnlConsForm; private Label lblConsNuevo; private Label lblConsNombre; private TextBox txtConsNombre;
        private Label lblConsUnidad; private TextBox txtConsUnidad; private Label lblConsMin; private NumericUpDown numConsMin;
        private Button btnConsCrear; private Label lblMovTitulo; private Label lblMovCons; private ComboBox cmbMovCons;
        private Label lblMovTipo; private ComboBox cmbMovTipo; private Label lblMovCant; private NumericUpDown numMovCant;
        private Label lblMovMotivo; private ComboBox cmbMovMotivo; private Label lblMovDestino; private TextBox txtMovDestino;
        private Button btnMovimiento; private Panel pnlConsLista; private Panel pnlStock; private Label lblStockTitulo;
        private DataGridView dgvStock; private Panel pnlKardexBarra; private Label lblKardexTitulo; private Button btnKardexTodos;
        private DataGridView dgvKardex;

        private Panel pnlMantForm; private Label lblMantTitulo; private Label lblMantActivo; private ComboBox cmbMantActivo;
        private Label lblMantCodigo; private TextBox txtMantCodigo; private Label lblMantFecha; private DateTimePicker dtpMantFecha;
        private Label lblMantTipo; private ComboBox cmbMantTipo; private Label lblMantCosto; private NumericUpDown numMantCosto;
        private Label lblMantEstado; private ComboBox cmbMantEstado; private Label lblMantDesc; private TextBox txtMantDesc;
        private Label lblMantVinculo; private Button btnMantRegistrar; private Button btnMantLimpiar;
        private Panel pnlMantLista; private Panel pnlMantReportes; private Label lblMantReportesTitulo;
        private DataGridView dgvMantReportes; private Label lblMantHistTitulo; private DataGridView dgvMantenimientos;

        private Panel pnlRepFiltros; private Label lblRepTipo; private ComboBox cmbRepTipo; private Label lblRepSalon;
        private ComboBox cmbRepSalon; private Label lblRepDesde; private DateTimePicker dtpRepDesde; private Label lblRepHasta;
        private DateTimePicker dtpRepHasta; private Button btnRepGenerar; private Button btnRepPdf; private Label lblRepInfo;
        private DataGridView dgvReporte;

        private ErrorProvider errorProvider;
        private ToolTip toolTip1;
        private Label lblKpi5Txt;

        // Cambio de estado de una unidad (ficha > Ubicación)
        private Panel pnlEstadoUnidad; private Label lblEstadoUnidad;
        private ComboBox cmbEstadoUnidad; private Button btnCambiarEstadoUnidad;
    }
}