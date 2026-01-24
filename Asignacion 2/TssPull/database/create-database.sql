CREATE TABLE Empleados (
    id INT IDENTITY(1,1) PRIMARY KEY,
    cedula VARCHAR(20) NOT NULL,
    nombre VARCHAR(200) NOT NULL,
    cuenta_banco VARCHAR(50) NOT NULL,
    sueldo DECIMAL(18, 2) NOT NULL,
    descuento_seguro DECIMAL(18, 2) NOT NULL,
    sueldo_neto DECIMAL(18, 2) NOT NULL,
    fecha_registro DATETIME2 DEFAULT (SYSDATETIME()),
    CONSTRAINT CHK_Sueldo CHECK (sueldo >= 0),
    CONSTRAINT CHK_Descuento CHECK (descuento_seguro >= 0)
);

CREATE INDEX IX_Empleados_Cedula ON dbo.Empleados(cedula);