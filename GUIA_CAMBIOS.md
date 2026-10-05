# Guía de cambios: estado individual por unidad de activo

**Idea central.** Antes, el estado (Bueno, Malo…) vivía en `GestionActivos`, que es el *tipo* de activo ("Pupitre"), así que se aplicaba a todos los pupitres por igual. Ahora cada pupitre/equipo físico es una fila de la tabla nueva **`UnidadesActivo`** con su propio estado, código de inventario y salón. `GestionActivos` queda solo como catálogo.

---

## A. Base de datos

**Son los mismos cambios del script que ya te pasé** (`02_estado_individual_por_unidad.sql`); no hay cambios nuevos en la base. Si ya lo corriste bien, no hace falta volver a correrlo.

Qué hace, en resumen:

| Qué | Para qué |
|---|---|
| Tabla `UnidadesActivo` | Una fila por unidad física: `IdUnidad`, `IdActivo`, `IdSalon`, `CodigoInventario` (único), `IdEstado`. |
| Migración de datos | Convierte cada `SalonClases.Cantidad = N` en N unidades y copia los equipos de `EquiposIndividualesSalon` conservando código y estado. Estado inicial = el que tenía el tipo. Códigos nuevos tipo `ACT-0001-001`. |
| `AuditoriaUnidades` + trigger | Registra cada cambio de estado/salón por unidad. |
| Columna `IdUnidad` en `Prestamos`, `MantenimientosActivo`, `ReportesDanio` | Enlaza el historial con la unidad concreta (se rellena donde había código). |
| Vistas nuevas/rehechas | `vw_UnidadesDetalle`, `vw_ResumenEstadoPorSalon`, `vw_AuditoriaUnidadesDetalle`; rehechas `vw_ActivosDetalle` (ahora con `TotalUnidades` y `UnidadesConProblema`, sin `Estado`), `vw_ActivosPorSalon`, `vw_ResumenActivosPorEstado/Categoria`, `vw_ReportesDanio`, `vw_Prestamos`, `vw_Mantenimientos`. |
| Procedimientos | Nuevos `sp_CambiarEstadoUnidad`, `sp_AgregarUnidades`. Ahora reciben `@IdUnidad`: `sp_RegistrarPrestamo`, `sp_RegistrarMantenimiento`. `sp_RegistrarDevolucion` cambia solo el estado de esa unidad. `sp_ReiniciarSistema` limpia también las unidades. |

**Cómo correrlo:** respaldo → ventana de consulta **nueva** en SSMS → pegar solo ese archivo → ejecutar → revisar que `UnidadesEsperadas` = `UnidadesMigradas`.

---

## B. Diseño (Designer)

Todo lo visual está en **`frmGestionActivos.Designer.cs`** (los controles ya no se crean por código). Puedes reemplazar el archivo completo (está en `cs/forms/`) o aplicar estos cuatro cambios a mano en tu Designer:

**1. Campos**, al final de la clase (junto a `private Label lblKpi5Txt;`):

```csharp
        // Cambio de estado de una unidad (ficha > Ubicación)
        private Panel pnlEstadoUnidad; private Label lblEstadoUnidad;
        private ComboBox cmbEstadoUnidad; private Button btnCambiarEstadoUnidad;
```

**2. En `InitializeComponent()`**, justo debajo de `this.dgvUbicacion = new System.Windows.Forms.DataGridView();`:

```csharp
            this.pnlEstadoUnidad = new System.Windows.Forms.Panel();
            this.lblEstadoUnidad = new System.Windows.Forms.Label();
            this.cmbEstadoUnidad = new System.Windows.Forms.ComboBox();
            this.btnCambiarEstadoUnidad = new System.Windows.Forms.Button();
```

y debajo de `this.tabUbicacion.SuspendLayout();`:

```csharp
            this.pnlEstadoUnidad.SuspendLayout();
```

**3. Agregar el panel a la pestaña y configurarlo.** En la sección de `tabUbicacion`, debajo de `this.tabUbicacion.Controls.Add(this.dgvUbicacion);`:

```csharp
            this.tabUbicacion.Controls.Add(this.pnlEstadoUnidad);
```

y debajo de la configuración de `dgvUbicacion` (después de `this.dgvUbicacion.TabIndex = 0;`):

```csharp
            // 
            // pnlEstadoUnidad  (cambio de estado de UNA unidad)
            // 
            this.pnlEstadoUnidad.Controls.Add(this.lblEstadoUnidad);
            this.pnlEstadoUnidad.Controls.Add(this.cmbEstadoUnidad);
            this.pnlEstadoUnidad.Controls.Add(this.btnCambiarEstadoUnidad);
            this.pnlEstadoUnidad.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlEstadoUnidad.Location = new System.Drawing.Point(0, 85);
            this.pnlEstadoUnidad.Name = "pnlEstadoUnidad";
            this.pnlEstadoUnidad.Size = new System.Drawing.Size(1196, 34);
            this.pnlEstadoUnidad.TabIndex = 1;
            // 
            // lblEstadoUnidad
            // 
            this.lblEstadoUnidad.AutoSize = true;
            this.lblEstadoUnidad.ForeColor = System.Drawing.Color.White;
            this.lblEstadoUnidad.Location = new System.Drawing.Point(8, 9);
            this.lblEstadoUnidad.Name = "lblEstadoUnidad";
            this.lblEstadoUnidad.Size = new System.Drawing.Size(235, 23);
            this.lblEstadoUnidad.TabIndex = 0;
            this.lblEstadoUnidad.Text = "Estado de la unidad seleccionada:";
            // 
            // cmbEstadoUnidad
            // 
            this.cmbEstadoUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoUnidad.FormattingEnabled = true;
            this.cmbEstadoUnidad.Location = new System.Drawing.Point(280, 4);
            this.cmbEstadoUnidad.Name = "cmbEstadoUnidad";
            this.cmbEstadoUnidad.Size = new System.Drawing.Size(220, 31);
            this.cmbEstadoUnidad.TabIndex = 1;
            // 
            // btnCambiarEstadoUnidad
            // 
            this.btnCambiarEstadoUnidad.Location = new System.Drawing.Point(515, 3);
            this.btnCambiarEstadoUnidad.Name = "btnCambiarEstadoUnidad";
            this.btnCambiarEstadoUnidad.Size = new System.Drawing.Size(150, 28);
            this.btnCambiarEstadoUnidad.TabIndex = 2;
            this.btnCambiarEstadoUnidad.Text = "Cambiar estado";
            this.btnCambiarEstadoUnidad.Click += new System.EventHandler(this.btnCambiarEstadoUnidad_Click);
```

Y antes de `this.tabUbicacion.ResumeLayout(false);` (al final de `InitializeComponent`):

```csharp
            this.pnlEstadoUnidad.ResumeLayout(false);
            this.pnlEstadoUnidad.PerformLayout();
```

El panel queda **debajo** de la tabla (`Dock = Bottom`) y la tabla sigue ocupando el resto (`Dock = Fill`). El orden de los `Controls.Add` importa: primero la tabla y después el panel.

**4. Ocultar el estado del formulario de alta/edición** (el estado ya no es del tipo de activo). Debajo de `this.lblEstado.Text = "Estado físico";` agrega `this.lblEstado.Visible = false;` y debajo de `this.cmbEstado.TabIndex = 3;` agrega `this.cmbEstado.Visible = false;`.

Tras ocultarlos queda un hueco en el formulario de la izquierda; si quieres, sube `lblUbicacion`/`cmbUbicacion` y los botones unos 60 px desde el diseñador visual. No afecta el funcionamiento.

Eso es **todo** el diseño: no hay cambios en ningún otro Designer.

---

## C. Lógica en los formularios y clases

Cada sección muestra el cambio exacto (formato diff). En los archivos con mucho cambio es más cómodo reemplazar el archivo completo: están todos en la carpeta `cs/` de la rama y en `cambios_csharp.zip`.

### 1. `Datos.cs` — método nuevo `IdUnidad`

Ayuda para convertir *(tipo de activo + código de inventario)* en el `IdUnidad` que ahora piden los procedimientos de préstamo y mantenimiento.

**Archivo `Datos.cs`** (líneas con `-` se quitan, líneas con `+` se agregan):

```diff
@@ -18,6 +18,19 @@
         }
 
 
+        // Cada unidad física tiene su código de inventario: (tipo de activo + código) -> IdUnidad
+        public static int IdUnidad(int idActivo, string codigoInventario)
+        {
+            if (string.IsNullOrWhiteSpace(codigoInventario))
+                throw new InvalidOperationException("Indique el código de inventario de la unidad.");
+            object r = Escalar("SELECT IdUnidad FROM UnidadesActivo WHERE IdActivo = @a AND CodigoInventario = @c",
+                               P("@a", idActivo), P("@c", codigoInventario.Trim()));
+            if (r == null || r == DBNull.Value)
+                throw new InvalidOperationException("No existe una unidad con el código '" + codigoInventario.Trim() +
+                                                    "' para el activo seleccionado.");
+            return Convert.ToInt32(r);
+        }
+
         public static SqlParameter PTexto(string nombre, string valor)
         {
             return new SqlParameter(nombre, string.IsNullOrWhiteSpace(valor) ? (object)DBNull.Value : valor.Trim());
```


### 2. `Salon.cs` — salones con unidades individuales

`AsignarActivo` ahora crea N unidades (llama a `sp_AgregarUnidades`), `QuitarActivo` borra unidades, y las consultas leen de `vw_UnidadesDetalle` (una fila por unidad con su estado). Se agrega `ObtenerIdEstadoInicial()` (estado con el que nacen las unidades: 'Bueno').

**Archivo `Salon.cs`** (líneas con `-` se quitan, líneas con `+` se agregan):

```diff
@@ -47,9 +47,10 @@
             DataTable dt = new DataTable();
             using (SqlConnection con = Conexion.Conectar())
             using (SqlDataAdapter da = new SqlDataAdapter(
-                @"SELECT IdActivo, NombreActivo, Categoria, Cantidad, CodigoInventario
-          FROM vw_ActivosPorSalon
-          WHERE IdSalon = @IdSalon", con))
+                @"SELECT IdActivo, Activo AS NombreActivo, Categoria, 1 AS Cantidad, CodigoInventario, Estado
+          FROM vw_UnidadesDetalle
+          WHERE IdSalon = @IdSalon
+          ORDER BY Activo, CodigoInventario", con))
             {
                 da.SelectCommand.Parameters.AddWithValue("@IdSalon", idSalon);
                 da.Fill(dt);
@@ -57,104 +58,70 @@
             return dt;
         }
 
+        // Estado con el que nacen las unidades nuevas (cada una cambia después por separado)
+        public int ObtenerIdEstadoInicial()
+        {
+            using (SqlConnection con = Conexion.Conectar())
+            using (SqlCommand cmd = new SqlCommand(
+                "SELECT TOP 1 IdEstado FROM Estados WHERE NombreEstado IN ('Bueno', 'Nuevo') ORDER BY CASE NombreEstado WHEN 'Bueno' THEN 0 ELSE 1 END", con))
+            {
+                con.Open();
+                object r = cmd.ExecuteScalar();
+                return r == null ? 1 : Convert.ToInt32(r);
+            }
+        }
+
+        // Crea N unidades individuales (cada una con su código y su propio estado)
         public bool AsignarActivo(int idSalon, int idActivo, int cantidad)
         {
-            
+            int idEstado = ObtenerIdEstadoInicial();
             using (SqlConnection conexion = Conexion.Conectar())
+            using (SqlCommand cmd = new SqlCommand("dbo.sp_AgregarUnidades", conexion))
             {
+                cmd.CommandType = CommandType.StoredProcedure;
+                cmd.Parameters.AddWithValue("@IdActivo", idActivo);
+                cmd.Parameters.AddWithValue("@IdSalon", idSalon);
+                cmd.Parameters.AddWithValue("@Cantidad", cantidad);
+                cmd.Parameters.AddWithValue("@IdEstado", idEstado);
                 conexion.Open();
-
-                string queryVerificar = "SELECT COUNT(*) FROM SalonClases WHERE IdSalon = @IdSalon AND IdActivo = @IdActivo";
-                SqlCommand cmdVerificar = new SqlCommand(queryVerificar, conexion);
-                cmdVerificar.Parameters.AddWithValue("@IdSalon", idSalon);
-                cmdVerificar.Parameters.AddWithValue("@IdActivo", idActivo);
-
-                int existe = Convert.ToInt32(cmdVerificar.ExecuteScalar());
-
-                SqlCommand cmdAccion;
-
-                if (existe > 0)
-                {
-                    string queryUpdate = "UPDATE SalonClases SET Cantidad = Cantidad + @Cantidad WHERE IdSalon = @IdSalon AND IdActivo = @IdActivo";
-                    cmdAccion = new SqlCommand(queryUpdate, conexion);
-                }
-                else
-                {
-                    string queryInsert = "INSERT INTO SalonClases (IdSalon, IdActivo, Cantidad) VALUES (@IdSalon, @IdActivo, @Cantidad)";
-                    cmdAccion = new SqlCommand(queryInsert, conexion);
-                }
-
-                cmdAccion.Parameters.AddWithValue("@IdSalon", idSalon);
-                cmdAccion.Parameters.AddWithValue("@IdActivo", idActivo);
-                cmdAccion.Parameters.AddWithValue("@Cantidad", cantidad);
-
-                int filasAfectadas = cmdAccion.ExecuteNonQuery();
-                return filasAfectadas > 0;
+                cmd.ExecuteNonQuery();
+                return true;
             }
         }
 
+        // Retira N unidades del salón (solo las que no tienen historial de préstamos/mantenimiento/reportes)
         public bool QuitarActivo(int idSalon, int idActivo, int cantidadAQuitar, out string mensajeError)
         {
             mensajeError = string.Empty;
-
             using (SqlConnection conexion = Conexion.Conectar())
+            using (SqlCommand cmd = new SqlCommand(
+                @"DELETE TOP (@n) FROM UnidadesActivo
+                  WHERE IdSalon = @IdSalon AND IdActivo = @IdActivo
+                    AND NOT EXISTS (SELECT 1 FROM Prestamos p WHERE p.IdUnidad = UnidadesActivo.IdUnidad)
+                    AND NOT EXISTS (SELECT 1 FROM MantenimientosActivo m WHERE m.IdUnidad = UnidadesActivo.IdUnidad)
+                    AND NOT EXISTS (SELECT 1 FROM ReportesDanio r WHERE r.IdUnidad = UnidadesActivo.IdUnidad)", conexion))
             {
+                cmd.Parameters.AddWithValue("@n", cantidadAQuitar);
+                cmd.Parameters.AddWithValue("@IdSalon", idSalon);
+                cmd.Parameters.AddWithValue("@IdActivo", idActivo);
                 conexion.Open();
-
-                
-                string queryVerificar = "SELECT Cantidad FROM SalonClases WHERE IdSalon = @IdSalon AND IdActivo = @IdActivo";
-                SqlCommand cmdVerificar = new SqlCommand(queryVerificar, conexion);
-                cmdVerificar.Parameters.AddWithValue("@IdSalon", idSalon);
-                cmdVerificar.Parameters.AddWithValue("@IdActivo", idActivo);
-
-                object resultado = cmdVerificar.ExecuteScalar();
-                if (resultado == null)
-                {
-                    mensajeError = "El activo seleccionado no se encuentra registrado en este salón.";
-                    return false;
-                }
-
-                int cantidadActual = Convert.ToInt32(resultado);
-
-               
-                if (cantidadAQuitar > cantidadActual)
-                {
-                    mensajeError = $"No puedes quitar {cantidadAQuitar} unidades porque en el salón solo hay {cantidadActual} disponibles.";
-                    return false;
-                }
-
-                SqlCommand cmdAccion;
-
-               
-                if (cantidadAQuitar == cantidadActual)
-                {
-                    string queryDelete = "DELETE FROM SalonClases WHERE IdSalon = @IdSalon AND IdActivo = @IdActivo";
-                    cmdAccion = new SqlCommand(queryDelete, conexion);
-                }
-                else
-                {
-                    
-                    string queryUpdate = "UPDATE SalonClases SET Cantidad = Cantidad - @Cantidad WHERE IdSalon = @IdSalon AND IdActivo = @IdActivo";
-                    cmdAccion = new SqlCommand(queryUpdate, conexion);
-                    cmdAccion.Parameters.AddWithValue("@Cantidad", cantidadAQuitar);
-                }
-
-                cmdAccion.Parameters.AddWithValue("@IdSalon", idSalon);
-                cmdAccion.Parameters.AddWithValue("@IdActivo", idActivo);
-
-                int filasAfectadas = cmdAccion.ExecuteNonQuery();
-                return filasAfectadas > 0;
+                int borradas = cmd.ExecuteNonQuery();
+                if (borradas < cantidadAQuitar)
+                    mensajeError = "Solo se pudieron retirar " + borradas + " unidades; las demás tienen historial. Cámbieles el estado a 'Dado de baja'.";
+                return borradas > 0;
             }
         }
+
         public DataTable BuscarActivosEnSalon(int idSalon, string criterio)
         {
             DataTable dt = new DataTable();
             using (SqlConnection con = Conexion.Conectar())
             using (SqlDataAdapter da = new SqlDataAdapter(
-                @"SELECT IdActivo, NombreActivo, Categoria, Cantidad, CodigoInventario
-          FROM vw_ActivosPorSalon
+                @"SELECT IdActivo, Activo AS NombreActivo, Categoria, 1 AS Cantidad, CodigoInventario, Estado
+          FROM vw_UnidadesDetalle
           WHERE IdSalon = @IdSalon
-            AND LOWER(LTRIM(RTRIM(NombreActivo))) LIKE @Criterio", con))
+            AND LOWER(LTRIM(RTRIM(Activo))) LIKE @Criterio
+          ORDER BY Activo, CodigoInventario", con))
             {
                 da.SelectCommand.Parameters.AddWithValue("@IdSalon", idSalon);
                 da.SelectCommand.Parameters.AddWithValue("@Criterio", "%" + criterio.Trim().ToLower() + "%");
@@ -168,7 +135,7 @@
             using (SqlConnection con = Conexion.Conectar())
             {
                 con.Open();
-                string query = @"UPDATE SalonClases 
+                string query = @"UPDATE UnidadesActivo 
                          SET IdActivo = @idActivoNuevo 
                          WHERE IdSalon = @idSalon AND IdActivo = @idActivoAnterior";
 
```


### 3. `frmSalones.cs` — asignar y quitar

Las unidades individuales se insertan/borran en `UnidadesActivo`. Si una unidad tiene historial (préstamos, mantenimientos, reportes) no se puede borrar y se avisa que debe pasarse a 'Dado de baja'. Se quitó la rama de 'quitar por cantidad' porque ya no existe.

**Archivo `frmSalones.cs`** (líneas con `-` se quitan, líneas con `+` se agregan):

```diff
@@ -168,7 +168,7 @@
                 {
                     codigoGenerado = $"{prefijoActivo}-S{idSalon}-{correlativo:D3}";
 
-                    string queryVerificar = "SELECT COUNT(*) FROM EquiposIndividualesSalon WHERE CodigoInventario = @Codigo";
+                    string queryVerificar = "SELECT COUNT(*) FROM UnidadesActivo WHERE CodigoInventario = @Codigo";
                     using (SqlCommand cmd = new SqlCommand(queryVerificar, conexion))
                     {
                         cmd.Parameters.AddWithValue("@Codigo", codigoGenerado);
@@ -274,8 +274,8 @@
                         errorProvider1.SetError(txtCodigoInventario, string.Empty);
                     }
 
-                    int estadoPorDefecto = 1;
-                    string queryInsert = "INSERT INTO EquiposIndividualesSalon (IdSalon, IdActivo, CodigoInventario, IdEstado) VALUES (@IdSalon, @IdActivo, @Codigo, @IdEstado)";
+                    int estadoPorDefecto = objSalon.ObtenerIdEstadoInicial();
+                    string queryInsert = "INSERT INTO UnidadesActivo (IdSalon, IdActivo, CodigoInventario, IdEstado) VALUES (@IdSalon, @IdActivo, @Codigo, @IdEstado)";
 
                     using (SqlConnection conexion = Conexion.Conectar())
                     {
@@ -355,16 +355,25 @@
 
                     if (!string.IsNullOrEmpty(codigoInventario))
                     {
-                        string queryDeleteIndividual = "DELETE FROM EquiposIndividualesSalon WHERE IdSalon = @IdSalon AND IdActivo = @IdActivo AND CodigoInventario = @Codigo";
+                        string queryDeleteIndividual = "DELETE FROM UnidadesActivo WHERE IdSalon = @IdSalon AND IdActivo = @IdActivo AND CodigoInventario = @Codigo";
                         using (SqlCommand cmd = new SqlCommand(queryDeleteIndividual, conexion))
                         {
                             cmd.Parameters.AddWithValue("@IdSalon", idSalon);
                             cmd.Parameters.AddWithValue("@IdActivo", idActivo);
                             cmd.Parameters.AddWithValue("@Codigo", codigoInventario);
 
-                            if (cmd.ExecuteNonQuery() > 0)
+                            int borradas;
+                            try { borradas = cmd.ExecuteNonQuery(); }
+                            catch (SqlException ex) when (ex.Number == 547)
                             {
-                                MessageBox.Show($"El equipo con código '{codigoInventario}' fue retirado del salón correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
+                                MessageBox.Show("Esa unidad tiene préstamos, mantenimientos o reportes de daño registrados y no se puede eliminar.\n\n" +
+                                                "Para retirarla del uso cambie su estado a 'Dado de baja' (Gestión de activos > ficha > Ubicación).",
+                                                "Operación cancelada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
+                                return;
+                            }
+                            if (borradas > 0)
+                            {
+                                MessageBox.Show($"La unidad con código '{codigoInventario}' fue retirada del salón correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                             }
                             else
                             {
@@ -374,56 +383,9 @@
                     }
                     else
                     {
-                        int cantidadAQuitar = Convert.ToInt32(numCantidadQuitar.Value);
-
-                        if (cantidadAQuitar <= 0)
-                        {
-                            MessageBox.Show("Por favor, ingresa una cantidad válida mayor a 0 para retirar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
-                            return;
-                        }
-
-                        int cantidadActualEnBD = 0;
-                        string queryConsultar = "SELECT Cantidad FROM SalonClases WHERE IdSalon = @IdSalon AND IdActivo = @IdActivo";
-                        using (SqlCommand cmdConsulta = new SqlCommand(queryConsultar, conexion))
-                        {
-                            cmdConsulta.Parameters.AddWithValue("@IdSalon", idSalon);
-                            cmdConsulta.Parameters.AddWithValue("@IdActivo", idActivo);
-                            object resultado = cmdConsulta.ExecuteScalar();
-                            if (resultado != null)
-                            {
-                                cantidadActualEnBD = Convert.ToInt32(resultado);
-                            }
-                        }
-
-                        if (cantidadAQuitar > cantidadActualEnBD)
-                        {
-                            MessageBox.Show($"No puedes retirar {cantidadAQuitar} unidades porque en este salón solo hay registradas {cantidadActualEnBD}.", "Restricción de inventario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
-                            return;
-                        }
-
-                        string queryAccion = "";
-                        if (cantidadAQuitar == cantidadActualEnBD)
-                        {
-                            queryAccion = "DELETE FROM SalonClases WHERE IdSalon = @IdSalon AND IdActivo = @IdActivo";
-                        }
-                        else
-                        {
-                            queryAccion = "UPDATE SalonClases SET Cantidad = Cantidad - @CantidadQuitar WHERE IdSalon = @IdSalon AND IdActivo = @IdActivo";
-                        }
-
-                        using (SqlCommand cmdAccion = new SqlCommand(queryAccion, conexion))
-                        {
-                            cmdAccion.Parameters.Clear();
-                            cmdAccion.Parameters.AddWithValue("@IdSalon", idSalon);
-                            cmdAccion.Parameters.AddWithValue("@IdActivo", idActivo);
-                            if (cantidadAQuitar < cantidadActualEnBD)
-                            {
-                                cmdAccion.Parameters.AddWithValue("@CantidadQuitar", cantidadAQuitar);
-                            }
-
-                            cmdAccion.ExecuteNonQuery();
-                            MessageBox.Show("Se han retirado los activos del salón correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
-                        }
+                        MessageBox.Show("Seleccione en la tabla la unidad (código de inventario) que desea retirar del salón.",
+                                        "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
+                        return;
                     }
                 }
 
```


### 4. `frmGestionActivos.cs` — catálogo y ficha (el cambio más grande)

Quita el estado del tipo de activo, muestra totales de unidades, la ficha lista cada unidad con su estado, y se agrega la lógica del botón *Cambiar estado* (`btnCambiarEstadoUnidad_Click`), cuyos controles ahora están en el Designer.

**Archivo `frmGestionActivos.cs`** (líneas con `-` se quitan, líneas con `+` se agregan):

```diff
@@ -44,6 +44,7 @@
         {
             ConfigurarTooltips();
             CargarCatalogos();
+            btnCambiarEstadoUnidad.Enabled = EsAdministrador();   // solo el administrador cambia estados
             CargarActivos();
             LimpiarFormulario();
             InicializarPrestamos();
@@ -179,6 +180,7 @@
                 LlenarCombo(cmbFiltroEstado, est, "IdEstado", "NombreEstado", "Todos los estados");
                 LlenarCombo(cmbDevEstado, est, "IdEstado", "NombreEstado", null);
                 LlenarCombo(cmbMantEstado, est, "IdEstado", "NombreEstado", null);
+                LlenarComboEstadoUnidad();
 
                 DataTable sal = Datos.Tabla("SELECT IdSalon, NombreSalon FROM Salones ORDER BY NombreSalon");
                 LlenarCombo(cmbUbicacion, sal, "IdSalon", "NombreSalon", "(Sin ubicación)");
@@ -217,8 +219,8 @@
             try
             {
                 dtActivos = Datos.Tabla(
-                    @"SELECT IdActivo, CodigoInventario, Nombre, Categoria, Estado, Ubicacion,
-                             IdCategoria, IdEstado, IdUbicacion
+                    @"SELECT IdActivo, CodigoInventario, Nombre, Categoria, TotalUnidades, UnidadesConProblema,
+                             Ubicacion, IdCategoria, IdUbicacion
                       FROM vw_ActivosDetalle ORDER BY IdActivo");
 
                 ActualizarIndicadores();
@@ -240,13 +242,13 @@
         {
             if (dgvActivos.Columns.Count == 0) return;
             dgvActivos.Columns["IdCategoria"].Visible = false;
-            dgvActivos.Columns["IdEstado"].Visible = false;
             dgvActivos.Columns["IdUbicacion"].Visible = false;
             Encabezado(dgvActivos, "IdActivo", "N°", 6);
             Encabezado(dgvActivos, "CodigoInventario", "Código", 14);
             Encabezado(dgvActivos, "Nombre", "Nombre del activo", 28);
             Encabezado(dgvActivos, "Categoria", "Categoría", 18);
-            Encabezado(dgvActivos, "Estado", "Estado físico", 16);
+            Encabezado(dgvActivos, "TotalUnidades", "Unidades", 9);
+            Encabezado(dgvActivos, "UnidadesConProblema", "Con problema", 10);
             Encabezado(dgvActivos, "Ubicacion", "Ubicación", 18);
         }
 
@@ -283,7 +285,13 @@
             int idEst;
             if (cmbFiltroEstado.SelectedValue != null &&
                 int.TryParse(cmbFiltroEstado.SelectedValue.ToString(), out idEst) && idEst > 0)
-                condiciones.Add("IdEstado = " + idEst);
+            {
+                // el estado es de cada unidad: se buscan los tipos que tengan al menos una unidad en ese estado
+                DataTable ids = Datos.Tabla("SELECT DISTINCT IdActivo FROM UnidadesActivo WHERE IdEstado = @e", Datos.P("@e", idEst));
+                condiciones.Add(ids.Rows.Count == 0
+                    ? "1 = 0"
+                    : "IdActivo IN (" + string.Join(",", ids.AsEnumerable().Select(x => Convert.ToString(x["IdActivo"]))) + ")");
+            }
 
             vista.RowFilter = string.Join(" AND ", condiciones);
             int n = vista.Count;
@@ -373,7 +381,6 @@
             txtCodigo.Text = Convert.ToString(fila["CodigoInventario"]);
 
             if (fila["IdCategoria"] != DBNull.Value) cmbCategoria.SelectedValue = Convert.ToInt32(fila["IdCategoria"]);
-            if (fila["IdEstado"] != DBNull.Value) cmbEstado.SelectedValue = Convert.ToInt32(fila["IdEstado"]);
             cmbUbicacion.SelectedValue = fila["IdUbicacion"] == DBNull.Value ? 0 : Convert.ToInt32(fila["IdUbicacion"]);
 
             lblModo.Text = "Editando activo N° " + idSeleccionado;
@@ -415,28 +422,42 @@
             try
             {
                 DataTable ubic = Datos.Tabla(
-                    @"SELECT NombreSalon AS Salon, CodigoInventario, Cantidad
-                      FROM vw_ActivosPorSalon WHERE IdActivo = @id ORDER BY NombreSalon", Datos.P("@id", idActivo));
+                    @"SELECT IdUnidad, IdEstado, Ubicacion AS Salon, CodigoInventario, Estado
+                      FROM vw_UnidadesDetalle WHERE IdActivo = @id ORDER BY Ubicacion, CodigoInventario", Datos.P("@id", idActivo));
+                // cambios del catálogo (nombre) + cambios de estado/salón de cada unidad
                 DataTable hist = Datos.Tabla(
-                    @"SELECT Fecha, Accion, NombreAnterior, NombreNuevo, EstadoAnterior, EstadoNuevo, Usuario
-                      FROM vw_AuditoriaActivosDetalle WHERE IdActivo = @id ORDER BY IdAuditoria DESC", Datos.P("@id", idActivo));
+                    @"SELECT Fecha, Accion, Codigo, Antes, Despues, Usuario FROM (
+                        SELECT Fecha, Accion, CAST(NULL AS VARCHAR(50)) AS Codigo,
+                               CAST(NombreAnterior AS NVARCHAR(200)) AS Antes, CAST(NombreNuevo AS NVARCHAR(200)) AS Despues, Usuario
+                        FROM vw_AuditoriaActivosDetalle
+                        WHERE IdActivo = @id AND (Accion <> 'UPDATE' OR ISNULL(NombreAnterior,'') <> ISNULL(NombreNuevo,''))
+                        UNION ALL
+                        SELECT Fecha, Accion, CodigoInventario,
+                               CAST(ISNULL(EstadoAnterior,'') + ISNULL(' · ' + SalonAnterior,'') AS NVARCHAR(200)),
+                               CAST(ISNULL(EstadoNuevo,'')    + ISNULL(' · ' + SalonNuevo,'')    AS NVARCHAR(200)), Usuario
+                        FROM vw_AuditoriaUnidadesDetalle
+                        WHERE IdActivo = @id
+                      ) h ORDER BY Fecha DESC", Datos.P("@id", idActivo));
                 DataTable danos = Datos.Tabla(
                     @"SELECT FechaReporte, Estado, Prioridad, Salon, CodigoInventario, Cantidad,
                              Descripcion, ReportadoPor, FechaReparacion, ObservacionReparacion
                       FROM vw_ReportesDanio WHERE IdActivo = @id ORDER BY FechaReporte DESC", Datos.P("@id", idActivo));
 
                 dgvUbicacion.DataSource = ubic; dgvHistorial.DataSource = hist; dgvDanos.DataSource = danos;
+                dgvUbicacion.Columns["IdUnidad"].Visible = false;
+                dgvUbicacion.Columns["IdEstado"].Visible = false;
+                dgvUbicacion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
+                dgvUbicacion.MultiSelect = false;
 
-                Encabezado(dgvUbicacion, "Salon", "Salón", 50);
+                Encabezado(dgvUbicacion, "Salon", "Salón", 40);
                 Encabezado(dgvUbicacion, "CodigoInventario", "Código de inventario", 30);
-                Encabezado(dgvUbicacion, "Cantidad", "Unidades", 20);
+                Encabezado(dgvUbicacion, "Estado", "Estado de la unidad", 30);
 
                 Encabezado(dgvHistorial, "Fecha", "Fecha", 16);
                 Encabezado(dgvHistorial, "Accion", "Acción", 10);
-                Encabezado(dgvHistorial, "NombreAnterior", "Nombre anterior", 20);
-                Encabezado(dgvHistorial, "NombreNuevo", "Nombre nuevo", 20);
-                Encabezado(dgvHistorial, "EstadoAnterior", "Estado anterior", 12);
-                Encabezado(dgvHistorial, "EstadoNuevo", "Estado nuevo", 12);
+                Encabezado(dgvHistorial, "Codigo", "Unidad", 14);
+                Encabezado(dgvHistorial, "Antes", "Antes", 26);
+                Encabezado(dgvHistorial, "Despues", "Después", 26);
                 Encabezado(dgvHistorial, "Usuario", "Usuario", 14);
 
                 Encabezado(dgvDanos, "FechaReporte", "Reportado", 12);
@@ -450,8 +471,7 @@
                 Encabezado(dgvDanos, "FechaReparacion", "Reparado", 12);
                 Encabezado(dgvDanos, "ObservacionReparacion", "Observación", 18);
 
-                object suma = ubic.Compute("SUM(Cantidad)", "");
-                int unidades = suma == DBNull.Value ? 0 : Convert.ToInt32(suma);
+                int unidades = ubic.Rows.Count;
                 int salones = ubic.AsEnumerable().Select(r => Convert.ToString(r["Salon"])).Distinct().Count();
                 int abiertos = danos.Select("Estado = 'Abierto'").Length;
 
@@ -497,7 +517,6 @@
             { errorProvider.SetError(txtCodigo, "Ese código de inventario ya está en uso."); ok = false; }
 
             if (cmbCategoria.SelectedValue == null) { errorProvider.SetError(cmbCategoria, "Seleccione una categoría."); ok = false; }
-            if (cmbEstado.SelectedValue == null) { errorProvider.SetError(cmbEstado, "Seleccione un estado."); ok = false; }
             return ok;
         }
 
@@ -517,12 +536,11 @@
                     @"SET XACT_ABORT ON; BEGIN TRAN;
                       DECLARE @nuevoId INT = (SELECT ISNULL(MAX(IdActivo), 0) + 1
                                               FROM GestionActivos WITH (UPDLOCK, HOLDLOCK));
-                      INSERT INTO GestionActivos (IdActivo, Nombre, IdEstado, IdCategoria, CodigoInventario, IdUbicacion)
-                      VALUES (@nuevoId, @nombre, @estado, @categoria,
+                      INSERT INTO GestionActivos (IdActivo, Nombre, IdCategoria, CodigoInventario, IdUbicacion)
+                      VALUES (@nuevoId, @nombre, @categoria,
                               ISNULL(@codigo, 'ACT-' + RIGHT('0000' + CAST(@nuevoId AS VARCHAR(10)), 4)), @ubic);
                       COMMIT;",
                     Datos.P("@nombre", txtNombre.Text.Trim()),
-                    Datos.P("@estado", Convert.ToInt32(cmbEstado.SelectedValue)),
                     Datos.P("@categoria", Convert.ToInt32(cmbCategoria.SelectedValue)),
                     Datos.PTexto("@codigo", txtCodigo.Text),
                     Datos.P("@ubic", UbicacionSeleccionada()));
@@ -553,11 +571,10 @@
             {
                 Datos.Ejecutar(
                     @"UPDATE GestionActivos
-                      SET Nombre = @nombre, IdEstado = @estado, IdCategoria = @categoria,
+                      SET Nombre = @nombre, IdCategoria = @categoria,
                           CodigoInventario = @codigo, IdUbicacion = @ubic
                       WHERE IdActivo = @id",
                     Datos.P("@nombre", nombre),
-                    Datos.P("@estado", Convert.ToInt32(cmbEstado.SelectedValue)),
                     Datos.P("@categoria", Convert.ToInt32(cmbCategoria.SelectedValue)),
                     Datos.PTexto("@codigo", txtCodigo.Text),
                     Datos.P("@ubic", UbicacionSeleccionada()),
@@ -585,8 +602,7 @@
             try
             {
                 int usos = Convert.ToInt32(Datos.Escalar(
-                    @"SELECT (SELECT COUNT(*) FROM SalonClases WHERE IdActivo = @id) +
-                             (SELECT COUNT(*) FROM EquiposIndividualesSalon WHERE IdActivo = @id) +
+                    @"SELECT (SELECT COUNT(*) FROM UnidadesActivo WHERE IdActivo = @id) +
                              (SELECT COUNT(*) FROM Prestamos WHERE IdActivo = @id) +
                              (SELECT COUNT(*) FROM MantenimientosActivo WHERE IdActivo = @id)",
                     Datos.P("@id", idSeleccionado)));
@@ -594,8 +610,8 @@
                 if (usos > 0)
                 {
                     MessageBox.Show(
-                        "No se puede eliminar este activo porque está asignado a un salón o tiene préstamos o mantenimientos registrados.\n\n" +
-                        "Para retirarlo del uso, cambie su estado a 'Dado de baja'.",
+                        "No se puede eliminar este activo porque tiene unidades asignadas o préstamos o mantenimientos registrados.\n\n" +
+                        "Para retirar una unidad del uso, cambie su estado a 'Dado de baja' en la ficha (pestaña Ubicación).",
                         "Operación cancelada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     return;
                 }
@@ -613,6 +629,47 @@
             }
         }
 
+        // ---------------------------------------------------------------
+        //  ESTADO INDIVIDUAL: panel bajo la lista de unidades de la ficha
+        // ---------------------------------------------------------------
+        private void LlenarComboEstadoUnidad()
+        {
+            if (cmbEstadoUnidad == null || cmbEstadoUnidad.Items.Count > 0) return;
+            DataTable est = Datos.Tabla("SELECT IdEstado, NombreEstado FROM Estados ORDER BY IdEstado");
+            cmbEstadoUnidad.DataSource = est;
+            cmbEstadoUnidad.ValueMember = "IdEstado";
+            cmbEstadoUnidad.DisplayMember = "NombreEstado";
+        }
+
+        // Cambia el estado de UNA sola unidad; las demás del mismo tipo no se tocan
+        private void btnCambiarEstadoUnidad_Click(object sender, EventArgs e)
+        {
+            if (idSeleccionado == 0 || dgvUbicacion.CurrentRow == null || !dgvUbicacion.Columns.Contains("IdUnidad"))
+            {
+                MessageBox.Show("Seleccione un activo y luego una unidad de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
+                return;
+            }
+            if (cmbEstadoUnidad.SelectedValue == null) return;
+
+            int idUnidad = Convert.ToInt32(dgvUbicacion.CurrentRow.Cells["IdUnidad"].Value);
+            string codigo = Convert.ToString(dgvUbicacion.CurrentRow.Cells["CodigoInventario"].Value);
+            try
+            {
+                Datos.Procedimiento("sp_CambiarEstadoUnidad",
+                    Datos.P("@IdUnidad", idUnidad),
+                    Datos.P("@IdEstado", Convert.ToInt32(cmbEstadoUnidad.SelectedValue)));
+                string nombre = txtNombre.Text.Trim();
+                CargarActivos();
+                CargarFicha(idSeleccionado, nombre);
+                MessageBox.Show("La unidad " + codigo + " ahora está en estado '" + cmbEstadoUnidad.Text + "'.",
+                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
+            }
+            catch (Exception ex)
+            {
+                MessageBox.Show("No se pudo cambiar el estado: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
+            }
+        }
+
         private void btnExportarPdf_Click(object sender, EventArgs e)
         {
             try
@@ -622,11 +679,12 @@
                     MessageBox.Show("No hay datos para exportar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     return;
                 }
-                DataTable dt = vista.ToTable(false, "CodigoInventario", "Nombre", "Categoria", "Estado", "Ubicacion");
+                DataTable dt = vista.ToTable(false, "CodigoInventario", "Nombre", "Categoria", "TotalUnidades", "UnidadesConProblema", "Ubicacion");
                 dt.Columns["CodigoInventario"].ColumnName = "Código";
                 dt.Columns["Nombre"].ColumnName = "Nombre del activo";
                 dt.Columns["Categoria"].ColumnName = "Categoría";
-                dt.Columns["Estado"].ColumnName = "Estado físico";
+                dt.Columns["TotalUnidades"].ColumnName = "Unidades";
+                dt.Columns["UnidadesConProblema"].ColumnName = "Con problema";
                 dt.Columns["Ubicacion"].ColumnName = "Ubicación";
                 ExportadorPdf.Exportar("Catálogo de activos", dt);
             }
```

### 5. `frmGestionActivosPrestamos.cs`

El préstamo se hace sobre una unidad (se obtiene con el código). La cantidad queda fija en 1.

**Archivo `frmGestionActivosPrestamos.cs`** (líneas con `-` se quitan, líneas con `+` se agregan):

```diff
@@ -21,6 +21,7 @@
             cmbPrestVer.Items.AddRange(new object[] { "Activos", "Atrasados", "Por vencer", "Devueltos", "Todos" });
             cmbPrestVer.SelectedIndex = 0;
             cmbDevEstado.SelectedIndex = cmbDevEstado.FindStringExact("Bueno");
+            numPrestCant.Value = 1; numPrestCant.Maximum = 1; numPrestCant.Enabled = false;   // se presta una unidad a la vez
             dtpPrestLimite.Value = DateTime.Now.AddDays(1);
             cargando = previo;
             CargarPrestamos();
@@ -125,6 +126,7 @@
             bool error = false;
 
             if (cmbPrestActivo.SelectedValue == null) { errorProvider.SetError(cmbPrestActivo, "Seleccione el equipo."); error = true; }
+            if (string.IsNullOrWhiteSpace(txtPrestCodigo.Text)) { errorProvider.SetError(txtPrestCodigo, "Indique el código de la unidad (ver ficha del activo > Ubicación)."); error = true; }
             if (string.IsNullOrWhiteSpace(txtPrestResp.Text)) { errorProvider.SetError(txtPrestResp, "El responsable es obligatorio."); error = true; }
             if (dtpPrestLimite.Value <= DateTime.Now) { errorProvider.SetError(dtpPrestLimite, "La fecha límite debe ser posterior a la actual."); error = true; }
             if (error) return;
@@ -132,10 +134,9 @@
             int aula = cmbPrestAula.SelectedValue == null ? 0 : Convert.ToInt32(cmbPrestAula.SelectedValue);
             try
             {
+                int idUnidad = Datos.IdUnidad(Convert.ToInt32(cmbPrestActivo.SelectedValue), txtPrestCodigo.Text);
                 Datos.Procedimiento("sp_RegistrarPrestamo",
-                    Datos.P("@IdActivo", Convert.ToInt32(cmbPrestActivo.SelectedValue)),
-                    Datos.PTexto("@CodigoInventario", txtPrestCodigo.Text),
-                    Datos.P("@Cantidad", (int)numPrestCant.Value),
+                    Datos.P("@IdUnidad", idUnidad),
                     Datos.P("@TipoResponsable", cmbPrestTipo.Text),
                     Datos.P("@Responsable", txtPrestResp.Text.Trim()),
                     Datos.P("@IdSalonDestino", aula > 0 ? (object)aula : null),
@@ -181,7 +182,7 @@
             errorProvider.Clear();
 
             string estado = cmbDevEstado.Text;
-            if (MessageBox.Show("Se registrará la devolución y el activo pasará a estado '" + estado + "'. ¿Continuar?",
+            if (MessageBox.Show("Se registrará la devolución y la unidad pasará a estado '" + estado + "'. ¿Continuar?",
                 "Confirmar devolución", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
 
             try
@@ -200,7 +201,7 @@
 
                 txtDevObs.Clear();
                 CargarPrestamos();
-                CargarActivos();   // el estado del activo cambió
+                CargarActivos();   // cambió el estado de la unidad
             }
             catch (Exception ex)
             {
```


### 6. `frmGestionActivos.Mantenimiento.cs`

El mantenimiento se registra sobre una unidad (por código).

**Archivo `frmGestionActivos.Mantenimiento.cs`** (líneas con `-` se quitan, líneas con `+` se agregan):

```diff
@@ -94,14 +94,15 @@
             bool error = false;
             if (cmbMantActivo.SelectedValue == null) { errorProvider.SetError(cmbMantActivo, "Seleccione el equipo."); error = true; }
             if (cmbMantEstado.SelectedValue == null) { errorProvider.SetError(cmbMantEstado, "Seleccione el estado resultante."); error = true; }
+            if (string.IsNullOrWhiteSpace(txtMantCodigo.Text)) { errorProvider.SetError(txtMantCodigo, "Indique el código de la unidad."); error = true; }
             if (string.IsNullOrWhiteSpace(txtMantDesc.Text)) { errorProvider.SetError(txtMantDesc, "Describa el servicio realizado."); error = true; }
             if (error) return;
 
             try
             {
+                int idUnidad = Datos.IdUnidad(Convert.ToInt32(cmbMantActivo.SelectedValue), txtMantCodigo.Text);
                 Datos.Procedimiento("sp_RegistrarMantenimiento",
-                    Datos.P("@IdActivo", Convert.ToInt32(cmbMantActivo.SelectedValue)),
-                    Datos.PTexto("@CodigoInventario", txtMantCodigo.Text),
+                    Datos.P("@IdUnidad", idUnidad),
                     Datos.P("@Fecha", dtpMantFecha.Value.Date),
                     Datos.P("@Tipo", cmbMantTipo.Text),
                     Datos.P("@Descripcion", txtMantDesc.Text.Trim()),
@@ -110,7 +111,7 @@
                     Datos.P("@IdReporte", idReporteVinculado > 0 ? (object)idReporteVinculado : null),
                     Datos.P("@Usuario", UsuarioActual()));
 
-                MessageBox.Show("Mantenimiento registrado y estado del equipo actualizado.", "Éxito",
+                MessageBox.Show("Mantenimiento registrado y estado de la unidad actualizado.", "Éxito",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                 btnMantLimpiar_Click(null, EventArgs.Empty);
                 CargarActivos();        // estado del activo, indicadores y marcas de daño
```


### 7. `frmGestionActivos.Reportes.cs`

Los reportes por salón y de activos con problemas salen por unidad con su estado.

**Archivo `frmGestionActivos.Reportes.cs`** (líneas con `-` se quitan, líneas con `+` se agregan):

```diff
@@ -47,22 +47,22 @@
                 {
                     case 0:
                         dtReporte = Datos.Tabla(
-                            @"SELECT NombreSalon AS [Aula / departamento], NombreActivo AS [Activo], Categoria AS [Categoría],
-                                     CodigoInventario AS [Código], Cantidad
-                              FROM vw_ActivosPorSalon
+                            @"SELECT Ubicacion AS [Aula / departamento], Activo AS [Activo], Categoria AS [Categoría],
+                                     CodigoInventario AS [Código], Estado AS [Estado]
+                              FROM vw_UnidadesDetalle
                               WHERE (@s = 0 OR IdSalon = @s)
-                              ORDER BY NombreSalon, NombreActivo", Datos.P("@s", salon));
+                              ORDER BY Ubicacion, Activo, CodigoInventario", Datos.P("@s", salon));
                         break;
 
                     case 1:
                         dtReporte = Datos.Tabla(
-                            @"SELECT d.CodigoInventario AS [Código], d.Nombre AS [Activo], d.Categoria AS [Categoría],
+                            @"SELECT d.CodigoInventario AS [Código], d.Activo AS [Activo], d.Categoria AS [Categoría],
                                      d.Estado AS [Estado físico], d.Ubicacion AS [Ubicación],
-                                     (SELECT COUNT(*) FROM vw_ReportesDanio r WHERE r.IdActivo = d.IdActivo) AS [Reportes de daño]
-                              FROM vw_ActivosDetalle d
+                                     (SELECT COUNT(*) FROM vw_ReportesDanio r WHERE r.IdUnidad = d.IdUnidad) AS [Reportes de daño]
+                              FROM vw_UnidadesDetalle d
                               WHERE d.Estado IN ('Malo', 'En reparación', 'Mantenimiento Pendiente')
-                                 OR (SELECT COUNT(*) FROM vw_ReportesDanio r WHERE r.IdActivo = d.IdActivo) >= 2
-                              ORDER BY d.Estado, d.Nombre");
+                                 OR (SELECT COUNT(*) FROM vw_ReportesDanio r WHERE r.IdUnidad = d.IdUnidad) >= 2
+                              ORDER BY d.Estado, d.Activo, d.CodigoInventario");
                         break;
 
                     default:
```


### 8. `frmReportarDaño.cs`

La lista de equipos del salón sale de `UnidadesActivo` (cada unidad con su estado).

**Archivo `frmReportarDaño.cs`** (líneas con `-` se quitan, líneas con `+` se agregan):

```diff
@@ -130,19 +130,14 @@
                 using (SqlConnection conexion = Conexion.Conectar())
                 {
                     string query = @"
-                    SELECT A.IdActivo, A.Nombre AS Activo, C.NombreCategoria AS Categoria, SC.Cantidad, CAST(NULL AS VARCHAR(50)) AS CodigoInventario
-                    FROM SalonClases SC
-                    INNER JOIN GestionActivos A ON SC.IdActivo = A.IdActivo
+                    SELECT A.IdActivo, A.Nombre AS Activo, C.NombreCategoria AS Categoria, 1 AS Cantidad,
+                           U.CodigoInventario, ES.NombreEstado AS Estado
+                    FROM UnidadesActivo U
+                    INNER JOIN GestionActivos A ON U.IdActivo = A.IdActivo
+                    INNER JOIN Estados ES ON ES.IdEstado = U.IdEstado
                     LEFT JOIN Categorias C ON A.IdCategoria = C.IdCategoria
-                    WHERE SC.IdSalon = @IdSalon
-
-                    UNION ALL
-
-                    SELECT E.IdActivo, A.Nombre AS Activo, C.NombreCategoria AS Categoria, 1 AS Cantidad, E.CodigoInventario
-                    FROM EquiposIndividualesSalon E
-                    INNER JOIN GestionActivos A ON E.IdActivo = A.IdActivo
-                    LEFT JOIN Categorias C ON A.IdCategoria = C.IdCategoria
-                    WHERE E.IdSalon = @IdSalon";
+                    WHERE U.IdSalon = @IdSalon
+                    ORDER BY A.Nombre, U.CodigoInventario";
 
                     using (SqlCommand cmd = new SqlCommand(query, conexion))
                     {
```


### 9. `Activo.cs` y `ReportaDaño.cs` (proyecto Modelos)

`Activo.cs`: ya no maneja estado por tipo; agrega `ListarUnidades`, `CambiarEstadoUnidad`, `AgregarUnidades`. `ReportaDaño.cs`: `Registrar` exige el código y guarda `IdUnidad`; los cambios de estado se aplican solo a la unidad con ese código (y se corrige `'Mantenimiento'` → `'Mantenimiento Pendiente'`, que es el nombre real en `Estados`). Por ser archivos casi reescritos, usa los archivos completos de `cs/` (el diff sería largo):


---

## D. Qué debes probar

1. Correr el script SQL y revisar `UnidadesEsperadas` = `UnidadesMigradas`.
2. Salones: asignar 3 pupitres a un salón → deben salir 3 filas con su código y estado.
3. Gestión de activos → clic en "Pupitre" → ficha → Ubicación → elegir **una** unidad → cambiar a "Malo" → las demás deben seguir igual.
4. Reportar daño sobre una unidad → debe pasar a "Mantenimiento Pendiente" solo esa unidad.
5. Préstamo: escribir el código de la unidad (se ve en la ficha) → registrar → devolver con un estado.
6. Mantenimiento: registrar servicio a una unidad por su código.

## E. Limitaciones conocidas

- En Préstamos y Mantenimiento hay que **escribir el código** de la unidad (antes era opcional). Mejora posible: un combo que liste las unidades del activo elegido.
- Las tablas viejas `SalonClases` y `EquiposIndividualesSalon` y la columna `GestionActivos.IdEstado` quedan sin uso; bórralas con la sección 8 del script cuando todo funcione.
- No pude compilar ni ejecutar nada (no hay SQL Server ni Visual Studio aquí): compila y prueba, y pásame cualquier error.
