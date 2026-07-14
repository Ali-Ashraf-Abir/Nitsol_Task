import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private http = inject(HttpClient);

  private readonly api = 'http://localhost:5031/api';

  get<T>(url: string, params?: HttpParams) {
    return this.http.get<T>(`${this.api}/${url}`, { params });
  }

  post<T>(url: string, body: unknown) {
    return this.http.post<T>(`${this.api}/${url}`, body);
  }

  put<T>(url: string, body: unknown) {
    return this.http.put<T>(`${this.api}/${url}`, body);
  }

  patch<T>(url: string, body: unknown) {
    return this.http.patch<T>(`${this.api}/${url}`, body);
  }

  delete<T>(url: string) {
    return this.http.delete<T>(`${this.api}/${url}`);
  }
}