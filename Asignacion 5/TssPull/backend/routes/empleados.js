const express = require("express");
const router = express.Router();
const { connectDB, query } = require("../config/database");

// 3.04% para el SFS de la TSS en República Dominicana
const PORCENTAJE_SEGURO = 0.0304;

// Retorna todos los empleados guardados en la DB de TSS (Para tu Frontend web)
router.get("/", async (req, res) => {
  try {
    await connectDB();
    const result = await query(
      "SELECT * FROM TSSEmpleados ORDER BY fecha_registro DESC"
    );
    res.json(result.recordset);
  } catch (error) {
    console.error("Error obteniendo empleados:", error);
    res.status(500).json({ error: "Error al obtener los datos" });
  }
});

// Recibe los empleados directamente desde tu Windows Form y los guarda en la DB
router.post("/guardar-empleados", async (req, res) => {
  try {
    // 1. Tomamos los datos que el Windows Form nos envía en el cuerpo de la petición
    // Puede ser un solo empleado o un arreglo de empleados. Asumiremos un arreglo.
    const empleadosForm = req.body;

    if (!empleadosForm || empleadosForm.length === 0) {
      return res.status(400).json({ message: "No se recibieron empleados desde el formulario.", registros: 0 });
    }

    await connectDB();

    let insertados = 0;
    let omitidos = 0;

    for (const emp of empleadosForm) {
      // Evitar duplicados por cédula
      const existe = await query(
        "SELECT COUNT(1) AS total FROM TSSEmpleados WHERE cedula = $1",
        [emp.cedula]
      );
      if (existe.recordset[0].total > 0) {
        omitidos++;
        continue;
      }

      const sueldo          = parseFloat(emp.salario) || 0;
      const descuentoSeguro = parseFloat((sueldo * PORCENTAJE_SEGURO).toFixed(2));
      const sueldoNeto      = parseFloat((sueldo - descuentoSeguro).toFixed(2));

      await query(
        `INSERT INTO TSSEmpleados (cedula, cargo, sueldo, descuento_seguro, sueldo_neto, fecha_ingreso, fecha_registro)
         VALUES ($1, $2, $3, $4, $5, $6, GETDATE())`,
        [
          emp.cedula,
          emp.cargo,
          sueldo,
          descuentoSeguro,
          sueldoNeto,
          emp.fechaIngreso,
        ]
      );

      insertados++;
    }

    res.json({
      message: `Carga completada. ${insertados} empleado(s) insertado(s), ${omitidos} omitido(s) por duplicado.`,
      insertados,
      omitidos,
    });
  } catch (error) {
    console.error("Error guardando desde Windows Form:", error);
    res.status(500).json({ error: "Error al guardar empleados: " + error.message });
  }
});

module.exports = router;