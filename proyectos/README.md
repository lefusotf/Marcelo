# Proyectos integradores

Seis proyectos de dificultad creciente. Cada uno integra lo aprendido hasta ese punto, se **defiende oralmente** y deja evidencia en tu portafolio.

| Proyecto | Semana | Qué integra | Especificación |
|---|---|---|---|
| **P1 · Colección de programas de consola** | 4 | Módulo 1 | [ESPECIFICACION](P1-programas-de-consola/ESPECIFICACION.md) |
| **P2 · Gestión de registros** | 9 | Módulos 1–3 | [ESPECIFICACION](P2-gestion-de-registros/ESPECIFICACION.md) |
| **P3 · Aplicación conectada a SQL Server** | 17 | Módulos 3, 5, 6 | [ESPECIFICACION](P3-aplicacion-con-sql-server/ESPECIFICACION.md) |
| **P4 · Aplicación estructurada en capas** | 20 | Módulos 6–8 | [ESPECIFICACION](P4-aplicacion-en-capas/ESPECIFICACION.md) |
| **P5 · API web con persistencia** | 23 | Módulos 6, 8, 9 | [ESPECIFICACION](P5-api-con-persistencia/ESPECIFICACION.md) |
| **P6 · Proyecto final original** | 24–26 | Todo | [ESPECIFICACION](P6-proyecto-final/ESPECIFICACION.md) |

## Cómo se trabaja un proyecto

1. **Requisitos.** Lees la especificación y escribes tus propios casos de uso en una página.
2. **Planificación.** Divides el trabajo en tareas de 30–60 minutos (hay una lista inicial en cada especificación; tú la ajustas).
3. **Diseño.** Antes de programar: diagrama sencillo de las piezas y de los datos. Se revisa conmigo.
4. **Implementación por iteraciones.** Tú escribes las partes centrales; yo te guío por etapas con preguntas y pistas (no construyo el proyecto por ti). Cada iteración termina con commit.
5. **Pruebas.** Tabla de pruebas ejecutada (módulos 1–7) o pruebas automáticas (desde el módulo 8).
6. **Documentación.** Un `README.md` propio dentro de `codigo/` a partir de [plantillas/readme-de-proyecto.md](../plantillas/readme-de-proyecto.md).
7. **Revisión y defensa.** Evaluación con la rúbrica D ([RUBRICAS.md](../evaluaciones/RUBRICAS.md)): funcionamiento, diseño, calidad, pruebas, documentación y defensa oral.

## Estructura de cada carpeta de proyecto

```text
proyectos/P1-programas-de-consola/
├── ESPECIFICACION.md    ← qué hay que construir (no se edita)
└── codigo/              ← TU proyecto (lo creas tú)
    ├── README.md        ← TU README (propósito, instalación, ejecución, decisiones)
    ├── (tu solución .sln / .csproj / código)
    └── pruebas/         ← tabla de pruebas o proyecto de pruebas
```

## Definición de "terminado"

Un proyecto está terminado cuando:

- [ ] Cumple los requisitos funcionales obligatorios y los criterios de aceptación.
- [ ] Se ejecuta siguiendo **solo** tu README.
- [ ] Tiene pruebas (tabla de pruebas ejecutada o automáticas) y están en verde.
- [ ] No contiene **credenciales, cadenas de conexión reales, claves ni datos personales reales** (bloqueante: si se subieron, se **rotan** además de borrarse).
- [ ] Puedes explicar cada parte central y cambiar algo pequeño en vivo.
- [ ] Tu historial de Git cuenta cómo lo hiciste (commits pequeños y claros).

## Reglas de honestidad

- El código es **tuyo**. Si usas una idea de una documentación o tutorial, la entiendes y la reescribes tú.
- Si usas ayuda (pista, explicación), se anota en la bitácora con el peldaño de la escalera de ayuda.
- En la defensa te pediré explicar y modificar partes del proyecto. Lo que no puedas explicar, no cuenta.
