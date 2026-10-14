# Índice general del curso

> Este archivo se **genera** con `python3 -I herramientas/generar_indices.py` a partir de `herramientas/curriculo.json`. No lo edites a mano: tus cambios se perderían.

**Cómo leerlo.** Las columnas *Lección*, *Retos* y *Soluciones* indican si ese archivo ya existe en el repositorio (✅ o enlace = disponible; ⏳ = en construcción). El avance **tuyo** no está aquí: está en [PROGRESO.md](PROGRESO.md).

Navegación rápida: [PLAN_DE_ESTUDIO.md](PLAN_DE_ESTUDIO.md) · [CALENDARIO.md](CALENDARIO.md) · [REGLAS_DE_APRENDIZAJE.md](REGLAS_DE_APRENDIZAJE.md) · [evaluaciones/RUBRICAS.md](evaluaciones/RUBRICAS.md)

## Módulo 0 · Preparación del entorno y método de aprendizaje

Qué es programar, cómo pasa el código fuente a programa en ejecución, tu entorno de trabajo, la terminal, los errores, el depurador y el método de estudio.

Programa del módulo: [M00-entorno-y-metodo/README.md](modulos/M00-entorno-y-metodo/README.md)

| Unidad | Sem. | Temas | Lección | Retos | Soluciones |
|---|---|---|---|---|---|
| ✅ [0.1 Qué es programar y cómo funciona un programa](modulos/M00-entorno-y-metodo/00.01-que-es-programar.md) | 1 | algoritmo y programa; código fuente, compilación y ejecución; .NET: CLR, IL y JIT a nivel intuitivo; primer programa | ✅ | [retos](modulos/M00-entorno-y-metodo/retos/00.01-que-es-programar-retos.md) | [soluciones](soluciones/M00-entorno-y-metodo/00.01-que-es-programar-soluciones.md) |
| ✅ [0.2 Terminal, archivos y carpetas; instalación y verificación del entorno](modulos/M00-entorno-y-metodo/00.02-terminal-y-entorno.md) | 1 | rutas y navegación; comandos básicos de terminal; .NET SDK, editor y SQL Server; verificar la instalación | ✅ | [retos](modulos/M00-entorno-y-metodo/retos/00.02-terminal-y-entorno-retos.md) | [soluciones](soluciones/M00-entorno-y-metodo/00.02-terminal-y-entorno-soluciones.md) |
| ✅ [0.3 Tu primer proyecto, tu bitácora y Git mínimo](modulos/M00-entorno-y-metodo/00.03-primer-proyecto-git-y-bitacora.md) | 1 | dotnet new/build/run; anatomía de un proyecto; organizar sesiones de estudio y registrar progreso; git init, add, commit, log | ✅ | [retos](modulos/M00-entorno-y-metodo/retos/00.03-primer-proyecto-git-y-bitacora-retos.md) | [soluciones](soluciones/M00-entorno-y-metodo/00.03-primer-proyecto-git-y-bitacora-soluciones.md) |
| ✅ [0.4 Errores, depurador y documentación](modulos/M00-entorno-y-metodo/00.04-errores-depurador-y-documentacion.md) | 1 | errores de compilación, de ejecución y lógicos; leer un mensaje de error; puntos de interrupción y paso a paso; buscar en la documentación oficial | ✅ | [retos](modulos/M00-entorno-y-metodo/retos/00.04-errores-depurador-y-documentacion-retos.md) | [soluciones](soluciones/M00-entorno-y-metodo/00.04-errores-depurador-y-documentacion-soluciones.md) |

## Módulo 1 · Fundamentos de programación

Variables, tipos, entrada y salida, operadores, condicionales, bucles, métodos, colecciones básicas, cadenas, pseudocódigo y depuración.

Programa del módulo: [M01-fundamentos-de-programacion/README.md](modulos/M01-fundamentos-de-programacion/README.md)

| Unidad | Sem. | Temas | Lección | Retos | Soluciones |
|---|---|---|---|---|---|
| ✅ [1.1 Variables, constantes y tipos de datos](modulos/M01-fundamentos-de-programacion/01.01-variables-y-tipos.md) | 1 | declaración y asignación; int, long, double, decimal, bool, char, string; const y var; interpolación de cadenas; valores por defecto | ✅ | [retos](modulos/M01-fundamentos-de-programacion/retos/01.01-variables-y-tipos-retos.md) | [soluciones](soluciones/M01-fundamentos-de-programacion/01.01-variables-y-tipos-soluciones.md) |
| ⏳ 1.2 Entrada y salida por consola | 2 | Console.WriteLine/Write/ReadLine; secuencias de escape; formato numérico y cultura; diseño de la interacción con el usuario | ⏳ | ⏳ | ⏳ |
| ⏳ 1.3 Operadores aritméticos, relacionales y lógicos | 2 | división entera y resto; comparaciones; &&, || y !; precedencia; asignación compuesta, ++ y -- | ⏳ | ⏳ | ⏳ |
| ⏳ 1.4 Conversión y validación de datos | 2 | conversión implícita y explícita; Parse y TryParse; rangos y entradas vacías; desbordamiento | ⏳ | ⏳ | ⏳ |
| ⏳ 1.5 Condicionales: if y else | 2 | if / else if / else; condiciones compuestas; anidamiento y simplificación; operador condicional | ⏳ | ⏳ | ⏳ |
| ⏳ 1.6 Condicionales: switch y expresiones switch | 2 | switch clásico y break; expresión switch; patrones relacionales simples; cuándo usar switch o if | ⏳ | ⏳ | ⏳ |
| ⏳ 1.7 Bucles: while y do-while | 3 | condición de parada; centinelas y acumuladores; bucles infinitos; reintentar una entrada hasta que sea válida | ⏳ | ⏳ | ⏳ |
| ⏳ 1.8 Bucles: for, foreach y bucles anidados | 3 | contadores; break y continue; bucles anidados; errores de uno de más o de menos | ⏳ | ⏳ | ⏳ |
| ⏳ 1.9 Métodos, parámetros y valores de retorno | 3 | declarar y llamar métodos; void y retorno; parámetros; sobrecarga; nombrado de métodos | ⏳ | ⏳ | ⏳ |
| ⏳ 1.10 Ámbito de las variables y diseño con métodos | 3 | ámbito de bloque y de método; parámetros por valor; descomponer un programa; evitar efectos ocultos | ⏳ | ⏳ | ⏳ |
| ⏳ 1.11 Arrays | 4 | declaración e inicialización; índices y límites; recorrido; matrices bidimensionales (introducción) | ⏳ | ⏳ | ⏳ |
| ⏳ 1.12 Listas (List<T>) | 4 | Add, Remove, Contains, Count; recorrer y modificar; array frente a lista; buscar elementos | ⏳ | ⏳ | ⏳ |
| ⏳ 1.13 Cadenas de texto | 4 | inmutabilidad; Length, Substring, IndexOf, Split, Trim, Replace; comparar y normalizar; char y recorrido de cadenas; StringBuilder (introducción) | ⏳ | ⏳ | ⏳ |
| ⏳ 1.14 Pseudocódigo y diagramas de flujo | 3 | notación de pseudocódigo; diagramas de flujo; traducir a C#; tablas de seguimiento | ⏳ | ⏳ | ⏳ |
| ⏳ 1.15 Depuración y lectura de código | 4 | leer código ajeno; trazar y predecir; depurar errores deliberados; hipótesis y verificación | ⏳ | ⏳ | ⏳ |

## Módulo 2 · Lógica y resolución de problemas

Descomponer, modelar entradas, procesos y salidas, construir algoritmos, probar casos límite, patrones clásicos y complejidad introductoria.

Programa del módulo: [M02-logica-y-resolucion-de-problemas/README.md](modulos/M02-logica-y-resolucion-de-problemas/README.md)

| Unidad | Sem. | Temas | Lección | Retos | Soluciones |
|---|---|---|---|---|---|
| ⏳ 2.1 Descomposición de problemas y modelo entrada–proceso–salida | 5 | leer un enunciado con precisión; entradas, proceso y salidas; dividir en subproblemas; ejemplos a mano antes de programar | ⏳ | ⏳ | ⏳ |
| ⏳ 2.2 Construcción de algoritmos y trazas | 5 | de la idea al pseudocódigo; invariantes sencillos; trazas completas; verificar antes de codificar | ⏳ | ⏳ | ⏳ |
| ⏳ 2.3 Casos límite y validación de requisitos | 5 | vacío, uno, máximo, repetidos, negativos; requisitos ambiguos y preguntas aclaratorias; tabla de casos de prueba; pruebas manuales sistemáticas | ⏳ | ⏳ | ⏳ |
| ⏳ 2.4 Patrones: conteo y acumulación | 5 | contadores; acumuladores; promedios y totales; inicialización correcta | ⏳ | ⏳ | ⏳ |
| ⏳ 2.5 Patrones: búsqueda y selección | 5 | primera coincidencia; máximo y mínimo; existencia y posición; parar cuando ya se sabe | ⏳ | ⏳ | ⏳ |
| ⏳ 2.6 Patrones: clasificación y agrupación | 6 | clasificar en categorías; frecuencias; ordenar a mano (intuición); agrupar con estructuras sencillas | ⏳ | ⏳ | ⏳ |
| ⏳ 2.7 Análisis de errores y corrección de algoritmos | 6 | localizar errores lógicos; contraejemplos; invariantes rotos; corregir sin reescribir todo | ⏳ | ⏳ | ⏳ |
| ⏳ 2.8 Complejidad algorítmica introductoria | 6 | contar operaciones; crecimiento con el tamaño de entrada; lineal frente a cuadrático; medir tiempos con cuidado | ⏳ | ⏳ | ⏳ |
| ⏳ 2.9 Explicar y comparar soluciones | 6 | explicar en voz alta; comparar estrategias; ventajas y desventajas; defender una elección | ⏳ | ⏳ | ⏳ |

## Módulo 3 · C# intermedio y programación orientada a objetos

Clases, encapsulación, composición, interfaces, herencia, tipos por valor y referencia, colecciones genéricas, LINQ básico, excepciones y buenas prácticas.

Programa del módulo: [M03-csharp-intermedio-y-poo/README.md](modulos/M03-csharp-intermedio-y-poo/README.md)

| Unidad | Sem. | Temas | Lección | Retos | Soluciones |
|---|---|---|---|---|---|
| ⏳ 3.1 Clases y objetos | 7 | clase frente a objeto; campos y métodos; new y referencias; modelar una entidad | ⏳ | ⏳ | ⏳ |
| ⏳ 3.2 Propiedades, constructores y encapsulación | 7 | propiedades; constructores; invariantes y objetos válidos; private, public e init | ⏳ | ⏳ | ⏳ |
| ⏳ 3.3 Miembros estáticos, archivos y espacios de nombres | 7 | static; un tipo por archivo; namespaces y using; organizar un proyecto | ⏳ | ⏳ | ⏳ |
| ⏳ 3.4 Composición y relaciones entre objetos | 7 | tiene-un frente a es-un; objetos que contienen objetos; responsabilidades; diagramas de clases sencillos | ⏳ | ⏳ | ⏳ |
| ⏳ 3.5 Interfaces | 8 | contrato frente a implementación; implementar varias interfaces; programar contra la interfaz; cuándo una interfaz sobra | ⏳ | ⏳ | ⏳ |
| ⏳ 3.6 Herencia y polimorfismo | 8 | clase base y derivada; virtual y override; clases abstractas; herencia frente a composición | ⏳ | ⏳ | ⏳ |
| ⏳ 3.7 Enums, structs, records y tipos por valor y por referencia | 8 | enum; struct frente a class; record; copia por valor y por referencia; null y nullabilidad | ⏳ | ⏳ | ⏳ |
| ⏳ 3.8 Colecciones genéricas y genéricos propios | 8 | List, Dictionary, HashSet, Queue, Stack; inicializadores; métodos genéricos; clases genéricas sencillas | ⏳ | ⏳ | ⏳ |
| ⏳ 3.9 Manejo de excepciones | 8 | try, catch, finally; lanzar excepciones propias; qué capturar y qué no; validar frente a capturar | ⏳ | ⏳ | ⏳ |
| ⏳ 3.10 Buenas prácticas y SOLID con ejemplos | 9 | responsabilidad única; abierto y cerrado; dependencias; cuándo una abstracción ayuda y cuándo complica | ⏳ | ⏳ | ⏳ |
| ⏳ 3.11 LINQ esencial | 9 | Where, Select, OrderBy; Any, Count, First, Sum; GroupBy (introducción); ejecución diferida | ⏳ | ⏳ | ⏳ |

## Módulo 4 · Estructuras de datos y fundamentos de algoritmos

Cómo funcionan y cuánto cuestan las estructuras habituales; búsqueda, ordenamiento, recursividad y razonamiento sobre complejidad.

Programa del módulo: [M04-estructuras-de-datos-y-algoritmos/README.md](modulos/M04-estructuras-de-datos-y-algoritmos/README.md)

| Unidad | Sem. | Temas | Lección | Retos | Soluciones |
|---|---|---|---|---|---|
| ⏳ 4.1 Arrays y listas por dentro | 10 | memoria contigua; redimensionamiento de List; costo de insertar, buscar y borrar; medir en vez de suponer | ⏳ | ⏳ | ⏳ |
| ⏳ 4.2 Diccionarios y conjuntos | 10 | clave y valor; idea de tabla hash; HashSet; colisiones a nivel intuitivo | ⏳ | ⏳ | ⏳ |
| ⏳ 4.3 Pilas y colas | 10 | LIFO y FIFO; Stack<T> y Queue<T>; problemas típicos (paréntesis balanceados, turnos); elegir pila o cola | ⏳ | ⏳ | ⏳ |
| ⏳ 4.4 Búsqueda lineal y binaria | 10 | búsqueda lineal; búsqueda binaria; precondición: datos ordenados; errores de límites | ⏳ | ⏳ | ⏳ |
| ⏳ 4.5 Ordenamiento básico | 10 | selección; inserción; burbuja; trazar un ordenamiento | ⏳ | ⏳ | ⏳ |
| ⏳ 4.6 Ordenamiento eficiente y ordenamiento de la biblioteca | 11 | idea de dividir y combinar; Array.Sort y OrderBy; comparadores; estabilidad | ⏳ | ⏳ | ⏳ |
| ⏳ 4.7 Recursividad básica | 11 | caso base y caso recursivo; la pila de llamadas; recursión frente a iteración; desbordamiento de pila | ⏳ | ⏳ | ⏳ |
| ⏳ 4.8 Big O e intuición de complejidad | 11 | O(1), O(log n), O(n), O(n log n), O(n²); analizar un fragmento; mejor, promedio y peor caso; complejidad de espacio | ⏳ | ⏳ | ⏳ |
| ⏳ 4.9 Elegir la estructura según el problema | 11 | criterios de elección; problemas progresivos de razonamiento; justificar con costos; contraejemplos | ⏳ | ⏳ | ⏳ |

## Módulo 5 · Bases de datos y SQL Server

Modelo relacional, consultas, modificación de datos, diseño y normalización, restricciones, índices, transacciones e inyección SQL.

Programa del módulo: [M05-bases-de-datos-y-sql-server/README.md](modulos/M05-bases-de-datos-y-sql-server/README.md)

| Unidad | Sem. | Temas | Lección | Retos | Soluciones |
|---|---|---|---|---|---|
| ⏳ 5.1 Bases de datos relacionales, SQL Server y SSMS | 12 | tablas, filas y columnas; tipos de datos de SQL Server; crear una base y una tabla; usar SSMS o la extensión MSSQL | ⏳ | ⏳ | ⏳ |
| ⏳ 5.2 Claves y relaciones | 12 | clave primaria; clave foránea; uno a uno, uno a muchos, muchos a muchos; tablas intermedias | ⏳ | ⏳ | ⏳ |
| ⏳ 5.3 SELECT, WHERE y ORDER BY | 12 | proyección y filtros; operadores y NULL; ordenar y limitar resultados; LIKE e IN | ⏳ | ⏳ | ⏳ |
| ⏳ 5.4 Funciones de agregación, GROUP BY y HAVING | 12 | COUNT, SUM, AVG, MIN, MAX; GROUP BY; HAVING frente a WHERE; orden lógico de una consulta | ⏳ | ⏳ | ⏳ |
| ⏳ 5.5 INSERT, UPDATE y DELETE | 12 | insertar filas; actualizar con WHERE; borrar con seguridad; probar con SELECT antes de modificar | ⏳ | ⏳ | ⏳ |
| ⏳ 5.6 JOIN | 13 | INNER JOIN; LEFT JOIN; varias tablas; errores típicos (duplicados y filas perdidas) | ⏳ | ⏳ | ⏳ |
| ⏳ 5.7 Subconsultas y expresiones de tabla comunes | 13 | subconsultas escalares y de lista; EXISTS; CTE; reescribir con JOIN | ⏳ | ⏳ | ⏳ |
| ⏳ 5.8 Diseño de esquemas y normalización | 13 | redundancia y anomalías; 1FN, 2FN y 3FN; diagrama entidad–relación; cuándo desnormalizar | ⏳ | ⏳ | ⏳ |
| ⏳ 5.9 Restricciones e índices | 13 | NOT NULL, UNIQUE, CHECK, DEFAULT; integridad referencial; índices; plan de ejecución (introducción) | ⏳ | ⏳ | ⏳ |
| ⏳ 5.10 Transacciones | 14 | ACID a nivel intuitivo; BEGIN, COMMIT y ROLLBACK; bloqueos (introducción); TRY/CATCH en T-SQL | ⏳ | ⏳ | ⏳ |
| ⏳ 5.11 Consultas parametrizadas e inyección SQL | 14 | qué es la inyección SQL; demostración controlada; parámetros; mínimo privilegio | ⏳ | ⏳ | ⏳ |
| ⏳ 5.12 Diseñar una base de datos desde requisitos reales | 14 | de requisitos a entidades; modelo y script de creación; datos de prueba; consultas de validación | ⏳ | ⏳ | ⏳ |

## Módulo 6 · C# conectado a bases de datos

ADO.NET con Microsoft.Data.SqlClient, CRUD seguro, capas, transacciones, async/await y una primera mirada a Entity Framework Core.

Programa del módulo: [M06-csharp-y-bases-de-datos/README.md](modulos/M06-csharp-y-bases-de-datos/README.md)

| Unidad | Sem. | Temas | Lección | Retos | Soluciones |
|---|---|---|---|---|---|
| ⏳ 6.1 Conexiones, cadenas de conexión y configuración segura | 15 | SqlConnection; cadena de conexión; User Secrets y variables de entorno; no versionar credenciales | ⏳ | ⏳ | ⏳ |
| ⏳ 6.2 Consultas parametrizadas y lectura de resultados | 15 | SqlCommand; parámetros tipados; SqlDataReader; ExecuteScalar y ExecuteNonQuery | ⏳ | ⏳ | ⏳ |
| ⏳ 6.3 CRUD completo con ADO.NET | 15 | crear, leer, actualizar y borrar; mapear filas a objetos; manejo de resultados vacíos; pruebas manuales contra la base | ⏳ | ⏳ | ⏳ |
| ⏳ 6.4 Separar lógica de negocio y acceso a datos | 15 | responsabilidades; repositorio simple; entidades y servicios; qué no va en la capa de datos | ⏳ | ⏳ | ⏳ |
| ⏳ 6.5 Validación, errores y gestión de recursos | 15 | using y Dispose; excepciones de SQL; mensajes al usuario frente a registros técnicos; no perder la excepción original | ⏳ | ⏳ | ⏳ |
| ⏳ 6.6 Transacciones y consistencia de los datos | 16 | SqlTransaction; operaciones que deben ir juntas; commit y rollback; pruebas de fallo | ⏳ | ⏳ | ⏳ |
| ⏳ 6.7 async/await esencial | 16 | qué problema resuelve; Task y await; async en acceso a datos; errores comunes (async void, bloqueos) | ⏳ | ⏳ | ⏳ |
| ⏳ 6.8 Entity Framework Core y comparación con ADO.NET | 16 | DbContext y DbSet; consultas con LINQ; seguimiento de cambios; cuándo elegir cada enfoque | ⏳ | ⏳ | ⏳ |
| ⏳ 6.9 Migraciones y gestión del esquema | 16 | crear una migración; aplicar y revertir; revisar el SQL generado; versionar el esquema | ⏳ | ⏳ | ⏳ |

## Módulo 7 · Herramientas y flujo de trabajo profesional

Git y GitHub a fondo, terminal, convenciones, depuración avanzada, revisión de código, documentación y trabajo por iteraciones.

Programa del módulo: [M07-herramientas-y-flujo-profesional/README.md](modulos/M07-herramientas-y-flujo-profesional/README.md)

| Unidad | Sem. | Temas | Lección | Retos | Soluciones |
|---|---|---|---|---|---|
| ⏳ 7.1 Git a fondo: historial, deshacer y .gitignore | 17 | área de preparación; ver y comparar cambios; deshacer con seguridad; .gitignore | ⏳ | ⏳ | ⏳ |
| ⏳ 7.2 Ramas, merge y resolución de conflictos | 17 | crear y cambiar de rama; merge; conflictos; flujo de trabajo con ramas | ⏳ | ⏳ | ⏳ |
| ⏳ 7.3 GitHub: remotos, issues y pull requests | 17 | remote, push y pull; issues; pull requests; revisión y fusión | ⏳ | ⏳ | ⏳ |
| ⏳ 7.4 Terminal productiva, convenciones de nombres y formato | 18 | atajos y scripts simples; convenciones de C#; editorconfig; analizadores | ⏳ | ⏳ | ⏳ |
| ⏳ 7.5 Depuración avanzada e investigación de errores | 18 | puntos de interrupción condicionales; excepciones y pila de llamadas; reproducir y reducir; preguntar bien | ⏳ | ⏳ | ⏳ |
| ⏳ 7.6 Leer y revisar código ajeno | 18 | estrategia de lectura; lista de verificación de revisión; comentarios de revisión útiles; revisar código propio antiguo | ⏳ | ⏳ | ⏳ |
| ⏳ 7.7 Documentación técnica y trabajo por iteraciones | 18 | README útil; comentarios XML; registro de decisiones; tareas pequeñas y tablero simple | ⏳ | ⏳ | ⏳ |

## Módulo 8 · Calidad y mantenimiento del software

Pruebas, refactorización, capas, inyección de dependencias, registros, seguridad básica y mantenimiento de aplicaciones existentes.

Programa del módulo: [M08-calidad-y-mantenimiento/README.md](modulos/M08-calidad-y-mantenimiento/README.md)

| Unidad | Sem. | Temas | Lección | Retos | Soluciones |
|---|---|---|---|---|---|
| ⏳ 8.1 Pruebas unitarias con xUnit | 19 | Arrange, Act, Assert; Fact y Theory; qué probar y qué no; nombres de pruebas | ⏳ | ⏳ | ⏳ |
| ⏳ 8.2 Casos de prueba, criterios de aceptación y pruebas de integración | 19 | criterios de aceptación; derivar casos de prueba; pruebas de integración; datos de prueba | ⏳ | ⏳ | ⏳ |
| ⏳ 8.3 Refactorización, duplicación y complejidad innecesaria | 19 | olores de código; extraer método; eliminar duplicación; refactorizar con pruebas | ⏳ | ⏳ | ⏳ |
| ⏳ 8.4 Arquitectura por capas y SOLID sin dogmatismo | 19 | capas y responsabilidades; dependencias hacia adentro; SOLID aplicado; sobreingeniería | ⏳ | ⏳ | ⏳ |
| ⏳ 8.5 Inyección de dependencias | 20 | acoplamiento; inyección por constructor; contenedor de .NET; dobles de prueba | ⏳ | ⏳ | ⏳ |
| ⏳ 8.6 Logging y diagnóstico de errores | 20 | niveles de registro; ILogger; qué registrar y qué no; diagnosticar un fallo desde los registros | ⏳ | ⏳ | ⏳ |
| ⏳ 8.7 Seguridad básica y validación de entradas | 20 | no confiar en la entrada; secretos y datos sensibles; errores que filtran información; dependencias | ⏳ | ⏳ | ⏳ |
| ⏳ 8.8 Mantenimiento de aplicaciones existentes | 20 | entender antes de tocar; pruebas de caracterización; cambios pequeños y seguros; deuda técnica | ⏳ | ⏳ | ⏳ |

## Módulo 9 · Desarrollo web con ASP.NET Core

HTTP, lo esencial de HTML, CSS y JavaScript, APIs REST con ASP.NET Core, acceso a datos, autenticación, configuración, documentación y publicación.

Programa del módulo: [M09-desarrollo-web-aspnet-core/README.md](modulos/M09-desarrollo-web-aspnet-core/README.md)

| Unidad | Sem. | Temas | Lección | Retos | Soluciones |
|---|---|---|---|---|---|
| ⏳ 9.1 Fundamentos de HTTP: solicitudes y respuestas | 21 | cliente y servidor; URL, método, cabeceras y cuerpo; códigos de estado; observar tráfico real | ⏳ | ⏳ | ⏳ |
| ⏳ 9.2 HTML y CSS esenciales | 21 | estructura de un documento; formularios; selectores y caja; lo justo para entender una página | ⏳ | ⏳ | ⏳ |
| ⏳ 9.3 JavaScript esencial y consumo de una API | 21 | variables y funciones; el DOM; fetch y JSON; consola del navegador | ⏳ | ⏳ | ⏳ |
| ⏳ 9.4 ASP.NET Core: primer endpoint, rutas y controladores | 21 | estructura de un proyecto web; endpoints; enrutamiento; controladores | ⏳ | ⏳ | ⏳ |
| ⏳ 9.5 APIs REST: verbos, códigos de estado y JSON | 21 | recursos y rutas; GET, POST, PUT, PATCH y DELETE; códigos de estado correctos; serialización JSON | ⏳ | ⏳ | ⏳ |
| ⏳ 9.6 DTOs, validaciones y manejo de errores | 22 | modelos de dominio frente a DTOs; validación de entrada; respuestas de error consistentes; ProblemDetails | ⏳ | ⏳ | ⏳ |
| ⏳ 9.7 Acceso a datos desde una API | 22 | EF Core en una API; inyección del DbContext; paginación y filtros; async de extremo a extremo | ⏳ | ⏳ | ⏳ |
| ⏳ 9.8 Contraseñas y autenticación | 22 | hash con sal; registro e inicio de sesión; tokens JWT; qué nunca hacer | ⏳ | ⏳ | ⏳ |
| ⏳ 9.9 Autorización | 22 | roles y políticas; proteger endpoints; autorización a nivel de recurso; pruebas de acceso denegado | ⏳ | ⏳ | ⏳ |
| ⏳ 9.10 Configuración, secretos y variables de entorno | 22 | appsettings; entornos; User Secrets; variables de entorno en producción | ⏳ | ⏳ | ⏳ |
| ⏳ 9.11 Documentación y pruebas de APIs | 23 | OpenAPI; pruebas manuales con herramientas; pruebas automáticas de endpoints; colecciones de peticiones | ⏳ | ⏳ | ⏳ |
| ⏳ 9.12 Publicación de una aplicación | 23 | publicar y empaquetar; configuración por entorno; plataforma de alojamiento; lista de verificación previa | ⏳ | ⏳ | ⏳ |

## Módulo 10 · Proyectos integradores

Seis proyectos de dificultad creciente que integran lo aprendido. Las especificaciones están en proyectos/; este módulo no tiene lecciones propias.

Programa del módulo: [M10-proyectos-integradores/README.md](modulos/M10-proyectos-integradores/README.md)

Este módulo se desarrolla mediante proyectos: ver [proyectos/README.md](proyectos/README.md).

| Proyecto | Semana de entrega | Especificación |
|---|---|---|
| P1 · Colección de programas de consola | 4 | ✅ disponible |
| P2 · Aplicación de gestión de registros | 9 | ✅ disponible |
| P3 · Aplicación conectada a SQL Server | 17 | ✅ disponible |
| P4 · Aplicación estructurada con responsabilidades separadas | 20 | ✅ disponible |
| P5 · API web con persistencia de datos | 23 | ✅ disponible |
| P6 · Proyecto final original de portafolio | 26 | ✅ disponible |

## Módulo 11 · Preparación para el mundo laboral

Expectativas de un junior, ofertas, CV y GitHub honestos, defensa de decisiones, preguntas frecuentes, entrevistas, pruebas con tiempo y búsqueda de oportunidades.

Programa del módulo: [M11-preparacion-laboral/README.md](modulos/M11-preparacion-laboral/README.md)

| Unidad | Sem. | Temas | Lección | Retos | Soluciones |
|---|---|---|---|---|---|
| ⏳ 11.1 Qué se espera de un desarrollador junior y cómo leer ofertas | 24 | expectativas reales; anatomía de una oferta; requisitos obligatorios y deseables; contrastar con mis competencias | ⏳ | ⏳ | ⏳ |
| ⏳ 11.2 CV técnico honesto y GitHub profesional | 24 | estructura de un CV técnico; describir proyectos con resultados; organizar repositorios; perfil y README de perfil | ⏳ | ⏳ | ⏳ |
| ⏳ 11.3 Describir y defender decisiones técnicas | 25 | problema, alternativas y decisión; compromisos (trade-offs); explicar fallos y aprendizajes; preguntas de defensa | ⏳ | ⏳ | ⏳ |
| ⏳ 11.4 Preguntas frecuentes de C#, SQL, algoritmos y APIs | 26 | C# y .NET; SQL Server; algoritmos y estructuras; APIs y web | ⏳ | ⏳ | ⏳ |
| ⏳ 11.5 Entrevistas técnicas y simulacros | 26 | formato de una entrevista técnica; pensar en voz alta; simulacros; retroalimentación | ⏳ | ⏳ | ⏳ |
| ⏳ 11.6 Pruebas técnicas con tiempo limitado | 27 | gestionar el tiempo; priorizar requisitos; entregar algo que funcione; revisión final | ⏳ | ⏳ | ⏳ |
| ⏳ 11.7 Buscar oportunidades e identificar lagunas | 28 | prácticas y puestos junior; candidatura útil; análisis de lagunas; plan de estudio siguiente | ⏳ | ⏳ | ⏳ |

**Resumen de construcción:** 5 de 103 lecciones disponibles.
