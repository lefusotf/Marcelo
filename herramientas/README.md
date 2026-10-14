# Herramientas del curso

Scripts de **mantenimiento y verificación**. No son parte del estudio diario; los usa quien construye el material (el instructor / Claude Code) y puedes usarlos tú para comprobar que nada se rompió.

Requieren Python 3 (solo biblioteca estándar). `verificar_codigo.py` requiere además `dotnet` (SDK de .NET 10) en el PATH, o la variable de entorno `DOTNET` apuntando al ejecutable.

| Script | Para qué | Cómo |
|---|---|---|
| `generar_indices.py` | Regenera `INDICE.md`, `CALENDARIO.md`, las tablas de unidades de cada módulo, la tabla de calendario/módulos de `PLAN_DE_ESTUDIO.md` y la parte automática de `PENDIENTES_DEL_CURSO.md`, a partir de `curriculo.json` y de los archivos que existen. Crea `progreso/progreso.json` y `progreso/competencias.md` **solo si no existen**. | `python3 -I herramientas/generar_indices.py` (o con `--verificar` para solo validar el currículo) |
| `verificar_codigo.py` | Extrae los bloques de C# con directiva `<!--v … -->`, los **compila y ejecuta** y comprueba que la salida coincide con la documentada (o que falla con el error/excepción esperados). | `python3 -I herramientas/verificar_codigo.py [ruta …] [-j N]` |
| `verificar_enlaces.py` | Comprueba los enlaces **internos** (archivo y ancla) y contrasta los **externos** con la lista de verificados. | `python3 -I herramientas/verificar_enlaces.py [--escribir] [--red]` |
| `curriculo.json` | **Fuente única** del currículo: módulos, unidades, temas, competencias y calendario. | Se edita a mano; luego `generar_indices.py`. |

## Directivas de verificación de código

Una directiva es un comentario HTML (invisible al renderizar) justo antes de un bloque ` ```csharp `:

```text
<!--v
modo: ejecuta | compila | error CS0029 | excepcion IndexOutOfRangeException | omitir
entrada: dato1|dato2             (líneas de stdin separadas por |)
salida: siguiente                (la salida debe coincidir con el bloque ``` que sigue)
salida-contiene: texto           (puede repetirse)
caso: e1|e2 => t1 && t2          (ejecución adicional; contiene)
caso: e1 ==> texto exacto        (ejecución adicional; salida exacta, \n = salto de línea)
grupo: nombre                    (varios bloques con el mismo grupo se compilan juntos)
archivo: Nombre.cs               (nombre del archivo del bloque)
nullable: off
-->
```

`modo: omitir` marca explícitamente un bloque como **no verificado**: el resumen del verificador lo cuenta aparte, así que nunca pasa desapercibido.

## Ejemplo de ejecución completa

```text
python3 -I herramientas/generar_indices.py
python3 -I herramientas/verificar_enlaces.py
python3 -I herramientas/verificar_codigo.py
```

Todo debe terminar en verde antes de dar por terminada una fase de contenido.

## Nota de seguridad

Los scripts compilan y ejecutan el código de **estos** archivos del curso en directorios temporales. No ejecutes `verificar_codigo.py` sobre archivos Markdown de origen desconocido: ejecuta código.
