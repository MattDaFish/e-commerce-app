import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductApiService } from 'src/services/product-api.service';

@Component({
  selector: 'app-featured-product',
  templateUrl: './featured-product.component.html',
  styleUrls: ['./featured-product.component.css']
})
export class FeaturedProductComponent implements OnInit {

  productList$!:Observable<any[]>;

  constructor(private service:ProductApiService) { }

  ngOnInit(): void {
    this.productList$ = this.service.getProductsList();
  }

}
