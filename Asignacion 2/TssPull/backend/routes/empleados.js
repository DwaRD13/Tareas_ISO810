const express = require("express");
const router = express.Router();
const multer = require("multer");
const fs = require("fs");
const path = require("path");
const { connectDB, query } = require("../config/database");

const upload = multer({ dest: "uploads/" });

const PORCENTAJE_SEGURO = 0.0304;

function parsearLayoutTXT(contenido) {
  const lineas = contenido.split("\n").filter((linea) => linea.trim() !== "");
  const empleados = [];
  let encabezado = null;

  for (const linea of lineas) {
    if (linea.length < 5) continue;

    const tipo = linea.substring(0, 1); 
    if (tipo === "E") {

      encabezado = {
        tipo: "E",
        numeroControl: linea.substring(1, 12).trim(),
        fechaProceso: linea.substring(12, 22).trim(),
        periodo: linea.substring(22, 28).trim(),
      };
    } else if (tipo === "D") {
      const cedula = linea.substring(1, 12);
      const sueldo = linea.substring(12, 22);
      const fechaIngreso = linea.substring(22, 32);
      const tipoEmpleado = linea.substring(32, 33);
      const cargo = linea.substring(33, 73);

      if (isNaN(sueldo)) continue;

      const descuentoSeguro = sueldo * PORCENTAJE_SEGURO;
      const sueldoNeto = sueldo - descuentoSeguro;

      let fechaSQL = null;
      if (fechaIngreso.length === 10) {
        const [dia, mes, anio] = fechaIngreso.split("/");
        fechaSQL = `${anio}-${mes}-${dia}`;
      }

      empleados.push({
        cedula,
        nombre: cargo,
        cuentaBanco: cedula,
        sueldo,
        descuentoSeguro,
        sueldoNeto,
        fechaNacimiento: "1990-01-01",
        sexo: "F",
      });
    }
  }

  return { encabezado, empleados };
}

router.post("/upload", upload.single("file"), async (req, res) => {
  try {
    if (!req.file) {
      return res.status(400).json({ error: "No se recibió ningún archivo" });
    }

    await connectDB();

    const contenido = fs.readFileSync(req.file.path, "utf-8");
    const { encabezado, empleados } = parsearLayoutTXT(contenido);

    for (const emp of empleados) {
      await query(
        `INSERT INTO Empleados 
         (cedula, nombre, cuenta_banco, sueldo, descuento_seguro, sueldo_neto, fecha_registro)
         VALUES ($1, $2, $3, $4, $5, $6, GETDATE())`,
        [
          emp.cedula,
          emp.nombre,
          emp.cuentaBanco,
          emp.sueldo,
          emp.descuentoSeguro,
          emp.sueldoNeto,
        ],
      );
    }

    fs.unlinkSync(req.file.path);

    res.json({
      message: "Archivo procesado exitosamente",
      registros: empleados.length,
      encabezado,
      empleados,
    });
  } catch (error) {
    console.error("Error en upload:", error);
    res
      .status(500)
      .json({ error: "Error procesando el archivo: " + error.message });
  }
});

router.get("/", async (req, res) => {
  try {
    await connectDB();
    const result = await query(
      "SELECT * FROM Empleados ORDER BY fecha_registro DESC",
    );
    res.json(result.recordset);
  } catch (error) {
    console.error("Error obteniendo empleados:", error);
    res.status(500).json({ error: "Error al obtener los datos" });
  }
});

router.get("/generar-archivo", async (req, res) => {
  try {
    await connectDB();
    const result = await query("SELECT * FROM Empleados ORDER BY cedula");

    const fecha = new Date();
    const fechaProceso = fecha.toISOString().split("T")[0].replace(/-/g, ""); // YYYYMMDD
    const periodo = fechaProceso.substring(0, 6); // YYYYMM
    const numeroControl = Math.floor(Math.random() * 1000000000)
      .toString()
      .padStart(9, "0");

    let contenido = `E ${numeroControl} ${fechaProceso} ${periodo}\n`;

    result.recordset.forEach((emp) => {
      const cedula = emp.cedula.toString().padEnd(11, " ");
      const sueldoNum = parseFloat(emp.sueldo) || 0;
      const sueldo = sueldoNum.toFixed(2).padStart(8, " ");
      const descuentoVal =
        parseFloat(emp.descuento_seguro || emp.descuentoSeguro) ||
        parseFloat((sueldoNum * PORCENTAJE_SEGURO).toFixed(2));
      const descuento = descuentoVal.toFixed(2).padStart(8, " ");
      const sueldoNetoVal = sueldoNum - descuentoVal;
      const sueldoNeto = sueldoNetoVal.toFixed(2).padStart(8, " ");
      const fechaNac = "01011990"; // Fecha por defecto si no existe
      const sexo = (emp.sexo || "F").toString().trim().charAt(0) || "F"; // Sexo por defecto
      const posicion = emp.nombre || "Empleado";

      contenido += `D ${cedula} ${sueldo} ${descuento} ${sueldoNeto} ${fechaNac} ${sexo} ${posicion}\n`;
    });

    contenido += `S ${result.recordset.length}\n`;

    const fileName = `empleados_procesados_${Date.now()}.txt`;
    const filePath = path.join(__dirname, "../uploads", fileName);

    if (!fs.existsSync(path.join(__dirname, "../uploads"))) {
      fs.mkdirSync(path.join(__dirname, "../uploads"));
    }

    fs.writeFileSync(filePath, contenido);

    res.download(filePath, fileName, (err) => {
      if (err) {
        console.error("Error enviando archivo:", err);
      }
      fs.unlinkSync(filePath);
    });
  } catch (error) {
    console.error("Error generando archivo:", error);
    res.status(500).json({ error: "Error al generar el archivo" });
  }
});

router.delete("/limpiar", async (req, res) => {
  try {
    await connectDB();
    await query("DELETE FROM Empleados");
    res.json({ message: "Todos los registros han sido eliminados" });
  } catch (error) {
    console.error("Error limpiando registros:", error);
    res.status(500).json({ error: "Error al limpiar los registros" });
  }
});

module.exports = router;
