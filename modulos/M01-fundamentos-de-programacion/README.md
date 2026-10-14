# Módulo 1 · Fundamentos de programación

> **Semanas:** 1–4 · **Fase:** A · Fundamentos · [Plan de estudio](../../PLAN_DE_ESTUDIO.md) · [Índice](../../INDICE.md) · [Calendario](../../CALENDARIO.md)

## Objetivo

Dominar los bloques con los que se construye cualquier programa: variables y tipos, entrada y salida, decisiones, repetición, métodos, colecciones y cadenas, y aprender a razonar sobre ellos con pseudocódigo, trazas y depuración.

## Por qué importa

Todo lo demás (POO, bases de datos, web) se construye con estas piezas. Un fallo aquí se arrastra y se vuelve cada vez más caro. Se estudia despacio, con muchos ejercicios y con evaluaciones sin apuntes.

## Requisitos previos

Módulo 0 dominado (en particular: crear/ejecutar un proyecto, leer errores, depurador básico, Git mínimo).

## Competencias de salida

Estas competencias se registran en [progreso/competencias.md](../../progreso/competencias.md) y solo se marcan como *demostradas* con evidencia (programa, evaluación o defensa).

| Código | Al terminar el módulo… |
|---|---|
| M1-C1 | Elijo el tipo de dato adecuado para cada valor y justifico la elección. |
| M1-C2 | Leo datos por consola y presento resultados con formato claro. |
| M1-C3 | Convierto y valido entradas con TryParse sin que el programa se caiga. |
| M1-C4 | Escribo condiciones correctas (if, else, switch) incluyendo los casos límite. |
| M1-C5 | Escribo bucles con condición de parada correcta, sin errores de uno de más o de menos. |
| M1-C6 | Descompongo un programa en métodos con parámetros y retorno bien elegidos. |
| M1-C7 | Manipulo arrays, listas y cadenas sin salirme de rango. |
| M1-C8 | Trazo a mano un programa con una tabla de seguimiento y predigo su salida. |
| M1-C9 | Traduzco entre pseudocódigo o diagrama de flujo y C#. |

## Unidades

<!-- AUTO:UNIDADES:INICIO -->
| Unidad | Sem. | Qué cubre | Lección | Retos | Soluciones |
|---|---|---|---|---|---|
| 1.1 Variables, constantes y tipos de datos | 1 | declaración y asignación; int, long, double, decimal, bool, char, string; const y var; interpolación de cadenas; valores por defecto | [lección](01.01-variables-y-tipos.md) | [retos](retos/01.01-variables-y-tipos-retos.md) | [soluciones](../../soluciones/M01-fundamentos-de-programacion/01.01-variables-y-tipos-soluciones.md) |
| 1.2 Entrada y salida por consola | 2 | Console.WriteLine/Write/ReadLine; secuencias de escape; formato numérico y cultura; diseño de la interacción con el usuario | ⏳ | ⏳ | ⏳ |
| 1.3 Operadores aritméticos, relacionales y lógicos | 2 | división entera y resto; comparaciones; &&, || y !; precedencia; asignación compuesta, ++ y -- | ⏳ | ⏳ | ⏳ |
| 1.4 Conversión y validación de datos | 2 | conversión implícita y explícita; Parse y TryParse; rangos y entradas vacías; desbordamiento | ⏳ | ⏳ | ⏳ |
| 1.5 Condicionales: if y else | 2 | if / else if / else; condiciones compuestas; anidamiento y simplificación; operador condicional | ⏳ | ⏳ | ⏳ |
| 1.6 Condicionales: switch y expresiones switch | 2 | switch clásico y break; expresión switch; patrones relacionales simples; cuándo usar switch o if | ⏳ | ⏳ | ⏳ |
| 1.7 Bucles: while y do-while | 3 | condición de parada; centinelas y acumuladores; bucles infinitos; reintentar una entrada hasta que sea válida | ⏳ | ⏳ | ⏳ |
| 1.8 Bucles: for, foreach y bucles anidados | 3 | contadores; break y continue; bucles anidados; errores de uno de más o de menos | ⏳ | ⏳ | ⏳ |
| 1.9 Métodos, parámetros y valores de retorno | 3 | declarar y llamar métodos; void y retorno; parámetros; sobrecarga; nombrado de métodos | ⏳ | ⏳ | ⏳ |
| 1.10 Ámbito de las variables y diseño con métodos | 3 | ámbito de bloque y de método; parámetros por valor; descomponer un programa; evitar efectos ocultos | ⏳ | ⏳ | ⏳ |
| 1.11 Arrays | 4 | declaración e inicialización; índices y límites; recorrido; matrices bidimensionales (introducción) | ⏳ | ⏳ | ⏳ |
| 1.12 Listas (List<T>) | 4 | Add, Remove, Contains, Count; recorrer y modificar; array frente a lista; buscar elementos | ⏳ | ⏳ | ⏳ |
| 1.13 Cadenas de texto | 4 | inmutabilidad; Length, Substring, IndexOf, Split, Trim, Replace; comparar y normalizar; char y recorrido de cadenas; StringBuilder (introducción) | ⏳ | ⏳ | ⏳ |
| 1.14 Pseudocódigo y diagramas de flujo | 3 | notación de pseudocódigo; diagramas de flujo; traducir a C#; tablas de seguimiento | ⏳ | ⏳ | ⏳ |
| 1.15 Depuración y lectura de código | 4 | leer código ajeno; trazar y predecir; depurar errores deliberados; hipótesis y verificación | ⏳ | ⏳ | ⏳ |
<!-- AUTO:UNIDADES:FIN -->

Cada unidad sigue la [plantilla de lección](../../plantillas/leccion.md) de quince secciones y tiene un archivo de retos de cuatro niveles en `retos/` y soluciones separadas en [`soluciones/M01-fundamentos-de-programacion/`](../../soluciones/M01-fundamentos-de-programacion/).

## Cómo se trabaja este módulo

Cada unidad: explicación corta, ejemplos verificados, retos de cuatro niveles y una evaluación semanal. Se predice antes de ejecutar y se traza a mano. Los ejercicios se revisan con tablas de pruebas, no con "parece que funciona".

## Errores típicos de este módulo

División entera · errores de uno de más o de uno de menos en bucles · `=` frente a `==` · no validar entradas · bucles que no terminan · mezclar texto y números · modificar una colección mientras se recorre.

## Proyecto asociado

**P1 · Colección de programas de consola** (semana 4): 5–6 programas pequeños integrados en un menú, con README y tabla de pruebas.

## Evaluación y puerta de avance

Evaluación semanal en cada S6 y **evaluación del módulo** (semana 4, rúbrica C) con defensa de P1. **Puerta 1.**

Criterios y reglas esenciales: [evaluaciones/RUBRICAS.md](../../evaluaciones/RUBRICAS.md). Puertas: [PLAN_DE_ESTUDIO.md, sección 5](../../PLAN_DE_ESTUDIO.md#5-puertas-de-avance).

## Recursos

Tour de C# y documentación del lenguaje (Microsoft Learn); documentación de `System.Console`, `System.String`, `List<T>` y `Array`. Estado de verificación de enlaces: [recursos/ENLACES.md](../../recursos/ENLACES.md).
