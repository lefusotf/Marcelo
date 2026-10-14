# Mini-proyecto de la semana 1 · Ficha de estudio v2

**Tiempo:** 30 minutos · **Dónde:** `practica/semana-01/miniproyecto/FichaEstudio2/` · **Entrega:** commits en Git + un `README.md` breve.
**Qué integra:** proyecto con `dotnet` (0.3), tipos y `decimal` (1.1), depuración y pruebas (0.4), Git (0.3).

## Contexto

Ya hiciste la ficha del plan de estudio. Ahora debe mostrar **cuánto llevas avanzado**, con un porcentaje.

## Requisitos funcionales

1. Partir de tu ficha del reto R-0.3-N3-A (sesiones por semana, horas por sesión, semanas del plan; horas por semana y horas totales **calculadas**).
2. Añadir `horasCompletadas` (un `int` en el código; por ejemplo `12`).
3. Calcular el **porcentaje de avance** = horas completadas ÷ horas totales × 100, como `decimal`.
4. Mostrar exactamente:

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

## Restricciones técnicas

- El porcentaje debe ser correcto con decimales: cuidado con la **división entera**.
- Ningún resultado escrito a mano. Los datos de entrada son variables o constantes con nombre.
- El avance se muestra con **dos decimales**.
- Al menos **cuatro commits** con mensajes concretos.

## Casos de prueba

| `horasCompletadas` | Salida de `Avance` |
|---|---|
| 12 | `3.57%` |
| 336 | `100.00%` |
| 0 | `0.00%` |
| 168 | `50.00%` |
| 400 | `119.05%` *(todavía no hay validación: anota qué te parece este resultado y cómo lo resolverías con lo que aprenderás en 1.5)* |

## Criterios de aceptación

- [ ] Compila sin errores ni advertencias que ignoraste sin entender.
- [ ] Las cinco filas de la tabla se cumplen.
- [ ] `git log --oneline` cuenta la historia en al menos 4 pasos.
- [ ] El `README.md` explica en 5–8 líneas qué hace, cómo ejecutarlo (`dotnet run`) y qué decisión técnica tomaste (por ejemplo, por qué `decimal` para el porcentaje).
- [ ] Anotaste en tu bitácora qué te costó más y qué error cometiste.

## Pista de método (no es la solución)

Antes de programar, calcula a mano `12 × 100 ÷ 336` y decide **en qué tipo** se hace cada paso. Prueba primero con la fila de `336` (debería dar 100): si da `0` o `99`, hay un problema de tipos.

## Rúbrica (se califica con la rúbrica A de RUBRICAS.md)

| Criterio | Puntos |
|---|---|
| Corrección funcional | 35 |
| Comprensión y razonamiento | 20 |
| Calidad y organización (nombres, constantes, commits) | 15 |
| Validaciones y casos límite | 15 |
| Pruebas y explicación | 15 |

> La solución de referencia está en `soluciones/evaluaciones/semana-01/`. Ábrela solo después de entregar.
