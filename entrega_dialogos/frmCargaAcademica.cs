using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Vistass
{
    // Reporte de carga académica del año lectivo, con dos vistas:
    //  - Por docente: materias, grupos, horas semanales y % de la carga máxima (40 h).
    //    También muestra a los docentes que todavía NO tienen grupos asignados.
    //  - Por grado y sección: cuántos docentes atienden cada grupo (y los grupos sin docente).
    public class frmCargaAcademica : Form
    {
        private readonly ComboOscuro cmbVista = new ComboOscuro();
        private readonly ComboOscuro cmbAnio = new ComboOscuro();
        private readonly GridOscuro dgv = new GridOscuro();
        private readonly Label lblInfo = new Label();
        private DataTable actual;

        private static readonly Font FuenteNegrita = new Font("Segoe UI", 10F, FontStyle.Bold);

        public frmCargaAcademica()
        {
            Text = "Carga académica";
            ShowIcon = false; ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            BackColor = PaletaSistema.Fondo;
            ForeColor = PaletaSistema.Texto;
            Font = new Font("Segoe UI", 9.5F);
            ClientSize = new Size(1120, 660);
            MinimumSize = new Size(900, 480);

            Label titulo = new Label
            {
                Text = "Carga académica",
                AutoSize = false,
                Dock = DockStyle.Top,
                Height = 56,
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = PaletaSistema.Texto,
                Padding = new Padding(24, 10, 0, 0)
            };

            PanelTarjeta barra = new PanelTarjeta { Dock = DockStyle.Top, Height = 70 };

            cmbVista.Font = new Font("Segoe UI", 10.5F); cmbVista.Location = new Point(24, 19); cmbVista.Width = 250;
            cmbVista.Items.AddRange(new object[] { "Por docente", "Por grado y sección" });

            cmbAnio.Font = new Font("Segoe UI", 10.5F); cmbAnio.Location = new Point(290, 19); cmbAnio.Width = 120;

            BotonTema btnPdf = new BotonTema
            {
                Text = "Exportar PDF",
                Location = new Point(430, 17),
                Size = new Size(140, 36),
                Tipo = TipoBoton.Secundario
            };
            btnPdf.Click += Exportar;

            BotonTema btnCerrar = new BotonTema
            {
                Text = "Cerrar",
                Location = new Point(586, 17),
                Size = new Size(100, 36),
                Tipo = TipoBoton.Secundario,
                DialogResult = DialogResult.Cancel
            };
            CancelButton = btnCerrar;

            lblInfo.AutoSize = false; lblInfo.Location = new Point(710, 24); lblInfo.Size = new Size(380, 24);
            lblInfo.ForeColor = PaletaSistema.Tenue; lblInfo.TextAlign = ContentAlignment.MiddleRight;
            lblInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            barra.Controls.AddRange(new Control[] { cmbVista, cmbAnio, btnPdf, btnCerrar, lblInfo });

            Panel contenedor = new Panel { Dock = DockStyle.Fill, Padding = new Padding(24, 16, 24, 24) };
            dgv.Dock = DockStyle.Fill;
            contenedor.Controls.Add(dgv);

            // El último control agregado se acopla primero: título arriba, luego la barra y al final el relleno
            Controls.Add(contenedor);
            Controls.Add(barra);
            Controls.Add(titulo);

            dgv.AllowUserToAddRows = false; dgv.AllowUserToDeleteRows = false; dgv.AllowUserToResizeRows = false;
            dgv.ReadOnly = true; dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.CellFormatting += FormatoCeldas;

            // Se llena cuando la ventana ya está lista (evento Load)
            Load += (s, e) =>
            {
                int anio = DateTime.Today.Year;
                for (int a = anio - 2; a <= anio + 1; a++) cmbAnio.Items.Add(a);
                cmbAnio.SelectedItem = anio;
                cmbVista.SelectedIndex = 0;
                cmbVista.SelectedIndexChanged += (s2, e2) => Cargar();
                cmbAnio.SelectedIndexChanged += (s2, e2) => Cargar();
                Cargar();
            };
        }

        private void Cargar()
        {
            if (cmbAnio.SelectedItem == null || cmbVista.SelectedIndex < 0) return;
            int anio = Convert.ToInt32(cmbAnio.SelectedItem);

            try
            {
                if (cmbVista.SelectedIndex == 0)
                {
                    // Docentes con carga (vw_CargaDocente) + docentes activos que todavía no tienen grupos ese año
                    actual = Datos.Tabla(
                        @"SELECT d.Docente, ISNULL(d.Materia, '') AS Materias, d.TotalHoras AS [Horas semanales],
                                 d.Grupos AS Grupos, CAST(d.TotalHoras * 100.0 / 40 AS DECIMAL(5,1)) AS [% de carga]
                          FROM vw_CargaDocente d
                          WHERE d.AnioLectivo = @a
                          UNION ALL
                          SELECT e.Nombre,
                                 ISNULL((SELECT STRING_AGG(m.NombreMateria, ', ')
                                         FROM EmpleadoMaterias em JOIN Materias m ON m.IdMateria = em.IdMateria
                                         WHERE em.IdEmpleado = e.IdEmpleado), ''),
                                 0, 0, CAST(0 AS DECIMAL(5,1))
                          FROM Empleados e
                          JOIN Cargos c ON c.IdCargo = e.IdCargo
                          WHERE LOWER(c.NombreCargo) LIKE 'docente%' AND e.IdEstado <> 2
                            AND NOT EXISTS (SELECT 1 FROM AsignacionesDocente a
                                            WHERE a.IdEmpleado = e.IdEmpleado AND a.AnioLectivo = @a)
                          ORDER BY 1", Datos.P("@a", anio));

                    int sinGrupos = 0, completos = 0;
                    foreach (DataRow r in actual.Rows)
                    {
                        int h = Convert.ToInt32(r["Horas semanales"]);
                        if (h == 0) sinGrupos++; else if (h >= 40) completos++;
                    }
                    lblInfo.Text = actual.Rows.Count + " docentes · " + completos + " con 40 h · " + sinGrupos + " sin grupos";
                }
                else
                {
                    // Todas las secciones, incluso las que no tienen docente asignado
                    actual = Datos.Tabla(
                        @"SELECT g.NombreGrado AS Grado, s.NombreSeccion AS [Sección],
                                 (SELECT COUNT(DISTINCT a.IdEmpleado) FROM AsignacionesDocente a
                                  WHERE a.IdSeccion = s.IdSeccion AND a.AnioLectivo = @a) AS Docentes,
                                 (SELECT ISNULL(SUM(a.HorasSemanales), 0) FROM AsignacionesDocente a
                                  WHERE a.IdSeccion = s.IdSeccion AND a.AnioLectivo = @a) AS [Horas semanales],
                                 ISNULL((SELECT STRING_AGG(x.Txt, '; ')
                                         FROM (SELECT DISTINCT e.Nombre + ' - ' + ISNULL(m.NombreMateria, '') AS Txt
                                               FROM AsignacionesDocente a
                                               JOIN Empleados e ON e.IdEmpleado = a.IdEmpleado
                                               LEFT JOIN Materias m ON m.IdMateria = a.IdMateria
                                               WHERE a.IdSeccion = s.IdSeccion AND a.AnioLectivo = @a) x),
                                         'Sin docentes asignados') AS [Docentes y materias]
                          FROM Secciones s
                          JOIN Grados g ON g.IdGrado = s.IdGrado
                          ORDER BY g.Orden, s.NombreSeccion", Datos.P("@a", anio));

                    int sinDocente = 0;
                    foreach (DataRow r in actual.Rows) if (Convert.ToInt32(r["Docentes"]) == 0) sinDocente++;
                    lblInfo.Text = actual.Rows.Count + " grupos · " + sinDocente + " sin docente";
                }

                dgv.DataSource = actual;
                if (cmbVista.SelectedIndex == 0)
                {
                    Peso("Docente", 24); Peso("Materias", 28); Peso("Horas semanales", 12); Peso("Grupos", 9); Peso("% de carga", 12);
                    CentrarColumnas("Horas semanales", "Grupos", "% de carga");
                }
                else
                {
                    Peso("Grado", 22); Peso("Sección", 8); Peso("Docentes", 9); Peso("Horas semanales", 11); Peso("Docentes y materias", 50);
                    CentrarColumnas("Sección", "Docentes", "Horas semanales");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el reporte: " + ex.Message, "Error SQL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Peso(string columna, float peso)
        {
            if (dgv.Columns.Contains(columna)) dgv.Columns[columna].FillWeight = peso;
        }

        private void CentrarColumnas(params string[] columnas)
        {
            foreach (string c in columnas)
                if (dgv.Columns.Contains(c)) dgv.Columns[c].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        // Color según la carga: gris = sin grupos, ámbar = carga completa (40 h); rojo = grupo sin docente
        private void FormatoCeldas(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || actual == null) return;
            DataRowView fila = dgv.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (fila == null) return;
            DataTable tabla = fila.DataView.Table;
            string col = dgv.Columns[e.ColumnIndex].Name;

            if (tabla.Columns.Contains("Grupos"))               // vista por docente
            {
                int horas = Convert.ToInt32(fila["Horas semanales"]);
                if (horas == 0)
                    e.CellStyle.ForeColor = Color.FromArgb(110, 118, 140);
                else if (horas >= 40 && (col == "Horas semanales" || col == "% de carga"))
                {
                    e.CellStyle.ForeColor = Color.FromArgb(252, 211, 77);
                    e.CellStyle.Font = FuenteNegrita;
                }
            }
            else if (tabla.Columns.Contains("Docentes") && Convert.ToInt32(fila["Docentes"]) == 0)
            {
                e.CellStyle.BackColor = Color.FromArgb(72, 32, 42);      // grupo sin docente
                e.CellStyle.ForeColor = Color.FromArgb(252, 165, 165);
            }
        }

        private void Exportar(object sender, EventArgs e)
        {
            if (actual == null || actual.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ExportadorPdf.Exportar("Carga académica " + cmbVista.Text.ToLower() + " " + cmbAnio.Text, actual);
        }
    }
}