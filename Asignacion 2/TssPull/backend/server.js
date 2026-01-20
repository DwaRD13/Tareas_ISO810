const express = require('express');
const cors = require('cors');
const path = require('path');
const fs = require('fs');
const empleadosRouter = require('./routes/empleados');

const app = express();
const PORT = process.env.PORT || 3000;

// Middleware
app.use(cors());
app.use(express.json());
app.use(express.urlencoded({ extended: true }));

// Crear carpeta uploads si no existe
const uploadsDir = path.join(__dirname, 'uploads');
if (!fs.existsSync(uploadsDir)) {
  fs.mkdirSync(uploadsDir);
}

// Rutas
app.use('/api/empleados', empleadosRouter);

// Ruta de prueba
app.get('/', (req, res) => {
  res.json({ message: 'API TSS funcionando correctamente' });
});

// Iniciar servidor
app.listen(PORT, () => {
  console.log(`Servidor corriendo en http://localhost:${PORT}`);
});
