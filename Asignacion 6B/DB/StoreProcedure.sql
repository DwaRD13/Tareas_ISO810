-- SP: Recalcular Estado
CREATE OR ALTER PROCEDURE dbo.sp_CxC_RecalcularEstado
    @DocumentoId BIGINT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @MontoOriginal DECIMAL(18,2), @Saldo DECIMAL(18,2), @EstadoActual VARCHAR(15);

    SELECT @MontoOriginal = MontoOriginal, @Saldo = SaldoActual, @EstadoActual = Estado
    FROM dbo.CxC_Documento
    WHERE DocumentoId = @DocumentoId;

    IF @DocumentoId IS NULL RETURN;
    IF @EstadoActual = 'ANULADO' RETURN;

    UPDATE dbo.CxC_Documento
    SET Estado = CASE
            WHEN @Saldo <= 0 THEN 'PAGADO'
            WHEN @Saldo < @MontoOriginal THEN 'PARCIAL'
            ELSE 'ABIERTO'
        END
    WHERE DocumentoId = @DocumentoId;
END;
GO

-- SP: Aplicar Factura (Ajustado para leer de dbo.FACTURACION)
CREATE OR ALTER PROCEDURE dbo.sp_CxC_AplicarFactura
    @FacturaId BIGINT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM dbo.CxC_IntegracionAplicada WHERE TipoEvento='FACTURA_CREADA' AND EntidadId=@FacturaId)
        RETURN;

    BEGIN TRY
        BEGIN TRAN;

        DECLARE @ClienteId BIGINT, @Total DECIMAL(18,2), @Fecha DATE, @Venc DATE, @EstadoFactura VARCHAR(20),
                @Ref VARCHAR(50) = CONCAT('FAC-', @FacturaId);

        -- Se ajustaron los campos para que correspondan a la tabla FACTURACION
        SELECT 
            @ClienteId = f.ClienteId,
            @Total = f.MontoTotal,
            @Fecha = CAST(f.FechaCreacion AS DATE),
            @Venc = NULL,
            @EstadoFactura = 'ACTIVA' -- FACTURACION no tiene estado en su esquema, asumimos activa.
        FROM dbo.FACTURACION f
        WHERE f.ID = @FacturaId;

        IF @ClienteId IS NULL THROW 50001, 'Factura no encontrada en FACTURACION.', 1;
        IF @Venc IS NULL SET @Venc = DATEADD(DAY, 30, @Fecha);

        DECLARE @DocumentoId BIGINT;

        SELECT @DocumentoId = DocumentoId FROM dbo.CxC_Documento WHERE TipoDocumento='FAC' AND ReferenciaExterna=@Ref;

        IF @DocumentoId IS NULL
        BEGIN
            INSERT INTO dbo.CxC_Documento (ClienteId, TipoDocumento, ReferenciaExterna, FechaEmision, FechaVencimiento, MontoOriginal, SaldoActual, Estado)
            VALUES (@ClienteId, 'FAC', @Ref, @Fecha, @Venc, @Total, @Total, 'ABIERTO');

            SET @DocumentoId = SCOPE_IDENTITY();

            INSERT INTO dbo.CxC_Movimiento (DocumentoId, TipoMovimiento, Monto, ReferenciaExterna, Descripcion)
            VALUES (@DocumentoId, 'CARGO', @Total, @Ref, 'Cargo por factura');
        END

        IF (@EstadoFactura = 'ANULADA')
        BEGIN
            EXEC dbo.sp_CxC_AnularFactura @FacturaId = @FacturaId;
        END
        ELSE
        BEGIN
            EXEC dbo.sp_CxC_RecalcularEstado @DocumentoId = @DocumentoId;
        END

        INSERT INTO dbo.CxC_IntegracionAplicada (TipoEvento, EntidadId) VALUES ('FACTURA_CREADA', @FacturaId);

        COMMIT;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        THROW;
    END CATCH
END;
GO

-- SP: Aplicar Pago
CREATE OR ALTER PROCEDURE dbo.sp_CxC_AplicarPago
    @PagoId BIGINT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM dbo.CxC_IntegracionAplicada WHERE TipoEvento='PAGO_APLICADO' AND EntidadId=@PagoId)
        RETURN;

    BEGIN TRY
        BEGIN TRAN;

        DECLARE @FacturaId BIGINT, @Monto DECIMAL(18,2), @FechaPago DATETIME2,
                @RefPago VARCHAR(50) = CONCAT('PAGO-', @PagoId), @RefFac VARCHAR(50);

        -- NOTA: Se asume que existe esta tabla origen según tu script
        SELECT @FacturaId = p.FacturaId, @Monto = p.Monto, @FechaPago = p.FechaPago
        FROM FacturacionCarol.dbo.Pago p WHERE p.PagoId = @PagoId;

        IF @FacturaId IS NULL THROW 50002, 'Pago no encontrado en FacturacionCarol.', 1;

        SET @RefFac = CONCAT('FAC-', @FacturaId);

        DECLARE @DocumentoId BIGINT;
        SELECT @DocumentoId = DocumentoId FROM dbo.CxC_Documento WHERE TipoDocumento='FAC' AND ReferenciaExterna=@RefFac;

        IF @DocumentoId IS NULL
        BEGIN
            EXEC dbo.sp_CxC_AplicarFactura @FacturaId = @FacturaId;
            SELECT @DocumentoId = DocumentoId FROM dbo.CxC_Documento WHERE TipoDocumento='FAC' AND ReferenciaExterna=@RefFac;
        END

        IF EXISTS (SELECT 1 FROM dbo.CxC_Documento WHERE DocumentoId=@DocumentoId AND Estado='ANULADO')
            THROW 50003, 'No se puede aplicar pago: documento ANULADO en CxC.', 1;

        INSERT INTO dbo.CxC_Movimiento (DocumentoId, TipoMovimiento, Monto, Fecha, ReferenciaExterna, Descripcion)
        VALUES (@DocumentoId, 'PAGO', @Monto, @FechaPago, @RefPago, 'Pago aplicado desde Facturación');

        UPDATE dbo.CxC_Documento
        SET SaldoActual = CASE WHEN SaldoActual - @Monto < 0 THEN 0 ELSE SaldoActual - @Monto END
        WHERE DocumentoId = @DocumentoId;

        EXEC dbo.sp_CxC_RecalcularEstado @DocumentoId = @DocumentoId;

        INSERT INTO dbo.CxC_IntegracionAplicada (TipoEvento, EntidadId) VALUES ('PAGO_APLICADO', @PagoId);

        COMMIT;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        THROW;
    END CATCH
END;
GO

-- SP: Aplicar Nota de Crédito
CREATE OR ALTER PROCEDURE dbo.sp_CxC_AplicarNotaCredito
    @NotaCreditoId BIGINT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM dbo.CxC_IntegracionAplicada WHERE TipoEvento='NOTA_CREDITO_CREADA' AND EntidadId=@NotaCreditoId)
        RETURN;

    BEGIN TRY
        BEGIN TRAN;

        DECLARE @FacturaId BIGINT, @Monto DECIMAL(18,2), @Fecha DATETIME2,
                @RefNC VARCHAR(50) = CONCAT('NC-', @NotaCreditoId), @RefFac VARCHAR(50);

        -- NOTA: Se asume que existe esta tabla origen según tu script
        SELECT @FacturaId = n.FacturaId, @Monto = n.Monto, @Fecha = n.Fecha
        FROM FacturacionCarol.dbo.NotaCredito n WHERE n.NotaCreditoId = @NotaCreditoId;

        IF @FacturaId IS NULL THROW 50004, 'Nota de crédito no encontrada en FacturacionCarol.', 1;

        SET @RefFac = CONCAT('FAC-', @FacturaId);

        DECLARE @DocumentoId BIGINT;
        SELECT @DocumentoId = DocumentoId FROM dbo.CxC_Documento WHERE TipoDocumento='FAC' AND ReferenciaExterna=@RefFac;

        IF @DocumentoId IS NULL
        BEGIN
            EXEC dbo.sp_CxC_AplicarFactura @FacturaId = @FacturaId;
            SELECT @DocumentoId = DocumentoId FROM dbo.CxC_Documento WHERE TipoDocumento='FAC' AND ReferenciaExterna=@RefFac;
        END

        IF EXISTS (SELECT 1 FROM dbo.CxC_Documento WHERE DocumentoId=@DocumentoId AND Estado='ANULADO')
            THROW 50005, 'No se puede aplicar NC: documento ANULADO en CxC.', 1;

        INSERT INTO dbo.CxC_Movimiento (DocumentoId, TipoMovimiento, Monto, Fecha, ReferenciaExterna, Descripcion)
        VALUES (@DocumentoId, 'ABONO', @Monto, @Fecha, @RefNC, 'Nota de crédito aplicada desde Facturación');

        UPDATE dbo.CxC_Documento
        SET SaldoActual = CASE WHEN SaldoActual - @Monto < 0 THEN 0 ELSE SaldoActual - @Monto END
        WHERE DocumentoId = @DocumentoId;

        EXEC dbo.sp_CxC_RecalcularEstado @DocumentoId = @DocumentoId;

        INSERT INTO dbo.CxC_IntegracionAplicada (TipoEvento, EntidadId) VALUES ('NOTA_CREDITO_CREADA', @NotaCreditoId);

        COMMIT;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        THROW;
    END CATCH
END;
GO

-- SP: Anular Factura
CREATE OR ALTER PROCEDURE dbo.sp_CxC_AnularFactura
    @FacturaId BIGINT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM dbo.CxC_IntegracionAplicada WHERE TipoEvento='FACTURA_ANULADA' AND EntidadId=@FacturaId)
        RETURN;

    BEGIN TRY
        BEGIN TRAN;

        DECLARE @RefFac VARCHAR(50) = CONCAT('FAC-', @FacturaId);
        DECLARE @DocumentoId BIGINT, @Saldo DECIMAL(18,2);

        SELECT @DocumentoId = DocumentoId, @Saldo = SaldoActual FROM dbo.CxC_Documento WHERE TipoDocumento='FAC' AND ReferenciaExterna=@RefFac;

        IF @DocumentoId IS NULL
        BEGIN
            EXEC dbo.sp_CxC_AplicarFactura @FacturaId = @FacturaId;
            SELECT @DocumentoId = DocumentoId, @Saldo = SaldoActual FROM dbo.CxC_Documento WHERE TipoDocumento='FAC' AND ReferenciaExterna=@RefFac;
        END

        IF EXISTS (SELECT 1 FROM dbo.CxC_Documento WHERE DocumentoId=@DocumentoId AND Estado='ANULADO')
        BEGIN
            INSERT INTO dbo.CxC_IntegracionAplicada (TipoEvento, EntidadId) VALUES ('FACTURA_ANULADA', @FacturaId);
            COMMIT;
            RETURN;
        END

        IF (@Saldo > 0)
        BEGIN
            INSERT INTO dbo.CxC_Movimiento (DocumentoId, TipoMovimiento, Monto, ReferenciaExterna, Descripcion)
            VALUES (@DocumentoId, 'ANULACION', @Saldo, @RefFac, 'Anulación de factura: saldo cancelado');
        END

        UPDATE dbo.CxC_Documento SET Estado='ANULADO', SaldoActual=0 WHERE DocumentoId=@DocumentoId;

        INSERT INTO dbo.CxC_IntegracionAplicada (TipoEvento, EntidadId) VALUES ('FACTURA_ANULADA', @FacturaId);

        COMMIT;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        THROW;
    END CATCH
END;
GO
