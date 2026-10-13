# Lote B: reglas y validaciones

Igual que el lote A: cada archivo es el **completo**, con la misma ruta que en tu proyecto. Reemplaza y compila.
Este lote se aplica **después** del lote A (los archivos repetidos ya incluyen los cambios del A).
Si en tu base ya existen empleados con estado civil "Unión libre", corre también `db/07_estado_civil_sin_union_libre.sql`.

| Archivo | Qué cambia |
|---|---|
| `frmGestionActivos.Designer.cs` + `frmGestionActivos.Consumibles.cs` | **Consumibles.** (1) *Unidad de medida*: ya no es texto libre, es una lista (Unidad, Caja, Paquete, Resma, Litro, Galón, Kilogramo, Metro, Par, Rollo). (2) *Editar*: botón **Editar** junto a "Crear consumible" (o doble clic en la fila): carga el consumible, cambias nombre y stock mínimo y pulsas **Guardar cambios** (o **Cancelar**). La unidad solo se cambia si el consumible aún no tiene movimientos. Solo administrador. (3) *Destino o referencia*: el campo cambia según lo que haces. Despacho a aula: lista de salones (queda enlazado al salón). Despacho a departamento o Merma: texto obligatorio. Compra, Donación o Ajuste: proveedor / factura, donante o detalle obligatorio. (4) En una **salida** la cantidad no puede pasar del stock (se ve "Cantidad (hay 25)" y, si escribes de más, vuelve al máximo y avisa). (5) *Colores de alerta*: Agotado en rojo y Stock bajo en ámbar, con los mismos tonos oscuros de Préstamos. |
| `frmGestionPersonal.Designer.cs` + `frmGestionPersonal.cs` | Botón **Editar cargo** (junto a "Nuevo cargo"): elige un cargo en la lista de cargos y cámbiale el nombre. Los botones de la fila se reacomodaron. Solo administrador. |
| `frmAsignarCargo.cs` | La misma ventana de "Nuevo cargo" sirve para editar. Reglas: no deja repetir nombres, pide confirmación porque el cambio afecta a todos los empleados de ese cargo, y un cargo "Docente…" no puede dejar de empezar con "Docente" (ni uno que no lo es, empezar así) porque el sistema reconoce a los docentes por ese nombre. |
| `frmAgregarPersonal.Designer.cs` | Estado civil sin "Unión libre". |
| `frmAsignarEquipo.cs` | Gestión de salones > Asignar equipo: el numérico ya no deja escribir más de lo disponible en la bodega (vuelve al máximo y avisa), y está desactivado hasta elegir el equipo. Además se revisa otra vez al guardar. |
| `Vista/Estilizadores/ControlesTema.cs` | Clase nueva `NumericoLimitado` (la usan Asignar equipo y Consumibles). Incluye el arreglo del fin de tabla del lote A. |

Base de datos: no cambia ninguna tabla ni procedimiento. Cambió `db/BaseDeDatos_Completa.sql` solo en los datos de
ejemplo (5 empleados que tenían "Unión libre" ahora tienen "Casado/a") y se añadió `db/07_estado_civil_sin_union_libre.sql`
para quien ya tiene la base creada.

## Cómo probarlo

1. Gestión de activos > Consumibles: crea "Páginas de papel bond" (unidad Resma). Selecciónalo y pulsa **Editar**: cambia el nombre y guarda.
   Registra una entrada (Compra pide proveedor) y luego una salida: con "Despacho a aula" sale la lista de salones; intenta sacar más del stock.
2. Deja un consumible en 0 o bajo el mínimo y mira los colores.
3. Gestión de personal: elige un cargo en el filtro, **Editar cargo**, cambia el nombre. Prueba renombrar "Docente" a "Profesor": debe negarlo.
4. Agregar empleado: el combo de estado civil ya no trae Unión libre.
5. Gestión de salones > un salón > Asignar equipo: escribe 999 en la cantidad.
