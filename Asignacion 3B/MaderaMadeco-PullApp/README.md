# Proyecto - Integración de Asientos de Activos Fijos

Sistema para procesar archivos XML de asientos de activos fijos y persistir sus movimientos en SQL Server.

## Tecnologías
- **Backend**: Node.js + Express + SQL Server
- **Frontend**: Angular
- **Base de datos**: SQL Server (DigitalOcean)

## Requisitos Previos
- Node.js (v16 o superior)
- Angular CLI (`npm install -g @angular/cli`)
- SQL Server corriendo (local o remoto)

## Pasos para Correr el Backend

```bash
# 1. Navegar a la carpeta backend
cd backend

# 2. Instalar dependencias
npm install

# 3. Configurar variables de entorno (opcional, crear archivo .env)
# DB_SERVER=144.126.222.52
# DB_PORT=1433
# DB_USER=sa
# DB_PASSWORD=tu_password
# DB_DATABASE=madeco

# 4. Iniciar el servidor
npm start
# o en modo desarrollo con nodemon
npm run dev
```

El backend estará corriendo en `http://localhost:3000`

Endpoints principales:
- `POST /api/asientos-activo-fijo/upload`
- `GET /api/asientos-activo-fijo`
- `DELETE /api/asientos-activo-fijo/limpiar`

## Pasos para Correr el Frontend

```bash
# 1. Navegar a la carpeta frontend
cd frontend

# 2. Instalar dependencias
npm install

# 3. Iniciar la aplicación Angular
npm start
# o
ng serve
```

El frontend estará disponible en `http://localhost:4200`
