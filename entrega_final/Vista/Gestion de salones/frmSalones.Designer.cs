namespace Vistass
{
    partial class frmSalones
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
            this.lblTituloSalones = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.flpResumen = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlCuerpo = new System.Windows.Forms.Panel();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.lblVacio = new System.Windows.Forms.Label();
            this.pnlTablaInv = new System.Windows.Forms.Panel();
            this.dgvInventario = new Vistass.GridOscuro();
            this.pnlBarraInv = new Vistass.PanelTarjeta();
            this.pnlBuscadorEquipo = new System.Windows.Forms.Panel();
            this.lblHintEquipo = new System.Windows.Forms.Label();
            this.txtBuscarEquipo = new System.Windows.Forms.TextBox();
            this.pnlLupaEquipo = new System.Windows.Forms.Panel();
            this.cmbCategoria = new Vistass.ComboOscuro();
            this.chkSoloProblemas = new System.Windows.Forms.CheckBox();
            this.btnAsignar = new Vistass.BotonTema();
            this.btnMover = new Vistass.BotonTema();
            this.btnQuitar = new Vistass.BotonTema();
            this.btnExportarPdf = new Vistass.BotonTema();
            this.lblSeleccionInv = new System.Windows.Forms.Label();
            this.pnlEspacio = new System.Windows.Forms.Panel();
            this.pnlSalonInfo = new Vistass.PanelTarjeta();
            this.flpChips = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlFilaNombre = new System.Windows.Forms.Panel();
            this.lblNombreSalon = new System.Windows.Forms.Label();
            this.pnlAccionesSalon = new System.Windows.Forms.Panel();
            this.btnEditarSalon = new Vistass.BotonTema();
            this.btnEstadoSalon = new Vistass.BotonTema();
            this.pnlLista = new System.Windows.Forms.Panel();
            this.pnlTablaLista = new System.Windows.Forms.Panel();
            this.dgvSalones = new Vistass.GridOscuro();
            this.pnlBarraLista = new Vistass.PanelTarjeta();
            this.pnlBuscadorSalon = new System.Windows.Forms.Panel();
            this.lblHintSalon = new System.Windows.Forms.Label();
            this.txtBuscarSalon = new System.Windows.Forms.TextBox();
            this.pnlLupaSalon = new System.Windows.Forms.Panel();
            this.btnNuevoSalon = new Vistass.BotonTema();
            this.cmbTipoSalon = new Vistass.ComboOscuro();
            this.chkInactivos = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlEncabezado.SuspendLayout();
            this.flpResumen.SuspendLayout();
            this.pnlCuerpo.SuspendLayout();
            this.pnlDetalle.SuspendLayout();
            this.pnlTablaInv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
            this.pnlBarraInv.SuspendLayout();
            this.pnlBuscadorEquipo.SuspendLayout();
            this.pnlSalonInfo.SuspendLayout();
            this.pnlFilaNombre.SuspendLayout();
            this.pnlAccionesSalon.SuspendLayout();
            this.pnlLista.SuspendLayout();
            this.pnlTablaLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalones)).BeginInit();
            this.pnlBarraLista.SuspendLayout();
            this.pnlBuscadorSalon.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.pnlEncabezado.Controls.Add(this.flpResumen);
            this.pnlEncabezado.Controls.Add(this.lblTituloSalones);
            this.pnlEncabezado.Controls.Add(this.lblSubtitulo);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Location = new System.Drawing.Point(24, 0);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(1200, 84);
            this.pnlEncabezado.TabIndex = 3;
            // 
            // lblTituloSalones
            // 
            this.lblTituloSalones.AutoSize = true;
            this.lblTituloSalones.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTituloSalones.ForeColor = System.Drawing.Color.FromArgb(240, 244, 252);
            this.lblTituloSalones.Location = new System.Drawing.Point(0, 12);
            this.lblTituloSalones.Name = "lblTituloSalones";
            this.lblTituloSalones.Text = "Gestión de salones";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(170, 180, 200);
            this.lblSubtitulo.Location = new System.Drawing.Point(2, 52);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Text = "Aulas, laboratorios y espacios con su equipo asignado";
            // 
            // flpResumen  (totales en una línea, pegados a la derecha del encabezado; se llenan desde el .cs)
            // 
            this.flpResumen.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.flpResumen.Dock = System.Windows.Forms.DockStyle.Right;
            this.flpResumen.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpResumen.Name = "flpResumen";
            this.flpResumen.Padding = new System.Windows.Forms.Padding(0, 46, 0, 0);
            this.flpResumen.Size = new System.Drawing.Size(520, 84);
            this.flpResumen.TabIndex = 2;
            this.flpResumen.WrapContents = false;
            // 
            // pnlCuerpo
            // 
            this.pnlCuerpo.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.pnlCuerpo.Controls.Add(this.pnlDetalle);
            this.pnlCuerpo.Controls.Add(this.pnlLista);
            this.pnlCuerpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCuerpo.Location = new System.Drawing.Point(24, 84);
            this.pnlCuerpo.Name = "pnlCuerpo";
            this.pnlCuerpo.Size = new System.Drawing.Size(1200, 660);
            this.pnlCuerpo.TabIndex = 0;
            // 
            // pnlDetalle  (zona derecha: ficha del salón + equipo)
            // 
            this.pnlDetalle.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.pnlDetalle.Controls.Add(this.lblVacio);
            this.pnlDetalle.Controls.Add(this.pnlTablaInv);
            this.pnlDetalle.Controls.Add(this.pnlBarraInv);
            this.pnlDetalle.Controls.Add(this.pnlEspacio);
            this.pnlDetalle.Controls.Add(this.pnlSalonInfo);
            this.pnlDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.TabIndex = 0;
            // 
            // lblVacio  (mensaje cuando no hay ningún salón seleccionado)
            // 
            this.lblVacio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVacio.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblVacio.ForeColor = System.Drawing.Color.FromArgb(170, 180, 200);
            this.lblVacio.Name = "lblVacio";
            this.lblVacio.Text = "Elija un salón de la lista para ver su equipo.";
            this.lblVacio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblVacio.Visible = false;
            // 
            // pnlTablaInv
            // 
            this.pnlTablaInv.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.pnlTablaInv.Controls.Add(this.dgvInventario);
            this.pnlTablaInv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTablaInv.Name = "pnlTablaInv";
            this.pnlTablaInv.Padding = new System.Windows.Forms.Padding(0, 16, 0, 0);
            this.pnlTablaInv.TabIndex = 0;
            // 
            // dgvInventario
            // 
            this.dgvInventario.ColumnHeadersHeight = 40;
            this.dgvInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.RowHeadersWidth = 51;
            this.dgvInventario.RowTemplate.Height = 36;
            this.dgvInventario.TabIndex = 0;
            this.dgvInventario.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvInventario_CellFormatting);
            this.dgvInventario.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvInventario_CellPainting);
            this.dgvInventario.SelectionChanged += new System.EventHandler(this.dgvInventario_SelectionChanged);
            // 
            // pnlBarraInv  (buscador, filtros y acciones del equipo)
            // 
            this.pnlBarraInv.BackColor = System.Drawing.Color.FromArgb(27, 29, 38);
            this.pnlBarraInv.Controls.Add(this.pnlBuscadorEquipo);
            this.pnlBarraInv.Controls.Add(this.cmbCategoria);
            this.pnlBarraInv.Controls.Add(this.chkSoloProblemas);
            this.pnlBarraInv.Controls.Add(this.btnAsignar);
            this.pnlBarraInv.Controls.Add(this.btnMover);
            this.pnlBarraInv.Controls.Add(this.btnQuitar);
            this.pnlBarraInv.Controls.Add(this.btnExportarPdf);
            this.pnlBarraInv.Controls.Add(this.lblSeleccionInv);
            this.pnlBarraInv.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarraInv.Name = "pnlBarraInv";
            this.pnlBarraInv.Size = new System.Drawing.Size(700, 112);
            this.pnlBarraInv.TabIndex = 1;
            // 
            // pnlBuscadorEquipo
            // 
            this.pnlBuscadorEquipo.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.pnlBuscadorEquipo.Controls.Add(this.lblHintEquipo);
            this.pnlBuscadorEquipo.Controls.Add(this.txtBuscarEquipo);
            this.pnlBuscadorEquipo.Controls.Add(this.pnlLupaEquipo);
            this.pnlBuscadorEquipo.Location = new System.Drawing.Point(16, 14);
            this.pnlBuscadorEquipo.Name = "pnlBuscadorEquipo";
            this.pnlBuscadorEquipo.Padding = new System.Windows.Forms.Padding(1);
            this.pnlBuscadorEquipo.Size = new System.Drawing.Size(290, 28);
            this.pnlBuscadorEquipo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBuscadorEquipo_Paint);
            // 
            // lblHintEquipo
            // 
            this.lblHintEquipo.AutoSize = true;
            this.lblHintEquipo.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.lblHintEquipo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblHintEquipo.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblHintEquipo.ForeColor = System.Drawing.Color.FromArgb(140, 150, 176);
            this.lblHintEquipo.Location = new System.Drawing.Point(33, 4);
            this.lblHintEquipo.Name = "lblHintEquipo";
            this.lblHintEquipo.Text = "Buscar equipo, categoría o código...";
            this.lblHintEquipo.Click += new System.EventHandler(this.lblHintEquipo_Click);
            // 
            // txtBuscarEquipo
            // 
            this.txtBuscarEquipo.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.txtBuscarEquipo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscarEquipo.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtBuscarEquipo.ForeColor = System.Drawing.Color.FromArgb(240, 244, 252);
            this.txtBuscarEquipo.Location = new System.Drawing.Point(32, 4);
            this.txtBuscarEquipo.MaxLength = 80;
            this.txtBuscarEquipo.Name = "txtBuscarEquipo";
            this.txtBuscarEquipo.Size = new System.Drawing.Size(248, 19);
            this.txtBuscarEquipo.TabIndex = 0;
            this.txtBuscarEquipo.TextChanged += new System.EventHandler(this.txtBuscarEquipo_TextChanged);
            this.txtBuscarEquipo.Enter += new System.EventHandler(this.txtBuscar_FocoCambiado);
            this.txtBuscarEquipo.Leave += new System.EventHandler(this.txtBuscar_FocoCambiado);
            // 
            // pnlLupaEquipo
            // 
            this.pnlLupaEquipo.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.pnlLupaEquipo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLupaEquipo.Name = "pnlLupaEquipo";
            this.pnlLupaEquipo.Size = new System.Drawing.Size(28, 26);
            this.pnlLupaEquipo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlLupa_Paint);
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCategoria.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cmbCategoria.ForeColor = System.Drawing.Color.FromArgb(240, 244, 252);
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(314, 14);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(190, 27);
            this.cmbCategoria.TabIndex = 1;
            this.cmbCategoria.SelectedIndexChanged += new System.EventHandler(this.cmbCategoria_SelectedIndexChanged);
            // 
            // chkSoloProblemas
            // 
            this.chkSoloProblemas.AutoSize = true;
            this.chkSoloProblemas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkSoloProblemas.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkSoloProblemas.ForeColor = System.Drawing.Color.FromArgb(170, 180, 200);
            this.chkSoloProblemas.Location = new System.Drawing.Point(516, 17);
            this.chkSoloProblemas.Name = "chkSoloProblemas";
            this.chkSoloProblemas.TabIndex = 2;
            this.chkSoloProblemas.Text = "Solo con problemas";
            this.chkSoloProblemas.UseVisualStyleBackColor = true;
            this.chkSoloProblemas.CheckedChanged += new System.EventHandler(this.chkSoloProblemas_CheckedChanged);
            // 
            // btnAsignar
            // 
            this.btnAsignar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAsignar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAsignar.Location = new System.Drawing.Point(16, 60);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(170, 38);
            this.btnAsignar.TabIndex = 3;
            this.btnAsignar.Text = "+ Asignar equipo";
            this.btnAsignar.Tipo = Vistass.TipoBoton.Principal;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // btnMover
            // 
            this.btnMover.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMover.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMover.Location = new System.Drawing.Point(194, 60);
            this.btnMover.Name = "btnMover";
            this.btnMover.Size = new System.Drawing.Size(100, 38);
            this.btnMover.TabIndex = 4;
            this.btnMover.Text = "Mover";
            this.btnMover.Tipo = Vistass.TipoBoton.Secundario;
            this.btnMover.Click += new System.EventHandler(this.btnMover_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnQuitar.Location = new System.Drawing.Point(302, 60);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(100, 38);
            this.btnQuitar.TabIndex = 5;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.Tipo = Vistass.TipoBoton.Peligro;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnExportarPdf
            // 
            this.btnExportarPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportarPdf.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportarPdf.Location = new System.Drawing.Point(410, 60);
            this.btnExportarPdf.Name = "btnExportarPdf";
            this.btnExportarPdf.Size = new System.Drawing.Size(130, 38);
            this.btnExportarPdf.TabIndex = 6;
            this.btnExportarPdf.Text = "Exportar";
            this.btnExportarPdf.Tipo = Vistass.TipoBoton.Secundario;
            this.btnExportarPdf.Click += new System.EventHandler(this.btnExportarPdf_Click);
            // 
            // lblSeleccionInv  (contador de unidades marcadas)
            // 
            this.lblSeleccionInv.AutoSize = true;
            this.lblSeleccionInv.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSeleccionInv.ForeColor = System.Drawing.Color.FromArgb(252, 211, 77);
            this.lblSeleccionInv.Location = new System.Drawing.Point(556, 70);
            this.lblSeleccionInv.Name = "lblSeleccionInv";
            this.lblSeleccionInv.Text = "";
            // 
            // pnlEspacio  (separación entre la ficha y la barra del equipo)
            // 
            this.pnlEspacio.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.pnlEspacio.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEspacio.Name = "pnlEspacio";
            this.pnlEspacio.Size = new System.Drawing.Size(700, 12);
            this.pnlEspacio.TabIndex = 3;
            // 
            // pnlSalonInfo  (ficha del salón: nombre, acciones y etiquetas)
            // 
            this.pnlSalonInfo.BackColor = System.Drawing.Color.FromArgb(27, 29, 38);
            this.pnlSalonInfo.Controls.Add(this.flpChips);
            this.pnlSalonInfo.Controls.Add(this.pnlFilaNombre);
            this.pnlSalonInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSalonInfo.Name = "pnlSalonInfo";
            this.pnlSalonInfo.Size = new System.Drawing.Size(700, 136);
            this.pnlSalonInfo.TabIndex = 2;
            // 
            // flpChips
            // 
            this.flpChips.BackColor = System.Drawing.Color.FromArgb(27, 29, 38);
            this.flpChips.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpChips.Name = "flpChips";
            this.flpChips.Padding = new System.Windows.Forms.Padding(16, 2, 16, 6);
            this.flpChips.TabIndex = 1;
            // 
            // pnlFilaNombre
            // 
            this.pnlFilaNombre.BackColor = System.Drawing.Color.FromArgb(27, 29, 38);
            this.pnlFilaNombre.Controls.Add(this.lblNombreSalon);
            this.pnlFilaNombre.Controls.Add(this.pnlAccionesSalon);
            this.pnlFilaNombre.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilaNombre.Name = "pnlFilaNombre";
            this.pnlFilaNombre.Size = new System.Drawing.Size(700, 58);
            this.pnlFilaNombre.TabIndex = 0;
            // 
            // lblNombreSalon
            // 
            this.lblNombreSalon.AutoSize = true;
            this.lblNombreSalon.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblNombreSalon.ForeColor = System.Drawing.Color.FromArgb(240, 244, 252);
            this.lblNombreSalon.Location = new System.Drawing.Point(18, 10);
            this.lblNombreSalon.Name = "lblNombreSalon";
            this.lblNombreSalon.Text = "Sin salón seleccionado";
            // 
            // pnlAccionesSalon  (botones de la ficha, pegados a la derecha)
            // 
            this.pnlAccionesSalon.BackColor = System.Drawing.Color.FromArgb(27, 29, 38);
            this.pnlAccionesSalon.Controls.Add(this.btnEditarSalon);
            this.pnlAccionesSalon.Controls.Add(this.btnEstadoSalon);
            this.pnlAccionesSalon.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlAccionesSalon.Name = "pnlAccionesSalon";
            this.pnlAccionesSalon.Size = new System.Drawing.Size(300, 58);
            // 
            // btnEditarSalon
            // 
            this.btnEditarSalon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarSalon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditarSalon.Location = new System.Drawing.Point(0, 11);
            this.btnEditarSalon.Name = "btnEditarSalon";
            this.btnEditarSalon.Size = new System.Drawing.Size(120, 38);
            this.btnEditarSalon.TabIndex = 3;
            this.btnEditarSalon.Text = "Editar salón";
            this.btnEditarSalon.Tipo = Vistass.TipoBoton.Secundario;
            this.btnEditarSalon.Click += new System.EventHandler(this.btnEditarSalon_Click);
            // 
            // btnEstadoSalon
            // 
            this.btnEstadoSalon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEstadoSalon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEstadoSalon.Location = new System.Drawing.Point(128, 11);
            this.btnEstadoSalon.Name = "btnEstadoSalon";
            this.btnEstadoSalon.Size = new System.Drawing.Size(156, 38);
            this.btnEstadoSalon.TabIndex = 4;
            this.btnEstadoSalon.Text = "Desactivar salón";
            this.btnEstadoSalon.Tipo = Vistass.TipoBoton.Peligro;
            this.btnEstadoSalon.Click += new System.EventHandler(this.btnEstadoSalon_Click);
            // 
            // pnlLista  (zona izquierda: lista de salones)
            // 
            this.pnlLista.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.pnlLista.Controls.Add(this.pnlTablaLista);
            this.pnlLista.Controls.Add(this.pnlBarraLista);
            this.pnlLista.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLista.Name = "pnlLista";
            this.pnlLista.Padding = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.pnlLista.Size = new System.Drawing.Size(460, 660);
            this.pnlLista.TabIndex = 1;
            // 
            // pnlTablaLista
            // 
            this.pnlTablaLista.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.pnlTablaLista.Controls.Add(this.dgvSalones);
            this.pnlTablaLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTablaLista.Name = "pnlTablaLista";
            this.pnlTablaLista.Padding = new System.Windows.Forms.Padding(0, 16, 0, 0);
            this.pnlTablaLista.TabIndex = 0;
            // 
            // dgvSalones
            // 
            this.dgvSalones.ColumnHeadersHeight = 40;
            this.dgvSalones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSalones.Name = "dgvSalones";
            this.dgvSalones.RowHeadersWidth = 51;
            this.dgvSalones.RowTemplate.Height = 36;
            this.dgvSalones.TabIndex = 0;
            this.dgvSalones.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalones_CellDoubleClick);
            this.dgvSalones.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvSalones_CellFormatting);
            this.dgvSalones.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvSalones_CellPainting);
            this.dgvSalones.SelectionChanged += new System.EventHandler(this.dgvSalones_SelectionChanged);
            // 
            // pnlBarraLista  (buscador, tipo y salones inactivos)
            // 
            this.pnlBarraLista.BackColor = System.Drawing.Color.FromArgb(27, 29, 38);
            this.pnlBarraLista.Controls.Add(this.pnlBuscadorSalon);
            this.pnlBarraLista.Controls.Add(this.btnNuevoSalon);
            this.pnlBarraLista.Controls.Add(this.cmbTipoSalon);
            this.pnlBarraLista.Controls.Add(this.chkInactivos);
            this.pnlBarraLista.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarraLista.Name = "pnlBarraLista";
            this.pnlBarraLista.Size = new System.Drawing.Size(448, 108);
            this.pnlBarraLista.TabIndex = 1;
            // 
            // pnlBuscadorSalon
            // 
            this.pnlBuscadorSalon.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.pnlBuscadorSalon.Controls.Add(this.lblHintSalon);
            this.pnlBuscadorSalon.Controls.Add(this.txtBuscarSalon);
            this.pnlBuscadorSalon.Controls.Add(this.pnlLupaSalon);
            this.pnlBuscadorSalon.Location = new System.Drawing.Point(16, 16);
            this.pnlBuscadorSalon.Name = "pnlBuscadorSalon";
            this.pnlBuscadorSalon.Padding = new System.Windows.Forms.Padding(1);
            this.pnlBuscadorSalon.Size = new System.Drawing.Size(250, 28);
            this.pnlBuscadorSalon.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBuscadorSalon_Paint);
            // 
            // lblHintSalon
            // 
            this.lblHintSalon.AutoSize = true;
            this.lblHintSalon.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.lblHintSalon.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblHintSalon.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblHintSalon.ForeColor = System.Drawing.Color.FromArgb(140, 150, 176);
            this.lblHintSalon.Location = new System.Drawing.Point(33, 4);
            this.lblHintSalon.Name = "lblHintSalon";
            this.lblHintSalon.Text = "Buscar salón o responsable...";
            this.lblHintSalon.Click += new System.EventHandler(this.lblHintSalon_Click);
            // 
            // txtBuscarSalon
            // 
            this.txtBuscarSalon.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.txtBuscarSalon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscarSalon.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtBuscarSalon.ForeColor = System.Drawing.Color.FromArgb(240, 244, 252);
            this.txtBuscarSalon.Location = new System.Drawing.Point(32, 4);
            this.txtBuscarSalon.MaxLength = 50;
            this.txtBuscarSalon.Name = "txtBuscarSalon";
            this.txtBuscarSalon.Size = new System.Drawing.Size(208, 19);
            this.txtBuscarSalon.TabIndex = 0;
            this.txtBuscarSalon.TextChanged += new System.EventHandler(this.txtBuscarSalon_TextChanged);
            this.txtBuscarSalon.Enter += new System.EventHandler(this.txtBuscar_FocoCambiado);
            this.txtBuscarSalon.Leave += new System.EventHandler(this.txtBuscar_FocoCambiado);
            // 
            // pnlLupaSalon
            // 
            this.pnlLupaSalon.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.pnlLupaSalon.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLupaSalon.Name = "pnlLupaSalon";
            this.pnlLupaSalon.Size = new System.Drawing.Size(28, 26);
            this.pnlLupaSalon.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlLupa_Paint);
            // 
            // btnNuevoSalon
            // 
            this.btnNuevoSalon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoSalon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNuevoSalon.Location = new System.Drawing.Point(276, 11);
            this.btnNuevoSalon.Name = "btnNuevoSalon";
            this.btnNuevoSalon.Size = new System.Drawing.Size(156, 38);
            this.btnNuevoSalon.TabIndex = 1;
            this.btnNuevoSalon.Text = "+ Nuevo salón";
            this.btnNuevoSalon.Tipo = Vistass.TipoBoton.Principal;
            this.btnNuevoSalon.Click += new System.EventHandler(this.btnNuevoSalon_Click);
            // 
            // cmbTipoSalon
            // 
            this.cmbTipoSalon.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.cmbTipoSalon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoSalon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTipoSalon.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cmbTipoSalon.ForeColor = System.Drawing.Color.FromArgb(240, 244, 252);
            this.cmbTipoSalon.FormattingEnabled = true;
            this.cmbTipoSalon.Location = new System.Drawing.Point(16, 62);
            this.cmbTipoSalon.Name = "cmbTipoSalon";
            this.cmbTipoSalon.Size = new System.Drawing.Size(200, 27);
            this.cmbTipoSalon.TabIndex = 2;
            this.cmbTipoSalon.SelectedIndexChanged += new System.EventHandler(this.cmbTipoSalon_SelectedIndexChanged);
            // 
            // chkInactivos
            // 
            this.chkInactivos.AutoSize = true;
            this.chkInactivos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkInactivos.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkInactivos.ForeColor = System.Drawing.Color.FromArgb(170, 180, 200);
            this.chkInactivos.Location = new System.Drawing.Point(228, 65);
            this.chkInactivos.Name = "chkInactivos";
            this.chkInactivos.TabIndex = 3;
            this.chkInactivos.Text = "Mostrar inactivos";
            this.chkInactivos.UseVisualStyleBackColor = true;
            this.chkInactivos.CheckedChanged += new System.EventHandler(this.chkInactivos_CheckedChanged);
            // 
            // frmSalones
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.ClientSize = new System.Drawing.Size(1248, 760);
            this.Controls.Add(this.pnlCuerpo);
            this.Controls.Add(this.pnlEncabezado);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "frmSalones";
            this.Padding = new System.Windows.Forms.Padding(24, 0, 24, 16);
            this.Text = "Gestión de salones";
            this.Load += new System.EventHandler(this.frmSalones_Load);
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.flpResumen.ResumeLayout(false);
            this.pnlCuerpo.ResumeLayout(false);
            this.pnlDetalle.ResumeLayout(false);
            this.pnlTablaInv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            this.pnlBarraInv.ResumeLayout(false);
            this.pnlBarraInv.PerformLayout();
            this.pnlBuscadorEquipo.ResumeLayout(false);
            this.pnlBuscadorEquipo.PerformLayout();
            this.pnlSalonInfo.ResumeLayout(false);
            this.pnlFilaNombre.ResumeLayout(false);
            this.pnlFilaNombre.PerformLayout();
            this.pnlAccionesSalon.ResumeLayout(false);
            this.pnlLista.ResumeLayout(false);
            this.pnlTablaLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalones)).EndInit();
            this.pnlBarraLista.ResumeLayout(false);
            this.pnlBarraLista.PerformLayout();
            this.pnlBuscadorSalon.ResumeLayout(false);
            this.pnlBuscadorSalon.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label lblTituloSalones;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.FlowLayoutPanel flpResumen;
        private System.Windows.Forms.Panel pnlCuerpo;
        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.Label lblVacio;
        private System.Windows.Forms.Panel pnlTablaInv;
        private Vistass.GridOscuro dgvInventario;
        private Vistass.PanelTarjeta pnlBarraInv;
        private System.Windows.Forms.Panel pnlBuscadorEquipo;
        private System.Windows.Forms.Label lblHintEquipo;
        private System.Windows.Forms.TextBox txtBuscarEquipo;
        private System.Windows.Forms.Panel pnlLupaEquipo;
        private Vistass.ComboOscuro cmbCategoria;
        private System.Windows.Forms.CheckBox chkSoloProblemas;
        private Vistass.BotonTema btnAsignar;
        private Vistass.BotonTema btnMover;
        private Vistass.BotonTema btnQuitar;
        private Vistass.BotonTema btnExportarPdf;
        private System.Windows.Forms.Label lblSeleccionInv;
        private System.Windows.Forms.Panel pnlEspacio;
        private Vistass.PanelTarjeta pnlSalonInfo;
        private System.Windows.Forms.FlowLayoutPanel flpChips;
        private System.Windows.Forms.Panel pnlFilaNombre;
        private System.Windows.Forms.Label lblNombreSalon;
        private System.Windows.Forms.Panel pnlAccionesSalon;
        private Vistass.BotonTema btnEditarSalon;
        private Vistass.BotonTema btnEstadoSalon;
        private System.Windows.Forms.Panel pnlLista;
        private System.Windows.Forms.Panel pnlTablaLista;
        private Vistass.GridOscuro dgvSalones;
        private Vistass.PanelTarjeta pnlBarraLista;
        private System.Windows.Forms.Panel pnlBuscadorSalon;
        private System.Windows.Forms.Label lblHintSalon;
        private System.Windows.Forms.TextBox txtBuscarSalon;
        private System.Windows.Forms.Panel pnlLupaSalon;
        private Vistass.BotonTema btnNuevoSalon;
        private Vistass.ComboOscuro cmbTipoSalon;
        private System.Windows.Forms.CheckBox chkInactivos;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}