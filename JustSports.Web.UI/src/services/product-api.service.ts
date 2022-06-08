import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductApiService {

  readonly productAPIUrl = "https://localhost:7184/api/v1";

  constructor(private http:HttpClient) { }

  getProductsList():Observable<any[]> {
    return this.http.get<any>(this.productAPIUrl + '/products');    
  }

}
