INSERT INTO AsientosActivoFijo
    (id_transaccion, numero_asiento, descripcion_asiento, fecha_asiento, moneda, tipo_movimiento, cuenta_contable, monto)
VALUES
    (1331, 42, 'Asiento de Cierre', '2026-02-13', 'DOP', 'DB', '45000002', 50000.00),
    (1331, 42, 'Asiento de Cierre', '2026-02-13', 'DOP', 'CR', '24550003', 60000.00);

SELECT * FROM AsientosActivoFijo;
