const express = require("express");
const router = express.Router();
const multer = require("multer");
const fs = require("fs");
const { XMLParser } = require("fast-xml-parser");
const { connectDB, query } = require("../config/database");

const upload = multer({ dest: "uploads/" });

const parser = new XMLParser({
  ignoreAttributes: false,
  attributeNamePrefix: "",
  parseAttributeValue: true,
  parseTagValue: true,
  trimValues: true,
});

function parsearAsientoXML(contenido) {
  const data = parser.parse(contenido);
  const asiento = data?.asientoActivoFijo;

  if (!asiento) {
    throw new Error("El XML no contiene el nodo raíz 'asientoActivoFijo'");
  }

  const numeroAsiento = Number(asiento.numeroAsiento);
  const descripcionAsiento = String(asiento.descripcionAsiento || "").trim();
  const fechaAsiento = String(asiento.fechaAsiento || "").trim();
  const moneda = String(asiento.moneda || "").trim();
  const idTransaccion = Number(asiento.idTransaccion);

  if (!numeroAsiento || !descripcionAsiento || !fechaAsiento || !moneda || !idTransaccion) {
    throw new Error("Faltan datos obligatorios del encabezado del asiento");
  }

  let movimientos = asiento?.movimientos?.movimiento || [];
  if (!Array.isArray(movimientos)) {
    movimientos = [movimientos];
  }

  if (!movimientos.length) {
    throw new Error("El XML no contiene movimientos");
  }

  const movimientosNormalizados = movimientos.map((mov, index) => {
    const tipoMovimiento = String(mov.tipo || "").trim().toUpperCase();
    const cuentaContable = String(mov.cuentaContable || "").trim();
    const monto = Number(mov.monto);

    if (!["DB", "CR"].includes(tipoMovimiento)) {
      throw new Error(`Tipo de movimiento inválido en la línea ${index + 1}`);
    }

    if (!cuentaContable) {
      throw new Error(`Cuenta contable inválida en la línea ${index + 1}`);
    }

    if (!Number.isFinite(monto) || monto <= 0) {
      throw new Error(`Monto inválido en la línea ${index + 1}`);
    }

    return {
      tipoMovimiento,
      cuentaContable,
      monto,
    };
  });

  return {
    encabezado: {
      idTransaccion,
      numeroAsiento,
      descripcionAsiento,
      fechaAsiento,
      moneda,
    },
    movimientos: movimientosNormalizados,
  };
}

router.post("/upload", upload.single("file"), async (req, res) => {
  try {
    if (!req.file) {
      return res.status(400).json({ error: "No se recibió ningún archivo" });
    }

    if (!req.file.originalname.toLowerCase().endsWith(".xml")) {
      fs.unlinkSync(req.file.path);
      return res.status(400).json({ error: "El archivo debe ser XML" });
    }

    await connectDB();

    const contenido = fs.readFileSync(req.file.path, "utf-8");
    const { encabezado, movimientos } = parsearAsientoXML(contenido);

    for (const movimiento of movimientos) {
      await query(
        `INSERT INTO AsientosActivoFijo 
        (id_transaccion, numero_asiento, descripcion_asiento, fecha_asiento, moneda, tipo_movimiento, cuenta_contable, monto, fecha_registro)
        VALUES ($1, $2, $3, $4, $5, $6, $7, $8, SYSDATETIME())`,
        [
          encabezado.idTransaccion,
          encabezado.numeroAsiento,
          encabezado.descripcionAsiento,
          encabezado.fechaAsiento,
          encabezado.moneda,
          movimiento.tipoMovimiento,
          movimiento.cuentaContable,
          movimiento.monto,
        ],
      );
    }

    fs.unlinkSync(req.file.path);

    const totalDebitos = movimientos
      .filter((m) => m.tipoMovimiento === "DB")
      .reduce((sum, m) => sum + m.monto, 0);
    const totalCreditos = movimientos
      .filter((m) => m.tipoMovimiento === "CR")
      .reduce((sum, m) => sum + m.monto, 0);

    res.json({
      message: "Archivo XML procesado exitosamente",
      encabezado,
      movimientos,
      resumen: {
        cantidadMovimientos: movimientos.length,
        totalDebitos,
        totalCreditos,
        balanceado: totalDebitos === totalCreditos,
      },
    });
  } catch (error) {
    console.error("Error en upload XML:", error);
    if (req.file && fs.existsSync(req.file.path)) {
      fs.unlinkSync(req.file.path);
    }
    res
      .status(500)
      .json({ error: "Error procesando el archivo XML: " + error.message });
  }
});

router.get("/", async (req, res) => {
  try {
    await connectDB();
    const result = await query(
      `SELECT 
          id,
          id_transaccion,
          numero_asiento,
          descripcion_asiento,
          fecha_asiento,
          moneda,
          tipo_movimiento,
          cuenta_contable,
          monto,
          fecha_registro
       FROM AsientosActivoFijo
       ORDER BY fecha_registro DESC, id DESC`,
    );

    const rows = result.recordset;
    const totalDebitos = rows
      .filter((m) => m.tipo_movimiento === "DB")
      .reduce((sum, m) => sum + Number(m.monto || 0), 0);
    const totalCreditos = rows
      .filter((m) => m.tipo_movimiento === "CR")
      .reduce((sum, m) => sum + Number(m.monto || 0), 0);

    res.json({
      movimientos: rows,
      resumen: {
        totalRegistros: rows.length,
        totalDebitos,
        totalCreditos,
        balanceado: totalDebitos === totalCreditos,
      },
    });
  } catch (error) {
    console.error("Error obteniendo asientos:", error);
    res.status(500).json({ error: "Error al obtener los asientos" });
  }
});

router.delete("/limpiar", async (req, res) => {
  try {
    await connectDB();
    await query("DELETE FROM AsientosActivoFijo");
    res.json({ message: "Todos los registros han sido eliminados" });
  } catch (error) {
    console.error("Error limpiando registros:", error);
    res.status(500).json({ error: "Error al limpiar los registros" });
  }
});

module.exports = router;
