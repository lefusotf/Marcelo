#!/usr/bin/env python3
"""Genera los indices del curso a partir de herramientas/curriculo.json.

Uso (desde la raiz del repositorio):
    python3 -I herramientas/generar_indices.py            # genera y actualiza
    python3 -I herramientas/generar_indices.py --verificar  # solo valida el curriculo

Que escribe:
  - INDICE.md                   (completo, se regenera siempre)
  - CALENDARIO.md               (completo, se regenera siempre)
  - PENDIENTES_DEL_CURSO.md     (solo el bloque entre marcadores AUTO)
  - PLAN_DE_ESTUDIO.md          (solo el bloque entre marcadores AUTO:CALENDARIO)
  - modulos/<Mxx>/README.md     (solo el bloque entre marcadores AUTO:UNIDADES)
  - progreso/progreso.json      (SOLO si no existe; nunca sobrescribe tu progreso)

Un contenido se considera "disponible" si el archivo correspondiente existe.
Solo usa la biblioteca estandar de Python.
"""
import json
import re
import sys
from pathlib import Path

RAIZ = Path(__file__).resolve().parent.parent
CURRICULO = RAIZ / "herramientas" / "curriculo.json"


def cargar():
    with open(CURRICULO, encoding="utf-8") as f:
        return json.load(f)


def clave_unidad(uid):
    a, b = uid.split(".")
    return (int(a), int(b))


def prefijo(modulo, unidad):
    """00.01-que-es-programar"""
    n = unidad["id"].split(".")[1]
    return f"{modulo['num']:02d}.{int(n):02d}-{unidad['slug']}"


def carpeta_modulo(m):
    return f"{m['id']}-{m['slug']}"


def ruta_leccion(m, u):
    return f"modulos/{carpeta_modulo(m)}/{prefijo(m, u)}.md"


def ruta_retos(m, u):
    return f"modulos/{carpeta_modulo(m)}/retos/{prefijo(m, u)}-retos.md"


def ruta_soluciones(m, u):
    return f"soluciones/{carpeta_modulo(m)}/{prefijo(m, u)}-soluciones.md"


def ruta_proyecto(p):
    return f"proyectos/{p['id']}-{p['slug']}/ESPECIFICACION.md"


def existe(rel):
    return (RAIZ / rel).exists()


def validar(datos):
    errores = []
    unidades = {}
    for m in datos["modulos"]:
        for u in m["unidades"]:
            if u["id"] in unidades:
                errores.append(f"Unidad duplicada: {u['id']}")
            unidades[u["id"]] = (m, u)
    vistas = {}
    for s in datos["calendario"]:
        if len(s["sesiones"]) != 6:
            errores.append(f"Semana {s['n']}: debe tener 6 sesiones, tiene {len(s['sesiones'])}")
        for i, ses in enumerate(s["sesiones"], start=1):
            if ses in unidades:
                if ses in vistas:
                    errores.append(f"Unidad {ses} programada dos veces (semanas {vistas[ses]} y {s['n']})")
                vistas[ses] = s["n"]
            elif re.fullmatch(r"\d+\.\d+", ses):
                errores.append(f"Semana {s['n']}, sesion {i}: '{ses}' parece una unidad pero no existe")
    for uid in unidades:
        if uid not in vistas:
            errores.append(f"Unidad {uid} no esta programada en el calendario")
    semanas = [s["n"] for s in datos["calendario"]]
    if semanas != list(range(1, len(semanas) + 1)):
        errores.append("Las semanas del calendario no son consecutivas desde 1")
    return unidades, vistas, errores


def etiqueta_sesion(ses, unidades):
    if ses in unidades:
        m, u = unidades[ses]
        return u, m
    return None, None


def enlace(texto, rel, base=""):
    return f"[{texto}]({base}{rel})"


def reemplazar_bloque(ruta, nombre, contenido):
    """Reemplaza el texto entre <!-- AUTO:nombre:INICIO --> y <!-- AUTO:nombre:FIN -->."""
    p = RAIZ / ruta
    if not p.exists():
        return False
    texto = p.read_text(encoding="utf-8")
    ini = f"<!-- AUTO:{nombre}:INICIO -->"
    fin = f"<!-- AUTO:{nombre}:FIN -->"
    if ini not in texto or fin not in texto:
        print(f"AVISO: {ruta} no tiene los marcadores AUTO:{nombre}", file=sys.stderr)
        return False
    antes, resto = texto.split(ini, 1)
    _, despues = resto.split(fin, 1)
    nuevo = f"{antes}{ini}\n{contenido.strip()}\n{fin}{despues}"
    if nuevo != texto:
        p.write_text(nuevo, encoding="utf-8")
    return True


def generar_indice(datos, unidades, vistas):
    L = []
    L.append("# Índice general del curso\n")
    L.append("> Este archivo se **genera** con `python3 -I herramientas/generar_indices.py` a partir de "
             "`herramientas/curriculo.json`. No lo edites a mano: tus cambios se perderían.\n")
    L.append("**Cómo leerlo.** Las columnas *Lección*, *Retos* y *Soluciones* indican si ese archivo ya existe en el repositorio "
             "(✅ o enlace = disponible; ⏳ = en construcción). El avance **tuyo** no está aquí: "
             "está en [PROGRESO.md](PROGRESO.md).\n")
    L.append("Navegación rápida: [PLAN_DE_ESTUDIO.md](PLAN_DE_ESTUDIO.md) · [CALENDARIO.md](CALENDARIO.md) · "
             "[REGLAS_DE_APRENDIZAJE.md](REGLAS_DE_APRENDIZAJE.md) · [evaluaciones/RUBRICAS.md](evaluaciones/RUBRICAS.md)\n")
    total = disponibles = 0
    for m in datos["modulos"]:
        L.append(f"## Módulo {m['num']} · {m['titulo']}\n")
        L.append(f"{m['resumen']}\n")
        L.append(f"Programa del módulo: [{carpeta_modulo(m)}/README.md](modulos/{carpeta_modulo(m)}/README.md)\n")
        if not m["unidades"]:
            L.append("Este módulo se desarrolla mediante proyectos: ver [proyectos/README.md](proyectos/README.md).\n")
            L.append("| Proyecto | Semana de entrega | Especificación |")
            L.append("|---|---|---|")
            for p in datos["proyectos"]:
                est = "✅ disponible" if existe(ruta_proyecto(p)) else "⏳ pendiente"
                L.append(f"| {p['id']} · {p['titulo']} | {p['semana']} | {est} |")
            L.append("")
            continue
        L.append("| Unidad | Sem. | Temas | Lección | Retos | Soluciones |")
        L.append("|---|---|---|---|---|---|")
        for u in sorted(m["unidades"], key=lambda x: clave_unidad(x["id"])):
            total += 1
            l_ok = existe(ruta_leccion(m, u))
            r_ok = existe(ruta_retos(m, u))
            s_ok = existe(ruta_soluciones(m, u))
            if l_ok:
                disponibles += 1
            titulo = enlace(f"{u['id']} {u['titulo']}", ruta_leccion(m, u)) if l_ok else f"{u['id']} {u['titulo']}"
            retos = enlace("retos", ruta_retos(m, u)) if r_ok else "⏳"
            sols = enlace("soluciones", ruta_soluciones(m, u)) if s_ok else "⏳"
            estado = "✅" if l_ok else "⏳"
            L.append(f"| {estado} {titulo} | {vistas[u['id']]} | {'; '.join(u['temas'])} | {'✅' if l_ok else '⏳'} | {retos} | {sols} |")
        L.append("")
    L.append(f"**Resumen de construcción:** {disponibles} de {total} lecciones disponibles.\n")
    return "\n".join(L)


def semanas_de_modulo(m, vistas):
    ws = sorted({vistas[u["id"]] for u in m["unidades"]})
    if not ws:
        return "—"
    return f"{ws[0]}" if ws[0] == ws[-1] else f"{ws[0]}–{ws[-1]}"


def generar_calendario(datos, unidades):
    L = []
    L.append("# Calendario de referencia (semanas 1–28)\n")
    L.append("> Archivo **generado** desde `herramientas/curriculo.json` con `python3 -I herramientas/generar_indices.py`. "
             "No lo edites a mano.\n")
    L.append("Ritmo supuesto: **6 sesiones de 2 horas por semana** (S1–S5 de contenido y S6 de evaluación e integración) "
             "y un día de descanso. Es un calendario **de referencia**: se avanza cuando se demuestra dominio "
             "(ver [las puertas de avance](PLAN_DE_ESTUDIO.md#5-puertas-de-avance)), no cuando pasa el tiempo. "
             "Las semanas 25–28 son la fase de portafolio y empleabilidad: la ruta técnica nuclear ocupa las semanas 1–24.\n")
    for s in datos["calendario"]:
        L.append(f"## Semana {s['n']} · {s['titulo']}\n")
        L.append(f"*Fase {s['fase']}: {datos['fases'][s['fase']]}* · **Hito:** {s['hito']}\n")
        for i, ses in enumerate(s["sesiones"], start=1):
            if ses in unidades:
                m, u = unidades[ses]
                if existe(ruta_leccion(m, u)):
                    destino = enlace(f"{u['id']} {u['titulo']}", ruta_leccion(m, u))
                else:
                    destino = f"{u['id']} {u['titulo']} *(⏳ en construcción)*"
                L.append(f"- **S{i}** · {destino}")
            else:
                L.append(f"- **S{i}** · {ses}")
        L.append("")
    return "\n".join(L)


def tabla_calendario_resumen(datos, vistas):
    L = ["| Sem. | Fase | Foco | Hito |", "|---|---|---|---|"]
    for s in datos["calendario"]:
        L.append(f"| {s['n']} | {s['fase']} | {s['titulo']} | {s['hito']} |")
    return "\n".join(L)


def tabla_modulos_resumen(datos, vistas):
    L = ["| Módulo | Semanas | Unidades | Resumen |", "|---|---|---|---|"]
    for m in datos["modulos"]:
        if m["unidades"]:
            sem = semanas_de_modulo(m, vistas)
        else:
            sem = "9, 17, 20, 23, 24–26 (proyectos)"
        L.append(f"| M{m['num']} · {m['titulo']} | {sem} | {len(m['unidades'])} | {m['resumen']} |")
    return "\n".join(L)


def tabla_unidades_modulo(m, vistas):
    if not m["unidades"]:
        return "Este módulo no tiene unidades propias: se trabaja con los proyectos de [`proyectos/`](../../proyectos/README.md)."
    L = ["| Unidad | Sem. | Qué cubre | Lección | Retos | Soluciones |", "|---|---|---|---|---|---|"]
    for u in sorted(m["unidades"], key=lambda x: clave_unidad(x["id"])):
        lec = ruta_leccion(m, u).split("/", 2)[2]
        ret = ruta_retos(m, u).split("/", 2)[2]
        sol = "../../" + ruta_soluciones(m, u)
        l_ok, r_ok, s_ok = existe(ruta_leccion(m, u)), existe(ruta_retos(m, u)), existe(ruta_soluciones(m, u))
        L.append(
            f"| {u['id']} {u['titulo']} | {vistas[u['id']]} | {'; '.join(u['temas'])} | "
            f"{enlace('lección', lec) if l_ok else '⏳'} | {enlace('retos', ret) if r_ok else '⏳'} | "
            f"{enlace('soluciones', sol) if s_ok else '⏳'} |"
        )
    return "\n".join(L)


def generar_pendientes(datos, unidades, vistas):
    L = []
    falta_lec, falta_ret, falta_sol = [], [], []
    for m in datos["modulos"]:
        for u in sorted(m["unidades"], key=lambda x: clave_unidad(x["id"])):
            if not existe(ruta_leccion(m, u)):
                falta_lec.append((vistas[u["id"]], m, u))
            if not existe(ruta_retos(m, u)):
                falta_ret.append((vistas[u["id"]], m, u))
            if not existe(ruta_soluciones(m, u)):
                falta_sol.append((vistas[u["id"]], m, u))
    total = sum(len(m["unidades"]) for m in datos["modulos"])
    L.append(f"**Estado calculado de los archivos** (actualizado al ejecutar el generador): "
             f"{total - len(falta_lec)} de {total} lecciones, {total - len(falta_ret)} de {total} archivos de retos y "
             f"{total - len(falta_sol)} de {total} archivos de soluciones.\n")
    L.append("### Por fases de construcción (orden recomendado)\n")
    por_semana = {}
    for sem, m, u in falta_lec:
        por_semana.setdefault(sem, []).append((m, u))
    L.append("| Semanas del curso | Lecciones pendientes |")
    L.append("|---|---|")
    bloques = {}
    for sem in sorted(por_semana):
        bloques.setdefault((sem - 1) // 2, []).extend((sem, m, u) for m, u in por_semana[sem])
    for k in sorted(bloques):
        items = bloques[k]
        sems = sorted({s for s, _, _ in items})
        rango = f"{sems[0]}–{sems[-1]}" if sems[0] != sems[-1] else f"{sems[0]}"
        ids = ", ".join(u["id"] for _, _, u in items)
        L.append(f"| {rango} | {ids} |")
    L.append("")
    L.append("### Evaluaciones, proyectos y recursos pendientes\n")
    L.append("| Elemento | Estado |")
    L.append("|---|---|")
    for p in datos["proyectos"]:
        est = "✅" if existe(ruta_proyecto(p)) else "⏳"
        L.append(f"| Especificación {p['id']} · {p['titulo']} (`{ruta_proyecto(p)}`) | {est} |")
    for s in datos["calendario"]:
        if s["n"] <= 24:
            rel = f"evaluaciones/semana-{s['n']:02d}/EVALUACION_SEMANA_{s['n']:02d}.md"
            L.append(f"| Evaluación de la semana {s['n']} (`{rel}`) | {'✅' if existe(rel) else '⏳'} |")
    for m in datos["modulos"]:
        if m["unidades"]:
            rel = f"evaluaciones/modulo-{m['num']:02d}/EVALUACION_MODULO_{m['num']:02d}.md"
            L.append(f"| Evaluación del módulo {m['num']} (`{rel}`) | {'✅' if existe(rel) else '⏳'} |")
    return "\n".join(L)


def esqueleto_progreso(datos):
    unidades = {}
    for m in datos["modulos"]:
        for u in m["unidades"]:
            unidades[u["id"]] = {
                "titulo": u["titulo"],
                "estado": "no_iniciado",
                "ejercicios": {},
                "evaluacion": None,
                "fecha_dominio": None,
                "ultimo_repaso": None,
            }
    competencias = {}
    for m in datos["modulos"]:
        for cid, texto in m["competencias"]:
            competencias[cid] = {"descripcion": texto, "estado": "no_demostrada", "evidencias": []}
    proyectos = {p["id"]: {"titulo": p["titulo"], "estado": "no_iniciado", "puntaje": None, "repositorio": None}
                 for p in datos["proyectos"]}
    return {
        "_nota": "Estados de unidad: no_iniciado, en_curso, practicada, en_recuperacion, dominada, consolidada. "
                 "Estados de competencia: no_demostrada, en_desarrollo, demostrada, consolidada. "
                 "Un estado solo cambia con evidencia registrada (ver REGLAS_DE_APRENDIZAJE.md).",
        "version_curso": datos["version"],
        "herramientas": {"dotnet": "10 (LTS)", "csharp": "14", "sql_server": "2022 o 2025", "verificado": "2026-10-14"},
        "ruta": {"fecha_inicio": None, "semana_actual": 0, "sesion_actual": 0},
        "diagnostico": {"estado": "pendiente", "fecha": None, "resultados": None},
        "unidades": unidades,
        "evaluaciones": [],
        "competencias": competencias,
        "proyectos": proyectos,
        "errores_recurrentes": [],
        "sesiones": [],
        "proxima_actividad": {"tipo": "diagnostico", "referencia": "evaluaciones/00-diagnostico/DIAGNOSTICO.md"},
    }


def esqueleto_competencias(datos):
    L = ["# Competencias", "",
         "Registro de las competencias del curso. Una competencia pasa a **demostrada** solo con evidencia concreta "
         "(un programa, una evaluación superada, una defensa) anotada en la columna *Evidencia*. "
         "Estados: `no demostrada` · `en desarrollo` · `demostrada` · `consolidada`.", ""]
    total = 0
    for m in datos["modulos"]:
        L.append(f"## Módulo {m['num']} · {m['titulo']}")
        L.append("")
        L.append("| Código | Competencia | Estado | Evidencia | Fecha |")
        L.append("|---|---|---|---|---|")
        for cid, texto in m["competencias"]:
            total += 1
            L.append(f"| {cid} | {texto} | no demostrada | — | — |")
        L.append("")
    L.append(f"**Total:** {total} competencias, 0 demostradas.")
    L.append("")
    return "\n".join(L)


def main():
    datos = cargar()
    unidades, vistas, errores = validar(datos)
    if errores:
        print("ERRORES en curriculo.json:", file=sys.stderr)
        for e in errores:
            print(" -", e, file=sys.stderr)
        sys.exit(1)
    print(f"Curriculo valido: {len(datos['modulos'])} modulos, {len(unidades)} unidades, "
          f"{len(datos['calendario'])} semanas.")
    if "--verificar" in sys.argv:
        return
    (RAIZ / "INDICE.md").write_text(generar_indice(datos, unidades, vistas), encoding="utf-8")
    (RAIZ / "CALENDARIO.md").write_text(generar_calendario(datos, unidades), encoding="utf-8")
    reemplazar_bloque("PLAN_DE_ESTUDIO.md", "CALENDARIO", tabla_calendario_resumen(datos, vistas))
    reemplazar_bloque("PLAN_DE_ESTUDIO.md", "MODULOS", tabla_modulos_resumen(datos, vistas))
    reemplazar_bloque("PENDIENTES_DEL_CURSO.md", "ESTADO", generar_pendientes(datos, unidades, vistas))
    for m in datos["modulos"]:
        reemplazar_bloque(f"modulos/{carpeta_modulo(m)}/README.md", "UNIDADES", tabla_unidades_modulo(m, vistas))
    destino = RAIZ / "progreso" / "progreso.json"
    if not destino.exists():
        destino.parent.mkdir(parents=True, exist_ok=True)
        destino.write_text(json.dumps(esqueleto_progreso(datos), ensure_ascii=False, indent=2) + "\n", encoding="utf-8")
        print("Creado progreso/progreso.json (esqueleto inicial).")
    else:
        print("progreso/progreso.json ya existe: no se toca.")
    comp = RAIZ / "progreso" / "competencias.md"
    if not comp.exists():
        comp.write_text(esqueleto_competencias(datos), encoding="utf-8")
        print("Creado progreso/competencias.md (esqueleto inicial).")
    else:
        print("progreso/competencias.md ya existe: no se toca.")
    print("Indices generados.")


if __name__ == "__main__":
    main()
