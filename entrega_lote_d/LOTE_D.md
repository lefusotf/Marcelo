# Lote D: revisión final

Resultado de revisar todo el proyecto contra tu rúbrica. Aplícalo después de A, B y C (o usa `entrega_final/`, que ya lo incluye).

| Archivo | Qué cambia |
|---|---|
| `Vista/Funciones/frmLogin.cs` | **Bloqueo temporal por intentos fallidos** (seguridad): tras 5 contraseñas incorrectas con el mismo usuario hay que esperar 60 segundos. Desde el 3.er fallo avisa cuántos intentos quedan. Se reinicia al entrar bien. Constantes `MaxFallos` y `SegundosBloqueo` al inicio del archivo. |
| `frmRegistrarAusencia.cs` | Era el único diálogo con combos azules de Windows y selectores de fecha blancos. Ahora usa `ComboOscuro` y `FechaOscura`, y la barra del motivo es oscura. |
| `frmResolverReporte.cs` | Combo de estado oscuro, costo con borde fino y barra oscura en la descripción. |
| `frmSalon.Designer.cs`, `frmAltaUnidades.Designer.cs`, `frmAsignarEquipo.Designer.cs` | El numérico (capacidad / cantidad) era blanco en una interfaz oscura; ahora es oscuro. |
| `frmSalon.cs`, `frmRegistrarPago.cs` | Barra de desplazamiento oscura en "Observación". |

Nota: `frmAltaUnidades.cs` NO está en esta entrega; solo su Designer.
