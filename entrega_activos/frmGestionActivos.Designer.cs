using System.Drawing;
using System.Windows.Forms;

namespace Vistass
{
    partial class frmGestionActivos
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
            this.btnGuardar = new Vistass.BotonTema();
            this.btnActualizar = new Vistass.BotonTema();
            this.btnEliminar = new Vistass.BotonTema();
            this.btnLimpiar = new Vistass.BotonTema();
            this.pnlAccionesCat = new Panel();
            this.lblModo = new Label();
            this.lblCodigo = new Label();
            this.txtCodigo = new TextBox();
            this.lblNombre = new Label();
            this.txtNombre = new TextBox();
            this.lblCategoria = new Label();
            this.cmbCategoria = new ComboBox();
            this.lblEstado = new Label();
            this.cmbEstado = new ComboBox();
            this.lblUbicacion = new Label();
            this.cmbUbicacion = new ComboBox();
            this.pnlFormulario = new Panel();
            this.dgvActivos = new Vistass.GridOscuro();
            this.pnlSeparador = new Panel();
            this.dgvUbicacion = new Vistass.GridOscuro();
            this.dgvHistorial = new Vistass.GridOscuro();
            this.dgvDanos = new Vistass.GridOscuro();
            this.tabUbicacion = new TabPage();
            this.tabHistorial = new TabPage();
            this.tabDanos = new TabPage();
            this.tabFicha = new Vistass.TabControlOscuro();
            this.lblFichaTitulo = new Label();
            this.pnlFicha = new Panel();
            this.lblBuscar = new Label();
            this.btnExportarPdf = new Vistass.BotonTema();
            this.btnHistorial = new Vistass.BotonTema();
            this.btnVerUnidades = new Vistass.BotonTema();
            this.txtBuscar = new TextBox();
            this.cmbFiltroCategoria = new ComboBox();
            this.cmbFiltroEstado = new ComboBox();
            this.pnlBusqueda = new Panel();
            this.pnlLista = new Panel();
            this.tabCatalogo = new TabPage();
            this.lblPrestTitulo = new Label();
            this.lblPrestActivo = new Label();
            this.cmbPrestActivo = new ComboBox();
            this.lblPrestCodigo = new Label();
            this.txtPrestCodigo = new TextBox();
            this.lblPrestCant = new Label();
            this.numPrestCant = new NumericUpDown();
            this.lblPrestTipo = new Label();
            this.cmbPrestTipo = new ComboBox();
            this.lblPrestResp = new Label();
            this.txtPrestResp = new TextBox();
            this.lblPrestAula = new Label();
            this.cmbPrestAula = new ComboBox();
            this.lblPrestLimite = new Label();
            this.dtpPrestLimite = new DateTimePicker();
            this.lblPrestObs = new Label();
            this.txtPrestObs = new TextBox();
            this.btnPrestar = new Vistass.BotonTema();
            this.pnlAccionesPrest = new Panel();
            this.pnlPrestForm = new Panel();
            this.dgvPrestamos = new Vistass.GridOscuro();
            this.lblDevSel = new Label();
            this.lblDevEstado = new Label();
            this.cmbDevEstado = new ComboBox();
            this.lblDevObs = new Label();
            this.txtDevObs = new TextBox();
            this.btnDevolver = new Vistass.BotonTema();
            this.btnHoja = new Vistass.BotonTema();
            this.pnlDevolucion = new Panel();
            this.lblPrestVer = new Label();
            this.cmbPrestVer = new ComboBox();
            this.lblPrestAlertas = new Label();
            this.pnlPrestFiltro = new Panel();
            this.pnlPrestLista = new Panel();
            this.tabPrestamos = new TabPage();
            this.lblConsNuevo = new Label();
            this.lblConsNombre = new Label();
            this.txtConsNombre = new TextBox();
            this.lblConsUnidad = new Label();
            this.txtConsUnidad = new TextBox();
            this.lblConsMin = new Label();
            this.numConsMin = new NumericUpDown();
            this.btnConsCrear = new Vistass.BotonTema();
            this.lblMovTitulo = new Label();
            this.lblMovCons = new Label();
            this.cmbMovCons = new ComboBox();
            this.lblMovTipo = new Label();
            this.cmbMovTipo = new ComboBox();
            this.lblMovCant = new Label();
            this.numMovCant = new NumericUpDown();
            this.lblMovMotivo = new Label();
            this.cmbMovMotivo = new ComboBox();
            this.lblMovDestino = new Label();
            this.txtMovDestino = new ComboBox();
            this.btnMovimiento = new Vistass.BotonTema();
            this.pnlAccionesCons = new Panel();
            this.pnlConsForm = new Panel();
            this.dgvStock = new Vistass.GridOscuro();
            this.lblStockTitulo = new Label();
            this.pnlStock = new Panel();
            this.dgvKardex = new Vistass.GridOscuro();
            this.lblKardexTitulo = new Label();
            this.btnKardexTodos = new Vistass.BotonTema();
            this.pnlKardexBarra = new Panel();
            this.pnlConsLista = new Panel();
            this.tabConsumibles = new TabPage();
            this.lblMantTitulo = new Label();
            this.lblMantActivo = new Label();
            this.cmbMantActivo = new ComboBox();
            this.lblMantCodigo = new Label();
            this.txtMantCodigo = new TextBox();
            this.lblMantFecha = new Label();
            this.dtpMantFecha = new DateTimePicker();
            this.lblMantTipo = new Label();
            this.cmbMantTipo = new ComboBox();
            this.lblMantCosto = new Label();
            this.numMantCosto = new NumericUpDown();
            this.lblMantEstado = new Label();
            this.cmbMantEstado = new ComboBox();
            this.lblMantDesc = new Label();
            this.txtMantDesc = new TextBox();
            this.lblMantVinculo = new Label();
            this.btnMantRegistrar = new Vistass.BotonTema();
            this.btnMantLimpiar = new Vistass.BotonTema();
            this.pnlAccionesMant = new Panel();
            this.pnlMantForm = new Panel();
            this.dgvMantenimientos = new Vistass.GridOscuro();
            this.lblMantHistTitulo = new Label();
            this.pnlMantLista = new Panel();
            this.tabMantenimiento = new TabPage();
            this.dgvReporte = new Vistass.GridOscuro();
            this.lblRepTipo = new Label();
            this.cmbRepTipo = new ComboBox();
            this.lblRepSalon = new Label();
            this.cmbRepSalon = new ComboBox();
            this.lblRepDesde = new Label();
            this.dtpRepDesde = new DateTimePicker();
            this.lblRepHasta = new Label();
            this.dtpRepHasta = new DateTimePicker();
            this.btnRepGenerar = new Vistass.BotonTema();
            this.btnRepPdf = new Vistass.BotonTema();
            this.lblRepInfo = new Label();
            this.pnlRepFiltros = new Panel();
            this.tabReportes = new TabPage();
            this.tabPrincipal = new Vistass.TabControlOscuro();
            this.lblTitulo = new Label();
            this.lblSubtitulo = new Label();
            this.pnlEncabezado = new Panel();
            this.lblKpi1 = new Label();
            this.lblKpi1Txt = new Label();
            this.pnlKpi1 = new Panel();
            this.lblKpi2 = new Label();
            this.lblKpi2Txt = new Label();
            this.pnlKpi2 = new Panel();
            this.lblKpi3 = new Label();
            this.lblKpi3Txt = new Label();
            this.pnlKpi3 = new Panel();
            this.lblKpi4 = new Label();
            this.lblKpi4Txt = new Label();
            this.pnlKpi4 = new Panel();
            this.lblKpi5 = new Label();
            this.lblKpi5Txt = new Label();
            this.pnlKpi5 = new Panel();
            this.tlpKpis = new TableLayoutPanel();
            this.errorProvider = new ErrorProvider(this.components);
            this.toolTip1 = new ToolTip(this.components);
            this.SuspendLayout();

            this.btnGuardar.Location = new Point(20, 0);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new Size(340, 40);
            this.btnGuardar.Text = "Agregar activo";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnActualizar.Location = new Point(20, 50);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new Size(165, 40);
            this.btnActualizar.Text = "Guardar cambios";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);

            this.btnEliminar.Location = new Point(195, 50);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new Size(165, 40);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Tipo = Vistass.TipoBoton.Peligro;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            this.btnLimpiar.Location = new Point(20, 100);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new Size(340, 40);
            this.btnLimpiar.Text = "Nuevo / limpiar formulario";
            this.btnLimpiar.Tipo = Vistass.TipoBoton.Secundario;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            this.pnlAccionesCat.Controls.Add(this.btnGuardar);
            this.pnlAccionesCat.Controls.Add(this.btnActualizar);
            this.pnlAccionesCat.Controls.Add(this.btnEliminar);
            this.pnlAccionesCat.Controls.Add(this.btnLimpiar);
            this.pnlAccionesCat.Name = "pnlAccionesCat";
            this.pnlAccionesCat.Dock = DockStyle.Bottom;
            this.pnlAccionesCat.Size = new Size(380, 156);

            this.lblModo.AutoSize = true;
            this.lblModo.Location = new Point(20, 16);
            this.lblModo.Name = "lblModo";
            this.lblModo.Text = "Nuevo activo";
            this.lblModo.Font = new Font("Segoe UI Semibold", 11.5F, FontStyle.Bold);
            this.lblModo.ForeColor = Color.FromArgb(250, 204, 21);

            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new Point(20, 54);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Text = "Código (vacío = automático)";
            this.lblCodigo.Click += new System.EventHandler(this.lblCodigo_Click);

            this.txtCodigo.BackColor = Color.FromArgb(38, 42, 58);
            this.txtCodigo.BorderStyle = BorderStyle.FixedSingle;
            this.txtCodigo.ForeColor = Color.FromArgb(226, 232, 244);
            this.txtCodigo.Location = new Point(20, 76);
            this.txtCodigo.MaxLength = 50;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new Size(340, 27);
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);

            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new Point(20, 116);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Text = "Nombre del activo";

            this.txtNombre.BackColor = Color.FromArgb(38, 42, 58);
            this.txtNombre.BorderStyle = BorderStyle.FixedSingle;
            this.txtNombre.ForeColor = Color.FromArgb(226, 232, 244);
            this.txtNombre.Location = new Point(20, 138);
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new Size(340, 27);

            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new Point(20, 178);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Text = "Categoría";

            this.cmbCategoria.BackColor = Color.FromArgb(38, 42, 58);
            this.cmbCategoria.FlatStyle = FlatStyle.Flat;
            this.cmbCategoria.ForeColor = Color.FromArgb(226, 232, 244);
            this.cmbCategoria.Location = new Point(20, 200);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new Size(340, 27);

            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new Point(20, 240);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Text = "Estado físico";
            this.lblEstado.Visible = false;

            this.cmbEstado.BackColor = Color.FromArgb(38, 42, 58);
            this.cmbEstado.FlatStyle = FlatStyle.Flat;
            this.cmbEstado.ForeColor = Color.FromArgb(226, 232, 244);
            this.cmbEstado.Location = new Point(20, 262);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new Size(340, 27);
            this.cmbEstado.Visible = false;

            this.lblUbicacion.AutoSize = true;
            this.lblUbicacion.Location = new Point(20, 240);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Text = "Ubicación predeterminada";

            this.cmbUbicacion.BackColor = Color.FromArgb(38, 42, 58);
            this.cmbUbicacion.FlatStyle = FlatStyle.Flat;
            this.cmbUbicacion.ForeColor = Color.FromArgb(226, 232, 244);
            this.cmbUbicacion.Location = new Point(20, 262);
            this.cmbUbicacion.Name = "cmbUbicacion";
            this.cmbUbicacion.Size = new Size(340, 27);

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
            this.pnlFormulario.Controls.Add(this.pnlAccionesCat);
            this.pnlFormulario.Name = "pnlFormulario";
            this.pnlFormulario.BackColor = Color.FromArgb(21, 23, 31);
            this.pnlFormulario.Dock = DockStyle.Left;
            this.pnlFormulario.Size = new Size(380, 580);

            this.dgvActivos.Dock = DockStyle.Fill;
            this.dgvActivos.Name = "dgvActivos";
            this.dgvActivos.CellClick += new DataGridViewCellEventHandler(this.dgvActivos_CellClick);
            this.dgvActivos.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvActivos_CellDoubleClick);
            this.dgvActivos.CellFormatting += new DataGridViewCellFormattingEventHandler(this.dgvActivos_CellFormatting);

            this.pnlSeparador.Name = "pnlSeparador";
            this.pnlSeparador.Dock = DockStyle.Bottom;
            this.pnlSeparador.Size = new Size(1124, 8);
            this.pnlSeparador.Visible = false;

            this.dgvUbicacion.Dock = DockStyle.Fill;
            this.dgvUbicacion.Name = "dgvUbicacion";

            this.dgvHistorial.Dock = DockStyle.Fill;
            this.dgvHistorial.Name = "dgvHistorial";

            this.dgvDanos.Dock = DockStyle.Fill;
            this.dgvDanos.Name = "dgvDanos";

            this.tabUbicacion.Controls.Add(this.dgvUbicacion);
            this.tabUbicacion.BackColor = Color.FromArgb(26, 28, 36);
            this.tabUbicacion.Name = "tabUbicacion";
            this.tabUbicacion.Text = "Ubicación";
            this.tabUbicacion.UseVisualStyleBackColor = false;

            this.tabHistorial.Controls.Add(this.dgvHistorial);
            this.tabHistorial.BackColor = Color.FromArgb(26, 28, 36);
            this.tabHistorial.Name = "tabHistorial";
            this.tabHistorial.Text = "Historial de cambios";
            this.tabHistorial.UseVisualStyleBackColor = false;

            this.tabDanos.Controls.Add(this.dgvDanos);
            this.tabDanos.BackColor = Color.FromArgb(26, 28, 36);
            this.tabDanos.Name = "tabDanos";
            this.tabDanos.Text = "Reportes de daño";
            this.tabDanos.UseVisualStyleBackColor = false;

            this.tabFicha.Controls.Add(this.tabUbicacion);
            this.tabFicha.Controls.Add(this.tabHistorial);
            this.tabFicha.Controls.Add(this.tabDanos);
            this.tabFicha.Dock = DockStyle.Fill;
            this.tabFicha.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            this.tabFicha.ItemSize = new Size(170, 28);
            this.tabFicha.Name = "tabFicha";
            this.tabFicha.SelectedIndex = 0;
            this.tabFicha.SizeMode = TabSizeMode.Fixed;

            this.lblFichaTitulo.BackColor = Color.FromArgb(21, 23, 31);
            this.lblFichaTitulo.Dock = DockStyle.Top;
            this.lblFichaTitulo.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.lblFichaTitulo.ForeColor = Color.FromArgb(226, 232, 244);
            this.lblFichaTitulo.Name = "lblFichaTitulo";
            this.lblFichaTitulo.Padding = new Padding(12, 0, 0, 0);
            this.lblFichaTitulo.Size = new Size(100, 29);
            this.lblFichaTitulo.Text = "Seleccione un activo para ver su ficha";
            this.lblFichaTitulo.TextAlign = ContentAlignment.MiddleLeft;

            this.pnlFicha.Controls.Add(this.tabFicha);
            this.pnlFicha.Controls.Add(this.lblFichaTitulo);
            this.pnlFicha.Name = "pnlFicha";
            this.pnlFicha.BackColor = Color.FromArgb(21, 23, 31);
            this.pnlFicha.Dock = DockStyle.Bottom;
            this.pnlFicha.Size = new Size(1124, 184);
            this.pnlFicha.Visible = false;

            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new Point(16, 17);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Text = "Buscar";

            this.btnExportarPdf.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnExportarPdf.Location = new Point(978, 12);
            this.btnExportarPdf.Name = "btnExportarPdf";
            this.btnExportarPdf.Size = new Size(130, 32);
            this.btnExportarPdf.Text = "Exportar a PDF";
            this.btnExportarPdf.Tipo = Vistass.TipoBoton.Secundario;
            this.btnExportarPdf.Click += new System.EventHandler(this.btnExportarPdf_Click);

            this.btnHistorial.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnHistorial.Location = new Point(875, 12);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new Size(95, 32);
            this.btnHistorial.Text = "Historial";
            this.btnHistorial.Tipo = Vistass.TipoBoton.Secundario;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);

            this.btnVerUnidades.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnVerUnidades.Location = new Point(772, 12);
            this.btnVerUnidades.Name = "btnVerUnidades";
            this.btnVerUnidades.Size = new Size(95, 32);
            this.btnVerUnidades.Text = "Unidades";
            this.btnVerUnidades.Tipo = Vistass.TipoBoton.Secundario;
            this.btnVerUnidades.Click += new System.EventHandler(this.btnVerUnidades_Click);

            this.txtBuscar.BackColor = Color.FromArgb(38, 42, 58);
            this.txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            this.txtBuscar.ForeColor = Color.FromArgb(226, 232, 244);
            this.txtBuscar.Location = new Point(74, 14);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new Size(200, 27);
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);

            this.cmbFiltroCategoria.BackColor = Color.FromArgb(38, 42, 58);
            this.cmbFiltroCategoria.FlatStyle = FlatStyle.Flat;
            this.cmbFiltroCategoria.ForeColor = Color.FromArgb(226, 232, 244);
            this.cmbFiltroCategoria.Location = new Point(286, 14);
            this.cmbFiltroCategoria.Name = "cmbFiltroCategoria";
            this.cmbFiltroCategoria.Size = new Size(180, 27);
            this.cmbFiltroCategoria.SelectedIndexChanged += new System.EventHandler(this.cmbFiltro_SelectedIndexChanged);

            this.cmbFiltroEstado.BackColor = Color.FromArgb(38, 42, 58);
            this.cmbFiltroEstado.FlatStyle = FlatStyle.Flat;
            this.cmbFiltroEstado.ForeColor = Color.FromArgb(226, 232, 244);
            this.cmbFiltroEstado.Location = new Point(478, 14);
            this.cmbFiltroEstado.Name = "cmbFiltroEstado";
            this.cmbFiltroEstado.Size = new Size(170, 27);
            this.cmbFiltroEstado.SelectedIndexChanged += new System.EventHandler(this.cmbFiltro_SelectedIndexChanged);

            this.pnlBusqueda.Controls.Add(this.lblBuscar);
            this.pnlBusqueda.Controls.Add(this.txtBuscar);
            this.pnlBusqueda.Controls.Add(this.cmbFiltroCategoria);
            this.pnlBusqueda.Controls.Add(this.cmbFiltroEstado);
            this.pnlBusqueda.Controls.Add(this.btnVerUnidades);
            this.pnlBusqueda.Controls.Add(this.btnHistorial);
            this.pnlBusqueda.Controls.Add(this.btnExportarPdf);
            this.pnlBusqueda.Name = "pnlBusqueda";
            this.pnlBusqueda.BackColor = Color.FromArgb(21, 23, 31);
            this.pnlBusqueda.Dock = DockStyle.Top;
            this.pnlBusqueda.Size = new Size(1124, 56);

            this.pnlLista.Controls.Add(this.dgvActivos);
            this.pnlLista.Controls.Add(this.pnlSeparador);
            this.pnlLista.Controls.Add(this.pnlFicha);
            this.pnlLista.Controls.Add(this.pnlBusqueda);
            this.pnlLista.Name = "pnlLista";
            this.pnlLista.Dock = DockStyle.Fill;
            this.pnlLista.Padding = new Padding(16, 0, 0, 0);
            this.pnlLista.Size = new Size(1124, 580);

            this.tabCatalogo.Controls.Add(this.pnlLista);
            this.tabCatalogo.Controls.Add(this.pnlFormulario);
            this.tabCatalogo.BackColor = Color.FromArgb(26, 28, 36);
            this.tabCatalogo.Name = "tabCatalogo";
            this.tabCatalogo.Padding = new Padding(0, 12, 0, 0);
            this.tabCatalogo.Text = "1. Catálogo";
            this.tabCatalogo.UseVisualStyleBackColor = false;

            this.lblPrestTitulo.AutoSize = true;
            this.lblPrestTitulo.Location = new Point(20, 12);
            this.lblPrestTitulo.Name = "lblPrestTitulo";
            this.lblPrestTitulo.Text = "Registrar salida de equipo";
            this.lblPrestTitulo.Font = new Font("Segoe UI Semibold", 11.5F, FontStyle.Bold);
            this.lblPrestTitulo.ForeColor = Color.FromArgb(250, 204, 21);

            this.lblPrestActivo.AutoSize = true;
            this.lblPrestActivo.Location = new Point(20, 42);
            this.lblPrestActivo.Name = "lblPrestActivo";
            this.lblPrestActivo.Text = "Equipo a prestar";

            this.cmbPrestActivo.BackColor = Color.FromArgb(38, 42, 58);
            this.cmbPrestActivo.FlatStyle = FlatStyle.Flat;
            this.cmbPrestActivo.ForeColor = Color.FromArgb(226, 232, 244);
            this.cmbPrestActivo.Location = new Point(20, 62);
            this.cmbPrestActivo.Name = "cmbPrestActivo";
            this.cmbPrestActivo.Size = new Size(340, 27);

            this.lblPrestCodigo.AutoSize = true;
            this.lblPrestCodigo.Location = new Point(20, 94);
            this.lblPrestCodigo.Name = "lblPrestCodigo";
            this.lblPrestCodigo.Text = "Código del equipo (opcional)";

            this.txtPrestCodigo.BackColor = Color.FromArgb(38, 42, 58);
            this.txtPrestCodigo.BorderStyle = BorderStyle.FixedSingle;
            this.txtPrestCodigo.ForeColor = Color.FromArgb(226, 232, 244);
            this.txtPrestCodigo.Location = new Point(20, 114);
            this.txtPrestCodigo.MaxLength = 50;
            this.txtPrestCodigo.Name = "txtPrestCodigo";
            this.txtPrestCodigo.Size = new Size(340, 27);

            this.lblPrestCant.AutoSize = true;
            this.lblPrestCant.Location = new Point(250, 94);
            this.lblPrestCant.Name = "lblPrestCant";
            this.lblPrestCant.Text = "Cantidad";
            this.lblPrestCant.Visible = false;

            this.numPrestCant.BackColor = Color.FromArgb(38, 42, 58);
            this.numPrestCant.BorderStyle = BorderStyle.FixedSingle;
            this.numPrestCant.ForeColor = Color.FromArgb(226, 232, 244);
            this.numPrestCant.Location = new Point(250, 114);
            this.numPrestCant.Maximum = new decimal(1000);
            this.numPrestCant.Minimum = new decimal(1);
            this.numPrestCant.Name = "numPrestCant";
            this.numPrestCant.Size = new Size(110, 27);
            this.numPrestCant.Value = new decimal(1);
            this.numPrestCant.Visible = false;

            this.lblPrestTipo.AutoSize = true;
            this.lblPrestTipo.Location = new Point(20, 146);
            this.lblPrestTipo.Name = "lblPrestTipo";
            this.lblPrestTipo.Text = "Tipo de responsable";

            this.cmbPrestTipo.BackColor = Color.FromArgb(38, 42, 58);
            this.cmbPrestTipo.FlatStyle = FlatStyle.Flat;
            this.cmbPrestTipo.ForeColor = Color.FromArgb(226, 232, 244);
            this.cmbPrestTipo.Location = new Point(20, 166);
            this.cmbPrestTipo.Name = "cmbPrestTipo";
            this.cmbPrestTipo.Size = new Size(340, 27);

            this.lblPrestResp.AutoSize = true;
            this.lblPrestResp.Location = new Point(20, 198);
            this.lblPrestResp.Name = "lblPrestResp";
            this.lblPrestResp.Text = "Nombre del responsable";

            this.txtPrestResp.BackColor = Color.FromArgb(38, 42, 58);
            this.txtPrestResp.BorderStyle = BorderStyle.FixedSingle;
            this.txtPrestResp.ForeColor = Color.FromArgb(226, 232, 244);
            this.txtPrestResp.Location = new Point(20, 218);
            this.txtPrestResp.MaxLength = 100;
            this.txtPrestResp.Name = "txtPrestResp";
            this.txtPrestResp.Size = new Size(340, 27);

            this.lblPrestAula.AutoSize = true;
            this.lblPrestAula.Location = new Point(20, 250);
            this.lblPrestAula.Name = "lblPrestAula";
            this.lblPrestAula.Text = "Aula de destino";

            this.cmbPrestAula.BackColor = Color.FromArgb(38, 42, 58);
            this.cmbPrestAula.FlatStyle = FlatStyle.Flat;
            this.cmbPrestAula.ForeColor = Color.FromArgb(226, 232, 244);
            this.cmbPrestAula.Location = new Point(20, 270);
            this.cmbPrestAula.Name = "cmbPrestAula";
            this.cmbPrestAula.Size = new Size(340, 27);

            this.lblPrestLimite.AutoSize = true;
            this.lblPrestLimite.Location = new Point(20, 302);
            this.lblPrestLimite.Name = "lblPrestLimite";
            this.lblPrestLimite.Text = "Fecha y hora límite de devolución";

            this.dtpPrestLimite.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpPrestLimite.Format = DateTimePickerFormat.Custom;
            this.dtpPrestLimite.Location = new Point(20, 322);
            this.dtpPrestLimite.Name = "dtpPrestLimite";
            this.dtpPrestLimite.Size = new Size(340, 27);

            this.lblPrestObs.AutoSize = true;
            this.lblPrestObs.Location = new Point(20, 354);
            this.lblPrestObs.Name = "lblPrestObs";
            this.lblPrestObs.Text = "Observaciones";

            this.txtPrestObs.BackColor = Color.FromArgb(38, 42, 58);
            this.txtPrestObs.BorderStyle = BorderStyle.FixedSingle;
            this.txtPrestObs.ForeColor = Color.FromArgb(226, 232, 244);
            this.txtPrestObs.Location = new Point(20, 374);
            this.txtPrestObs.MaxLength = 300;
            this.txtPrestObs.Name = "txtPrestObs";
            this.txtPrestObs.Size = new Size(340, 27);

            this.btnPrestar.Location = new Point(20, 0);
            this.btnPrestar.Name = "btnPrestar";
            this.btnPrestar.Size = new Size(340, 40);
            this.btnPrestar.Text = "Registrar salida";
            this.btnPrestar.Click += new System.EventHandler(this.btnPrestar_Click);

            this.pnlAccionesPrest.Controls.Add(this.btnPrestar);
            this.pnlAccionesPrest.Name = "pnlAccionesPrest";
            this.pnlAccionesPrest.Dock = DockStyle.Bottom;
            this.pnlAccionesPrest.Size = new Size(380, 56);

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
            this.pnlPrestForm.Controls.Add(this.pnlAccionesPrest);
            this.pnlPrestForm.Name = "pnlPrestForm";
            this.pnlPrestForm.BackColor = Color.FromArgb(21, 23, 31);
            this.pnlPrestForm.Dock = DockStyle.Left;
            this.pnlPrestForm.Size = new Size(380, 580);

            this.dgvPrestamos.Dock = DockStyle.Fill;
            this.dgvPrestamos.Name = "dgvPrestamos";
            this.dgvPrestamos.CellFormatting += new DataGridViewCellFormattingEventHandler(this.dgvPrestamos_CellFormatting);
            this.dgvPrestamos.SelectionChanged += new System.EventHandler(this.dgvPrestamos_SelectionChanged);

            this.lblDevSel.BackColor = Color.FromArgb(21, 23, 31);
            this.lblDevSel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.lblDevSel.ForeColor = Color.FromArgb(226, 232, 244);
            this.lblDevSel.Location = new Point(16, 12);
            this.lblDevSel.Name = "lblDevSel";
            this.lblDevSel.Size = new Size(700, 22);
            this.lblDevSel.Text = "Seleccione un préstamo para devolverlo o imprimir su hoja";

            this.lblDevEstado.AutoSize = true;
            this.lblDevEstado.Location = new Point(16, 48);
            this.lblDevEstado.Name = "lblDevEstado";
            this.lblDevEstado.Text = "Estado físico al devolver";

            this.cmbDevEstado.BackColor = Color.FromArgb(38, 42, 58);
            this.cmbDevEstado.FlatStyle = FlatStyle.Flat;
            this.cmbDevEstado.ForeColor = Color.FromArgb(226, 232, 244);
            this.cmbDevEstado.Location = new Point(16, 70);
            this.cmbDevEstado.Name = "cmbDevEstado";
            this.cmbDevEstado.Size = new Size(220, 27);

            this.lblDevObs.AutoSize = true;
            this.lblDevObs.Location = new Point(252, 48);
            this.lblDevObs.Name = "lblDevObs";
            this.lblDevObs.Text = "Observación de la devolución";

            this.txtDevObs.BackColor = Color.FromArgb(38, 42, 58);
            this.txtDevObs.BorderStyle = BorderStyle.FixedSingle;
            this.txtDevObs.ForeColor = Color.FromArgb(226, 232, 244);
            this.txtDevObs.Location = new Point(252, 70);
            this.txtDevObs.MaxLength = 300;
            this.txtDevObs.Name = "txtDevObs";
            this.txtDevObs.Size = new Size(330, 27);

            this.btnDevolver.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left)));
            this.btnDevolver.Location = new Point(600, 66);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new Size(190, 34);
            this.btnDevolver.Text = "Registrar devolución";
            this.btnDevolver.Click += new System.EventHandler(this.btnDevolver_Click);

            this.btnHoja.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left)));
            this.btnHoja.Location = new Point(798, 66);
            this.btnHoja.Name = "btnHoja";
            this.btnHoja.Size = new Size(200, 34);
            this.btnHoja.Text = "Hoja de resguardo (PDF)";
            this.btnHoja.Tipo = Vistass.TipoBoton.Secundario;
            this.btnHoja.Click += new System.EventHandler(this.btnHoja_Click);

            this.pnlDevolucion.Controls.Add(this.lblDevSel);
            this.pnlDevolucion.Controls.Add(this.lblDevEstado);
            this.pnlDevolucion.Controls.Add(this.cmbDevEstado);
            this.pnlDevolucion.Controls.Add(this.lblDevObs);
            this.pnlDevolucion.Controls.Add(this.txtDevObs);
            this.pnlDevolucion.Controls.Add(this.btnDevolver);
            this.pnlDevolucion.Controls.Add(this.btnHoja);
            this.pnlDevolucion.Name = "pnlDevolucion";
            this.pnlDevolucion.BackColor = Color.FromArgb(21, 23, 31);
            this.pnlDevolucion.Dock = DockStyle.Bottom;
            this.pnlDevolucion.Size = new Size(1124, 124);

            this.lblPrestVer.AutoSize = true;
            this.lblPrestVer.Location = new Point(16, 16);
            this.lblPrestVer.Name = "lblPrestVer";
            this.lblPrestVer.Text = "Mostrar";

            this.cmbPrestVer.BackColor = Color.FromArgb(38, 42, 58);
            this.cmbPrestVer.FlatStyle = FlatStyle.Flat;
            this.cmbPrestVer.ForeColor = Color.FromArgb(226, 232, 244);
            this.cmbPrestVer.Location = new Point(82, 12);
            this.cmbPrestVer.Name = "cmbPrestVer";
            this.cmbPrestVer.Size = new Size(170, 27);
            this.cmbPrestVer.SelectedIndexChanged += new System.EventHandler(this.cmbPrestVer_SelectedIndexChanged);

            this.lblPrestAlertas.AutoSize = true;
            this.lblPrestAlertas.Location = new Point(264, 16);
            this.lblPrestAlertas.Name = "lblPrestAlertas";
            this.lblPrestAlertas.Text = "";
            this.lblPrestAlertas.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.lblPrestAlertas.ForeColor = Color.FromArgb(150, 160, 182);

            this.pnlPrestFiltro.Controls.Add(this.lblPrestVer);
            this.pnlPrestFiltro.Controls.Add(this.cmbPrestVer);
            this.pnlPrestFiltro.Controls.Add(this.lblPrestAlertas);
            this.pnlPrestFiltro.Name = "pnlPrestFiltro";
            this.pnlPrestFiltro.BackColor = Color.FromArgb(21, 23, 31);
            this.pnlPrestFiltro.Dock = DockStyle.Top;
            this.pnlPrestFiltro.Size = new Size(1124, 52);

            this.pnlPrestLista.Controls.Add(this.dgvPrestamos);
            this.pnlPrestLista.Controls.Add(this.pnlDevolucion);
            this.pnlPrestLista.Controls.Add(this.pnlPrestFiltro);
            this.pnlPrestLista.Name = "pnlPrestLista";
            this.pnlPrestLista.Dock = DockStyle.Fill;
            this.pnlPrestLista.Padding = new Padding(16, 0, 0, 0);
            this.pnlPrestLista.Size = new Size(1124, 580);

            this.tabPrestamos.Controls.Add(this.pnlPrestLista);
            this.tabPrestamos.Controls.Add(this.pnlPrestForm);
            this.tabPrestamos.BackColor = Color.FromArgb(26, 28, 36);
            this.tabPrestamos.Name = "tabPrestamos";
            this.tabPrestamos.Padding = new Padding(0, 12, 0, 0);
            this.tabPrestamos.Text = "2. Préstamos";
            this.tabPrestamos.UseVisualStyleBackColor = false;

            this.lblConsNuevo.AutoSize = true;
            this.lblConsNuevo.Location = new Point(20, 12);
            this.lblConsNuevo.Name = "lblConsNuevo";
            this.lblConsNuevo.Text = "Nuevo consumible";
            this.lblConsNuevo.Font = new Font("Segoe UI Semibold", 11.5F, FontStyle.Bold);
            this.lblConsNuevo.ForeColor = Color.FromArgb(250, 204, 21);

            this.lblConsNombre.AutoSize = true;
            this.lblConsNombre.Location = new Point(20, 42);
            this.lblConsNombre.Name = "lblConsNombre";
            this.lblConsNombre.Text = "Nombre (ej. Resma de papel carta)";

            this.txtConsNombre.BackColor = Color.FromArgb(38, 42, 58);
            this.txtConsNombre.BorderStyle = BorderStyle.FixedSingle;
            this.txtConsNombre.ForeColor = Color.FromArgb(226, 232, 244);
            this.txtConsNombre.Location = new Point(20, 62);
            this.txtConsNombre.MaxLength = 100;
            this.txtConsNombre.Name = "txtConsNombre";
            this.txtConsNombre.Size = new Size(340, 27);

            this.lblConsUnidad.AutoSize = true;
            this.lblConsUnidad.Location = new Point(20, 98);
            this.lblConsUnidad.Name = "lblConsUnidad";
            this.lblConsUnidad.Text = "Unidad de medida";

            this.txtConsUnidad.BackColor = Color.FromArgb(38, 42, 58);
            this.txtConsUnidad.BorderStyle = BorderStyle.FixedSingle;
            this.txtConsUnidad.ForeColor = Color.FromArgb(226, 232, 244);
            this.txtConsUnidad.Location = new Point(20, 118);
            this.txtConsUnidad.MaxLength = 30;
            this.txtConsUnidad.Name = "txtConsUnidad";
            this.txtConsUnidad.Size = new Size(160, 27);

            this.lblConsMin.AutoSize = true;
            this.lblConsMin.Location = new Point(196, 98);
            this.lblConsMin.Name = "lblConsMin";
            this.lblConsMin.Text = "Stock mínimo";

            this.numConsMin.BackColor = Color.FromArgb(38, 42, 58);
            this.numConsMin.BorderStyle = BorderStyle.FixedSingle;
            this.numConsMin.ForeColor = Color.FromArgb(226, 232, 244);
            this.numConsMin.Location = new Point(196, 118);
            this.numConsMin.Maximum = new decimal(100000);
            this.numConsMin.Name = "numConsMin";
            this.numConsMin.Size = new Size(164, 27);

            this.btnConsCrear.Location = new Point(20, 152);
            this.btnConsCrear.Name = "btnConsCrear";
            this.btnConsCrear.Size = new Size(340, 40);
            this.btnConsCrear.Text = "Crear consumible";
            this.btnConsCrear.Click += new System.EventHandler(this.btnConsCrear_Click);

            this.lblMovTitulo.AutoSize = true;
            this.lblMovTitulo.Location = new Point(20, 206);
            this.lblMovTitulo.Name = "lblMovTitulo";
            this.lblMovTitulo.Text = "Registrar movimiento";
            this.lblMovTitulo.Font = new Font("Segoe UI Semibold", 11.5F, FontStyle.Bold);
            this.lblMovTitulo.ForeColor = Color.FromArgb(250, 204, 21);

            this.lblMovCons.AutoSize = true;
            this.lblMovCons.Location = new Point(20, 238);
            this.lblMovCons.Name = "lblMovCons";
            this.lblMovCons.Text = "Consumible";

            this.cmbMovCons.BackColor = Color.FromArgb(38, 42, 58);
            this.cmbMovCons.FlatStyle = FlatStyle.Flat;
            this.cmbMovCons.ForeColor = Color.FromArgb(226, 232, 244);
            this.cmbMovCons.Location = new Point(20, 258);
            this.cmbMovCons.Name = "cmbMovCons";
            this.cmbMovCons.Size = new Size(340, 27);

            this.lblMovTipo.AutoSize = true;
            this.lblMovTipo.Location = new Point(20, 296);
            this.lblMovTipo.Name = "lblMovTipo";
            this.lblMovTipo.Text = "Tipo";

            this.cmbMovTipo.BackColor = Color.FromArgb(38, 42, 58);
            this.cmbMovTipo.FlatStyle = FlatStyle.Flat;
            this.cmbMovTipo.ForeColor = Color.FromArgb(226, 232, 244);
            this.cmbMovTipo.Location = new Point(20, 316);
            this.cmbMovTipo.Name = "cmbMovTipo";
            this.cmbMovTipo.Size = new Size(160, 27);
            this.cmbMovTipo.SelectedIndexChanged += new System.EventHandler(this.cmbMovTipo_SelectedIndexChanged);

            this.lblMovCant.AutoSize = true;
            this.lblMovCant.Location = new Point(196, 296);
            this.lblMovCant.Name = "lblMovCant";
            this.lblMovCant.Text = "Cantidad";

            this.numMovCant.BackColor = Color.FromArgb(38, 42, 58);
            this.numMovCant.BorderStyle = BorderStyle.FixedSingle;
            this.numMovCant.ForeColor = Color.FromArgb(226, 232, 244);
            this.numMovCant.Location = new Point(196, 316);
            this.numMovCant.Maximum = new decimal(100000);
            this.numMovCant.Minimum = new decimal(1);
            this.numMovCant.Name = "numMovCant";
            this.numMovCant.Size = new Size(164, 27);
            this.numMovCant.Value = new decimal(1);

            this.lblMovMotivo.AutoSize = true;
            this.lblMovMotivo.Location = new Point(20, 354);
            this.lblMovMotivo.Name = "lblMovMotivo";
            this.lblMovMotivo.Text = "Motivo";

            this.cmbMovMotivo.BackColor = Color.FromArgb(38, 42, 58);
            this.cmbMovMotivo.FlatStyle = FlatStyle.Flat;
            this.cmbMovMotivo.ForeColor = Color.FromArgb(226, 232, 244);
            this.cmbMovMotivo.Location = new Point(20, 374);
            this.cmbMovMotivo.Name = "cmbMovMotivo";
            this.cmbMovMotivo.Size = new Size(340, 27);

            this.lblMovDestino.AutoSize = true;
            this.lblMovDestino.Location = new Point(20, 412);
            this.lblMovDestino.Name = "lblMovDestino";
            this.lblMovDestino.Text = "Destino o referencia (aula, factura…)";

            this.txtMovDestino.BackColor = Color.FromArgb(38, 42, 58);
            this.txtMovDestino.FlatStyle = FlatStyle.Flat;
            this.txtMovDestino.ForeColor = Color.FromArgb(226, 232, 244);
            this.txtMovDestino.Location = new Point(20, 432);
            this.txtMovDestino.MaxLength = 100;
            this.txtMovDestino.Name = "txtMovDestino";
            this.txtMovDestino.Size = new Size(340, 27);

            this.btnMovimiento.Location = new Point(20, 0);
            this.btnMovimiento.Name = "btnMovimiento";
            this.btnMovimiento.Size = new Size(340, 40);
            this.btnMovimiento.Text = "Registrar movimiento";
            this.btnMovimiento.Click += new System.EventHandler(this.btnMovimiento_Click);

            this.pnlAccionesCons.Controls.Add(this.btnMovimiento);
            this.pnlAccionesCons.Name = "pnlAccionesCons";
            this.pnlAccionesCons.Dock = DockStyle.Bottom;
            this.pnlAccionesCons.Size = new Size(380, 56);

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
            this.pnlConsForm.Controls.Add(this.pnlAccionesCons);
            this.pnlConsForm.Name = "pnlConsForm";
            this.pnlConsForm.BackColor = Color.FromArgb(21, 23, 31);
            this.pnlConsForm.Dock = DockStyle.Left;
            this.pnlConsForm.Size = new Size(380, 580);

            this.dgvStock.Dock = DockStyle.Fill;
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.CellFormatting += new DataGridViewCellFormattingEventHandler(this.dgvStock_CellFormatting);
            this.dgvStock.SelectionChanged += new System.EventHandler(this.dgvStock_SelectionChanged);

            this.lblStockTitulo.BackColor = Color.FromArgb(21, 23, 31);
            this.lblStockTitulo.Dock = DockStyle.Top;
            this.lblStockTitulo.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.lblStockTitulo.ForeColor = Color.FromArgb(226, 232, 244);
            this.lblStockTitulo.Name = "lblStockTitulo";
            this.lblStockTitulo.Padding = new Padding(12, 0, 0, 0);
            this.lblStockTitulo.Size = new Size(100, 36);
            this.lblStockTitulo.Text = "Existencias (clic en una fila para ver su kardex)";
            this.lblStockTitulo.TextAlign = ContentAlignment.MiddleLeft;

            this.pnlStock.Controls.Add(this.dgvStock);
            this.pnlStock.Controls.Add(this.lblStockTitulo);
            this.pnlStock.Name = "pnlStock";
            this.pnlStock.Dock = DockStyle.Top;
            this.pnlStock.Size = new Size(1108, 220);

            this.dgvKardex.Dock = DockStyle.Fill;
            this.dgvKardex.Name = "dgvKardex";

            this.lblKardexTitulo.AutoSize = true;
            this.lblKardexTitulo.Location = new Point(12, 12);
            this.lblKardexTitulo.Name = "lblKardexTitulo";
            this.lblKardexTitulo.Text = "Kardex";
            this.lblKardexTitulo.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.lblKardexTitulo.ForeColor = Color.FromArgb(226, 232, 244);

            this.btnKardexTodos.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnKardexTodos.Location = new Point(888, 6);
            this.btnKardexTodos.Name = "btnKardexTodos";
            this.btnKardexTodos.Size = new Size(220, 32);
            this.btnKardexTodos.Text = "Ver todos los movimientos";
            this.btnKardexTodos.Tipo = Vistass.TipoBoton.Secundario;
            this.btnKardexTodos.Click += new System.EventHandler(this.btnKardexTodos_Click);

            this.pnlKardexBarra.Controls.Add(this.lblKardexTitulo);
            this.pnlKardexBarra.Controls.Add(this.btnKardexTodos);
            this.pnlKardexBarra.Name = "pnlKardexBarra";
            this.pnlKardexBarra.BackColor = Color.FromArgb(21, 23, 31);
            this.pnlKardexBarra.Dock = DockStyle.Top;
            this.pnlKardexBarra.Size = new Size(1108, 44);

            this.pnlConsLista.Controls.Add(this.dgvKardex);
            this.pnlConsLista.Controls.Add(this.pnlKardexBarra);
            this.pnlConsLista.Controls.Add(this.pnlStock);
            this.pnlConsLista.Name = "pnlConsLista";
            this.pnlConsLista.Dock = DockStyle.Fill;
            this.pnlConsLista.Padding = new Padding(16, 0, 0, 0);
            this.pnlConsLista.Size = new Size(1124, 580);

            this.tabConsumibles.Controls.Add(this.pnlConsLista);
            this.tabConsumibles.Controls.Add(this.pnlConsForm);
            this.tabConsumibles.BackColor = Color.FromArgb(26, 28, 36);
            this.tabConsumibles.Name = "tabConsumibles";
            this.tabConsumibles.Padding = new Padding(0, 12, 0, 0);
            this.tabConsumibles.Text = "3. Consumibles";
            this.tabConsumibles.UseVisualStyleBackColor = false;

            this.lblMantTitulo.AutoSize = true;
            this.lblMantTitulo.Location = new Point(20, 16);
            this.lblMantTitulo.Name = "lblMantTitulo";
            this.lblMantTitulo.Text = "Registrar mantenimiento";
            this.lblMantTitulo.Font = new Font("Segoe UI Semibold", 11.5F, FontStyle.Bold);
            this.lblMantTitulo.ForeColor = Color.FromArgb(250, 204, 21);

            this.lblMantActivo.AutoSize = true;
            this.lblMantActivo.Location = new Point(20, 48);
            this.lblMantActivo.Name = "lblMantActivo";
            this.lblMantActivo.Text = "Equipo";

            this.cmbMantActivo.BackColor = Color.FromArgb(38, 42, 58);
            this.cmbMantActivo.FlatStyle = FlatStyle.Flat;
            this.cmbMantActivo.ForeColor = Color.FromArgb(226, 232, 244);
            this.cmbMantActivo.Location = new Point(20, 70);
            this.cmbMantActivo.Name = "cmbMantActivo";
            this.cmbMantActivo.Size = new Size(340, 27);

            this.lblMantCodigo.AutoSize = true;
            this.lblMantCodigo.Location = new Point(20, 110);
            this.lblMantCodigo.Name = "lblMantCodigo";
            this.lblMantCodigo.Text = "Código (opcional)";

            this.txtMantCodigo.BackColor = Color.FromArgb(38, 42, 58);
            this.txtMantCodigo.BorderStyle = BorderStyle.FixedSingle;
            this.txtMantCodigo.ForeColor = Color.FromArgb(226, 232, 244);
            this.txtMantCodigo.Location = new Point(20, 132);
            this.txtMantCodigo.MaxLength = 50;
            this.txtMantCodigo.Name = "txtMantCodigo";
            this.txtMantCodigo.Size = new Size(160, 27);

            this.lblMantFecha.AutoSize = true;
            this.lblMantFecha.Location = new Point(196, 110);
            this.lblMantFecha.Name = "lblMantFecha";
            this.lblMantFecha.Text = "Fecha del servicio";

            this.dtpMantFecha.Format = DateTimePickerFormat.Short;
            this.dtpMantFecha.Location = new Point(196, 132);
            this.dtpMantFecha.Name = "dtpMantFecha";
            this.dtpMantFecha.Size = new Size(164, 27);

            this.lblMantTipo.AutoSize = true;
            this.lblMantTipo.Location = new Point(20, 172);
            this.lblMantTipo.Name = "lblMantTipo";
            this.lblMantTipo.Text = "Tipo";

            this.cmbMantTipo.BackColor = Color.FromArgb(38, 42, 58);
            this.cmbMantTipo.FlatStyle = FlatStyle.Flat;
            this.cmbMantTipo.ForeColor = Color.FromArgb(226, 232, 244);
            this.cmbMantTipo.Location = new Point(20, 194);
            this.cmbMantTipo.Name = "cmbMantTipo";
            this.cmbMantTipo.Size = new Size(160, 27);

            this.lblMantCosto.AutoSize = true;
            this.lblMantCosto.Location = new Point(196, 172);
            this.lblMantCosto.Name = "lblMantCosto";
            this.lblMantCosto.Text = "Costo";

            this.numMantCosto.BackColor = Color.FromArgb(38, 42, 58);
            this.numMantCosto.BorderStyle = BorderStyle.FixedSingle;
            this.numMantCosto.DecimalPlaces = 2;
            this.numMantCosto.ForeColor = Color.FromArgb(226, 232, 244);
            this.numMantCosto.Location = new Point(196, 194);
            this.numMantCosto.Maximum = new decimal(1000000);
            this.numMantCosto.Name = "numMantCosto";
            this.numMantCosto.Size = new Size(164, 27);

            this.lblMantEstado.AutoSize = true;
            this.lblMantEstado.Location = new Point(20, 234);
            this.lblMantEstado.Name = "lblMantEstado";
            this.lblMantEstado.Text = "Estado resultante del equipo";

            this.cmbMantEstado.BackColor = Color.FromArgb(38, 42, 58);
            this.cmbMantEstado.FlatStyle = FlatStyle.Flat;
            this.cmbMantEstado.ForeColor = Color.FromArgb(226, 232, 244);
            this.cmbMantEstado.Location = new Point(20, 256);
            this.cmbMantEstado.Name = "cmbMantEstado";
            this.cmbMantEstado.Size = new Size(340, 27);

            this.lblMantDesc.AutoSize = true;
            this.lblMantDesc.Location = new Point(20, 296);
            this.lblMantDesc.Name = "lblMantDesc";
            this.lblMantDesc.Text = "Descripción del servicio";

            this.txtMantDesc.BackColor = Color.FromArgb(38, 42, 58);
            this.txtMantDesc.BorderStyle = BorderStyle.FixedSingle;
            this.txtMantDesc.ForeColor = Color.FromArgb(226, 232, 244);
            this.txtMantDesc.Location = new Point(20, 318);
            this.txtMantDesc.MaxLength = 500;
            this.txtMantDesc.Multiline = true;
            this.txtMantDesc.Name = "txtMantDesc";
            this.txtMantDesc.Size = new Size(340, 64);

            this.lblMantVinculo.Location = new Point(20, 392);
            this.lblMantVinculo.Name = "lblMantVinculo";
            this.lblMantVinculo.Size = new Size(340, 34);
            this.lblMantVinculo.Text = "Sin reporte de daño vinculado (seleccione uno de la tabla para cerrarlo al guardar)";
            this.lblMantVinculo.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.lblMantVinculo.ForeColor = Color.FromArgb(150, 160, 182);

            this.btnMantRegistrar.Location = new Point(20, 0);
            this.btnMantRegistrar.Name = "btnMantRegistrar";
            this.btnMantRegistrar.Size = new Size(340, 40);
            this.btnMantRegistrar.Text = "Registrar mantenimiento";
            this.btnMantRegistrar.Click += new System.EventHandler(this.btnMantRegistrar_Click);

            this.btnMantLimpiar.Location = new Point(20, 50);
            this.btnMantLimpiar.Name = "btnMantLimpiar";
            this.btnMantLimpiar.Size = new Size(340, 40);
            this.btnMantLimpiar.Text = "Limpiar";
            this.btnMantLimpiar.Tipo = Vistass.TipoBoton.Secundario;
            this.btnMantLimpiar.Click += new System.EventHandler(this.btnMantLimpiar_Click);

            this.pnlAccionesMant.Controls.Add(this.btnMantRegistrar);
            this.pnlAccionesMant.Controls.Add(this.btnMantLimpiar);
            this.pnlAccionesMant.Name = "pnlAccionesMant";
            this.pnlAccionesMant.Dock = DockStyle.Bottom;
            this.pnlAccionesMant.Size = new Size(380, 106);

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
            this.pnlMantForm.Controls.Add(this.pnlAccionesMant);
            this.pnlMantForm.Name = "pnlMantForm";
            this.pnlMantForm.BackColor = Color.FromArgb(21, 23, 31);
            this.pnlMantForm.Dock = DockStyle.Left;
            this.pnlMantForm.Size = new Size(380, 580);

            this.dgvMantenimientos.Dock = DockStyle.Fill;
            this.dgvMantenimientos.Name = "dgvMantenimientos";

            this.lblMantHistTitulo.BackColor = Color.FromArgb(21, 23, 31);
            this.lblMantHistTitulo.Dock = DockStyle.Top;
            this.lblMantHistTitulo.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.lblMantHistTitulo.ForeColor = Color.FromArgb(226, 232, 244);
            this.lblMantHistTitulo.Name = "lblMantHistTitulo";
            this.lblMantHistTitulo.Padding = new Padding(12, 0, 0, 0);
            this.lblMantHistTitulo.Size = new Size(100, 36);
            this.lblMantHistTitulo.Text = "Bitácora de mantenimiento";
            this.lblMantHistTitulo.TextAlign = ContentAlignment.MiddleLeft;

            this.pnlMantLista.Controls.Add(this.dgvMantenimientos);
            this.pnlMantLista.Controls.Add(this.lblMantHistTitulo);
            this.pnlMantLista.Name = "pnlMantLista";
            this.pnlMantLista.Dock = DockStyle.Fill;
            this.pnlMantLista.Padding = new Padding(16, 0, 0, 0);
            this.pnlMantLista.Size = new Size(1124, 580);

            this.tabMantenimiento.Controls.Add(this.pnlMantLista);
            this.tabMantenimiento.Controls.Add(this.pnlMantForm);
            this.tabMantenimiento.BackColor = Color.FromArgb(26, 28, 36);
            this.tabMantenimiento.Name = "tabMantenimiento";
            this.tabMantenimiento.Padding = new Padding(0, 12, 0, 0);
            this.tabMantenimiento.Text = "4. Mantenimiento";
            this.tabMantenimiento.UseVisualStyleBackColor = false;

            this.dgvReporte.Dock = DockStyle.Fill;
            this.dgvReporte.Name = "dgvReporte";

            this.lblRepTipo.AutoSize = true;
            this.lblRepTipo.Location = new Point(16, 10);
            this.lblRepTipo.Name = "lblRepTipo";
            this.lblRepTipo.Text = "Reporte";

            this.cmbRepTipo.BackColor = Color.FromArgb(38, 42, 58);
            this.cmbRepTipo.FlatStyle = FlatStyle.Flat;
            this.cmbRepTipo.ForeColor = Color.FromArgb(226, 232, 244);
            this.cmbRepTipo.Location = new Point(16, 32);
            this.cmbRepTipo.Name = "cmbRepTipo";
            this.cmbRepTipo.Size = new Size(340, 27);
            this.cmbRepTipo.SelectedIndexChanged += new System.EventHandler(this.cmbRepTipo_SelectedIndexChanged);

            this.lblRepSalon.AutoSize = true;
            this.lblRepSalon.Location = new Point(372, 10);
            this.lblRepSalon.Name = "lblRepSalon";
            this.lblRepSalon.Text = "Aula o departamento";

            this.cmbRepSalon.BackColor = Color.FromArgb(38, 42, 58);
            this.cmbRepSalon.FlatStyle = FlatStyle.Flat;
            this.cmbRepSalon.ForeColor = Color.FromArgb(226, 232, 244);
            this.cmbRepSalon.Location = new Point(372, 32);
            this.cmbRepSalon.Name = "cmbRepSalon";
            this.cmbRepSalon.Size = new Size(230, 27);

            this.lblRepDesde.AutoSize = true;
            this.lblRepDesde.Location = new Point(618, 10);
            this.lblRepDesde.Name = "lblRepDesde";
            this.lblRepDesde.Text = "Desde";

            this.dtpRepDesde.Format = DateTimePickerFormat.Short;
            this.dtpRepDesde.Location = new Point(618, 32);
            this.dtpRepDesde.Name = "dtpRepDesde";
            this.dtpRepDesde.Size = new Size(130, 27);

            this.lblRepHasta.AutoSize = true;
            this.lblRepHasta.Location = new Point(764, 10);
            this.lblRepHasta.Name = "lblRepHasta";
            this.lblRepHasta.Text = "Hasta";

            this.dtpRepHasta.Format = DateTimePickerFormat.Short;
            this.dtpRepHasta.Location = new Point(764, 32);
            this.dtpRepHasta.Name = "dtpRepHasta";
            this.dtpRepHasta.Size = new Size(130, 27);

            this.btnRepGenerar.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left)));
            this.btnRepGenerar.Location = new Point(910, 30);
            this.btnRepGenerar.Name = "btnRepGenerar";
            this.btnRepGenerar.Size = new Size(110, 32);
            this.btnRepGenerar.Text = "Generar";
            this.btnRepGenerar.Click += new System.EventHandler(this.btnRepGenerar_Click);

            this.btnRepPdf.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left)));
            this.btnRepPdf.Location = new Point(1028, 30);
            this.btnRepPdf.Name = "btnRepPdf";
            this.btnRepPdf.Size = new Size(140, 32);
            this.btnRepPdf.Text = "Exportar a PDF";
            this.btnRepPdf.Tipo = Vistass.TipoBoton.Secundario;
            this.btnRepPdf.Click += new System.EventHandler(this.btnRepPdf_Click);

            this.lblRepInfo.AutoSize = true;
            this.lblRepInfo.Location = new Point(16, 68);
            this.lblRepInfo.Name = "lblRepInfo";
            this.lblRepInfo.Text = "Elija un reporte y presione Generar";
            this.lblRepInfo.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.lblRepInfo.ForeColor = Color.FromArgb(150, 160, 182);

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
            this.pnlRepFiltros.Name = "pnlRepFiltros";
            this.pnlRepFiltros.BackColor = Color.FromArgb(21, 23, 31);
            this.pnlRepFiltros.Dock = DockStyle.Top;
            this.pnlRepFiltros.Size = new Size(1200, 96);

            this.tabReportes.Controls.Add(this.dgvReporte);
            this.tabReportes.Controls.Add(this.pnlRepFiltros);
            this.tabReportes.BackColor = Color.FromArgb(26, 28, 36);
            this.tabReportes.Name = "tabReportes";
            this.tabReportes.Padding = new Padding(0, 12, 0, 0);
            this.tabReportes.Text = "5. Reportes";
            this.tabReportes.UseVisualStyleBackColor = false;

            this.tabPrincipal.Controls.Add(this.tabCatalogo);
            this.tabPrincipal.Controls.Add(this.tabPrestamos);
            this.tabPrincipal.Controls.Add(this.tabConsumibles);
            this.tabPrincipal.Controls.Add(this.tabMantenimiento);
            this.tabPrincipal.Controls.Add(this.tabReportes);
            this.tabPrincipal.Dock = DockStyle.Fill;
            this.tabPrincipal.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            this.tabPrincipal.ItemSize = new Size(190, 36);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.SelectedIndex = 0;
            this.tabPrincipal.SizeMode = TabSizeMode.Fixed;
            this.tabPrincipal.SelectedIndexChanged += new System.EventHandler(this.tabPrincipal_SelectedIndexChanged);

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.White;
            this.lblTitulo.Location = new Point(0, 6);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new Size(401, 32);
            this.lblTitulo.Text = "Gestión de activos escolares";

            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.ForeColor = Color.FromArgb(150, 160, 182);
            this.lblSubtitulo.Location = new Point(2, 44);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new Size(600, 19);
            this.lblSubtitulo.Text = "Catálogo, préstamos, consumibles, mantenimiento y reportes de los bienes de la institución";

            this.pnlEncabezado.Controls.Add(this.lblTitulo);
            this.pnlEncabezado.Controls.Add(this.lblSubtitulo);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Dock = DockStyle.Top;
            this.pnlEncabezado.Size = new Size(1200, 72);

            this.lblKpi1.Dock = DockStyle.Top;
            this.lblKpi1.Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold);
            this.lblKpi1.ForeColor = Color.FromArgb(250, 204, 21);
            this.lblKpi1.Name = "lblKpi1";
            this.lblKpi1.Size = new Size(100, 44);
            this.lblKpi1.Text = "0";

            this.lblKpi1Txt.Dock = DockStyle.Fill;
            this.lblKpi1Txt.ForeColor = Color.FromArgb(150, 160, 182);
            this.lblKpi1Txt.Name = "lblKpi1Txt";
            this.lblKpi1Txt.Size = new Size(100, 40);
            this.lblKpi1Txt.Text = "Activos registrados";
            this.lblKpi1Txt.TextAlign = ContentAlignment.TopLeft;

            this.pnlKpi1.Controls.Add(this.lblKpi1Txt);
            this.pnlKpi1.Controls.Add(this.lblKpi1);
            this.pnlKpi1.Name = "pnlKpi1";
            this.pnlKpi1.BackColor = Color.FromArgb(21, 23, 31);
            this.pnlKpi1.Dock = DockStyle.Fill;
            this.pnlKpi1.Margin = new Padding(0, 0, 12, 0);
            this.pnlKpi1.Padding = new Padding(18, 10, 10, 8);
            this.pnlKpi1.Size = new Size(200, 96);

            this.lblKpi2.Dock = DockStyle.Top;
            this.lblKpi2.Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold);
            this.lblKpi2.ForeColor = Color.FromArgb(250, 204, 21);
            this.lblKpi2.Name = "lblKpi2";
            this.lblKpi2.Size = new Size(100, 44);
            this.lblKpi2.Text = "0";

            this.lblKpi2Txt.Dock = DockStyle.Fill;
            this.lblKpi2Txt.ForeColor = Color.FromArgb(150, 160, 182);
            this.lblKpi2Txt.Name = "lblKpi2Txt";
            this.lblKpi2Txt.Size = new Size(100, 40);
            this.lblKpi2Txt.Text = "Préstamos activos";
            this.lblKpi2Txt.TextAlign = ContentAlignment.TopLeft;

            this.pnlKpi2.Controls.Add(this.lblKpi2Txt);
            this.pnlKpi2.Controls.Add(this.lblKpi2);
            this.pnlKpi2.Name = "pnlKpi2";
            this.pnlKpi2.BackColor = Color.FromArgb(21, 23, 31);
            this.pnlKpi2.Dock = DockStyle.Fill;
            this.pnlKpi2.Margin = new Padding(0, 0, 12, 0);
            this.pnlKpi2.Padding = new Padding(18, 10, 10, 8);
            this.pnlKpi2.Size = new Size(200, 96);

            this.lblKpi3.Dock = DockStyle.Top;
            this.lblKpi3.Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold);
            this.lblKpi3.ForeColor = Color.FromArgb(76, 217, 100);
            this.lblKpi3.Name = "lblKpi3";
            this.lblKpi3.Size = new Size(100, 44);
            this.lblKpi3.Text = "0";

            this.lblKpi3Txt.Dock = DockStyle.Fill;
            this.lblKpi3Txt.ForeColor = Color.FromArgb(150, 160, 182);
            this.lblKpi3Txt.Name = "lblKpi3Txt";
            this.lblKpi3Txt.Size = new Size(100, 40);
            this.lblKpi3Txt.Text = "Préstamos atrasados";
            this.lblKpi3Txt.TextAlign = ContentAlignment.TopLeft;

            this.pnlKpi3.Controls.Add(this.lblKpi3Txt);
            this.pnlKpi3.Controls.Add(this.lblKpi3);
            this.pnlKpi3.Name = "pnlKpi3";
            this.pnlKpi3.BackColor = Color.FromArgb(21, 23, 31);
            this.pnlKpi3.Dock = DockStyle.Fill;
            this.pnlKpi3.Margin = new Padding(0, 0, 12, 0);
            this.pnlKpi3.Padding = new Padding(18, 10, 10, 8);
            this.pnlKpi3.Size = new Size(200, 96);

            this.lblKpi4.Dock = DockStyle.Top;
            this.lblKpi4.Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold);
            this.lblKpi4.ForeColor = Color.FromArgb(250, 204, 21);
            this.lblKpi4.Name = "lblKpi4";
            this.lblKpi4.Size = new Size(100, 44);
            this.lblKpi4.Text = "0";

            this.lblKpi4Txt.Dock = DockStyle.Fill;
            this.lblKpi4Txt.ForeColor = Color.FromArgb(150, 160, 182);
            this.lblKpi4Txt.Name = "lblKpi4Txt";
            this.lblKpi4Txt.Size = new Size(100, 40);
            this.lblKpi4Txt.Text = "Reportes de daño abiertos";
            this.lblKpi4Txt.TextAlign = ContentAlignment.TopLeft;

            this.pnlKpi4.Controls.Add(this.lblKpi4Txt);
            this.pnlKpi4.Controls.Add(this.lblKpi4);
            this.pnlKpi4.Name = "pnlKpi4";
            this.pnlKpi4.BackColor = Color.FromArgb(21, 23, 31);
            this.pnlKpi4.Dock = DockStyle.Fill;
            this.pnlKpi4.Margin = new Padding(0, 0, 12, 0);
            this.pnlKpi4.Padding = new Padding(18, 10, 10, 8);
            this.pnlKpi4.Size = new Size(200, 96);

            this.lblKpi5.Dock = DockStyle.Top;
            this.lblKpi5.Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold);
            this.lblKpi5.ForeColor = Color.FromArgb(76, 217, 100);
            this.lblKpi5.Name = "lblKpi5";
            this.lblKpi5.Size = new Size(100, 44);
            this.lblKpi5.Text = "0";

            this.lblKpi5Txt.Dock = DockStyle.Fill;
            this.lblKpi5Txt.ForeColor = Color.FromArgb(150, 160, 182);
            this.lblKpi5Txt.Name = "lblKpi5Txt";
            this.lblKpi5Txt.Size = new Size(100, 40);
            this.lblKpi5Txt.Text = "Consumibles en alerta de stock";
            this.lblKpi5Txt.TextAlign = ContentAlignment.TopLeft;

            this.pnlKpi5.Controls.Add(this.lblKpi5Txt);
            this.pnlKpi5.Controls.Add(this.lblKpi5);
            this.pnlKpi5.Name = "pnlKpi5";
            this.pnlKpi5.BackColor = Color.FromArgb(21, 23, 31);
            this.pnlKpi5.Dock = DockStyle.Fill;
            this.pnlKpi5.Margin = new Padding(0, 0, 0, 0);
            this.pnlKpi5.Padding = new Padding(18, 10, 10, 8);
            this.pnlKpi5.Size = new Size(200, 96);

            this.tlpKpis.ColumnCount = 5;
            this.tlpKpis.RowCount = 1;
            this.tlpKpis.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            this.tlpKpis.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            this.tlpKpis.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            this.tlpKpis.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            this.tlpKpis.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            this.tlpKpis.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tlpKpis.Controls.Add(this.pnlKpi1, 0, 0);
            this.tlpKpis.Controls.Add(this.pnlKpi2, 1, 0);
            this.tlpKpis.Controls.Add(this.pnlKpi3, 2, 0);
            this.tlpKpis.Controls.Add(this.pnlKpi4, 3, 0);
            this.tlpKpis.Controls.Add(this.pnlKpi5, 4, 0);
            this.tlpKpis.Dock = DockStyle.Top;
            this.tlpKpis.Name = "tlpKpis";
            this.tlpKpis.Padding = new Padding(0, 0, 0, 8);
            this.tlpKpis.Size = new Size(1200, 108);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmGestionActivos
            // 
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.FromArgb(26, 28, 36);
            this.ClientSize = new Size(1240, 800);
            this.Controls.Add(this.tabPrincipal);
            this.Controls.Add(this.tlpKpis);
            this.Controls.Add(this.pnlEncabezado);
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.ForeColor = Color.FromArgb(226, 232, 244);
            this.Name = "frmGestionActivos";
            this.Padding = new Padding(20, 0, 20, 16);
            this.Text = "Gestión de activos";
            this.Load += new System.EventHandler(this.frmGestionActivos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Vistass.BotonTema btnGuardar;
        private Vistass.BotonTema btnActualizar;
        private Vistass.BotonTema btnEliminar;
        private Vistass.BotonTema btnLimpiar;
        private Panel pnlAccionesCat;
        private Label lblModo;
        private Label lblCodigo;
        private TextBox txtCodigo;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblCategoria;
        private ComboBox cmbCategoria;
        private Label lblEstado;
        private ComboBox cmbEstado;
        private Label lblUbicacion;
        private ComboBox cmbUbicacion;
        private Panel pnlFormulario;
        private Vistass.GridOscuro dgvActivos;
        private Panel pnlSeparador;
        private Vistass.GridOscuro dgvUbicacion;
        private Vistass.GridOscuro dgvHistorial;
        private Vistass.GridOscuro dgvDanos;
        private TabPage tabUbicacion;
        private TabPage tabHistorial;
        private TabPage tabDanos;
        private Vistass.TabControlOscuro tabFicha;
        private Label lblFichaTitulo;
        private Panel pnlFicha;
        private Label lblBuscar;
        private Vistass.BotonTema btnExportarPdf;
        private Vistass.BotonTema btnHistorial;
        private Vistass.BotonTema btnVerUnidades;
        private TextBox txtBuscar;
        private ComboBox cmbFiltroCategoria;
        private ComboBox cmbFiltroEstado;
        private Panel pnlBusqueda;
        private Panel pnlLista;
        private TabPage tabCatalogo;
        private Label lblPrestTitulo;
        private Label lblPrestActivo;
        private ComboBox cmbPrestActivo;
        private Label lblPrestCodigo;
        private TextBox txtPrestCodigo;
        private Label lblPrestCant;
        private NumericUpDown numPrestCant;
        private Label lblPrestTipo;
        private ComboBox cmbPrestTipo;
        private Label lblPrestResp;
        private TextBox txtPrestResp;
        private Label lblPrestAula;
        private ComboBox cmbPrestAula;
        private Label lblPrestLimite;
        private DateTimePicker dtpPrestLimite;
        private Label lblPrestObs;
        private TextBox txtPrestObs;
        private Vistass.BotonTema btnPrestar;
        private Panel pnlAccionesPrest;
        private Panel pnlPrestForm;
        private Vistass.GridOscuro dgvPrestamos;
        private Label lblDevSel;
        private Label lblDevEstado;
        private ComboBox cmbDevEstado;
        private Label lblDevObs;
        private TextBox txtDevObs;
        private Vistass.BotonTema btnDevolver;
        private Vistass.BotonTema btnHoja;
        private Panel pnlDevolucion;
        private Label lblPrestVer;
        private ComboBox cmbPrestVer;
        private Label lblPrestAlertas;
        private Panel pnlPrestFiltro;
        private Panel pnlPrestLista;
        private TabPage tabPrestamos;
        private Label lblConsNuevo;
        private Label lblConsNombre;
        private TextBox txtConsNombre;
        private Label lblConsUnidad;
        private TextBox txtConsUnidad;
        private Label lblConsMin;
        private NumericUpDown numConsMin;
        private Vistass.BotonTema btnConsCrear;
        private Label lblMovTitulo;
        private Label lblMovCons;
        private ComboBox cmbMovCons;
        private Label lblMovTipo;
        private ComboBox cmbMovTipo;
        private Label lblMovCant;
        private NumericUpDown numMovCant;
        private Label lblMovMotivo;
        private ComboBox cmbMovMotivo;
        private Label lblMovDestino;
        private ComboBox txtMovDestino;
        private Vistass.BotonTema btnMovimiento;
        private Panel pnlAccionesCons;
        private Panel pnlConsForm;
        private Vistass.GridOscuro dgvStock;
        private Label lblStockTitulo;
        private Panel pnlStock;
        private Vistass.GridOscuro dgvKardex;
        private Label lblKardexTitulo;
        private Vistass.BotonTema btnKardexTodos;
        private Panel pnlKardexBarra;
        private Panel pnlConsLista;
        private TabPage tabConsumibles;
        private Label lblMantTitulo;
        private Label lblMantActivo;
        private ComboBox cmbMantActivo;
        private Label lblMantCodigo;
        private TextBox txtMantCodigo;
        private Label lblMantFecha;
        private DateTimePicker dtpMantFecha;
        private Label lblMantTipo;
        private ComboBox cmbMantTipo;
        private Label lblMantCosto;
        private NumericUpDown numMantCosto;
        private Label lblMantEstado;
        private ComboBox cmbMantEstado;
        private Label lblMantDesc;
        private TextBox txtMantDesc;
        private Label lblMantVinculo;
        private Vistass.BotonTema btnMantRegistrar;
        private Vistass.BotonTema btnMantLimpiar;
        private Panel pnlAccionesMant;
        private Panel pnlMantForm;
        private Vistass.GridOscuro dgvMantenimientos;
        private Label lblMantHistTitulo;
        private Panel pnlMantLista;
        private TabPage tabMantenimiento;
        private Vistass.GridOscuro dgvReporte;
        private Label lblRepTipo;
        private ComboBox cmbRepTipo;
        private Label lblRepSalon;
        private ComboBox cmbRepSalon;
        private Label lblRepDesde;
        private DateTimePicker dtpRepDesde;
        private Label lblRepHasta;
        private DateTimePicker dtpRepHasta;
        private Vistass.BotonTema btnRepGenerar;
        private Vistass.BotonTema btnRepPdf;
        private Label lblRepInfo;
        private Panel pnlRepFiltros;
        private TabPage tabReportes;
        private Vistass.TabControlOscuro tabPrincipal;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Panel pnlEncabezado;
        private Label lblKpi1;
        private Label lblKpi1Txt;
        private Panel pnlKpi1;
        private Label lblKpi2;
        private Label lblKpi2Txt;
        private Panel pnlKpi2;
        private Label lblKpi3;
        private Label lblKpi3Txt;
        private Panel pnlKpi3;
        private Label lblKpi4;
        private Label lblKpi4Txt;
        private Panel pnlKpi4;
        private Label lblKpi5;
        private Label lblKpi5Txt;
        private Panel pnlKpi5;
        private TableLayoutPanel tlpKpis;
        private ErrorProvider errorProvider;
        private ToolTip toolTip1;
    }
}
