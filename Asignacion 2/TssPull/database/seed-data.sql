INSERT INTO Empleados (cedula, nombre, cuenta_banco, sueldo, descuento_seguro, sueldo_neto, fecha_registro)
VALUES 
    ('001-0000001-1', 'Juan Pérez', '1234567890', 50000.00, 1520.00, 48480.00, NOW()),
    ('001-0000002-2', 'María García', '2345678901', 45000.00, 1368.00, 43632.00, NOW()),
    ('001-0000003-3', 'Pedro Martínez', '3456789012', 60000.00, 1824.00, 58176.00, NOW()),
    ('001-0000004-4', 'Ana López', '4567890123', 40000.00, 1216.00, 38784.00, NOW()),
    ('001-0000005-5', 'Carlos Rodríguez', '5678901234', 55000.00, 1672.00, 53328.00, NOW());

SELECT * FROM Empleados;
