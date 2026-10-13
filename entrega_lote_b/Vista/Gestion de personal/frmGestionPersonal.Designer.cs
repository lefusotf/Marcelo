using System.Drawing;
using System.Windows.Forms;

namespace Gestion_de_personal
{
    partial class frmGestionPersonal
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
            this.pnlEncabezado = new Panel();
            this.lblGestionPersonal = new Label();
            this.lblSubtitulo = new Label();
            this.pnlResumen = new Panel();
            this.tlpResumen = new TableLayoutPanel();
            this.pnlTarjEmpleados = new Vistass.PanelTarjeta();
            this.lblEmpleadosDetalle = new Label();
            this.lblEmpleadosValor = new Label();
            this.lblEmpleadosTitulo = new Label();
            this.pnlAcEmpleados = new Panel();
            this.pnlTarjNomina = new Vistass.PanelTarjeta();
            this.lblNominaDetalle = new Label();
            this.lblNominaValor = new Label();
            this.lblNominaTitulo = new Label();
            this.pnlAcNomina = new Panel();
            this.pnlBarra = new Vistass.PanelTarjeta();
            this.pnlBuscador = new Panel();
            this.lblBuscarHint = new Label();
            this.txtBuscar = new TextBox();
            this.pnlLupa = new Panel();
            this.cmbCargo = new Vistass.ComboOscuro();
            this.btnAgregarPersonal = new Vistass.BotonTema();
            this.btnActualizarPersonal = new Vistass.BotonTema();
            this.btnNuevoCargo = new Vistass.BotonTema();
            this.btnEditarCargo = new Vistass.BotonTema();
            this.btnEliminarPersonal = new Vistass.BotonTema();
            this.btnExpediente = new Vistass.BotonTema();
            this.btnAusencias = new Vistass.BotonTema();
            this.btnCargaAcademica = new Vistass.BotonTema();
            this.btnExportarPdf = new Vistass.BotonTema();
            this.pnlTabla = new Panel();
            this.dgvEmpleados = new Vistass.GridOscuro();
            this.toolTip1 = new ToolTip(this.components);
            this.pnlEncabezado.SuspendLayout();
            this.pnlResumen.SuspendLayout();
            this.tlpResumen.SuspendLayout();
            this.pnlTarjEmpleados.SuspendLayout();
            this.pnlTarjNomina.SuspendLayout();
            this.pnlBarra.SuspendLayout();
            this.pnlBuscador.SuspendLayout();
            this.pnlTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.BackColor = Color.FromArgb(18, 18, 18);
            this.pnlEncabezado.Controls.Add(this.lblGestionPersonal);
            this.pnlEncabezado.Controls.Add(this.lblSubtitulo);
            this.pnlEncabezado.Dock = DockStyle.Top;
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new Size(1200, 84);
            this.pnlEncabezado.TabIndex = 3;
            // 
            // lblGestionPersonal
            // 
            this.lblGestionPersonal.AutoSize = true;
            this.lblGestionPersonal.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            this.lblGestionPersonal.ForeColor = Color.White;
            this.lblGestionPersonal.Location = new Point(0, 6);
            this.lblGestionPersonal.Name = "lblGestionPersonal";
            this.lblGestionPersonal.Text = "Gestión de personal";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.ForeColor = Color.FromArgb(170, 180, 200);
            this.lblSubtitulo.Location = new Point(2, 50);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Text = "Expedientes, cargos y planilla del personal de la institución";
            // 
            // pnlResumen
            // 
            this.pnlResumen.BackColor = Color.FromArgb(18, 18, 18);
            this.pnlResumen.Controls.Add(this.tlpResumen);
            this.pnlResumen.Dock = DockStyle.Top;
            this.pnlResumen.Name = "pnlResumen";
            this.pnlResumen.Padding = new Padding(0, 0, 0, 12);
            this.pnlResumen.Size = new Size(1200, 88);
            this.pnlResumen.TabIndex = 2;
            // 
            // tlpResumen
            // 
            this.tlpResumen.BackColor = Color.FromArgb(18, 18, 18);
            this.tlpResumen.ColumnCount = 2;
            this.tlpResumen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tlpResumen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tlpResumen.Controls.Add(this.pnlTarjEmpleados, 0, 0);
            this.tlpResumen.Controls.Add(this.pnlTarjNomina, 1, 0);
            this.tlpResumen.Dock = DockStyle.Fill;
            this.tlpResumen.Margin = new Padding(0);
            this.tlpResumen.Name = "tlpResumen";
            this.tlpResumen.RowCount = 1;
            this.tlpResumen.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            // 
            // pnlTarjEmpleados
            // 
            this.pnlTarjEmpleados.BackColor = Color.FromArgb(27, 29, 38);
            this.pnlTarjEmpleados.Controls.Add(this.lblEmpleadosDetalle);
            this.pnlTarjEmpleados.Controls.Add(this.lblEmpleadosValor);
            this.pnlTarjEmpleados.Controls.Add(this.lblEmpleadosTitulo);
            this.pnlTarjEmpleados.Controls.Add(this.pnlAcEmpleados);
            this.pnlTarjEmpleados.Dock = DockStyle.Fill;
            this.pnlTarjEmpleados.Margin = new Padding(0, 0, 12, 0);
            this.pnlTarjEmpleados.Name = "pnlTarjEmpleados";
            // 
            // pnlAcEmpleados
            // 
            this.pnlAcEmpleados.BackColor = Color.FromArgb(96, 165, 250);
            this.pnlAcEmpleados.Dock = DockStyle.Left;
            this.pnlAcEmpleados.Name = "pnlAcEmpleados";
            this.pnlAcEmpleados.Size = new Size(4, 76);
            // 
            // lblEmpleadosTitulo
            // 
            this.lblEmpleadosTitulo.AutoSize = true;
            this.lblEmpleadosTitulo.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            this.lblEmpleadosTitulo.ForeColor = Color.FromArgb(170, 180, 200);
            this.lblEmpleadosTitulo.Location = new Point(20, 8);
            this.lblEmpleadosTitulo.Name = "lblEmpleadosTitulo";
            this.lblEmpleadosTitulo.Text = "EMPLEADOS";
            // 
            // lblEmpleadosValor
            // 
            this.lblEmpleadosValor.AutoSize = true;
            this.lblEmpleadosValor.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblEmpleadosValor.ForeColor = Color.FromArgb(147, 197, 253);
            this.lblEmpleadosValor.Location = new Point(18, 22);
            this.lblEmpleadosValor.Name = "lblEmpleadosValor";
            this.lblEmpleadosValor.Text = "0";
            // 
            // lblEmpleadosDetalle
            // 
            this.lblEmpleadosDetalle.AutoSize = true;
            this.lblEmpleadosDetalle.Font = new Font("Segoe UI", 9F);
            this.lblEmpleadosDetalle.ForeColor = Color.FromArgb(170, 180, 200);
            this.lblEmpleadosDetalle.Location = new Point(20, 56);
            this.lblEmpleadosDetalle.Name = "lblEmpleadosDetalle";
            this.lblEmpleadosDetalle.Text = "...";
            // 
            // pnlTarjNomina
            // 
            this.pnlTarjNomina.BackColor = Color.FromArgb(27, 29, 38);
            this.pnlTarjNomina.Controls.Add(this.lblNominaDetalle);
            this.pnlTarjNomina.Controls.Add(this.lblNominaValor);
            this.pnlTarjNomina.Controls.Add(this.lblNominaTitulo);
            this.pnlTarjNomina.Controls.Add(this.pnlAcNomina);
            this.pnlTarjNomina.Dock = DockStyle.Fill;
            this.pnlTarjNomina.Margin = new Padding(0);
            this.pnlTarjNomina.Name = "pnlTarjNomina";
            // 
            // pnlAcNomina
            // 
            this.pnlAcNomina.BackColor = Color.FromArgb(74, 222, 128);
            this.pnlAcNomina.Dock = DockStyle.Left;
            this.pnlAcNomina.Name = "pnlAcNomina";
            this.pnlAcNomina.Size = new Size(4, 76);
            // 
            // lblNominaTitulo
            // 
            this.lblNominaTitulo.AutoSize = true;
            this.lblNominaTitulo.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            this.lblNominaTitulo.ForeColor = Color.FromArgb(170, 180, 200);
            this.lblNominaTitulo.Location = new Point(20, 8);
            this.lblNominaTitulo.Name = "lblNominaTitulo";
            this.lblNominaTitulo.Text = "NÓMINA MENSUAL NETA";
            // 
            // lblNominaValor
            // 
            this.lblNominaValor.AutoSize = true;
            this.lblNominaValor.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblNominaValor.ForeColor = Color.FromArgb(134, 239, 172);
            this.lblNominaValor.Location = new Point(18, 22);
            this.lblNominaValor.Name = "lblNominaValor";
            this.lblNominaValor.Text = "$0.00";
            // 
            // lblNominaDetalle
            // 
            this.lblNominaDetalle.AutoSize = true;
            this.lblNominaDetalle.Font = new Font("Segoe UI", 9F);
            this.lblNominaDetalle.ForeColor = Color.FromArgb(170, 180, 200);
            this.lblNominaDetalle.Location = new Point(20, 56);
            this.lblNominaDetalle.Name = "lblNominaDetalle";
            this.lblNominaDetalle.Text = "...";
            // 
            // pnlBarra
            // 
            this.pnlBarra.BackColor = Color.FromArgb(27, 29, 38);
            this.pnlBarra.Controls.Add(this.pnlBuscador);
            this.pnlBarra.Controls.Add(this.cmbCargo);
            this.pnlBarra.Controls.Add(this.btnAgregarPersonal);
            this.pnlBarra.Controls.Add(this.btnActualizarPersonal);
            this.pnlBarra.Controls.Add(this.btnNuevoCargo);
            this.pnlBarra.Controls.Add(this.btnEditarCargo);
            this.pnlBarra.Controls.Add(this.btnEliminarPersonal);
            this.pnlBarra.Controls.Add(this.btnExpediente);
            this.pnlBarra.Controls.Add(this.btnAusencias);
            this.pnlBarra.Controls.Add(this.btnCargaAcademica);
            this.pnlBarra.Controls.Add(this.btnExportarPdf);
            this.pnlBarra.Dock = DockStyle.Top;
            this.pnlBarra.Name = "pnlBarra";
            this.pnlBarra.Size = new Size(1200, 112);
            this.pnlBarra.TabIndex = 1;
            // 
            // pnlBuscador
            // 
            this.pnlBuscador.BackColor = Color.FromArgb(38, 42, 58);
            this.pnlBuscador.Controls.Add(this.lblBuscarHint);
            this.pnlBuscador.Controls.Add(this.txtBuscar);
            this.pnlBuscador.Controls.Add(this.pnlLupa);
            this.pnlBuscador.Location = new Point(16, 16);
            this.pnlBuscador.Name = "pnlBuscador";
            this.pnlBuscador.Padding = new Padding(1);
            this.pnlBuscador.Size = new Size(320, 28);
            this.pnlBuscador.Paint += new PaintEventHandler(this.pnlBuscador_Paint);
            // 
            // lblBuscarHint
            // 
            this.lblBuscarHint.AutoSize = true;
            this.lblBuscarHint.BackColor = Color.FromArgb(38, 42, 58);
            this.lblBuscarHint.Cursor = Cursors.IBeam;
            this.lblBuscarHint.Font = new Font("Segoe UI", 10.5F);
            this.lblBuscarHint.ForeColor = Color.FromArgb(140, 150, 176);
            this.lblBuscarHint.Location = new Point(33, 4);
            this.lblBuscarHint.Name = "lblBuscarHint";
            this.lblBuscarHint.Text = "Buscar por nombre, ID o cargo...";
            this.lblBuscarHint.Click += new System.EventHandler(this.lblBuscarHint_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.BackColor = Color.FromArgb(38, 42, 58);
            this.txtBuscar.BorderStyle = BorderStyle.None;
            this.txtBuscar.Font = new Font("Segoe UI", 10.5F);
            this.txtBuscar.ForeColor = Color.FromArgb(240, 244, 252);
            this.txtBuscar.Location = new Point(32, 4);
            this.txtBuscar.MaxLength = 100;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new Size(278, 19);
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar.Enter += new System.EventHandler(this.txtBuscar_FocoCambiado);
            this.txtBuscar.Leave += new System.EventHandler(this.txtBuscar_FocoCambiado);
            // 
            // pnlLupa
            // 
            this.pnlLupa.BackColor = Color.FromArgb(38, 42, 58);
            this.pnlLupa.Dock = DockStyle.Left;
            this.pnlLupa.Name = "pnlLupa";
            this.pnlLupa.Size = new Size(28, 26);
            this.pnlLupa.Paint += new PaintEventHandler(this.pnlLupa_Paint);
            // 
            // cmbCargo
            // 
            this.cmbCargo.BackColor = Color.FromArgb(38, 42, 58);
            this.cmbCargo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCargo.FlatStyle = FlatStyle.Flat;
            this.cmbCargo.Font = new Font("Segoe UI", 10.5F);
            this.cmbCargo.ForeColor = Color.FromArgb(240, 244, 252);
            this.cmbCargo.FormattingEnabled = true;
            this.cmbCargo.Location = new Point(348, 16);
            this.cmbCargo.Name = "cmbCargo";
            this.cmbCargo.Size = new Size(230, 27);
            this.cmbCargo.SelectedIndexChanged += new System.EventHandler(this.cmbCargo_SelectedIndexChanged);
            // 
            // btnAgregarPersonal
            // 
            this.btnAgregarPersonal.Location = new Point(16, 58);
            this.btnAgregarPersonal.Name = "btnAgregarPersonal";
            this.btnAgregarPersonal.Size = new Size(210, 38);
            this.btnAgregarPersonal.Text = "Agregar nuevo empleado";
            this.btnAgregarPersonal.Click += new System.EventHandler(this.btnAgregarPersonal_Click);
            // 
            // btnActualizarPersonal
            // 
            this.btnActualizarPersonal.Location = new Point(234, 58);
            this.btnActualizarPersonal.Name = "btnActualizarPersonal";
            this.btnActualizarPersonal.Size = new Size(90, 38);
            this.btnActualizarPersonal.Text = "Editar";
            this.btnActualizarPersonal.Tipo = Vistass.TipoBoton.Secundario;
            this.btnActualizarPersonal.Click += new System.EventHandler(this.btnActualizarPersonal_Click);
            // 
            // btnNuevoCargo
            // 
            this.btnNuevoCargo.Location = new Point(440, 58);
            this.btnNuevoCargo.Name = "btnNuevoCargo";
            this.btnNuevoCargo.Size = new Size(110, 38);
            this.btnNuevoCargo.Text = "Nuevo cargo";
            this.btnNuevoCargo.Tipo = Vistass.TipoBoton.Secundario;
            this.btnNuevoCargo.Click += new System.EventHandler(this.btnNuevoCargo_Click);
            // 
            // btnEditarCargo
            // 
            this.btnEditarCargo.Location = new Point(558, 58);
            this.btnEditarCargo.Name = "btnEditarCargo";
            this.btnEditarCargo.Size = new Size(110, 38);
            this.btnEditarCargo.Text = "Editar cargo";
            this.btnEditarCargo.Tipo = Vistass.TipoBoton.Secundario;
            this.btnEditarCargo.Click += new System.EventHandler(this.btnEditarCargo_Click);
            // 
            // btnEliminarPersonal
            // 
            this.btnEliminarPersonal.Location = new Point(332, 58);
            this.btnEliminarPersonal.Name = "btnEliminarPersonal";
            this.btnEliminarPersonal.Size = new Size(100, 38);
            this.btnEliminarPersonal.Text = "Eliminar";
            this.btnEliminarPersonal.Tipo = Vistass.TipoBoton.Peligro;
            this.btnEliminarPersonal.Click += new System.EventHandler(this.btnEliminarPersonal_Click);
            // 
            // btnExpediente
            // 
            this.btnExpediente.Location = new Point(676, 58);
            this.btnExpediente.Name = "btnExpediente";
            this.btnExpediente.Size = new Size(110, 38);
            this.btnExpediente.Text = "Expediente";
            this.btnExpediente.Tipo = Vistass.TipoBoton.Secundario;
            this.btnExpediente.Click += new System.EventHandler(this.btnExpediente_Click);
            // 
            // btnAusencias
            // 
            this.btnAusencias.Location = new Point(794, 58);
            this.btnAusencias.Name = "btnAusencias";
            this.btnAusencias.Size = new Size(110, 38);
            this.btnAusencias.Text = "Ausencias";
            this.btnAusencias.Tipo = Vistass.TipoBoton.Secundario;
            this.btnAusencias.Click += new System.EventHandler(this.btnAusencias_Click);
            // 
            // btnCargaAcademica
            // 
            this.btnCargaAcademica.Location = new Point(912, 58);
            this.btnCargaAcademica.Name = "btnCargaAcademica";
            this.btnCargaAcademica.Size = new Size(150, 38);
            this.btnCargaAcademica.Text = "Carga académica";
            this.btnCargaAcademica.Tipo = Vistass.TipoBoton.Secundario;
            this.btnCargaAcademica.Click += new System.EventHandler(this.btnCargaAcademica_Click);
            // 
            // btnExportarPdf
            // 
            this.btnExportarPdf.Location = new Point(1070, 58);
            this.btnExportarPdf.Name = "btnExportarPdf";
            this.btnExportarPdf.Size = new Size(100, 38);
            this.btnExportarPdf.Text = "Exportar";
            this.btnExportarPdf.Tipo = Vistass.TipoBoton.Secundario;
            this.btnExportarPdf.Click += new System.EventHandler(this.btnExportarPdf_Click);
            // 
            // pnlTabla
            // 
            this.pnlTabla.BackColor = Color.FromArgb(18, 18, 18);
            this.pnlTabla.Controls.Add(this.dgvEmpleados);
            this.pnlTabla.Dock = DockStyle.Fill;
            this.pnlTabla.Name = "pnlTabla";
            this.pnlTabla.Padding = new Padding(0, 16, 0, 0);
            this.pnlTabla.Size = new Size(1200, 460);
            this.pnlTabla.TabIndex = 0;
            // 
            // dgvEmpleados
            // 
            this.dgvEmpleados.ColumnHeadersHeight = 40;
            this.dgvEmpleados.Dock = DockStyle.Fill;
            this.dgvEmpleados.Name = "dgvEmpleados";
            this.dgvEmpleados.RowTemplate.Height = 40;
            this.dgvEmpleados.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvEmpleados_CellDoubleClick);
            this.dgvEmpleados.CellPainting += new DataGridViewCellPaintingEventHandler(this.dgvEmpleados_CellPainting);
            this.dgvEmpleados.SelectionChanged += new System.EventHandler(this.dgvEmpleados_SelectionChanged);
            // 
            // frmGestionPersonal
            // 
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.FromArgb(18, 18, 18);
            this.ClientSize = new Size(1248, 760);
            this.Controls.Add(this.pnlTabla);
            this.Controls.Add(this.pnlBarra);
            this.Controls.Add(this.pnlResumen);
            this.Controls.Add(this.pnlEncabezado);
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.ForeColor = Color.FromArgb(240, 244, 252);
            this.Name = "frmGestionPersonal";
            this.Padding = new Padding(24, 0, 24, 16);
            this.Text = "Gestión de personal";
            this.Load += new System.EventHandler(this.frmGestionPersonal_Load);
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.pnlResumen.ResumeLayout(false);
            this.tlpResumen.ResumeLayout(false);
            this.pnlTarjEmpleados.ResumeLayout(false);
            this.pnlTarjEmpleados.PerformLayout();
            this.pnlTarjNomina.ResumeLayout(false);
            this.pnlTarjNomina.PerformLayout();
            this.pnlBarra.ResumeLayout(false);
            this.pnlBuscador.ResumeLayout(false);
            this.pnlBuscador.PerformLayout();
            this.pnlTabla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlEncabezado;
        private Label lblGestionPersonal;
        private Label lblSubtitulo;
        private Panel pnlResumen;
        private TableLayoutPanel tlpResumen;
        private Vistass.PanelTarjeta pnlTarjEmpleados;
        private Panel pnlAcEmpleados;
        private Label lblEmpleadosTitulo;
        private Label lblEmpleadosValor;
        private Label lblEmpleadosDetalle;
        private Vistass.PanelTarjeta pnlTarjNomina;
        private Panel pnlAcNomina;
        private Label lblNominaTitulo;
        private Label lblNominaValor;
        private Label lblNominaDetalle;
        private Vistass.PanelTarjeta pnlBarra;
        private Panel pnlBuscador;
        private Label lblBuscarHint;
        private TextBox txtBuscar;
        private Panel pnlLupa;
        private Vistass.ComboOscuro cmbCargo;
        private Vistass.BotonTema btnAgregarPersonal;
        private Vistass.BotonTema btnActualizarPersonal;
        private Vistass.BotonTema btnNuevoCargo;
        private Vistass.BotonTema btnEditarCargo;
        private Vistass.BotonTema btnEliminarPersonal;
        private Vistass.BotonTema btnExpediente;
        private Vistass.BotonTema btnAusencias;
        private Vistass.BotonTema btnCargaAcademica;
        private Vistass.BotonTema btnExportarPdf;
        private Panel pnlTabla;
        private Vistass.GridOscuro dgvEmpleados;
        private ToolTip toolTip1;
    }
}