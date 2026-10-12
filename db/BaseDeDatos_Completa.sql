/* =====================================================================
   SISTEMA DE GESTION ADMINISTRATIVA Y ESCOLAR
   Base de datos: Gestion_administrativa_y_escolar
   SCRIPT COMPLETO Y FINAL  -  estructura, logica y datos de ejemplo
   =====================================================================

   Este unico archivo contiene TODA la base de datos:

     1. Base de datos
     2. Tablas (30), llaves, restricciones e indices
     3. Funciones (6)
     4. Vistas (27)
     5. Procedimientos almacenados (34)
     6. Triggers (20): historial de cambios y registro de actividad
     7. Datos iniciales (roles, estados, estados de empleado, categorias,
        cargos, grados, secciones y bodega)
     8. Datos de ejemplo de la institucion: 50 empleados, 5 estructuras
        salariales, 13 salones (mas la bodega), 31 tipos de equipo,
        692 unidades fisicas y 4 reportes de dano abiertos
     9. Verificacion
    10. Anexo: codigos de error (THROW) de cada procedimiento

   COMO USARLO
   - Abrelo en SQL Server Management Studio y presiona F5 (ejecutar todo).
   - Funciona en SQL Server 2017 o superior (incluido LocalDB 2017+).
   - Si lo ejecutas con sqlcmd usa:
       sqlcmd -S (localdb)\MSSQLLocalDB -E -I -f 65001 -i BaseDeDatos_Completa.sql
     (-I activa QUOTED_IDENTIFIER, que exigen los indices filtrados; el script
      tambien lo activa en su primer lote, asi que -I es una precaucion extra;
      -f 65001 lee el archivo como UTF-8).
   - Lo recomendado es ejecutarlo donde la base NO exista (instalacion limpia).
   - Tambien se puede volver a ejecutar sobre una base ya creada: no borra
     datos (la instalacion no ejecuta DELETE ni TRUNCATE; los DROP son solo de
     tablas temporales). Cada tabla se crea solo si no existe; vistas,
     funciones, procedimientos y triggers usan CREATE OR ALTER. Los datos de
     la seccion 7 se insertan solo si su tabla esta vacia (la bodega, solo si
     no hay un salon de tipo Bodega); los de la seccion 8, solo si faltan:
     empleados, salones y tipos de equipo por nombre, estructuras salariales
     por importes, y unidades y reportes solo si no existe ninguna unidad.
   - Si NO quieres los datos de ejemplo, ejecuta el script solo hasta la
     seccion 7 (antes de "8. DATOS DE EJEMPLO DE LA INSTITUCION").
   - La primera vez que se abre el programa, el asistente de configuracion
     pide los datos de la institucion y crea el usuario administrador
     (la clave se guarda como hash BCrypt). Por eso este script NO crea
     usuarios ni claves.

   REGLAS DE NEGOCIO QUE VIVEN EN LA BASE DE DATOS (no dependen de la pantalla)
   - Cada unidad fisica tiene su propio estado, codigo, ubicacion, costo y
     proveedor.
   - Dar de baja con sp_CambiarEstadoUnidades exige un motivo (minimo 5
     caracteres), deja fecha y motivo en la unidad, no se permite si la
     unidad esta prestada y ese procedimiento no revierte una baja. Es el
     unico camino con todas estas garantias: sp_RegistrarMantenimiento,
     sp_RegistrarDevolucion o un UPDATE directo pueden dejar o sacar una
     unidad de "Dado de baja" sin ellas.
   - Una unidad no puede tener dos prestamos activos ni dos reportes abiertos.
   - Prestamos a Docente / Personal administrativo apuntan a un empleado real.
   - Un solo pago vigente por empleado y mes; un mes cerrado no admite
     cambios en pagos ni en ausencias.
   - El descuento por ausencias usa los dias habiles del mes.
   - El registro de actividad (tabla Auditoria) no admite UPDATE ni DELETE
     (trigger INSTEAD OF) y sus triggers guardan el usuario del sistema
     (SESSION_CONTEXT 'Usuario', que la aplicacion fija al conectarse), no
     el login de Windows.
   ===================================================================== */

/* =====================================================================
   1. BASE DE DATOS
   ===================================================================== */
SET QUOTED_IDENTIFIER ON;
SET ANSI_NULLS ON;
SET ANSI_PADDING ON;
SET ANSI_WARNINGS ON;
SET ARITHABORT ON;
SET CONCAT_NULL_YIELDS_NULL ON;
SET NUMERIC_ROUNDABORT OFF;
SET NOCOUNT ON;
GO

IF DB_ID(N'Gestion_administrativa_y_escolar') IS NULL
    CREATE DATABASE Gestion_administrativa_y_escolar;
GO

USE Gestion_administrativa_y_escolar;
GO

-- Guardia: si la base no se pudo crear o abrir (archivo .mdf huerfano en LocalDB, falta de permisos...),
-- el USE anterior falla y SSMS seguiria ejecutando los lotes siguientes en otra base (normalmente master).
-- Con NOEXEC ON el resto del script solo se compila y NO se ejecuta; se desactiva al final del script.
IF DB_NAME() <> N'Gestion_administrativa_y_escolar'
BEGIN
    PRINT N'*** No se pudo crear o abrir la base Gestion_administrativa_y_escolar. Se cancela el resto del script: no se ejecutara nada mas. ***';
    SET NOEXEC ON;
END
GO

/* =====================================================================
   2. TABLAS, LLAVES, RESTRICCIONES E INDICES
   ===================================================================== */
-- Roles de acceso al sistema (Administrador / Empleado).
IF OBJECT_ID(N'dbo.Roles', 'U') IS NULL
CREATE TABLE dbo.Roles (
    IdRol              INT IDENTITY(1,1) NOT NULL,
    NombreRol          VARCHAR(50) NOT NULL,
    CONSTRAINT PK_Roles PRIMARY KEY (IdRol)
);
GO

-- Estados fisicos de una unidad de activo (Nuevo, Bueno, Dado de baja...).
IF OBJECT_ID(N'dbo.Estados', 'U') IS NULL
CREATE TABLE dbo.Estados (
    IdEstado           INT IDENTITY(1,1) NOT NULL,
    NombreEstado       VARCHAR(200) NULL,
    CONSTRAINT PK_Estados PRIMARY KEY (IdEstado)
);
GO

-- Categorias del catalogo de activos. RequiereSerial = se identifica por numero de serie.
IF OBJECT_ID(N'dbo.Categorias', 'U') IS NULL
CREATE TABLE dbo.Categorias (
    IdCategoria        INT IDENTITY(1,1) NOT NULL,
    NombreCategoria    VARCHAR(100) NULL,
    RequiereSerial     BIT NULL CONSTRAINT DF_Categorias_RequiereSerial DEFAULT 0,
    CONSTRAINT PK_Categorias PRIMARY KEY (IdCategoria)
);
GO

-- Cargos del personal (Director, Docente de ..., Conserje...).
IF OBJECT_ID(N'dbo.Cargos', 'U') IS NULL
CREATE TABLE dbo.Cargos (
    IdCargo            INT IDENTITY(1,1) NOT NULL,
    NombreCargo        VARCHAR(100) NULL,
    CONSTRAINT PK_Cargos PRIMARY KEY (IdCargo)
);
GO

-- Estado laboral del empleado: 1 = Activo, 2 = Inactivo (el programa usa estos numeros).
IF OBJECT_ID(N'dbo.EstadosEmpleado', 'U') IS NULL
CREATE TABLE dbo.EstadosEmpleado (
    IdEstado           INT IDENTITY(1,1) NOT NULL,
    NombreEstado       VARCHAR(100) NULL,
    CONSTRAINT PK_EstadosEmpleado PRIMARY KEY (IdEstado)
);
GO

-- Catalogo de salarios: cada fila es una estructura salarial (base, descuento, bono, neto).
IF OBJECT_ID(N'dbo.Planillas', 'U') IS NULL
CREATE TABLE dbo.Planillas (
    IdPlanilla         INT IDENTITY(1,1) NOT NULL,
    SalarioBase        DECIMAL(10,2) NOT NULL,
    Descuento          DECIMAL(10,2) NOT NULL CONSTRAINT DF_Planillas_Descuento DEFAULT 0,
    Bono               DECIMAL(10,2) NOT NULL CONSTRAINT DF_Planillas_Bono DEFAULT 0,
    SalarioNeto        DECIMAL(10,2) NOT NULL,
    Estado             BIT NOT NULL CONSTRAINT DF_Planillas_Estado DEFAULT 1,
    CONSTRAINT PK_Planillas PRIMARY KEY (IdPlanilla)
);
GO

-- Personal de la institucion (docente y administrativo). El nombre es unico.
IF OBJECT_ID(N'dbo.Empleados', 'U') IS NULL
CREATE TABLE dbo.Empleados (
    IdEmpleado         INT IDENTITY(1,1) NOT NULL,
    Nombre             VARCHAR(200) NOT NULL,
    FechaContratacion  DATE NULL,
    IdCargo            INT NULL,
    IdEstado           INT NULL,
    IdPlanilla         INT NULL,
    FechaNacimiento    DATE NULL,
    EstadoCivil        VARCHAR(50) NULL,
    Religion           VARCHAR(50) NULL,
    Telefono           VARCHAR(20) NULL,
    Correo             VARCHAR(100) NULL,
    Direccion          VARCHAR(255) NULL,
    DUI                VARCHAR(10) NULL,
    ContactoEmergenciaNombre VARCHAR(100) NULL,
    ContactoEmergenciaParentesco VARCHAR(50) NULL,
    ContactoEmergenciaTelefono VARCHAR(20) NULL,
    Especialidad       VARCHAR(150) NULL,
    CONSTRAINT PK_Empleados PRIMARY KEY (IdEmpleado),
    CONSTRAINT UQ_Empleados_Nombre UNIQUE (Nombre),
    CONSTRAINT FK_Empleados_Cargo FOREIGN KEY (IdCargo) REFERENCES dbo.Cargos(IdCargo),
    CONSTRAINT FK_Empleados_Estado FOREIGN KEY (IdEstado) REFERENCES dbo.EstadosEmpleado(IdEstado),
    CONSTRAINT FK_Empleados_Planilla FOREIGN KEY (IdPlanilla) REFERENCES dbo.Planillas(IdPlanilla),
    CONSTRAINT CK_Empleados_DUI CHECK ([DUI] IS NULL OR [DUI] like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]-[0-9]')
);
GO
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'UX_Empleados_DUI' AND object_id = OBJECT_ID(N'dbo.Empleados'))
    CREATE UNIQUE INDEX UX_Empleados_DUI ON dbo.Empleados (DUI) WHERE ([DUI] IS NOT NULL);
GO

-- Cuentas de acceso al sistema. La clave se guarda como hash BCrypt, nunca en texto plano.
IF OBJECT_ID(N'dbo.Usuarios', 'U') IS NULL
CREATE TABLE dbo.Usuarios (
    IdUsuario          INT IDENTITY(1,1) NOT NULL,
    Usuario            VARCHAR(50) NOT NULL,
    Clave              VARCHAR(255) NOT NULL,
    IdRol              INT NOT NULL,
    Correo             VARCHAR(100) NULL,
    CorreoVerificado   BIT NOT NULL CONSTRAINT DF_Usuarios_CorreoVerificado DEFAULT 0,
    Activo             BIT NOT NULL CONSTRAINT DF_Usuarios_Activo DEFAULT 1,
    NombreCompleto     NVARCHAR(100) NULL,
    DebeCambiarClave   BIT NOT NULL CONSTRAINT DF_Usuarios_DebeCambiarClave DEFAULT 0,
    FechaCreacion      DATETIME NOT NULL CONSTRAINT DF_Usuarios_FechaCreacion DEFAULT GETDATE(),
    CreadoPor          NVARCHAR(50) NULL,
    UltimoAcceso       DATETIME NULL,
    CONSTRAINT PK_Usuarios PRIMARY KEY (IdUsuario),
    CONSTRAINT UQ_Usuarios_Usuario UNIQUE (Usuario),
    CONSTRAINT FK_Usuarios_Rol FOREIGN KEY (IdRol) REFERENCES dbo.Roles(IdRol)
);
GO

-- Salones y espacios fisicos. IdSalon se asigna con MAX+1 (sp_GuardarSalon). La Bodega es el salon de tipo Bodega.
IF OBJECT_ID(N'dbo.Salones', 'U') IS NULL
CREATE TABLE dbo.Salones (
    IdSalon            INT NOT NULL,
    NombreSalon        VARCHAR(50) NOT NULL,
    Tipo               VARCHAR(30) NULL,
    Capacidad          INT NULL,
    Edificio           VARCHAR(100) NULL,
    IdResponsable      INT NULL,
    Activo             BIT NOT NULL CONSTRAINT DF_Salones_Activo DEFAULT 1,
    Observacion        VARCHAR(300) NULL,
    CONSTRAINT PK_Salones PRIMARY KEY (IdSalon),
    CONSTRAINT FK_Salones_Responsable FOREIGN KEY (IdResponsable) REFERENCES dbo.Empleados(IdEmpleado),
    CONSTRAINT CK_Salones_Tipo CHECK ([Tipo] IS NULL OR ([Tipo]='Otro' OR [Tipo]='Auditorio' OR [Tipo]='Bodega' OR [Tipo]='Oficina' OR [Tipo]='Biblioteca' OR [Tipo]='Laboratorio' OR [Tipo]='Aula')),
    CONSTRAINT CK_Salones_Capacidad CHECK ([Capacidad] IS NULL OR [Capacidad]>=(1) AND [Capacidad]<=(500))
);
GO
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'UX_Salones_Nombre' AND object_id = OBJECT_ID(N'dbo.Salones'))
    CREATE UNIQUE INDEX UX_Salones_Nombre ON dbo.Salones (NombreSalon);
GO

-- Catalogo de tipos de activo (Pupitre, Laptop...). Cada pieza fisica es una fila de UnidadesActivo.
IF OBJECT_ID(N'dbo.GestionActivos', 'U') IS NULL
CREATE TABLE dbo.GestionActivos (
    IdActivo           INT NOT NULL,
    Nombre             VARCHAR(100) NOT NULL,
    IdCategoria        INT NULL,
    CodigoInventario   VARCHAR(50) NULL,
    IdUbicacion        INT NULL,
    CONSTRAINT PK_GestionActivos PRIMARY KEY (IdActivo),
    CONSTRAINT FK_GestionActivos_Categoria FOREIGN KEY (IdCategoria) REFERENCES dbo.Categorias(IdCategoria),
    CONSTRAINT FK_GestionActivos_Ubicacion FOREIGN KEY (IdUbicacion) REFERENCES dbo.Salones(IdSalon)
);
GO
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'UX_GestionActivos_Codigo' AND object_id = OBJECT_ID(N'dbo.GestionActivos'))
    CREATE UNIQUE INDEX UX_GestionActivos_Codigo ON dbo.GestionActivos (CodigoInventario) WHERE ([CodigoInventario] IS NOT NULL);
GO

-- Cada unidad fisica con SU estado, codigo, ubicacion, costo, proveedor y datos de baja.
IF OBJECT_ID(N'dbo.UnidadesActivo', 'U') IS NULL
CREATE TABLE dbo.UnidadesActivo (
    IdUnidad           INT IDENTITY(1,1) NOT NULL,
    IdActivo           INT NOT NULL,
    IdSalon            INT NOT NULL,
    CodigoInventario   VARCHAR(50) NULL,
    IdEstado           INT NOT NULL,
    FechaAlta          DATETIME NOT NULL CONSTRAINT DF_UnidadesActivo_FechaAlta DEFAULT GETDATE(),
    Observacion        VARCHAR(300) NULL,
    CostoUnitario      DECIMAL(10,2) NULL,
    FechaAdquisicion   DATE NULL,
    Proveedor          VARCHAR(100) NULL,
    FechaBaja          DATETIME NULL,
    MotivoBaja         VARCHAR(300) NULL,
    CONSTRAINT PK_UnidadesActivo PRIMARY KEY (IdUnidad),
    CONSTRAINT FK_UnidadesActivo_Activo FOREIGN KEY (IdActivo) REFERENCES dbo.GestionActivos(IdActivo) ON DELETE CASCADE,
    CONSTRAINT FK_UnidadesActivo_Salon FOREIGN KEY (IdSalon) REFERENCES dbo.Salones(IdSalon),
    CONSTRAINT FK_UnidadesActivo_Estado FOREIGN KEY (IdEstado) REFERENCES dbo.Estados(IdEstado),
    CONSTRAINT CK_Unidades_Costo CHECK ([CostoUnitario] IS NULL OR [CostoUnitario]>=(0))
);
GO
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'UX_UnidadesActivo_Codigo' AND object_id = OBJECT_ID(N'dbo.UnidadesActivo'))
    CREATE UNIQUE INDEX UX_UnidadesActivo_Codigo ON dbo.UnidadesActivo (CodigoInventario) WHERE ([CodigoInventario] IS NOT NULL);
GO
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_UnidadesActivo_SalonActivo' AND object_id = OBJECT_ID(N'dbo.UnidadesActivo'))
    CREATE INDEX IX_UnidadesActivo_SalonActivo ON dbo.UnidadesActivo (IdSalon, IdActivo) INCLUDE (IdEstado);
GO

-- Historial de cambios de cada unidad (alta, retiro, cambio de estado y traslado).
IF OBJECT_ID(N'dbo.AuditoriaUnidades', 'U') IS NULL
CREATE TABLE dbo.AuditoriaUnidades (
    IdAuditoria        INT IDENTITY(1,1) NOT NULL,
    IdUnidad           INT NULL,
    IdActivo           INT NULL,
    CodigoInventario   VARCHAR(50) NULL,
    Accion             VARCHAR(10) NULL,
    EstadoAnterior     INT NULL,
    EstadoNuevo        INT NULL,
    SalonAnterior      INT NULL,
    SalonNuevo         INT NULL,
    Usuario            SYSNAME NOT NULL CONSTRAINT DF_AuditoriaUnidades_Usuario DEFAULT SUSER_SNAME(),
    Fecha              DATETIME NULL CONSTRAINT DF_AuditoriaUnidades_Fecha DEFAULT GETDATE(),
    CONSTRAINT PK_AuditoriaUnidades PRIMARY KEY (IdAuditoria)
);
GO

-- Historial de cambios del catalogo de equipos (altas, bajas y cambios de nombre).
IF OBJECT_ID(N'dbo.AuditoriaActivos', 'U') IS NULL
CREATE TABLE dbo.AuditoriaActivos (
    IdAuditoria        INT IDENTITY(1,1) NOT NULL,
    IdActivo           INT NULL,
    Accion             VARCHAR(10) NULL,
    NombreAnterior     NVARCHAR(200) NULL,
    NombreNuevo        NVARCHAR(200) NULL,
    Usuario            SYSNAME NOT NULL CONSTRAINT DF_AuditoriaActivos_Usuario DEFAULT SUSER_SNAME(),
    Fecha              DATETIME NULL CONSTRAINT DF_AuditoriaActivos_Fecha DEFAULT GETDATE(),
    CONSTRAINT PK_AuditoriaActivos PRIMARY KEY (IdAuditoria)
);
GO

-- Reportes de dano de una unidad. Una unidad no puede tener dos reportes abiertos a la vez.
IF OBJECT_ID(N'dbo.ReportesDanio', 'U') IS NULL
CREATE TABLE dbo.ReportesDanio (
    IdReporte          INT IDENTITY(1,1) NOT NULL,
    IdSalon            INT NOT NULL,
    IdActivo           INT NOT NULL,
    IdUnidad           INT NULL,
    CodigoInventario   VARCHAR(50) NULL,
    Cantidad           INT NOT NULL CONSTRAINT DF_ReportesDanio_Cantidad DEFAULT 1,
    Prioridad          VARCHAR(10) NOT NULL CONSTRAINT DF_ReportesDanio_Prioridad DEFAULT 'Media',
    Descripcion        VARCHAR(500) NOT NULL,
    ReportadoPor       VARCHAR(50) NOT NULL,
    FechaReporte       DATETIME NOT NULL CONSTRAINT DF_ReportesDanio_FechaReporte DEFAULT GETDATE(),
    Estado             VARCHAR(10) NOT NULL CONSTRAINT DF_ReportesDanio_Estado DEFAULT 'Abierto',
    FechaReparacion    DATETIME NULL,
    ReparadoPor        VARCHAR(50) NULL,
    ObservacionReparacion VARCHAR(500) NULL,
    CONSTRAINT PK_ReportesDanio PRIMARY KEY (IdReporte),
    CONSTRAINT FK_ReportesDanio_Salones FOREIGN KEY (IdSalon) REFERENCES dbo.Salones(IdSalon),
    CONSTRAINT FK_ReportesDanio_Activos FOREIGN KEY (IdActivo) REFERENCES dbo.GestionActivos(IdActivo) ON DELETE CASCADE,
    CONSTRAINT FK_ReportesDanio_Unidad FOREIGN KEY (IdUnidad) REFERENCES dbo.UnidadesActivo(IdUnidad),
    CONSTRAINT CK_ReportesDanio_Cantidad CHECK ([Cantidad]>(0)),
    CONSTRAINT CK_ReportesDanio_Prioridad CHECK ([Prioridad]='Alta' OR [Prioridad]='Media' OR [Prioridad]='Baja'),
    CONSTRAINT CK_ReportesDanio_Descripcion CHECK (len(ltrim(rtrim([Descripcion])))>(0)),
    CONSTRAINT CK_ReportesDanio_Estado CHECK ([Estado]='Reparado' OR [Estado]='Abierto')
);
GO
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'UX_ReportesDanio_UnidadAbierta' AND object_id = OBJECT_ID(N'dbo.ReportesDanio'))
    CREATE UNIQUE INDEX UX_ReportesDanio_UnidadAbierta ON dbo.ReportesDanio (IdUnidad) WHERE ([Estado]='Abierto' AND [IdUnidad] IS NOT NULL);
GO

-- Prestamos de unidades. Docente / Personal administrativo = empleado real (IdEmpleado); Alumno = texto libre.
IF OBJECT_ID(N'dbo.Prestamos', 'U') IS NULL
CREATE TABLE dbo.Prestamos (
    IdPrestamo         INT IDENTITY(1,1) NOT NULL,
    IdActivo           INT NOT NULL,
    IdUnidad           INT NULL,
    CodigoInventario   VARCHAR(50) NULL,
    Cantidad           INT NOT NULL CONSTRAINT DF_Prestamos_Cantidad DEFAULT 1,
    TipoResponsable    VARCHAR(30) NOT NULL,
    Responsable        VARCHAR(100) NOT NULL,
    IdSalonDestino     INT NULL,
    FechaEntrega       DATETIME NOT NULL CONSTRAINT DF_Prestamos_FechaEntrega DEFAULT GETDATE(),
    FechaLimite        DATETIME NOT NULL,
    Estado             VARCHAR(10) NOT NULL CONSTRAINT DF_Prestamos_Estado DEFAULT 'Activo',
    FechaDevolucion    DATETIME NULL,
    IdEstadoDevolucion INT NULL,
    ObservacionSalida  VARCHAR(300) NULL,
    ObservacionDevolucion VARCHAR(300) NULL,
    EntregadoPor       VARCHAR(50) NOT NULL,
    IdEmpleado         INT NULL,
    CONSTRAINT PK_Prestamos PRIMARY KEY (IdPrestamo),
    CONSTRAINT FK_Prestamos_Activos FOREIGN KEY (IdActivo) REFERENCES dbo.GestionActivos(IdActivo),
    CONSTRAINT FK_Prestamos_Unidad FOREIGN KEY (IdUnidad) REFERENCES dbo.UnidadesActivo(IdUnidad),
    CONSTRAINT FK_Prestamos_Salon FOREIGN KEY (IdSalonDestino) REFERENCES dbo.Salones(IdSalon),
    CONSTRAINT FK_Prestamos_EstadoDev FOREIGN KEY (IdEstadoDevolucion) REFERENCES dbo.Estados(IdEstado),
    CONSTRAINT FK_Prestamos_Empleado FOREIGN KEY (IdEmpleado) REFERENCES dbo.Empleados(IdEmpleado),
    CONSTRAINT CK_Prestamos_Estado CHECK ([Estado]='Devuelto' OR [Estado]='Activo'),
    CONSTRAINT CK_Prestamos_Cant CHECK ([Cantidad]>(0)),
    CONSTRAINT CK_Prestamos_Tipo CHECK ([TipoResponsable]='Personal administrativo' OR [TipoResponsable]='Alumno' OR [TipoResponsable]='Docente')
);
GO
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'UX_Prestamos_UnidadActiva' AND object_id = OBJECT_ID(N'dbo.Prestamos'))
    CREATE UNIQUE INDEX UX_Prestamos_UnidadActiva ON dbo.Prestamos (IdUnidad) WHERE ([Estado]='Activo' AND [IdUnidad] IS NOT NULL);
GO

-- Mantenimientos preventivos y correctivos de una unidad, con costo y estado resultante.
IF OBJECT_ID(N'dbo.MantenimientosActivo', 'U') IS NULL
CREATE TABLE dbo.MantenimientosActivo (
    IdMantenimiento    INT IDENTITY(1,1) NOT NULL,
    IdActivo           INT NOT NULL,
    IdUnidad           INT NULL,
    CodigoInventario   VARCHAR(50) NULL,
    Fecha              DATETIME NOT NULL CONSTRAINT DF_MantenimientosActivo_Fecha DEFAULT GETDATE(),
    Tipo               VARCHAR(12) NOT NULL,
    Descripcion        VARCHAR(500) NOT NULL,
    Costo              DECIMAL(10,2) NOT NULL CONSTRAINT DF_MantenimientosActivo_Costo DEFAULT 0,
    IdEstadoResultante INT NOT NULL,
    IdReporte          INT NULL,
    RealizadoPor       VARCHAR(50) NOT NULL,
    CONSTRAINT PK_Mantenimientos PRIMARY KEY (IdMantenimiento),
    CONSTRAINT FK_Mant_Activo FOREIGN KEY (IdActivo) REFERENCES dbo.GestionActivos(IdActivo),
    CONSTRAINT FK_Mant_Unidad FOREIGN KEY (IdUnidad) REFERENCES dbo.UnidadesActivo(IdUnidad),
    CONSTRAINT FK_Mant_Estado FOREIGN KEY (IdEstadoResultante) REFERENCES dbo.Estados(IdEstado),
    CONSTRAINT FK_Mant_Reporte FOREIGN KEY (IdReporte) REFERENCES dbo.ReportesDanio(IdReporte),
    CONSTRAINT CK_Mant_Tipo CHECK ([Tipo]='Correctivo' OR [Tipo]='Preventivo'),
    CONSTRAINT CK_Mant_Costo CHECK ([Costo]>=(0))
);
GO

-- Materiales consumibles (papel, marcadores...) con stock actual y minimo.
IF OBJECT_ID(N'dbo.Consumibles', 'U') IS NULL
CREATE TABLE dbo.Consumibles (
    IdConsumible       INT IDENTITY(1,1) NOT NULL,
    Nombre             VARCHAR(100) NOT NULL,
    Unidad             VARCHAR(30) NOT NULL CONSTRAINT DF_Consumibles_Unidad DEFAULT 'Unidad',
    StockActual        INT NOT NULL CONSTRAINT DF_Consumibles_StockActual DEFAULT 0,
    StockMinimo        INT NOT NULL CONSTRAINT DF_Consumibles_StockMinimo DEFAULT 0,
    CONSTRAINT PK_Consumibles PRIMARY KEY (IdConsumible),
    CONSTRAINT UQ_Consumibles_Nombre UNIQUE (Nombre),
    CONSTRAINT CK_Consumibles_Min CHECK ([StockMinimo]>=(0)),
    CONSTRAINT CK_Consumibles_Stock CHECK ([StockActual]>=(0))
);
GO

-- Kardex: entradas y salidas de consumibles.
IF OBJECT_ID(N'dbo.MovimientosConsumible', 'U') IS NULL
CREATE TABLE dbo.MovimientosConsumible (
    IdMovimiento       INT IDENTITY(1,1) NOT NULL,
    IdConsumible       INT NOT NULL,
    Tipo               VARCHAR(10) NOT NULL,
    Cantidad           INT NOT NULL,
    Motivo             VARCHAR(40) NOT NULL,
    Destino            VARCHAR(100) NULL,
    SaldoResultante    INT NOT NULL,
    Fecha              DATETIME NOT NULL CONSTRAINT DF_MovimientosConsumible_Fecha DEFAULT GETDATE(),
    Usuario            VARCHAR(50) NOT NULL,
    IdSalon            INT NULL,
    CONSTRAINT PK_MovCons PRIMARY KEY (IdMovimiento),
    CONSTRAINT FK_MovCons_Cons FOREIGN KEY (IdConsumible) REFERENCES dbo.Consumibles(IdConsumible),
    CONSTRAINT FK_MovCons_Salon FOREIGN KEY (IdSalon) REFERENCES dbo.Salones(IdSalon),
    CONSTRAINT CK_MovCons_Tipo CHECK ([Tipo]='Salida' OR [Tipo]='Entrada'),
    CONSTRAINT CK_MovCons_Cant CHECK ([Cantidad]>(0))
);
GO

-- Datos de la institucion. Una sola fila (el CHECK impide crear una segunda).
IF OBJECT_ID(N'dbo.ConfiguracionEmpresa', 'U') IS NULL
CREATE TABLE dbo.ConfiguracionEmpresa (
    IdConfig           INT NOT NULL,
    NombreEmpresa      NVARCHAR(150) NOT NULL,
    Logotipo           VARBINARY(MAX) NULL,
    Direccion          NVARCHAR(200) NULL,
    Telefono           NVARCHAR(30) NULL,
    Correo             NVARCHAR(100) NULL,
    InfoGeneral        NVARCHAR(500) NULL,
    FechaConfig        DATETIME NOT NULL CONSTRAINT DF_ConfiguracionEmpresa_FechaConfig DEFAULT GETDATE(),
    CONSTRAINT PK_ConfigEmpresa PRIMARY KEY (IdConfig),
    CONSTRAINT CK_ConfigEmpresa_Unica CHECK ([IdConfig]=(1))
);
GO

-- Grados escolares.
IF OBJECT_ID(N'dbo.Grados', 'U') IS NULL
CREATE TABLE dbo.Grados (
    IdGrado            INT IDENTITY(1,1) NOT NULL,
    NombreGrado        NVARCHAR(60) NOT NULL,
    Orden              INT NOT NULL,
    CONSTRAINT PK_Grados PRIMARY KEY (IdGrado),
    CONSTRAINT UQ_Grados_Nombre UNIQUE (NombreGrado)
);
GO

-- Secciones de cada grado (A, B, A1...).
IF OBJECT_ID(N'dbo.Secciones', 'U') IS NULL
CREATE TABLE dbo.Secciones (
    IdSeccion          INT IDENTITY(1,1) NOT NULL,
    IdGrado            INT NOT NULL,
    NombreSeccion      NVARCHAR(10) NOT NULL,
    CONSTRAINT PK_Secciones PRIMARY KEY (IdSeccion),
    CONSTRAINT UQ_Secciones UNIQUE (IdGrado, NombreSeccion),
    CONSTRAINT FK_Secciones_Grados FOREIGN KEY (IdGrado) REFERENCES dbo.Grados(IdGrado)
);
GO

-- Materias que se imparten.
IF OBJECT_ID(N'dbo.Materias', 'U') IS NULL
CREATE TABLE dbo.Materias (
    IdMateria          INT IDENTITY(1,1) NOT NULL,
    NombreMateria      VARCHAR(100) NOT NULL,
    Activa             BIT NOT NULL CONSTRAINT DF_Materias_Activa DEFAULT 1,
    CONSTRAINT PK_Materias PRIMARY KEY (IdMateria),
    CONSTRAINT UQ_Materias_Nombre UNIQUE (NombreMateria)
);
GO

-- Materias que puede dar cada docente.
IF OBJECT_ID(N'dbo.EmpleadoMaterias', 'U') IS NULL
CREATE TABLE dbo.EmpleadoMaterias (
    IdEmpleado         INT NOT NULL,
    IdMateria          INT NOT NULL,
    CONSTRAINT PK_EmpleadoMaterias PRIMARY KEY (IdEmpleado, IdMateria),
    CONSTRAINT FK_EmpMat_Empleado FOREIGN KEY (IdEmpleado) REFERENCES dbo.Empleados(IdEmpleado) ON DELETE CASCADE,
    CONSTRAINT FK_EmpMat_Materia FOREIGN KEY (IdMateria) REFERENCES dbo.Materias(IdMateria)
);
GO

-- Fotografia del empleado (una por empleado).
IF OBJECT_ID(N'dbo.EmpleadoFotos', 'U') IS NULL
CREATE TABLE dbo.EmpleadoFotos (
    IdEmpleado         INT NOT NULL,
    Foto               VARBINARY(MAX) NOT NULL,
    FechaActualizacion DATETIME NOT NULL CONSTRAINT DF_EmpleadoFotos_FechaActualizacion DEFAULT GETDATE(),
    CONSTRAINT PK_EmpleadoFotos PRIMARY KEY (IdEmpleado),
    CONSTRAINT FK_EmpleadoFotos_Empleado FOREIGN KEY (IdEmpleado) REFERENCES dbo.Empleados(IdEmpleado) ON DELETE CASCADE
);
GO

-- Carga academica: docente + materia + seccion + horas semanales por anio lectivo.
IF OBJECT_ID(N'dbo.AsignacionesDocente', 'U') IS NULL
CREATE TABLE dbo.AsignacionesDocente (
    IdAsignacion       INT IDENTITY(1,1) NOT NULL,
    IdEmpleado         INT NOT NULL,
    IdSeccion          INT NOT NULL,
    AnioLectivo        INT NOT NULL,
    HorasSemanales     INT NOT NULL,
    FechaRegistro      DATETIME NOT NULL CONSTRAINT DF_AsignacionesDocente_FechaRegistro DEFAULT GETDATE(),
    IdMateria          INT NOT NULL,
    CONSTRAINT PK_AsignacionesDocente PRIMARY KEY (IdAsignacion),
    CONSTRAINT UQ_AsigDoc_Materia UNIQUE (IdEmpleado, IdSeccion, IdMateria, AnioLectivo),
    CONSTRAINT FK_AsigDoc_Materia FOREIGN KEY (IdMateria) REFERENCES dbo.Materias(IdMateria),
    CONSTRAINT FK_AsigDoc_Empleado FOREIGN KEY (IdEmpleado) REFERENCES dbo.Empleados(IdEmpleado) ON DELETE CASCADE,
    CONSTRAINT FK_AsigDoc_Seccion FOREIGN KEY (IdSeccion) REFERENCES dbo.Secciones(IdSeccion),
    CONSTRAINT CK_AsigDoc_Horas CHECK ([HorasSemanales]>=(1) AND [HorasSemanales]<=(40))
);
GO

-- Pagos mensuales. Un solo pago vigente por empleado y mes (los anulados no cuentan). SalarioNeto es calculada.
IF OBJECT_ID(N'dbo.PagosPlanilla', 'U') IS NULL
CREATE TABLE dbo.PagosPlanilla (
    IdPago             INT IDENTITY(1,1) NOT NULL,
    IdEmpleado         INT NOT NULL,
    Periodo            DATE NOT NULL,
    SalarioBase        DECIMAL(10,2) NOT NULL,
    Bono               DECIMAL(10,2) NOT NULL CONSTRAINT DF_PagosPlanilla_Bono DEFAULT 0,
    Descuento          DECIMAL(10,2) NOT NULL CONSTRAINT DF_PagosPlanilla_Descuento DEFAULT 0,
    SalarioNeto        AS (SalarioBase + Bono - Descuento) PERSISTED,
    EstadoPago         VARCHAR(20) NOT NULL CONSTRAINT DF_PagosPlanilla_EstadoPago DEFAULT 'Pendiente',
    FechaPago          DATETIME NULL,
    Observacion        VARCHAR(200) NULL,
    Anulado            BIT NOT NULL CONSTRAINT DF_PagosPlanilla_Anulado DEFAULT 0,
    FechaRegistro      DATETIME NOT NULL CONSTRAINT DF_PagosPlanilla_FechaRegistro DEFAULT GETDATE(),
    DiasAusencia       INT NOT NULL CONSTRAINT DF_PagosPlanilla_DiasAusencia DEFAULT 0,
    DescuentoAusencias DECIMAL(10,2) NOT NULL CONSTRAINT DF_PagosPlanilla_DescuentoAusencias DEFAULT 0,
    CONSTRAINT PK_PagosPlanilla PRIMARY KEY (IdPago),
    CONSTRAINT FK_PagosPlanilla_Empleado FOREIGN KEY (IdEmpleado) REFERENCES dbo.Empleados(IdEmpleado),
    CONSTRAINT CK_PagosPlanilla_Estado CHECK ([EstadoPago]='Pagado' OR [EstadoPago]='Pendiente'),
    CONSTRAINT CK_PagosPlanilla_Periodo CHECK (datepart(day,[Periodo])=(1)),
    CONSTRAINT CK_PagosPlanilla_Montos CHECK ([SalarioBase]>(0) AND [Bono]>=(0) AND [Descuento]>=(0) AND [Descuento]<=([SalarioBase]+[Bono]))
);
GO
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'UX_PagosPlanilla_Empleado_Periodo' AND object_id = OBJECT_ID(N'dbo.PagosPlanilla'))
    CREATE UNIQUE INDEX UX_PagosPlanilla_Empleado_Periodo ON dbo.PagosPlanilla (IdEmpleado, Periodo) WHERE ([Anulado]=(0));
GO

-- Estado de cada mes de planilla (siempre el dia 1): Cerrado = 1, o reabierto = 0. Un mes cerrado no admite cambios.
IF OBJECT_ID(N'dbo.PeriodosPlanilla', 'U') IS NULL
CREATE TABLE dbo.PeriodosPlanilla (
    Periodo            DATE NOT NULL,
    Cerrado            BIT NOT NULL CONSTRAINT DF_PeriodosPlanilla_Cerrado DEFAULT 1,
    FechaCierre        DATETIME NULL,
    CerradoPor         VARCHAR(50) NULL,
    CONSTRAINT PK_PeriodosPlanilla PRIMARY KEY (Periodo),
    CONSTRAINT CK_PeriodosPlanilla_Dia CHECK (datepart(day,[Periodo])=(1))
);
GO

-- Bitacora de cierres y reaperturas de mes.
IF OBJECT_ID(N'dbo.PeriodosPlanillaHistorial', 'U') IS NULL
CREATE TABLE dbo.PeriodosPlanillaHistorial (
    IdHistorial        INT IDENTITY(1,1) NOT NULL,
    Periodo            DATE NOT NULL,
    Accion             VARCHAR(20) NOT NULL,
    Usuario            VARCHAR(50) NOT NULL,
    Fecha              DATETIME NOT NULL CONSTRAINT DF_PeriodosPlanillaHistorial_Fecha DEFAULT GETDATE(),
    Motivo             VARCHAR(200) NULL,
    CONSTRAINT PK_PeriodosHistorial PRIMARY KEY (IdHistorial),
    CONSTRAINT CK_PeriodosHistorial_Accion CHECK ([Accion]='Reapertura' OR [Accion]='Cierre')
);
GO

-- Faltas, permisos e incapacidades. Alimentan el descuento de la planilla.
IF OBJECT_ID(N'dbo.Ausencias', 'U') IS NULL
CREATE TABLE dbo.Ausencias (
    IdAusencia         INT IDENTITY(1,1) NOT NULL,
    IdEmpleado         INT NOT NULL,
    Tipo               VARCHAR(20) NOT NULL,
    FechaInicio        DATE NOT NULL,
    FechaFin           DATE NOT NULL,
    Justificada        BIT NOT NULL CONSTRAINT DF_Ausencias_Justificada DEFAULT 0,
    ConGoce            BIT NOT NULL CONSTRAINT DF_Ausencias_ConGoce DEFAULT 0,
    Motivo             VARCHAR(300) NULL,
    RegistradoPor      VARCHAR(50) NOT NULL,
    FechaRegistro      DATETIME NOT NULL CONSTRAINT DF_Ausencias_FechaRegistro DEFAULT GETDATE(),
    Anulada            BIT NOT NULL CONSTRAINT DF_Ausencias_Anulada DEFAULT 0,
    CONSTRAINT PK_Ausencias PRIMARY KEY (IdAusencia),
    CONSTRAINT FK_Ausencias_Empleado FOREIGN KEY (IdEmpleado) REFERENCES dbo.Empleados(IdEmpleado),
    CONSTRAINT CK_Ausencias_Tipo CHECK ([Tipo]='Incapacidad' OR [Tipo]='Permiso' OR [Tipo]='Falta'),
    CONSTRAINT CK_Ausencias_Fechas CHECK ([FechaFin]>=[FechaInicio])
);
GO
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_Ausencias_Empleado' AND object_id = OBJECT_ID(N'dbo.Ausencias'))
    CREATE INDEX IX_Ausencias_Empleado ON dbo.Ausencias (IdEmpleado, FechaInicio, FechaFin) WHERE Anulada = 0;
GO

-- Registro de actividad del sistema (quien hizo que). No admite UPDATE ni DELETE (trigger trg_Auditoria_Inmutable).
IF OBJECT_ID(N'dbo.Auditoria', 'U') IS NULL
CREATE TABLE dbo.Auditoria (
    IdAuditoria        BIGINT IDENTITY(1,1) NOT NULL,
    FechaHora          DATETIME2(0) NOT NULL CONSTRAINT DF_Auditoria_FechaHora DEFAULT SYSDATETIME(),
    Usuario            NVARCHAR(50) NULL,
    Tabla              NVARCHAR(128) NOT NULL,
    Operacion          CHAR(1) NOT NULL,
    Clave              NVARCHAR(100) NULL,
    Antes              NVARCHAR(MAX) NULL,
    Despues            NVARCHAR(MAX) NULL,
    Equipo             NVARCHAR(128) NULL CONSTRAINT DF_Auditoria_Equipo DEFAULT HOST_NAME(),
    CONSTRAINT PK_Auditoria PRIMARY KEY (IdAuditoria),
    CONSTRAINT CK_Auditoria_Operacion CHECK ([Operacion]='A' OR [Operacion]='D' OR [Operacion]='U' OR [Operacion]='I')
);
GO
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_Auditoria_Fecha' AND object_id = OBJECT_ID(N'dbo.Auditoria'))
    CREATE INDEX IX_Auditoria_Fecha ON dbo.Auditoria (FechaHora DESC);
GO
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_Auditoria_Usuario' AND object_id = OBJECT_ID(N'dbo.Auditoria'))
    CREATE INDEX IX_Auditoria_Usuario ON dbo.Auditoria (Usuario, FechaHora DESC);
GO
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_Auditoria_Tabla' AND object_id = OBJECT_ID(N'dbo.Auditoria'))
    CREATE INDEX IX_Auditoria_Tabla ON dbo.Auditoria (Tabla, Clave);
GO

-- Si la base ya existia con una version anterior de estas tablas, se agregan las columnas
-- nuevas. En una instalacion limpia solo crea el indice IX_Prestamos_Empleado; lo demas
-- ya viene en el CREATE TABLE.
IF COL_LENGTH('dbo.UnidadesActivo', 'CostoUnitario') IS NULL
    ALTER TABLE dbo.UnidadesActivo ADD CostoUnitario DECIMAL(10,2) NULL, FechaAdquisicion DATE NULL,
                                       Proveedor VARCHAR(100) NULL, FechaBaja DATETIME NULL, MotivoBaja VARCHAR(300) NULL;
GO
IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = N'CK_Unidades_Costo')
    ALTER TABLE dbo.UnidadesActivo ADD CONSTRAINT CK_Unidades_Costo CHECK (CostoUnitario IS NULL OR CostoUnitario >= 0);
GO
IF COL_LENGTH('dbo.Prestamos', 'IdEmpleado') IS NULL
    ALTER TABLE dbo.Prestamos ADD IdEmpleado INT NULL;
GO
IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = N'FK_Prestamos_Empleado')
    ALTER TABLE dbo.Prestamos ADD CONSTRAINT FK_Prestamos_Empleado FOREIGN KEY (IdEmpleado) REFERENCES dbo.Empleados(IdEmpleado);
GO
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_Prestamos_Empleado' AND object_id = OBJECT_ID(N'dbo.Prestamos'))
    CREATE INDEX IX_Prestamos_Empleado ON dbo.Prestamos (IdEmpleado) WHERE IdEmpleado IS NOT NULL;
GO
-- Prestamos que ya existian: se enlazan con su empleado por nombre exacto (el nombre de empleado es unico).
-- En una instalacion limpia no hace nada; si se repite, tampoco (solo toca filas con IdEmpleado NULL).
UPDATE p
SET    p.IdEmpleado = e.IdEmpleado
FROM   dbo.Prestamos p
JOIN   dbo.Empleados e ON e.Nombre = p.Responsable
WHERE  p.IdEmpleado IS NULL
  AND  p.TipoResponsable IN ('Docente', 'Personal administrativo');
GO

/* =====================================================================
   3. FUNCIONES
   ===================================================================== */
-- Compara el JSON "Antes" y "Despues" de un registro de Auditoria y devuelve una fila por campo: en una
-- modificación (U) solo los campos que cambiaron; en altas y bajas (I/D), todos los guardados.
-- Columnas: Campo, Antes, Despues y Linea (el texto ya armado). La usa vw_Auditoria.
-- Los textos llevan la intercalación de la base para poder mezclarse sin conflictos.
CREATE OR ALTER FUNCTION dbo.fn_AuditoriaCambios (@IdAuditoria BIGINT)
RETURNS TABLE
AS
RETURN
(
    SELECT y.Campo, y.Antes, y.Despues,
           CAST(y.Campo + N': ' +
                CASE WHEN y.Operacion = 'U'
                     THEN ISNULL(y.Antes, N'(vacío)') + N' → ' + ISNULL(y.Despues, N'(vacío)')
                     ELSE ISNULL(COALESCE(y.Despues, y.Antes), N'(vacío)') END
                AS NVARCHAR(MAX)) AS Linea
    FROM (
        SELECT CAST(COALESCE(x.kd, x.kb) AS NVARCHAR(200)) COLLATE DATABASE_DEFAULT AS Campo,
               CAST(x.vb AS NVARCHAR(MAX))                 COLLATE DATABASE_DEFAULT AS Antes,
               CAST(x.vd AS NVARCHAR(MAX))                 COLLATE DATABASE_DEFAULT AS Despues,
               a.Operacion
        FROM dbo.Auditoria a
        CROSS APPLY (
            SELECT b.[key] AS kb, b.[value] AS vb, d.[key] AS kd, d.[value] AS vd
            FROM OPENJSON(ISNULL(a.Antes, N'{}')) b
            FULL OUTER JOIN OPENJSON(ISNULL(a.Despues, N'{}')) d ON d.[key] = b.[key]
        ) x
        WHERE a.IdAuditoria = @IdAuditoria
          AND (a.Operacion <> 'U' OR ISNULL(x.vb, N'') <> ISNULL(x.vd, N''))
    ) y
);
GO

-- Días hábiles (lunes a viernes) entre dos fechas, ambas incluidas.
-- 1900-01-01 fue lunes: (días desde esa fecha) % 7 = 0 lunes ... 6 domingo, sin depender del idioma del servidor.
CREATE OR ALTER FUNCTION dbo.fn_DiasHabiles (@Ini DATE, @Fin DATE)
RETURNS INT
AS
BEGIN
    IF @Ini IS NULL OR @Fin IS NULL OR @Fin < @Ini RETURN 0;

    DECLARE @total INT = DATEDIFF(DAY, @Ini, @Fin) + 1;
    DECLARE @habiles INT = (@total / 7) * 5;                 -- cada semana completa trae 5 días hábiles
    DECLARE @resto INT = @total % 7;
    DECLARE @dia INT = DATEDIFF(DAY, '19000101', @Ini) % 7;  -- día de la semana del primer día
    DECLARE @i INT = 0;

    WHILE @i < @resto                                         -- los días sueltos que sobran
    BEGIN
        IF ((@dia + @i) % 7) < 5 SET @habiles = @habiles + 1;
        SET @i = @i + 1;
    END
    RETURN @habiles;
END
GO

-- Devuelve el Id del salón activo de tipo 'Bodega' (por defecto 'Bodega central'): ahí entra todo el equipo nuevo.
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

-- ¿El mes de esa fecha está cerrado? (1 = sí). Un mes cerrado no admite cambios en pagos ni en ausencias.
CREATE OR ALTER FUNCTION dbo.fn_PeriodoCerrado (@Fecha DATE)
RETURNS BIT
AS
BEGIN
    RETURN ISNULL((SELECT Cerrado FROM dbo.PeriodosPlanilla
                   WHERE Periodo = DATEFROMPARTS(YEAR(@Fecha), MONTH(@Fecha), 1)), 0);
END
GO

-- Días hábiles del MES del período que se descuentan a un empleado
-- (faltas injustificadas y permisos sin goce de sueldo).
CREATE OR ALTER FUNCTION dbo.fn_DiasDescontados (@IdEmpleado INT, @Periodo DATE)
RETURNS INT
AS
BEGIN
    DECLARE @ini DATE = DATEFROMPARTS(YEAR(@Periodo), MONTH(@Periodo), 1);
    DECLARE @fin DATE = EOMONTH(@Periodo);

    RETURN ISNULL((
        SELECT SUM(dbo.fn_DiasHabiles(
                       CASE WHEN a.FechaInicio > @ini THEN a.FechaInicio ELSE @ini END,   -- solo la parte que cae en este mes
                       CASE WHEN a.FechaFin    < @fin THEN a.FechaFin    ELSE @fin END))
        FROM dbo.Ausencias a
        WHERE a.IdEmpleado = @IdEmpleado AND a.Anulada = 0
          AND a.FechaInicio <= @fin AND a.FechaFin >= @ini
          AND ((a.Tipo = 'Falta' AND a.Justificada = 0) OR (a.Tipo = 'Permiso' AND a.ConGoce = 0))
    ), 0);
END
GO

-- Descuento en dinero por las ausencias de un empleado en un mes:
-- salario base ÷ días hábiles del mes × días que se descuentan.
CREATE OR ALTER FUNCTION dbo.fn_DescuentoAusencias
    (@IdEmpleado INT, @Periodo DATE, @SalarioBase DECIMAL(10,2))
RETURNS DECIMAL(10,2)
AS
BEGIN
    DECLARE @ini DATE = DATEFROMPARTS(YEAR(@Periodo), MONTH(@Periodo), 1);
    DECLARE @habiles INT = dbo.fn_DiasHabiles(@ini, EOMONTH(@ini));
    IF @habiles = 0 RETURN 0;
    RETURN CAST(ROUND(@SalarioBase / @habiles * dbo.fn_DiasDescontados(@IdEmpleado, @Periodo), 2) AS DECIMAL(10,2));
END
GO

/* =====================================================================
   4. VISTAS
   ===================================================================== */
-- Catálogo de equipos con sus totales de unidades.
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

-- Equipo de cada salón. Las categorías que requieren serial (RequiereSerial = 1) salen con una fila por unidad y su
-- código; las demás, agrupadas por equipo con la cantidad y sin código.
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

-- Carga académica detallada: docente, materia, grado, sección, año lectivo y horas semanales.
CREATE OR ALTER VIEW dbo.vw_AsignacionesDetalle AS
SELECT a.IdAsignacion, a.IdEmpleado, e.Nombre AS Docente, c.NombreCargo AS Cargo,
       a.IdMateria, ISNULL(mt.NombreMateria, c.NombreCargo) AS Materia,
       g.IdGrado, g.NombreGrado AS Grado, g.Orden AS OrdenGrado,
       s.IdSeccion, s.NombreSeccion AS Seccion,
       a.AnioLectivo, a.HorasSemanales
FROM dbo.AsignacionesDocente a
JOIN dbo.Empleados e ON e.IdEmpleado = a.IdEmpleado
JOIN dbo.Cargos c    ON c.IdCargo    = e.IdCargo
LEFT JOIN dbo.Materias mt ON mt.IdMateria = a.IdMateria
JOIN dbo.Secciones s ON s.IdSeccion  = a.IdSeccion
JOIN dbo.Grados g    ON g.IdGrado    = s.IdGrado;
GO

-- Registro de actividad legible: módulo, acción y resumen en español de cada cambio.
CREATE OR ALTER VIEW dbo.vw_Auditoria AS
SELECT a.IdAuditoria,
       a.FechaHora,
       ISNULL(a.Usuario, N'(sistema)') AS Usuario,
       u.NombreCompleto,
       CASE a.Tabla
            WHEN N'Empleados'            THEN N'Personal'
            WHEN N'Cargos'               THEN N'Cargos'
            WHEN N'Planillas'            THEN N'Catálogo de salarios'
            WHEN N'PagosPlanilla'        THEN N'Pagos de planilla'
            WHEN N'Ausencias'            THEN N'Ausencias y permisos'
            WHEN N'AsignacionesDocente'  THEN N'Asignaciones docentes'
            WHEN N'Materias'             THEN N'Materias'
            WHEN N'EmpleadoMaterias'     THEN N'Materias del docente'
            WHEN N'PeriodosPlanilla'     THEN N'Cierre de mes'
            WHEN N'ConfiguracionEmpresa' THEN N'Configuración de la institución'
            WHEN N'Usuarios'             THEN N'Usuarios'
            WHEN N'GestionActivos'       THEN N'Activos (catálogo)'
            WHEN N'UnidadesActivo'       THEN N'Activos (unidades)'
            WHEN N'Salones'              THEN N'Salones'
            WHEN N'ReportesDanio'        THEN N'Reportes de daño'
            WHEN N'MantenimientosActivo' THEN N'Mantenimientos'
            WHEN N'Prestamos'            THEN N'Préstamos'
            WHEN N'Acceso'               THEN N'Acceso al sistema'
            ELSE a.Tabla
       END AS Modulo,
       CASE
            WHEN a.Operacion = 'A' THEN ISNULL(JSON_VALUE(a.Despues, '$.Resultado'), N'Acceso')
            WHEN a.Tabla = N'PeriodosPlanilla' AND a.Operacion = 'I' THEN N'Cerró el mes'
            WHEN a.Tabla = N'PeriodosPlanilla' AND a.Operacion = 'U'
                 THEN CASE WHEN JSON_VALUE(a.Despues, '$.Cerrado') = 'true' THEN N'Cerró el mes' ELSE N'Reabrió el mes' END
            WHEN a.Operacion = 'U' AND JSON_VALUE(a.Antes, '$.Anulado') = 'false' AND JSON_VALUE(a.Despues, '$.Anulado') = 'true' THEN N'Anuló'
            WHEN a.Operacion = 'U' AND JSON_VALUE(a.Antes, '$.Anulada') = 'false' AND JSON_VALUE(a.Despues, '$.Anulada') = 'true' THEN N'Anuló'
            WHEN a.Operacion = 'U' AND JSON_VALUE(a.Antes, '$.EstadoPago') = N'Pendiente' AND JSON_VALUE(a.Despues, '$.EstadoPago') = N'Pagado' THEN N'Marcó como pagado'
            WHEN a.Tabla = N'Usuarios' AND a.Operacion = 'U' AND JSON_VALUE(a.Antes, '$.Activo') = 'true' AND JSON_VALUE(a.Despues, '$.Activo') = 'false' THEN N'Desactivó'
            WHEN a.Tabla = N'Usuarios' AND a.Operacion = 'U' AND JSON_VALUE(a.Antes, '$.Activo') = 'false' AND JSON_VALUE(a.Despues, '$.Activo') = 'true' THEN N'Reactivó'
            WHEN a.Operacion = 'I' THEN N'Creó'
            WHEN a.Operacion = 'D' THEN N'Eliminó'
            ELSE N'Modificó'
       END AS Accion,
       a.Tabla, a.Operacion, a.Clave,
       CASE WHEN a.Tabla = N'Acceso' THEN N'Equipo: ' + ISNULL(a.Equipo, N'?')
            ELSE LEFT((SELECT STRING_AGG(c.Linea, N'; ') FROM dbo.fn_AuditoriaCambios(a.IdAuditoria) c), 600)
       END AS Resumen,
       a.Equipo
FROM dbo.Auditoria a
LEFT JOIN dbo.Usuarios u ON u.Usuario = a.Usuario;
GO

-- Historial del catálogo de equipos (altas, bajas y cambios de nombre).
CREATE OR ALTER VIEW dbo.vw_AuditoriaActivosDetalle AS
SELECT IdAuditoria, Fecha, Accion, IdActivo, NombreAnterior, NombreNuevo, Usuario
FROM dbo.AuditoriaActivos;
GO

-- Historial de unidades con nombres: alta, retiro, cambio de estado y traslado.
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

-- Ausencias con empleado, cargo, días hábiles y si descuentan sueldo.
CREATE OR ALTER VIEW dbo.vw_AusenciasDetalle AS
SELECT a.IdAusencia, a.IdEmpleado, e.Nombre AS Empleado, c.NombreCargo AS Cargo,
       a.Tipo, a.FechaInicio, a.FechaFin,
       dbo.fn_DiasHabiles(a.FechaInicio, a.FechaFin) AS Dias,
       a.Justificada, a.ConGoce,
       CASE WHEN (a.Tipo = 'Falta' AND a.Justificada = 0) OR (a.Tipo = 'Permiso' AND a.ConGoce = 0)
            THEN 1 ELSE 0 END AS Descuenta,
       CASE a.Tipo
            WHEN 'Falta'   THEN CASE WHEN a.Justificada = 1 THEN 'Falta justificada' ELSE 'Falta injustificada' END
            WHEN 'Permiso' THEN CASE WHEN a.ConGoce = 1 THEN 'Permiso con goce de sueldo' ELSE 'Permiso sin goce de sueldo' END
            ELSE 'Incapacidad médica' END AS Clase,
       a.Motivo, a.RegistradoPor, a.FechaRegistro, a.Anulada
FROM dbo.Ausencias a
JOIN dbo.Empleados e ON e.IdEmpleado = a.IdEmpleado
JOIN dbo.Cargos c    ON c.IdCargo    = e.IdCargo;
GO

-- Datos de la boleta de pago en PDF: pago, empleado, cargo y fecha de contratación.
CREATE OR ALTER VIEW dbo.vw_BoletaPago AS
SELECT pg.IdPago, pg.IdEmpleado, e.Nombre AS Empleado, e.DUI, c.NombreCargo AS Cargo,
       e.FechaContratacion, pg.Periodo,
       LEFT(CONVERT(CHAR(10), pg.Periodo, 23), 7) AS PeriodoClave,
       pg.SalarioBase, pg.Bono, pg.Descuento, pg.SalarioNeto,
       pg.EstadoPago, pg.FechaPago, pg.Observacion, pg.Anulado,
       pg.DiasAusencia, pg.DescuentoAusencias
FROM dbo.PagosPlanilla pg
JOIN dbo.Empleados e ON e.IdEmpleado = pg.IdEmpleado
JOIN dbo.Cargos c    ON c.IdCargo    = e.IdCargo;
GO

-- Carga por docente y año: el tope de 40 horas cuenta TODAS sus materias.
-- La columna Materia muestra todas las que imparte ("Física, Matemáticas").
CREATE OR ALTER VIEW dbo.vw_CargaDocente AS
SELECT x.IdEmpleado, x.Docente,
       (SELECT STRING_AGG(m.NombreMateria, ', ') WITHIN GROUP (ORDER BY m.NombreMateria)
        FROM (SELECT DISTINCT a2.IdMateria
              FROM dbo.AsignacionesDocente a2
              WHERE a2.IdEmpleado = x.IdEmpleado AND a2.AnioLectivo = x.AnioLectivo) d
        JOIN dbo.Materias m ON m.IdMateria = d.IdMateria) AS Materia,
       x.AnioLectivo, x.TotalHoras, x.Grupos
FROM (SELECT IdEmpleado, Docente, AnioLectivo,
             SUM(HorasSemanales) AS TotalHoras, COUNT(*) AS Grupos
      FROM dbo.vw_AsignacionesDetalle
      GROUP BY IdEmpleado, Docente, AnioLectivo) x;
GO

-- Consumibles entregados a cada salón y la fecha de la última entrega.
CREATE OR ALTER VIEW dbo.vw_ConsumiblesPorSalon AS
SELECT m.IdSalon, s.NombreSalon, c.IdConsumible, c.Nombre AS Consumible, c.Unidad,
       SUM(m.Cantidad) AS Entregado, MAX(m.Fecha) AS UltimaEntrega
FROM dbo.MovimientosConsumible m
JOIN dbo.Consumibles c ON c.IdConsumible = m.IdConsumible
JOIN dbo.Salones s     ON s.IdSalon      = m.IdSalon
WHERE m.Tipo = 'Salida' AND m.IdSalon IS NOT NULL
GROUP BY m.IdSalon, s.NombreSalon, c.IdConsumible, c.Nombre, c.Unidad;
GO

-- Empleados con cargo, estado, estructura salarial y estado del pago del mes actual.
CREATE OR ALTER VIEW dbo.vw_EmpleadosDetalle AS
SELECT e.IdEmpleado, e.Nombre, e.FechaContratacion,
       e.IdCargo,  c.NombreCargo,
       e.IdEstado, ee.NombreEstado AS Estado,
       e.IdPlanilla,
       p.SalarioBase, p.Descuento, p.Bono, p.SalarioNeto,
       -- Estado del pago del mes actual
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

-- Historial unificado: préstamos, devoluciones, consumibles y mantenimientos.
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

-- Kardex de consumibles: cada movimiento con su saldo resultante.
CREATE OR ALTER VIEW dbo.vw_KardexConsumibles AS
SELECT m.IdMovimiento, m.IdConsumible, c.Nombre AS Consumible, c.Unidad,
       m.Fecha, m.Tipo, m.Cantidad, m.Motivo, m.Destino, m.SaldoResultante, m.Usuario
FROM dbo.MovimientosConsumible m
JOIN dbo.Consumibles c ON c.IdConsumible = m.IdConsumible;
GO

-- Mantenimientos con el equipo y el estado en que quedó la unidad.
CREATE OR ALTER VIEW dbo.vw_Mantenimientos AS
SELECT m.IdMantenimiento, m.Fecha, m.IdActivo, a.Nombre AS Activo, m.IdUnidad, m.CodigoInventario,
       m.Tipo, m.Descripcion, m.Costo, e.NombreEstado AS EstadoResultante,
       m.IdReporte, m.RealizadoPor
FROM dbo.MantenimientosActivo m
JOIN dbo.GestionActivos a ON a.IdActivo = m.IdActivo
JOIN dbo.Estados e        ON e.IdEstado = m.IdEstadoResultante;
GO

-- Pagos de planilla con empleado y cargo; indica si el mes del pago está cerrado.
CREATE OR ALTER VIEW dbo.vw_PagosPlanillaDetalle AS
SELECT pg.IdPago, pg.IdEmpleado, e.Nombre AS Empleado, c.NombreCargo AS Cargo,
       pg.Periodo, LEFT(CONVERT(CHAR(10), pg.Periodo, 23), 7) AS PeriodoClave,
       pg.SalarioBase, pg.Bono, pg.Descuento, pg.SalarioNeto,
       pg.EstadoPago, pg.FechaPago, pg.Observacion, pg.Anulado, pg.FechaRegistro,
       pg.DiasAusencia, pg.DescuentoAusencias,
       CAST(ISNULL(pp.Cerrado, 0) AS INT) AS PeriodoCerrado
FROM dbo.PagosPlanilla pg
INNER JOIN dbo.Empleados e ON e.IdEmpleado = pg.IdEmpleado
INNER JOIN dbo.Cargos    c ON c.IdCargo    = e.IdCargo
LEFT  JOIN dbo.PeriodosPlanilla pp ON pp.Periodo = pg.Periodo;
GO

-- Préstamos con equipo, aula destino, estado de devolución y el empleado responsable (IdEmpleado).
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

-- Reportes de daño con salón, equipo y categoría.
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

-- Dashboard: tipos de equipo y unidades por categoría.
CREATE OR ALTER VIEW dbo.vw_ResumenActivosPorCategoria AS
SELECT cat.NombreCategoria,
       COUNT(DISTINCT a.IdActivo) AS TiposDeActivo,
       COUNT(u.IdUnidad)          AS UnidadesAsignadas
FROM dbo.Categorias cat
LEFT JOIN dbo.GestionActivos a ON a.IdCategoria = cat.IdCategoria
LEFT JOIN dbo.UnidadesActivo u ON u.IdActivo    = a.IdActivo
GROUP BY cat.NombreCategoria;
GO

-- Dashboard: cantidad de unidades por estado.
CREATE OR ALTER VIEW dbo.vw_ResumenActivosPorEstado AS
SELECT e.NombreEstado, COUNT(u.IdUnidad) AS TotalActivos
FROM dbo.Estados e
LEFT JOIN dbo.UnidadesActivo u ON u.IdEstado = e.IdEstado
GROUP BY e.NombreEstado;
GO

-- Dashboard: tipos de equipo y total de unidades por salón.
CREATE OR ALTER VIEW dbo.vw_ResumenActivosPorSalon AS
SELECT NombreSalon,
       COUNT(DISTINCT IdActivo) AS TiposDeActivo,
       SUM(Cantidad)            AS TotalUnidades
FROM dbo.vw_ActivosPorSalon
GROUP BY NombreSalon;
GO

-- Dashboard: empleados activos e inactivos.
CREATE OR ALTER VIEW dbo.vw_ResumenEmpleadosPorEstado AS
SELECT ee.NombreEstado AS Estado, COUNT(e.IdEmpleado) AS TotalEmpleados
FROM dbo.EstadosEmpleado ee
LEFT JOIN dbo.Empleados e ON e.IdEstado = ee.IdEstado
GROUP BY ee.NombreEstado;
GO

-- Dashboard: unidades por estado en cada salón y equipo.
CREATE OR ALTER VIEW dbo.vw_ResumenEstadoPorSalon AS
SELECT u.IdSalon, s.NombreSalon, a.IdActivo, a.Nombre AS Activo,
       e.IdEstado, e.NombreEstado AS Estado, COUNT(*) AS Unidades
FROM dbo.UnidadesActivo u
JOIN dbo.Salones s        ON s.IdSalon  = u.IdSalon
JOIN dbo.GestionActivos a ON a.IdActivo = u.IdActivo
JOIN dbo.Estados e        ON e.IdEstado = u.IdEstado
GROUP BY u.IdSalon, s.NombreSalon, a.IdActivo, a.Nombre, e.IdEstado, e.NombreEstado;
GO

-- Dashboard: empleados por cargo (incluye inactivos) y suma del salario base y neto de su estructura salarial
-- (no usa los pagos registrados).
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

-- Salones con su responsable, total de unidades y cuántas tienen problemas.
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

-- Unidades de la bodega (fn_IdBodega) sin préstamo activo y cuyo estado no es Malo, En reparación,
-- Mantenimiento Pendiente ni Dado de baja (incluye Regular), listas para asignar.
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

-- Stock de consumibles con alerta: Agotado, Stock bajo o Normal.
CREATE OR ALTER VIEW dbo.vw_StockConsumibles AS
SELECT IdConsumible, Nombre, Unidad, StockActual, StockMinimo,
       CASE WHEN StockActual = 0 THEN 'Agotado'
            WHEN StockActual <= StockMinimo THEN 'Stock bajo'
            ELSE 'Normal' END AS Alerta
FROM dbo.Consumibles;
GO

-- Cada unidad con su equipo, categoría, ubicación, estado, costo, fecha de compra, proveedor y datos de baja.
CREATE OR ALTER VIEW dbo.vw_UnidadesDetalle AS
SELECT u.IdUnidad, u.CodigoInventario,
       u.IdActivo, a.Nombre AS Activo,
       a.IdCategoria, cat.NombreCategoria AS Categoria,
       u.IdSalon, s.NombreSalon AS Ubicacion,
       u.IdEstado, e.NombreEstado AS Estado,
       u.FechaAlta, u.Observacion,
       u.CostoUnitario, u.FechaAdquisicion, u.Proveedor, u.FechaBaja, u.MotivoBaja
FROM dbo.UnidadesActivo u
JOIN dbo.GestionActivos a    ON a.IdActivo      = u.IdActivo
JOIN dbo.Salones s           ON s.IdSalon       = u.IdSalon
JOIN dbo.Estados e           ON e.IdEstado      = u.IdEstado
LEFT JOIN dbo.Categorias cat ON cat.IdCategoria = a.IdCategoria;
GO

/* =====================================================================
   5. PROCEDIMIENTOS ALMACENADOS
   ===================================================================== */
-- Edita el nombre completo y el correo de un usuario (el nombre de usuario no se cambia nunca).
CREATE OR ALTER PROCEDURE dbo.sp_ActualizarUsuario
    @IdUsuario      INT,
    @NombreCompleto NVARCHAR(100),
    @Correo         VARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;

    SET @NombreCompleto = LTRIM(RTRIM(ISNULL(@NombreCompleto, N'')));
    SET @Correo         = NULLIF(LTRIM(RTRIM(ISNULL(@Correo, ''))), '');

    IF NOT EXISTS (SELECT 1 FROM dbo.Usuarios WHERE IdUsuario = @IdUsuario)
        THROW 50907, N'El usuario ya no existe.', 1;
    IF LEN(@NombreCompleto) = 0
        THROW 50902, N'El nombre completo es obligatorio.', 1;
    IF @Correo IS NOT NULL AND EXISTS (SELECT 1 FROM dbo.Usuarios WHERE Correo = @Correo AND IdUsuario <> @IdUsuario)
        THROW 50904, N'Ese correo ya está asignado a otro usuario.', 1;

    UPDATE dbo.Usuarios
    SET NombreCompleto = @NombreCompleto, Correo = @Correo
    WHERE IdUsuario = @IdUsuario;
END;
GO

-- Crea N unidades de un tipo en un salón, cada una con su código ACT-0014-027
-- (el consecutivo sigue al número más alto existente; los huecos no se reutilizan).
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

-- ALTA: el equipo entra al inventario (siempre a la bodega). Acepta costo, fecha de compra y
-- proveedor (opcionales) y los aplica a las unidades creadas.
CREATE OR ALTER PROCEDURE dbo.sp_AltaUnidades
    @IdActivo INT,
    @Cantidad INT,
    @IdEstado INT,
    @Codigo   VARCHAR(50) = NULL,
    @CostoUnitario    DECIMAL(10,2) = NULL,
    @FechaAdquisicion DATE          = NULL,
    @Proveedor        VARCHAR(100)  = NULL
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
    IF @CostoUnitario IS NOT NULL AND @CostoUnitario < 0
        THROW 50960, 'El costo no puede ser negativo.', 1;
    IF @FechaAdquisicion IS NOT NULL AND @FechaAdquisicion > CAST(GETDATE() AS DATE)
        THROW 50961, 'La fecha de compra no puede ser futura.', 1;

    SET @Codigo    = NULLIF(LTRIM(RTRIM(ISNULL(@Codigo, ''))), '');
    SET @Proveedor = NULLIF(LTRIM(RTRIM(ISNULL(@Proveedor, ''))), '');

    BEGIN TRANSACTION;
    DECLARE @Antes INT = ISNULL((SELECT MAX(IdUnidad) FROM dbo.UnidadesActivo WITH (UPDLOCK, HOLDLOCK)), 0);

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

    -- las unidades recién creadas son las de id mayor al que había antes
    UPDATE dbo.UnidadesActivo
    SET    CostoUnitario = @CostoUnitario, FechaAdquisicion = @FechaAdquisicion, Proveedor = @Proveedor
    WHERE  IdUnidad > @Antes AND IdActivo = @IdActivo;

    COMMIT TRANSACTION;
    SELECT @Cantidad AS Creadas;
END;
GO

-- Anula una ausencia y devuelve el descuento en los pagos pendientes de esos meses.
CREATE OR ALTER PROCEDURE dbo.sp_AnularAusencia @IdAusencia INT
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;

    IF EXISTS (SELECT 1 FROM dbo.Ausencias a
               JOIN dbo.PeriodosPlanilla p
                 ON p.Cerrado = 1
                AND p.Periodo BETWEEN DATEFROMPARTS(YEAR(a.FechaInicio), MONTH(a.FechaInicio), 1) AND a.FechaFin
               WHERE a.IdAusencia = @IdAusencia AND a.Anulada = 0)
        THROW 50801, 'Esa ausencia cae en un mes cerrado de la planilla. Un administrador debe reabrirlo.', 1;

    DECLARE @emp INT, @ini DATE, @fin DATE;
    SELECT @emp = IdEmpleado, @ini = FechaInicio, @fin = FechaFin
    FROM dbo.Ausencias WHERE IdAusencia = @IdAusencia AND Anulada = 0;

    IF @emp IS NULL
        THROW 50706, 'La ausencia no existe o ya estaba anulada.', 1;

    BEGIN TRY
        BEGIN TRANSACTION;
        UPDATE dbo.Ausencias SET Anulada = 1 WHERE IdAusencia = @IdAusencia;
        EXEC dbo.sp_RecalcularDescuentoAusencias @emp, @ini, @fin;
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- Anula un pago de planilla (no se borra: queda marcado como anulado).
CREATE OR ALTER PROCEDURE dbo.sp_AnularPago @IdPago INT
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.PagosPlanilla WHERE IdPago = @IdPago AND dbo.fn_PeriodoCerrado(Periodo) = 1)
        THROW 50800, 'El mes está cerrado: no se pueden registrar ni modificar pagos. Un administrador debe reabrirlo.', 1;

    UPDATE dbo.PagosPlanilla SET Anulado = 1 WHERE IdPago = @IdPago AND Anulado = 0;
    IF @@ROWCOUNT = 0
        THROW 50310, 'El pago no existe o ya estaba anulado.', 1;
END
GO

-- Asigna un docente a un grupo. @IdMateria es opcional si el docente imparte una sola.
CREATE OR ALTER PROCEDURE dbo.sp_AsignarDocente
    @IdEmpleado  INT,
    @IdSeccion   INT,
    @AnioLectivo INT,
    @Horas       INT,
    @IdMateria   INT = NULL
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

        -- Materia: si no se indica y el docente tiene una sola, se usa esa
        IF @IdMateria IS NULL
        BEGIN
            DECLARE @n INT = (SELECT COUNT(*) FROM dbo.EmpleadoMaterias WHERE IdEmpleado = @IdEmpleado);
            IF @n = 0
                THROW 50205, 'El docente no tiene materias registradas. Agréguelas en su ficha de personal.', 1;
            IF @n > 1
                THROW 50206, 'El docente imparte varias materias: indique cuál se asigna a este grupo.', 1;
            SELECT @IdMateria = IdMateria FROM dbo.EmpleadoMaterias WHERE IdEmpleado = @IdEmpleado;
        END
        ELSE IF NOT EXISTS (SELECT 1 FROM dbo.EmpleadoMaterias WHERE IdEmpleado = @IdEmpleado AND IdMateria = @IdMateria)
            THROW 50207, 'Esa materia no está entre las materias del docente.', 1;

        BEGIN TRANSACTION;

        IF EXISTS (SELECT 1 FROM dbo.AsignacionesDocente WITH (UPDLOCK, HOLDLOCK)
                   WHERE IdEmpleado = @IdEmpleado AND IdSeccion = @IdSeccion
                     AND IdMateria = @IdMateria AND AnioLectivo = @AnioLectivo)
            THROW 50203, 'Ese docente ya tiene asignada esa materia en ese grupo y año lectivo.', 1;

        -- El tope de 40 horas cuenta todas las materias del docente en el año
        DECLARE @Actual INT = ISNULL((SELECT SUM(HorasSemanales) FROM dbo.AsignacionesDocente
                                      WHERE IdEmpleado = @IdEmpleado AND AnioLectivo = @AnioLectivo), 0);
        IF @Actual + @Horas > 40
        BEGIN
            DECLARE @Msg NVARCHAR(200) = CONCAT(N'Supera el máximo de 40 horas semanales: el docente ya tiene ',
                                                @Actual, N' h asignadas.');
            THROW 50204, @Msg, 1;
        END

        INSERT INTO dbo.AsignacionesDocente (IdEmpleado, IdSeccion, IdMateria, AnioLectivo, HorasSemanales)
        VALUES (@IdEmpleado, @IdSeccion, @IdMateria, @AnioLectivo, @Horas);
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- ASIGNACIÓN: pasa unidades YA EXISTENTES de la bodega a un salón. Solo se asignan las disponibles
-- (las mismas de vw_StockBodega); si se piden más, rechaza la operación (error 50514).
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

-- Activa o desactiva un salón (no se puede desactivar si todavía tiene equipo).
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

-- Cambia el estado de UNA unidad SIN las validaciones de sp_CambiarEstadoUnidades (no pide motivo ni guarda
-- fecha y motivo de baja, no comprueba préstamos ni reportes abiertos, no impide revertir una baja).
-- El programa usa sp_CambiarEstadoUnidades.
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

-- Cambia el estado de varias unidades de un equipo. Valida: estado válido, unidades del equipo, no se da de baja
-- una unidad prestada, no se marca en buen estado una unidad con reporte de daño abierto y una baja no se revierte.
-- Dar de baja exige un motivo (mínimo 5 caracteres) y deja fecha y motivo en la unidad.
-- Es el único camino con todas estas garantías.
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

    UPDATE u
    SET    u.IdEstado   = @IdEstado,
           u.FechaBaja  = CASE WHEN @estado = 'Dado de baja' THEN GETDATE() ELSE u.FechaBaja END,
           u.MotivoBaja = CASE WHEN @estado = 'Dado de baja' THEN LEFT(LTRIM(RTRIM(@Motivo)), 300) ELSE u.MotivoBaja END
    FROM   dbo.UnidadesActivo u JOIN @sel s ON s.IdUnidad = u.IdUnidad;
END;
GO

-- Activa o desactiva un usuario. Protege: no desactivarse a sí mismo ni al último administrador activo.
CREATE OR ALTER PROCEDURE dbo.sp_CambiarEstadoUsuario
    @IdUsuario     INT,
    @Activo        BIT,
    @UsuarioActual VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;
    BEGIN TRANSACTION;

    DECLARE @usuario VARCHAR(50), @activoActual BIT;
    SELECT @usuario = Usuario, @activoActual = Activo
    FROM dbo.Usuarios WITH (UPDLOCK, HOLDLOCK)
    WHERE IdUsuario = @IdUsuario;

    IF @usuario IS NULL
        THROW 50907, N'El usuario ya no existe.', 1;

    IF @Activo = 0 AND @activoActual = 1
    BEGIN
        IF @usuario = @UsuarioActual
            THROW 50905, N'No puedes desactivar tu propia cuenta.', 1;

        IF NOT EXISTS (SELECT 1
                       FROM dbo.Usuarios u
                       JOIN dbo.Roles r ON r.IdRol = u.IdRol
                       WHERE r.NombreRol = 'Administrador' AND u.Activo = 1 AND u.IdUsuario <> @IdUsuario)
            THROW 50906, N'Debe quedar al menos un administrador activo.', 1;
    END

    UPDATE dbo.Usuarios SET Activo = @Activo WHERE IdUsuario = @IdUsuario;
    COMMIT TRANSACTION;
END;
GO

-- Cambio de contraseña propio (obligatorio en el primer ingreso o voluntario).
CREATE OR ALTER PROCEDURE dbo.sp_CambiarMiClave
    @Usuario   VARCHAR(50),
    @HashClave VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM dbo.Usuarios WHERE Usuario = @Usuario)
        THROW 50907, N'No se encontró la cuenta.', 1;

    UPDATE dbo.Usuarios
    SET Clave = @HashClave, DebeCambiarClave = 0
    WHERE Usuario = @Usuario;
END;
GO

-- Cierra un mes de planilla (ya no admite cambios en pagos ni ausencias) y lo anota en el historial.
CREATE OR ALTER PROCEDURE dbo.sp_CerrarPeriodo
    @Periodo DATE,
    @Usuario VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;
    SET @Periodo = DATEFROMPARTS(YEAR(@Periodo), MONTH(@Periodo), 1);

    IF @Periodo > DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1)
        THROW 50808, 'No se puede cerrar un mes que todavía no empieza.', 1;
    IF dbo.fn_PeriodoCerrado(@Periodo) = 1
        THROW 50804, 'Ese mes ya está cerrado.', 1;
    IF NOT EXISTS (SELECT 1 FROM dbo.PagosPlanilla WHERE Periodo = @Periodo AND Anulado = 0)
        THROW 50805, 'Ese mes no tiene pagos: genere o registre la planilla antes de cerrarlo.', 1;

    DECLARE @pend INT = (SELECT COUNT(*) FROM dbo.PagosPlanilla
                         WHERE Periodo = @Periodo AND Anulado = 0 AND EstadoPago = 'Pendiente');
    IF @pend > 0
    BEGIN
        DECLARE @msg NVARCHAR(200) = CONCAT(N'No se puede cerrar: hay ', @pend,
                                            N' pago(s) pendiente(s). Márquelos como pagados o anúlelos.');
        THROW 50803, @msg, 1;
    END

    BEGIN TRY
        BEGIN TRANSACTION;
        IF EXISTS (SELECT 1 FROM dbo.PeriodosPlanilla WHERE Periodo = @Periodo)
            UPDATE dbo.PeriodosPlanilla SET Cerrado = 1, FechaCierre = GETDATE(), CerradoPor = @Usuario
            WHERE Periodo = @Periodo;
        ELSE
            INSERT INTO dbo.PeriodosPlanilla (Periodo, Cerrado, FechaCierre, CerradoPor)
            VALUES (@Periodo, 1, GETDATE(), @Usuario);

        INSERT INTO dbo.PeriodosPlanillaHistorial (Periodo, Accion, Usuario) VALUES (@Periodo, 'Cierre', @Usuario);
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- GENERADOR DE TRIGGERS DE AUDITORÍA
-- Crea trg_Aud_<Tabla> para tablas con clave primaria de una o varias columnas.
-- No guarda columnas binarias (fotos, logo) ni las que se indiquen en @Excluir.
CREATE OR ALTER PROCEDURE dbo.sp_CrearTriggerAuditoria
    @Tabla   SYSNAME,
    @Excluir NVARCHAR(500) = N''
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @obj INT = OBJECT_ID(N'dbo.' + QUOTENAME(@Tabla), N'U');
    IF @obj IS NULL
    BEGIN
        PRINT N'Omitida (la tabla no existe): ' + @Tabla;
        RETURN;
    END

    -- Columnas de la clave primaria (una o varias)
    DECLARE @join NVARCHAR(MAX), @lista NVARCHAR(MAX), @npk INT;
    SELECT @npk   = COUNT(*),
           @join  = STRING_AGG(CAST(N'd.' + QUOTENAME(c.name) + N' = i.' + QUOTENAME(c.name) AS NVARCHAR(MAX)), N' AND '),
           @lista = STRING_AGG(CAST(N'CAST(COALESCE(i.' + QUOTENAME(c.name) + N', d.' + QUOTENAME(c.name) + N') AS NVARCHAR(100))' AS NVARCHAR(MAX)), N', ')
    FROM sys.indexes ix
    JOIN sys.index_columns ic ON ic.object_id = ix.object_id AND ic.index_id = ix.index_id
    JOIN sys.columns c ON c.object_id = ic.object_id AND c.column_id = ic.column_id
    WHERE ix.object_id = @obj AND ix.is_primary_key = 1;

    IF ISNULL(@npk, 0) = 0
    BEGIN
        PRINT N'Omitida (no tiene clave primaria): ' + @Tabla;
        RETURN;
    END

    -- Una columna: se usa tal cual. Varias columnas: se unen con un guion (por ejemplo "7-3").
    DECLARE @clave NVARCHAR(MAX) = CASE WHEN @npk = 1 THEN @lista
                                        ELSE N'CONCAT_WS(N''-'', ' + @lista + N')' END;

    DECLARE @colsD NVARCHAR(MAX), @colsI NVARCHAR(MAX);
    SELECT @colsD = STRING_AGG(CAST(N'd.' + QUOTENAME(c.name) AS NVARCHAR(MAX)), N', ') WITHIN GROUP (ORDER BY c.column_id),
           @colsI = STRING_AGG(CAST(N'i.' + QUOTENAME(c.name) AS NVARCHAR(MAX)), N', ') WITHIN GROUP (ORDER BY c.column_id)
    FROM sys.columns c
    JOIN sys.types ty ON ty.user_type_id = c.user_type_id
    WHERE c.object_id = @obj
      AND ty.name NOT IN (N'varbinary', N'binary', N'image', N'timestamp', N'xml', N'geography', N'geometry', N'hierarchyid', N'sql_variant')
      AND c.name NOT IN (SELECT LTRIM(RTRIM(value)) FROM STRING_SPLIT(@Excluir, N','));

    DECLARE @sql NVARCHAR(MAX) = N'
CREATE OR ALTER TRIGGER dbo.' + QUOTENAME(N'trg_Aud_' + @Tabla) + N' ON dbo.' + QUOTENAME(@Tabla) + N'
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @op CHAR(1) = CASE WHEN EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted) THEN ''U''
                               WHEN EXISTS (SELECT 1 FROM inserted) THEN ''I'' ELSE ''D'' END;

    INSERT INTO dbo.Auditoria (Usuario, Tabla, Operacion, Clave, Antes, Despues)
    SELECT CAST(SESSION_CONTEXT(N''Usuario'') AS NVARCHAR(50)), N''' + @Tabla + N''', @op,
           CAST(' + @clave + N' AS NVARCHAR(100)),
           x.Antes, x.Despues
    FROM inserted i
    FULL OUTER JOIN deleted d ON ' + @join + N'
    CROSS APPLY (SELECT
        Antes   = CASE WHEN @op = ''I'' THEN NULL ELSE (SELECT ' + @colsD + N' FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) END,
        Despues = CASE WHEN @op = ''D'' THEN NULL ELSE (SELECT ' + @colsI + N' FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) END) x
    WHERE @op <> ''U'' OR ISNULL(x.Antes, N'''') <> ISNULL(x.Despues, N'''');
END';

    BEGIN TRY
        EXEC sp_executesql @sql;
        PRINT N'Auditoría activada en: ' + @Tabla;
    END TRY
    BEGIN CATCH
        PRINT N'*** FALLÓ en ' + @Tabla + N': ' + ERROR_MESSAGE();
    END CATCH
END;
GO

-- Crea un administrador nuevo con contraseña temporal (ya viene como hash desde la aplicación).
CREATE OR ALTER PROCEDURE dbo.sp_CrearUsuario
    @Usuario        VARCHAR(50),
    @NombreCompleto NVARCHAR(100),
    @Correo         VARCHAR(100) = NULL,
    @HashClave      VARCHAR(255),
    @CreadoPor      VARCHAR(50)  = NULL
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;

    SET @Usuario        = LTRIM(RTRIM(ISNULL(@Usuario, '')));
    SET @NombreCompleto = LTRIM(RTRIM(ISNULL(@NombreCompleto, N'')));
    SET @Correo         = NULLIF(LTRIM(RTRIM(ISNULL(@Correo, ''))), '');

    IF LEN(@Usuario) < 3
        THROW 50901, N'El nombre de usuario debe tener al menos 3 caracteres.', 1;
    IF LEN(@NombreCompleto) = 0
        THROW 50902, N'El nombre completo es obligatorio.', 1;
    IF EXISTS (SELECT 1 FROM dbo.Usuarios WHERE Usuario = @Usuario)
        THROW 50903, N'Ya existe un usuario con ese nombre.', 1;
    IF @Correo IS NOT NULL AND EXISTS (SELECT 1 FROM dbo.Usuarios WHERE Correo = @Correo)
        THROW 50904, N'Ese correo ya está asignado a otro usuario.', 1;

    DECLARE @IdRol INT = (SELECT IdRol FROM dbo.Roles WHERE NombreRol = 'Administrador');
    IF @IdRol IS NULL
        THROW 50908, N'No existe el rol Administrador en la tabla Roles.', 1;

    INSERT INTO dbo.Usuarios
        (Usuario, Clave, IdRol, Correo, Activo, NombreCompleto, DebeCambiarClave, FechaCreacion, CreadoPor)
    VALUES
        (@Usuario, @HashClave, @IdRol, @Correo, 1, @NombreCompleto, 1, SYSDATETIME(), @CreadoPor);
END;
GO

-- GENERA LA PLANILLA DEL MES
-- @Simular = 1 solo cuenta (vista previa); @Simular = 0 crea los pagos.
-- Devuelve: Generados, YaExistian, SinSalario, NombresSinSalario, Cerrado.
CREATE OR ALTER PROCEDURE dbo.sp_GenerarPlanilla
    @Periodo  DATE,
    @Usuario  VARCHAR(50),
    @Simular  BIT = 0
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;
    SET @Periodo = DATEFROMPARTS(YEAR(@Periodo), MONTH(@Periodo), 1);
    DECLARE @cerrado BIT = dbo.fn_PeriodoCerrado(@Periodo);
    DECLARE @fin DATE = EOMONTH(@Periodo);

    IF @Simular = 0
    BEGIN
        IF @Periodo > DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1)
            THROW 50802, 'No se puede generar la planilla de un mes futuro.', 1;
        IF @cerrado = 1
            THROW 50800, 'El mes está cerrado: no se pueden registrar ni modificar pagos. Un administrador debe reabrirlo.', 1;
    END

    -- Candidatos: empleados activos, ya contratados a fin de ese mes
    SELECT e.IdEmpleado, e.Nombre,
           ISNULL(p.SalarioBase, 0) AS SalarioBase,
           ISNULL(p.Bono, 0)        AS Bono,
           ISNULL(p.Descuento, 0)   AS Descuento,
           CASE WHEN EXISTS (SELECT 1 FROM dbo.PagosPlanilla pg
                             WHERE pg.IdEmpleado = e.IdEmpleado AND pg.Periodo = @Periodo AND pg.Anulado = 0)
                THEN 1 ELSE 0 END AS YaTiene
    INTO #cand
    FROM dbo.Empleados e
    LEFT JOIN dbo.Planillas p ON p.IdPlanilla = e.IdPlanilla
    WHERE e.IdEstado <> 2 AND e.FechaContratacion <= @fin;

    DECLARE @ya  INT = (SELECT COUNT(*) FROM #cand WHERE YaTiene = 1);
    DECLARE @sin INT = (SELECT COUNT(*) FROM #cand WHERE YaTiene = 0 AND SalarioBase <= 0);
    DECLARE @gen INT = (SELECT COUNT(*) FROM #cand WHERE YaTiene = 0 AND SalarioBase > 0);
    DECLARE @nombres NVARCHAR(MAX) = (SELECT STRING_AGG(CAST(Nombre AS NVARCHAR(MAX)), N', ')
                                      FROM #cand WHERE YaTiene = 0 AND SalarioBase <= 0);

    IF @Simular = 1
    BEGIN
        SELECT @gen AS Generados, @ya AS YaExistian, @sin AS SinSalario,
               @nombres AS NombresSinSalario, CAST(@cerrado AS INT) AS Cerrado;
        RETURN;
    END

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Un pago Pendiente por empleado: base, bono y descuento de ley de su estructura salarial,
        -- más el descuento por ausencias de ese mes (topado para no superar base + bono)
        INSERT INTO dbo.PagosPlanilla (IdEmpleado, Periodo, SalarioBase, Bono, Descuento, EstadoPago,
                                       Observacion, DiasAusencia, DescuentoAusencias)
        SELECT c.IdEmpleado, @Periodo, c.SalarioBase, c.Bono, d.Total, 'Pendiente',
               'Generado automáticamente', a.Dias,
               CASE WHEN a.Aus > d.Total THEN d.Total ELSE a.Aus END
        FROM #cand c
        CROSS APPLY (SELECT Dias = dbo.fn_DiasDescontados(c.IdEmpleado, @Periodo),
                            Aus  = dbo.fn_DescuentoAusencias(c.IdEmpleado, @Periodo, c.SalarioBase)) a
        CROSS APPLY (SELECT Total = CASE WHEN c.Descuento + a.Aus > c.SalarioBase + c.Bono
                                         THEN c.SalarioBase + c.Bono ELSE c.Descuento + a.Aus END) d
        WHERE c.YaTiene = 0 AND c.SalarioBase > 0;

        SET @gen = @@ROWCOUNT;
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH

    SELECT @gen AS Generados, @ya AS YaExistian, @sin AS SinSalario,
           @nombres AS NombresSinSalario, 0 AS Cerrado;
END;
GO

-- Asistente de primer uso: guarda los datos de la institución y crea el administrador inicial
-- (la clave llega ya como hash BCrypt).
CREATE OR ALTER PROCEDURE dbo.sp_GuardarConfiguracionInicial
    @NombreEmpresa    NVARCHAR(150),
    @Logotipo         VARBINARY(MAX) = NULL,
    @Direccion        NVARCHAR(200)  = NULL,
    @Telefono         NVARCHAR(30)   = NULL,
    @Correo           NVARCHAR(100)  = NULL,
    @InfoGeneral      NVARCHAR(500)  = NULL,
    @Usuario          NVARCHAR(50)   = NULL,
    @HashClave        NVARCHAR(200)  = NULL,
    @CorreoAdmin      NVARCHAR(100)  = NULL,
    @CorreoVerificado BIT            = 0
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;
    BEGIN TRY
        IF LEN(LTRIM(RTRIM(ISNULL(@NombreEmpresa, '')))) = 0
            THROW 50020, 'El nombre de la empresa es obligatorio.', 1;
        IF EXISTS (SELECT 1 FROM dbo.ConfiguracionEmpresa)
            THROW 50021, 'El sistema ya fue configurado.', 1;

        DECLARE @CorreoUsuario NVARCHAR(100) = NULLIF(LTRIM(RTRIM(ISNULL(@CorreoAdmin, @Correo))), '');

        IF @Usuario IS NOT NULL AND @CorreoUsuario IS NOT NULL
           AND EXISTS (SELECT 1 FROM dbo.Usuarios WHERE Correo = @CorreoUsuario)
            THROW 50024, 'Ese correo ya está registrado para otro usuario.', 1;

        BEGIN TRANSACTION;

        INSERT INTO dbo.ConfiguracionEmpresa
            (IdConfig, NombreEmpresa, Logotipo, Direccion, Telefono, Correo, InfoGeneral)
        VALUES (1, LTRIM(RTRIM(@NombreEmpresa)), @Logotipo, @Direccion, @Telefono, @Correo, @InfoGeneral);

        IF @Usuario IS NOT NULL
        BEGIN
            IF EXISTS (SELECT 1 FROM dbo.Usuarios WHERE Usuario = @Usuario)
                THROW 50022, 'Ese nombre de usuario ya existe.', 1;

            INSERT INTO dbo.Usuarios (Usuario, Clave, IdRol, Correo, CorreoVerificado)
            SELECT @Usuario, @HashClave, IdRol, @CorreoUsuario, ISNULL(@CorreoVerificado, 0)
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

-- Catálogo de materias: crear o editar.
CREATE OR ALTER PROCEDURE dbo.sp_GuardarMateria
    @IdMateria     INT = NULL,
    @NombreMateria VARCHAR(100),
    @Activa        BIT = 1
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;
    SET @NombreMateria = LTRIM(RTRIM(ISNULL(@NombreMateria, '')));

    IF LEN(@NombreMateria) < 3
        THROW 50600, 'El nombre de la materia es obligatorio (mínimo 3 caracteres).', 1;
    IF EXISTS (SELECT 1 FROM dbo.Materias
               WHERE LOWER(NombreMateria) = LOWER(@NombreMateria)
                 AND (@IdMateria IS NULL OR IdMateria <> @IdMateria))
        THROW 50601, 'Ya existe una materia con ese nombre.', 1;

    IF @IdMateria IS NULL
    BEGIN
        INSERT INTO dbo.Materias (NombreMateria, Activa) VALUES (@NombreMateria, @Activa);
        SET @IdMateria = SCOPE_IDENTITY();
    END
    ELSE
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM dbo.Materias WHERE IdMateria = @IdMateria)
            THROW 50602, 'La materia no existe.', 1;
        UPDATE dbo.Materias SET NombreMateria = @NombreMateria, Activa = @Activa
        WHERE IdMateria = @IdMateria;
    END

    SELECT @IdMateria AS IdMateria;
END;
GO

-- Define las materias de un docente. @Ids = IdMateria separados por coma ('2,5').
-- Una lista vacía quita todas, siempre que el docente no tenga grupos asignados (si los tiene: error 50613).
CREATE OR ALTER PROCEDURE dbo.sp_GuardarMateriasEmpleado
    @IdEmpleado INT,
    @Ids        VARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;

    IF NOT EXISTS (SELECT 1 FROM dbo.Empleados WHERE IdEmpleado = @IdEmpleado)
        THROW 50610, 'El empleado no existe.', 1;

    DECLARE @t TABLE (IdMateria INT PRIMARY KEY);
    DECLARE @x XML = CAST('<i>' + REPLACE(ISNULL(@Ids, ''), ',', '</i><i>') + '</i>' AS XML);
    INSERT INTO @t (IdMateria)
    SELECT DISTINCT TRY_CAST(NULLIF(LTRIM(RTRIM(n.value('.', 'VARCHAR(20)'))), '') AS INT)
    FROM @x.nodes('/i') AS q(n)
    WHERE TRY_CAST(NULLIF(LTRIM(RTRIM(n.value('.', 'VARCHAR(20)'))), '') AS INT) IS NOT NULL;

    IF EXISTS (SELECT 1 FROM @t)
       AND NOT EXISTS (SELECT 1 FROM dbo.Empleados e JOIN dbo.Cargos c ON c.IdCargo = e.IdCargo
                       WHERE e.IdEmpleado = @IdEmpleado AND LOWER(c.NombreCargo) LIKE 'docente%')
        THROW 50611, 'Solo los empleados con cargo Docente pueden tener materias.', 1;

    IF EXISTS (SELECT 1 FROM @t t WHERE NOT EXISTS (SELECT 1 FROM dbo.Materias m WHERE m.IdMateria = t.IdMateria))
        THROW 50612, 'Alguna de las materias seleccionadas no existe.', 1;

    -- No se puede quitar una materia con la que el docente ya tiene grupos asignados
    IF EXISTS (SELECT 1
               FROM dbo.AsignacionesDocente a
               WHERE a.IdEmpleado = @IdEmpleado
                 AND NOT EXISTS (SELECT 1 FROM @t t WHERE t.IdMateria = a.IdMateria))
        THROW 50613, 'No se puede quitar una materia que ya tiene grupos asignados. Quite primero esas asignaciones.', 1;

    BEGIN TRANSACTION;

    DELETE em FROM dbo.EmpleadoMaterias em
    WHERE em.IdEmpleado = @IdEmpleado
      AND NOT EXISTS (SELECT 1 FROM @t t WHERE t.IdMateria = em.IdMateria);

    INSERT INTO dbo.EmpleadoMaterias (IdEmpleado, IdMateria)
    SELECT @IdEmpleado, t.IdMateria FROM @t t
    WHERE NOT EXISTS (SELECT 1 FROM dbo.EmpleadoMaterias em
                      WHERE em.IdEmpleado = @IdEmpleado AND em.IdMateria = t.IdMateria);

    COMMIT TRANSACTION;
END;
GO

-- Crea o edita un salón (al crear, IdSalon = MAX + 1).
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

-- Marca un pago pendiente como pagado.
CREATE OR ALTER PROCEDURE dbo.sp_MarcarPagado @IdPago INT
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.PagosPlanilla WHERE IdPago = @IdPago AND dbo.fn_PeriodoCerrado(Periodo) = 1)
        THROW 50800, 'El mes está cerrado: no se pueden registrar ni modificar pagos. Un administrador debe reabrirlo.', 1;

    UPDATE dbo.PagosPlanilla SET EstadoPago = 'Pagado', FechaPago = GETDATE()
    WHERE IdPago = @IdPago AND Anulado = 0 AND EstadoPago = 'Pendiente';
    IF @@ROWCOUNT = 0
        THROW 50309, 'El pago no existe, está anulado o ya estaba pagado.', 1;
END
GO

-- Mueve unidades concretas a otro salón. Si alguna está prestada, rechaza toda la operación (error 50423);
-- las que ya están en el destino no se cuentan.
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

-- Quita unidades (solo las que no tienen historial de préstamos, mantenimientos ni reportes).
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

-- Reabre un mes cerrado: exige un motivo (mínimo 5 caracteres) y lo anota en el historial.
CREATE OR ALTER PROCEDURE dbo.sp_ReabrirPeriodo
    @Periodo DATE,
    @Usuario VARCHAR(50),
    @Motivo  VARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;
    SET @Periodo = DATEFROMPARTS(YEAR(@Periodo), MONTH(@Periodo), 1);

    IF dbo.fn_PeriodoCerrado(@Periodo) = 0
        THROW 50806, 'Ese mes no está cerrado.', 1;
    IF LEN(LTRIM(RTRIM(ISNULL(@Motivo, '')))) < 5
        THROW 50807, 'Indique el motivo de la reapertura (mínimo 5 caracteres).', 1;

    BEGIN TRY
        BEGIN TRANSACTION;
        UPDATE dbo.PeriodosPlanilla SET Cerrado = 0 WHERE Periodo = @Periodo;
        INSERT INTO dbo.PeriodosPlanillaHistorial (Periodo, Accion, Usuario, Motivo)
        VALUES (@Periodo, 'Reapertura', @Usuario, LTRIM(RTRIM(@Motivo)));
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- Recalcula la parte de ausencias de los pagos PENDIENTES de ese empleado en esos meses.
-- Solo cambia esa parte; el descuento de ley (Descuento - DescuentoAusencias) se conserva.
-- No toca pagos pagados, anulados ni de meses cerrados.
CREATE OR ALTER PROCEDURE dbo.sp_RecalcularDescuentoAusencias
    @IdEmpleado  INT,
    @FechaInicio DATE,
    @FechaFin    DATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE pg
    SET pg.DiasAusencia       = c.Dias,
        pg.Descuento          = c.Total,
        pg.DescuentoAusencias = c.Total - c.Legal
    FROM dbo.PagosPlanilla pg
    CROSS APPLY (SELECT Legal = pg.Descuento - pg.DescuentoAusencias,
                        Dias  = dbo.fn_DiasDescontados(pg.IdEmpleado, pg.Periodo),
                        Aus   = dbo.fn_DescuentoAusencias(pg.IdEmpleado, pg.Periodo, pg.SalarioBase)) a
    CROSS APPLY (SELECT a.Legal, a.Dias,
                        Total = CASE WHEN a.Legal + a.Aus > pg.SalarioBase + pg.Bono
                                     THEN pg.SalarioBase + pg.Bono        -- nunca más que base + bono
                                     ELSE a.Legal + a.Aus END) c
    WHERE pg.IdEmpleado = @IdEmpleado
      AND pg.Anulado = 0
      AND pg.EstadoPago = 'Pendiente'
      AND pg.Periodo BETWEEN DATEFROMPARTS(YEAR(@FechaInicio), MONTH(@FechaInicio), 1) AND @FechaFin
      AND dbo.fn_PeriodoCerrado(pg.Periodo) = 0;
END;
GO

-- Registra inicios de sesión, cierres de sesión e intentos fallidos en el registro de actividad
-- (y guarda el último acceso del usuario).
CREATE OR ALTER PROCEDURE dbo.sp_RegistrarAcceso
    @Usuario   NVARCHAR(50),
    @Resultado NVARCHAR(40)       -- 'Inició sesión', 'Cerró sesión', 'Intento fallido', ...
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.Auditoria (Usuario, Tabla, Operacion, Clave, Despues)
    VALUES (LEFT(@Usuario, 50), N'Acceso', 'A', NULL,
            (SELECT @Resultado AS Resultado FOR JSON PATH, WITHOUT_ARRAY_WRAPPER));

    IF @Resultado = N'Inició sesión'
        UPDATE dbo.Usuarios SET UltimoAcceso = GETDATE() WHERE Usuario = @Usuario;
END;
GO

-- Registra una ausencia (falta, permiso o incapacidad) y actualiza los pagos pendientes de esos meses.
CREATE OR ALTER PROCEDURE dbo.sp_RegistrarAusencia
    @IdEmpleado  INT,
    @Tipo        VARCHAR(20),
    @FechaInicio DATE,
    @FechaFin    DATE,
    @Justificada BIT = 0,
    @ConGoce     BIT = 0,
    @Motivo      VARCHAR(300) = NULL,
    @Usuario     VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;

    IF NOT EXISTS (SELECT 1 FROM dbo.Empleados WHERE IdEmpleado = @IdEmpleado AND IdEstado <> 2)
        THROW 50700, 'El empleado no existe o está inactivo.', 1;
    IF @Tipo IS NULL OR @Tipo NOT IN ('Falta', 'Permiso', 'Incapacidad')
        THROW 50701, 'El tipo debe ser Falta, Permiso o Incapacidad.', 1;
    IF @FechaInicio IS NULL OR @FechaFin IS NULL OR @FechaFin < @FechaInicio
        THROW 50702, 'La fecha final no puede ser anterior a la fecha inicial.', 1;
    IF DATEDIFF(DAY, @FechaInicio, @FechaFin) > 90
        THROW 50703, 'El rango no puede superar 90 días. Registre varios períodos.', 1;
    IF dbo.fn_DiasHabiles(@FechaInicio, @FechaFin) = 0
        THROW 50704, 'Ese rango solo incluye sábados o domingos: no hay días laborales que registrar.', 1;

    IF EXISTS (SELECT 1 FROM dbo.PeriodosPlanilla
               WHERE Cerrado = 1
                 AND Periodo BETWEEN DATEFROMPARTS(YEAR(@FechaInicio), MONTH(@FechaInicio), 1) AND @FechaFin)
        THROW 50801, 'Esas fechas caen en un mes cerrado de la planilla. Un administrador debe reabrirlo.', 1;

    IF @Tipo = 'Incapacidad'
        SELECT @Justificada = 1, @ConGoce = 1;
    ELSE IF @Tipo = 'Permiso'
        SET @Justificada = 1;
    ELSE
        SET @ConGoce = 0;

    IF EXISTS (SELECT 1 FROM dbo.Ausencias
               WHERE IdEmpleado = @IdEmpleado AND Anulada = 0
                 AND FechaInicio <= @FechaFin AND FechaFin >= @FechaInicio)
        THROW 50705, 'Ese empleado ya tiene una ausencia registrada que se cruza con esas fechas.', 1;

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO dbo.Ausencias (IdEmpleado, Tipo, FechaInicio, FechaFin, Justificada, ConGoce, Motivo, RegistradoPor)
        VALUES (@IdEmpleado, @Tipo, @FechaInicio, @FechaFin, @Justificada, @ConGoce,
                NULLIF(LTRIM(RTRIM(ISNULL(@Motivo, ''))), ''), @Usuario);
        DECLARE @id INT = CAST(SCOPE_IDENTITY() AS INT);

        -- los pagos pendientes de esos meses se actualizan solos
        EXEC dbo.sp_RecalcularDescuentoAusencias @IdEmpleado, @FechaInicio, @FechaFin;

        COMMIT TRANSACTION;
        SELECT @id AS IdAusencia;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- Devolución: cierra el préstamo y actualiza SOLO el estado de esa unidad.
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

-- Registra un evento de usuarios en el registro de actividad (mismo formato que los accesos).
CREATE OR ALTER PROCEDURE dbo.sp_RegistrarEvento
    @Usuario NVARCHAR(50),
    @Evento  NVARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.Auditoria (Usuario, Tabla, Operacion, Clave, Despues)
    VALUES (LEFT(@Usuario, 50), N'Acceso', 'A', NULL,
            (SELECT @Evento AS Resultado FOR JSON PATH, WITHOUT_ARRAY_WRAPPER));
END;
GO

-- Mantenimiento: registra el servicio de una unidad y actualiza su estado; si se indica @IdReporte, cierra ese
-- reporte de daño (error 50051 si ya estaba cerrado). Si el estado resultante es "Dado de baja", guarda la fecha y,
-- como motivo, la descripción; no aplica las validaciones de sp_CambiarEstadoUnidades (motivo de 5 caracteres,
-- unidad prestada, baja irreversible).
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

        UPDATE u
        SET    u.IdEstado   = @IdEstadoResultante,
               u.FechaBaja  = CASE WHEN es.NombreEstado = 'Dado de baja' THEN GETDATE() ELSE u.FechaBaja END,
               u.MotivoBaja = CASE WHEN es.NombreEstado = 'Dado de baja' THEN LEFT(LTRIM(RTRIM(@Descripcion)), 300) ELSE u.MotivoBaja END
        FROM   dbo.UnidadesActivo u
        JOIN   dbo.Estados es ON es.IdEstado = @IdEstadoResultante
        WHERE  u.IdUnidad = @IdUnidad;

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

-- Kardex: registra una entrada o salida de consumible y actualiza el stock (no permite stock negativo).
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

-- Crea o edita el pago de un empleado en un mes. Rechaza los meses cerrados (error 50800).
CREATE OR ALTER PROCEDURE dbo.sp_RegistrarPago
    @IdPago             INT           = NULL,
    @IdEmpleado         INT,
    @Periodo            DATE,
    @SalarioBase        DECIMAL(10,2),
    @Bono               DECIMAL(10,2) = 0,
    @Descuento          DECIMAL(10,2) = 0,
    @EstadoPago         VARCHAR(20)   = 'Pendiente',
    @Observacion        VARCHAR(200)  = NULL,
    @DiasAusencia       INT           = 0,
    @DescuentoAusencias DECIMAL(10,2) = 0
AS
BEGIN
    SET NOCOUNT ON; SET XACT_ABORT ON;
    SET @Periodo = DATEFROMPARTS(YEAR(@Periodo), MONTH(@Periodo), 1);

    -- Mes cerrado: no se registra ni se modifica nada (ni en el mes nuevo ni en el mes original del pago)
    IF dbo.fn_PeriodoCerrado(@Periodo) = 1
       OR (@IdPago IS NOT NULL AND EXISTS (SELECT 1 FROM dbo.PagosPlanilla
                                           WHERE IdPago = @IdPago AND dbo.fn_PeriodoCerrado(Periodo) = 1))
        THROW 50800, 'El mes está cerrado: no se pueden registrar ni modificar pagos. Un administrador debe reabrirlo.', 1;

    IF NOT EXISTS (SELECT 1 FROM dbo.Empleados WHERE IdEmpleado = @IdEmpleado AND (IdEstado <> 2 OR @IdPago IS NOT NULL))
        THROW 50300, 'El empleado no existe o está inactivo.', 1;
    IF @SalarioBase IS NULL OR @SalarioBase <= 0
        THROW 50301, 'El salario base debe ser mayor que cero.', 1;
    IF @Bono < 0 OR @Descuento < 0
        THROW 50302, 'El bono y el descuento no pueden ser negativos.', 1;
    IF @Descuento > @SalarioBase + @Bono
        THROW 50303, 'El descuento no puede superar el salario base más el bono.', 1;
    IF @DescuentoAusencias < 0 OR @DescuentoAusencias > @Descuento OR @DiasAusencia < 0
        THROW 50311, 'El descuento por ausencias no es válido: no puede superar el descuento total.', 1;
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
        INSERT INTO dbo.PagosPlanilla (IdEmpleado, Periodo, SalarioBase, Bono, Descuento, EstadoPago, FechaPago,
                                       Observacion, DiasAusencia, DescuentoAusencias)
        VALUES (@IdEmpleado, @Periodo, @SalarioBase, @Bono, @Descuento, @EstadoPago,
                CASE WHEN @EstadoPago = 'Pagado' THEN GETDATE() END, @Observacion,
                @DiasAusencia, @DescuentoAusencias);
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
            Observacion = @Observacion,
            DiasAusencia = @DiasAusencia, DescuentoAusencias = @DescuentoAusencias
        WHERE IdPago = @IdPago;
    END
END;
GO

-- Préstamo de una unidad: Docente y Personal administrativo exigen un empleado real y activo (@IdEmpleado);
-- Alumno = texto libre (sin empleado).
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

-- Restablece la contraseña de otro administrador: queda temporal y obliga a cambiarla.
CREATE OR ALTER PROCEDURE dbo.sp_RestablecerClaveUsuario
    @IdUsuario INT,
    @HashClave VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM dbo.Usuarios WHERE IdUsuario = @IdUsuario)
        THROW 50907, N'El usuario ya no existe.', 1;

    UPDATE dbo.Usuarios
    SET Clave = @HashClave, DebeCambiarClave = 1
    WHERE IdUsuario = @IdUsuario;
END;
GO

/* =====================================================================
   6. TRIGGERS
   ===================================================================== */
-- Historial del inventario: trg_AuditoriaUnidades y trg_AuditoriaActivos (guardan al usuario del sistema;
-- si no hay, el login de la conexion).
-- Registro de actividad: un trigger trg_Aud_<Tabla> por cada tabla auditada (17 de las 30) guarda quien,
-- cuando y el contenido antes y despues (JSON) en la tabla Auditoria, sin columnas binarias;
-- trg_Aud_Usuarios tampoco guarda Clave ni UltimoAcceso. Se pueden regenerar con sp_CrearTriggerAuditoria
-- (para Usuarios: @Excluir = N'Clave,UltimoAcceso'); aqui aparecen completos para poder leerlos.
-- trg_Aud_UnidadesActivo y trg_Aud_Prestamos incluyen tambien costo, adquisicion, proveedor, baja e IdEmpleado.

-- El registro de actividad no admite UPDATE ni DELETE (INSTEAD OF): no se puede modificar ni borrar.
CREATE OR ALTER TRIGGER dbo.trg_Auditoria_Inmutable ON dbo.Auditoria
INSTEAD OF UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    THROW 50900, 'El registro de actividad no se puede modificar ni borrar.', 1;
END;
GO

-- Historial del catálogo de equipos (altas, bajas y cambios de nombre); guarda al usuario del sistema
-- (si no hay, el login de la conexión).
CREATE OR ALTER TRIGGER dbo.trg_AuditoriaActivos ON dbo.GestionActivos
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @u NVARCHAR(128) = ISNULL(CONVERT(NVARCHAR(128), SESSION_CONTEXT(N'Usuario')), SUSER_SNAME());

    INSERT INTO dbo.AuditoriaActivos (IdActivo, Accion, NombreNuevo, Usuario)
    SELECT i.IdActivo, 'INSERT', i.Nombre, @u
    FROM inserted i
    WHERE NOT EXISTS (SELECT 1 FROM deleted);

    INSERT INTO dbo.AuditoriaActivos (IdActivo, Accion, NombreAnterior, NombreNuevo, Usuario)
    SELECT i.IdActivo, 'UPDATE', d.Nombre, i.Nombre, @u
    FROM inserted i
    JOIN deleted d ON d.IdActivo = i.IdActivo
    WHERE ISNULL(d.Nombre, '') <> ISNULL(i.Nombre, '');

    INSERT INTO dbo.AuditoriaActivos (IdActivo, Accion, NombreAnterior, Usuario)
    SELECT d.IdActivo, 'DELETE', d.Nombre, @u
    FROM deleted d
    WHERE NOT EXISTS (SELECT 1 FROM inserted);
END;
GO

-- Historial de unidades (alta, retiro, cambio de estado y traslado); guarda al usuario del sistema
-- (si no hay, el login de la conexión).
CREATE OR ALTER TRIGGER dbo.trg_AuditoriaUnidades ON dbo.UnidadesActivo
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @u NVARCHAR(128) = ISNULL(CONVERT(NVARCHAR(128), SESSION_CONTEXT(N'Usuario')), SUSER_SNAME());

    INSERT INTO dbo.AuditoriaUnidades (IdUnidad, IdActivo, CodigoInventario, Accion, EstadoNuevo, SalonNuevo, Usuario)
    SELECT i.IdUnidad, i.IdActivo, i.CodigoInventario, 'INSERT', i.IdEstado, i.IdSalon, @u
    FROM inserted i
    WHERE NOT EXISTS (SELECT 1 FROM deleted);

    INSERT INTO dbo.AuditoriaUnidades (IdUnidad, IdActivo, CodigoInventario, Accion,
                                       EstadoAnterior, EstadoNuevo, SalonAnterior, SalonNuevo, Usuario)
    SELECT i.IdUnidad, i.IdActivo, i.CodigoInventario, 'UPDATE',
           d.IdEstado, i.IdEstado, d.IdSalon, i.IdSalon, @u
    FROM inserted i
    JOIN deleted d ON d.IdUnidad = i.IdUnidad
    WHERE d.IdEstado <> i.IdEstado OR d.IdSalon <> i.IdSalon;

    INSERT INTO dbo.AuditoriaUnidades (IdUnidad, IdActivo, CodigoInventario, Accion, EstadoAnterior, SalonAnterior, Usuario)
    SELECT d.IdUnidad, d.IdActivo, d.CodigoInventario, 'DELETE', d.IdEstado, d.IdSalon, @u
    FROM deleted d
    WHERE NOT EXISTS (SELECT 1 FROM inserted);
END;
GO

-- Registro de actividad de AsignacionesDocente: guarda quién, cuándo y el contenido antes y después (JSON) en Auditoria.
CREATE OR ALTER TRIGGER dbo.[trg_Aud_AsignacionesDocente] ON dbo.[AsignacionesDocente] AFTER INSERT, UPDATE, DELETE AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @op CHAR(1) = CASE WHEN EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted) THEN 'U'
                               WHEN EXISTS (SELECT 1 FROM inserted) THEN 'I' ELSE 'D' END;

    INSERT INTO dbo.Auditoria (Usuario, Tabla, Operacion, Clave, Antes, Despues)
    SELECT CAST(SESSION_CONTEXT(N'Usuario') AS NVARCHAR(50)), N'AsignacionesDocente', @op,
           CAST(CAST(COALESCE(i.[IdAsignacion], d.[IdAsignacion]) AS NVARCHAR(100)) AS NVARCHAR(100)),
           x.Antes, x.Despues
    FROM inserted i
    FULL OUTER JOIN deleted d ON d.[IdAsignacion] = i.[IdAsignacion]
    CROSS APPLY (SELECT
        Antes   = CASE WHEN @op = 'I' THEN NULL ELSE (SELECT
            d.[IdAsignacion], d.[IdEmpleado], d.[IdSeccion], d.[AnioLectivo],
            d.[HorasSemanales], d.[FechaRegistro], d.[IdMateria]
            FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) END,
        Despues = CASE WHEN @op = 'D' THEN NULL ELSE (SELECT
            i.[IdAsignacion], i.[IdEmpleado], i.[IdSeccion], i.[AnioLectivo],
            i.[HorasSemanales], i.[FechaRegistro], i.[IdMateria]
            FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) END) x
    WHERE @op <> 'U' OR ISNULL(x.Antes, N'') <> ISNULL(x.Despues, N'');
END
GO

-- Registro de actividad de Ausencias: guarda quién, cuándo y el contenido antes y después (JSON) en Auditoria.
CREATE OR ALTER TRIGGER dbo.[trg_Aud_Ausencias] ON dbo.[Ausencias] AFTER INSERT, UPDATE, DELETE AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @op CHAR(1) = CASE WHEN EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted) THEN 'U'
                               WHEN EXISTS (SELECT 1 FROM inserted) THEN 'I' ELSE 'D' END;

    INSERT INTO dbo.Auditoria (Usuario, Tabla, Operacion, Clave, Antes, Despues)
    SELECT CAST(SESSION_CONTEXT(N'Usuario') AS NVARCHAR(50)), N'Ausencias', @op,
           CAST(CAST(COALESCE(i.[IdAusencia], d.[IdAusencia]) AS NVARCHAR(100)) AS NVARCHAR(100)),
           x.Antes, x.Despues
    FROM inserted i
    FULL OUTER JOIN deleted d ON d.[IdAusencia] = i.[IdAusencia]
    CROSS APPLY (SELECT
        Antes   = CASE WHEN @op = 'I' THEN NULL ELSE (SELECT
            d.[IdAusencia], d.[IdEmpleado], d.[Tipo], d.[FechaInicio], d.[FechaFin],
            d.[Justificada], d.[ConGoce], d.[Motivo], d.[RegistradoPor], d.[FechaRegistro],
            d.[Anulada]
            FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) END,
        Despues = CASE WHEN @op = 'D' THEN NULL ELSE (SELECT
            i.[IdAusencia], i.[IdEmpleado], i.[Tipo], i.[FechaInicio], i.[FechaFin],
            i.[Justificada], i.[ConGoce], i.[Motivo], i.[RegistradoPor], i.[FechaRegistro],
            i.[Anulada]
            FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) END) x
    WHERE @op <> 'U' OR ISNULL(x.Antes, N'') <> ISNULL(x.Despues, N'');
END
GO

-- Registro de actividad de Cargos: guarda quién, cuándo y el contenido antes y después (JSON) en Auditoria.
CREATE OR ALTER TRIGGER dbo.[trg_Aud_Cargos] ON dbo.[Cargos] AFTER INSERT, UPDATE, DELETE AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @op CHAR(1) = CASE WHEN EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted) THEN 'U'
                               WHEN EXISTS (SELECT 1 FROM inserted) THEN 'I' ELSE 'D' END;

    INSERT INTO dbo.Auditoria (Usuario, Tabla, Operacion, Clave, Antes, Despues)
    SELECT CAST(SESSION_CONTEXT(N'Usuario') AS NVARCHAR(50)), N'Cargos', @op,
           CAST(CAST(COALESCE(i.[IdCargo], d.[IdCargo]) AS NVARCHAR(100)) AS NVARCHAR(100)),
           x.Antes, x.Despues
    FROM inserted i
    FULL OUTER JOIN deleted d ON d.[IdCargo] = i.[IdCargo]
    CROSS APPLY (SELECT
        Antes   = CASE WHEN @op = 'I' THEN NULL ELSE (SELECT
            d.[IdCargo], d.[NombreCargo]
            FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) END,
        Despues = CASE WHEN @op = 'D' THEN NULL ELSE (SELECT
            i.[IdCargo], i.[NombreCargo]
            FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) END) x
    WHERE @op <> 'U' OR ISNULL(x.Antes, N'') <> ISNULL(x.Despues, N'');
END
GO

-- Registro de actividad de ConfiguracionEmpresa: guarda quién, cuándo y el contenido antes y después (JSON) en Auditoria.
CREATE OR ALTER TRIGGER dbo.[trg_Aud_ConfiguracionEmpresa] ON dbo.[ConfiguracionEmpresa] AFTER INSERT, UPDATE, DELETE AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @op CHAR(1) = CASE WHEN EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted) THEN 'U'
                               WHEN EXISTS (SELECT 1 FROM inserted) THEN 'I' ELSE 'D' END;

    INSERT INTO dbo.Auditoria (Usuario, Tabla, Operacion, Clave, Antes, Despues)
    SELECT CAST(SESSION_CONTEXT(N'Usuario') AS NVARCHAR(50)), N'ConfiguracionEmpresa', @op,
           CAST(CAST(COALESCE(i.[IdConfig], d.[IdConfig]) AS NVARCHAR(100)) AS NVARCHAR(100)),
           x.Antes, x.Despues
    FROM inserted i
    FULL OUTER JOIN deleted d ON d.[IdConfig] = i.[IdConfig]
    CROSS APPLY (SELECT
        Antes   = CASE WHEN @op = 'I' THEN NULL ELSE (SELECT
            d.[IdConfig], d.[NombreEmpresa], d.[Direccion], d.[Telefono], d.[Correo],
            d.[InfoGeneral], d.[FechaConfig]
            FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) END,
        Despues = CASE WHEN @op = 'D' THEN NULL ELSE (SELECT
            i.[IdConfig], i.[NombreEmpresa], i.[Direccion], i.[Telefono], i.[Correo],
            i.[InfoGeneral], i.[FechaConfig]
            FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) END) x
    WHERE @op <> 'U' OR ISNULL(x.Antes, N'') <> ISNULL(x.Despues, N'');
END
GO

-- Registro de actividad de EmpleadoMaterias: guarda quién, cuándo y el contenido antes y después (JSON) en Auditoria.
CREATE OR ALTER TRIGGER dbo.[trg_Aud_EmpleadoMaterias] ON dbo.[EmpleadoMaterias] AFTER INSERT, UPDATE, DELETE AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @op CHAR(1) = CASE WHEN EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted) THEN 'U'
                               WHEN EXISTS (SELECT 1 FROM inserted) THEN 'I' ELSE 'D' END;

    INSERT INTO dbo.Auditoria (Usuario, Tabla, Operacion, Clave, Antes, Despues)
    SELECT CAST(SESSION_CONTEXT(N'Usuario') AS NVARCHAR(50)), N'EmpleadoMaterias', @op,
           CAST(CONCAT_WS(N'-', CAST(COALESCE(i.[IdEmpleado], d.[IdEmpleado]) AS NVARCHAR(100)), CAST(COALESCE(i.[IdMateria], d.[IdMateria]) AS NVARCHAR(100))) AS NVARCHAR(100)),
           x.Antes, x.Despues
    FROM inserted i
    FULL OUTER JOIN deleted d ON d.[IdEmpleado] = i.[IdEmpleado] AND d.[IdMateria] = i.[IdMateria]
    CROSS APPLY (SELECT
        Antes   = CASE WHEN @op = 'I' THEN NULL ELSE (SELECT
            d.[IdEmpleado], d.[IdMateria]
            FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) END,
        Despues = CASE WHEN @op = 'D' THEN NULL ELSE (SELECT
            i.[IdEmpleado], i.[IdMateria]
            FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) END) x
    WHERE @op <> 'U' OR ISNULL(x.Antes, N'') <> ISNULL(x.Despues, N'');
END
GO

-- Registro de actividad de Empleados: guarda quién, cuándo y el contenido antes y después (JSON) en Auditoria.
CREATE OR ALTER TRIGGER dbo.[trg_Aud_Empleados] ON dbo.[Empleados] AFTER INSERT, UPDATE, DELETE AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @op CHAR(1) = CASE WHEN EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted) THEN 'U'
                               WHEN EXISTS (SELECT 1 FROM inserted) THEN 'I' ELSE 'D' END;

    INSERT INTO dbo.Auditoria (Usuario, Tabla, Operacion, Clave, Antes, Despues)
    SELECT CAST(SESSION_CONTEXT(N'Usuario') AS NVARCHAR(50)), N'Empleados', @op,
           CAST(CAST(COALESCE(i.[IdEmpleado], d.[IdEmpleado]) AS NVARCHAR(100)) AS NVARCHAR(100)),
           x.Antes, x.Despues
    FROM inserted i
    FULL OUTER JOIN deleted d ON d.[IdEmpleado] = i.[IdEmpleado]
    CROSS APPLY (SELECT
        Antes   = CASE WHEN @op = 'I' THEN NULL ELSE (SELECT
            d.[IdEmpleado], d.[Nombre], d.[FechaContratacion], d.[IdCargo], d.[IdEstado],
            d.[IdPlanilla], d.[FechaNacimiento], d.[EstadoCivil], d.[Religion], d.[Telefono],
            d.[Correo], d.[Direccion], d.[DUI], d.[ContactoEmergenciaNombre],
            d.[ContactoEmergenciaParentesco], d.[ContactoEmergenciaTelefono], d.[Especialidad]
            FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) END,
        Despues = CASE WHEN @op = 'D' THEN NULL ELSE (SELECT
            i.[IdEmpleado], i.[Nombre], i.[FechaContratacion], i.[IdCargo], i.[IdEstado],
            i.[IdPlanilla], i.[FechaNacimiento], i.[EstadoCivil], i.[Religion], i.[Telefono],
            i.[Correo], i.[Direccion], i.[DUI], i.[ContactoEmergenciaNombre],
            i.[ContactoEmergenciaParentesco], i.[ContactoEmergenciaTelefono], i.[Especialidad]
            FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) END) x
    WHERE @op <> 'U' OR ISNULL(x.Antes, N'') <> ISNULL(x.Despues, N'');
END
GO

-- Registro de actividad de GestionActivos: guarda quién, cuándo y el contenido antes y después (JSON) en Auditoria.
CREATE OR ALTER TRIGGER dbo.[trg_Aud_GestionActivos] ON dbo.[GestionActivos] AFTER INSERT, UPDATE, DELETE AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @op CHAR(1) = CASE WHEN EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted) THEN 'U'
                               WHEN EXISTS (SELECT 1 FROM inserted) THEN 'I' ELSE 'D' END;

    INSERT INTO dbo.Auditoria (Usuario, Tabla, Operacion, Clave, Antes, Despues)
    SELECT CAST(SESSION_CONTEXT(N'Usuario') AS NVARCHAR(50)), N'GestionActivos', @op,
           CAST(CAST(COALESCE(i.[IdActivo], d.[IdActivo]) AS NVARCHAR(100)) AS NVARCHAR(100)),
           x.Antes, x.Despues
    FROM inserted i
    FULL OUTER JOIN deleted d ON d.[IdActivo] = i.[IdActivo]
    CROSS APPLY (SELECT
        Antes   = CASE WHEN @op = 'I' THEN NULL ELSE (SELECT
            d.[IdActivo], d.[Nombre], d.[IdCategoria], d.[CodigoInventario], d.[IdUbicacion]
            FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) END,
        Despues = CASE WHEN @op = 'D' THEN NULL ELSE (SELECT
            i.[IdActivo], i.[Nombre], i.[IdCategoria], i.[CodigoInventario], i.[IdUbicacion]
            FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) END) x
    WHERE @op <> 'U' OR ISNULL(x.Antes, N'') <> ISNULL(x.Despues, N'');
END
GO

-- Registro de actividad de MantenimientosActivo: guarda quién, cuándo y el contenido antes y después (JSON) en Auditoria.
CREATE OR ALTER TRIGGER dbo.[trg_Aud_MantenimientosActivo] ON dbo.[MantenimientosActivo] AFTER INSERT, UPDATE, DELETE AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @op CHAR(1) = CASE WHEN EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted) THEN 'U'
                               WHEN EXISTS (SELECT 1 FROM inserted) THEN 'I' ELSE 'D' END;

    INSERT INTO dbo.Auditoria (Usuario, Tabla, Operacion, Clave, Antes, Despues)
    SELECT CAST(SESSION_CONTEXT(N'Usuario') AS NVARCHAR(50)), N'MantenimientosActivo', @op,
           CAST(CAST(COALESCE(i.[IdMantenimiento], d.[IdMantenimiento]) AS NVARCHAR(100)) AS NVARCHAR(100)),
           x.Antes, x.Despues
    FROM inserted i
    FULL OUTER JOIN deleted d ON d.[IdMantenimiento] = i.[IdMantenimiento]
    CROSS APPLY (SELECT
        Antes   = CASE WHEN @op = 'I' THEN NULL ELSE (SELECT
            d.[IdMantenimiento], d.[IdActivo], d.[IdUnidad], d.[CodigoInventario], d.[Fecha],
            d.[Tipo], d.[Descripcion], d.[Costo], d.[IdEstadoResultante], d.[IdReporte],
            d.[RealizadoPor]
            FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) END,
        Despues = CASE WHEN @op = 'D' THEN NULL ELSE (SELECT
            i.[IdMantenimiento], i.[IdActivo], i.[IdUnidad], i.[CodigoInventario], i.[Fecha],
            i.[Tipo], i.[Descripcion], i.[Costo], i.[IdEstadoResultante], i.[IdReporte],
            i.[RealizadoPor]
            FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) END) x
    WHERE @op <> 'U' OR ISNULL(x.Antes, N'') <> ISNULL(x.Despues, N'');
END
GO

-- Registro de actividad de Materias: guarda quién, cuándo y el contenido antes y después (JSON) en Auditoria.
CREATE OR ALTER TRIGGER dbo.[trg_Aud_Materias] ON dbo.[Materias] AFTER INSERT, UPDATE, DELETE AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @op CHAR(1) = CASE WHEN EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted) THEN 'U'
                               WHEN EXISTS (SELECT 1 FROM inserted) THEN 'I' ELSE 'D' END;

    INSERT INTO dbo.Auditoria (Usuario, Tabla, Operacion, Clave, Antes, Despues)
    SELECT CAST(SESSION_CONTEXT(N'Usuario') AS NVARCHAR(50)), N'Materias', @op,
           CAST(CAST(COALESCE(i.[IdMateria], d.[IdMateria]) AS NVARCHAR(100)) AS NVARCHAR(100)),
           x.Antes, x.Despues
    FROM inserted i
    FULL OUTER JOIN deleted d ON d.[IdMateria] = i.[IdMateria]
    CROSS APPLY (SELECT
        Antes   = CASE WHEN @op = 'I' THEN NULL ELSE (SELECT
            d.[IdMateria], d.[NombreMateria], d.[Activa]
            FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) END,
        Despues = CASE WHEN @op = 'D' THEN NULL ELSE (SELECT
            i.[IdMateria], i.[NombreMateria], i.[Activa]
            FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) END) x
    WHERE @op <> 'U' OR ISNULL(x.Antes, N'') <> ISNULL(x.Despues, N'');
END
GO

-- Registro de actividad de PagosPlanilla: guarda quién, cuándo y el contenido antes y después (JSON) en Auditoria.
CREATE OR ALTER TRIGGER dbo.[trg_Aud_PagosPlanilla] ON dbo.[PagosPlanilla] AFTER INSERT, UPDATE, DELETE AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @op CHAR(1) = CASE WHEN EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted) THEN 'U'
                               WHEN EXISTS (SELECT 1 FROM inserted) THEN 'I' ELSE 'D' END;

    INSERT INTO dbo.Auditoria (Usuario, Tabla, Operacion, Clave, Antes, Despues)
    SELECT CAST(SESSION_CONTEXT(N'Usuario') AS NVARCHAR(50)), N'PagosPlanilla', @op,
           CAST(CAST(COALESCE(i.[IdPago], d.[IdPago]) AS NVARCHAR(100)) AS NVARCHAR(100)),
           x.Antes, x.Despues
    FROM inserted i
    FULL OUTER JOIN deleted d ON d.[IdPago] = i.[IdPago]
    CROSS APPLY (SELECT
        Antes   = CASE WHEN @op = 'I' THEN NULL ELSE (SELECT
            d.[IdPago], d.[IdEmpleado], d.[Periodo], d.[SalarioBase], d.[Bono], d.[Descuento],
            d.[SalarioNeto], d.[EstadoPago], d.[FechaPago], d.[Observacion], d.[Anulado],
            d.[FechaRegistro], d.[DiasAusencia], d.[DescuentoAusencias]
            FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) END,
        Despues = CASE WHEN @op = 'D' THEN NULL ELSE (SELECT
            i.[IdPago], i.[IdEmpleado], i.[Periodo], i.[SalarioBase], i.[Bono], i.[Descuento],
            i.[SalarioNeto], i.[EstadoPago], i.[FechaPago], i.[Observacion], i.[Anulado],
            i.[FechaRegistro], i.[DiasAusencia], i.[DescuentoAusencias]
            FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) END) x
    WHERE @op <> 'U' OR ISNULL(x.Antes, N'') <> ISNULL(x.Despues, N'');
END
GO

-- Registro de actividad de PeriodosPlanilla: guarda quién, cuándo y el contenido antes y después (JSON) en Auditoria.
CREATE OR ALTER TRIGGER dbo.[trg_Aud_PeriodosPlanilla] ON dbo.[PeriodosPlanilla] AFTER INSERT, UPDATE, DELETE AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @op CHAR(1) = CASE WHEN EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted) THEN 'U'
                               WHEN EXISTS (SELECT 1 FROM inserted) THEN 'I' ELSE 'D' END;

    INSERT INTO dbo.Auditoria (Usuario, Tabla, Operacion, Clave, Antes, Despues)
    SELECT CAST(SESSION_CONTEXT(N'Usuario') AS NVARCHAR(50)), N'PeriodosPlanilla', @op,
           CAST(CAST(COALESCE(i.[Periodo], d.[Periodo]) AS NVARCHAR(100)) AS NVARCHAR(100)),
           x.Antes, x.Despues
    FROM inserted i
    FULL OUTER JOIN deleted d ON d.[Periodo] = i.[Periodo]
    CROSS APPLY (SELECT
        Antes   = CASE WHEN @op = 'I' THEN NULL ELSE (SELECT
            d.[Periodo], d.[Cerrado], d.[FechaCierre], d.[CerradoPor]
            FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) END,
        Despues = CASE WHEN @op = 'D' THEN NULL ELSE (SELECT
            i.[Periodo], i.[Cerrado], i.[FechaCierre], i.[CerradoPor]
            FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) END) x
    WHERE @op <> 'U' OR ISNULL(x.Antes, N'') <> ISNULL(x.Despues, N'');
END
GO

-- Registro de actividad de Planillas: guarda quién, cuándo y el contenido antes y después (JSON) en Auditoria.
CREATE OR ALTER TRIGGER dbo.[trg_Aud_Planillas] ON dbo.[Planillas] AFTER INSERT, UPDATE, DELETE AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @op CHAR(1) = CASE WHEN EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted) THEN 'U'
                               WHEN EXISTS (SELECT 1 FROM inserted) THEN 'I' ELSE 'D' END;

    INSERT INTO dbo.Auditoria (Usuario, Tabla, Operacion, Clave, Antes, Despues)
    SELECT CAST(SESSION_CONTEXT(N'Usuario') AS NVARCHAR(50)), N'Planillas', @op,
           CAST(CAST(COALESCE(i.[IdPlanilla], d.[IdPlanilla]) AS NVARCHAR(100)) AS NVARCHAR(100)),
           x.Antes, x.Despues
    FROM inserted i
    FULL OUTER JOIN deleted d ON d.[IdPlanilla] = i.[IdPlanilla]
    CROSS APPLY (SELECT
        Antes   = CASE WHEN @op = 'I' THEN NULL ELSE (SELECT
            d.[IdPlanilla], d.[SalarioBase], d.[Descuento], d.[Bono], d.[SalarioNeto],
            d.[Estado]
            FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) END,
        Despues = CASE WHEN @op = 'D' THEN NULL ELSE (SELECT
            i.[IdPlanilla], i.[SalarioBase], i.[Descuento], i.[Bono], i.[SalarioNeto],
            i.[Estado]
            FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) END) x
    WHERE @op <> 'U' OR ISNULL(x.Antes, N'') <> ISNULL(x.Despues, N'');
END
GO

-- Registro de actividad de Prestamos: guarda quién, cuándo y el contenido antes y después (JSON) en Auditoria.
CREATE OR ALTER TRIGGER dbo.[trg_Aud_Prestamos] ON dbo.[Prestamos] AFTER INSERT, UPDATE, DELETE AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @op CHAR(1) = CASE WHEN EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted) THEN 'U'
                               WHEN EXISTS (SELECT 1 FROM inserted) THEN 'I' ELSE 'D' END;

    INSERT INTO dbo.Auditoria (Usuario, Tabla, Operacion, Clave, Antes, Despues)
    SELECT CAST(SESSION_CONTEXT(N'Usuario') AS NVARCHAR(50)), N'Prestamos', @op,
           CAST(CAST(COALESCE(i.[IdPrestamo], d.[IdPrestamo]) AS NVARCHAR(100)) AS NVARCHAR(100)),
           x.Antes, x.Despues
    FROM inserted i
    FULL OUTER JOIN deleted d ON d.[IdPrestamo] = i.[IdPrestamo]
    CROSS APPLY (SELECT
        Antes   = CASE WHEN @op = 'I' THEN NULL ELSE (SELECT
            d.[IdPrestamo], d.[IdActivo], d.[IdUnidad], d.[CodigoInventario], d.[Cantidad],
            d.[TipoResponsable], d.[Responsable], d.[IdSalonDestino], d.[FechaEntrega],
            d.[FechaLimite], d.[Estado], d.[FechaDevolucion], d.[IdEstadoDevolucion],
            d.[ObservacionSalida], d.[ObservacionDevolucion], d.[EntregadoPor], d.[IdEmpleado]
            FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) END,
        Despues = CASE WHEN @op = 'D' THEN NULL ELSE (SELECT
            i.[IdPrestamo], i.[IdActivo], i.[IdUnidad], i.[CodigoInventario], i.[Cantidad],
            i.[TipoResponsable], i.[Responsable], i.[IdSalonDestino], i.[FechaEntrega],
            i.[FechaLimite], i.[Estado], i.[FechaDevolucion], i.[IdEstadoDevolucion],
            i.[ObservacionSalida], i.[ObservacionDevolucion], i.[EntregadoPor], i.[IdEmpleado]
            FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) END) x
    WHERE @op <> 'U' OR ISNULL(x.Antes, N'') <> ISNULL(x.Despues, N'');
END
GO

-- Registro de actividad de ReportesDanio: guarda quién, cuándo y el contenido antes y después (JSON) en Auditoria.
CREATE OR ALTER TRIGGER dbo.[trg_Aud_ReportesDanio] ON dbo.[ReportesDanio] AFTER INSERT, UPDATE, DELETE AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @op CHAR(1) = CASE WHEN EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted) THEN 'U'
                               WHEN EXISTS (SELECT 1 FROM inserted) THEN 'I' ELSE 'D' END;

    INSERT INTO dbo.Auditoria (Usuario, Tabla, Operacion, Clave, Antes, Despues)
    SELECT CAST(SESSION_CONTEXT(N'Usuario') AS NVARCHAR(50)), N'ReportesDanio', @op,
           CAST(CAST(COALESCE(i.[IdReporte], d.[IdReporte]) AS NVARCHAR(100)) AS NVARCHAR(100)),
           x.Antes, x.Despues
    FROM inserted i
    FULL OUTER JOIN deleted d ON d.[IdReporte] = i.[IdReporte]
    CROSS APPLY (SELECT
        Antes   = CASE WHEN @op = 'I' THEN NULL ELSE (SELECT
            d.[IdReporte], d.[IdSalon], d.[IdActivo], d.[IdUnidad], d.[CodigoInventario],
            d.[Cantidad], d.[Prioridad], d.[Descripcion], d.[ReportadoPor], d.[FechaReporte],
            d.[Estado], d.[FechaReparacion], d.[ReparadoPor], d.[ObservacionReparacion]
            FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) END,
        Despues = CASE WHEN @op = 'D' THEN NULL ELSE (SELECT
            i.[IdReporte], i.[IdSalon], i.[IdActivo], i.[IdUnidad], i.[CodigoInventario],
            i.[Cantidad], i.[Prioridad], i.[Descripcion], i.[ReportadoPor], i.[FechaReporte],
            i.[Estado], i.[FechaReparacion], i.[ReparadoPor], i.[ObservacionReparacion]
            FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) END) x
    WHERE @op <> 'U' OR ISNULL(x.Antes, N'') <> ISNULL(x.Despues, N'');
END
GO

-- Registro de actividad de Salones: guarda quién, cuándo y el contenido antes y después (JSON) en Auditoria.
CREATE OR ALTER TRIGGER dbo.[trg_Aud_Salones] ON dbo.[Salones] AFTER INSERT, UPDATE, DELETE AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @op CHAR(1) = CASE WHEN EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted) THEN 'U'
                               WHEN EXISTS (SELECT 1 FROM inserted) THEN 'I' ELSE 'D' END;

    INSERT INTO dbo.Auditoria (Usuario, Tabla, Operacion, Clave, Antes, Despues)
    SELECT CAST(SESSION_CONTEXT(N'Usuario') AS NVARCHAR(50)), N'Salones', @op,
           CAST(CAST(COALESCE(i.[IdSalon], d.[IdSalon]) AS NVARCHAR(100)) AS NVARCHAR(100)),
           x.Antes, x.Despues
    FROM inserted i
    FULL OUTER JOIN deleted d ON d.[IdSalon] = i.[IdSalon]
    CROSS APPLY (SELECT
        Antes   = CASE WHEN @op = 'I' THEN NULL ELSE (SELECT
            d.[IdSalon], d.[NombreSalon], d.[Tipo], d.[Capacidad], d.[Edificio],
            d.[IdResponsable], d.[Activo], d.[Observacion]
            FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) END,
        Despues = CASE WHEN @op = 'D' THEN NULL ELSE (SELECT
            i.[IdSalon], i.[NombreSalon], i.[Tipo], i.[Capacidad], i.[Edificio],
            i.[IdResponsable], i.[Activo], i.[Observacion]
            FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) END) x
    WHERE @op <> 'U' OR ISNULL(x.Antes, N'') <> ISNULL(x.Despues, N'');
END
GO

-- Registro de actividad de UnidadesActivo: guarda quién, cuándo y el contenido antes y después (JSON) en Auditoria.
CREATE OR ALTER TRIGGER dbo.[trg_Aud_UnidadesActivo] ON dbo.[UnidadesActivo] AFTER INSERT, UPDATE, DELETE AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @op CHAR(1) = CASE WHEN EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted) THEN 'U'
                               WHEN EXISTS (SELECT 1 FROM inserted) THEN 'I' ELSE 'D' END;

    INSERT INTO dbo.Auditoria (Usuario, Tabla, Operacion, Clave, Antes, Despues)
    SELECT CAST(SESSION_CONTEXT(N'Usuario') AS NVARCHAR(50)), N'UnidadesActivo', @op,
           CAST(CAST(COALESCE(i.[IdUnidad], d.[IdUnidad]) AS NVARCHAR(100)) AS NVARCHAR(100)),
           x.Antes, x.Despues
    FROM inserted i
    FULL OUTER JOIN deleted d ON d.[IdUnidad] = i.[IdUnidad]
    CROSS APPLY (SELECT
        Antes   = CASE WHEN @op = 'I' THEN NULL ELSE (SELECT
            d.[IdUnidad], d.[IdActivo], d.[IdSalon], d.[CodigoInventario], d.[IdEstado],
            d.[FechaAlta], d.[Observacion], d.[CostoUnitario], d.[FechaAdquisicion],
            d.[Proveedor], d.[FechaBaja], d.[MotivoBaja]
            FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) END,
        Despues = CASE WHEN @op = 'D' THEN NULL ELSE (SELECT
            i.[IdUnidad], i.[IdActivo], i.[IdSalon], i.[CodigoInventario], i.[IdEstado],
            i.[FechaAlta], i.[Observacion], i.[CostoUnitario], i.[FechaAdquisicion],
            i.[Proveedor], i.[FechaBaja], i.[MotivoBaja]
            FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) END) x
    WHERE @op <> 'U' OR ISNULL(x.Antes, N'') <> ISNULL(x.Despues, N'');
END
GO

-- Registro de actividad de Usuarios: guarda quién, cuándo y el contenido antes y después (JSON) en Auditoria. Sin las columnas Clave ni UltimoAcceso.
CREATE OR ALTER TRIGGER dbo.[trg_Aud_Usuarios] ON dbo.[Usuarios] AFTER INSERT, UPDATE, DELETE AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @op CHAR(1) = CASE WHEN EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted) THEN 'U'
                               WHEN EXISTS (SELECT 1 FROM inserted) THEN 'I' ELSE 'D' END;

    INSERT INTO dbo.Auditoria (Usuario, Tabla, Operacion, Clave, Antes, Despues)
    SELECT CAST(SESSION_CONTEXT(N'Usuario') AS NVARCHAR(50)), N'Usuarios', @op,
           CAST(CAST(COALESCE(i.[IdUsuario], d.[IdUsuario]) AS NVARCHAR(100)) AS NVARCHAR(100)),
           x.Antes, x.Despues
    FROM inserted i
    FULL OUTER JOIN deleted d ON d.[IdUsuario] = i.[IdUsuario]
    CROSS APPLY (SELECT
        Antes   = CASE WHEN @op = 'I' THEN NULL ELSE (SELECT
            d.[IdUsuario], d.[Usuario], d.[IdRol], d.[Correo], d.[CorreoVerificado], d.[Activo],
            d.[NombreCompleto], d.[DebeCambiarClave], d.[FechaCreacion], d.[CreadoPor]
            FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) END,
        Despues = CASE WHEN @op = 'D' THEN NULL ELSE (SELECT
            i.[IdUsuario], i.[Usuario], i.[IdRol], i.[Correo], i.[CorreoVerificado], i.[Activo],
            i.[NombreCompleto], i.[DebeCambiarClave], i.[FechaCreacion], i.[CreadoPor]
            FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) END) x
    WHERE @op <> 'U' OR ISNULL(x.Antes, N'') <> ISNULL(x.Despues, N'');
END
GO

/* =====================================================================
   7. DATOS INICIALES (solo si la tabla esta vacia)
   ===================================================================== */
-- Los cambios de esta seccion y de la siguiente quedan en el historial a nombre de "Script de instalación".
EXEC sys.sp_set_session_context @key = N'Usuario', @value = N'Script de instalación', @read_only = 0;
GO

-- El orden de insercion fija los Id y el programa depende de ellos
-- (EstadosEmpleado: 1 = Activo, 2 = Inactivo).
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

-- Fin de la seccion 7: se quita el usuario de sesion (la seccion 8 lo vuelve a fijar).
EXEC sys.sp_set_session_context @key = N'Usuario', @value = NULL;
GO

/* =====================================================================
   8. DATOS DE EJEMPLO DE LA INSTITUCION
   ===================================================================== */
-- Cada dato se inserta solo si falta (empleados, salones y tipos de equipo, por nombre; estructuras
-- salariales, por importes; unidades y reportes, solo si no existe ninguna unidad), asi que se puede
-- ejecutar de nuevo sin duplicar. Lo unico que toca de lo existente es completar FechaBaja y MotivoBaja
-- vacios de unidades 'Dado de baja'. Los cambios quedan en el historial a nombre de "Script de instalación".
EXEC sys.sp_set_session_context @key = N'Usuario', @value = N'Script de instalación', @read_only = 0;
GO

-- 8.1 y 8.2 Estructuras salariales (catalogo de salarios) y empleados (50: direccion, docentes,
--     administrativos y servicios). Niveles: A = Director · B = Subdireccion/Coordinacion ·
--     C = Docentes · D = Administrativo/tecnico · E = Servicios generales
IF OBJECT_ID('tempdb..#Niveles') IS NOT NULL DROP TABLE #Niveles;
CREATE TABLE #Niveles (
    Nivel       CHAR(1) PRIMARY KEY,
    SalarioBase DECIMAL(10,2), Descuento DECIMAL(10,2), Bono DECIMAL(10,2)
);
INSERT INTO #Niveles VALUES
    ('A', 1800.00, 184.50, 200.00),
    ('B', 1400.00, 143.50, 150.00),
    ('C',  900.00,  92.25,  50.00),
    ('D',  750.00,  76.88,  25.00),
    ('E',  520.00,  53.30,   0.00);

IF OBJECT_ID('tempdb..#Nuevos') IS NOT NULL DROP TABLE #Nuevos;
CREATE TABLE #Nuevos (
    Nombre NVARCHAR(200), Cargo NVARCHAR(100), Nivel CHAR(1),
    Contratacion DATE, Nacimiento DATE,
    EstadoCivil NVARCHAR(50), Religion NVARCHAR(50),
    Telefono NVARCHAR(20), Correo NVARCHAR(100), Estado NVARCHAR(50)
);

INSERT INTO #Nuevos VALUES
(N'Carlos Alberto Mejía Hernández',     N'Director',                    'A','2012-01-16','1978-03-14',N'Casado/a',     N'Católica',  N'7845-1203',N'carlos.mejia@smartschool.edu.sv',     N'Activo'),
(N'Ana Patricia Ramírez Flores',        N'Subdirectora',                'B','2013-02-04','1981-07-22',N'Casado/a',     N'Católica',  N'7712-3456',N'ana.ramirez@smartschool.edu.sv',      N'Activo'),
(N'Roberto Antonio Vásquez Cruz',       N'Coordinador Académico',       'B','2015-01-12','1984-11-05',N'Casado/a',     N'Evangélica',N'7390-8821',N'roberto.vasquez@smartschool.edu.sv',  N'Activo'),
(N'Luis Fernando Orellana Pérez',       N'Docente de Sistemas',         'C','2018-01-15','1990-05-19',N'Soltero/a',    N'Católica',  N'7601-2278',N'luis.orellana@smartschool.edu.sv',    N'Activo'),
(N'Karla Jeannette Guzmán Rivas',       N'Docente de Sistemas',         'C','2016-02-01','1988-09-30',N'Unión libre',  N'Evangélica',N'7234-9087',N'karla.guzman@smartschool.edu.sv',     N'Activo'),
(N'José Manuel Cárcamo Rosales',        N'Docente de Sistemas',         'C','2020-01-13','1992-02-11',N'Soltero/a',    N'Ninguna',   N'6987-4412',N'jose.carcamo@smartschool.edu.sv',     N'Activo'),
(N'Daniela Michelle Argueta Sorto',     N'Docente de Sistemas',         'C','2022-02-07','1995-12-03',N'Soltero/a',    N'Católica',  N'7156-3390',N'daniela.argueta@smartschool.edu.sv',  N'Activo'),
(N'Miguel Ángel Portillo Segovia',      N'Docente de Matemáticas',      'C','2014-01-20','1983-04-27',N'Casado/a',     N'Católica',  N'7423-6615',N'miguel.portillo@smartschool.edu.sv',  N'Activo'),
(N'Rosa Elena Chávez Menjívar',         N'Docente de Matemáticas',      'C','2012-02-06','1979-08-16',N'Divorciado/a', N'Católica',  N'7068-1934',N'rosa.chavez@smartschool.edu.sv',      N'Activo'),
(N'Héctor Daniel Quintanilla Mendoza',  N'Docente de Matemáticas',      'C','2019-01-14','1991-10-09',N'Soltero/a',    N'Evangélica',N'7539-4701',N'hector.quintanilla@smartschool.edu.sv',N'Activo'),
(N'Gabriela Alejandra Linares Castro',  N'Docente de Matemáticas',      'C','2021-02-01','1994-06-25',N'Soltero/a',    N'Católica',  N'6812-7745',N'gabriela.linares@smartschool.edu.sv', N'Activo'),
(N'Francisco Javier Alvarado Ponce',    N'Docente de Física',           'C','2013-01-14','1980-01-31',N'Casado/a',     N'Católica',  N'7276-5528',N'francisco.alvarado@smartschool.edu.sv',N'Activo'),
(N'Sofía Valentina Cruz Alfaro',        N'Docente de Física',           'C','2020-02-03','1993-03-08',N'Soltero/a',    N'Ninguna',   N'7714-0963',N'sofia.cruz@smartschool.edu.sv',       N'Activo'),
(N'Jennifer Lizeth Martínez Aguilar',   N'Docente de Inglés',           'C','2017-01-16','1989-07-12',N'Casado/a',     N'Evangélica',N'7365-8140',N'jennifer.martinez@smartschool.edu.sv',N'Activo'),
(N'Kevin Alexander Rodríguez Barrera',  N'Docente de Inglés',           'C','2021-01-18','1993-11-20',N'Soltero/a',    N'Católica',  N'6745-2219',N'kevin.rodriguez@smartschool.edu.sv',  N'Activo'),
(N'Mónica Beatriz Hernández Ayala',     N'Docente de Inglés',           'C','2015-02-02','1986-05-04',N'Unión libre',  N'Católica',  N'7092-6677',N'monica.hernandez@smartschool.edu.sv', N'Activo'),
(N'Andrés Eduardo Salazar Molina',      N'Docente de Inglés',           'C','2023-01-16','1996-09-14',N'Soltero/a',    N'Ninguna',   N'7881-3304',N'andres.salazar@smartschool.edu.sv',   N'Activo'),
(N'Ricardo Josué Peña Gómez',           N'Docente de Natacion',         'C','2019-02-04','1991-12-28',N'Soltero/a',    N'Evangélica',N'7430-5592',N'ricardo.pena@smartschool.edu.sv',     N'Activo'),
(N'María José Escobar Henríquez',       N'Docente de Ciencias',         'C','2016-01-18','1987-02-17',N'Casado/a',     N'Católica',  N'7517-1186',N'maria.escobar@smartschool.edu.sv',    N'Activo'),
(N'Jorge Armando Fuentes Navarro',      N'Docente de Ciencias',         'C','2014-02-03','1982-10-23',N'Casado/a',     N'Católica',  N'7208-7430',N'jorge.fuentes@smartschool.edu.sv',    N'Activo'),
(N'Lissette Carolina Campos Rivera',    N'Docente de Ciencias',         'C','2018-02-05','1990-08-06',N'Soltero/a',    N'Evangélica',N'6633-9051',N'lissette.campos@smartschool.edu.sv',  N'Activo'),
(N'Óscar René Guardado Solís',          N'Docente de Ciencias',         'C','2012-01-16','1977-04-02',N'Viudo/a',      N'Católica',  N'7959-2467',N'oscar.guardado@smartschool.edu.sv',   N'Inactivo'),
(N'Verónica Isabel Henríquez Mora',     N'Docente de Sociales',         'C','2015-01-19','1985-06-18',N'Casado/a',     N'Católica',  N'7344-0818',N'veronica.henriquez@smartschool.edu.sv',N'Activo'),
(N'Walter Alexander Benítez Cañas',     N'Docente de Sociales',         'C','2013-02-04','1981-03-29',N'Divorciado/a', N'Evangélica',N'7126-5973',N'walter.benitez@smartschool.edu.sv',   N'Activo'),
(N'Claudia Marisol Pineda Ortiz',       N'Docente de Sociales',         'C','2020-01-20','1992-11-15',N'Soltero/a',    N'Católica',  N'6578-3626',N'claudia.pineda@smartschool.edu.sv',   N'Activo'),
(N'Edwin Stanley Rivas Amaya',          N'Docente de Sociales',         'C','2022-01-17','1994-01-07',N'Soltero/a',    N'Ninguna',   N'7803-1749',N'edwin.rivas@smartschool.edu.sv',      N'Activo'),
(N'Mauricio Ernesto Cortez Valle',      N'Docente de Educación Física', 'C','2014-01-13','1984-09-03',N'Casado/a',     N'Católica',  N'7461-8205',N'mauricio.cortez@smartschool.edu.sv',  N'Activo'),
(N'Cristina Yamileth Lemus Barahona',   N'Docente de Educación Física', 'C','2023-02-06','1996-05-21',N'Soltero/a',    N'Católica',  N'6924-4358',N'cristina.lemus@smartschool.edu.sv',   N'Activo'),
(N'Raúl Antonio Martínez Villalta',     N'Docente de Educación Física', 'C','2018-01-22','1989-12-10',N'Unión libre',  N'Evangélica',N'7037-9612',N'raul.martinez@smartschool.edu.sv',    N'Activo'),
(N'Wendy Johana Mendoza Reyes',         N'Secretaria Administrativa',   'D','2016-01-11','1988-04-13',N'Casado/a',     N'Evangélica',N'7582-3071',N'wendy.mendoza@smartschool.edu.sv',    N'Activo'),
(N'Irma Yaneth Castillo Rauda',         N'Secretaria Administrativa',   'D','2012-02-01','1976-10-26',N'Divorciado/a', N'Católica',  N'7219-6484',N'irma.castillo@smartschool.edu.sv',    N'Activo'),
(N'Julio César Amaya Bonilla',          N'Contador',                    'D','2013-01-07','1980-07-08',N'Casado/a',     N'Católica',  N'7675-2530',N'julio.amaya@smartschool.edu.sv',      N'Activo'),
(N'Fátima Nohemy Girón Alas',           N'Asistente Contable',          'D','2023-02-13','1997-03-19',N'Soltero/a',    N'Católica',  N'6396-7718',N'fatima.giron@smartschool.edu.sv',     N'Activo'),
(N'Teresa de Jesús Moreno Lara',        N'Bibliotecaria',               'D','2012-01-23','1972-08-30',N'Viudo/a',      N'Católica',  N'7148-0245',N'teresa.moreno@smartschool.edu.sv',    N'Activo'),
(N'Silvia Margarita Ventura Díaz',      N'Orientadora',                 'D','2014-02-10','1983-01-14',N'Casado/a',     N'Católica',  N'7790-5139',N'silvia.ventura@smartschool.edu.sv',   N'Activo'),
(N'Lorena Beatriz Cáceres Sandoval',    N'Psicóloga Escolar',           'D','2019-01-21','1990-06-05',N'Soltero/a',    N'Ninguna',   N'6851-6082',N'lorena.caceres@smartschool.edu.sv',   N'Activo'),
(N'Blanca Estela Hernández Acosta',     N'Enfermera',                   'D','2015-02-09','1979-11-27',N'Casado/a',     N'Evangélica',N'7323-9467',N'blanca.hernandez@smartschool.edu.sv', N'Activo'),
(N'Nelson Rolando Tobar Paz',           N'Técnico de Laboratorio',      'D','2016-02-08','1987-02-24',N'Casado/a',     N'Católica',  N'7406-1853',N'nelson.tobar@smartschool.edu.sv',     N'Activo'),
(N'Diana Carolina Funes Pacheco',       N'Técnico de Laboratorio',      'D','2022-01-24','1995-09-02',N'Soltero/a',    N'Católica',  N'6709-4926',N'diana.funes@smartschool.edu.sv',      N'Activo'),
(N'Bryan Josué Alfaro Cienfuegos',      N'Técnico de Soporte',          'D','2021-02-15','1997-07-17',N'Soltero/a',    N'Ninguna',   N'6272-3380',N'bryan.alfaro@smartschool.edu.sv',     N'Activo'),
(N'Rodrigo Alonso Medrano Flores',      N'Técnico de Soporte',          'D','2019-02-11','1991-04-11',N'Unión libre',  N'Católica',  N'7955-7014',N'rodrigo.medrano@smartschool.edu.sv',  N'Inactivo'),
(N'Santos Gilberto Rivera Mejía',       N'Jefe de Seguridad',           'D','2012-01-09','1975-12-06',N'Casado/a',     N'Evangélica',N'7101-2698',N'santos.rivera@smartschool.edu.sv',    N'Activo'),
(N'Estefany Michelle Gómez Arévalo',    N'Recepcionista',               'E','2024-01-15','1998-02-09',N'Soltero/a',    N'Católica',  N'6487-5531',N'estefany.gomez@smartschool.edu.sv',   N'Activo'),
(N'Pedro Antonio Villatoro Cruz',       N'Conserje',                    'E','2012-03-05','1970-06-12',N'Casado/a',     N'Católica',  N'7568-8847',N'pedro.villatoro@smartschool.edu.sv',  N'Activo'),
(N'Juan Carlos Ayala Rodas',            N'Conserje',                    'E','2017-02-06','1982-05-18',N'Unión libre',  N'Evangélica',N'7249-1362',N'juan.ayala@smartschool.edu.sv',       N'Activo'),
(N'María Luisa Reyes Torres',           N'Conserje',                    'E','2014-03-03','1975-09-23',N'Viudo/a',      N'Católica',  N'7833-6195',N'maria.reyes@smartschool.edu.sv',      N'Inactivo'),
(N'Josefina Alicia Marroquín Pérez',    N'Encargado de Limpieza',       'E','2013-03-04','1978-01-29',N'Casado/a',     N'Católica',  N'7012-4079',N'josefina.marroquin@smartschool.edu.sv',N'Activo'),
(N'Tomás Armando Escalante Rosa',       N'Encargado de Limpieza',       'E','2018-03-05','1985-10-15',N'Casado/a',     N'Evangélica',N'7694-3521',N'tomas.escalante@smartschool.edu.sv',  N'Activo'),
(N'Ernesto Wilfredo Guevara Palacios',  N'Chofer',                      'E','2013-02-18','1973-03-07',N'Casado/a',     N'Católica',  N'7370-0786',N'ernesto.guevara@smartschool.edu.sv',  N'Activo'),
(N'Alexis Manuel Rosales Duarte',       N'Chofer',                      'E','2022-03-07','1993-08-22',N'Soltero/a',    N'Ninguna',   N'6165-9243',N'alexis.rosales@smartschool.edu.sv',   N'Activo');

-- Una estructura salarial de ejemplo solo se crea si falta algun empleado de ese nivel y no hay una vigente igual.
-- Asi, si ya editaste o borraste una estructura y los empleados ya existen, no se vuelve a crear.
INSERT INTO dbo.Planillas (SalarioBase, Descuento, Bono, SalarioNeto, Estado)
SELECT v.SalarioBase, v.Descuento, v.Bono, v.SalarioBase - v.Descuento + v.Bono, 1
FROM #Niveles v
WHERE EXISTS (SELECT 1 FROM #Nuevos n
              WHERE n.Nivel = v.Nivel
                AND NOT EXISTS (SELECT 1 FROM dbo.Empleados e WHERE e.Nombre = n.Nombre))
  AND NOT EXISTS (SELECT 1 FROM dbo.Planillas p
                  WHERE p.SalarioBase = v.SalarioBase AND p.Descuento = v.Descuento AND p.Bono = v.Bono
                    AND p.Estado = 1);

INSERT INTO dbo.Empleados
       (Nombre, FechaContratacion, IdCargo, IdEstado, IdPlanilla,
        FechaNacimiento, EstadoCivil, Religion, Telefono, Correo, Direccion)
SELECT n.Nombre, n.Contratacion, c.IdCargo, ee.IdEstado,
       (SELECT TOP 1 p.IdPlanilla
        FROM dbo.Planillas p
        JOIN #Niveles v ON v.Nivel = n.Nivel
        WHERE p.SalarioBase = v.SalarioBase AND p.Descuento = v.Descuento
          AND p.Bono = v.Bono AND p.Estado = 1
        ORDER BY p.IdPlanilla),
       n.Nacimiento, n.EstadoCivil, n.Religion, n.Telefono, n.Correo, NULL
FROM #Nuevos n
JOIN dbo.Cargos c            ON c.NombreCargo = n.Cargo
JOIN dbo.EstadosEmpleado ee  ON ee.NombreEstado = n.Estado
WHERE NOT EXISTS (SELECT 1 FROM dbo.Empleados e WHERE e.Nombre = n.Nombre);

DROP TABLE #Nuevos;
DROP TABLE #Niveles;
GO

-- 8.3 Salones (con su responsable)
IF OBJECT_ID('tempdb..#Salones') IS NOT NULL DROP TABLE #Salones;
CREATE TABLE #Salones (
    Orden INT IDENTITY(1,1), Nombre NVARCHAR(50), Tipo NVARCHAR(30),
    Capacidad INT, Edificio NVARCHAR(100), Responsable NVARCHAR(200)
);
INSERT INTO #Salones (Nombre, Tipo, Capacidad, Edificio, Responsable) VALUES
(N'Aula Séptimo A',            N'Aula',        35,  N'Edificio A', NULL),
(N'Aula Séptimo B',            N'Aula',        35,  N'Edificio A', NULL),
(N'Aula Octavo A',             N'Aula',        35,  N'Edificio A', NULL),
(N'Aula Noveno A',             N'Aula',        35,  N'Edificio A', NULL),
(N'Aula 1er Bachillerato A1',  N'Aula',        40,  N'Edificio B', NULL),
(N'Aula 2do Bachillerato A1',  N'Aula',        40,  N'Edificio B', NULL),
(N'Laboratorio de Informática',N'Laboratorio', 30,  N'Edificio C', N'Luis Fernando Orellana Pérez'),
(N'Laboratorio de Ciencias',   N'Laboratorio', 30,  N'Edificio C', N'Nelson Rolando Tobar Paz'),
(N'Biblioteca',                N'Biblioteca',  40,  N'Edificio B', N'Teresa de Jesús Moreno Lara'),
(N'Dirección',                 N'Oficina',      6,  N'Edificio A', N'Carlos Alberto Mejía Hernández'),
(N'Sala de Profesores',        N'Oficina',     25,  N'Edificio B', N'Roberto Antonio Vásquez Cruz'),
(N'Auditorio',                 N'Auditorio',  200,  N'Edificio D', N'Santos Gilberto Rivera Mejía'),
(N'Gimnasio',                  N'Otro',       120,  N'Edificio D', N'Mauricio Ernesto Cortez Valle');

DECLARE @baseSalon INT = (SELECT ISNULL(MAX(IdSalon), 0) FROM dbo.Salones);   -- IdSalon no es identity: MAX + 1

INSERT INTO dbo.Salones (IdSalon, NombreSalon, Tipo, Capacidad, Edificio, IdResponsable, Activo)
SELECT @baseSalon + ROW_NUMBER() OVER (ORDER BY s.Orden),
       s.Nombre, s.Tipo, s.Capacidad, s.Edificio,
       (SELECT TOP 1 e.IdEmpleado FROM dbo.Empleados e
        WHERE e.Nombre = s.Responsable AND e.IdEstado <> 2),
       1
FROM #Salones s
WHERE NOT EXISTS (SELECT 1 FROM dbo.Salones x WHERE LOWER(x.NombreSalon) = LOWER(s.Nombre));

DROP TABLE #Salones;
GO

-- 8.4 Catalogo de equipos (31 tipos). Entran asignados a la bodega.
IF OBJECT_ID('tempdb..#Catalogo') IS NOT NULL DROP TABLE #Catalogo;
CREATE TABLE #Catalogo (Orden INT IDENTITY(1,1), Nombre NVARCHAR(100), Categoria NVARCHAR(100));
INSERT INTO #Catalogo (Nombre, Categoria) VALUES
(N'Pupitre individual',        N'Mobiliario Escolar'),
(N'Escritorio de docente',     N'Mobiliario Escolar'),
(N'Silla de docente',          N'Mobiliario Escolar'),
(N'Pizarra acrílica',          N'Mobiliario Escolar'),
(N'Archivero metálico',        N'Mobiliario Escolar'),
(N'Estante de madera',         N'Mobiliario Escolar'),
(N'Mesa de laboratorio',       N'Mobiliario Escolar'),
(N'Silla de laboratorio',      N'Mobiliario Escolar'),
(N'Mesa de biblioteca',        N'Mobiliario Escolar'),
(N'Silla de biblioteca',       N'Mobiliario Escolar'),
(N'Silla plegable',            N'Mobiliario Escolar'),
(N'Proyector multimedia',      N'Equipo Audiovisual'),
(N'Televisor 55 pulgadas',     N'Equipo Audiovisual'),
(N'Parlante amplificado',      N'Equipo Audiovisual'),
(N'Micrófono inalámbrico',     N'Equipo Audiovisual'),
(N'Router inalámbrico',        N'Equipo de Red'),
(N'Switch de 24 puertos',      N'Equipo de Red'),
(N'Punto de acceso Wi-Fi',     N'Equipo de Red'),
(N'Computadora de escritorio', N'Equipo Informático'),
(N'Laptop',                    N'Equipo Informático'),
(N'Impresora multifuncional',  N'Equipo Informático'),
(N'Aire acondicionado',        N'Infraestructura'),
(N'Ventilador de pared',       N'Infraestructura'),
(N'Extintor',                  N'Equipo de Seguridad'),
(N'Cámara de vigilancia',      N'Equipo de Seguridad'),
(N'Botiquín',                  N'Equipo de Seguridad'),
(N'Aspiradora industrial',     N'Limpieza'),
(N'Carrito de limpieza',       N'Limpieza'),
(N'Microscopio',               N'Material Escolar'),
(N'Balanza digital',           N'Material Escolar'),
(N'Esqueleto anatómico',       N'Material Escolar');

DECLARE @baseActivo INT = (SELECT ISNULL(MAX(IdActivo), 0) FROM dbo.GestionActivos);   -- IdActivo tampoco es identity

;WITH nuevos AS (
    SELECT @baseActivo + ROW_NUMBER() OVER (ORDER BY k.Orden) AS Id, k.Nombre, c.IdCategoria
    FROM #Catalogo k
    JOIN dbo.Categorias c ON c.NombreCategoria = k.Categoria
    WHERE NOT EXISTS (SELECT 1 FROM dbo.GestionActivos g WHERE LOWER(g.Nombre) = LOWER(k.Nombre))
)
INSERT INTO dbo.GestionActivos (IdActivo, Nombre, IdCategoria, CodigoInventario, IdUbicacion)
SELECT Id, Nombre, IdCategoria,
       'ACT-' + RIGHT('0000' + CAST(Id AS VARCHAR(10)), 4),     -- codigo del tipo, igual que lo genera el programa
       dbo.fn_IdBodega()
FROM nuevos;

DROP TABLE #Catalogo;
GO

-- 8.5 Unidades fisicas por salon (cada una con su propio estado) y reportes de dano abiertos.
--     Todo o nada: si algo falla, no queda nada a medias y se puede volver a ejecutar.
IF OBJECT_ID('tempdb..#Dist') IS NOT NULL DROP TABLE #Dist;
CREATE TABLE #Dist (Orden INT IDENTITY(1,1), Salon NVARCHAR(50), Activo NVARCHAR(100), Cantidad INT, Estado NVARCHAR(50));
INSERT INTO #Dist (Salon, Activo, Cantidad, Estado) VALUES
(N'Aula Séptimo A', N'Pupitre individual', 26, N'Bueno'), (N'Aula Séptimo A', N'Pupitre individual', 3, N'Regular'), (N'Aula Séptimo A', N'Pupitre individual', 1, N'Malo'),
(N'Aula Séptimo A', N'Escritorio de docente', 1, N'Bueno'), (N'Aula Séptimo A', N'Silla de docente', 1, N'Bueno'),
(N'Aula Séptimo A', N'Pizarra acrílica', 1, N'Bueno'), (N'Aula Séptimo A', N'Proyector multimedia', 1, N'Excelente'),
(N'Aula Séptimo A', N'Ventilador de pared', 2, N'Bueno'), (N'Aula Séptimo A', N'Extintor', 1, N'Bueno'),
(N'Aula Séptimo B', N'Pupitre individual', 28, N'Bueno'), (N'Aula Séptimo B', N'Pupitre individual', 2, N'Regular'),
(N'Aula Séptimo B', N'Escritorio de docente', 1, N'Bueno'), (N'Aula Séptimo B', N'Silla de docente', 1, N'Regular'),
(N'Aula Séptimo B', N'Pizarra acrílica', 1, N'Bueno'), (N'Aula Séptimo B', N'Proyector multimedia', 1, N'Mantenimiento Pendiente'),
(N'Aula Séptimo B', N'Ventilador de pared', 2, N'Bueno'), (N'Aula Séptimo B', N'Extintor', 1, N'Bueno'),
(N'Aula Octavo A', N'Pupitre individual', 30, N'Bueno'), (N'Aula Octavo A', N'Pupitre individual', 2, N'Regular'),
(N'Aula Octavo A', N'Escritorio de docente', 1, N'Bueno'), (N'Aula Octavo A', N'Silla de docente', 1, N'Bueno'),
(N'Aula Octavo A', N'Pizarra acrílica', 1, N'Bueno'), (N'Aula Octavo A', N'Proyector multimedia', 1, N'Bueno'),
(N'Aula Octavo A', N'Ventilador de pared', 1, N'Bueno'), (N'Aula Octavo A', N'Ventilador de pared', 1, N'Malo'),
(N'Aula Octavo A', N'Extintor', 1, N'Bueno'),
(N'Aula Noveno A', N'Pupitre individual', 31, N'Bueno'), (N'Aula Noveno A', N'Pupitre individual', 1, N'Regular'),
(N'Aula Noveno A', N'Escritorio de docente', 1, N'Bueno'), (N'Aula Noveno A', N'Silla de docente', 1, N'Bueno'),
(N'Aula Noveno A', N'Pizarra acrílica', 1, N'Bueno'), (N'Aula Noveno A', N'Proyector multimedia', 1, N'Bueno'),
(N'Aula Noveno A', N'Ventilador de pared', 2, N'Bueno'), (N'Aula Noveno A', N'Extintor', 1, N'Bueno'),
(N'Aula 1er Bachillerato A1', N'Pupitre individual', 38, N'Bueno'), (N'Aula 1er Bachillerato A1', N'Pupitre individual', 2, N'Regular'),
(N'Aula 1er Bachillerato A1', N'Escritorio de docente', 1, N'Bueno'), (N'Aula 1er Bachillerato A1', N'Silla de docente', 1, N'Bueno'),
(N'Aula 1er Bachillerato A1', N'Pizarra acrílica', 1, N'Bueno'), (N'Aula 1er Bachillerato A1', N'Proyector multimedia', 1, N'Excelente'),
(N'Aula 1er Bachillerato A1', N'Aire acondicionado', 1, N'Bueno'), (N'Aula 1er Bachillerato A1', N'Extintor', 1, N'Bueno'),
(N'Aula 2do Bachillerato A1', N'Pupitre individual', 38, N'Bueno'), (N'Aula 2do Bachillerato A1', N'Pupitre individual', 2, N'Regular'),
(N'Aula 2do Bachillerato A1', N'Escritorio de docente', 1, N'Bueno'), (N'Aula 2do Bachillerato A1', N'Silla de docente', 1, N'Bueno'),
(N'Aula 2do Bachillerato A1', N'Pizarra acrílica', 1, N'Bueno'), (N'Aula 2do Bachillerato A1', N'Proyector multimedia', 1, N'Bueno'),
(N'Aula 2do Bachillerato A1', N'Aire acondicionado', 1, N'Regular'), (N'Aula 2do Bachillerato A1', N'Extintor', 1, N'Bueno'),
(N'Laboratorio de Informática', N'Computadora de escritorio', 22, N'Bueno'), (N'Laboratorio de Informática', N'Computadora de escritorio', 4, N'Excelente'),
(N'Laboratorio de Informática', N'Computadora de escritorio', 2, N'Mantenimiento Pendiente'), (N'Laboratorio de Informática', N'Computadora de escritorio', 1, N'Malo'),
(N'Laboratorio de Informática', N'Mesa de laboratorio', 15, N'Bueno'), (N'Laboratorio de Informática', N'Silla de laboratorio', 30, N'Bueno'),
(N'Laboratorio de Informática', N'Proyector multimedia', 1, N'Excelente'), (N'Laboratorio de Informática', N'Switch de 24 puertos', 1, N'Excelente'),
(N'Laboratorio de Informática', N'Punto de acceso Wi-Fi', 1, N'Bueno'), (N'Laboratorio de Informática', N'Aire acondicionado', 2, N'Bueno'),
(N'Laboratorio de Informática', N'Extintor', 1, N'Bueno'), (N'Laboratorio de Informática', N'Escritorio de docente', 1, N'Bueno'),
(N'Laboratorio de Informática', N'Impresora multifuncional', 1, N'Bueno'), (N'Laboratorio de Informática', N'Cámara de vigilancia', 1, N'Bueno'),
(N'Laboratorio de Ciencias', N'Mesa de laboratorio', 8, N'Bueno'), (N'Laboratorio de Ciencias', N'Mesa de laboratorio', 1, N'Regular'),
(N'Laboratorio de Ciencias', N'Silla de laboratorio', 28, N'Bueno'), (N'Laboratorio de Ciencias', N'Silla de laboratorio', 2, N'Regular'),
(N'Laboratorio de Ciencias', N'Microscopio', 10, N'Bueno'), (N'Laboratorio de Ciencias', N'Microscopio', 1, N'En reparación'), (N'Laboratorio de Ciencias', N'Microscopio', 1, N'Malo'),
(N'Laboratorio de Ciencias', N'Balanza digital', 4, N'Bueno'), (N'Laboratorio de Ciencias', N'Esqueleto anatómico', 1, N'Bueno'),
(N'Laboratorio de Ciencias', N'Pizarra acrílica', 1, N'Bueno'), (N'Laboratorio de Ciencias', N'Extintor', 2, N'Bueno'),
(N'Laboratorio de Ciencias', N'Botiquín', 1, N'Bueno'), (N'Laboratorio de Ciencias', N'Escritorio de docente', 1, N'Bueno'),
(N'Laboratorio de Ciencias', N'Proyector multimedia', 1, N'Regular'),
(N'Biblioteca', N'Mesa de biblioteca', 8, N'Bueno'), (N'Biblioteca', N'Silla de biblioteca', 30, N'Bueno'), (N'Biblioteca', N'Silla de biblioteca', 2, N'Regular'),
(N'Biblioteca', N'Estante de madera', 14, N'Bueno'), (N'Biblioteca', N'Computadora de escritorio', 4, N'Bueno'),
(N'Biblioteca', N'Escritorio de docente', 1, N'Bueno'), (N'Biblioteca', N'Aire acondicionado', 1, N'Bueno'),
(N'Biblioteca', N'Extintor', 1, N'Bueno'), (N'Biblioteca', N'Cámara de vigilancia', 1, N'Bueno'),
(N'Dirección', N'Escritorio de docente', 2, N'Bueno'), (N'Dirección', N'Silla de docente', 3, N'Bueno'),
(N'Dirección', N'Archivero metálico', 3, N'Bueno'), (N'Dirección', N'Archivero metálico', 1, N'Regular'),
(N'Dirección', N'Laptop', 1, N'Excelente'), (N'Dirección', N'Computadora de escritorio', 1, N'Bueno'),
(N'Dirección', N'Impresora multifuncional', 1, N'Bueno'), (N'Dirección', N'Aire acondicionado', 1, N'Excelente'),
(N'Dirección', N'Extintor', 1, N'Bueno'),
(N'Sala de Profesores', N'Archivero metálico', 6, N'Bueno'), (N'Sala de Profesores', N'Escritorio de docente', 6, N'Bueno'),
(N'Sala de Profesores', N'Silla de docente', 9, N'Bueno'), (N'Sala de Profesores', N'Silla de docente', 1, N'Malo'),
(N'Sala de Profesores', N'Laptop', 5, N'Bueno'), (N'Sala de Profesores', N'Laptop', 1, N'Mantenimiento Pendiente'),
(N'Sala de Profesores', N'Impresora multifuncional', 1, N'Regular'), (N'Sala de Profesores', N'Televisor 55 pulgadas', 1, N'Bueno'),
(N'Sala de Profesores', N'Ventilador de pared', 3, N'Bueno'), (N'Sala de Profesores', N'Extintor', 1, N'Bueno'),
(N'Sala de Profesores', N'Punto de acceso Wi-Fi', 1, N'Bueno'),
(N'Auditorio', N'Silla plegable', 120, N'Bueno'), (N'Auditorio', N'Silla plegable', 10, N'Regular'),
(N'Auditorio', N'Proyector multimedia', 1, N'Excelente'), (N'Auditorio', N'Parlante amplificado', 3, N'Excelente'), (N'Auditorio', N'Parlante amplificado', 1, N'Bueno'),
(N'Auditorio', N'Micrófono inalámbrico', 4, N'Bueno'), (N'Auditorio', N'Aire acondicionado', 4, N'Bueno'),
(N'Auditorio', N'Extintor', 4, N'Bueno'), (N'Auditorio', N'Cámara de vigilancia', 2, N'Bueno'),
(N'Gimnasio', N'Botiquín', 1, N'Bueno'), (N'Gimnasio', N'Parlante amplificado', 1, N'Bueno'),
(N'Gimnasio', N'Cámara de vigilancia', 1, N'Bueno'),
(N'Bodega central', N'Pupitre individual', 10, N'Nuevo'), (N'Bodega central', N'Pupitre individual', 3, N'Dado de baja'),
(N'Bodega central', N'Silla de docente', 3, N'Nuevo'), (N'Bodega central', N'Proyector multimedia', 2, N'Nuevo'),
(N'Bodega central', N'Proyector multimedia', 1, N'Dado de baja'), (N'Bodega central', N'Computadora de escritorio', 5, N'Nuevo'),
(N'Bodega central', N'Laptop', 3, N'Nuevo'), (N'Bodega central', N'Ventilador de pared', 4, N'Nuevo'),
(N'Bodega central', N'Extintor', 3, N'Nuevo'), (N'Bodega central', N'Router inalámbrico', 2, N'Nuevo'),
(N'Bodega central', N'Aspiradora industrial', 2, N'Bueno'), (N'Bodega central', N'Carrito de limpieza', 2, N'Bueno');

SET XACT_ABORT ON;
IF NOT EXISTS (SELECT 1 FROM dbo.UnidadesActivo)
BEGIN
    DECLARE @a INT, @s INT, @c INT, @e INT;

    BEGIN TRANSACTION;

    DECLARE cur CURSOR LOCAL FAST_FORWARD FOR
        SELECT g.IdActivo, sa.IdSalon, d.Cantidad, es.IdEstado
        FROM #Dist d
        JOIN dbo.GestionActivos g ON g.Nombre       = d.Activo
        JOIN dbo.Salones sa       ON sa.NombreSalon = d.Salon
        JOIN dbo.Estados es       ON es.NombreEstado = d.Estado
        ORDER BY d.Orden;

    OPEN cur;
    FETCH NEXT FROM cur INTO @a, @s, @c, @e;
    WHILE @@FETCH_STATUS = 0
    BEGIN
        EXEC dbo.sp_AgregarUnidades @IdActivo = @a, @IdSalon = @s, @Cantidad = @c, @IdEstado = @e;
        FETCH NEXT FROM cur INTO @a, @s, @c, @e;
    END
    CLOSE cur;
    DEALLOCATE cur;

    -- Cada unidad con "Mantenimiento Pendiente" tiene su reporte de dano abierto
    INSERT INTO dbo.ReportesDanio
           (IdSalon, IdActivo, IdUnidad, CodigoInventario, Cantidad, Prioridad,
            Descripcion, ReportadoPor, FechaReporte)
    SELECT u.IdSalon, u.IdActivo, u.IdUnidad, u.CodigoInventario, 1,
           CASE ROW_NUMBER() OVER (ORDER BY u.IdUnidad) % 3 WHEN 1 THEN 'Alta' WHEN 2 THEN 'Media' ELSE 'Baja' END,
           a.Nombre + ' presenta fallas de funcionamiento y necesita revisión técnica.',
           'Personal docente',
           DATEADD(DAY, -((ROW_NUMBER() OVER (ORDER BY u.IdUnidad)) * 3 % 14), GETDATE())
    FROM dbo.UnidadesActivo u
    JOIN dbo.GestionActivos a ON a.IdActivo = u.IdActivo
    JOIN dbo.Estados e        ON e.IdEstado = u.IdEstado
    WHERE e.NombreEstado = 'Mantenimiento Pendiente'
      AND NOT EXISTS (SELECT 1 FROM dbo.ReportesDanio r WHERE r.IdUnidad = u.IdUnidad AND r.Estado = 'Abierto');

    COMMIT TRANSACTION;
    PRINT 'Unidades y reportes creados.';
END
ELSE
    PRINT 'Ya existen unidades: no se crearon unidades ni reportes nuevos.';

-- Las unidades "Dado de baja" llevan fecha y motivo, como exige el programa. Esto va fuera del IF
-- para completar tambien las bajas hechas antes de que existiera el motivo (solo llena los vacios).
UPDATE u
SET    u.FechaBaja  = ISNULL(u.FechaBaja, u.FechaAlta),
       u.MotivoBaja = ISNULL(u.MotivoBaja, 'Baja del inventario inicial (sin motivo registrado)')
FROM   dbo.UnidadesActivo u
JOIN   dbo.Estados e ON e.IdEstado = u.IdEstado
WHERE  e.NombreEstado = 'Dado de baja' AND (u.FechaBaja IS NULL OR u.MotivoBaja IS NULL);

SET XACT_ABORT OFF;
DROP TABLE #Dist;
GO

-- Fin de la seccion 8: se quita el usuario de sesion; lo que haga el programa lo registra con el usuario que inicie sesion.
EXEC sys.sp_set_session_context @key = N'Usuario', @value = NULL;
GO

/* =====================================================================
   9. VERIFICACION
   ===================================================================== */
-- Resultado esperado en una instalacion limpia: Tablas 30, Vistas 27,
-- Procedimientos 34, Triggers 20, Funciones 6.
-- Datos de ejemplo: Empleados 50, Salones 14 (13 de ejemplo + la Bodega central), TiposDeEquipo 31,
-- Unidades 692, ReportesAbiertos 4.
SELECT 'Tablas'         AS Objeto, COUNT(*) AS Total FROM sys.tables
UNION ALL SELECT 'Vistas',         COUNT(*) FROM sys.views
UNION ALL SELECT 'Procedimientos', COUNT(*) FROM sys.procedures
UNION ALL SELECT 'Triggers',       COUNT(*) FROM sys.triggers
UNION ALL SELECT 'Funciones',      COUNT(*) FROM sys.objects WHERE type IN ('FN', 'IF', 'TF');

SELECT (SELECT COUNT(*) FROM dbo.Empleados)       AS Empleados,
       (SELECT COUNT(*) FROM dbo.Salones)         AS Salones,
       (SELECT COUNT(*) FROM dbo.GestionActivos)  AS TiposDeEquipo,
       (SELECT COUNT(*) FROM dbo.UnidadesActivo)  AS Unidades,
       (SELECT COUNT(*) FROM dbo.ReportesDanio WHERE Estado = 'Abierto') AS ReportesAbiertos;

SELECT dbo.fn_IdBodega() AS IdBodega,
       (SELECT NombreSalon FROM dbo.Salones WHERE IdSalon = dbo.fn_IdBodega()) AS Bodega;
GO

-- Fin del script (deshace la guardia del inicio, por si hubiera quedado activa).
SET NOEXEC OFF;
GO

/* =====================================================================
   10. ANEXO: CODIGOS DE ERROR (THROW) POR PROCEDIMIENTO
   ===================================================================== */
-- Los procedimientos avisan con THROW y un codigo propio (50000 en adelante); la aplicacion muestra
-- el mensaje al usuario. Los marcados "(mensaje armado)" incluyen cantidades calculadas por la consulta.
--
-- sp_ActualizarUsuario
--     50902  El nombre completo es obligatorio.
--     50904  Ese correo ya está asignado a otro usuario.
--     50907  El usuario ya no existe.
-- sp_AgregarUnidades
--     50062  La cantidad debe ser mayor que cero.
-- sp_AltaUnidades
--     50500  No hay una bodega activa. Cree un salón de tipo Bodega en Gestión de salones.
--     50501  El equipo seleccionado no existe en el catálogo.
--     50502  La cantidad debe estar entre 1 y 500.
--     50503  El estado inicial no es válido.
--     50504  Un código personalizado solo se puede usar al dar de alta una unidad.
--     50505  Ya existe una unidad con ese código de inventario.
--     50960  El costo no puede ser negativo.
--     50961  La fecha de compra no puede ser futura.
-- sp_AnularAusencia
--     50706  La ausencia no existe o ya estaba anulada.
--     50801  Esa ausencia cae en un mes cerrado de la planilla. Un administrador debe reabrirlo.
-- sp_AnularPago
--     50310  El pago no existe o ya estaba anulado.
--     50800  El mes está cerrado: no se pueden registrar ni modificar pagos. Un administrador debe reabrirlo.
-- sp_AsignarDocente
--     50200  Las horas semanales deben ser al menos 1.
--     50201  El empleado seleccionado no es docente.
--     50202  La sección seleccionada no existe.
--     50203  Ese docente ya tiene asignada esa materia en ese grupo y año lectivo.
--     50204  (mensaje armado)
--     50205  El docente no tiene materias registradas. Agréguelas en su ficha de personal.
--     50206  El docente imparte varias materias: indique cuál se asigna a este grupo.
--     50207  Esa materia no está entre las materias del docente.
-- sp_AsignarUnidades
--     50510  No hay una bodega activa. Cree un salón de tipo Bodega en Gestión de salones.
--     50511  La cantidad debe ser mayor que cero.
--     50512  El salón destino no existe o está inactivo.
--     50513  El equipo ya está en la bodega. Elija otro salón como destino.
--     50514  (mensaje armado)
-- sp_CambiarEstadoSalon
--     50410  El salón no existe.
--     50411  (mensaje armado)
-- sp_CambiarEstadoUnidad
--     50060  El estado seleccionado no es válido.
--     50061  La unidad no existe.
-- sp_CambiarEstadoUnidades
--     50910  El estado seleccionado no es válido.
--     50911  Alguna de las unidades no existe o no pertenece a este activo.
--     50912  No se puede dar de baja una unidad que está prestada. Registre primero su devolución.
--     50913  Hay unidades con un reporte de daño abierto. Resuélvalo con un mantenimiento antes de marcarlas en buen estado.
--     50914  Hay unidades dadas de baja: una baja no se revierte desde esta pantalla.
--     50962  Indique el motivo de la baja (mínimo 5 caracteres).
-- sp_CambiarEstadoUsuario
--     50905  No puedes desactivar tu propia cuenta.
--     50906  Debe quedar al menos un administrador activo.
--     50907  El usuario ya no existe.
-- sp_CambiarMiClave
--     50907  No se encontró la cuenta.
-- sp_CerrarPeriodo
--     50803  (mensaje armado)
--     50804  Ese mes ya está cerrado.
--     50805  Ese mes no tiene pagos: genere o registre la planilla antes de cerrarlo.
--     50808  No se puede cerrar un mes que todavía no empieza.
-- sp_CrearUsuario
--     50901  El nombre de usuario debe tener al menos 3 caracteres.
--     50902  El nombre completo es obligatorio.
--     50903  Ya existe un usuario con ese nombre.
--     50904  Ese correo ya está asignado a otro usuario.
--     50908  No existe el rol Administrador en la tabla Roles.
-- sp_GenerarPlanilla
--     50800  El mes está cerrado: no se pueden registrar ni modificar pagos. Un administrador debe reabrirlo.
--     50802  No se puede generar la planilla de un mes futuro.
-- sp_GuardarConfiguracionInicial
--     50020  El nombre de la empresa es obligatorio.
--     50021  El sistema ya fue configurado.
--     50022  Ese nombre de usuario ya existe.
--     50023  No existe el rol Administrador en la tabla Roles.
--     50024  Ese correo ya está registrado para otro usuario.
-- sp_GuardarMateria
--     50600  El nombre de la materia es obligatorio (mínimo 3 caracteres).
--     50601  Ya existe una materia con ese nombre.
--     50602  La materia no existe.
-- sp_GuardarMateriasEmpleado
--     50610  El empleado no existe.
--     50611  Solo los empleados con cargo Docente pueden tener materias.
--     50612  Alguna de las materias seleccionadas no existe.
--     50613  No se puede quitar una materia que ya tiene grupos asignados. Quite primero esas asignaciones.
-- sp_GuardarSalon
--     50400  El nombre del salón es obligatorio (mínimo 3 caracteres).
--     50401  Seleccione un tipo de salón válido.
--     50402  La capacidad debe estar entre 1 y 500 personas.
--     50403  El responsable no existe o está inactivo.
--     50404  Ya existe un salón con ese nombre.
--     50405  El salón no existe.
-- sp_MarcarPagado
--     50309  El pago no existe, está anulado o ya estaba pagado.
--     50800  El mes está cerrado: no se pueden registrar ni modificar pagos. Un administrador debe reabrirlo.
-- sp_MoverUnidades
--     50420  El salón destino no existe o está inactivo.
--     50421  No se indicó ninguna unidad para mover.
--     50422  Alguna de las unidades ya no existe.
--     50423  Alguna de las unidades está prestada. Registre su devolución antes de moverla.
-- sp_QuitarUnidades
--     50430  No se indicó ninguna unidad para quitar.
-- sp_ReabrirPeriodo
--     50806  Ese mes no está cerrado.
--     50807  Indique el motivo de la reapertura (mínimo 5 caracteres).
-- sp_RegistrarAusencia
--     50700  El empleado no existe o está inactivo.
--     50701  El tipo debe ser Falta, Permiso o Incapacidad.
--     50702  La fecha final no puede ser anterior a la fecha inicial.
--     50703  El rango no puede superar 90 días. Registre varios períodos.
--     50704  Ese rango solo incluye sábados o domingos: no hay días laborales que registrar.
--     50705  Ese empleado ya tiene una ausencia registrada que se cruza con esas fechas.
--     50801  Esas fechas caen en un mes cerrado de la planilla. Un administrador debe reabrirlo.
-- sp_RegistrarDevolucion
--     50036  El estado seleccionado no es válido.
--     50037  El préstamo no existe o ya fue devuelto.
-- sp_RegistrarMantenimiento
--     50050  La descripción del servicio es obligatoria.
--     50051  El reporte de daño ya estaba cerrado.
--     50052  La unidad no existe.
-- sp_RegistrarMovimientoConsumible
--     50040  El tipo de movimiento debe ser Entrada o Salida.
--     50041  La cantidad debe ser mayor que cero.
--     50042  El consumible no existe.
--     50043  Stock insuficiente: no se puede despachar más de lo que hay.
-- sp_RegistrarPago
--     50300  El empleado no existe o está inactivo.
--     50301  El salario base debe ser mayor que cero.
--     50302  El bono y el descuento no pueden ser negativos.
--     50303  El descuento no puede superar el salario base más el bono.
--     50304  El estado de pago debe ser Pendiente o Pagado.
--     50305  No se pueden registrar pagos de períodos futuros.
--     50306  Ese empleado ya tiene un pago registrado en ese período.
--     50307  El pago no existe o ya fue anulado.
--     50308  Un pago ya pagado no se puede modificar. Anúlelo y regístrelo de nuevo.
--     50311  El descuento por ausencias no es válido: no puede superar el descuento total.
--     50800  El mes está cerrado: no se pueden registrar ni modificar pagos. Un administrador debe reabrirlo.
-- sp_RegistrarPrestamo
--     50031  El responsable es obligatorio.
--     50032  La fecha límite debe ser posterior a la fecha de entrega.
--     50033  La unidad no existe.
--     50034  No se puede prestar una unidad en mal estado, en reparación o dada de baja.
--     50035  Esa unidad ya está prestada y no ha sido devuelta.
--     50950  Seleccione al empleado responsable de la lista.
--     50951  El empleado no existe o está dado de baja.
--     50952  El empleado elegido no es docente.
--     50953  Los docentes se registran con el tipo "Docente".
-- sp_RestablecerClaveUsuario
--     50907  El usuario ya no existe.
--
-- Tambien hay un error en el trigger trg_Auditoria_Inmutable:
--     50900  El registro de actividad no se puede modificar ni borrar.
