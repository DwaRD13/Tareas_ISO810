CREATE OR ALTER TRIGGER TRG_AUDITAR_FACTURACION
ON dbo.FACTURACION
AFTER UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- ELIMINACIÓN
    IF EXISTS (SELECT * FROM deleted) AND NOT EXISTS (SELECT * FROM inserted)
    BEGIN
        INSERT INTO dbo.FACTURACION_LOG (Accion, FacturaId, Productos, MontoTotal, NCF, NombreVendedor)
        SELECT 'ELIMINACION', ID, Productos, MontoTotal, NCF, NombreVendedor FROM deleted;
    END

    -- MODIFICACIÓN
    IF EXISTS (SELECT * FROM deleted) AND EXISTS (SELECT * FROM inserted)
    BEGIN
        INSERT INTO dbo.FACTURACION_LOG (Accion, FacturaId, Productos, MontoTotal, NCF, NombreVendedor)
        SELECT 'MODIFICACION', ID, Productos, MontoTotal, NCF, NombreVendedor FROM deleted; 
    END
END;
GO

-- 2. Modificar el Trigger para que SOLO envíe a CxC si es Crédito o tiene Seguro
CREATE OR ALTER TRIGGER TRG_CXC_INTEGRACION_FACTURACION
ON dbo.FACTURACION
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM inserted) RETURN;

    DECLARE @NewFacturaId INT;

    -- Solo seleccionamos las facturas que sean a Crédito o tengan Seguro Médico
    DECLARE cur_Facturas CURSOR LOCAL FAST_FORWARD FOR 
    SELECT ID FROM inserted 
    WHERE FormaPago = 'Crédito' OR (ARSNombre IS NOT NULL AND ARSNombre <> '');

    OPEN cur_Facturas;
    FETCH NEXT FROM cur_Facturas INTO @NewFacturaId;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        EXEC dbo.sp_CxC_AplicarFactura @FacturaId = @NewFacturaId;
        FETCH NEXT FROM cur_Facturas INTO @NewFacturaId;
    END;

    CLOSE cur_Facturas;
    DEALLOCATE cur_Facturas;
END;
GO

-- 3. Corregir el SP de pagos para que apunte a FarmaciaCarol en lugar de FacturacionCarol
CREATE OR ALTER PROCEDURE dbo.sp_CxC_AplicarPago
    @PagoId BIGINT
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.CxC_IntegracionAplicada WHERE TipoEvento='PAGO_APLICADO' AND EntidadId=@PagoId) RETURN;

    BEGIN TRY
        BEGIN TRAN;
        DECLARE @FacturaId BIGINT, @Monto DECIMAL(18,2), @FechaPago DATETIME2,
                @RefPago VARCHAR(50) = CONCAT('PAGO-', @PagoId), @RefFac VARCHAR(50);

        -- CORRECCIÓN: Apuntar a la tabla correcta en FarmaciaCarol
        SELECT @FacturaId = p.FacturaId, @Monto = p.Monto, @FechaPago = p.FechaPago
        FROM dbo.Pago p WHERE p.PagoId = @PagoId;

        IF @FacturaId IS NULL THROW 50002, 'Pago no encontrado.', 1;

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

        -- AQUÍ SE CUMPLE TU REGLA: Este SP revisa si el saldo es 0 y lo cambia a 'PAGADO'
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