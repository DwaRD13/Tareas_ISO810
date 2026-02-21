import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class EmpleadosService {
  private http = inject(HttpClient);
  
  // Asumimos que tu app en Express (server.js o app.js) monta las rutas en /api/empleados
  private baseUrl = 'http://localhost:3000/api/empleados'; 

  obtenerEmpleados() {
    return this.http.get<any[]>(this.baseUrl); 
  }

  cargarDesdeFerrAme(): Observable<any> {
    return this.http.post(`${this.baseUrl}/cargar-desde-ferreteria`, {});
  }
}
