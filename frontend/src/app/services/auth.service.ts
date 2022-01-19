import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { LoginRequest } from '../interfaces/login-request';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl: string = environment.baseUrl;
  private publicHeaders = {
    headers: new HttpHeaders({
      'content-type': 'application/json',
    })
  };

  constructor(private http: HttpClient) { }

  login(data: LoginRequest) {
    return this.http.post(
      this.baseUrl + 'api/user/login',
      data,
      this.publicHeaders
    );
  }
}
