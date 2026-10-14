# Módulo 5 · Bases de datos y SQL Server

> **Semanas:** 12–14 · **Fase:** C · Datos · [Plan de estudio](../../PLAN_DE_ESTUDIO.md) · [Índice](../../INDICE.md) · [Calendario](../../CALENDARIO.md)

## Objetivo

Comprender el modelo relacional y escribir SQL con soltura (consultas, agregaciones, joins, subconsultas, modificación de datos), diseñar esquemas normalizados con restricciones e índices, usar transacciones y prevenir la inyección SQL.

## Por qué importa

Casi todo sistema real guarda datos. SQL es una de las habilidades más pedidas y más duraderas. Aquí construyes la base sobre la que se apoyará C# conectado.

## Requisitos previos

Módulo 3 dominado. SQL Server instalado y verificado (módulo 0).

## Competencias de salida

Estas competencias se registran en [progreso/competencias.md](../../progreso/competencias.md) y solo se marcan como *demostradas* con evidencia (programa, evaluación o defensa).

| Código | Al terminar el módulo… |
|---|---|
| M5-C1 | Modelo entidades y relaciones (1:1, 1:N, N:M) a partir de requisitos. |
| M5-C2 | Escribo consultas con filtros, ordenamiento, agregaciones y agrupaciones. |
| M5-C3 | Combino tablas con JOIN y subconsultas y verifico los resultados. |
| M5-C4 | Modifico datos con INSERT, UPDATE y DELETE de forma segura. |
| M5-C5 | Aplico normalización, restricciones e índices con justificación. |
| M5-C6 | Explico y prevengo la inyección SQL. |
| M5-C7 | Diseño y creo una base de datos completa desde requisitos. |

## Unidades

<!-- AUTO:UNIDADES:INICIO -->
| Unidad | Sem. | Qué cubre | Lección | Retos | Soluciones |
|---|---|---|---|---|---|
| 5.1 Bases de datos relacionales, SQL Server y SSMS | 12 | tablas, filas y columnas; tipos de datos de SQL Server; crear una base y una tabla; usar SSMS o la extensión MSSQL | ⏳ | ⏳ | ⏳ |
| 5.2 Claves y relaciones | 12 | clave primaria; clave foránea; uno a uno, uno a muchos, muchos a muchos; tablas intermedias | ⏳ | ⏳ | ⏳ |
| 5.3 SELECT, WHERE y ORDER BY | 12 | proyección y filtros; operadores y NULL; ordenar y limitar resultados; LIKE e IN | ⏳ | ⏳ | ⏳ |
| 5.4 Funciones de agregación, GROUP BY y HAVING | 12 | COUNT, SUM, AVG, MIN, MAX; GROUP BY; HAVING frente a WHERE; orden lógico de una consulta | ⏳ | ⏳ | ⏳ |
| 5.5 INSERT, UPDATE y DELETE | 12 | insertar filas; actualizar con WHERE; borrar con seguridad; probar con SELECT antes de modificar | ⏳ | ⏳ | ⏳ |
| 5.6 JOIN | 13 | INNER JOIN; LEFT JOIN; varias tablas; errores típicos (duplicados y filas perdidas) | ⏳ | ⏳ | ⏳ |
| 5.7 Subconsultas y expresiones de tabla comunes | 13 | subconsultas escalares y de lista; EXISTS; CTE; reescribir con JOIN | ⏳ | ⏳ | ⏳ |
| 5.8 Diseño de esquemas y normalización | 13 | redundancia y anomalías; 1FN, 2FN y 3FN; diagrama entidad–relación; cuándo desnormalizar | ⏳ | ⏳ | ⏳ |
| 5.9 Restricciones e índices | 13 | NOT NULL, UNIQUE, CHECK, DEFAULT; integridad referencial; índices; plan de ejecución (introducción) | ⏳ | ⏳ | ⏳ |
| 5.10 Transacciones | 14 | ACID a nivel intuitivo; BEGIN, COMMIT y ROLLBACK; bloqueos (introducción); TRY/CATCH en T-SQL | ⏳ | ⏳ | ⏳ |
| 5.11 Consultas parametrizadas e inyección SQL | 14 | qué es la inyección SQL; demostración controlada; parámetros; mínimo privilegio | ⏳ | ⏳ | ⏳ |
| 5.12 Diseñar una base de datos desde requisitos reales | 14 | de requisitos a entidades; modelo y script de creación; datos de prueba; consultas de validación | ⏳ | ⏳ | ⏳ |
<!-- AUTO:UNIDADES:FIN -->

Cada unidad seguirá la [plantilla de lección](../../plantillas/leccion.md) de quince secciones, con un archivo de retos de cuatro niveles en `retos/` y soluciones separadas en `soluciones/M05-bases-de-datos-y-sql-server/` (se crean al desarrollar el módulo; protocolo en [soluciones/README.md](../../soluciones/README.md)).

## Cómo se trabaja este módulo

Todo se practica contra una base real en tu SQL Server. Se diseña antes de crear. Se prueba cada `UPDATE`/`DELETE` primero con `SELECT`. Los scripts se versionan en Git.

## Errores típicos de este módulo

`UPDATE`/`DELETE` sin `WHERE` · `JOIN` que duplica filas · `GROUP BY` mal entendido · diseñar tablas sin claves · concatenar texto en consultas.

## Proyecto asociado

**Caso integral de base de datos** (semana 14): diseño, script de creación, datos de prueba y consultas de validación; sirve de base para P3.

## Evaluación y puerta de avance

Evaluaciones semanales + **prueba de SQL sin apuntes** (semana 14) + **evaluación del módulo**. **Puerta 5.**

Criterios y reglas esenciales: [evaluaciones/RUBRICAS.md](../../evaluaciones/RUBRICAS.md). Puertas: [PLAN_DE_ESTUDIO.md, sección 5](../../PLAN_DE_ESTUDIO.md#5-puertas-de-avance).

## Recursos

Documentación de T-SQL y de SQL Server en Microsoft Learn; SSMS 22 o la extensión MSSQL de VS Code. Estado de verificación de enlaces: [recursos/ENLACES.md](../../recursos/ENLACES.md).
