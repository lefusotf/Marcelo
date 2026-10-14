# Módulo 0 · Preparación del entorno y método de aprendizaje

> **Semanas:** 1 · **Fase:** A · Fundamentos · [Plan de estudio](../../PLAN_DE_ESTUDIO.md) · [Índice](../../INDICE.md) · [Calendario](../../CALENDARIO.md)

## Objetivo

Dejar tu entorno funcionando, entender cómo un texto escrito en C# se convierte en un programa que corre, manejar la terminal y Git para guardar tu trabajo, y aprender a depurar con método en lugar de por tanteo.

## Por qué importa

Sin un entorno que funcione y un método de estudio, el resto del curso se vuelve fricción. La depuración es la habilidad que más separa a quien *copia* código de quien *programa*: se entrena desde el primer día.

## Requisitos previos

Ninguno. Se asume que puedes instalar programas y crear archivos de texto.

## Competencias de salida

Estas competencias se registran en [progreso/competencias.md](../../progreso/competencias.md) y solo se marcan como *demostradas* con evidencia (programa, evaluación o defensa).

| Código | Al terminar el módulo… |
|---|---|
| M0-C1 | Explico con mis palabras el recorrido código fuente → compilación → ejecución y distingo errores de compilación, de ejecución y lógicos. |
| M0-C2 | Creo, compilo y ejecuto un proyecto de consola desde la terminal y desde mi editor, sin guía. |
| M0-C3 | Me muevo por carpetas y creo, copio y borro archivos desde la terminal sin perderme. |
| M0-C4 | Leo un mensaje de error, localizo archivo y línea y formulo una hipótesis antes de cambiar nada. |
| M0-C5 | Uso puntos de interrupción, ejecución paso a paso y la ventana de variables para explicar qué valores toma un programa. |
| M0-C6 | Versiono mi trabajo con Git (init, add, commit, log) usando mensajes claros. |

## Unidades

<!-- AUTO:UNIDADES:INICIO -->
| Unidad | Sem. | Qué cubre | Lección | Retos | Soluciones |
|---|---|---|---|---|---|
| 0.1 Qué es programar y cómo funciona un programa | 1 | algoritmo y programa; código fuente, compilación y ejecución; .NET: CLR, IL y JIT a nivel intuitivo; primer programa | [lección](00.01-que-es-programar.md) | [retos](retos/00.01-que-es-programar-retos.md) | [soluciones](../../soluciones/M00-entorno-y-metodo/00.01-que-es-programar-soluciones.md) |
| 0.2 Terminal, archivos y carpetas; instalación y verificación del entorno | 1 | rutas y navegación; comandos básicos de terminal; .NET SDK, editor y SQL Server; verificar la instalación | [lección](00.02-terminal-y-entorno.md) | [retos](retos/00.02-terminal-y-entorno-retos.md) | [soluciones](../../soluciones/M00-entorno-y-metodo/00.02-terminal-y-entorno-soluciones.md) |
| 0.3 Tu primer proyecto, tu bitácora y Git mínimo | 1 | dotnet new/build/run; anatomía de un proyecto; organizar sesiones de estudio y registrar progreso; git init, add, commit, log | [lección](00.03-primer-proyecto-git-y-bitacora.md) | [retos](retos/00.03-primer-proyecto-git-y-bitacora-retos.md) | [soluciones](../../soluciones/M00-entorno-y-metodo/00.03-primer-proyecto-git-y-bitacora-soluciones.md) |
| 0.4 Errores, depurador y documentación | 1 | errores de compilación, de ejecución y lógicos; leer un mensaje de error; puntos de interrupción y paso a paso; buscar en la documentación oficial | [lección](00.04-errores-depurador-y-documentacion.md) | [retos](retos/00.04-errores-depurador-y-documentacion-retos.md) | [soluciones](../../soluciones/M00-entorno-y-metodo/00.04-errores-depurador-y-documentacion-soluciones.md) |
<!-- AUTO:UNIDADES:FIN -->

Cada unidad sigue la [plantilla de lección](../../plantillas/leccion.md) de quince secciones y tiene un archivo de retos de cuatro niveles en `retos/` y soluciones separadas en [`soluciones/M00-entorno-y-metodo/`](../../soluciones/M00-entorno-y-metodo/).

## Cómo se trabaja este módulo

Cada unidad termina con algo funcionando en tu máquina. Las unidades 0.2 y 0.3 se hacen en el equipo: no se pueden aprender solo leyendo. La unidad 0.4 es la base de todo el método de depuración del curso.

## Errores típicos de este módulo

Copiar comandos sin entenderlos · trabajar en carpetas sincronizadas (OneDrive) · ignorar el mensaje de error y cambiar cosas al azar · no cerrar la sesión con la bitácora.

## Proyecto asociado

No hay proyecto de puerta. El **mini-proyecto de la semana 1** (*Ficha de estudio v2*) es evidencia de integración con Git, tipos y pruebas.

## Evaluación y puerta de avance

[Evaluación de la semana 1](../../evaluaciones/semana-01/EVALUACION_SEMANA_01.md) (unidades 0.1–0.4 y 1.1; variante B para recuperaciones).

Criterios y reglas esenciales: [evaluaciones/RUBRICAS.md](../../evaluaciones/RUBRICAS.md). Puertas: [PLAN_DE_ESTUDIO.md, sección 5](../../PLAN_DE_ESTUDIO.md#5-puertas-de-avance).

## Recursos

Documentación oficial de .NET y de la CLI de `dotnet`; documentación del depurador de tu editor; *Pro Git* (Git). Los enlaces verificados están en cada lección. Estado de verificación de enlaces: [recursos/ENLACES.md](../../recursos/ENLACES.md).
