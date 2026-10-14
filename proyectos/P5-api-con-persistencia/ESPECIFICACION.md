# P5 · API web con persistencia de datos

> **Semana 23** · Integra los **Módulos 6, 8 y 9** · Evaluación: rúbrica D + defensa · **Puerta 9**
> Tu código va en `proyectos/P5-api-con-persistencia/codigo/`. No se edita este archivo.
> *Especificación inicial: se detalla (endpoints concretos, colección de peticiones, guía por etapas) al desarrollar el módulo 9.*

## 1. Problema que resuelve

Los dominios de P2–P4 solo se usan desde una consola. P5 los expone como una **API REST** que cualquier cliente (web, móvil, otro servicio) puede usar, con datos persistentes, autenticación y documentación.

## 2. Público objetivo

Desarrolladores que consumen tu API (tú mismo con una herramienta de pruebas HTTP, un cliente web sencillo) y quien evalúe tu portafolio.

## 3. Requisitos funcionales

- **RF1 · Recursos REST** del dominio (≥ 2 recursos relacionados) con las operaciones `GET` (lista y detalle), `POST`, `PUT`/`PATCH` y `DELETE`, con **códigos de estado correctos** (`200`, `201`, `204`, `400`, `401`, `403`, `404`, `409`).
- **RF2 · DTOs:** las entidades de la base **no** se exponen directamente.
- **RF3 · Validación** de entrada con mensajes consistentes (`ProblemDetails`).
- **RF4 · Persistencia** con EF Core 10 y SQL Server; migraciones versionadas.
- **RF5 · Paginación y filtros** en las listas.
- **RF6 · Autenticación** con registro/inicio de sesión, **contraseñas con hash y sal**, y tokens (JWT).
- **RF7 · Autorización:** al menos dos roles; endpoints protegidos y una regla a nivel de recurso (cada usuario solo ve/modifica lo suyo cuando corresponda).
- **RF8 · Documentación** OpenAPI generada y ejemplos de peticiones.
- **RF9 · Manejo de errores global** (sin filtrar trazas ni detalles internos).

## 4. Requisitos no funcionales

- **Seguridad:** ningún secreto en el repositorio (User Secrets en desarrollo, variables de entorno en producción); HTTPS; sin datos reales.
- **Calidad:** capas del módulo 8, DI, logging útil sin datos sensibles.
- **Pruebas:** unitarias y de integración de endpoints (≥ 25 en total, con sentido).
- **Operación:** instrucciones de publicación y una lista de verificación previa.

## 5. Conceptos que practicarás

HTTP y REST · ASP.NET Core · EF Core · DTOs · validación · autenticación y autorización · configuración y secretos · OpenAPI · pruebas de API · publicación.

## 6. Diseño inicial

```text
Cliente HTTP ──► Controladores/Endpoints ──► Servicios ──► Repositorio (EF Core) ──► SQL Server
                       │
                       └── DTOs, validación, ProblemDetails, autenticación
```

Entrega antes de programar: tabla de endpoints (método, ruta, autenticación, entrada, salida, códigos de estado), modelo de datos y matriz de roles.

## 7. Plan de tareas (borrador)

| N.º | Tarea |
|---|---|
| T1 | Contrato de la API (tabla de endpoints) y modelo de datos |
| T2 | Proyecto web, EF Core, migración inicial |
| T3 | Endpoints de lectura y DTOs |
| T4 | Endpoints de escritura con validación y errores |
| T5 | Paginación y filtros |
| T6 | Usuarios, contraseñas con hash, inicio de sesión y JWT |
| T7 | Autorización por roles y por recurso |
| T8 | Documentación OpenAPI y colección de peticiones |
| T9 | Pruebas automáticas de endpoints |
| T10 | Configuración por entorno, publicación, README, defensa |

## 8. Criterios de aceptación

- [ ] Cada endpoint devuelve el código de estado correcto en éxito y en error.
- [ ] No existe ninguna ruta que devuelva una entidad de base de datos directamente.
- [ ] Un usuario sin autenticar o sin permiso recibe `401`/`403`, comprobado por pruebas.
- [ ] Las contraseñas **nunca** se guardan en texto plano ni se devuelven.
- [ ] La API arranca solo con las instrucciones del README.
- [ ] Ningún secreto en el repositorio ni en su historial.

## 9. Casos de prueba (ejemplos)

| Caso | Esperado |
|---|---|
| `POST` con cuerpo inválido | `400` con detalle de validación |
| `GET` de un id inexistente | `404` |
| `POST` que duplica un recurso único | `409` |
| Petición sin token a un endpoint protegido | `401` |
| Usuario con rol insuficiente | `403` |
| Usuario A pide un recurso de usuario B | `404` o `403` (decídelo y justifícalo) |
| Inicio de sesión con contraseña errónea | `401` sin revelar si el usuario existe |

## 10. Posibles ampliaciones

Cliente web mínimo (HTML + JS con `fetch`) · límite de peticiones · caché · contenedor.

## 11. Entregables

Solución, migraciones, pruebas, README, documentación OpenAPI y colección de peticiones; instrucciones de publicación.

## 12. Evaluación y defensa

Rúbrica D. **Defensa:** recorrer una petición desde que llega hasta la base de datos; explicar el flujo de autenticación y dónde se guarda y verifica la contraseña; añadir un endpoint o una regla en vivo.
