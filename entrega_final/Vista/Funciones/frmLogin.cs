using Modelos;
using pagina_principal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vistass;

namespace loginn
{
    public partial class frmLogin : Form
    {
        private static readonly Color Amarillo = Color.FromArgb(250, 204, 21);
        private static readonly Color AmarilloHover = Color.FromArgb(253, 224, 71);
        private static readonly Color Rojo = Color.FromArgb(248, 113, 113);
        private static readonly Color LineaNormal = Color.FromArgb(70, 75, 95);
        private static readonly Color Suave = Color.FromArgb(170, 180, 200);

        private bool claveVisible = false;       
        private bool errUsuario = false;         
        private bool errClave = false;
        private bool conexionFallida = false;    

        // Bloqueo temporal: tras varios intentos fallidos con el mismo usuario hay que esperar un momento.
        // Frena a quien prueba contraseñas una tras otra. Se guarda en memoria (se reinicia al cerrar el programa).
        private const int MaxFallos = 5;
        private const int SegundosBloqueo = 60;
        private static readonly Dictionary<string, int> fallosPorUsuario = new Dictionary<string, int>();
        private static readonly Dictionary<string, DateTime> bloqueadoHasta = new Dictionary<string, DateTime>();

        private string motivoRechazo = null;          
        private string nombreCompletoObtenido = "";

        public frmLogin()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                        ControlStyles.UserPaint |
                        ControlStyles.OptimizedDoubleBuffer,
                        true);
            this.UpdateStyles();

         
            pnlTarjeta.Region = new Region(Redondeado(new Rectangle(0, 0, pnlTarjeta.Width, pnlTarjeta.Height), 18));
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnVer, "Mostrar/Ocultar Contraseña");
            toolTip1.SetToolTip(lnkOlvidoContraseña, "Recuperar Contraseña");
            toolTip1.SetToolTip(btnIniciarSesion, "Iniciar Sesión");
            toolTip1.SetToolTip(txtUsuario, "Ingrese su nombre de usuario");
            toolTip1.SetToolTip(txtContraseña, "Ingrese su contraseña");

            CentrarTarjeta();
            txtUsuario.Focus();             
        }

      

     
        private void CentrarTarjeta()
        {
            pnlTarjeta.Left = (this.ClientSize.Width - pnlTarjeta.Width) / 2;
            pnlTarjeta.Top = Math.Max(10, (this.ClientSize.Height - pnlTarjeta.Height) / 2);
        }

        private void frmLogin_Resize(object sender, EventArgs e)
        {
            CentrarTarjeta();
        }

    
        private static GraphicsPath Redondeado(Rectangle r, int radio)
        {
            int d = radio * 2;
            GraphicsPath p = new GraphicsPath();
            p.AddArc(r.X, r.Y, d, d, 180, 90);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            p.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            p.CloseFigure();
            return p;
        }

        
        private void pnlTarjeta_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath ruta = Redondeado(new Rectangle(1, 1, pnlTarjeta.Width - 3, pnlTarjeta.Height - 3), 18))
            using (Pen lapiz = new Pen(Color.FromArgb(130, 250, 204, 21), 1.5f))
                e.Graphics.DrawPath(lapiz, ruta);
        }

        
        private void Campo_Paint(object sender, PaintEventArgs e)
        {
            Panel p = (Panel)sender;
            bool esUsuario = ReferenceEquals(p, pnlUsuario);
            TextBox caja = esUsuario ? txtUsuario : txtContraseña;
            bool error = esUsuario ? errUsuario : errClave;

            Color color = error ? Rojo : (caja.Focused ? Amarillo : LineaNormal);
            using (SolidBrush b = new SolidBrush(color))
                e.Graphics.FillRectangle(b, 0, p.Height - 2, p.Width, 2);
        }

   
        private void Campo_Click(object sender, EventArgs e)
        {
            if (ReferenceEquals(sender, pnlUsuario)) txtUsuario.Focus();
            else txtContraseña.Focus();
        }

        
        private void Campo_FocoCambia(object sender, EventArgs e)
        {
            pnlUsuario.Invalidate();
            pnlClave.Invalidate();
            RevisarMayus();
        }

 
        private void Campo_TextChanged(object sender, EventArgs e)
        {
            OcultarError();
        }

        private void Campo_KeyUp(object sender, KeyEventArgs e)
        {
            RevisarMayus();
        }

        private void frmLogin_Activated(object sender, EventArgs e)
        {
            RevisarMayus();
        }

       
        private void RevisarMayus()
        {
            lblMayus.Visible = Control.IsKeyLocked(Keys.CapsLock) && txtContraseña.ContainsFocus;
        }

   
        private void Boton_Hover(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.BackColor = b.ClientRectangle.Contains(b.PointToClient(Cursor.Position)) ? AmarilloHover : Amarillo;
        }

     
        private void btnVer_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            float cx = btnVer.Width / 2f, cy = btnVer.Height / 2f;
            Color color = claveVisible ? Amarillo : Suave;

            using (Pen lapiz = new Pen(color, 1.8f))
            using (SolidBrush pincel = new SolidBrush(color))
            {
                g.DrawBezier(lapiz, cx - 10, cy, cx - 5, cy - 9, cx + 5, cy - 9, cx + 10, cy);
                g.DrawBezier(lapiz, cx - 10, cy, cx - 5, cy + 9, cx + 5, cy + 9, cx + 10, cy);
                g.FillEllipse(pincel, cx - 3.5f, cy - 3.5f, 7, 7);                 // pupila

                if (claveVisible) g.DrawLine(lapiz, cx - 9, cy + 9, cx + 9, cy - 9);
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            claveVisible = !claveVisible;
            txtContraseña.PasswordChar = claveVisible ? '\0' : '•';
            btnVer.Invalidate();
            txtContraseña.Focus();
        }

        private void MostrarError(string mensaje)
        {
            lblError.Text = mensaje;
            lblError.Visible = true;
            pnlUsuario.Invalidate();
            pnlClave.Invalidate();
        }

        private void OcultarError()
        {
            if (!lblError.Visible && !errUsuario && !errClave) return;
            lblError.Visible = false;
            errUsuario = false;
            errClave = false;
            pnlUsuario.Invalidate();
            pnlClave.Invalidate();
        }

        private string ValidarCredenciales(string user, string pass)
        {
            string nombreRol = null;
            string query = @"SELECT r.NombreRol, u.Clave, u.IdUsuario, u.Activo, u.NombreCompleto
                     FROM Usuarios u
                     INNER JOIN Roles r ON u.IdRol = r.IdRol
                     WHERE u.Usuario = @user";

            using (SqlConnection conexion = Conexion.Conectar())
            {
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@user", user);

                    try
                    {
                        conexion.Open();
                        string hashGuardado = null;
                        int idUsuario = 0;
                        bool activo = true;
                        string nombreCompleto = "";
                        

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                nombreRol = reader["NombreRol"].ToString();
                                hashGuardado = reader["Clave"].ToString();
                                idUsuario = Convert.ToInt32(reader["IdUsuario"]);
                                activo = Convert.ToBoolean(reader["Activo"]);
                                nombreCompleto = reader["NombreCompleto"] == DBNull.Value ? "" : reader["NombreCompleto"].ToString();
                            }
                        }

                        if (!string.IsNullOrEmpty(hashGuardado))
                        {
                            bool esValido = false;

                            if (!hashGuardado.StartsWith("$2"))
                            {
                                if (hashGuardado == pass)
                                {
                                    string nuevoHash = Modelos.Utils.PasswordHasher.Hash(pass);

                                    using (SqlCommand updateCmd = new SqlCommand(
                                        "UPDATE Usuarios SET Clave = @nuevoHash WHERE IdUsuario = @id", conexion))
                                    {
                                        updateCmd.Parameters.AddWithValue("@nuevoHash", nuevoHash);
                                        updateCmd.Parameters.AddWithValue("@id", idUsuario);
                                        updateCmd.ExecuteNonQuery();
                                    }
                                    esValido = true;
                                }
                            }
                            else
                            {
                                try
                                {
                                    esValido = Modelos.Utils.PasswordHasher.Verificar(pass, hashGuardado);
                                }
                                catch
                                {
                                    esValido = false;
                                }

                        
                                if (!esValido)
                                {
                                    nombreRol = null;
                                }
                                else if (!activo)
                                {
                                    nombreRol = null;
                                    motivoRechazo = "inactivo";
                                }
                                else if (!string.Equals(nombreRol, "Administrador", StringComparison.OrdinalIgnoreCase))
                                {
                                    nombreRol = null;
                                    motivoRechazo = "no_admin";
                                }
                                else
                                {
                                    nombreCompletoObtenido = nombreCompleto;
                                }
                                
                            }

                            if (!esValido)
                            {
                                nombreRol = null;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        conexionFallida = true;     
                        MessageBox.Show("Error de conexión al validar credenciales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        nombreRol = null;
                    }
                }
            }
            return nombreRol;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            OcultarError();

            string usuarioIngresado = txtUsuario.Text.Trim();
            string claveIngresada = txtContraseña.Text.Trim();

            
            bool falta = string.IsNullOrEmpty(usuarioIngresado) || string.IsNullOrEmpty(claveIngresada);
            if (falta)
            {
                errUsuario = string.IsNullOrEmpty(usuarioIngresado);
                errClave = string.IsNullOrEmpty(claveIngresada);
                MostrarError(errUsuario && errClave ? "Ingrese el usuario y la contraseña."
                           : errUsuario ? "Ingrese el usuario."
                           : "Ingrese la contraseña.");
                (errUsuario ? txtUsuario : txtContraseña).Focus();
                return;
            }

            string llaveUsuario = usuarioIngresado.ToLowerInvariant();
            DateTime hastaCuando;
            if (bloqueadoHasta.TryGetValue(llaveUsuario, out hastaCuando) && hastaCuando > DateTime.Now)
            {
                int faltan = (int)Math.Ceiling((hastaCuando - DateTime.Now).TotalSeconds);
                txtContraseña.Clear();
                errUsuario = true;
                MostrarError("Demasiados intentos fallidos. Espere " + faltan + " segundos para volver a intentarlo.");
                return;
            }

            btnIniciarSesion.Enabled = false;
            btnIniciarSesion.Text = "Ingresando...";
            btnIniciarSesion.Refresh();

            string rolObtenido;
            conexionFallida = false;
            motivoRechazo = null;
            nombreCompletoObtenido = "";
            try
            {
                rolObtenido = ValidarCredenciales(usuarioIngresado, claveIngresada);
            }
            finally
            {
                btnIniciarSesion.Enabled = true;
                btnIniciarSesion.Text = "Iniciar sesión";
            }

            if (!string.IsNullOrEmpty(rolObtenido))
            {
                fallosPorUsuario.Remove(llaveUsuario);       // entró bien: se borra el conteo de fallos
                bloqueadoHasta.Remove(llaveUsuario);
                Modelos.Sesion.Usuario = usuarioIngresado;
                Modelos.Sesion.Rol = rolObtenido;
                Modelos.Sesion.NombreCompleto = nombreCompletoObtenido;
                RegistrarAcceso(usuarioIngresado, "Inició sesión");

            
                if (ServicioUsuarios.DebeCambiarClave(usuarioIngresado))
                {
                    bool cambio;
                    using (dlgCambiarClave dlg = new dlgCambiarClave(true, usuarioIngresado))
                        cambio = dlg.ShowDialog(this) == DialogResult.OK;

                    if (!cambio)
                    {
                       
                        Modelos.Sesion.Usuario = null;
                        Modelos.Sesion.Rol = null;
                        Modelos.Sesion.NombreCompleto = null;
                        txtContraseña.Clear();
                        MostrarError("Debe cambiar la contraseña temporal para poder entrar.");
                        return;
                    }
                }
                this.Hide();

                try
                {
                    using (frmDashboard dashboard = new frmDashboard())
                    {
                        dashboard.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al cargar el Dashboard:\n" + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (string.IsNullOrEmpty(Modelos.Sesion.Rol))
                {
                    txtUsuario.Clear();
                    txtContraseña.Clear();
                    this.Show();
                    txtUsuario.Focus();
                }
                else
                {
                    this.Close();
                }
            }
            else if (!conexionFallida)
            {
                RegistrarAcceso(usuarioIngresado,
                    motivoRechazo == "inactivo" ? "Intento con cuenta desactivada"
                    : motivoRechazo == "no_admin" ? "Intento sin permiso"
                    : "Intento fallido");

                txtContraseña.Clear();
                errUsuario = true;
                errClave = true;
                string mensajeError = motivoRechazo == "inactivo" ? "Esta cuenta está desactivada. Contacte a un administrador."
                           : motivoRechazo == "no_admin" ? "Esta cuenta no tiene permiso para usar el sistema."
                           : "Usuario o contraseña incorrectos.";

                if (motivoRechazo == null)                    // contraseña equivocada: se cuenta el fallo
                {
                    int fallos;
                    fallosPorUsuario.TryGetValue(llaveUsuario, out fallos);
                    fallos++;
                    if (fallos >= MaxFallos)
                    {
                        fallosPorUsuario.Remove(llaveUsuario);
                        bloqueadoHasta[llaveUsuario] = DateTime.Now.AddSeconds(SegundosBloqueo);
                        mensajeError = "Demasiados intentos fallidos. Espere " + SegundosBloqueo + " segundos para volver a intentarlo.";
                    }
                    else
                    {
                        fallosPorUsuario[llaveUsuario] = fallos;
                        if (fallos >= MaxFallos - 2)
                            mensajeError += " Le quedan " + (MaxFallos - fallos) + (MaxFallos - fallos == 1 ? " intento." : " intentos.");
                    }
                }
                MostrarError(mensajeError);
                txtContraseña.Focus();
            }
        }
        private static void RegistrarAcceso(string usuario, string resultado)
        {
            try
            {
                Datos.Procedimiento("sp_RegistrarAcceso",
                    Datos.P("@Usuario", usuario.Length > 50 ? usuario.Substring(0, 50) : usuario),
                    Datos.P("@Resultado", resultado));
            }
            catch { }       
        }
        private void lnkOlvidoContraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRecuperarContraseña frm = new frmRecuperarContraseña();
            frm.ShowDialog();
        }
    }
}