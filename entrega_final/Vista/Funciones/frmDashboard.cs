using CentroDeSoporte;
using Gestion_de_personal;
using loginn;
using Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vistass;
using System.IO;

namespace pagina_principal
{
    public partial class frmDashboard : Form
    {
        public static string RolUsuarioActual = "";

        private static readonly Color Amarillo = Color.FromArgb(250, 204, 21);
        private static readonly Color RojoAviso = Color.FromArgb(239, 68, 68);
        private static readonly Color AmbarAviso = Color.FromArgb(251, 191, 36);

        private const int AnchoAbierto = 281;                 
        private const int AnchoPlegado = 73;              
        private const int PasosAnimacion = 6;                 
        private const int AnchoPantallaParaPlegar = 1600;     
        private static readonly bool AnimarMenu = false;     

        private bool menuPlegado = false;                     
        private bool modoCompacto = false;                    
        private int anchoInicio, anchoFin, pasoActual;
        private readonly Timer timerMenu = new Timer { Interval = 20 };
        private readonly List<int> separadores = new List<int>();   

        private int scrollMenu;          
        private int altoContenidoMenu;   
        private RuedaMenu filtroRueda;   

        
        private ItemMenuLateral[] opcionesDeSeccion;
        private ItemMenuLateral[] todosLosItems;

    
        private readonly HashSet<ItemMenuLateral> ocultas = new HashSet<ItemMenuLateral>();


        private readonly Timer timerInsignias = new Timer { Interval = 60000 };

        public frmDashboard(string rolUsuario)
        {
            InitializeComponent();
            RolUsuarioActual = rolUsuario;
        }

        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            this.Text = ConfiguracionInicial.NombreEmpresa;

            if (string.IsNullOrEmpty(Sesion.Rol))
            {
                #if DEBUG
                                Sesion.Rol = "Administrador";  
                #else
                    this.Close();                  
                    return;
                #endif
            }

            opcionesDeSeccion = new[] { itmInicio, itmActivos, itmPersonal, itmPlanillas, itmSalones, itmCatalogo, itmReportar, itmUsuarios, itmActividad };
            todosLosItems = new[] { itmInicio, itmActivos, itmPersonal, itmPlanillas, itmSalones, itmCatalogo, itmReportar, itmUsuarios, itmActividad, itmAyuda, itmCerrarSesion };

            PrepararMarcaYUsuario();

            pnlMarca.Resize += (s, ev) => pnlMarca.Invalidate();
            pnlUsuario.Resize += (s, ev) => pnlUsuario.Invalidate();
            timerMenu.Tick += timerMenu_Tick;

            try
            {
                AplicarPermisosSidebar();

                bool plegadoInicial = LeerPreferenciaMenuPlegado()
                                      ?? (Screen.PrimaryScreen.WorkingArea.Width < AnchoPantallaParaPlegar);
                EstablecerMenuPlegado(plegadoInicial, false);

                AbrirFormularioEnContenedor(new frmInicio());
                MarcarActivo(itmInicio);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el Dashboard: " + ex.Message, "Error en Dashboard", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ActualizarInsignias();
            timerInsignias.Tick += (s, ev) => ActualizarInsignias();
            timerInsignias.Start();

            // Ventana normal de Windows, maximizada: barra de título con minimizar / restaurar / cerrar y sin hueco
            // hasta la barra de tareas. Si el usuario pulsa "restaurar", vuelve a un tamaño cómodo y centrado.
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MinimizeBox = true;
            this.MaximizeBox = true;
            this.WindowState = FormWindowState.Normal;
            this.ClientSize = new Size(1280, 720);
            this.CenterToScreen();
            this.WindowState = FormWindowState.Maximized;

            filtroRueda = new RuedaMenu(this);
            Application.AddMessageFilter(filtroRueda);
            this.FormClosed += (s, ev) => Application.RemoveMessageFilter(filtroRueda);
            pnlNavegacion.MouseDown += pnlNavegacion_MouseDown;
            pnlNavegacion.MouseMove += pnlNavegacion_MouseMove;
            pnlNavegacion.MouseUp += pnlNavegacion_MouseUp;
            pnlNavegacion.MouseLeave += pnlNavegacion_MouseLeave;
        }

        private void frmDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cerrar con la X sale del sistema: se pide confirmación y se registra la salida.
            // (Cerrar sesión desde el menú ya pregunta por su cuenta.)
            if (!cerrandoSesion && e.CloseReason == CloseReason.UserClosing && !string.IsNullOrEmpty(Sesion.Rol))
            {
                DialogResult r = MessageBox.Show("¿Desea salir del sistema?", "Salir",
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (r != DialogResult.Yes) { e.Cancel = true; return; }

                try
                {
                    Datos.Procedimiento("sp_RegistrarAcceso", Datos.P("@Usuario", Sesion.Usuario ?? ""), Datos.P("@Resultado", "Cerró sesión"));
                }
                catch { }
            }

            timerInsignias.Stop();
            timerMenu.Stop();
        }

        private void itmPlegar_Click(object sender, EventArgs e)
        {
            AlternarMenu();
        }

        private void AlternarMenu()
        {
            EstablecerMenuPlegado(!menuPlegado, true);
            GuardarPreferenciaMenuPlegado(menuPlegado);     
        }

        private void EstablecerMenuPlegado(bool plegar, bool animar)
        {
            menuPlegado = plegar;
            timerMenu.Stop();
            anchoInicio = pnlMenu.Width;
            anchoFin = plegar ? AnchoPlegado : AnchoAbierto;

            if (!animar || !AnimarMenu || anchoInicio == anchoFin)
            {
                pnlMenu.Width = anchoFin;
                AplicarModoMenu();
                return;
            }

            if (!plegar) AplicarModoMenu();
            pasoActual = 0;
            timerMenu.Start();
        }

        private void timerMenu_Tick(object sender, EventArgs e)
        {
            pasoActual++;
            double t = Math.Min(1.0, pasoActual / (double)PasosAnimacion);
            double suave = 1 - Math.Pow(1 - t, 2);                        
            pnlMenu.Width = anchoInicio + (int)Math.Round((anchoFin - anchoInicio) * suave);

            if (pasoActual >= PasosAnimacion)
            {
                timerMenu.Stop();
                pnlMenu.Width = anchoFin;
                if (menuPlegado) AplicarModoMenu();
            }
        }

      
        private void AplicarModoMenu()
        {
            modoCompacto = menuPlegado;

            foreach (ItemMenuLateral i in todosLosItems) i.Compacto = modoCompacto;

            lblInstitucion.Visible = !modoCompacto;
            lblSistema.Visible = !modoCompacto;
            lblUsuarioNombre.Visible = !modoCompacto;
            lblUsuarioRol.Visible = !modoCompacto;
            AjustarMarca();
            ReordenarMenu();
            ActualizarTooltips();
            pnlMarca.Invalidate();
            pnlUsuario.Invalidate();
        }

        private void AjustarMarca()
        {
            if (modoCompacto)
            {
                pbLogo.Location = new Point((AnchoPlegado - 1 - pbLogo.Width) / 2, 10);
                itmPlegar.Location = new Point((AnchoPlegado - 1 - itmPlegar.Width) / 2, 56);
            }
            else
            {
                pbLogo.Location = new Point(20, 26);
                itmPlegar.Location = new Point(232, 30);
            }
        }

        private void ActualizarTooltips()
        {
            foreach (ItemMenuLateral i in todosLosItems)
            {
                string tip = "";
                if (modoCompacto)
                {
                    tip = i.Texto;
                    if (i.Insignia > 0) tip += " (" + i.Insignia + ")";
                    if (ReferenceEquals(i, itmAyuda)) tip += " (F1)";
                }
                else if (ReferenceEquals(i, itmAyuda))
                {
                    tip = "Abre el manual de usuario (también con F1)";
                }
                toolTip1.SetToolTip(i, tip);
            }

            toolTip1.SetToolTip(itmPlegar, modoCompacto ? "Expandir menú (Ctrl+B)" : "Plegar menú (Ctrl+B)");
            toolTip1.SetToolTip(pnlUsuario, modoCompacto ? lblUsuarioNombre.Text + " · " + lblUsuarioRol.Text : "");
        }

        private static string RutaPreferencias
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                    "SistemaEscolar", "preferencias.txt");
            }
        }

        private static bool? LeerPreferenciaMenuPlegado()
        {
            try
            {
                if (!File.Exists(RutaPreferencias)) return null;
                foreach (string linea in File.ReadAllLines(RutaPreferencias))
                    if (linea.StartsWith("MenuPlegado=")) return linea.Substring("MenuPlegado=".Length).Trim() == "1";
            }
            catch { }
            return null;
        }

        private static void GuardarPreferenciaMenuPlegado(bool plegado)
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(RutaPreferencias));
                File.WriteAllText(RutaPreferencias, "MenuPlegado=" + (plegado ? "1" : "0"));
            }
            catch { }           
        }

        private void PrepararMarcaYUsuario()
        {
            string empresa = ConfiguracionInicial.NombreEmpresa;
            lblInstitucion.Text = string.IsNullOrWhiteSpace(empresa) ? "Sistema escolar" : empresa;
            pbLogo.Image = ConfiguracionInicial.Logotipo;

            bool tieneNombre = !string.IsNullOrWhiteSpace(Sesion.NombreCompleto);
            lblUsuarioNombre.Text = tieneNombre ? Sesion.NombreCompleto
                                  : string.IsNullOrWhiteSpace(Sesion.Usuario) ? "Usuario" : Sesion.Usuario;
            lblUsuarioRol.Text = (tieneNombre ? Sesion.Usuario + " · " : "") + (Sesion.Rol ?? "");
            pnlUsuario.Invalidate();
        }

        private void pbLogo_Paint(object sender, PaintEventArgs e)
        {
            if (pbLogo.Image != null) return;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle c = new Rectangle(0, 0, pbLogo.Width - 1, pbLogo.Height - 1);
            using (SolidBrush b = new SolidBrush(Amarillo)) g.FillEllipse(b, c);
            string inicial = string.IsNullOrWhiteSpace(lblInstitucion.Text) ? "S" : lblInstitucion.Text.Trim().Substring(0, 1).ToUpper();
            using (Font f = new Font("Segoe UI", 16F, FontStyle.Bold))
                TextRenderer.DrawText(g, inicial, f, c, Color. FromArgb(18, 18, 18),
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private void pnlMarca_Paint(object sender, PaintEventArgs e)
        {
            int m = modoCompacto ? 12 : 20;
            using (Pen l = new Pen(Color.FromArgb(45, 49, 66)))
                e.Graphics.DrawLine(l, m, pnlMarca.Height - 1, pnlMarca.Width - m, pnlMarca.Height - 1);
        }

        private void pnlUsuario_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int m = modoCompacto ? 12 : 20;
            using (Pen l = new Pen(Color.FromArgb(45, 49, 66)))
                g.DrawLine(l, m, 0, pnlUsuario.Width - m, 0);

            int xAvatar = modoCompacto ? (pnlUsuario.Width - 42) / 2 : 20;
            Rectangle avatar = new Rectangle(xAvatar, 16, 42, 42);
            using (SolidBrush b = new SolidBrush(Amarillo)) g.FillEllipse(b, avatar);
            string baseInicial = !string.IsNullOrWhiteSpace(Sesion.NombreCompleto) ? Sesion.NombreCompleto : Sesion.Usuario;
            string inicial = string.IsNullOrWhiteSpace(baseInicial) ? "U" : baseInicial.Trim().Substring(0, 1).ToUpper();
            using (Font f = new Font("Segoe UI", 14F, FontStyle.Bold))
                TextRenderer.DrawText(g, inicial, f, avatar, Color. FromArgb(18, 18, 18),
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

  
        private void Ocultar(ItemMenuLateral item)
        {
            ocultas.Add(item);
            item.Visible = false;
        }


        private void AplicarPermisosSidebar()
        {
            if (Sesion.Rol != "Administrador")
            {
                Ocultar(itmPlanillas);
                Ocultar(itmPersonal);
                Ocultar(itmSalones);
                Ocultar(itmActivos);
                Ocultar(itmCatalogo);
                Ocultar(itmUsuarios);
                Ocultar(itmActividad);
            }
        }


        private void DesplazarMenu(int delta)
        {
            scrollMenu += delta;
            ReordenarMenu();
        }

     
        private bool arrastrandoMenu;
        private bool encimaBarraMenu;
        private int agarreMenu;     

   
        private bool BarraMenu(out int top, out int largo)
        {
            int alto = pnlNavegacion.ClientSize.Height;
            top = 0; largo = 0;
            if (altoContenidoMenu <= alto) return false;

            largo = Math.Max(30, alto * alto / altoContenidoMenu);
            int recorrido = alto - largo;
            int maximo = altoContenidoMenu - alto;
            top = maximo <= 0 ? 0 : (int)((long)scrollMenu * recorrido / maximo);
            return true;
        }

        private bool EnPistaMenu(Point p)
        {
            int top, largo;
            return BarraMenu(out top, out largo) && p.X >= pnlNavegacion.ClientSize.Width - 10;
        }

        private void pnlNavegacion_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || !EnPistaMenu(e.Location)) return;

            int top, largo;
            BarraMenu(out top, out largo);

            if (e.Y < top || e.Y > top + largo)
                agarreMenu = largo / 2;                    
            else
                agarreMenu = e.Y - top;                      

            arrastrandoMenu = true;
            MoverBarraMenu(e.Y);
        }

        private void pnlNavegacion_MouseMove(object sender, MouseEventArgs e)
        {
            if (arrastrandoMenu) { MoverBarraMenu(e.Y); return; }

            bool encima = EnPistaMenu(e.Location);
            if (encima != encimaBarraMenu)
            {
                encimaBarraMenu = encima;
                pnlNavegacion.Invalidate();
            }
        }

        private void pnlNavegacion_MouseUp(object sender, MouseEventArgs e)
        {
            arrastrandoMenu = false;
            pnlNavegacion.Invalidate();
        }

        private void pnlNavegacion_MouseLeave(object sender, EventArgs e)
        {
            if (arrastrandoMenu || !encimaBarraMenu) return;
            encimaBarraMenu = false;
            pnlNavegacion.Invalidate();
        }

        private void MoverBarraMenu(int yPuntero)
        {
            int top, largo;
            if (!BarraMenu(out top, out largo)) return;

            int alto = pnlNavegacion.ClientSize.Height;
            int recorrido = Math.Max(1, alto - largo);
            int maximo = altoContenidoMenu - alto;

            int nuevoTop = Math.Max(0, Math.Min(recorrido, yPuntero - agarreMenu));
            scrollMenu = (int)((long)nuevoTop * maximo / recorrido);
            ReordenarMenu();
        }


        private class RuedaMenu : IMessageFilter
        {
            private readonly frmDashboard f;
            public RuedaMenu(frmDashboard f) { this.f = f; }

            public bool PreFilterMessage(ref Message m)
            {
                if (m.Msg != 0x020A) return false;                  
                Rectangle zona = f.pnlNavegacion.RectangleToScreen(f.pnlNavegacion.ClientRectangle);
                if (!zona.Contains(Cursor.Position)) return false;

                short giro = (short)((m.WParam.ToInt64() >> 16) & 0xFFFF);
                f.DesplazarMenu(-(giro / 120) * 44);               
                return true;
            }
        }

        private const int AltoOpcionMenu = 42;       // alto de cada opción del menú
        private const int AltoTituloGrupo = 20;      // alto del rótulo de cada grupo (PRINCIPAL, GESTIÓN…)
        private const int AireEntreGrupos = 8;       // espacio bajo cada grupo con el menú desplegado

        private void ReordenarMenu()
        {
            if (opcionesDeSeccion == null) return;

            var grupos = new List<KeyValuePair<Label, ItemMenuLateral[]>>
            {
                new KeyValuePair<Label, ItemMenuLateral[]>(lblGrpPrincipal, new[] { itmInicio }),
                new KeyValuePair<Label, ItemMenuLateral[]>(lblGrpGestion, new[] { itmActivos, itmPersonal, itmPlanillas, itmSalones }),
                new KeyValuePair<Label, ItemMenuLateral[]>(lblGrpOperacion, new[] { itmCatalogo, itmReportar }),
                new KeyValuePair<Label, ItemMenuLateral[]>(lblGrpSistema, new[] { itmUsuarios, itmActividad, itmAyuda })
            };

            int inicio = 12;
            int ancho = pnlNavegacion.ClientSize.Width - 8;      
            int maximo = Math.Max(0, altoContenidoMenu - pnlNavegacion.ClientSize.Height);
            scrollMenu = Math.Max(0, Math.Min(scrollMenu, maximo));

            separadores.Clear();
            int y = inicio - scrollMenu;
            bool primero = true;

            foreach (var grupo in grupos)
            {
                var visibles = grupo.Value.Where(i => !ocultas.Contains(i)).ToList();
                if (visibles.Count == 0) { grupo.Key.Visible = false; continue; }

                if (modoCompacto)
                {
                    grupo.Key.Visible = false;
                    if (!primero) { separadores.Add(y + 2); y += 10; }
                }
                else
                {
                    grupo.Key.Visible = true;
                    grupo.Key.Location = new Point(22, y);
                    y += AltoTituloGrupo;
                }

                foreach (ItemMenuLateral item in visibles)
                {
                    item.SetBounds(0, y, ancho, AltoOpcionMenu);
                    y += AltoOpcionMenu;
                }
                y += modoCompacto ? 4 : AireEntreGrupos;
                primero = false;
            }

            int nuevoAlto = y + scrollMenu + 12;
            bool cambio = nuevoAlto != altoContenidoMenu;
            altoContenidoMenu = nuevoAlto;
            pnlNavegacion.Invalidate();
            if (cambio) ReordenarMenu();
        }

        private void pnlNavegacion_Resize(object sender, EventArgs e)
        {
            ReordenarMenu();
        }

       
        private void pnlNavegacion_Paint(object sender, PaintEventArgs e)
        {
            if (modoCompacto && separadores.Count > 0)
            {
                using (Pen l = new Pen(Color.FromArgb(45, 49, 66)))
                    foreach (int sy in separadores)
                        e.Graphics.DrawLine(l, 18, sy, pnlNavegacion.ClientSize.Width - 18, sy);
            }

            int top, largo;
            if (!BarraMenu(out top, out largo)) return;

            bool activa = encimaBarraMenu || arrastrandoMenu;
            int grosor = activa ? 6 : 3;
            Color color = arrastrandoMenu ? Color.FromArgb(125, 133, 168)
                        : activa ? Color.FromArgb(95, 102, 135)
                        : Color.FromArgb(55, 60, 80);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using (SolidBrush b = new SolidBrush(color))
                e.Graphics.FillRectangle(b, pnlNavegacion.ClientSize.Width - grosor - 3, top + 2, grosor, largo - 4);
        }

        private void MarcarActivo(ItemMenuLateral item)
        {
            foreach (ItemMenuLateral i in opcionesDeSeccion)
                i.Activo = ReferenceEquals(i, item);
        }

        private void ActualizarInsignias()
        {
            try
            {
                DataRow r = Datos.Tabla(
                    @"SELECT COUNT(*) AS Total,
                             ISNULL(SUM(CASE WHEN Prioridad = 'Alta' THEN 1 ELSE 0 END), 0) AS Altas
                      FROM vw_ReportesDanio WHERE Estado = 'Abierto'").Rows[0];
                int total = Convert.ToInt32(r["Total"]);
                int altas = Convert.ToInt32(r["Altas"]);
                itmReportar.ColorInsignia = altas > 0 ? RojoAviso : AmbarAviso;
                itmReportar.Insignia = total;
            }
            catch { itmReportar.Insignia = 0; }

            try
            {
                if (!ocultas.Contains(itmPlanillas))
                {
                    int pend = Convert.ToInt32(Datos.Escalar(
                        @"SELECT COUNT(*) FROM PagosPlanilla
                          WHERE Anulado = 0 AND EstadoPago = 'Pendiente'
                            AND Periodo = DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1)"));
                    itmPlanillas.Insignia = pend;
                }
            }
            catch { itmPlanillas.Insignia = 0; }

            if (modoCompacto) ActualizarTooltips();          
        }

        private void AbrirFormularioEnContenedor(Form formularioHijo)
        {
            foreach (Control anterior in pnlContenedor.Controls.Cast<Control>().ToList())
            {
                pnlContenedor.Controls.Remove(anterior);
                anterior.Dispose();
            }

            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;

            this.pnlContenedor.Controls.Add(formularioHijo);
            this.pnlContenedor.Tag = formularioHijo;
            formularioHijo.Show();
        }

        private void Navegar(ItemMenuLateral item, Func<Form> crearFormulario)
        {
            try
            {
                AbrirFormularioEnContenedor(crearFormulario());
                MarcarActivo(item);
                ActualizarInsignias();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir la sección: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void IrA(string seccion)
        {
            switch (seccion)
            {
                case "catalogo":
                    Navegar(itmActivos, () => { var f = new frmGestionActivos(); f.IrAPestana(0); return f; }); break;
                case "prestamos":
                    Navegar(itmActivos, () => { var f = new frmGestionActivos(); f.IrAPestana(1); return f; }); break;
                case "consumibles":
                    Navegar(itmActivos, () => { var f = new frmGestionActivos(); f.IrAPestana(2); return f; }); break;
                case "reportes":
                    Navegar(itmReportar, () => new frmReportarDaño()); break;
                case "planillas":
                    Navegar(itmPlanillas, () => new frmGestionPlanillas()); break;
                case "personal":
                    Navegar(itmPersonal, () => new frmGestionPersonal()); break;
                case "actividad":
                    Navegar(itmActividad, () => new frmRegistroActividad()); break;
            }
        }

        private void itmInicio_Click(object sender, EventArgs e) { Navegar(itmInicio, () => new frmInicio()); }
        private void itmActivos_Click(object sender, EventArgs e) { Navegar(itmActivos, () => new frmGestionActivos()); }
        private void itmPersonal_Click(object sender, EventArgs e) { Navegar(itmPersonal, () => new frmGestionPersonal()); }
        private void itmPlanillas_Click(object sender, EventArgs e) { Navegar(itmPlanillas, () => new frmGestionPlanillas()); }
        private void itmSalones_Click(object sender, EventArgs e) { Navegar(itmSalones, () => new frmSalones()); }
        private void itmCatalogo_Click(object sender, EventArgs e) { Navegar(itmCatalogo, () => new frmCatalogoSalarios()); }
        private void itmReportar_Click(object sender, EventArgs e) { Navegar(itmReportar, () => new frmReportarDaño()); }
        private void itmUsuarios_Click(object sender, EventArgs e) { Navegar(itmUsuarios, () => new frmUsuarios()); }

        private void itmActividad_Click(object sender, EventArgs e) { Navegar(itmActividad, () => new frmRegistroActividad()); }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                AbrirManual("Manual_de_Usuario_ptc_2026.pdf");
                return true;
            }
            if (keyData == (Keys.Control | Keys.B))        
            {
                AlternarMenu();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void itmAyuda_Click(object sender, EventArgs e)
        {
            AbrirManual("Manual_de_Usuario_ptc_2026.pdf");
        }

        private void AbrirManual(string nombreArchivo)
        {
            try
            {
                string ruta = Path.Combine(Application.StartupPath, "Ayuda", nombreArchivo);

                if (!File.Exists(ruta))
                {
                    MessageBox.Show("No se encontró el manual solicitado. Contacte a soporte técnico.",
                                    "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Process.Start(new ProcessStartInfo(ruta) { UseShellExecute = true });
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo abrir el manual. Verifique que tenga un lector de PDF instalado.",
                                "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool cerrandoSesion = false;

        private void itmCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Está seguro de que desea cerrar sesión?",
                                  "Cerrar sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

           
            try
            {
                Datos.Procedimiento("sp_RegistrarAcceso", Datos.P("@Usuario", Sesion.Usuario ?? ""), Datos.P("@Resultado", "Cerró sesión"));
            }
            catch { }

            Sesion.Rol = null;
            Sesion.Usuario = null;
            Sesion.NombreCompleto = null;

            cerrandoSesion = true;

            Form login = Application.OpenForms.OfType<frmLogin>().FirstOrDefault();
            if (login == null)
                login = new frmLogin();

            login.Show();
            this.Close();
        }
    }
}