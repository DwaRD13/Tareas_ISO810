# Backend - TSS API

API REST para el procesamiento de archivos de layout TXT de empleados y cálculo de descuentos del SDSS.

## Instalación

```bash
npm install
```

## Configuración

1. Editar `config/database.js` con las credenciales de tu SQL Server:
   - `user`: Usuario de SQL Server
   - `password`: Contraseña
   - `server`: Servidor (localhost por defecto)
   - `database`: TSS_DB

## Ejecutar

```bash
# Modo producción
npm start

# Modo desarrollo (con auto-reload)
npm run dev
```

El servidor estará en `http://localhost:3000`

## Endpoints

- `POST /api/empleados/upload` - Subir archivo de layout TXT
- `GET /api/empleados` - Obtener todos los empleados
- `GET /api/empleados/generar-archivo` - Generar archivo de salida en formato layout TXT
- `DELETE /api/empleados/limpiar` - Eliminar todos los registros

## Formato de Archivo Layout TXT

El sistema trabaja con archivos de layout TXT:
- **E**: Línea de encabezado (número control, fecha, período)
- **D**: Líneas de detalle (cédula, sueldo, fecha nacimiento, sexo, posición)
- **S**: Línea de sumario (total de registros)

Ver `database/FORMATO-LAYOUT.md` para especificaciones completas.

## Dependencias

- express: Framework web
- cors: Habilitar CORS
- mssql: Driver para SQL Server
- multer: Manejo de archivos
- csv-parser: Procesamiento de CSV
