using Modelos;
using pagina_principal;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vistass;

namespace CentroDeSoporte
{
    public partial class frmCentroSoporte : Form
    {

        
        // Horario de atención (24 h). Cambie estos dos números y se actualizan solos el
        // texto "HORARIO DE ATENCIÓN" y el indicador "Atención disponible ahora".
        private const int HoraApertura = 9;
        private const int HoraCierre = 18;


        private const int MinAsunto = 5;
        private const int MinDescripcion = 20;
        private const int MaxDescripcion = 1000;
        private const int MaxRecomendacion = 500;
        private const int SegundosEntreEnvios = 60;     

   
        private static readonly Color Amarillo = Color.FromArgb(250, 204, 21);
        private static readonly Color AmarilloHover = Color.FromArgb(253, 224, 71);
        private static readonly Color Rojo = Color.FromArgb(248, 113, 113);
        private static readonly Color Verde = Color.FromArgb(74, 222, 128);
        private static readonly Color Ambar = Color.FromArgb(251, 191, 36);
        private static readonly Color LineaNormal = Color.FromArgb(70, 75, 95);
        private static readonly Color Suave = Color.FromArgb(170, 180, 200);

        private static DateTime ultimoEnvio = DateTime.MinValue;
        private readonly HashSet<Panel> camposConError = new HashSet<Panel>();   
        private readonly Timer timerEstado = new Timer { Interval = 60000 };    

      
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                const int CP_NOCLOSE_BUTTON = 0x200;
                cp.ClassStyle |= CP_NOCLOSE_BUTTON;
                return cp;
            }
        }

        public frmCentroSoporte()
        {
            InitializeComponent();
            BarrasOscuras.Aplicar(pnlScroll);
        }

        private void frmCentroSoporte_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnEnviarProblema, "Envía el reporte al equipo de soporte técnico.");
            toolTip1.SetToolTip(btnEnviarRecomendacion, "Envía su recomendación al equipo de desarrollo.");
            toolTip1.SetToolTip(btnVolver, "Vuelve a la página principal.");
            toolTip1.SetToolTip(cmbCategoriaProblema, "Elija la categoría que mejor describa su problema.");
            toolTip1.SetToolTip(txtAsunto, "Un título corto que resuma el problema.");
            toolTip1.SetToolTip(txtDescripcionDetallada, "Explique qué estaba haciendo, qué esperaba y qué ocurrió.");
            toolTip1.SetToolTip(txtCorreoRespuesta, "Si lo deja, podremos responderle directamente.");
            toolTip1.SetToolTip(txtRecomendacion, "Su idea para mejorar el sistema.");
            toolTip1.SetToolTip(chkUrgente, "Márquelo solo si el problema le impide trabajar.");

            lblHorarioSoporte.Text = "Lunes a viernes\r\n" + Hora12(HoraApertura) + " - " + Hora12(HoraCierre);

            CentrarContenido();
            ActualizarEstadoAtencion();
            timerEstado.Tick += (s, ev) => ActualizarEstadoAtencion();
            timerEstado.Start();
            ActualizarContadores();
        }

        private void frmCentroSoporte_FormClosed(object sender, FormClosedEventArgs e)
        {
            timerEstado.Stop();
            timerEstado.Dispose();
        }

   
        private void btnVolver_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is frmDashboard)
                {
                    form.Show();
                    this.Close();
                    return;
                }
            }

            frmDashboard principal = new frmDashboard();
            principal.Show();
            this.Close();
        }

        
      

        
        private void CentrarContenido()
        {
            int x = Math.Max(20, (pnlScroll.ClientSize.Width - pnlContenido.Width) / 2);
            pnlContenido.Left = x + pnlScroll.AutoScrollPosition.X;
        }

        private void frmCentroSoporte_Resize(object sender, EventArgs e)
        {
            CentrarContenido();
        }

        private void Tarjeta_Paint(object sender, PaintEventArgs e)
        {
            Panel p = (Panel)sender;
            using (Pen lapiz = new Pen(Color.FromArgb(58, 62, 82), 1))
                e.Graphics.DrawRectangle(lapiz, 0, 0, p.Width - 1, p.Height - 1);
        }

        private void Campo_Paint(object sender, PaintEventArgs e)
        {
            Panel p = (Panel)sender;
            Control caja = p.Controls.Count > 0 ? p.Controls[0] : null;
            Color color = camposConError.Contains(p) ? Rojo
                        : (caja != null && caja.Focused) ? Amarillo
                        : LineaNormal;
            using (SolidBrush b = new SolidBrush(color))
                e.Graphics.FillRectangle(b, 0, p.Height - 2, p.Width, 2);
        }

        private void Campo_Click(object sender, EventArgs e)
        {
            Panel p = (Panel)sender;
            if (p.Controls.Count > 0) p.Controls[0].Focus();
        }

        private void Campo_FocoCambia(object sender, EventArgs e)
        {
            Control padre = ((Control)sender).Parent;
            if (padre != null) padre.Invalidate();
        }

        private void Boton_Hover(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (!b.Enabled) return;
            b.BackColor = b.ClientRectangle.Contains(b.PointToClient(Cursor.Position)) ? AmarilloHover : Amarillo;
        }

        private void chkUrgente_CheckedChanged(object sender, EventArgs e)
        {
            chkUrgente.ForeColor = chkUrgente.Checked ? Ambar : Suave;
        }

        private static string Hora12(int hora24)
        {
            int h = hora24 % 12 == 0 ? 12 : hora24 % 12;
            return h + ":00 " + (hora24 < 12 ? "a.m." : "p.m.");
        }

        private void ActualizarEstadoAtencion()
        {
            DateTime ahora = DateTime.Now;
            bool diaHabil = ahora.DayOfWeek != DayOfWeek.Saturday && ahora.DayOfWeek != DayOfWeek.Sunday;
            bool abierto = diaHabil && ahora.Hour >= HoraApertura && ahora.Hour < HoraCierre;

            lblEstadoAtencion.Text = abierto ? "●  Atención disponible ahora" : "●  Fuera del horario de atención";
            lblEstadoAtencion.ForeColor = abierto ? Verde : Ambar;
        }

        private void ActualizarContadores()
        {
            int d = txtDescripcionDetallada.TextLength;
            lblContadorDesc.Text = d + " / " + MaxDescripcion;
            lblContadorDesc.ForeColor = d >= MaxDescripcion * 0.9 ? Ambar : Color.FromArgb(120, 128, 150);

            int r = txtRecomendacion.TextLength;
            lblContadorRecom.Text = r + " / " + MaxRecomendacion;
            lblContadorRecom.ForeColor = r >= MaxRecomendacion * 0.9 ? Ambar : Color.FromArgb(120, 128, 150);
        }

        private void Mostrar(Label lbl, string texto, bool esError, params Panel[] marcados)
        {
            camposConError.Clear();
            foreach (Panel p in marcados) camposConError.Add(p);
            lbl.ForeColor = esError ? Rojo : Verde;
            lbl.Text = texto;
            lbl.Visible = true;
            InvalidarCampos();
        }

        private void Ocultar(Label lbl)
        {
            if (!lbl.Visible && camposConError.Count == 0) return;
            lbl.Visible = false;
            camposConError.Clear();
            InvalidarCampos();
        }

        private void InvalidarCampos()
        {
            pnlCategoria.Invalidate(); pnlAsunto.Invalidate(); pnlDescripcion.Invalidate();
            pnlContacto.Invalidate(); pnlRecom.Invalidate();
        }

        private void CampoProblema_Changed(object sender, EventArgs e)
        {
            Ocultar(lblMsgProblema);
        }

        private void txtDescripcionDetallada_TextChanged(object sender, EventArgs e)
        {
            ActualizarContadores();
            Ocultar(lblMsgProblema);
        }

        private void txtRecomendacion_TextChanged(object sender, EventArgs e)
        {
            ActualizarContadores();
            Ocultar(lblMsgRecom);
        }

        private static int SegundosDeEspera()
        {
            double pasados = (DateTime.Now - ultimoEnvio).TotalSeconds;
            return pasados >= SegundosEntreEnvios ? 0 : (int)Math.Ceiling(SegundosEntreEnvios - pasados);
        }

        private static string UnaLinea(string texto)
        {
            return Regex.Replace(texto ?? "", @"\s+", " ").Trim();
        }

        private static bool CorreoValido(string correo)
        {
            try { return new MailAddress(correo).Address == correo; }
            catch { return false; }
        }

        private static string Referencia(string prefijo)
        {
            return prefijo + "-" + DateTime.Now.ToString("yyyyMMdd-HHmmss");
        }

        private string DatosTecnicos()
        {
            string institucion = "(no disponible)";
            string servidor = "(no disponible)";
            try
            {
                object o = Datos.Escalar("SELECT TOP 1 NombreEmpresa FROM ConfiguracionEmpresa");
                if (o != null && o != DBNull.Value) institucion = Convert.ToString(o);
            }
            catch { }
            try
            {
                using (SqlConnection c = Conexion.Conectar())
                    servidor = c.DataSource + " / " + c.Database;
            }
            catch { }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("----- DATOS TÉCNICOS (automáticos) -----");
            sb.AppendLine("Institución:        " + institucion);
            sb.AppendLine("Usuario del sistema: " + (Sesion.Usuario ?? "(sin sesión)"));
            sb.AppendLine("Rol:                " + (Sesion.Rol ?? "(sin sesión)"));
            sb.AppendLine("Fecha y hora:       " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("Versión del sistema: " + Assembly.GetExecutingAssembly().GetName().Version);
            sb.AppendLine("Windows:            " + Environment.OSVersion);
            sb.AppendLine(".NET:               " + Environment.Version);
            sb.AppendLine("Equipo:             " + Environment.MachineName + " (usuario Windows: " + Environment.UserName + ")");
            sb.AppendLine("Servidor / base:    " + servidor);
            return sb.ToString();
        }

        private static Task EnviarCorreoAsync(string asunto, string cuerpo, string responderA)
        {
            return ServicioCorreo.EnviarSoporteAsync(asunto, cuerpo, responderA);
        }

        private static string TextoFallo(Exception ex)
        {
            string detalle = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            if (detalle.Length > 110) detalle = detalle.Substring(0, 110) + "…";
            return "No se pudo enviar. Verifique su conexión a internet e intente de nuevo. (" + detalle + ")";
        }

        private async void btnEnviarProblema_Click(object sender, EventArgs e)
        {
            Ocultar(lblMsgProblema);

            string categoria = cmbCategoriaProblema.SelectedItem != null ? cmbCategoriaProblema.SelectedItem.ToString() : "";
            string asunto = UnaLinea(txtAsunto.Text);
            string descripcion = txtDescripcionDetallada.Text.Trim();
            string respuesta = txtCorreoRespuesta.Text.Trim();

            if (categoria.Length == 0)
            { Mostrar(lblMsgProblema, "Seleccione una categoría para clasificar el problema.", true, pnlCategoria); cmbCategoriaProblema.Focus(); return; }
            if (asunto.Length < MinAsunto)
            { Mostrar(lblMsgProblema, "Escriba un asunto (mínimo " + MinAsunto + " caracteres).", true, pnlAsunto); txtAsunto.Focus(); return; }
            if (descripcion.Length < MinDescripcion)
            { Mostrar(lblMsgProblema, "Describa el problema con más detalle (mínimo " + MinDescripcion + " caracteres).", true, pnlDescripcion); txtDescripcionDetallada.Focus(); return; }
            if (respuesta.Length > 0 && !CorreoValido(respuesta))
            { Mostrar(lblMsgProblema, "El correo para responderle no tiene un formato válido.", true, pnlContacto); txtCorreoRespuesta.Focus(); return; }

            int espera = SegundosDeEspera();
            if (espera > 0)
            { Mostrar(lblMsgProblema, "Espere " + espera + " segundos antes de enviar otro mensaje.", true); return; }

            string referencia = Referencia("SOP");
            bool urgente = chkUrgente.Checked;
            string asuntoCorreo = "[" + referencia + "]" + (urgente ? " [URGENTE]" : "") + " " + categoria + " - " + asunto;

            StringBuilder cuerpo = new StringBuilder();
            cuerpo.AppendLine("REPORTE DE SOPORTE " + referencia);
            cuerpo.AppendLine("Prioridad:  " + (urgente ? "URGENTE (no puede trabajar)" : "Normal"));
            cuerpo.AppendLine("Categoría:  " + categoria);
            cuerpo.AppendLine("Asunto:     " + asunto);
            cuerpo.AppendLine("Responder a: " + (respuesta.Length > 0 ? respuesta : "(no dejó correo)"));
            cuerpo.AppendLine();
            cuerpo.AppendLine("----- DESCRIPCIÓN -----");
            cuerpo.AppendLine(descripcion);
            cuerpo.AppendLine();
            cuerpo.Append(DatosTecnicos());

            btnEnviarProblema.Enabled = false;
            btnEnviarProblema.Text = "Enviando...";
            btnEnviarProblema.Refresh();
            try
            {
                await EnviarCorreoAsync(asuntoCorreo, cuerpo.ToString(), respuesta);
                if (IsDisposed) return;

                ultimoEnvio = DateTime.Now;
                cmbCategoriaProblema.SelectedIndex = -1;
                txtAsunto.Clear();
                txtDescripcionDetallada.Clear();
                txtCorreoRespuesta.Clear();
                chkUrgente.Checked = false;
                Mostrar(lblMsgProblema, "Reporte enviado. Su número de referencia es " + referencia + ".", false);
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                Mostrar(lblMsgProblema, TextoFallo(ex), true);       
            }
            finally
            {
                if (!IsDisposed)
                {
                    btnEnviarProblema.Enabled = true;
                    btnEnviarProblema.Text = "Enviar reporte";
                }
            }
        }

        private async void btnEnviarRecomendacion_Click(object sender, EventArgs e)
        {
            Ocultar(lblMsgRecom);

            string recomendacion = txtRecomendacion.Text.Trim();
            if (recomendacion.Length < MinAsunto)
            { Mostrar(lblMsgRecom, "Escriba su recomendación antes de enviarla.", true, pnlRecom); txtRecomendacion.Focus(); return; }

            int espera = SegundosDeEspera();
            if (espera > 0)
            { Mostrar(lblMsgRecom, "Espere " + espera + " segundos antes de enviar otro mensaje.", true); return; }

            string referencia = Referencia("REC");
            StringBuilder cuerpo = new StringBuilder();
            cuerpo.AppendLine("RECOMENDACIÓN " + referencia);
            cuerpo.AppendLine();
            cuerpo.AppendLine("----- RECOMENDACIÓN -----");
            cuerpo.AppendLine(recomendacion);
            cuerpo.AppendLine();
            cuerpo.Append(DatosTecnicos());

            btnEnviarRecomendacion.Enabled = false;
            btnEnviarRecomendacion.Text = "Enviando...";
            btnEnviarRecomendacion.Refresh();
            try
            {
                await EnviarCorreoAsync("[" + referencia + "] Recomendación de mejora", cuerpo.ToString(), null);
                if (IsDisposed) return;

                ultimoEnvio = DateTime.Now;
                txtRecomendacion.Clear();
                Mostrar(lblMsgRecom, "¡Gracias! Su recomendación fue enviada.", false);
            }
            catch (Exception ex)
            {
                if (IsDisposed) return;
                Mostrar(lblMsgRecom, TextoFallo(ex), true);
            }
            finally
            {
                if (!IsDisposed)
                {
                    btnEnviarRecomendacion.Enabled = true;
                    btnEnviarRecomendacion.Text = "Enviar recomendación";
                }
            }
        }
    }
}