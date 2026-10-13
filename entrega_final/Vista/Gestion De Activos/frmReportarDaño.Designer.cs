using System.Drawing;
using System.Windows.Forms;

namespace Vistass
{
    partial class frmReportarDaño
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.tlpKpis = new System.Windows.Forms.TableLayoutPanel();
            this.pnlKpiAbiertos = new System.Windows.Forms.Panel();
            this.lblKpiAbiertosValor = new System.Windows.Forms.Label();
            this.lblKpiAbiertosDetalle = new System.Windows.Forms.Label();
            this.lblKpiAbiertosTitulo = new System.Windows.Forms.Label();
            this.pnlKpiAltas = new System.Windows.Forms.Panel();
            this.lblKpiAltasValor = new System.Windows.Forms.Label();
            this.lblKpiAltasDetalle = new System.Windows.Forms.Label();
            this.lblKpiAltasTitulo = new System.Windows.Forms.Label();
            this.pnlKpiAntiguo = new System.Windows.Forms.Panel();
            this.lblKpiAntiguoValor = new System.Windows.Forms.Label();
            this.lblKpiAntiguoDetalle = new System.Windows.Forms.Label();
            this.lblKpiAntiguoTitulo = new System.Windows.Forms.Label();
            this.pnlKpiMes = new System.Windows.Forms.Panel();
            this.lblKpiMesValor = new System.Windows.Forms.Label();
            this.lblKpiMesDetalle = new System.Windows.Forms.Label();
            this.lblKpiMesTitulo = new System.Windows.Forms.Label();
            this.pnlIzq = new System.Windows.Forms.Panel();
            this.cardNuevo = new System.Windows.Forms.Panel();
            this.tlpNuevo = new System.Windows.Forms.TableLayoutPanel();
            this.lblNuevoTitulo = new System.Windows.Forms.Label();
            this.lblSalon = new System.Windows.Forms.Label();
            this.cmbSalon = new Vistass.ComboOscuro();
            this.txtBuscarEquipo = new System.Windows.Forms.TextBox();
            this.dgvEquipos = new Vistass.GridOscuro();
            this.pnlSeleccion = new System.Windows.Forms.Panel();
            this.lblSeleccion = new System.Windows.Forms.Label();
            this.chkTodas = new System.Windows.Forms.CheckBox();
            this.lblPrioridad = new System.Windows.Forms.Label();
            this.cmbPrioridad = new Vistass.ComboOscuro();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.flpBotonesNuevo = new System.Windows.Forms.FlowLayoutPanel();
            this.btnReportar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.pnlDer = new System.Windows.Forms.Panel();
            this.cardLista = new System.Windows.Forms.Panel();
            this.dgvReportes = new Vistass.GridOscuro();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.txtDetalle = new System.Windows.Forms.TextBox();
            this.lblDetalleTitulo = new System.Windows.Forms.Label();
            this.pnlAcciones = new System.Windows.Forms.Panel();
            this.flpAcciones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnResolver = new System.Windows.Forms.Button();
            this.btnBaja = new System.Windows.Forms.Button();
            this.btnPrioridad = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.lblAvisoAdmin = new System.Windows.Forms.Label();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.tlpFiltros = new System.Windows.Forms.TableLayoutPanel();
            this.cmbFiltroEstado = new Vistass.ComboOscuro();
            this.cmbFiltroSalon = new Vistass.ComboOscuro();
            this.cmbFiltroPrioridad = new Vistass.ComboOscuro();
            this.btnExportar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblListaTitulo = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlTitulo.SuspendLayout();
            this.tlpKpis.SuspendLayout();
            this.pnlKpiAbiertos.SuspendLayout();
            this.pnlKpiAltas.SuspendLayout();
            this.pnlKpiAntiguo.SuspendLayout();
            this.pnlKpiMes.SuspendLayout();
            this.pnlIzq.SuspendLayout();
            this.cardNuevo.SuspendLayout();
            this.tlpNuevo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).BeginInit();
            this.pnlSeleccion.SuspendLayout();
            this.flpBotonesNuevo.SuspendLayout();
            this.pnlDer.SuspendLayout();
            this.cardLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).BeginInit();
            this.pnlDetalle.SuspendLayout();
            this.pnlAcciones.SuspendLayout();
            this.flpAcciones.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            this.tlpFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.Controls.Add(this.lblSubtitulo);
            this.pnlTitulo.Controls.Add(this.lblTitulo);
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(24, 8);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(1592, 76);
            this.pnlTitulo.TabIndex = 3;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(0, 44);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(1592, 32);
            this.lblSubtitulo.TabIndex = 0;
            this.lblSubtitulo.Text = "Elija un salón, marque los equipos dañados y describa el problema. Cada reporte p" +
    "asa la unidad a mantenimiento.";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1592, 44);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Reportar equipo dañado";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpKpis
            // 
            this.tlpKpis.ColumnCount = 4;
            this.tlpKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKpis.Controls.Add(this.pnlKpiAbiertos, 0, 0);
            this.tlpKpis.Controls.Add(this.pnlKpiAltas, 1, 0);
            this.tlpKpis.Controls.Add(this.pnlKpiAntiguo, 2, 0);
            this.tlpKpis.Controls.Add(this.pnlKpiMes, 3, 0);
            this.tlpKpis.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpKpis.Location = new System.Drawing.Point(24, 84);
            this.tlpKpis.Name = "tlpKpis";
            this.tlpKpis.Padding = new System.Windows.Forms.Padding(0, 0, 0, 14);
            this.tlpKpis.RowCount = 1;
            this.tlpKpis.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpKpis.Size = new System.Drawing.Size(1592, 112);
            this.tlpKpis.TabIndex = 2;
            // 
            // pnlKpiAbiertos
            // 
            this.pnlKpiAbiertos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.pnlKpiAbiertos.Controls.Add(this.lblKpiAbiertosValor);
            this.pnlKpiAbiertos.Controls.Add(this.lblKpiAbiertosDetalle);
            this.pnlKpiAbiertos.Controls.Add(this.lblKpiAbiertosTitulo);
            this.pnlKpiAbiertos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiAbiertos.Location = new System.Drawing.Point(0, 0);
            this.pnlKpiAbiertos.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.pnlKpiAbiertos.Name = "pnlKpiAbiertos";
            this.pnlKpiAbiertos.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.pnlKpiAbiertos.Size = new System.Drawing.Size(386, 98);
            this.pnlKpiAbiertos.TabIndex = 0;
            // 
            // lblKpiAbiertosValor
            // 
            this.lblKpiAbiertosValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKpiAbiertosValor.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblKpiAbiertosValor.ForeColor = System.Drawing.Color.White;
            this.lblKpiAbiertosValor.Location = new System.Drawing.Point(16, 30);
            this.lblKpiAbiertosValor.Name = "lblKpiAbiertosValor";
            this.lblKpiAbiertosValor.Size = new System.Drawing.Size(354, 40);
            this.lblKpiAbiertosValor.TabIndex = 0;
            this.lblKpiAbiertosValor.Text = "—";
            this.lblKpiAbiertosValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblKpiAbiertosDetalle
            // 
            this.lblKpiAbiertosDetalle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblKpiAbiertosDetalle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKpiAbiertosDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblKpiAbiertosDetalle.Location = new System.Drawing.Point(16, 70);
            this.lblKpiAbiertosDetalle.Name = "lblKpiAbiertosDetalle";
            this.lblKpiAbiertosDetalle.Size = new System.Drawing.Size(354, 20);
            this.lblKpiAbiertosDetalle.TabIndex = 1;
            // 
            // lblKpiAbiertosTitulo
            // 
            this.lblKpiAbiertosTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpiAbiertosTitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiAbiertosTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblKpiAbiertosTitulo.Location = new System.Drawing.Point(16, 8);
            this.lblKpiAbiertosTitulo.Name = "lblKpiAbiertosTitulo";
            this.lblKpiAbiertosTitulo.Size = new System.Drawing.Size(354, 22);
            this.lblKpiAbiertosTitulo.TabIndex = 2;
            this.lblKpiAbiertosTitulo.Text = "REPORTES ABIERTOS";
            // 
            // pnlKpiAltas
            // 
            this.pnlKpiAltas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.pnlKpiAltas.Controls.Add(this.lblKpiAltasValor);
            this.pnlKpiAltas.Controls.Add(this.lblKpiAltasDetalle);
            this.pnlKpiAltas.Controls.Add(this.lblKpiAltasTitulo);
            this.pnlKpiAltas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiAltas.Location = new System.Drawing.Point(398, 0);
            this.pnlKpiAltas.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.pnlKpiAltas.Name = "pnlKpiAltas";
            this.pnlKpiAltas.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.pnlKpiAltas.Size = new System.Drawing.Size(386, 98);
            this.pnlKpiAltas.TabIndex = 1;
            // 
            // lblKpiAltasValor
            // 
            this.lblKpiAltasValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKpiAltasValor.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblKpiAltasValor.ForeColor = System.Drawing.Color.White;
            this.lblKpiAltasValor.Location = new System.Drawing.Point(16, 30);
            this.lblKpiAltasValor.Name = "lblKpiAltasValor";
            this.lblKpiAltasValor.Size = new System.Drawing.Size(354, 40);
            this.lblKpiAltasValor.TabIndex = 0;
            this.lblKpiAltasValor.Text = "—";
            this.lblKpiAltasValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblKpiAltasDetalle
            // 
            this.lblKpiAltasDetalle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblKpiAltasDetalle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKpiAltasDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblKpiAltasDetalle.Location = new System.Drawing.Point(16, 70);
            this.lblKpiAltasDetalle.Name = "lblKpiAltasDetalle";
            this.lblKpiAltasDetalle.Size = new System.Drawing.Size(354, 20);
            this.lblKpiAltasDetalle.TabIndex = 1;
            // 
            // lblKpiAltasTitulo
            // 
            this.lblKpiAltasTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpiAltasTitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiAltasTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblKpiAltasTitulo.Location = new System.Drawing.Point(16, 8);
            this.lblKpiAltasTitulo.Name = "lblKpiAltasTitulo";
            this.lblKpiAltasTitulo.Size = new System.Drawing.Size(354, 22);
            this.lblKpiAltasTitulo.TabIndex = 2;
            this.lblKpiAltasTitulo.Text = "PRIORIDAD ALTA";
            // 
            // pnlKpiAntiguo
            // 
            this.pnlKpiAntiguo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.pnlKpiAntiguo.Controls.Add(this.lblKpiAntiguoValor);
            this.pnlKpiAntiguo.Controls.Add(this.lblKpiAntiguoDetalle);
            this.pnlKpiAntiguo.Controls.Add(this.lblKpiAntiguoTitulo);
            this.pnlKpiAntiguo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiAntiguo.Location = new System.Drawing.Point(796, 0);
            this.pnlKpiAntiguo.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.pnlKpiAntiguo.Name = "pnlKpiAntiguo";
            this.pnlKpiAntiguo.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.pnlKpiAntiguo.Size = new System.Drawing.Size(386, 98);
            this.pnlKpiAntiguo.TabIndex = 2;
            // 
            // lblKpiAntiguoValor
            // 
            this.lblKpiAntiguoValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKpiAntiguoValor.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblKpiAntiguoValor.ForeColor = System.Drawing.Color.White;
            this.lblKpiAntiguoValor.Location = new System.Drawing.Point(16, 30);
            this.lblKpiAntiguoValor.Name = "lblKpiAntiguoValor";
            this.lblKpiAntiguoValor.Size = new System.Drawing.Size(354, 40);
            this.lblKpiAntiguoValor.TabIndex = 0;
            this.lblKpiAntiguoValor.Text = "—";
            this.lblKpiAntiguoValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblKpiAntiguoDetalle
            // 
            this.lblKpiAntiguoDetalle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblKpiAntiguoDetalle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKpiAntiguoDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblKpiAntiguoDetalle.Location = new System.Drawing.Point(16, 70);
            this.lblKpiAntiguoDetalle.Name = "lblKpiAntiguoDetalle";
            this.lblKpiAntiguoDetalle.Size = new System.Drawing.Size(354, 20);
            this.lblKpiAntiguoDetalle.TabIndex = 1;
            // 
            // lblKpiAntiguoTitulo
            // 
            this.lblKpiAntiguoTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpiAntiguoTitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiAntiguoTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblKpiAntiguoTitulo.Location = new System.Drawing.Point(16, 8);
            this.lblKpiAntiguoTitulo.Name = "lblKpiAntiguoTitulo";
            this.lblKpiAntiguoTitulo.Size = new System.Drawing.Size(354, 22);
            this.lblKpiAntiguoTitulo.TabIndex = 2;
            this.lblKpiAntiguoTitulo.Text = "MÁS ANTIGUO";
            // 
            // pnlKpiMes
            // 
            this.pnlKpiMes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.pnlKpiMes.Controls.Add(this.lblKpiMesValor);
            this.pnlKpiMes.Controls.Add(this.lblKpiMesDetalle);
            this.pnlKpiMes.Controls.Add(this.lblKpiMesTitulo);
            this.pnlKpiMes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiMes.Location = new System.Drawing.Point(1194, 0);
            this.pnlKpiMes.Margin = new System.Windows.Forms.Padding(0);
            this.pnlKpiMes.Name = "pnlKpiMes";
            this.pnlKpiMes.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.pnlKpiMes.Size = new System.Drawing.Size(398, 98);
            this.pnlKpiMes.TabIndex = 3;
            // 
            // lblKpiMesValor
            // 
            this.lblKpiMesValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKpiMesValor.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblKpiMesValor.ForeColor = System.Drawing.Color.White;
            this.lblKpiMesValor.Location = new System.Drawing.Point(16, 30);
            this.lblKpiMesValor.Name = "lblKpiMesValor";
            this.lblKpiMesValor.Size = new System.Drawing.Size(366, 40);
            this.lblKpiMesValor.TabIndex = 0;
            this.lblKpiMesValor.Text = "—";
            this.lblKpiMesValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblKpiMesDetalle
            // 
            this.lblKpiMesDetalle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblKpiMesDetalle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKpiMesDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblKpiMesDetalle.Location = new System.Drawing.Point(16, 70);
            this.lblKpiMesDetalle.Name = "lblKpiMesDetalle";
            this.lblKpiMesDetalle.Size = new System.Drawing.Size(366, 20);
            this.lblKpiMesDetalle.TabIndex = 1;
            // 
            // lblKpiMesTitulo
            // 
            this.lblKpiMesTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpiMesTitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiMesTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblKpiMesTitulo.Location = new System.Drawing.Point(16, 8);
            this.lblKpiMesTitulo.Name = "lblKpiMesTitulo";
            this.lblKpiMesTitulo.Size = new System.Drawing.Size(366, 22);
            this.lblKpiMesTitulo.TabIndex = 2;
            this.lblKpiMesTitulo.Text = "CERRADOS ESTE MES";
            // 
            // pnlIzq
            // 
            this.pnlIzq.Controls.Add(this.cardNuevo);
            this.pnlIzq.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlIzq.Location = new System.Drawing.Point(24, 196);
            this.pnlIzq.Name = "pnlIzq";
            this.pnlIzq.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.pnlIzq.Size = new System.Drawing.Size(440, 524);
            this.pnlIzq.TabIndex = 1;
            // 
            // cardNuevo
            // 
            this.cardNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.cardNuevo.Controls.Add(this.tlpNuevo);
            this.cardNuevo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardNuevo.Location = new System.Drawing.Point(0, 0);
            this.cardNuevo.Name = "cardNuevo";
            this.cardNuevo.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.cardNuevo.Size = new System.Drawing.Size(432, 524);
            this.cardNuevo.TabIndex = 0;
            // 
            // tlpNuevo
            // 
            this.tlpNuevo.ColumnCount = 1;
            this.tlpNuevo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNuevo.Controls.Add(this.lblNuevoTitulo, 0, 0);
            this.tlpNuevo.Controls.Add(this.lblSalon, 0, 1);
            this.tlpNuevo.Controls.Add(this.cmbSalon, 0, 2);
            this.tlpNuevo.Controls.Add(this.txtBuscarEquipo, 0, 3);
            this.tlpNuevo.Controls.Add(this.dgvEquipos, 0, 4);
            this.tlpNuevo.Controls.Add(this.pnlSeleccion, 0, 5);
            this.tlpNuevo.Controls.Add(this.lblPrioridad, 0, 6);
            this.tlpNuevo.Controls.Add(this.cmbPrioridad, 0, 7);
            this.tlpNuevo.Controls.Add(this.lblDescripcion, 0, 8);
            this.tlpNuevo.Controls.Add(this.txtDescripcion, 0, 9);
            this.tlpNuevo.Controls.Add(this.flpBotonesNuevo, 0, 10);
            this.tlpNuevo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpNuevo.Location = new System.Drawing.Point(16, 12);
            this.tlpNuevo.Name = "tlpNuevo";
            this.tlpNuevo.RowCount = 11;
            this.tlpNuevo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpNuevo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlpNuevo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpNuevo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpNuevo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNuevo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpNuevo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlpNuevo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpNuevo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlpNuevo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tlpNuevo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tlpNuevo.Size = new System.Drawing.Size(400, 500);
            this.tlpNuevo.TabIndex = 0;
            // 
            // lblNuevoTitulo
            // 
            this.lblNuevoTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNuevoTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblNuevoTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(204)))), ((int)(((byte)(21)))));
            this.lblNuevoTitulo.Location = new System.Drawing.Point(3, 0);
            this.lblNuevoTitulo.Name = "lblNuevoTitulo";
            this.lblNuevoTitulo.Size = new System.Drawing.Size(394, 34);
            this.lblNuevoTitulo.TabIndex = 0;
            this.lblNuevoTitulo.Text = "NUEVO REPORTE";
            this.lblNuevoTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSalon
            // 
            this.lblSalon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSalon.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSalon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblSalon.Location = new System.Drawing.Point(3, 34);
            this.lblSalon.Name = "lblSalon";
            this.lblSalon.Size = new System.Drawing.Size(394, 24);
            this.lblSalon.TabIndex = 1;
            this.lblSalon.Text = "1. Salón donde está el equipo";
            this.lblSalon.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cmbSalon
            // 
            this.cmbSalon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.cmbSalon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbSalon.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSalon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSalon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSalon.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cmbSalon.ForeColor = System.Drawing.Color.White;
            this.cmbSalon.ItemHeight = 20;
            this.cmbSalon.Location = new System.Drawing.Point(3, 61);
            this.cmbSalon.Name = "cmbSalon";
            this.cmbSalon.Size = new System.Drawing.Size(394, 26);
            this.cmbSalon.TabIndex = 0;
            this.cmbSalon.SelectedIndexChanged += new System.EventHandler(this.cmbSalon_SelectedIndexChanged);
            // 
            // txtBuscarEquipo
            // 
            this.txtBuscarEquipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.txtBuscarEquipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarEquipo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBuscarEquipo.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtBuscarEquipo.ForeColor = System.Drawing.Color.White;
            this.txtBuscarEquipo.Location = new System.Drawing.Point(3, 97);
            this.txtBuscarEquipo.Name = "txtBuscarEquipo";
            this.txtBuscarEquipo.Size = new System.Drawing.Size(394, 31);
            this.txtBuscarEquipo.TabIndex = 1;
            this.txtBuscarEquipo.TextChanged += new System.EventHandler(this.txtBuscarEquipo_TextChanged);
            // 
            // dgvEquipos
            // 
            this.dgvEquipos.AllowUserToAddRows = false;
            this.dgvEquipos.AllowUserToDeleteRows = false;
            this.dgvEquipos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(45)))));
            this.dgvEquipos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEquipos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEquipos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.dgvEquipos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEquipos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvEquipos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEquipos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEquipos.ColumnHeadersHeight = 38;
            this.dgvEquipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(25)))), ((int)(((byte)(33)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEquipos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEquipos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEquipos.EnableHeadersVisualStyles = false;
            this.dgvEquipos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(42)))), ((int)(((byte)(56)))));
            this.dgvEquipos.Location = new System.Drawing.Point(3, 133);
            this.dgvEquipos.MultiSelect = false;
            this.dgvEquipos.Name = "dgvEquipos";
            this.dgvEquipos.ReadOnly = true;
            this.dgvEquipos.RowHeadersVisible = false;
            this.dgvEquipos.RowHeadersWidth = 51;
            this.dgvEquipos.RowTemplate.Height = 34;
            this.dgvEquipos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEquipos.Size = new System.Drawing.Size(394, 114);
            this.dgvEquipos.TabIndex = 2;
            this.dgvEquipos.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvEquipos_CellBeginEdit);
            this.dgvEquipos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEquipos_CellClick);
            this.dgvEquipos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvEquipos_CellFormatting);
            this.dgvEquipos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEquipos_CellValueChanged);
            this.dgvEquipos.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvEquipos_CurrentCellDirtyStateChanged);
            // 
            // pnlSeleccion
            // 
            this.pnlSeleccion.Controls.Add(this.lblSeleccion);
            this.pnlSeleccion.Controls.Add(this.chkTodas);
            this.pnlSeleccion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSeleccion.Location = new System.Drawing.Point(0, 250);
            this.pnlSeleccion.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSeleccion.Name = "pnlSeleccion";
            this.pnlSeleccion.Size = new System.Drawing.Size(400, 30);
            this.pnlSeleccion.TabIndex = 3;
            // 
            // lblSeleccion
            // 
            this.lblSeleccion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSeleccion.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSeleccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(204)))), ((int)(((byte)(21)))));
            this.lblSeleccion.Location = new System.Drawing.Point(180, 0);
            this.lblSeleccion.Name = "lblSeleccion";
            this.lblSeleccion.Size = new System.Drawing.Size(220, 30);
            this.lblSeleccion.TabIndex = 0;
            this.lblSeleccion.Text = "Ninguna seleccionada";
            this.lblSeleccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkTodas
            // 
            this.chkTodas.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkTodas.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkTodas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.chkTodas.Location = new System.Drawing.Point(0, 0);
            this.chkTodas.Name = "chkTodas";
            this.chkTodas.Size = new System.Drawing.Size(180, 30);
            this.chkTodas.TabIndex = 3;
            this.chkTodas.Text = "Seleccionar todas";
            this.chkTodas.UseVisualStyleBackColor = true;
            this.chkTodas.CheckedChanged += new System.EventHandler(this.chkTodas_CheckedChanged);
            // 
            // lblPrioridad
            // 
            this.lblPrioridad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPrioridad.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPrioridad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblPrioridad.Location = new System.Drawing.Point(3, 280);
            this.lblPrioridad.Name = "lblPrioridad";
            this.lblPrioridad.Size = new System.Drawing.Size(394, 24);
            this.lblPrioridad.TabIndex = 4;
            this.lblPrioridad.Text = "2. Prioridad";
            this.lblPrioridad.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cmbPrioridad
            // 
            this.cmbPrioridad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.cmbPrioridad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbPrioridad.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPrioridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrioridad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPrioridad.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cmbPrioridad.ForeColor = System.Drawing.Color.White;
            this.cmbPrioridad.ItemHeight = 20;
            this.cmbPrioridad.Location = new System.Drawing.Point(3, 307);
            this.cmbPrioridad.Name = "cmbPrioridad";
            this.cmbPrioridad.Size = new System.Drawing.Size(394, 26);
            this.cmbPrioridad.TabIndex = 4;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblDescripcion.Location = new System.Drawing.Point(3, 340);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(394, 24);
            this.lblDescripcion.TabIndex = 5;
            this.lblDescripcion.Text = "3. Descripción del daño  (0/500)";
            this.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtDescripcion.ForeColor = System.Drawing.Color.White;
            this.txtDescripcion.Location = new System.Drawing.Point(3, 367);
            this.txtDescripcion.MaxLength = 500;
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(394, 78);
            this.txtDescripcion.TabIndex = 5;
            this.txtDescripcion.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
            // 
            // flpBotonesNuevo
            // 
            this.flpBotonesNuevo.Controls.Add(this.btnReportar);
            this.flpBotonesNuevo.Controls.Add(this.btnLimpiar);
            this.flpBotonesNuevo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpBotonesNuevo.Location = new System.Drawing.Point(0, 448);
            this.flpBotonesNuevo.Margin = new System.Windows.Forms.Padding(0);
            this.flpBotonesNuevo.Name = "flpBotonesNuevo";
            this.flpBotonesNuevo.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.flpBotonesNuevo.Size = new System.Drawing.Size(400, 52);
            this.flpBotonesNuevo.TabIndex = 6;
            // 
            // btnReportar
            // 
            this.btnReportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(204)))), ((int)(((byte)(21)))));
            this.btnReportar.FlatAppearance.BorderSize = 0;
            this.btnReportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnReportar.ForeColor = System.Drawing.Color.Black;
            this.btnReportar.Location = new System.Drawing.Point(0, 10);
            this.btnReportar.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnReportar.Name = "btnReportar";
            this.btnReportar.Size = new System.Drawing.Size(220, 38);
            this.btnReportar.TabIndex = 6;
            this.btnReportar.Text = "Reportar daño";
            this.btnReportar.UseVisualStyleBackColor = false;
            this.btnReportar.Click += new System.EventHandler(this.btnReportar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(80)))));
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(230, 10);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(0);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(110, 38);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // pnlDer
            // 
            this.pnlDer.Controls.Add(this.cardLista);
            this.pnlDer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDer.Location = new System.Drawing.Point(464, 196);
            this.pnlDer.Name = "pnlDer";
            this.pnlDer.Size = new System.Drawing.Size(1152, 524);
            this.pnlDer.TabIndex = 0;
            // 
            // cardLista
            // 
            this.cardLista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.cardLista.Controls.Add(this.dgvReportes);
            this.cardLista.Controls.Add(this.pnlDetalle);
            this.cardLista.Controls.Add(this.pnlAcciones);
            this.cardLista.Controls.Add(this.pnlFiltros);
            this.cardLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardLista.Location = new System.Drawing.Point(0, 0);
            this.cardLista.Name = "cardLista";
            this.cardLista.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.cardLista.Size = new System.Drawing.Size(1152, 524);
            this.cardLista.TabIndex = 0;
            // 
            // dgvReportes
            // 
            this.dgvReportes.AllowUserToAddRows = false;
            this.dgvReportes.AllowUserToDeleteRows = false;
            this.dgvReportes.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(45)))));
            this.dgvReportes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvReportes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReportes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.dgvReportes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReportes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvReportes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReportes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvReportes.ColumnHeadersHeight = 38;
            this.dgvReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(25)))), ((int)(((byte)(33)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReportes.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvReportes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReportes.EnableHeadersVisualStyles = false;
            this.dgvReportes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(42)))), ((int)(((byte)(56)))));
            this.dgvReportes.Location = new System.Drawing.Point(16, 146);
            this.dgvReportes.MultiSelect = false;
            this.dgvReportes.Name = "dgvReportes";
            this.dgvReportes.ReadOnly = true;
            this.dgvReportes.RowHeadersVisible = false;
            this.dgvReportes.RowHeadersWidth = 51;
            this.dgvReportes.RowTemplate.Height = 34;
            this.dgvReportes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReportes.Size = new System.Drawing.Size(1120, 138);
            this.dgvReportes.TabIndex = 10;
            this.dgvReportes.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvReportes_CellFormatting);
            this.dgvReportes.SelectionChanged += new System.EventHandler(this.dgvReportes_SelectionChanged);
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.pnlDetalle.Controls.Add(this.txtDetalle);
            this.pnlDetalle.Controls.Add(this.lblDetalleTitulo);
            this.pnlDetalle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDetalle.Location = new System.Drawing.Point(16, 284);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Padding = new System.Windows.Forms.Padding(14, 8, 14, 8);
            this.pnlDetalle.Size = new System.Drawing.Size(1120, 170);
            this.pnlDetalle.TabIndex = 11;
            // 
            // txtDetalle
            // 
            this.txtDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.txtDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetalle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(225)))), ((int)(((byte)(235)))));
            this.txtDetalle.Location = new System.Drawing.Point(14, 34);
            this.txtDetalle.Multiline = true;
            this.txtDetalle.Name = "txtDetalle";
            this.txtDetalle.ReadOnly = true;
            this.txtDetalle.Size = new System.Drawing.Size(1092, 128);
            this.txtDetalle.TabIndex = 0;
            this.txtDetalle.TabStop = false;
            // 
            // lblDetalleTitulo
            // 
            this.lblDetalleTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDetalleTitulo.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblDetalleTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(204)))), ((int)(((byte)(21)))));
            this.lblDetalleTitulo.Location = new System.Drawing.Point(14, 8);
            this.lblDetalleTitulo.Name = "lblDetalleTitulo";
            this.lblDetalleTitulo.Size = new System.Drawing.Size(1092, 26);
            this.lblDetalleTitulo.TabIndex = 1;
            this.lblDetalleTitulo.Text = "Detalle del reporte";
            this.lblDetalleTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlAcciones
            // 
            this.pnlAcciones.Controls.Add(this.flpAcciones);
            this.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAcciones.Location = new System.Drawing.Point(16, 454);
            this.pnlAcciones.Name = "pnlAcciones";
            this.pnlAcciones.Size = new System.Drawing.Size(1120, 58);
            this.pnlAcciones.TabIndex = 12;
            // 
            // flpAcciones
            // 
            this.flpAcciones.Controls.Add(this.btnResolver);
            this.flpAcciones.Controls.Add(this.btnBaja);
            this.flpAcciones.Controls.Add(this.btnPrioridad);
            this.flpAcciones.Controls.Add(this.btnActualizar);
            this.flpAcciones.Controls.Add(this.lblAvisoAdmin);
            this.flpAcciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpAcciones.Location = new System.Drawing.Point(0, 0);
            this.flpAcciones.Name = "flpAcciones";
            this.flpAcciones.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.flpAcciones.Size = new System.Drawing.Size(1120, 58);
            this.flpAcciones.TabIndex = 0;
            this.flpAcciones.WrapContents = false;
            // 
            // btnResolver
            // 
            this.btnResolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(204)))), ((int)(((byte)(21)))));
            this.btnResolver.FlatAppearance.BorderSize = 0;
            this.btnResolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResolver.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnResolver.ForeColor = System.Drawing.Color.Black;
            this.btnResolver.Location = new System.Drawing.Point(0, 10);
            this.btnResolver.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnResolver.Name = "btnResolver";
            this.btnResolver.Size = new System.Drawing.Size(170, 38);
            this.btnResolver.TabIndex = 11;
            this.btnResolver.Text = "Marcar reparado";
            this.btnResolver.UseVisualStyleBackColor = false;
            this.btnResolver.Click += new System.EventHandler(this.btnResolver_Click);
            // 
            // btnBaja
            // 
            this.btnBaja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnBaja.FlatAppearance.BorderSize = 0;
            this.btnBaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaja.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnBaja.ForeColor = System.Drawing.Color.White;
            this.btnBaja.Location = new System.Drawing.Point(180, 10);
            this.btnBaja.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(130, 38);
            this.btnBaja.TabIndex = 12;
            this.btnBaja.Text = "Dar de baja";
            this.btnBaja.UseVisualStyleBackColor = false;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // btnPrioridad
            // 
            this.btnPrioridad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(80)))));
            this.btnPrioridad.FlatAppearance.BorderSize = 0;
            this.btnPrioridad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrioridad.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnPrioridad.ForeColor = System.Drawing.Color.White;
            this.btnPrioridad.Location = new System.Drawing.Point(320, 10);
            this.btnPrioridad.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnPrioridad.Name = "btnPrioridad";
            this.btnPrioridad.Size = new System.Drawing.Size(170, 38);
            this.btnPrioridad.TabIndex = 13;
            this.btnPrioridad.Text = "Cambiar prioridad ▾";
            this.btnPrioridad.UseVisualStyleBackColor = false;
            this.btnPrioridad.Click += new System.EventHandler(this.btnPrioridad_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(80)))));
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(500, 10);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(110, 38);
            this.btnActualizar.TabIndex = 14;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // lblAvisoAdmin
            // 
            this.lblAvisoAdmin.AutoSize = true;
            this.lblAvisoAdmin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblAvisoAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblAvisoAdmin.Location = new System.Drawing.Point(630, 20);
            this.lblAvisoAdmin.Margin = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.lblAvisoAdmin.Name = "lblAvisoAdmin";
            this.lblAvisoAdmin.Size = new System.Drawing.Size(435, 20);
            this.lblAvisoAdmin.TabIndex = 15;
            this.lblAvisoAdmin.Text = "Solo el administrador puede cerrar reportes o cambiar su prioridad.";
            this.lblAvisoAdmin.Visible = false;
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.Controls.Add(this.tlpFiltros);
            this.pnlFiltros.Controls.Add(this.lblListaTitulo);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Location = new System.Drawing.Point(16, 12);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(1120, 134);
            this.pnlFiltros.TabIndex = 13;
            // 
            // tlpFiltros
            // 
            this.tlpFiltros.ColumnCount = 4;
            this.tlpFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26F));
            this.tlpFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38F));
            this.tlpFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36F));
            this.tlpFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 149F));
            this.tlpFiltros.Controls.Add(this.cmbFiltroEstado, 0, 0);
            this.tlpFiltros.Controls.Add(this.cmbFiltroSalon, 1, 0);
            this.tlpFiltros.Controls.Add(this.cmbFiltroPrioridad, 2, 0);
            this.tlpFiltros.Controls.Add(this.btnExportar, 3, 0);
            this.tlpFiltros.Controls.Add(this.txtBuscar, 0, 1);
            this.tlpFiltros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFiltros.Location = new System.Drawing.Point(0, 36);
            this.tlpFiltros.Name = "tlpFiltros";
            this.tlpFiltros.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.tlpFiltros.RowCount = 2;
            this.tlpFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tlpFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpFiltros.Size = new System.Drawing.Size(1120, 98);
            this.tlpFiltros.TabIndex = 0;
            // 
            // cmbFiltroEstado
            // 
            this.cmbFiltroEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.cmbFiltroEstado.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbFiltroEstado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFiltroEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbFiltroEstado.ForeColor = System.Drawing.Color.White;
            this.cmbFiltroEstado.ItemHeight = 20;
            this.cmbFiltroEstado.Location = new System.Drawing.Point(0, 0);
            this.cmbFiltroEstado.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.cmbFiltroEstado.Name = "cmbFiltroEstado";
            this.cmbFiltroEstado.Size = new System.Drawing.Size(242, 26);
            this.cmbFiltroEstado.TabIndex = 0;
            this.cmbFiltroEstado.SelectedIndexChanged += new System.EventHandler(this.Filtro_Changed);
            // 
            // cmbFiltroSalon
            // 
            this.cmbFiltroSalon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.cmbFiltroSalon.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbFiltroSalon.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbFiltroSalon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroSalon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFiltroSalon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbFiltroSalon.ForeColor = System.Drawing.Color.White;
            this.cmbFiltroSalon.ItemHeight = 20;
            this.cmbFiltroSalon.Location = new System.Drawing.Point(252, 0);
            this.cmbFiltroSalon.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.cmbFiltroSalon.Name = "cmbFiltroSalon";
            this.cmbFiltroSalon.Size = new System.Drawing.Size(358, 26);
            this.cmbFiltroSalon.TabIndex = 1;
            this.cmbFiltroSalon.SelectedIndexChanged += new System.EventHandler(this.Filtro_Changed);
            // 
            // cmbFiltroPrioridad
            // 
            this.cmbFiltroPrioridad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.cmbFiltroPrioridad.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbFiltroPrioridad.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbFiltroPrioridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroPrioridad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFiltroPrioridad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbFiltroPrioridad.ForeColor = System.Drawing.Color.White;
            this.cmbFiltroPrioridad.ItemHeight = 20;
            this.cmbFiltroPrioridad.Location = new System.Drawing.Point(620, 0);
            this.cmbFiltroPrioridad.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.cmbFiltroPrioridad.Name = "cmbFiltroPrioridad";
            this.cmbFiltroPrioridad.Size = new System.Drawing.Size(339, 26);
            this.cmbFiltroPrioridad.TabIndex = 2;
            this.cmbFiltroPrioridad.SelectedIndexChanged += new System.EventHandler(this.Filtro_Changed);
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(80)))));
            this.btnExportar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExportar.FlatAppearance.BorderSize = 0;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Location = new System.Drawing.Point(969, 0);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(0);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(151, 30);
            this.btnExportar.TabIndex = 4;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tlpFiltros.SetColumnSpan(this.txtBuscar, 4);
            this.txtBuscar.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtBuscar.ForeColor = System.Drawing.Color.White;
            this.txtBuscar.Location = new System.Drawing.Point(0, 46);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(0);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(1120, 31);
            this.txtBuscar.TabIndex = 3;
            this.txtBuscar.TextChanged += new System.EventHandler(this.Filtro_Changed);
            // 
            // lblListaTitulo
            // 
            this.lblListaTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblListaTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblListaTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(204)))), ((int)(((byte)(21)))));
            this.lblListaTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblListaTitulo.Name = "lblListaTitulo";
            this.lblListaTitulo.Size = new System.Drawing.Size(1120, 36);
            this.lblListaTitulo.TabIndex = 1;
            this.lblListaTitulo.Text = "REPORTES";
            this.lblListaTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmReportarDaño
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(1640, 744);
            this.Controls.Add(this.pnlDer);
            this.Controls.Add(this.pnlIzq);
            this.Controls.Add(this.tlpKpis);
            this.Controls.Add(this.pnlTitulo);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmReportarDaño";
            this.Padding = new System.Windows.Forms.Padding(24, 8, 24, 24);
            this.Text = "frmReportarDaño";
            this.Load += new System.EventHandler(this.frmReportarDaño_Load);
            this.pnlTitulo.ResumeLayout(false);
            this.tlpKpis.ResumeLayout(false);
            this.pnlKpiAbiertos.ResumeLayout(false);
            this.pnlKpiAltas.ResumeLayout(false);
            this.pnlKpiAntiguo.ResumeLayout(false);
            this.pnlKpiMes.ResumeLayout(false);
            this.pnlIzq.ResumeLayout(false);
            this.cardNuevo.ResumeLayout(false);
            this.tlpNuevo.ResumeLayout(false);
            this.tlpNuevo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).EndInit();
            this.pnlSeleccion.ResumeLayout(false);
            this.flpBotonesNuevo.ResumeLayout(false);
            this.pnlDer.ResumeLayout(false);
            this.cardLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            this.pnlDetalle.PerformLayout();
            this.pnlAcciones.ResumeLayout(false);
            this.flpAcciones.ResumeLayout(false);
            this.flpAcciones.PerformLayout();
            this.pnlFiltros.ResumeLayout(false);
            this.tlpFiltros.ResumeLayout(false);
            this.tlpFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        // Encabezado y tarjetas de resumen
        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.TableLayoutPanel tlpKpis;
        private System.Windows.Forms.Panel pnlKpiAbiertos;
        private System.Windows.Forms.Label lblKpiAbiertosValor;
        private System.Windows.Forms.Label lblKpiAbiertosDetalle;
        private System.Windows.Forms.Label lblKpiAbiertosTitulo;
        private System.Windows.Forms.Panel pnlKpiAltas;
        private System.Windows.Forms.Label lblKpiAltasValor;
        private System.Windows.Forms.Label lblKpiAltasDetalle;
        private System.Windows.Forms.Label lblKpiAltasTitulo;
        private System.Windows.Forms.Panel pnlKpiAntiguo;
        private System.Windows.Forms.Label lblKpiAntiguoValor;
        private System.Windows.Forms.Label lblKpiAntiguoDetalle;
        private System.Windows.Forms.Label lblKpiAntiguoTitulo;
        private System.Windows.Forms.Panel pnlKpiMes;
        private System.Windows.Forms.Label lblKpiMesValor;
        private System.Windows.Forms.Label lblKpiMesDetalle;
        private System.Windows.Forms.Label lblKpiMesTitulo;
        // Panel izquierdo: nuevo reporte
        private System.Windows.Forms.Panel pnlIzq;
        private System.Windows.Forms.Panel cardNuevo;
        private System.Windows.Forms.TableLayoutPanel tlpNuevo;
        private System.Windows.Forms.Label lblNuevoTitulo;
        private System.Windows.Forms.Label lblSalon;
        private Vistass.ComboOscuro cmbSalon;
        private System.Windows.Forms.TextBox txtBuscarEquipo;
        private Vistass.GridOscuro dgvEquipos;
        private System.Windows.Forms.Panel pnlSeleccion;
        private System.Windows.Forms.Label lblSeleccion;
        private System.Windows.Forms.CheckBox chkTodas;
        private System.Windows.Forms.Label lblPrioridad;
        private Vistass.ComboOscuro cmbPrioridad;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.FlowLayoutPanel flpBotonesNuevo;
        private System.Windows.Forms.Button btnReportar;
        private System.Windows.Forms.Button btnLimpiar;
        // Panel derecho: lista de reportes
        private System.Windows.Forms.Panel pnlDer;
        private System.Windows.Forms.Panel cardLista;
        private Vistass.GridOscuro dgvReportes;
        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.TextBox txtDetalle;
        private System.Windows.Forms.Label lblDetalleTitulo;
        private System.Windows.Forms.Panel pnlAcciones;
        private System.Windows.Forms.FlowLayoutPanel flpAcciones;
        private System.Windows.Forms.Button btnResolver;
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.Button btnPrioridad;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label lblAvisoAdmin;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.TableLayoutPanel tlpFiltros;
        private Vistass.ComboOscuro cmbFiltroEstado;
        private Vistass.ComboOscuro cmbFiltroSalon;
        private Vistass.ComboOscuro cmbFiltroPrioridad;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Label lblListaTitulo;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}