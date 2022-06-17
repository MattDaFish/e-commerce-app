import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AccountComponent } from './account/account.component';
import { AccountLoginComponent } from './account/account-login/account-login.component';
import { AccountRegisterComponent } from './account/account-register/account-register.component';
import { AccountThankYouComponent } from './account/account-thank-you/account-thank-you.component';
import { CategoryComponent } from './category/category.component';
import { ContactComponent } from './contact/contact.component';
import { CustomerComponent } from './customer/customer.component';
import { ProductComponent } from './product/product.component';
import { FeaturedProductComponent } from './product/featured-product/featured-product.component';
import { OrderComponent } from './order/order.component';

import { AccountApiService } from 'src/services/account-api.service';
import { CategoryApiService } from 'src/services/category-api.service';
import { OrderApiService } from 'src/services/order-api.service';
import { ProductApiService } from 'src/services/product-api.service';
import { BasketComponent } from './basket/basket.component';

@NgModule({
  declarations: [
    AppComponent,
    AccountComponent,
    AccountLoginComponent,
    AccountRegisterComponent,
    CategoryComponent,
    ContactComponent,
    ProductComponent,
    CustomerComponent,
    OrderComponent,
    FeaturedProductComponent,
    AccountThankYouComponent,
    BasketComponent    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [AccountApiService, CategoryApiService, OrderApiService, ProductApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
