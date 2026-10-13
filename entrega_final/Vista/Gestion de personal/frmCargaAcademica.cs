using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Modelos;

namespace Vistass
{
   
    public class frmCargaAcademica : Form
    {
        private readonly ComboOscuro cmbVista = new ComboOscuro();
        private readonly ComboOscuro cmbAnio = new ComboOscuro();
        private readonly GridOscuro dgv = new GridOscuro();
        private readonly Label lblInfo = new Label();
        private DataTable actual;       // lo que se exporta
        private DataTable pantalla;     // lo que se ve (en la vista por grado lleva una fila de encabezado por grupo)

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
                Text = "Exportar",
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
                    // Una fila por materia y docente de cada grupo; las secciones sin docente aparecen igual
                    actual = Datos.Tabla(
                        @"SELECT g.NombreGrado AS Grado, s.NombreSeccion AS [Sección],
                                 ISNULL(m.NombreMateria, '') AS Materia,
                                 CASE WHEN a.IdEmpleado IS NULL THEN 'Sin docente asignado' ELSE e.Nombre END AS Docente,
                                 ISNULL(a.HorasSemanales, 0) AS Horas,
                                 s.IdSeccion AS IdSeccion, ISNULL(a.IdEmpleado, 0) AS IdEmpleado
                          FROM Secciones s
                          JOIN Grados g ON g.IdGrado = s.IdGrado
                          LEFT JOIN AsignacionesDocente a ON a.IdSeccion = s.IdSeccion AND a.AnioLectivo = @a
                          LEFT JOIN Empleados e ON e.IdEmpleado = a.IdEmpleado
                          LEFT JOIN Materias m ON m.IdMateria = a.IdMateria
                          ORDER BY g.Orden, s.NombreSeccion, m.NombreMateria, e.Nombre", Datos.P("@a", anio));

                    pantalla = ArmarVistaPorGrupo(actual);
                    int grupos = 0, sinDocente = 0;
                    foreach (DataRow r in pantalla.Rows)
                    {
                        string tipo = Convert.ToString(r["Tipo"]);
                        if (tipo == "G" || tipo == "V") grupos++;
                        if (tipo == "V") sinDocente++;
                    }
                    lblInfo.Text = grupos + " grupos · " + sinDocente + " sin docente";
                }

                if (cmbVista.SelectedIndex == 0) pantalla = actual;

                // sin filas alternadas en la vista por grupo: los encabezados de grupo ya separan visualmente
                dgv.AlternatingRowsDefaultCellStyle.BackColor = cmbVista.SelectedIndex == 0
                    ? Color.FromArgb(31, 34, 45) : dgv.DefaultCellStyle.BackColor;

                dgv.DataSource = pantalla;
                if (cmbVista.SelectedIndex == 0)
                {
                    Peso("Docente", 24); Peso("Materias", 28); Peso("Horas semanales", 12); Peso("Grupos", 9); Peso("% de carga", 12);
                    CentrarColumnas("Horas semanales", "Grupos", "% de carga");
                }
                else
                {
                    dgv.Columns["Tipo"].Visible = false;
                    Peso("Grupo", 26); Peso("Materia", 26); Peso("Docente", 36); Peso("Horas", 12);
                    CentrarColumnas("Horas");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el reporte: " + ex.Message, "Error SQL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Convierte la lista plana en: encabezado de grupo ("Primer grado · Sección A", n docentes, total de horas)
        // seguido de una fila por cada materia con su docente y horas.
        private static DataTable ArmarVistaPorGrupo(DataTable plano)
        {
            DataTable t = new DataTable();
            t.Columns.Add("Grupo", typeof(string));
            t.Columns.Add("Materia", typeof(string));
            t.Columns.Add("Docente", typeof(string));
            t.Columns.Add("Horas", typeof(int));
            t.Columns.Add("Tipo", typeof(string));          // G = encabezado, D = detalle, V = grupo sin docente

            int i = 0;
            while (i < plano.Rows.Count)
            {
                int idSeccion = Convert.ToInt32(plano.Rows[i]["IdSeccion"]);
                int fin = i;
                while (fin < plano.Rows.Count && Convert.ToInt32(plano.Rows[fin]["IdSeccion"]) == idSeccion) fin++;

                System.Collections.Generic.HashSet<int> docentes = new System.Collections.Generic.HashSet<int>();
                int horas = 0;
                for (int k = i; k < fin; k++)
                {
                    int idEmp = Convert.ToInt32(plano.Rows[k]["IdEmpleado"]);
                    if (idEmp > 0) docentes.Add(idEmp);
                    horas += Convert.ToInt32(plano.Rows[k]["Horas"]);
                }

                DataRow primera = plano.Rows[i];
                string grupo = Convert.ToString(primera["Grado"]) + "  ·  Sección " + Convert.ToString(primera["Sección"]);
                if (docentes.Count == 0)
                    t.Rows.Add(grupo, "Sin docentes asignados", "", 0, "V");
                else
                {
                    t.Rows.Add(grupo, docentes.Count + (docentes.Count == 1 ? " docente" : " docentes"), "", horas, "G");
                    for (int k = i; k < fin; k++)
                    {
                        DataRow r = plano.Rows[k];
                        t.Rows.Add("", Convert.ToString(r["Materia"]), Convert.ToString(r["Docente"]), Convert.ToInt32(r["Horas"]), "D");
                    }
                }
                i = fin;
            }
            return t;
        }

        private void Peso(string columna, float peso)
        {
            if (dgv.Columns.Contains(columna)) dgv.Columns[columna].FillWeight = peso;
        }

        private void CentrarColumnas(params string[] columnas)
        {
            foreach (string c in columnas)
                if (dgv.Columns.Contains(c))
                {
                    dgv.Columns[c].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv.Columns[c].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;   // título centrado igual que los datos
                }
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
            else if (tabla.Columns.Contains("Tipo"))                // vista por grado y sección
            {
                string tipo = Convert.ToString(fila["Tipo"]);
                if (tipo == "G" || tipo == "V")
                {
                    e.CellStyle.Font = FuenteNegrita;
                    e.CellStyle.BackColor = tipo == "V" ? Color.FromArgb(72, 32, 42) : Color.FromArgb(40, 45, 66);
                    e.CellStyle.ForeColor = tipo == "V" ? Color.FromArgb(252, 165, 165)
                                          : col == "Grupo" ? PaletaSistema.Amarillo : PaletaSistema.Texto;
                }
                else if (col == "Materia")
                    e.CellStyle.Padding = new Padding(28, 0, 8, 0);   // las materias van sangradas bajo su grupo
            }
        }

        private void Exportar(object sender, EventArgs e)
        {
            if (actual == null || actual.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ExportadorPdf.Exportar("Carga académica " + cmbVista.Text.ToLower() + " " + cmbAnio.Text, actual,
                                   "IdSeccion", "IdEmpleado");
        }
    }
}