import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { BasketApiService } from 'src/services/basket-api.service';
import { IBasket, IBasketItem } from 'src/app/shared/models/basket';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.css']
})
export class BasketComponent implements OnInit {

  basket$!: Observable<any[]>;

  constructor(private service:BasketApiService) { }

  ngOnInit(): void {
    //this.basket$ = this.service.getBasket(9);
  }

}
