/* =====================================================================
   PARCHE 06: UN SOLO CARGO "Docente" + MATERIAS
   Para una base que YA existe y todavia tiene cargos como "Docente de Sistemas".
   Si instalas BaseDeDatos_Completa.sql nuevo no hace falta: ya viene asi.

   Que hace (se puede ejecutar varias veces; no borra empleados ni datos de personal):
   1. Crea el cargo "Docente" si no existe.
   2. Crea una materia por cada cargo "Docente de X" (X = la materia).
   3. Asigna a cada docente la materia que decia su cargo.
   4. Pasa a esos empleados al cargo "Docente".
   5. Borra los cargos "Docente de X" que ya no usa nadie.
   6. Escribe "Natacion" con tilde (Natación) en las materias.
   Los cambios quedan en el historial a nombre de "Script de migración".
   Ejecutalo con SSMS (F5).
   ===================================================================== */
SET QUOTED_IDENTIFIER ON;
SET ANSI_NULLS ON;
SET NOEXEC OFF;
GO

USE Gestion_administrativa_y_escolar;
GO

IF DB_NAME() <> N'Gestion_administrativa_y_escolar'
BEGIN
    PRINT N'*** No existe la base Gestion_administrativa_y_escolar en este servidor. No se ejecutara nada. ***';
    SET NOEXEC ON;
END
GO

EXEC sys.sp_set_session_context @key = N'Usuario', @value = N'Script de migración', @read_only = 0;
GO

-- 1) El cargo nuevo
IF NOT EXISTS (SELECT 1 FROM dbo.Cargos WHERE NombreCargo = 'Docente')
    INSERT INTO dbo.Cargos (NombreCargo) VALUES ('Docente');

-- 2) Una materia por cada cargo "Docente de X" (la materia es lo que va despues de 'Docente de ')
INSERT INTO dbo.Materias (NombreMateria)
SELECT DISTINCT LTRIM(SUBSTRING(c.NombreCargo, 12, 100))
FROM dbo.Cargos c
WHERE c.NombreCargo LIKE 'Docente de %'
  AND NOT EXISTS (SELECT 1 FROM dbo.Materias m
                  WHERE m.NombreMateria = LTRIM(SUBSTRING(c.NombreCargo, 12, 100)));

-- 3) A cada docente se le asigna la materia que decia su cargo
INSERT INTO dbo.EmpleadoMaterias (IdEmpleado, IdMateria)
SELECT e.IdEmpleado, m.IdMateria
FROM dbo.Empleados e
JOIN dbo.Cargos c    ON c.IdCargo = e.IdCargo
JOIN dbo.Materias m  ON m.NombreMateria = LTRIM(SUBSTRING(c.NombreCargo, 12, 100))
WHERE c.NombreCargo LIKE 'Docente de %'
  AND NOT EXISTS (SELECT 1 FROM dbo.EmpleadoMaterias x
                  WHERE x.IdEmpleado = e.IdEmpleado AND x.IdMateria = m.IdMateria);

-- 4) Los empleados pasan al cargo "Docente"
UPDATE e SET e.IdCargo = (SELECT TOP 1 IdCargo FROM dbo.Cargos WHERE NombreCargo = 'Docente')
FROM dbo.Empleados e
JOIN dbo.Cargos c ON c.IdCargo = e.IdCargo
WHERE c.NombreCargo LIKE 'Docente de %';

-- 5) Se eliminan los cargos "Docente de X" que ya no usa nadie
DELETE c
FROM dbo.Cargos c
WHERE c.NombreCargo LIKE 'Docente de %'
  AND NOT EXISTS (SELECT 1 FROM dbo.Empleados e WHERE e.IdCargo = c.IdCargo);

-- 6) Ortografia de una materia que venia sin tilde en el cargo
IF EXISTS (SELECT 1 FROM dbo.Materias WHERE NombreMateria = 'Natacion')
   AND NOT EXISTS (SELECT 1 FROM dbo.Materias WHERE NombreMateria = N'Natación')
    UPDATE dbo.Materias SET NombreMateria = N'Natación' WHERE NombreMateria = 'Natacion';
GO

-- Resultado: no debe quedar ningun cargo "Docente de ..." y cada docente debe tener su materia
SELECT (SELECT COUNT(*) FROM dbo.Cargos WHERE NombreCargo LIKE 'Docente de %') AS CargosDocenteDe_debe_ser_0,
       (SELECT COUNT(*) FROM dbo.Empleados e JOIN dbo.Cargos c ON c.IdCargo = e.IdCargo
        WHERE c.NombreCargo = 'Docente') AS Docentes,
       (SELECT COUNT(DISTINCT IdEmpleado) FROM dbo.EmpleadoMaterias) AS DocentesConMateria,
       (SELECT COUNT(*) FROM dbo.Materias) AS Materias;
GO

EXEC sys.sp_set_session_context @key = N'Usuario', @value = NULL;
SET NOEXEC OFF;
GO
