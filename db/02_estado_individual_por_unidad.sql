/* =====================================================================
   MIGRACION: estado INDIVIDUAL por unidad física (SQL Server)
   Base: Gestion_administrativa_y_escolar  (corre DESPUES de advincula.sql)

   Problema: GestionActivos.IdEstado (y SalonClases.IdEstado) aplicaban UN
   estado a todas las unidades de un mismo tipo (100 pupitres = 1 estado).

   Solución: GestionActivos pasa a ser solo CATALOGO (tipo de activo) y
   cada unidad física es una fila en dbo.UnidadesActivo con su propio
   estado, código de inventario y ubicación.

   - Idempotente: se puede correr más de una vez.
   - NO borra nada: SalonClases, EquiposIndividualesSalon y
     GestionActivos.IdEstado quedan intactos (obsoletos) hasta que
     verifiques; al final hay una sección opcional para eliminarlos.
   - HAZ UN RESPALDO ANTES:  BACKUP DATABASE Gestion_administrativa_y_escolar
                             TO DISK = 'C:\respaldo\antes_unidades.bak';
   ===================================================================== */
USE Gestion_administrativa_y_escolar;
GO

/* ---------------------------------------------------------------
   1. Tabla de unidades individuales
   --------------------------------------------------------------- */
IF OBJECT_ID('dbo.UnidadesActivo', 'U') IS NULL
CREATE TABLE dbo.UnidadesActivo (
    IdUnidad         INT IDENTITY(1,1) CONSTRAINT PK_UnidadesActivo PRIMARY KEY,
    IdActivo         INT NOT NULL
        CONSTRAINT FK_UnidadesActivo_Activo  FOREIGN KEY REFERENCES dbo.GestionActivos(IdActivo) ON DELETE CASCADE,
    IdSalon          INT NOT NULL
        CONSTRAINT FK_UnidadesActivo_Salon   FOREIGN KEY REFERENCES dbo.Salones(IdSalon),
    CodigoInventario VARCHAR(50) NULL,
    IdEstado         INT NOT NULL
        CONSTRAINT FK_UnidadesActivo_Estado  FOREIGN KEY REFERENCES dbo.Estados(IdEstado),
    FechaAlta        DATETIME NOT NULL CONSTRAINT DF_UnidadesActivo_Alta DEFAULT GETDATE(),
    Observacion      VARCHAR(300) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'UX_UnidadesActivo_Codigo'
               AND object_id = OBJECT_ID('dbo.UnidadesActivo'))
    CREATE UNIQUE INDEX UX_UnidadesActivo_Codigo
    ON dbo.UnidadesActivo (CodigoInventario) WHERE CodigoInventario IS NOT NULL;
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_UnidadesActivo_SalonActivo'
               AND object_id = OBJECT_ID('dbo.UnidadesActivo'))
    CREATE INDEX IX_UnidadesActivo_SalonActivo ON dbo.UnidadesActivo (IdSalon, IdActivo) INCLUDE (IdEstado);
GO

/* ---------------------------------------------------------------
   2. Migración de datos (solo si la tabla está vacía => idempotente)
   --------------------------------------------------------------- */
IF NOT EXISTS (SELECT 1 FROM dbo.UnidadesActivo)
BEGIN
    BEGIN TRANSACTION;

    -- 2a. Equipos que ya eran individuales: conservan su código y estado
    INSERT INTO dbo.UnidadesActivo (IdActivo, IdSalon, CodigoInventario, IdEstado)
    SELECT IdActivo, IdSalon, CodigoInventario, IdEstado
    FROM dbo.EquiposIndividualesSalon;

    -- 2b. Cantidades globales: una fila por cada unidad.
    --     Estado inicial = el que tenía el tipo de activo (GestionActivos.IdEstado),
    --     que es el que veía el sistema; a partir de aquí cada unidad cambia sola.
    ;WITH Nums AS (
        SELECT TOP (SELECT ISNULL(MAX(Cantidad), 0) FROM dbo.SalonClases)
               ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS n
        FROM sys.all_objects a CROSS JOIN sys.all_objects b
    )
    INSERT INTO dbo.UnidadesActivo (IdActivo, IdSalon, CodigoInventario, IdEstado)
    SELECT sc.IdActivo, sc.IdSalon, NULL, ISNULL(a.IdEstado, sc.IdEstado)
    FROM dbo.SalonClases sc
    JOIN dbo.GestionActivos a ON a.IdActivo = sc.IdActivo
    JOIN Nums ON Nums.n <= sc.Cantidad;

    -- 2c. Código de inventario a las unidades que no lo tienen: ACT-0001-001, ACT-0001-002...
    ;WITH Sin AS (
        SELECT u.IdUnidad, u.IdActivo,
               ROW_NUMBER() OVER (PARTITION BY u.IdActivo ORDER BY u.IdUnidad) AS seq
        FROM dbo.UnidadesActivo u
        WHERE u.CodigoInventario IS NULL
    )
    UPDATE u
    SET CodigoInventario = 'ACT-' + RIGHT('0000' + CAST(u.IdActivo AS VARCHAR(10)), 4)
                         + '-'   + RIGHT('000'  + CAST(s.seq      AS VARCHAR(10)), 3)
    FROM dbo.UnidadesActivo u
    JOIN Sin s ON s.IdUnidad = u.IdUnidad;

    COMMIT TRANSACTION;
END
GO

/* ---------------------------------------------------------------
   3. Auditoría por unidad (reemplaza el estado en AuditoriaActivos)
   --------------------------------------------------------------- */
IF OBJECT_ID('dbo.AuditoriaUnidades', 'U') IS NULL
CREATE TABLE dbo.AuditoriaUnidades (
    IdAuditoria    INT IDENTITY(1,1) PRIMARY KEY,
    IdUnidad       INT NULL,
    IdActivo       INT NULL,
    CodigoInventario VARCHAR(50) NULL,
    Accion         VARCHAR(10),
    EstadoAnterior INT NULL,
    EstadoNuevo    INT NULL,
    SalonAnterior  INT NULL,
    SalonNuevo     INT NULL,
    Usuario        SYSNAME  DEFAULT SUSER_SNAME(),
    Fecha          DATETIME DEFAULT GETDATE()
);
GO

CREATE OR ALTER TRIGGER dbo.trg_AuditoriaUnidades
ON dbo.UnidadesActivo
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.AuditoriaUnidades (IdUnidad, IdActivo, CodigoInventario, Accion, EstadoNuevo, SalonNuevo)
    SELECT i.IdUnidad, i.IdActivo, i.CodigoInventario, 'INSERT', i.IdEstado, i.IdSalon
    FROM inserted i
    WHERE NOT EXISTS (SELECT 1 FROM deleted);

    INSERT INTO dbo.AuditoriaUnidades (IdUnidad, IdActivo, CodigoInventario, Accion,
                                       EstadoAnterior, EstadoNuevo, SalonAnterior, SalonNuevo)
    SELECT i.IdUnidad, i.IdActivo, i.CodigoInventario, 'UPDATE',
           d.IdEstado, i.IdEstado, d.IdSalon, i.IdSalon
    FROM inserted i
    JOIN deleted d ON d.IdUnidad = i.IdUnidad
    WHERE d.IdEstado <> i.IdEstado OR d.IdSalon <> i.IdSalon;   -- solo cambios relevantes

    INSERT INTO dbo.AuditoriaUnidades (IdUnidad, IdActivo, CodigoInventario, Accion, EstadoAnterior, SalonAnterior)
    SELECT d.IdUnidad, d.IdActivo, d.CodigoInventario, 'DELETE', d.IdEstado, d.IdSalon
    FROM deleted d
    WHERE NOT EXISTS (SELECT 1 FROM inserted);
END;
GO

/* ---------------------------------------------------------------
   4. Enlazar préstamos / mantenimientos / reportes a la unidad
   --------------------------------------------------------------- */
IF COL_LENGTH('dbo.Prestamos', 'IdUnidad') IS NULL
    ALTER TABLE dbo.Prestamos ADD IdUnidad INT NULL
        CONSTRAINT FK_Prestamos_Unidad FOREIGN KEY REFERENCES dbo.UnidadesActivo(IdUnidad);
IF COL_LENGTH('dbo.MantenimientosActivo', 'IdUnidad') IS NULL
    ALTER TABLE dbo.MantenimientosActivo ADD IdUnidad INT NULL
        CONSTRAINT FK_Mant_Unidad FOREIGN KEY REFERENCES dbo.UnidadesActivo(IdUnidad);
IF COL_LENGTH('dbo.ReportesDanio', 'IdUnidad') IS NULL
    ALTER TABLE dbo.ReportesDanio ADD IdUnidad INT NULL
        CONSTRAINT FK_ReportesDanio_Unidad FOREIGN KEY REFERENCES dbo.UnidadesActivo(IdUnidad);
GO

-- Historial: solo se puede enlazar donde había código de inventario.
-- Los registros viejos sin código (mobiliario por cantidad) quedan con IdUnidad = NULL.
UPDATE p SET p.IdUnidad = u.IdUnidad
FROM dbo.Prestamos p
JOIN dbo.UnidadesActivo u ON u.IdActivo = p.IdActivo AND u.CodigoInventario = p.CodigoInventario
WHERE p.IdUnidad IS NULL AND p.CodigoInventario IS NOT NULL;

UPDATE m SET m.IdUnidad = u.IdUnidad
FROM dbo.MantenimientosActivo m
JOIN dbo.UnidadesActivo u ON u.IdActivo = m.IdActivo AND u.CodigoInventario = m.CodigoInventario
WHERE m.IdUnidad IS NULL AND m.CodigoInventario IS NOT NULL;

UPDATE r SET r.IdUnidad = u.IdUnidad
FROM dbo.ReportesDanio r
JOIN dbo.UnidadesActivo u ON u.IdActivo = r.IdActivo AND u.CodigoInventario = r.CodigoInventario
WHERE r.IdUnidad IS NULL AND r.CodigoInventario IS NOT NULL;
GO

-- Una unidad no puede tener dos préstamos activos / dos reportes abiertos
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'UX_Prestamos_UnidadActiva' AND object_id = OBJECT_ID('dbo.Prestamos'))
    CREATE UNIQUE INDEX UX_Prestamos_UnidadActiva ON dbo.Prestamos (IdUnidad)
    WHERE Estado = 'Activo' AND IdUnidad IS NOT NULL;
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'UX_ReportesDanio_UnidadAbierta' AND object_id = OBJECT_ID('dbo.ReportesDanio'))
    CREATE UNIQUE INDEX UX_ReportesDanio_UnidadAbierta ON dbo.ReportesDanio (IdUnidad)
    WHERE Estado = 'Abierto' AND IdUnidad IS NOT NULL;
GO

/* ---------------------------------------------------------------
   5. Vistas
   --------------------------------------------------------------- */
-- Detalle individual: una fila por unidad con SU estado
CREATE OR ALTER VIEW dbo.vw_UnidadesDetalle AS
SELECT u.IdUnidad, u.CodigoInventario,
       u.IdActivo, a.Nombre AS Activo,
       a.IdCategoria, cat.NombreCategoria AS Categoria,
       u.IdSalon, s.NombreSalon AS Ubicacion,
       u.IdEstado, e.NombreEstado AS Estado,
       u.FechaAlta, u.Observacion
FROM dbo.UnidadesActivo u
JOIN dbo.GestionActivos a    ON a.IdActivo     = u.IdActivo
JOIN dbo.Salones s           ON s.IdSalon      = u.IdSalon
JOIN dbo.Estados e           ON e.IdEstado     = u.IdEstado
LEFT JOIN dbo.Categorias cat ON cat.IdCategoria = a.IdCategoria;
GO

-- Catálogo con totales (ya no hay un estado único por tipo)
CREATE OR ALTER VIEW dbo.vw_ActivosDetalle AS
SELECT a.IdActivo, a.Nombre,
       a.IdCategoria, cat.NombreCategoria AS Categoria,
       a.CodigoInventario, a.IdUbicacion, s.NombreSalon AS Ubicacion,
       COUNT(u.IdUnidad) AS TotalUnidades,
       SUM(CASE WHEN es.NombreEstado IN ('Malo','En reparación','Mantenimiento Pendiente','Dado de baja')
                THEN 1 ELSE 0 END) AS UnidadesConProblema
FROM dbo.GestionActivos a
LEFT JOIN dbo.Categorias cat ON cat.IdCategoria = a.IdCategoria
LEFT JOIN dbo.Salones s      ON s.IdSalon       = a.IdUbicacion
LEFT JOIN dbo.UnidadesActivo u ON u.IdActivo    = a.IdActivo
LEFT JOIN dbo.Estados es     ON es.IdEstado     = u.IdEstado
GROUP BY a.IdActivo, a.Nombre, a.IdCategoria, cat.NombreCategoria,
         a.CodigoInventario, a.IdUbicacion, s.NombreSalon;
GO

-- Misma forma que antes: con serial = una fila por equipo; sin serial = agrupado por cantidad.
-- Se agrega Estado/IdEstado (en agrupados, NULL => usar vw_UnidadesDetalle o vw_ResumenEstadoPorSalon).
CREATE OR ALTER VIEW dbo.vw_ActivosPorSalon AS
SELECT u.IdSalon, s.NombreSalon, a.IdActivo, a.Nombre AS NombreActivo,
       cat.NombreCategoria AS Categoria,
       COUNT(*) AS Cantidad,
       CAST(NULL AS VARCHAR(50)) AS CodigoInventario
FROM dbo.UnidadesActivo u
JOIN dbo.Salones s          ON s.IdSalon  = u.IdSalon
JOIN dbo.GestionActivos a   ON a.IdActivo = u.IdActivo
LEFT JOIN dbo.Categorias cat ON cat.IdCategoria = a.IdCategoria
WHERE ISNULL(cat.RequiereSerial, 0) = 0
GROUP BY u.IdSalon, s.NombreSalon, a.IdActivo, a.Nombre, cat.NombreCategoria
UNION ALL
SELECT u.IdSalon, s.NombreSalon, a.IdActivo, a.Nombre, cat.NombreCategoria,
       1, u.CodigoInventario
FROM dbo.UnidadesActivo u
JOIN dbo.Salones s          ON s.IdSalon  = u.IdSalon
JOIN dbo.GestionActivos a   ON a.IdActivo = u.IdActivo
LEFT JOIN dbo.Categorias cat ON cat.IdCategoria = a.IdCategoria
WHERE cat.RequiereSerial = 1;
GO

-- Cuántas unidades hay en cada estado, por salón y tipo (para mobiliario por cantidad)
CREATE OR ALTER VIEW dbo.vw_ResumenEstadoPorSalon AS
SELECT u.IdSalon, s.NombreSalon, a.IdActivo, a.Nombre AS Activo,
       e.IdEstado, e.NombreEstado AS Estado, COUNT(*) AS Unidades
FROM dbo.UnidadesActivo u
JOIN dbo.Salones s        ON s.IdSalon  = u.IdSalon
JOIN dbo.GestionActivos a ON a.IdActivo = u.IdActivo
JOIN dbo.Estados e        ON e.IdEstado = u.IdEstado
GROUP BY u.IdSalon, s.NombreSalon, a.IdActivo, a.Nombre, e.IdEstado, e.NombreEstado;
GO

CREATE OR ALTER VIEW dbo.vw_ResumenActivosPorEstado AS
SELECT e.NombreEstado, COUNT(u.IdUnidad) AS TotalActivos
FROM dbo.Estados e
LEFT JOIN dbo.UnidadesActivo u ON u.IdEstado = e.IdEstado
GROUP BY e.NombreEstado;
GO

CREATE OR ALTER VIEW dbo.vw_ResumenActivosPorCategoria AS
SELECT cat.NombreCategoria,
       COUNT(DISTINCT a.IdActivo) AS TiposDeActivo,
       COUNT(u.IdUnidad)          AS UnidadesAsignadas
FROM dbo.Categorias cat
LEFT JOIN dbo.GestionActivos a ON a.IdCategoria = cat.IdCategoria
LEFT JOIN dbo.UnidadesActivo u ON u.IdActivo    = a.IdActivo
GROUP BY cat.NombreCategoria;
GO

CREATE OR ALTER VIEW dbo.vw_AuditoriaUnidadesDetalle AS
SELECT a.IdAuditoria, a.Fecha, a.Accion, a.IdUnidad, a.IdActivo, a.CodigoInventario,
       g.Nombre AS Activo,
       ea.NombreEstado AS EstadoAnterior, en.NombreEstado AS EstadoNuevo,
       sa.NombreSalon  AS SalonAnterior,  sn.NombreSalon  AS SalonNuevo,
       a.Usuario
FROM dbo.AuditoriaUnidades a
LEFT JOIN dbo.GestionActivos g ON g.IdActivo = a.IdActivo
LEFT JOIN dbo.Estados ea ON ea.IdEstado = a.EstadoAnterior
LEFT JOIN dbo.Estados en ON en.IdEstado = a.EstadoNuevo
LEFT JOIN dbo.Salones sa ON sa.IdSalon  = a.SalonAnterior
LEFT JOIN dbo.Salones sn ON sn.IdSalon  = a.SalonNuevo;
GO

CREATE OR ALTER VIEW dbo.vw_ReportesDanio AS
SELECT r.IdReporte, r.IdSalon, s.NombreSalon AS Salon,
       r.IdActivo, a.Nombre AS Activo, c.NombreCategoria AS Categoria,
       r.IdUnidad, r.CodigoInventario, r.Cantidad, r.Prioridad, r.Descripcion,
       r.ReportadoPor, r.FechaReporte, r.Estado,
       r.FechaReparacion, r.ReparadoPor, r.ObservacionReparacion
FROM dbo.ReportesDanio r
JOIN dbo.Salones s         ON s.IdSalon  = r.IdSalon
JOIN dbo.GestionActivos a  ON a.IdActivo = r.IdActivo
LEFT JOIN dbo.Categorias c ON c.IdCategoria = a.IdCategoria;
GO

CREATE OR ALTER VIEW dbo.vw_Prestamos AS
SELECT p.IdPrestamo, p.IdActivo, a.Nombre AS Activo, p.IdUnidad, p.CodigoInventario, p.Cantidad,
       p.TipoResponsable, p.Responsable,
       p.IdSalonDestino, s.NombreSalon AS AulaDestino,
       p.FechaEntrega, p.FechaLimite, p.Estado, p.FechaDevolucion,
       es.NombreEstado AS EstadoDevolucion,
       p.ObservacionSalida, p.ObservacionDevolucion, p.EntregadoPor,
       CASE WHEN p.Estado = 'Devuelto'                      THEN 'Devuelto'
            WHEN p.FechaLimite < GETDATE()                  THEN 'Atrasado'
            WHEN p.FechaLimite < DATEADD(DAY, 2, GETDATE()) THEN 'Por vencer'
            ELSE 'En curso' END AS Alerta
FROM dbo.Prestamos p
JOIN dbo.GestionActivos a ON a.IdActivo  = p.IdActivo
LEFT JOIN dbo.Salones s   ON s.IdSalon   = p.IdSalonDestino
LEFT JOIN dbo.Estados es  ON es.IdEstado = p.IdEstadoDevolucion;
GO

CREATE OR ALTER VIEW dbo.vw_Mantenimientos AS
SELECT m.IdMantenimiento, m.Fecha, m.IdActivo, a.Nombre AS Activo, m.IdUnidad, m.CodigoInventario,
       m.Tipo, m.Descripcion, m.Costo, e.NombreEstado AS EstadoResultante,
       m.IdReporte, m.RealizadoPor
FROM dbo.MantenimientosActivo m
JOIN dbo.GestionActivos a ON a.IdActivo = m.IdActivo
JOIN dbo.Estados e        ON e.IdEstado = m.IdEstadoResultante;
GO

/* ---------------------------------------------------------------
   6. Procedimientos: ahora operan sobre UNA unidad (@IdUnidad)
   --------------------------------------------------------------- */
-- Cambiar el estado de una sola unidad
CREATE OR ALTER PROCEDURE dbo.sp_CambiarEstadoUnidad
    @IdUnidad INT, @IdEstado INT
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM dbo.Estados WHERE IdEstado = @IdEstado)
        THROW 50060, 'El estado seleccionado no es válido.', 1;
    UPDATE dbo.UnidadesActivo SET IdEstado = @IdEstado WHERE IdUnidad = @IdUnidad;
    IF @@ROWCOUNT = 0
        THROW 50061, 'La unidad no existe.', 1;
END;
GO

-- Alta de N unidades de un tipo en un salón, cada una con su estado y código
CREATE OR ALTER PROCEDURE dbo.sp_AgregarUnidades
    @IdActivo INT, @IdSalon INT, @Cantidad INT, @IdEstado INT
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;
    IF @Cantidad IS NULL OR @Cantidad <= 0
        THROW 50062, 'La cantidad debe ser mayor que cero.', 1;

    BEGIN TRANSACTION;
    DECLARE @base INT = (SELECT COUNT(*) FROM dbo.UnidadesActivo WITH (UPDLOCK, HOLDLOCK) WHERE IdActivo = @IdActivo);
    -- el siguiente consecutivo no debe chocar con códigos ya usados
    WHILE EXISTS (SELECT 1 FROM dbo.UnidadesActivo
                  WHERE CodigoInventario = 'ACT-' + RIGHT('0000' + CAST(@IdActivo AS VARCHAR(10)), 4)
                                         + '-'   + RIGHT('000'  + CAST(@base + 1 AS VARCHAR(10)), 3))
        SET @base += 1;

    ;WITH Nums AS (
        SELECT TOP (@Cantidad) ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS n
        FROM sys.all_objects a CROSS JOIN sys.all_objects b
    )
    INSERT INTO dbo.UnidadesActivo (IdActivo, IdSalon, CodigoInventario, IdEstado)
    SELECT @IdActivo, @IdSalon,
           'ACT-' + RIGHT('0000' + CAST(@IdActivo AS VARCHAR(10)), 4)
                  + '-' + RIGHT('000' + CAST(@base + n AS VARCHAR(10)), 3),
           @IdEstado
    FROM Nums;
    COMMIT TRANSACTION;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_RegistrarPrestamo
    @IdUnidad INT, @TipoResponsable VARCHAR(30), @Responsable VARCHAR(100),
    @IdSalonDestino INT = NULL, @FechaLimite DATETIME,
    @Observacion VARCHAR(300) = NULL, @EntregadoPor VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;
    BEGIN TRY
        IF LEN(LTRIM(RTRIM(ISNULL(@Responsable, '')))) = 0
            THROW 50031, 'El responsable es obligatorio.', 1;
        IF @FechaLimite <= GETDATE()
            THROW 50032, 'La fecha límite debe ser posterior a la fecha de entrega.', 1;

        DECLARE @IdActivo INT, @Codigo VARCHAR(50), @Estado VARCHAR(200);
        SELECT @IdActivo = u.IdActivo, @Codigo = u.CodigoInventario, @Estado = e.NombreEstado
        FROM dbo.UnidadesActivo u JOIN dbo.Estados e ON e.IdEstado = u.IdEstado
        WHERE u.IdUnidad = @IdUnidad;
        IF @@ROWCOUNT = 0
            THROW 50033, 'La unidad no existe.', 1;
        IF @Estado IN ('Dado de baja', 'En reparación', 'Malo', 'Mantenimiento Pendiente')
            THROW 50034, 'No se puede prestar una unidad en mal estado, en reparación o dada de baja.', 1;
        IF EXISTS (SELECT 1 FROM dbo.Prestamos WHERE IdUnidad = @IdUnidad AND Estado = 'Activo')
            THROW 50035, 'Esa unidad ya está prestada y no ha sido devuelta.', 1;

        INSERT INTO dbo.Prestamos
            (IdActivo, IdUnidad, CodigoInventario, Cantidad, TipoResponsable, Responsable,
             IdSalonDestino, FechaLimite, ObservacionSalida, EntregadoPor)
        VALUES
            (@IdActivo, @IdUnidad, @Codigo, 1, @TipoResponsable, LTRIM(RTRIM(@Responsable)),
             @IdSalonDestino, @FechaLimite, @Observacion, @EntregadoPor);
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO

-- Devolución: cierra el préstamo y actualiza SOLO el estado de esa unidad
CREATE OR ALTER PROCEDURE dbo.sp_RegistrarDevolucion
    @IdPrestamo INT, @IdEstadoDevolucion INT, @Observacion VARCHAR(300) = NULL
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;
    BEGIN TRY
        IF NOT EXISTS (SELECT 1 FROM dbo.Estados WHERE IdEstado = @IdEstadoDevolucion)
            THROW 50036, 'El estado seleccionado no es válido.', 1;

        BEGIN TRANSACTION;
        DECLARE @IdUnidad INT, @Encontrado BIT = 0;
        SELECT @IdUnidad = IdUnidad, @Encontrado = 1 FROM dbo.Prestamos WITH (UPDLOCK)
        WHERE IdPrestamo = @IdPrestamo AND Estado = 'Activo';
        IF @Encontrado = 0
            THROW 50037, 'El préstamo no existe o ya fue devuelto.', 1;

        UPDATE dbo.Prestamos
        SET Estado = 'Devuelto', FechaDevolucion = GETDATE(),
            IdEstadoDevolucion = @IdEstadoDevolucion, ObservacionDevolucion = @Observacion
        WHERE IdPrestamo = @IdPrestamo;

        -- préstamos antiguos sin unidad (mobiliario por cantidad) ya no tocan ningún estado global
        IF @IdUnidad IS NOT NULL
            UPDATE dbo.UnidadesActivo SET IdEstado = @IdEstadoDevolucion WHERE IdUnidad = @IdUnidad;
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- Mantenimiento: cambia el estado de la unidad atendida y cierra el reporte (si hay)
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

        DECLARE @IdActivo INT, @Codigo VARCHAR(50);
        SELECT @IdActivo = IdActivo, @Codigo = CodigoInventario
        FROM dbo.UnidadesActivo WHERE IdUnidad = @IdUnidad;
        IF @IdActivo IS NULL
            THROW 50052, 'La unidad no existe.', 1;

        BEGIN TRANSACTION;
        INSERT INTO dbo.MantenimientosActivo
            (IdActivo, IdUnidad, CodigoInventario, Fecha, Tipo, Descripcion, Costo, IdEstadoResultante, IdReporte, RealizadoPor)
        VALUES (@IdActivo, @IdUnidad, @Codigo, @Fecha, @Tipo, LTRIM(RTRIM(@Descripcion)), @Costo,
                @IdEstadoResultante, @IdReporte, @Usuario);

        UPDATE dbo.UnidadesActivo SET IdEstado = @IdEstadoResultante WHERE IdUnidad = @IdUnidad;

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

-- Reinicio: ahora también limpia las unidades y su auditoría
CREATE OR ALTER PROCEDURE dbo.sp_ReiniciarSistema
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        DELETE FROM dbo.MantenimientosActivo;
        DELETE FROM dbo.Prestamos;
        DELETE FROM dbo.MovimientosConsumible;
        DELETE FROM dbo.Consumibles;
        DELETE FROM dbo.ReportesDanio;

        DISABLE TRIGGER trg_AuditoriaUnidades ON dbo.UnidadesActivo;
        DELETE FROM dbo.UnidadesActivo;
        ENABLE TRIGGER trg_AuditoriaUnidades ON dbo.UnidadesActivo;
        DELETE FROM dbo.AuditoriaUnidades;

        DELETE FROM dbo.EquiposIndividualesSalon;
        DELETE FROM dbo.SalonClases;

        DISABLE TRIGGER trg_AuditoriaActivos ON dbo.GestionActivos;
        DELETE FROM dbo.GestionActivos;
        ENABLE TRIGGER trg_AuditoriaActivos ON dbo.GestionActivos;

        DELETE FROM dbo.AuditoriaActivos;
        DELETE FROM dbo.Salones;

        UPDATE dbo.Empleados SET IdPlanilla = NULL;
        DELETE FROM dbo.Planillas;
        DELETE FROM dbo.Empleados;

        DELETE FROM dbo.Usuarios;
        DELETE FROM dbo.ConfiguracionEmpresa;

        DBCC CHECKIDENT ('dbo.MantenimientosActivo', RESEED, 0);
        DBCC CHECKIDENT ('dbo.Prestamos', RESEED, 0);
        DBCC CHECKIDENT ('dbo.MovimientosConsumible', RESEED, 0);
        DBCC CHECKIDENT ('dbo.Consumibles', RESEED, 0);
        DBCC CHECKIDENT ('dbo.ReportesDanio', RESEED, 0);
        DBCC CHECKIDENT ('dbo.UnidadesActivo', RESEED, 0);
        DBCC CHECKIDENT ('dbo.AuditoriaUnidades', RESEED, 0);
        DBCC CHECKIDENT ('dbo.EquiposIndividualesSalon', RESEED, 0);
        DBCC CHECKIDENT ('dbo.AuditoriaActivos', RESEED, 0);
        DBCC CHECKIDENT ('dbo.Empleados', RESEED, 0);
        DBCC CHECKIDENT ('dbo.Planillas', RESEED, 0);
        DBCC CHECKIDENT ('dbo.Usuarios', RESEED, 0);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

/* ---------------------------------------------------------------
   7. Verificación (el total debe coincidir con lo que había)
   --------------------------------------------------------------- */
SELECT (SELECT ISNULL(SUM(Cantidad),0) FROM dbo.SalonClases)
     + (SELECT COUNT(*) FROM dbo.EquiposIndividualesSalon) AS UnidadesEsperadas,
       (SELECT COUNT(*) FROM dbo.UnidadesActivo)           AS UnidadesMigradas;
SELECT TOP 20 * FROM dbo.vw_UnidadesDetalle ORDER BY IdUnidad;
SELECT * FROM dbo.vw_ResumenActivosPorEstado;
GO

-- ---------------------------------------------------------------
--    8. OPCIONAL — limpieza, SOLO cuando tu aplicación ya use UnidadesActivo
--       y hayas comprobado la verificación de arriba. Está comentado a propósito.
--    ---------------------------------------------------------------
-- -- DROP VIEW dbo.vw_ResumenActivosPorSalon;   -- (se recrea: depende de vw_ActivosPorSalon, sigue funcionando; no hace falta borrarla)
-- -- DROP TABLE dbo.SalonClases;
-- -- DROP TABLE dbo.EquiposIndividualesSalon;
-- -- ALTER TABLE dbo.GestionActivos DROP CONSTRAINT <FK hacia Estados>;   -- ver nombre en sys.foreign_keys
-- -- ALTER TABLE dbo.GestionActivos DROP COLUMN IdEstado;                 -- requiere ajustar/eliminar trg_AuditoriaActivos
   --------------------------------------------------------------- 
