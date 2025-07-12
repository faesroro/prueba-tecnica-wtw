import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Solicitud {
  id: string;
  tipo: string;
  fechaCreacion: string;
  estado: string;
  datos: any;
}

@Injectable({
  providedIn: 'root'
})
export class SolicitudService {
  private readonly apiUrl = '/api/solicitudes';

  constructor(private http: HttpClient) {}

  getAll(): Observable<Solicitud[]> {
    return this.http.get<Solicitud[]>(this.apiUrl);
  }

  getById(id: string): Observable<Solicitud> {
    return this.http.get<Solicitud>(`${this.apiUrl}/${id}`);
  }

  create(solicitud: any): Observable<any> {
    return this.http.post(this.apiUrl, solicitud);
  }

  delete(id: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

  getByFilters(tipo?: string, estado?: number | '', fecha?: string): Observable<Solicitud[]> {
    const params = new URLSearchParams();
  
    if (tipo) params.append('tipo', tipo);
    if (estado !== undefined && estado !== null) params.append('estado', estado.toString());
    if (fecha) params.append('fecha', fecha);
  
    return this.http.get<Solicitud[]>(`${this.apiUrl}/filtro?${params.toString()}`);
  }
}
