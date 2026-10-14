#!/usr/bin/env python3
"""Verifica los enlaces de los archivos Markdown del curso.

Uso (desde la raiz del repositorio):
    python3 -I herramientas/verificar_enlaces.py             # internos + resumen de externos
    python3 -I herramientas/verificar_enlaces.py --escribir  # ademas actualiza la tabla de recursos/ENLACES.md
    python3 -I herramientas/verificar_enlaces.py --red       # ademas intenta abrir los externos con una peticion HTTP

Que comprueba:
  * Enlaces internos [texto](ruta) y [texto](ruta#ancla): que el archivo exista y que el encabezado exista.
  * Enlaces externos: los contrasta con recursos/enlaces-verificados.json (NO afirma verificacion que no se hizo).
Ignora el contenido de bloques de codigo y los archivos del proyecto previo (cs/, db/, entrega_*, PDF, GUIA_CAMBIOS.md).
Solo usa la biblioteca estandar de Python.
"""
import json
import re
import sys
import unicodedata
import urllib.request
from pathlib import Path

RAIZ = Path(__file__).resolve().parent.parent
EXCLUIR_PREFIJOS = ("cs/", "db/", "entrega_", ".git/", "GUIA_CAMBIOS.md", "practica/")
VERIFICADOS = RAIZ / "recursos" / "enlaces-verificados.json"


def archivos_md():
    for p in sorted(RAIZ.rglob("*.md")):
        rel = p.relative_to(RAIZ).as_posix()
        if rel.startswith(EXCLUIR_PREFIJOS):
            continue
        yield p


def quitar_codigo(texto):
    """Elimina bloques ``` y codigo en linea para no analizar enlaces dentro de ellos."""
    salida, en_bloque = [], False
    for linea in texto.splitlines():
        if linea.lstrip().startswith("```"):
            en_bloque = not en_bloque
            continue
        if not en_bloque:
            salida.append(re.sub(r"`[^`]*`", "", linea))
    return "\n".join(salida)


def slug(titulo):
    """Aproxima los identificadores de ancla de GitHub."""
    t = titulo.strip().lower()
    t = re.sub(r"`([^`]*)`", r"\1", t)
    t = re.sub(r"\[([^\]]*)\]\([^)]*\)", r"\1", t)
    t = unicodedata.normalize("NFC", t)
    t = re.sub(r"[^\w\- ]", "", t, flags=re.UNICODE)
    return t.replace(" ", "-")


def anclas(ruta):
    res = set()
    en_bloque = False
    for linea in ruta.read_text(encoding="utf-8").splitlines():
        if linea.lstrip().startswith("```"):
            en_bloque = not en_bloque
            continue
        if en_bloque:
            continue
        m = re.match(r"^(#{1,6})\s+(.*)$", linea)
        if m:
            res.add(slug(m.group(2)))
    return res


def main():
    args = sys.argv[1:]
    datos = json.loads(VERIFICADOS.read_text(encoding="utf-8")) if VERIFICADOS.exists() else {"abiertos_directamente": [], "vistos_en_busqueda": []}
    abiertos = set(datos["abiertos_directamente"])
    vistos = set(datos["vistos_en_busqueda"])
    cache_anclas = {}
    errores = []
    externos = {}
    total_internos = 0
    patron = re.compile(r"\[([^\]]*)\]\(([^)\s]+)(?:\s+\"[^\"]*\")?\)")
    for md in archivos_md():
        rel_md = md.relative_to(RAIZ).as_posix()
        texto = quitar_codigo(md.read_text(encoding="utf-8"))
        for m in patron.finditer(texto):
            destino = m.group(2)
            if destino.startswith(("http://", "https://")):
                externos.setdefault(destino, set()).add(rel_md)
                continue
            if destino.startswith(("mailto:", "tel:")):
                continue
            total_internos += 1
            ruta, _, ancla = destino.partition("#")
            if ruta == "":
                objetivo = md
            else:
                objetivo = (md.parent / ruta).resolve()
            try:
                objetivo.relative_to(RAIZ)
            except ValueError:
                errores.append(f"{rel_md}: enlace fuera del repositorio: {destino}")
                continue
            if not objetivo.exists():
                errores.append(f"{rel_md}: no existe {destino}")
                continue
            if ancla and objetivo.suffix == ".md":
                if objetivo not in cache_anclas:
                    cache_anclas[objetivo] = anclas(objetivo)
                if ancla.lower() not in cache_anclas[objetivo] and slug(ancla.replace("-", " ")) not in cache_anclas[objetivo]:
                    errores.append(f"{rel_md}: la ancla #{ancla} no existe en {objetivo.relative_to(RAIZ).as_posix()}")
    print(f"Enlaces internos revisados: {total_internos}. Errores: {len(errores)}.")
    for e in errores:
        print("  ERROR", e)
    estado = {}
    for url in sorted(externos):
        if url in abiertos:
            estado[url] = "Abierto directamente (2026-10-14)"
        elif url in vistos:
            estado[url] = "Visto en resultados de búsqueda (2026-10-14); no abierto directamente"
        else:
            estado[url] = "NO VERIFICADO"
    sin = [u for u, e in estado.items() if e == "NO VERIFICADO"]
    print(f"Enlaces externos distintos: {len(estado)}. Abiertos directamente: {sum(1 for e in estado.values() if e.startswith('Abierto'))}. "
          f"Vistos en búsqueda: {sum(1 for e in estado.values() if e.startswith('Visto'))}. No verificados: {len(sin)}.")
    for u in sin:
        print("  NO VERIFICADO", u, "<-", ", ".join(sorted(externos[u])))
    if "--red" in args:
        print("Comprobando con peticiones HTTP (puede tardar)...")
        for url in sorted(estado):
            try:
                req = urllib.request.Request(url, method="HEAD", headers={"User-Agent": "Mozilla/5.0"})
                with urllib.request.urlopen(req, timeout=15) as r:
                    print(f"  {r.status} {url}")
            except Exception as ex:
                print(f"  ERR {url}: {ex}")
    if "--escribir" in args:
        destino = RAIZ / "recursos" / "ENLACES.md"
        filas = ["| Enlace | Estado de verificación | Usado en |", "|---|---|---|"]
        for url in sorted(estado):
            usos = ", ".join(sorted(externos[url]))
            filas.append(f"| <{url}> | {estado[url]} | {usos} |")
        bloque = "\n".join(filas)
        texto = destino.read_text(encoding="utf-8")
        ini, fin = "<!-- AUTO:TABLA:INICIO -->", "<!-- AUTO:TABLA:FIN -->"
        antes, resto = texto.split(ini, 1)
        _, despues = resto.split(fin, 1)
        destino.write_text(f"{antes}{ini}\n{bloque}\n{fin}{despues}", encoding="utf-8")
        print("Tabla de recursos/ENLACES.md actualizada.")
    sys.exit(1 if errores else 0)


if __name__ == "__main__":
    main()
