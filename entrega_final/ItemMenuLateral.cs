using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace pagina_principal
{
    // Opción del menú lateral: dibuja ella sola su icono, texto, estado activo, efecto del mouse e insignia.
    // En modo Compacto (menú plegado) solo muestra el icono centrado y la insignia como un punto.
    public class ItemMenuLateral : Control
    {
        private static readonly Color Amarillo = Color.FromArgb(250, 204, 21);
        private static readonly Color FondoActivo = Color.FromArgb(38, 42, 58);
        private static readonly Color FondoHover = Color.FromArgb(31, 34, 46);
        private static readonly Color FondoHoverPeligro = Color.FromArgb(52, 30, 34);
        private static readonly Color TextoNormal = Color.FromArgb(176, 186, 206);
        private static readonly Color IconoNormal = Color. FromArgb(170, 180, 200);
        private static readonly Color Rojo = Color.FromArgb(248, 113, 113);

        private string texto = "";
        private string icono = "inicio";
        private bool activo = false;
        private bool peligro = false;
        private bool compacto = false;
        private bool hover = false;
        private int insignia = 0;
        private Color colorInsignia = Color.FromArgb(239, 68, 68);

        private readonly Font fuenteNormal = new Font("Segoe UI", 10.5F);
        private readonly Font fuenteActiva = new Font("Segoe UI Semibold", 10.5F);
        private readonly Font fuenteInsignia = new Font("Segoe UI", 8.5F, FontStyle.Bold);

        public ItemMenuLateral()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            Size = new Size(279, 44);
            Cursor = Cursors.Hand;
            TabStop = false;
        }

        // ---------------- Propiedades que se pueden cambiar desde el Diseñador ----------------

        [Category("Menú"), DefaultValue("")]
        public string Texto
        {
            get { return texto; }
            set { texto = value ?? ""; AccessibleName = texto; Invalidate(); }
        }

        // inicio, activos, personal, planillas, salones, catalogo, reportar, ayuda, salir, menu
        [Category("Menú"), DefaultValue("inicio")]
        public string Icono
        {
            get { return icono; }
            set { icono = value ?? "inicio"; Invalidate(); }
        }

        // La opción de la sección que se está viendo
        [Category("Menú"), DefaultValue(false)]
        public bool Activo
        {
            get { return activo; }
            set { if (activo != value) { activo = value; Invalidate(); } }
        }

        // true = al pasar el mouse se pone rojizo (Cerrar sesión)
        [Category("Menú"), DefaultValue(false)]
        public bool Peligro
        {
            get { return peligro; }
            set { peligro = value; Invalidate(); }
        }

        // true = menú plegado: solo icono centrado y la insignia como punto
        [Category("Menú"), DefaultValue(false)]
        public bool Compacto
        {
            get { return compacto; }
            set { if (compacto != value) { compacto = value; Invalidate(); } }
        }

        // Número de aviso a la derecha (0 = no se muestra)
        [Category("Menú"), DefaultValue(0)]
        public int Insignia
        {
            get { return insignia; }
            set { if (insignia != value) { insignia = Math.Max(0, value); Invalidate(); } }
        }

        public Color ColorInsignia
        {
            get { return colorInsignia; }
            set { colorInsignia = value; Invalidate(); }
        }

        private bool ShouldSerializeColorInsignia() { return colorInsignia != Color.FromArgb(239, 68, 68); }
        private void ResetColorInsignia() { colorInsignia = Color.FromArgb(239, 68, 68); }

        // ---------------- Mouse ----------------
        protected override void OnMouseEnter(EventArgs e) { hover = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { hover = false; Invalidate(); base.OnMouseLeave(e); }
        protected override void OnEnabledChanged(EventArgs e) { Invalidate(); base.OnEnabledChanged(e); }

        // ---------------- Dibujo ----------------
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Color fondoPadre = Parent != null ? Parent.BackColor : Color. FromArgb(27, 29, 38);
            g.Clear(fondoPadre);

            bool resaltar = Enabled && hover;
            int margen = Height <= 40 ? 2 : 10;          // los botones pequeños (como el ☰) usan menos margen

            // fondo redondeado cuando está activa o con el mouse encima
            if (activo || resaltar)
            {
                Rectangle r = new Rectangle(margen, 2, Width - margen * 2, Height - 4);
                using (GraphicsPath ruta = Redondeado(r, 8))
                using (SolidBrush b = new SolidBrush(activo ? FondoActivo : (peligro ? FondoHoverPeligro : FondoHover)))
                    g.FillPath(b, ruta);
            }

            // barra amarilla a la izquierda de la opción activa
            if (activo && Height > 40)
            {
                using (GraphicsPath barra = Redondeado(new Rectangle(0, 10, 5, Height - 20), 2))
                using (SolidBrush b = new SolidBrush(Amarillo))
                    g.FillPath(b, barra);
            }

            Color colIcono = !Enabled ? Color.FromArgb(80, 86, 104)
                           : activo ? Amarillo
                           : resaltar ? (peligro ? Rojo : Color.White)
                           : IconoNormal;
            Color colTexto = !Enabled ? Color.FromArgb(90, 96, 114)
                           : activo ? Color.White
                           : resaltar ? (peligro ? Rojo : Color.White)
                           : TextoNormal;

            // el icono va a la izquierda, o centrado cuando el menú está plegado
            float xIcono = compacto ? (Width - 22) / 2f : 24;
            float yIcono = (Height - 22) / 2f;
            IconosMenu.Dibujar(g, icono, new RectangleF(xIcono, yIcono, 22, 22), colIcono);

            if (!compacto)
            {
                int reservado = insignia > 0 ? 64 : 16;
                Rectangle zonaTexto = new Rectangle(60, 0, Math.Max(10, Width - 60 - reservado), Height);
                TextRenderer.DrawText(g, texto, activo ? fuenteActiva : fuenteNormal, zonaTexto, colTexto,
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPadding);

                // insignia (cápsula con número)
                if (insignia > 0)
                {
                    string t = insignia > 99 ? "99+" : insignia.ToString();
                    Size medida = TextRenderer.MeasureText(g, t, fuenteInsignia, new Size(100, 20),
                        TextFormatFlags.NoPadding | TextFormatFlags.SingleLine);
                    int ancho = Math.Max(22, medida.Width + 14);
                    Rectangle cap = new Rectangle(Width - 22 - ancho, (Height - 20) / 2, ancho, 20);
                    using (GraphicsPath ruta = Redondeado(cap, 10))
                    using (SolidBrush b = new SolidBrush(colorInsignia))
                        g.FillPath(b, ruta);
                    TextRenderer.DrawText(g, t, fuenteInsignia, cap, Color.White,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
                }
            }
            else if (insignia > 0)
            {
                // menú plegado: la insignia es un punto de color en la esquina del icono
                Rectangle borde = new Rectangle((int)xIcono + 14, (int)yIcono - 5, 15, 15);
                Rectangle punto = new Rectangle(borde.X + 2, borde.Y + 2, 11, 11);
                using (SolidBrush b = new SolidBrush(fondoPadre)) g.FillEllipse(b, borde);      // contorno del color del fondo
                using (SolidBrush b = new SolidBrush(colorInsignia)) g.FillEllipse(b, punto);
            }
        }

        private static GraphicsPath Redondeado(Rectangle r, int radio)
        {
            int d = Math.Max(1, radio * 2);
            GraphicsPath p = new GraphicsPath();
            p.AddArc(r.X, r.Y, d, d, 180, 90);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            p.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            p.CloseFigure();
            return p;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                fuenteNormal.Dispose();
                fuenteActiva.Dispose();
                fuenteInsignia.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    // Iconos de línea (todos de la misma familia), dibujados en una cuadrícula de 24 x 24
    internal static class IconosMenu
    {
        public static void Dibujar(Graphics g, string nombre, RectangleF caja, Color color)
        {
            GraphicsState estado = g.Save();
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TranslateTransform(caja.X, caja.Y);
            float k = caja.Width / 24f;
            g.ScaleTransform(k, k);

            using (Pen p = new Pen(color, 1.8f) { StartCap = LineCap.Round, EndCap = LineCap.Round, LineJoin = LineJoin.Round })
            using (SolidBrush relleno = new SolidBrush(color))
            {
                switch (nombre)
                {
                    case "inicio":          // casa
                        g.DrawLines(p, new[] { new PointF(3, 11), new PointF(12, 3), new PointF(21, 11) });
                        g.DrawLines(p, new[] { new PointF(5.5f, 9.5f), new PointF(5.5f, 20), new PointF(18.5f, 20), new PointF(18.5f, 9.5f) });
                        g.DrawLines(p, new[] { new PointF(10, 20), new PointF(10, 14), new PointF(14, 14), new PointF(14, 20) });
                        break;

                    case "activos":         // caja / cubo de inventario
                        g.DrawPolygon(p, new[] { new PointF(12, 2.5f), new PointF(20.5f, 7), new PointF(20.5f, 17),
                                                 new PointF(12, 21.5f), new PointF(3.5f, 17), new PointF(3.5f, 7) });
                        g.DrawLines(p, new[] { new PointF(3.5f, 7), new PointF(12, 11.5f), new PointF(20.5f, 7) });
                        g.DrawLine(p, 12, 11.5f, 12, 21.5f);
                        break;

                    case "personal":        // dos personas
                        g.DrawEllipse(p, 4.5f, 3.5f, 7, 7);
                        g.DrawArc(p, 2.5f, 13.5f, 11, 11, 180, 180);
                        g.DrawEllipse(p, 14.5f, 5.5f, 5, 5);
                        g.DrawArc(p, 13f, 13.5f, 8, 8, 180, 180);
                        break;
                    case "usuarios":        // persona con signo +
                        g.DrawEllipse(p, 5, 4, 8, 8);
                        g.DrawArc(p, 2, 14, 14, 14, 180, 180);
                        g.DrawLine(p, 19.5f, 4.5f, 19.5f, 11.5f);
                        g.DrawLine(p, 16, 8, 23, 8);
                        break;
                    case "actividad":       // reloj: historial
                        g.DrawEllipse(p, 3, 3, 18, 18);
                        g.DrawLine(p, 12, 7, 12, 12);
                        g.DrawLine(p, 12, 12, 16, 14.5f);
                        break;
                    case "planillas":       // documento con renglones
                        g.DrawRectangle(p, 5, 3, 14, 18);
                        g.DrawLine(p, 8.5f, 9, 15.5f, 9);
                        g.DrawLine(p, 8.5f, 13, 15.5f, 13);
                        g.DrawLine(p, 8.5f, 17, 12.5f, 17);
                        break;

                    case "salones":         // pizarra
                        g.DrawRectangle(p, 3, 4, 18, 12);
                        g.DrawLine(p, 7, 8.5f, 13, 8.5f);
                        g.DrawLine(p, 12, 16, 12, 20);
                        g.DrawLine(p, 8, 20, 16, 20);
                        break;

                    case "catalogo":        // billete
                        g.DrawRectangle(p, 2.5f, 6, 19, 12);
                        g.DrawEllipse(p, 9, 9, 6, 6);
                        break;

                    case "reportar":        // triángulo de advertencia
                        g.DrawPolygon(p, new[] { new PointF(12, 3), new PointF(22, 20), new PointF(2, 20) });
                        g.DrawLine(p, 12, 9.5f, 12, 14);
                        g.FillEllipse(relleno, 11.1f, 16.2f, 1.8f, 1.8f);
                        break;

                    case "ayuda":           // círculo con signo de interrogación
                        g.DrawEllipse(p, 3, 3, 18, 18);
                        using (Font f = new Font("Segoe UI", 10.5F, FontStyle.Bold))
                        using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                        {
                            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                            g.DrawString("?", f, relleno, new RectangleF(3, 3.5f, 18, 18), sf);
                        }
                        break;

                    case "salir":           // puerta con flecha
                        g.DrawLines(p, new[] { new PointF(10, 3), new PointF(4, 3), new PointF(4, 21), new PointF(10, 21) });
                        g.DrawLine(p, 9, 12, 20, 12);
                        g.DrawLines(p, new[] { new PointF(16, 8), new PointF(20, 12), new PointF(16, 16) });
                        break;

                    case "menu":            // tres líneas (botón de plegar/expandir)
                        g.DrawLine(p, 4, 6.5f, 20, 6.5f);
                        g.DrawLine(p, 4, 12, 20, 12);
                        g.DrawLine(p, 4, 17.5f, 20, 17.5f);
                        break;
                }
            }
            g.Restore(estado);
        }
    }
}