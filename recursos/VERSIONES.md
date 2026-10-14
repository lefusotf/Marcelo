# Versiones del curso y cómo se verificó el código

> Verificado el **2026-10-14**. Antes de fijar una versión en una lección nueva, repite estas comprobaciones.

## Versiones fijadas

| Tecnología | Versión del curso | Estado el 2026-10-14 | Fuente de la comprobación |
|---|---|---|---|
| **.NET** | **10 (LTS)** | Soporte hasta noviembre de 2028 (el 14 de noviembre según la página de descargas). Última actualización de la línea: **10.0.13** (13-oct-2026). | Página de descargas de .NET (`dotnet.microsoft.com`, **abierta directamente**) |
| .NET 11 | No se usa | En candidata a versión (RC), 11.0.0-rc.2 el 13-oct-2026. | Misma página |
| .NET 9 y 8 | No se usan | Fin de soporte el **10-nov-2026**. | Misma página |
| **C#** | **14** | Viene con el SDK de .NET 10. | Documentación del SDK (resultado de búsqueda) |
| **SDK usado para verificar el código** | **10.0.112** | Paquete de Ubuntu 24.04; el SDK más reciente publicado era 10.0.402. Las funciones del curso (consola, tipos, `decimal`, interpolación, `const`, `Math`, LINQ básico, xUnit) no cambian entre ambos. | `dotnet --info` en el entorno |
| **Visual Studio** | **2026 Community** (o VS Code) | Disponible desde el 11-nov-2025, con .NET 10 y C# 14. | Resultado de búsqueda (blog de .NET / documentación) |
| **VS Code** | Cualquier versión actual + extensión **C#** | El C# Dev Kit es opcional y pide iniciar sesión; términos de licencia propios. | Documentación de VS Code (resultado de búsqueda) |
| **SQL Server** | **2022 o 2025** (Developer o Express) | SQL Server 2025 tiene dos variantes Developer (Standard y Enterprise). | Resultados de búsqueda |
| **SSMS** | **22** (22.10.2 el 28-sep-2026) | Se instala con el *Visual Studio Installer*; sin MSI independiente; solo Windows. | Documentación de SSMS (resultado de búsqueda) |
| Azure Data Studio | No se usa | Fin de soporte el **28-feb-2026**; la alternativa es la extensión **MSSQL** de VS Code. | Resultados de búsqueda |
| **EF Core** | **10 (LTS)** | Lanzado en noviembre de 2025; soporte hasta noviembre de 2028. | Documentación de EF Core (resultado de búsqueda) |
| **Acceso a SQL Server desde C#** | `Microsoft.Data.SqlClient` | `System.Data.SqlClient` figura como **obsoleto** en NuGet. | Página del paquete en NuGet (resultado de búsqueda) |
| **xUnit** | Se fija al llegar al módulo 8 | El plantilla `dotnet new xunit` del SDK 10.0.112 referencia xunit 2.9.3, Microsoft.NET.Test.Sdk 17.14.1 y xunit.runner.visualstudio 3.1.4. | Plantilla instalada (ejecutada) |
| **Git** | Cualquier versión reciente | Verificado con Git 2.43. | `git --version` |

## Cómo se verificó el código del curso

- **Qué se ejecutó:** todos los bloques de C# que llevan la directiva `<!--v … -->` en lecciones, retos, soluciones y evaluaciones se **compilaron y ejecutaron** con `herramientas/verificar_codigo.py` usando el SDK de .NET 10.0.112, y su salida se comparó con la documentada.
- **Qué tipo de comprobaciones hay:** programas que deben compilar y producir una salida exacta · programas que deben **fallar al compilar con un código concreto** (errores intencionales de las lecciones) · programas que deben terminar con una **excepción concreta**.
- **Cultura:** las ejecuciones usaron `InvariantGlobalization`: los decimales salen con **punto**. En tu equipo pueden salir con coma; el material lo avisa.
- **Sistema operativo:** Linux (Ubuntu 24.04). Los programas de consola de C# se comportan igual en Windows, salvo la codificación de la consola (acentos), que depende de la configuración.

## Qué **no** se pudo verificar

| Elemento | Motivo |
|---|---|
| Comandos de **PowerShell de Windows** (lección 0.2 y soluciones) | El entorno era Linux; se contrastaron con la documentación oficial de los alias. |
| **Depurador gráfico** de Visual Studio y VS Code (lección 0.4) | Sin entorno gráfico; los atajos proceden de la documentación oficial. |
| **Instaladores** de .NET, Visual Studio, SSMS y SQL Server | No se instalan aquí; las instrucciones se contrastaron con la documentación oficial. |
| **Enlaces** (ver [ENLACES.md](ENLACES.md)) | Sitios no alcanzables desde el entorno. |
| Consultas **SQL** del diagnóstico | No había SQL Server; se revisaron a mano y se ejecutarán en el módulo 5. |

Si encuentras una diferencia entre lo que dice el material y lo que ves en tu equipo, **anótala en tu bitácora**: es una corrección pendiente del curso.

## Cómo se construyó el entorno de verificación (para reproducirlo)

Sin instalar nada en el sistema: se descargaron del archivo de Ubuntu 24.04 los paquetes `dotnet-sdk-10.0`, `dotnet-runtime-10.0`, `aspnetcore-runtime-10.0`, `dotnet-host-10.0`, `dotnet-hostfxr-10.0`, `dotnet-targeting-pack-10.0`, `aspnetcore-targeting-pack-10.0`, `dotnet-apphost-pack-10.0` y `dotnet-templates-10.0`, y se extrajeron con `dpkg -x` en un directorio temporal; `DOTNET_ROOT` apuntó a ese directorio. Se usó `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1`.
