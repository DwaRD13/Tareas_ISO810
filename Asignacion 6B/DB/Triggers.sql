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

CREATE OR ALTER TRIGGER TRG_CXC_INTEGRACION_FACTURACION
ON dbo.FACTURACION
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM inserted) RETURN;

    DECLARE @NewFacturaId INT;

    -- Usamos un cursor rápido para procesar múltiples inserciones en batch si llegaran a ocurrir
    DECLARE cur_Facturas CURSOR LOCAL FAST_FORWARD FOR 
    SELECT ID FROM inserted;

    OPEN cur_Facturas;
    FETCH NEXT FROM cur_Facturas INTO @NewFacturaId;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Llamamos al Stored Procedure por cada ID nuevo
        EXEC dbo.sp_CxC_AplicarFactura @FacturaId = @NewFacturaId;

        FETCH NEXT FROM cur_Facturas INTO @NewFacturaId;
    END;

    CLOSE cur_Facturas;
    DEALLOCATE cur_Facturas;
END;
GO