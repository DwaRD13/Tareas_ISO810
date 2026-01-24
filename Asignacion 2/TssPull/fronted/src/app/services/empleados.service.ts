import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class EmpleadosService {

  private apiUrl = 'http://localhost:3000/api/empleados';

  constructor(private http: HttpClient) {}

  subirArchivo(file: File): Observable<any> {
    const formData = new FormData();
    formData.append('file', file);
    return this.http.post(`${this.apiUrl}/upload`, formData);
  }

  obtenerEmpleados(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  generarArchivo(): Observable<Blob> {
    return this.http.get(`${this.apiUrl}/generar-archivo`, {
      responseType: 'blob',
    });
  }

  limpiarRegistros(): Observable<any> {
    return this.http.delete(`${this.apiUrl}/limpiar`);
  }
}
