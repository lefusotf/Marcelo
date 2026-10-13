using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Modelos
{
    // Genera un libro de Excel real (.xlsx). A diferencia del CSV, las fechas se guardan como
    // fechas de verdad (formato dd/mm/aaaa), los números como números y cada columna lleva su
    // ancho ya ajustado, por lo que nunca aparece "########".
    // Un .xlsx es un .zip con varios XML dentro; aquí se arma a mano (sin compresión) para no
    // depender de referencias adicionales.
    public static class ExportadorExcel
    {
        private const int EstiloNormal = 0, EstiloCabecera = 1, EstiloFecha = 2, EstiloFechaHora = 3, EstiloDecimal = 4;

        public static void Exportar(string titulo, DataTable dt, params string[] columnasOcultas)
        {
            var columnas = dt.Columns.Cast<DataColumn>()
                .Where(c => !columnasOcultas.Contains(c.ColumnName, StringComparer.OrdinalIgnoreCase))
                .ToList();

            using (var guardar = new SaveFileDialog())
            {
                guardar.Filter = "Libro de Excel (*.xlsx)|*.xlsx";
                guardar.FileName = "Reporte_" + titulo.Replace(" ", "_") + ".xlsx";
                if (guardar.ShowDialog() != DialogResult.OK) return;

                try
                {
                    byte[] libro = ConstruirLibro(titulo, dt, columnas);
                    File.WriteAllBytes(guardar.FileName, libro);

                    if (MessageBox.Show("Archivo guardado.\n\n¿Desea abrirlo ahora?", "Exportar a Excel",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        Process.Start(new ProcessStartInfo(guardar.FileName) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el archivo: " + ex.Message +
                                    "\n\n(Si está abierto en Excel, ciérrelo e intente de nuevo.)",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ---------------------------------------------------------------- contenido del libro

        private static byte[] ConstruirLibro(string titulo, DataTable dt, List<DataColumn> columnas)
        {
            var archivos = new List<KeyValuePair<string, string>>();
            archivos.Add(Par("[Content_Types].xml",
                "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
                "<Types xmlns=\"http://schemas.openxmlformats.org/package/2006/content-types\">" +
                "<Default Extension=\"rels\" ContentType=\"application/vnd.openxmlformats-package.relationships+xml\"/>" +
                "<Default Extension=\"xml\" ContentType=\"application/xml\"/>" +
                "<Override PartName=\"/xl/workbook.xml\" ContentType=\"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml\"/>" +
                "<Override PartName=\"/xl/worksheets/sheet1.xml\" ContentType=\"application/vnd.openxmlformats-officedocument.spreadsheetml.worksheet+xml\"/>" +
                "<Override PartName=\"/xl/styles.xml\" ContentType=\"application/vnd.openxmlformats-officedocument.spreadsheetml.styles+xml\"/>" +
                "</Types>"));
            archivos.Add(Par("_rels/.rels",
                "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
                "<Relationships xmlns=\"http://schemas.openxmlformats.org/package/2006/relationships\">" +
                "<Relationship Id=\"rId1\" Type=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument\" Target=\"xl/workbook.xml\"/>" +
                "</Relationships>"));
            archivos.Add(Par("xl/workbook.xml",
                "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
                "<workbook xmlns=\"http://schemas.openxmlformats.org/spreadsheetml/2006/main\" " +
                "xmlns:r=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships\">" +
                "<sheets><sheet name=\"" + Xml(NombreHoja(titulo)) + "\" sheetId=\"1\" r:id=\"rId1\"/></sheets></workbook>"));
            archivos.Add(Par("xl/_rels/workbook.xml.rels",
                "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
                "<Relationships xmlns=\"http://schemas.openxmlformats.org/package/2006/relationships\">" +
                "<Relationship Id=\"rId1\" Type=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships/worksheet\" Target=\"worksheets/sheet1.xml\"/>" +
                "<Relationship Id=\"rId2\" Type=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships/styles\" Target=\"styles.xml\"/>" +
                "</Relationships>"));
            archivos.Add(Par("xl/styles.xml", Estilos()));
            archivos.Add(Par("xl/worksheets/sheet1.xml", Hoja(dt, columnas)));
            return Zip(archivos);
        }

        private static string Estilos()
        {
            return "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
                "<styleSheet xmlns=\"http://schemas.openxmlformats.org/spreadsheetml/2006/main\">" +
                "<numFmts count=\"2\">" +
                "<numFmt numFmtId=\"164\" formatCode=\"dd/mm/yyyy\"/>" +
                "<numFmt numFmtId=\"165\" formatCode=\"dd/mm/yyyy\\ hh:mm\"/>" +
                "</numFmts>" +
                "<fonts count=\"2\">" +
                "<font><sz val=\"11\"/><name val=\"Calibri\"/></font>" +
                "<font><b/><sz val=\"11\"/><color rgb=\"FFFFFFFF\"/><name val=\"Calibri\"/></font>" +
                "</fonts>" +
                "<fills count=\"3\">" +
                "<fill><patternFill patternType=\"none\"/></fill>" +
                "<fill><patternFill patternType=\"gray125\"/></fill>" +
                "<fill><patternFill patternType=\"solid\"><fgColor rgb=\"FF222634\"/><bgColor indexed=\"64\"/></patternFill></fill>" +
                "</fills>" +
                "<borders count=\"1\"><border><left/><right/><top/><bottom/><diagonal/></border></borders>" +
                "<cellStyleXfs count=\"1\"><xf numFmtId=\"0\" fontId=\"0\" fillId=\"0\" borderId=\"0\"/></cellStyleXfs>" +
                "<cellXfs count=\"5\">" +
                "<xf numFmtId=\"0\" fontId=\"0\" fillId=\"0\" borderId=\"0\" xfId=\"0\"/>" +
                "<xf numFmtId=\"0\" fontId=\"1\" fillId=\"2\" borderId=\"0\" xfId=\"0\" applyFont=\"1\" applyFill=\"1\" applyAlignment=\"1\"><alignment vertical=\"center\"/></xf>" +
                "<xf numFmtId=\"164\" fontId=\"0\" fillId=\"0\" borderId=\"0\" xfId=\"0\" applyNumberFormat=\"1\" applyAlignment=\"1\"><alignment horizontal=\"center\"/></xf>" +
                "<xf numFmtId=\"165\" fontId=\"0\" fillId=\"0\" borderId=\"0\" xfId=\"0\" applyNumberFormat=\"1\" applyAlignment=\"1\"><alignment horizontal=\"center\"/></xf>" +
                "<xf numFmtId=\"4\" fontId=\"0\" fillId=\"0\" borderId=\"0\" xfId=\"0\" applyNumberFormat=\"1\"/>" +
                "</cellXfs>" +
                "<cellStyles count=\"1\"><cellStyle name=\"Normal\" xfId=\"0\" builtinId=\"0\"/></cellStyles>" +
                "</styleSheet>";
        }

        private static string Hoja(DataTable dt, List<DataColumn> columnas)
        {
            int n = columnas.Count;
            var anchos = new int[n];
            for (int i = 0; i < n; i++) anchos[i] = columnas[i].ColumnName.Length + 4;

            var filas = new StringBuilder();

            // cabecera
            filas.Append("<row r=\"1\" ht=\"22\" customHeight=\"1\">");
            for (int i = 0; i < n; i++)
                filas.Append(CeldaTexto(Referencia(i, 1), columnas[i].ColumnName, EstiloCabecera));
            filas.Append("</row>");

            // datos
            int r = 2;
            foreach (DataRow fila in dt.Rows)
            {
                filas.Append("<row r=\"").Append(r).Append("\">");
                for (int i = 0; i < n; i++)
                    filas.Append(Celda(Referencia(i, r), fila[columnas[i]], ref anchos[i]));
                filas.Append("</row>");
                r++;
            }

            var sb = new StringBuilder();
            sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>");
            sb.Append("<worksheet xmlns=\"http://schemas.openxmlformats.org/spreadsheetml/2006/main\">");
            sb.Append("<sheetViews><sheetView workbookViewId=\"0\">");
            sb.Append("<pane ySplit=\"1\" topLeftCell=\"A2\" activePane=\"bottomLeft\" state=\"frozen\"/>");
            sb.Append("</sheetView></sheetViews>");
            sb.Append("<sheetFormatPr defaultRowHeight=\"15\"/>");
            sb.Append("<cols>");
            for (int i = 0; i < n; i++)
                sb.Append("<col min=\"").Append(i + 1).Append("\" max=\"").Append(i + 1)
                  .Append("\" width=\"").Append(Math.Min(60, Math.Max(10, anchos[i])).ToString(CultureInfo.InvariantCulture))
                  .Append("\" customWidth=\"1\"/>");
            sb.Append("</cols>");
            sb.Append("<sheetData>").Append(filas).Append("</sheetData>");
            if (n > 0)
                sb.Append("<autoFilter ref=\"A1:").Append(Referencia(n - 1, Math.Max(1, r - 1))).Append("\"/>");
            sb.Append("<pageMargins left=\"0.5\" right=\"0.5\" top=\"0.75\" bottom=\"0.75\" header=\"0.3\" footer=\"0.3\"/>");
            sb.Append("<pageSetup orientation=\"landscape\"/>");
            sb.Append("</worksheet>");
            return sb.ToString();
        }

        // Cada valor se guarda con el tipo que le corresponde: fecha, número o texto.
        private static string Celda(string refer, object v, ref int ancho)
        {
            if (v == null || v == DBNull.Value) return "";

            if (v is DateTime)
            {
                DateTime d = (DateTime)v;
                if (d.Year < 1901) return CeldaTexto(refer, d.ToString("dd/MM/yyyy"), EstiloNormal);
                bool conHora = d.TimeOfDay != TimeSpan.Zero;
                ancho = Math.Max(ancho, conHora ? 20 : 14);
                return "<c r=\"" + refer + "\" s=\"" + (conHora ? EstiloFechaHora : EstiloFecha) + "\"><v>" +
                       d.ToOADate().ToString("R", CultureInfo.InvariantCulture) + "</v></c>";
            }

            if (v is bool)
            {
                ancho = Math.Max(ancho, 8);
                return CeldaTexto(refer, (bool)v ? "Sí" : "No", EstiloNormal);
            }

            if (v is byte || v is short || v is int || v is long || v is sbyte || v is ushort || v is uint || v is ulong)
            {
                string t = Convert.ToString(v, CultureInfo.InvariantCulture);
                ancho = Math.Max(ancho, t.Length + 3);
                return "<c r=\"" + refer + "\"><v>" + t + "</v></c>";
            }

            if (v is decimal || v is double || v is float)
            {
                double dd = Convert.ToDouble(v, CultureInfo.InvariantCulture);
                if (double.IsNaN(dd) || double.IsInfinity(dd)) return "";
                string t = v is decimal ? ((decimal)v).ToString(CultureInfo.InvariantCulture)
                                        : dd.ToString("R", CultureInfo.InvariantCulture);
                ancho = Math.Max(ancho, t.Length + 5);
                return "<c r=\"" + refer + "\" s=\"" + EstiloDecimal + "\"><v>" + t + "</v></c>";
            }

            string texto = Convert.ToString(v, CultureInfo.CurrentCulture) ?? "";
            if (texto.Length == 0) return "";
            int mayor = texto.Split('\n').Max(l => l.Length);       // línea más larga
            ancho = Math.Max(ancho, mayor + 3);
            return CeldaTexto(refer, texto, EstiloNormal);
        }

        private static string CeldaTexto(string refer, string texto, int estilo)
        {
            return "<c r=\"" + refer + "\" t=\"inlineStr\"" + (estilo != 0 ? " s=\"" + estilo + "\"" : "") +
                   "><is><t xml:space=\"preserve\">" + Xml(texto) + "</t></is></c>";
        }

        private static string Referencia(int columna, int fila)
        {
            string letras = "";
            for (int c = columna; c >= 0; c = c / 26 - 1) letras = (char)('A' + c % 26) + letras;
            return letras + fila;
        }

        private static string NombreHoja(string titulo)
        {
            string s = new string((titulo ?? "").Where(ch => "[]:*?/\\".IndexOf(ch) < 0).ToArray()).Trim();
            if (s.Length == 0) s = "Reporte";
            return s.Length > 31 ? s.Substring(0, 31) : s;
        }

        private static string Xml(string s)
        {
            var sb = new StringBuilder(s.Length + 8);
            foreach (char c in s)
            {
                if (c == '&') sb.Append("&amp;");
                else if (c == '<') sb.Append("&lt;");
                else if (c == '>') sb.Append("&gt;");
                else if (c == '"') sb.Append("&quot;");
                else if (c < 0x20 && c != '\t' && c != '\n' && c != '\r') continue;   // caracteres que XML no admite
                else sb.Append(c);
            }
            return sb.ToString();
        }

        private static KeyValuePair<string, string> Par(string nombre, string contenido)
        {
            return new KeyValuePair<string, string>(nombre, contenido);
        }

        // ---------------------------------------------------------------- ZIP mínimo (sin compresión)

        private static uint[] tablaCrc;

        private static uint Crc32(byte[] datos)
        {
            if (tablaCrc == null)
            {
                var t = new uint[256];
                for (uint i = 0; i < 256; i++)
                {
                    uint c = i;
                    for (int k = 0; k < 8; k++) c = (c & 1) != 0 ? 0xEDB88320u ^ (c >> 1) : c >> 1;
                    t[i] = c;
                }
                tablaCrc = t;
            }
            uint crc = 0xFFFFFFFFu;
            foreach (byte b in datos) crc = tablaCrc[(crc ^ b) & 0xFF] ^ (crc >> 8);
            return crc ^ 0xFFFFFFFFu;
        }

        private static byte[] Zip(List<KeyValuePair<string, string>> archivos)
        {
            DateTime ahora = DateTime.Now;
            ushort hora = (ushort)((ahora.Hour << 11) | (ahora.Minute << 5) | (ahora.Second / 2));
            ushort fecha = (ushort)(((ahora.Year - 1980) << 9) | (ahora.Month << 5) | ahora.Day);

            using (var ms = new MemoryStream())
            using (var w = new BinaryWriter(ms))
            {
                var centrales = new List<byte[]>();
                foreach (var a in archivos)
                {
                    byte[] nombre = Encoding.ASCII.GetBytes(a.Key);
                    byte[] datos = new UTF8Encoding(false).GetBytes(a.Value);
                    uint crc = Crc32(datos);
                    uint inicio = (uint)ms.Position;

                    w.Write(0x04034b50u);            // cabecera local
                    w.Write((ushort)20);             // versión necesaria
                    w.Write((ushort)0);              // banderas
                    w.Write((ushort)0);              // 0 = sin compresión
                    w.Write(hora); w.Write(fecha);
                    w.Write(crc);
                    w.Write((uint)datos.Length);
                    w.Write((uint)datos.Length);
                    w.Write((ushort)nombre.Length);
                    w.Write((ushort)0);
                    w.Write(nombre);
                    w.Write(datos);

                    using (var cm = new MemoryStream())
                    using (var c = new BinaryWriter(cm))
                    {
                        c.Write(0x02014b50u);        // entrada del directorio central
                        c.Write((ushort)20); c.Write((ushort)20);
                        c.Write((ushort)0); c.Write((ushort)0);
                        c.Write(hora); c.Write(fecha);
                        c.Write(crc);
                        c.Write((uint)datos.Length);
                        c.Write((uint)datos.Length);
                        c.Write((ushort)nombre.Length);
                        c.Write((ushort)0); c.Write((ushort)0);
                        c.Write((ushort)0); c.Write((ushort)0);
                        c.Write(0u);
                        c.Write(inicio);
                        c.Write(nombre);
                        c.Flush();
                        centrales.Add(cm.ToArray());
                    }
                }

                uint inicioCentral = (uint)ms.Position;
                foreach (var c in centrales) w.Write(c);
                uint tamCentral = (uint)ms.Position - inicioCentral;

                w.Write(0x06054b50u);                // fin del directorio central
                w.Write((ushort)0); w.Write((ushort)0);
                w.Write((ushort)archivos.Count); w.Write((ushort)archivos.Count);
                w.Write(tamCentral);
                w.Write(inicioCentral);
                w.Write((ushort)0);
                w.Flush();
                return ms.ToArray();
            }
        }
    }
}
