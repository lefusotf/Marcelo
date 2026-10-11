namespace Vistass
{
    partial class frmEstructuraSalarial
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
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.lblSecMontos = new System.Windows.Forms.Label();
            this.lblSalarioBase = new System.Windows.Forms.Label();
            this.txtSalarioBase = new System.Windows.Forms.TextBox();
            this.lblBono = new System.Windows.Forms.Label();
            this.txtBono = new System.Windows.Forms.TextBox();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.pnlNeto = new System.Windows.Forms.Panel();
            this.lblNetoCap = new System.Windows.Forms.Label();
            this.lblNeto = new System.Windows.Forms.Label();
            this.lblDesglose = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.pnlPie = new System.Windows.Forms.Panel();
            this.lblObligatorios = new System.Windows.Forms.Label();
            this.btnGuardar = new Vistass.BotonTema();
            this.btnVolver = new Vistass.BotonTema();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.button1 = new Vistass.BotonTema();
            this.button2 = new Vistass.BotonTema();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new Vistass.BotonTema();
            this.label7 = new System.Windows.Forms.Label();
            this.button4 = new Vistass.BotonTema();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pnlDatos.SuspendLayout();
            this.pnlNeto.SuspendLayout();
            this.pnlPie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTituloForm
            // 
            this.lblTituloForm.AutoSize = true;
            this.lblTituloForm.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloForm.ForeColor = System.Drawing.Color.White;
            this.lblTituloForm.Location = new System.Drawing.Point(41, 9);
            this.lblTituloForm.Name = "lblTituloForm";
            this.lblTituloForm.Size = new System.Drawing.Size(271, 31);
            this.lblTituloForm.TabIndex = 0;
            this.lblTituloForm.Text = "Nueva estructura salarial";
            // 
            // lblSubtituloForm
            // 
            this.lblSubtituloForm.AutoSize = true;
            this.lblSubtituloForm.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtituloForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblSubtituloForm.Location = new System.Drawing.Point(26, 46);
            this.lblSubtituloForm.Name = "lblSubtituloForm";
            this.lblSubtituloForm.Size = new System.Drawing.Size(384, 23);
            this.lblSubtituloForm.TabIndex = 1;
            this.lblSubtituloForm.Text = "Defina el salario que se asignará a los empleados";
            // 
            // pnlDatos
            // 
            this.pnlDatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.pnlDatos.Controls.Add(this.lblSecMontos);
            this.pnlDatos.Controls.Add(this.lblSalarioBase);
            this.pnlDatos.Controls.Add(this.txtSalarioBase);
            this.pnlDatos.Controls.Add(this.lblBono);
            this.pnlDatos.Controls.Add(this.txtBono);
            this.pnlDatos.Controls.Add(this.lblDescuento);
            this.pnlDatos.Controls.Add(this.txtDescuento);
            this.pnlDatos.Controls.Add(this.pnlNeto);
            this.pnlDatos.Controls.Add(this.lblInfo);
            this.pnlDatos.Location = new System.Drawing.Point(24, 80);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(424, 290);
            this.pnlDatos.TabIndex = 2;
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
            this.txtSalarioBase.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalarioBase.Location = new System.Drawing.Point(24, 76);
            this.txtSalarioBase.MaxLength = 10;
            this.txtSalarioBase.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.txtSalarioBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSalarioBase.ForeColor = System.Drawing.Color.FromArgb(240, 244, 252);
            this.txtSalarioBase.Name = "txtSalarioBase";
            this.txtSalarioBase.Size = new System.Drawing.Size(112, 30);
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
            this.txtBono.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBono.Location = new System.Drawing.Point(156, 76);
            this.txtBono.MaxLength = 10;
            this.txtBono.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.txtBono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBono.ForeColor = System.Drawing.Color.FromArgb(240, 244, 252);
            this.txtBono.Name = "txtBono";
            this.txtBono.Size = new System.Drawing.Size(112, 30);
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
            this.txtDescuento.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescuento.Location = new System.Drawing.Point(288, 76);
            this.txtDescuento.MaxLength = 10;
            this.txtDescuento.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.txtDescuento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescuento.ForeColor = System.Drawing.Color.FromArgb(240, 244, 252);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(112, 30);
            this.txtDescuento.TabIndex = 2;
            this.txtDescuento.Text = "0.00";
            this.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDescuento.TextChanged += new System.EventHandler(this.txtMonto_TextChanged);
            this.txtDescuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
            // 
            // pnlNeto
            // 
            this.pnlNeto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.pnlNeto.Controls.Add(this.label1);
            this.pnlNeto.Controls.Add(this.button2);
            this.pnlNeto.Controls.Add(this.lblNetoCap);
            this.pnlNeto.Controls.Add(this.button1);
            this.pnlNeto.Controls.Add(this.lblNeto);
            this.pnlNeto.Controls.Add(this.lblDesglose);
            this.pnlNeto.Location = new System.Drawing.Point(24, 128);
            this.pnlNeto.Name = "pnlNeto";
            this.pnlNeto.Size = new System.Drawing.Size(376, 100);
            this.pnlNeto.TabIndex = 7;
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
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblInfo.Location = new System.Drawing.Point(24, 238);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(376, 40);
            this.lblInfo.TabIndex = 8;
            // 
            // pnlPie
            // 
            this.pnlPie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.pnlPie.Controls.Add(this.lblObligatorios);
            this.pnlPie.Controls.Add(this.btnGuardar);
            this.pnlPie.Controls.Add(this.panel1);
            this.pnlPie.Controls.Add(this.btnVolver);
            this.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPie.Location = new System.Drawing.Point(0, 386);
            this.pnlPie.Name = "pnlPie";
            this.pnlPie.Size = new System.Drawing.Size(472, 62);
            this.pnlPie.TabIndex = 3;
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
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(188, 13);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(150, 36);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar estructura";
            this.btnGuardar.Tipo = Vistass.TipoBoton.Principal;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVolver.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnVolver.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnVolver.Location = new System.Drawing.Point(348, 13);
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
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(309, 197);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 36);
            this.button1.TabIndex = 2;
            this.button1.Text = "Cancelar";
            this.button1.Tipo = Vistass.TipoBoton.Secundario;
            this.button1.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(149, 197);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 36);
            this.button2.TabIndex = 1;
            this.button2.Text = "Guardar estructura";
            this.button2.Tipo = Vistass.TipoBoton.Principal;
            this.button2.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.label1.Location = new System.Drawing.Point(-13, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "* Campo obligatorio";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(30, -303);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(424, 290);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(204)))), ((int)(((byte)(21)))));
            this.label2.Location = new System.Drawing.Point(24, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "MONTOS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.label3.Location = new System.Drawing.Point(24, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "Salario base *";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.textBox1.Location = new System.Drawing.Point(24, 76);
            this.textBox1.MaxLength = 10;
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(240, 244, 252);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(112, 32);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox1.TextChanged += new System.EventHandler(this.txtMonto_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.label4.Location = new System.Drawing.Point(156, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Bono";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.textBox2.Location = new System.Drawing.Point(156, 76);
            this.textBox2.MaxLength = 10;
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.ForeColor = System.Drawing.Color.FromArgb(240, 244, 252);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(112, 32);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "0.00";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox2.TextChanged += new System.EventHandler(this.txtMonto_TextChanged);
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.label5.Location = new System.Drawing.Point(288, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 21);
            this.label5.TabIndex = 5;
            this.label5.Text = "Descuento";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.textBox3.Location = new System.Drawing.Point(288, 76);
            this.textBox3.MaxLength = 10;
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(38, 42, 58);
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.ForeColor = System.Drawing.Color.FromArgb(240, 244, 252);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(112, 32);
            this.textBox3.TabIndex = 2;
            this.textBox3.Text = "0.00";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox3.TextChanged += new System.EventHandler(this.txtMonto_TextChanged);
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Location = new System.Drawing.Point(24, 128);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(376, 100);
            this.panel2.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.label6.Location = new System.Drawing.Point(-13, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "* Campo obligatorio";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(149, 197);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 36);
            this.button3.TabIndex = 1;
            this.button3.Text = "Guardar estructura";
            this.button3.Tipo = Vistass.TipoBoton.Principal;
            this.button3.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.label7.Location = new System.Drawing.Point(16, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 21);
            this.label7.TabIndex = 0;
            this.label7.Text = "SALARIO NETO";
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.button4.Location = new System.Drawing.Point(309, 197);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 36);
            this.button4.TabIndex = 2;
            this.button4.Text = "Cancelar";
            this.button4.Tipo = Vistass.TipoBoton.Secundario;
            this.button4.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(204)))), ((int)(((byte)(21)))));
            this.label8.Location = new System.Drawing.Point(12, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 54);
            this.label8.TabIndex = 1;
            this.label8.Text = "$ 0.00";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.label9.Location = new System.Drawing.Point(16, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(286, 20);
            this.label9.TabIndex = 2;
            this.label9.Text = "Base 0.00  +  Bono 0.00  -  Descuento 0.00";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.label10.Location = new System.Drawing.Point(24, 238);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(376, 40);
            this.label10.TabIndex = 8;
            // 
            // frmEstructuraSalarial
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.CancelButton = this.btnVolver;
            this.ClientSize = new System.Drawing.Size(472, 448);
            this.Controls.Add(this.lblTituloForm);
            this.Controls.Add(this.lblSubtituloForm);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.pnlPie);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEstructuraSalarial";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Estructura salarial";
            this.Load += new System.EventHandler(this.frmEstructuraSalarial_Load);
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            this.pnlNeto.ResumeLayout(false);
            this.pnlNeto.PerformLayout();
            this.pnlPie.ResumeLayout(false);
            this.pnlPie.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTituloForm;
        private System.Windows.Forms.Label lblSubtituloForm;
        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.Label lblSecMontos;
        private System.Windows.Forms.Label lblSalarioBase;
        private System.Windows.Forms.TextBox txtSalarioBase;
        private System.Windows.Forms.Label lblBono;
        private System.Windows.Forms.TextBox txtBono;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Panel pnlNeto;
        private System.Windows.Forms.Label lblNetoCap;
        private System.Windows.Forms.Label lblNeto;
        private System.Windows.Forms.Label lblDesglose;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Panel pnlPie;
        private System.Windows.Forms.Label lblObligatorios;
        private Vistass.BotonTema btnGuardar;
        private Vistass.BotonTema btnVolver;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label1;
        private Vistass.BotonTema button2;
        private Vistass.BotonTema button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private Vistass.BotonTema button3;
        private System.Windows.Forms.Label label7;
        private Vistass.BotonTema button4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}