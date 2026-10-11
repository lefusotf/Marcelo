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
        private DataTable dtActivos = new DataTable();
        private DataView vista;
        private HashSet<int> activosConDano = new HashSet<int>();
        private int idSeleccionado = 0;      // 0 = modo "nuevo activo"
        private bool cargando = false;       // evita disparar eventos mientras se llenan listas

        public frmGestionActivos()
        {
            InitializeComponent();
        }

        private void frmGestionActivos_Load(object sender, EventArgs e)
        {
            ConfigurarTooltips();
            CargarCatalogos();
            CargarActivos();
            LimpiarFormulario();
            InicializarPrestamos();
            InicializarConsumibles();
            InicializarMantenimiento();
            InicializarReportes();
        }

        private void ConfigurarTooltips()
        {
            toolTip1.SetToolTip(txtCodigo, "Identificador único. Si lo deja vacío se genera uno (ACT-0001)");
            toolTip1.SetToolTip(cmbUbicacion, "Dónde se guarda normalmente el activo");
            toolTip1.SetToolTip(btnEliminar, "Solo si no tiene salones, préstamos ni mantenimientos. Si no, use el estado 'Dado de baja'");
            toolTip1.SetToolTip(btnPrestar, "Registra la salida del equipo; no se presta equipo en mal estado");
            toolTip1.SetToolTip(btnDevolver, "Cierra el préstamo y actualiza el estado físico del activo");
            toolTip1.SetToolTip(btnHoja, "Genera la hoja de resguardo en PDF para la firma del responsable");
            toolTip1.SetToolTip(btnHistorial, "Historial de cambios y reportes de daño del activo");
        }

        private bool EsAdministrador()
        {
            return Sesion.Rol != null &&
                   Sesion.Rol.Trim().Equals("Administrador", StringComparison.OrdinalIgnoreCase);
        }

        // Administrador que inició sesión (queda en el kardex y en los registros de movimientos)
        private string UsuarioActual()
        {
            return string.IsNullOrWhiteSpace(Sesion.Usuario) ? Environment.UserName : Sesion.Usuario;
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
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e) { AplicarFiltro(); }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargando) return;
            AplicarFiltro();
        }

        // Franja de alertas (solo lo que requiere atención)
        private void ActualizarIndicadores()
        {
            try
            {
                DataRow r = Datos.Tabla(
                    @"SELECT
                        (SELECT COUNT(*) FROM vw_Prestamos WHERE Estado = 'Activo')             AS Prestados,
                        (SELECT COUNT(*) FROM vw_Prestamos WHERE Alerta = 'Atrasado')           AS Atrasados,
                        (SELECT COUNT(*) FROM vw_ReportesDanio WHERE Estado = 'Abierto')        AS Danos,
                        (SELECT COUNT(*) FROM vw_StockConsumibles WHERE Alerta <> 'Normal')     AS StockBajo").Rows[0];

                MostrarAlertas(dtActivos.Rows.Count,
                    Convert.ToInt32(r["Prestados"]), Convert.ToInt32(r["Atrasados"]),
                    Convert.ToInt32(r["Danos"]), Convert.ToInt32(r["StockBajo"]));

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

        private void MostrarAlertas(int activos, int prestados, int atrasados, int danos, int stockBajo)
        {
            flpAlertas.SuspendLayout();
            foreach (Control c in flpAlertas.Controls) c.Dispose();
            flpAlertas.Controls.Clear();

            // Rojo / ámbar = requieren atención. Azul = informativo.
            if (danos > 0)
                AgregarAlerta(danos + (danos == 1 ? " reporte de daño abierto" : " reportes de daño abiertos"),
                    Color.FromArgb(239, 68, 68), Color.FromArgb(252, 165, 165), 3);
            if (atrasados > 0)
                AgregarAlerta(atrasados + (atrasados == 1 ? " préstamo atrasado" : " préstamos atrasados"),
                    Color.FromArgb(245, 158, 11), Color.FromArgb(252, 211, 77), 1);
            if (stockBajo > 0)
                AgregarAlerta(stockBajo + (stockBajo == 1 ? " consumible en alerta de stock" : " consumibles en alerta de stock"),
                    Color.FromArgb(245, 158, 11), Color.FromArgb(252, 211, 77), 2);
            if (prestados > 0)
                AgregarAlerta(prestados + (prestados == 1 ? " préstamo activo" : " préstamos activos"),
                    Color.FromArgb(96, 165, 250), Color.FromArgb(147, 197, 253), 1);

            if (flpAlertas.Controls.Count == 0)
                AgregarAlerta("Sin alertas", Color.FromArgb(34, 197, 94), Color.FromArgb(134, 239, 172), -1);

            Label lbl = new Label();
            lbl.AutoSize = true;
            lbl.ForeColor = Color.FromArgb(170, 180, 200);
            lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            lbl.Text = activos + " activos registrados";
            lbl.Margin = new Padding(6, 7, 0, 0);
            flpAlertas.Controls.Add(lbl);

            flpAlertas.ResumeLayout();
        }

        private void AgregarAlerta(string texto, Color baseColor, Color letra, int tabDestino)
        {
            AlertaChip chip = new AlertaChip(texto, baseColor, letra);
            chip.Margin = new Padding(0, 0, 10, 0);
            if (tabDestino >= 0)
                chip.Click += delegate { tabPrincipal.SelectedIndex = tabDestino; };
            else
                chip.Cursor = Cursors.Default;
            flpAlertas.Controls.Add(chip);
        }

        private class AlertaChip : Control
        {
            private readonly Color baseColor, letra;
            private bool hover;

            public AlertaChip(string texto, Color baseColor, Color letra)
            {
                this.baseColor = baseColor;
                this.letra = letra;
                Text = texto;
                Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
                Cursor = Cursors.Hand;
                SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                         ControlStyles.SupportsTransparentBackColor, true);
                BackColor = Color.Transparent;
                Size sz = TextRenderer.MeasureText(texto, Font);
                Size = new Size(sz.Width + 44, 30);
            }

            protected override void OnMouseEnter(EventArgs e) { hover = true; Invalidate(); base.OnMouseEnter(e); }
            protected override void OnMouseLeave(EventArgs e) { hover = false; Invalidate(); base.OnMouseLeave(e); }

            protected override void OnPaint(PaintEventArgs e)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                System.Drawing.Rectangle r = new System.Drawing.Rectangle(0, 0, Width - 1, Height - 1);
                int d = Height - 1;
                using (System.Drawing.Drawing2D.GraphicsPath p = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    p.AddArc(r.X, r.Y, d, d, 90, 180);
                    p.AddArc(r.Right - d, r.Y, d, d, 270, 180);
                    p.CloseFigure();
                    using (SolidBrush b = new SolidBrush(Color.FromArgb(hover ? 64 : 40, baseColor)))
                        e.Graphics.FillPath(b, p);
                    using (Pen pen = new Pen(Color.FromArgb(130, baseColor)))
                        e.Graphics.DrawPath(pen, p);
                }
                using (SolidBrush punto = new SolidBrush(baseColor))
                    e.Graphics.FillEllipse(punto, 13, (Height - 8) / 2, 8, 8);
                TextRenderer.DrawText(e.Graphics, Text, Font,
                    new System.Drawing.Rectangle(28, 0, Width - 28, Height), letra,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.NoPadding);
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
                e.CellStyle.BackColor = Color.FromArgb(72, 32, 42);     

            if (e.Value == null || dgvActivos.Columns[e.ColumnIndex].Name != "Estado") return;
            Color? color = ColorEstado(e.Value.ToString());
            if (color == null) return;
            e.CellStyle.ForeColor = color.Value;
            e.CellStyle.SelectionForeColor = Color.White;
        }

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

        private void CargarFicha(int idActivo, string nombre) { }
        private void LimpiarFicha() { }

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
                        "No se puede eliminar este activo porque está asignado a un salón o tiene préstamos o mantenimientos registrados.\n\n" +
                        "Para retirarlo del uso, cambie su estado a 'Dado de baja'.",
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

        private void btnVerUnidades_Click(object sender, EventArgs e)
        {
            AbrirUnidades();
        }

        private void dgvActivos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) AbrirUnidades();
        }

        private void AbrirUnidades()
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un activo de la tabla.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombre = txtNombre.Text.Trim();
            using (frmUnidadesActivo frm = new frmUnidadesActivo(idSeleccionado, nombre, EsAdministrador()))
                frm.ShowDialog(this);

            // al volver se refrescan los totales y la ficha
            CargarActivos();
            CargarFicha(idSeleccionado, nombre);
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un activo de la tabla.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (frmHistorialActivo frm = new frmHistorialActivo(idSeleccionado, txtNombre.Text.Trim()))
                frm.ShowDialog(this);
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

        private void tabPrincipal_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
        }

        private void lblCodigo_Click(object sender, EventArgs e)
        {
        }
    }
}