# Módulo 4 · Estructuras de datos y fundamentos de algoritmos

> **Semanas:** 10–11 · **Fase:** B · POO y estructuras · [Plan de estudio](../../PLAN_DE_ESTUDIO.md) · [Índice](../../INDICE.md) · [Calendario](../../CALENDARIO.md)

## Objetivo

Entender cómo funcionan por dentro las estructuras de datos habituales, elegir la adecuada con criterios de coste, y dominar búsqueda, ordenamiento, recursividad y el razonamiento intuitivo con Big O.

## Por qué importa

Es la base de las entrevistas técnicas y de escribir código que no se arrastra cuando los datos crecen. También cambia cómo lees el código ajeno.

## Requisitos previos

Módulo 3 dominado (en especial colecciones genéricas y LINQ).

## Competencias de salida

Estas competencias se registran en [progreso/competencias.md](../../progreso/competencias.md) y solo se marcan como *demostradas* con evidencia (programa, evaluación o defensa).

| Código | Al terminar el módulo… |
|---|---|
| M4-C1 | Elijo entre array, lista, diccionario, conjunto, pila y cola justificando los costos. |
| M4-C2 | Implemento búsqueda lineal y binaria y sé cuándo aplica cada una. |
| M4-C3 | Implemento y trazo al menos dos algoritmos de ordenamiento. |
| M4-C4 | Escribo funciones recursivas con caso base correcto. |
| M4-C5 | Estimo e interpreto la complejidad (Big O) de un fragmento de código. |

## Unidades

<!-- AUTO:UNIDADES:INICIO -->
| Unidad | Sem. | Qué cubre | Lección | Retos | Soluciones |
|---|---|---|---|---|---|
| 4.1 Arrays y listas por dentro | 10 | memoria contigua; redimensionamiento de List; costo de insertar, buscar y borrar; medir en vez de suponer | ⏳ | ⏳ | ⏳ |
| 4.2 Diccionarios y conjuntos | 10 | clave y valor; idea de tabla hash; HashSet; colisiones a nivel intuitivo | ⏳ | ⏳ | ⏳ |
| 4.3 Pilas y colas | 10 | LIFO y FIFO; Stack<T> y Queue<T>; problemas típicos (paréntesis balanceados, turnos); elegir pila o cola | ⏳ | ⏳ | ⏳ |
| 4.4 Búsqueda lineal y binaria | 10 | búsqueda lineal; búsqueda binaria; precondición: datos ordenados; errores de límites | ⏳ | ⏳ | ⏳ |
| 4.5 Ordenamiento básico | 10 | selección; inserción; burbuja; trazar un ordenamiento | ⏳ | ⏳ | ⏳ |
| 4.6 Ordenamiento eficiente y ordenamiento de la biblioteca | 11 | idea de dividir y combinar; Array.Sort y OrderBy; comparadores; estabilidad | ⏳ | ⏳ | ⏳ |
| 4.7 Recursividad básica | 11 | caso base y caso recursivo; la pila de llamadas; recursión frente a iteración; desbordamiento de pila | ⏳ | ⏳ | ⏳ |
| 4.8 Big O e intuición de complejidad | 11 | O(1), O(log n), O(n), O(n log n), O(n²); analizar un fragmento; mejor, promedio y peor caso; complejidad de espacio | ⏳ | ⏳ | ⏳ |
| 4.9 Elegir la estructura según el problema | 11 | criterios de elección; problemas progresivos de razonamiento; justificar con costos; contraejemplos | ⏳ | ⏳ | ⏳ |
<!-- AUTO:UNIDADES:FIN -->

Cada unidad seguirá la [plantilla de lección](../../plantillas/leccion.md) de quince secciones, con un archivo de retos de cuatro niveles en `retos/` y soluciones separadas en `soluciones/M04-estructuras-de-datos-y-algoritmos/` (se crean al desarrollar el módulo; protocolo en [soluciones/README.md](../../soluciones/README.md)).

## Cómo se trabaja este módulo

Se implementan algoritmos a mano antes de usar la biblioteca estándar, y después se compara con ella. Se **mide** en vez de suponer.

## Errores típicos de este módulo

Elegir una lista por costumbre · búsqueda binaria sobre datos sin ordenar · recursión sin caso base · confundir complejidad con tiempo medido · optimizar sin medir.

## Proyecto asociado

Sin proyecto propio; un reto integrador compara estrategias con datos medidos.

## Evaluación y puerta de avance

Evaluación semanal + sesión de construcción sin IA (semana 11) + **evaluación del módulo**. **Puerta 4.**

Criterios y reglas esenciales: [evaluaciones/RUBRICAS.md](../../evaluaciones/RUBRICAS.md). Puertas: [PLAN_DE_ESTUDIO.md, sección 5](../../PLAN_DE_ESTUDIO.md#5-puertas-de-avance).

## Recursos

Documentación de `System.Collections.Generic`; lecturas de complejidad algorítmica en fuentes reconocidas (se anotarán como tales). Estado de verificación de enlaces: [recursos/ENLACES.md](../../recursos/ENLACES.md).
