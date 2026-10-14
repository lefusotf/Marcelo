# Solucionario y hoja de calificación · Evaluación de la semana 1 (variante A)

> **No abrir antes de entregar la evaluación.** Todo el código y las salidas de este archivo se verificaron con .NET SDK 10 (`herramientas/verificar_codigo.py`).
>
> Enunciado: [evaluaciones/semana-01/EVALUACION_SEMANA_01.md](../../../evaluaciones/semana-01/EVALUACION_SEMANA_01.md) · Rúbrica: [RUBRICAS.md](../../../evaluaciones/RUBRICAS.md)

---

## Bloque 1 · Conceptuales (2 puntos cada una: 2 = correcta y razonada · 1 = parcial · 0 = incorrecta)

1. **Recorrido.** Código fuente (`.cs`) → el **compilador** (Roslyn) valida sintaxis y tipos y genera **IL** en un **ensamblado** (`.dll`) → al ejecutar, el **CLR** carga el ensamblado y el **JIT** traduce el IL a **código de máquina** → la CPU lo ejecuta. 2 puntos si nombra compilador, IL/ensamblado y JIT/CLR en orden; 1 si confunde compilar con ejecutar.
2. **`decimal` frente a `double`.** `double` guarda aproximaciones binarias: `0.1 + 0.2` da `0.30000000000000004` y `== 0.3` es `False`. `decimal` guarda base 10: `0.1m + 0.2m == 0.3m` es `True`. Para dinero se exige exactitud.
3. **Compilación frente a lógico.** El de compilación **impide** generar el programa y lo detecta el compilador (ej.: falta `;`, `CS1002`). El lógico **corre sin quejarse pero da un resultado equivocado** y solo se detecta comparando con lo esperado (ej.: sumar en vez de multiplicar).
4. **`git add` / `git commit`.** `add` prepara cambios en el área de preparación; `commit` guarda una instantánea con ese contenido preparado y un mensaje.
5. **`CS0103`.** *El nombre no existe en el contexto actual* (variable mal escrita, sin declarar o fuera de ámbito, o `console` con minúscula). Se busca por el código `CS0103` en la documentación oficial de Microsoft (Learn).

---

## Bloque 2 · Predicción (3 puntos cada una: se reparten por línea de salida correcta; el tipo de excepción en P4 vale 1)

**P1**

<!--v
modo: ejecuta
salida: siguiente
-->
```csharp
int a = 17;
int b = 5;
Console.WriteLine(a / b);
Console.WriteLine(a / (double)b);
```

```text
3
3.4
```

**P2**

<!--v
modo: ejecuta
salida: siguiente
-->
```csharp
int x = 4;
x = x * 2;
x = x - 3;
Console.WriteLine(x);
Console.WriteLine("x" + x);
Console.WriteLine(x + x);
```

```text
5
x5
10
```

**P3**

<!--v
modo: ejecuta
salida: siguiente
-->
```csharp
decimal p = 0.1m;
double q = 0.1;
Console.WriteLine(p * 3);
Console.WriteLine(q * 3);
```

```text
0.3
0.30000000000000004
```

**P4** · Se muestra `Inicio` y el programa se cae en la línea 3 (`Console.WriteLine(12 / d);`) con `DivideByZeroException`; `Fin` **no** se muestra.

<!--v
modo: excepcion DivideByZeroException
salida: siguiente
-->
```csharp
Console.WriteLine("Inicio");
int d = 0;
Console.WriteLine(12 / d);
Console.WriteLine("Fin");
```

```text
Inicio
```

**P5**

<!--v
modo: ejecuta
salida: siguiente
-->
```csharp
const int Max = 3;
int a = Max + 1;
string s = "Nivel " + a;
Console.WriteLine(s);
Console.WriteLine($"{Max}{a}");
```

```text
Nivel 4
34
```

---

## Bloque 3 · Lectura y explicación (5 puntos cada una)

**L1.** Reparto: 2 puntos por explicar las seis líneas con sentido, 2 por la salida, 1 por señalar el propósito de `const` y de `F2`.

<!--v
modo: ejecuta
salida: siguiente
-->
```csharp
const decimal Iva = 0.13m;
decimal precio = 40.00m;
decimal impuesto = precio * Iva;
decimal total = precio + impuesto;
Console.WriteLine($"Impuesto: {impuesto:F2}");
Console.WriteLine($"Total: {total:F2}");
```

```text
Impuesto: 5.20
Total: 45.20
```

Explicación esperada: se define el IVA como constante decimal (no cambia); se guarda un precio; el impuesto es precio × IVA; el total suma ambos; se muestran con dos decimales.

**L2.** Reparto: 1 punto por archivo y línea (`Program.cs`, línea 7, columna 12); 2 por el significado (se intenta guardar un `double` en un `int`, y eso pierde información); 2 por las dos correcciones: (1) **convertir explícitamente** con `(int)` si se acepta truncar; (2) **cambiar el tipo** de la variable de destino a `double` (o `decimal` si es dinero).

---

## Bloque 4 · Corrección de errores (5 puntos cada uno: tipo 1 · causa 2 · corrección 2)

**C1 · Compilación (`CS0664`).** `19.99` es `double`; falta el sufijo `m`. Corrección: `19.99m`.

<!--v
modo: error CS0664
-->
```csharp
decimal precio = 19.99;
int unidades = 3;
Console.WriteLine(precio * unidades);
```

<!--v
modo: ejecuta
salida: siguiente
-->
```csharp
decimal precio = 19.99m;
int unidades = 3;
Console.WriteLine(precio * unidades);
```

```text
59.97
```

**C2 · Ejecución (`DivideByZeroException`).** El divisor `personas` vale `0` (el dato inicial es incorrecto: el grupo es de 4). Corrección: `int personas = 4;`. (Se acepta también mencionar que, en un programa real, convendría comprobar el divisor antes de dividir.)

<!--v
modo: excepcion DivideByZeroException
-->
```csharp
int total = 120;
int personas = 0;
int porPersona = total / personas;
Console.WriteLine(porPersona);
```

<!--v
modo: ejecuta
salida: siguiente
-->
```csharp
int total = 120;
int personas = 4;
int porPersona = total / personas;
Console.WriteLine(porPersona);
```

```text
30
```

**C3 · Lógico.** `(nota1 + nota2) / 2` es una división entera (17 ÷ 2 = 8) y *después* se guarda en un `double`. Corrección: dividir entre `2.0` o convertir un operando a `double`.

<!--v
modo: ejecuta
salida: siguiente
-->
```csharp
int nota1 = 9;
int nota2 = 8;
double promedio = (nota1 + nota2) / 2;
Console.WriteLine(promedio);
```

```text
8
```

<!--v
modo: ejecuta
salida: siguiente
-->
```csharp
int nota1 = 9;
int nota2 = 8;
double promedio = (nota1 + nota2) / 2.0;
Console.WriteLine(promedio);
```

```text
8.5
```

---

## Bloque 5 · Modificación (10 puntos: 4 funcional · 3 tipos y constante · 3 calidad)

<!--v
modo: ejecuta
salida: siguiente
-->
```csharp
const decimal PorcentajeDescuento = 0.10m;

decimal precio = 25.00m;
int cantidad = 2;
decimal total = precio * cantidad;
decimal descuento = total * PorcentajeDescuento;
decimal aPagar = total - descuento;

Console.WriteLine($"Total: {total:F2}");
Console.WriteLine($"Descuento: {descuento:F2}");
Console.WriteLine($"A pagar: {aPagar:F2}");
```

```text
Total: 50.00
Descuento: 5.00
A pagar: 45.00
```

Penalizaciones habituales: `0.10` sin `m` (`CS0664`); porcentaje escrito a mano en la fórmula; nombre de la constante y de la variable iguales salvo mayúsculas (legal pero confuso).

---

## Bloque 6 · Programación desde cero (30 puntos)

**Solución de referencia**

<!--v
modo: ejecuta
salida: siguiente
-->
```csharp
const int SegundosPorHora = 3600;
const int SegundosPorMinuto = 60;

int segundosTotales = 3725;

int horas = segundosTotales / SegundosPorHora;
int restoTrasHoras = segundosTotales - horas * SegundosPorHora;
int minutos = restoTrasHoras / SegundosPorMinuto;
int segundos = restoTrasHoras - minutos * SegundosPorMinuto;

Console.WriteLine($"Duración: {segundosTotales} segundos");
Console.WriteLine($"Equivale a {horas} h {minutos} min {segundos} s");
```

```text
Duración: 3725 segundos
Equivale a 1 h 2 min 5 s
```

**Traza con 3725**

| Paso | Cálculo | Valor |
|---|---|---|
| `horas` | 3725 ÷ 3600 (entera) | 1 |
| `restoTrasHoras` | 3725 − 1 × 3600 | 125 |
| `minutos` | 125 ÷ 60 (entera) | 2 |
| `segundos` | 125 − 2 × 60 | 5 |

**Versión de prueba con lectura** (para comprobar los seis casos de una vez; la entrada es solo para probar):

<!--v
modo: ejecuta
caso: 3725 => Equivale a 1 h 2 min 5 s
caso: 59 => Equivale a 0 h 0 min 59 s
caso: 60 => Equivale a 0 h 1 min 0 s
caso: 3600 => Equivale a 1 h 0 min 0 s
caso: 0 => Equivale a 0 h 0 min 0 s
caso: 86399 => Equivale a 23 h 59 min 59 s
-->
```csharp
const int SegundosPorHora = 3600;
const int SegundosPorMinuto = 60;

int segundosTotales = int.Parse(Console.ReadLine() ?? "0");

int horas = segundosTotales / SegundosPorHora;
int restoTrasHoras = segundosTotales - horas * SegundosPorHora;
int minutos = restoTrasHoras / SegundosPorMinuto;
int segundos = restoTrasHoras - minutos * SegundosPorMinuto;

Console.WriteLine($"Duración: {segundosTotales} segundos");
Console.WriteLine($"Equivale a {horas} h {minutos} min {segundos} s");
```

**Alternativa válida** con el operador `%` (resto): `segundos = segundosTotales % 60;` y `minutos = (segundosTotales % 3600) / 60;`. Compara: la versión con resta explicita cada paso; la de `%` es más corta.

**Calificación del bloque (30 puntos)**

| Subcriterio | Puntos | Qué se mira |
|---|---|---|
| Funciona con las entradas normales | 14 | `3725` produce la salida exacta; usa división y resto correctos. |
| Casos límite | 8 | Los seis casos de la tabla. Se asignan puntos por caso correcto y anotado (los fallos típicos: `59`, `3600` y `0`). |
| Diseño, nombres y legibilidad | 5 | `SegundosPorHora` / `SegundosPorMinuto` como constantes con nombre; sin números mágicos; nombres claros. |
| Razonamiento previo | 3 | Plan escrito de 3–4 líneas y traza con 3725 **antes** de programar. |

**Errores frecuentes:** escribir 3600 y 60 sueltos; dividir entre 60 para obtener horas; mostrar `1 h 62 min` (olvidar restar las horas ya contadas); resultados negativos o incorrectos en 59 y 60.

**Regla esencial:** este bloque debe alcanzar **21 de 30** (70 %) y el programa debe **funcionar** con las entradas normales, aunque el total de la evaluación sea ≥ 80.

---

## Bloque 7 · Defensa técnica (10 puntos: 4 preguntas × 2,5)

Respuestas esperadas:

1. **¿Por qué `int`?** Los segundos de un día caben de sobra en `int` (hasta ~2 147 millones). Con `5000000000` el literal es `long` y **no compila** (`CS0266`: no hay conversión implícita de `long` a `int`); habría que cambiar el tipo a `long`.
2. **¿Cómo comprobaste 3600 y 59?** Ejecutando con esos datos y comparando con el valor calculado a mano; con tabla de pruebas.
3. **Punto de interrupción.** En la línea que calcula `minutos`; ventana de variables locales (o inspección): se ve `restoTrasHoras` antes de dividir. `F10` para avanzar línea a línea.
4. **Añadir días.** Una constante `SegundosPorDia = 86400`, `dias = segundosTotales / SegundosPorDia`, el resto pasa a la cuenta de horas, y la salida se amplía. El diseño por restos sucesivos escala bien.

Escala de la defensa: **alto** (explica y justifica sin leer, anticipa límites) 9–10 · **medio** (explica lo que hace, necesita ayuda con los "¿qué pasa si?") 6–8 · **bajo** (lee el código sin explicar) 0–5. **Regla esencial: ≥ 6.**

---

## Hoja de calificación

| Bloque | Máx. | Obtenido | Regla esencial | ¿Cumple? |
|---|---|---|---|---|
| 1 · Conceptuales | 10 | | — | — |
| 2 · Predicción | 15 | | ≥ 7,5 | |
| 3 · Lectura | 10 | | — | — |
| 4 · Corrección | 15 | | ≥ 7,5 | |
| 5 · Modificación | 10 | | — | — |
| 6 · Programación desde cero | 30 | | ≥ 21 y funciona | |
| 7 · Defensa | 10 | | ≥ 6 | |
| **Total** | **100** | | **≥ 80** | |

**Resultado:** ☐ Aprobada (dominio) ☐ Pendiente de recuperación en: ____________ (competencias `M0-C?`, `M1-C?`) ☐ Interrumpida ☐ No válida.

**Mapa de competencias que esta evaluación aporta como evidencia**

| Competencia | Dónde se observa |
|---|---|
| M0-C1 (recorrido y tipos de error) | Bloque 1 (pregunta 1 y 3) y Bloque 4 (tipo de error) |
| M0-C4 (leer un error) | Bloque 3 (L2) y Bloque 4 |
| M0-C5 (depurador) | Bloque 7 (pregunta 3) |
| M0-C6 (Git) | Bloque 1 (pregunta 4) |
| M1-C1 (elegir tipos) | Bloque 1 (pregunta 2), Bloque 2 (P3) y Bloque 4 (C1) |
| M1-C8 (trazar a mano) | Bloque 2 y la traza escrita del Bloque 6 |

M0-C2 (crear y ejecutar un proyecto) y M0-C3 (terminal) **no** se evalúan con este examen: su evidencia son los retos R-0.2 y R-0.3 y el propio Bloque 6, que se ejecuta en un proyecto creado por ti. M1-C2 y las demás de M1 se evidencian en las semanas siguientes.
