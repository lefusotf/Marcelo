namespace Vistass
{
    partial class frmUsuarios
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
            System.Windows.Forms.DataGridViewCellStyle estCabecera = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle estCelda = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlBusqueda = new System.Windows.Forms.Panel();
            this.chkInactivos = new System.Windows.Forms.CheckBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.pnlPie = new System.Windows.Forms.Panel();
            this.lblResumen = new System.Windows.Forms.Label();
            this.dgvUsuarios = new Vistass.GridOscuro();
            this.pnlAcciones = new System.Windows.Forms.Panel();
            this.lblPanelTitulo = new System.Windows.Forms.Label();
            this.lblSelNombre = new System.Windows.Forms.Label();
            this.lblSelUsuario = new System.Windows.Forms.Label();
            this.lblSelCorreo = new System.Windows.Forms.Label();
            this.lblSelEstado = new System.Windows.Forms.Label();
            this.lblSelUltimo = new System.Windows.Forms.Label();
            this.lblSelCreado = new System.Windows.Forms.Label();
            this.btnNuevo = new Vistass.BotonTema();
            this.btnEditar = new Vistass.BotonTema();
            this.btnCambiarEstado = new Vistass.BotonTema();
            this.btnRestablecer = new Vistass.BotonTema();
            this.btnMiClave = new Vistass.BotonTema();
            this.pnlEncabezado.SuspendLayout();
            this.pnlBusqueda.SuspendLayout();
            this.pnlPie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.pnlAcciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.BackColor = System.Drawing.Color. FromArgb(18, 18, 18);
            this.pnlEncabezado.Controls.Add(this.lblSubtitulo);
            this.pnlEncabezado.Controls.Add(this.lblTitulo);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Location = new System.Drawing.Point(0, 0);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(1000, 84);
            this.pnlEncabezado.TabIndex = 4;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color. FromArgb(240, 244, 252);
            this.lblTitulo.Location = new System.Drawing.Point(22, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(116, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Usuarios";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitulo.ForeColor = System.Drawing.Color. FromArgb(170, 180, 200);
            this.lblSubtitulo.Location = new System.Drawing.Point(26, 52);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(398, 19);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Administradores con acceso al sistema. Cada uno entra con su propia cuenta.";
            // 
            // pnlBusqueda
            // 
            this.pnlBusqueda.BackColor = System.Drawing.Color. FromArgb(18, 18, 18);
            this.pnlBusqueda.Controls.Add(this.chkInactivos);
            this.pnlBusqueda.Controls.Add(this.txtBuscar);
            this.pnlBusqueda.Controls.Add(this.lblBuscar);
            this.pnlBusqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBusqueda.Location = new System.Drawing.Point(0, 84);
            this.pnlBusqueda.Name = "pnlBusqueda";
            this.pnlBusqueda.Size = new System.Drawing.Size(720, 56);
            this.pnlBusqueda.TabIndex = 2;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.ForeColor = System.Drawing.Color. FromArgb(170, 180, 200);
            this.lblBuscar.Location = new System.Drawing.Point(24, 19);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(48, 19);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(82, 15);
            this.txtBuscar.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.ForeColor = System.Drawing.Color.FromArgb(240, 244, 252);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(280, 26);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // chkInactivos
            // 
            this.chkInactivos.AutoSize = true;
            this.chkInactivos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkInactivos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInactivos.ForeColor = System.Drawing.Color. FromArgb(170, 180, 200);
            this.chkInactivos.Location = new System.Drawing.Point(382, 17);
            this.chkInactivos.Name = "chkInactivos";
            this.chkInactivos.Size = new System.Drawing.Size(139, 23);
            this.chkInactivos.TabIndex = 2;
            this.chkInactivos.Text = "Mostrar inactivos";
            this.chkInactivos.UseVisualStyleBackColor = true;
            this.chkInactivos.CheckedChanged += new System.EventHandler(this.chkInactivos_CheckedChanged);
            // 
            // pnlPie
            // 
            this.pnlPie.BackColor = System.Drawing.Color. FromArgb(18, 18, 18);
            this.pnlPie.Controls.Add(this.lblResumen);
            this.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPie.Location = new System.Drawing.Point(0, 604);
            this.pnlPie.Name = "pnlPie";
            this.pnlPie.Size = new System.Drawing.Size(720, 36);
            this.pnlPie.TabIndex = 1;
            // 
            // lblResumen
            // 
            this.lblResumen.AutoSize = true;
            this.lblResumen.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResumen.ForeColor = System.Drawing.Color. FromArgb(170, 180, 200);
            this.lblResumen.Location = new System.Drawing.Point(24, 9);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Size = new System.Drawing.Size(16, 17);
            this.lblResumen.TabIndex = 0;
            this.lblResumen.Text = "...";
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.AllowUserToResizeRows = false;
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.BackgroundColor = System.Drawing.Color. FromArgb(18, 18, 18);
            this.dgvUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsuarios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUsuarios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            estCabecera.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            estCabecera.BackColor = System.Drawing.Color. FromArgb(27, 29, 38);
            estCabecera.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            estCabecera.ForeColor = System.Drawing.Color. FromArgb(170, 180, 200);
            estCabecera.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            estCabecera.SelectionBackColor = System.Drawing.Color. FromArgb(27, 29, 38);
            estCabecera.SelectionForeColor = System.Drawing.Color. FromArgb(170, 180, 200);
            this.dgvUsuarios.ColumnHeadersDefaultCellStyle = estCabecera;
            this.dgvUsuarios.ColumnHeadersHeight = 38;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            estCelda.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            estCelda.BackColor = System.Drawing.Color. FromArgb(18, 18, 18);
            estCelda.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            estCelda.ForeColor = System.Drawing.Color. FromArgb(240, 244, 252);
            estCelda.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            estCelda.SelectionBackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            estCelda.SelectionForeColor = System.Drawing.Color. FromArgb(240, 244, 252);
            this.dgvUsuarios.DefaultCellStyle = estCelda;
            this.dgvUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsuarios.EnableHeadersVisualStyles = false;
            this.dgvUsuarios.GridColor = System.Drawing.Color.FromArgb(45, 49, 66);
            this.dgvUsuarios.Location = new System.Drawing.Point(0, 140);
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.RowHeadersVisible = false;
            this.dgvUsuarios.RowTemplate.Height = 36;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(720, 464);
            this.dgvUsuarios.TabIndex = 0;
            this.dgvUsuarios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellDoubleClick);
            this.dgvUsuarios.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvUsuarios_CellFormatting);
            this.dgvUsuarios.SelectionChanged += new System.EventHandler(this.dgvUsuarios_SelectionChanged);
            // 
            // pnlAcciones
            // 
            this.pnlAcciones.AutoScroll = true;
            this.pnlAcciones.BackColor = System.Drawing.Color. FromArgb(27, 29, 38);
            this.pnlAcciones.Controls.Add(this.lblPanelTitulo);
            this.pnlAcciones.Controls.Add(this.lblSelNombre);
            this.pnlAcciones.Controls.Add(this.lblSelUsuario);
            this.pnlAcciones.Controls.Add(this.lblSelCorreo);
            this.pnlAcciones.Controls.Add(this.lblSelEstado);
            this.pnlAcciones.Controls.Add(this.lblSelUltimo);
            this.pnlAcciones.Controls.Add(this.lblSelCreado);
            this.pnlAcciones.Controls.Add(this.btnNuevo);
            this.pnlAcciones.Controls.Add(this.btnEditar);
            this.pnlAcciones.Controls.Add(this.btnCambiarEstado);
            this.pnlAcciones.Controls.Add(this.btnRestablecer);
            this.pnlAcciones.Controls.Add(this.btnMiClave);
            this.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlAcciones.Location = new System.Drawing.Point(720, 84);
            this.pnlAcciones.Name = "pnlAcciones";
            this.pnlAcciones.Size = new System.Drawing.Size(280, 556);
            this.pnlAcciones.TabIndex = 3;
            // 
            // lblPanelTitulo
            // 
            this.lblPanelTitulo.AutoSize = true;
            this.lblPanelTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPanelTitulo.ForeColor = System.Drawing.Color.FromArgb(100, 108, 130);
            this.lblPanelTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblPanelTitulo.Name = "lblPanelTitulo";
            this.lblPanelTitulo.Size = new System.Drawing.Size(137, 15);
            this.lblPanelTitulo.TabIndex = 0;
            this.lblPanelTitulo.Text = "USUARIO SELECCIONADO";
            // 
            // lblSelNombre
            // 
            this.lblSelNombre.AutoEllipsis = true;
            this.lblSelNombre.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelNombre.ForeColor = System.Drawing.Color. FromArgb(240, 244, 252);
            this.lblSelNombre.Location = new System.Drawing.Point(20, 44);
            this.lblSelNombre.Name = "lblSelNombre";
            this.lblSelNombre.Size = new System.Drawing.Size(240, 28);
            this.lblSelNombre.TabIndex = 1;
            this.lblSelNombre.Text = "—";
            // 
            // lblSelUsuario
            // 
            this.lblSelUsuario.AutoEllipsis = true;
            this.lblSelUsuario.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelUsuario.ForeColor = System.Drawing.Color. FromArgb(170, 180, 200);
            this.lblSelUsuario.Location = new System.Drawing.Point(20, 74);
            this.lblSelUsuario.Name = "lblSelUsuario";
            this.lblSelUsuario.Size = new System.Drawing.Size(240, 20);
            this.lblSelUsuario.TabIndex = 2;
            // 
            // lblSelCorreo
            // 
            this.lblSelCorreo.AutoEllipsis = true;
            this.lblSelCorreo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelCorreo.ForeColor = System.Drawing.Color. FromArgb(170, 180, 200);
            this.lblSelCorreo.Location = new System.Drawing.Point(20, 98);
            this.lblSelCorreo.Name = "lblSelCorreo";
            this.lblSelCorreo.Size = new System.Drawing.Size(240, 20);
            this.lblSelCorreo.TabIndex = 3;
            // 
            // lblSelEstado
            // 
            this.lblSelEstado.AutoEllipsis = true;
            this.lblSelEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelEstado.ForeColor = System.Drawing.Color.FromArgb(74, 222, 128);
            this.lblSelEstado.Location = new System.Drawing.Point(20, 122);
            this.lblSelEstado.Name = "lblSelEstado";
            this.lblSelEstado.Size = new System.Drawing.Size(240, 20);
            this.lblSelEstado.TabIndex = 4;
            // 
            // lblSelUltimo
            // 
            this.lblSelUltimo.AutoEllipsis = true;
            this.lblSelUltimo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelUltimo.ForeColor = System.Drawing.Color. FromArgb(170, 180, 200);
            this.lblSelUltimo.Location = new System.Drawing.Point(20, 146);
            this.lblSelUltimo.Name = "lblSelUltimo";
            this.lblSelUltimo.Size = new System.Drawing.Size(240, 20);
            this.lblSelUltimo.TabIndex = 5;
            // 
            // lblSelCreado
            // 
            this.lblSelCreado.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelCreado.ForeColor = System.Drawing.Color. FromArgb(170, 180, 200);
            this.lblSelCreado.Location = new System.Drawing.Point(20, 170);
            this.lblSelCreado.Name = "lblSelCreado";
            this.lblSelCreado.Size = new System.Drawing.Size(240, 40);
            this.lblSelCreado.TabIndex = 6;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Location = new System.Drawing.Point(20, 230);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(240, 40);
            this.btnNuevo.TabIndex = 7;
            this.btnNuevo.Text = "Nuevo administrador";
            this.btnNuevo.Tipo = Vistass.TipoBoton.Principal;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Location = new System.Drawing.Point(20, 280);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(240, 40);
            this.btnEditar.TabIndex = 8;
            this.btnEditar.Text = "Editar datos";
            this.btnEditar.Tipo = Vistass.TipoBoton.Secundario;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnCambiarEstado
            // 
            this.btnCambiarEstado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCambiarEstado.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiarEstado.Location = new System.Drawing.Point(20, 330);
            this.btnCambiarEstado.Name = "btnCambiarEstado";
            this.btnCambiarEstado.Size = new System.Drawing.Size(240, 40);
            this.btnCambiarEstado.TabIndex = 9;
            this.btnCambiarEstado.Text = "Desactivar usuario";
            this.btnCambiarEstado.Tipo = Vistass.TipoBoton.Peligro;
            this.btnCambiarEstado.Click += new System.EventHandler(this.btnCambiarEstado_Click);
            // 
            // btnRestablecer
            // 
            this.btnRestablecer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestablecer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestablecer.Location = new System.Drawing.Point(20, 380);
            this.btnRestablecer.Name = "btnRestablecer";
            this.btnRestablecer.Size = new System.Drawing.Size(240, 40);
            this.btnRestablecer.TabIndex = 10;
            this.btnRestablecer.Text = "Restablecer contraseña";
            this.btnRestablecer.Tipo = Vistass.TipoBoton.Secundario;
            this.btnRestablecer.Click += new System.EventHandler(this.btnRestablecer_Click);
            // 
            // btnMiClave
            // 
            this.btnMiClave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMiClave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMiClave.Location = new System.Drawing.Point(20, 450);
            this.btnMiClave.Name = "btnMiClave";
            this.btnMiClave.Size = new System.Drawing.Size(240, 40);
            this.btnMiClave.TabIndex = 11;
            this.btnMiClave.Text = "Cambiar mi contraseña";
            this.btnMiClave.Tipo = Vistass.TipoBoton.Secundario;
            this.btnMiClave.Click += new System.EventHandler(this.btnMiClave_Click);
            // 
            // frmUsuarios
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color. FromArgb(18, 18, 18);
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.pnlPie);
            this.Controls.Add(this.pnlBusqueda);
            this.Controls.Add(this.pnlAcciones);
            this.Controls.Add(this.pnlEncabezado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmUsuarios";
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.frmUsuarios_Load);
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.pnlBusqueda.ResumeLayout(false);
            this.pnlBusqueda.PerformLayout();
            this.pnlPie.ResumeLayout(false);
            this.pnlPie.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.pnlAcciones.ResumeLayout(false);
            this.pnlAcciones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel pnlBusqueda;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.CheckBox chkInactivos;
        private System.Windows.Forms.Panel pnlPie;
        private System.Windows.Forms.Label lblResumen;
        private Vistass.GridOscuro dgvUsuarios;
        private System.Windows.Forms.Panel pnlAcciones;
        private System.Windows.Forms.Label lblPanelTitulo;
        private System.Windows.Forms.Label lblSelNombre;
        private System.Windows.Forms.Label lblSelUsuario;
        private System.Windows.Forms.Label lblSelCorreo;
        private System.Windows.Forms.Label lblSelEstado;
        private System.Windows.Forms.Label lblSelUltimo;
        private System.Windows.Forms.Label lblSelCreado;
        private Vistass.BotonTema btnNuevo;
        private Vistass.BotonTema btnEditar;
        private Vistass.BotonTema btnCambiarEstado;
        private Vistass.BotonTema btnRestablecer;
        private Vistass.BotonTema btnMiClave;
    }
}