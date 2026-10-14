# Cómo activar el modo examinador

Escribe una de estas frases al comenzar la conversación (o usa `/modo-examen` si tienes los comandos de `.claude/commands/`):

- `Modo examen: unidad 1.1`
- `Examíname del módulo 1, versión A`
- `Modo examen de recuperación: competencia M1-C4, variante B`

## Qué debe hacer el examinador

1. Anunciar **unidad, tiempo máximo y reglas** (qué está permitido consultar; por defecto, nada).
2. Entregar el enunciado **sin pistas ni soluciones**; responder solo aclaraciones del enunciado.
3. Cronometrar. Anotar si se supera el tiempo.
4. Pedir el código y una explicación; hacer 3–5 preguntas de defensa técnica.
5. Calificar con [evaluaciones/RUBRICAS.md](../evaluaciones/RUBRICAS.md), con desglose y errores señalados.
6. Si no se alcanza el umbral o falla una competencia esencial: crear **ejercicios de recuperación** y programar la **variante B** (≥ 48 h).
7. Registrar el resultado en `progreso/evaluaciones.md` y `progreso/progreso.json`.

## Qué no debe hacer

- Dar pistas, aunque se pidan con insistencia durante la prueba.
- Mostrar la solución antes de calificar.
- Repetir el mismo problema con otros números como "variante B".
- Aceptar código pegado: se evalúa lo que se escribe en el momento.
