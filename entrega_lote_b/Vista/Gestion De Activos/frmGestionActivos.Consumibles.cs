using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Modelos;

namespace Vistass
{
    public partial class frmGestionActivos
    {
        // Unidades de medida permitidas (no se escribe a mano: así no hay "Resmas", "resma", "RESMA"...)
        private static readonly string[] UnidadesMedida =
            { "Unidad", "Caja", "Paquete", "Resma", "Litro", "Galón", "Kilogramo", "Metro", "Par", "Rollo" };

        private int idConsEditando;      // 0 = se está creando uno nuevo; otro valor = se está editando ese

        private void InicializarConsumibles()
        {
            bool previo = cargando; cargando = true;
            cmbMovTipo.Items.AddRange(new object[] { "Entrada", "Salida" });
            cmbMovTipo.SelectedIndex = 0;
            cmbConsUnidad.Items.AddRange(UnidadesMedida);
            cmbConsUnidad.SelectedIndex = 0;
            CargarSalonesDestino();
            CargarMotivos();
            btnConsCrear.Enabled = EsAdministrador();
            btnConsEditar.Enabled = EsAdministrador();

            NumericoLimitado.Aplicar(numMovCant, errorProvider,
                () => "Solo hay " + numMovCant.Maximum.ToString("0") + " en existencia.");
            cmbMovMotivo.SelectedIndexChanged += (s, e) => AjustarDestino();
            cmbMovCons.SelectedIndexChanged += (s, e) => { if (!cargando) ActualizarDisponible(); };
            dgvStock.CellDoubleClick += (s, e) => { if (e.RowIndex >= 0 && EsAdministrador()) IniciarEdicionConsumible(); };
            cargando = previo;

            CargarConsumibles();
            AjustarDestino();
            ActualizarDisponible();
        }

        private void CargarSalonesDestino()
        {
            cmbMovDestino.Items.Clear();
            cmbMovDestino.Items.Add(new ElementoLista(0, "Seleccione el salón…"));
            foreach (DataRow r in Datos.Tabla(
                @"SELECT IdSalon, NombreSalon FROM Salones
                  WHERE Activo = 1 AND ISNULL(Tipo, '') <> 'Bodega'
                  ORDER BY NombreSalon").Rows)
                cmbMovDestino.Items.Add(new ElementoLista(Convert.ToInt32(r["IdSalon"]), Convert.ToString(r["NombreSalon"])));
            cmbMovDestino.SelectedIndex = 0;
        }

        private void CargarMotivos()
        {
            cmbMovMotivo.Items.Clear();
            if (cmbMovTipo.Text == "Entrada")
                cmbMovMotivo.Items.AddRange(new object[] { "Compra", "Donación", "Ajuste de inventario" });
            else
                cmbMovMotivo.Items.AddRange(new object[] { "Despacho a aula", "Despacho a departamento", "Merma o baja" });
            cmbMovMotivo.SelectedIndex = 0;
        }

        private void cmbMovTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMotivos();
            AjustarDestino();
            if (!cargando) ActualizarDisponible();
        }

        // El campo de destino cambia según lo que se está haciendo:
        //   Despacho a aula        -> lista de salones (queda enlazado al salón)
        //   Despacho a departamento / Merma -> texto obligatorio
        //   Compra / Donación / Ajuste      -> proveedor, donante o detalle obligatorio
        private void AjustarDestino()
        {
            if (cmbMovMotivo == null || cmbMovDestino == null) return;
            string tipo = cmbMovTipo.Text, motivo = cmbMovMotivo.Text;
            bool esSalon = tipo == "Salida" && motivo == "Despacho a aula";

            cmbMovDestino.Visible = esSalon;
            txtMovDestino.Visible = !esSalon;

            if (tipo == "Entrada")
                lblMovDestino.Text = motivo == "Compra" ? "Proveedor o N.º de factura"
                                   : motivo == "Donación" ? "Donante"
                                   : "Detalle del ajuste";
            else
                lblMovDestino.Text = motivo == "Despacho a aula" ? "Salón de destino"
                                   : motivo == "Despacho a departamento" ? "Departamento u oficina de destino"
                                   : "¿Qué ocurrió? (vencido, dañado, perdido…)";

            errorProvider.SetError(txtMovDestino, "");
            errorProvider.SetError(cmbMovDestino, "");
        }

        // En una salida no se puede sacar más de lo que hay: el tope de la cantidad es el stock actual.
        private void ActualizarDisponible()
        {
            try
            {
                if (cmbMovCons.SelectedValue == null) { numMovCant.Maximum = 100000; lblMovCant.Text = "Cantidad"; return; }

                object o = Datos.Escalar("SELECT StockActual FROM Consumibles WHERE IdConsumible = @id",
                                         Datos.P("@id", Convert.ToInt32(cmbMovCons.SelectedValue)));
                int stock = (o == null || o == DBNull.Value) ? 0 : Convert.ToInt32(o);

                if (cmbMovTipo.Text == "Salida")
                {
                    numMovCant.Maximum = Math.Max(1, stock);
                    lblMovCant.Text = "Cantidad (hay " + stock + ")";
                }
                else
                {
                    numMovCant.Maximum = 100000;
                    lblMovCant.Text = "Cantidad";
                }
            }
            catch { }
        }

        private void CargarConsumibles()
        {
            try
            {
                object previo = cmbMovCons.SelectedValue;
                DataTable dt = Datos.Tabla(
                    @"SELECT IdConsumible, Nombre, Unidad, StockActual, StockMinimo, Alerta
                      FROM vw_StockConsumibles
                      ORDER BY CASE Alerta WHEN 'Agotado' THEN 0 WHEN 'Stock bajo' THEN 1 ELSE 2 END, Nombre");

                bool bandera = cargando; cargando = true;
                dgvStock.DataSource = dt;
                dgvStock.ClearSelection();
                LlenarCombo(cmbMovCons, dt.DefaultView.ToTable(false, "IdConsumible", "Nombre"), "IdConsumible", "Nombre", null);
                if (previo != null) cmbMovCons.SelectedValue = previo;
                cargando = bandera;

                dgvStock.Columns["IdConsumible"].Visible = false;
                Encabezado(dgvStock, "Nombre", "Consumible", 40);
                Encabezado(dgvStock, "Unidad", "Unidad", 14);
                Encabezado(dgvStock, "StockActual", "Stock actual", 16);
                Encabezado(dgvStock, "StockMinimo", "Stock mínimo", 16);
                Encabezado(dgvStock, "Alerta", "Estado del stock", 14);

                CargarKardex();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los consumibles: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int ConsumibleSeleccionado()
        {
            if (dgvStock.SelectedRows.Count == 0) return 0;
            DataRowView f = dgvStock.SelectedRows[0].DataBoundItem as DataRowView;
            return f == null ? 0 : Convert.ToInt32(f["IdConsumible"]);
        }

        private void CargarKardex()
        {
            int id = ConsumibleSeleccionado();
            DataTable dt = Datos.Tabla(
                @"SELECT TOP 300 Fecha, Consumible, Tipo, Cantidad, Motivo, Destino, SaldoResultante, Usuario
                  FROM vw_KardexConsumibles
                  WHERE (@id = 0 OR IdConsumible = @id)
                  ORDER BY IdMovimiento DESC", Datos.P("@id", id));
            dgvKardex.DataSource = dt;

            Encabezado(dgvKardex, "Fecha", "Fecha", 15);
            Encabezado(dgvKardex, "Consumible", "Consumible", 20);
            Encabezado(dgvKardex, "Tipo", "Tipo", 9);
            Encabezado(dgvKardex, "Cantidad", "Cant.", 8);
            Encabezado(dgvKardex, "Motivo", "Motivo", 15);
            Encabezado(dgvKardex, "Destino", "Destino o referencia", 17);
            Encabezado(dgvKardex, "SaldoResultante", "Saldo", 8);
            Encabezado(dgvKardex, "Usuario", "Usuario", 10);
            if (dgvKardex.Columns.Contains("Fecha"))
                dgvKardex.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yy HH:mm";

            lblKardexTitulo.Text = id == 0 ? "Kardex: últimos movimientos de todos los consumibles"
                                           : "Kardex del consumible seleccionado";
        }

        private void dgvStock_SelectionChanged(object sender, EventArgs e)
        {
            if (cargando) return;
            try { CargarKardex(); } catch { }
        }

        private void btnKardexTodos_Click(object sender, EventArgs e)
        {
            dgvStock.ClearSelection();
            CargarKardex();
        }

        // Agotado = rojo, Stock bajo = ámbar (mismos tonos oscuros que las alertas de Préstamos)
        private void dgvStock_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || !dgvStock.Columns.Contains("Alerta")) return;
            string alerta = Convert.ToString(dgvStock.Rows[e.RowIndex].Cells["Alerta"].Value);
            if (alerta == "Agotado")
            { e.CellStyle.BackColor = Color.FromArgb(72, 32, 42); e.CellStyle.ForeColor = Color.FromArgb(252, 165, 165); }
            else if (alerta == "Stock bajo")
            { e.CellStyle.BackColor = Color.FromArgb(66, 50, 18); e.CellStyle.ForeColor = Color.FromArgb(252, 211, 77); }
        }

        // Rellena el formulario con el consumible seleccionado para poder corregirlo
        private void IniciarEdicionConsumible()
        {
            int id = ConsumibleSeleccionado();
            if (id == 0)
            {
                MessageBox.Show("Seleccione primero un consumible en la tabla de existencias.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable dt = Datos.Tabla(
                @"SELECT c.Nombre, c.Unidad, c.StockMinimo,
                         (SELECT COUNT(*) FROM MovimientosConsumible m WHERE m.IdConsumible = c.IdConsumible) AS Movimientos
                  FROM Consumibles c WHERE c.IdConsumible = @id", Datos.P("@id", id));
            if (dt.Rows.Count == 0) return;
            DataRow r = dt.Rows[0];

            errorProvider.Clear();
            idConsEditando = id;
            txtConsNombre.Text = Convert.ToString(r["Nombre"]);

            string unidad = Convert.ToString(r["Unidad"]);
            if (!cmbConsUnidad.Items.Contains(unidad)) cmbConsUnidad.Items.Add(unidad);   // valor antiguo escrito a mano
            cmbConsUnidad.SelectedItem = unidad;
            // con movimientos registrados la unidad ya no se cambia: las cantidades del kardex perderían sentido
            cmbConsUnidad.Enabled = Convert.ToInt32(r["Movimientos"]) == 0;
            toolTip1.SetToolTip(cmbConsUnidad, cmbConsUnidad.Enabled ? "" : "No se puede cambiar: el consumible ya tiene movimientos.");

            numConsMin.Value = Math.Min(numConsMin.Maximum, Convert.ToDecimal(r["StockMinimo"]));
            lblConsNuevo.Text = "Editar consumible";
            btnConsCrear.Text = "Guardar cambios";
            btnConsEditar.Text = "Cancelar";
            txtConsNombre.Focus();
        }

        private void TerminarEdicionConsumible()
        {
            idConsEditando = 0;
            errorProvider.Clear();
            txtConsNombre.Clear();
            numConsMin.Value = 0;
            cmbConsUnidad.Enabled = true;
            toolTip1.SetToolTip(cmbConsUnidad, "");
            cmbConsUnidad.SelectedIndex = 0;
            lblConsNuevo.Text = "Nuevo consumible";
            btnConsCrear.Text = "Crear consumible";
            btnConsEditar.Text = "Editar";
        }

        private void btnConsEditar_Click(object sender, EventArgs e)
        {
            if (idConsEditando != 0) TerminarEdicionConsumible();     // era "Cancelar"
            else IniciarEdicionConsumible();
        }

        private void btnConsCrear_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            string nombre = txtConsNombre.Text.Trim();
            if (nombre.Length < 3)
            {
                errorProvider.SetError(txtConsNombre, "El nombre del consumible es obligatorio (mínimo 3 caracteres).");
                return;
            }
            if (cmbConsUnidad.SelectedItem == null)
            {
                errorProvider.SetError(cmbConsUnidad, "Seleccione la unidad de medida.");
                return;
            }
            string unidad = Convert.ToString(cmbConsUnidad.SelectedItem);

            try
            {
                if (idConsEditando == 0)
                {
                    Datos.Ejecutar("INSERT INTO Consumibles (Nombre, Unidad, StockMinimo) VALUES (@n, @u, @m)",
                        Datos.P("@n", nombre), Datos.P("@u", unidad), Datos.P("@m", (int)numConsMin.Value));

                    MessageBox.Show("Consumible creado con stock 0. Registre una entrada para cargar existencias.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Datos.Ejecutar("UPDATE Consumibles SET Nombre = @n, Unidad = @u, StockMinimo = @m WHERE IdConsumible = @id",
                        Datos.P("@n", nombre), Datos.P("@u", unidad), Datos.P("@m", (int)numConsMin.Value),
                        Datos.P("@id", idConsEditando));

                    MessageBox.Show("Consumible actualizado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                TerminarEdicionConsumible();
                CargarConsumibles();
                ActualizarDisponible();
                ActualizarIndicadores();
            }
            catch (System.Data.SqlClient.SqlException ex) when (ex.Number == 2601 || ex.Number == 2627)
            {
                errorProvider.SetError(txtConsNombre, "Ya existe un consumible con ese nombre.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el consumible: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMovimiento_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            bool error = false;
            bool esSalon = cmbMovTipo.Text == "Salida" && cmbMovMotivo.Text == "Despacho a aula";

            if (cmbMovCons.SelectedValue == null) { errorProvider.SetError(cmbMovCons, "Seleccione el consumible."); error = true; }

            int? idSalon = null;
            string destino;
            if (esSalon)
            {
                idSalon = IdSeleccionado(cmbMovDestino);
                if (idSalon == null || idSalon.Value == 0)
                { errorProvider.SetError(cmbMovDestino, "Seleccione el salón de destino."); error = true; }
                destino = cmbMovDestino.Text;
            }
            else
            {
                destino = txtMovDestino.Text.Trim();
                if (destino.Length < 3)
                { errorProvider.SetError(txtMovDestino, "Este dato es obligatorio (mínimo 3 caracteres)."); error = true; }
            }
            if (error) return;

            int id = Convert.ToInt32(cmbMovCons.SelectedValue);
            try
            {
                Datos.Procedimiento("sp_RegistrarMovimientoConsumible",
                    Datos.P("@IdConsumible", id),
                    Datos.P("@Tipo", cmbMovTipo.Text),
                    Datos.P("@Cantidad", (int)numMovCant.Value),
                    Datos.P("@Motivo", cmbMovMotivo.Text),
                    Datos.PTexto("@Destino", destino),
                    Datos.P("@Usuario", UsuarioActual()),
                    Datos.P("@IdSalon", idSalon.HasValue ? (object)idSalon.Value : null));

                txtMovDestino.Text = "";
                cmbMovDestino.SelectedIndex = 0;
                numMovCant.Value = 1;
                CargarConsumibles();
                ActualizarDisponible();
                ActualizarIndicadores();

                DataTable alerta = Datos.Tabla("SELECT Nombre, StockActual, Alerta FROM vw_StockConsumibles WHERE IdConsumible = @id",
                    Datos.P("@id", id));
                if (alerta.Rows.Count > 0 && Convert.ToString(alerta.Rows[0]["Alerta"]) != "Normal")
                    MessageBox.Show("Alerta de stock: '" + alerta.Rows[0]["Nombre"] + "' quedó en " +
                        alerta.Rows[0]["StockActual"] + " (" + alerta.Rows[0]["Alerta"] + "). Conviene reponerlo.",
                        "Stock mínimo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("Movimiento registrado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo registrar el movimiento: " + ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
