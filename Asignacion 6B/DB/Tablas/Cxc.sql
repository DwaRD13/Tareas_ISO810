USE FarmaciaCarol;
GO
-- Tabla: CxC_Documento
IF OBJECT_ID('dbo.CxC_Documento','U') IS NULL
BEGIN
    CREATE TABLE dbo.CxC_Documento (
        DocumentoId        BIGINT IDENTITY(1,1) PRIMARY KEY,
        ClienteId          BIGINT NOT NULL,
        TipoDocumento      CHAR(3) NOT NULL,                  -- 'FAC'
        ReferenciaExterna  VARCHAR(50) NOT NULL,              -- 'FAC-12345'
        FechaEmision       DATE NOT NULL,
        FechaVencimiento   DATE NULL,
        MontoOriginal      DECIMAL(18,2) NOT NULL,
        SaldoActual        DECIMAL(18,2) NOT NULL,
        Estado             VARCHAR(15) NOT NULL,              -- ABIERTO/PARCIAL/PAGADO/ANULADO
        FechaCreacion      DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),

        CONSTRAINT CK_CxC_Doc_Tipo CHECK (TipoDocumento IN ('FAC')),
        CONSTRAINT CK_CxC_Doc_Estado CHECK (Estado IN ('ABIERTO','PARCIAL','PAGADO','ANULADO')),
        CONSTRAINT CK_CxC_Doc_Saldos CHECK (MontoOriginal >= 0 AND SaldoActual >= 0)
    );

    CREATE UNIQUE INDEX UX_CxC_Documento_Ref ON dbo.CxC_Documento (TipoDocumento, ReferenciaExterna);
    CREATE INDEX IX_CxC_Documento_Cliente ON dbo.CxC_Documento (ClienteId, Estado);
END
GO

-- Tabla: CxC_Movimiento
IF OBJECT_ID('dbo.CxC_Movimiento','U') IS NULL
BEGIN
    CREATE TABLE dbo.CxC_Movimiento (
        MovimientoId       BIGINT IDENTITY(1,1) PRIMARY KEY,
        DocumentoId        BIGINT NOT NULL,
        TipoMovimiento     VARCHAR(15) NOT NULL,              -- CARGO/PAGO/ABONO/AJUSTE/ANULACION
        Monto              DECIMAL(18,2) NOT NULL,             -- siempre positivo
        Fecha              DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
        ReferenciaExterna  VARCHAR(50) NULL,                   -- PAGO-77, NC-12, FAC-12345
        Descripcion        VARCHAR(200) NULL,

        CONSTRAINT FK_CxC_Mov_Doc FOREIGN KEY (DocumentoId) REFERENCES dbo.CxC_Documento(DocumentoId),
        CONSTRAINT CK_CxC_Mov_Tipo CHECK (TipoMovimiento IN ('CARGO','PAGO','ABONO','AJUSTE','ANULACION')),
        CONSTRAINT CK_CxC_Mov_MontoPos CHECK (Monto > 0)
    );

    CREATE INDEX IX_CxC_Mov_DocFecha ON dbo.CxC_Movimiento (DocumentoId, Fecha);
END
GO

-- Tabla: CxC_IntegracionAplicada (Idempotencia)
IF OBJECT_ID('dbo.CxC_IntegracionAplicada','U') IS NULL
BEGIN
    CREATE TABLE dbo.CxC_IntegracionAplicada (
        TipoEvento     VARCHAR(50) NOT NULL,                  -- FACTURA_CREADA, PAGO_APLICADO, etc.
        EntidadId      BIGINT NOT NULL,                       -- FacturaId/PagoId/NotaCreditoId
        FechaAplicado  DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
        CONSTRAINT PK_CxC_IntegracionAplicada PRIMARY KEY (TipoEvento, EntidadId)
    );
END
GO