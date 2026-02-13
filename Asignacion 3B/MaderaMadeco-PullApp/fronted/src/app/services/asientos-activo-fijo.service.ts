import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AsientosActivoFijoService {
  private apiUrl = 'http://localhost:3000/api/asientos-activo-fijo';

  constructor(private http: HttpClient) {}

  subirXml(file: File): Observable<any> {
    const formData = new FormData();
    formData.append('file', file);
    return this.http.post(`${this.apiUrl}/upload`, formData);
  }

  obtenerMovimientos(): Observable<any> {
    return this.http.get<any>(this.apiUrl);
  }

  limpiarRegistros(): Observable<any> {
    return this.http.delete(`${this.apiUrl}/limpiar`);
  }
}
