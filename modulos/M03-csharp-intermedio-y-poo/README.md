# Módulo 3 · C# intermedio y programación orientada a objetos

> **Semanas:** 7–9 · **Fase:** B · POO y estructuras · [Plan de estudio](../../PLAN_DE_ESTUDIO.md) · [Índice](../../INDICE.md) · [Calendario](../../CALENDARIO.md)

## Objetivo

Modelar problemas con clases y objetos, aplicar encapsulación, composición, interfaces y herencia con criterio, usar colecciones genéricas y LINQ básico, manejar excepciones y organizar el código con buenas prácticas.

## Por qué importa

Es el modelo con el que está escrito casi todo el C# profesional y el que ya viste en tu proyecto anterior. Aquí pasas de *usar* clases ajenas a *diseñar* las tuyas y a poder explicar por qué.

## Requisitos previos

Módulos 1 y 2 dominados.

## Competencias de salida

Estas competencias se registran en [progreso/competencias.md](../../progreso/competencias.md) y solo se marcan como *demostradas* con evidencia (programa, evaluación o defensa).

| Código | Al terminar el módulo… |
|---|---|
| M3-C1 | Modelo las entidades de un problema como clases con estado y comportamiento. |
| M3-C2 | Aplico encapsulación: propiedades y constructores que impiden objetos inválidos. |
| M3-C3 | Relaciono objetos mediante composición e interfaces. |
| M3-C4 | Uso herencia y polimorfismo cuando corresponde y reconozco cuándo evitarlos. |
| M3-C5 | Elijo entre enum, struct, record y clase y explico valor frente a referencia. |
| M3-C6 | Uso colecciones genéricas y LINQ básico para consultar datos. |
| M3-C7 | Manejo excepciones con criterio: qué capturar, qué lanzar y qué dejar subir. |
| M3-C8 | Organizo el código en archivos y espacios de nombres y aplico SOLID sin sobreingeniería. |

## Unidades

<!-- AUTO:UNIDADES:INICIO -->
| Unidad | Sem. | Qué cubre | Lección | Retos | Soluciones |
|---|---|---|---|---|---|
| 3.1 Clases y objetos | 7 | clase frente a objeto; campos y métodos; new y referencias; modelar una entidad | ⏳ | ⏳ | ⏳ |
| 3.2 Propiedades, constructores y encapsulación | 7 | propiedades; constructores; invariantes y objetos válidos; private, public e init | ⏳ | ⏳ | ⏳ |
| 3.3 Miembros estáticos, archivos y espacios de nombres | 7 | static; un tipo por archivo; namespaces y using; organizar un proyecto | ⏳ | ⏳ | ⏳ |
| 3.4 Composición y relaciones entre objetos | 7 | tiene-un frente a es-un; objetos que contienen objetos; responsabilidades; diagramas de clases sencillos | ⏳ | ⏳ | ⏳ |
| 3.5 Interfaces | 8 | contrato frente a implementación; implementar varias interfaces; programar contra la interfaz; cuándo una interfaz sobra | ⏳ | ⏳ | ⏳ |
| 3.6 Herencia y polimorfismo | 8 | clase base y derivada; virtual y override; clases abstractas; herencia frente a composición | ⏳ | ⏳ | ⏳ |
| 3.7 Enums, structs, records y tipos por valor y por referencia | 8 | enum; struct frente a class; record; copia por valor y por referencia; null y nullabilidad | ⏳ | ⏳ | ⏳ |
| 3.8 Colecciones genéricas y genéricos propios | 8 | List, Dictionary, HashSet, Queue, Stack; inicializadores; métodos genéricos; clases genéricas sencillas | ⏳ | ⏳ | ⏳ |
| 3.9 Manejo de excepciones | 8 | try, catch, finally; lanzar excepciones propias; qué capturar y qué no; validar frente a capturar | ⏳ | ⏳ | ⏳ |
| 3.10 Buenas prácticas y SOLID con ejemplos | 9 | responsabilidad única; abierto y cerrado; dependencias; cuándo una abstracción ayuda y cuándo complica | ⏳ | ⏳ | ⏳ |
| 3.11 LINQ esencial | 9 | Where, Select, OrderBy; Any, Count, First, Sum; GroupBy (introducción); ejecución diferida | ⏳ | ⏳ | ⏳ |
<!-- AUTO:UNIDADES:FIN -->

Cada unidad seguirá la [plantilla de lección](../../plantillas/leccion.md) de quince secciones, con un archivo de retos de cuatro niveles en `retos/` y soluciones separadas en `soluciones/M03-csharp-intermedio-y-poo/` (se crean al desarrollar el módulo; protocolo en [soluciones/README.md](../../soluciones/README.md)).

## Cómo se trabaja este módulo

Se construye una pequeña aplicación de registros a lo largo del módulo. Se enseña también cuándo **no** abstraer. Desde aquí algunos retos incluyen pruebas automáticas con xUnit para verificar tu código sin que yo lo ejecute.

## Errores típicos de este módulo

Clases que lo hacen todo · campos públicos · herencia por comodidad · abstracciones que nadie pidió · capturar excepciones y no hacer nada · modificar objetos compartidos sin darse cuenta.

## Proyecto asociado

**P2 · Aplicación de gestión de registros** (semana 9): consola, con clases, colecciones, validación y persistencia sencilla en archivo.

## Evaluación y puerta de avance

Evaluaciones de las semanas 7 y 8 + **evaluación del módulo** (semana 9) con defensa de P2. **Puerta 3.**

Criterios y reglas esenciales: [evaluaciones/RUBRICAS.md](../../evaluaciones/RUBRICAS.md). Puertas: [PLAN_DE_ESTUDIO.md, sección 5](../../PLAN_DE_ESTUDIO.md#5-puertas-de-avance).

## Recursos

Guía de C# (clases, interfaces, genéricos, LINQ, excepciones) en Microsoft Learn. Estado de verificación de enlaces: [recursos/ENLACES.md](../../recursos/ENLACES.md).
