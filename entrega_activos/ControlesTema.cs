using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Vistass
{
    /// <summary>Paleta única del sistema. Para cambiar un color de todos los botones y tablas, se cambia aquí.</summary>
    public static class PaletaSistema
    {
        public static readonly Color Fondo = Color.FromArgb(26, 28, 36);
        public static readonly Color Tarjeta = Color.FromArgb(21, 23, 31);
        public static readonly Color Campo = Color.FromArgb(38, 42, 58);
        public static readonly Color Amarillo = Color.FromArgb(250, 204, 21);
        public static readonly Color Gris = Color.FromArgb(55, 60, 80);
        public static readonly Color Rojo = Color.FromArgb(220, 53, 69);
        public static readonly Color Texto = Color.FromArgb(226, 232, 244);
        public static readonly Color Tenue = Color.FromArgb(150, 160, 182);
    }

    public enum TipoBoton { Principal, Secundario, Peligro }

    /// <summary>
    /// Botón con el estilo del sistema. En el Designer solo se elige la propiedad "Tipo":
    /// Principal = amarillo, Secundario = gris, Peligro = rojo. Si está deshabilitado se ve apagado.
    /// </summary>
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
                letra = Color.FromArgb(100, 108, 130);
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

    /// <summary>Tabla con el estilo del sistema: encabezado oscuro, filas claras y selección azul.</summary>
    [DesignerCategory("Code")]
    public class GridOscuro : DataGridView
    {
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
            GridColor = Color.FromArgb(225, 228, 235);
            EnableHeadersVisualStyles = false;

            ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            ColumnHeadersHeight = 36;
            RowTemplate.Height = 30;

            ColumnHeadersDefaultCellStyle.BackColor = PaletaSistema.Tarjeta;
            ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            ColumnHeadersDefaultCellStyle.SelectionBackColor = PaletaSistema.Tarjeta;
            ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 0, 0, 0);

            DefaultCellStyle.BackColor = Color.White;
            DefaultCellStyle.ForeColor = Color.Black;
            DefaultCellStyle.Padding = new Padding(6, 0, 0, 0);
            DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 212);
            DefaultCellStyle.SelectionForeColor = Color.White;
            AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(244, 246, 250);
        }
    }
}
