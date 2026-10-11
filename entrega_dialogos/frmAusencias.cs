using Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Vistass
{
    // Lista de ausencias y permisos del personal. Registrar y anular es solo del administrador.
    public partial class frmAusencias : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        private static readonly CultureInfo Es = new CultureInfo("es-ES");
        private static readonly CultureInfo Inv = CultureInfo.InvariantCulture;

        private DataTable dtAusencias;
        private DataView vista;          // lo que muestra la tabla (ya filtrado en memoria)
        private bool cargando = true;    // evita filtrar mientras se llenan los combos
        private bool esAdmin;

        public frmAusencias()
        {
            InitializeComponent();
        }

        private void frmAusencias_Load(object sender, EventArgs e)
        {
            esAdmin = Sesion.Rol != null &&
                      Sesion.Rol.Trim().Equals("Administrador", StringComparison.OrdinalIgnoreCase);

            SendMessage(txtBuscar.Handle, EM_SETCUEBANNER, 1, "Buscar por empleado, cargo o motivo...");
            toolTip1.SetToolTip(btnRegistrar, "Registrar una falta, permiso o incapacidad");
            toolTip1.SetToolTip(btnAnular, "Anular la ausencia seleccionada (queda en el historial)");
            toolTip1.SetToolTip(btnExportar, "Exportar a PDF lo que se está viendo");
            EstilizarGrid();

            // Tipos (los textos coinciden con los valores que guarda la base de datos)
            cmbTipo.Items.AddRange(new object[] { "Todos los tipos", "Falta", "Permiso", "Incapacidad" });
            cmbTipo.SelectedIndex = 0;

            // Períodos: los últimos 12 meses (el actual primero)
            DataTable per = new DataTable();
            per.Columns.Add("Clave", typeof(string));
            per.Columns.Add("Texto", typeof(string));
            per.Rows.Add("", "Todos los períodos");
            for (int i = 0; i < 12; i++)
            {
                DateTime m = DateTime.Today.AddMonths(-i);
                string t = m.ToString("MMMM yyyy", Es);
                per.Rows.Add(m.ToString("yyyy-MM", Inv), char.ToUpper(t[0]) + t.Substring(1));
            }
            cmbPeriodo.DisplayMember = "Texto";
            cmbPeriodo.ValueMember = "Clave";
            cmbPeriodo.DataSource = per;

            cargando = false;
            Cargar();
        }

        private void EstilizarGrid()
        {
            DataGridView g = dgvAusencias;
            g.AllowUserToAddRows = false; g.AllowUserToDeleteRows = false; g.AllowUserToResizeRows = false;
            g.ReadOnly = true; g.RowHeadersVisible = false; g.MultiSelect = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            g.ColumnHeadersHeight = 40; g.RowTemplate.Height = 36;


        }

        // Los datos se traen una vez; los filtros trabajan en memoria (DataView) y por eso responden al instante
        private void Cargar()
        {
            try
            {
                dtAusencias = Datos.Tabla(
                    @"SELECT IdAusencia, IdEmpleado, Empleado, Cargo, Tipo, Clase, FechaInicio, FechaFin, Dias,
                             CASE WHEN Descuenta = 1 THEN 'Sí' ELSE 'No' END AS SeDescuenta, Descuenta,
                             Motivo, RegistradoPor, FechaRegistro, CAST(Anulada AS INT) AS Anulada,
                             CASE WHEN Anulada = 1 THEN 'Anulada' ELSE 'Vigente' END AS Estado
                      FROM vw_AusenciasDetalle
                      ORDER BY FechaInicio DESC, Empleado");

                vista = new DataView(dtAusencias);
                dgvAusencias.DataSource = vista;
                FormatearGrid();
                AplicarFiltro();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar las ausencias: " + ex.Message, "Error SQL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatearGrid()
        {
            foreach (string oculta in new[] { "IdAusencia", "IdEmpleado", "Tipo", "Descuenta", "FechaRegistro", "Anulada" })
                if (dgvAusencias.Columns.Contains(oculta)) dgvAusencias.Columns[oculta].Visible = false;

            Columna("Empleado", "Empleado", 20);
            Columna("Cargo", "Cargo", 13);
            Columna("Clase", "Tipo", 18);
            Columna("FechaInicio", "Desde", 9);
            Columna("FechaFin", "Hasta", 9);
            Columna("Dias", "Días hábiles", 8);
            Columna("SeDescuenta", "Se descuenta", 9);
            Columna("Motivo", "Motivo", 17);
            Columna("RegistradoPor", "Registró", 10);
            Columna("Estado", "Estado", 8);

            dgvAusencias.Columns["FechaInicio"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvAusencias.Columns["FechaFin"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvAusencias.Columns["Dias"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAusencias.Columns["SeDescuenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void Columna(string nombre, string encabezado, float peso)
        {
            if (!dgvAusencias.Columns.Contains(nombre)) return;
            dgvAusencias.Columns[nombre].HeaderText = encabezado;
            dgvAusencias.Columns[nombre].FillWeight = peso;
        }

        // Lo que se descuenta se resalta; lo anulado se atenúa
        private void dgvAusencias_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataRowView r = dgvAusencias.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (r == null) return;

            if (Convert.ToInt32(r["Anulada"]) == 1)
            {
                e.CellStyle.ForeColor = Color.FromArgb(150, 150, 160);
                return;
            }
            if (dgvAusencias.Columns[e.ColumnIndex].Name == "SeDescuenta" && Convert.ToString(e.Value) == "Sí")
            {
                e.CellStyle.ForeColor = Color.FromArgb(252, 165, 165);
                e.CellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            }
        }

        // ---------------------------------------------------------------
        //  Filtros
        // ---------------------------------------------------------------
        private static string Escapar(string t)
        {
            return t.Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("*", "[*]");
        }

        private void Filtro_Changed(object sender, EventArgs e)
        {
            if (cargando) return;
            AplicarFiltro();
        }

        private void AplicarFiltro()
        {
            if (vista == null) return;
            var cond = new List<string>();

            string t = txtBuscar.Text.Trim();
            if (t.Length > 0)
            {
                string esc = Escapar(t);
                cond.Add("(Empleado LIKE '%" + esc + "%' OR Cargo LIKE '%" + esc + "%' OR Motivo LIKE '%" + esc + "%')");
            }

            if (cmbTipo.SelectedIndex > 0) cond.Add("Tipo = '" + cmbTipo.Text + "'");

            // Una ausencia entra en un mes si se SOLAPA con él (aunque empiece o termine en otro mes)
            string clave = cmbPeriodo.SelectedValue as string;
            if (!string.IsNullOrEmpty(clave))
            {
                DateTime ini = DateTime.ParseExact(clave + "-01", "yyyy-MM-dd", Inv);
                DateTime fin = ini.AddMonths(1).AddDays(-1);
                cond.Add("FechaInicio <= #" + fin.ToString("MM/dd/yyyy", Inv) + "# AND FechaFin >= #" +
                         ini.ToString("MM/dd/yyyy", Inv) + "#");
            }

            if (!chkAnuladas.Checked) cond.Add("Anulada = 0");

            vista.RowFilter = string.Join(" AND ", cond);

            int diasDescontables = 0;
            foreach (DataRowView r in vista)
                if (Convert.ToInt32(r["Anulada"]) == 0 && Convert.ToInt32(r["Descuenta"]) == 1)
                    diasDescontables += Convert.ToInt32(r["Dias"]);

            lblResultados.Text = vista.Count + (vista.Count == 1 ? " ausencia" : " ausencias") +
                                 "   ·   " + diasDescontables + (diasDescontables == 1 ? " día descontable" : " días descontables");
            ActualizarBotones();
        }

        // ---------------------------------------------------------------
        //  Acciones
        // ---------------------------------------------------------------
        private void dgvAusencias_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarBotones();
        }

        private DataRowView Seleccionada()
        {
            return dgvAusencias.SelectedRows.Count == 1 ? dgvAusencias.SelectedRows[0].DataBoundItem as DataRowView : null;
        }

        private void ActualizarBotones()
        {
            DataRowView r = Seleccionada();
            btnRegistrar.Enabled = esAdmin;
            btnAnular.Enabled = esAdmin && r != null && Convert.ToInt32(r["Anulada"]) == 0;
            btnExportar.Enabled = vista != null && vista.Count > 0;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            using (frmRegistrarAusencia frm = new frmRegistrarAusencia())
            {
                if (frm.ShowDialog(this) == DialogResult.OK) Cargar();
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            DataRowView r = Seleccionada();
            if (r == null) return;

            string resumen = Convert.ToString(r["Empleado"]) + " · " + Convert.ToString(r["Clase"]) + " · " +
                             Convert.ToDateTime(r["FechaInicio"]).ToString("dd/MM/yyyy") + " al " +
                             Convert.ToDateTime(r["FechaFin"]).ToString("dd/MM/yyyy");

            if (MessageBox.Show("¿Anular esta ausencia?\n\n" + resumen + "\n\n" +
                "Quedará en el historial como anulada y dejará de descontarse en la planilla.\n" +
                "Si el pago de ese mes ya se registró, deberá editarlo o anularlo para que el cambio se refleje.",
                "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            try
            {
                Datos.Procedimiento("sp_AnularAusencia", Datos.P("@IdAusencia", Convert.ToInt32(r["IdAusencia"])));
                Cargar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "No se pudo anular", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (vista == null || vista.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                DataTable dt = vista.ToTable(false, "Empleado", "Cargo", "Clase", "FechaInicio", "FechaFin", "Dias",
                                             "SeDescuenta", "Motivo", "RegistradoPor", "Estado");
                dt.Columns["Clase"].ColumnName = "Tipo";
                dt.Columns["FechaInicio"].ColumnName = "Desde";
                dt.Columns["FechaFin"].ColumnName = "Hasta";
                dt.Columns["Dias"].ColumnName = "Días hábiles";
                dt.Columns["SeDescuenta"].ColumnName = "Se descuenta";
                dt.Columns["RegistradoPor"].ColumnName = "Registró";
                string titulo = cmbPeriodo.SelectedIndex > 0 ? "Ausencias de " + cmbPeriodo.Text : "Ausencias y permisos";
                ExportadorPdf.Exportar(titulo, dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}