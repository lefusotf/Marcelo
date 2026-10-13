# Lote A: arreglos globales

Cada archivo de esta carpeta es el archivo **completo**, con la misma ruta que en tu proyecto.
Reemplaza el de tu proyecto por el de aquí (misma carpeta y mismo nombre) y compila.
Están hechos sobre el zip `wiwiwi_2.zip` que me pasaste.

| Archivo | Qué arregla |
|---|---|
| `ExportadorExcel.cs` (proyecto **Modelos**) | Fechas al exportar a Excel. Ahora crea un `.xlsx` real: fechas `dd/mm/aaaa`, números como números, columnas con el ancho justo, encabezado oscuro, filtros y fila fija. Ya no sale `####`. No necesita referencias nuevas. |
| `Vista/Estilizadores/ControlesTema.cs` | El final de todas las tablas se veía cortado: la última fila salía a la mitad. Ahora esa franja se tapa y la tabla termina siempre en una fila completa (al bajar con la rueda aparece entera). |
| `frmSalones`, `frmAusencias`, `frmGestionPersonal`, `frmReportarDaño`, `frmGestionPlanillas`, `frmCatalogoSalarios` (`.Designer.cs`), `frmCargaAcademica.cs`, `frmGestionActivos.Designer.cs` | Todos los botones de "Exportar PDF" (y el "PDF" y "Exportar a PDF" de Gestión de activos) ahora dicen **Exportar**. Los tooltips dicen "(PDF o Excel)" porque el botón pregunta el formato. "Hoja de resguardo (PDF)" y "Boleta PDF" se quedan porque sí generan solo PDF. |
| `frmCentroSoporte.cs` y `.Designer.cs` | Teléfono `+503 4093-2134`, correo `smartschoolptc@gmail.com`, asteriscos quitados de los tres campos, y nuevo texto bajo "Reportar un problema". El horario se calcula de las constantes `HoraApertura` y `HoraCierre` (líneas 22-23 de `frmCentroSoporte.cs`). |
| `frmGestionActivosPrestamos.cs` | En Préstamos la hora ya no se corta: las columnas Entrega / Límite / Devuelto tienen ancho mínimo. |
| `frmGestionActivos.Designer.cs` | El ejemplo de consumible ahora es "Páginas de papel bond" y el botón Exportar tiene el ancho correcto. |

## Dos cosas que dependen de ti

1. **Horario de atención.** No me dijiste el horario nuevo, así que dejé el de antes (lunes a viernes, 9:00 a.m. a 6:00 p.m.).
   Para cambiarlo, edita `HoraApertura` y `HoraCierre` en `frmCentroSoporte.cs`; el texto de la tarjeta y el
   indicador "Atención disponible ahora" se actualizan solos.
2. **A dónde llegan los reportes.** Cambiar el correo en pantalla no cambia el destino real de los reportes: ese
   destino lo define el servicio de correo (el script de Google que usa `ServicioCorreo.cs`). Si quieres que los
   reportes lleguen a `smartschoolptc@gmail.com`, hay que cambiarlo allí.

## Cómo probarlo

- Abre cualquier tabla con más filas de las que caben: debe terminar en una fila completa, sin media fila abajo.
- Exporta a Excel desde cualquier módulo, elige **Excel**, ábrelo: las fechas se leen completas.
- Entra a Gestión de activos > Préstamos: la columna de fechas muestra `dd/mm/aa HH:mm` completo.
- Abre el Centro de soporte y revisa teléfono, correo y que no haya asteriscos.
