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
            this.pnlFormulario = new System.Windows.Forms.Panel();
            this.dgvActivos = new Vistass.GridOscuro();
            this.pnlSeparador = new System.Windows.Forms.Panel();
            this.dgvUbicacion = new Vistass.GridOscuro();
            this.dgvHistorial = new Vistass.GridOscuro();
            this.dgvDanos = new Vistass.GridOscuro();
            this.tabUbicacion = new System.Windows.Forms.TabPage();
            this.tabHistorial = new System.Windows.Forms.TabPage();
            this.tabDanos = new System.Windows.Forms.TabPage();
            this.tabFicha = new Vistass.TabControlOscuro();
            this.lblFichaTitulo = new System.Windows.Forms.Label();
            this.pnlFicha = new System.Windows.Forms.Panel();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.btnExportarPdf = new Vistass.BotonTema();
            this.btnHistorial = new Vistass.BotonTema();
            this.btnVerUnidades = new Vistass.BotonTema();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.cmbFiltroCategoria = new System.Windows.Forms.ComboBox();
            this.cmbFiltroEstado = new System.Windows.Forms.ComboBox();
            this.pnlBusqueda = new System.Windows.Forms.Panel();
            this.pnlLista = new System.Windows.Forms.Panel();
            this.tabCatalogo = new System.Windows.Forms.TabPage();
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
            this.btnPrestar = new Vistass.BotonTema();
            this.pnlPrestForm = new System.Windows.Forms.Panel();
            this.dgvPrestamos = new Vistass.GridOscuro();
            this.lblDevSel = new System.Windows.Forms.Label();
            this.lblDevEstado = new System.Windows.Forms.Label();
            this.cmbDevEstado = new System.Windows.Forms.ComboBox();
            this.lblDevObs = new System.Windows.Forms.Label();
            this.txtDevObs = new System.Windows.Forms.TextBox();
            this.btnDevolver = new Vistass.BotonTema();
            this.btnHoja = new Vistass.BotonTema();
            this.pnlDevolucion = new System.Windows.Forms.Panel();
            this.lblPrestVer = new System.Windows.Forms.Label();
            this.cmbPrestVer = new System.Windows.Forms.ComboBox();
            this.lblPrestAlertas = new System.Windows.Forms.Label();
            this.pnlPrestFiltro = new System.Windows.Forms.Panel();
            this.pnlPrestLista = new System.Windows.Forms.Panel();
            this.tabPrestamos = new System.Windows.Forms.TabPage();
            this.lblConsNuevo = new System.Windows.Forms.Label();
            this.lblConsNombre = new System.Windows.Forms.Label();
            this.txtConsNombre = new System.Windows.Forms.TextBox();
            this.lblConsUnidad = new System.Windows.Forms.Label();
            this.txtConsUnidad = new System.Windows.Forms.TextBox();
            this.lblConsMin = new System.Windows.Forms.Label();
            this.numConsMin = new System.Windows.Forms.NumericUpDown();
            this.btnConsCrear = new Vistass.BotonTema();
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
            this.txtMovDestino = new System.Windows.Forms.ComboBox();
            this.btnMovimiento = new Vistass.BotonTema();
            this.pnlConsForm = new System.Windows.Forms.Panel();
            this.dgvStock = new Vistass.GridOscuro();
            this.lblStockTitulo = new System.Windows.Forms.Label();
            this.pnlStock = new System.Windows.Forms.Panel();
            this.dgvKardex = new Vistass.GridOscuro();
            this.lblKardexTitulo = new System.Windows.Forms.Label();
            this.btnKardexTodos = new Vistass.BotonTema();
            this.pnlKardexBarra = new System.Windows.Forms.Panel();
            this.pnlConsLista = new System.Windows.Forms.Panel();
            this.tabConsumibles = new System.Windows.Forms.TabPage();
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
            this.btnMantRegistrar = new Vistass.BotonTema();
            this.btnMantLimpiar = new Vistass.BotonTema();
            this.pnlMantForm = new System.Windows.Forms.Panel();
            this.dgvMantenimientos = new Vistass.GridOscuro();
            this.lblMantHistTitulo = new System.Windows.Forms.Label();
            this.pnlMantLista = new System.Windows.Forms.Panel();
            this.tabMantenimiento = new System.Windows.Forms.TabPage();
            this.dgvReporte = new Vistass.GridOscuro();
            this.lblRepTipo = new System.Windows.Forms.Label();
            this.cmbRepTipo = new System.Windows.Forms.ComboBox();
            this.lblRepSalon = new System.Windows.Forms.Label();
            this.cmbRepSalon = new System.Windows.Forms.ComboBox();
            this.lblRepDesde = new System.Windows.Forms.Label();
            this.dtpRepDesde = new System.Windows.Forms.DateTimePicker();
            this.lblRepHasta = new System.Windows.Forms.Label();
            this.dtpRepHasta = new System.Windows.Forms.DateTimePicker();
            this.btnRepGenerar = new Vistass.BotonTema();
            this.btnRepPdf = new Vistass.BotonTema();
            this.lblRepInfo = new System.Windows.Forms.Label();
            this.pnlRepFiltros = new System.Windows.Forms.Panel();
            this.tabReportes = new System.Windows.Forms.TabPage();
            this.tabPrincipal = new Vistass.TabControlOscuro();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblKpi1 = new System.Windows.Forms.Label();
            this.lblKpi1Txt = new System.Windows.Forms.Label();
            this.pnlKpi1 = new System.Windows.Forms.Panel();
            this.lblKpi2 = new System.Windows.Forms.Label();
            this.lblKpi2Txt = new System.Windows.Forms.Label();
            this.pnlKpi2 = new System.Windows.Forms.Panel();
            this.lblKpi3 = new System.Windows.Forms.Label();
            this.lblKpi3Txt = new System.Windows.Forms.Label();
            this.pnlKpi3 = new System.Windows.Forms.Panel();
            this.lblKpi4 = new System.Windows.Forms.Label();
            this.lblKpi4Txt = new System.Windows.Forms.Label();
            this.pnlKpi4 = new System.Windows.Forms.Panel();
            this.lblKpi5 = new System.Windows.Forms.Label();
            this.lblKpi5Txt = new System.Windows.Forms.Label();
            this.pnlKpi5 = new System.Windows.Forms.Panel();
            this.tlpKpis = new System.Windows.Forms.TableLayoutPanel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Location = new System.Drawing.Point(20, 424);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(340, 40);
            this.btnGuardar.Text = "Agregar activo";
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnActualizar.Location = new System.Drawing.Point(20, 474);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(165, 40);
            this.btnActualizar.Text = "Guardar cambios";
            this.btnActualizar.TabIndex = 12;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminar.Location = new System.Drawing.Point(195, 474);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(165, 40);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Tipo = Vistass.TipoBoton.Peligro;
            this.btnEliminar.TabIndex = 13;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiar.Location = new System.Drawing.Point(20, 524);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(340, 40);
            this.btnLimpiar.Text = "Nuevo / limpiar formulario";
            this.btnLimpiar.Tipo = Vistass.TipoBoton.Secundario;
            this.btnLimpiar.TabIndex = 14;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lblModo
            // 
            this.lblModo.AutoSize = true;
            this.lblModo.Location = new System.Drawing.Point(20, 16);
            this.lblModo.Name = "lblModo";
            this.lblModo.Text = "Nuevo activo";
            this.lblModo.Size = new System.Drawing.Size(120, 19);
            this.lblModo.Font = new System.Drawing.Font("Segoe UI Semibold", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModo.ForeColor = System.Drawing.Color.FromArgb(250, 204, 21);
            this.lblModo.TabIndex = 0;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(20, 54);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Text = "Código (vacío = automático)";
            this.lblCodigo.Size = new System.Drawing.Size(120, 19);
            this.lblCodigo.TabIndex = 1;
            this.lblCodigo.Click += new System.EventHandler(this.lblCodigo_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.txtCodigo.Location = new System.Drawing.Point(20, 76);
            this.txtCodigo.MaxLength = 50;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(340, 27);
            this.txtCodigo.TabIndex = 2;
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(20, 116);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Text = "Nombre del activo";
            this.lblNombre.Size = new System.Drawing.Size(120, 19);
            this.lblNombre.TabIndex = 3;
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.txtNombre.Location = new System.Drawing.Point(20, 138);
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(340, 27);
            this.txtNombre.TabIndex = 4;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(20, 178);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Text = "Categoría";
            this.lblCategoria.Size = new System.Drawing.Size(120, 19);
            this.lblCategoria.TabIndex = 5;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.cmbCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCategoria.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.cmbCategoria.Location = new System.Drawing.Point(20, 200);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(340, 27);
            this.cmbCategoria.TabIndex = 6;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(20, 240);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Text = "Estado físico";
            this.lblEstado.Size = new System.Drawing.Size(120, 19);
            this.lblEstado.Visible = false;
            this.lblEstado.TabIndex = 7;
            // 
            // cmbEstado
            // 
            this.cmbEstado.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.cmbEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEstado.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.cmbEstado.Location = new System.Drawing.Point(20, 262);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(340, 27);
            this.cmbEstado.Visible = false;
            this.cmbEstado.TabIndex = 8;
            // 
            // lblUbicacion
            // 
            this.lblUbicacion.AutoSize = true;
            this.lblUbicacion.Location = new System.Drawing.Point(20, 240);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Text = "Ubicación predeterminada";
            this.lblUbicacion.Size = new System.Drawing.Size(120, 19);
            this.lblUbicacion.TabIndex = 9;
            // 
            // cmbUbicacion
            // 
            this.cmbUbicacion.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.cmbUbicacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbUbicacion.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.cmbUbicacion.Location = new System.Drawing.Point(20, 262);
            this.cmbUbicacion.Name = "cmbUbicacion";
            this.cmbUbicacion.Size = new System.Drawing.Size(340, 27);
            this.cmbUbicacion.TabIndex = 10;
            // 
            // pnlFormulario
            // 
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
            this.pnlFormulario.Name = "pnlFormulario";
            this.pnlFormulario.BackColor = System.Drawing.Color.FromArgb(21, 23, 31);
            this.pnlFormulario.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFormulario.Size = new System.Drawing.Size(380, 580);
            this.pnlFormulario.TabIndex = 1;
            // 
            // dgvActivos
            // 
            this.dgvActivos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvActivos.Name = "dgvActivos";
            this.dgvActivos.TabIndex = 0;
            this.dgvActivos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvActivos_CellClick);
            this.dgvActivos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvActivos_CellDoubleClick);
            this.dgvActivos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvActivos_CellFormatting);
            // 
            // pnlSeparador
            // 
            this.pnlSeparador.Name = "pnlSeparador";
            this.pnlSeparador.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSeparador.Size = new System.Drawing.Size(1124, 8);
            this.pnlSeparador.Visible = false;
            this.pnlSeparador.TabIndex = 1;
            // 
            // dgvUbicacion
            // 
            this.dgvUbicacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUbicacion.Name = "dgvUbicacion";
            this.dgvUbicacion.TabIndex = 0;
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.TabIndex = 0;
            // 
            // dgvDanos
            // 
            this.dgvDanos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDanos.Name = "dgvDanos";
            this.dgvDanos.TabIndex = 0;
            // 
            // tabUbicacion
            // 
            this.tabUbicacion.Controls.Add(this.dgvUbicacion);
            this.tabUbicacion.BackColor = System.Drawing.Color.FromArgb(26, 28, 36);
            this.tabUbicacion.Name = "tabUbicacion";
            this.tabUbicacion.Text = "Ubicación";
            this.tabUbicacion.UseVisualStyleBackColor = false;
            // 
            // tabHistorial
            // 
            this.tabHistorial.Controls.Add(this.dgvHistorial);
            this.tabHistorial.BackColor = System.Drawing.Color.FromArgb(26, 28, 36);
            this.tabHistorial.Name = "tabHistorial";
            this.tabHistorial.Text = "Historial de cambios";
            this.tabHistorial.UseVisualStyleBackColor = false;
            // 
            // tabDanos
            // 
            this.tabDanos.Controls.Add(this.dgvDanos);
            this.tabDanos.BackColor = System.Drawing.Color.FromArgb(26, 28, 36);
            this.tabDanos.Name = "tabDanos";
            this.tabDanos.Text = "Reportes de daño";
            this.tabDanos.UseVisualStyleBackColor = false;
            // 
            // tabFicha
            // 
            this.tabFicha.Controls.Add(this.tabUbicacion);
            this.tabFicha.Controls.Add(this.tabHistorial);
            this.tabFicha.Controls.Add(this.tabDanos);
            this.tabFicha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFicha.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabFicha.ItemSize = new System.Drawing.Size(170, 28);
            this.tabFicha.Name = "tabFicha";
            this.tabFicha.SelectedIndex = 0;
            this.tabFicha.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabFicha.TabIndex = 0;
            // 
            // lblFichaTitulo
            // 
            this.lblFichaTitulo.BackColor = System.Drawing.Color.FromArgb(21, 23, 31);
            this.lblFichaTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFichaTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFichaTitulo.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.lblFichaTitulo.Name = "lblFichaTitulo";
            this.lblFichaTitulo.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblFichaTitulo.Size = new System.Drawing.Size(100, 29);
            this.lblFichaTitulo.Text = "Seleccione un activo para ver su ficha";
            this.lblFichaTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFichaTitulo.TabIndex = 1;
            // 
            // pnlFicha
            // 
            this.pnlFicha.Controls.Add(this.tabFicha);
            this.pnlFicha.Controls.Add(this.lblFichaTitulo);
            this.pnlFicha.Name = "pnlFicha";
            this.pnlFicha.BackColor = System.Drawing.Color.FromArgb(21, 23, 31);
            this.pnlFicha.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFicha.Size = new System.Drawing.Size(1124, 184);
            this.pnlFicha.Visible = false;
            this.pnlFicha.TabIndex = 2;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(16, 17);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Text = "Buscar";
            this.lblBuscar.Size = new System.Drawing.Size(120, 19);
            this.lblBuscar.TabIndex = 0;
            // 
            // btnExportarPdf
            // 
            this.btnExportarPdf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarPdf.Location = new System.Drawing.Point(978, 12);
            this.btnExportarPdf.Name = "btnExportarPdf";
            this.btnExportarPdf.Size = new System.Drawing.Size(130, 32);
            this.btnExportarPdf.Text = "Exportar a PDF";
            this.btnExportarPdf.Tipo = Vistass.TipoBoton.Secundario;
            this.btnExportarPdf.TabIndex = 6;
            this.btnExportarPdf.Click += new System.EventHandler(this.btnExportarPdf_Click);
            // 
            // btnHistorial
            // 
            this.btnHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistorial.Location = new System.Drawing.Point(875, 12);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(95, 32);
            this.btnHistorial.Text = "Historial";
            this.btnHistorial.Tipo = Vistass.TipoBoton.Secundario;
            this.btnHistorial.TabIndex = 5;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
            // 
            // btnVerUnidades
            // 
            this.btnVerUnidades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerUnidades.Location = new System.Drawing.Point(772, 12);
            this.btnVerUnidades.Name = "btnVerUnidades";
            this.btnVerUnidades.Size = new System.Drawing.Size(95, 32);
            this.btnVerUnidades.Text = "Unidades";
            this.btnVerUnidades.Tipo = Vistass.TipoBoton.Secundario;
            this.btnVerUnidades.TabIndex = 4;
            this.btnVerUnidades.Click += new System.EventHandler(this.btnVerUnidades_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.txtBuscar.Location = new System.Drawing.Point(74, 14);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(200, 27);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // cmbFiltroCategoria
            // 
            this.cmbFiltroCategoria.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.cmbFiltroCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFiltroCategoria.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.cmbFiltroCategoria.Location = new System.Drawing.Point(286, 14);
            this.cmbFiltroCategoria.Name = "cmbFiltroCategoria";
            this.cmbFiltroCategoria.Size = new System.Drawing.Size(180, 27);
            this.cmbFiltroCategoria.TabIndex = 2;
            this.cmbFiltroCategoria.SelectedIndexChanged += new System.EventHandler(this.cmbFiltro_SelectedIndexChanged);
            // 
            // cmbFiltroEstado
            // 
            this.cmbFiltroEstado.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.cmbFiltroEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFiltroEstado.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.cmbFiltroEstado.Location = new System.Drawing.Point(478, 14);
            this.cmbFiltroEstado.Name = "cmbFiltroEstado";
            this.cmbFiltroEstado.Size = new System.Drawing.Size(170, 27);
            this.cmbFiltroEstado.TabIndex = 3;
            this.cmbFiltroEstado.SelectedIndexChanged += new System.EventHandler(this.cmbFiltro_SelectedIndexChanged);
            // 
            // pnlBusqueda
            // 
            this.pnlBusqueda.Controls.Add(this.lblBuscar);
            this.pnlBusqueda.Controls.Add(this.txtBuscar);
            this.pnlBusqueda.Controls.Add(this.cmbFiltroCategoria);
            this.pnlBusqueda.Controls.Add(this.cmbFiltroEstado);
            this.pnlBusqueda.Controls.Add(this.btnVerUnidades);
            this.pnlBusqueda.Controls.Add(this.btnHistorial);
            this.pnlBusqueda.Controls.Add(this.btnExportarPdf);
            this.pnlBusqueda.Name = "pnlBusqueda";
            this.pnlBusqueda.BackColor = System.Drawing.Color.FromArgb(21, 23, 31);
            this.pnlBusqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBusqueda.Size = new System.Drawing.Size(1124, 56);
            this.pnlBusqueda.TabIndex = 3;
            // 
            // pnlLista
            // 
            this.pnlLista.Controls.Add(this.dgvActivos);
            this.pnlLista.Controls.Add(this.pnlSeparador);
            this.pnlLista.Controls.Add(this.pnlFicha);
            this.pnlLista.Controls.Add(this.pnlBusqueda);
            this.pnlLista.Name = "pnlLista";
            this.pnlLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLista.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.pnlLista.Size = new System.Drawing.Size(1124, 580);
            this.pnlLista.TabIndex = 0;
            // 
            // tabCatalogo
            // 
            this.tabCatalogo.Controls.Add(this.pnlLista);
            this.tabCatalogo.Controls.Add(this.pnlFormulario);
            this.tabCatalogo.BackColor = System.Drawing.Color.FromArgb(26, 28, 36);
            this.tabCatalogo.Name = "tabCatalogo";
            this.tabCatalogo.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.tabCatalogo.Text = "1. Catálogo";
            this.tabCatalogo.UseVisualStyleBackColor = false;
            // 
            // lblPrestTitulo
            // 
            this.lblPrestTitulo.AutoSize = true;
            this.lblPrestTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblPrestTitulo.Name = "lblPrestTitulo";
            this.lblPrestTitulo.Text = "Registrar salida de equipo";
            this.lblPrestTitulo.Size = new System.Drawing.Size(120, 19);
            this.lblPrestTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrestTitulo.ForeColor = System.Drawing.Color.FromArgb(250, 204, 21);
            this.lblPrestTitulo.TabIndex = 0;
            // 
            // lblPrestActivo
            // 
            this.lblPrestActivo.AutoSize = true;
            this.lblPrestActivo.Location = new System.Drawing.Point(20, 54);
            this.lblPrestActivo.Name = "lblPrestActivo";
            this.lblPrestActivo.Text = "Equipo a prestar";
            this.lblPrestActivo.Size = new System.Drawing.Size(120, 19);
            this.lblPrestActivo.TabIndex = 1;
            // 
            // cmbPrestActivo
            // 
            this.cmbPrestActivo.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.cmbPrestActivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPrestActivo.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.cmbPrestActivo.Location = new System.Drawing.Point(20, 76);
            this.cmbPrestActivo.Name = "cmbPrestActivo";
            this.cmbPrestActivo.Size = new System.Drawing.Size(340, 27);
            this.cmbPrestActivo.TabIndex = 2;
            // 
            // lblPrestCodigo
            // 
            this.lblPrestCodigo.AutoSize = true;
            this.lblPrestCodigo.Location = new System.Drawing.Point(20, 116);
            this.lblPrestCodigo.Name = "lblPrestCodigo";
            this.lblPrestCodigo.Text = "Código del equipo (opcional)";
            this.lblPrestCodigo.Size = new System.Drawing.Size(120, 19);
            this.lblPrestCodigo.TabIndex = 3;
            // 
            // txtPrestCodigo
            // 
            this.txtPrestCodigo.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.txtPrestCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrestCodigo.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.txtPrestCodigo.Location = new System.Drawing.Point(20, 138);
            this.txtPrestCodigo.MaxLength = 50;
            this.txtPrestCodigo.Name = "txtPrestCodigo";
            this.txtPrestCodigo.Size = new System.Drawing.Size(340, 27);
            this.txtPrestCodigo.TabIndex = 4;
            // 
            // lblPrestCant
            // 
            this.lblPrestCant.AutoSize = true;
            this.lblPrestCant.Location = new System.Drawing.Point(250, 116);
            this.lblPrestCant.Name = "lblPrestCant";
            this.lblPrestCant.Text = "Cantidad";
            this.lblPrestCant.Size = new System.Drawing.Size(120, 19);
            this.lblPrestCant.Visible = false;
            this.lblPrestCant.TabIndex = 5;
            // 
            // numPrestCant
            // 
            this.numPrestCant.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.numPrestCant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numPrestCant.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.numPrestCant.Location = new System.Drawing.Point(250, 138);
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
            this.numPrestCant.Size = new System.Drawing.Size(110, 27);
            this.numPrestCant.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPrestCant.Visible = false;
            this.numPrestCant.TabIndex = 6;
            // 
            // lblPrestTipo
            // 
            this.lblPrestTipo.AutoSize = true;
            this.lblPrestTipo.Location = new System.Drawing.Point(20, 178);
            this.lblPrestTipo.Name = "lblPrestTipo";
            this.lblPrestTipo.Text = "Tipo de responsable";
            this.lblPrestTipo.Size = new System.Drawing.Size(120, 19);
            this.lblPrestTipo.TabIndex = 7;
            // 
            // cmbPrestTipo
            // 
            this.cmbPrestTipo.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.cmbPrestTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPrestTipo.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.cmbPrestTipo.Location = new System.Drawing.Point(20, 200);
            this.cmbPrestTipo.Name = "cmbPrestTipo";
            this.cmbPrestTipo.Size = new System.Drawing.Size(340, 27);
            this.cmbPrestTipo.TabIndex = 8;
            // 
            // lblPrestResp
            // 
            this.lblPrestResp.AutoSize = true;
            this.lblPrestResp.Location = new System.Drawing.Point(20, 240);
            this.lblPrestResp.Name = "lblPrestResp";
            this.lblPrestResp.Text = "Nombre del responsable";
            this.lblPrestResp.Size = new System.Drawing.Size(120, 19);
            this.lblPrestResp.TabIndex = 9;
            // 
            // txtPrestResp
            // 
            this.txtPrestResp.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.txtPrestResp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrestResp.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.txtPrestResp.Location = new System.Drawing.Point(20, 262);
            this.txtPrestResp.MaxLength = 100;
            this.txtPrestResp.Name = "txtPrestResp";
            this.txtPrestResp.Size = new System.Drawing.Size(340, 27);
            this.txtPrestResp.TabIndex = 10;
            // 
            // lblPrestAula
            // 
            this.lblPrestAula.AutoSize = true;
            this.lblPrestAula.Location = new System.Drawing.Point(20, 302);
            this.lblPrestAula.Name = "lblPrestAula";
            this.lblPrestAula.Text = "Aula de destino";
            this.lblPrestAula.Size = new System.Drawing.Size(120, 19);
            this.lblPrestAula.TabIndex = 11;
            // 
            // cmbPrestAula
            // 
            this.cmbPrestAula.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.cmbPrestAula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPrestAula.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.cmbPrestAula.Location = new System.Drawing.Point(20, 324);
            this.cmbPrestAula.Name = "cmbPrestAula";
            this.cmbPrestAula.Size = new System.Drawing.Size(340, 27);
            this.cmbPrestAula.TabIndex = 12;
            // 
            // lblPrestLimite
            // 
            this.lblPrestLimite.AutoSize = true;
            this.lblPrestLimite.Location = new System.Drawing.Point(20, 364);
            this.lblPrestLimite.Name = "lblPrestLimite";
            this.lblPrestLimite.Text = "Fecha y hora límite de devolución";
            this.lblPrestLimite.Size = new System.Drawing.Size(120, 19);
            this.lblPrestLimite.TabIndex = 13;
            // 
            // dtpPrestLimite
            // 
            this.dtpPrestLimite.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpPrestLimite.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPrestLimite.Location = new System.Drawing.Point(20, 386);
            this.dtpPrestLimite.Name = "dtpPrestLimite";
            this.dtpPrestLimite.Size = new System.Drawing.Size(340, 27);
            this.dtpPrestLimite.TabIndex = 14;
            // 
            // lblPrestObs
            // 
            this.lblPrestObs.AutoSize = true;
            this.lblPrestObs.Location = new System.Drawing.Point(20, 426);
            this.lblPrestObs.Name = "lblPrestObs";
            this.lblPrestObs.Text = "Observaciones";
            this.lblPrestObs.Size = new System.Drawing.Size(120, 19);
            this.lblPrestObs.TabIndex = 15;
            // 
            // txtPrestObs
            // 
            this.txtPrestObs.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.txtPrestObs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrestObs.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.txtPrestObs.Location = new System.Drawing.Point(20, 448);
            this.txtPrestObs.MaxLength = 300;
            this.txtPrestObs.Name = "txtPrestObs";
            this.txtPrestObs.Size = new System.Drawing.Size(340, 27);
            this.txtPrestObs.TabIndex = 16;
            // 
            // btnPrestar
            // 
            this.btnPrestar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrestar.Location = new System.Drawing.Point(20, 524);
            this.btnPrestar.Name = "btnPrestar";
            this.btnPrestar.Size = new System.Drawing.Size(340, 40);
            this.btnPrestar.Text = "Registrar salida";
            this.btnPrestar.TabIndex = 17;
            this.btnPrestar.Click += new System.EventHandler(this.btnPrestar_Click);
            // 
            // pnlPrestForm
            // 
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
            this.pnlPrestForm.Name = "pnlPrestForm";
            this.pnlPrestForm.BackColor = System.Drawing.Color.FromArgb(21, 23, 31);
            this.pnlPrestForm.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlPrestForm.Size = new System.Drawing.Size(380, 580);
            this.pnlPrestForm.TabIndex = 1;
            // 
            // dgvPrestamos
            // 
            this.dgvPrestamos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPrestamos.Name = "dgvPrestamos";
            this.dgvPrestamos.TabIndex = 0;
            this.dgvPrestamos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPrestamos_CellFormatting);
            this.dgvPrestamos.SelectionChanged += new System.EventHandler(this.dgvPrestamos_SelectionChanged);
            // 
            // lblDevSel
            // 
            this.lblDevSel.BackColor = System.Drawing.Color.FromArgb(21, 23, 31);
            this.lblDevSel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDevSel.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.lblDevSel.Location = new System.Drawing.Point(16, 12);
            this.lblDevSel.Name = "lblDevSel";
            this.lblDevSel.Size = new System.Drawing.Size(700, 22);
            this.lblDevSel.Text = "Seleccione un préstamo para devolverlo o imprimir su hoja";
            // 
            // lblDevEstado
            // 
            this.lblDevEstado.AutoSize = true;
            this.lblDevEstado.Location = new System.Drawing.Point(16, 48);
            this.lblDevEstado.Name = "lblDevEstado";
            this.lblDevEstado.Text = "Estado físico al devolver";
            this.lblDevEstado.Size = new System.Drawing.Size(120, 19);
            this.lblDevEstado.TabIndex = 1;
            // 
            // cmbDevEstado
            // 
            this.cmbDevEstado.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.cmbDevEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDevEstado.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.cmbDevEstado.Location = new System.Drawing.Point(16, 70);
            this.cmbDevEstado.Name = "cmbDevEstado";
            this.cmbDevEstado.Size = new System.Drawing.Size(220, 27);
            this.cmbDevEstado.TabIndex = 2;
            // 
            // lblDevObs
            // 
            this.lblDevObs.AutoSize = true;
            this.lblDevObs.Location = new System.Drawing.Point(252, 48);
            this.lblDevObs.Name = "lblDevObs";
            this.lblDevObs.Text = "Observación de la devolución";
            this.lblDevObs.Size = new System.Drawing.Size(120, 19);
            this.lblDevObs.TabIndex = 3;
            // 
            // txtDevObs
            // 
            this.txtDevObs.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.txtDevObs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDevObs.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.txtDevObs.Location = new System.Drawing.Point(252, 70);
            this.txtDevObs.MaxLength = 300;
            this.txtDevObs.Name = "txtDevObs";
            this.txtDevObs.Size = new System.Drawing.Size(330, 27);
            this.txtDevObs.TabIndex = 4;
            // 
            // btnDevolver
            // 
            this.btnDevolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDevolver.Location = new System.Drawing.Point(600, 66);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(190, 34);
            this.btnDevolver.Text = "Registrar devolución";
            this.btnDevolver.TabIndex = 5;
            this.btnDevolver.Click += new System.EventHandler(this.btnDevolver_Click);
            // 
            // btnHoja
            // 
            this.btnHoja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHoja.Location = new System.Drawing.Point(798, 66);
            this.btnHoja.Name = "btnHoja";
            this.btnHoja.Size = new System.Drawing.Size(200, 34);
            this.btnHoja.Text = "Hoja de resguardo (PDF)";
            this.btnHoja.Tipo = Vistass.TipoBoton.Secundario;
            this.btnHoja.TabIndex = 6;
            this.btnHoja.Click += new System.EventHandler(this.btnHoja_Click);
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
            this.pnlDevolucion.Name = "pnlDevolucion";
            this.pnlDevolucion.BackColor = System.Drawing.Color.FromArgb(21, 23, 31);
            this.pnlDevolucion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDevolucion.Size = new System.Drawing.Size(1124, 124);
            this.pnlDevolucion.TabIndex = 1;
            // 
            // lblPrestVer
            // 
            this.lblPrestVer.AutoSize = true;
            this.lblPrestVer.Location = new System.Drawing.Point(16, 16);
            this.lblPrestVer.Name = "lblPrestVer";
            this.lblPrestVer.Text = "Mostrar";
            this.lblPrestVer.Size = new System.Drawing.Size(120, 19);
            this.lblPrestVer.TabIndex = 0;
            // 
            // cmbPrestVer
            // 
            this.cmbPrestVer.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.cmbPrestVer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPrestVer.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.cmbPrestVer.Location = new System.Drawing.Point(82, 12);
            this.cmbPrestVer.Name = "cmbPrestVer";
            this.cmbPrestVer.Size = new System.Drawing.Size(170, 27);
            this.cmbPrestVer.TabIndex = 1;
            this.cmbPrestVer.SelectedIndexChanged += new System.EventHandler(this.cmbPrestVer_SelectedIndexChanged);
            // 
            // lblPrestAlertas
            // 
            this.lblPrestAlertas.AutoSize = true;
            this.lblPrestAlertas.Location = new System.Drawing.Point(264, 16);
            this.lblPrestAlertas.Name = "lblPrestAlertas";
            this.lblPrestAlertas.Text = "";
            this.lblPrestAlertas.Size = new System.Drawing.Size(120, 19);
            this.lblPrestAlertas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrestAlertas.ForeColor = System.Drawing.Color.FromArgb(150, 160, 182);
            this.lblPrestAlertas.TabIndex = 2;
            // 
            // pnlPrestFiltro
            // 
            this.pnlPrestFiltro.Controls.Add(this.lblPrestVer);
            this.pnlPrestFiltro.Controls.Add(this.cmbPrestVer);
            this.pnlPrestFiltro.Controls.Add(this.lblPrestAlertas);
            this.pnlPrestFiltro.Name = "pnlPrestFiltro";
            this.pnlPrestFiltro.BackColor = System.Drawing.Color.FromArgb(21, 23, 31);
            this.pnlPrestFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPrestFiltro.Size = new System.Drawing.Size(1124, 52);
            this.pnlPrestFiltro.TabIndex = 2;
            // 
            // pnlPrestLista
            // 
            this.pnlPrestLista.Controls.Add(this.dgvPrestamos);
            this.pnlPrestLista.Controls.Add(this.pnlDevolucion);
            this.pnlPrestLista.Controls.Add(this.pnlPrestFiltro);
            this.pnlPrestLista.Name = "pnlPrestLista";
            this.pnlPrestLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrestLista.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.pnlPrestLista.Size = new System.Drawing.Size(1124, 580);
            this.pnlPrestLista.TabIndex = 0;
            // 
            // tabPrestamos
            // 
            this.tabPrestamos.Controls.Add(this.pnlPrestLista);
            this.tabPrestamos.Controls.Add(this.pnlPrestForm);
            this.tabPrestamos.BackColor = System.Drawing.Color.FromArgb(26, 28, 36);
            this.tabPrestamos.Name = "tabPrestamos";
            this.tabPrestamos.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.tabPrestamos.Text = "2. Préstamos";
            this.tabPrestamos.UseVisualStyleBackColor = false;
            // 
            // lblConsNuevo
            // 
            this.lblConsNuevo.AutoSize = true;
            this.lblConsNuevo.Location = new System.Drawing.Point(20, 16);
            this.lblConsNuevo.Name = "lblConsNuevo";
            this.lblConsNuevo.Text = "Nuevo consumible";
            this.lblConsNuevo.Size = new System.Drawing.Size(120, 19);
            this.lblConsNuevo.Font = new System.Drawing.Font("Segoe UI Semibold", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsNuevo.ForeColor = System.Drawing.Color.FromArgb(250, 204, 21);
            this.lblConsNuevo.TabIndex = 0;
            // 
            // lblConsNombre
            // 
            this.lblConsNombre.AutoSize = true;
            this.lblConsNombre.Location = new System.Drawing.Point(20, 48);
            this.lblConsNombre.Name = "lblConsNombre";
            this.lblConsNombre.Text = "Nombre (ej. Resma de papel carta)";
            this.lblConsNombre.Size = new System.Drawing.Size(120, 19);
            this.lblConsNombre.TabIndex = 1;
            // 
            // txtConsNombre
            // 
            this.txtConsNombre.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.txtConsNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConsNombre.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.txtConsNombre.Location = new System.Drawing.Point(20, 70);
            this.txtConsNombre.MaxLength = 100;
            this.txtConsNombre.Name = "txtConsNombre";
            this.txtConsNombre.Size = new System.Drawing.Size(340, 27);
            this.txtConsNombre.TabIndex = 2;
            // 
            // lblConsUnidad
            // 
            this.lblConsUnidad.AutoSize = true;
            this.lblConsUnidad.Location = new System.Drawing.Point(20, 110);
            this.lblConsUnidad.Name = "lblConsUnidad";
            this.lblConsUnidad.Text = "Unidad de medida";
            this.lblConsUnidad.Size = new System.Drawing.Size(120, 19);
            this.lblConsUnidad.TabIndex = 3;
            // 
            // txtConsUnidad
            // 
            this.txtConsUnidad.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.txtConsUnidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConsUnidad.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.txtConsUnidad.Location = new System.Drawing.Point(20, 132);
            this.txtConsUnidad.MaxLength = 30;
            this.txtConsUnidad.Name = "txtConsUnidad";
            this.txtConsUnidad.Size = new System.Drawing.Size(160, 27);
            this.txtConsUnidad.TabIndex = 4;
            // 
            // lblConsMin
            // 
            this.lblConsMin.AutoSize = true;
            this.lblConsMin.Location = new System.Drawing.Point(196, 110);
            this.lblConsMin.Name = "lblConsMin";
            this.lblConsMin.Text = "Stock mínimo";
            this.lblConsMin.Size = new System.Drawing.Size(120, 19);
            this.lblConsMin.TabIndex = 5;
            // 
            // numConsMin
            // 
            this.numConsMin.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.numConsMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numConsMin.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.numConsMin.Location = new System.Drawing.Point(196, 132);
            this.numConsMin.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numConsMin.Name = "numConsMin";
            this.numConsMin.Size = new System.Drawing.Size(164, 27);
            this.numConsMin.TabIndex = 6;
            // 
            // btnConsCrear
            // 
            this.btnConsCrear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConsCrear.Location = new System.Drawing.Point(20, 176);
            this.btnConsCrear.Name = "btnConsCrear";
            this.btnConsCrear.Size = new System.Drawing.Size(340, 40);
            this.btnConsCrear.Text = "Crear consumible";
            this.btnConsCrear.TabIndex = 7;
            this.btnConsCrear.Click += new System.EventHandler(this.btnConsCrear_Click);
            // 
            // lblMovTitulo
            // 
            this.lblMovTitulo.AutoSize = true;
            this.lblMovTitulo.Location = new System.Drawing.Point(20, 236);
            this.lblMovTitulo.Name = "lblMovTitulo";
            this.lblMovTitulo.Text = "Registrar movimiento";
            this.lblMovTitulo.Size = new System.Drawing.Size(120, 19);
            this.lblMovTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovTitulo.ForeColor = System.Drawing.Color.FromArgb(250, 204, 21);
            this.lblMovTitulo.TabIndex = 8;
            // 
            // lblMovCons
            // 
            this.lblMovCons.AutoSize = true;
            this.lblMovCons.Location = new System.Drawing.Point(20, 270);
            this.lblMovCons.Name = "lblMovCons";
            this.lblMovCons.Text = "Consumible";
            this.lblMovCons.Size = new System.Drawing.Size(120, 19);
            this.lblMovCons.TabIndex = 9;
            // 
            // cmbMovCons
            // 
            this.cmbMovCons.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.cmbMovCons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMovCons.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.cmbMovCons.Location = new System.Drawing.Point(20, 292);
            this.cmbMovCons.Name = "cmbMovCons";
            this.cmbMovCons.Size = new System.Drawing.Size(340, 27);
            this.cmbMovCons.TabIndex = 10;
            // 
            // lblMovTipo
            // 
            this.lblMovTipo.AutoSize = true;
            this.lblMovTipo.Location = new System.Drawing.Point(20, 332);
            this.lblMovTipo.Name = "lblMovTipo";
            this.lblMovTipo.Text = "Tipo";
            this.lblMovTipo.Size = new System.Drawing.Size(120, 19);
            this.lblMovTipo.TabIndex = 11;
            // 
            // cmbMovTipo
            // 
            this.cmbMovTipo.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.cmbMovTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMovTipo.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.cmbMovTipo.Location = new System.Drawing.Point(20, 354);
            this.cmbMovTipo.Name = "cmbMovTipo";
            this.cmbMovTipo.Size = new System.Drawing.Size(160, 27);
            this.cmbMovTipo.TabIndex = 12;
            this.cmbMovTipo.SelectedIndexChanged += new System.EventHandler(this.cmbMovTipo_SelectedIndexChanged);
            // 
            // lblMovCant
            // 
            this.lblMovCant.AutoSize = true;
            this.lblMovCant.Location = new System.Drawing.Point(196, 332);
            this.lblMovCant.Name = "lblMovCant";
            this.lblMovCant.Text = "Cantidad";
            this.lblMovCant.Size = new System.Drawing.Size(120, 19);
            this.lblMovCant.TabIndex = 13;
            // 
            // numMovCant
            // 
            this.numMovCant.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.numMovCant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numMovCant.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.numMovCant.Location = new System.Drawing.Point(196, 354);
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
            this.numMovCant.Size = new System.Drawing.Size(164, 27);
            this.numMovCant.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMovCant.TabIndex = 14;
            // 
            // lblMovMotivo
            // 
            this.lblMovMotivo.AutoSize = true;
            this.lblMovMotivo.Location = new System.Drawing.Point(20, 394);
            this.lblMovMotivo.Name = "lblMovMotivo";
            this.lblMovMotivo.Text = "Motivo";
            this.lblMovMotivo.Size = new System.Drawing.Size(120, 19);
            this.lblMovMotivo.TabIndex = 15;
            // 
            // cmbMovMotivo
            // 
            this.cmbMovMotivo.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.cmbMovMotivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMovMotivo.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.cmbMovMotivo.Location = new System.Drawing.Point(20, 416);
            this.cmbMovMotivo.Name = "cmbMovMotivo";
            this.cmbMovMotivo.Size = new System.Drawing.Size(340, 27);
            this.cmbMovMotivo.TabIndex = 16;
            // 
            // lblMovDestino
            // 
            this.lblMovDestino.AutoSize = true;
            this.lblMovDestino.Location = new System.Drawing.Point(20, 456);
            this.lblMovDestino.Name = "lblMovDestino";
            this.lblMovDestino.Text = "Destino o referencia (aula, factura…)";
            this.lblMovDestino.Size = new System.Drawing.Size(120, 19);
            this.lblMovDestino.TabIndex = 17;
            // 
            // txtMovDestino
            // 
            this.txtMovDestino.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.txtMovDestino.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtMovDestino.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.txtMovDestino.Location = new System.Drawing.Point(20, 478);
            this.txtMovDestino.MaxLength = 100;
            this.txtMovDestino.Name = "txtMovDestino";
            this.txtMovDestino.Size = new System.Drawing.Size(340, 27);
            this.txtMovDestino.TabIndex = 18;
            // 
            // btnMovimiento
            // 
            this.btnMovimiento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMovimiento.Location = new System.Drawing.Point(20, 524);
            this.btnMovimiento.Name = "btnMovimiento";
            this.btnMovimiento.Size = new System.Drawing.Size(340, 40);
            this.btnMovimiento.Text = "Registrar movimiento";
            this.btnMovimiento.TabIndex = 19;
            this.btnMovimiento.Click += new System.EventHandler(this.btnMovimiento_Click);
            // 
            // pnlConsForm
            // 
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
            this.pnlConsForm.Name = "pnlConsForm";
            this.pnlConsForm.BackColor = System.Drawing.Color.FromArgb(21, 23, 31);
            this.pnlConsForm.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlConsForm.Size = new System.Drawing.Size(380, 580);
            this.pnlConsForm.TabIndex = 1;
            // 
            // dgvStock
            // 
            this.dgvStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.TabIndex = 0;
            this.dgvStock.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvStock_CellFormatting);
            this.dgvStock.SelectionChanged += new System.EventHandler(this.dgvStock_SelectionChanged);
            // 
            // lblStockTitulo
            // 
            this.lblStockTitulo.BackColor = System.Drawing.Color.FromArgb(21, 23, 31);
            this.lblStockTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStockTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockTitulo.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.lblStockTitulo.Name = "lblStockTitulo";
            this.lblStockTitulo.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblStockTitulo.Size = new System.Drawing.Size(100, 36);
            this.lblStockTitulo.Text = "Existencias (clic en una fila para ver su kardex)";
            this.lblStockTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStockTitulo.TabIndex = 1;
            // 
            // pnlStock
            // 
            this.pnlStock.Controls.Add(this.dgvStock);
            this.pnlStock.Controls.Add(this.lblStockTitulo);
            this.pnlStock.Name = "pnlStock";
            this.pnlStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStock.Size = new System.Drawing.Size(1108, 220);
            this.pnlStock.TabIndex = 2;
            // 
            // dgvKardex
            // 
            this.dgvKardex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKardex.Name = "dgvKardex";
            this.dgvKardex.TabIndex = 0;
            // 
            // lblKardexTitulo
            // 
            this.lblKardexTitulo.AutoSize = true;
            this.lblKardexTitulo.Location = new System.Drawing.Point(12, 12);
            this.lblKardexTitulo.Name = "lblKardexTitulo";
            this.lblKardexTitulo.Text = "Kardex";
            this.lblKardexTitulo.Size = new System.Drawing.Size(120, 19);
            this.lblKardexTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKardexTitulo.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.lblKardexTitulo.TabIndex = 0;
            // 
            // btnKardexTodos
            // 
            this.btnKardexTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKardexTodos.Location = new System.Drawing.Point(888, 6);
            this.btnKardexTodos.Name = "btnKardexTodos";
            this.btnKardexTodos.Size = new System.Drawing.Size(220, 32);
            this.btnKardexTodos.Text = "Ver todos los movimientos";
            this.btnKardexTodos.Tipo = Vistass.TipoBoton.Secundario;
            this.btnKardexTodos.TabIndex = 1;
            this.btnKardexTodos.Click += new System.EventHandler(this.btnKardexTodos_Click);
            // 
            // pnlKardexBarra
            // 
            this.pnlKardexBarra.Controls.Add(this.lblKardexTitulo);
            this.pnlKardexBarra.Controls.Add(this.btnKardexTodos);
            this.pnlKardexBarra.Name = "pnlKardexBarra";
            this.pnlKardexBarra.BackColor = System.Drawing.Color.FromArgb(21, 23, 31);
            this.pnlKardexBarra.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKardexBarra.Size = new System.Drawing.Size(1108, 44);
            this.pnlKardexBarra.TabIndex = 1;
            // 
            // pnlConsLista
            // 
            this.pnlConsLista.Controls.Add(this.dgvKardex);
            this.pnlConsLista.Controls.Add(this.pnlKardexBarra);
            this.pnlConsLista.Controls.Add(this.pnlStock);
            this.pnlConsLista.Name = "pnlConsLista";
            this.pnlConsLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConsLista.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.pnlConsLista.Size = new System.Drawing.Size(1124, 580);
            this.pnlConsLista.TabIndex = 0;
            // 
            // tabConsumibles
            // 
            this.tabConsumibles.Controls.Add(this.pnlConsLista);
            this.tabConsumibles.Controls.Add(this.pnlConsForm);
            this.tabConsumibles.BackColor = System.Drawing.Color.FromArgb(26, 28, 36);
            this.tabConsumibles.Name = "tabConsumibles";
            this.tabConsumibles.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.tabConsumibles.Text = "3. Consumibles";
            this.tabConsumibles.UseVisualStyleBackColor = false;
            // 
            // lblMantTitulo
            // 
            this.lblMantTitulo.AutoSize = true;
            this.lblMantTitulo.Location = new System.Drawing.Point(20, 16);
            this.lblMantTitulo.Name = "lblMantTitulo";
            this.lblMantTitulo.Text = "Registrar mantenimiento";
            this.lblMantTitulo.Size = new System.Drawing.Size(120, 19);
            this.lblMantTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMantTitulo.ForeColor = System.Drawing.Color.FromArgb(250, 204, 21);
            this.lblMantTitulo.TabIndex = 0;
            // 
            // lblMantActivo
            // 
            this.lblMantActivo.AutoSize = true;
            this.lblMantActivo.Location = new System.Drawing.Point(20, 48);
            this.lblMantActivo.Name = "lblMantActivo";
            this.lblMantActivo.Text = "Equipo";
            this.lblMantActivo.Size = new System.Drawing.Size(120, 19);
            this.lblMantActivo.TabIndex = 1;
            // 
            // cmbMantActivo
            // 
            this.cmbMantActivo.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.cmbMantActivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMantActivo.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.cmbMantActivo.Location = new System.Drawing.Point(20, 70);
            this.cmbMantActivo.Name = "cmbMantActivo";
            this.cmbMantActivo.Size = new System.Drawing.Size(340, 27);
            this.cmbMantActivo.TabIndex = 2;
            // 
            // lblMantCodigo
            // 
            this.lblMantCodigo.AutoSize = true;
            this.lblMantCodigo.Location = new System.Drawing.Point(20, 110);
            this.lblMantCodigo.Name = "lblMantCodigo";
            this.lblMantCodigo.Text = "Código (opcional)";
            this.lblMantCodigo.Size = new System.Drawing.Size(120, 19);
            this.lblMantCodigo.TabIndex = 3;
            // 
            // txtMantCodigo
            // 
            this.txtMantCodigo.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.txtMantCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMantCodigo.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.txtMantCodigo.Location = new System.Drawing.Point(20, 132);
            this.txtMantCodigo.MaxLength = 50;
            this.txtMantCodigo.Name = "txtMantCodigo";
            this.txtMantCodigo.Size = new System.Drawing.Size(160, 27);
            this.txtMantCodigo.TabIndex = 4;
            // 
            // lblMantFecha
            // 
            this.lblMantFecha.AutoSize = true;
            this.lblMantFecha.Location = new System.Drawing.Point(196, 110);
            this.lblMantFecha.Name = "lblMantFecha";
            this.lblMantFecha.Text = "Fecha del servicio";
            this.lblMantFecha.Size = new System.Drawing.Size(120, 19);
            this.lblMantFecha.TabIndex = 5;
            // 
            // dtpMantFecha
            // 
            this.dtpMantFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpMantFecha.Location = new System.Drawing.Point(196, 132);
            this.dtpMantFecha.Name = "dtpMantFecha";
            this.dtpMantFecha.Size = new System.Drawing.Size(164, 27);
            this.dtpMantFecha.TabIndex = 6;
            // 
            // lblMantTipo
            // 
            this.lblMantTipo.AutoSize = true;
            this.lblMantTipo.Location = new System.Drawing.Point(20, 172);
            this.lblMantTipo.Name = "lblMantTipo";
            this.lblMantTipo.Text = "Tipo";
            this.lblMantTipo.Size = new System.Drawing.Size(120, 19);
            this.lblMantTipo.TabIndex = 7;
            // 
            // cmbMantTipo
            // 
            this.cmbMantTipo.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.cmbMantTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMantTipo.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.cmbMantTipo.Location = new System.Drawing.Point(20, 194);
            this.cmbMantTipo.Name = "cmbMantTipo";
            this.cmbMantTipo.Size = new System.Drawing.Size(160, 27);
            this.cmbMantTipo.TabIndex = 8;
            // 
            // lblMantCosto
            // 
            this.lblMantCosto.AutoSize = true;
            this.lblMantCosto.Location = new System.Drawing.Point(196, 172);
            this.lblMantCosto.Name = "lblMantCosto";
            this.lblMantCosto.Text = "Costo";
            this.lblMantCosto.Size = new System.Drawing.Size(120, 19);
            this.lblMantCosto.TabIndex = 9;
            // 
            // numMantCosto
            // 
            this.numMantCosto.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.numMantCosto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numMantCosto.DecimalPlaces = 2;
            this.numMantCosto.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.numMantCosto.Location = new System.Drawing.Point(196, 194);
            this.numMantCosto.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numMantCosto.Name = "numMantCosto";
            this.numMantCosto.Size = new System.Drawing.Size(164, 27);
            this.numMantCosto.TabIndex = 10;
            // 
            // lblMantEstado
            // 
            this.lblMantEstado.AutoSize = true;
            this.lblMantEstado.Location = new System.Drawing.Point(20, 234);
            this.lblMantEstado.Name = "lblMantEstado";
            this.lblMantEstado.Text = "Estado resultante del equipo";
            this.lblMantEstado.Size = new System.Drawing.Size(120, 19);
            this.lblMantEstado.TabIndex = 11;
            // 
            // cmbMantEstado
            // 
            this.cmbMantEstado.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.cmbMantEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMantEstado.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.cmbMantEstado.Location = new System.Drawing.Point(20, 256);
            this.cmbMantEstado.Name = "cmbMantEstado";
            this.cmbMantEstado.Size = new System.Drawing.Size(340, 27);
            this.cmbMantEstado.TabIndex = 12;
            // 
            // lblMantDesc
            // 
            this.lblMantDesc.AutoSize = true;
            this.lblMantDesc.Location = new System.Drawing.Point(20, 296);
            this.lblMantDesc.Name = "lblMantDesc";
            this.lblMantDesc.Text = "Descripción del servicio";
            this.lblMantDesc.Size = new System.Drawing.Size(120, 19);
            this.lblMantDesc.TabIndex = 13;
            // 
            // txtMantDesc
            // 
            this.txtMantDesc.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.txtMantDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMantDesc.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.txtMantDesc.Location = new System.Drawing.Point(20, 318);
            this.txtMantDesc.MaxLength = 500;
            this.txtMantDesc.Multiline = true;
            this.txtMantDesc.Name = "txtMantDesc";
            this.txtMantDesc.Size = new System.Drawing.Size(340, 64);
            this.txtMantDesc.TabIndex = 14;
            // 
            // lblMantVinculo
            // 
            this.lblMantVinculo.Location = new System.Drawing.Point(20, 392);
            this.lblMantVinculo.Name = "lblMantVinculo";
            this.lblMantVinculo.Size = new System.Drawing.Size(340, 34);
            this.lblMantVinculo.Text = "Sin reporte de daño vinculado (seleccione uno de la tabla para cerrarlo al guardar)";
            this.lblMantVinculo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMantVinculo.ForeColor = System.Drawing.Color.FromArgb(150, 160, 182);
            this.lblMantVinculo.TabIndex = 15;
            // 
            // btnMantRegistrar
            // 
            this.btnMantRegistrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMantRegistrar.Location = new System.Drawing.Point(20, 474);
            this.btnMantRegistrar.Name = "btnMantRegistrar";
            this.btnMantRegistrar.Size = new System.Drawing.Size(340, 40);
            this.btnMantRegistrar.Text = "Registrar mantenimiento";
            this.btnMantRegistrar.TabIndex = 16;
            this.btnMantRegistrar.Click += new System.EventHandler(this.btnMantRegistrar_Click);
            // 
            // btnMantLimpiar
            // 
            this.btnMantLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMantLimpiar.Location = new System.Drawing.Point(20, 524);
            this.btnMantLimpiar.Name = "btnMantLimpiar";
            this.btnMantLimpiar.Size = new System.Drawing.Size(340, 40);
            this.btnMantLimpiar.Text = "Limpiar";
            this.btnMantLimpiar.Tipo = Vistass.TipoBoton.Secundario;
            this.btnMantLimpiar.TabIndex = 17;
            this.btnMantLimpiar.Click += new System.EventHandler(this.btnMantLimpiar_Click);
            // 
            // pnlMantForm
            // 
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
            this.pnlMantForm.Name = "pnlMantForm";
            this.pnlMantForm.BackColor = System.Drawing.Color.FromArgb(21, 23, 31);
            this.pnlMantForm.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMantForm.Size = new System.Drawing.Size(380, 580);
            this.pnlMantForm.TabIndex = 1;
            // 
            // dgvMantenimientos
            // 
            this.dgvMantenimientos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMantenimientos.Name = "dgvMantenimientos";
            this.dgvMantenimientos.TabIndex = 0;
            // 
            // lblMantHistTitulo
            // 
            this.lblMantHistTitulo.BackColor = System.Drawing.Color.FromArgb(21, 23, 31);
            this.lblMantHistTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMantHistTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMantHistTitulo.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.lblMantHistTitulo.Name = "lblMantHistTitulo";
            this.lblMantHistTitulo.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblMantHistTitulo.Size = new System.Drawing.Size(100, 36);
            this.lblMantHistTitulo.Text = "Bitácora de mantenimiento";
            this.lblMantHistTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMantHistTitulo.TabIndex = 1;
            // 
            // pnlMantLista
            // 
            this.pnlMantLista.Controls.Add(this.dgvMantenimientos);
            this.pnlMantLista.Controls.Add(this.lblMantHistTitulo);
            this.pnlMantLista.Name = "pnlMantLista";
            this.pnlMantLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMantLista.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.pnlMantLista.Size = new System.Drawing.Size(1124, 580);
            this.pnlMantLista.TabIndex = 0;
            // 
            // tabMantenimiento
            // 
            this.tabMantenimiento.Controls.Add(this.pnlMantLista);
            this.tabMantenimiento.Controls.Add(this.pnlMantForm);
            this.tabMantenimiento.BackColor = System.Drawing.Color.FromArgb(26, 28, 36);
            this.tabMantenimiento.Name = "tabMantenimiento";
            this.tabMantenimiento.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.tabMantenimiento.Text = "4. Mantenimiento";
            this.tabMantenimiento.UseVisualStyleBackColor = false;
            // 
            // dgvReporte
            // 
            this.dgvReporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.TabIndex = 0;
            // 
            // lblRepTipo
            // 
            this.lblRepTipo.AutoSize = true;
            this.lblRepTipo.Location = new System.Drawing.Point(16, 10);
            this.lblRepTipo.Name = "lblRepTipo";
            this.lblRepTipo.Text = "Reporte";
            this.lblRepTipo.Size = new System.Drawing.Size(120, 19);
            this.lblRepTipo.TabIndex = 0;
            // 
            // cmbRepTipo
            // 
            this.cmbRepTipo.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.cmbRepTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbRepTipo.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.cmbRepTipo.Location = new System.Drawing.Point(16, 32);
            this.cmbRepTipo.Name = "cmbRepTipo";
            this.cmbRepTipo.Size = new System.Drawing.Size(340, 27);
            this.cmbRepTipo.TabIndex = 1;
            this.cmbRepTipo.SelectedIndexChanged += new System.EventHandler(this.cmbRepTipo_SelectedIndexChanged);
            // 
            // lblRepSalon
            // 
            this.lblRepSalon.AutoSize = true;
            this.lblRepSalon.Location = new System.Drawing.Point(372, 10);
            this.lblRepSalon.Name = "lblRepSalon";
            this.lblRepSalon.Text = "Aula o departamento";
            this.lblRepSalon.Size = new System.Drawing.Size(120, 19);
            this.lblRepSalon.TabIndex = 2;
            // 
            // cmbRepSalon
            // 
            this.cmbRepSalon.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.cmbRepSalon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbRepSalon.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.cmbRepSalon.Location = new System.Drawing.Point(372, 32);
            this.cmbRepSalon.Name = "cmbRepSalon";
            this.cmbRepSalon.Size = new System.Drawing.Size(230, 27);
            this.cmbRepSalon.TabIndex = 3;
            // 
            // lblRepDesde
            // 
            this.lblRepDesde.AutoSize = true;
            this.lblRepDesde.Location = new System.Drawing.Point(618, 10);
            this.lblRepDesde.Name = "lblRepDesde";
            this.lblRepDesde.Text = "Desde";
            this.lblRepDesde.Size = new System.Drawing.Size(120, 19);
            this.lblRepDesde.TabIndex = 4;
            // 
            // dtpRepDesde
            // 
            this.dtpRepDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRepDesde.Location = new System.Drawing.Point(618, 32);
            this.dtpRepDesde.Name = "dtpRepDesde";
            this.dtpRepDesde.Size = new System.Drawing.Size(130, 27);
            this.dtpRepDesde.TabIndex = 5;
            // 
            // lblRepHasta
            // 
            this.lblRepHasta.AutoSize = true;
            this.lblRepHasta.Location = new System.Drawing.Point(764, 10);
            this.lblRepHasta.Name = "lblRepHasta";
            this.lblRepHasta.Text = "Hasta";
            this.lblRepHasta.Size = new System.Drawing.Size(120, 19);
            this.lblRepHasta.TabIndex = 6;
            // 
            // dtpRepHasta
            // 
            this.dtpRepHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRepHasta.Location = new System.Drawing.Point(764, 32);
            this.dtpRepHasta.Name = "dtpRepHasta";
            this.dtpRepHasta.Size = new System.Drawing.Size(130, 27);
            this.dtpRepHasta.TabIndex = 7;
            // 
            // btnRepGenerar
            // 
            this.btnRepGenerar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRepGenerar.Location = new System.Drawing.Point(910, 30);
            this.btnRepGenerar.Name = "btnRepGenerar";
            this.btnRepGenerar.Size = new System.Drawing.Size(110, 32);
            this.btnRepGenerar.Text = "Generar";
            this.btnRepGenerar.TabIndex = 8;
            this.btnRepGenerar.Click += new System.EventHandler(this.btnRepGenerar_Click);
            // 
            // btnRepPdf
            // 
            this.btnRepPdf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRepPdf.Location = new System.Drawing.Point(1028, 30);
            this.btnRepPdf.Name = "btnRepPdf";
            this.btnRepPdf.Size = new System.Drawing.Size(140, 32);
            this.btnRepPdf.Text = "Exportar a PDF";
            this.btnRepPdf.Tipo = Vistass.TipoBoton.Secundario;
            this.btnRepPdf.TabIndex = 9;
            this.btnRepPdf.Click += new System.EventHandler(this.btnRepPdf_Click);
            // 
            // lblRepInfo
            // 
            this.lblRepInfo.AutoSize = true;
            this.lblRepInfo.Location = new System.Drawing.Point(16, 68);
            this.lblRepInfo.Name = "lblRepInfo";
            this.lblRepInfo.Text = "Elija un reporte y presione Generar";
            this.lblRepInfo.Size = new System.Drawing.Size(120, 19);
            this.lblRepInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRepInfo.ForeColor = System.Drawing.Color.FromArgb(150, 160, 182);
            this.lblRepInfo.TabIndex = 10;
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
            this.pnlRepFiltros.Name = "pnlRepFiltros";
            this.pnlRepFiltros.BackColor = System.Drawing.Color.FromArgb(21, 23, 31);
            this.pnlRepFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRepFiltros.Size = new System.Drawing.Size(1200, 96);
            this.pnlRepFiltros.TabIndex = 1;
            // 
            // tabReportes
            // 
            this.tabReportes.Controls.Add(this.dgvReporte);
            this.tabReportes.Controls.Add(this.pnlRepFiltros);
            this.tabReportes.BackColor = System.Drawing.Color.FromArgb(26, 28, 36);
            this.tabReportes.Name = "tabReportes";
            this.tabReportes.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.tabReportes.Text = "5. Reportes";
            this.tabReportes.UseVisualStyleBackColor = false;
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Controls.Add(this.tabCatalogo);
            this.tabPrincipal.Controls.Add(this.tabPrestamos);
            this.tabPrincipal.Controls.Add(this.tabConsumibles);
            this.tabPrincipal.Controls.Add(this.tabMantenimiento);
            this.tabPrincipal.Controls.Add(this.tabReportes);
            this.tabPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPrincipal.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPrincipal.ItemSize = new System.Drawing.Size(190, 36);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.SelectedIndex = 0;
            this.tabPrincipal.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabPrincipal.TabIndex = 0;
            this.tabPrincipal.SelectedIndexChanged += new System.EventHandler(this.tabPrincipal_SelectedIndexChanged);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 6);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(401, 32);
            this.lblTitulo.Text = "Gestión de activos escolares";
            this.lblTitulo.TabIndex = 0;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(150, 160, 182);
            this.lblSubtitulo.Location = new System.Drawing.Point(2, 44);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(600, 19);
            this.lblSubtitulo.Text = "Catálogo, préstamos, consumibles, mantenimiento y reportes de los bienes de la institución";
            this.lblSubtitulo.TabIndex = 1;
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.Controls.Add(this.lblTitulo);
            this.pnlEncabezado.Controls.Add(this.lblSubtitulo);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Size = new System.Drawing.Size(1200, 72);
            // 
            // lblKpi1
            // 
            this.lblKpi1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpi1.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKpi1.ForeColor = System.Drawing.Color.FromArgb(250, 204, 21);
            this.lblKpi1.Name = "lblKpi1";
            this.lblKpi1.Size = new System.Drawing.Size(100, 44);
            this.lblKpi1.Text = "0";
            this.lblKpi1.TabIndex = 1;
            // 
            // lblKpi1Txt
            // 
            this.lblKpi1Txt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKpi1Txt.ForeColor = System.Drawing.Color.FromArgb(150, 160, 182);
            this.lblKpi1Txt.Name = "lblKpi1Txt";
            this.lblKpi1Txt.Size = new System.Drawing.Size(100, 40);
            this.lblKpi1Txt.Text = "Activos registrados";
            this.lblKpi1Txt.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblKpi1Txt.TabIndex = 0;
            // 
            // pnlKpi1
            // 
            this.pnlKpi1.Controls.Add(this.lblKpi1Txt);
            this.pnlKpi1.Controls.Add(this.lblKpi1);
            this.pnlKpi1.Name = "pnlKpi1";
            this.pnlKpi1.BackColor = System.Drawing.Color.FromArgb(21, 23, 31);
            this.pnlKpi1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpi1.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.pnlKpi1.Padding = new System.Windows.Forms.Padding(18, 10, 10, 8);
            this.pnlKpi1.Size = new System.Drawing.Size(200, 96);
            // 
            // lblKpi2
            // 
            this.lblKpi2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpi2.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKpi2.ForeColor = System.Drawing.Color.FromArgb(250, 204, 21);
            this.lblKpi2.Name = "lblKpi2";
            this.lblKpi2.Size = new System.Drawing.Size(100, 44);
            this.lblKpi2.Text = "0";
            this.lblKpi2.TabIndex = 1;
            // 
            // lblKpi2Txt
            // 
            this.lblKpi2Txt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKpi2Txt.ForeColor = System.Drawing.Color.FromArgb(150, 160, 182);
            this.lblKpi2Txt.Name = "lblKpi2Txt";
            this.lblKpi2Txt.Size = new System.Drawing.Size(100, 40);
            this.lblKpi2Txt.Text = "Préstamos activos";
            this.lblKpi2Txt.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblKpi2Txt.TabIndex = 0;
            // 
            // pnlKpi2
            // 
            this.pnlKpi2.Controls.Add(this.lblKpi2Txt);
            this.pnlKpi2.Controls.Add(this.lblKpi2);
            this.pnlKpi2.Name = "pnlKpi2";
            this.pnlKpi2.BackColor = System.Drawing.Color.FromArgb(21, 23, 31);
            this.pnlKpi2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpi2.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.pnlKpi2.Padding = new System.Windows.Forms.Padding(18, 10, 10, 8);
            this.pnlKpi2.Size = new System.Drawing.Size(200, 96);
            // 
            // lblKpi3
            // 
            this.lblKpi3.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpi3.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKpi3.ForeColor = System.Drawing.Color.FromArgb(76, 217, 100);
            this.lblKpi3.Name = "lblKpi3";
            this.lblKpi3.Size = new System.Drawing.Size(100, 44);
            this.lblKpi3.Text = "0";
            this.lblKpi3.TabIndex = 1;
            // 
            // lblKpi3Txt
            // 
            this.lblKpi3Txt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKpi3Txt.ForeColor = System.Drawing.Color.FromArgb(150, 160, 182);
            this.lblKpi3Txt.Name = "lblKpi3Txt";
            this.lblKpi3Txt.Size = new System.Drawing.Size(100, 40);
            this.lblKpi3Txt.Text = "Préstamos atrasados";
            this.lblKpi3Txt.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblKpi3Txt.TabIndex = 0;
            // 
            // pnlKpi3
            // 
            this.pnlKpi3.Controls.Add(this.lblKpi3Txt);
            this.pnlKpi3.Controls.Add(this.lblKpi3);
            this.pnlKpi3.Name = "pnlKpi3";
            this.pnlKpi3.BackColor = System.Drawing.Color.FromArgb(21, 23, 31);
            this.pnlKpi3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpi3.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.pnlKpi3.Padding = new System.Windows.Forms.Padding(18, 10, 10, 8);
            this.pnlKpi3.Size = new System.Drawing.Size(200, 96);
            // 
            // lblKpi4
            // 
            this.lblKpi4.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpi4.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKpi4.ForeColor = System.Drawing.Color.FromArgb(250, 204, 21);
            this.lblKpi4.Name = "lblKpi4";
            this.lblKpi4.Size = new System.Drawing.Size(100, 44);
            this.lblKpi4.Text = "0";
            this.lblKpi4.TabIndex = 1;
            // 
            // lblKpi4Txt
            // 
            this.lblKpi4Txt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKpi4Txt.ForeColor = System.Drawing.Color.FromArgb(150, 160, 182);
            this.lblKpi4Txt.Name = "lblKpi4Txt";
            this.lblKpi4Txt.Size = new System.Drawing.Size(100, 40);
            this.lblKpi4Txt.Text = "Reportes de daño abiertos";
            this.lblKpi4Txt.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblKpi4Txt.TabIndex = 0;
            // 
            // pnlKpi4
            // 
            this.pnlKpi4.Controls.Add(this.lblKpi4Txt);
            this.pnlKpi4.Controls.Add(this.lblKpi4);
            this.pnlKpi4.Name = "pnlKpi4";
            this.pnlKpi4.BackColor = System.Drawing.Color.FromArgb(21, 23, 31);
            this.pnlKpi4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpi4.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.pnlKpi4.Padding = new System.Windows.Forms.Padding(18, 10, 10, 8);
            this.pnlKpi4.Size = new System.Drawing.Size(200, 96);
            // 
            // lblKpi5
            // 
            this.lblKpi5.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpi5.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKpi5.ForeColor = System.Drawing.Color.FromArgb(76, 217, 100);
            this.lblKpi5.Name = "lblKpi5";
            this.lblKpi5.Size = new System.Drawing.Size(100, 44);
            this.lblKpi5.Text = "0";
            this.lblKpi5.TabIndex = 1;
            // 
            // lblKpi5Txt
            // 
            this.lblKpi5Txt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKpi5Txt.ForeColor = System.Drawing.Color.FromArgb(150, 160, 182);
            this.lblKpi5Txt.Name = "lblKpi5Txt";
            this.lblKpi5Txt.Size = new System.Drawing.Size(100, 40);
            this.lblKpi5Txt.Text = "Consumibles en alerta de stock";
            this.lblKpi5Txt.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblKpi5Txt.TabIndex = 0;
            // 
            // pnlKpi5
            // 
            this.pnlKpi5.Controls.Add(this.lblKpi5Txt);
            this.pnlKpi5.Controls.Add(this.lblKpi5);
            this.pnlKpi5.Name = "pnlKpi5";
            this.pnlKpi5.BackColor = System.Drawing.Color.FromArgb(21, 23, 31);
            this.pnlKpi5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpi5.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.pnlKpi5.Padding = new System.Windows.Forms.Padding(18, 10, 10, 8);
            this.pnlKpi5.Size = new System.Drawing.Size(200, 96);
            // 
            // tlpKpis
            // 
            this.tlpKpis.ColumnCount = 5;
            this.tlpKpis.RowCount = 1;
            this.tlpKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpKpis.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpKpis.Controls.Add(this.pnlKpi1, 0, 0);
            this.tlpKpis.Controls.Add(this.pnlKpi2, 1, 0);
            this.tlpKpis.Controls.Add(this.pnlKpi3, 2, 0);
            this.tlpKpis.Controls.Add(this.pnlKpi4, 3, 0);
            this.tlpKpis.Controls.Add(this.pnlKpi5, 4, 0);
            this.tlpKpis.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpKpis.Name = "tlpKpis";
            this.tlpKpis.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.tlpKpis.Size = new System.Drawing.Size(1200, 108);
            this.tlpKpis.TabIndex = 1;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmGestionActivos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(26, 28, 36);
            this.ClientSize = new System.Drawing.Size(1240, 800);
            this.Controls.Add(this.tabPrincipal);
            this.Controls.Add(this.tlpKpis);
            this.Controls.Add(this.pnlEncabezado);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(226, 232, 244);
            this.Name = "frmGestionActivos";
            this.Padding = new System.Windows.Forms.Padding(20, 0, 20, 16);
            this.Text = "Gestión de activos";
            this.Load += new System.EventHandler(this.frmGestionActivos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Vistass.BotonTema btnGuardar;
        private Vistass.BotonTema btnActualizar;
        private Vistass.BotonTema btnEliminar;
        private Vistass.BotonTema btnLimpiar;
        private System.Windows.Forms.Label lblModo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label lblUbicacion;
        private System.Windows.Forms.ComboBox cmbUbicacion;
        private System.Windows.Forms.Panel pnlFormulario;
        private Vistass.GridOscuro dgvActivos;
        private System.Windows.Forms.Panel pnlSeparador;
        private Vistass.GridOscuro dgvUbicacion;
        private Vistass.GridOscuro dgvHistorial;
        private Vistass.GridOscuro dgvDanos;
        private System.Windows.Forms.TabPage tabUbicacion;
        private System.Windows.Forms.TabPage tabHistorial;
        private System.Windows.Forms.TabPage tabDanos;
        private Vistass.TabControlOscuro tabFicha;
        private System.Windows.Forms.Label lblFichaTitulo;
        private System.Windows.Forms.Panel pnlFicha;
        private System.Windows.Forms.Label lblBuscar;
        private Vistass.BotonTema btnExportarPdf;
        private Vistass.BotonTema btnHistorial;
        private Vistass.BotonTema btnVerUnidades;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.ComboBox cmbFiltroCategoria;
        private System.Windows.Forms.ComboBox cmbFiltroEstado;
        private System.Windows.Forms.Panel pnlBusqueda;
        private System.Windows.Forms.Panel pnlLista;
        private System.Windows.Forms.TabPage tabCatalogo;
        private System.Windows.Forms.Label lblPrestTitulo;
        private System.Windows.Forms.Label lblPrestActivo;
        private System.Windows.Forms.ComboBox cmbPrestActivo;
        private System.Windows.Forms.Label lblPrestCodigo;
        private System.Windows.Forms.TextBox txtPrestCodigo;
        private System.Windows.Forms.Label lblPrestCant;
        private System.Windows.Forms.NumericUpDown numPrestCant;
        private System.Windows.Forms.Label lblPrestTipo;
        private System.Windows.Forms.ComboBox cmbPrestTipo;
        private System.Windows.Forms.Label lblPrestResp;
        private System.Windows.Forms.TextBox txtPrestResp;
        private System.Windows.Forms.Label lblPrestAula;
        private System.Windows.Forms.ComboBox cmbPrestAula;
        private System.Windows.Forms.Label lblPrestLimite;
        private System.Windows.Forms.DateTimePicker dtpPrestLimite;
        private System.Windows.Forms.Label lblPrestObs;
        private System.Windows.Forms.TextBox txtPrestObs;
        private Vistass.BotonTema btnPrestar;
        private System.Windows.Forms.Panel pnlPrestForm;
        private Vistass.GridOscuro dgvPrestamos;
        private System.Windows.Forms.Label lblDevSel;
        private System.Windows.Forms.Label lblDevEstado;
        private System.Windows.Forms.ComboBox cmbDevEstado;
        private System.Windows.Forms.Label lblDevObs;
        private System.Windows.Forms.TextBox txtDevObs;
        private Vistass.BotonTema btnDevolver;
        private Vistass.BotonTema btnHoja;
        private System.Windows.Forms.Panel pnlDevolucion;
        private System.Windows.Forms.Label lblPrestVer;
        private System.Windows.Forms.ComboBox cmbPrestVer;
        private System.Windows.Forms.Label lblPrestAlertas;
        private System.Windows.Forms.Panel pnlPrestFiltro;
        private System.Windows.Forms.Panel pnlPrestLista;
        private System.Windows.Forms.TabPage tabPrestamos;
        private System.Windows.Forms.Label lblConsNuevo;
        private System.Windows.Forms.Label lblConsNombre;
        private System.Windows.Forms.TextBox txtConsNombre;
        private System.Windows.Forms.Label lblConsUnidad;
        private System.Windows.Forms.TextBox txtConsUnidad;
        private System.Windows.Forms.Label lblConsMin;
        private System.Windows.Forms.NumericUpDown numConsMin;
        private Vistass.BotonTema btnConsCrear;
        private System.Windows.Forms.Label lblMovTitulo;
        private System.Windows.Forms.Label lblMovCons;
        private System.Windows.Forms.ComboBox cmbMovCons;
        private System.Windows.Forms.Label lblMovTipo;
        private System.Windows.Forms.ComboBox cmbMovTipo;
        private System.Windows.Forms.Label lblMovCant;
        private System.Windows.Forms.NumericUpDown numMovCant;
        private System.Windows.Forms.Label lblMovMotivo;
        private System.Windows.Forms.ComboBox cmbMovMotivo;
        private System.Windows.Forms.Label lblMovDestino;
        private System.Windows.Forms.ComboBox txtMovDestino;
        private Vistass.BotonTema btnMovimiento;
        private System.Windows.Forms.Panel pnlConsForm;
        private Vistass.GridOscuro dgvStock;
        private System.Windows.Forms.Label lblStockTitulo;
        private System.Windows.Forms.Panel pnlStock;
        private Vistass.GridOscuro dgvKardex;
        private System.Windows.Forms.Label lblKardexTitulo;
        private Vistass.BotonTema btnKardexTodos;
        private System.Windows.Forms.Panel pnlKardexBarra;
        private System.Windows.Forms.Panel pnlConsLista;
        private System.Windows.Forms.TabPage tabConsumibles;
        private System.Windows.Forms.Label lblMantTitulo;
        private System.Windows.Forms.Label lblMantActivo;
        private System.Windows.Forms.ComboBox cmbMantActivo;
        private System.Windows.Forms.Label lblMantCodigo;
        private System.Windows.Forms.TextBox txtMantCodigo;
        private System.Windows.Forms.Label lblMantFecha;
        private System.Windows.Forms.DateTimePicker dtpMantFecha;
        private System.Windows.Forms.Label lblMantTipo;
        private System.Windows.Forms.ComboBox cmbMantTipo;
        private System.Windows.Forms.Label lblMantCosto;
        private System.Windows.Forms.NumericUpDown numMantCosto;
        private System.Windows.Forms.Label lblMantEstado;
        private System.Windows.Forms.ComboBox cmbMantEstado;
        private System.Windows.Forms.Label lblMantDesc;
        private System.Windows.Forms.TextBox txtMantDesc;
        private System.Windows.Forms.Label lblMantVinculo;
        private Vistass.BotonTema btnMantRegistrar;
        private Vistass.BotonTema btnMantLimpiar;
        private System.Windows.Forms.Panel pnlMantForm;
        private Vistass.GridOscuro dgvMantenimientos;
        private System.Windows.Forms.Label lblMantHistTitulo;
        private System.Windows.Forms.Panel pnlMantLista;
        private System.Windows.Forms.TabPage tabMantenimiento;
        private Vistass.GridOscuro dgvReporte;
        private System.Windows.Forms.Label lblRepTipo;
        private System.Windows.Forms.ComboBox cmbRepTipo;
        private System.Windows.Forms.Label lblRepSalon;
        private System.Windows.Forms.ComboBox cmbRepSalon;
        private System.Windows.Forms.Label lblRepDesde;
        private System.Windows.Forms.DateTimePicker dtpRepDesde;
        private System.Windows.Forms.Label lblRepHasta;
        private System.Windows.Forms.DateTimePicker dtpRepHasta;
        private Vistass.BotonTema btnRepGenerar;
        private Vistass.BotonTema btnRepPdf;
        private System.Windows.Forms.Label lblRepInfo;
        private System.Windows.Forms.Panel pnlRepFiltros;
        private System.Windows.Forms.TabPage tabReportes;
        private Vistass.TabControlOscuro tabPrincipal;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label lblKpi1;
        private System.Windows.Forms.Label lblKpi1Txt;
        private System.Windows.Forms.Panel pnlKpi1;
        private System.Windows.Forms.Label lblKpi2;
        private System.Windows.Forms.Label lblKpi2Txt;
        private System.Windows.Forms.Panel pnlKpi2;
        private System.Windows.Forms.Label lblKpi3;
        private System.Windows.Forms.Label lblKpi3Txt;
        private System.Windows.Forms.Panel pnlKpi3;
        private System.Windows.Forms.Label lblKpi4;
        private System.Windows.Forms.Label lblKpi4Txt;
        private System.Windows.Forms.Panel pnlKpi4;
        private System.Windows.Forms.Label lblKpi5;
        private System.Windows.Forms.Label lblKpi5Txt;
        private System.Windows.Forms.Panel pnlKpi5;
        private System.Windows.Forms.TableLayoutPanel tlpKpis;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
