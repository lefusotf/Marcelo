# P2 · Aplicación de gestión de registros

> **Semana 9** · Integra los **Módulos 1–3** · Evaluación: rúbrica D + defensa · Forma parte de la **Puerta 3**
> Tu código va en `proyectos/P2-gestion-de-registros/codigo/`. No se edita este archivo.

## 1. Problema que resuelve

Pequeñas organizaciones llevan sus registros en hojas de papel o de cálculo y pierden datos, duplican entradas y no pueden buscar rápido. Construirás una **aplicación de consola** que gestiona un conjunto de registros con búsqueda, orden y **persistencia en archivo**, modelada con clases.

## 2. Elige un dominio (uno solo)

Para que el proyecto sea tuyo y no una copia, elige **una** de estas opciones (o propón otra equivalente y la discutimos):

| Dominio | Entidad principal | Entidad relacionada |
|---|---|---|
| **A · Inventario de un pequeño negocio** | `Producto` (código, nombre, categoría, precio, existencias) | `Movimiento` (entrada/salida de existencias) |
| **B · Biblioteca de aula** | `Libro` (código, título, autor, año, disponible) | `Prestamo` (libro, persona, fecha, devolución) |
| **C · Agenda de citas** | `Cliente` (nombre, teléfono, correo) | `Cita` (cliente, fecha, motivo, estado) |

Reglas del dominio: la entidad principal tiene **al menos 5 campos** con tipos distintos; hay **una entidad relacionada** que referencia a la principal.

## 3. Público objetivo

Una persona sin conocimientos técnicos que gestiona los registros desde la consola, y quien revise tu portafolio y quiera ver el modelado de clases y las decisiones.

## 4. Requisitos funcionales

- **RF1 · Alta:** crear registros con **validación**: campos obligatorios, rangos (precio ≥ 0, año plausible), formatos (código único).
- **RF2 · Listado** con formato de tabla legible y paginación sencilla si hay muchos.
- **RF3 · Búsqueda** por nombre/título (parcial, sin distinguir mayúsculas) y por otro campo (categoría/estado).
- **RF4 · Modificación y baja** de un registro existente, con confirmación antes de borrar.
- **RF5 · Ordenar** el listado por al menos dos criterios.
- **RF6 · Entidad relacionada:** registrar movimientos / préstamos / citas que enlacen con la entidad principal, con reglas (no se puede prestar un libro no disponible; no se puede sacar más existencias que las disponibles; no dos citas a la misma hora).
- **RF7 · Resumen:** un informe con totales y estadísticas (con LINQ) — por ejemplo, valor total del inventario o préstamos activos.
- **RF8 · Persistencia:** los datos se **guardan en un archivo JSON** al salir (y se cargan al arrancar). Si el archivo no existe o está dañado, el programa **no se cae**: avisa y empieza vacío.

## 5. Requisitos no funcionales

- **Encapsulación:** los campos de las clases son privados o con propiedades con validación; no existen objetos en estado inválido.
- **Separación:** la interfaz de consola no contiene reglas del negocio; las reglas viven en clases.
- **Robustez:** excepciones propias para reglas de negocio (por ejemplo, `ExistenciasInsuficientesException`) y manejo centralizado; ninguna entrada del usuario causa una caída.
- **Mantenibilidad:** un tipo por archivo, espacios de nombres coherentes, sin duplicación; nombres sin `ñ` ni tildes.
- **Calidad de proceso:** commits pequeños, ≥ 20.

## 6. Conceptos que practicarás

Todo el módulo 1 y el módulo 3: clases, propiedades, constructores, encapsulación, composición, **al menos una interfaz** (por ejemplo, `IRepositorio<T>`), colecciones genéricas, LINQ básico, excepciones, enums, organización en archivos y espacios de nombres.

## 7. Diseño inicial (tú lo completas)

```text
Programa (consola)  →  Servicio (reglas del negocio)  →  Repositorio (colección en memoria + archivo JSON)
        │                         │                                  │
   solo muestra/lee         valida y aplica reglas            guarda y carga datos

Clases: Entidad principal · Entidad relacionada · Servicio · IRepositorio<T> · RepositorioJson<T> · excepciones propias
```

Entrega antes de programar: un diagrama de clases sencillo (a mano vale), la lista de reglas de negocio numeradas y una tabla de las operaciones con su validación.

## 8. Plan de tareas

| N.º | Tarea |
|---|---|
| T1 | Requisitos y reglas de negocio por escrito; diagrama de clases |
| T2 | Entidad principal con propiedades, constructor y validación |
| T3 | Repositorio en memoria (alta, listado, búsqueda, baja, modificación) |
| T4 | Interfaz de consola (menú) separada del servicio |
| T5 | Entidad relacionada y sus reglas |
| T6 | Ordenar y filtrar con LINQ; informe de resumen |
| T7 | Persistencia JSON (guardar y cargar) con manejo de errores |
| T8 | Pruebas manuales: tabla de pruebas completa |
| T9 | Revisión de diseño: duplicación, nombres, responsabilidades |
| T10 | README, defensa |

## 9. Criterios de aceptación

- [ ] RF1–RF8 funcionan según lo descrito.
- [ ] No es posible crear un objeto en estado inválido (se demuestra con pruebas).
- [ ] Reiniciar el programa conserva los datos; el archivo dañado no lo rompe.
- [ ] El servicio no contiene `Console.WriteLine` ni `Console.ReadLine`.
- [ ] La tabla de pruebas tiene ≥ 30 casos (normales, límite, inválidos, de persistencia).
- [ ] Hay una interfaz que se usa de verdad (no decorativa) y puedes justificar por qué existe.

## 10. Casos de prueba (ejemplos; añade los tuyos)

| Caso | Esperado |
|---|---|
| Alta con precio negativo | Rechazado con mensaje; nada se guarda |
| Alta con código repetido | Rechazado |
| Búsqueda `"pan"` con mayúsculas variadas | Encuentra coincidencias parciales sin distinguir mayúsculas |
| Baja con confirmación negativa | No se borra |
| Préstamo de un libro no disponible | Rechazado por regla de negocio |
| Cerrar y abrir el programa | Los datos siguen ahí |
| Archivo JSON con contenido inválido | Aviso claro y arranque con datos vacíos (el archivo no se sobrescribe sin avisar) |

## 11. Posibles ampliaciones

- Exportar a CSV.
- Estadísticas por periodo.
- Pruebas automáticas con xUnit para las reglas de negocio (te servirán en el módulo 8).

## 12. Evaluación y defensa

Rúbrica D. **Defensa:** explicarás el diagrama de clases, por qué elegiste interfaz/herencia/composición donde corresponda, qué pasaría si cambiara la forma de guardar (JSON → base de datos) y qué parte de tu código cambiarías primero; y modificarás una regla de negocio en vivo.

> **Nota:** este proyecto es el punto de partida del dominio de **P3** (SQL Server), **P4** (capas) y **P5** (API). Elige un dominio con el que quieras vivir varias semanas.
