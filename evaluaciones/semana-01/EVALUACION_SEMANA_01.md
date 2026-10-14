# Evaluación de la semana 1 · Variante A

**Unidades evaluadas:** 0.1 · 0.2 · 0.3 · 0.4 · 1.1
**Tiempo máximo:** 50 minutos de prueba + 5 minutos de defensa oral.
**Material permitido:** ninguno. **Sin apuntes, sin IA, sin buscar.** Puedes usar tu editor y `dotnet` para el Bloque 6 (programación desde cero) y para comprobar el Bloque 5; en los demás bloques **no ejecutes** código.
**Modo:** examinador. No se dan pistas ni soluciones durante la prueba; solo se aclaran dudas de enunciado.
**Puntuación:** sobre 100 (rúbrica B de [RUBRICAS.md](../RUBRICAS.md)). Umbral de dominio: **80**, con las reglas esenciales (programación desde cero ≥ 70 %, predicción ≥ 50 %, corrección ≥ 50 %, defensa ≥ 60 %).

> Decimales: si ves coma en vez de punto en tu equipo, responde con cualquiera de las dos.

**Antes de empezar:** abre `progreso/bitacora/` y anota la hora de inicio. Al terminar, anota la hora de fin, cuántos minutos usaste y si hubo interrupciones.

---

## Bloque 1 · Preguntas conceptuales (10 puntos · 5 × 2)

Responde en una o dos frases propias.

1. Explica el recorrido que sigue tu código C# desde que lo escribes hasta que se ejecuta en .NET. Nombra los pasos y los productos.
2. ¿Por qué el dinero se guarda en `decimal` y no en `double`? Da un ejemplo numérico.
3. ¿Qué diferencia hay entre un error de compilación y un error lógico? Un ejemplo de cada uno.
4. ¿Qué hace `git add` y qué hace `git commit`?
5. ¿Qué te indica un mensaje con el código `CS0103` y dónde buscarías qué significa?

---

## Bloque 2 · Predicción de resultados (15 puntos · 5 × 3) — *esencial: ≥ 50 %*

**No ejecutes.** Escribe exactamente lo que se muestra. Si el programa falla, di en qué línea y con qué excepción, y qué se alcanzó a mostrar.

**P1**
```text
int a = 17;
int b = 5;
Console.WriteLine(a / b);
Console.WriteLine(a / (double)b);
```

**P2**
```text
int x = 4;
x = x * 2;
x = x - 3;
Console.WriteLine(x);
Console.WriteLine("x" + x);
Console.WriteLine(x + x);
```

**P3**
```text
decimal p = 0.1m;
double q = 0.1;
Console.WriteLine(p * 3);
Console.WriteLine(q * 3);
```

**P4**
```text
Console.WriteLine("Inicio");
int d = 0;
Console.WriteLine(12 / d);
Console.WriteLine("Fin");
```

**P5**
```text
const int Max = 3;
int a = Max + 1;
string s = "Nivel " + a;
Console.WriteLine(s);
Console.WriteLine($"{Max}{a}");
```

---

## Bloque 3 · Lectura y explicación de código (10 puntos · 2 × 5)

**L1.** Explica con tus palabras, línea por línea, qué hace este programa y qué muestra.

```text
const decimal Iva = 0.13m;
decimal precio = 40.00m;
decimal impuesto = precio * Iva;
decimal total = precio + impuesto;
Console.WriteLine($"Impuesto: {impuesto:F2}");
Console.WriteLine($"Total: {total:F2}");
```

**L2.** Desmonta este mensaje del compilador: ¿qué archivo y qué línea señala, qué significa, y qué **dos** correcciones posibles hay?

```text
Program.cs(7,12): error CS0266: Cannot implicitly convert type 'double' to 'int'. An explicit conversion exists (are you missing a cast?)
```

---

## Bloque 4 · Corrección de errores (15 puntos · 3 × 5) — *esencial: ≥ 50 %*

Para cada programa indica: **tipo de error** (compilación, ejecución o lógico) (1 punto), **causa** (2 puntos) y **corrección** (2 puntos).

**C1**
```text
decimal precio = 19.99;
int unidades = 3;
Console.WriteLine(precio * unidades);
```
Resultado esperado: `59.97`.

**C2**
```text
int total = 120;
int personas = 0;
int porPersona = total / personas;
Console.WriteLine(porPersona);
```
Resultado esperado: `30` (el grupo real es de 4 personas).

**C3**
```text
int nota1 = 9;
int nota2 = 8;
double promedio = (nota1 + nota2) / 2;
Console.WriteLine(promedio);
```
Resultado esperado: `8.5`.

---

## Bloque 5 · Modificación de un programa existente (10 puntos)

Este programa calcula un total sin descuento:

```text
decimal precio = 25.00m;
int cantidad = 2;
decimal total = precio * cantidad;
Console.WriteLine($"Total: {total:F2}");
```

**Modifícalo** para que:
1. Aplique un descuento del **10 %** definido como **constante con nombre**.
2. Muestre exactamente tres líneas: `Total: 50.00`, `Descuento: 5.00`, `A pagar: 45.00`.
3. No escriba a mano ningún número en las fórmulas, salvo los datos de partida.

Comprueba tu respuesta ejecutándola.

---

## Bloque 6 · Programación desde cero (30 puntos) — *esencial: ≥ 70 %*

**Convertidor de duración.** Escribe un programa que parta de una cantidad de segundos guardada en una variable `int segundosTotales = 3725;` y muestre cuántas horas, minutos y segundos equivalen.

**Salida exacta** para `3725`:

```text
Duración: 3725 segundos
Equivale a 1 h 2 min 5 s
```

**Requisitos**
1. El resultado se calcula (no se escribe a mano).
2. Los valores `3600` (segundos por hora) y `60` (segundos por minuto) deben ser **constantes con nombre**.
3. Los datos de entrada se cambian en la primera línea del programa; no hay lectura del teclado.
4. Antes de programar, escribe en **tres o cuatro líneas** tu plan (qué entra, qué pasos, qué sale) y una **traza** con 3725.

**Casos límite que debes probar y anotar (entrada → salida)**

| `segundosTotales` | Salida esperada de la segunda línea |
|---|---|
| 3725 | `Equivale a 1 h 2 min 5 s` |
| 59 | `Equivale a 0 h 0 min 59 s` |
| 60 | `Equivale a 0 h 1 min 0 s` |
| 3600 | `Equivale a 1 h 0 min 0 s` |
| 0 | `Equivale a 0 h 0 min 0 s` |
| 86399 | `Equivale a 23 h 59 min 59 s` |

**Desglose:** funciona con las entradas normales (14) · casos límite (8) · diseño, nombres y legibilidad (5) · razonamiento previo (3).

---

## Bloque 7 · Defensa técnica (10 puntos · se hace de viva voz tras entregar)

El examinador te hará cuatro preguntas sobre **tu propia solución del Bloque 6**, por ejemplo:

- ¿Por qué elegiste `int` para los segundos? ¿Qué pasaría con `5000000000`?
- ¿Cómo comprobaste que funciona con `3600` y con `59`?
- ¿Dónde pondrías un punto de interrupción para ver cuántos minutos quedan por convertir, y qué ventana mirarías?
- Si el requisito cambiara a mostrar también **días**, ¿qué cambiarías?

---

## Al terminar

1. Entrega: respuestas por escrito (puede ser en un archivo `practica/semana-01/evaluacion/respuestas.md`), tu programa del Bloque 6 en `practica/semana-01/evaluacion/Duracion/` y un commit con mensaje claro.
2. El examinador calificará con la rúbrica y registrará el resultado en [progreso/evaluaciones.md](../../progreso/evaluaciones.md).
3. Si cumples las reglas esenciales y alcanzas 80: las unidades 0.1–0.4 y 1.1 pasan a **dominadas**.
4. Si no, recibirás ejercicios de recuperación específicos y una nueva evaluación con **problemas distintos** (variante B) pasadas al menos 48 horas.

Mini-proyecto de la semana (30 minutos, no puntúa en este examen, pero se registra como evidencia): [MINIPROYECTO_SEMANA_01.md](MINIPROYECTO_SEMANA_01.md).
