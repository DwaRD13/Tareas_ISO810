const express = require("express");
const router = express.Router();
const { connectDB, query } = require("../config/database");
const axios = require("axios");

const PORCENTAJE_SEGURO = 0.0304;

// URL de la API de FerrAmeManager (.NET)
const FERR_AME_API_URL =
  process.env.FERR_AME_API_URL || "http://localhost:5000/api/empleados";

// Retorna todos los empleados guardados en la DB de TSS
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

// Consume la API .NET de FerrAmeManager, calcula descuentos y guarda en la DB de TSS
router.post("/cargar-desde-ferreteria", async (req, res) => {
  try {
    // 1. Traer empleados desde la API .NET
    const response = await axios.get(FERR_AME_API_URL);
    const empleadosFerrAme = response.data;

    if (!empleadosFerrAme || empleadosFerrAme.length === 0) {
      return res
        .status(200)
        .json({ message: "No hay empleados en FerrAmeManager.", registros: 0 });
    }

    await connectDB();

    let insertados = 0;
    let omitidos = 0;

    for (const emp of empleadosFerrAme) {
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
          emp.cargo,   // cargo en FerrAme → nombre en TSS
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
    console.error("Error cargando desde FerrAmeManager:", error);

    if (error.code === "ECONNREFUSED") {
      return res.status(503).json({
        error:
          "No se pudo conectar a la API de FerrAmeManager. Verificá que esté corriendo en " +
          FERR_AME_API_URL,
      });
    }

    res.status(500).json({ error: "Error al cargar empleados: " + error.message });
  }
});

module.exports = router;
