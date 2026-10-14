# Enlaces externos: qué se comprobó y qué no

> **Léelo antes de fiarte de un enlace.** El curso enlaza documentación oficial, pero **no inventa enlaces ni afirma haberlos abierto si no lo hizo**.

## Cómo se verificó (2026-10-14)

El material se construyó en un entorno Linux con salida a internet restringida por un proxy. En ese entorno:

- `dotnet.microsoft.com` **sí** respondió (se abrió una página directamente).
- `learn.microsoft.com`, `git-scm.com`, `docs.github.com`, `code.visualstudio.com` y otros **no resolvían o estaban bloqueados**, así que **no se pudieron abrir con una petición**.
- Para esos sitios, cada URL se incluyó **solo si apareció textualmente en los resultados del buscador** ese día. Eso demuestra que la URL existe en el índice del buscador en esa fecha, no que el contenido sea el que describo; por eso la columna *Estado* distingue "abierto directamente" de "visto en búsqueda".
- Los enlaces están en la versión `en-us` de Microsoft Learn. Si quieres la traducción, cambia `en-us` por `es-es` en la URL; puede existir o estar menos actualizada. **Esa variante no se verificó.**

## Estado de cada enlace

La tabla se genera con `python3 -I herramientas/verificar_enlaces.py --escribir` a partir de los enlaces que aparecen en los archivos del curso y de [enlaces-verificados.json](enlaces-verificados.json).

<!-- AUTO:TABLA:INICIO -->
| Enlace | Estado de verificación | Usado en |
|---|---|---|
| <https://code.visualstudio.com/docs/csharp/get-started> | Visto en resultados de búsqueda (2026-10-14); no abierto directamente | modulos/M00-entorno-y-metodo/00.02-terminal-y-entorno.md |
| <https://code.visualstudio.com/docs/debugtest/debugging> | Visto en resultados de búsqueda (2026-10-14); no abierto directamente | modulos/M00-entorno-y-metodo/00.04-errores-depurador-y-documentacion.md |
| <https://dotnet.microsoft.com/en-us/download/dotnet/10.0> | Visto en resultados de búsqueda (2026-10-14); no abierto directamente | modulos/M00-entorno-y-metodo/00.02-terminal-y-entorno.md |
| <https://git-scm.com/book/en/v2> | Visto en resultados de búsqueda (2026-10-14); no abierto directamente | modulos/M00-entorno-y-metodo/00.03-primer-proyecto-git-y-bitacora.md, modulos/M00-entorno-y-metodo/00.04-errores-depurador-y-documentacion.md |
| <https://git-scm.com/install/windows> | Visto en resultados de búsqueda (2026-10-14); no abierto directamente | modulos/M00-entorno-y-metodo/00.02-terminal-y-entorno.md |
| <https://learn.microsoft.com/en-us/dotnet/api/system.console.readline?view=net-10.0> | Visto en resultados de búsqueda (2026-10-14); no abierto directamente | soluciones/M00-entorno-y-metodo/00.04-errores-depurador-y-documentacion-soluciones.md |
| <https://learn.microsoft.com/en-us/dotnet/api/system.int32.parse?view=net-9.0> | Visto en resultados de búsqueda (2026-10-14); no abierto directamente | modulos/M01-fundamentos-de-programacion/01.01-variables-y-tipos.md |
| <https://learn.microsoft.com/en-us/dotnet/api/system.math.abs?view=net-10.0> | Visto en resultados de búsqueda (2026-10-14); no abierto directamente | modulos/M01-fundamentos-de-programacion/01.01-variables-y-tipos.md, soluciones/M00-entorno-y-metodo/00.04-errores-depurador-y-documentacion-soluciones.md |
| <https://learn.microsoft.com/en-us/dotnet/api/system.string.indexof?view=net-10.0> | Visto en resultados de búsqueda (2026-10-14); no abierto directamente | soluciones/M00-entorno-y-metodo/00.04-errores-depurador-y-documentacion-soluciones.md |
| <https://learn.microsoft.com/en-us/dotnet/core/install/windows> | Visto en resultados de búsqueda (2026-10-14); no abierto directamente | modulos/M00-entorno-y-metodo/00.02-terminal-y-entorno.md |
| <https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet> | Visto en resultados de búsqueda (2026-10-14); no abierto directamente | modulos/M00-entorno-y-metodo/00.03-primer-proyecto-git-y-bitacora.md |
| <https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new> | Visto en resultados de búsqueda (2026-10-14); no abierto directamente | modulos/M00-entorno-y-metodo/00.03-primer-proyecto-git-y-bitacora.md |
| <https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new-sdk-templates> | Visto en resultados de búsqueda (2026-10-14); no abierto directamente | modulos/M00-entorno-y-metodo/00.03-primer-proyecto-git-y-bitacora.md |
| <https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/program-structure/top-level-statements> | Visto en resultados de búsqueda (2026-10-14); no abierto directamente | modulos/M00-entorno-y-metodo/00.01-que-es-programar.md, modulos/M00-entorno-y-metodo/00.03-primer-proyecto-git-y-bitacora.md |
| <https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/cs0103> | Visto en resultados de búsqueda (2026-10-14); no abierto directamente | modulos/M00-entorno-y-metodo/00.01-que-es-programar.md, modulos/M00-entorno-y-metodo/00.04-errores-depurador-y-documentacion.md |
| <https://learn.microsoft.com/en-us/dotnet/csharp/misc/cs1002> | Visto en resultados de búsqueda (2026-10-14); no abierto directamente | modulos/M00-entorno-y-metodo/00.01-que-es-programar.md, modulos/M00-entorno-y-metodo/00.04-errores-depurador-y-documentacion.md |
| <https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/> | Visto en resultados de búsqueda (2026-10-14); no abierto directamente | modulos/M00-entorno-y-metodo/00.01-que-es-programar.md |
| <https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/tutorials/> | Visto en resultados de búsqueda (2026-10-14); no abierto directamente | modulos/M01-fundamentos-de-programacion/01.01-variables-y-tipos.md |
| <https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/tutorials/hello-world> | Visto en resultados de búsqueda (2026-10-14); no abierto directamente | modulos/M00-entorno-y-metodo/00.01-que-es-programar.md |
| <https://learn.microsoft.com/en-us/dotnet/standard/base-types/parsing-numeric> | Visto en resultados de búsqueda (2026-10-14); no abierto directamente | modulos/M01-fundamentos-de-programacion/01.01-variables-y-tipos.md |
| <https://learn.microsoft.com/en-us/dotnet/standard/managed-execution-process> | Visto en resultados de búsqueda (2026-10-14); no abierto directamente | modulos/M00-entorno-y-metodo/00.01-que-es-programar.md |
| <https://learn.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_aliases?view=powershell-7.4> | Visto en resultados de búsqueda (2026-10-14); no abierto directamente | modulos/M00-entorno-y-metodo/00.02-terminal-y-entorno.md |
| <https://learn.microsoft.com/en-us/sql/database-engine/install-windows/install-sql-server-from-the-installation-wizard-setup?view=sql-server-ver17> | Visto en resultados de búsqueda (2026-10-14); no abierto directamente | modulos/M00-entorno-y-metodo/00.02-terminal-y-entorno.md |
| <https://learn.microsoft.com/en-us/sql/tools/visual-studio-code-extensions/mssql/mssql-run-first-query?view=sql-server-ver17> | Visto en resultados de búsqueda (2026-10-14); no abierto directamente | modulos/M00-entorno-y-metodo/00.02-terminal-y-entorno.md |
| <https://learn.microsoft.com/en-us/ssms/install/install> | Visto en resultados de búsqueda (2026-10-14); no abierto directamente | modulos/M00-entorno-y-metodo/00.02-terminal-y-entorno.md |
| <https://learn.microsoft.com/en-us/visualstudio/debugger/debugging-absolute-beginners?view=visualstudio> | Visto en resultados de búsqueda (2026-10-14); no abierto directamente | modulos/M00-entorno-y-metodo/00.04-errores-depurador-y-documentacion.md |
| <https://learn.microsoft.com/en-us/visualstudio/get-started/csharp/tutorial-debugger?view=vs-2022> | Visto en resultados de búsqueda (2026-10-14); no abierto directamente | modulos/M00-entorno-y-metodo/00.04-errores-depurador-y-documentacion.md |
| <https://learn.microsoft.com/en-us/visualstudio/install/install-visual-studio?view=visualstudio> | Visto en resultados de búsqueda (2026-10-14); no abierto directamente | modulos/M00-entorno-y-metodo/00.02-terminal-y-entorno.md |
<!-- AUTO:TABLA:FIN -->

## Tarea pendiente

Abrir cada enlace en un entorno con acceso web completo, comprobar que el contenido corresponde a .NET 10 / C# 14 / SQL Server 2022–2025, y mover la URL a `abiertos_directamente` en `enlaces-verificados.json` (ejecuta después `verificar_enlaces.py --escribir`). Mientras tanto, si un enlace falla, tú tienes la información suficiente (título de la página y código de error o nombre del método) para encontrarla con el buscador de Microsoft Learn.

## Tipo de fuentes

| Tipo | Cómo se marca | Ejemplos |
|---|---|---|
| **Oficial** | Documentación del fabricante o proyecto | Microsoft Learn, git-scm.com |
| **Oficial · tutorial** | Tutorial publicado por el fabricante | Tour de C# |
| **Libro / opinión** | Se indica expresamente y se distingue de lo oficial | *Pro Git* es el libro oficial de Git, escrito por sus autores; no es la documentación de referencia |
