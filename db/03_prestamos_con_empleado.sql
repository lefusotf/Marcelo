/* ----------------------------------------------------------------------
   Préstamos vinculados a empleados reales
   - Prestamos.IdEmpleado (FK a Empleados) para Docente y Personal administrativo
   - Alumno sigue siendo texto libre (el sistema no maneja alumnos)
   - vw_Prestamos expone IdEmpleado; sp_RegistrarPrestamo lo valida
   Se puede ejecutar más de una vez sin problema.
   Ejecutar con la base Gestion_administrativa_y_escolar seleccionada.
   ---------------------------------------------------------------------- */
USE Gestion_administrativa_y_escolar;
GO

-- 1) Columna, llave foránea e índice
IF COL_LENGTH('dbo.Prestamos', 'IdEmpleado') IS NULL
    ALTER TABLE dbo.Prestamos ADD IdEmpleado INT NULL;
GO

IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_Prestamos_Empleado')
    ALTER TABLE dbo.Prestamos ADD CONSTRAINT FK_Prestamos_Empleado
        FOREIGN KEY (IdEmpleado) REFERENCES dbo.Empleados (IdEmpleado);

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_Prestamos_Empleado' AND object_id = OBJECT_ID('dbo.Prestamos'))
    CREATE INDEX IX_Prestamos_Empleado ON dbo.Prestamos (IdEmpleado) WHERE IdEmpleado IS NOT NULL;
GO

-- 2) Préstamos que ya existían: se enlazan por nombre exacto (el nombre de empleado es único)
UPDATE p
SET    p.IdEmpleado = e.IdEmpleado
FROM   dbo.Prestamos p
JOIN   dbo.Empleados e ON e.Nombre = p.Responsable
WHERE  p.IdEmpleado IS NULL
  AND  p.TipoResponsable IN ('Docente', 'Personal administrativo');
GO

-- 3) Vista: se agrega IdEmpleado al final (lo demás queda igual)
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
            ELSE 'En curso' END AS Alerta,
       p.IdEmpleado
FROM dbo.Prestamos p
JOIN dbo.GestionActivos a ON a.IdActivo  = p.IdActivo
LEFT JOIN dbo.Salones s   ON s.IdSalon   = p.IdSalonDestino
LEFT JOIN dbo.Estados es  ON es.IdEstado = p.IdEstadoDevolucion;
GO

-- 4) Procedimiento: Docente y Personal administrativo exigen un empleado real y activo
CREATE OR ALTER PROCEDURE dbo.sp_RegistrarPrestamo
    @IdUnidad INT, @TipoResponsable VARCHAR(30), @Responsable VARCHAR(100),
    @IdSalonDestino INT = NULL, @FechaLimite DATETIME,
    @Observacion VARCHAR(300) = NULL, @EntregadoPor VARCHAR(50),
    @IdEmpleado INT = NULL
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;
    BEGIN TRY
        IF @TipoResponsable IN ('Docente', 'Personal administrativo')
        BEGIN
            IF @IdEmpleado IS NULL
                THROW 50950, 'Seleccione al empleado responsable de la lista.', 1;

            DECLARE @NombreEmp VARCHAR(200), @Cargo VARCHAR(100);
            SELECT @NombreEmp = e.Nombre, @Cargo = ISNULL(c.NombreCargo, '')
            FROM dbo.Empleados e
            LEFT JOIN dbo.Cargos c ON c.IdCargo = e.IdCargo
            WHERE e.IdEmpleado = @IdEmpleado AND e.IdEstado <> 2;
            IF @@ROWCOUNT = 0
                THROW 50951, 'El empleado no existe o está dado de baja.', 1;

            IF @TipoResponsable = 'Docente' AND LOWER(@Cargo) NOT LIKE 'docente%'
                THROW 50952, 'El empleado elegido no es docente.', 1;
            IF @TipoResponsable = 'Personal administrativo' AND LOWER(@Cargo) LIKE 'docente%'
                THROW 50953, 'Los docentes se registran con el tipo "Docente".', 1;

            SET @Responsable = LEFT(@NombreEmp, 100);     -- el nombre sale del registro del empleado
        END
        ELSE
            SET @IdEmpleado = NULL;                        -- Alumno: texto libre, sin empleado

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
            (IdActivo, IdUnidad, CodigoInventario, Cantidad, TipoResponsable, Responsable, IdEmpleado,
             IdSalonDestino, FechaLimite, ObservacionSalida, EntregadoPor)
        VALUES
            (@IdActivo, @IdUnidad, @Codigo, 1, @TipoResponsable, LTRIM(RTRIM(@Responsable)), @IdEmpleado,
             @IdSalonDestino, @FechaLimite, @Observacion, @EntregadoPor);
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO
