using iTextSharp.text;
using iTextSharp.text.pdf;
using Modelos;
using pagina_principal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;







namespace Vistass
{
    public partial class frmGestionActivos : Form
    {
        private static readonly Color Fondo = Color.FromArgb(18, 18, 18);
        private static readonly Color Tarjeta = Color.FromArgb(27, 29, 38);

        private DataTable dtActivos = new DataTable();
        private DataView vista;
        private HashSet<int> activosConDano = new HashSet<int>();
        private int idSeleccionado = 0;      // 0 = modo "nuevo activo"
        private bool cargando = false;       // evita disparar eventos mientras se llenan listas

        public frmGestionActivos()
        {
            InitializeComponent();
            BackColor = Fondo;
            AplicarTema(this);
        }

        private void frmGestionActivos_Load(object sender, EventArgs e)
        {
            ConfigurarTooltips();
            // El estado ya no es del tipo de activo sino de cada unidad (se cambia en la ficha > Ubicación)
            lblEstado.Visible = false; cmbEstado.Visible = false;
            CrearPanelEstadoUnidad();
            CargarCatalogos();
            CargarActivos();
            LimpiarFormulario();
            InicializarPrestamos();
            InicializarConsumibles();
            InicializarMantenimiento();
            InicializarReportes();
        }

        // ---------------------------------------------------------------
        //  TEMA (colores y fuentes por código)
        // ---------------------------------------------------------------
        private void AplicarTema(Control raiz)
        {
            foreach (Control c in raiz.Controls)
            {
                string tag = c.Tag as string;

                if (c is DataGridView g) { EstilizarGrid(g); continue; }

                if (c is Button b)
                {
                    b.FlatStyle = FlatStyle.Flat;
                    b.FlatAppearance.BorderSize = 0;
                    b.UseVisualStyleBackColor = false;
                    b.ForeColor = Color.White;
                    b.BackColor = tag == "ok" ? Color.FromArgb(0, 150, 136)
                                : tag == "peligro" ? Color.FromArgb(220, 38, 38)
                                : tag == "secundario" ? Color.FromArgb(60, 60, 60)
                                : Color.FromArgb(0, 120, 212);
                }
                else if (c is Label l)
                {
                }
                else if (c is TextBox t)
                {
                    t.BackColor = Color.White; t.ForeColor = Color.Black;
                }
                else if (c is ComboBox cb)
                {
                }
                else if (c is TabPage) { c.BackColor = Fondo; }
                else if (c is Panel) { c.BackColor = tag == "tarjeta" ? Tarjeta : Fondo; }

                AplicarTema(c);
            }
        }

        private static void EstilizarGrid(DataGridView g)
        {
            g.AllowUserToAddRows = false; g.AllowUserToDeleteRows = false; g.AllowUserToResizeRows = false;
            g.ReadOnly = true; g.RowHeadersVisible = false; g.MultiSelect = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            g.BackgroundColor = Color.FromArgb(30, 30, 44); g.BorderStyle = BorderStyle.None;
            g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            g.GridColor = Color.FromArgb(225, 228, 235);
            g.EnableHeadersVisualStyles = false;
            g.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            g.ColumnHeadersHeight = 36; g.RowTemplate.Height = 30;

            g.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            g.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            g.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(40, 40, 40);
            g.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 0, 0, 0);

            g.DefaultCellStyle.BackColor = Color.White; g.DefaultCellStyle.ForeColor = Color.Black;
            g.DefaultCellStyle.Padding = new Padding(6, 0, 0, 0);
            g.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 212);
            g.DefaultCellStyle.SelectionForeColor = Color.White;
            g.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(244, 246, 250);
        }

        // Pestañas con tema oscuro (sirve para tabPrincipal y tabFicha)
        private void tab_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tab = (TabControl)sender;
            bool activa = e.Index == tab.SelectedIndex;
            using (SolidBrush fondo = new SolidBrush(activa ? Color.FromArgb(0, 120, 212) : Color.FromArgb(40, 40, 40)))
                e.Graphics.FillRectangle(fondo, e.Bounds);
            TextRenderer.DrawText(e.Graphics, tab.TabPages[e.Index].Text, tab.Font, e.Bounds, Color.White,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private void ConfigurarTooltips()
        {
            toolTip1.SetToolTip(txtCodigo, "Identificador único. Si lo deja vacío se genera uno (ACT-0001)");
            toolTip1.SetToolTip(cmbUbicacion, "Dónde se guarda normalmente el activo");
            toolTip1.SetToolTip(btnEliminar, "Solo si no tiene salones, préstamos ni mantenimientos. Si no, use el estado 'Dado de baja'");
            toolTip1.SetToolTip(btnPrestar, "Registra la salida del equipo; no se presta equipo en mal estado");
            toolTip1.SetToolTip(btnDevolver, "Cierra el préstamo y actualiza el estado físico del activo");
            toolTip1.SetToolTip(btnHoja, "Genera la hoja de resguardo en PDF para la firma del responsable");
        }

        private bool EsAdministrador()
        {
            return Sesion.Rol != null &&
                   Sesion.Rol.Trim().Equals("Administrador", StringComparison.OrdinalIgnoreCase);
        }

        // Cambie por el usuario de la sesión de su aplicación si lo tiene (por ejemplo Sesion.Usuario)
        private string UsuarioActual()
        {
            return Environment.UserName;
        }

        private static void LlenarCombo(ComboBox c, DataTable dt, string id, string texto, string primera)
        {
            DataTable t = dt.Copy();
            if (primera != null)
            {
                DataRow r = t.NewRow();
                r[id] = 0; r[texto] = primera;
                t.Rows.InsertAt(r, 0);
            }
            c.DataSource = t; c.DisplayMember = texto; c.ValueMember = id;
        }

        // ---------------------------------------------------------------
        //  Listas desplegables
        // ---------------------------------------------------------------
        private void CargarCatalogos()
        {
            bool previo = cargando; cargando = true;
            try
            {
                DataTable cats = Datos.Tabla("SELECT IdCategoria, NombreCategoria FROM Categorias ORDER BY NombreCategoria");
                LlenarCombo(cmbCategoria, cats, "IdCategoria", "NombreCategoria", null);
                LlenarCombo(cmbFiltroCategoria, cats, "IdCategoria", "NombreCategoria", "Todas las categorías");

                DataTable est = Datos.Tabla("SELECT IdEstado, NombreEstado FROM Estados ORDER BY IdEstado");
                LlenarCombo(cmbEstado, est, "IdEstado", "NombreEstado", null);
                LlenarCombo(cmbFiltroEstado, est, "IdEstado", "NombreEstado", "Todos los estados");
                LlenarCombo(cmbDevEstado, est, "IdEstado", "NombreEstado", null);
                LlenarCombo(cmbMantEstado, est, "IdEstado", "NombreEstado", null);
                LlenarComboEstadoUnidad();

                DataTable sal = Datos.Tabla("SELECT IdSalon, NombreSalon FROM Salones ORDER BY NombreSalon");
                LlenarCombo(cmbUbicacion, sal, "IdSalon", "NombreSalon", "(Sin ubicación)");
                LlenarCombo(cmbPrestAula, sal, "IdSalon", "NombreSalon", "(Sin aula de destino)");
                LlenarCombo(cmbRepSalon, sal, "IdSalon", "NombreSalon", "Todos los salones y departamentos");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las listas: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { cargando = previo; }
        }

        // Combos de activos usados en Préstamos y Mantenimiento
        private void CargarCombosActivos()
        {
            object p1 = cmbPrestActivo.SelectedValue, p2 = cmbMantActivo.SelectedValue;
            bool previo = cargando; cargando = true;

            DataView dv = new DataView(dtActivos) { Sort = "Nombre" };
            DataTable lista = dv.ToTable(false, "IdActivo", "Nombre");
            LlenarCombo(cmbPrestActivo, lista, "IdActivo", "Nombre", null);
            LlenarCombo(cmbMantActivo, lista, "IdActivo", "Nombre", null);

            if (p1 != null) cmbPrestActivo.SelectedValue = p1;
            if (p2 != null) cmbMantActivo.SelectedValue = p2;
            cargando = previo;
        }

        // ---------------------------------------------------------------
        //  CATÁLOGO: tabla, filtros e indicadores (vw_ActivosDetalle)
        // ---------------------------------------------------------------
        private void CargarActivos()
        {
            try
            {
                dtActivos = Datos.Tabla(
                    @"SELECT IdActivo, CodigoInventario, Nombre, Categoria, TotalUnidades, UnidadesConProblema,
                             Ubicacion, IdCategoria, IdUbicacion
                      FROM vw_ActivosDetalle ORDER BY IdActivo");

                ActualizarIndicadores();

                vista = new DataView(dtActivos);
                dgvActivos.DataSource = vista;
                ConfigurarColumnas();
                AplicarFiltro();
                CargarCombosActivos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los activos: " + ex.Message, "Error SQL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnas()
        {
            if (dgvActivos.Columns.Count == 0) return;
            dgvActivos.Columns["IdCategoria"].Visible = false;
            dgvActivos.Columns["IdUbicacion"].Visible = false;
            Encabezado(dgvActivos, "IdActivo", "N°", 6);
            Encabezado(dgvActivos, "CodigoInventario", "Código", 14);
            Encabezado(dgvActivos, "Nombre", "Nombre del activo", 28);
            Encabezado(dgvActivos, "Categoria", "Categoría", 18);
            Encabezado(dgvActivos, "TotalUnidades", "Unidades", 9);
            Encabezado(dgvActivos, "UnidadesConProblema", "Con problema", 10);
            Encabezado(dgvActivos, "Ubicacion", "Ubicación", 18);
        }

        private static void Encabezado(DataGridView g, string columna, string texto, float peso)
        {
            if (!g.Columns.Contains(columna)) return;
            g.Columns[columna].HeaderText = texto;
            g.Columns[columna].FillWeight = peso;
            if (columna.StartsWith("Fecha") || columna == "Fecha")
                g.Columns[columna].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
        }

        private static string EscaparLike(string texto)
        {
            return texto.Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("*", "[*]");
        }

        private void AplicarFiltro()
        {
            if (vista == null) return;
            var condiciones = new List<string>();

            string t = txtBuscar.Text.Trim();
            if (t.Length > 0)
            {
                string e = EscaparLike(t);
                condiciones.Add("(Nombre LIKE '%" + e + "%' OR CodigoInventario LIKE '%" + e +
                                "%' OR Convert(IdActivo, 'System.String') LIKE '%" + e + "%')");
            }
            int idCat;
            if (cmbFiltroCategoria.SelectedValue != null &&
                int.TryParse(cmbFiltroCategoria.SelectedValue.ToString(), out idCat) && idCat > 0)
                condiciones.Add("IdCategoria = " + idCat);
            int idEst;
            if (cmbFiltroEstado.SelectedValue != null &&
                int.TryParse(cmbFiltroEstado.SelectedValue.ToString(), out idEst) && idEst > 0)
            {
                // el estado es de cada unidad: se buscan los tipos que tengan al menos una unidad en ese estado
                DataTable ids = Datos.Tabla("SELECT DISTINCT IdActivo FROM UnidadesActivo WHERE IdEstado = @e", Datos.P("@e", idEst));
                condiciones.Add(ids.Rows.Count == 0
                    ? "1 = 0"
                    : "IdActivo IN (" + string.Join(",", ids.AsEnumerable().Select(x => Convert.ToString(x["IdActivo"]))) + ")");
            }

            vista.RowFilter = string.Join(" AND ", condiciones);
            int n = vista.Count;
            lblResultados.Text = n + (n == 1 ? " resultado" : " resultados") + "  ·  fila rosada = daño abierto";
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e) { AplicarFiltro(); }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargando) return;
            AplicarFiltro();
        }

        // Indicadores de las 5 tarjetas
        private void ActualizarIndicadores()
        {
            try
            {
                lblKpi1.Text = dtActivos.Rows.Count.ToString();

                DataRow r = Datos.Tabla(
                    @"SELECT
                        (SELECT COUNT(*) FROM vw_Prestamos WHERE Estado = 'Activo')             AS Prestados,
                        (SELECT COUNT(*) FROM vw_Prestamos WHERE Alerta = 'Atrasado')           AS Atrasados,
                        (SELECT COUNT(*) FROM vw_ReportesDanio WHERE Estado = 'Abierto')        AS Danos,
                        (SELECT COUNT(*) FROM vw_StockConsumibles WHERE Alerta <> 'Normal')     AS StockBajo").Rows[0];

                int atrasados = Convert.ToInt32(r["Atrasados"]);
                int stock = Convert.ToInt32(r["StockBajo"]);
                lblKpi2.Text = Convert.ToString(r["Prestados"]);
                lblKpi3.Text = atrasados.ToString();
                lblKpi3.ForeColor = atrasados > 0 ? Color.FromArgb(255, 69, 58) : Color.FromArgb(76, 217, 100);
                lblKpi4.Text = Convert.ToString(r["Danos"]);
                lblKpi5.Text = stock.ToString();
                lblKpi5.ForeColor = stock > 0 ? Color.FromArgb(255, 159, 10) : Color.FromArgb(76, 217, 100);

                DataTable conDano = Datos.Tabla("SELECT DISTINCT IdActivo FROM vw_ReportesDanio WHERE Estado = 'Abierto'");
                activosConDano = new HashSet<int>(conDano.AsEnumerable().Select(x => Convert.ToInt32(x["IdActivo"])));
                dgvActivos.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron calcular los indicadores: " + ex.Message, "Error SQL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static Color? ColorEstado(string estado)
        {
            if (estado == "Nuevo" || estado == "Excelente") return Color.FromArgb(22, 163, 74);
            if (estado == "Bueno") return Color.FromArgb(101, 163, 13);
            if (estado == "Regular") return Color.FromArgb(217, 119, 6);
            if (estado == "Malo" || estado == "Dado de baja" || estado == "En reparación" ||
                estado.StartsWith("Mantenimiento")) return Color.FromArgb(220, 38, 38);
            return null;
        }

        private void dgvActivos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataRowView fila = dgvActivos.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (fila != null && activosConDano.Contains(Convert.ToInt32(fila["IdActivo"])))
                e.CellStyle.BackColor = Color.FromArgb(254, 226, 226);

            if (e.Value == null || dgvActivos.Columns[e.ColumnIndex].Name != "Estado") return;
            Color? color = ColorEstado(e.Value.ToString());
            if (color == null) return;
            e.CellStyle.ForeColor = color.Value;
            e.CellStyle.SelectionForeColor = Color.White;
        }

        // ---------------------------------------------------------------
        //  Selección de una fila -> modo edición + ficha
        // ---------------------------------------------------------------
        private void dgvActivos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataRowView fila = dgvActivos.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (fila == null) return;

            errorProvider.Clear();
            idSeleccionado = Convert.ToInt32(fila["IdActivo"]);
            string nombre = Convert.ToString(fila["Nombre"]);
            txtNombre.Text = nombre;
            txtCodigo.Text = Convert.ToString(fila["CodigoInventario"]);

            if (fila["IdCategoria"] != DBNull.Value) cmbCategoria.SelectedValue = Convert.ToInt32(fila["IdCategoria"]);
            cmbUbicacion.SelectedValue = fila["IdUbicacion"] == DBNull.Value ? 0 : Convert.ToInt32(fila["IdUbicacion"]);

            lblModo.Text = "Editando activo N° " + idSeleccionado;
            ActualizarBotones();
            CargarFicha(idSeleccionado, nombre);
        }

        private void ActualizarBotones()
        {
            bool admin = EsAdministrador();
            bool editando = idSeleccionado != 0;
            btnGuardar.Enabled = admin && !editando;
            btnActualizar.Enabled = admin && editando;
            btnEliminar.Enabled = admin && editando;
        }

        private void LimpiarFormulario()
        {
            idSeleccionado = 0;
            errorProvider.Clear();
            txtNombre.Clear(); txtCodigo.Clear();
            if (cmbCategoria.Items.Count > 0) cmbCategoria.SelectedIndex = 0;
            if (cmbEstado.Items.Count > 0) cmbEstado.SelectedIndex = 0;
            if (cmbUbicacion.Items.Count > 0) cmbUbicacion.SelectedIndex = 0;
            dgvActivos.ClearSelection();
            lblModo.Text = "Nuevo activo";
            LimpiarFicha();
            ActualizarBotones();
            txtNombre.Focus();
        }

        private void btnLimpiar_Click(object sender, EventArgs e) { LimpiarFormulario(); }

        // ---------------------------------------------------------------
        //  FICHA: ubicación, historial (trigger) y daños
        // ---------------------------------------------------------------
        private void CargarFicha(int idActivo, string nombre)
        {
            try
            {
                DataTable ubic = Datos.Tabla(
                    @"SELECT IdUnidad, IdEstado, Ubicacion AS Salon, CodigoInventario, Estado
                      FROM vw_UnidadesDetalle WHERE IdActivo = @id ORDER BY Ubicacion, CodigoInventario", Datos.P("@id", idActivo));
                // cambios del catálogo (nombre) + cambios de estado/salón de cada unidad
                DataTable hist = Datos.Tabla(
                    @"SELECT Fecha, Accion, Codigo, Antes, Despues, Usuario FROM (
                        SELECT Fecha, Accion, CAST(NULL AS VARCHAR(50)) AS Codigo,
                               CAST(NombreAnterior AS NVARCHAR(200)) AS Antes, CAST(NombreNuevo AS NVARCHAR(200)) AS Despues, Usuario
                        FROM vw_AuditoriaActivosDetalle
                        WHERE IdActivo = @id AND (Accion <> 'UPDATE' OR ISNULL(NombreAnterior,'') <> ISNULL(NombreNuevo,''))
                        UNION ALL
                        SELECT Fecha, Accion, CodigoInventario,
                               CAST(ISNULL(EstadoAnterior,'') + ISNULL(' · ' + SalonAnterior,'') AS NVARCHAR(200)),
                               CAST(ISNULL(EstadoNuevo,'')    + ISNULL(' · ' + SalonNuevo,'')    AS NVARCHAR(200)), Usuario
                        FROM vw_AuditoriaUnidadesDetalle
                        WHERE IdActivo = @id
                      ) h ORDER BY Fecha DESC", Datos.P("@id", idActivo));
                DataTable danos = Datos.Tabla(
                    @"SELECT FechaReporte, Estado, Prioridad, Salon, CodigoInventario, Cantidad,
                             Descripcion, ReportadoPor, FechaReparacion, ObservacionReparacion
                      FROM vw_ReportesDanio WHERE IdActivo = @id ORDER BY FechaReporte DESC", Datos.P("@id", idActivo));

                dgvUbicacion.DataSource = ubic; dgvHistorial.DataSource = hist; dgvDanos.DataSource = danos;
                dgvUbicacion.Columns["IdUnidad"].Visible = false;
                dgvUbicacion.Columns["IdEstado"].Visible = false;
                dgvUbicacion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvUbicacion.MultiSelect = false;

                Encabezado(dgvUbicacion, "Salon", "Salón", 40);
                Encabezado(dgvUbicacion, "CodigoInventario", "Código de inventario", 30);
                Encabezado(dgvUbicacion, "Estado", "Estado de la unidad", 30);

                Encabezado(dgvHistorial, "Fecha", "Fecha", 16);
                Encabezado(dgvHistorial, "Accion", "Acción", 10);
                Encabezado(dgvHistorial, "Codigo", "Unidad", 14);
                Encabezado(dgvHistorial, "Antes", "Antes", 26);
                Encabezado(dgvHistorial, "Despues", "Después", 26);
                Encabezado(dgvHistorial, "Usuario", "Usuario", 14);

                Encabezado(dgvDanos, "FechaReporte", "Reportado", 12);
                Encabezado(dgvDanos, "Estado", "Estado", 8);
                Encabezado(dgvDanos, "Prioridad", "Prioridad", 8);
                Encabezado(dgvDanos, "Salon", "Salón", 12);
                Encabezado(dgvDanos, "CodigoInventario", "Código", 10);
                Encabezado(dgvDanos, "Cantidad", "Unid.", 5);
                Encabezado(dgvDanos, "Descripcion", "Descripción", 22);
                Encabezado(dgvDanos, "ReportadoPor", "Reportó", 8);
                Encabezado(dgvDanos, "FechaReparacion", "Reparado", 12);
                Encabezado(dgvDanos, "ObservacionReparacion", "Observación", 18);

                int unidades = ubic.Rows.Count;
                int salones = ubic.AsEnumerable().Select(r => Convert.ToString(r["Salon"])).Distinct().Count();
                int abiertos = danos.Select("Estado = 'Abierto'").Length;

                lblFichaTitulo.Text = "Ficha: " + nombre + "   ·   " + unidades + (unidades == 1 ? " unidad" : " unidades") +
                    " en " + salones + (salones == 1 ? " salón" : " salones") + "   ·   " + abiertos +
                    (abiertos == 1 ? " reporte abierto" : " reportes abiertos");
                lblFichaTitulo.ForeColor = abiertos > 0 ? Color.FromArgb(255, 120, 110) : Color.White;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la ficha del activo: " + ex.Message, "Error SQL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFicha()
        {
            dgvUbicacion.DataSource = null; dgvHistorial.DataSource = null; dgvDanos.DataSource = null;
            lblFichaTitulo.Text = "Seleccione un activo para ver su ficha";
            lblFichaTitulo.ForeColor = Color.White;
        }

        // ---------------------------------------------------------------
        //  Validación y CRUD
        // ---------------------------------------------------------------
        private bool ValidarFormulario()
        {
            errorProvider.Clear();
            bool ok = true;

            string nombre = txtNombre.Text.Trim();
            if (nombre.Length == 0)
            { errorProvider.SetError(txtNombre, "El nombre del activo es obligatorio."); ok = false; }
            else if (Convert.ToInt32(Datos.Escalar(
                "SELECT COUNT(*) FROM GestionActivos WHERE LOWER(Nombre) = LOWER(@n) AND IdActivo <> @id",
                Datos.P("@n", nombre), Datos.P("@id", idSeleccionado))) > 0)
            { errorProvider.SetError(txtNombre, "Ya existe un activo con ese nombre."); ok = false; }

            string codigo = txtCodigo.Text.Trim();
            if (codigo.Length > 0 && Convert.ToInt32(Datos.Escalar(
                "SELECT COUNT(*) FROM GestionActivos WHERE CodigoInventario = @c AND IdActivo <> @id",
                Datos.P("@c", codigo), Datos.P("@id", idSeleccionado))) > 0)
            { errorProvider.SetError(txtCodigo, "Ese código de inventario ya está en uso."); ok = false; }

            if (cmbCategoria.SelectedValue == null) { errorProvider.SetError(cmbCategoria, "Seleccione una categoría."); ok = false; }
            return ok;
        }

        private object UbicacionSeleccionada()
        {
            int u = cmbUbicacion.SelectedValue == null ? 0 : Convert.ToInt32(cmbUbicacion.SelectedValue);
            return u > 0 ? (object)u : null;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario()) return;
            try
            {
                // IdActivo no es IDENTITY: se calcula el siguiente dentro de una transacción
                Datos.Ejecutar(
                    @"SET XACT_ABORT ON; BEGIN TRAN;
                      DECLARE @nuevoId INT = (SELECT ISNULL(MAX(IdActivo), 0) + 1
                                              FROM GestionActivos WITH (UPDLOCK, HOLDLOCK));
                      INSERT INTO GestionActivos (IdActivo, Nombre, IdCategoria, CodigoInventario, IdUbicacion)
                      VALUES (@nuevoId, @nombre, @categoria,
                              ISNULL(@codigo, 'ACT-' + RIGHT('0000' + CAST(@nuevoId AS VARCHAR(10)), 4)), @ubic);
                      COMMIT;",
                    Datos.P("@nombre", txtNombre.Text.Trim()),
                    Datos.P("@categoria", Convert.ToInt32(cmbCategoria.SelectedValue)),
                    Datos.PTexto("@codigo", txtCodigo.Text),
                    Datos.P("@ubic", UbicacionSeleccionada()));

                MessageBox.Show("Activo registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarActivos();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo registrar el activo: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // El trigger trg_AuditoriaActivos registra el cambio y la ficha lo muestra
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un activo de la tabla.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidarFormulario()) return;

            int id = idSeleccionado;
            string nombre = txtNombre.Text.Trim();
            try
            {
                Datos.Ejecutar(
                    @"UPDATE GestionActivos
                      SET Nombre = @nombre, IdCategoria = @categoria,
                          CodigoInventario = @codigo, IdUbicacion = @ubic
                      WHERE IdActivo = @id",
                    Datos.P("@nombre", nombre),
                    Datos.P("@categoria", Convert.ToInt32(cmbCategoria.SelectedValue)),
                    Datos.PTexto("@codigo", txtCodigo.Text),
                    Datos.P("@ubic", UbicacionSeleccionada()),
                    Datos.P("@id", id));

                MessageBox.Show("Activo actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarActivos();
                LimpiarFormulario();
                CargarFicha(id, nombre);
                tabFicha.SelectedTab = tabHistorial;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar el activo: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un activo de la tabla.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                int usos = Convert.ToInt32(Datos.Escalar(
                    @"SELECT (SELECT COUNT(*) FROM UnidadesActivo WHERE IdActivo = @id) +
                             (SELECT COUNT(*) FROM Prestamos WHERE IdActivo = @id) +
                             (SELECT COUNT(*) FROM MantenimientosActivo WHERE IdActivo = @id)",
                    Datos.P("@id", idSeleccionado)));

                if (usos > 0)
                {
                    MessageBox.Show(
                        "No se puede eliminar este activo porque tiene unidades asignadas o préstamos o mantenimientos registrados.\n\n" +
                        "Para retirar una unidad del uso, cambie su estado a 'Dado de baja' en la ficha (pestaña Ubicación).",
                        "Operación cancelada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("¿Está seguro de eliminar este activo?", "Confirmar eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

                Datos.Ejecutar("DELETE FROM GestionActivos WHERE IdActivo = @id", Datos.P("@id", idSeleccionado));
                MessageBox.Show("Activo eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarActivos();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar el activo: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------------------------------------------------------------
        //  ESTADO INDIVIDUAL: panel bajo la lista de unidades de la ficha
        // ---------------------------------------------------------------
        private ComboBox cmbEstadoUnidad;
        private Button btnCambiarEstadoUnidad;

        private void CrearPanelEstadoUnidad()
        {
            Panel pnl = new Panel { Dock = DockStyle.Bottom, Height = 34, BackColor = Tarjeta };
            Label lbl = new Label { Text = "Estado de la unidad seleccionada:", AutoSize = true,
                                    ForeColor = Color.White, Location = new Point(8, 9) };
            cmbEstadoUnidad = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Width = 200, Location = new Point(250, 5) };
            btnCambiarEstadoUnidad = new Button { Text = "Cambiar estado", Width = 130, Height = 26, Location = new Point(460, 4),
                                                  FlatStyle = FlatStyle.Flat, BackColor = Color.FromArgb(0, 120, 212), ForeColor = Color.White };
            btnCambiarEstadoUnidad.Click += btnCambiarEstadoUnidad_Click;
            pnl.Controls.Add(lbl); pnl.Controls.Add(cmbEstadoUnidad); pnl.Controls.Add(btnCambiarEstadoUnidad);
            tabUbicacion.Controls.Add(pnl);
            dgvUbicacion.BringToFront();   // la tabla ocupa el resto del espacio
            btnCambiarEstadoUnidad.Enabled = EsAdministrador();
        }

        private void LlenarComboEstadoUnidad()
        {
            if (cmbEstadoUnidad == null || cmbEstadoUnidad.Items.Count > 0) return;
            DataTable est = Datos.Tabla("SELECT IdEstado, NombreEstado FROM Estados ORDER BY IdEstado");
            cmbEstadoUnidad.DataSource = est;
            cmbEstadoUnidad.ValueMember = "IdEstado";
            cmbEstadoUnidad.DisplayMember = "NombreEstado";
        }

        // Cambia el estado de UNA sola unidad; las demás del mismo tipo no se tocan
        private void btnCambiarEstadoUnidad_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0 || dgvUbicacion.CurrentRow == null || !dgvUbicacion.Columns.Contains("IdUnidad"))
            {
                MessageBox.Show("Seleccione un activo y luego una unidad de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbEstadoUnidad.SelectedValue == null) return;

            int idUnidad = Convert.ToInt32(dgvUbicacion.CurrentRow.Cells["IdUnidad"].Value);
            string codigo = Convert.ToString(dgvUbicacion.CurrentRow.Cells["CodigoInventario"].Value);
            try
            {
                Datos.Procedimiento("sp_CambiarEstadoUnidad",
                    Datos.P("@IdUnidad", idUnidad),
                    Datos.P("@IdEstado", Convert.ToInt32(cmbEstadoUnidad.SelectedValue)));
                string nombre = txtNombre.Text.Trim();
                CargarActivos();
                CargarFicha(idSeleccionado, nombre);
                MessageBox.Show("La unidad " + codigo + " ahora está en estado '" + cmbEstadoUnidad.Text + "'.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cambiar el estado: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportarPdf_Click(object sender, EventArgs e)
        {
            try
            {
                if (vista == null || vista.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DataTable dt = vista.ToTable(false, "CodigoInventario", "Nombre", "Categoria", "TotalUnidades", "UnidadesConProblema", "Ubicacion");
                dt.Columns["CodigoInventario"].ColumnName = "Código";
                dt.Columns["Nombre"].ColumnName = "Nombre del activo";
                dt.Columns["Categoria"].ColumnName = "Categoría";
                dt.Columns["TotalUnidades"].ColumnName = "Unidades";
                dt.Columns["UnidadesConProblema"].ColumnName = "Con problema";
                dt.Columns["Ubicacion"].ColumnName = "Ubicación";
                ExportadorPdf.Exportar("Catálogo de activos", dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}