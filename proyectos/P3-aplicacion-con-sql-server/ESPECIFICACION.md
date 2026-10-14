# P3 · Aplicación conectada a SQL Server

> **Semana 17** · Integra los **Módulos 3, 5 y 6** · Evaluación: rúbrica D + defensa · Forma parte de la **Puerta 6**
> Tu código va en `proyectos/P3-aplicacion-con-sql-server/codigo/`. No se edita este archivo.
> *Especificación inicial: se detalla (casos de prueba, base de datos de ejemplo y guía de etapas) al desarrollar el módulo 6, adaptándola a tu dominio de P2.*

## 1. Problema que resuelve

P2 guardaba datos en un archivo. Un archivo no soporta varios usuarios, consultas complejas ni garantías de consistencia. P3 lleva **el mismo dominio** a una base de datos de **SQL Server** y lo opera desde C# con acceso seguro.

## 2. Público objetivo

La misma persona usuaria de P2, y quien evalúe tu portafolio: verá si sabes diseñar una base relacional y conectarla bien, sin inyección SQL ni credenciales expuestas.

## 3. Requisitos funcionales

- **RF1 · Base de datos propia:** esquema con **≥ 4 tablas**, claves primarias y foráneas, restricciones (`NOT NULL`, `UNIQUE`, `CHECK`) e **índices justificados**. Script `crear-base.sql` reproducible.
- **RF2 · CRUD completo** de la entidad principal contra la base (consultas parametrizadas).
- **RF3 · Entidades relacionadas** con operaciones que cruzan tablas (JOIN) y reglas de negocio.
- **RF4 · Una operación transaccional** (por ejemplo, registrar un préstamo y actualizar la disponibilidad) que deja los datos **consistentes** aunque algo falle a la mitad.
- **RF5 · Búsqueda y filtros** resueltos en la base de datos (no cargando todo en memoria).
- **RF6 · Informes** con agregaciones (`GROUP BY`) mostrados en la aplicación.
- **RF7 · Manejo de errores de base de datos** con mensajes comprensibles (por ejemplo, clave duplicada) sin exponer detalles internos al usuario.
- **RF8 · Datos de prueba:** script `datos-de-prueba.sql` con **datos ficticios**.

## 4. Requisitos no funcionales

- **Seguridad:** consultas **siempre parametrizadas**; cadena de conexión fuera del código y del repositorio (**User Secrets** o variable de entorno); el usuario de la base con privilegios mínimos (documentado).
- **Separación:** lógica de negocio separada del acceso a datos (ver 6.4); acceso a datos con `Microsoft.Data.SqlClient`.
- **Recursos:** conexiones y comandos liberados (`using`); sin conexiones abiertas de más.
- **Mantenibilidad:** script de base de datos versionado; README que explica cómo crear la base y configurar el secreto.
- **Calidad de proceso:** trabajo en **rama**, al menos un *pull request* propio revisado (módulo 7).

## 5. Conceptos que practicarás

Diseño relacional y normalización · restricciones e índices · JOIN y agregaciones · transacciones · consultas parametrizadas · ADO.NET · configuración segura · excepciones de SQL · async/await (opcional) · Git con ramas.

## 6. Diseño inicial

```text
Presentación (consola)  →  Servicio (reglas del negocio)  →  Repositorio ADO.NET  →  SQL Server
```

Entrega antes de programar: diagrama entidad–relación, justificación de la normalización (3FN), lista de índices con la consulta que los motiva, y la lista de operaciones transaccionales.

## 7. Plan de tareas (borrador)

| N.º | Tarea |
|---|---|
| T1 | Modelo entidad–relación y script de creación |
| T2 | Script de datos de prueba y consultas de verificación |
| T3 | Conexión segura (User Secrets) y prueba de conexión |
| T4 | Repositorio: CRUD con consultas parametrizadas |
| T5 | Consultas con JOIN y agregaciones |
| T6 | Operación transaccional y prueba de fallo (rollback) |
| T7 | Servicio con reglas de negocio y manejo de errores |
| T8 | Pruebas manuales (tabla) incluyendo un intento de inyección SQL controlado |
| T9 | README, rama, *pull request* y defensa |

## 8. Criterios de aceptación

- [ ] El script crea la base desde cero en una instalación limpia.
- [ ] Cero concatenación de texto en consultas con datos del usuario.
- [ ] Ninguna contraseña ni cadena de conexión real en el repositorio ni en su historial.
- [ ] La operación transaccional deja los datos coherentes cuando se fuerza un error.
- [ ] El servicio no contiene SQL ni `Console`; el repositorio no contiene reglas de negocio.
- [ ] Tabla de pruebas ≥ 30 casos, con resultados reales.

## 9. Casos de prueba (ejemplos)

| Caso | Esperado |
|---|---|
| Insertar con clave duplicada | Mensaje claro; la base no cambia |
| Entrada con comilla simple (`O'Brien`) | Se guarda correctamente (parámetros) |
| Texto de inyección (`'; DROP TABLE ...--`) como nombre | Se trata como dato; no ejecuta nada |
| Operación transaccional con fallo a mitad | Ninguna de las dos escrituras queda aplicada |
| Búsqueda sin resultados | Mensaje sin error |
| Conexión no disponible | Mensaje comprensible, sin detalles internos |

## 10. Posibles ampliaciones

Migrarlo a Entity Framework Core (te sirve de comparación con ADO.NET) · paginación en la base · auditoría de cambios con un *trigger*.

## 11. Entregables

Carpeta `codigo/` con solución, scripts SQL, README y pruebas; historial de Git con rama y PR.

## 12. Evaluación y defensa

Rúbrica D. **Defensa:** diseñar en la pizarra la consulta de un informe pedido en el momento, explicar tu transacción, mostrar por qué tu código no es vulnerable a inyección SQL y demostrar dónde está (y dónde **no** está) la cadena de conexión.
