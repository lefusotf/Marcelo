# P6 · Proyecto final original de portafolio

> **Semanas 24–26** (con MVP en la 25 y pulido en la 26) · Integra **todo** · Evaluación: rúbrica D + defensa · **Puerta final**
> Tu código va en `proyectos/P6-proyecto-final/codigo/`. No se edita este archivo.
> *Especificación marco: se concreta contigo en la semana 24, cuando elijas el tema.*

## 1. Qué es

Un proyecto **tuyo**: lo eliges, lo defines, lo diseñas y lo defiendes. Es el que enseñarás primero en una entrevista. Debe ser lo bastante completo como para que puedas **explicar qué decisiones tomaste y qué problemas resolviste**.

## 2. Cómo se elige el tema (semana 24)

1. Lista **tres ideas** de problemas reales que conozcas de cerca (tu entorno, tu trabajo, tus aficiones).
2. Evalúa cada una con esta matriz (1–5): *¿existe un usuario real?* · *¿puedo terminar un MVP en ~30 horas?* · *¿necesita datos persistentes y reglas de negocio?* · *¿me obliga a usar lo aprendido (API, SQL Server, auth, pruebas)?* · *¿me motiva?*
3. Elige una y escribe una **propuesta de una página**: problema, usuario, funcionalidades *imprescindibles* y *deseables*, y fuera de alcance. Se revisa conmigo antes de empezar.

**Una opción legítima:** reconstruir, **con tu propio diseño y tu propio código**, el dominio del sistema que ya conoces de tu proyecto anterior (gestión de activos y personal de un centro educativo), pasándolo a una API con pruebas, seguridad y documentación. Tendrías ventaja en conocer el dominio, pero **no puedes reutilizar código generado con ayuda de IA**: se defiende lo que entiendes. Decidimos esto en la semana 24, no antes.

## 3. Requisitos mínimos (obligatorios)

- **Backend:** ASP.NET Core (.NET 10) con API REST o aplicación equivalente justificada.
- **Datos:** SQL Server con diseño normalizado, migraciones o scripts versionados.
- **Seguridad:** autenticación y autorización; contraseñas con hash; ningún secreto en el repositorio.
- **Calidad:** capas con responsabilidades claras, validación, manejo de errores y registros.
- **Pruebas:** automáticas (unitarias e integración), con sentido y en verde.
- **Documentación:** README completo (propósito, instalación, ejecución, decisiones técnicas, límites), OpenAPI y diagrama del sistema.
- **Proceso:** repositorio en GitHub con historial claro, *issues* y *pull requests* propios.
- **Publicación o ejecución reproducible:** instrucciones para ejecutarlo desde cero; opcionalmente publicado.

## 4. Requisitos no funcionales

Seguridad básica comprobada · rendimiento razonable con datos de prueba abundantes · sin datos personales reales · código mantenible y legible.

## 5. Requisitos opcionales (suman, no sustituyen)

Cliente web sencillo · paginación avanzada · exportación · contenedor · integración continua con compilación y pruebas.

## 6. Plan de trabajo

| Semana | Objetivo |
|---|---|
| 24 | Propuesta aprobada, requisitos, diseño, plan de tareas y primera iteración |
| 25 | MVP funcional (iteraciones 2–3), pruebas y configuración segura |
| 26 | Pulido, documentación, publicación y defensa |

## 7. Criterios de aceptación

- [ ] La propuesta aprobada está en `codigo/docs/propuesta.md`.
- [ ] Cumple todos los requisitos mínimos de la sección 3.
- [ ] Puede ejecutarlo otra persona siguiendo solo el README.
- [ ] No hay credenciales ni datos reales en el repositorio ni en su historial.
- [ ] Hay un documento de **decisiones técnicas** (≥ 5) con alternativas descartadas.
- [ ] Hay una lista honesta de **limitaciones conocidas**.

## 8. Evaluación y defensa

Rúbrica D, defensa de 20–30 minutos: presentación del problema y la solución · recorrido por el diseño · decisiones y alternativas · problemas difíciles y cómo se resolvieron · cambio pequeño en vivo · preguntas de entrevista sobre tu propio código. El objetivo es que puedas hacerlo con naturalidad ante un entrevistador.
