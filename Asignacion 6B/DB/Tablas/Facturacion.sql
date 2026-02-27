USE FarmaciaCarol;
GO

-- Tabla principal de Facturación
IF OBJECT_ID('dbo.FACTURACION', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.FACTURACION (
        ID INT IDENTITY(1,1) PRIMARY KEY,
        ClienteId INT,
        Caroleal INT,
        Productos NVARCHAR(MAX),
        Subtotal DECIMAL(12,2),
        Itbis DECIMAL(12,2),
        DescuentoSeguro DECIMAL(12,2),
        MontoTotal DECIMAL(12,2),
        FechaCreacion DATETIME DEFAULT GETDATE(), 
        CantidadProductos INT,
        NombreVendedor NVARCHAR(200),
        FormaPago NVARCHAR(50),
        NCF VARCHAR(11),
        ARSNombre NVARCHAR(100),
        Sucursal NVARCHAR(100)
    );
END
GO

-- Tabla de Log/Auditoría
IF OBJECT_ID('dbo.FACTURACION_LOG', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.FACTURACION_LOG (
        LogId INT IDENTITY(1,1) PRIMARY KEY,
        Accion NVARCHAR(50), 
        FechaAccion DATETIME DEFAULT GETDATE(),
        UsuarioBD NVARCHAR(100) DEFAULT SYSTEM_USER, 
        FacturaId INT,
        Productos NVARCHAR(MAX),
        MontoTotal DECIMAL(12,2),
        NCF VARCHAR(11),
        NombreVendedor NVARCHAR(200)
    );
END
GO