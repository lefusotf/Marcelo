using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelos;


namespace Vistass
{
    public partial class frmRegistrarPago : Form
    {
        private static readonly CultureInfo Inv = CultureInfo.InvariantCulture;

        private readonly int idPago;          // 0 = pago nuevo, > 0 = edición
        private bool cargando = true;         // evita reaccionar mientras se llenan los controles
        private bool aplicando = false;       // evita reaccionar a cambios que hace el propio código
        private DataTable dtEmpleados;

        // Ausencias del mes: días descontables y el monto que ya está sumado dentro del Descuento
        private int diasAus = 0;
        private int diasHabilesMes = 30;
        private decimal descAus = 0m;

        // período guardado ("yyyy-MM"); la lista lo usa para mostrar el mes donde quedó el pago
        public string ClavePeriodo { get; private set; }

        public frmRegistrarPago() : this(0) { }

        public frmRegistrarPago(int idPago)
        {
            InitializeComponent();
            BarrasOscuras.Aplicar(txtObservacion);      // barra de desplazamiento oscura
            this.idPago = idPago;
        }

        private void frmRegistrarPago_Load(object sender, EventArgs e)
        {
            bool edicion = idPago > 0;
            lblTituloForm.Text = edicion ? "Editar pago" : "Registrar pago";
            lblSubtituloForm.Text = edicion ? "Modifique los montos o el período del pago"
                                            : "Seleccione al empleado y confirme los montos del mes";
            this.Text = lblTituloForm.Text;
            btnGuardar.Text = edicion ? "Guardar cambios" : "Registrar pago";

            cmbEstadoPago.Items.AddRange(new object[] { "Pendiente", "Pagado" });
            cmbEstadoPago.SelectedIndex = 0;

            // el período es un mes (cualquier día del mes sirve: se guarda el día 1); no se admiten meses futuros
            dtpPeriodo.MinDate = new DateTime(2000, 1, 1);
            dtpPeriodo.MaxDate = DateTime.Today;
            dtpPeriodo.Value = DateTime.Today;

            int idEmpleadoPago = 0;
            DataRow pago = null;
            if (edicion)
            {
                DataTable dp = Datos.Tabla(
                    @"SELECT IdEmpleado, Periodo, SalarioBase, Bono, Descuento, EstadoPago, Observacion,
                             DiasAusencia, DescuentoAusencias
                      FROM PagosPlanilla WHERE IdPago = @id AND Anulado = 0", Datos.P("@id", idPago));
                if (dp.Rows.Count == 0)
                {
                    MessageBox.Show("El pago ya no existe o fue anulado.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.Cancel;
                    return;
                }
                pago = dp.Rows[0];
                idEmpleadoPago = Convert.ToInt32(pago["IdEmpleado"]);
            }

            // empleados activos (en edición también el del pago, aunque ya esté inactivo) con los montos de su estructura salarial
            dtEmpleados = Datos.Tabla(
                @"SELECT e.IdEmpleado, e.Nombre + N' · ' + c.NombreCargo AS Descripcion, e.IdPlanilla,
                         ISNULL(p.SalarioBase, 0) AS SalarioBase, ISNULL(p.Bono, 0) AS Bono,
                         ISNULL(p.Descuento, 0) AS Descuento
                  FROM Empleados e
                  INNER JOIN Cargos c ON c.IdCargo = e.IdCargo
                  LEFT JOIN Planillas p ON p.IdPlanilla = e.IdPlanilla
                  WHERE e.IdEstado <> 2 OR e.IdEmpleado = @emp
                  ORDER BY e.Nombre", Datos.P("@emp", idEmpleadoPago));

            cmbEmpleado.DataSource = dtEmpleados;
            cmbEmpleado.DisplayMember = "Descripcion";
            cmbEmpleado.ValueMember = "IdEmpleado";
            cmbEmpleado.SelectedIndex = -1;

            if (edicion)
            {
                cmbEmpleado.SelectedValue = idEmpleadoPago;
                cmbEmpleado.Enabled = false;               // el pago pertenece a este empleado
                dtpPeriodo.Value = (DateTime)pago["Periodo"];
                txtSalarioBase.Text = Convert.ToDecimal(pago["SalarioBase"]).ToString("0.00", Inv);
                txtBono.Text = Convert.ToDecimal(pago["Bono"]).ToString("0.00", Inv);
                txtDescuento.Text = Convert.ToDecimal(pago["Descuento"]).ToString("0.00", Inv);
                cmbEstadoPago.SelectedItem = Convert.ToString(pago["EstadoPago"]);
                txtObservacion.Text = pago["Observacion"] == DBNull.Value ? "" : Convert.ToString(pago["Observacion"]);
                lblOrigen.Text = "";

                // el desglose guardado en el pago (no se recalcula hasta que cambie el período)
                diasAus = Convert.ToInt32(pago["DiasAusencia"]);
                descAus = Convert.ToDecimal(pago["DescuentoAusencias"]);
            }
            else
            {
                lblOrigen.Text = "Al elegir al empleado, los montos se completan con su estructura salarial.";
            }

            cargando = false;
            ActualizarTextoAusencias();
            Recalcular();

            // Si cambia el mes, se vuelven a buscar las ausencias de ese mes.
            // Se conecta aquí para que no se dispare mientras se carga el formulario.
            dtpPeriodo.ValueChanged += dtpPeriodo_ValueChanged;
        }

        private void cmbEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargando || idPago > 0 || cmbEmpleado.SelectedIndex < 0) return;
            DataRowView fila = cmbEmpleado.SelectedItem as DataRowView;
            if (fila == null) return;

            // 'aplicando' evita que cada cambio de texto dispare cálculos intermedios
            aplicando = true;
            diasAus = 0; descAus = 0m;

            decimal b = Convert.ToDecimal(fila["SalarioBase"]);
            if (fila["IdPlanilla"] == DBNull.Value || b <= 0)
            {
                txtSalarioBase.Clear();
                txtBono.Text = "0.00";
                txtDescuento.Text = "0.00";
                lblOrigen.Text = "Este empleado no tiene estructura salarial asignada: ingrese los montos manualmente.";
            }
            else
            {
                txtSalarioBase.Text = b.ToString("0.00", Inv);
                txtBono.Text = Convert.ToDecimal(fila["Bono"]).ToString("0.00", Inv);
                txtDescuento.Text = Convert.ToDecimal(fila["Descuento"]).ToString("0.00", Inv);
                lblOrigen.Text = "Montos tomados de la estructura salarial N° " + Convert.ToInt32(fila["IdPlanilla"]) +
                                 ". Puede ajustarlos solo para este pago.";
            }
            aplicando = false;

            ConsultarAusencias();       // suma al descuento las ausencias de ese empleado en el mes
        }

        private void dtpPeriodo_ValueChanged(object sender, EventArgs e)
        {
            if (cargando || aplicando || cmbEmpleado.SelectedValue == null) return;
            ConsultarAusencias();
        }

        // ---------------------------------------------------------------
        //  Descuento automático por ausencias
        //  Regla: salario base / 30 por cada día hábil de falta injustificada o permiso sin goce.
        //  Los DÍAS los calcula la base de datos (fn_DiasDescontados); el monto se calcula aquí
        //  para poder recalcularlo al instante si se cambia el salario base.
        // ---------------------------------------------------------------
        private void ConsultarAusencias()
        {
            DateTime periodo = new DateTime(dtpPeriodo.Value.Year, dtpPeriodo.Value.Month, 1);
            try
            {
                diasAus = Convert.ToInt32(Datos.Escalar("SELECT dbo.fn_DiasDescontados(@e, @p)",
                    Datos.P("@e", Convert.ToInt32(cmbEmpleado.SelectedValue)), Datos.P("@p", periodo)));
                diasHabilesMes = Convert.ToInt32(Datos.Escalar("SELECT dbo.fn_DiasHabiles(@i, EOMONTH(@i))",
                     Datos.P("@i", periodo)));
                if (diasHabilesMes < 1) diasHabilesMes = 30;
            }
            catch
            {
                diasAus = 0;    // si el módulo de ausencias no está instalado, el pago sigue funcionando sin descuento extra
            }
            AplicarDescuentoAusencias();
        }

        // Suma (o actualiza) en el Descuento la parte que corresponde a ausencias,
        // sin pisar lo que el usuario haya escrito a mano.
        private void AplicarDescuentoAusencias()
        {
            decimal b;
            TryMonto(txtSalarioBase, true, out b);
            decimal nuevo = Math.Round(b / diasHabilesMes * diasAus, 2, MidpointRounding.AwayFromZero);

            decimal actual;
            TryMonto(txtDescuento, true, out actual);
            decimal sinAusencias = Math.Max(0m, actual - descAus);   // lo que ya había, sin la parte anterior de ausencias
            descAus = nuevo;

            aplicando = true;
            txtDescuento.Text = (sinAusencias + descAus).ToString("0.00", Inv);
            aplicando = false;

            ActualizarTextoAusencias();
            Recalcular();
        }

        private void ActualizarTextoAusencias()
        {
            if (diasAus > 0 || descAus > 0)
            {
                lblAusencias.ForeColor = Color.FromArgb(251, 191, 36);
                lblAusencias.Text = "Ausencias del mes: " + diasAus + (diasAus == 1 ? " día" : " días") +
                                    "  →  -$" + descAus.ToString("N2", Inv) + " (incluido en el descuento)";
            }
            else
            {
                lblAusencias.ForeColor = Color.FromArgb(140, 150, 170);
                lblAusencias.Text = cmbEmpleado.SelectedValue == null ? "" : "Sin ausencias descontables este mes.";
            }
        }

        private static bool TryMonto(TextBox t, bool vacioEsCero, out decimal valor)
        {
            if (string.IsNullOrWhiteSpace(t.Text)) { valor = 0m; return vacioEsCero; }
            return decimal.TryParse(t.Text.Trim(), NumberStyles.AllowDecimalPoint, Inv, out valor) && valor >= 0;
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.') e.Handled = true;
            if (e.KeyChar == '.' && txt.Text.IndexOf('.') > -1) e.Handled = true;
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            Recalcular();

            // Si el usuario cambia el salario base, el valor del día cambia: se recalcula la parte de ausencias
            if (!cargando && !aplicando && ReferenceEquals(sender, txtSalarioBase) && cmbEmpleado.SelectedValue != null)
                AplicarDescuentoAusencias();
        }

        private void Recalcular()
        {
            decimal b, bo, d;
            TryMonto(txtSalarioBase, true, out b);
            TryMonto(txtBono, true, out bo);
            TryMonto(txtDescuento, true, out d);

            decimal neto = b + bo - d;
            lblNeto.Text = "$ " + neto.ToString("N2", Inv);
            lblNeto.ForeColor = neto < 0 ? Color.FromArgb(220, 38, 38) : Color.FromArgb(250, 204, 21);
            lblDesglose.Text = "Base " + b.ToString("N2", Inv) + "  +  Bono " + bo.ToString("N2", Inv) +
                               "  -  Descuento " + d.ToString("N2", Inv);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            bool hayError = false;

            if (cmbEmpleado.SelectedIndex < 0 || cmbEmpleado.SelectedValue == null)
            { errorProvider.SetError(cmbEmpleado, "Seleccione un empleado."); hayError = true; }

            decimal b, bo, d;
            if (!TryMonto(txtSalarioBase, false, out b) || b <= 0)
            { errorProvider.SetError(txtSalarioBase, "Ingrese un salario base mayor que cero."); hayError = true; }
            if (!TryMonto(txtBono, true, out bo))
            { errorProvider.SetError(txtBono, "Ingrese un bono válido (0 si no aplica)."); hayError = true; }
            if (!TryMonto(txtDescuento, true, out d))
            { errorProvider.SetError(txtDescuento, "Ingrese un descuento válido (0 si no aplica)."); hayError = true; }

            if (!hayError && d > b + bo)
            { errorProvider.SetError(txtDescuento, "El descuento no puede superar el salario base más el bono."); hayError = true; }

            if (hayError)
            {
                MessageBox.Show("Revise los campos marcados.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime periodo = new DateTime(dtpPeriodo.Value.Year, dtpPeriodo.Value.Month, 1);

            try
            {
                // La parte de ausencias nunca puede ser mayor que el descuento total
                // (por si el usuario bajó el descuento a mano)
                decimal descAusenciasGuardado = Math.Min(descAus, d);

                Datos.Procedimiento("sp_RegistrarPago",
                    Datos.P("@IdPago", idPago > 0 ? (object)idPago : null),
                    Datos.P("@IdEmpleado", Convert.ToInt32(cmbEmpleado.SelectedValue)),
                    Datos.P("@Periodo", periodo),
                    Datos.P("@SalarioBase", b),
                    Datos.P("@Bono", bo),
                    Datos.P("@Descuento", d),
                    Datos.P("@EstadoPago", cmbEstadoPago.SelectedItem.ToString()),
                    Datos.PTexto("@Observacion", txtObservacion.Text),
                    Datos.P("@DiasAusencia", descAusenciasGuardado > 0 ? diasAus : 0),
                    Datos.P("@DescuentoAusencias", descAusenciasGuardado));

                ClavePeriodo = periodo.ToString("yyyy-MM", Inv);
                DialogResult = DialogResult.OK;
            }
            catch (SqlException ex)
            {
                MostrarErrorSql(ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el pago: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarErrorSql(SqlException ex)
        {
            string empleado = cmbEmpleado.Text.Split('·')[0].Trim();
            string mes = dtpPeriodo.Value.ToString("MMMM yyyy", new CultureInfo("es-ES"));

            switch (ex.Number)
            {
                case 50306:
                    errorProvider.SetError(dtpPeriodo, "Este empleado ya tiene un pago en este mes.");
                    MessageBox.Show(empleado + " ya tiene un pago registrado en " + mes + ".\n\n" +
                        "Elija otro período. Si necesita registrarlo de nuevo, anule primero el pago existente " +
                        "desde la lista de planillas.",
                        "Pago ya registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpPeriodo.Focus();
                    break;

                case 50303:
                    errorProvider.SetError(txtDescuento, "El descuento es mayor que el salario base más el bono.");
                    MessageBox.Show("El descuento no puede ser mayor que el salario base más el bono.\n\nRevise los montos.",
                        "Descuento demasiado alto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDescuento.Focus();
                    break;

                case 50305:
                    errorProvider.SetError(dtpPeriodo, "No se puede registrar un período futuro.");
                    MessageBox.Show("Solo se pueden registrar pagos del mes actual o de meses anteriores.",
                        "Período no válido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpPeriodo.Focus();
                    break;

                case 50308:
                    MessageBox.Show("Este pago ya fue pagado y no se puede modificar.\n\n" +
                        "Si hay un error, anúlelo desde la lista y regístrelo de nuevo.",
                        "Pago ya pagado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case 50300:
                    errorProvider.SetError(cmbEmpleado, "El empleado no está disponible.");
                    MessageBox.Show("El empleado seleccionado ya no está activo.",
                        "Empleado no disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case 50311:
                    MessageBox.Show("El descuento por ausencias no es válido: no puede ser mayor que el descuento total.\n\nRevise el descuento.",
                        "Descuento por ausencias", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDescuento.Focus();
                    break;

                default:
                    MessageBox.Show("No se pudo guardar el pago.\n\nDetalle: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}