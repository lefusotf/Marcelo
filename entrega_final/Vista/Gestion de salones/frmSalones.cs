using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using Modelos;

namespace Vistass
{
    public partial class frmSalones : Form
    {
        private static readonly string[] EstadosMalos = { "Malo", "En reparación", "Dado de baja", "Mantenimiento Pendiente" };

        // colores de las etiquetas y cápsulas: (fondo, letra)
        private static readonly Color AzulBase = Color.FromArgb(96, 165, 250), AzulLetra = Color.FromArgb(147, 197, 253);
        private static readonly Color GrisBase = Color.FromArgb(148, 163, 184), GrisLetra = Color.FromArgb(203, 213, 225);
        private static readonly Color VioletaBase = Color.FromArgb(167, 139, 250), VioletaLetra = Color.FromArgb(196, 181, 253);
        private static readonly Color VerdeBase = Color.FromArgb(34, 197, 94), VerdeLetra = Color.FromArgb(134, 239, 172);
        private static readonly Color RojoBase = Color.FromArgb(239, 68, 68), RojoLetra = Color.FromArgb(252, 165, 165);
        private static readonly Color AmbarBase = Color.FromArgb(245, 158, 11), AmbarLetra = Color.FromArgb(252, 211, 77);

        private DataTable dtSalones;
        private DataView vistaSalones;
        private DataView vistaInventario;
        private bool cargando = false;
        private bool cargandoFiltros = false;   // evita consultas mientras se llenan los combos de filtro
        private int idSalonActual = 0;
        private string nombreSalonActual = "";

        public frmSalones()
        {
            InitializeComponent();
        }

        private void frmSalones_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnNuevoSalon, "Crear un salón nuevo");
            toolTip1.SetToolTip(btnEditarSalon, "Editar los datos del salón (también con doble clic en la lista)");
            toolTip1.SetToolTip(btnEstadoSalon, "Desactivar o reactivar el salón");
            toolTip1.SetToolTip(btnAsignar, "Agregar equipo a este salón");
            toolTip1.SetToolTip(btnMover, "Mover el equipo seleccionado a otro salón (puede seleccionar varios con Ctrl o Mayús)");
            toolTip1.SetToolTip(btnQuitar, "Retirar del salón el equipo seleccionado");
            toolTip1.SetToolTip(btnExportarPdf, "Exportar el inventario de este salón (PDF o Excel)");

            dgvInventario.MultiSelect = true;       // se puede mover o quitar varias unidades a la vez

            CargarSalones(0);
        }

        // ---------------------------------------------------------------
        //  Buscadores: lupa, borde amarillo al enfocarse y texto de ayuda
        // ---------------------------------------------------------------
        private void pnlLupa_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen p = new Pen(PaletaSistema.Tenue, 1.8f))
            {
                p.StartCap = LineCap.Round;
                p.EndCap = LineCap.Round;
                e.Graphics.DrawEllipse(p, 8, 6, 9, 9);
                e.Graphics.DrawLine(p, 15.5f, 13.5f, 19f, 17f);
            }
        }

        private static void BordeBuscador(PaintEventArgs e, Panel panel, TextBox caja)
        {
            Color borde = caja.Focused ? PaletaSistema.Amarillo : Color.FromArgb(60, 66, 88);
            using (Pen p = new Pen(borde))
                e.Graphics.DrawRectangle(p, 0, 0, panel.Width - 1, panel.Height - 1);
        }

        private void pnlBuscadorSalon_Paint(object sender, PaintEventArgs e) { BordeBuscador(e, pnlBuscadorSalon, txtBuscarSalon); }
        private void pnlBuscadorEquipo_Paint(object sender, PaintEventArgs e) { BordeBuscador(e, pnlBuscadorEquipo, txtBuscarEquipo); }

        private void txtBuscar_FocoCambiado(object sender, EventArgs e)
        {
            pnlBuscadorSalon.Invalidate();
            pnlBuscadorEquipo.Invalidate();
        }

        // el texto de ayuda está encima de la caja: un clic sobre él enfoca la caja
        private void lblHintSalon_Click(object sender, EventArgs e) { txtBuscarSalon.Focus(); }
        private void lblHintEquipo_Click(object sender, EventArgs e) { txtBuscarEquipo.Focus(); }

        // ---------------------------------------------------------------
        //  Cápsulas y etiquetas
        // ---------------------------------------------------------------
        private static GraphicsPath Pastilla(Rectangle r)
        {
            int d = r.Height;
            GraphicsPath p = new GraphicsPath();
            p.AddArc(r.X, r.Y, d, d, 90, 180);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 180);
            p.CloseFigure();
            return p;
        }

        // Pinta una celda con una cápsula de color en lugar del texto
        private static void PintarPildora(DataGridViewCellPaintingEventArgs e, string texto, Color baseColor, Color letra, bool centrada)
        {
            // fondo, selección, resaltado y borde de la celda, pero sin el texto
            e.Paint(e.CellBounds, e.PaintParts & ~DataGridViewPaintParts.ContentForeground);
            e.Handled = true;

            using (Font f = new Font("Segoe UI Semibold", 9F, FontStyle.Bold))
            {
                Size t = TextRenderer.MeasureText(e.Graphics, texto, f, new Size(int.MaxValue, int.MaxValue),
                                                  TextFormatFlags.NoPadding);
                int alto = 22;
                int ancho = Math.Min(t.Width + 22, Math.Max(24, e.CellBounds.Width - 12));
                int x = centrada ? e.CellBounds.Left + (e.CellBounds.Width - ancho) / 2 : e.CellBounds.Left + 8;
                Rectangle r = new Rectangle(x, e.CellBounds.Top + (e.CellBounds.Height - alto) / 2, ancho, alto);

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath p = Pastilla(r))
                using (SolidBrush b = new SolidBrush(Color.FromArgb(55, baseColor)))
                    e.Graphics.FillPath(b, p);

                TextRenderer.DrawText(e.Graphics, texto, f, r, letra,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter |
                    TextFormatFlags.NoPadding | TextFormatFlags.EndEllipsis);
            }
        }

        // Etiqueta redondeada (ficha del salón y totales del encabezado)
        private sealed class Chip : Control
        {
            private readonly Color baseColor;
            private readonly Color letra;

            public Chip(string texto, Color baseColor, Color letra)
            {
                this.baseColor = baseColor;
                this.letra = letra;
                SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                         ControlStyles.SupportsTransparentBackColor, true);
                BackColor = Color.Transparent;
                Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
                Text = texto;
                Size t = TextRenderer.MeasureText(texto, Font, new Size(int.MaxValue, int.MaxValue), TextFormatFlags.NoPadding);
                Size = new Size(t.Width + 26, 28);
                Margin = new Padding(0, 0, 8, 6);
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle r = new Rectangle(0, 0, Width - 1, Height - 1);
                using (GraphicsPath p = Pastilla(r))
                {
                    using (SolidBrush b = new SolidBrush(Color.FromArgb(55, baseColor)))
                        e.Graphics.FillPath(b, p);
                    using (Pen borde = new Pen(Color.FromArgb(90, baseColor)))
                        e.Graphics.DrawPath(borde, p);
                }
                TextRenderer.DrawText(e.Graphics, Text, Font, new Rectangle(0, 0, Width, Height), letra,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
            }
        }

        private void AgregarChip(FlowLayoutPanel destino, string texto, Color baseColor, Color letra)
        {
            destino.Controls.Add(new Chip(texto, baseColor, letra));
        }

        private static void VaciarChips(FlowLayoutPanel panel)
        {
            while (panel.Controls.Count > 0)
            {
                Control c = panel.Controls[0];
                panel.Controls.RemoveAt(0);
                c.Dispose();
            }
        }

        // ---------------------------------------------------------------
        //  Utilidades
        // ---------------------------------------------------------------
        private static void Columna(DataGridView g, string nombre, string encabezado, float peso)
        {
            if (!g.Columns.Contains(nombre)) return;
            g.Columns[nombre].HeaderText = encabezado;
            g.Columns[nombre].FillWeight = peso;
        }

        // para LIKE
        private static string Escapar(string t)
        {
            return t.Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("*", "[*]");
        }

        // para comparaciones exactas (=, IN)
        private static string Lit(string t)
        {
            return t.Replace("'", "''");
        }

        // ---------------------------------------------------------------
        //  Lista de salones
        // ---------------------------------------------------------------
        private void CargarSalones(int idSeleccionar)
        {
            try
            {
                if (idSeleccionar == 0) idSeleccionar = idSalonActual;

                dtSalones = Datos.Tabla(
                    @"SELECT IdSalon, NombreSalon, Tipo, Capacidad, Edificio, IdResponsable, Responsable,
                             Activo, Observacion, Unidades, ConProblema
                      FROM vw_SalonesResumen
                      ORDER BY NombreSalon");

                cargando = true;
                CargarTipos();
                vistaSalones = new DataView(dtSalones);
                dgvSalones.DataSource = vistaSalones;
                FormatearGridSalones();
                AplicarFiltroSalones();
                cargando = false;

                if (idSeleccionar > 0) SeleccionarSalon(idSeleccionar);

                ActualizarResumen();
                MostrarSalonActual();
            }
            catch (Exception ex)
            {
                cargando = false;
                MessageBox.Show("No se pudieron cargar los salones: " + ex.Message, "Error SQL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Lista de tipos de salón para el filtro (Aula, Laboratorio, Oficina...)
        private void CargarTipos()
        {
            string previo = cmbTipoSalon.SelectedItem as string;
            var tipos = new SortedSet<string>();
            foreach (DataRow r in dtSalones.Rows) tipos.Add(Convert.ToString(r["Tipo"]));

            cargandoFiltros = true;
            cmbTipoSalon.Items.Clear();
            cmbTipoSalon.Items.Add("Todos los tipos");
            foreach (string t in tipos) cmbTipoSalon.Items.Add(t);
            int i = previo == null ? -1 : cmbTipoSalon.Items.IndexOf(previo);
            cmbTipoSalon.SelectedIndex = i >= 0 ? i : 0;
            cargandoFiltros = false;
        }

        // Totales en una línea, a la derecha del encabezado (salones activos, unidades y equipos con problema)
        private void ActualizarResumen()
        {
            int activos = 0, unidades = 0, conProblema = 0;
            foreach (DataRow r in dtSalones.Rows)
            {
                if (!Convert.ToBoolean(r["Activo"])) continue;
                activos++;
                unidades += Convert.ToInt32(r["Unidades"]);
                conProblema += Convert.ToInt32(r["ConProblema"]);
            }

            flpResumen.SuspendLayout();
            VaciarChips(flpResumen);

            // el panel se llena de derecha a izquierda: se agrega primero lo que va más a la derecha
            if (conProblema > 0) AgregarChip(flpResumen, conProblema + " con problema", RojoBase, RojoLetra);
            else AgregarChip(flpResumen, "Sin problemas", VerdeBase, VerdeLetra);
            AgregarChip(flpResumen, unidades.ToString("N0") + " unidades", GrisBase, GrisLetra);
            AgregarChip(flpResumen, activos + (activos == 1 ? " salón activo" : " salones activos"), AzulBase, AzulLetra);

            flpResumen.ResumeLayout();
        }

        private void FormatearGridSalones()
        {
            if (dgvSalones.Columns.Count == 0) return;
            foreach (string oculta in new[] { "IdSalon", "Capacidad", "Edificio", "IdResponsable", "Responsable", "Activo", "Observacion" })
                if (dgvSalones.Columns.Contains(oculta)) dgvSalones.Columns[oculta].Visible = false;

            dgvSalones.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

            Columna(dgvSalones, "NombreSalon", "Salón", 36);
            Columna(dgvSalones, "Tipo", "Tipo", 22);
            Columna(dgvSalones, "Unidades", "Unidades", 21);
            Columna(dgvSalones, "ConProblema", "Problemas", 21);

            foreach (string c in new[] { "Unidades", "ConProblema" })
            {
                dgvSalones.Columns[c].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvSalones.Columns[c].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void AplicarFiltroSalones()
        {
            if (vistaSalones == null) return;
            var cond = new List<string>();
            if (!chkInactivos.Checked) cond.Add("Activo = true");
            if (cmbTipoSalon.SelectedIndex > 0) cond.Add("Tipo = '" + Lit(cmbTipoSalon.Text) + "'");

            string t = txtBuscarSalon.Text.Trim();
            if (t.Length > 0)
            {
                string esc = Escapar(t);
                cond.Add("(NombreSalon LIKE '%" + esc + "%' OR Tipo LIKE '%" + esc + "%' OR Responsable LIKE '%" + esc + "%')");
            }
            vistaSalones.RowFilter = string.Join(" AND ", cond);
        }

        private void txtBuscarSalon_TextChanged(object sender, EventArgs e)
        {
            lblHintSalon.Visible = txtBuscarSalon.Text.Length == 0;
            AplicarFiltroSalones();
            MostrarSalonActual();
        }

        private void cmbTipoSalon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoFiltros) return;
            AplicarFiltroSalones();
            MostrarSalonActual();
        }

        private void chkInactivos_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltroSalones();
            MostrarSalonActual();
        }

        private void SeleccionarSalon(int idSalon)
        {
            foreach (DataGridViewRow r in dgvSalones.Rows)
            {
                if (Convert.ToInt32(r.Cells["IdSalon"].Value) == idSalon)
                {
                    dgvSalones.CurrentCell = r.Cells["NombreSalon"];
                    break;
                }
            }
        }

        private DataRowView SalonSeleccionado()
        {
            if (dgvSalones.CurrentRow == null) return null;
            return dgvSalones.CurrentRow.DataBoundItem as DataRowView;
        }

        // salón inactivo en gris; sin problemas se muestra un guion (con problemas, la celda se pinta como cápsula)
        private void dgvSalones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataRowView fila = dgvSalones.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (fila == null) return;
            string col = dgvSalones.Columns[e.ColumnIndex].Name;

            if (!Convert.ToBoolean(fila["Activo"]))
            {
                e.CellStyle.ForeColor = Color.FromArgb(125, 133, 155);
                e.CellStyle.SelectionForeColor = Color.White;
                if (col == "NombreSalon" && e.Value != null)
                {
                    e.Value = e.Value + " (inactivo)";
                    e.FormattingApplied = true;
                }
                return;
            }

            if (col == "ConProblema" && e.Value != null && Convert.ToInt32(e.Value) == 0)
            {
                e.Value = "—";
                e.FormattingApplied = true;
                e.CellStyle.ForeColor = Color.FromArgb(110, 118, 140);
            }
        }

        // Número de problemas como cápsula roja
        private void dgvSalones_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || dgvSalones.Columns[e.ColumnIndex].Name != "ConProblema") return;

            DataRowView fila = dgvSalones.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (fila == null || !Convert.ToBoolean(fila["Activo"])) return;

            int n = Convert.ToInt32(fila["ConProblema"]);
            if (n == 0) return;

            PintarPildora(e, n.ToString(), RojoBase, RojoLetra, true);
        }

        private void dgvSalones_SelectionChanged(object sender, EventArgs e)
        {
            if (cargando) return;
            MostrarSalonActual();
        }

        private void dgvSalones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) EditarSalon();
        }

        // ---------------------------------------------------------------
        //  Ficha del salón
        // ---------------------------------------------------------------
        private void MostrarSalonActual()
        {
            DataRowView s = SalonSeleccionado();
            bool hay = s != null;

            // sin salón elegido se muestra un mensaje en lugar de paneles vacíos
            pnlSalonInfo.Visible = hay;
            pnlEspacio.Visible = hay;
            pnlBarraInv.Visible = hay;
            pnlTablaInv.Visible = hay;
            lblVacio.Visible = !hay;

            if (!hay)
            {
                idSalonActual = 0;
                nombreSalonActual = "";
                lblNombreSalon.Text = "Sin salón seleccionado";
                VaciarChips(flpChips);
                vistaInventario = null;
                dgvInventario.DataSource = null;
                ActualizarBotones();
                return;
            }

            idSalonActual = Convert.ToInt32(s["IdSalon"]);
            nombreSalonActual = Convert.ToString(s["NombreSalon"]);
            bool activo = Convert.ToBoolean(s["Activo"]);
            int unidades = Convert.ToInt32(s["Unidades"]);
            int problemas = Convert.ToInt32(s["ConProblema"]);

            lblNombreSalon.Text = nombreSalonActual + (activo ? "" : "  (inactivo)");
            ConstruirChips(s, activo, unidades, problemas);

            bool esBodega = Convert.ToString(s["Tipo"]) == "Bodega";
            btnAsignar.Text = "+ Asignar equipo";
            btnAsignar.Visible = !esBodega;
            toolTip1.SetToolTip(btnAsignar, "Pasar equipo disponible de la bodega a este salón");

            // desactivar es la acción delicada (rojo); reactivar es la acción positiva (amarillo)
            if (activo)
            {
                btnEstadoSalon.Text = "Desactivar salón";
                btnEstadoSalon.Tipo = TipoBoton.Peligro;
            }
            else
            {
                btnEstadoSalon.Text = "Reactivar salón";
                btnEstadoSalon.Tipo = TipoBoton.Principal;
            }

            CargarInventario();
            ActualizarBotones();
        }

        // Etiquetas de la ficha: tipo, capacidad, edificio, responsable, unidades y salud
        private void ConstruirChips(DataRowView s, bool activo, int unidades, int problemas)
        {
            flpChips.SuspendLayout();
            VaciarChips(flpChips);

         
            if (!string.Equals(Convert.ToString(s["Tipo"]), nombreSalonActual, StringComparison.OrdinalIgnoreCase))
                AgregarChip(flpChips, Convert.ToString(s["Tipo"]), AzulBase, AzulLetra);
            if (s["Capacidad"] != DBNull.Value)
                AgregarChip(flpChips, "Capacidad " + Convert.ToInt32(s["Capacidad"]) + " personas", GrisBase, GrisLetra);
            if (s["Edificio"] != DBNull.Value && Convert.ToString(s["Edificio"]).Trim().Length > 0)
                AgregarChip(flpChips, Convert.ToString(s["Edificio"]), GrisBase, GrisLetra);

            if (s["Responsable"] == DBNull.Value) AgregarChip(flpChips, "Sin responsable", AmbarBase, AmbarLetra);
            else AgregarChip(flpChips, "Responsable: " + Convert.ToString(s["Responsable"]), VioletaBase, VioletaLetra);

            AgregarChip(flpChips, unidades + (unidades == 1 ? " unidad" : " unidades"), GrisBase, GrisLetra);

            if (problemas > 0) AgregarChip(flpChips, problemas + " con problema", RojoBase, RojoLetra);
            else AgregarChip(flpChips, "Sin problemas", VerdeBase, VerdeLetra);

            if (!activo) AgregarChip(flpChips, "Inactivo", GrisBase, GrisLetra);
            flpChips.ResumeLayout();
        }

        // ---------------------------------------------------------------
        //  Equipo del salón
        // ---------------------------------------------------------------
        private void CargarInventario()
        {
            try
            {
                DataTable dt = Datos.Tabla(
                    @"SELECT IdUnidad, IdActivo, Activo AS Equipo, Categoria, 1 AS Cantidad, CodigoInventario, Estado
                      FROM vw_UnidadesDetalle
                      WHERE IdSalon = @s
                      UNION ALL
                      SELECT NULL, 0, Consumible, 'Consumible entregado', Entregado, NULL,
                             'Última entrega: ' + CONVERT(VARCHAR(10), UltimaEntrega, 103)
                      FROM vw_ConsumiblesPorSalon
                      WHERE IdSalon = @s
                      ORDER BY Equipo, CodigoInventario", Datos.P("@s", idSalonActual));

                // categorías de este salón para el filtro (se conserva la elegida si existe)
                string previa = cmbCategoria.SelectedItem as string;
                var categorias = new SortedSet<string>();
                foreach (DataRow r in dt.Rows) categorias.Add(Convert.ToString(r["Categoria"]));

                cargandoFiltros = true;
                cmbCategoria.Items.Clear();
                cmbCategoria.Items.Add("Todas las categorías");
                foreach (string c in categorias) cmbCategoria.Items.Add(c);
                int i = previa == null ? -1 : cmbCategoria.Items.IndexOf(previa);
                cmbCategoria.SelectedIndex = i >= 0 ? i : 0;
                cargandoFiltros = false;

                vistaInventario = new DataView(dt);
                dgvInventario.DataSource = vistaInventario;

                foreach (string oculta in new[] { "IdUnidad", "IdActivo" })
                    if (dgvInventario.Columns.Contains(oculta)) dgvInventario.Columns[oculta].Visible = false;

                dgvInventario.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
                Columna(dgvInventario, "Equipo", "Equipo", 28);
                Columna(dgvInventario, "Categoria", "Categoría", 22);
                Columna(dgvInventario, "Cantidad", "Cant.", 10);
                Columna(dgvInventario, "CodigoInventario", "Código", 20);
                Columna(dgvInventario, "Estado", "Estado", 22);
                dgvInventario.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvInventario.Columns["Cantidad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                AplicarFiltroInventario();
            }
            catch (Exception ex)
            {
                cargandoFiltros = false;
                MessageBox.Show("No se pudo cargar el inventario: " + ex.Message, "Error SQL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Búsqueda, categoría y "solo con problemas" se combinan en un solo filtro
        private void AplicarFiltroInventario()
        {
            if (vistaInventario == null) return;

            var cond = new List<string>();

            string t = txtBuscarEquipo.Text.Trim();
            if (t.Length > 0)
            {
                string esc = Escapar(t);
                cond.Add("(Equipo LIKE '%" + esc + "%' OR Categoria LIKE '%" + esc +
                         "%' OR CodigoInventario LIKE '%" + esc + "%')");
            }

            if (cmbCategoria.SelectedIndex > 0)
                cond.Add("Categoria = '" + Lit(cmbCategoria.Text) + "'");

            if (chkSoloProblemas.Checked)
                cond.Add("Estado IN (" + string.Join(",", EstadosMalos.Select(x => "'" + Lit(x) + "'")) + ")");

            vistaInventario.RowFilter = string.Join(" AND ", cond);
            ActualizarBotones();
        }

        private void txtBuscarEquipo_TextChanged(object sender, EventArgs e)
        {
            lblHintEquipo.Visible = txtBuscarEquipo.Text.Length == 0;
            AplicarFiltroInventario();
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoFiltros) return;
            AplicarFiltroInventario();
        }

        private void chkSoloProblemas_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltroInventario();
        }

        // Las entregas de consumibles se atenúan; el estado de las unidades se pinta como cápsula (ver CellPainting)
        private void dgvInventario_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null || dgvInventario.Columns[e.ColumnIndex].Name != "Estado") return;
            if (e.Value.ToString().StartsWith("Última entrega"))
                e.CellStyle.ForeColor = Color.FromArgb(125, 133, 155);
        }

        private void dgvInventario_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || dgvInventario.Columns[e.ColumnIndex].Name != "Estado") return;

            string estado = Convert.ToString(e.Value);
            if (estado.Length == 0 || estado.StartsWith("Última entrega")) return;

            if (EstadosMalos.Contains(estado)) PintarPildora(e, estado, RojoBase, RojoLetra, false);
            else if (estado == "Regular") PintarPildora(e, estado, AmbarBase, AmbarLetra, false);
            else PintarPildora(e, estado, VerdeBase, VerdeLetra, false);
        }

        private void dgvInventario_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarBotones();
        }

        private List<DataRowView> FilasSeleccionadas()
        {
            var lista = new List<DataRowView>();
            foreach (DataGridViewRow r in dgvInventario.SelectedRows)
            {
                DataRowView f = r.DataBoundItem as DataRowView;
                if (f != null && f["IdUnidad"] != DBNull.Value) lista.Add(f);
            }
            return lista;
        }

        private void ActualizarBotones()
        {
            DataRowView s = SalonSeleccionado();
            bool haySalon = s != null && idSalonActual > 0;
            bool activo = haySalon && Convert.ToBoolean(s["Activo"]);
            int seleccion = haySalon ? FilasSeleccionadas().Count : 0;

            btnEditarSalon.Enabled = haySalon;
            btnEstadoSalon.Enabled = haySalon;
            btnAsignar.Enabled = activo;
            btnMover.Enabled = activo && seleccion > 0;
            btnQuitar.Enabled = haySalon && seleccion > 0;
            btnExportarPdf.Enabled = haySalon;

            lblSeleccionInv.Text = seleccion == 0 ? ""
                                 : seleccion + (seleccion == 1 ? " unidad seleccionada" : " unidades seleccionadas");
        }

        // ---------------------------------------------------------------
        //  Acciones sobre el salón
        // ---------------------------------------------------------------
        private void btnNuevoSalon_Click(object sender, EventArgs e)
        {
            using (frmSalon frm = new frmSalon())
            {
                if (frm.ShowDialog(this) == DialogResult.OK) CargarSalones(frm.IdGuardado);
            }
        }

        private void btnEditarSalon_Click(object sender, EventArgs e)
        {
            EditarSalon();
        }

        private void EditarSalon()
        {
            if (idSalonActual == 0)
            {
                MessageBox.Show("Seleccione un salón de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (frmSalon frm = new frmSalon(idSalonActual))
            {
                if (frm.ShowDialog(this) == DialogResult.OK) CargarSalones(frm.IdGuardado);
            }
        }

        private void btnEstadoSalon_Click(object sender, EventArgs e)
        {
            DataRowView s = SalonSeleccionado();
            if (s == null) return;
            bool activo = Convert.ToBoolean(s["Activo"]);

            string pregunta = activo
                ? "¿Desactivar el salón \"" + nombreSalonActual + "\"?\n\nDejará de aparecer para asignar equipo. Podrá reactivarlo cuando quiera."
                : "¿Reactivar el salón \"" + nombreSalonActual + "\"?";
            if (MessageBox.Show(pregunta, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                Datos.Ejecutar("EXEC dbo.sp_CambiarEstadoSalon @IdSalon = @id, @Activo = @a",
                               Datos.P("@id", idSalonActual), Datos.P("@a", !activo));
                CargarSalones(idSalonActual);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "No se pudo cambiar el estado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------------------------------------------------------------
        //  Acciones sobre el equipo
        // ---------------------------------------------------------------
        private void btnAsignar_Click(object sender, EventArgs e)
        {
            DataRowView s = SalonSeleccionado();
            bool esBodega = s != null && Convert.ToString(s["Tipo"]) == "Bodega";

            if (esBodega)
            {
                // alta: el equipo nuevo entra al inventario
                using (frmAltaUnidades frm = new frmAltaUnidades())
                {
                    if (frm.ShowDialog(this) == DialogResult.OK) CargarSalones(idSalonActual);
                }
            }
            else
            {
                // asignación: pasa unidades que ya existen desde la bodega
                using (frmAsignarEquipo frm = new frmAsignarEquipo(idSalonActual, nombreSalonActual))
                {
                    if (frm.ShowDialog(this) == DialogResult.OK) CargarSalones(idSalonActual);
                }
            }
        }

        private void btnMover_Click(object sender, EventArgs e)
        {
            List<DataRowView> filas = FilasSeleccionadas();
            if (filas.Count == 0) return;

            var nombres = new List<string>();
            foreach (DataRowView f in filas.Take(3))
                nombres.Add(Convert.ToString(f["Equipo"]) + " (" + Convert.ToString(f["CodigoInventario"]) + ")");
            string descripcion = filas.Count + (filas.Count == 1 ? " unidad: " : " unidades: ") + string.Join(", ", nombres) +
                                 (filas.Count > 3 ? " y " + (filas.Count - 3) + " más" : "");

            List<int> ids = filas.Select(f => Convert.ToInt32(f["IdUnidad"])).ToList();

            using (frmMoverEquipo frm = new frmMoverEquipo(idSalonActual, nombreSalonActual, ids, descripcion))
            {
                if (frm.ShowDialog(this) == DialogResult.OK) CargarSalones(idSalonActual);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            List<DataRowView> filas = FilasSeleccionadas();
            if (filas.Count == 0)
            {
                MessageBox.Show("Seleccione en la tabla las unidades que desea retirar del salón.\n\n" +
                                "Los consumibles entregados no se retiran desde aquí: se registra un movimiento en Gestión de activos > Consumibles.",
                                "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string pregunta = "¿Retirar " + filas.Count + (filas.Count == 1 ? " unidad" : " unidades") + " de \"" + nombreSalonActual + "\"?\n\n" +
                              "Solo se eliminan las que no tienen historial (préstamos, mantenimientos o reportes de daño). " +
                              "Las demás deben pasar a 'Dado de baja' desde Gestión de activos.";
            if (MessageBox.Show(pregunta, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            try
            {
                string ids = string.Join(",", filas.Select(f => Convert.ToInt32(f["IdUnidad"]).ToString()));
                DataTable r = Datos.Tabla("EXEC dbo.sp_QuitarUnidades @Ids = @ids", Datos.P("@ids", ids));
                int quitadas = Convert.ToInt32(r.Rows[0]["Quitadas"]);
                int conHistorial = Convert.ToInt32(r.Rows[0]["ConHistorial"]);

                if (conHistorial > 0)
                {
                    MessageBox.Show("Se retiraron " + quitadas + " unidad(es).\n\n" +
                        conHistorial + " no se pudo retirar porque tiene historial registrado.\n" +
                        "Para sacarla de uso, cambie su estado a 'Dado de baja' (Gestión de activos > ficha > Ubicación).",
                        "Retiro parcial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                CargarSalones(idSalonActual);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "No se pudo retirar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al retirar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportarPdf_Click(object sender, EventArgs e)
        {
            if (vistaInventario == null || vistaInventario.Count == 0)
            {
                MessageBox.Show("Este salón no tiene equipo para exportar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                DataTable dt = new DataTable();
                foreach (string c in new[] { "Equipo", "Categoría", "Cantidad", "Código de inventario", "Estado" })
                    dt.Columns.Add(c);

                foreach (DataRowView r in vistaInventario)
                    dt.Rows.Add(r["Equipo"], r["Categoria"], r["Cantidad"], r["CodigoInventario"], r["Estado"]);

                ExportadorPdf.Exportar("Inventario de " + nombreSalonActual, dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}