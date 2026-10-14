# P1 · Colección de programas de consola

> **Semana 4** · Integra el **Módulo 1** · Evaluación: rúbrica D + defensa · Forma parte de la **Puerta 1**
> Tu código va en `proyectos/P1-programas-de-consola/codigo/`. No se edita este archivo.

## 1. Problema que resuelve

Practicar los fundamentos juntos en un programa de verdad: no cinco ejercicios sueltos, sino **una pequeña aplicación de consola con menú** que reúne varios programas útiles, validada y probada.

## 2. Público objetivo

Una persona que abre el programa y quiere usar rápidamente varias utilidades (calcular, convertir, jugar, analizar notas, manipular texto). Y, en un segundo plano, **quien revise tu portafolio**: verá si escribes código legible, validas entradas y pruebas lo que haces.

## 3. Requisitos funcionales

**RF0 · Menú.** Al ejecutar, muestra un menú numerado con las utilidades y la opción *Salir*. Tras cada utilidad, vuelve al menú. Una opción inválida avisa y repite el menú; el programa **nunca se cae** por una entrada incorrecta.

**Las seis utilidades** (cada una en su propio método):

| N.º | Utilidad | Qué hace |
|---|---|---|
| 1 | **Calculadora** | Pide dos números decimales y una operación (`+`, `-`, `*`, `/`). Muestra el resultado. Divide solo si el divisor no es cero. |
| 2 | **Conversor** | Convierte temperatura (°C ↔ °F) y longitud (km ↔ millas) según una opción elegida. |
| 3 | **Adivina el número** | El programa elige un número secreto entre 1 y 100 (`Random`). La persona tiene 7 intentos; tras cada uno se le dice *mayor* o *menor*. Al final muestra el resultado y los intentos usados. |
| 4 | **Estadísticas de notas** | Lee notas (0–100) hasta que se escribe `fin`. Muestra cantidad, promedio, mayor, menor y cuántas están aprobadas (≥ 60). Ignora y avisa de notas inválidas. |
| 5 | **Utilidades de texto** | Dada una frase: cuenta vocales, cuenta palabras, la invierte y dice si es **palíndromo** (ignorando mayúsculas y espacios). |
| 6 | **Cajero simple** | Un saldo inicial de 100.00; permite consultar, depositar y retirar. No se puede retirar más que el saldo ni depositar valores no positivos. |

**RF7 · Validación.** Toda entrada numérica se valida con `TryParse` y se vuelve a pedir si es inválida.

**RF8 · Salida.** Mensajes claros, en español, con formato consistente (dinero con dos decimales).

## 4. Requisitos no funcionales

- **Legibilidad:** nombres descriptivos, métodos cortos (una responsabilidad), sin números "mágicos" (constantes con nombre).
- **Robustez:** ninguna entrada del usuario debe provocar una excepción no controlada.
- **Mantenibilidad:** sin código duplicado; la lectura y validación de números es **un solo método reutilizado**.
- **Convenciones:** identificadores en `camelCase`/`PascalCase`, sin `ñ` ni tildes en el código.
- **Calidad de proceso:** commits pequeños (uno por utilidad como mínimo), con mensajes concretos.

## 5. Conceptos que practicarás

Variables y tipos (1.1) · entrada y salida (1.2) · operadores (1.3) · conversión y validación (1.4) · `if` y `switch` (1.5–1.6) · bucles (1.7–1.8) · métodos y ámbito (1.9–1.10) · arrays y listas (1.11–1.12) · cadenas (1.13) · pseudocódigo (1.14) · depuración (1.15) · Git (0.3).

## 6. Diseño inicial

Antes de programar, dibuja en papel el diagrama de flujo del menú y del bucle principal. Estructura sugerida (sin clases todavía; se verán en el módulo 3):

```text
Program.cs
 ├─ bucle del menú (while) + switch
 ├─ métodos de entrada reutilizables:   LeerDecimal(...), LeerEntero(...), LeerTexto(...)
 └─ un método por utilidad:             Calculadora(), Conversor(), AdivinaElNumero(),
                                         EstadisticasDeNotas(), UtilidadesDeTexto(), CajeroSimple()
```

Decisiones que debes tomar y justificar en tu README: dónde guardar el saldo del cajero entre llamadas (¿variable local? ¿parámetro?), qué tipo usar para el dinero y por qué, cómo evitar repetir la validación.

## 7. Plan de tareas (30–60 min cada una)

| N.º | Tarea | Resultado verificable |
|---|---|---|
| T1 | Crear el proyecto y el repositorio de trabajo; primer commit | `dotnet run` muestra el menú vacío |
| T2 | Métodos de lectura validada (`LeerDecimal`, `LeerEntero`) con sus pruebas | Tabla de pruebas de entradas válidas e inválidas |
| T3 | Menú con `while` + `switch` y opción Salir | Opciones inválidas no rompen el programa |
| T4 | Calculadora | Casos: división por cero, negativos, decimales |
| T5 | Conversor | Valores de referencia conocidos (0 °C = 32 °F, 100 °C = 212 °F) |
| T6 | Adivina el número | Se puede ganar y perder; el contador es correcto |
| T7 | Estadísticas de notas | Lista vacía, una nota, nota inválida |
| T8 | Utilidades de texto | Frase vacía, palíndromo con mayúsculas y espacios |
| T9 | Cajero simple | Retiro mayor que el saldo; depósito negativo |
| T10 | Revisión de duplicación, nombres y constantes | Código sin repeticiones evidentes |
| T11 | Tabla de pruebas completa y `README.md` | Otra persona puede ejecutar y probar |
| T12 | Preparar la defensa (ensayar la explicación) | Puedes explicar cada método sin leer |

## 8. Criterios de aceptación

- [ ] Las seis utilidades funcionan según las reglas de la sección 3.
- [ ] Ninguna entrada inválida (letras, vacío, números fuera de rango) provoca una caída.
- [ ] La tabla de pruebas tiene **al menos 5 casos por utilidad** (normales, límite e inválidos), con resultados reales.
- [ ] La lectura y validación está en métodos reutilizados, sin copiar y pegar.
- [ ] `git log` cuenta la historia en ≥ 10 commits claros.
- [ ] El README explica propósito, ejecución y 3 decisiones técnicas.

## 9. Casos de prueba mínimos (los amplías tú)

| Utilidad | Caso | Resultado esperado |
|---|---|---|
| Menú | Escribir `9` | Aviso de opción inválida y vuelve al menú |
| Menú | Escribir `abc` | Aviso y vuelve al menú |
| Calculadora | `7` `/` `0` | Mensaje de error sin caída |
| Calculadora | `0.1` `+` `0.2` | Resultado coherente con el tipo elegido (justifica) |
| Conversor | `0` °C a °F | `32` |
| Adivina | Acertar al primer intento | Mensaje de victoria con `1` intento |
| Adivina | Fallar los 7 | Mensaje de derrota con el número secreto |
| Notas | `fin` sin notas | Aviso de que no hay datos |
| Notas | `101` | Avisa que la nota es inválida y no se cuenta |
| Texto | `Anita lava la tina` | Palíndromo: sí |
| Texto | frase vacía | Aviso o resultado sensato, sin caída |
| Cajero | Retirar `150` con saldo `100` | Rechazado, saldo intacto |

## 10. Posibles ampliaciones (después de la puerta)

- Guardar y mostrar las mejores puntuaciones de *Adivina el número* en un archivo.
- Añadir una utilidad más (por ejemplo, tabla de multiplicar con bucles anidados).
- Colores en la consola y una cabecera con tu nombre y la fecha.

## 11. Entregables

1. `codigo/` con el proyecto, y `codigo/README.md` (usa [plantillas/readme-de-proyecto.md](../../plantillas/readme-de-proyecto.md)).
2. `codigo/pruebas/tabla-de-pruebas.md` (usa [plantillas/tabla-de-pruebas.md](../../plantillas/tabla-de-pruebas.md)).
3. Historial de Git.
4. Bitácora con el informe de los problemas más difíciles que resolviste.

## 12. Evaluación y defensa

Rúbrica D (100 puntos): requisitos y funcionamiento 30 · diseño y organización 20 · calidad, validaciones y errores 15 · pruebas 10 · documentación 10 · defensa 15. **Bloqueantes:** credenciales o datos reales en el repositorio, no ejecutable con tu README, no poder explicar partes centrales.

En la defensa te pediré: explicar el flujo del menú, justificar dos decisiones, localizar un error que introduzca en tu código y hacer un cambio pequeño en vivo (por ejemplo, añadir una operación a la calculadora).
