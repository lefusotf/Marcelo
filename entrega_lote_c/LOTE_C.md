# Lote C: diseño de tablas y diálogos

Igual que los lotes A y B: cada archivo es el **completo**, con la misma ruta que en tu proyecto. Reemplaza y compila.
Aplícalo **después** de A y B (`frmAsignarGrupo` usa la clase `NumericoLimitado` que viene en el lote B).

Revisé cada pantalla de este lote ejecutándola con datos de prueba, para ver la distribución. Esa vista previa no usa la
fuente Segoe UI de Windows, así que algunos textos se ven distintos; las proporciones y los problemas de estructura sí se ven.

| Pantalla | Archivo | Qué estaba mal y qué cambió |
|---|---|---|
| **Gestión de activos (tabla del catálogo)** | `frmGestionActivos.cs` | La columna *Código* no estaba configurada: tomaba el peso por defecto (100) frente a 6-23 de las demás, así que ocupaba más de la mitad de la tabla. Ahora cada columna tiene su peso y ancho mínimo (N°, Código, Nombre, Categoría, Unidades, Con problema, Ubicación), los números van centrados y los títulos no se parten en dos líneas. |
| **Unidades de un activo** | `frmUnidadesActivo.cs` | Se pasó de 8 columnas apretadas a 6 (+1): *Baja* y *Motivo de baja* se unen en una sola columna "Baja y motivo" que solo aparece si hay unidades dadas de baja. El **color por estado** estaba calculado pero nunca se aplicaba: ahora Nuevo y Excelente en verde, Bueno en lima, Regular en ámbar, Malo y Dado de baja en rojo, en negrita. Costo alineado a la derecha, fecha de compra centrada, anchos mínimos para que no se parta "Dado de baja". |
| **Carga académica, vista "Por grado y sección"** | `frmCargaAcademica.cs` | Cada grupo era una sola fila con todos los docentes en una línea ("Nombre - Materia; Nombre - Materia; …") que se cortaba. Ahora cada grupo tiene una fila de encabezado en amarillo ("Primer grado · Sección A", cuántos docentes, total de horas) y debajo una fila por materia con su docente y horas. Los grupos sin docente salen en rojo. Exportar sigue sacando la lista plana (grado, sección, materia, docente, horas). Los títulos de las columnas centradas también quedan centrados. |
| **Asignar grupo** | `frmAsignarGrupo.cs` y `.Designer.cs` | El nombre del docente y el año iban en una sola línea y con nombres largos se cortaban. Ahora el año pasa al título ("Asignar grupo · Año lectivo 2026") y el nombre queda solo, con puntos suspensivos si no cabe. El numérico de horas ya no es blanco (tema oscuro) y no deja escribir más horas de las disponibles. |
| **Catálogo de salarios** | `frmCatalogoSalarios.Designer.cs` | Debajo de las tarjetas, la barra del buscador y los botones tenía el borde roto: el panel de botones tapaba el borde de la derecha y solo se veía a medias. Se corrigió con un margen de 1 px, igual que las demás tarjetas. |
| **Registro de actividad** | `frmRegistroActividad.cs` y `.Designer.cs` | Las 7 columnas tenían el mismo ancho, así que "Qué cambió" (la más larga) se cortaba mientras Usuario y Registro sobraban. Ahora Fecha, Usuario, Nombre, Módulo, Acción, Registro y "Qué cambió" tienen su peso (esta última la más ancha) y un ancho mínimo. Los selectores *Desde* y *Hasta* eran claros (DateTimePicker normal) y ahora son oscuros. Los colores de la columna Acción (verde, ámbar, rojo) se aclararon para que se lean sobre fondo oscuro. |
| **Agregar empleado, selectores de fecha** | `frmAgregarPersonal.Designer.cs` | Los selectores de fecha medían 29 px y los combos y cuadros de texto de al lado 26 px, así que se veían más altos y desalineados. Ahora miden lo mismo (26 px) en nacimiento y contratación. |

## Cómo probarlo

1. **Activos:** abre Gestión de activos > Catálogo. La tabla debe repartir bien el ancho y mostrar la columna Código angosta. Doble clic en un activo (o botón Unidades): la tabla de unidades muestra el estado con color.
2. **Carga académica:** Gestión de personal > Carga académica > "Por grado y sección".
3. **Asignar grupo:** abre el expediente de un docente con nombre largo y pulsa Asignar grupo.
4. **Catálogo de salarios:** el borde de la barra debe cerrar completo por los cuatro lados.
5. **Registro de actividad:** que "Qué cambió" use el resto del ancho y los selectores de fecha sean oscuros.
6. **Agregar empleado:** compara la altura de los selectores de fecha con la de los combos.

## Si algo aún no se ve bien

Del lote A al C hay dos puntos que no pude confirmar con certeza sin ver tu pantalla: el aspecto de los selectores de fecha en
Windows (el ajuste fue de altura, no de diseño) y la tabla "Catálogo de salarios" (arreglé el borde roto; si lo que te molestaba
era otra cosa, mándame una captura). El resto lo verifiqué en pantalla.

## `Vista/Estilizadores/ControlesTema.cs`

Este archivo ya no tapa la fila cortada del final de las tablas (esa corrección pintaba mal las filas). Reemplázalo con el de esta carpeta.

## Gestión de personal: menos botones

La barra tenía 9 botones en una fila. Ahora quedan visibles los de uso diario (Agregar nuevo empleado, Editar, Eliminar,
Expediente, Exportar) y un botón **Más acciones** con un menú: Nuevo cargo, Editar cargo, Ausencias y Carga académica.
Archivos: `frmGestionPersonal.cs` y `frmGestionPersonal.Designer.cs` (reemplazan a los del lote B).
Los cuatro botones viejos siguen en el Designer pero ocultos, así que no se rompe ningún evento.

## Gestión de planillas: menos botones

Visibles: Nuevo pago, Generar planilla, Editar, Marcar pagado y Cerrar mes. En **Más acciones**: Boleta PDF, Exportar y
Anular. Cerrar mes dice "Reabrir mes" cuando el mes está cerrado. El menú copia el texto y si está habilitado de los botones originales.
Archivos: `frmGestionPlanillas.cs` y `frmGestionPlanillas.Designer.cs`.
Gestión de salones se dejó igual: no tiene más de 4 botones por fila.
