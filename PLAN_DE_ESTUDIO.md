# Plan de estudio: de cero a desarrollador junior con C#, SQL Server y ASP.NET Core

> Punto de referencia permanente. Si algo de aquí cambia (orden, plazos, criterios), se cambia **aquí** y se anota en [PROGRESO.md](PROGRESO.md).
> Atajos: [INDICE.md](INDICE.md) · [CALENDARIO.md](CALENDARIO.md) · [REGLAS_DE_APRENDIZAJE.md](REGLAS_DE_APRENDIZAJE.md) · [evaluaciones/RUBRICAS.md](evaluaciones/RUBRICAS.md)

---

## 1. Objetivo y perfil de partida

**Objetivo final:** poder postularte a puestos de desarrollo de software de nivel de entrada (junior/prácticas) con evidencia real: código propio, proyectos publicados y capacidad de defenderlos.

**Perfil de partida (declarado por ti):** principiante en fundamentos; contacto previo con C#, SQL Server, aplicaciones de escritorio y proyectos por capas, con parte del código generado con ayuda de IA. **Por eso no se asume ningún fundamento:** el diagnóstico inicial ([evaluaciones/00-diagnostico/](evaluaciones/00-diagnostico/DIAGNOSTICO.md)) mide qué dominas de verdad y se puede *saltar* lo ya demostrado (sección 6.3).

**Disponibilidad:** 2 horas diarias. Plan de referencia: 6 sesiones de 2 horas por semana (12 h) y un día de descanso.

**Idioma:** español. Identificadores de código y nombres de objetos de SQL Server sin `ñ` ni tildes.

---

## 2. Cómo se aprende aquí

| Principio | Qué significa en la práctica |
|---|---|
| **Aprender haciendo** | Cada lección es 20 min de lectura y 100 min de práctica. |
| **Práctica deliberada** | Retos de cuatro niveles (comprensión, aplicación, independiente, transferencia) con dificultad progresiva. |
| **Recuperación espaciada** | Cada sesión cierra con preguntas de sesiones anteriores (+1, +3, +7, +14, +30 días). |
| **Entrelazado** | Los retos de transferencia mezclan temas nuevos con anteriores. |
| **Retroalimentación sincera** | Rúbricas con puntuación desglosada; errores señalados sin adornos. |
| **Dominio antes que avance** | Se avanza por **puertas** con evidencia, no por calendario. |
| **Proyectos reales** | Seis proyectos de dificultad creciente que se defienden oralmente. |
| **La IA como herramienta de aprendizaje** | Reglas en [REGLAS_DE_APRENDIZAJE.md](REGLAS_DE_APRENDIZAJE.md). |

---

## 3. Mapa de la ruta

```
FASE A · Fundamentos (sem. 1-6)
  M0 Entorno y método ─► M1 Fundamentos ─► M2 Lógica y resolución de problemas
                          └─ P1 Programas de consola (sem. 4)        ◄ PUERTAS 1 y 2

FASE B · POO y estructuras (sem. 7-11)
  M3 C# intermedio y POO ─► M4 Estructuras de datos y algoritmos
        └─ P2 Gestión de registros (sem. 9)                         ◄ PUERTAS 3 y 4

FASE C · Datos (sem. 12-17)
  M5 SQL Server ─► M6 C# conectado a bases de datos
                    └─ P3 Aplicación con SQL Server (sem. 17)       ◄ PUERTAS 5 y 6

FASE D · Oficio profesional (sem. 17-20)
  M7 Git, GitHub y flujo de trabajo ─► M8 Calidad y mantenimiento
                                        └─ P4 Aplicación en capas (sem. 20)  ◄ PUERTAS 7 y 8

FASE E · Web, portafolio y empleabilidad (sem. 21-28)
  M9 ASP.NET Core ─► P5 API con persistencia (sem. 23)              ◄ PUERTA 9
  P6 Proyecto final (sem. 24-26) ─► M11 Preparación laboral (sem. 24-28)  ◄ PUERTA FINAL
```

**Dependencias que importan:** no se empieza SQL con C# conectado sin M3 (clases) y M5; no se empieza ASP.NET Core sin M6 (acceso a datos) y M8 (pruebas y capas); no se empieza M11 en serio sin al menos P3.

---

## 4. Módulos de un vistazo

<!-- AUTO:MODULOS:INICIO -->
| Módulo | Semanas | Unidades | Resumen |
|---|---|---|---|
| M0 · Preparación del entorno y método de aprendizaje | 1 | 4 | Qué es programar, cómo pasa el código fuente a programa en ejecución, tu entorno de trabajo, la terminal, los errores, el depurador y el método de estudio. |
| M1 · Fundamentos de programación | 1–4 | 15 | Variables, tipos, entrada y salida, operadores, condicionales, bucles, métodos, colecciones básicas, cadenas, pseudocódigo y depuración. |
| M2 · Lógica y resolución de problemas | 5–6 | 9 | Descomponer, modelar entradas, procesos y salidas, construir algoritmos, probar casos límite, patrones clásicos y complejidad introductoria. |
| M3 · C# intermedio y programación orientada a objetos | 7–9 | 11 | Clases, encapsulación, composición, interfaces, herencia, tipos por valor y referencia, colecciones genéricas, LINQ básico, excepciones y buenas prácticas. |
| M4 · Estructuras de datos y fundamentos de algoritmos | 10–11 | 9 | Cómo funcionan y cuánto cuestan las estructuras habituales; búsqueda, ordenamiento, recursividad y razonamiento sobre complejidad. |
| M5 · Bases de datos y SQL Server | 12–14 | 12 | Modelo relacional, consultas, modificación de datos, diseño y normalización, restricciones, índices, transacciones e inyección SQL. |
| M6 · C# conectado a bases de datos | 15–16 | 9 | ADO.NET con Microsoft.Data.SqlClient, CRUD seguro, capas, transacciones, async/await y una primera mirada a Entity Framework Core. |
| M7 · Herramientas y flujo de trabajo profesional | 17–18 | 7 | Git y GitHub a fondo, terminal, convenciones, depuración avanzada, revisión de código, documentación y trabajo por iteraciones. |
| M8 · Calidad y mantenimiento del software | 19–20 | 8 | Pruebas, refactorización, capas, inyección de dependencias, registros, seguridad básica y mantenimiento de aplicaciones existentes. |
| M9 · Desarrollo web con ASP.NET Core | 21–23 | 12 | HTTP, lo esencial de HTML, CSS y JavaScript, APIs REST con ASP.NET Core, acceso a datos, autenticación, configuración, documentación y publicación. |
| M10 · Proyectos integradores | 9, 17, 20, 23, 24–26 (proyectos) | 0 | Seis proyectos de dificultad creciente que integran lo aprendido. Las especificaciones están en proyectos/; este módulo no tiene lecciones propias. |
| M11 · Preparación para el mundo laboral | 24–28 | 7 | Expectativas de un junior, ofertas, CV y GitHub honestos, defensa de decisiones, preguntas frecuentes, entrevistas, pruebas con tiempo y búsqueda de oportunidades. |
<!-- AUTO:MODULOS:FIN -->

El detalle unidad por unidad está en [INDICE.md](INDICE.md) y el programa de cada módulo en `modulos/<módulo>/README.md`.

---

## 5. Puertas de avance

Una **puerta** es el punto donde se decide si pasas a lo siguiente. Hay dos niveles de control.

### 5.1 Evaluación semanal (sesión S6)

Mide las unidades de la semana más un repaso de semanas anteriores.

| Resultado | Qué ocurre |
|---|---|
| **≥ 80/100** y reglas esenciales cumplidas (ver 5.3) | Las unidades pasan a **dominada**. Sigues con la semana siguiente. |
| **60–79** | Las unidades quedan **practicada**. Haces los ejercicios de recuperación indicados (≈ 30 min extra repartidos en las 3 sesiones siguientes) y se te reevalúa con un ejercicio distinto en el S6 siguiente. Sigues con la semana siguiente. |
| **< 60** o falla una competencia esencial | **No avanzas.** Semana de recuperación: otra explicación, ejercicios dirigidos y nueva evaluación con otro problema (variante B). |

### 5.2 Puertas de módulo y de proyecto

| Puerta | Semana | Qué debe quedar demostrado para avanzar |
|---|---|---|
| **1** | 4 | Módulo 1 evaluado ≥ 80 · Proyecto P1 defendido ≥ 80 · competencias M1-C1…C9 demostradas |
| **2** | 6 | Módulo 2 ≥ 80 · prueba acumulativa sin apuntes ≥ 70 · M2-C1…C7 |
| **3** | 9 | Módulo 3 ≥ 80 · P2 defendido ≥ 80 · M3-C1…C8 |
| **4** | 11 | Módulo 4 ≥ 80 · sesión de construcción sin IA superada · M4-C1…C5 |
| **5** | 14 | Módulo 5 ≥ 80 · prueba de SQL sin apuntes ≥ 70 · diseño de BD del caso integral aprobado · M5-C1…C7 |
| **6** | 17 | Módulo 6 ≥ 80 · P3 defendido ≥ 80 (sin credenciales en el repositorio) · M6-C1…C6 |
| **7** | 18 | Módulo 7 ≥ 80 · un *pull request* propio revisado y fusionado · M7-C1…C6 |
| **8** | 20 | Módulo 8 ≥ 80 · P4 defendido ≥ 80 con pruebas pasando · M8-C1…C7 |
| **9** | 23 | Módulo 9 ≥ 80 · P5 defendido ≥ 80 y publicado o ejecutable con instrucciones · M9-C1…C7 |
| **Final** | 26 | P6 defendido ≥ 80 · evaluación global ≥ 80 · CV y GitHub revisados |

### 5.3 Reglas que se aplican siempre

1. **La teoría no compensa la práctica.** Un total ≥ 80 **no basta** si no se cumple alguna de estas condiciones:
   - El bloque de **programar desde cero** alcanza al menos el **70 %** de sus puntos y el programa **funciona** con las entradas normales.
   - Ningún bloque esencial (lista en [RUBRICAS.md](evaluaciones/RUBRICAS.md)) queda por debajo del **50 %**.
   - La **defensa técnica** (preguntas orales o escritas sobre tu propia solución) alcanza al menos el **60 %**.
2. **Competencia esencial fallada → recuperación específica.** Se te asignan ejercicios dirigidos a esa competencia y se te evalúa con un **problema diferente** (no el mismo con otros números) pasadas al menos 48 horas.
3. **Dos recuperaciones fallidas en la misma competencia** activan un *diagnóstico de causa* ([plantillas/diagnostico-de-causa.md](plantillas/diagnostico-de-causa.md)): se cambia el enfoque, no se repite la explicación.
4. **Las puertas no se compran con tiempo.** No hay "pasar por calendario".

### 5.4 Estados de una unidad

`no iniciada` → `en curso` → `practicada` (retos guiados e independientes hechos) → `dominada` (evaluación superada con los criterios del 5.1 y 5.3) → `consolidada` (superaste un repaso espaciado ≥ 7 días después y la prueba acumulativa que la incluye).

Solo se pasa a un estado superior con evidencia registrada en `progreso/`.

---

## 6. Calendario de referencia

<!-- AUTO:CALENDARIO:INICIO -->
| Sem. | Fase | Foco | Hito |
|---|---|---|---|
| 1 | A | Entorno, método y primeras variables | Evaluación semana 1 |
| 2 | A | Datos de entrada, operadores y decisiones | Evaluación semana 2 |
| 3 | A | Repetición y métodos | Evaluación semana 3 |
| 4 | A | Colecciones, cadenas y primer proyecto | Puerta 1: Módulo 1 y Proyecto 1 |
| 5 | A | Pensar antes de programar | Evaluación semana 5 |
| 6 | A | Patrones, errores y complejidad | Puerta 2: Módulo 2 |
| 7 | B | Clases y objetos | Evaluación semana 7 |
| 8 | B | Abstracción, colecciones y excepciones | Evaluación semana 8 |
| 9 | B | Buenas prácticas, LINQ y Proyecto 2 | Puerta 3: Módulo 3 y Proyecto 2 |
| 10 | B | Estructuras de datos | Evaluación semana 10 |
| 11 | B | Ordenamiento, recursividad y complejidad | Puerta 4: Módulo 4 |
| 12 | C | SQL I: modelo relacional y consultas básicas | Evaluación semana 12 |
| 13 | C | SQL II: JOIN, subconsultas y diseño | Evaluación semana 13 |
| 14 | C | SQL III: transacciones, seguridad y caso integral | Puerta 5: Módulo 5 |
| 15 | C | C# y SQL Server con ADO.NET | Evaluación semana 15 |
| 16 | C | Transacciones, async y EF Core | Evaluación semana 16 |
| 17 | C | Proyecto 3 y Git con ramas | Puerta 6: Módulo 6 y Proyecto 3 |
| 18 | D | Oficio: convenciones, depuración y revisión | Puerta 7: Módulo 7 |
| 19 | D | Pruebas, refactorización y capas | Evaluación semana 19 |
| 20 | D | Inyección de dependencias, registros y mantenimiento | Puerta 8: Módulo 8 y Proyecto 4 |
| 21 | E | La web y tu primera API | Evaluación semana 21 |
| 22 | E | API con datos, seguridad y configuración | Evaluación semana 22 |
| 23 | E | Documentar, publicar y Proyecto 5 | Puerta 9: Módulo 9 y Proyecto 5 |
| 24 | E | Proyecto final: alcance y diseño; primera evaluación global | Cierre del núcleo; decisión de ampliación |
| 25 | E | Proyecto final: construcción | P6 funcional (MVP) |
| 26 | E | Proyecto final: pulido y publicación | Puerta final: Proyecto 6 |
| 27 | E | Entrevistas y pruebas técnicas | Simulacros completados |
| 28 | E | Búsqueda de oportunidades y plan siguiente | Cierre de la ruta inicial |
<!-- AUTO:CALENDARIO:FIN -->

Detalle sesión por sesión: [CALENDARIO.md](CALENDARIO.md).

### 6.1 Por qué 28 semanas y no 24

Las **semanas 1–24** cubren toda la formación técnica y dejan el proyecto final en marcha. El proyecto final original (P6) y la preparación de entrevistas necesitan **cuatro semanas más** (25–28) para quedar con calidad de portafolio. Tu petición de 20–24 semanas se respeta para el **núcleo técnico**; comprimir el proyecto final y las entrevistas sacrificaría justo lo que más pesa al buscar trabajo.

### 6.2 Cuándo se alarga

El calendario es una **referencia**, no un compromiso. Cada puerta fallada añade una semana de recuperación. Es normal que la ruta real dure más (o menos) de lo previsto. **No es un fracaso; es el sistema funcionando.**

### 6.3 Cómo se puede acortar: el examen de salto

Si el diagnóstico o tu práctica indican que ya dominas una unidad, puedes pedir un **examen de salto**: se te evalúa esa unidad *sin estudiarla*. Con **≥ 85/100** y defensa técnica aprobada, la unidad pasa a *dominada* y recuperas la sesión. Solo se permite en las unidades de los módulos 0 y 1 (y SQL básico) y no sustituye a las puertas.

---

## 7. La sesión de 2 horas

| Bloque | Minutos | Qué se hace |
|---|---|---|
| **Explicación y estudio** | 20 | Lees la lección (secciones 1–8). Anotas dudas. No escribes código aún. |
| **Programación práctica** | 40 | Ejemplos comentados y ejercicios guiados, escribiendo tú. Predecir antes de ejecutar. |
| **Retos y depuración** | 30 | Retos de nivel 2–4. Aquí es donde más se aprende; si hace falta, este bloque se alarga. |
| **Recuperación, evaluación y registro** | 30 | Repaso de sesiones anteriores (sin apuntes), autoevaluación, criterios de dominio y cierre de 5 puntos en la bitácora. |

La distribución es flexible: **si un reto importante necesita más tiempo, se le da** a costa de los bloques 1–2, nunca del cierre.

### Sesión mínima (días con poco tiempo)

Si un día solo tienes **30–45 minutos**:

1. 10 min · repaso sin apuntes (3 preguntas del cierre de la sesión anterior).
2. 20–25 min · **un** reto de nivel 2 o 3 de la unidad en curso.
3. 5 min · registro corto en la bitácora.

**Límites:** máximo 2 sesiones mínimas por semana, y las dos horas completas que faltan se **recuperan** el fin de semana. No sustituye a la práctica completa.

### Sesión de evaluación (S6)

| Minutos | Contenido |
|---|---|
| 50 | Evaluación (sin apuntes, sin IA) |
| 30 | Mini-proyecto o integración de la semana |
| 20 | Corrección conjunta y defensa técnica |
| 20 | Recuperación dirigida, registro y plan de la semana siguiente |

---

## 8. Repaso acumulativo

| Cuándo | Qué |
|---|---|
| Cada sesión (bloque 4) | 3–5 preguntas o mini-ejercicios de sesiones previas (+1, +3, +7, +14 días). |
| Cada S6 | Un 20 % de la evaluación es de semanas anteriores. |
| Semanas 6, 11, 14 | Pruebas acumulativas sin apuntes ni IA. |
| Antes de cada puerta | Revisión de [errores recurrentes](progreso/errores-recurrentes.md). |
| Cada 4 semanas | Reconstruir de memoria un programa pequeño del módulo anterior. |

---

## 9. Tecnologías y versiones

Verificadas el **2026-10-14** (fuentes y límites de la verificación en [recursos/VERSIONES.md](recursos/VERSIONES.md)):

| Tecnología | Versión del curso | Nota |
|---|---|---|
| .NET | **10 (LTS)**, soporte hasta noviembre de 2028 | 10.0.13 era la última actualización el 2026-10-13. .NET 11 estaba en candidata a versión (RC); no se usa. |
| C# | **14** | Va con el SDK de .NET 10. |
| Editor | **Visual Studio 2026 Community** o **VS Code + C# Dev Kit** | Elige uno como principal. |
| SQL Server | **2022 o 2025** (Developer o Express) | Cualquiera sirve para todo el curso. |
| Herramienta SQL | **SSMS 22** o la **extensión MSSQL de VS Code** | Azure Data Studio dejó de tener soporte el 28-feb-2026. |
| Acceso a datos | **Microsoft.Data.SqlClient** y **EF Core 10** | `System.Data.SqlClient` está declarado obsoleto en NuGet. |
| Pruebas | **xUnit** | Se fija la versión al llegar al módulo 8. |
| Control de versiones | **Git** + **GitHub** | |

---

## 10. Decisiones de diseño del currículo

**Añadido a tu lista, con justificación:**
- **LINQ esencial (3.11):** se usa a diario en C# y es la base de las consultas de EF Core.
- **async/await esencial (6.7):** el acceso a datos y las APIs de ASP.NET Core son asíncronos; sin esto no se entiende el código real.
- **Git mínimo en la semana 1 (0.3):** desde el primer día tu trabajo queda versionado y revisable; la profundización queda en el módulo 7.
- **Pruebas de caracterización y mantenimiento (8.8):** tu proyecto previo sirve de caso real de código heredado.

**Dejado fuera a propósito** (no construyen fundamentos transferibles ahora): frameworks de front-end (React, Angular), Blazor/MVC con vistas, WPF/WinForms nuevos, Docker y nube, microservicios, patrones de diseño del GoF. Cada uno se retoma si un problema concreto lo justifica; la sección "Después de la ruta" de [PENDIENTES_DEL_CURSO.md](PENDIENTES_DEL_CURSO.md) los lista con su motivo.

**Tu proyecto previo** (carpetas `cs/`, `db/`, `entrega_*` y los PDF) se **conserva sin cambios**. Se usará en el módulo 8 como caso de mantenimiento de código existente y en el diagnóstico como material de lectura. Ningún archivo suyo se modifica sin tu autorización.

---

## 11. Qué no promete esta ruta

- **No promete que al terminar estés listo para cualquier empleo.** Promete formarte en fundamentos sólidos y darte evidencia verificable de lo que sabes hacer.
- **No sustituye experiencia en equipo real.** Prácticas o un primer puesto añaden lo que ningún curso individual da.
- **No garantiza contratación.** El mercado, tu ubicación y tu búsqueda también cuentan; el módulo 11 trabaja la parte que depende de ti.
- **El tiempo es una estimación.** El avance real depende de tus competencias demostradas.
