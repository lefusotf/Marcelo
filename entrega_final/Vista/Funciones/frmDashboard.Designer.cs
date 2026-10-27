namespace pagina_principal
{
    partial class frmDashboard
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDashboard));
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlNavegacion = new System.Windows.Forms.Panel();
            this.lblGrpPrincipal = new System.Windows.Forms.Label();
            this.itmInicio = new pagina_principal.ItemMenuLateral();
            this.lblGrpGestion = new System.Windows.Forms.Label();
            this.itmActivos = new pagina_principal.ItemMenuLateral();
            this.itmPersonal = new pagina_principal.ItemMenuLateral();
            this.itmPlanillas = new pagina_principal.ItemMenuLateral();
            this.itmSalones = new pagina_principal.ItemMenuLateral();
            this.lblGrpOperacion = new System.Windows.Forms.Label();
            this.itmCatalogo = new pagina_principal.ItemMenuLateral();
            this.itmReportar = new pagina_principal.ItemMenuLateral();
            this.lblGrpSistema = new System.Windows.Forms.Label();
            this.itmUsuarios = new pagina_principal.ItemMenuLateral();
            this.itmActividad = new pagina_principal.ItemMenuLateral();
            this.itmAyuda = new pagina_principal.ItemMenuLateral();
            this.pnlUsuario = new System.Windows.Forms.Panel();
            this.lblUsuarioNombre = new System.Windows.Forms.Label();
            this.lblUsuarioRol = new System.Windows.Forms.Label();
            this.itmCerrarSesion = new pagina_principal.ItemMenuLateral();
            this.pnlMarca = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.lblInstitucion = new System.Windows.Forms.Label();
            this.lblSistema = new System.Windows.Forms.Label();
            this.itmPlegar = new pagina_principal.ItemMenuLateral();
            this.pnlLineaMenu = new System.Windows.Forms.Panel();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlMenu.SuspendLayout();
            this.pnlNavegacion.SuspendLayout();
            this.pnlUsuario.SuspendLayout();
            this.pnlMarca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color. FromArgb(27, 29, 38);
            this.pnlMenu.Controls.Add(this.pnlNavegacion);
            this.pnlMenu.Controls.Add(this.pnlUsuario);
            this.pnlMenu.Controls.Add(this.pnlMarca);
            this.pnlMenu.Controls.Add(this.pnlLineaMenu);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(281, 1055);
            this.pnlMenu.TabIndex = 0;
            // 
            // pnlNavegacion
            // 
            this.pnlNavegacion.AutoScroll = false;
            this.pnlNavegacion.BackColor = System.Drawing.Color. FromArgb(27, 29, 38);
            this.pnlNavegacion.Controls.Add(this.lblGrpPrincipal);
            this.pnlNavegacion.Controls.Add(this.itmInicio);
            this.pnlNavegacion.Controls.Add(this.lblGrpGestion);
            this.pnlNavegacion.Controls.Add(this.itmActivos);
            this.pnlNavegacion.Controls.Add(this.itmPersonal);
            this.pnlNavegacion.Controls.Add(this.itmPlanillas);
            this.pnlNavegacion.Controls.Add(this.itmSalones);
            this.pnlNavegacion.Controls.Add(this.lblGrpOperacion);
            this.pnlNavegacion.Controls.Add(this.itmCatalogo);
            this.pnlNavegacion.Controls.Add(this.itmReportar);
            this.pnlNavegacion.Controls.Add(this.lblGrpSistema);
            this.pnlNavegacion.Controls.Add(this.itmActividad);
            this.pnlNavegacion.Controls.Add(this.itmUsuarios);
            this.pnlNavegacion.Controls.Add(this.itmAyuda);
            this.pnlNavegacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNavegacion.Location = new System.Drawing.Point(0, 100);
            this.pnlNavegacion.Name = "pnlNavegacion";
            this.pnlNavegacion.Size = new System.Drawing.Size(280, 823);
            this.pnlNavegacion.TabIndex = 0;
            this.pnlNavegacion.Resize += new System.EventHandler(this.pnlNavegacion_Resize);
            this.pnlNavegacion.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlNavegacion_Paint);
            // 
            // lblGrpPrincipal
            // 
            this.lblGrpPrincipal.AutoSize = true;
            this.lblGrpPrincipal.BackColor = System.Drawing.Color.Transparent;
            this.lblGrpPrincipal.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.lblGrpPrincipal.ForeColor = System.Drawing.Color.FromArgb(100, 108, 130);
            this.lblGrpPrincipal.Location = new System.Drawing.Point(22, 12);
            this.lblGrpPrincipal.Name = "lblGrpPrincipal";
            this.lblGrpPrincipal.Size = new System.Drawing.Size(71, 15);
            this.lblGrpPrincipal.TabIndex = 0;
            this.lblGrpPrincipal.Text = "PRINCIPAL";
            // 
            // itmInicio
            // 
            this.itmInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.itmInicio.Icono = "inicio";
            this.itmInicio.Location = new System.Drawing.Point(0, 34);
            this.itmInicio.Name = "itmInicio";
            this.itmInicio.Size = new System.Drawing.Size(279, 44);
            this.itmInicio.TabIndex = 1;
            this.itmInicio.Texto = "Inicio";
            this.itmInicio.Click += new System.EventHandler(this.itmInicio_Click);
            // 
            // lblGrpGestion
            // 
            this.lblGrpGestion.AutoSize = true;
            this.lblGrpGestion.BackColor = System.Drawing.Color.Transparent;
            this.lblGrpGestion.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.lblGrpGestion.ForeColor = System.Drawing.Color.FromArgb(100, 108, 130);
            this.lblGrpGestion.Location = new System.Drawing.Point(22, 98);
            this.lblGrpGestion.Name = "lblGrpGestion";
            this.lblGrpGestion.Size = new System.Drawing.Size(59, 15);
            this.lblGrpGestion.TabIndex = 2;
            this.lblGrpGestion.Text = "GESTIÓN";
            // 
            // itmActivos
            // 
            this.itmActivos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.itmActivos.Icono = "activos";
            this.itmActivos.Location = new System.Drawing.Point(0, 120);
            this.itmActivos.Name = "itmActivos";
            this.itmActivos.Size = new System.Drawing.Size(279, 44);
            this.itmActivos.TabIndex = 3;
            this.itmActivos.Texto = "Gestión de activos";
            this.itmActivos.Click += new System.EventHandler(this.itmActivos_Click);
            // 
            // itmPersonal
            // 
            this.itmPersonal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.itmPersonal.Icono = "personal";
            this.itmPersonal.Location = new System.Drawing.Point(0, 164);
            this.itmPersonal.Name = "itmPersonal";
            this.itmPersonal.Size = new System.Drawing.Size(279, 44);
            this.itmPersonal.TabIndex = 4;
            this.itmPersonal.Texto = "Gestión de personal";
            this.itmPersonal.Click += new System.EventHandler(this.itmPersonal_Click);
            // 
            // itmPlanillas
            // 
            this.itmPlanillas.ColorInsignia = System.Drawing.Color.FromArgb(251, 191, 36);
            this.itmPlanillas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.itmPlanillas.Icono = "planillas";
            this.itmPlanillas.Location = new System.Drawing.Point(0, 208);
            this.itmPlanillas.Name = "itmPlanillas";
            this.itmPlanillas.Size = new System.Drawing.Size(279, 44);
            this.itmPlanillas.TabIndex = 5;
            this.itmPlanillas.Texto = "Gestión de planillas";
            this.itmPlanillas.Click += new System.EventHandler(this.itmPlanillas_Click);
            // 
            // itmSalones
            // 
            this.itmSalones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.itmSalones.Icono = "salones";
            this.itmSalones.Location = new System.Drawing.Point(0, 252);
            this.itmSalones.Name = "itmSalones";
            this.itmSalones.Size = new System.Drawing.Size(279, 44);
            this.itmSalones.TabIndex = 6;
            this.itmSalones.Texto = "Gestión de salones";
            this.itmSalones.Click += new System.EventHandler(this.itmSalones_Click);
            // 
            // lblGrpOperacion
            // 
            this.lblGrpOperacion.AutoSize = true;
            this.lblGrpOperacion.BackColor = System.Drawing.Color.Transparent;
            this.lblGrpOperacion.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.lblGrpOperacion.ForeColor = System.Drawing.Color.FromArgb(100, 108, 130);
            this.lblGrpOperacion.Location = new System.Drawing.Point(22, 316);
            this.lblGrpOperacion.Name = "lblGrpOperacion";
            this.lblGrpOperacion.Size = new System.Drawing.Size(77, 15);
            this.lblGrpOperacion.TabIndex = 7;
            this.lblGrpOperacion.Text = "OPERACIÓN";
            // 
            // itmCatalogo
            // 
            this.itmCatalogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.itmCatalogo.Icono = "catalogo";
            this.itmCatalogo.Location = new System.Drawing.Point(0, 338);
            this.itmCatalogo.Name = "itmCatalogo";
            this.itmCatalogo.Size = new System.Drawing.Size(279, 44);
            this.itmCatalogo.TabIndex = 8;
            this.itmCatalogo.Texto = "Catálogo de salarios";
            this.itmCatalogo.Click += new System.EventHandler(this.itmCatalogo_Click);
            // 
            // itmReportar
            // 
            this.itmReportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.itmReportar.Icono = "reportar";
            this.itmReportar.Location = new System.Drawing.Point(0, 382);
            this.itmReportar.Name = "itmReportar";
            this.itmReportar.Size = new System.Drawing.Size(279, 44);
            this.itmReportar.TabIndex = 9;
            this.itmReportar.Texto = "Reportar daño";
            this.itmReportar.Click += new System.EventHandler(this.itmReportar_Click);
            // 
            // lblGrpSistema
            // 
            this.lblGrpSistema.AutoSize = true;
            this.lblGrpSistema.BackColor = System.Drawing.Color.Transparent;
            this.lblGrpSistema.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.lblGrpSistema.ForeColor = System.Drawing.Color.FromArgb(100, 108, 130);
            this.lblGrpSistema.Location = new System.Drawing.Point(22, 446);
            this.lblGrpSistema.Name = "lblGrpSistema";
            this.lblGrpSistema.Size = new System.Drawing.Size(58, 15);
            this.lblGrpSistema.TabIndex = 10;
            this.lblGrpSistema.Text = "SISTEMA";
            // 
            // itmUsuarios
            // 
            this.itmUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.itmUsuarios.Icono = "usuarios";
            this.itmUsuarios.Location = new System.Drawing.Point(0, 468);
            this.itmUsuarios.Name = "itmUsuarios";
            this.itmUsuarios.Size = new System.Drawing.Size(279, 44);
            this.itmUsuarios.TabIndex = 12;
            this.itmUsuarios.Texto = "Usuarios";
            this.itmUsuarios.Click += new System.EventHandler(this.itmUsuarios_Click);
            // 
            // itmActividad
            // 
            this.itmActividad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.itmActividad.Icono = "actividad";
            this.itmActividad.Location = new System.Drawing.Point(0, 512);
            this.itmActividad.Name = "itmActividad";
            this.itmActividad.Size = new System.Drawing.Size(279, 44);
            this.itmActividad.TabIndex = 14;
            this.itmActividad.Texto = "Registro de actividad";
            this.itmActividad.Click += new System.EventHandler(this.itmActividad_Click);
            // 
            // itmAyuda
            // 
            this.itmAyuda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.itmAyuda.Icono = "ayuda";
            this.itmAyuda.Location = new System.Drawing.Point(0, 468);
            this.itmAyuda.Name = "itmAyuda";
            this.itmAyuda.Size = new System.Drawing.Size(279, 44);
            this.itmAyuda.TabIndex = 11;
            this.itmAyuda.Texto = "Ayuda";
            this.itmAyuda.Click += new System.EventHandler(this.itmAyuda_Click);
            // 
            // pnlUsuario
            // 
            this.pnlUsuario.BackColor = System.Drawing.Color. FromArgb(27, 29, 38);
            this.pnlUsuario.Controls.Add(this.lblUsuarioNombre);
            this.pnlUsuario.Controls.Add(this.lblUsuarioRol);
            this.pnlUsuario.Controls.Add(this.itmCerrarSesion);
            this.pnlUsuario.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlUsuario.Location = new System.Drawing.Point(0, 923);
            this.pnlUsuario.Name = "pnlUsuario";
            this.pnlUsuario.Size = new System.Drawing.Size(280, 132);
            this.pnlUsuario.TabIndex = 1;
            this.pnlUsuario.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlUsuario_Paint);
            // 
            // lblUsuarioNombre
            // 
            this.lblUsuarioNombre.AutoEllipsis = true;
            this.lblUsuarioNombre.BackColor = System.Drawing.Color.Transparent;
            this.lblUsuarioNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblUsuarioNombre.ForeColor = System.Drawing.Color.White;
            this.lblUsuarioNombre.Location = new System.Drawing.Point(74, 18);
            this.lblUsuarioNombre.Name = "lblUsuarioNombre";
            this.lblUsuarioNombre.Size = new System.Drawing.Size(190, 22);
            this.lblUsuarioNombre.TabIndex = 0;
            this.lblUsuarioNombre.Text = "Usuario";
            // 
            // lblUsuarioRol
            // 
            this.lblUsuarioRol.AutoEllipsis = true;
            this.lblUsuarioRol.BackColor = System.Drawing.Color.Transparent;
            this.lblUsuarioRol.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUsuarioRol.ForeColor = System.Drawing.Color. FromArgb(170, 180, 200);
            this.lblUsuarioRol.Location = new System.Drawing.Point(74, 41);
            this.lblUsuarioRol.Name = "lblUsuarioRol";
            this.lblUsuarioRol.Size = new System.Drawing.Size(190, 18);
            this.lblUsuarioRol.TabIndex = 1;
            this.lblUsuarioRol.Text = "Rol";
            // 
            // itmCerrarSesion
            // 
            this.itmCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.itmCerrarSesion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.itmCerrarSesion.Icono = "salir";
            this.itmCerrarSesion.Location = new System.Drawing.Point(0, 84);
            this.itmCerrarSesion.Name = "itmCerrarSesion";
            this.itmCerrarSesion.Peligro = true;
            this.itmCerrarSesion.Size = new System.Drawing.Size(280, 48);
            this.itmCerrarSesion.TabIndex = 2;
            this.itmCerrarSesion.Texto = "Cerrar sesión";
            this.itmCerrarSesion.Click += new System.EventHandler(this.itmCerrarSesion_Click);
            // 
            // pnlMarca
            // 
            this.pnlMarca.BackColor = System.Drawing.Color. FromArgb(27, 29, 38);
            this.pnlMarca.Controls.Add(this.pbLogo);
            this.pnlMarca.Controls.Add(this.lblInstitucion);
            this.pnlMarca.Controls.Add(this.lblSistema);
            this.pnlMarca.Controls.Add(this.itmPlegar);
            this.pnlMarca.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMarca.Location = new System.Drawing.Point(0, 0);
            this.pnlMarca.Name = "pnlMarca";
            this.pnlMarca.Size = new System.Drawing.Size(280, 100);
            this.pnlMarca.TabIndex = 2;
            this.pnlMarca.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMarca_Paint);
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbLogo.Location = new System.Drawing.Point(20, 26);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(48, 48);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            this.pbLogo.Paint += new System.Windows.Forms.PaintEventHandler(this.pbLogo_Paint);
            // 
            // lblInstitucion
            // 
            this.lblInstitucion.AutoEllipsis = true;
            this.lblInstitucion.BackColor = System.Drawing.Color.Transparent;
            this.lblInstitucion.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblInstitucion.ForeColor = System.Drawing.Color.White;
            this.lblInstitucion.Location = new System.Drawing.Point(78, 24);
            this.lblInstitucion.Name = "lblInstitucion";
            this.lblInstitucion.Size = new System.Drawing.Size(150, 40);
            this.lblInstitucion.TabIndex = 1;
            this.lblInstitucion.Text = "Sistema escolar";
            this.lblInstitucion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSistema
            // 
            this.lblSistema.BackColor = System.Drawing.Color.Transparent;
            this.lblSistema.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSistema.ForeColor = System.Drawing.Color.FromArgb(120, 128, 150);
            this.lblSistema.Location = new System.Drawing.Point(78, 66);
            this.lblSistema.Name = "lblSistema";
            this.lblSistema.Size = new System.Drawing.Size(150, 18);
            this.lblSistema.TabIndex = 2;
            this.lblSistema.Text = "Sistema de gestión";
            // 
            // itmPlegar
            // 
            this.itmPlegar.Compacto = true;
            this.itmPlegar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.itmPlegar.Icono = "menu";
            this.itmPlegar.Location = new System.Drawing.Point(232, 30);
            this.itmPlegar.Name = "itmPlegar";
            this.itmPlegar.Size = new System.Drawing.Size(40, 40);
            this.itmPlegar.TabIndex = 3;
            this.itmPlegar.Texto = "Plegar menú";
            this.itmPlegar.Click += new System.EventHandler(this.itmPlegar_Click);
            // 
            // pnlLineaMenu
            // 
            this.pnlLineaMenu.BackColor = System.Drawing.Color.FromArgb(45, 49, 66);
            this.pnlLineaMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlLineaMenu.Location = new System.Drawing.Point(280, 0);
            this.pnlLineaMenu.Name = "pnlLineaMenu";
            this.pnlLineaMenu.Size = new System.Drawing.Size(1, 1055);
            this.pnlLineaMenu.TabIndex = 3;
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.BackColor = System.Drawing.Color. FromArgb(18, 18, 18);
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(281, 0);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(1388, 1055);
            this.pnlContenedor.TabIndex = 1;
            // 
            // frmDashboard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color. FromArgb(18, 18, 18);
            this.ClientSize = new System.Drawing.Size(1669, 1055);
            this.Controls.Add(this.pnlContenedor);
            this.Controls.Add(this.pnlMenu);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDashboard_FormClosing);
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            this.pnlMenu.ResumeLayout(false);
            this.pnlNavegacion.ResumeLayout(false);
            this.pnlNavegacion.PerformLayout();
            this.pnlUsuario.ResumeLayout(false);
            this.pnlMarca.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlNavegacion;
        private System.Windows.Forms.Label lblGrpPrincipal;
        private ItemMenuLateral itmInicio;
        private System.Windows.Forms.Label lblGrpGestion;
        private ItemMenuLateral itmActivos;
        private ItemMenuLateral itmPersonal;
        private ItemMenuLateral itmPlanillas;
        private ItemMenuLateral itmSalones;
        private System.Windows.Forms.Label lblGrpOperacion;
        private ItemMenuLateral itmCatalogo;
        private ItemMenuLateral itmReportar;
        private System.Windows.Forms.Label lblGrpSistema;
        private ItemMenuLateral itmAyuda;
        private System.Windows.Forms.Panel pnlUsuario;
        private System.Windows.Forms.Label lblUsuarioNombre;
        private System.Windows.Forms.Label lblUsuarioRol;
        private ItemMenuLateral itmCerrarSesion;
        private System.Windows.Forms.Panel pnlMarca;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lblInstitucion;
        private System.Windows.Forms.Label lblSistema;
        private System.Windows.Forms.Panel pnlLineaMenu;
        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.ToolTip toolTip1;
        private ItemMenuLateral itmPlegar;
        private ItemMenuLateral itmUsuarios;
        private ItemMenuLateral itmActividad;
    }
}