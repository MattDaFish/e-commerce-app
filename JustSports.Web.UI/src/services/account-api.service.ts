import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AccountApiService {
  baseUrl = environment.apiUrl;

  constructor(private http:HttpClient) { }

  login(data:any) {
    return this.http.post(this.baseUrl + '/accounts/authenticate', data);
  }

  register(data:any) {
    return this.http.post(this.baseUrl + '/accounts/sign-up', data);
  }

}
