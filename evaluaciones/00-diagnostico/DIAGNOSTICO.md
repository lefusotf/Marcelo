# Evaluación diagnóstica

**Para qué sirve:** descubrir qué dominas *de verdad* hoy, para ajustar la ruta. **No es un examen que se apruebe o suspenda.** Una respuesta honesta de "no sé" me sirve más que una adivinanza afortunada, y no resta nada.

**Duración:** 75–90 minutos en total. Se puede partir en dos sesiones.

## Reglas

1. **Sin IA, sin apuntes, sin buscar en internet.**
2. **Partes 1, 2 y 3 (predicciones y lectura):** **no ejecutes código.** Se trata de saber qué hace, no de comprobarlo. Responde primero y, si quieres, comprueba después (anota si cambiaste de opinión).
3. **Parte 4 (programar):** puedes usar tu editor y ejecutar, pero **sin IA ni buscar soluciones**.
4. Escribe tus respuestas en un archivo propio, por ejemplo `practica/00-diagnostico/respuestas.md`, o directamente en la conversación.
5. No hay solución a la vista: el solucionario está en `soluciones/evaluaciones/00-diagnostico/` y **se abre después** de entregar tus respuestas.

> **⚡ Ronda rápida (sesión 0).** Los elementos marcados con ⚡ forman un diagnóstico breve (≈ 25 minutos) que se hace en la primera conversación para adaptar la primera lección. El resto se completa después y se usa para confirmar el nivel de cada área.

> **Nota sobre decimales.** Si un resultado lleva decimales, en tu equipo pueden aparecer con coma (`3,5`) en vez de con punto (`3.5`). Responde con cualquiera de las dos formas.

---

## Parte 0 · Autoevaluación (5 min)

Para cada afirmación escribe un número:
**0** = no sé · **1** = lo he hecho con ayuda · **2** = puedo hacerlo solo · **3** = podría explicárselo a otra persona.

| N.º | Puedo… |
|---|---|
| A1 ⚡ | Crear un proyecto de consola con la terminal (`dotnet`) y ejecutarlo. |
| A2 ⚡ | Explicar la diferencia entre compilar y ejecutar. |
| A3 | Declarar variables de distintos tipos y justificar por qué elijo cada tipo. |
| A4 ⚡ | Leer un dato del usuario y comprobar que es realmente un número. |
| A5 | Escribir un `if / else if / else` con condiciones compuestas. |
| A6 | Escribir un `for` y un `while` y decidir cuál usar. |
| A7 | Escribir un método con parámetros y valor de retorno. |
| A8 | Recorrer un array o una lista y calcular un total o un máximo. |
| A9 ⚡ | Usar el depurador: punto de interrupción, paso a paso, ver variables. |
| A10 | Crear una clase con propiedades y constructor. |
| A11 | Explicar qué es una interfaz y para qué sirve. |
| A12 ⚡ | Escribir una consulta `SELECT` con `WHERE` y `ORDER BY`. |
| A13 | Escribir un `JOIN` entre dos tablas. |
| A14 | Explicar clave primaria frente a clave foránea. |
| A15 | Explicar qué es una consulta parametrizada y por qué importa. |
| A16 ⚡ | Hacer un *commit* con Git y ver el historial. |
| A17 | Hacer una traza (tabla de valores) para comprobar un algoritmo. |
| A18 | Capturar y manejar una excepción con `try / catch`. |

---

## Parte 1 · Conceptos (10 min)

Responde con tus palabras en 1–3 líneas.

- **C1 ⚡** ¿Qué diferencia hay entre el *código fuente*, el *compilador* y el *programa en ejecución*?
- **C2.** ¿Qué es una variable? ¿Qué ocurre si intentas guardar el texto `"hola"` en una variable de tipo `int`?
- **C3.** ¿En qué se diferencian `=` y `==`?
- **C4.** ¿Qué diferencia hay entre `int` y `double`? Da un ejemplo en el que usar `int` sea un error.
- **C5.** ¿Qué es un método y qué ventaja tiene dividir un programa en métodos?
- **C6.** ¿Qué diferencia hay entre un array y una `List<int>`?
- **C7.** En una tabla de SQL Server, ¿qué es una clave primaria y qué es una clave foránea?
- **C8 ⚡** ¿Qué es un error de compilación, un error de ejecución y un error lógico? Pon un ejemplo de cada uno.

---

## Parte 2 · Predicción de resultados (15 min)

**No ejecutes.** Escribe exactamente lo que mostraría la consola. Si crees que el programa falla, di en qué línea y qué error esperas.

**P1 ⚡**
```csharp
int a = 7;
int b = 2;
Console.WriteLine(a / b);
Console.WriteLine(a % b);
Console.WriteLine((double)a / b);
```

**P2 ⚡**
```csharp
string s = "5" + 3;
int n = 5 + 3;
Console.WriteLine(s);
Console.WriteLine(n);
Console.WriteLine("5" + 3 + 2);
Console.WriteLine(5 + 3 + "2");
```

**P3 ⚡**
```csharp
int suma = 0;
for (int i = 1; i <= 4; i++)
{
    suma += i;
    Console.WriteLine(i + " -> " + suma);
}
Console.WriteLine("Fin: " + suma);
```

**P4**
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

**P5**
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

**P6**
```csharp
int edad = 17;
bool tieneCarnet = true;
bool puedeEntrar = edad >= 18 || tieneCarnet && edad >= 16;
Console.WriteLine(puedeEntrar);
Console.WriteLine(!(edad > 16));
```

**P7 ⚡**
```csharp
int[] datos = { 4, 8, 15, 16, 23, 42 };
Console.WriteLine(datos[2]);
Console.WriteLine(datos.Length);
Console.WriteLine(datos[datos.Length - 1]);
Console.WriteLine(datos[6]);
```

---

## Parte 3 · Leer, encontrar y corregir errores (15 min)

**L1.** Este código no compila. ¿Por qué? ¿Cómo lo arreglarías?
```csharp
int edad = "veinte";
Console.WriteLine(edad);
```

**L2 ⚡** Este método debería devolver el promedio de tres notas. Con `Promedio(7, 8, 8)` el resultado esperado es aproximadamente `7.67`. ¿Qué devuelve realmente? ¿Por qué? ¿Cómo lo corriges?
```csharp
static double Promedio(int a, int b, int c)
{
    return (a + b + c) / 3;
}

Console.WriteLine(Promedio(7, 8, 8));
```

**L3.** Este programa debería sumar las notas, pero falla al ejecutarse. ¿En qué línea y por qué? ¿Cómo lo corriges?
```csharp
int[] notas = { 70, 85, 90 };
int total = 0;
for (int i = 0; i <= notas.Length; i++)
{
    total += notas[i];
}
Console.WriteLine(total);
```

**L4 ⚡** ¿Qué pasa con este programa si la persona escribe `abc` en vez de un número? ¿Y si deja el campo vacío y pulsa Enter? Describe cómo harías el programa más robusto (con palabras o con código).
```csharp
Console.Write("Edad: ");
int edad = int.Parse(Console.ReadLine());
Console.WriteLine("Dentro de diez años tendrás " + (edad + 10));
```

**L5 ⚡ Código de tu propio proyecto.** Este método está en `cs/Activo.cs` (clase `Activo`, método `GuardarActivo`). Respóndelo sin ejecutar nada y sin mirar el resto del proyecto:
```csharp
public static bool GuardarActivo(int id, string nombre, int idCategoria)
{
    try
    {
        using (SqlConnection con = Conexion.Conectar())
        {
            con.Open();
            string query = @"INSERT INTO GestionActivos (IdActivo, Nombre, IdCategoria)
                         VALUES (@id, @nombre, @idCategoria)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@idCategoria", idCategoria);
            return cmd.ExecuteNonQuery() > 0;
        }
    }
    catch (Exception ex)
    {
        throw new Exception("Error SQL: " + ex.Message);
    }
}
```
- **(a) ⚡** ¿Qué hace `using (SqlConnection con = ...)` y qué ocurriría si no estuviera?
- **(b)** ¿Qué diferencia hay entre usar `@nombre` con `Parameters.AddWithValue` y construir la consulta uniendo texto, como `"... VALUES (" + id + ", '" + nombre + "', ..."`? ¿Por qué importa?
- **(c) ⚡** ¿Qué devuelve `ExecuteNonQuery()` y qué significa la comparación `> 0`?
- **(d) ⚡** El `catch` crea una excepción **nueva** con el mensaje de la original. ¿Qué información crees que se pierde?

---

## Parte 4 · Programar desde cero (25 min)

Puedes usar tu editor y ejecutar. **Sin IA.** Para cada programa, antes de escribir código anota en 2–3 líneas tu plan (qué datos entran, qué pasos sigues, qué sale). Al terminar, prueba con al menos **tres entradas distintas** y anota los resultados.

**E1 ⚡ · Par o impar.** Pide un número entero. Si el texto no es un entero válido, muestra `Entrada no válida` y termina. Si lo es, muestra `par` o `impar`.

**E2 · Estadísticas hasta el cero.** Lee números enteros hasta que la persona escriba `0`. Al terminar, muestra cuántos números se ingresaron (sin contar el 0), su suma, su promedio con dos decimales y el mayor. Si no se ingresó ninguno, muestra `No hay datos`. Si el usuario escribe algo que no es un número, avisa y vuelve a pedir ese dato (no debe terminar el programa).

**E3 · Contar vocales.** Escribe un método `ContarVocales(string texto)` que devuelva cuántas vocales (`a, e, i, o, u`, en mayúscula o minúscula; sin contar las que llevan tilde) tiene el texto. Úsalo en un programa que lea una frase y muestre el resultado. Piensa y prueba: cadena vacía, solo consonantes, mayúsculas.

---

## Parte 5 · SQL (10 min)

Tablas de una academia:

```text
Departamentos(IdDepartamento PK, Nombre)
Empleados(IdEmpleado PK, Nombre, Salario, IdDepartamento FK -> Departamentos)
```

Escribe las consultas (en papel o texto; no hace falta ejecutarlas):

- **Q1.** Nombre y salario de los empleados con salario mayor que 500, del salario más alto al más bajo.
- **Q2.** Nombre de cada departamento y cuántos empleados tiene.
- **Q3.** Nombres de los departamentos que **no** tienen ningún empleado.
- **Q4.** ¿Qué hace exactamente esta sentencia y por qué es peligrosa? `UPDATE Empleados SET Salario = 600;`

---

## Parte 6 · Herramientas (5 min)

- **H1.** ¿Qué hace `git commit` y qué hace `git push`? ¿Cuál de las dos necesita conexión a internet?
- **H2.** Estás en la terminal en `C:\Proyectos`. Escribe los comandos para crear la carpeta `Hola`, entrar en ella y crear un proyecto de consola llamado `Hola`.
- **H3.** ¿Qué son las carpetas `bin` y `obj` de un proyecto de .NET y por qué no se suben a Git?
- **H4.** En tu editor (Visual Studio o VS Code), ¿cómo pones un punto de interrupción y cómo avanzas una sola línea?

---

## Parte 7 · Contexto (5 min, sin respuesta correcta)

- **R1.** De tu proyecto anterior, ¿qué partes escribiste tú sin ayuda y cuáles no podrías reescribir hoy sin ayuda?
- **R2.** ¿Qué parte de programar te resulta más difícil o te frustra más?
- **R3.** ¿Qué sistema operativo usas y qué editor prefieres? ¿Tienes ya instalado .NET SDK y SQL Server? (No hace falta que lo hayas verificado; dime lo que crees).
- **R4.** ¿Cuántos días por semana puedes estudiar de verdad las 2 horas y a qué hora del día?

---

## Qué pasa después

1. Entregas tus respuestas (en la conversación o en un archivo).
2. Las califico con el solucionario y te devuelvo un **mapa de niveles por área** (entorno, fundamentos, control de flujo, métodos y colecciones, POO, SQL, herramientas) con recomendación para cada una: *saltar con examen de salto*, *ritmo rápido*, *ritmo normal* o *reforzar*.
3. Se registra en [PROGRESO.md](../../PROGRESO.md) y [progreso/evaluaciones.md](../../progreso/evaluaciones.md).
4. Se ajusta la lección 0.1 y las siguientes según el resultado.
