/* =====================================================================
   PARCHE 07: QUITAR "Unión libre" DEL ESTADO CIVIL
   Para una base que YA existe. Si instalas BaseDeDatos_Completa.sql nuevo no hace falta.

   El combo de Estado civil ya no ofrece "Unión libre" (solo Soltero/a, Casado/a,
   Divorciado/a y Viudo/a). Este parche pasa a "Casado/a" a los empleados de ejemplo que
   la tenian, para que su ficha se abra con un valor valido.
   Se puede ejecutar varias veces. Ejecutalo con SSMS (F5).
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

UPDATE dbo.Empleados SET EstadoCivil = N'Casado/a' WHERE EstadoCivil = N'Unión libre';
PRINT CONCAT(N'Empleados actualizados: ', @@ROWCOUNT);
GO

EXEC sys.sp_set_session_context @key = N'Usuario', @value = NULL;
GO
SET NOEXEC OFF;
GO
