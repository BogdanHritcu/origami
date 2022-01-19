import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PublicService {
  private baseUrl = environment.baseUrl;
  private publicHeaders = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    })
  };

  constructor(private http: HttpClient) { }

  getProfile(username: string) {
    return this.http.get(this.baseUrl + 'api/profile/' + username, this.publicHeaders);
  }

  getOrigami(id: string) {
    return this.http.get(this.baseUrl + 'api/origami/' + id, this.publicHeaders);
  }
}
