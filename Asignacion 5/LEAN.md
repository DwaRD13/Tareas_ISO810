# Instrucciones para correr el proyecto

## 1. API (.NET)
```bash
cd FerrAmeManager.API
dotnet run
```
Dejar la API corriendo.

## 2. Backend (Node/Bun)
```bash
cd TssPull/backend
bun start
# o
npm start
```

## 3. Frontend (Angular)
```bash
cd TssPull/fronted
bun start
# o
npm start
```

## Notas importantes

⚠️ **Seguridad:** No compartan estas credenciales. Si no se nos tira el COA.

Asegúrense de estar usando la base de datos en la nube. Las claves de conexión están en `backend/config/database.js`:

| Configuración | Valor |
|---|---|
| **Server** | `143.110.239.84` |
| **Database** | `TSS` |
| **User** | `sa` |
| **Password** | `TuPasswordFuerte2026!` |

