import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CategoryComponent } from './category/category.component';
import { ProductComponent } from './product/product.component';
import { CustomerComponent } from './customer/customer.component';
import { OrderComponent } from './order/order.component';
import { FeaturedProductComponent } from './product/featured-product/featured-product.component';
import { ContactComponent } from './contact/contact.component';
import { RegisterCustomerComponent } from './customer/register-customer/register-customer.component';
import { LoginCustomerComponent } from './customer/login-customer/login-customer.component';

import { CategoryApiService } from 'src/services/category-api.service';

@NgModule({
  declarations: [
    AppComponent,
    CategoryComponent,
    ProductComponent,
    CustomerComponent,
    OrderComponent,
    FeaturedProductComponent,
    ContactComponent,
    RegisterCustomerComponent,
    LoginCustomerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [CategoryApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
