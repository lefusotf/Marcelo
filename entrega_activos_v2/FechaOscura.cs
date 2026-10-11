using System;
using System.Drawing;
using System.Windows.Forms;

namespace Vistass
{
    // DateTimePicker con el aspecto oscuro del sistema.
    // En reposo se repinta (campo oscuro + flecha); mientras tiene el foco se deja el
    // dibujo nativo para que se vea qué parte de la fecha se está editando.
    public class FechaOscura : DateTimePicker
    {
        private const int WM_PAINT = 0x000F;

        public FechaOscura()
        {
            MinimumSize = new Size(0, 27);
            CalendarMonthBackground = PaletaSistema.Campo;
            CalendarForeColor = PaletaSistema.Texto;
            CalendarTitleBackColor = PaletaSistema.Amarillo;
            CalendarTitleForeColor = Color.FromArgb(20, 20, 20);
            CalendarTrailingForeColor = PaletaSistema.Tenue;
        }

        protected override void OnLeave(EventArgs e) { base.OnLeave(e); Invalidate(); }
        protected override void OnCloseUp(EventArgs eventargs) { base.OnCloseUp(eventargs); Invalidate(); }
        protected override void OnEnabledChanged(EventArgs e) { base.OnEnabledChanged(e); Invalidate(); }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_PAINT && !Focused) Repintar();
        }

        private void Repintar()
        {
            using (Graphics g = Graphics.FromHwnd(Handle))
            {
                Rectangle r = ClientRectangle;
                Color texto = Enabled ? PaletaSistema.Texto : Color.FromArgb(110, 118, 140);
                using (SolidBrush b = new SolidBrush(PaletaSistema.Campo))
                    g.FillRectangle(b, r);
                using (Pen borde = new Pen(Color.FromArgb(60, 66, 88)))
                    g.DrawRectangle(borde, 0, 0, r.Width - 1, r.Height - 1);

                TextRenderer.DrawText(g, Text, Font, new Rectangle(5, 0, r.Width - 30, r.Height), texto,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.NoPadding |
                    TextFormatFlags.EndEllipsis);

                // flecha (chevron) a la derecha
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                int cx = r.Width - 14, cy = r.Height / 2;
                using (Pen p = new Pen(Enabled ? PaletaSistema.Tenue : Color.FromArgb(90, 96, 116), 1.6f))
                {
                    p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                    p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                    g.DrawLine(p, cx - 4, cy - 2, cx, cy + 2);
                    g.DrawLine(p, cx, cy + 2, cx + 4, cy - 2);
                }
            }
        }
    }
}
