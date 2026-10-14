# Módulo 6 · C# conectado a bases de datos

> **Semanas:** 15–17 · **Fase:** C · Datos · [Plan de estudio](../../PLAN_DE_ESTUDIO.md) · [Índice](../../INDICE.md) · [Calendario](../../CALENDARIO.md)

## Objetivo

Conectar C# con SQL Server de forma segura y ordenada: ADO.NET con consultas parametrizadas, CRUD, separación de lógica y datos, transacciones, `async/await` y una primera mirada a Entity Framework Core y a las migraciones.

## Por qué importa

Es el puente entre lo que sabes de C# y lo que sabes de SQL, y la base para cualquier aplicación o API con datos. Tu proyecto anterior ya usaba ADO.NET; aquí entiendes por qué cada línea está como está y qué mejorarías.

## Requisitos previos

Módulos 3 y 5 dominados.

## Competencias de salida

Estas competencias se registran en [progreso/competencias.md](../../progreso/competencias.md) y solo se marcan como *demostradas* con evidencia (programa, evaluación o defensa).

| Código | Al terminar el módulo… |
|---|---|
| M6-C1 | Conecto C# a SQL Server con configuración segura, sin credenciales en el código. |
| M6-C2 | Implemento CRUD con consultas parametrizadas y liberación correcta de recursos. |
| M6-C3 | Separo la lógica de negocio del acceso a datos. |
| M6-C4 | Uso transacciones para mantener la consistencia. |
| M6-C5 | Uso async/await en operaciones de entrada y salida entendiendo qué ocurre. |
| M6-C6 | Uso EF Core (modelo, consultas, migraciones) y lo comparo con ADO.NET. |

## Unidades

<!-- AUTO:UNIDADES:INICIO -->
| Unidad | Sem. | Qué cubre | Lección | Retos | Soluciones |
|---|---|---|---|---|---|
| 6.1 Conexiones, cadenas de conexión y configuración segura | 15 | SqlConnection; cadena de conexión; User Secrets y variables de entorno; no versionar credenciales | ⏳ | ⏳ | ⏳ |
| 6.2 Consultas parametrizadas y lectura de resultados | 15 | SqlCommand; parámetros tipados; SqlDataReader; ExecuteScalar y ExecuteNonQuery | ⏳ | ⏳ | ⏳ |
| 6.3 CRUD completo con ADO.NET | 15 | crear, leer, actualizar y borrar; mapear filas a objetos; manejo de resultados vacíos; pruebas manuales contra la base | ⏳ | ⏳ | ⏳ |
| 6.4 Separar lógica de negocio y acceso a datos | 15 | responsabilidades; repositorio simple; entidades y servicios; qué no va en la capa de datos | ⏳ | ⏳ | ⏳ |
| 6.5 Validación, errores y gestión de recursos | 15 | using y Dispose; excepciones de SQL; mensajes al usuario frente a registros técnicos; no perder la excepción original | ⏳ | ⏳ | ⏳ |
| 6.6 Transacciones y consistencia de los datos | 16 | SqlTransaction; operaciones que deben ir juntas; commit y rollback; pruebas de fallo | ⏳ | ⏳ | ⏳ |
| 6.7 async/await esencial | 16 | qué problema resuelve; Task y await; async en acceso a datos; errores comunes (async void, bloqueos) | ⏳ | ⏳ | ⏳ |
| 6.8 Entity Framework Core y comparación con ADO.NET | 16 | DbContext y DbSet; consultas con LINQ; seguimiento de cambios; cuándo elegir cada enfoque | ⏳ | ⏳ | ⏳ |
| 6.9 Migraciones y gestión del esquema | 16 | crear una migración; aplicar y revertir; revisar el SQL generado; versionar el esquema | ⏳ | ⏳ | ⏳ |
<!-- AUTO:UNIDADES:FIN -->

Cada unidad seguirá la [plantilla de lección](../../plantillas/leccion.md) de quince secciones, con un archivo de retos de cuatro niveles en `retos/` y soluciones separadas en `soluciones/M06-csharp-y-bases-de-datos/` (se crean al desarrollar el módulo; protocolo en [soluciones/README.md](../../soluciones/README.md)).

## Cómo se trabaja este módulo

Se usa `Microsoft.Data.SqlClient` (el paquete recomendado; `System.Data.SqlClient` figura como obsoleto). Las credenciales **nunca** van en el código ni en el repositorio: se usa User Secrets o variables de entorno desde la primera unidad.

## Errores típicos de este módulo

Cadenas de conexión con contraseña en el repositorio · concatenar texto en consultas · conexiones sin cerrar · lógica de negocio mezclada con acceso a datos · tragar excepciones de SQL · `async void`.

## Proyecto asociado

**P3 · Aplicación conectada a SQL Server** (semana 17): consola o escritorio, con CRUD, capas y configuración segura.

## Evaluación y puerta de avance

Evaluaciones semanales + **evaluación del módulo** con defensa de P3. **Puerta 6.**

Criterios y reglas esenciales: [evaluaciones/RUBRICAS.md](../../evaluaciones/RUBRICAS.md). Puertas: [PLAN_DE_ESTUDIO.md, sección 5](../../PLAN_DE_ESTUDIO.md#5-puertas-de-avance).

## Recursos

Documentación de ADO.NET con `Microsoft.Data.SqlClient` y de EF Core 10 (Microsoft Learn). Estado de verificación de enlaces: [recursos/ENLACES.md](../../recursos/ENLACES.md).
