# Evaluación de la semana 1 · Variante B (para recuperación)

> **NO ABRIR antes de que el examinador lo indique.** Esta variante se usa cuando la variante A no alcanzó el criterio de dominio o falló una competencia esencial. Son **problemas distintos** (no el mismo con otros números), mismas reglas: sin apuntes, sin IA, sin buscar, 50 minutos + defensa.
>
> Las soluciones están en la segunda mitad de este archivo. **Si estás haciendo la prueba, cierra el archivo a partir de "Solucionario de la variante B".** Todo el código se verificó con .NET SDK 10.

Rúbrica y reglas esenciales: [RUBRICAS.md](../../../evaluaciones/RUBRICAS.md) (bloques B). Umbral de dominio 80 con: programación desde cero ≥ 70 %, predicción ≥ 50 %, corrección ≥ 50 %, defensa ≥ 60 %.

---

## Enunciado

### Bloque 1 · Conceptuales (10 puntos · 5 × 2)

1. ¿Qué diferencia hay entre el SDK y el runtime de .NET? ¿Cuál necesita quien solo ejecuta un programa ya compilado?
2. ¿Por qué un número de teléfono se guarda como `string` y no como `int`?
3. ¿Qué es el depurador y qué hace la tecla `F10`?
4. ¿Qué es un `.gitignore` y por qué `bin/` y `obj/` van en él?
5. ¿Qué indica una advertencia (`warning`) del compilador y por qué no conviene ignorarla?

### Bloque 2 · Predicción (15 puntos · 5 × 3)

**P1**
```text
Console.WriteLine(9 / 2);
Console.WriteLine(9 / 2.0);
Console.WriteLine((int)9.9);
```

**P2**
```text
int n = 3;
n = n + n * 2;
Console.WriteLine(n);
Console.WriteLine("n" + n);
```

**P3**
```text
long g = int.MaxValue;
g++;
int h = int.MaxValue;
h++;
Console.WriteLine(g);
Console.WriteLine(h);
```

**P4**
```text
var a = 3;
var b = 3.0;
var c = 3.0m;
Console.WriteLine(a.GetType().Name + " " + b.GetType().Name + " " + c.GetType().Name);
```

**P5**
```text
const int Lado = 4;
int area = Lado * Lado;
Console.WriteLine($"Area {Lado}x{Lado} = {area}");
```

### Bloque 3 · Lectura y explicación (10 puntos · 2 × 5)

**L1.** Explica línea por línea y di qué muestra:
```text
const decimal Propina = 0.10m;
decimal cuenta = 30.00m;
decimal montoPropina = cuenta * Propina;
decimal total = cuenta + montoPropina;
Console.WriteLine($"Propina: {montoPropina:F2}");
Console.WriteLine($"Total: {total:F2}");
```

**L2.** Desmonta este mensaje y da la corrección:
```text
Program.cs(3,16): error CS0029: Cannot implicitly convert type 'int' to 'string'
```

### Bloque 4 · Corrección de errores (15 puntos · 3 × 5: tipo 1 · causa 2 · corrección 2)

**C1**
```text
int x = 5;
int x = 6;
Console.WriteLine(x);
```
Esperado: `6`.

**C2**
```text
string texto = "veinte";
int edad = int.Parse(texto);
Console.WriteLine(edad + 1);
```
Esperado: `21`.

**C3**
```text
int nota1 = 7;
int nota2 = 8;
int nota3 = 9;
double promedio = nota1 + nota2 + nota3 / 3;
Console.WriteLine(promedio);
```
Esperado: `8`.

### Bloque 5 · Modificación (10 puntos)

```text
decimal cuenta = 18.50m;
int personas = 2;
decimal porPersona = cuenta / personas;
Console.WriteLine($"Por persona: {porPersona:F2}");
```

**Modifícalo** para que: (1) aplique una propina del **15 %** definida como constante con nombre; (2) muestre `Cuenta: 18.50`, `Propina: 2.78` y `Por persona: 10.64`; (3) no escriba números a mano en las fórmulas. Comprueba ejecutando.

### Bloque 6 · Programación desde cero (30 puntos)

**Cambio en monedas.** Parte de una cantidad en centavos guardada en `int centavos = 87;`. Calcula cuántas monedas de **25**, **10**, **5** y **1** centavos hacen falta usando el menor número posible de monedas (empieza por las más grandes).

Salida exacta para `87`:
```text
Cambio de 87 centavos:
25 centavos: 3
10 centavos: 1
5 centavos: 0
1 centavo: 2
```

**Requisitos:** resultado calculado; valores `25`, `10`, `5` y `1` como constantes con nombre; sin lectura del teclado; plan de 3–4 líneas y traza con 87 **antes** de programar.

**Casos límite**

| `centavos` | 25 | 10 | 5 | 1 |
|---|---|---|---|---|
| 87 | 3 | 1 | 0 | 2 |
| 0 | 0 | 0 | 0 | 0 |
| 99 | 3 | 2 | 0 | 4 |
| 25 | 1 | 0 | 0 | 0 |
| 4 | 0 | 0 | 0 | 4 |
| 5 | 0 | 0 | 1 | 0 |
| 100 | 4 | 0 | 0 | 0 |

**Desglose:** funciona (14) · casos límite (8) · diseño y legibilidad (5) · razonamiento previo (3).

### Bloque 7 · Defensa (10 puntos)

Cuatro preguntas sobre tu solución, por ejemplo: ¿por qué empiezas por la moneda más grande? · ¿cómo probaste `99` y `100`? · ¿dónde pondrías un punto de interrupción para ver el resto después de las monedas de 25? · si se añadiera una moneda de 50, ¿qué cambiarías?

---
---

# Solucionario de la variante B

## Bloque 1

1. El **SDK** (compilador, `dotnet`, plantillas y runtime) sirve para **desarrollar**; el **runtime** solo para **ejecutar** programas ya compilados. Quien solo ejecuta necesita el runtime.
2. No se hacen cálculos con él; puede empezar con ceros, llevar `+` o guiones, y un `int` no soporta números largos ni formatos.
3. El depurador ejecuta el programa **bajo control** para pausarlo e inspeccionar valores. `F10` ejecuta la línea actual **sin entrar** en los métodos que llame.
4. Es un archivo que lista patrones de archivos que Git **no debe versionar**. `bin/` y `obj/` se **regeneran** al compilar, ocupan espacio y causan conflictos.
5. Indica que el código **compila pero algo es sospechoso** (por ejemplo un posible valor nulo sin comprobar). No se ignora porque suele anticipar errores de ejecución.

## Bloque 2

**P1**

<!--v
modo: ejecuta
salida: siguiente
-->
```csharp
Console.WriteLine(9 / 2);
Console.WriteLine(9 / 2.0);
Console.WriteLine((int)9.9);
```

```text
4
4.5
9
```

**P2**

<!--v
modo: ejecuta
salida: siguiente
-->
```csharp
int n = 3;
n = n + n * 2;
Console.WriteLine(n);
Console.WriteLine("n" + n);
```

```text
9
n9
```

**P3**

<!--v
modo: ejecuta
salida: siguiente
-->
```csharp
long g = int.MaxValue;
g++;
int h = int.MaxValue;
h++;
Console.WriteLine(g);
Console.WriteLine(h);
```

```text
2147483648
-2147483648
```

**P4**

<!--v
modo: ejecuta
salida: siguiente
-->
```csharp
var a = 3;
var b = 3.0;
var c = 3.0m;
Console.WriteLine(a.GetType().Name + " " + b.GetType().Name + " " + c.GetType().Name);
```

```text
Int32 Double Decimal
```

**P5**

<!--v
modo: ejecuta
salida: siguiente
-->
```csharp
const int Lado = 4;
int area = Lado * Lado;
Console.WriteLine($"Area {Lado}x{Lado} = {area}");
```

```text
Area 4x4 = 16
```

## Bloque 3

**L1.** Constante de propina del 10 %; cuenta de 30; la propina es cuenta × 10 % (3.00); el total suma ambas (33.00); se muestran con dos decimales.

<!--v
modo: ejecuta
salida: siguiente
-->
```csharp
const decimal Propina = 0.10m;
decimal cuenta = 30.00m;
decimal montoPropina = cuenta * Propina;
decimal total = cuenta + montoPropina;
Console.WriteLine($"Propina: {montoPropina:F2}");
Console.WriteLine($"Total: {total:F2}");
```

```text
Propina: 3.00
Total: 33.00
```

**L2.** Archivo `Program.cs`, línea 3, columna 16. Se intenta guardar un `int` en una variable `string` (tipos incompatibles). Correcciones: declarar la variable como `int`, o convertir el número a texto (por ejemplo, con interpolación o `ToString()`).

## Bloque 4

**C1 · Compilación (`CS0128`).** El nombre `x` se declara dos veces. Corrección: para cambiar el valor, **asignar** `x = 6;`.

<!--v
modo: error CS0128
-->
```csharp
int x = 5;
int x = 6;
Console.WriteLine(x);
```

<!--v
modo: ejecuta
salida: siguiente
-->
```csharp
int x = 5;
x = 6;
Console.WriteLine(x);
```

```text
6
```

**C2 · Ejecución (`FormatException`).** `int.Parse` recibe `"veinte"`, que no es un número. Corrección: pasar un texto numérico (`"20"`).

<!--v
modo: excepcion FormatException
-->
```csharp
string texto = "veinte";
int edad = int.Parse(texto);
Console.WriteLine(edad + 1);
```

<!--v
modo: ejecuta
salida: siguiente
-->
```csharp
string texto = "20";
int edad = int.Parse(texto);
Console.WriteLine(edad + 1);
```

```text
21
```

**C3 · Lógico.** Precedencia: `nota3 / 3` se calcula **antes** que las sumas: 7 + 8 + 3 = 18. Corrección: paréntesis `(nota1 + nota2 + nota3) / 3` y, para decimales, dividir entre `3.0`.

<!--v
modo: ejecuta
salida: siguiente
-->
```csharp
int nota1 = 7;
int nota2 = 8;
int nota3 = 9;
double promedio = nota1 + nota2 + nota3 / 3;
Console.WriteLine(promedio);
```

```text
18
```

<!--v
modo: ejecuta
salida: siguiente
-->
```csharp
int nota1 = 7;
int nota2 = 8;
int nota3 = 9;
double promedio = (nota1 + nota2 + nota3) / 3.0;
Console.WriteLine(promedio);
```

```text
8
```

## Bloque 5

<!--v
modo: ejecuta
salida: siguiente
-->
```csharp
const decimal PorcentajePropina = 0.15m;

decimal cuenta = 18.50m;
int personas = 2;
decimal propina = cuenta * PorcentajePropina;
decimal total = cuenta + propina;
decimal porPersona = total / personas;

Console.WriteLine($"Cuenta: {cuenta:F2}");
Console.WriteLine($"Propina: {propina:F2}");
Console.WriteLine($"Por persona: {porPersona:F2}");
```

```text
Cuenta: 18.50
Propina: 2.78
Por persona: 10.64
```

*(18.50 × 0.15 = 2.775 → se muestra `2.78`; el total es 21.275 y por persona 10.6375 → `10.64`. Se trabaja con el valor sin redondear y se redondea al mostrar.)*

## Bloque 6

<!--v
modo: ejecuta
salida: siguiente
-->
```csharp
const int Cuarto = 25;
const int Decima = 10;
const int Quinta = 5;
const int Centavo = 1;

int centavos = 87;
int resto = centavos;

int cuartos = resto / Cuarto;
resto = resto - cuartos * Cuarto;

int decimas = resto / Decima;
resto = resto - decimas * Decima;

int quintas = resto / Quinta;
resto = resto - quintas * Quinta;

int unidades = resto / Centavo;

Console.WriteLine($"Cambio de {centavos} centavos:");
Console.WriteLine($"{Cuarto} centavos: {cuartos}");
Console.WriteLine($"{Decima} centavos: {decimas}");
Console.WriteLine($"{Quinta} centavos: {quintas}");
Console.WriteLine($"{Centavo} centavo: {unidades}");
```

```text
Cambio de 87 centavos:
25 centavos: 3
10 centavos: 1
5 centavos: 0
1 centavo: 2
```

**Traza con 87:** 87 ÷ 25 = 3 (resto 12) → 12 ÷ 10 = 1 (resto 2) → 2 ÷ 5 = 0 (resto 2) → 2 ÷ 1 = 2.

**Versión de prueba con lectura** (comprueba los siete casos de una vez):

<!--v
modo: ejecuta
caso: 87 => 25 centavos: 3 && 10 centavos: 1 && 5 centavos: 0 && 1 centavo: 2
caso: 0 => 25 centavos: 0 && 10 centavos: 0 && 5 centavos: 0 && 1 centavo: 0
caso: 99 => 25 centavos: 3 && 10 centavos: 2 && 5 centavos: 0 && 1 centavo: 4
caso: 25 => 25 centavos: 1 && 10 centavos: 0 && 5 centavos: 0 && 1 centavo: 0
caso: 4 => 25 centavos: 0 && 10 centavos: 0 && 5 centavos: 0 && 1 centavo: 4
caso: 5 => 25 centavos: 0 && 10 centavos: 0 && 5 centavos: 1 && 1 centavo: 0
caso: 100 => 25 centavos: 4 && 10 centavos: 0 && 5 centavos: 0 && 1 centavo: 0
-->
```csharp
const int Cuarto = 25;
const int Decima = 10;
const int Quinta = 5;
const int Centavo = 1;

int centavos = int.Parse(Console.ReadLine() ?? "0");
int resto = centavos;

int cuartos = resto / Cuarto;
resto = resto - cuartos * Cuarto;

int decimas = resto / Decima;
resto = resto - decimas * Decima;

int quintas = resto / Quinta;
resto = resto - quintas * Quinta;

int unidades = resto / Centavo;

Console.WriteLine($"Cambio de {centavos} centavos:");
Console.WriteLine($"{Cuarto} centavos: {cuartos}");
Console.WriteLine($"{Decima} centavos: {decimas}");
Console.WriteLine($"{Quinta} centavos: {quintas}");
Console.WriteLine($"{Centavo} centavo: {unidades}");
```

Calificación (30): funciona 14 · casos límite 8 · diseño 5 · razonamiento previo 3. **Regla esencial: ≥ 21 y funciona.**

## Bloque 7

1. **¿Por qué empiezas por la más grande?** Porque con estas monedas (25, 10, 5, 1) cada una es múltiplo de las menores o encaja bien, y tomar tantas como se pueda de la mayor minimiza el total (estrategia *voraz*); con otros sistemas de monedas no siempre funciona.
2. **Probar 99 y 100:** ejecutando y comparando con el cálculo a mano (99 → 3, 2, 0, 4; 100 → 4, 0, 0, 0).
3. **Punto de interrupción:** en la línea posterior a calcular `cuartos`; ventana de variables locales o inspección: `resto` antes y después de restar.
4. **Añadir 50:** una constante `Medio = 50`, calcular las monedas de 50 **antes** de las de 25 y restar de `resto`, y ampliar la salida.

Escala de la defensa: alto 9–10 · medio 6–8 · bajo 0–5. **Regla esencial: ≥ 6.**
