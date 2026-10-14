# Progreso

> **Punto de reanudación diario.** Al empezar una sesión se lee este archivo y los de [`progreso/`](progreso/). Si un dato no está aquí, no se da por sabido.
> Regla: los estados solo cambian con evidencia registrada (ver [REGLAS_DE_APRENDIZAJE.md](REGLAS_DE_APRENDIZAJE.md#9-qué-sí-cuenta-como-evidencia-de-dominio-y-qué-no)).

---

## Estado actual

| Campo | Valor |
|---|---|
| **Última actualización** | 2026-10-14 |
| **Fase / semana / sesión** | Sesión 0 (antes de la semana 1) |
| **Diagnóstico** | **En curso:** ronda rápida planteada el 2026-10-14; respuestas del alumno **aún no registradas** |
| **Unidades dominadas** | 0 de 103 |
| **Competencias demostradas** | 0 de 77 |
| **Proyectos terminados** | 0 de 6 |
| **Versión del curso** | 1.0 (construcción: semana 1 completa, resto en fases; ver [PENDIENTES_DEL_CURSO.md](PENDIENTES_DEL_CURSO.md)) |

## Próxima actividad recomendada

1. Responder la **ronda rápida del diagnóstico** (elementos ⚡ de [DIAGNOSTICO.md](evaluaciones/00-diagnostico/DIAGNOSTICO.md)).
2. Con los resultados se ajusta la lección [0.1](modulos/M00-entorno-y-metodo/00.01-que-es-programar.md) y se decide qué unidades de los módulos 0–1 son candidatas a examen de salto.
3. Completar el resto del diagnóstico (partes no marcadas con ⚡) en la sesión siguiente.

---

## Resumen por módulo

| Módulo | Estado | Unidades dominadas | Evaluación del módulo | Proyecto |
|---|---|---|---|---|
| M0 · Entorno y método | No iniciado | 0 / 4 | — | — |
| M1 · Fundamentos | No iniciado | 0 / 15 | — | P1 |
| M2 · Lógica y resolución de problemas | No iniciado | 0 / 9 | — | — |
| M3 · C# intermedio y POO | No iniciado | 0 / 11 | — | P2 |
| M4 · Estructuras de datos y algoritmos | No iniciado | 0 / 9 | — | — |
| M5 · Bases de datos y SQL Server | No iniciado | 0 / 12 | — | — |
| M6 · C# conectado a bases de datos | No iniciado | 0 / 9 | — | P3 |
| M7 · Herramientas y flujo profesional | No iniciado | 0 / 7 | — | — |
| M8 · Calidad y mantenimiento | No iniciado | 0 / 8 | — | P4 |
| M9 · Desarrollo web con ASP.NET Core | No iniciado | 0 / 12 | — | P5 |
| M10 · Proyectos integradores | No iniciado | — | — | P6 |
| M11 · Preparación laboral | No iniciado | 0 / 7 | — | — |

## Puertas de avance

| Puerta | Semana | Estado |
|---|---|---|
| 1 · Módulo 1 + P1 | 4 | Pendiente |
| 2 · Módulo 2 | 6 | Pendiente |
| 3 · Módulo 3 + P2 | 9 | Pendiente |
| 4 · Módulo 4 | 11 | Pendiente |
| 5 · Módulo 5 | 14 | Pendiente |
| 6 · Módulo 6 + P3 | 17 | Pendiente |
| 7 · Módulo 7 | 18 | Pendiente |
| 8 · Módulo 8 + P4 | 20 | Pendiente |
| 9 · Módulo 9 + P5 | 23 | Pendiente |
| Final · P6 | 26 | Pendiente |

---

## Registro por tema

Los detalles viven en archivos específicos:

| Qué | Dónde |
|---|---|
| Estado estructurado (unidades, ejercicios, evaluaciones, competencias, proyectos) | [progreso/progreso.json](progreso/progreso.json) |
| Competencias y su evidencia | [progreso/competencias.md](progreso/competencias.md) |
| Resultados de evaluaciones | [progreso/evaluaciones.md](progreso/evaluaciones.md) |
| Errores recurrentes | [progreso/errores-recurrentes.md](progreso/errores-recurrentes.md) |
| Repasos programados | [progreso/repasos.md](progreso/repasos.md) |
| Bitácora de sesiones | [progreso/bitacora/](progreso/bitacora/README.md) |

## Temas pendientes de repaso

*(ninguno todavía)*

## Últimas sesiones

| Fecha | Sesión | Resumen | Bitácora |
|---|---|---|---|
| 2026-10-14 | 0 | Construcción del sistema de formación; ronda rápida del diagnóstico planteada | [sesión 00](progreso/bitacora/2026-10-14_sesion-00.md) |

---

## Cómo se actualiza este archivo

1. Al **cerrar cada sesión**: se añade una fila a *Últimas sesiones*, se actualiza *Estado actual* y *Próxima actividad*, y se escribe la bitácora.
2. Al **resolver una evaluación**: se añade la fila en `progreso/evaluaciones.md`, se actualiza `progreso.json` y las competencias afectadas.
3. Los contadores (unidades, competencias, proyectos) se calculan desde `progreso.json`; si no coinciden, manda el JSON y se corrige este archivo.
4. Nunca se marca algo como dominado "porque parece que ya lo sabes". Se necesita una evaluación o una evidencia concreta.
