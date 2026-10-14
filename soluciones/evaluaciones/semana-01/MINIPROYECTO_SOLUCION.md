# Solución de referencia · Mini-proyecto de la semana 1 (Ficha de estudio v2)

> **No abrir antes de entregar.** Código verificado con .NET SDK 10.
> Enunciado: [evaluaciones/semana-01/MINIPROYECTO_SEMANA_01.md](../../../evaluaciones/semana-01/MINIPROYECTO_SEMANA_01.md)

## Solución

<!--v
modo: ejecuta
salida: siguiente
-->
```csharp
int sesionesPorSemana = 6;
int horasPorSesion = 2;
int semanas = 28;
int horasCompletadas = 12;

int horasPorSemana = sesionesPorSemana * horasPorSesion;
int horasTotales = horasPorSemana * semanas;
decimal avance = horasCompletadas * 100m / horasTotales;

Console.WriteLine("===== FICHA DE ESTUDIO =====");
Console.WriteLine($"Sesiones por semana: {sesionesPorSemana}");
Console.WriteLine($"Horas por sesión: {horasPorSesion}");
Console.WriteLine($"Horas por semana: {horasPorSemana}");
Console.WriteLine($"Semanas del plan: {semanas}");
Console.WriteLine($"Horas totales: {horasTotales}");
Console.WriteLine($"Horas completadas: {horasCompletadas}");
Console.WriteLine($"Avance: {avance:F2}%");
```

```text
===== FICHA DE ESTUDIO =====
Sesiones por semana: 6
Horas por sesión: 2
Horas por semana: 12
Semanas del plan: 28
Horas totales: 336
Horas completadas: 12
Avance: 3.57%
```

## Por qué funciona (y por qué falla la versión ingenua)

`horasCompletadas * 100m / horasTotales`: el `100m` es `decimal`, así que `int * decimal` da `decimal` y la división `decimal / int` también es decimal. Si se escribe `horasCompletadas * 100 / horasTotales` (todo `int`), el resultado es la **división entera**: `1200 / 336 = 3` y el avance saldría como `3` o `3.00`. Con `336` horas completadas, la ingenua sí daría `100`; con `168`, `50`; el error aparece con valores que no son múltiplos exactos, como `12`.

Demostración del error:

<!--v
modo: ejecuta
salida: siguiente
-->
```csharp
int horasCompletadas = 12;
int horasTotales = 336;
decimal avanceMalo = horasCompletadas * 100 / horasTotales;
Console.WriteLine($"Avance ingenuo: {avanceMalo:F2}%");
```

```text
Avance ingenuo: 3.00%
```

## Casos de prueba (versión de prueba con lectura de las horas completadas)

<!--v
modo: ejecuta
caso: 12 => Avance: 3.57%
caso: 336 => Avance: 100.00%
caso: 0 => Avance: 0.00%
caso: 168 => Avance: 50.00%
caso: 400 => Avance: 119.05%
-->
```csharp
int sesionesPorSemana = 6;
int horasPorSesion = 2;
int semanas = 28;
int horasCompletadas = int.Parse(Console.ReadLine() ?? "0");

int horasPorSemana = sesionesPorSemana * horasPorSesion;
int horasTotales = horasPorSemana * semanas;
decimal avance = horasCompletadas * 100m / horasTotales;

Console.WriteLine("===== FICHA DE ESTUDIO =====");
Console.WriteLine($"Sesiones por semana: {sesionesPorSemana}");
Console.WriteLine($"Horas por sesión: {horasPorSesion}");
Console.WriteLine($"Horas por semana: {horasPorSemana}");
Console.WriteLine($"Semanas del plan: {semanas}");
Console.WriteLine($"Horas totales: {horasTotales}");
Console.WriteLine($"Horas completadas: {horasCompletadas}");
Console.WriteLine($"Avance: {avance:F2}%");
```

## Sobre el caso `400`

Avance de `119.05%` no tiene sentido (nadie completa más del 100 % del plan). **Lo correcto es validar la entrada**: si `horasCompletadas` supera `horasTotales`, informar del error o limitar el valor. Para eso hace falta `if` (unidad 1.5) y, en una versión posterior, validación de datos del usuario (unidad 1.4).

## README de ejemplo (5–8 líneas)

```text
# Ficha de estudio v2

Programa de consola que muestra el plan de estudio (sesiones, horas, semanas) y el porcentaje de avance.
Ejecutar: `dotnet run` dentro de la carpeta del proyecto.
Decisión técnica: el avance se calcula con `decimal` (multiplicando por `100m`) para evitar la división entera
y se muestra con dos decimales con `{avance:F2}`.
Límite conocido: no valida que las horas completadas sean ≤ horas totales.
```

## Historial de Git sugerido (≥ 4 commits)

1. `Crea el proyecto FichaEstudio2 a partir de la ficha anterior`
2. `Agrega las horas completadas`
3. `Calcula el avance como decimal para no perder los decimales`
4. `Da formato al avance y agrega el README`
