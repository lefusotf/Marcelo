namespace Vistass
{
    partial class frmUnidadesActivo
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
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblResumen = new System.Windows.Forms.Label();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.lblFSalon = new System.Windows.Forms.Label();
            this.cmbFSalon = new Vistass.ComboOscuro();
            this.lblFEstado = new System.Windows.Forms.Label();
            this.cmbFEstado = new Vistass.ComboOscuro();
            this.lblFBuscar = new System.Windows.Forms.Label();
            this.txtFBuscar = new System.Windows.Forms.TextBox();
            this.btnLimpiar = new Vistass.BotonTema();
            this.dgvUnidades = new Vistass.GridOscuro();
            this.pnlAccion = new System.Windows.Forms.Panel();
            this.lblSeleccion = new System.Windows.Forms.Label();
            this.btnSeleccionarTodo = new Vistass.BotonTema();
            this.lblAccion = new System.Windows.Forms.Label();
            this.cmbNuevoEstado = new Vistass.ComboOscuro();
            this.btnAplicar = new Vistass.BotonTema();
            this.btnCerrar = new Vistass.BotonTema();
            this.pnlTitulo.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnidades)).BeginInit();
            this.pnlAccion.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.BackColor = System.Drawing.Color.FromArgb(27, 29, 38);
            this.pnlTitulo.Controls.Add(this.lblTitulo);
            this.pnlTitulo.Controls.Add(this.lblResumen);
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(980, 74);
            this.pnlTitulo.TabIndex = 3;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(16, 8);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(150, 28);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Unidades del activo";
            // 
            // lblResumen
            // 
            this.lblResumen.AutoSize = true;
            this.lblResumen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblResumen.ForeColor = System.Drawing.Color.FromArgb(170, 180, 200);
            this.lblResumen.Location = new System.Drawing.Point(18, 44);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Size = new System.Drawing.Size(60, 19);
            this.lblResumen.TabIndex = 1;
            this.lblResumen.Text = "Resumen";
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.pnlFiltros.Controls.Add(this.lblFSalon);
            this.pnlFiltros.Controls.Add(this.cmbFSalon);
            this.pnlFiltros.Controls.Add(this.lblFEstado);
            this.pnlFiltros.Controls.Add(this.cmbFEstado);
            this.pnlFiltros.Controls.Add(this.lblFBuscar);
            this.pnlFiltros.Controls.Add(this.txtFBuscar);
            this.pnlFiltros.Controls.Add(this.btnLimpiar);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Location = new System.Drawing.Point(0, 74);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(980, 54);
            this.pnlFiltros.TabIndex = 2;
            // 
            // lblFSalon
            // 
            this.lblFSalon.AutoSize = true;
            this.lblFSalon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFSalon.ForeColor = System.Drawing.Color.White;
            this.lblFSalon.Location = new System.Drawing.Point(16, 18);
            this.lblFSalon.Name = "lblFSalon";
            this.lblFSalon.Size = new System.Drawing.Size(41, 19);
            this.lblFSalon.TabIndex = 0;
            this.lblFSalon.Text = "Salón";
            // 
            // cmbFSalon
            // 
            this.cmbFSalon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFSalon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbFSalon.FormattingEnabled = true;
            this.cmbFSalon.Location = new System.Drawing.Point(66, 14);
            this.cmbFSalon.Name = "cmbFSalon";
            this.cmbFSalon.Size = new System.Drawing.Size(200, 25);
            this.cmbFSalon.TabIndex = 1;
            this.cmbFSalon.SelectedIndexChanged += new System.EventHandler(this.Filtro_Changed);
            // 
            // lblFEstado
            // 
            this.lblFEstado.AutoSize = true;
            this.lblFEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFEstado.ForeColor = System.Drawing.Color.White;
            this.lblFEstado.Location = new System.Drawing.Point(286, 18);
            this.lblFEstado.Name = "lblFEstado";
            this.lblFEstado.Size = new System.Drawing.Size(48, 19);
            this.lblFEstado.TabIndex = 2;
            this.lblFEstado.Text = "Estado";
            // 
            // cmbFEstado
            // 
            this.cmbFEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbFEstado.FormattingEnabled = true;
            this.cmbFEstado.Location = new System.Drawing.Point(342, 14);
            this.cmbFEstado.Name = "cmbFEstado";
            this.cmbFEstado.Size = new System.Drawing.Size(180, 25);
            this.cmbFEstado.TabIndex = 3;
            this.cmbFEstado.SelectedIndexChanged += new System.EventHandler(this.Filtro_Changed);
            // 
            // lblFBuscar
            // 
            this.lblFBuscar.AutoSize = true;
            this.lblFBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFBuscar.ForeColor = System.Drawing.Color.White;
            this.lblFBuscar.Location = new System.Drawing.Point(542, 18);
            this.lblFBuscar.Name = "lblFBuscar";
            this.lblFBuscar.Size = new System.Drawing.Size(48, 19);
            this.lblFBuscar.TabIndex = 4;
            this.lblFBuscar.Text = "Código";
            // 
            // txtFBuscar
            // 
            this.txtFBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFBuscar.Location = new System.Drawing.Point(598, 14);
            this.txtFBuscar.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.txtFBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFBuscar.ForeColor = System.Drawing.Color.FromArgb(240, 244, 252);
            this.txtFBuscar.Name = "txtFBuscar";
            this.txtFBuscar.Size = new System.Drawing.Size(170, 25);
            this.txtFBuscar.TabIndex = 5;
            this.txtFBuscar.TextChanged += new System.EventHandler(this.Filtro_Changed);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnLimpiar.Location = new System.Drawing.Point(854, 12);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(110, 29);
            this.btnLimpiar.TabIndex = 6;
            this.btnLimpiar.Text = "Limpiar filtros";
            this.btnLimpiar.Tipo = Vistass.TipoBoton.Secundario;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // dgvUnidades
            // 
            this.dgvUnidades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUnidades.Location = new System.Drawing.Point(0, 128);
            this.dgvUnidades.Name = "dgvUnidades";
            this.dgvUnidades.RowHeadersWidth = 51;
            this.dgvUnidades.Size = new System.Drawing.Size(980, 412);
            this.dgvUnidades.TabIndex = 0;
            this.dgvUnidades.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvUnidades_CellFormatting);
            this.dgvUnidades.SelectionChanged += new System.EventHandler(this.dgvUnidades_SelectionChanged);
            // 
            // pnlAccion
            // 
            this.pnlAccion.BackColor = System.Drawing.Color.FromArgb(27, 29, 38);
            this.pnlAccion.Controls.Add(this.lblSeleccion);
            this.pnlAccion.Controls.Add(this.btnSeleccionarTodo);
            this.pnlAccion.Controls.Add(this.lblAccion);
            this.pnlAccion.Controls.Add(this.cmbNuevoEstado);
            this.pnlAccion.Controls.Add(this.btnAplicar);
            this.pnlAccion.Controls.Add(this.btnCerrar);
            this.pnlAccion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAccion.Location = new System.Drawing.Point(0, 540);
            this.pnlAccion.Name = "pnlAccion";
            this.pnlAccion.Size = new System.Drawing.Size(980, 80);
            this.pnlAccion.TabIndex = 1;
            // 
            // lblSeleccion
            // 
            this.lblSeleccion.AutoSize = true;
            this.lblSeleccion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSeleccion.ForeColor = System.Drawing.Color.White;
            this.lblSeleccion.Location = new System.Drawing.Point(16, 12);
            this.lblSeleccion.Name = "lblSeleccion";
            this.lblSeleccion.Size = new System.Drawing.Size(170, 19);
            this.lblSeleccion.TabIndex = 0;
            this.lblSeleccion.Text = "0 unidades seleccionadas";
            // 
            // btnSeleccionarTodo
            // 
            this.btnSeleccionarTodo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnSeleccionarTodo.Location = new System.Drawing.Point(250, 8);
            this.btnSeleccionarTodo.Name = "btnSeleccionarTodo";
            this.btnSeleccionarTodo.Size = new System.Drawing.Size(190, 28);
            this.btnSeleccionarTodo.TabIndex = 1;
            this.btnSeleccionarTodo.Text = "Seleccionar todas las visibles";
            this.btnSeleccionarTodo.Tipo = Vistass.TipoBoton.Secundario;
            this.btnSeleccionarTodo.Click += new System.EventHandler(this.btnSeleccionarTodo_Click);
            // 
            // lblAccion
            // 
            this.lblAccion.AutoSize = true;
            this.lblAccion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAccion.ForeColor = System.Drawing.Color.White;
            this.lblAccion.Location = new System.Drawing.Point(16, 48);
            this.lblAccion.Name = "lblAccion";
            this.lblAccion.Size = new System.Drawing.Size(250, 19);
            this.lblAccion.TabIndex = 2;
            this.lblAccion.Text = "Cambiar el estado de las seleccionadas a:";
            // 
            // cmbNuevoEstado
            // 
            this.cmbNuevoEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNuevoEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbNuevoEstado.FormattingEnabled = true;
            this.cmbNuevoEstado.Location = new System.Drawing.Point(300, 44);
            this.cmbNuevoEstado.Name = "cmbNuevoEstado";
            this.cmbNuevoEstado.Size = new System.Drawing.Size(200, 25);
            this.cmbNuevoEstado.TabIndex = 3;
            // 
            // btnAplicar
            // 
            this.btnAplicar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAplicar.Location = new System.Drawing.Point(514, 42);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(150, 29);
            this.btnAplicar.TabIndex = 4;
            this.btnAplicar.Text = "Aplicar cambio";
            this.btnAplicar.Tipo = Vistass.TipoBoton.Principal;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCerrar.Location = new System.Drawing.Point(854, 42);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(110, 29);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Tipo = Vistass.TipoBoton.Secundario;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // frmUnidadesActivo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.ClientSize = new System.Drawing.Size(980, 620);
            this.Controls.Add(this.dgvUnidades);
            this.Controls.Add(this.pnlAccion);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.pnlTitulo);
            this.MinimumSize = new System.Drawing.Size(900, 520);
            this.Name = "frmUnidadesActivo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Unidades del activo";
            this.Load += new System.EventHandler(this.frmUnidadesActivo_Load);
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnidades)).EndInit();
            this.pnlAccion.ResumeLayout(false);
            this.pnlAccion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblResumen;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Label lblFSalon;
        private Vistass.ComboOscuro cmbFSalon;
        private System.Windows.Forms.Label lblFEstado;
        private Vistass.ComboOscuro cmbFEstado;
        private System.Windows.Forms.Label lblFBuscar;
        private System.Windows.Forms.TextBox txtFBuscar;
        private Vistass.BotonTema btnLimpiar;
        private Vistass.GridOscuro dgvUnidades;
        private System.Windows.Forms.Panel pnlAccion;
        private System.Windows.Forms.Label lblSeleccion;
        private Vistass.BotonTema btnSeleccionarTodo;
        private System.Windows.Forms.Label lblAccion;
        private Vistass.ComboOscuro cmbNuevoEstado;
        private Vistass.BotonTema btnAplicar;
        private Vistass.BotonTema btnCerrar;
    }
}