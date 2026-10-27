using CentroDeSoporte;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Charting = System.Windows.Forms.DataVisualization.Charting;
using System.Linq;
using pagina_principal;

namespace Vistass
{
    public partial class frmInicio : Form
    {
        private static readonly CultureInfo Es = new CultureInfo("es-ES");
        private static readonly Color Fondo = Color.FromArgb(27, 29, 38);
        private static readonly Color TextoSuave = Color.FromArgb(170, 180, 200);
        private static readonly Color Amarillo = Color.FromArgb(250, 204, 21);
        private static readonly Color Rojo = Color.FromArgb(248, 113, 113);
        private static readonly Color Verde = Color.FromArgb(74, 222, 128);
        private static readonly Color Ambar = Color.FromArgb(251, 191, 36);
        private static readonly Color Azul = Color.FromArgb(96, 165, 250);

        private bool esAdmin;

        private DataRow filaEquipo, filaPrestamos, filaReportes, filaPlanilla, filaPersonal;

        private int fallos;                    // consultas que no se pudieron ejecutar en esta carga
        private string ultimoFallo;

        private static readonly Font FuenteTitulo = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        private static readonly Font FuenteDetalle = new Font("Segoe UI", 9F);
        private static readonly Font FuenteDetalleChico = new Font("Segoe UI", 8.5F);
        private static readonly Font FuenteFila = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        private static readonly Font FuenteAccion = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        private static readonly Font FuenteMensaje = new Font("Segoe UI", 10F, FontStyle.Italic);

        private readonly List<Button> accesos = new List<Button>();
        private readonly ToolTip tip = new ToolTip();

        private Panel pnlActividad;            // tarjeta "Actividad reciente"
        private FlowLayoutPanel flpActividad;
        private const int FilaActividad = 36;

        public frmInicio()
        {
            InitializeComponent();
            ConstruirAccesos();
            ConstruirActividad();
            pnlEncabezado.Resize += (s, e) => PosicionarAccesos();
            flpAlertas.ClientSizeChanged += flpAlertas_Resize;      // al aparecer la barra de desplazamiento, las tarjetas se ajustan al ancho que queda
        }

        private void frmInicio_Load(object sender, EventArgs e)
        {
            esAdmin = Sesion.Rol != null && Sesion.Rol.Trim().Equals("Administrador", StringComparison.OrdinalIgnoreCase);

            ConfigurarSegunRol();
            Recargar();
        }

        // Lee otra vez todo el inicio: al abrirlo, al reintentar tras un fallo y tras registrar algo desde un acceso rápido.
        private void Recargar()
        {
            fallos = 0;
            ultimoFallo = null;

            ActualizarEncabezado();
            CargarIndicadores();
            CargarGraficos();
            CargarActividad();
            CargarAlertas();
            PosicionarAccesos();
        }

        private void ActualizarEncabezado()
        {
            DateTime hoy = DateTime.Now;

            string saludo = hoy.Hour < 12 ? "¡Buenos días" : (hoy.Hour < 19 ? "¡Buenas tardes" : "¡Buenas noches");
            string usuario = Sesion.Usuario;
            lblSaludo.Text = saludo + (string.IsNullOrWhiteSpace(usuario) ? "" : ", " + Capitalizar(usuario.Trim())) + "!";

            string fecha = hoy.ToString("dddd, d 'de' MMMM 'de' yyyy", Es);
            lblFecha.Text = Capitalizar(fecha);
        }

        private static string Capitalizar(string t)
        {
            return string.IsNullOrEmpty(t) ? t : char.ToUpper(t[0]) + t.Substring(1);
        }

        private void ConfigurarSegunRol()
        {
            pnlActividad.Visible = esAdmin;
            if (!esAdmin) tlpGraficos.SetColumnSpan(chartSalones, 2);   // sin actividad, el gráfico de salones ocupa todo el ancho

            if (esAdmin) return;
            pnlKpi5.Visible = false;
            pnlKpi6.Visible = false;
            for (int i = 0; i < 4; i++) tlpKpis.ColumnStyles[i].Width = 25F;
            tlpKpis.ColumnStyles[4].Width = 0F;
            tlpKpis.ColumnStyles[5].Width = 0F;
        }

        private DataTable Consulta(string sql, params SqlParameter[] ps)
        {
            try { return Datos.Tabla(sql, ps); }
            catch (Exception ex)
            {
                fallos++;
                ultimoFallo = ex.Message;
                System.Diagnostics.Debug.WriteLine("Inicio: " + ex.Message);
                return null;
            }
        }

        private static DataRow Primera(DataTable dt)
        {
            return (dt != null && dt.Rows.Count > 0) ? dt.Rows[0] : null;
        }

        private static int Entero(object o)
        {
            return (o == null || o == DBNull.Value) ? 0 : Convert.ToInt32(o);
        }
        private void Kpi(Label valor, Label detalle, string textoValor, string textoDetalle, Color colorDetalle, Color? colorValor = null)
        {
            valor.Text = textoValor;
            valor.ForeColor = colorValor ?? Color.White;
            detalle.Text = textoDetalle;
            detalle.ForeColor = colorDetalle;
        }

        // Si una consulta falla, el indicador dice "No disponible" en vez de quedarse vacío
        private void NoDisponible(Label valor, Label detalle)
        {
            Kpi(valor, detalle, "—", "No disponible", Rojo, TextoSuave);
        }

        private void CargarIndicadores()
        {
            filaEquipo = Primera(Consulta(
                @"SELECT COUNT(*) AS Total,
                         ISNULL(SUM(CASE WHEN e.NombreEstado IN ('Malo','En reparación','Mantenimiento Pendiente','Dado de baja')
                                         THEN 1 ELSE 0 END), 0) AS Problema,
                         (SELECT COUNT(*) FROM GestionActivos) AS Tipos
                  FROM UnidadesActivo u
                  JOIN Estados e ON e.IdEstado = u.IdEstado"));
            if (filaEquipo != null)
            {
                int total = Entero(filaEquipo["Total"]), prob = Entero(filaEquipo["Problema"]), tipos = Entero(filaEquipo["Tipos"]);
                if (total == 0)
                {
                    Kpi(lblKpi1Valor, lblKpi1Detalle, "0", "Aún no hay equipos registrados", TextoSuave);
                    Kpi(lblKpi2Valor, lblKpi2Detalle, "0", "Sin equipos todavía", TextoSuave);
                }
                else
                {
                    int bueno = (int)Math.Round(100.0 * (total - prob) / total);
                    Kpi(lblKpi1Valor, lblKpi1Detalle, total.ToString("N0"), tipos + (tipos == 1 ? " tipo de equipo" : " tipos de equipo"), TextoSuave);
                    Kpi(lblKpi2Valor, lblKpi2Detalle, prob.ToString("N0"), bueno + "% del equipo en buen estado",
                        prob > 0 ? Ambar : Verde, prob > 0 ? Rojo : Verde);
                }
            }
            else
            {
                NoDisponible(lblKpi1Valor, lblKpi1Detalle);
                NoDisponible(lblKpi2Valor, lblKpi2Detalle);
            }

            filaPrestamos = Primera(Consulta(
                @"SELECT COUNT(*) AS Activos,
                         ISNULL(SUM(CASE WHEN FechaLimite < GETDATE() THEN 1 ELSE 0 END), 0) AS Vencidos,
                         MIN(CASE WHEN FechaLimite < GETDATE() THEN FechaLimite END) AS MasAntiguo
                  FROM Prestamos WHERE Estado = 'Activo'"));
            if (filaPrestamos != null)
            {
                int activos = Entero(filaPrestamos["Activos"]), vencidos = Entero(filaPrestamos["Vencidos"]);
                Kpi(lblKpi3Valor, lblKpi3Detalle, activos.ToString("N0"),
                    vencidos > 0 ? vencidos + (vencidos == 1 ? " vencido" : " vencidos") : "Ninguno vencido",
                    vencidos > 0 ? Rojo : Verde);
            }
            else NoDisponible(lblKpi3Valor, lblKpi3Detalle);

            filaReportes = Primera(Consulta(
                @"SELECT COUNT(*) AS Abiertos,
                         ISNULL(SUM(CASE WHEN Prioridad = 'Alta' THEN 1 ELSE 0 END), 0) AS Altas
                  FROM ReportesDanio WHERE Estado = 'Abierto'"));
            if (filaReportes != null)
            {
                int abiertos = Entero(filaReportes["Abiertos"]), altas = Entero(filaReportes["Altas"]);
                Kpi(lblKpi4Valor, lblKpi4Detalle, abiertos.ToString("N0"),
                    altas > 0 ? altas + " de prioridad alta" : (abiertos > 0 ? "Ninguno de prioridad alta" : "Sin reportes pendientes"),
                    altas > 0 ? Rojo : (abiertos > 0 ? Ambar : Verde));
            }
            else NoDisponible(lblKpi4Valor, lblKpi4Detalle);

            if (!esAdmin) return;

            filaPersonal = Primera(Consulta(
                @"SELECT COUNT(*) AS Total,
                         ISNULL(SUM(CASE WHEN c.NombreCargo LIKE 'Docente%' THEN 1 ELSE 0 END), 0) AS Docentes
                  FROM Empleados e
                  JOIN Cargos c ON c.IdCargo = e.IdCargo
                  WHERE e.IdEstado <> 2"));
            if (filaPersonal != null)
            {
                int total = Entero(filaPersonal["Total"]), docentes = Entero(filaPersonal["Docentes"]);
                if (total == 0)
                    Kpi(lblKpi5Valor, lblKpi5Detalle, "0", "Aún no hay personal registrado", TextoSuave);
                else
                    Kpi(lblKpi5Valor, lblKpi5Detalle, total.ToString("N0"),
                        docentes + (docentes == 1 ? " docente" : " docentes"), TextoSuave);
            }
            else NoDisponible(lblKpi5Valor, lblKpi5Detalle);

            DateTime mes = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            lblKpi6Titulo.Text = "PLANILLA PENDIENTE · " +
                Es.DateTimeFormat.GetAbbreviatedMonthName(mes.Month).TrimEnd('.').ToUpper(Es);
            filaPlanilla = Primera(Consulta(
                @"SELECT ISNULL(SUM(CASE WHEN EstadoPago = 'Pendiente' THEN SalarioNeto END), 0) AS Monto,
                         ISNULL(SUM(CASE WHEN EstadoPago = 'Pendiente' THEN 1 ELSE 0 END), 0) AS Pagos,
                         COUNT(*) AS Total
                  FROM PagosPlanilla
                  WHERE Anulado = 0 AND Periodo = @p", Datos.P("@p", mes)));
            if (filaPlanilla != null)
            {
                decimal monto = Convert.ToDecimal(filaPlanilla["Monto"]);
                int pagos = Entero(filaPlanilla["Pagos"]), totalPagos = Entero(filaPlanilla["Total"]);
                bool sinPersonal = filaPersonal != null && Entero(filaPersonal["Total"]) == 0;
                if (totalPagos == 0 && sinPersonal)
                    Kpi(lblKpi6Valor, lblKpi6Detalle, "$0.00", "Sin personal a quien pagar", TextoSuave);
                else if (totalPagos == 0)
                    Kpi(lblKpi6Valor, lblKpi6Detalle, "$0.00", "Planilla del mes sin generar", Ambar);
                else
                    Kpi(lblKpi6Valor, lblKpi6Detalle, "$" + monto.ToString("N2", CultureInfo.InvariantCulture),
                        pagos > 0 ? pagos + (pagos == 1 ? " pago sin pagar" : " pagos sin pagar") : "Todo pagado",
                        pagos > 0 ? Ambar : Verde);
            }
            else NoDisponible(lblKpi6Valor, lblKpi6Detalle);
        }

        private void EstilizarChart(Charting.Chart c, string titulo)
        {
            c.Series.Clear();
            c.Titles.Clear();
            c.Annotations.Clear();
            c.BackColor = Fondo;

            Charting.Title t = new Charting.Title(titulo, Charting.Docking.Top, new Font("Segoe UI", 11F, FontStyle.Bold), Color.White);
            t.Alignment = ContentAlignment.TopLeft;
            c.Titles.Add(t);

            Charting.ChartArea area = c.ChartAreas[0];
            area.BackColor = Color.Transparent;
            Font fuente = new Font("Segoe UI", 9F);
            foreach (Charting.Axis eje in new[] { area.AxisX, area.AxisY })
            {
                eje.LabelStyle.ForeColor = TextoSuave;
                eje.LabelStyle.Font = fuente;
                eje.LineColor = Color.FromArgb(60, 64, 80);
                eje.MajorTickMark.Enabled = false;
            }
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.LineColor = Color.FromArgb(45, 48, 62);
            area.AxisX.IsReversed = false;
            area.AxisY.LabelStyle.Enabled = true;

            if (c.Legends.Count > 0)
            {
                c.Legends[0].BackColor = Color.Transparent;
                c.Legends[0].ForeColor = TextoSuave;
                c.Legends[0].Font = fuente;
            }
        }

        private void SinDatos(Charting.Chart c, string texto = "Sin datos para mostrar")
        {
            Charting.TextAnnotation a = new Charting.TextAnnotation();
            a.Text = texto;
            a.ForeColor = TextoSuave;
            a.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            a.Alignment = ContentAlignment.MiddleCenter;
            a.X = 25; a.Y = 45; a.Width = 50; a.Height = 10;
            c.Annotations.Add(a);
        }

      

        private void CargarGraficos()
        {
            GraficoBarras(chartCategoria, "Equipo por categoría",
                Consulta(@"SELECT ISNULL(c.NombreCategoria, 'Sin categoría') AS Etiqueta, COUNT(*) AS Total
                           FROM UnidadesActivo u
                           JOIN GestionActivos a ON a.IdActivo = u.IdActivo
                           LEFT JOIN Categorias c ON c.IdCategoria = a.IdCategoria
                           GROUP BY c.NombreCategoria
                           ORDER BY COUNT(*) DESC"),
                Azul);
            GraficoBarras(chartSalones, "Equipo por salón (los 8 con más equipo)",
                Consulta(@"SELECT TOP 8 NombreSalon AS Etiqueta, Unidades AS Total
                           FROM vw_SalonesResumen
                           WHERE Activo = 1 AND Unidades > 0
                           ORDER BY Unidades DESC"),
                Verde);
            GraficoReportes();
        }

       

        private void GraficoBarras(Charting.Chart c, string titulo, DataTable dt, Color color)
        {
            EstilizarChart(c, titulo);
            if (dt == null) { SinDatos(c, "No se pudo cargar este gráfico"); return; }
            if (dt.Rows.Count == 0) { SinDatos(c); return; }

            Charting.Series s = c.Series.Add("Serie");
            s.ChartType = Charting.SeriesChartType.Bar;
            s.Color = color;
            s["PointWidth"] = "0.6";
            s.IsValueShownAsLabel = true;
            s.LabelForeColor = Color.White;
            s.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            foreach (DataRow r in dt.Rows)
                s.Points.AddXY(Convert.ToString(r["Etiqueta"]), Entero(r["Total"]));

            Charting.ChartArea area = c.ChartAreas[0];
            area.AxisX.IsReversed = true;
            area.AxisX.Interval = 1;
            area.AxisY.MajorGrid.Enabled = false;
            area.AxisY.LabelStyle.Enabled = false;    
        }

        private void GraficoReportes()
        {
            EstilizarChart(chartReportes, "Reportes de daño por mes");
            DataTable dt = Consulta(
                @"SELECT m.Mes, COUNT(r.IdReporte) AS Total
                  FROM (SELECT DATEFROMPARTS(YEAR(DATEADD(MONTH, -n, GETDATE())), MONTH(DATEADD(MONTH, -n, GETDATE())), 1) AS Mes
                        FROM (VALUES (5),(4),(3),(2),(1),(0)) v(n)) m
                  LEFT JOIN ReportesDanio r ON r.FechaReporte >= m.Mes AND r.FechaReporte < DATEADD(MONTH, 1, m.Mes)
                  GROUP BY m.Mes
                  ORDER BY m.Mes");
            if (dt == null) { SinDatos(chartReportes, "No se pudo cargar este gráfico"); return; }
            if (dt.Rows.Count == 0) { SinDatos(chartReportes); return; }

            Charting.Series s = chartReportes.Series.Add("Reportes");
            s.ChartType = Charting.SeriesChartType.Column;
            s.Color = Amarillo;
            s["PointWidth"] = "0.5";
            s.IsValueShownAsLabel = true;
            s.LabelForeColor = Color.White;
            s.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            int max = 0;
            foreach (DataRow r in dt.Rows)
            {
                DateTime mes = Convert.ToDateTime(r["Mes"]);
                int total = Entero(r["Total"]);
                if (total > max) max = total;
                s.Points.AddXY(Capitalizar(mes.ToString("MMM", Es)), total);
            }

            Charting.ChartArea area = chartReportes.ChartAreas[0];
            area.AxisY.Minimum = 0;
            area.AxisY.LabelStyle.Format = "0";
            if (max <= 5) area.AxisY.Interval = 1;
        }

        // ---------------------------------------------------------------
        //  Accesos rápidos (encabezado)
        // ---------------------------------------------------------------
        private void ConstruirAccesos()
        {
            AgregarAcceso("Préstamos", "Abrir los préstamos de equipo", true, (s, e) => IrA("prestamos"));
            AgregarAcceso("Reportar daño", "Reportar un equipo dañado", false, (s, e) => IrA("reportes"));
            AgregarAcceso("Nuevo empleado", "Registrar un empleado nuevo", true, (s, e) => NuevoEmpleado());
            AgregarAcceso("Generar planilla", "Crear los pagos de un mes", true, (s, e) => GenerarPlanilla());
        }

        // soloAdmin: el menú lateral ya oculta esas secciones a los demás roles, así que tampoco se ofrecen aquí
        private void AgregarAcceso(string texto, string ayuda, bool soloAdmin, EventHandler alHacerClic)
        {
            BotonTema b = new BotonTema();
            b.Tipo = TipoBoton.Secundario;
            b.Text = texto;
            b.Font = FuenteAccion;
            b.Tag = soloAdmin;
            b.Height = btnSoporte.Height;
            b.Width = Math.Max(110, TextRenderer.MeasureText(texto, b.Font).Width + 32);
            b.Visible = false;
            b.Click += alHacerClic;
            tip.SetToolTip(b, ayuda);
            accesos.Add(b);
            pnlEncabezado.Controls.Add(b);
        }

        // Los botones se acomodan a la derecha, junto al de soporte; los que no caben en el ancho disponible se ocultan
        private void PosicionarAccesos()
        {
            const int Espacio = 8;
            int derecha = pnlEncabezado.ClientSize.Width - 24 - btnSoporte.Width - 16;
            int izquierda = Math.Max(lblSaludo.Left + lblSaludo.PreferredWidth, lblFecha.Left + lblFecha.PreferredWidth) + 24;
            int disponible = derecha - izquierda;

            List<Button> permitidos = accesos.Where(b => esAdmin || !(bool)b.Tag).ToList();
            foreach (Button b in accesos) b.Visible = false;

            int usado = 0, caben = 0;
            foreach (Button b in permitidos)
            {
                int ancho = b.Width + (caben == 0 ? 0 : Espacio);
                if (usado + ancho > disponible) break;
                usado += ancho;
                caben++;
            }

            int x = derecha - usado;
            for (int i = 0; i < caben; i++)
            {
                permitidos[i].Location = new Point(x, btnSoporte.Top);
                permitidos[i].Visible = true;
                x += permitidos[i].Width + Espacio;
            }
        }

        private void NuevoEmpleado()
        {
            using (frmAgregarPersonal f = new frmAgregarPersonal())
                if (f.ShowDialog(this) == DialogResult.OK) Recargar();
        }

        private void GenerarPlanilla()
        {
            using (frmGenerarPlanilla f = new frmGenerarPlanilla(null))
                if (f.ShowDialog(this) == DialogResult.OK) IrA("planillas");
        }

        // ---------------------------------------------------------------
        //  Actividad reciente (solo administrador)
        // ---------------------------------------------------------------
        private void ConstruirActividad()
        {
            pnlActividad = new Panel();
            pnlActividad.Name = "pnlActividad";
            pnlActividad.BackColor = Fondo;
            pnlActividad.Dock = DockStyle.Fill;
            pnlActividad.Margin = new Padding(6);
            pnlActividad.Padding = new Padding(16, 8, 16, 8);

            flpActividad = new FlowLayoutPanel();
            flpActividad.Dock = DockStyle.Fill;
            flpActividad.FlowDirection = FlowDirection.TopDown;
            flpActividad.WrapContents = false;
            flpActividad.BackColor = Fondo;
            flpActividad.Resize += (s, e) => AjustarActividad();

            Panel cabecera = new Panel();
            cabecera.Dock = DockStyle.Top;
            cabecera.Height = 34;
            cabecera.BackColor = Fondo;

            Label titulo = new Label();
            titulo.Text = "Actividad reciente";
            titulo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            titulo.ForeColor = Color.White;
            titulo.AutoSize = false;
            titulo.TextAlign = ContentAlignment.MiddleLeft;
            titulo.Dock = DockStyle.Fill;

            Label verTodo = new Label();
            verTodo.Text = "Ver todo ›";
            verTodo.Font = FuenteAccion;
            verTodo.ForeColor = Amarillo;
            verTodo.AutoSize = false;
            verTodo.TextAlign = ContentAlignment.MiddleRight;
            verTodo.Dock = DockStyle.Right;
            verTodo.Width = 90;
            verTodo.Cursor = Cursors.Hand;
            verTodo.Click += (s, e) => IrA("actividad");
            tip.SetToolTip(verTodo, "Abrir el registro de actividad completo");

            cabecera.Controls.Add(titulo);
            cabecera.Controls.Add(verTodo);
            pnlActividad.Controls.Add(flpActividad);
            pnlActividad.Controls.Add(cabecera);

            tlpGraficos.Controls.Add(pnlActividad, 1, 1);
        }

        private void CargarActividad()
        {
            if (!esAdmin) return;

            // No se pide la columna Resumen de la vista: arma el texto de cada cambio y es la parte cara
            DataTable dt = Consulta(
                @"SELECT TOP 6 FechaHora, Usuario, NombreCompleto, Modulo, Accion
                  FROM vw_Auditoria
                  ORDER BY IdAuditoria DESC");

            Vaciar(flpActividad);
            if (dt == null) { MensajeActividad("No se pudo cargar la actividad.", Rojo); return; }
            if (dt.Rows.Count == 0) { MensajeActividad("Todavía no hay actividad registrada.", TextoSuave); return; }

            foreach (DataRow r in dt.Rows)
            {
                string accion = Convert.ToString(r["Accion"]);
                string modulo = Convert.ToString(r["Modulo"]);
                string quien = r["NombreCompleto"] == DBNull.Value || string.IsNullOrWhiteSpace(Convert.ToString(r["NombreCompleto"]))
                    ? Convert.ToString(r["Usuario"])
                    : Convert.ToString(r["NombreCompleto"]);

                // los accesos al sistema ya dicen todo en la acción ("Inició sesión", "Cerró sesión"...)
                string linea1 = modulo == "Acceso al sistema" ? accion : accion + " · " + modulo;
                string linea2 = quien + " · " + Hace(Convert.ToDateTime(r["FechaHora"]));
                AgregarFilaActividad(ColorAccion(accion, modulo), linea1, linea2);
            }
            AjustarActividad();
        }

        private static Color ColorAccion(string accion, string modulo)
        {
            if (modulo == "Acceso al sistema") return TextoSuave;
            if (accion == "Eliminó" || accion == "Anuló" || accion == "Desactivó") return Rojo;
            if (accion == "Creó" || accion == "Reactivó" || accion == "Marcó como pagado") return Verde;
            return Azul;
        }

        private void AgregarFilaActividad(Color color, string linea1, string linea2)
        {
            Panel p = new Panel();
            p.Tag = "fila";
            p.BackColor = Fondo;
            p.Height = FilaActividad;
            p.Margin = new Padding(0, 0, 0, 4);
            p.Width = Math.Max(120, flpActividad.ClientSize.Width - p.Margin.Horizontal);

            Panel barra = new Panel();
            barra.BackColor = color;
            barra.Dock = DockStyle.Left;
            barra.Width = 3;

            Label a = new Label();
            a.Text = linea1;
            a.Font = FuenteFila;
            a.ForeColor = Color.White;
            a.AutoSize = false;
            a.AutoEllipsis = true;
            a.Location = new Point(12, 1);
            a.Size = new Size(p.Width - 12, 18);
            a.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            Label b = new Label();
            b.Text = linea2;
            b.Font = FuenteDetalleChico;
            b.ForeColor = TextoSuave;
            b.AutoSize = false;
            b.AutoEllipsis = true;
            b.Location = new Point(12, 19);
            b.Size = new Size(p.Width - 12, 16);
            b.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            p.Controls.Add(a);
            p.Controls.Add(b);
            p.Controls.Add(barra);
            flpActividad.Controls.Add(p);
        }

        private void MensajeActividad(string texto, Color color)
        {
            Label m = new Label();
            m.Tag = "mensaje";
            m.Text = texto;
            m.Font = FuenteMensaje;
            m.ForeColor = color;
            m.AutoSize = false;
            m.TextAlign = ContentAlignment.MiddleCenter;
            m.Margin = new Padding(0);
            m.Size = new Size(Math.Max(120, flpActividad.ClientSize.Width), Math.Max(60, flpActividad.ClientSize.Height - 10));
            flpActividad.Controls.Add(m);
        }

        // Se muestran solo las filas que caben en la altura de la tarjeta
        private void AjustarActividad()
        {
            int cabe = Math.Max(1, flpActividad.ClientSize.Height / (FilaActividad + 4));
            int fila = 0;
            foreach (Control c in flpActividad.Controls)
            {
                if ("fila".Equals(c.Tag))
                {
                    c.Visible = fila < cabe;
                    c.Width = Math.Max(120, flpActividad.ClientSize.Width - c.Margin.Horizontal);
                    fila++;
                }
                else if ("mensaje".Equals(c.Tag))
                {
                    c.Size = new Size(Math.Max(120, flpActividad.ClientSize.Width), Math.Max(60, flpActividad.ClientSize.Height - 10));
                }
            }
        }

        private static string Hace(DateTime momento)
        {
            TimeSpan d = DateTime.Now - momento;
            if (d < TimeSpan.Zero) d = TimeSpan.Zero;       // el reloj de este equipo va atrasado respecto al servidor

            if (d.TotalMinutes < 1) return "hace un momento";
            if (d.TotalMinutes < 60) return "hace " + (int)d.TotalMinutes + " min";
            if (d.TotalHours < 24) return "hace " + (int)d.TotalHours + ((int)d.TotalHours == 1 ? " hora" : " horas");
            if (momento.Date == DateTime.Today.AddDays(-1)) return "ayer " + momento.ToString("HH:mm");
            if (d.TotalDays < 7) return "hace " + (int)d.TotalDays + " días";
            return momento.ToString("dd/MM/yyyy");
        }

        // ---------------------------------------------------------------
        //  Alertas
        // ---------------------------------------------------------------
        private static void Vaciar(Control contenedor)
        {
            for (int i = contenedor.Controls.Count - 1; i >= 0; i--)
            {
                Control c = contenedor.Controls[i];
                contenedor.Controls.RemoveAt(i);
                c.Dispose();
            }
        }

        private static string Resumir(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return "";
            string linea = texto.Trim().Split('\r', '\n')[0];
            return linea.Length > 90 ? linea.Substring(0, 90) + "…" : linea;
        }

        // El menú lateral oculta casi todas las secciones a quien no es administrador; las alertas no deben abrirlas
        private bool PuedeIr(string destino)
        {
            return destino == "reintentar" || destino == "reportes" || esAdmin;
        }

        private void AgregarAlerta(Color color, string titulo, string detalle, string destino = null, string accion = "Abrir ›")
        {
            bool clicable = destino != null && PuedeIr(destino);
            Color normal = Color.FromArgb(18, 18, 18);
            Color resaltado = Color.FromArgb(34, 36, 48);

            Panel p = new Panel();
            p.BackColor = normal;
            p.Height = 72;
            p.Margin = new Padding(0, 0, 0, 10);
            p.Width = Math.Max(120, flpAlertas.ClientSize.Width - p.Margin.Horizontal);

            Panel barra = new Panel();
            barra.BackColor = color;
            barra.Dock = DockStyle.Left;
            barra.Width = 5;

            // El título usa todo el ancho; la acción ("Abrir ›") va abajo a la derecha y solo le quita espacio al detalle
            int reservado = clicable ? 104 : 0;

            Label t = new Label();
            t.Text = titulo;
            t.Font = FuenteTitulo;
            t.ForeColor = Color.White;
            t.AutoSize = false;
            t.AutoEllipsis = true;
            t.Location = new Point(18, 8);
            t.Size = new Size(p.Width - 18 - 10, 24);
            t.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            Label d = new Label();
            d.Text = detalle;
            d.Font = FuenteDetalle;
            d.ForeColor = TextoSuave;
            d.AutoSize = false;
            d.AutoEllipsis = true;
            d.Location = new Point(18, 34);
            d.Size = new Size(p.Width - 18 - 10 - reservado, 32);
            d.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            tip.SetToolTip(t, titulo);
            tip.SetToolTip(d, detalle);

            p.Controls.Add(t);
            p.Controls.Add(d);
            p.Controls.Add(barra);

            if (clicable)
            {
                Label abrir = new Label();
                abrir.Text = accion;
                abrir.Font = FuenteAccion;
                abrir.ForeColor = color;
                abrir.AutoSize = false;
                abrir.TextAlign = ContentAlignment.MiddleRight;
                abrir.Size = new Size(96, 22);
                abrir.Location = new Point(p.Width - 96 - 10, 42);
                abrir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                p.Controls.Add(abrir);

                EventHandler alAbrir = (s, e) => IrA(destino);
                EventHandler alEntrar = (s, e) => p.BackColor = resaltado;
                EventHandler alSalir = (s, e) =>
                {
                    if (!p.ClientRectangle.Contains(p.PointToClient(Cursor.Position))) p.BackColor = normal;
                };
                foreach (Control c in new Control[] { p, t, d, abrir, barra })
                {
                    c.Cursor = Cursors.Hand;
                    c.Click += alAbrir;
                    c.MouseEnter += alEntrar;
                    c.MouseLeave += alSalir;
                }
            }

            flpAlertas.Controls.Add(p);
        }

        private void IrA(string seccion)
        {
            // "reintentar" no cambia de sección: vuelve a leer todo el inicio
            if (seccion == "reintentar")
            {
                BeginInvoke((Action)(() => { if (!IsDisposed) Recargar(); }));
                return;
            }

            frmDashboard panel = Application.OpenForms.OfType<frmDashboard>().FirstOrDefault();
            if (panel == null) return;
            panel.BeginInvoke((Action)(() => panel.IrA(seccion)));
        }

        private void CargarAlertas()
        {
            // Primero se consulta todo: así se sabe si algo falló antes de decidir qué mostrar
            int totalAltas = filaReportes != null ? Entero(filaReportes["Altas"]) : 0;
            DataTable urgentes = null;
            if (totalAltas > 0)
                urgentes = Consulta(@"SELECT TOP 1 Activo, Salon, DATEDIFF(DAY, FechaReporte, GETDATE()) AS Dias
                                      FROM vw_ReportesDanio
                                      WHERE Estado = 'Abierto' AND Prioridad = 'Alta'
                                      ORDER BY FechaReporte");
            DataTable cons = Consulta(@"SELECT Nombre FROM Consumibles
                                        WHERE StockMinimo > 0 AND StockActual <= StockMinimo
                                        ORDER BY Nombre");

            Vaciar(flpAlertas);
            int n = 0;

            if (fallos > 0)
            {
                n++;
                string causa = Resumir(ultimoFallo);
                AgregarAlerta(Rojo, "Algunos datos no se cargaron",
                    "Revise la conexión con la base de datos." + (causa.Length > 0 ? " " + causa : ""),
                    "reintentar", "Reintentar ›");
            }

            if (filaPrestamos != null)
            {
                int vencidos = Entero(filaPrestamos["Vencidos"]);
                if (vencidos > 0)
                {
                    n++;
                    string detalle = filaPrestamos["MasAntiguo"] == DBNull.Value ? "Pendientes de devolución"
                        : "El más antiguo venció el " + Convert.ToDateTime(filaPrestamos["MasAntiguo"]).ToString("dd/MM/yyyy");
                    AgregarAlerta(Rojo, vencidos + (vencidos == 1 ? " préstamo vencido" : " préstamos vencidos"), detalle, "prestamos");
                }
            }

            if (urgentes != null && urgentes.Rows.Count > 0)
            {
                DataRow u = urgentes.Rows[0];
                int dias = Entero(u["Dias"]);
                n++;
                AgregarAlerta(Rojo,
                    totalAltas + (totalAltas == 1 ? " reporte urgente sin atender" : " reportes urgentes sin atender"),
                    "Más antiguo: " + (dias == 0 ? "de hoy" : dias + (dias == 1 ? " día" : " días")) +
                    " · " + Convert.ToString(u["Activo"]) + ", " + Convert.ToString(u["Salon"]),
                    "reportes");
            }

            if (filaReportes != null)
            {
                int otros = Entero(filaReportes["Abiertos"]) - totalAltas;
                if (otros > 0)
                {
                    n++;
                    AgregarAlerta(Ambar,
                        otros + (otros == 1 ? " reporte de daño abierto" : " reportes de daño abiertos"),
                        "Pendientes de reparación",
                        "reportes");
                }
            }

            if (filaEquipo != null)
            {
                int prob = Entero(filaEquipo["Problema"]);
                if (prob > 0)
                {
                    n++;
                    AgregarAlerta(Ambar, prob + (prob == 1 ? " equipo con problema" : " equipos con problema"),
                        "En mal estado, reparación, mantenimiento o dados de baja",
                        "catalogo");
                }
            }

            if (cons != null && cons.Rows.Count > 0)
            {
                n++;
                var nombres = new List<string>();
                for (int i = 0; i < cons.Rows.Count && i < 3; i++) nombres.Add(Convert.ToString(cons.Rows[i]["Nombre"]));
                int c = cons.Rows.Count;
                AgregarAlerta(Ambar, c + (c == 1 ? " consumible bajo el mínimo" : " consumibles bajo el mínimo"),
                    string.Join(", ", nombres) + (c > 3 ? " y " + (c - 3) + " más" : ""),
                    "consumibles");
            }

            if (esAdmin && filaPlanilla != null)
            {
                int pagos = Entero(filaPlanilla["Pagos"]);
                if (pagos > 0)
                {
                    n++;
                    decimal monto = Convert.ToDecimal(filaPlanilla["Monto"]);
                    AgregarAlerta(Azul, pagos + (pagos == 1 ? " pago de planilla pendiente" : " pagos de planilla pendientes"),
                        "$" + monto.ToString("N2", CultureInfo.InvariantCulture) + " netos sin pagar este mes",
                        "planillas");
                }
                else if (Entero(filaPlanilla["Total"]) == 0 && filaPersonal != null && Entero(filaPersonal["Total"]) > 0)
                {
                    // hay personal pero aún no se crearon los pagos del mes
                    n++;
                    AgregarAlerta(Azul, "Planilla de " + Es.DateTimeFormat.GetMonthName(DateTime.Today.Month) + " sin generar",
                        "Todavía no se han creado los pagos de este mes.",
                        "planillas");
                }
            }

            // Sin alertas: si el sistema está vacío se guía al usuario; si no, se confirma que todo está en orden
            int guias = 0;
            if (n == 0)
            {
                bool sinEquipo = filaEquipo != null && Entero(filaEquipo["Total"]) == 0;
                bool sinPersonal = esAdmin && filaPersonal != null && Entero(filaPersonal["Total"]) == 0;

                if (sinEquipo)
                {
                    guias++;
                    if (esAdmin)
                        AgregarAlerta(Azul, "Registre su primer equipo", "El inventario está vacío. Empiece por el catálogo de equipos.",
                            "catalogo");
                    else
                        AgregarAlerta(Azul, "Aún no hay equipos registrados", "Un administrador debe cargar el inventario.");
                }
                if (sinPersonal)
                {
                    guias++;
                    AgregarAlerta(Azul, "Registre al personal", "Aún no hay empleados. Los necesita para generar la planilla.",
                        "personal", "Agregar ›");
                }
                if (guias == 0)
                    AgregarAlerta(Verde, "Todo en orden", "No hay alertas pendientes por ahora.");
            }

            lblAlertasTitulo.Text = n > 0 ? "REQUIERE ATENCIÓN  ·  " + n
                                  : (guias > 0 ? "PRIMEROS PASOS" : "REQUIERE ATENCIÓN");

            // Si ya son más de las que caben, aparece la barra de desplazamiento: se fuerza el cálculo y las tarjetas se ajustan al ancho que queda
            flpAlertas.PerformLayout();
            flpAlertas_Resize(flpAlertas, EventArgs.Empty);
        }


        private void flpAlertas_Resize(object sender, EventArgs e)
        {
            foreach (Control c in flpAlertas.Controls)
                c.Width = Math.Max(120, flpAlertas.ClientSize.Width - c.Margin.Horizontal);
        }
        private void btnSoporte_Click(object sender, EventArgs e)
        {
            frmCentroSoporte soporte = new frmCentroSoporte();
            soporte.FormClosed += (s, args) => this.Show();
            soporte.Show();
            this.Hide();
        }
    }
}