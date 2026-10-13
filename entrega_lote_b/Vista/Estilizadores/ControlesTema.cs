using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Vistass
{
   
    public static class PaletaSistema
    {
        public static readonly Color Fondo = Color.FromArgb(18, 18, 18);
        public static readonly Color Tarjeta = Color.FromArgb(27, 29, 38);
        public static readonly Color Campo = Color.FromArgb(38, 42, 58);
        public static readonly Color Borde = Color.FromArgb(45, 50, 63);
        public static readonly Color Amarillo = Color.FromArgb(250, 204, 21);
        public static readonly Color Gris = Color.FromArgb(55, 60, 80);
        public static readonly Color Rojo = Color.FromArgb(220, 53, 69);
        public static readonly Color Texto = Color.FromArgb(240, 244, 252);
        public static readonly Color Tenue = Color.FromArgb(170, 180, 200);
    }

    public enum TipoBoton { Principal, Secundario, Peligro }


    [DesignerCategory("Code")]
    public class BotonTema : Button
    {
        private TipoBoton tipo = TipoBoton.Principal;

        [Category("Tema"), DefaultValue(TipoBoton.Principal), Description("Principal = amarillo, Secundario = gris, Peligro = rojo")]
        public TipoBoton Tipo
        {
            get { return tipo; }
            set { tipo = value; Aplicar(); }
        }

        public BotonTema()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            UseVisualStyleBackColor = false;
            Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            TextAlign = ContentAlignment.MiddleCenter;
            Aplicar();
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            Aplicar();
        }

        private void Aplicar()
        {
            Color fondo = tipo == TipoBoton.Peligro ? PaletaSistema.Rojo
                        : tipo == TipoBoton.Secundario ? PaletaSistema.Gris
                        : PaletaSistema.Amarillo;
            Color letra = tipo == TipoBoton.Principal ? PaletaSistema.Fondo : Color.White;

            if (!Enabled)
            {
                fondo = PaletaSistema.Campo;
                letra = Color.FromArgb(105, 113, 138);
            }

            BackColor = fondo;
            ForeColor = letra;
            Cursor = Enabled ? Cursors.Hand : Cursors.Default;
            FlatAppearance.MouseOverBackColor = Enabled ? Aclarar(fondo, 18) : fondo;
            FlatAppearance.MouseDownBackColor = Enabled ? Aclarar(fondo, -12) : fondo;
        }

        private static Color Aclarar(Color c, int delta)
        {
            return Color.FromArgb(Math.Max(0, Math.Min(255, c.R + delta)),
                                  Math.Max(0, Math.Min(255, c.G + delta)),
                                  Math.Max(0, Math.Min(255, c.B + delta)));
        }
    }

    [DesignerCategory("Code")]
    public class PanelTarjeta : Panel
    {
        public PanelTarjeta()
        {
            BackColor = PaletaSistema.Tarjeta;
            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen p = new Pen(PaletaSistema.Borde))
                e.Graphics.DrawRectangle(p, 0, 0, Width - 1, Height - 1);
        }
    }

    [DesignerCategory("Code")]
    public class GridOscuro : DataGridView
    {
        private static readonly Color Cabecera = Color.FromArgb(34, 38, 52);
        private static readonly Color FilaA = Color.FromArgb(23, 25, 33);
        private static readonly Color FilaB = Color.FromArgb(31, 34, 45);
        private static readonly Color FilaSeleccion = Color.FromArgb(58, 66, 98);
        private static readonly Color FilaHover = Color.FromArgb(42, 47, 66);

        private int filaHover = -1;
        private BarraFina barraV;
        private BarraFina barraH;
        private bool actualizacionPendiente;



        public GridOscuro()
        {
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToResizeRows = false;
            ReadOnly = true;
            RowHeadersVisible = false;
            MultiSelect = false;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            BackgroundColor = PaletaSistema.Tarjeta;
            BorderStyle = BorderStyle.None;
            CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            GridColor = Color.FromArgb(38, 42, 56);
            EnableHeadersVisualStyles = false;

            ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            ColumnHeadersHeight = 40;
            RowTemplate.Height = 36;

            ColumnHeadersDefaultCellStyle.BackColor = Cabecera;
            ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            ColumnHeadersDefaultCellStyle.SelectionBackColor = Cabecera;
            ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 8, 0);

            DefaultCellStyle.BackColor = FilaA;
            DefaultCellStyle.ForeColor = PaletaSistema.Texto;
            DefaultCellStyle.Padding = new Padding(8, 0, 8, 0);
            DefaultCellStyle.SelectionBackColor = FilaSeleccion;
            DefaultCellStyle.SelectionForeColor = Color.White;
            AlternatingRowsDefaultCellStyle.BackColor = FilaB;


        }

        private void CambiarHover(int nueva)
        {
            if (nueva == filaHover) return;
            int anterior = filaHover;
            filaHover = nueva;
            if (anterior >= 0 && anterior < RowCount) InvalidateRow(anterior);
            if (nueva >= 0 && nueva < RowCount) InvalidateRow(nueva);
        }

        protected override void OnCellMouseEnter(DataGridViewCellEventArgs e)
        {
            base.OnCellMouseEnter(e);
            CambiarHover(e.RowIndex);
        }

        protected override void OnCellMouseLeave(DataGridViewCellEventArgs e)
        {
            base.OnCellMouseLeave(e);
            CambiarHover(-1);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            CambiarHover(-1);
        }

        protected override void OnCellFormatting(DataGridViewCellFormattingEventArgs e)
        {
            base.OnCellFormatting(e);
            if (e.RowIndex >= 0 && e.RowIndex == filaHover &&
                (Rows.GetRowState(e.RowIndex) & DataGridViewElementStates.Selected) == 0)
                e.CellStyle.BackColor = FilaHover;
        }

        protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
        {
            base.OnRowPostPaint(e);
            if ((e.State & DataGridViewElementStates.Selected) == 0) return;
            using (SolidBrush b = new SolidBrush(PaletaSistema.Amarillo))
                e.Graphics.FillRectangle(b, 0, e.RowBounds.Top, 3, e.RowBounds.Height - 1);
        }

        internal ScrollBar NativaV { get { return VerticalScrollBar; } }
        internal ScrollBar NativaH { get { return HorizontalScrollBar; } }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (DesignMode || barraV != null) return;      

            barraV = new BarraFina(this, true);
            barraH = new BarraFina(this, false);
            Controls.Add(barraV);
            Controls.Add(barraH);
            ProgramarActualizacion();
        }

        private void ProgramarActualizacion()
        {
            if (actualizacionPendiente || barraV == null || !IsHandleCreated) return;
            actualizacionPendiente = true;
            BeginInvoke(new Action(ActualizarBarras));
        }

        private void ActualizarBarras()
        {
            actualizacionPendiente = false;
            if (IsDisposed || barraV == null) return;
            Sincronizar(barraV, NativaV);
            Sincronizar(barraH, NativaH);
        }
        private static void Sincronizar(BarraFina barra, ScrollBar nativa)
        {
            if (!nativa.Visible)
            {
                if (barra.Visible) barra.Visible = false;
                return;
            }

            if (barra.Bounds != nativa.Bounds) barra.Bounds = nativa.Bounds;  
            if (!barra.Visible)
            {
                barra.Visible = true;
                barra.BringToFront();   
            }
        }

        protected override void OnLayout(LayoutEventArgs e) { base.OnLayout(e); ProgramarActualizacion(); }
        protected override void OnScroll(ScrollEventArgs e) { base.OnScroll(e); ProgramarActualizacion(); }
        protected override void OnRowsAdded(DataGridViewRowsAddedEventArgs e) { base.OnRowsAdded(e); ProgramarActualizacion(); }
        protected override void OnRowsRemoved(DataGridViewRowsRemovedEventArgs e) { base.OnRowsRemoved(e); ProgramarActualizacion(); }
        protected override void OnColumnWidthChanged(DataGridViewColumnEventArgs e) { base.OnColumnWidthChanged(e); ProgramarActualizacion(); }
        protected override void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e) { base.OnDataBindingComplete(e); ProgramarActualizacion(); }
        protected override void OnVisibleChanged(EventArgs e) { base.OnVisibleChanged(e); ProgramarActualizacion(); }

        private int ultimaFila = -2;
        private int ultimoDesplazamiento = -1;

        // Si la última fila visible no cabe completa, el grid la dibuja cortada por la mitad.
        // Se tapa esa franja con el color de fondo para que la tabla termine limpia en una fila
        // completa. Solo se consultan medidas del grid (no se tocan las filas) para no alterar el pintado.
        private void OcultarFilaParcial(Graphics g)
        {
            if (RowCount == 0 || FirstDisplayedScrollingRowIndex < 0) return;

            int completas = DisplayedRowCount(false);          // filas que caben enteras
            if (completas <= 0 || DisplayedRowCount(true) <= completas) return;   // no hay fila a medias

            int ultima = FirstDisplayedScrollingRowIndex + completas - 1;
            int fondo = GetRowDisplayRectangle(ultima, true).Bottom;
            int limite = ClientSize.Height - (HorizontalScrollBar.Visible ? HorizontalScrollBar.Height : 0);
            int ancho = ClientSize.Width - (VerticalScrollBar.Visible ? VerticalScrollBar.Width : 0);
            if (limite <= fondo) return;

            using (SolidBrush br = new SolidBrush(BackgroundColor))
                g.FillRectangle(br, 0, fondo, ancho, limite - fondo);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            OcultarFilaParcial(e.Graphics);

            if (ColumnCount > 0)
                using (SolidBrush b = new SolidBrush(Color.FromArgb(200, PaletaSistema.Amarillo)))
                    e.Graphics.FillRectangle(b, 0, ColumnHeadersHeight - 2, ClientSize.Width, 2);

       
            if (barraV == null) return;
            int fila = FirstDisplayedScrollingRowIndex;
            int desp = HorizontalScrollingOffset;
            if (fila != ultimaFila || desp != ultimoDesplazamiento)
            {
                ultimaFila = fila;
                ultimoDesplazamiento = desp;
                barraV.Invalidate();
                barraH.Invalidate();
            }
        }
    }

 
    internal sealed class BarraFina : Control
    {
        private readonly DataGridView grid;
        private readonly bool vertical;
        private bool encima;
        private bool arrastrando;
        private int agarre;      

        public BarraFina(DataGridView grid, bool vertical)
        {
            this.grid = grid;
            this.vertical = vertical;
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.Selectable, false);
            TabStop = false;
            Visible = false;
        }

        
        private void Medidas(out int total, out int visible, out int pos)
        {
            if (vertical)
            {
                total = grid.RowCount;
                visible = grid.DisplayedRowCount(true);
                pos = Math.Max(0, grid.FirstDisplayedScrollingRowIndex);
            }
            else
            {
                total = grid.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);
                visible = Width;
                pos = grid.HorizontalScrollingOffset;
            }
        }

        private void Geometria(int total, int visible, int pos, out int ini, out int largo, out int pista)
        {
            pista = (vertical ? Height : Width) - 8;
            largo = (int)Math.Max(28, Math.Min(pista, (long)pista * visible / Math.Max(1, total)));
            int rango = Math.Max(1, total - visible);
            ini = 4 + (int)((long)(pista - largo) * Math.Min(pos, rango) / rango);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(PaletaSistema.Tarjeta);

            int total, visible, pos;
            Medidas(out total, out visible, out pos);
            if (total <= visible) return;

            int ini, largo, pista;
            Geometria(total, visible, pos, out ini, out largo, out pista);

            int grosor = (encima || arrastrando) ? 8 : 6;
            Rectangle m = vertical
                ? new Rectangle((Width - grosor) / 2, ini, grosor, largo)
                : new Rectangle(ini, (Height - grosor) / 2, largo, grosor);

            Color c = arrastrando ? Color.FromArgb(125, 133, 168)
                    : encima ? Color.FromArgb(100, 108, 142)
                    : Color.FromArgb(72, 79, 106);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath gp = Pastilla(m))
            using (SolidBrush b = new SolidBrush(c))
                e.Graphics.FillPath(b, gp);
        }

        private static GraphicsPath Pastilla(Rectangle r)
        {
            int d = Math.Min(r.Width, r.Height);
            GraphicsPath p = new GraphicsPath();
            p.AddArc(r.X, r.Y, d, d, 180, 90);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            p.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            p.CloseFigure();
            return p;
        }

       
        private void Mover(int punto)
        {
            int total, visible, pos;
            Medidas(out total, out visible, out pos);
            if (total <= visible) return;

            int ini, largo, pista;
            Geometria(total, visible, pos, out ini, out largo, out pista);

            int libre = Math.Max(1, pista - largo);
            int nuevoIni = Math.Max(4, Math.Min(4 + libre, punto - agarre));
            int rango = total - visible;
            int destino = (int)(((long)(nuevoIni - 4) * rango + libre / 2) / libre);

            try
            {
                if (vertical)
                {
                    if (grid.RowCount > 0)
                        grid.FirstDisplayedScrollingRowIndex = Math.Max(0, Math.Min(destino, grid.RowCount - 1));
                }
                else grid.HorizontalScrollingOffset = Math.Max(0, Math.Min(destino, rango));
            }
            catch (InvalidOperationException) { }
            catch (ArgumentOutOfRangeException) { }
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button != MouseButtons.Left) return;

            int total, visible, pos;
            Medidas(out total, out visible, out pos);
            if (total <= visible) return;

            int ini, largo, pista;
            Geometria(total, visible, pos, out ini, out largo, out pista);

            int punto = vertical ? e.Y : e.X;
         
            agarre = (punto >= ini && punto <= ini + largo) ? punto - ini : largo / 2;
            arrastrando = true;
            Mover(punto);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (arrastrando) Mover(vertical ? e.Y : e.X);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            arrastrando = false;
            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e) { base.OnMouseEnter(e); encima = true; Invalidate(); }
        protected override void OnMouseLeave(EventArgs e) { base.OnMouseLeave(e); encima = false; Invalidate(); }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (!vertical || grid.RowCount == 0) return;
            try
            {
                int fila = Math.Max(0, grid.FirstDisplayedScrollingRowIndex) - Math.Sign(e.Delta) * 3;
                grid.FirstDisplayedScrollingRowIndex = Math.Max(0, Math.Min(fila, grid.RowCount - 1));
            }
            catch (InvalidOperationException) { }
            Invalidate();
        }
    }

    [DesignerCategory("Code")]
    public class ComboOscuro : ComboBox
    {
        private const int WM_PAINT = 0x000F;
        private bool encima;

        public ComboOscuro()
        {
            DropDownStyle = ComboBoxStyle.DropDownList;
            DrawMode = DrawMode.OwnerDrawFixed;
            FlatStyle = FlatStyle.Flat;
            BackColor = PaletaSistema.Campo;
            ForeColor = PaletaSistema.Texto;
            ItemHeight = 20;
        }

        protected override void OnMouseEnter(EventArgs e) { base.OnMouseEnter(e); encima = true; Invalidate(); }
        protected override void OnMouseLeave(EventArgs e) { base.OnMouseLeave(e); encima = false; Invalidate(); }
        protected override void OnGotFocus(EventArgs e) { base.OnGotFocus(e); Invalidate(); }
        protected override void OnLostFocus(EventArgs e) { base.OnLostFocus(e); Invalidate(); }

     
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            bool resaltado = (e.State & DrawItemState.Selected) != 0;

            using (SolidBrush fondo = new SolidBrush(resaltado ? PaletaSistema.Gris : PaletaSistema.Campo))
                e.Graphics.FillRectangle(fondo, e.Bounds);

            Rectangle area = new Rectangle(e.Bounds.X + 6, e.Bounds.Y, e.Bounds.Width - 8, e.Bounds.Height);
            TextRenderer.DrawText(e.Graphics, GetItemText(Items[e.Index]), Font, area, PaletaSistema.Texto,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPadding);
        }

        
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_PAINT) Dibujar();
        }

        private void Dibujar()
        {
            using (Graphics g = CreateGraphics())
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                Color borde = !Enabled ? Color.FromArgb(45, 50, 70)
                            : Focused ? PaletaSistema.Amarillo
                            : encima ? Color.FromArgb(100, 108, 142)
                            : PaletaSistema.Borde;

                using (SolidBrush fondo = new SolidBrush(Enabled ? PaletaSistema.Campo : PaletaSistema.Tarjeta))
                    g.FillRectangle(fondo, ClientRectangle);
                using (Pen p = new Pen(borde))
                    g.DrawRectangle(p, 0, 0, Width - 1, Height - 1);

                string texto = SelectedIndex >= 0 ? GetItemText(SelectedItem) : "";
                Rectangle area = new Rectangle(8, 0, Width - 34, Height);
                TextRenderer.DrawText(g, texto, Font, area,
                    Enabled ? PaletaSistema.Texto : PaletaSistema.Tenue,
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPadding);

                // flecha fina
                float cx = Width - 16, cy = Height / 2f;
                using (Pen flecha = new Pen(Enabled ? PaletaSistema.Tenue : Color.FromArgb(105, 113, 138), 1.8f))
                {
                    flecha.StartCap = LineCap.Round;
                    flecha.EndCap = LineCap.Round;
                    g.DrawLines(flecha, new[] { new PointF(cx - 4, cy - 2), new PointF(cx, cy + 2), new PointF(cx + 4, cy - 2) });
                }
            }
        }
    }


    // Un NumericUpDown deja ESCRIBIR cualquier número aunque supere el máximo. Este ayudante
    // corrige en el acto: si se escribe (o pega) algo mayor que el máximo vuelve al máximo y avisa.
    public static class NumericoLimitado
    {
        public static void Aplicar(NumericUpDown n, ErrorProvider avisos, Func<string> mensaje)
        {
            bool ajustando = false;
            n.TextChanged += (s, e) =>
            {
                if (ajustando || n.Text.Length == 0) return;
                decimal v;
                if (!decimal.TryParse(n.Text, out v)) return;

                if (v > n.Maximum)
                {
                    ajustando = true;
                    n.Value = n.Maximum;
                    n.Text = n.Maximum.ToString("0");
                    n.Select(n.Text.Length, 0);
                    ajustando = false;
                    if (avisos != null)
                        avisos.SetError(n, mensaje != null ? mensaje() : "El máximo permitido es " + n.Maximum.ToString("0") + ".");
                }
                else if (avisos != null && avisos.GetError(n).Length > 0)
                    avisos.SetError(n, "");
            };
        }
    }
}
