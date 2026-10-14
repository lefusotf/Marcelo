# Módulo 9 · Desarrollo web con ASP.NET Core

> **Semanas:** 21–23 · **Fase:** E · Web y portafolio · [Plan de estudio](../../PLAN_DE_ESTUDIO.md) · [Índice](../../INDICE.md) · [Calendario](../../CALENDARIO.md)

## Objetivo

Entender HTTP y lo esencial de la web, construir una API REST con ASP.NET Core con acceso a datos, validación, autenticación y autorización, documentarla, probarla y publicarla.

## Por qué importa

Las APIs web son el punto de entrada más común al desarrollo con .NET y la pieza que más se pide en ofertas junior.

## Requisitos previos

Módulos 6 y 8 dominados.

## Competencias de salida

Estas competencias se registran en [progreso/competencias.md](../../progreso/competencias.md) y solo se marcan como *demostradas* con evidencia (programa, evaluación o defensa).

| Código | Al terminar el módulo… |
|---|---|
| M9-C1 | Explico el ciclo petición–respuesta de HTTP y leo una petición y una respuesta reales. |
| M9-C2 | Entiendo HTML, CSS y JavaScript lo suficiente para consumir y depurar un cliente web sencillo. |
| M9-C3 | Construyo una API REST con rutas, verbos y códigos de estado correctos. |
| M9-C4 | Uso DTOs, validación y manejo de errores consistentes. |
| M9-C5 | Conecto la API a SQL Server mediante EF Core. |
| M9-C6 | Implemento autenticación y autorización y almaceno contraseñas de forma segura. |
| M9-C7 | Gestiono configuración y secretos, documento y pruebo la API y la publico. |

## Unidades

<!-- AUTO:UNIDADES:INICIO -->
| Unidad | Sem. | Qué cubre | Lección | Retos | Soluciones |
|---|---|---|---|---|---|
| 9.1 Fundamentos de HTTP: solicitudes y respuestas | 21 | cliente y servidor; URL, método, cabeceras y cuerpo; códigos de estado; observar tráfico real | ⏳ | ⏳ | ⏳ |
| 9.2 HTML y CSS esenciales | 21 | estructura de un documento; formularios; selectores y caja; lo justo para entender una página | ⏳ | ⏳ | ⏳ |
| 9.3 JavaScript esencial y consumo de una API | 21 | variables y funciones; el DOM; fetch y JSON; consola del navegador | ⏳ | ⏳ | ⏳ |
| 9.4 ASP.NET Core: primer endpoint, rutas y controladores | 21 | estructura de un proyecto web; endpoints; enrutamiento; controladores | ⏳ | ⏳ | ⏳ |
| 9.5 APIs REST: verbos, códigos de estado y JSON | 21 | recursos y rutas; GET, POST, PUT, PATCH y DELETE; códigos de estado correctos; serialización JSON | ⏳ | ⏳ | ⏳ |
| 9.6 DTOs, validaciones y manejo de errores | 22 | modelos de dominio frente a DTOs; validación de entrada; respuestas de error consistentes; ProblemDetails | ⏳ | ⏳ | ⏳ |
| 9.7 Acceso a datos desde una API | 22 | EF Core en una API; inyección del DbContext; paginación y filtros; async de extremo a extremo | ⏳ | ⏳ | ⏳ |
| 9.8 Contraseñas y autenticación | 22 | hash con sal; registro e inicio de sesión; tokens JWT; qué nunca hacer | ⏳ | ⏳ | ⏳ |
| 9.9 Autorización | 22 | roles y políticas; proteger endpoints; autorización a nivel de recurso; pruebas de acceso denegado | ⏳ | ⏳ | ⏳ |
| 9.10 Configuración, secretos y variables de entorno | 22 | appsettings; entornos; User Secrets; variables de entorno en producción | ⏳ | ⏳ | ⏳ |
| 9.11 Documentación y pruebas de APIs | 23 | OpenAPI; pruebas manuales con herramientas; pruebas automáticas de endpoints; colecciones de peticiones | ⏳ | ⏳ | ⏳ |
| 9.12 Publicación de una aplicación | 23 | publicar y empaquetar; configuración por entorno; plataforma de alojamiento; lista de verificación previa | ⏳ | ⏳ | ⏳ |
<!-- AUTO:UNIDADES:FIN -->

Cada unidad seguirá la [plantilla de lección](../../plantillas/leccion.md) de quince secciones, con un archivo de retos de cuatro niveles en `retos/` y soluciones separadas en `soluciones/M09-desarrollo-web-aspnet-core/` (se crean al desarrollar el módulo; protocolo en [soluciones/README.md](../../soluciones/README.md)).

## Cómo se trabaja este módulo

HTML/CSS/JS son *lo justo* para comprender un cliente y depurarlo; el centro es la API. Se usa EF Core 10 y se aplican desde el inicio las prácticas de seguridad del módulo 8.

## Errores típicos de este módulo

Devolver entidades de base de datos directamente · códigos de estado incorrectos · contraseñas sin hash · secretos en `appsettings.json` versionado · no validar la entrada · exponer detalles internos en los errores.

## Proyecto asociado

**P5 · API web con persistencia de datos** (semana 23): CRUD, autenticación, documentación y publicación.

## Evaluación y puerta de avance

Evaluaciones parciales + **evaluación del módulo** con defensa de P5. **Puerta 9.**

Criterios y reglas esenciales: [evaluaciones/RUBRICAS.md](../../evaluaciones/RUBRICAS.md). Puertas: [PLAN_DE_ESTUDIO.md, sección 5](../../PLAN_DE_ESTUDIO.md#5-puertas-de-avance).

## Recursos

Documentación de ASP.NET Core 10 y de EF Core 10; MDN para HTML/CSS/JS. Estado de verificación de enlaces: [recursos/ENLACES.md](../../recursos/ENLACES.md).
