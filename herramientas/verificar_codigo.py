#!/usr/bin/env python3
"""Verifica que los bloques de C# de los archivos .md compilan, se ejecutan y producen la salida documentada.

Uso (desde la raiz del repositorio, con `dotnet` en el PATH):
    python3 -I herramientas/verificar_codigo.py                # todo el repositorio del curso
    python3 -I herramientas/verificar_codigo.py modulos/M00-entorno-y-metodo   # una carpeta o archivo
    python3 -I herramientas/verificar_codigo.py -j 4           # 4 compilaciones en paralelo

Un bloque ```csharp se verifica si va PRECEDIDO por un comentario HTML (invisible al renderizar):

    <!--v
    modo: ejecuta
    entrada: 12|abc
    salida: siguiente
    caso: 5|0 => contiene uno && contiene dos
    -->

Directivas (una por linea):
    modo: ejecuta                  compila y ejecuta; exit code 0 (por defecto)
    modo: compila                  solo compila (para fragmentos interactivos o largos)
    modo: error CS0029             la compilacion DEBE fallar con ese codigo (error intencional de la leccion)
    modo: excepcion NombreTipo     debe compilar y terminar con esa excepcion no controlada
    modo: omitir                   NO se verifica; se cuenta como [NO VERIFICADO] en el resumen
    entrada: a|b|c                 lineas de stdin separadas por |
    salida: siguiente              la stdout completa debe coincidir con el siguiente bloque ``` (normalizando espacios finales)
    salida-contiene: texto         la stdout debe contener ese texto (puede repetirse)
    caso: e1|e2 => t1 && t2        ejecucion adicional con esa entrada; la stdout debe contener t1 y t2
    caso: e1|e2 ==> texto exacto   idem pero la stdout completa debe ser exactamente ese texto (\\n = salto de linea)
    grupo: nombre                  varios bloques con el mismo grupo se compilan juntos en un proyecto
    archivo: Nombre.cs             nombre del archivo del bloque (por defecto Program.cs)
    nullable: off                  desactiva <Nullable>

Todas las ejecuciones usan InvariantGlobalization: los decimales salen con punto.
"""
import concurrent.futures
import os
import re
import shutil
import subprocess
import sys
import tempfile
from pathlib import Path

RAIZ = Path(__file__).resolve().parent.parent
CARPETAS_POR_DEFECTO = ["modulos", "soluciones", "evaluaciones", "proyectos", "plantillas", "recursos"]
CSPROJ = """<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>{nullable}</Nullable>
    <InvariantGlobalization>true</InvariantGlobalization>
    <AssemblyName>App</AssemblyName>
    <RootNamespace>App</RootNamespace>
    <EnableDefaultCompileItems>false</EnableDefaultCompileItems>
    <NoWarn>CS0219;CS0168;CS8321;CS0162;CS0164;CS8600;CS8602;CS8604;CS8618;CS8625;IDE0059</NoWarn>
  </PropertyGroup>
  <ItemGroup>
{compiles}
  </ItemGroup>
</Project>
"""


class Bloque:
    def __init__(self, archivo, linea, codigo, directivas, siguiente):
        self.archivo = archivo
        self.linea = linea
        self.codigo = codigo
        self.directivas = directivas
        self.siguiente = siguiente  # texto del bloque ``` que sigue (o None)

    @property
    def modo(self):
        return self.directivas.get("modo", ["ejecuta"])[0].strip()

    def uno(self, clave, defecto=None):
        v = self.directivas.get(clave)
        return v[0].strip() if v else defecto


def parsear_directivas(texto):
    d = {}
    for linea in texto.strip().splitlines():
        linea = linea.strip()
        if not linea or ":" not in linea:
            continue
        clave, valor = linea.split(":", 1)
        d.setdefault(clave.strip(), []).append(valor.strip() if clave.strip() != "caso" else linea.split(":", 1)[1].strip())
    return d


def extraer_bloques(ruta):
    lineas = ruta.read_text(encoding="utf-8").splitlines()
    bloques = []
    i = 0
    n = len(lineas)
    while i < n:
        linea = lineas[i]
        if linea.strip().startswith("<!--v"):
            inicio = i
            contenido = [linea.strip()[5:]]
            while "-->" not in lineas[i]:
                i += 1
                contenido.append(lineas[i])
            texto = "\n".join(contenido).replace("-->", "")
            directivas = parsear_directivas(texto)
            i += 1
            while i < n and lineas[i].strip() == "":
                i += 1
            if i < n and lineas[i].lstrip().startswith("```csharp"):
                fence_linea = i
                i += 1
                codigo = []
                while i < n and not lineas[i].strip().startswith("```"):
                    codigo.append(lineas[i])
                    i += 1
                i += 1
                # buscar el siguiente bloque ``` para 'salida: siguiente'
                j = i
                while j < n and lineas[j].strip() == "":
                    j += 1
                siguiente = None
                if j < n and lineas[j].lstrip().startswith("```"):
                    k = j + 1
                    texto_sig = []
                    while k < n and not lineas[k].strip().startswith("```"):
                        texto_sig.append(lineas[k])
                        k += 1
                    siguiente = "\n".join(texto_sig)
                bloques.append(Bloque(ruta, fence_linea + 1, "\n".join(codigo) + "\n", directivas, siguiente))
                continue
            else:
                print(f"AVISO: {ruta}:{inicio + 1}: directiva <!--v sin bloque csharp a continuacion", file=sys.stderr)
                continue
        i += 1
    return bloques


def normalizar(s):
    s = s.replace("\r\n", "\n").replace("\r", "\n")
    lineas = [l.rstrip() for l in s.split("\n")]
    while lineas and lineas[-1] == "":
        lineas.pop()
    return "\n".join(lineas)


def agrupar(bloques):
    """Devuelve una lista de 'unidades': cada una es una lista de bloques que se compilan juntos."""
    unidades = []
    grupos = {}
    for b in bloques:
        g = b.uno("grupo")
        if g:
            clave = (str(b.archivo), g)
            if clave not in grupos:
                grupos[clave] = []
                unidades.append(grupos[clave])
            grupos[clave].append(b)
        else:
            unidades.append([b])
    return unidades


def ejecutar(cmd, cwd, entrada=None, timeout=60):
    return subprocess.run(cmd, cwd=cwd, input=entrada, capture_output=True, text=True, timeout=timeout,
                          env={**os.environ, "DOTNET_NOLOGO": "1", "DOTNET_CLI_TELEMETRY_OPTOUT": "1",
                               "DOTNET_SYSTEM_GLOBALIZATION_INVARIANT": "1"})


def verificar_unidad(unidad, dotnet, tmp_base, indice):
    """Devuelve (estado, mensaje). estado en {ok, fallo, omitido}."""
    principal = unidad[-1]
    modo = principal.modo
    try:
        ref = f"{principal.archivo.relative_to(RAIZ)}:{principal.linea}"
    except ValueError:
        ref = f"{principal.archivo}:{principal.linea}"
    if modo == "omitir":
        return "omitido", f"{ref}: omitido (no verificado)"
    d = Path(tmp_base) / f"u{indice}"
    d.mkdir(parents=True, exist_ok=True)
    nullable = "disable" if principal.uno("nullable") == "off" else "enable"
    compiles = []
    for b in unidad:
        nombre = b.uno("archivo", "Program.cs")
        (d / nombre).write_text(b.codigo, encoding="utf-8")
        compiles.append(f'    <Compile Include="{nombre}" />')
    (d / "App.csproj").write_text(CSPROJ.format(nullable=nullable, compiles="\n".join(dict.fromkeys(compiles))), encoding="utf-8")
    comp = ejecutar([dotnet, "build", "-nologo", "-v", "q", "-o", str(d / "out"), "-p:UseAppHost=false"], d)
    salida_build = comp.stdout + comp.stderr
    if modo.startswith("error"):
        codigo_esperado = modo.split()[1] if len(modo.split()) > 1 else ""
        if comp.returncode == 0:
            return "fallo", f"{ref}: se esperaba error {codigo_esperado} pero compiló"
        if codigo_esperado and codigo_esperado not in salida_build:
            return "fallo", f"{ref}: se esperaba {codigo_esperado}; salida de compilación:\n{salida_build[-800:]}"
        return "ok", f"{ref}: error {codigo_esperado} confirmado"
    if comp.returncode != 0:
        errores = [l for l in salida_build.splitlines() if "error" in l]
        return "fallo", f"{ref}: no compila:\n  " + "\n  ".join(errores[:6])
    if modo == "compila":
        return "ok", f"{ref}: compila"
    # ejecutar
    dll = d / "out" / "App.dll"
    ejecuciones = []
    ent = principal.uno("entrada")
    sal_sig = principal.uno("salida")
    if ent is not None or sal_sig or not principal.directivas.get("caso") or principal.directivas.get("salida-contiene"):
        ejecuciones.append(("principal", ent))
    for c in principal.directivas.get("caso", []):
        ejecuciones.append(("caso", c))
    errores = []
    for tipo, dato in ejecuciones:
        if tipo == "principal":
            entrada = (dato or "").replace("|", "\n") + ("\n" if dato else "")
            r = ejecutar([dotnet, str(dll)], d, entrada)
            out = normalizar(r.stdout)
            etiqueta = f"entrada={dato!r}"
            if modo.startswith("excepcion"):
                nombre_exc = modo.split()[1]
                if r.returncode == 0 or nombre_exc not in r.stderr:
                    errores.append(f"{etiqueta}: se esperaba excepción {nombre_exc}; rc={r.returncode}; stderr={r.stderr[:300]!r}")
            elif r.returncode != 0:
                errores.append(f"{etiqueta}: terminó con código {r.returncode}: {r.stderr[:300]!r}")
            if sal_sig == "siguiente":
                if principal.siguiente is None:
                    errores.append("salida: siguiente, pero no hay bloque a continuación")
                elif normalizar(principal.siguiente) != out:
                    errores.append(f"{etiqueta}: la salida documentada NO coincide.\n--- documentada:\n{normalizar(principal.siguiente)}\n--- real:\n{out}\n---")
            for esperado in principal.directivas.get("salida-contiene", []):
                if esperado not in out:
                    errores.append(f"{etiqueta}: falta {esperado!r} en la salida:\n{out}")
        else:
            exacto = "==>" in dato
            partes = dato.split("==>" if exacto else "=>", 1)
            ent_caso = partes[0].strip()
            esperado = partes[1].strip() if len(partes) > 1 else ""
            entrada = ent_caso.replace("|", "\n") + ("\n" if ent_caso else "")
            r = ejecutar([dotnet, str(dll)], d, entrada)
            out = normalizar(r.stdout)
            if r.returncode != 0 and not modo.startswith("excepcion"):
                errores.append(f"caso {ent_caso!r}: terminó con código {r.returncode}: {r.stderr[:300]!r}")
                continue
            if exacto:
                if normalizar(esperado.replace("\\n", "\n")) != out:
                    errores.append(f"caso {ent_caso!r}: salida distinta.\n--- esperada:\n{esperado}\n--- real:\n{out}\n---")
            else:
                for trozo in [t.strip() for t in esperado.split("&&") if t.strip()]:
                    if trozo not in out:
                        errores.append(f"caso {ent_caso!r}: falta {trozo!r}. Salida real:\n{out}")
    if errores:
        return "fallo", f"{ref}: " + "\n  ".join(errores)
    return "ok", f"{ref}: ejecuta ({len(ejecuciones)} caso(s))"


def archivos_md(objetivos):
    rutas = []
    for o in objetivos:
        p = (RAIZ / o) if not Path(o).is_absolute() else Path(o)
        if p.is_file():
            rutas.append(p)
        elif p.is_dir():
            rutas.extend(sorted(p.rglob("*.md")))
    return rutas


def main():
    args = sys.argv[1:]
    jobs = 3
    if "-j" in args:
        k = args.index("-j")
        jobs = int(args[k + 1])
        del args[k:k + 2]
    objetivos = args or CARPETAS_POR_DEFECTO
    dotnet = os.environ.get("DOTNET") or shutil.which("dotnet")
    if not dotnet:
        print("ERROR: no se encontró `dotnet`. Instala el SDK de .NET 10 o define la variable DOTNET.", file=sys.stderr)
        sys.exit(2)
    bloques = []
    for ruta in archivos_md(objetivos):
        bloques.extend(extraer_bloques(ruta))
    unidades = agrupar(bloques)
    print(f"{len(bloques)} bloques con directiva ({len(unidades)} proyectos a compilar). Usando: {dotnet}")
    tmp_base = tempfile.mkdtemp(prefix="verif_cs_")
    resultados = []
    try:
        with concurrent.futures.ThreadPoolExecutor(max_workers=jobs) as ex:
            futuros = {ex.submit(verificar_unidad, u, dotnet, tmp_base, i): i for i, u in enumerate(unidades)}
            for f in concurrent.futures.as_completed(futuros):
                resultados.append((futuros[f], f.result()))
    finally:
        shutil.rmtree(tmp_base, ignore_errors=True)
    resultados.sort()
    ok = sum(1 for _, (e, _) in resultados if e == "ok")
    omit = sum(1 for _, (e, _) in resultados if e == "omitido")
    fallos = [(i, m) for i, (e, m) in resultados if e == "fallo"]
    for _, (e, m) in resultados:
        if e != "ok":
            print(("FALLO  " if e == "fallo" else "OMITIDO ") + m)
    print(f"\nResumen: {ok} verificados correctamente, {len(fallos)} con fallo, {omit} omitidos (no verificados).")
    sys.exit(1 if fallos else 0)


if __name__ == "__main__":
    main()
