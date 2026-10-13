namespace Vistass
{
    partial class frmRegistroActividad
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

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle estFecha = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblResultados = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlFiltros = new Vistass.PanelTarjeta();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new Vistass.FechaOscura();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new Vistass.FechaOscura();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.cmbUsuario = new Vistass.ComboOscuro();
            this.lblModulo = new System.Windows.Forms.Label();
            this.cmbModulo = new Vistass.ComboOscuro();
            this.lblAccion = new System.Windows.Forms.Label();
            this.cmbAccion = new Vistass.ComboOscuro();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new Vistass.BotonTema();
            this.btnLimpiar = new Vistass.BotonTema();
            this.btnHoy = new Vistass.BotonTema();
            this.btnSemana = new Vistass.BotonTema();
            this.btnMes = new Vistass.BotonTema();
            this.btnDetalle = new Vistass.BotonTema();
            this.pnlTabla = new System.Windows.Forms.Panel();
            this.dgvActividad = new Vistass.GridOscuro();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResumen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlEncabezado.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            this.pnlTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActividad)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.BackColor = System.Drawing.Color. FromArgb(18, 18, 18);
            this.pnlEncabezado.Controls.Add(this.lblResultados);
            this.pnlEncabezado.Controls.Add(this.lblSubtitulo);
            this.pnlEncabezado.Controls.Add(this.lblTitulo);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Location = new System.Drawing.Point(24, 0);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(1200, 84);
            this.pnlEncabezado.TabIndex = 2;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color. FromArgb(240, 244, 252);
            this.lblTitulo.Location = new System.Drawing.Point(0, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(290, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Registro de actividad";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitulo.ForeColor = System.Drawing.Color. FromArgb(170, 180, 200);
            this.lblSubtitulo.Location = new System.Drawing.Point(2, 52);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(400, 19);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Quién hizo qué y cuándo. Este registro no se puede editar ni borrar.";
            // 
            // lblResultados
            // 
            this.lblResultados.AutoSize = false;
            this.lblResultados.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblResultados.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultados.ForeColor = System.Drawing.Color. FromArgb(170, 180, 200);
            this.lblResultados.Location = new System.Drawing.Point(880, 0);
            this.lblResultados.Name = "lblResultados";
            this.lblResultados.Padding = new System.Windows.Forms.Padding(0, 0, 0, 14);
            this.lblResultados.Size = new System.Drawing.Size(320, 84);
            this.lblResultados.TabIndex = 2;
            this.lblResultados.Text = "0 registros";
            this.lblResultados.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.BackColor = System.Drawing.Color. FromArgb(27, 29, 38);
            this.pnlFiltros.Controls.Add(this.lblDesde);
            this.pnlFiltros.Controls.Add(this.dtpDesde);
            this.pnlFiltros.Controls.Add(this.lblHasta);
            this.pnlFiltros.Controls.Add(this.dtpHasta);
            this.pnlFiltros.Controls.Add(this.lblUsuario);
            this.pnlFiltros.Controls.Add(this.cmbUsuario);
            this.pnlFiltros.Controls.Add(this.lblModulo);
            this.pnlFiltros.Controls.Add(this.cmbModulo);
            this.pnlFiltros.Controls.Add(this.lblAccion);
            this.pnlFiltros.Controls.Add(this.cmbAccion);
            this.pnlFiltros.Controls.Add(this.lblBuscar);
            this.pnlFiltros.Controls.Add(this.txtBuscar);
            this.pnlFiltros.Controls.Add(this.btnBuscar);
            this.pnlFiltros.Controls.Add(this.btnLimpiar);
            this.pnlFiltros.Controls.Add(this.btnHoy);
            this.pnlFiltros.Controls.Add(this.btnSemana);
            this.pnlFiltros.Controls.Add(this.btnMes);
            this.pnlFiltros.Controls.Add(this.btnDetalle);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Location = new System.Drawing.Point(24, 84);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(1200, 132);
            this.pnlFiltros.TabIndex = 1;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesde.ForeColor = System.Drawing.Color. FromArgb(170, 180, 200);
            this.lblDesde.Location = new System.Drawing.Point(16, 12);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(40, 15);
            this.lblDesde.TabIndex = 0;
            this.lblDesde.Text = "Desde";
            // 
            // dtpDesde
            // 
            this.dtpDesde.CalendarMonthBackground = System.Drawing.Color.FromArgb(38, 42, 58);
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDesde.CustomFormat = "dd/MM/yyyy";
            this.dtpDesde.Location = new System.Drawing.Point(16, 34);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(140, 26);
            this.dtpDesde.TabIndex = 1;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHasta.ForeColor = System.Drawing.Color. FromArgb(170, 180, 200);
            this.lblHasta.Location = new System.Drawing.Point(164, 12);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(37, 15);
            this.lblHasta.TabIndex = 2;
            this.lblHasta.Text = "Hasta";
            // 
            // dtpHasta
            // 
            this.dtpHasta.CalendarMonthBackground = System.Drawing.Color.FromArgb(38, 42, 58);
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHasta.CustomFormat = "dd/MM/yyyy";
            this.dtpHasta.Location = new System.Drawing.Point(164, 34);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(140, 26);
            this.dtpHasta.TabIndex = 3;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color. FromArgb(170, 180, 200);
            this.lblUsuario.Location = new System.Drawing.Point(312, 12);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(47, 15);
            this.lblUsuario.TabIndex = 4;
            this.lblUsuario.Text = "Usuario";
            // 
            // cmbUsuario
            // 
            this.cmbUsuario.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbUsuario.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUsuario.ForeColor = System.Drawing.Color. FromArgb(240, 244, 252);
            this.cmbUsuario.FormattingEnabled = true;
            this.cmbUsuario.Location = new System.Drawing.Point(312, 34);
            this.cmbUsuario.Name = "cmbUsuario";
            this.cmbUsuario.Size = new System.Drawing.Size(190, 27);
            this.cmbUsuario.TabIndex = 5;
            // 
            // lblModulo
            // 
            this.lblModulo.AutoSize = true;
            this.lblModulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModulo.ForeColor = System.Drawing.Color. FromArgb(170, 180, 200);
            this.lblModulo.Location = new System.Drawing.Point(510, 12);
            this.lblModulo.Name = "lblModulo";
            this.lblModulo.Size = new System.Drawing.Size(47, 15);
            this.lblModulo.TabIndex = 6;
            this.lblModulo.Text = "Módulo";
            // 
            // cmbModulo
            // 
            this.cmbModulo.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.cmbModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbModulo.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbModulo.ForeColor = System.Drawing.Color. FromArgb(240, 244, 252);
            this.cmbModulo.FormattingEnabled = true;
            this.cmbModulo.Location = new System.Drawing.Point(510, 34);
            this.cmbModulo.Name = "cmbModulo";
            this.cmbModulo.Size = new System.Drawing.Size(230, 27);
            this.cmbModulo.TabIndex = 7;
            // 
            // lblAccion
            // 
            this.lblAccion.AutoSize = true;
            this.lblAccion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccion.ForeColor = System.Drawing.Color. FromArgb(170, 180, 200);
            this.lblAccion.Location = new System.Drawing.Point(748, 12);
            this.lblAccion.Name = "lblAccion";
            this.lblAccion.Size = new System.Drawing.Size(44, 15);
            this.lblAccion.TabIndex = 8;
            this.lblAccion.Text = "Acción";
            // 
            // cmbAccion
            // 
            this.cmbAccion.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.cmbAccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbAccion.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAccion.ForeColor = System.Drawing.Color. FromArgb(240, 244, 252);
            this.cmbAccion.FormattingEnabled = true;
            this.cmbAccion.Location = new System.Drawing.Point(748, 34);
            this.cmbAccion.Name = "cmbAccion";
            this.cmbAccion.Size = new System.Drawing.Size(210, 27);
            this.cmbAccion.TabIndex = 9;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.ForeColor = System.Drawing.Color. FromArgb(170, 180, 200);
            this.lblBuscar.Location = new System.Drawing.Point(966, 12);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(91, 15);
            this.lblBuscar.TabIndex = 10;
            this.lblBuscar.Text = "Buscar en detalle";
            // 
            // txtBuscar
            // 
            this.txtBuscar.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.ForeColor = System.Drawing.Color. FromArgb(240, 244, 252);
            this.txtBuscar.Location = new System.Drawing.Point(966, 34);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(218, 26);
            this.txtBuscar.TabIndex = 11;
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(16, 78);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(120, 38);
            this.btnBuscar.TabIndex = 12;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Tipo = Vistass.TipoBoton.Principal;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(144, 78);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(100, 38);
            this.btnLimpiar.TabIndex = 13;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Tipo = Vistass.TipoBoton.Secundario;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnHoy
            // 
            this.btnHoy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHoy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoy.Location = new System.Drawing.Point(276, 78);
            this.btnHoy.Name = "btnHoy";
            this.btnHoy.Size = new System.Drawing.Size(80, 38);
            this.btnHoy.TabIndex = 14;
            this.btnHoy.Text = "Hoy";
            this.btnHoy.Tipo = Vistass.TipoBoton.Secundario;
            this.btnHoy.Click += new System.EventHandler(this.btnHoy_Click);
            // 
            // btnSemana
            // 
            this.btnSemana.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSemana.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSemana.Location = new System.Drawing.Point(364, 78);
            this.btnSemana.Name = "btnSemana";
            this.btnSemana.Size = new System.Drawing.Size(130, 38);
            this.btnSemana.TabIndex = 15;
            this.btnSemana.Text = "Últimos 7 días";
            this.btnSemana.Tipo = Vistass.TipoBoton.Secundario;
            this.btnSemana.Click += new System.EventHandler(this.btnSemana_Click);
            // 
            // btnMes
            // 
            this.btnMes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMes.Location = new System.Drawing.Point(502, 78);
            this.btnMes.Name = "btnMes";
            this.btnMes.Size = new System.Drawing.Size(140, 38);
            this.btnMes.TabIndex = 16;
            this.btnMes.Text = "Últimos 30 días";
            this.btnMes.Tipo = Vistass.TipoBoton.Secundario;
            this.btnMes.Click += new System.EventHandler(this.btnMes_Click);
            // 
            // btnDetalle
            // 
            this.btnDetalle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetalle.Enabled = false;
            this.btnDetalle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalle.Location = new System.Drawing.Point(1024, 78);
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(160, 38);
            this.btnDetalle.TabIndex = 17;
            this.btnDetalle.Text = "Ver detalle";
            this.btnDetalle.Tipo = Vistass.TipoBoton.Secundario;
            this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
            // 
            // pnlTabla
            // 
            this.pnlTabla.BackColor = System.Drawing.Color. FromArgb(18, 18, 18);
            this.pnlTabla.Controls.Add(this.dgvActividad);
            this.pnlTabla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTabla.Location = new System.Drawing.Point(24, 216);
            this.pnlTabla.Name = "pnlTabla";
            this.pnlTabla.Padding = new System.Windows.Forms.Padding(0, 16, 0, 0);
            this.pnlTabla.Size = new System.Drawing.Size(1200, 544);
            this.pnlTabla.TabIndex = 0;
            // 
            // dgvActividad
            // 
            this.dgvActividad.AllowUserToAddRows = false;
            this.dgvActividad.AllowUserToDeleteRows = false;
            this.dgvActividad.AllowUserToResizeRows = false;
            this.dgvActividad.AutoGenerateColumns = false;
            this.dgvActividad.ColumnHeadersHeight = 40;
            this.dgvActividad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvActividad.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colFecha,
            this.colUsuario,
            this.colNombre,
            this.colModulo,
            this.colAccion,
            this.colClave,
            this.colResumen});
            this.dgvActividad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvActividad.Location = new System.Drawing.Point(0, 16);
            this.dgvActividad.MultiSelect = false;
            this.dgvActividad.Name = "dgvActividad";
            this.dgvActividad.ReadOnly = true;
            this.dgvActividad.RowTemplate.Height = 36;
            this.dgvActividad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvActividad.Size = new System.Drawing.Size(1200, 528);
            this.dgvActividad.TabIndex = 0;
            this.dgvActividad.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvActividad_CellDoubleClick);
            this.dgvActividad.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvActividad_CellFormatting);
            this.dgvActividad.SelectionChanged += new System.EventHandler(this.dgvActividad_SelectionChanged);
            // 
            // colId
            // 
            this.colId.DataPropertyName = "IdAuditoria";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colFecha
            // 
            estFecha.Format = "dd/MM/yyyy HH:mm:ss";
            this.colFecha.DataPropertyName = "FechaHora";
            this.colFecha.DefaultCellStyle = estFecha;
            this.colFecha.HeaderText = "Fecha y hora";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            this.colFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFecha.FillWeight = 15F;
            this.colFecha.MinimumWidth = 150;
            // 
            // colUsuario
            // 
            this.colUsuario.DataPropertyName = "Usuario";
            this.colUsuario.HeaderText = "Usuario";
            this.colUsuario.Name = "colUsuario";
            this.colUsuario.ReadOnly = true;
            this.colUsuario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colUsuario.FillWeight = 9F;
            this.colUsuario.MinimumWidth = 90;
            // 
            // colNombre
            // 
            this.colNombre.DataPropertyName = "NombreCompleto";
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            this.colNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNombre.FillWeight = 14F;
            this.colNombre.MinimumWidth = 150;
            // 
            // colModulo
            // 
            this.colModulo.DataPropertyName = "Modulo";
            this.colModulo.HeaderText = "Módulo";
            this.colModulo.Name = "colModulo";
            this.colModulo.ReadOnly = true;
            this.colModulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colModulo.FillWeight = 10F;
            this.colModulo.MinimumWidth = 100;
            // 
            // colAccion
            // 
            this.colAccion.DataPropertyName = "Accion";
            this.colAccion.HeaderText = "Acción";
            this.colAccion.Name = "colAccion";
            this.colAccion.ReadOnly = true;
            this.colAccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAccion.FillWeight = 13F;
            this.colAccion.MinimumWidth = 130;
            // 
            // colClave
            // 
            this.colClave.DataPropertyName = "Clave";
            this.colClave.HeaderText = "Registro";
            this.colClave.Name = "colClave";
            this.colClave.ReadOnly = true;
            this.colClave.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colClave.FillWeight = 9F;
            this.colClave.MinimumWidth = 90;
            // 
            // colResumen
            // 
            this.colResumen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colResumen.FillWeight = 40F;
            this.colResumen.DataPropertyName = "Resumen";
            this.colResumen.HeaderText = "Qué cambió";
            this.colResumen.MinimumWidth = 200;
            this.colResumen.Name = "colResumen";
            this.colResumen.ReadOnly = true;
            // 
            // frmRegistroActividad
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color. FromArgb(18, 18, 18);
            this.ClientSize = new System.Drawing.Size(1248, 760);
            this.Controls.Add(this.pnlTabla);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.pnlEncabezado);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmRegistroActividad";
            this.Padding = new System.Windows.Forms.Padding(24, 0, 24, 16);
            this.Text = "Registro de actividad";
            this.Load += new System.EventHandler(this.frmRegistroActividad_Load);
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.pnlTabla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActividad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblResultados;
        private Vistass.PanelTarjeta pnlFiltros;
        private System.Windows.Forms.Label lblDesde;
        private Vistass.FechaOscura dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private Vistass.FechaOscura dtpHasta;
        private System.Windows.Forms.Label lblUsuario;
        private Vistass.ComboOscuro cmbUsuario;
        private System.Windows.Forms.Label lblModulo;
        private Vistass.ComboOscuro cmbModulo;
        private System.Windows.Forms.Label lblAccion;
        private Vistass.ComboOscuro cmbAccion;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private Vistass.BotonTema btnBuscar;
        private Vistass.BotonTema btnLimpiar;
        private Vistass.BotonTema btnHoy;
        private Vistass.BotonTema btnSemana;
        private Vistass.BotonTema btnMes;
        private Vistass.BotonTema btnDetalle;
        private System.Windows.Forms.Panel pnlTabla;
        private Vistass.GridOscuro dgvActividad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClave;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResumen;
    }
}