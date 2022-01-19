import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PrivateService {
  private baseUrl = environment.baseUrl;
  private privateHeaders = {
    headers: new HttpHeaders({
      'content-type': 'application/json',
      Authorization: '' + localStorage.getItem('token')
    })
  };
  constructor(private http: HttpClient) { }

  getMyProfile() {
    return this.http.get(this.baseUrl + 'api/profile/me', this.privateHeaders);
  }

  getUserCreations(username: string) {
    return this.http.get(this.baseUrl + 'api/origami/creations/' + username, this.privateHeaders);
  }
}
