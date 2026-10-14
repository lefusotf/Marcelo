# P4 · Aplicación estructurada con responsabilidades separadas

> **Semana 20** · Integra los **Módulos 6, 7 y 8** · Evaluación: rúbrica D + defensa · Forma parte de la **Puerta 8**
> Tu código va en `proyectos/P4-aplicacion-en-capas/codigo/`. No se edita este archivo.
> *Especificación inicial: se detalla al desarrollar el módulo 8.*

## 1. Problema que resuelve

P3 funciona, pero ¿se puede **cambiar** sin romperlo? P4 transforma P3 en una aplicación **mantenible**: capas con responsabilidades claras, dependencias invertidas, pruebas automáticas que protegen los cambios, registros para diagnosticar fallos y errores controlados de forma consistente.

## 2. Público objetivo

Quien mantiene la aplicación después de ti (incluido tu yo del futuro) y quien evalúe tu portafolio: verá si distingues "funciona" de "está bien diseñado".

## 3. Requisitos funcionales

- **RF1 · Mismas funciones que P3**, sin regresiones (se demuestra con las pruebas).
- **RF2 · Capas:** al menos **Dominio** (entidades y reglas), **Aplicación/Servicios**, **Infraestructura** (datos) y **Presentación** (consola). Las dependencias apuntan **hacia el dominio**.
- **RF3 · Inyección de dependencias** con el contenedor de .NET; el servicio recibe sus dependencias por constructor.
- **RF4 · Pruebas unitarias** (xUnit) del dominio y los servicios, con repositorios simulados.
- **RF5 · Pruebas de integración** de al menos el repositorio contra una base de **pruebas** (no la real).
- **RF6 · Registros** (`ILogger`) en puntos útiles: arranque, operaciones, errores. Sin datos sensibles.
- **RF7 · Manejo de errores** consistente: excepciones del dominio, traducción a mensajes de usuario, registro técnico aparte.
- **RF8 · Validación de entradas** en el borde (presentación) **y** en el dominio.

## 4. Requisitos no funcionales

- **Cobertura con sentido:** ≥ 20 pruebas significativas (reglas de negocio, casos límite, errores), no pruebas triviales.
- **Sin sobreingeniería:** cada interfaz y cada capa se justifica por escrito en un registro de decisiones.
- **Trazabilidad:** *pull requests* pequeños con descripción; commits convencionales.
- **Seguridad:** secretos fuera del repositorio; consultas parametrizadas; privilegios mínimos.

## 5. Conceptos que practicarás

SOLID aplicado · arquitectura por capas · DI · pruebas unitarias y de integración · refactorización con red de seguridad · logging · seguridad básica · documentación técnica · revisión de código.

## 6. Diseño inicial

```text
Presentación ──► Aplicación ──► Dominio ◄── Infraestructura
                                  ▲
                                  └── interfaces (IRepositorio…) definidas en el dominio o la aplicación
```

Antes de refactorizar: escribe **pruebas de caracterización** de P3 (lo que hace hoy) para tener una red de seguridad.

## 7. Plan de tareas (borrador)

| N.º | Tarea |
|---|---|
| T1 | Plan de refactorización: qué moverás a qué capa |
| T2 | Pruebas de caracterización del comportamiento actual |
| T3 | Extraer el dominio (entidades y reglas) |
| T4 | Interfaces de repositorio y servicios; DI |
| T5 | Pruebas unitarias con dobles de prueba |
| T6 | Pruebas de integración del repositorio |
| T7 | Logging y manejo de errores consistentes |
| T8 | Registro de decisiones (ADR corto) y README |
| T9 | PR final y defensa |

## 8. Criterios de aceptación

- [ ] Todas las pruebas pasan (`dotnet test` en verde).
- [ ] El dominio no depende de infraestructura ni de presentación (se comprueba con el grafo de referencias).
- [ ] Cambiar el repositorio por uno falso no exige tocar el dominio.
- [ ] Ningún registro contiene contraseñas, tokens ni datos personales reales.
- [ ] El registro de decisiones explica **al menos tres** elecciones y una alternativa descartada.

## 9. Casos de prueba (ejemplos)

| Caso | Esperado |
|---|---|
| Regla de negocio violada | Excepción de dominio específica y mensaje de usuario claro |
| Repositorio simulado que lanza un error | El servicio traduce y registra; no se cae |
| Entrada inválida en el borde | Rechazada antes de llegar al dominio |
| Operación transaccional con fallo | Estado consistente (prueba de integración) |

## 10. Posibles ampliaciones

Cambiar ADO.NET por EF Core detrás de la misma interfaz (demuestra el valor de las capas).

## 11. Entregables

Solución con proyectos por capa, proyecto de pruebas, README, registro de decisiones, historial de PR.

## 12. Evaluación y defensa

Rúbrica D, con **pruebas automáticas obligatorias**. **Defensa:** justificar cada capa y cada interfaz; mostrar una prueba que habría detectado un error real; hacer un cambio de requisito en vivo y comprobar que las pruebas lo protegen.
