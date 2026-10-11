namespace Vistass
{
    partial class frmRegistrarPago
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
            this.lblTituloForm = new System.Windows.Forms.Label();
            this.lblSubtituloForm = new System.Windows.Forms.Label();
            this.pnlPago = new System.Windows.Forms.Panel();
            this.lblSecPago = new System.Windows.Forms.Label();
            this.lblEmpleado = new System.Windows.Forms.Label();
            this.cmbEmpleado = new Vistass.ComboOscuro();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.dtpPeriodo = new Vistass.FechaOscura();
            this.lblEstadoPago = new System.Windows.Forms.Label();
            this.cmbEstadoPago = new Vistass.ComboOscuro();
            this.lblObservacion = new System.Windows.Forms.Label();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.pnlMontos = new System.Windows.Forms.Panel();
            this.lblSecMontos = new System.Windows.Forms.Label();
            this.lblSalarioBase = new System.Windows.Forms.Label();
            this.txtSalarioBase = new System.Windows.Forms.TextBox();
            this.lblBono = new System.Windows.Forms.Label();
            this.txtBono = new System.Windows.Forms.TextBox();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.lblOrigen = new System.Windows.Forms.Label();
            this.lblAusencias = new System.Windows.Forms.Label();
            this.pnlNeto = new System.Windows.Forms.Panel();
            this.lblNetoCap = new System.Windows.Forms.Label();
            this.lblNeto = new System.Windows.Forms.Label();
            this.lblDesglose = new System.Windows.Forms.Label();
            this.pnlPie = new System.Windows.Forms.Panel();
            this.lblObligatorios = new System.Windows.Forms.Label();
            this.btnGuardar = new Vistass.BotonTema();
            this.btnVolver = new Vistass.BotonTema();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlPago.SuspendLayout();
            this.pnlMontos.SuspendLayout();
            this.pnlNeto.SuspendLayout();
            this.pnlPie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTituloForm
            // 
            this.lblTituloForm.AutoSize = true;
            this.lblTituloForm.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTituloForm.ForeColor = System.Drawing.Color.White;
            this.lblTituloForm.Location = new System.Drawing.Point(24, 14);
            this.lblTituloForm.Name = "lblTituloForm";
            this.lblTituloForm.Size = new System.Drawing.Size(207, 37);
            this.lblTituloForm.TabIndex = 0;
            this.lblTituloForm.Text = "Registrar pago";
            // 
            // lblSubtituloForm
            // 
            this.lblSubtituloForm.AutoSize = true;
            this.lblSubtituloForm.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtituloForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblSubtituloForm.Location = new System.Drawing.Point(26, 46);
            this.lblSubtituloForm.Name = "lblSubtituloForm";
            this.lblSubtituloForm.Size = new System.Drawing.Size(427, 23);
            this.lblSubtituloForm.TabIndex = 1;
            this.lblSubtituloForm.Text = "Seleccione al empleado y confirme los montos del mes";
            // 
            // pnlPago
            // 
            this.pnlPago.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.pnlPago.Controls.Add(this.lblSecPago);
            this.pnlPago.Controls.Add(this.lblEmpleado);
            this.pnlPago.Controls.Add(this.cmbEmpleado);
            this.pnlPago.Controls.Add(this.lblPeriodo);
            this.pnlPago.Controls.Add(this.dtpPeriodo);
            this.pnlPago.Controls.Add(this.lblEstadoPago);
            this.pnlPago.Controls.Add(this.cmbEstadoPago);
            this.pnlPago.Controls.Add(this.lblObservacion);
            this.pnlPago.Controls.Add(this.txtObservacion);
            this.pnlPago.Location = new System.Drawing.Point(24, 80);
            this.pnlPago.Name = "pnlPago";
            this.pnlPago.Size = new System.Drawing.Size(432, 300);
            this.pnlPago.TabIndex = 2;
            // 
            // lblSecPago
            // 
            this.lblSecPago.AutoSize = true;
            this.lblSecPago.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSecPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(204)))), ((int)(((byte)(21)))));
            this.lblSecPago.Location = new System.Drawing.Point(24, 16);
            this.lblSecPago.Name = "lblSecPago";
            this.lblSecPago.Size = new System.Drawing.Size(153, 23);
            this.lblSecPago.TabIndex = 0;
            this.lblSecPago.Text = "DATOS DEL PAGO";
            // 
            // lblEmpleado
            // 
            this.lblEmpleado.AutoSize = true;
            this.lblEmpleado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblEmpleado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblEmpleado.Location = new System.Drawing.Point(24, 52);
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.Size = new System.Drawing.Size(90, 21);
            this.lblEmpleado.TabIndex = 1;
            this.lblEmpleado.Text = "Empleado *";
            // 
            // cmbEmpleado
            // 
            this.cmbEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpleado.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbEmpleado.FormattingEnabled = true;
            this.cmbEmpleado.Location = new System.Drawing.Point(24, 76);
            this.cmbEmpleado.Name = "cmbEmpleado";
            this.cmbEmpleado.Size = new System.Drawing.Size(384, 33);
            this.cmbEmpleado.TabIndex = 2;
            this.cmbEmpleado.SelectedIndexChanged += new System.EventHandler(this.cmbEmpleado_SelectedIndexChanged);
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPeriodo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblPeriodo.Location = new System.Drawing.Point(24, 128);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(74, 21);
            this.lblPeriodo.TabIndex = 3;
            this.lblPeriodo.Text = "Período *";
            // 
            // dtpPeriodo
            // 
            this.dtpPeriodo.CustomFormat = "MMMM yyyy";
            this.dtpPeriodo.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dtpPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodo.Location = new System.Drawing.Point(24, 152);
            this.dtpPeriodo.Name = "dtpPeriodo";
            this.dtpPeriodo.ShowUpDown = true;
            this.dtpPeriodo.Size = new System.Drawing.Size(180, 32);
            this.dtpPeriodo.TabIndex = 4;
            // 
            // lblEstadoPago
            // 
            this.lblEstadoPago.AutoSize = true;
            this.lblEstadoPago.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblEstadoPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblEstadoPago.Location = new System.Drawing.Point(228, 128);
            this.lblEstadoPago.Name = "lblEstadoPago";
            this.lblEstadoPago.Size = new System.Drawing.Size(127, 21);
            this.lblEstadoPago.TabIndex = 5;
            this.lblEstadoPago.Text = "Estado de pago *";
            // 
            // cmbEstadoPago
            // 
            this.cmbEstadoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoPago.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbEstadoPago.FormattingEnabled = true;
            this.cmbEstadoPago.Location = new System.Drawing.Point(228, 152);
            this.cmbEstadoPago.Name = "cmbEstadoPago";
            this.cmbEstadoPago.Size = new System.Drawing.Size(180, 33);
            this.cmbEstadoPago.TabIndex = 5;
            // 
            // lblObservacion
            // 
            this.lblObservacion.AutoSize = true;
            this.lblObservacion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblObservacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblObservacion.Location = new System.Drawing.Point(24, 204);
            this.lblObservacion.Name = "lblObservacion";
            this.lblObservacion.Size = new System.Drawing.Size(170, 21);
            this.lblObservacion.TabIndex = 7;
            this.lblObservacion.Text = "Observación (opcional)";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtObservacion.Location = new System.Drawing.Point(24, 228);
            this.txtObservacion.MaxLength = 200;
            this.txtObservacion.Multiline = true;
            this.txtObservacion.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.txtObservacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservacion.ForeColor = System.Drawing.Color.FromArgb(240, 244, 252);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacion.Size = new System.Drawing.Size(384, 44);
            this.txtObservacion.TabIndex = 6;
            // 
            // pnlMontos
            // 
            this.pnlMontos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.pnlMontos.Controls.Add(this.lblSecMontos);
            this.pnlMontos.Controls.Add(this.lblSalarioBase);
            this.pnlMontos.Controls.Add(this.txtSalarioBase);
            this.pnlMontos.Controls.Add(this.lblBono);
            this.pnlMontos.Controls.Add(this.txtBono);
            this.pnlMontos.Controls.Add(this.lblDescuento);
            this.pnlMontos.Controls.Add(this.txtDescuento);
            this.pnlMontos.Controls.Add(this.lblOrigen);
            this.pnlMontos.Controls.Add(this.lblAusencias);
            this.pnlMontos.Controls.Add(this.pnlNeto);
            this.pnlMontos.Location = new System.Drawing.Point(472, 80);
            this.pnlMontos.Name = "pnlMontos";
            this.pnlMontos.Size = new System.Drawing.Size(424, 300);
            this.pnlMontos.TabIndex = 3;
            // 
            // lblSecMontos
            // 
            this.lblSecMontos.AutoSize = true;
            this.lblSecMontos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSecMontos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(204)))), ((int)(((byte)(21)))));
            this.lblSecMontos.Location = new System.Drawing.Point(24, 16);
            this.lblSecMontos.Name = "lblSecMontos";
            this.lblSecMontos.Size = new System.Drawing.Size(84, 23);
            this.lblSecMontos.TabIndex = 0;
            this.lblSecMontos.Text = "MONTOS";
            // 
            // lblSalarioBase
            // 
            this.lblSalarioBase.AutoSize = true;
            this.lblSalarioBase.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSalarioBase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblSalarioBase.Location = new System.Drawing.Point(24, 52);
            this.lblSalarioBase.Name = "lblSalarioBase";
            this.lblSalarioBase.Size = new System.Drawing.Size(105, 21);
            this.lblSalarioBase.TabIndex = 1;
            this.lblSalarioBase.Text = "Salario base *";
            // 
            // txtSalarioBase
            // 
            this.txtSalarioBase.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSalarioBase.Location = new System.Drawing.Point(24, 76);
            this.txtSalarioBase.MaxLength = 10;
            this.txtSalarioBase.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.txtSalarioBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSalarioBase.ForeColor = System.Drawing.Color.FromArgb(240, 244, 252);
            this.txtSalarioBase.Name = "txtSalarioBase";
            this.txtSalarioBase.Size = new System.Drawing.Size(112, 32);
            this.txtSalarioBase.TabIndex = 0;
            this.txtSalarioBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSalarioBase.TextChanged += new System.EventHandler(this.txtMonto_TextChanged);
            this.txtSalarioBase.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
            // 
            // lblBono
            // 
            this.lblBono.AutoSize = true;
            this.lblBono.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblBono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblBono.Location = new System.Drawing.Point(156, 52);
            this.lblBono.Name = "lblBono";
            this.lblBono.Size = new System.Drawing.Size(46, 21);
            this.lblBono.TabIndex = 3;
            this.lblBono.Text = "Bono";
            // 
            // txtBono
            // 
            this.txtBono.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtBono.Location = new System.Drawing.Point(156, 76);
            this.txtBono.MaxLength = 10;
            this.txtBono.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.txtBono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBono.ForeColor = System.Drawing.Color.FromArgb(240, 244, 252);
            this.txtBono.Name = "txtBono";
            this.txtBono.Size = new System.Drawing.Size(112, 32);
            this.txtBono.TabIndex = 1;
            this.txtBono.Text = "0.00";
            this.txtBono.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBono.TextChanged += new System.EventHandler(this.txtMonto_TextChanged);
            this.txtBono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDescuento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblDescuento.Location = new System.Drawing.Point(288, 52);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(83, 21);
            this.lblDescuento.TabIndex = 5;
            this.lblDescuento.Text = "Descuento";
            // 
            // txtDescuento
            // 
            this.txtDescuento.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtDescuento.Location = new System.Drawing.Point(288, 76);
            this.txtDescuento.MaxLength = 10;
            this.txtDescuento.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.txtDescuento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescuento.ForeColor = System.Drawing.Color.FromArgb(240, 244, 252);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(112, 32);
            this.txtDescuento.TabIndex = 2;
            this.txtDescuento.Text = "0.00";
            this.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDescuento.TextChanged += new System.EventHandler(this.txtMonto_TextChanged);
            this.txtDescuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
            // 
            // lblOrigen
            // 
            this.lblOrigen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblOrigen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblOrigen.Location = new System.Drawing.Point(24, 116);
            this.lblOrigen.Name = "lblOrigen";
            this.lblOrigen.Size = new System.Drawing.Size(376, 34);
            this.lblOrigen.TabIndex = 7;
            // 
            // lblAusencias
            // 
            this.lblAusencias.AutoSize = false;
            this.lblAusencias.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAusencias.ForeColor = System.Drawing.Color.FromArgb(140, 150, 170);
            this.lblAusencias.Location = new System.Drawing.Point(24, 148);
            this.lblAusencias.Name = "lblAusencias";
            this.lblAusencias.Size = new System.Drawing.Size(376, 20);
            this.lblAusencias.TabIndex = 9;
            // 
            // pnlNeto
            // 
            this.pnlNeto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.pnlNeto.Controls.Add(this.lblNetoCap);
            this.pnlNeto.Controls.Add(this.lblNeto);
            this.pnlNeto.Controls.Add(this.lblDesglose);
            this.pnlNeto.Location = new System.Drawing.Point(24, 170);
            this.pnlNeto.Name = "pnlNeto";
            this.pnlNeto.Size = new System.Drawing.Size(376, 100);
            this.pnlNeto.TabIndex = 8;
            // 
            // lblNetoCap
            // 
            this.lblNetoCap.AutoSize = true;
            this.lblNetoCap.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNetoCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblNetoCap.Location = new System.Drawing.Point(16, 14);
            this.lblNetoCap.Name = "lblNetoCap";
            this.lblNetoCap.Size = new System.Drawing.Size(122, 21);
            this.lblNetoCap.TabIndex = 0;
            this.lblNetoCap.Text = "SALARIO NETO";
            // 
            // lblNeto
            // 
            this.lblNeto.AutoSize = true;
            this.lblNeto.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblNeto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(204)))), ((int)(((byte)(21)))));
            this.lblNeto.Location = new System.Drawing.Point(12, 30);
            this.lblNeto.Name = "lblNeto";
            this.lblNeto.Size = new System.Drawing.Size(137, 54);
            this.lblNeto.TabIndex = 1;
            this.lblNeto.Text = "$ 0.00";
            // 
            // lblDesglose
            // 
            this.lblDesglose.AutoSize = true;
            this.lblDesglose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDesglose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblDesglose.Location = new System.Drawing.Point(16, 76);
            this.lblDesglose.Name = "lblDesglose";
            this.lblDesglose.Size = new System.Drawing.Size(286, 20);
            this.lblDesglose.TabIndex = 2;
            this.lblDesglose.Text = "Base 0.00  +  Bono 0.00  -  Descuento 0.00";
            // 
            // pnlPie
            // 
            this.pnlPie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.pnlPie.Controls.Add(this.lblObligatorios);
            this.pnlPie.Controls.Add(this.btnGuardar);
            this.pnlPie.Controls.Add(this.btnVolver);
            this.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPie.Location = new System.Drawing.Point(0, 396);
            this.pnlPie.Name = "pnlPie";
            this.pnlPie.Size = new System.Drawing.Size(920, 62);
            this.pnlPie.TabIndex = 4;
            // 
            // lblObligatorios
            // 
            this.lblObligatorios.AutoSize = true;
            this.lblObligatorios.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblObligatorios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblObligatorios.Location = new System.Drawing.Point(26, 22);
            this.lblObligatorios.Name = "lblObligatorios";
            this.lblObligatorios.Size = new System.Drawing.Size(151, 21);
            this.lblObligatorios.TabIndex = 0;
            this.lblObligatorios.Text = "* Campo obligatorio";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.Location = new System.Drawing.Point(636, 13);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(150, 36);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Registrar pago";
            this.btnGuardar.Tipo = Vistass.TipoBoton.Principal;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVolver.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnVolver.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnVolver.Location = new System.Drawing.Point(796, 13);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(100, 36);
            this.btnVolver.TabIndex = 2;
            this.btnVolver.Text = "Cancelar";
            this.btnVolver.Tipo = Vistass.TipoBoton.Secundario;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // frmRegistrarPago
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.CancelButton = this.btnVolver;
            this.ClientSize = new System.Drawing.Size(920, 458);
            this.Controls.Add(this.lblTituloForm);
            this.Controls.Add(this.lblSubtituloForm);
            this.Controls.Add(this.pnlPago);
            this.Controls.Add(this.pnlMontos);
            this.Controls.Add(this.pnlPie);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegistrarPago";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "7";
            this.Load += new System.EventHandler(this.frmRegistrarPago_Load);
            this.pnlPago.ResumeLayout(false);
            this.pnlPago.PerformLayout();
            this.pnlMontos.ResumeLayout(false);
            this.pnlMontos.PerformLayout();
            this.pnlNeto.ResumeLayout(false);
            this.pnlNeto.PerformLayout();
            this.pnlPie.ResumeLayout(false);
            this.pnlPie.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblAusencias;
        private System.Windows.Forms.Label lblTituloForm;
        private System.Windows.Forms.Label lblSubtituloForm;
        private System.Windows.Forms.Panel pnlPago;
        private System.Windows.Forms.Label lblSecPago;
        private System.Windows.Forms.Label lblEmpleado;
        private Vistass.ComboOscuro cmbEmpleado;
        private System.Windows.Forms.Label lblPeriodo;
        private Vistass.FechaOscura dtpPeriodo;
        private System.Windows.Forms.Label lblEstadoPago;
        private Vistass.ComboOscuro cmbEstadoPago;
        private System.Windows.Forms.Label lblObservacion;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Panel pnlMontos;
        private System.Windows.Forms.Label lblSecMontos;
        private System.Windows.Forms.Label lblSalarioBase;
        private System.Windows.Forms.TextBox txtSalarioBase;
        private System.Windows.Forms.Label lblBono;
        private System.Windows.Forms.TextBox txtBono;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Label lblOrigen;
        private System.Windows.Forms.Panel pnlNeto;
        private System.Windows.Forms.Label lblNetoCap;
        private System.Windows.Forms.Label lblNeto;
        private System.Windows.Forms.Label lblDesglose;
        private System.Windows.Forms.Panel pnlPie;
        private System.Windows.Forms.Label lblObligatorios;
        private Vistass.BotonTema btnGuardar;
        private Vistass.BotonTema btnVolver;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}