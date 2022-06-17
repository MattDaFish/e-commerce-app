import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BasketApiService {
  baseUrl = environment.apiUrl;

  constructor(private http:HttpClient) { }

  getBasket(customerId:number) {
    return this.http.get(this.baseUrl + `/basket/${customerId}`);
  }

  upsertBasket(data:any) {
    return this.http.put(this.baseUrl + '/basket', data);
  }

  deleteBasket(id:number) {
    return this.http.delete(this.baseUrl + `/basket/${id}`);
  }

}
