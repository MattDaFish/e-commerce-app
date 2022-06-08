import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { CategoryApiService } from 'src/services/category-api.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  categoryList$!:Observable<any[]>;

  constructor(private service:CategoryApiService) { }

  ngOnInit(): void {
    this.categoryList$ = this.service.getCategoriesList();
  }

}
