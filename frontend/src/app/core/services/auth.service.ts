import { Injectable, inject } from '@angular/core';
import { tap } from 'rxjs/operators';

import { ApiService } from './api.service';

import { LoginDto } from '../models/login.dto';
import { LoginResponseDto } from '../models/login-response.dto';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private api = inject(ApiService);

  login(dto: LoginDto) {
    return this.api
      .post<LoginResponseDto>('auth/login', dto)
      .pipe(
        tap(res => {
          localStorage.setItem('token', res.token);
        })
      );
  }

  logout() {
    localStorage.removeItem('token');
  }

  get token(): string | null {
    return localStorage.getItem('token');
  }

  get isLoggedIn(): boolean {
    return !!this.token;
  }
}