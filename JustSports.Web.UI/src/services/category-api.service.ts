import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoryApiService {

  readonly categoryAPIUrl = "https://localhost:7184/api/v1";

  constructor(private http:HttpClient) { }

  getCategoriesList():Observable<any[]> {
    return this.http.get<any>(this.categoryAPIUrl + '/categories');    
  }
  
}
