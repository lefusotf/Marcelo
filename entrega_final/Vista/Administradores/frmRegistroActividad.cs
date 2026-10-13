using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Modelos;

namespace Vistass
{

    public partial class frmRegistroActividad : Form
    {
        private const int Limite = 1000;        
        private const string Todos = "(Todos)";

        public frmRegistroActividad()
        {
            InitializeComponent();
        }

   
        private void frmRegistroActividad_Load(object sender, EventArgs e)
        {
            
            if (Sesion.Rol != "Administrador")
            {
                lblSubtitulo.Text = "Solo los administradores pueden ver esta pantalla.";
                pnlFiltros.Visible = false;
                pnlTabla.Visible = false;
                lblResultados.Text = "";
                return;
            }

            dtpDesde.Value = DateTime.Today.AddDays(-6);
            dtpHasta.Value = DateTime.Today;
            CargarFiltros();
            Buscar();
        }

       
        private void CargarFiltros()
        {
            try
            {
                SortedSet<string> usuarios = new SortedSet<string>();
                foreach (DataRow r in Datos.Tabla(
                    "SELECT DISTINCT ISNULL(Usuario, N'(sistema)') AS Usuario FROM dbo.Auditoria").Rows)
                    usuarios.Add(Convert.ToString(r["Usuario"]));

                SortedSet<string> modulos = new SortedSet<string>();
                SortedSet<string> acciones = new SortedSet<string>();
                foreach (DataRow r in Datos.Tabla("SELECT DISTINCT Modulo, Accion FROM dbo.vw_Auditoria").Rows)
                {
                    modulos.Add(Convert.ToString(r["Modulo"]));
                    acciones.Add(Convert.ToString(r["Accion"]));
                }

                LlenarCombo(cmbUsuario, usuarios);
                LlenarCombo(cmbModulo, modulos);
                LlenarCombo(cmbAccion, acciones);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los filtros.\n\n" + ex.Message,
                                "Registro de actividad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static void LlenarCombo(ComboBox cmb, IEnumerable<string> valores)
        {
            cmb.Items.Clear();
            cmb.Items.Add(Todos);
            foreach (string v in valores) cmb.Items.Add(v);
            cmb.SelectedIndex = 0;
        }

        
        private static object ValorFiltro(ComboBox cmb)
        {
            return cmb.SelectedIndex <= 0 ? null : cmb.SelectedItem.ToString();
        }

       
        private void Buscar()
        {
            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date.AddDays(1);   
            if (hasta <= desde)
            {
                MessageBox.Show("La fecha final no puede ser anterior a la inicial.",
                                "Registro de actividad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string texto = txtBuscar.Text.Trim();
            object patron = null;
            if (texto.Length > 0)
                patron = "%" + texto.Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]") + "%";

            string sql =
                "SELECT TOP (" + Limite + ") IdAuditoria, FechaHora, Usuario, NombreCompleto, Modulo, Accion, Clave, Resumen " +
                "FROM dbo.vw_Auditoria " +
                "WHERE FechaHora >= @d AND FechaHora < @h " +
                "  AND (@u IS NULL OR Usuario = @u) " +
                "  AND (@m IS NULL OR Modulo = @m) " +
                "  AND (@a IS NULL OR Accion = @a) " +
                "  AND (@q IS NULL OR Resumen LIKE @q OR Clave LIKE @q) " +
                "ORDER BY IdAuditoria DESC";

            try
            {
                Cursor = Cursors.WaitCursor;
                DataTable dt = Datos.Tabla(sql,
                    Datos.P("@d", desde), Datos.P("@h", hasta),
                    Datos.P("@u", ValorFiltro(cmbUsuario)),
                    Datos.P("@m", ValorFiltro(cmbModulo)),
                    Datos.P("@a", ValorFiltro(cmbAccion)),
                    Datos.P("@q", patron));

                dgvActividad.DataSource = dt;
                lblResultados.Text = dt.Rows.Count >= Limite
                    ? "Mostrando los " + Limite + " más recientes"
                    : dt.Rows.Count + (dt.Rows.Count == 1 ? " registro" : " registros");
                dgvActividad_SelectionChanged(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo consultar el registro.\n\n" + ex.Message,
                                "Registro de actividad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

     
        private void btnBuscar_Click(object sender, EventArgs e) { Buscar(); }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; Buscar(); }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today.AddDays(-6);
            dtpHasta.Value = DateTime.Today;
            cmbUsuario.SelectedIndex = 0;
            cmbModulo.SelectedIndex = 0;
            cmbAccion.SelectedIndex = 0;
            txtBuscar.Clear();
            Buscar();
        }

        private void btnHoy_Click(object sender, EventArgs e) { Rango(0); }
        private void btnSemana_Click(object sender, EventArgs e) { Rango(6); }
        private void btnMes_Click(object sender, EventArgs e) { Rango(29); }

        private void Rango(int diasAtras)
        {
            dtpDesde.Value = DateTime.Today.AddDays(-diasAtras);
            dtpHasta.Value = DateTime.Today;
            Buscar();
        }


        private void dgvActividad_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != colAccion.Index || e.Value == null) return;

            string a = Convert.ToString(e.Value);
            if (a.StartsWith("Cre") || a.StartsWith("Reactiv") || a.StartsWith("Inici") || a.StartsWith("Marc"))
                e.CellStyle.ForeColor = Color.FromArgb(74, 222, 128);
            else if (a.StartsWith("Elimin") || a.StartsWith("Anul") || a.StartsWith("Desactiv") || a.StartsWith("Intento"))
                e.CellStyle.ForeColor = Color.FromArgb(248, 113, 113);
            else if (a.StartsWith("Modific"))
                e.CellStyle.ForeColor = Color.FromArgb(251, 191, 36);
        }

        private void dgvActividad_SelectionChanged(object sender, EventArgs e)
        {
            btnDetalle.Enabled = dgvActividad.CurrentRow != null;
        }

        private void dgvActividad_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) VerDetalle();
        }

        private void btnDetalle_Click(object sender, EventArgs e) { VerDetalle(); }

        private void VerDetalle()
        {
            DataGridViewRow fila = dgvActividad.CurrentRow;
            if (fila == null) return;

            long id = Convert.ToInt64(fila.Cells[colId.Index].Value);
            using (frmDetalleActividad dlg = new frmDetalleActividad(id))
                dlg.ShowDialog(this);
        }
    }
}