/* =====================================================================
   PARCHE 05: REGLAS DE BAJA UNIFICADAS
   Para una base que YA existe. Si instalas BaseDeDatos_Completa.sql nuevo no hace
   falta: ya lo incluye.

   Que hace (solo actualiza 4 procedimientos con CREATE OR ALTER; no toca tablas
   ni datos, y se puede ejecutar varias veces):
   - sp_RegistrarMantenimiento y sp_RegistrarDevolucion aplican, al dar de baja,
     las mismas reglas que sp_CambiarEstadoUnidades: motivo de 5 caracteres como
     minimo, no se da de baja una unidad prestada (al devolverla si se puede) y
     una baja no se revierte.
   - La fecha y el motivo de baja se guardan cuando la unidad ENTRA en baja; si ya
     estaba de baja se conservan los originales (antes se sobrescribian).
   - sp_CambiarEstadoUnidad (la version antigua, sin uso en el programa) ahora
     delega en sp_CambiarEstadoUnidades.

   Los mensajes de error salen en pantalla igual que los demas errores del sistema.
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


-- Cambia el estado de varias unidades de un equipo. Valida: estado válido, unidades del equipo, no se da de baja
-- una unidad prestada, no se marca en buen estado una unidad con reporte de daño abierto y una baja no se revierte.
-- Dar de baja exige un motivo (mínimo 5 caracteres). La fecha y el motivo se guardan cuando la unidad entra en baja;
-- si ya estaba de baja se conservan los originales.
CREATE OR ALTER PROCEDURE dbo.sp_CambiarEstadoUnidades
    @IdActivo INT, @IdEstado INT, @Ids VARCHAR(MAX), @Motivo VARCHAR(300) = NULL
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;

    DECLARE @estado VARCHAR(200) = (SELECT NombreEstado FROM dbo.Estados WHERE IdEstado = @IdEstado);
    IF @estado IS NULL
        THROW 50910, 'El estado seleccionado no es válido.', 1;

    DECLARE @sel TABLE (IdUnidad INT PRIMARY KEY);
    INSERT @sel
    SELECT DISTINCT CAST(value AS INT) FROM STRING_SPLIT(@Ids, ',') WHERE LTRIM(RTRIM(value)) <> '';

    IF EXISTS (SELECT 1 FROM @sel s WHERE NOT EXISTS
               (SELECT 1 FROM dbo.UnidadesActivo u WHERE u.IdUnidad = s.IdUnidad AND u.IdActivo = @IdActivo))
        THROW 50911, 'Alguna de las unidades no existe o no pertenece a este activo.', 1;

    IF @estado = 'Dado de baja' AND EXISTS
       (SELECT 1 FROM dbo.Prestamos p JOIN @sel s ON s.IdUnidad = p.IdUnidad WHERE p.Estado = 'Activo')
        THROW 50912, 'No se puede dar de baja una unidad que está prestada. Registre primero su devolución.', 1;

    IF @estado IN ('Nuevo', 'Excelente', 'Bueno') AND EXISTS
       (SELECT 1 FROM dbo.ReportesDanio r JOIN @sel s ON s.IdUnidad = r.IdUnidad WHERE r.Estado = 'Abierto')
        THROW 50913, 'Hay unidades con un reporte de daño abierto. Resuélvalo con un mantenimiento antes de marcarlas en buen estado.', 1;

    IF @estado <> 'Dado de baja' AND EXISTS
       (SELECT 1 FROM dbo.UnidadesActivo u
          JOIN @sel s ON s.IdUnidad = u.IdUnidad
          JOIN dbo.Estados e ON e.IdEstado = u.IdEstado
         WHERE e.NombreEstado = 'Dado de baja')
        THROW 50914, 'Hay unidades dadas de baja: una baja no se revierte desde esta pantalla.', 1;

    IF @estado = 'Dado de baja' AND LEN(LTRIM(RTRIM(ISNULL(@Motivo, '')))) < 5
        THROW 50962, 'Indique el motivo de la baja (mínimo 5 caracteres).', 1;

    -- Fecha y motivo de baja: se escriben cuando la unidad ENTRA en baja; si ya estaba de baja se
    -- conservan los originales (solo se completan si faltaban); en cualquier otro caso no se tocan.
    UPDATE u
    SET    u.IdEstado   = @IdEstado,
           u.FechaBaja  = CASE WHEN @estado <> 'Dado de baja'        THEN u.FechaBaja
                               WHEN ea.NombreEstado = 'Dado de baja' THEN ISNULL(u.FechaBaja, GETDATE())
                               ELSE GETDATE() END,
           u.MotivoBaja = CASE WHEN @estado <> 'Dado de baja'        THEN u.MotivoBaja
                               WHEN ea.NombreEstado = 'Dado de baja' THEN ISNULL(u.MotivoBaja, LEFT(LTRIM(RTRIM(@Motivo)), 300))
                               ELSE LEFT(LTRIM(RTRIM(@Motivo)), 300) END
    FROM   dbo.UnidadesActivo u
    JOIN   @sel s         ON s.IdUnidad  = u.IdUnidad
    JOIN   dbo.Estados ea ON ea.IdEstado = u.IdEstado;
END;
GO

-- Cambia el estado de UNA unidad: delega en sp_CambiarEstadoUnidades (mismas validaciones y mismos errores).
-- @Motivo solo se usa al dar de baja.
CREATE OR ALTER PROCEDURE dbo.sp_CambiarEstadoUnidad
    @IdUnidad INT, @IdEstado INT, @Motivo VARCHAR(300) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @IdActivo INT = (SELECT IdActivo FROM dbo.UnidadesActivo WHERE IdUnidad = @IdUnidad);
    IF @IdActivo IS NULL
        THROW 50061, 'La unidad no existe.', 1;

    -- Delega en sp_CambiarEstadoUnidades: mismas validaciones y mismos errores
    DECLARE @Ids VARCHAR(20) = CAST(@IdUnidad AS VARCHAR(20));
    EXEC dbo.sp_CambiarEstadoUnidades @IdActivo = @IdActivo, @IdEstado = @IdEstado, @Ids = @Ids, @Motivo = @Motivo;
END;
GO

-- Mantenimiento: registra el servicio de una unidad y actualiza su estado; si se indica @IdReporte, cierra ese
-- reporte de daño (error 50051 si ya estaba cerrado). Si el estado resultante es "Dado de baja" aplica las reglas
-- de la baja (unidad no prestada, motivo = descripción de 5 caracteres como mínimo, una baja no se revierte)
-- y guarda la fecha y el motivo.
CREATE OR ALTER PROCEDURE dbo.sp_RegistrarMantenimiento
    @IdUnidad INT, @Fecha DATETIME,
    @Tipo VARCHAR(12), @Descripcion VARCHAR(500), @Costo DECIMAL(10,2),
    @IdEstadoResultante INT, @IdReporte INT = NULL, @Usuario VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;
    BEGIN TRY
        IF LEN(LTRIM(RTRIM(ISNULL(@Descripcion, '')))) = 0
            THROW 50050, 'La descripción del servicio es obligatoria.', 1;

        DECLARE @IdActivo INT, @Codigo VARCHAR(50), @EstadoActual VARCHAR(200);
        SELECT @IdActivo = u.IdActivo, @Codigo = u.CodigoInventario, @EstadoActual = ea.NombreEstado
        FROM dbo.UnidadesActivo u
        JOIN dbo.Estados ea ON ea.IdEstado = u.IdEstado
        WHERE u.IdUnidad = @IdUnidad;
        IF @IdActivo IS NULL
            THROW 50052, 'La unidad no existe.', 1;

        DECLARE @EstadoNuevo VARCHAR(200) = (SELECT NombreEstado FROM dbo.Estados WHERE IdEstado = @IdEstadoResultante);
        IF @EstadoNuevo IS NULL
            THROW 50910, 'El estado seleccionado no es válido.', 1;

        -- Reglas de la baja: las mismas de sp_CambiarEstadoUnidades
        IF @EstadoNuevo = 'Dado de baja' AND @EstadoActual <> 'Dado de baja'
        BEGIN
            IF EXISTS (SELECT 1 FROM dbo.Prestamos WHERE IdUnidad = @IdUnidad AND Estado = 'Activo')
                THROW 50912, 'No se puede dar de baja una unidad que está prestada. Registre primero su devolución.', 1;
            IF LEN(LTRIM(RTRIM(@Descripcion))) < 5
                THROW 50962, 'Indique el motivo de la baja (mínimo 5 caracteres).', 1;
        END
        IF @EstadoActual = 'Dado de baja' AND @EstadoNuevo <> 'Dado de baja'
            THROW 50914, 'La unidad está dada de baja: una baja no se revierte.', 1;

        BEGIN TRANSACTION;
        INSERT INTO dbo.MantenimientosActivo
            (IdActivo, IdUnidad, CodigoInventario, Fecha, Tipo, Descripcion, Costo, IdEstadoResultante, IdReporte, RealizadoPor)
        VALUES (@IdActivo, @IdUnidad, @Codigo, @Fecha, @Tipo, LTRIM(RTRIM(@Descripcion)), @Costo,
                @IdEstadoResultante, @IdReporte, @Usuario);

        -- Fecha y motivo de baja: se escriben cuando la unidad ENTRA en baja (el motivo es la descripción);
        -- si ya estaba de baja se conservan los originales; en cualquier otro caso no se tocan.
        UPDATE dbo.UnidadesActivo
        SET    IdEstado   = @IdEstadoResultante,
               FechaBaja  = CASE WHEN @EstadoNuevo <> 'Dado de baja'  THEN FechaBaja
                                 WHEN @EstadoActual = 'Dado de baja'  THEN ISNULL(FechaBaja, GETDATE())
                                 ELSE GETDATE() END,
               MotivoBaja = CASE WHEN @EstadoNuevo <> 'Dado de baja'  THEN MotivoBaja
                                 WHEN @EstadoActual = 'Dado de baja'  THEN ISNULL(MotivoBaja, LEFT(LTRIM(RTRIM(@Descripcion)), 300))
                                 ELSE LEFT(LTRIM(RTRIM(@Descripcion)), 300) END
        WHERE  IdUnidad = @IdUnidad;

        IF @IdReporte IS NOT NULL
        BEGIN
            UPDATE dbo.ReportesDanio
            SET Estado = 'Reparado', FechaReparacion = GETDATE(), ReparadoPor = @Usuario,
                ObservacionReparacion = LEFT(@Descripcion, 500)
            WHERE IdReporte = @IdReporte AND Estado = 'Abierto';
            IF @@ROWCOUNT = 0
                THROW 50051, 'El reporte de daño ya estaba cerrado.', 1;
        END
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- Devolución: cierra el préstamo y actualiza SOLO el estado de esa unidad. Si la unidad vuelve "Dado de baja" exige
-- un motivo en las observaciones (mínimo 5 caracteres) y guarda fecha y motivo; una unidad que ya está de baja
-- no puede volver a otro estado.
CREATE OR ALTER PROCEDURE dbo.sp_RegistrarDevolucion
    @IdPrestamo INT, @IdEstadoDevolucion INT, @Observacion VARCHAR(300) = NULL
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;
    BEGIN TRY
        DECLARE @EstadoNuevo VARCHAR(200) = (SELECT NombreEstado FROM dbo.Estados WHERE IdEstado = @IdEstadoDevolucion);
        IF @EstadoNuevo IS NULL
            THROW 50036, 'El estado seleccionado no es válido.', 1;

        BEGIN TRANSACTION;
        DECLARE @IdUnidad INT, @Encontrado BIT = 0;
        SELECT @IdUnidad = IdUnidad, @Encontrado = 1 FROM dbo.Prestamos WITH (UPDLOCK)
        WHERE IdPrestamo = @IdPrestamo AND Estado = 'Activo';
        IF @Encontrado = 0
            THROW 50037, 'El préstamo no existe o ya fue devuelto.', 1;

        DECLARE @EstadoActual VARCHAR(200) = NULL;
        IF @IdUnidad IS NOT NULL
        BEGIN
            SELECT @EstadoActual = ea.NombreEstado
            FROM dbo.UnidadesActivo u
            JOIN dbo.Estados ea ON ea.IdEstado = u.IdEstado
            WHERE u.IdUnidad = @IdUnidad;

            -- Reglas de la baja: las mismas de sp_CambiarEstadoUnidades (el motivo es la observación)
            IF @EstadoActual = 'Dado de baja' AND @EstadoNuevo <> 'Dado de baja'
                THROW 50914, 'La unidad está dada de baja: una baja no se revierte. Registre la devolución con el estado "Dado de baja".', 1;
            IF @EstadoNuevo = 'Dado de baja' AND @EstadoActual <> 'Dado de baja'
               AND LEN(LTRIM(RTRIM(ISNULL(@Observacion, '')))) < 5
                THROW 50962, 'Indique el motivo de la baja en las observaciones (mínimo 5 caracteres).', 1;
        END

        UPDATE dbo.Prestamos
        SET Estado = 'Devuelto', FechaDevolucion = GETDATE(),
            IdEstadoDevolucion = @IdEstadoDevolucion, ObservacionDevolucion = @Observacion
        WHERE IdPrestamo = @IdPrestamo;

        -- Fecha y motivo de baja: se escriben cuando la unidad ENTRA en baja; si ya estaba de baja se
        -- conservan los originales; en cualquier otro caso no se tocan.
        IF @IdUnidad IS NOT NULL
            UPDATE dbo.UnidadesActivo
            SET    IdEstado   = @IdEstadoDevolucion,
                   FechaBaja  = CASE WHEN @EstadoNuevo <> 'Dado de baja'  THEN FechaBaja
                                     WHEN @EstadoActual = 'Dado de baja'  THEN ISNULL(FechaBaja, GETDATE())
                                     ELSE GETDATE() END,
                   MotivoBaja = CASE WHEN @EstadoNuevo <> 'Dado de baja'  THEN MotivoBaja
                                     WHEN @EstadoActual = 'Dado de baja'  THEN ISNULL(MotivoBaja, LEFT(LTRIM(RTRIM(@Observacion)), 300))
                                     ELSE LEFT(LTRIM(RTRIM(@Observacion)), 300) END
            WHERE  IdUnidad = @IdUnidad;
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

SET NOEXEC OFF;
GO
