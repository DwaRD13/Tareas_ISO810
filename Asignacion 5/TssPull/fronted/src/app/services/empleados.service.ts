import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class EmpleadosService {

  private apiUrl = 'http://localhost:3000/api/empleados';

  constructor(private http: HttpClient) {}

  obtenerEmpleados(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  cargarDesdeFerrAme(): Observable<any> {
    return this.http.post(`${this.apiUrl}/cargar-desde-ferreteria`, {});
  }
}
