IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'TSS')
BEGIN
    CREATE DATABASE TSS;
END
GO

USE TSS;
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Empresas' and xtype='U')
BEGIN
    CREATE TABLE Empresas (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Nombre NVARCHAR(100),
        RNC NVARCHAR(11)
    )
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Empleados' and xtype='U')
BEGIN
    CREATE TABLE Empleados (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Cedula NVARCHAR(11),
        Salario DECIMAL(10,2),
        FechaIngreso DATETIME,
        TipoEmpleado NVARCHAR(1),
        Cargo NVARCHAR(50),
        EmpresaId INT FOREIGN KEY REFERENCES Empresas(Id)
    )
END
GO