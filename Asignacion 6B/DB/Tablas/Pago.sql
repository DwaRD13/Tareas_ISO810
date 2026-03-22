USE FarmaciaCarol;
GO

-- 1. Crear la tabla Pago que falta
IF OBJECT_ID('dbo.Pago', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Pago (
        PagoId BIGINT IDENTITY(1,1) PRIMARY KEY,
        FacturaId INT NOT NULL,
        Monto DECIMAL(18,2) NOT NULL,
        FechaPago DATETIME2 DEFAULT SYSUTCDATETIME()
    );
END
GO