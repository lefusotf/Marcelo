# Solucionario del diagnóstico

> **No abrir antes de entregar tus respuestas.** Las salidas y los programas de este archivo se ejecutaron con .NET SDK 10 mediante `herramientas/verificar_codigo.py` (ver [herramientas/README.md](../../../herramientas/README.md)). Los decimales se muestran con punto.

## Cómo puntuar

Cada elemento vale **0, 1 o 2**:
- **2** = respuesta correcta *y* razonada (acierta por el motivo correcto).
- **1** = parcialmente correcta, o correcta sin razón, o razón correcta con un fallo de detalle.
- **0** = incorrecta, en blanco o "no sé".

Los programas de la Parte 4 se puntúan aparte (E1 sobre 6, E2 sobre 10, E3 sobre 8; criterios en cada uno).

---

## Parte 1 · Conceptos

| N.º | Respuesta esperada (ideas clave) |
|---|---|
| **C1** | El **código fuente** es el texto que escribe la persona (`.cs`). El **compilador** lo traduce a un formato que la máquina (o el entorno de ejecución) puede ejecutar y avisa de errores de lenguaje. El **programa en ejecución** es ese resultado funcionando en memoria, con datos reales. 2 puntos si distingue los tres papeles; 1 si confunde compilar con ejecutar. |
| **C2** | Una variable es un **nombre** asociado a un **espacio de memoria** que guarda un valor de un **tipo** determinado. Asignar `"hola"` a un `int` es un **error de compilación** (no se puede convertir `string` en `int` implícitamente). |
| **C3** | `=` **asigna** (guarda un valor en una variable); `==` **compara** (devuelve `true` o `false`). |
| **C4** | `int` guarda enteros sin decimales; `double` guarda números con decimales (con error de precisión de punto flotante). Ejemplos válidos: promedio, precio, división `7 / 2` (con `int` da 3). Para dinero lo correcto es `decimal`. |
| **C5** | Un método es un bloque con nombre que hace una tarea y puede recibir datos y devolver un resultado. Ventajas: reutilizar, dar nombre a una idea, probar por partes, leer mejor. |
| **C6** | El array tiene **tamaño fijo** al crearse; la `List<T>` **crece y se reduce** (`Add`, `Remove`). |
| **C7** | PK: columna(s) que identifican **de forma única** cada fila (no nula). FK: columna que **referencia** la PK de otra tabla y relaciona filas. |
| **C8** | *Compilación*: el código no cumple el lenguaje y el programa ni siquiera se construye (`int x = "a";`). *Ejecución*: compila pero falla al correr (dividir entre cero entero, índice fuera de rango, `int.Parse("abc")`). *Lógico*: corre sin fallar pero el resultado es incorrecto (usar `<` en vez de `<=`, dividir enteros esperando decimales). |

---

## Parte 2 · Predicciones

<!--v
modo: ejecuta
salida: siguiente
-->
```csharp
int a = 7;
int b = 2;
Console.WriteLine(a / b);
Console.WriteLine(a % b);
Console.WriteLine((double)a / b);
```

```text
3
1
3.5
```

**P1.** `7 / 2` entre enteros da **3** (se descarta la parte decimal); `%` da el **resto** (1); el `cast` a `double` hace que la división sea decimal (3.5).

<!--v
modo: ejecuta
salida: siguiente
-->
```csharp
string s = "5" + 3;
int n = 5 + 3;
Console.WriteLine(s);
Console.WriteLine(n);
Console.WriteLine("5" + 3 + 2);
Console.WriteLine(5 + 3 + "2");
```

```text
53
8
532
82
```

**P2.** Con un texto, `+` **concatena**. `"5" + 3 + 2` se evalúa de izquierda a derecha: `"53"` y luego `"532"`. `5 + 3 + "2"`: primero suma numérica (8) y luego concatena con el texto: `"82"`.

<!--v
modo: ejecuta
salida: siguiente
-->
```csharp
int suma = 0;
for (int i = 1; i <= 4; i++)
{
    suma += i;
    Console.WriteLine(i + " -> " + suma);
}
Console.WriteLine("Fin: " + suma);
```

```text
1 -> 1
2 -> 3
3 -> 6
4 -> 10
Fin: 10
```

**P3.** Traza: `i=1, suma=1`; `i=2, suma=3`; `i=3, suma=6`; `i=4, suma=10`. En `i=5` la condición es falsa y el bucle termina.

<!--v
modo: ejecuta
salida: siguiente
-->
```csharp
int x = 10;
while (x > 0)
{
    x -= 4;
    if (x == 2) continue;
    Console.Write(x + " ");
}
Console.WriteLine();
```

```text
6 -2
```

**P4.** Vuelta 1: `x=6`, se imprime `6 `. Vuelta 2: `x=2`, `continue` salta el `Write`. Vuelta 3: `x=-2`, se imprime `-2 `. Ahora `x > 0` es falso. La línea termina con un espacio.

<!--v
modo: ejecuta
salida: siguiente
-->
```csharp
static void Duplicar(int numero)
{
    numero = numero * 2;
    Console.WriteLine("Dentro: " + numero);
}

int valor = 5;
Duplicar(valor);
Console.WriteLine("Fuera: " + valor);
```

```text
Dentro: 10
Fuera: 5
```

**P5.** Los números se pasan **por valor**: el método recibe una *copia*. Cambiar `numero` no cambia `valor`.

<!--v
modo: ejecuta
salida: siguiente
-->
```csharp
int edad = 17;
bool tieneCarnet = true;
bool puedeEntrar = edad >= 18 || tieneCarnet && edad >= 16;
Console.WriteLine(puedeEntrar);
Console.WriteLine(!(edad > 16));
```

```text
True
False
```

**P6.** `&&` tiene mayor precedencia que `||`: `(edad >= 18) || (tieneCarnet && edad >= 16)` → `false || (true && true)` → `True`. Y `!(17 > 16)` es `!true` → `False`.

<!--v
modo: excepcion IndexOutOfRangeException
salida: siguiente
-->
```csharp
int[] datos = { 4, 8, 15, 16, 23, 42 };
Console.WriteLine(datos[2]);
Console.WriteLine(datos.Length);
Console.WriteLine(datos[datos.Length - 1]);
Console.WriteLine(datos[6]);
```

```text
15
6
42
```

**P7.** Las tres primeras líneas funcionan (índices de 0 a 5). `datos[6]` no existe: se lanza `System.IndexOutOfRangeException` en la última línea y el programa termina sin imprimir nada más.

---

## Parte 3 · Lectura y corrección

**L1.** `error CS0029`: no se puede convertir implícitamente `string` a `int`. Solución: guardar el texto en una variable `string`, o usar el valor numérico `20`, o convertir con `int.Parse`/`TryParse` si el texto viene del usuario.

<!--v
modo: error CS0029
-->
```csharp
int edad = "veinte";
Console.WriteLine(edad);
```

**L2.** Devuelve `7`, no `7.67`. `(a + b + c)` es `int` (23) y `3` es `int`: la división es **entera** (23 / 3 = 7) y *después* el 7 se convierte a `double`. Correcciones válidas: `/ 3.0`, `/ 3d`, o `(double)(a + b + c) / 3`.

<!--v
modo: ejecuta
salida: siguiente
-->
```csharp
static double Promedio(int a, int b, int c)
{
    return (a + b + c) / 3;
}

Console.WriteLine(Promedio(7, 8, 8));
```

```text
7
```

**L3.** Línea del `for`: la condición `i <= notas.Length` permite `i = 3`, y `notas[3]` no existe → `IndexOutOfRangeException`. Corrección: `i < notas.Length` (o usar `foreach`).

<!--v
modo: excepcion IndexOutOfRangeException
-->
```csharp
int[] notas = { 70, 85, 90 };
int total = 0;
for (int i = 0; i <= notas.Length; i++)
{
    total += notas[i];
}
Console.WriteLine(total);
```

**L4.** Si la persona escribe `abc`, `int.Parse` lanza `FormatException` y el programa se cae. Con el campo vacío ocurre lo mismo (`""` no es un entero válido); además `Console.ReadLine()` puede devolver `null` si se cierra la entrada, y entonces `int.Parse(null)` lanza `ArgumentNullException`. Corrección: `int.TryParse` y reintentar o avisar.

<!--v
modo: excepcion FormatException
entrada: abc
-->
```csharp
Console.Write("Edad: ");
int edad = int.Parse(Console.ReadLine());
Console.WriteLine("Dentro de diez años tendrás " + (edad + 10));
```

**Versión robusta (referencia):**

<!--v
modo: ejecuta
caso: 30 ==> Edad: Dentro de diez años tendrás 40
caso: abc ==> Edad: Eso no es una edad válida.
caso: ==> Edad: Eso no es una edad válida.
caso: -5 ==> Edad: Eso no es una edad válida.
-->
```csharp
Console.Write("Edad: ");
string? texto = Console.ReadLine();

if (int.TryParse(texto, out int edad) && edad >= 0)
{
    Console.WriteLine("Dentro de diez años tendrás " + (edad + 10));
}
else
{
    Console.WriteLine("Eso no es una edad válida.");
}
```

**L5 (tu código).**
- **(a)** `using` garantiza que la conexión se **cierra y libera** al salir del bloque, incluso si hay una excepción. Sin él, las conexiones quedarían abiertas hasta que el recolector de basura actúe y se podría agotar el *pool* de conexiones. *(Nota: el `SqlCommand` tampoco está en un `using` en este método: es un detalle de mejora, no un error grave.)*
- **(b)** Con **parámetros**, el valor viaja separado del texto de la consulta y se trata siempre como dato, nunca como código SQL: evita la **inyección SQL** (p. ej. un nombre como `x'); DROP TABLE ...--`) y evita problemas con comillas y formatos. Unir texto mezcla datos con código.
- **(c)** Devuelve el **número de filas afectadas**. `> 0` convierte eso en `true` si se insertó al menos una fila.
- **(d)** Se pierde el **tipo** de la excepción original (p. ej. `SqlException` con su `Number` para distinguir una clave duplicada de un fallo de red), la **pila de llamadas** (`StackTrace`) y la excepción interna. Se corrige con `throw;` (relanzar) o `throw new Exception("mensaje", ex)` pasando la original como `InnerException`.

---

## Parte 4 · Programas de referencia

Criterios para cada uno: **funciona con entradas normales**, **valida**, **casos límite**, **claridad**. Si el programa no corre, el máximo del ejercicio es la mitad.

### E1 (6 puntos: 3 funciona · 2 validación · 1 claridad)

<!--v
modo: ejecuta
caso: 4 ==> Número: par
caso: 7 ==> Número: impar
caso: 0 ==> Número: par
caso: -3 ==> Número: impar
caso: abc ==> Número: Entrada no válida
caso: ==> Número: Entrada no válida
caso: 3.5 ==> Número: Entrada no válida
caso: 2147483648 ==> Número: Entrada no válida
-->
```csharp
Console.Write("Número: ");
string? texto = Console.ReadLine();

if (!int.TryParse(texto, out int numero))
{
    Console.WriteLine("Entrada no válida");
    return;
}

Console.WriteLine(numero % 2 == 0 ? "par" : "impar");
```

Errores frecuentes: usar `int.Parse` (se cae con `abc`); `numero % 2 == 1` (falla con negativos: `-3 % 2` es `-1`); olvidar el `0`.

### E2 (10 puntos: 4 funciona · 2 validación · 3 casos límite · 1 claridad)

<!--v
modo: ejecuta
caso: 5|3|10|0 => Cantidad: 3 && Suma: 18 && Promedio: 6.00 && Mayor: 10
caso: 0 ==> Número (0 para terminar): No hay datos
caso: abc|4|0 => no es un número entero && Cantidad: 1 && Mayor: 4
caso: -5|-2|0 => Mayor: -2 && Promedio: -3.50
caso: 7|8|8|0 => Promedio: 7.67
caso: 2000000000|2000000000|0 => Suma: 4000000000
-->
```csharp
int cantidad = 0;
long suma = 0;
int mayor = int.MinValue;

while (true)
{
    Console.Write("Número (0 para terminar): ");
    string? texto = Console.ReadLine();

    if (texto == null)
    {
        break; // la entrada se cerró (Ctrl+Z / Ctrl+D): no seguir pidiendo
    }

    if (!int.TryParse(texto, out int numero))
    {
        Console.WriteLine("Eso no es un número entero. Intenta de nuevo.");
        continue;
    }

    if (numero == 0)
    {
        break;
    }

    cantidad++;
    suma += numero;
    if (numero > mayor)
    {
        mayor = numero;
    }
}

if (cantidad == 0)
{
    Console.WriteLine("No hay datos");
}
else
{
    double promedio = (double)suma / cantidad;
    Console.WriteLine($"Cantidad: {cantidad}");
    Console.WriteLine($"Suma: {suma}");
    Console.WriteLine($"Promedio: {promedio:F2}");
    Console.WriteLine($"Mayor: {mayor}");
}
```

Casos límite que se miran: solo el `0`; todos negativos (si `mayor` se inicia en 0, falla); división entera en el promedio; texto no numérico sin terminar; suma mayor que `int` (por eso `long`).

### E3 (8 puntos: 4 funciona · 1 validación · 2 casos límite · 1 claridad)

<!--v
modo: ejecuta
caso: Hola Mundo ==> Frase: Vocales: 4
caso: ==> Frase: Vocales: 0
caso: rhythm ==> Frase: Vocales: 0
caso: AEIOU ==> Frase: Vocales: 5
caso: canción ==> Frase: Vocales: 2
-->
```csharp
static int ContarVocales(string texto)
{
    int total = 0;
    foreach (char c in texto)
    {
        char minuscula = char.ToLower(c);
        if (minuscula == 'a' || minuscula == 'e' || minuscula == 'i' || minuscula == 'o' || minuscula == 'u')
        {
            total++;
        }
    }
    return total;
}

Console.Write("Frase: ");
string frase = Console.ReadLine() ?? "";
Console.WriteLine($"Vocales: {ContarVocales(frase)}");
```

Errores frecuentes: olvidar mayúsculas (solo comparar con `'a'`…); contar la `y`; no manejar `null` si la entrada se cierra (`?? ""`); contar con `Contains` sobre una cadena y contar palabras en vez de letras.

---

## Parte 5 · SQL

- **Q1.** `SELECT Nombre, Salario FROM Empleados WHERE Salario > 500 ORDER BY Salario DESC;`
- **Q2.** `SELECT d.Nombre, COUNT(e.IdEmpleado) AS Cantidad FROM Departamentos d LEFT JOIN Empleados e ON e.IdDepartamento = d.IdDepartamento GROUP BY d.Nombre;` *(el `LEFT JOIN` hace que aparezcan también los departamentos con 0; con `INNER JOIN` se acepta 1 punto).*
- **Q3.** `SELECT d.Nombre FROM Departamentos d LEFT JOIN Empleados e ON e.IdDepartamento = d.IdDepartamento WHERE e.IdEmpleado IS NULL;` o con `NOT EXISTS` / `NOT IN`.
- **Q4.** Cambia el salario de **todas** las filas a 600 porque no tiene `WHERE`. Peligrosa: modificación masiva sin condición; se debe probar antes con `SELECT` y, en datos importantes, usar una transacción.

*(Estas consultas no se ejecutaron: requieren una base de datos de prueba. Están **[ESCRITAS]** y revisadas a mano; se ejecutarán en el módulo 5.)*

---

## Parte 6 · Herramientas

- **H1.** `git commit` guarda una *instantánea* de los cambios preparados en el **repositorio local**. `git push` envía los commits locales a un **repositorio remoto** (por ejemplo GitHub). Solo `push` necesita internet.
- **H2.** `mkdir Hola`, `cd Hola`, `dotnet new console -n Hola`. *(Acepta variantes: `-o`, o `dotnet new console` sin nombre, que usa el nombre de la carpeta.)*
- **H3.** Son carpetas generadas por la compilación (archivos intermedios y ejecutables). No se versionan porque se regeneran, ocupan espacio y producen conflictos; se excluyen con `.gitignore`.
- **H4.** Visual Studio: clic en el margen izquierdo de la línea o `F9`; `F10` avanza una línea sin entrar en métodos y `F11` entra en ellos. VS Code: clic en el margen o `F9`; `F10` y `F11` análogos con `F5` para iniciar la depuración.

---

## Mapa de niveles por área

Suma los puntos de cada área y calcula el porcentaje sobre su máximo:

| Área | Elementos | Máximo |
|---|---|---|
| **Entorno y herramientas** | C1, C8, H1, H2, H3, H4 | 12 |
| **Fundamentos** (tipos, operadores, conversión) | C2, C3, C4, P1, P2, P6, L1, L2, L4 | 18 |
| **Control de flujo** | P3, P4, L3, E1 (÷3), E2 (÷5) | 2+2+2+2+2 = 10 *(escala E1 y E2 a 0–2)* |
| **Métodos y colecciones** | C5, C6, P5, P7, E3 (÷4) | 10 |
| **Código con base de datos** (leer código propio) | L5 a–d | 8 |
| **SQL** | C7, Q1, Q2, Q3, Q4 | 10 |
| **POO** | *(no se diagnostica por preguntas: A10 y A11 son solo autoevaluación; se confirma en el módulo 3)* | — |

| % del área | Recomendación |
|---|---|
| **≥ 85 %** | Candidata a **examen de salto** de las unidades de esa área (solo módulos 0–1 y SQL básico). |
| **65–84 %** | **Ritmo rápido:** leer la lección en 10 minutos y dedicar el tiempo a los retos 3 y 4. |
| **40–64 %** | **Ritmo normal:** lección completa y todos los ejercicios. |
| **< 40 %** | **Reforzar:** lección completa, doble de ejercicios guiados y repaso más frecuente. |

### Cruce con la autoevaluación

Para cada área compara tu 0–3 de la Parte 0 con el porcentaje obtenido. Si te puntuaste con 2–3 y el área salió por debajo de 50 %, es una **brecha de confianza**: se anota en [progreso/errores-recurrentes.md](../../../progreso/errores-recurrentes.md) como alerta para revisar con más cuidado. Si te puntuaste con 0–1 y el área salió por encima de 65 %, tu confianza es menor que tu capacidad: lo cual también es información útil.

### Lo que no revela este diagnóstico

No mide POO, EF Core, pruebas, ni ASP.NET Core. No mide tu ritmo de aprendizaje real: eso lo mide el seguimiento de las primeras semanas.
