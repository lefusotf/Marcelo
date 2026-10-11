namespace CentroDeSoporte
{
    partial class frmCentroSoporte
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
            this.pnlScroll = new System.Windows.Forms.Panel();
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.tarjContacto = new System.Windows.Forms.Panel();
            this.lblTituloContacto = new System.Windows.Forms.Label();
            this.lblSubContacto = new System.Windows.Forms.Label();
            this.lblCapTel = new System.Windows.Forms.Label();
            this.lblTelefonoSoporte = new System.Windows.Forms.Label();
            this.lblCapCorreo = new System.Windows.Forms.Label();
            this.lblCorreoContacto = new System.Windows.Forms.Label();
            this.lblCapHorario = new System.Windows.Forms.Label();
            this.lblHorarioSoporte = new System.Windows.Forms.Label();
            this.lblEstadoAtencion = new System.Windows.Forms.Label();
            this.pnlSepContacto = new System.Windows.Forms.Panel();
            this.lblTituloConsejos = new System.Windows.Forms.Label();
            this.lblConsejos = new System.Windows.Forms.Label();
            this.tarjReporte = new System.Windows.Forms.Panel();
            this.lblTituloReporte = new System.Windows.Forms.Label();
            this.lblSubReporte = new System.Windows.Forms.Label();
            this.lblCategoriaProblema = new System.Windows.Forms.Label();
            this.pnlCategoria = new System.Windows.Forms.Panel();
            this.cmbCategoriaProblema = new Vistass.ComboOscuro();
            this.chkUrgente = new System.Windows.Forms.CheckBox();
            this.lblAsunto = new System.Windows.Forms.Label();
            this.pnlAsunto = new System.Windows.Forms.Panel();
            this.txtAsunto = new System.Windows.Forms.TextBox();
            this.lblDescripcionDetallada = new System.Windows.Forms.Label();
            this.lblContadorDesc = new System.Windows.Forms.Label();
            this.pnlDescripcion = new System.Windows.Forms.Panel();
            this.txtDescripcionDetallada = new System.Windows.Forms.TextBox();
            this.lblContactoResp = new System.Windows.Forms.Label();
            this.pnlContacto = new System.Windows.Forms.Panel();
            this.txtCorreoRespuesta = new System.Windows.Forms.TextBox();
            this.lblMsgProblema = new System.Windows.Forms.Label();
            this.btnEnviarProblema = new Vistass.BotonTema();
            this.tarjRecom = new System.Windows.Forms.Panel();
            this.lblTituloRecom = new System.Windows.Forms.Label();
            this.lblSubRecom = new System.Windows.Forms.Label();
            this.lblContadorRecom = new System.Windows.Forms.Label();
            this.pnlRecom = new System.Windows.Forms.Panel();
            this.txtRecomendacion = new System.Windows.Forms.TextBox();
            this.lblMsgRecom = new System.Windows.Forms.Label();
            this.btnEnviarRecomendacion = new Vistass.BotonTema();
            this.pnlCentroSoporte = new System.Windows.Forms.Panel();
            this.lblCentroSoporte = new System.Windows.Forms.Label();
            this.lblSubtituloSoporte = new System.Windows.Forms.Label();
            this.btnVolver = new Vistass.BotonTema();
            this.pnlLineaEncabezado = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlScroll.SuspendLayout();
            this.pnlContenido.SuspendLayout();
            this.tarjContacto.SuspendLayout();
            this.tarjReporte.SuspendLayout();
            this.pnlCategoria.SuspendLayout();
            this.pnlAsunto.SuspendLayout();
            this.pnlDescripcion.SuspendLayout();
            this.pnlContacto.SuspendLayout();
            this.tarjRecom.SuspendLayout();
            this.pnlRecom.SuspendLayout();
            this.pnlCentroSoporte.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlScroll
            // 
            this.pnlScroll.AutoScroll = true;
            this.pnlScroll.AutoScrollMinSize = new System.Drawing.Size(1140, 890);
            this.pnlScroll.BackColor = System.Drawing.Color. FromArgb(18, 18, 18);
            this.pnlScroll.Controls.Add(this.pnlContenido);
            this.pnlScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScroll.Location = new System.Drawing.Point(0, 92);
            this.pnlScroll.Name = "pnlScroll";
            this.pnlScroll.Size = new System.Drawing.Size(1321, 836);
            this.pnlScroll.TabIndex = 0;
            // 
            // pnlContenido
            // 
            this.pnlContenido.BackColor = System.Drawing.Color. FromArgb(18, 18, 18);
            this.pnlContenido.Controls.Add(this.tarjContacto);
            this.pnlContenido.Controls.Add(this.tarjReporte);
            this.pnlContenido.Controls.Add(this.tarjRecom);
            this.pnlContenido.Location = new System.Drawing.Point(110, 20);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(1100, 850);
            this.pnlContenido.TabIndex = 0;
            // 
            // tarjContacto
            // 
            this.tarjContacto.BackColor = System.Drawing.Color.FromArgb(30, 33, 44);
            this.tarjContacto.Controls.Add(this.lblTituloContacto);
            this.tarjContacto.Controls.Add(this.lblSubContacto);
            this.tarjContacto.Controls.Add(this.lblCapTel);
            this.tarjContacto.Controls.Add(this.lblTelefonoSoporte);
            this.tarjContacto.Controls.Add(this.lblCapCorreo);
            this.tarjContacto.Controls.Add(this.lblCorreoContacto);
            this.tarjContacto.Controls.Add(this.lblCapHorario);
            this.tarjContacto.Controls.Add(this.lblHorarioSoporte);
            this.tarjContacto.Controls.Add(this.lblEstadoAtencion);
            this.tarjContacto.Controls.Add(this.pnlSepContacto);
            this.tarjContacto.Controls.Add(this.lblTituloConsejos);
            this.tarjContacto.Controls.Add(this.lblConsejos);
            this.tarjContacto.Location = new System.Drawing.Point(0, 0);
            this.tarjContacto.Name = "tarjContacto";
            this.tarjContacto.Size = new System.Drawing.Size(340, 594);
            this.tarjContacto.TabIndex = 0;
            this.tarjContacto.Paint += new System.Windows.Forms.PaintEventHandler(this.Tarjeta_Paint);
            // 
            // lblTituloContacto
            // 
            this.lblTituloContacto.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloContacto.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTituloContacto.ForeColor = System.Drawing.Color.White;
            this.lblTituloContacto.Location = new System.Drawing.Point(28, 22);
            this.lblTituloContacto.Name = "lblTituloContacto";
            this.lblTituloContacto.Size = new System.Drawing.Size(284, 30);
            this.lblTituloContacto.TabIndex = 0;
            this.lblTituloContacto.Text = "Contacto de soporte";
            // 
            // lblSubContacto
            // 
            this.lblSubContacto.BackColor = System.Drawing.Color.Transparent;
            this.lblSubContacto.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubContacto.ForeColor = System.Drawing.Color.FromArgb(170, 180, 200);
            this.lblSubContacto.Location = new System.Drawing.Point(28, 54);
            this.lblSubContacto.Name = "lblSubContacto";
            this.lblSubContacto.Size = new System.Drawing.Size(284, 20);
            this.lblSubContacto.TabIndex = 1;
            this.lblSubContacto.Text = "Para consultas directas";
            // 
            // lblCapTel
            // 
            this.lblCapTel.BackColor = System.Drawing.Color.Transparent;
            this.lblCapTel.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCapTel.ForeColor = System.Drawing.Color.FromArgb(250, 204, 21);
            this.lblCapTel.Location = new System.Drawing.Point(28, 100);
            this.lblCapTel.Name = "lblCapTel";
            this.lblCapTel.Size = new System.Drawing.Size(284, 18);
            this.lblCapTel.TabIndex = 2;
            this.lblCapTel.Text = "TELÉFONO";
            // 
            // lblTelefonoSoporte
            // 
            this.lblTelefonoSoporte.BackColor = System.Drawing.Color.Transparent;
            this.lblTelefonoSoporte.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.lblTelefonoSoporte.ForeColor = System.Drawing.Color.White;
            this.lblTelefonoSoporte.Location = new System.Drawing.Point(28, 120);
            this.lblTelefonoSoporte.Name = "lblTelefonoSoporte";
            this.lblTelefonoSoporte.Size = new System.Drawing.Size(284, 26);
            this.lblTelefonoSoporte.TabIndex = 3;
            this.lblTelefonoSoporte.Text = "+503 6767-6767";
            // 
            // lblCapCorreo
            // 
            this.lblCapCorreo.BackColor = System.Drawing.Color.Transparent;
            this.lblCapCorreo.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCapCorreo.ForeColor = System.Drawing.Color.FromArgb(250, 204, 21);
            this.lblCapCorreo.Location = new System.Drawing.Point(28, 168);
            this.lblCapCorreo.Name = "lblCapCorreo";
            this.lblCapCorreo.Size = new System.Drawing.Size(284, 18);
            this.lblCapCorreo.TabIndex = 4;
            this.lblCapCorreo.Text = "CORREO DE CONTACTO";
            // 
            // lblCorreoContacto
            // 
            this.lblCorreoContacto.BackColor = System.Drawing.Color.Transparent;
            this.lblCorreoContacto.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.lblCorreoContacto.ForeColor = System.Drawing.Color.White;
            this.lblCorreoContacto.Location = new System.Drawing.Point(28, 188);
            this.lblCorreoContacto.Name = "lblCorreoContacto";
            this.lblCorreoContacto.Size = new System.Drawing.Size(284, 26);
            this.lblCorreoContacto.TabIndex = 5;
            this.lblCorreoContacto.Text = "20250095@ricaldone.edu.sv";
            // 
            // lblCapHorario
            // 
            this.lblCapHorario.BackColor = System.Drawing.Color.Transparent;
            this.lblCapHorario.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCapHorario.ForeColor = System.Drawing.Color.FromArgb(250, 204, 21);
            this.lblCapHorario.Location = new System.Drawing.Point(28, 236);
            this.lblCapHorario.Name = "lblCapHorario";
            this.lblCapHorario.Size = new System.Drawing.Size(284, 18);
            this.lblCapHorario.TabIndex = 6;
            this.lblCapHorario.Text = "HORARIO DE ATENCIÓN";
            // 
            // lblHorarioSoporte
            // 
            this.lblHorarioSoporte.BackColor = System.Drawing.Color.Transparent;
            this.lblHorarioSoporte.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.lblHorarioSoporte.ForeColor = System.Drawing.Color.White;
            this.lblHorarioSoporte.Location = new System.Drawing.Point(28, 256);
            this.lblHorarioSoporte.Name = "lblHorarioSoporte";
            this.lblHorarioSoporte.Size = new System.Drawing.Size(284, 48);
            this.lblHorarioSoporte.TabIndex = 7;
            this.lblHorarioSoporte.Text = "Lunes a viernes\r\n9:00 a.m. - 6:00 p.m.";
            // 
            // lblEstadoAtencion
            // 
            this.lblEstadoAtencion.BackColor = System.Drawing.Color.Transparent;
            this.lblEstadoAtencion.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblEstadoAtencion.ForeColor = System.Drawing.Color.FromArgb(74, 222, 128);
            this.lblEstadoAtencion.Location = new System.Drawing.Point(28, 314);
            this.lblEstadoAtencion.Name = "lblEstadoAtencion";
            this.lblEstadoAtencion.Size = new System.Drawing.Size(284, 24);
            this.lblEstadoAtencion.TabIndex = 8;
            // 
            // pnlSepContacto
            // 
            this.pnlSepContacto.BackColor = System.Drawing.Color.FromArgb(60, 64, 84);
            this.pnlSepContacto.Location = new System.Drawing.Point(28, 358);
            this.pnlSepContacto.Name = "pnlSepContacto";
            this.pnlSepContacto.Size = new System.Drawing.Size(284, 1);
            this.pnlSepContacto.TabIndex = 9;
            // 
            // lblTituloConsejos
            // 
            this.lblTituloConsejos.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloConsejos.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTituloConsejos.ForeColor = System.Drawing.Color.FromArgb(250, 204, 21);
            this.lblTituloConsejos.Location = new System.Drawing.Point(28, 376);
            this.lblTituloConsejos.Name = "lblTituloConsejos";
            this.lblTituloConsejos.Size = new System.Drawing.Size(284, 18);
            this.lblTituloConsejos.TabIndex = 10;
            this.lblTituloConsejos.Text = "ANTES DE ENVIAR SU REPORTE";
            // 
            // lblConsejos
            // 
            this.lblConsejos.BackColor = System.Drawing.Color.Transparent;
            this.lblConsejos.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblConsejos.ForeColor = System.Drawing.Color.FromArgb(170, 180, 200);
            this.lblConsejos.Location = new System.Drawing.Point(28, 400);
            this.lblConsejos.Name = "lblConsejos";
            this.lblConsejos.Size = new System.Drawing.Size(284, 176);
            this.lblConsejos.TabIndex = 11;
            this.lblConsejos.Text = "•  Indique en qué pantalla estaba.\r\n\r\n•  Cuente qué esperaba que pasara y qué pasó en realidad.\r\n\r\n•  Si aparece un mensaje de error, cópielo tal como se ve.\r\n\r\n•  Deje su correo para que le podamos responder.";
            // 
            // tarjReporte
            // 
            this.tarjReporte.BackColor = System.Drawing.Color.FromArgb(30, 33, 44);
            this.tarjReporte.Controls.Add(this.lblTituloReporte);
            this.tarjReporte.Controls.Add(this.lblSubReporte);
            this.tarjReporte.Controls.Add(this.lblCategoriaProblema);
            this.tarjReporte.Controls.Add(this.pnlCategoria);
            this.tarjReporte.Controls.Add(this.chkUrgente);
            this.tarjReporte.Controls.Add(this.lblAsunto);
            this.tarjReporte.Controls.Add(this.pnlAsunto);
            this.tarjReporte.Controls.Add(this.lblDescripcionDetallada);
            this.tarjReporte.Controls.Add(this.lblContadorDesc);
            this.tarjReporte.Controls.Add(this.pnlDescripcion);
            this.tarjReporte.Controls.Add(this.lblContactoResp);
            this.tarjReporte.Controls.Add(this.pnlContacto);
            this.tarjReporte.Controls.Add(this.lblMsgProblema);
            this.tarjReporte.Controls.Add(this.btnEnviarProblema);
            this.tarjReporte.Location = new System.Drawing.Point(360, 0);
            this.tarjReporte.Name = "tarjReporte";
            this.tarjReporte.Size = new System.Drawing.Size(740, 594);
            this.tarjReporte.TabIndex = 1;
            this.tarjReporte.Paint += new System.Windows.Forms.PaintEventHandler(this.Tarjeta_Paint);
            // 
            // lblTituloReporte
            // 
            this.lblTituloReporte.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloReporte.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTituloReporte.ForeColor = System.Drawing.Color.White;
            this.lblTituloReporte.Location = new System.Drawing.Point(32, 22);
            this.lblTituloReporte.Name = "lblTituloReporte";
            this.lblTituloReporte.Size = new System.Drawing.Size(676, 30);
            this.lblTituloReporte.TabIndex = 0;
            this.lblTituloReporte.Text = "Reportar un problema";
            // 
            // lblSubReporte
            // 
            this.lblSubReporte.BackColor = System.Drawing.Color.Transparent;
            this.lblSubReporte.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubReporte.ForeColor = System.Drawing.Color.FromArgb(170, 180, 200);
            this.lblSubReporte.Location = new System.Drawing.Point(32, 54);
            this.lblSubReporte.Name = "lblSubReporte";
            this.lblSubReporte.Size = new System.Drawing.Size(676, 20);
            this.lblSubReporte.TabIndex = 1;
            this.lblSubReporte.Text = "Describa lo que ocurrió. Puede enviarlo a cualquier hora; se atiende en horario laboral.";
            // 
            // lblCategoriaProblema
            // 
            this.lblCategoriaProblema.BackColor = System.Drawing.Color.Transparent;
            this.lblCategoriaProblema.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblCategoriaProblema.ForeColor = System.Drawing.Color.FromArgb(200, 208, 224);
            this.lblCategoriaProblema.Location = new System.Drawing.Point(32, 92);
            this.lblCategoriaProblema.Name = "lblCategoriaProblema";
            this.lblCategoriaProblema.Size = new System.Drawing.Size(300, 20);
            this.lblCategoriaProblema.TabIndex = 2;
            this.lblCategoriaProblema.Text = "Categoría del problema *";
            // 
            // pnlCategoria
            // 
            this.pnlCategoria.BackColor = System.Drawing.Color.FromArgb(40, 43, 58);
            this.pnlCategoria.Controls.Add(this.cmbCategoriaProblema);
            this.pnlCategoria.Location = new System.Drawing.Point(32, 112);
            this.pnlCategoria.Name = "pnlCategoria";
            this.pnlCategoria.Size = new System.Drawing.Size(456, 42);
            this.pnlCategoria.TabIndex = 3;
            this.pnlCategoria.Click += new System.EventHandler(this.Campo_Click);
            this.pnlCategoria.Paint += new System.Windows.Forms.PaintEventHandler(this.Campo_Paint);
            // 
            // cmbCategoriaProblema
            // 
            this.cmbCategoriaProblema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoriaProblema.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbCategoriaProblema.FormattingEnabled = true;
            this.cmbCategoriaProblema.Items.AddRange(new object[] {
            "Error en el sistema",
            "No puedo iniciar sesión / contraseña",
            "Personal y expedientes",
            "Planillas y pagos",
            "Ausencias y permisos",
            "Activos e inventario",
            "Salones y reportes de daño",
            "Reportes y PDF",
            "Otro"});
            this.cmbCategoriaProblema.Location = new System.Drawing.Point(8, 6);
            this.cmbCategoriaProblema.Name = "cmbCategoriaProblema";
            this.cmbCategoriaProblema.Size = new System.Drawing.Size(440, 28);
            this.cmbCategoriaProblema.TabIndex = 0;
            this.cmbCategoriaProblema.SelectedIndexChanged += new System.EventHandler(this.CampoProblema_Changed);
            this.cmbCategoriaProblema.Enter += new System.EventHandler(this.Campo_FocoCambia);
            this.cmbCategoriaProblema.Leave += new System.EventHandler(this.Campo_FocoCambia);
            // 
            // chkUrgente
            // 
            this.chkUrgente.BackColor = System.Drawing.Color.Transparent;
            this.chkUrgente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkUrgente.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.chkUrgente.ForeColor = System.Drawing.Color.FromArgb(170, 180, 200);
            this.chkUrgente.Location = new System.Drawing.Point(508, 112);
            this.chkUrgente.Name = "chkUrgente";
            this.chkUrgente.Size = new System.Drawing.Size(200, 42);
            this.chkUrgente.TabIndex = 1;
            this.chkUrgente.Text = "Urgente: no puedo trabajar";
            this.chkUrgente.UseVisualStyleBackColor = false;
            this.chkUrgente.CheckedChanged += new System.EventHandler(this.chkUrgente_CheckedChanged);
            // 
            // lblAsunto
            // 
            this.lblAsunto.BackColor = System.Drawing.Color.Transparent;
            this.lblAsunto.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblAsunto.ForeColor = System.Drawing.Color.FromArgb(200, 208, 224);
            this.lblAsunto.Location = new System.Drawing.Point(32, 170);
            this.lblAsunto.Name = "lblAsunto";
            this.lblAsunto.Size = new System.Drawing.Size(300, 20);
            this.lblAsunto.TabIndex = 4;
            this.lblAsunto.Text = "Asunto *";
            // 
            // pnlAsunto
            // 
            this.pnlAsunto.BackColor = System.Drawing.Color.FromArgb(40, 43, 58);
            this.pnlAsunto.Controls.Add(this.txtAsunto);
            this.pnlAsunto.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pnlAsunto.Location = new System.Drawing.Point(32, 190);
            this.pnlAsunto.Name = "pnlAsunto";
            this.pnlAsunto.Size = new System.Drawing.Size(676, 42);
            this.pnlAsunto.TabIndex = 5;
            this.pnlAsunto.Click += new System.EventHandler(this.Campo_Click);
            this.pnlAsunto.Paint += new System.Windows.Forms.PaintEventHandler(this.Campo_Paint);
            // 
            // txtAsunto
            // 
            this.txtAsunto.BackColor = System.Drawing.Color.FromArgb(40, 43, 58);
            this.txtAsunto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAsunto.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtAsunto.ForeColor = System.Drawing.Color.White;
            this.txtAsunto.Location = new System.Drawing.Point(14, 10);
            this.txtAsunto.MaxLength = 100;
            this.txtAsunto.Name = "txtAsunto";
            this.txtAsunto.Size = new System.Drawing.Size(648, 20);
            this.txtAsunto.TabIndex = 0;
            this.txtAsunto.TextChanged += new System.EventHandler(this.CampoProblema_Changed);
            this.txtAsunto.Enter += new System.EventHandler(this.Campo_FocoCambia);
            this.txtAsunto.Leave += new System.EventHandler(this.Campo_FocoCambia);
            // 
            // lblDescripcionDetallada
            // 
            this.lblDescripcionDetallada.BackColor = System.Drawing.Color.Transparent;
            this.lblDescripcionDetallada.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblDescripcionDetallada.ForeColor = System.Drawing.Color.FromArgb(200, 208, 224);
            this.lblDescripcionDetallada.Location = new System.Drawing.Point(32, 248);
            this.lblDescripcionDetallada.Name = "lblDescripcionDetallada";
            this.lblDescripcionDetallada.Size = new System.Drawing.Size(400, 20);
            this.lblDescripcionDetallada.TabIndex = 6;
            this.lblDescripcionDetallada.Text = "Descripción detallada del problema *";
            // 
            // lblContadorDesc
            // 
            this.lblContadorDesc.BackColor = System.Drawing.Color.Transparent;
            this.lblContadorDesc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblContadorDesc.ForeColor = System.Drawing.Color.FromArgb(120, 128, 150);
            this.lblContadorDesc.Location = new System.Drawing.Point(508, 248);
            this.lblContadorDesc.Name = "lblContadorDesc";
            this.lblContadorDesc.Size = new System.Drawing.Size(200, 20);
            this.lblContadorDesc.TabIndex = 7;
            this.lblContadorDesc.Text = "0 / 1000";
            this.lblContadorDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlDescripcion
            // 
            this.pnlDescripcion.BackColor = System.Drawing.Color.FromArgb(40, 43, 58);
            this.pnlDescripcion.Controls.Add(this.txtDescripcionDetallada);
            this.pnlDescripcion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pnlDescripcion.Location = new System.Drawing.Point(32, 268);
            this.pnlDescripcion.Name = "pnlDescripcion";
            this.pnlDescripcion.Size = new System.Drawing.Size(676, 130);
            this.pnlDescripcion.TabIndex = 8;
            this.pnlDescripcion.Click += new System.EventHandler(this.Campo_Click);
            this.pnlDescripcion.Paint += new System.Windows.Forms.PaintEventHandler(this.Campo_Paint);
            // 
            // txtDescripcionDetallada
            // 
            this.txtDescripcionDetallada.BackColor = System.Drawing.Color.FromArgb(40, 43, 58);
            this.txtDescripcionDetallada.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescripcionDetallada.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtDescripcionDetallada.ForeColor = System.Drawing.Color.White;
            this.txtDescripcionDetallada.Location = new System.Drawing.Point(14, 10);
            this.txtDescripcionDetallada.MaxLength = 1000;
            this.txtDescripcionDetallada.Multiline = true;
            this.txtDescripcionDetallada.Name = "txtDescripcionDetallada";
            this.txtDescripcionDetallada.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDescripcionDetallada.Size = new System.Drawing.Size(648, 108);
            this.txtDescripcionDetallada.TabIndex = 0;
            this.txtDescripcionDetallada.TextChanged += new System.EventHandler(this.txtDescripcionDetallada_TextChanged);
            this.txtDescripcionDetallada.Enter += new System.EventHandler(this.Campo_FocoCambia);
            this.txtDescripcionDetallada.Leave += new System.EventHandler(this.Campo_FocoCambia);
            // 
            // lblContactoResp
            // 
            this.lblContactoResp.BackColor = System.Drawing.Color.Transparent;
            this.lblContactoResp.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblContactoResp.ForeColor = System.Drawing.Color.FromArgb(200, 208, 224);
            this.lblContactoResp.Location = new System.Drawing.Point(32, 412);
            this.lblContactoResp.Name = "lblContactoResp";
            this.lblContactoResp.Size = new System.Drawing.Size(676, 20);
            this.lblContactoResp.TabIndex = 9;
            this.lblContactoResp.Text = "Su correo para responderle (opcional)";
            // 
            // pnlContacto
            // 
            this.pnlContacto.BackColor = System.Drawing.Color.FromArgb(40, 43, 58);
            this.pnlContacto.Controls.Add(this.txtCorreoRespuesta);
            this.pnlContacto.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pnlContacto.Location = new System.Drawing.Point(32, 432);
            this.pnlContacto.Name = "pnlContacto";
            this.pnlContacto.Size = new System.Drawing.Size(676, 42);
            this.pnlContacto.TabIndex = 10;
            this.pnlContacto.Click += new System.EventHandler(this.Campo_Click);
            this.pnlContacto.Paint += new System.Windows.Forms.PaintEventHandler(this.Campo_Paint);
            // 
            // txtCorreoRespuesta
            // 
            this.txtCorreoRespuesta.BackColor = System.Drawing.Color.FromArgb(40, 43, 58);
            this.txtCorreoRespuesta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCorreoRespuesta.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtCorreoRespuesta.ForeColor = System.Drawing.Color.White;
            this.txtCorreoRespuesta.Location = new System.Drawing.Point(14, 10);
            this.txtCorreoRespuesta.MaxLength = 100;
            this.txtCorreoRespuesta.Name = "txtCorreoRespuesta";
            this.txtCorreoRespuesta.Size = new System.Drawing.Size(648, 20);
            this.txtCorreoRespuesta.TabIndex = 0;
            this.txtCorreoRespuesta.TextChanged += new System.EventHandler(this.CampoProblema_Changed);
            this.txtCorreoRespuesta.Enter += new System.EventHandler(this.Campo_FocoCambia);
            this.txtCorreoRespuesta.Leave += new System.EventHandler(this.Campo_FocoCambia);
            // 
            // lblMsgProblema
            // 
            this.lblMsgProblema.BackColor = System.Drawing.Color.Transparent;
            this.lblMsgProblema.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblMsgProblema.ForeColor = System.Drawing.Color.FromArgb(248, 113, 113);
            this.lblMsgProblema.Location = new System.Drawing.Point(32, 484);
            this.lblMsgProblema.Name = "lblMsgProblema";
            this.lblMsgProblema.Size = new System.Drawing.Size(676, 32);
            this.lblMsgProblema.TabIndex = 11;
            this.lblMsgProblema.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMsgProblema.Visible = false;
            // 
            // btnEnviarProblema
            // 
            this.btnEnviarProblema.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnviarProblema.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnEnviarProblema.Location = new System.Drawing.Point(32, 524);
            this.btnEnviarProblema.Name = "btnEnviarProblema";
            this.btnEnviarProblema.Size = new System.Drawing.Size(676, 48);
            this.btnEnviarProblema.TabIndex = 12;
            this.btnEnviarProblema.Text = "Enviar reporte";
            this.btnEnviarProblema.Tipo = Vistass.TipoBoton.Principal;
            this.btnEnviarProblema.Click += new System.EventHandler(this.btnEnviarProblema_Click);
            this.btnEnviarProblema.MouseEnter += new System.EventHandler(this.Boton_Hover);
            this.btnEnviarProblema.MouseLeave += new System.EventHandler(this.Boton_Hover);
            // 
            // tarjRecom
            // 
            this.tarjRecom.BackColor = System.Drawing.Color.FromArgb(30, 33, 44);
            this.tarjRecom.Controls.Add(this.lblTituloRecom);
            this.tarjRecom.Controls.Add(this.lblSubRecom);
            this.tarjRecom.Controls.Add(this.lblContadorRecom);
            this.tarjRecom.Controls.Add(this.pnlRecom);
            this.tarjRecom.Controls.Add(this.lblMsgRecom);
            this.tarjRecom.Controls.Add(this.btnEnviarRecomendacion);
            this.tarjRecom.Location = new System.Drawing.Point(0, 614);
            this.tarjRecom.Name = "tarjRecom";
            this.tarjRecom.Size = new System.Drawing.Size(1100, 236);
            this.tarjRecom.TabIndex = 2;
            this.tarjRecom.Paint += new System.Windows.Forms.PaintEventHandler(this.Tarjeta_Paint);
            // 
            // lblTituloRecom
            // 
            this.lblTituloRecom.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloRecom.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTituloRecom.ForeColor = System.Drawing.Color.White;
            this.lblTituloRecom.Location = new System.Drawing.Point(32, 22);
            this.lblTituloRecom.Name = "lblTituloRecom";
            this.lblTituloRecom.Size = new System.Drawing.Size(700, 30);
            this.lblTituloRecom.TabIndex = 0;
            this.lblTituloRecom.Text = "¿Tienes recomendaciones?";
            // 
            // lblSubRecom
            // 
            this.lblSubRecom.BackColor = System.Drawing.Color.Transparent;
            this.lblSubRecom.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubRecom.ForeColor = System.Drawing.Color.FromArgb(170, 180, 200);
            this.lblSubRecom.Location = new System.Drawing.Point(32, 54);
            this.lblSubRecom.Name = "lblSubRecom";
            this.lblSubRecom.Size = new System.Drawing.Size(700, 20);
            this.lblSubRecom.TabIndex = 1;
            this.lblSubRecom.Text = "Cuéntenos qué mejoraría o qué función le gustaría ver en el sistema.";
            // 
            // lblContadorRecom
            // 
            this.lblContadorRecom.BackColor = System.Drawing.Color.Transparent;
            this.lblContadorRecom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblContadorRecom.ForeColor = System.Drawing.Color.FromArgb(120, 128, 150);
            this.lblContadorRecom.Location = new System.Drawing.Point(868, 56);
            this.lblContadorRecom.Name = "lblContadorRecom";
            this.lblContadorRecom.Size = new System.Drawing.Size(200, 20);
            this.lblContadorRecom.TabIndex = 2;
            this.lblContadorRecom.Text = "0 / 500";
            this.lblContadorRecom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlRecom
            // 
            this.pnlRecom.BackColor = System.Drawing.Color.FromArgb(40, 43, 58);
            this.pnlRecom.Controls.Add(this.txtRecomendacion);
            this.pnlRecom.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pnlRecom.Location = new System.Drawing.Point(32, 84);
            this.pnlRecom.Name = "pnlRecom";
            this.pnlRecom.Size = new System.Drawing.Size(1036, 72);
            this.pnlRecom.TabIndex = 3;
            this.pnlRecom.Click += new System.EventHandler(this.Campo_Click);
            this.pnlRecom.Paint += new System.Windows.Forms.PaintEventHandler(this.Campo_Paint);
            // 
            // txtRecomendacion
            // 
            this.txtRecomendacion.BackColor = System.Drawing.Color.FromArgb(40, 43, 58);
            this.txtRecomendacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRecomendacion.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtRecomendacion.ForeColor = System.Drawing.Color.White;
            this.txtRecomendacion.Location = new System.Drawing.Point(14, 10);
            this.txtRecomendacion.MaxLength = 500;
            this.txtRecomendacion.Multiline = true;
            this.txtRecomendacion.Name = "txtRecomendacion";
            this.txtRecomendacion.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRecomendacion.Size = new System.Drawing.Size(1008, 50);
            this.txtRecomendacion.TabIndex = 0;
            this.txtRecomendacion.TextChanged += new System.EventHandler(this.txtRecomendacion_TextChanged);
            this.txtRecomendacion.Enter += new System.EventHandler(this.Campo_FocoCambia);
            this.txtRecomendacion.Leave += new System.EventHandler(this.Campo_FocoCambia);
            // 
            // lblMsgRecom
            // 
            this.lblMsgRecom.BackColor = System.Drawing.Color.Transparent;
            this.lblMsgRecom.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblMsgRecom.ForeColor = System.Drawing.Color.FromArgb(248, 113, 113);
            this.lblMsgRecom.Location = new System.Drawing.Point(32, 168);
            this.lblMsgRecom.Name = "lblMsgRecom";
            this.lblMsgRecom.Size = new System.Drawing.Size(790, 44);
            this.lblMsgRecom.TabIndex = 4;
            this.lblMsgRecom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMsgRecom.Visible = false;
            // 
            // btnEnviarRecomendacion
            // 
            this.btnEnviarRecomendacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnviarRecomendacion.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnEnviarRecomendacion.Location = new System.Drawing.Point(848, 168);
            this.btnEnviarRecomendacion.Name = "btnEnviarRecomendacion";
            this.btnEnviarRecomendacion.Size = new System.Drawing.Size(220, 44);
            this.btnEnviarRecomendacion.TabIndex = 5;
            this.btnEnviarRecomendacion.Text = "Enviar recomendación";
            this.btnEnviarRecomendacion.Tipo = Vistass.TipoBoton.Principal;
            this.btnEnviarRecomendacion.Click += new System.EventHandler(this.btnEnviarRecomendacion_Click);
            this.btnEnviarRecomendacion.MouseEnter += new System.EventHandler(this.Boton_Hover);
            this.btnEnviarRecomendacion.MouseLeave += new System.EventHandler(this.Boton_Hover);
            // 
            // pnlCentroSoporte
            // 
            this.pnlCentroSoporte.BackColor = System.Drawing.Color.FromArgb(20, 22, 30);
            this.pnlCentroSoporte.Controls.Add(this.lblCentroSoporte);
            this.pnlCentroSoporte.Controls.Add(this.lblSubtituloSoporte);
            this.pnlCentroSoporte.Controls.Add(this.btnVolver);
            this.pnlCentroSoporte.Controls.Add(this.pnlLineaEncabezado);
            this.pnlCentroSoporte.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCentroSoporte.Location = new System.Drawing.Point(0, 0);
            this.pnlCentroSoporte.Name = "pnlCentroSoporte";
            this.pnlCentroSoporte.Size = new System.Drawing.Size(1321, 92);
            this.pnlCentroSoporte.TabIndex = 1;
            // 
            // lblCentroSoporte
            // 
            this.lblCentroSoporte.AutoSize = true;
            this.lblCentroSoporte.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblCentroSoporte.ForeColor = System.Drawing.Color.White;
            this.lblCentroSoporte.Location = new System.Drawing.Point(32, 10);
            this.lblCentroSoporte.Name = "lblCentroSoporte";
            this.lblCentroSoporte.Size = new System.Drawing.Size(415, 41);
            this.lblCentroSoporte.TabIndex = 0;
            this.lblCentroSoporte.Text = "Centro de soporte y ayuda";
            // 
            // lblSubtituloSoporte
            // 
            this.lblSubtituloSoporte.AutoSize = true;
            this.lblSubtituloSoporte.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtituloSoporte.ForeColor = System.Drawing.Color.FromArgb(170, 180, 200);
            this.lblSubtituloSoporte.Location = new System.Drawing.Point(36, 56);
            this.lblSubtituloSoporte.Name = "lblSubtituloSoporte";
            this.lblSubtituloSoporte.Size = new System.Drawing.Size(520, 23);
            this.lblSubtituloSoporte.TabIndex = 1;
            this.lblSubtituloSoporte.Text = "Sus reportes llegan directamente al equipo que desarrolló el sistema.";
            // 
            // btnVolver
            // 
            this.btnVolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVolver.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnVolver.Location = new System.Drawing.Point(1093, 24);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(190, 42);
            this.btnVolver.TabIndex = 2;
            this.btnVolver.Text = "Volver al inicio";
            this.btnVolver.Tipo = Vistass.TipoBoton.Secundario;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // pnlLineaEncabezado
            // 
            this.pnlLineaEncabezado.BackColor = System.Drawing.Color.FromArgb(250, 204, 21);
            this.pnlLineaEncabezado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLineaEncabezado.Location = new System.Drawing.Point(0, 90);
            this.pnlLineaEncabezado.Name = "pnlLineaEncabezado";
            this.pnlLineaEncabezado.Size = new System.Drawing.Size(1321, 2);
            this.pnlLineaEncabezado.TabIndex = 3;
            // 
            // frmCentroSoporte
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color. FromArgb(18, 18, 18);
            this.ClientSize = new System.Drawing.Size(1321, 928);
            this.Controls.Add(this.pnlScroll);
            this.Controls.Add(this.pnlCentroSoporte);
            this.ForeColor = System.Drawing.Color.White;
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "frmCentroSoporte";
            this.Text = "Centro de soporte y ayuda";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCentroSoporte_FormClosed);
            this.Load += new System.EventHandler(this.frmCentroSoporte_Load);
            this.Resize += new System.EventHandler(this.frmCentroSoporte_Resize);
            this.pnlScroll.ResumeLayout(false);
            this.pnlContenido.ResumeLayout(false);
            this.tarjContacto.ResumeLayout(false);
            this.tarjReporte.ResumeLayout(false);
            this.pnlCategoria.ResumeLayout(false);
            this.pnlAsunto.ResumeLayout(false);
            this.pnlAsunto.PerformLayout();
            this.pnlDescripcion.ResumeLayout(false);
            this.pnlDescripcion.PerformLayout();
            this.pnlContacto.ResumeLayout(false);
            this.pnlContacto.PerformLayout();
            this.tarjRecom.ResumeLayout(false);
            this.pnlRecom.ResumeLayout(false);
            this.pnlRecom.PerformLayout();
            this.pnlCentroSoporte.ResumeLayout(false);
            this.pnlCentroSoporte.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlScroll;
        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.Panel tarjContacto;
        private System.Windows.Forms.Label lblTituloContacto;
        private System.Windows.Forms.Label lblSubContacto;
        private System.Windows.Forms.Label lblCapTel;
        private System.Windows.Forms.Label lblTelefonoSoporte;
        private System.Windows.Forms.Label lblCapCorreo;
        private System.Windows.Forms.Label lblCorreoContacto;
        private System.Windows.Forms.Label lblCapHorario;
        private System.Windows.Forms.Label lblHorarioSoporte;
        private System.Windows.Forms.Label lblEstadoAtencion;
        private System.Windows.Forms.Panel pnlSepContacto;
        private System.Windows.Forms.Label lblTituloConsejos;
        private System.Windows.Forms.Label lblConsejos;
        private System.Windows.Forms.Panel tarjReporte;
        private System.Windows.Forms.Label lblTituloReporte;
        private System.Windows.Forms.Label lblSubReporte;
        private System.Windows.Forms.Label lblCategoriaProblema;
        private System.Windows.Forms.Panel pnlCategoria;
        private Vistass.ComboOscuro cmbCategoriaProblema;
        private System.Windows.Forms.CheckBox chkUrgente;
        private System.Windows.Forms.Label lblAsunto;
        private System.Windows.Forms.Panel pnlAsunto;
        private System.Windows.Forms.TextBox txtAsunto;
        private System.Windows.Forms.Label lblDescripcionDetallada;
        private System.Windows.Forms.Label lblContadorDesc;
        private System.Windows.Forms.Panel pnlDescripcion;
        private System.Windows.Forms.TextBox txtDescripcionDetallada;
        private System.Windows.Forms.Label lblContactoResp;
        private System.Windows.Forms.Panel pnlContacto;
        private System.Windows.Forms.TextBox txtCorreoRespuesta;
        private System.Windows.Forms.Label lblMsgProblema;
        private Vistass.BotonTema btnEnviarProblema;
        private System.Windows.Forms.Panel tarjRecom;
        private System.Windows.Forms.Label lblTituloRecom;
        private System.Windows.Forms.Label lblSubRecom;
        private System.Windows.Forms.Label lblContadorRecom;
        private System.Windows.Forms.Panel pnlRecom;
        private System.Windows.Forms.TextBox txtRecomendacion;
        private System.Windows.Forms.Label lblMsgRecom;
        private Vistass.BotonTema btnEnviarRecomendacion;
        private System.Windows.Forms.Panel pnlCentroSoporte;
        private System.Windows.Forms.Label lblCentroSoporte;
        private System.Windows.Forms.Label lblSubtituloSoporte;
        private Vistass.BotonTema btnVolver;
        private System.Windows.Forms.Panel pnlLineaEncabezado;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}