/* =====================================================================
   INSTALACION LIMPIA  -  Gestion_administrativa_y_escolar
   Estado FINAL de la base de datos, sin historial de cambios.

   SEGURO DE EJECUTAR:
   - No contiene DROP, DELETE ni TRUNCATE de datos.
   - Cada tabla se crea solo si no existe; las vistas, funciones,
     procedimientos y triggers se crean o se actualizan (CREATE OR ALTER).
   - Los datos iniciales se insertan solo si su tabla esta vacia.
   - Se puede ejecutar varias veces sin duplicar nada.

   Requiere SQL Server 2016 SP1 o superior (CREATE OR ALTER).
   La primera vez que se abre el programa, el asistente de configuracion
   crea la empresa y el usuario administrador.
   ===================================================================== */
SET NOCOUNT ON;
GO

IF DB_ID(N'Gestion_administrativa_y_escolar') IS NULL
    CREATE DATABASE Gestion_administrativa_y_escolar;
GO

USE Gestion_administrativa_y_escolar;
GO

/* =====================================================================
   1. CATALOGOS BASICOS
   ===================================================================== */
IF OBJECT_ID('dbo.Roles', 'U') IS NULL
CREATE TABLE dbo.Roles (
    IdRol     INT IDENTITY(1,1) CONSTRAINT PK_Roles PRIMARY KEY,
    NombreRol VARCHAR(50) NOT NULL
);

IF OBJECT_ID('dbo.Estados', 'U') IS NULL
CREATE TABLE dbo.Estados (
    IdEstado     INT IDENTITY(1,1) CONSTRAINT PK_Estados PRIMARY KEY,
    NombreEstado VARCHAR(200)
);

IF OBJECT_ID('dbo.Categorias', 'U') IS NULL
CREATE TABLE dbo.Categorias (
    IdCategoria     INT IDENTITY(1,1) CONSTRAINT PK_Categorias PRIMARY KEY,
    NombreCategoria VARCHAR(100),
    RequiereSerial  BIT CONSTRAINT DF_Categorias_Serial DEFAULT 0
);

IF OBJECT_ID('dbo.Cargos', 'U') IS NULL
CREATE TABLE dbo.Cargos (
    IdCargo     INT IDENTITY(1,1) CONSTRAINT PK_Cargos PRIMARY KEY,
    NombreCargo VARCHAR(100)
);

IF OBJECT_ID('dbo.EstadosEmpleado', 'U') IS NULL
CREATE TABLE dbo.EstadosEmpleado (
    IdEstado     INT IDENTITY(1,1) CONSTRAINT PK_EstadosEmpleado PRIMARY KEY,
    NombreEstado VARCHAR(100)
);
GO

/* =====================================================================
   2. PERSONAL, PLANILLAS Y USUARIOS
   ===================================================================== */
-- Estructuras salariales (catalogo de salarios). Los pagos reales van en PagosPlanilla.
IF OBJECT_ID('dbo.Planillas', 'U') IS NULL
CREATE TABLE dbo.Planillas (
    IdPlanilla  INT IDENTITY(1,1) CONSTRAINT PK_Planillas PRIMARY KEY,
    SalarioBase DECIMAL(10,2) NOT NULL,
    Descuento   DECIMAL(10,2) NOT NULL CONSTRAINT DF_Planillas_Descuento DEFAULT 0,
    Bono        DECIMAL(10,2) NOT NULL CONSTRAINT DF_Planillas_Bono      DEFAULT 0,
    SalarioNeto DECIMAL(10,2) NOT NULL,
    Estado      BIT           NOT NULL CONSTRAINT DF_Planillas_Estado    DEFAULT 1
);

IF OBJECT_ID('dbo.Empleados', 'U') IS NULL
CREATE TABLE dbo.Empleados (
    IdEmpleado        INT IDENTITY(1,1) CONSTRAINT PK_Empleados PRIMARY KEY,
    Nombre            VARCHAR(200) NOT NULL CONSTRAINT UQ_Empleados_Nombre UNIQUE,
    FechaContratacion DATE NULL,
    IdCargo    INT NULL CONSTRAINT FK_Empleados_Cargo    FOREIGN KEY REFERENCES dbo.Cargos(IdCargo),
    IdEstado   INT NULL CONSTRAINT FK_Empleados_Estado   FOREIGN KEY REFERENCES dbo.EstadosEmpleado(IdEstado),
    IdPlanilla INT NULL CONSTRAINT FK_Empleados_Planilla FOREIGN KEY REFERENCES dbo.Planillas(IdPlanilla),
    FechaNacimiento DATE NULL,
    EstadoCivil     VARCHAR(50)  NULL,
    Religion        VARCHAR(50)  NULL,
    Telefono        VARCHAR(20)  NULL,
    Correo          VARCHAR(100) NULL,
    Direccion       VARCHAR(255) NULL
);

IF OBJECT_ID('dbo.Usuarios', 'U') IS NULL
CREATE TABLE dbo.Usuarios (
    IdUsuario INT IDENTITY(1,1) CONSTRAINT PK_Usuarios PRIMARY KEY,
    Usuario   VARCHAR(50)  NOT NULL CONSTRAINT UQ_Usuarios_Usuario UNIQUE,
    Clave     VARCHAR(255) NOT NULL,
    IdRol     INT NOT NULL CONSTRAINT FK_Usuarios_Rol FOREIGN KEY REFERENCES dbo.Roles(IdRol),
    Correo    VARCHAR(100) NULL
);
GO

/* =====================================================================
   3. SALONES, CATALOGO DE ACTIVOS Y UNIDADES FISICAS
   ===================================================================== */
IF OBJECT_ID('dbo.Salones', 'U') IS NULL
CREATE TABLE dbo.Salones (
    IdSalon       INT NOT NULL CONSTRAINT PK_Salones PRIMARY KEY,   -- se asigna con MAX+1 (sp_GuardarSalon)
    NombreSalon   VARCHAR(50) NOT NULL,
    Tipo          VARCHAR(30) NULL,
    Capacidad     INT NULL,
    Edificio      VARCHAR(100) NULL,
    IdResponsable INT NULL CONSTRAINT FK_Salones_Responsable FOREIGN KEY REFERENCES dbo.Empleados(IdEmpleado),
    Activo        BIT NOT NULL CONSTRAINT DF_Salones_Activo DEFAULT 1,
    Observacion   VARCHAR(300) NULL,
    CONSTRAINT CK_Salones_Tipo      CHECK (Tipo IS NULL OR Tipo IN ('Aula','Laboratorio','Biblioteca','Oficina','Bodega','Auditorio','Otro')),
    CONSTRAINT CK_Salones_Capacidad CHECK (Capacidad IS NULL OR (Capacidad BETWEEN 1 AND 500))
);
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'UX_Salones_Nombre' AND object_id = OBJECT_ID('dbo.Salones'))
    CREATE UNIQUE INDEX UX_Salones_Nombre ON dbo.Salones (NombreSalon);
GO

-- Catalogo: tipo de equipo. El estado vive en cada unidad, no aqui.
IF OBJECT_ID('dbo.GestionActivos', 'U') IS NULL
CREATE TABLE dbo.GestionActivos (
    IdActivo         INT NOT NULL CONSTRAINT PK_GestionActivos PRIMARY KEY,   -- se asigna con MAX+1 desde la aplicacion
    Nombre           VARCHAR(100) NOT NULL,
    IdCategoria      INT NULL CONSTRAINT FK_GestionActivos_Categoria FOREIGN KEY REFERENCES dbo.Categorias(IdCategoria),
    CodigoInventario VARCHAR(50) NULL,
    IdUbicacion      INT NULL CONSTRAINT FK_GestionActivos_Ubicacion FOREIGN KEY REFERENCES dbo.Salones(IdSalon)
);
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'UX_GestionActivos_Codigo' AND object_id = OBJECT_ID('dbo.GestionActivos'))
    CREATE UNIQUE INDEX UX_GestionActivos_Codigo ON dbo.GestionActivos (CodigoInventario) WHERE CodigoInventario IS NOT NULL;
GO

-- Cada unidad fisica, con SU propio estado, codigo y ubicacion
IF OBJECT_ID('dbo.UnidadesActivo', 'U') IS NULL
CREATE TABLE dbo.UnidadesActivo (
    IdUnidad         INT IDENTITY(1,1) CONSTRAINT PK_UnidadesActivo PRIMARY KEY,
    IdActivo         INT NOT NULL CONSTRAINT FK_UnidadesActivo_Activo
                         FOREIGN KEY REFERENCES dbo.GestionActivos(IdActivo) ON DELETE CASCADE,
    IdSalon          INT NOT NULL CONSTRAINT FK_UnidadesActivo_Salon  FOREIGN KEY REFERENCES dbo.Salones(IdSalon),
    CodigoInventario VARCHAR(50) NULL,
    IdEstado         INT NOT NULL CONSTRAINT FK_UnidadesActivo_Estado FOREIGN KEY REFERENCES dbo.Estados(IdEstado),
    FechaAlta        DATETIME NOT NULL CONSTRAINT DF_UnidadesActivo_Alta DEFAULT GETDATE(),
    Observacion      VARCHAR(300) NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'UX_UnidadesActivo_Codigo' AND object_id = OBJECT_ID('dbo.UnidadesActivo'))
    CREATE UNIQUE INDEX UX_UnidadesActivo_Codigo ON dbo.UnidadesActivo (CodigoInventario) WHERE CodigoInventario IS NOT NULL;
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_UnidadesActivo_SalonActivo' AND object_id = OBJECT_ID('dbo.UnidadesActivo'))
    CREATE INDEX IX_UnidadesActivo_SalonActivo ON dbo.UnidadesActivo (IdSalon, IdActivo) INCLUDE (IdEstado);
GO

/* =====================================================================
   4. AUDITORIA (tablas; los triggers estan en la seccion 7)
   ===================================================================== */
-- Cambios en las unidades: alta, retiro, cambio de estado y traslado entre salones
IF OBJECT_ID('dbo.AuditoriaUnidades', 'U') IS NULL
CREATE TABLE dbo.AuditoriaUnidades (
    IdAuditoria      INT IDENTITY(1,1) CONSTRAINT PK_AuditoriaUnidades PRIMARY KEY,
    IdUnidad         INT NULL,
    IdActivo         INT NULL,
    CodigoInventario VARCHAR(50) NULL,
    Accion           VARCHAR(10),
    EstadoAnterior   INT NULL,
    EstadoNuevo      INT NULL,
    SalonAnterior    INT NULL,
    SalonNuevo       INT NULL,
    Usuario          SYSNAME  CONSTRAINT DF_AudUnidades_Usuario DEFAULT SUSER_SNAME(),
    Fecha            DATETIME CONSTRAINT DF_AudUnidades_Fecha   DEFAULT GETDATE()
);

-- Cambios en el catalogo de equipos (altas, bajas y cambios de nombre)
IF OBJECT_ID('dbo.AuditoriaActivos', 'U') IS NULL
CREATE TABLE dbo.AuditoriaActivos (
    IdAuditoria    INT IDENTITY(1,1) CONSTRAINT PK_AuditoriaActivos PRIMARY KEY,
    IdActivo       INT NULL,
    Accion         VARCHAR(10),
    NombreAnterior NVARCHAR(200) NULL,
    NombreNuevo    NVARCHAR(200) NULL,
    Usuario        SYSNAME  CONSTRAINT DF_AudActivos_Usuario DEFAULT SUSER_SNAME(),
    Fecha          DATETIME CONSTRAINT DF_AudActivos_Fecha   DEFAULT GETDATE()
);
GO

/* =====================================================================
   5. REPORTES DE DANO, PRESTAMOS, MANTENIMIENTO Y CONSUMIBLES
   ===================================================================== */
IF OBJECT_ID('dbo.ReportesDanio', 'U') IS NULL
CREATE TABLE dbo.ReportesDanio (
    IdReporte INT IDENTITY(1,1) CONSTRAINT PK_ReportesDanio PRIMARY KEY,
    IdSalon   INT NOT NULL CONSTRAINT FK_ReportesDanio_Salones FOREIGN KEY REFERENCES dbo.Salones(IdSalon),
    IdActivo  INT NOT NULL CONSTRAINT FK_ReportesDanio_Activos
                  FOREIGN KEY REFERENCES dbo.GestionActivos(IdActivo) ON DELETE CASCADE,
    IdUnidad  INT NULL CONSTRAINT FK_ReportesDanio_Unidad FOREIGN KEY REFERENCES dbo.UnidadesActivo(IdUnidad),
    CodigoInventario VARCHAR(50) NULL,
    Cantidad  INT NOT NULL CONSTRAINT DF_ReportesDanio_Cantidad DEFAULT 1
                  CONSTRAINT CK_ReportesDanio_Cantidad CHECK (Cantidad > 0),
    Prioridad VARCHAR(10) NOT NULL CONSTRAINT DF_ReportesDanio_Prioridad DEFAULT 'Media'
                  CONSTRAINT CK_ReportesDanio_Prioridad CHECK (Prioridad IN ('Baja', 'Media', 'Alta')),
    Descripcion VARCHAR(500) NOT NULL
                  CONSTRAINT CK_ReportesDanio_Descripcion CHECK (LEN(LTRIM(RTRIM(Descripcion))) > 0),
    ReportadoPor VARCHAR(50) NOT NULL,
    FechaReporte DATETIME NOT NULL CONSTRAINT DF_ReportesDanio_Fecha DEFAULT GETDATE(),
    Estado VARCHAR(10) NOT NULL CONSTRAINT DF_ReportesDanio_Estado DEFAULT 'Abierto'
                  CONSTRAINT CK_ReportesDanio_Estado CHECK (Estado IN ('Abierto', 'Reparado')),
    FechaReparacion       DATETIME NULL,
    ReparadoPor           VARCHAR(50) NULL,
    ObservacionReparacion VARCHAR(500) NULL
);
GO

-- Una unidad no puede tener dos reportes abiertos a la vez
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'UX_ReportesDanio_UnidadAbierta' AND object_id = OBJECT_ID('dbo.ReportesDanio'))
    CREATE UNIQUE INDEX UX_ReportesDanio_UnidadAbierta ON dbo.ReportesDanio (IdUnidad)
    WHERE Estado = 'Abierto' AND IdUnidad IS NOT NULL;
GO

IF OBJECT_ID('dbo.Prestamos', 'U') IS NULL
CREATE TABLE dbo.Prestamos (
    IdPrestamo INT IDENTITY(1,1) CONSTRAINT PK_Prestamos PRIMARY KEY,
    IdActivo   INT NOT NULL CONSTRAINT FK_Prestamos_Activos FOREIGN KEY REFERENCES dbo.GestionActivos(IdActivo),
    IdUnidad   INT NULL CONSTRAINT FK_Prestamos_Unidad FOREIGN KEY REFERENCES dbo.UnidadesActivo(IdUnidad),
    CodigoInventario VARCHAR(50) NULL,
    Cantidad   INT NOT NULL CONSTRAINT DF_Prestamos_Cant DEFAULT 1
                   CONSTRAINT CK_Prestamos_Cant CHECK (Cantidad > 0),
    TipoResponsable VARCHAR(30) NOT NULL
                   CONSTRAINT CK_Prestamos_Tipo CHECK (TipoResponsable IN ('Docente', 'Alumno', 'Personal administrativo')),
    Responsable    VARCHAR(100) NOT NULL,
    IdSalonDestino INT NULL CONSTRAINT FK_Prestamos_Salon FOREIGN KEY REFERENCES dbo.Salones(IdSalon),
    FechaEntrega   DATETIME NOT NULL CONSTRAINT DF_Prestamos_Entrega DEFAULT GETDATE(),
    FechaLimite    DATETIME NOT NULL,
    Estado         VARCHAR(10) NOT NULL CONSTRAINT DF_Prestamos_Estado DEFAULT 'Activo'
                   CONSTRAINT CK_Prestamos_Estado CHECK (Estado IN ('Activo', 'Devuelto')),
    FechaDevolucion    DATETIME NULL,
    IdEstadoDevolucion INT NULL CONSTRAINT FK_Prestamos_EstadoDev FOREIGN KEY REFERENCES dbo.Estados(IdEstado),
    ObservacionSalida     VARCHAR(300) NULL,
    ObservacionDevolucion VARCHAR(300) NULL,
    EntregadoPor VARCHAR(50) NOT NULL
);
GO

-- Una unidad no puede tener dos prestamos activos a la vez
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'UX_Prestamos_UnidadActiva' AND object_id = OBJECT_ID('dbo.Prestamos'))
    CREATE UNIQUE INDEX UX_Prestamos_UnidadActiva ON dbo.Prestamos (IdUnidad)
    WHERE Estado = 'Activo' AND IdUnidad IS NOT NULL;
GO

IF OBJECT_ID('dbo.MantenimientosActivo', 'U') IS NULL
CREATE TABLE dbo.MantenimientosActivo (
    IdMantenimiento INT IDENTITY(1,1) CONSTRAINT PK_Mantenimientos PRIMARY KEY,
    IdActivo  INT NOT NULL CONSTRAINT FK_Mant_Activo FOREIGN KEY REFERENCES dbo.GestionActivos(IdActivo),
    IdUnidad  INT NULL CONSTRAINT FK_Mant_Unidad FOREIGN KEY REFERENCES dbo.UnidadesActivo(IdUnidad),
    CodigoInventario VARCHAR(50) NULL,
    Fecha DATETIME NOT NULL CONSTRAINT DF_Mant_Fecha DEFAULT GETDATE(),
    Tipo  VARCHAR(12) NOT NULL CONSTRAINT CK_Mant_Tipo CHECK (Tipo IN ('Preventivo', 'Correctivo')),
    Descripcion VARCHAR(500) NOT NULL,
    Costo DECIMAL(10,2) NOT NULL CONSTRAINT DF_Mant_Costo DEFAULT 0 CONSTRAINT CK_Mant_Costo CHECK (Costo >= 0),
    IdEstadoResultante INT NOT NULL CONSTRAINT FK_Mant_Estado FOREIGN KEY REFERENCES dbo.Estados(IdEstado),
    IdReporte INT NULL CONSTRAINT FK_Mant_Reporte FOREIGN KEY REFERENCES dbo.ReportesDanio(IdReporte),
    RealizadoPor VARCHAR(50) NOT NULL
);

IF OBJECT_ID('dbo.Consumibles', 'U') IS NULL
CREATE TABLE dbo.Consumibles (
    IdConsumible INT IDENTITY(1,1) CONSTRAINT PK_Consumibles PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL CONSTRAINT UQ_Consumibles_Nombre UNIQUE,
    Unidad VARCHAR(30)  NOT NULL CONSTRAINT DF_Consumibles_Unidad DEFAULT 'Unidad',
    StockActual INT NOT NULL CONSTRAINT DF_Consumibles_Stock DEFAULT 0
                    CONSTRAINT CK_Consumibles_Stock CHECK (StockActual >= 0),
    StockMinimo INT NOT NULL CONSTRAINT DF_Consumibles_Min DEFAULT 0
                    CONSTRAINT CK_Consumibles_Min CHECK (StockMinimo >= 0)
);

IF OBJECT_ID('dbo.MovimientosConsumible', 'U') IS NULL
CREATE TABLE dbo.MovimientosConsumible (
    IdMovimiento INT IDENTITY(1,1) CONSTRAINT PK_MovCons PRIMARY KEY,
    IdConsumible INT NOT NULL CONSTRAINT FK_MovCons_Cons FOREIGN KEY REFERENCES dbo.Consumibles(IdConsumible),
    Tipo     VARCHAR(10) NOT NULL CONSTRAINT CK_MovCons_Tipo CHECK (Tipo IN ('Entrada', 'Salida')),
    Cantidad INT NOT NULL CONSTRAINT CK_MovCons_Cant CHECK (Cantidad > 0),
    Motivo   VARCHAR(40) NOT NULL,
    Destino  VARCHAR(100) NULL,
    SaldoResultante INT NOT NULL,
    Fecha    DATETIME NOT NULL CONSTRAINT DF_MovCons_Fecha DEFAULT GETDATE(),
    Usuario  VARCHAR(50) NOT NULL,
    IdSalon  INT NULL CONSTRAINT FK_MovCons_Salon FOREIGN KEY REFERENCES dbo.Salones(IdSalon)
);
GO

/* =====================================================================
   6. CONFIGURACION, ASIGNACIONES ACADEMICAS Y PAGOS DE PLANILLA
   ===================================================================== */
-- Una sola fila (el CHECK impide crear una segunda)
IF OBJECT_ID('dbo.ConfiguracionEmpresa', 'U') IS NULL
CREATE TABLE dbo.ConfiguracionEmpresa (
    IdConfig      INT NOT NULL CONSTRAINT PK_ConfigEmpresa PRIMARY KEY
                      CONSTRAINT CK_ConfigEmpresa_Unica CHECK (IdConfig = 1),
    NombreEmpresa NVARCHAR(150) NOT NULL,
    Logotipo      VARBINARY(MAX) NULL,
    Direccion     NVARCHAR(200) NULL,
    Telefono      NVARCHAR(30)  NULL,
    Correo        NVARCHAR(100) NULL,
    InfoGeneral   NVARCHAR(500) NULL,
    FechaConfig   DATETIME NOT NULL CONSTRAINT DF_ConfigEmpresa_Fecha DEFAULT GETDATE()
);

IF OBJECT_ID('dbo.Grados', 'U') IS NULL
CREATE TABLE dbo.Grados (
    IdGrado     INT IDENTITY(1,1) CONSTRAINT PK_Grados PRIMARY KEY,
    NombreGrado NVARCHAR(60) NOT NULL CONSTRAINT UQ_Grados_Nombre UNIQUE,
    Orden       INT NOT NULL
);

IF OBJECT_ID('dbo.Secciones', 'U') IS NULL
CREATE TABLE dbo.Secciones (
    IdSeccion     INT IDENTITY(1,1) CONSTRAINT PK_Secciones PRIMARY KEY,
    IdGrado       INT NOT NULL CONSTRAINT FK_Secciones_Grados FOREIGN KEY REFERENCES dbo.Grados(IdGrado),
    NombreSeccion NVARCHAR(10) NOT NULL,
    CONSTRAINT UQ_Secciones UNIQUE (IdGrado, NombreSeccion)
);

IF OBJECT_ID('dbo.AsignacionesDocente', 'U') IS NULL
CREATE TABLE dbo.AsignacionesDocente (
    IdAsignacion   INT IDENTITY(1,1) CONSTRAINT PK_AsignacionesDocente PRIMARY KEY,
    IdEmpleado     INT NOT NULL CONSTRAINT FK_AsigDoc_Empleado
                       FOREIGN KEY REFERENCES dbo.Empleados(IdEmpleado) ON DELETE CASCADE,
    IdSeccion      INT NOT NULL CONSTRAINT FK_AsigDoc_Seccion FOREIGN KEY REFERENCES dbo.Secciones(IdSeccion),
    AnioLectivo    INT NOT NULL,
    HorasSemanales INT NOT NULL CONSTRAINT CK_AsigDoc_Horas CHECK (HorasSemanales BETWEEN 1 AND 40),
    FechaRegistro  DATETIME NOT NULL CONSTRAINT DF_AsigDoc_Fecha DEFAULT GETDATE(),
    CONSTRAINT UQ_AsigDoc UNIQUE (IdEmpleado, IdSeccion, AnioLectivo)
);

IF OBJECT_ID('dbo.PagosPlanilla', 'U') IS NULL
CREATE TABLE dbo.PagosPlanilla (
    IdPago        INT IDENTITY(1,1) CONSTRAINT PK_PagosPlanilla PRIMARY KEY,
    IdEmpleado    INT NOT NULL CONSTRAINT FK_PagosPlanilla_Empleado FOREIGN KEY REFERENCES dbo.Empleados(IdEmpleado),
    Periodo       DATE NOT NULL,                      -- siempre el dia 1 del mes
    SalarioBase   DECIMAL(10,2) NOT NULL,
    Bono          DECIMAL(10,2) NOT NULL CONSTRAINT DF_PagosPlanilla_Bono   DEFAULT 0,
    Descuento     DECIMAL(10,2) NOT NULL CONSTRAINT DF_PagosPlanilla_Desc   DEFAULT 0,
    SalarioNeto   AS (SalarioBase + Bono - Descuento) PERSISTED,
    EstadoPago    VARCHAR(20)   NOT NULL CONSTRAINT DF_PagosPlanilla_Estado DEFAULT 'Pendiente',
    FechaPago     DATETIME NULL,
    Observacion   VARCHAR(200) NULL,
    Anulado       BIT NOT NULL CONSTRAINT DF_PagosPlanilla_Anulado DEFAULT 0,
    FechaRegistro DATETIME NOT NULL CONSTRAINT DF_PagosPlanilla_Fecha DEFAULT GETDATE(),
    CONSTRAINT CK_PagosPlanilla_Estado  CHECK (EstadoPago IN ('Pendiente','Pagado')),
    CONSTRAINT CK_PagosPlanilla_Periodo CHECK (DAY(Periodo) = 1),
    CONSTRAINT CK_PagosPlanilla_Montos  CHECK (SalarioBase > 0 AND Bono >= 0 AND Descuento >= 0
                                               AND Descuento <= SalarioBase + Bono)
);
GO

-- Un solo pago vigente por empleado y mes (los anulados no cuentan)
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'UX_PagosPlanilla_Empleado_Periodo' AND object_id = OBJECT_ID('dbo.PagosPlanilla'))
    CREATE UNIQUE INDEX UX_PagosPlanilla_Empleado_Periodo ON dbo.PagosPlanilla (IdEmpleado, Periodo) WHERE Anulado = 0;
GO

/* =====================================================================
   7. TRIGGERS
   ===================================================================== */
-- Registra altas, retiros, cambios de estado y traslados de cada unidad
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
    WHERE d.IdEstado <> i.IdEstado OR d.IdSalon <> i.IdSalon;    -- solo cambios relevantes

    INSERT INTO dbo.AuditoriaUnidades (IdUnidad, IdActivo, CodigoInventario, Accion, EstadoAnterior, SalonAnterior)
    SELECT d.IdUnidad, d.IdActivo, d.CodigoInventario, 'DELETE', d.IdEstado, d.IdSalon
    FROM deleted d
    WHERE NOT EXISTS (SELECT 1 FROM inserted);
END;
GO

-- Registra altas, bajas y cambios de nombre en el catalogo de equipos
CREATE OR ALTER TRIGGER dbo.trg_AuditoriaActivos
ON dbo.GestionActivos
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.AuditoriaActivos (IdActivo, Accion, NombreNuevo)
    SELECT i.IdActivo, 'INSERT', i.Nombre
    FROM inserted i
    WHERE NOT EXISTS (SELECT 1 FROM deleted);

    INSERT INTO dbo.AuditoriaActivos (IdActivo, Accion, NombreAnterior, NombreNuevo)
    SELECT i.IdActivo, 'UPDATE', d.Nombre, i.Nombre
    FROM inserted i
    JOIN deleted d ON d.IdActivo = i.IdActivo
    WHERE ISNULL(d.Nombre, '') <> ISNULL(i.Nombre, '');

    INSERT INTO dbo.AuditoriaActivos (IdActivo, Accion, NombreAnterior)
    SELECT d.IdActivo, 'DELETE', d.Nombre
    FROM deleted d
    WHERE NOT EXISTS (SELECT 1 FROM inserted);
END;
GO

/* =====================================================================
   8. FUNCION: la bodega es el salon activo de tipo 'Bodega'
   ===================================================================== */
CREATE OR ALTER FUNCTION dbo.fn_IdBodega()
RETURNS INT
AS
BEGIN
    RETURN (SELECT TOP 1 IdSalon
            FROM dbo.Salones
            WHERE Tipo = 'Bodega' AND Activo = 1
            ORDER BY CASE WHEN NombreSalon = 'Bodega central' THEN 0 ELSE 1 END, IdSalon);
END
GO

/* =====================================================================
   9. VISTAS
   ===================================================================== */
-- ---------- Personal y planillas ----------
CREATE OR ALTER VIEW dbo.vw_EmpleadosDetalle AS
SELECT e.IdEmpleado, e.Nombre, e.FechaContratacion,
       e.IdCargo,  c.NombreCargo,
       e.IdEstado, ee.NombreEstado AS Estado,
       e.IdPlanilla,
       p.SalarioBase, p.Descuento, p.Bono, p.SalarioNeto,
       -- Estado del pago del mes actual (el programa lo muestra en Personal)
       ISNULL(pg.EstadoPago, 'Sin registrar') AS EstadoPago
FROM dbo.Empleados e
LEFT JOIN dbo.Cargos c           ON c.IdCargo    = e.IdCargo
LEFT JOIN dbo.EstadosEmpleado ee ON ee.IdEstado  = e.IdEstado
LEFT JOIN dbo.Planillas p        ON p.IdPlanilla = e.IdPlanilla
OUTER APPLY (SELECT TOP 1 x.EstadoPago
             FROM dbo.PagosPlanilla x
             WHERE x.IdEmpleado = e.IdEmpleado AND x.Anulado = 0
               AND x.Periodo = DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1)
             ORDER BY x.IdPago DESC) pg;
GO

CREATE OR ALTER VIEW dbo.vw_ResumenEmpleadosPorEstado AS
SELECT ee.NombreEstado AS Estado, COUNT(e.IdEmpleado) AS TotalEmpleados
FROM dbo.EstadosEmpleado ee
LEFT JOIN dbo.Empleados e ON e.IdEstado = ee.IdEstado
GROUP BY ee.NombreEstado;
GO

CREATE OR ALTER VIEW dbo.vw_ResumenPlanillaPorCargo AS
SELECT c.NombreCargo,
       COUNT(e.IdEmpleado)           AS TotalEmpleados,
       ISNULL(SUM(p.SalarioBase), 0) AS TotalSalarioBase,
       ISNULL(SUM(p.SalarioNeto), 0) AS TotalSalarioNeto
FROM dbo.Cargos c
LEFT JOIN dbo.Empleados e ON e.IdCargo    = c.IdCargo
LEFT JOIN dbo.Planillas p ON p.IdPlanilla = e.IdPlanilla
GROUP BY c.NombreCargo;
GO

CREATE OR ALTER VIEW dbo.vw_PagosPlanillaDetalle AS
SELECT pg.IdPago, pg.IdEmpleado, e.Nombre AS Empleado, c.NombreCargo AS Cargo,
       pg.Periodo, LEFT(CONVERT(CHAR(10), pg.Periodo, 23), 7) AS PeriodoClave,
       pg.SalarioBase, pg.Bono, pg.Descuento, pg.SalarioNeto,
       pg.EstadoPago, pg.FechaPago, pg.Observacion, pg.Anulado, pg.FechaRegistro
FROM dbo.PagosPlanilla pg
INNER JOIN dbo.Empleados e ON e.IdEmpleado = pg.IdEmpleado
INNER JOIN dbo.Cargos    c ON c.IdCargo    = e.IdCargo;
GO

CREATE OR ALTER VIEW dbo.vw_AsignacionesDetalle AS
SELECT a.IdAsignacion, a.IdEmpleado, e.Nombre AS Docente, c.NombreCargo AS Cargo,
       CASE WHEN c.NombreCargo LIKE N'Docente de %' THEN LTRIM(SUBSTRING(c.NombreCargo, 12, 100))
            ELSE c.NombreCargo END AS Materia,
       g.IdGrado, g.NombreGrado AS Grado, g.Orden AS OrdenGrado,
       s.IdSeccion, s.NombreSeccion AS Seccion,
       a.AnioLectivo, a.HorasSemanales
FROM dbo.AsignacionesDocente a
JOIN dbo.Empleados e ON e.IdEmpleado = a.IdEmpleado
JOIN dbo.Cargos c    ON c.IdCargo    = e.IdCargo
JOIN dbo.Secciones s ON s.IdSeccion  = a.IdSeccion
JOIN dbo.Grados g    ON g.IdGrado    = s.IdGrado;
GO

CREATE OR ALTER VIEW dbo.vw_CargaDocente AS
SELECT IdEmpleado, Docente, Materia, AnioLectivo,
       SUM(HorasSemanales) AS TotalHoras, COUNT(*) AS Grupos
FROM dbo.vw_AsignacionesDetalle
GROUP BY IdEmpleado, Docente, Materia, AnioLectivo;
GO

-- ---------- Salones y equipo ----------
CREATE OR ALTER VIEW dbo.vw_SalonesResumen AS
SELECT s.IdSalon, s.NombreSalon, ISNULL(s.Tipo, 'Otro') AS Tipo, s.Capacidad, s.Edificio,
       s.IdResponsable, emp.Nombre AS Responsable, s.Activo, s.Observacion,
       COUNT(u.IdUnidad) AS Unidades,
       ISNULL(SUM(CASE WHEN es.NombreEstado IN ('Malo','En reparación','Mantenimiento Pendiente','Dado de baja')
                       THEN 1 ELSE 0 END), 0) AS ConProblema
FROM dbo.Salones s
LEFT JOIN dbo.Empleados emp    ON emp.IdEmpleado = s.IdResponsable
LEFT JOIN dbo.UnidadesActivo u ON u.IdSalon      = s.IdSalon
LEFT JOIN dbo.Estados es       ON es.IdEstado    = u.IdEstado
GROUP BY s.IdSalon, s.NombreSalon, s.Tipo, s.Capacidad, s.Edificio, s.IdResponsable,
         emp.Nombre, s.Activo, s.Observacion;
GO

-- Una fila por unidad con SU estado
CREATE OR ALTER VIEW dbo.vw_UnidadesDetalle AS
SELECT u.IdUnidad, u.CodigoInventario,
       u.IdActivo, a.Nombre AS Activo,
       a.IdCategoria, cat.NombreCategoria AS Categoria,
       u.IdSalon, s.NombreSalon AS Ubicacion,
       u.IdEstado, e.NombreEstado AS Estado,
       u.FechaAlta, u.Observacion
FROM dbo.UnidadesActivo u
JOIN dbo.GestionActivos a    ON a.IdActivo      = u.IdActivo
JOIN dbo.Salones s           ON s.IdSalon       = u.IdSalon
JOIN dbo.Estados e           ON e.IdEstado      = u.IdEstado
LEFT JOIN dbo.Categorias cat ON cat.IdCategoria = a.IdCategoria;
GO

-- Catalogo con totales de unidades
CREATE OR ALTER VIEW dbo.vw_ActivosDetalle AS
SELECT a.IdActivo, a.Nombre,
       a.IdCategoria, cat.NombreCategoria AS Categoria,
       a.CodigoInventario, a.IdUbicacion, s.NombreSalon AS Ubicacion,
       COUNT(u.IdUnidad) AS TotalUnidades,
       ISNULL(SUM(CASE WHEN es.NombreEstado IN ('Malo','En reparación','Mantenimiento Pendiente','Dado de baja')
                       THEN 1 ELSE 0 END), 0) AS UnidadesConProblema
FROM dbo.GestionActivos a
LEFT JOIN dbo.Categorias cat   ON cat.IdCategoria = a.IdCategoria
LEFT JOIN dbo.Salones s        ON s.IdSalon       = a.IdUbicacion
LEFT JOIN dbo.UnidadesActivo u ON u.IdActivo      = a.IdActivo
LEFT JOIN dbo.Estados es       ON es.IdEstado     = u.IdEstado
GROUP BY a.IdActivo, a.Nombre, a.IdCategoria, cat.NombreCategoria,
         a.CodigoInventario, a.IdUbicacion, s.NombreSalon;
GO

-- Con codigo = una fila por equipo; sin codigo requerido = agrupado por cantidad
CREATE OR ALTER VIEW dbo.vw_ActivosPorSalon AS
SELECT u.IdSalon, s.NombreSalon, a.IdActivo, a.Nombre AS NombreActivo,
       cat.NombreCategoria AS Categoria,
       COUNT(*) AS Cantidad,
       CAST(NULL AS VARCHAR(50)) AS CodigoInventario
FROM dbo.UnidadesActivo u
JOIN dbo.Salones s           ON s.IdSalon  = u.IdSalon
JOIN dbo.GestionActivos a    ON a.IdActivo = u.IdActivo
LEFT JOIN dbo.Categorias cat ON cat.IdCategoria = a.IdCategoria
WHERE ISNULL(cat.RequiereSerial, 0) = 0
GROUP BY u.IdSalon, s.NombreSalon, a.IdActivo, a.Nombre, cat.NombreCategoria
UNION ALL
SELECT u.IdSalon, s.NombreSalon, a.IdActivo, a.Nombre, cat.NombreCategoria,
       1, u.CodigoInventario
FROM dbo.UnidadesActivo u
JOIN dbo.Salones s           ON s.IdSalon  = u.IdSalon
JOIN dbo.GestionActivos a    ON a.IdActivo = u.IdActivo
LEFT JOIN dbo.Categorias cat ON cat.IdCategoria = a.IdCategoria
WHERE cat.RequiereSerial = 1;
GO

CREATE OR ALTER VIEW dbo.vw_ResumenActivosPorSalon AS
SELECT NombreSalon,
       COUNT(DISTINCT IdActivo) AS TiposDeActivo,
       SUM(Cantidad)            AS TotalUnidades
FROM dbo.vw_ActivosPorSalon
GROUP BY NombreSalon;
GO

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

-- Equipo disponible en la bodega (en buen estado y sin prestamo activo), listo para asignar
CREATE OR ALTER VIEW dbo.vw_StockBodega AS
SELECT a.IdActivo, a.Nombre AS Activo,
       ISNULL(c.NombreCategoria, 'Sin categoría') AS Categoria,
       COUNT(u.IdUnidad) AS Disponibles
FROM dbo.UnidadesActivo u
JOIN dbo.GestionActivos a  ON a.IdActivo = u.IdActivo
JOIN dbo.Estados e         ON e.IdEstado = u.IdEstado
LEFT JOIN dbo.Categorias c ON c.IdCategoria = a.IdCategoria
WHERE u.IdSalon = dbo.fn_IdBodega()
  AND e.NombreEstado NOT IN ('Malo', 'En reparación', 'Mantenimiento Pendiente', 'Dado de baja')
  AND NOT EXISTS (SELECT 1 FROM dbo.Prestamos p WHERE p.IdUnidad = u.IdUnidad AND p.Estado = 'Activo')
GROUP BY a.IdActivo, a.Nombre, c.NombreCategoria;
GO

-- ---------- Auditoria ----------
CREATE OR ALTER VIEW dbo.vw_AuditoriaActivosDetalle AS
SELECT IdAuditoria, Fecha, Accion, IdActivo, NombreAnterior, NombreNuevo, Usuario
FROM dbo.AuditoriaActivos;
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

-- ---------- Reportes de dano, prestamos y mantenimiento ----------
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

-- ---------- Consumibles ----------
CREATE OR ALTER VIEW dbo.vw_StockConsumibles AS
SELECT IdConsumible, Nombre, Unidad, StockActual, StockMinimo,
       CASE WHEN StockActual = 0 THEN 'Agotado'
            WHEN StockActual <= StockMinimo THEN 'Stock bajo'
            ELSE 'Normal' END AS Alerta
FROM dbo.Consumibles;
GO

CREATE OR ALTER VIEW dbo.vw_KardexConsumibles AS
SELECT m.IdMovimiento, m.IdConsumible, c.Nombre AS Consumible, c.Unidad,
       m.Fecha, m.Tipo, m.Cantidad, m.Motivo, m.Destino, m.SaldoResultante, m.Usuario
FROM dbo.MovimientosConsumible m
JOIN dbo.Consumibles c ON c.IdConsumible = m.IdConsumible;
GO

CREATE OR ALTER VIEW dbo.vw_ConsumiblesPorSalon AS
SELECT m.IdSalon, s.NombreSalon, c.IdConsumible, c.Nombre AS Consumible, c.Unidad,
       SUM(m.Cantidad) AS Entregado, MAX(m.Fecha) AS UltimaEntrega
FROM dbo.MovimientosConsumible m
JOIN dbo.Consumibles c ON c.IdConsumible = m.IdConsumible
JOIN dbo.Salones s     ON s.IdSalon      = m.IdSalon
WHERE m.Tipo = 'Salida' AND m.IdSalon IS NOT NULL
GROUP BY m.IdSalon, s.NombreSalon, c.IdConsumible, c.Nombre, c.Unidad;
GO

-- Historial unificado: prestamos, devoluciones, consumibles y mantenimientos
CREATE OR ALTER VIEW dbo.vw_HistorialMovimientos AS
SELECT p.FechaEntrega AS Fecha, CAST('Préstamo' AS VARCHAR(30)) AS Tipo,
       CAST(a.Nombre + ISNULL(' (' + p.CodigoInventario + ')', '') + ' x' + CAST(p.Cantidad AS VARCHAR(10)) AS VARCHAR(200)) AS Detalle,
       CAST(p.Responsable AS VARCHAR(100)) AS Responsable, CAST(p.EntregadoPor AS VARCHAR(50)) AS RegistradoPor
FROM dbo.Prestamos p JOIN dbo.GestionActivos a ON a.IdActivo = p.IdActivo
UNION ALL
SELECT p.FechaDevolucion, 'Devolución',
       CAST(a.Nombre + ISNULL(' (' + p.CodigoInventario + ')', '') + ' x' + CAST(p.Cantidad AS VARCHAR(10)) AS VARCHAR(200)),
       CAST(p.Responsable AS VARCHAR(100)), CAST(p.EntregadoPor AS VARCHAR(50))
FROM dbo.Prestamos p JOIN dbo.GestionActivos a ON a.IdActivo = p.IdActivo
WHERE p.FechaDevolucion IS NOT NULL
UNION ALL
SELECT m.Fecha, CAST('Consumible - ' + m.Tipo AS VARCHAR(30)),
       CAST(c.Nombre + ' x' + CAST(m.Cantidad AS VARCHAR(10)) AS VARCHAR(200)),
       CAST(ISNULL(m.Destino, m.Motivo) AS VARCHAR(100)), CAST(m.Usuario AS VARCHAR(50))
FROM dbo.MovimientosConsumible m JOIN dbo.Consumibles c ON c.IdConsumible = m.IdConsumible
UNION ALL
SELECT mt.Fecha, CAST('Mantenimiento - ' + mt.Tipo AS VARCHAR(30)),
       CAST(a.Nombre + ISNULL(' (' + mt.CodigoInventario + ')', '') AS VARCHAR(200)),
       CAST(mt.RealizadoPor AS VARCHAR(100)), CAST(mt.RealizadoPor AS VARCHAR(50))
FROM dbo.MantenimientosActivo mt JOIN dbo.GestionActivos a ON a.IdActivo = mt.IdActivo;
GO

/* =====================================================================
   10. PROCEDIMIENTOS ALMACENADOS
   ===================================================================== */
-- ---------- Configuracion inicial ----------
CREATE OR ALTER PROCEDURE dbo.sp_GuardarConfiguracionInicial
    @NombreEmpresa NVARCHAR(150),
    @Logotipo      VARBINARY(MAX) = NULL,
    @Direccion     NVARCHAR(200)  = NULL,
    @Telefono      NVARCHAR(30)   = NULL,
    @Correo        NVARCHAR(100)  = NULL,
    @InfoGeneral   NVARCHAR(500)  = NULL,
    @Usuario       NVARCHAR(50)   = NULL,
    @HashClave     NVARCHAR(200)  = NULL
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;
    BEGIN TRY
        IF LEN(LTRIM(RTRIM(ISNULL(@NombreEmpresa, '')))) = 0
            THROW 50020, 'El nombre de la empresa es obligatorio.', 1;
        IF EXISTS (SELECT 1 FROM dbo.ConfiguracionEmpresa)
            THROW 50021, 'El sistema ya fue configurado.', 1;

        BEGIN TRANSACTION;

        INSERT INTO dbo.ConfiguracionEmpresa
            (IdConfig, NombreEmpresa, Logotipo, Direccion, Telefono, Correo, InfoGeneral)
        VALUES (1, LTRIM(RTRIM(@NombreEmpresa)), @Logotipo, @Direccion, @Telefono, @Correo, @InfoGeneral);

        IF @Usuario IS NOT NULL
        BEGIN
            IF EXISTS (SELECT 1 FROM dbo.Usuarios WHERE Usuario = @Usuario)
                THROW 50022, 'Ese nombre de usuario ya existe.', 1;

            INSERT INTO dbo.Usuarios (Usuario, Clave, IdRol, Correo)
            SELECT @Usuario, @HashClave, IdRol, @Correo
            FROM dbo.Roles WHERE NombreRol = 'Administrador';

            IF @@ROWCOUNT = 0
                THROW 50023, 'No existe el rol Administrador en la tabla Roles.', 1;
        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- ---------- Unidades fisicas ----------
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

-- Crea N unidades de un tipo en un salon, cada una con su codigo ACT-0014-027
-- (el consecutivo sigue al numero mas alto existente; los huecos no se reutilizan)
CREATE OR ALTER PROCEDURE dbo.sp_AgregarUnidades
    @IdActivo INT, @IdSalon INT, @Cantidad INT, @IdEstado INT
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;
    IF @Cantidad IS NULL OR @Cantidad <= 0
        THROW 50062, 'La cantidad debe ser mayor que cero.', 1;

    BEGIN TRANSACTION;

    DECLARE @prefijo VARCHAR(20) = 'ACT-' + RIGHT('0000' + CAST(@IdActivo AS VARCHAR(10)), 4) + '-';
    DECLARE @base INT = ISNULL(
        (SELECT MAX(TRY_CAST(SUBSTRING(CodigoInventario, LEN(@prefijo) + 1, 10) AS INT))
         FROM dbo.UnidadesActivo WITH (UPDLOCK, HOLDLOCK)
         WHERE CodigoInventario LIKE @prefijo + '%'), 0);

    ;WITH Nums AS (
        SELECT TOP (@Cantidad) ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS n
        FROM sys.all_objects a CROSS JOIN sys.all_objects b
    )
    INSERT INTO dbo.UnidadesActivo (IdActivo, IdSalon, CodigoInventario, IdEstado)
    SELECT @IdActivo, @IdSalon,
           @prefijo + CASE WHEN @base + n < 1000
                           THEN RIGHT('000' + CAST(@base + n AS VARCHAR(10)), 3)
                           ELSE CAST(@base + n AS VARCHAR(10)) END,
           @IdEstado
    FROM Nums;

    COMMIT TRANSACTION;
END;
GO

-- ALTA: el equipo entra al inventario (siempre a la bodega)
CREATE OR ALTER PROCEDURE dbo.sp_AltaUnidades
    @IdActivo INT,
    @Cantidad INT,
    @IdEstado INT,
    @Codigo   VARCHAR(50) = NULL      -- opcional, solo al dar de alta una unidad
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;

    DECLARE @IdBodega INT = dbo.fn_IdBodega();
    IF @IdBodega IS NULL
        THROW 50500, 'No hay una bodega activa. Cree un salón de tipo Bodega en Gestión de salones.', 1;
    IF NOT EXISTS (SELECT 1 FROM dbo.GestionActivos WHERE IdActivo = @IdActivo)
        THROW 50501, 'El equipo seleccionado no existe en el catálogo.', 1;
    IF @Cantidad IS NULL OR @Cantidad < 1 OR @Cantidad > 500
        THROW 50502, 'La cantidad debe estar entre 1 y 500.', 1;
    IF NOT EXISTS (SELECT 1 FROM dbo.Estados WHERE IdEstado = @IdEstado AND NombreEstado <> 'Dado de baja')
        THROW 50503, 'El estado inicial no es válido.', 1;

    SET @Codigo = NULLIF(LTRIM(RTRIM(ISNULL(@Codigo, ''))), '');

    IF @Codigo IS NOT NULL
    BEGIN
        IF @Cantidad <> 1
            THROW 50504, 'Un código personalizado solo se puede usar al dar de alta una unidad.', 1;
        IF EXISTS (SELECT 1 FROM dbo.UnidadesActivo WHERE CodigoInventario = @Codigo)
            THROW 50505, 'Ya existe una unidad con ese código de inventario.', 1;

        INSERT INTO dbo.UnidadesActivo (IdActivo, IdSalon, CodigoInventario, IdEstado)
        VALUES (@IdActivo, @IdBodega, @Codigo, @IdEstado);
    END
    ELSE
        EXEC dbo.sp_AgregarUnidades @IdActivo = @IdActivo, @IdSalon = @IdBodega,
                                    @Cantidad = @Cantidad, @IdEstado = @IdEstado;

    SELECT @Cantidad AS Creadas;
END;
GO

-- ASIGNACION: pasa unidades YA EXISTENTES de la bodega a un salon (con tope de lo disponible)
CREATE OR ALTER PROCEDURE dbo.sp_AsignarUnidades
    @IdActivo       INT,
    @IdSalonDestino INT,
    @Cantidad       INT
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;

    DECLARE @IdBodega INT = dbo.fn_IdBodega();
    IF @IdBodega IS NULL
        THROW 50510, 'No hay una bodega activa. Cree un salón de tipo Bodega en Gestión de salones.', 1;
    IF @Cantidad IS NULL OR @Cantidad < 1
        THROW 50511, 'La cantidad debe ser mayor que cero.', 1;
    IF NOT EXISTS (SELECT 1 FROM dbo.Salones WHERE IdSalon = @IdSalonDestino AND Activo = 1)
        THROW 50512, 'El salón destino no existe o está inactivo.', 1;
    IF @IdSalonDestino = @IdBodega
        THROW 50513, 'El equipo ya está en la bodega. Elija otro salón como destino.', 1;

    BEGIN TRANSACTION;

    DECLARE @disp INT =
        (SELECT COUNT(*)
         FROM dbo.UnidadesActivo u WITH (UPDLOCK, HOLDLOCK)
         JOIN dbo.Estados e ON e.IdEstado = u.IdEstado
         WHERE u.IdActivo = @IdActivo AND u.IdSalon = @IdBodega
           AND e.NombreEstado NOT IN ('Malo', 'En reparación', 'Mantenimiento Pendiente', 'Dado de baja')
           AND NOT EXISTS (SELECT 1 FROM dbo.Prestamos p WHERE p.IdUnidad = u.IdUnidad AND p.Estado = 'Activo'));

    IF @Cantidad > @disp
    BEGIN
        DECLARE @msg NVARCHAR(250) = 'Solo hay ' + CAST(@disp AS VARCHAR(10)) +
                                     ' unidad(es) disponible(s) en la bodega. Registre más con "Alta de equipo".';
        THROW 50514, @msg, 1;
    END

    DECLARE @mov TABLE (IdUnidad INT);

    ;WITH sel AS (
        SELECT TOP (@Cantidad) u.IdUnidad
        FROM dbo.UnidadesActivo u
        JOIN dbo.Estados e ON e.IdEstado = u.IdEstado
        WHERE u.IdActivo = @IdActivo AND u.IdSalon = @IdBodega
          AND e.NombreEstado NOT IN ('Malo', 'En reparación', 'Mantenimiento Pendiente', 'Dado de baja')
          AND NOT EXISTS (SELECT 1 FROM dbo.Prestamos p WHERE p.IdUnidad = u.IdUnidad AND p.Estado = 'Activo')
        ORDER BY u.IdUnidad
    )
    UPDATE u SET IdSalon = @IdSalonDestino
    OUTPUT inserted.IdUnidad INTO @mov (IdUnidad)
    FROM dbo.UnidadesActivo u
    JOIN sel s ON s.IdUnidad = u.IdUnidad;

    COMMIT TRANSACTION;

    SELECT COUNT(*) AS Asignadas FROM @mov;
END;
GO

-- Mover unidades concretas a otro salon
CREATE OR ALTER PROCEDURE dbo.sp_MoverUnidades
    @Ids VARCHAR(MAX),          -- IdUnidad separados por coma: '12,13,14'
    @IdSalonDestino INT
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;

    IF NOT EXISTS (SELECT 1 FROM dbo.Salones WHERE IdSalon = @IdSalonDestino AND Activo = 1)
        THROW 50420, 'El salón destino no existe o está inactivo.', 1;

    DECLARE @t TABLE (IdUnidad INT PRIMARY KEY);
    DECLARE @x XML = CAST('<i>' + REPLACE(ISNULL(@Ids, ''), ',', '</i><i>') + '</i>' AS XML);
    INSERT INTO @t (IdUnidad) SELECT DISTINCT n.value('.', 'INT') FROM @x.nodes('/i') AS q(n);

    IF NOT EXISTS (SELECT 1 FROM @t)
        THROW 50421, 'No se indicó ninguna unidad para mover.', 1;
    IF EXISTS (SELECT 1 FROM @t t WHERE NOT EXISTS (SELECT 1 FROM dbo.UnidadesActivo u WHERE u.IdUnidad = t.IdUnidad))
        THROW 50422, 'Alguna de las unidades ya no existe.', 1;
    IF EXISTS (SELECT 1 FROM dbo.Prestamos p JOIN @t t ON t.IdUnidad = p.IdUnidad WHERE p.Estado = 'Activo')
        THROW 50423, 'Alguna de las unidades está prestada. Registre su devolución antes de moverla.', 1;

    DECLARE @mov TABLE (IdUnidad INT);
    UPDATE u SET IdSalon = @IdSalonDestino
    OUTPUT inserted.IdUnidad INTO @mov (IdUnidad)
    FROM dbo.UnidadesActivo u
    JOIN @t t ON t.IdUnidad = u.IdUnidad
    WHERE u.IdSalon <> @IdSalonDestino;

    SELECT COUNT(*) AS Movidas FROM @mov;
END;
GO

-- Quitar unidades (solo las que no tienen historial de prestamos, mantenimientos ni reportes)
CREATE OR ALTER PROCEDURE dbo.sp_QuitarUnidades
    @Ids VARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;

    DECLARE @t TABLE (IdUnidad INT PRIMARY KEY);
    DECLARE @x XML = CAST('<i>' + REPLACE(ISNULL(@Ids, ''), ',', '</i><i>') + '</i>' AS XML);
    INSERT INTO @t (IdUnidad) SELECT DISTINCT n.value('.', 'INT') FROM @x.nodes('/i') AS q(n);

    IF NOT EXISTS (SELECT 1 FROM @t)
        THROW 50430, 'No se indicó ninguna unidad para quitar.', 1;

    DECLARE @total INT = (SELECT COUNT(*) FROM @t);
    DECLARE @del TABLE (IdUnidad INT);

    DELETE u
    OUTPUT deleted.IdUnidad INTO @del (IdUnidad)
    FROM dbo.UnidadesActivo u
    JOIN @t t ON t.IdUnidad = u.IdUnidad
    WHERE NOT EXISTS (SELECT 1 FROM dbo.Prestamos p            WHERE p.IdUnidad = u.IdUnidad)
      AND NOT EXISTS (SELECT 1 FROM dbo.MantenimientosActivo m WHERE m.IdUnidad = u.IdUnidad)
      AND NOT EXISTS (SELECT 1 FROM dbo.ReportesDanio r        WHERE r.IdUnidad = u.IdUnidad);

    DECLARE @quitadas INT = (SELECT COUNT(*) FROM @del);
    SELECT @quitadas AS Quitadas, @total - @quitadas AS ConHistorial;
END;
GO

-- ---------- Salones ----------
CREATE OR ALTER PROCEDURE dbo.sp_GuardarSalon
    @IdSalon       INT          = NULL,
    @NombreSalon   VARCHAR(100),
    @Tipo          VARCHAR(30),
    @Capacidad     INT          = NULL,
    @Edificio      VARCHAR(100) = NULL,
    @IdResponsable INT          = NULL,
    @Observacion   VARCHAR(300) = NULL
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;
    SET @NombreSalon = LTRIM(RTRIM(ISNULL(@NombreSalon, '')));

    IF LEN(@NombreSalon) < 3
        THROW 50400, 'El nombre del salón es obligatorio (mínimo 3 caracteres).', 1;
    IF @Tipo IS NULL OR @Tipo NOT IN ('Aula','Laboratorio','Biblioteca','Oficina','Bodega','Auditorio','Otro')
        THROW 50401, 'Seleccione un tipo de salón válido.', 1;
    IF @Capacidad IS NOT NULL AND (@Capacidad < 1 OR @Capacidad > 500)
        THROW 50402, 'La capacidad debe estar entre 1 y 500 personas.', 1;
    IF @IdResponsable IS NOT NULL
       AND NOT EXISTS (SELECT 1 FROM dbo.Empleados WHERE IdEmpleado = @IdResponsable AND IdEstado <> 2)
        THROW 50403, 'El responsable no existe o está inactivo.', 1;
    IF EXISTS (SELECT 1 FROM dbo.Salones
               WHERE LOWER(NombreSalon) = LOWER(@NombreSalon) AND (@IdSalon IS NULL OR IdSalon <> @IdSalon))
        THROW 50404, 'Ya existe un salón con ese nombre.', 1;

    IF @IdSalon IS NULL
    BEGIN
        BEGIN TRANSACTION;
        SELECT @IdSalon = ISNULL(MAX(IdSalon), 0) + 1 FROM dbo.Salones WITH (UPDLOCK, HOLDLOCK);
        INSERT INTO dbo.Salones (IdSalon, NombreSalon, Tipo, Capacidad, Edificio, IdResponsable, Observacion, Activo)
        VALUES (@IdSalon, @NombreSalon, @Tipo, @Capacidad, @Edificio, @IdResponsable, @Observacion, 1);
        COMMIT TRANSACTION;
    END
    ELSE
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM dbo.Salones WHERE IdSalon = @IdSalon)
            THROW 50405, 'El salón no existe.', 1;
        UPDATE dbo.Salones
        SET NombreSalon = @NombreSalon, Tipo = @Tipo, Capacidad = @Capacidad, Edificio = @Edificio,
            IdResponsable = @IdResponsable, Observacion = @Observacion
        WHERE IdSalon = @IdSalon;
    END

    SELECT @IdSalon AS IdSalon;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_CambiarEstadoSalon
    @IdSalon INT, @Activo BIT
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM dbo.Salones WHERE IdSalon = @IdSalon)
        THROW 50410, 'El salón no existe.', 1;

    IF @Activo = 0
    BEGIN
        DECLARE @n INT = (SELECT COUNT(*) FROM dbo.UnidadesActivo WHERE IdSalon = @IdSalon);
        IF @n > 0
        BEGIN
            DECLARE @msg NVARCHAR(250) = 'El salón todavía tiene ' + CAST(@n AS VARCHAR(10)) +
                ' equipo(s). Muévalos a otro salón antes de desactivarlo.';
            THROW 50411, @msg, 1;
        END
    END

    UPDATE dbo.Salones SET Activo = @Activo WHERE IdSalon = @IdSalon;
END;
GO

-- ---------- Prestamos, devoluciones y mantenimiento (sobre UNA unidad) ----------
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

-- Devolucion: cierra el prestamo y actualiza SOLO el estado de esa unidad
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

-- Mantenimiento: cambia el estado de la unidad atendida y cierra el reporte de dano (si hay)
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

-- ---------- Consumibles ----------
CREATE OR ALTER PROCEDURE dbo.sp_RegistrarMovimientoConsumible
    @IdConsumible INT, @Tipo VARCHAR(10), @Cantidad INT, @Motivo VARCHAR(40),
    @Destino VARCHAR(100) = NULL, @Usuario VARCHAR(50), @IdSalon INT = NULL
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;
    BEGIN TRY
        IF @Tipo NOT IN ('Entrada', 'Salida')
            THROW 50040, 'El tipo de movimiento debe ser Entrada o Salida.', 1;
        IF @Cantidad IS NULL OR @Cantidad <= 0
            THROW 50041, 'La cantidad debe ser mayor que cero.', 1;
        IF @Tipo <> 'Salida' SET @IdSalon = NULL;

        BEGIN TRANSACTION;
        DECLARE @Stock INT;
        SELECT @Stock = StockActual FROM dbo.Consumibles WITH (UPDLOCK, HOLDLOCK)
        WHERE IdConsumible = @IdConsumible;
        IF @Stock IS NULL
            THROW 50042, 'El consumible no existe.', 1;
        IF @Tipo = 'Salida' AND @Cantidad > @Stock
            THROW 50043, 'Stock insuficiente: no se puede despachar más de lo que hay.', 1;

        DECLARE @Nuevo INT = CASE WHEN @Tipo = 'Entrada' THEN @Stock + @Cantidad ELSE @Stock - @Cantidad END;
        UPDATE dbo.Consumibles SET StockActual = @Nuevo WHERE IdConsumible = @IdConsumible;
        INSERT INTO dbo.MovimientosConsumible
            (IdConsumible, Tipo, Cantidad, Motivo, Destino, SaldoResultante, Usuario, IdSalon)
        VALUES (@IdConsumible, @Tipo, @Cantidad, @Motivo, @Destino, @Nuevo, @Usuario, @IdSalon);
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- ---------- Asignaciones academicas ----------
CREATE OR ALTER PROCEDURE dbo.sp_AsignarDocente
    @IdEmpleado INT, @IdSeccion INT, @AnioLectivo INT, @Horas INT
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;
    BEGIN TRY
        IF @Horas IS NULL OR @Horas < 1
            THROW 50200, 'Las horas semanales deben ser al menos 1.', 1;
        IF NOT EXISTS (SELECT 1 FROM dbo.Empleados e JOIN dbo.Cargos c ON c.IdCargo = e.IdCargo
                       WHERE e.IdEmpleado = @IdEmpleado AND LOWER(c.NombreCargo) LIKE 'docente%')
            THROW 50201, 'El empleado seleccionado no es docente.', 1;
        IF NOT EXISTS (SELECT 1 FROM dbo.Secciones WHERE IdSeccion = @IdSeccion)
            THROW 50202, 'La sección seleccionada no existe.', 1;

        BEGIN TRANSACTION;

        IF EXISTS (SELECT 1 FROM dbo.AsignacionesDocente WITH (UPDLOCK, HOLDLOCK)
                   WHERE IdEmpleado = @IdEmpleado AND IdSeccion = @IdSeccion AND AnioLectivo = @AnioLectivo)
            THROW 50203, 'Ese docente ya tiene asignado ese grupo en el año lectivo seleccionado.', 1;

        DECLARE @Actual INT = ISNULL((SELECT SUM(HorasSemanales) FROM dbo.AsignacionesDocente
                                      WHERE IdEmpleado = @IdEmpleado AND AnioLectivo = @AnioLectivo), 0);
        IF @Actual + @Horas > 40
        BEGIN
            DECLARE @Msg NVARCHAR(200) = CONCAT(N'Supera el máximo de 40 horas semanales: el docente ya tiene ',
                                                @Actual, N' h asignadas.');
            THROW 50204, @Msg, 1;
        END

        INSERT INTO dbo.AsignacionesDocente (IdEmpleado, IdSeccion, AnioLectivo, HorasSemanales)
        VALUES (@IdEmpleado, @IdSeccion, @AnioLectivo, @Horas);
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- ---------- Pagos de planilla ----------
CREATE OR ALTER PROCEDURE dbo.sp_RegistrarPago
    @IdPago      INT           = NULL,
    @IdEmpleado  INT,
    @Periodo     DATE,
    @SalarioBase DECIMAL(10,2),
    @Bono        DECIMAL(10,2) = 0,
    @Descuento   DECIMAL(10,2) = 0,
    @EstadoPago  VARCHAR(20)   = 'Pendiente',
    @Observacion VARCHAR(200)  = NULL
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;
    SET @Periodo = DATEFROMPARTS(YEAR(@Periodo), MONTH(@Periodo), 1);

    IF NOT EXISTS (SELECT 1 FROM dbo.Empleados WHERE IdEmpleado = @IdEmpleado AND (IdEstado <> 2 OR @IdPago IS NOT NULL))
        THROW 50300, 'El empleado no existe o está inactivo.', 1;
    IF @SalarioBase IS NULL OR @SalarioBase <= 0
        THROW 50301, 'El salario base debe ser mayor que cero.', 1;
    IF @Bono < 0 OR @Descuento < 0
        THROW 50302, 'El bono y el descuento no pueden ser negativos.', 1;
    IF @Descuento > @SalarioBase + @Bono
        THROW 50303, 'El descuento no puede superar el salario base más el bono.', 1;
    IF @EstadoPago NOT IN ('Pendiente', 'Pagado')
        THROW 50304, 'El estado de pago debe ser Pendiente o Pagado.', 1;
    IF @Periodo > DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1)
        THROW 50305, 'No se pueden registrar pagos de períodos futuros.', 1;
    IF EXISTS (SELECT 1 FROM dbo.PagosPlanilla
               WHERE IdEmpleado = @IdEmpleado AND Periodo = @Periodo AND Anulado = 0
                 AND (@IdPago IS NULL OR IdPago <> @IdPago))
        THROW 50306, 'Ese empleado ya tiene un pago registrado en ese período.', 1;

    IF @IdPago IS NULL
    BEGIN
        INSERT INTO dbo.PagosPlanilla (IdEmpleado, Periodo, SalarioBase, Bono, Descuento, EstadoPago, FechaPago, Observacion)
        VALUES (@IdEmpleado, @Periodo, @SalarioBase, @Bono, @Descuento, @EstadoPago,
                CASE WHEN @EstadoPago = 'Pagado' THEN GETDATE() END, @Observacion);
    END
    ELSE
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM dbo.PagosPlanilla WHERE IdPago = @IdPago AND Anulado = 0)
            THROW 50307, 'El pago no existe o ya fue anulado.', 1;
        IF EXISTS (SELECT 1 FROM dbo.PagosPlanilla WHERE IdPago = @IdPago AND EstadoPago = 'Pagado')
            THROW 50308, 'Un pago ya pagado no se puede modificar. Anúlelo y regístrelo de nuevo.', 1;

        UPDATE dbo.PagosPlanilla
        SET IdEmpleado = @IdEmpleado, Periodo = @Periodo, SalarioBase = @SalarioBase, Bono = @Bono,
            Descuento = @Descuento, EstadoPago = @EstadoPago,
            FechaPago = CASE WHEN @EstadoPago = 'Pagado' THEN GETDATE() END,
            Observacion = @Observacion
        WHERE IdPago = @IdPago;
    END
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_MarcarPagado @IdPago INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.PagosPlanilla SET EstadoPago = 'Pagado', FechaPago = GETDATE()
    WHERE IdPago = @IdPago AND Anulado = 0 AND EstadoPago = 'Pendiente';
    IF @@ROWCOUNT = 0
        THROW 50309, 'El pago no existe, está anulado o ya estaba pagado.', 1;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_AnularPago @IdPago INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.PagosPlanilla SET Anulado = 1 WHERE IdPago = @IdPago AND Anulado = 0;
    IF @@ROWCOUNT = 0
        THROW 50310, 'El pago no existe o ya estaba anulado.', 1;
END;
GO

/* =====================================================================
   11. DATOS INICIALES (solo si la tabla esta vacia)
   Se conserva el orden original: el programa usa estos numeros
   (EstadosEmpleado: 1 = Activo, 2 = Inactivo; Cargos: 1 = Director, 2 = Subdirectora).
   ===================================================================== */
IF NOT EXISTS (SELECT 1 FROM dbo.Roles)
    INSERT INTO dbo.Roles (NombreRol) VALUES ('Administrador'), ('Empleado');

IF NOT EXISTS (SELECT 1 FROM dbo.Estados)
    INSERT INTO dbo.Estados (NombreEstado)
    VALUES ('Regular'), ('Bueno'), ('Excelente'), ('Mantenimiento Pendiente'), ('Nuevo'),
           ('Malo'), ('En reparación'), ('Dado de baja');

IF NOT EXISTS (SELECT 1 FROM dbo.EstadosEmpleado)
    INSERT INTO dbo.EstadosEmpleado (NombreEstado) VALUES ('Activo'), ('Inactivo');

IF NOT EXISTS (SELECT 1 FROM dbo.Categorias)
    INSERT INTO dbo.Categorias (NombreCategoria, RequiereSerial)
    VALUES ('Mobiliario Escolar', 0), ('Equipo Audiovisual', 1), ('Equipo de Red', 1),
           ('Equipo Informático', 1), ('Infraestructura', 0), ('Equipo de Seguridad', 0),
           ('Limpieza', 0), ('Material Escolar', 0);

IF NOT EXISTS (SELECT 1 FROM dbo.Cargos)
    INSERT INTO dbo.Cargos (NombreCargo)
    VALUES ('Director'), ('Subdirectora'), ('Docente de Sistemas'), ('Docente de Matemáticas'),
           ('Docente de Física'), ('Secretaria Administrativa'), ('Técnico de Laboratorio'),
           ('Bibliotecaria'), ('Conserje'), ('Orientadora'), ('Contador'), ('Docente de Inglés'),
           ('Técnico de Soporte'), ('Enfermera'), ('Jefe de Seguridad'), ('Docente de Natacion'),
           ('Recepcionista'), ('Docente de Ciencias'), ('Encargado de Limpieza'),
           ('Psicóloga Escolar'), ('Coordinador Académico'), ('Docente de Sociales'),
           ('Chofer'), ('Asistente Contable'), ('Docente de Educación Física');

IF NOT EXISTS (SELECT 1 FROM dbo.Grados)
    INSERT INTO dbo.Grados (NombreGrado, Orden)
    VALUES (N'Séptimo grado', 1), (N'Octavo grado', 2), (N'Noveno grado', 3),
           (N'Primer año de bachillerato', 4), (N'Segundo año de bachillerato', 5),
           (N'Tercer año de bachillerato', 6);

IF NOT EXISTS (SELECT 1 FROM dbo.Secciones)
BEGIN
    INSERT INTO dbo.Secciones (IdGrado, NombreSeccion)
    SELECT g.IdGrado, s.n
    FROM dbo.Grados g
    JOIN (VALUES (N'A'), (N'B'), (N'C')) s(n) ON g.Orden IN (1, 2, 3);

    INSERT INTO dbo.Secciones (IdGrado, NombreSeccion)
    SELECT g.IdGrado, s.n
    FROM dbo.Grados g
    JOIN (VALUES (N'A1'), (N'A2'), (N'A3'), (N'A4'), (N'A5'),
                 (N'B1'), (N'B2'), (N'B3'), (N'B4')) s(n) ON g.Orden IN (4, 5, 6);
END

-- La bodega donde entra todo el equipo nuevo (ver sp_AltaUnidades)
IF NOT EXISTS (SELECT 1 FROM dbo.Salones WHERE Tipo = 'Bodega')
    INSERT INTO dbo.Salones (IdSalon, NombreSalon, Tipo)
    SELECT ISNULL((SELECT MAX(IdSalon) FROM dbo.Salones), 0) + 1, 'Bodega central', 'Bodega'
    WHERE NOT EXISTS (SELECT 1 FROM dbo.Salones WHERE NombreSalon = 'Bodega central');
GO

/* ---------------------------------------------------------------------
   OPCIONAL: usuario administrador por defecto.
   NO es necesario: al abrir el programa por primera vez, el asistente de
   configuracion crea la empresa y el administrador con la clave que elijas.
   Si prefieres crearlo aqui, usa un hash generado con tu aplicacion
   (nunca una clave en texto plano) y quita los comentarios:

   INSERT INTO dbo.Usuarios (Usuario, Clave, IdRol, Correo)
   SELECT 'admin', '<hash bcrypt>', IdRol, 'correo@ejemplo.com'
   FROM dbo.Roles WHERE NombreRol = 'Administrador'
     AND NOT EXISTS (SELECT 1 FROM dbo.Usuarios WHERE Usuario = 'admin');
   --------------------------------------------------------------------- */

/* =====================================================================
   12. VERIFICACION
   ===================================================================== */
SELECT 'Tablas'         AS Objeto, COUNT(*) AS Total FROM sys.tables
UNION ALL SELECT 'Vistas',         COUNT(*) FROM sys.views
UNION ALL SELECT 'Procedimientos', COUNT(*) FROM sys.procedures
UNION ALL SELECT 'Triggers',       COUNT(*) FROM sys.triggers
UNION ALL SELECT 'Funciones',      COUNT(*) FROM sys.objects WHERE type = 'FN';

SELECT dbo.fn_IdBodega() AS IdBodega,
       (SELECT NombreSalon FROM dbo.Salones WHERE IdSalon = dbo.fn_IdBodega()) AS Bodega;
GO
