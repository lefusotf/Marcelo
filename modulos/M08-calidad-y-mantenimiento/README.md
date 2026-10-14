# Módulo 8 · Calidad y mantenimiento del software

> **Semanas:** 19–20 · **Fase:** D · Oficio profesional · [Plan de estudio](../../PLAN_DE_ESTUDIO.md) · [Índice](../../INDICE.md) · [Calendario](../../CALENDARIO.md)

## Objetivo

Escribir pruebas útiles, refactorizar con red de seguridad, estructurar la aplicación en capas con inyección de dependencias, registrar y diagnosticar errores, aplicar seguridad básica y mantener código existente.

## Por qué importa

La diferencia entre un programa que funciona y uno que se puede mantener. Aquí usas tu proyecto anterior como caso real de código heredado.

## Requisitos previos

Módulos 6 y 7.

## Competencias de salida

Estas competencias se registran en [progreso/competencias.md](../../progreso/competencias.md) y solo se marcan como *demostradas* con evidencia (programa, evaluación o defensa).

| Código | Al terminar el módulo… |
|---|---|
| M8-C1 | Escribo pruebas unitarias significativas (AAA, casos límite) con xUnit. |
| M8-C2 | Derivo casos de prueba a partir de criterios de aceptación. |
| M8-C3 | Refactorizo con una red de seguridad de pruebas. |
| M8-C4 | Estructuro una aplicación en capas con inyección de dependencias. |
| M8-C5 | Añado registros útiles y diagnostico fallos con ellos. |
| M8-C6 | Aplico seguridad básica: valido entradas, protejo secretos y datos sensibles. |
| M8-C7 | Mantengo una aplicación existente: leo, entiendo, corrijo y amplío sin romperla. |

## Unidades

<!-- AUTO:UNIDADES:INICIO -->
| Unidad | Sem. | Qué cubre | Lección | Retos | Soluciones |
|---|---|---|---|---|---|
| 8.1 Pruebas unitarias con xUnit | 19 | Arrange, Act, Assert; Fact y Theory; qué probar y qué no; nombres de pruebas | ⏳ | ⏳ | ⏳ |
| 8.2 Casos de prueba, criterios de aceptación y pruebas de integración | 19 | criterios de aceptación; derivar casos de prueba; pruebas de integración; datos de prueba | ⏳ | ⏳ | ⏳ |
| 8.3 Refactorización, duplicación y complejidad innecesaria | 19 | olores de código; extraer método; eliminar duplicación; refactorizar con pruebas | ⏳ | ⏳ | ⏳ |
| 8.4 Arquitectura por capas y SOLID sin dogmatismo | 19 | capas y responsabilidades; dependencias hacia adentro; SOLID aplicado; sobreingeniería | ⏳ | ⏳ | ⏳ |
| 8.5 Inyección de dependencias | 20 | acoplamiento; inyección por constructor; contenedor de .NET; dobles de prueba | ⏳ | ⏳ | ⏳ |
| 8.6 Logging y diagnóstico de errores | 20 | niveles de registro; ILogger; qué registrar y qué no; diagnosticar un fallo desde los registros | ⏳ | ⏳ | ⏳ |
| 8.7 Seguridad básica y validación de entradas | 20 | no confiar en la entrada; secretos y datos sensibles; errores que filtran información; dependencias | ⏳ | ⏳ | ⏳ |
| 8.8 Mantenimiento de aplicaciones existentes | 20 | entender antes de tocar; pruebas de caracterización; cambios pequeños y seguros; deuda técnica | ⏳ | ⏳ | ⏳ |
<!-- AUTO:UNIDADES:FIN -->

Cada unidad seguirá la [plantilla de lección](../../plantillas/leccion.md) de quince secciones, con un archivo de retos de cuatro niveles en `retos/` y soluciones separadas en `soluciones/M08-calidad-y-mantenimiento/` (se crean al desarrollar el módulo; protocolo en [soluciones/README.md](../../soluciones/README.md)).

## Cómo se trabaja este módulo

Se aprende refactorizar **después** de tener pruebas. Se enseña SOLID sin dogmatismo y se nombran los casos en que una abstracción sobra.

## Errores típicos de este módulo

Pruebas que prueban la implementación · mocks para todo · capas por decorado · refactorizar sin pruebas · registrar datos sensibles · confiar en la entrada del usuario.

## Proyecto asociado

**P4 · Aplicación estructurada con responsabilidades separadas** (semana 20): evolución de P3 con capas, DI, pruebas y logging.

## Evaluación y puerta de avance

Evaluaciones semanales + **evaluación del módulo** con defensa de P4. **Puerta 8.**

Criterios y reglas esenciales: [evaluaciones/RUBRICAS.md](../../evaluaciones/RUBRICAS.md). Puertas: [PLAN_DE_ESTUDIO.md, sección 5](../../PLAN_DE_ESTUDIO.md#5-puertas-de-avance).

## Recursos

Documentación de xUnit, de inyección de dependencias en .NET y de `ILogger` (Microsoft Learn). Estado de verificación de enlaces: [recursos/ENLACES.md](../../recursos/ENLACES.md).
