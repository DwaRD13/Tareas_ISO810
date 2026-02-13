USE [madeco];

IF OBJECT_ID('dbo.AsientosActivoFijo', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.AsientosActivoFijo (
        id INT IDENTITY(1,1) PRIMARY KEY,
        id_transaccion INT NOT NULL,
        numero_asiento INT NOT NULL,
        descripcion_asiento VARCHAR(300) NOT NULL,
        fecha_asiento DATE NOT NULL,
        moneda VARCHAR(3) NOT NULL,
        tipo_movimiento VARCHAR(2) NOT NULL,
        cuenta_contable VARCHAR(20) NOT NULL,
        monto DECIMAL(18, 2) NOT NULL,
        fecha_registro DATETIME2 NOT NULL DEFAULT (SYSDATETIME()),
        CONSTRAINT CHK_AsientosActivoFijo_Monto CHECK (monto > 0),
        CONSTRAINT CHK_AsientosActivoFijo_Tipo CHECK (tipo_movimiento IN ('DB', 'CR'))
    );
END;

IF NOT EXISTS (
    SELECT 1
    FROM sys.indexes
    WHERE name = 'IX_AsientosActivoFijo_Transaccion'
      AND object_id = OBJECT_ID('dbo.AsientosActivoFijo')
)
BEGIN
    CREATE INDEX IX_AsientosActivoFijo_Transaccion
    ON dbo.AsientosActivoFijo(id_transaccion, numero_asiento);
END;