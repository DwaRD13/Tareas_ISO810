# Backend - API Asientos Activo Fijo

API REST para el procesamiento de archivos XML de asientos de activos fijos de la Maderera Madeco.

## Instalación

```bash
npm install
```

## Configuración

1. Editar `config/database.js` con las credenciales de tu SQL Server:
   - `user`: Usuario de SQL Server
   - `password`: Contraseña
   - `server`: Servidor (localhost por defecto)
   - `database`: madeco (o la base donde estará la tabla `AsientosActivoFijo`)

## Ejecutar

```bash
# Modo producción
npm start

# Modo desarrollo (con auto-reload)
npm run dev
```

El servidor estará en `http://localhost:3000`

## Endpoints

- `POST /api/asientos-activo-fijo/upload` - Subir archivo XML de asiento activo fijo
- `GET /api/asientos-activo-fijo` - Obtener movimientos registrados + resumen
- `DELETE /api/asientos-activo-fijo/limpiar` - Eliminar todos los registros

## Formato XML esperado

El sistema trabaja con el nodo raíz `asientoActivoFijo` y sus `movimiento`:
- Datos de cabecera: `idTransaccion`, `numeroAsiento`, `descripcionAsiento`, `fechaAsiento`, `moneda`
- En cada movimiento: `tipo` (`DB`/`CR`), `cuentaContable`, `monto`

## Dependencias

- express: Framework web
- cors: Habilitar CORS
- mssql: Driver para SQL Server
- multer: Manejo de archivos
- fast-xml-parser: Procesamiento de XML
