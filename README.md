# Formación como desarrollador de software: C#, SQL Server y ASP.NET Core

Un sistema de aprendizaje **práctico, progresivo y exigente** para pasar de principiante a poder postularte a puestos junior de desarrollo, con evidencia real de lo que sabes hacer. Está en español, usa **.NET 10 (LTS) y C# 14**, y se apoya en un instructor (Claude Code) que evalúa tu dominio de verdad, no tu memoria.

> **Este curso no promete** que estés listo para cualquier empleo al terminar. Promete fundamentos sólidos, proyectos defendibles y un mapa honesto de lo que dominas y lo que te falta. Los plazos son de referencia: **avanzas cuando demuestras competencia**, no cuando pasa el tiempo.

---

## Por dónde empezar (5 minutos)

1. Lee [PLAN_DE_ESTUDIO.md](PLAN_DE_ESTUDIO.md): la ruta, las puertas de avance y la sesión de 2 horas.
2. Lee [REGLAS_DE_APRENDIZAJE.md](REGLAS_DE_APRENDIZAJE.md): cómo usar la IA para aprender, no para evitar aprender.
3. Haz el **diagnóstico**: [evaluaciones/00-diagnostico/DIAGNOSTICO.md](evaluaciones/00-diagnostico/DIAGNOSTICO.md). Primero la *ronda rápida* (elementos ⚡).
4. Abre [PROGRESO.md](PROGRESO.md) para ver **dónde estás hoy y qué toca**.
5. Empieza por la [Unidad 0.1](modulos/M00-entorno-y-metodo/00.01-que-es-programar.md).

---

## Mapa de archivos

| Qué buscas | Dónde está |
|---|---|
| **La ruta completa** (mapa, puertas, versiones, decisiones) | [PLAN_DE_ESTUDIO.md](PLAN_DE_ESTUDIO.md) |
| **Calendario** semana a semana (28 semanas) | [CALENDARIO.md](CALENDARIO.md) |
| **Índice** de los 12 módulos y 103 unidades, con su estado | [INDICE.md](INDICE.md) |
| **Tu progreso** (punto de reanudación diario) | [PROGRESO.md](PROGRESO.md) y [progreso/](progreso/) |
| **Reglas** (tú, yo y la IA) | [REGLAS_DE_APRENDIZAJE.md](REGLAS_DE_APRENDIZAJE.md) |
| **Lecciones y retos** | [modulos/](modulos/README.md) |
| **Soluciones** (separadas; abrir tras tres intentos) | [soluciones/](soluciones/README.md) |
| **Evaluaciones y rúbricas** | [evaluaciones/](evaluaciones/README.md) |
| **Proyectos** (P1–P6) | [proyectos/](proyectos/README.md) |
| **Tu código** | [practica/](practica/README.md) |
| **Plantillas** (bitácora, tabla de pruebas, README de proyecto…) | [plantillas/](plantillas/) |
| **Versiones y enlaces** (qué se verificó y qué no) | [recursos/](recursos/README.md) |
| **Lo que falta construir** del curso | [PENDIENTES_DEL_CURSO.md](PENDIENTES_DEL_CURSO.md) |
| **Herramientas de verificación** | [herramientas/](herramientas/README.md) |
| **Instrucciones para el instructor** (Claude Code) | [CLAUDE.md](CLAUDE.md) |

---

## Estructura de archivos

```text
.
├── README.md · CLAUDE.md · PLAN_DE_ESTUDIO.md · INDICE.md · CALENDARIO.md · PROGRESO.md
├── REGLAS_DE_APRENDIZAJE.md · PENDIENTES_DEL_CURSO.md
├── modulos/            M00 … M11: README del módulo, lecciones NN.MM-*.md y retos/
├── soluciones/         soluciones separadas de los retos; evaluaciones/ con solucionarios y variantes B
├── evaluaciones/       RUBRICAS.md, 00-diagnostico/, semana-01/ …
├── proyectos/          P1 … P6: ESPECIFICACION.md + tu codigo/
├── practica/           TU código
├── progreso/           progreso.json, competencias.md, evaluaciones.md, errores-recurrentes.md,
│                       repasos.md y bitacora/ (una por sesión)
├── plantillas/         lección, reto, evaluación, bitácora, tabla de pruebas, README de proyecto…
├── recursos/           VERSIONES.md, ENLACES.md y datos de verificación
├── herramientas/       curriculo.json (fuente única) y scripts de verificación
├── .claude/commands/   /iniciar-sesion · /cerrar-sesion · /modo-examen · /repaso
└── cs/ db/ entrega_*/ GUIA_CAMBIOS.md *.pdf    ← proyecto previo, intacto
```

## Estado de este material

**Entrega 1 (esta):** sistema completo + **semana 1 completa** (unidades 0.1, 0.2, 0.3, 0.4 y 1.1 con sus retos, soluciones y evaluación) + el programa detallado de todos los módulos y las especificaciones de los seis proyectos. El resto de las lecciones se construye **por fases** (ver [PENDIENTES_DEL_CURSO.md](PENDIENTES_DEL_CURSO.md)), siempre justo antes de que las necesites y adaptadas a tus resultados.

Todo el código de las lecciones, los retos y las soluciones se **ejecutó** con el SDK de .NET 10. Lo que no se pudo ejecutar (comandos de PowerShell de Windows, depurador gráfico, instaladores, enlaces de `learn.microsoft.com`) está **marcado como no verificado** en [recursos/VERSIONES.md](recursos/VERSIONES.md) y [recursos/ENLACES.md](recursos/ENLACES.md).

---

## Cómo es un día

Dos horas, cuatro bloques (flexibles si un reto importante necesita más tiempo):

| Bloque | Min | Qué haces |
|---|---|---|
| Explicación y estudio | 20 | Lees la parte teórica de la lección |
| Programación práctica | 40 | Ejemplos y ejercicios guiados, **escribiendo tú** |
| Retos y depuración | 30 | Retos de nivel 2–4; aquí se aprende más |
| Recuperación, evaluación y registro | 30 | Repaso sin apuntes, criterios de dominio, **cierre de 5 puntos** |

Días con poco tiempo: la **sesión mínima** de 30–45 minutos (máximo 2 por semana, que se recuperan). Detalle en el [plan](PLAN_DE_ESTUDIO.md#7-la-sesión-de-2-horas).

---

## Continuar en futuras sesiones

El curso está pensado para retomarse **desde el estado real registrado**, nunca desde la memoria.

**Al empezar una sesión** (di "iniciemos la sesión", o usa `/iniciar-sesion` si tienes los comandos del proyecto):

1. El instructor lee [PROGRESO.md](PROGRESO.md), `progreso/progreso.json`, la última bitácora, `progreso/errores-recurrentes.md` y `progreso/repasos.md`, y mira tu último trabajo en `practica/`.
2. Te dice dónde estás, qué sigue y qué repasos vencen.
3. Hace un calentamiento de repaso sin apuntes y continúa con la unidad correspondiente.

**Al terminar:**

1. Cierre de 5 puntos en la bitácora (`/cerrar-sesion`).
2. Se actualizan `PROGRESO.md`, `progreso.json`, errores recurrentes y repasos.
3. **Commit y push**: las sesiones en la nube no conservan archivos entre ellas; **si no está en el repositorio, no existe**.

**Si trabajas en tu equipo local** (Visual Studio / VS Code) **y con Claude Code en la nube**, el flujo seguro es:

| Cuándo | Qué haces |
|---|---|
| Al empezar | `git pull` de la rama de trabajo |
| Mientras estudias | Escribes en `practica/` y haces commits pequeños |
| Al terminar | `git push` de `practica/` → el instructor revisa tu código |
| En la sesión con el instructor | Él escribe en `progreso/`, `PROGRESO.md` y el contenido nuevo; tú **no** editas esos archivos a mano para evitar conflictos |

La rama de trabajo actual es `claude/wizardly-cray-4h7n54` (ver `git branch`). Decidir cuándo y cómo fusionarla con la rama principal queda **a tu criterio**.

---

## Sobre los archivos que ya estaban aquí

Este repositorio ya contenía un proyecto anterior (aplicación de escritorio de gestión de activos y personal, con base de datos SQL Server, guías en PDF y carpetas de entregas). **No se ha tocado, movido ni modificado nada de eso**: `cs/`, `db/`, `entrega_*`, `GUIA_CAMBIOS.md` y los PDF siguen exactamente como estaban.

Se usará **con tu autorización**:

- En el **diagnóstico** (el ejercicio L5 lee un fragmento de `cs/Activo.cs`).
- En el **módulo 8** como caso de *mantenimiento de código existente* (leer, entender, probar, mejorar sin romper).
- Como una de las opciones para el **proyecto final** (reconstruir ese dominio con tu propio diseño y código).

---

## Licencia y uso

Material de estudio personal. Los fragmentos de documentación oficial que se citan pertenecen a sus autores y se enlazan, no se copian.
