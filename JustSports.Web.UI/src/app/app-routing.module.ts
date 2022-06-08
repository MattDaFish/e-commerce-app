import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactComponent } from './contact/contact.component';
import { FeaturedProductComponent } from './product/featured-product/featured-product.component';
import { RegisterCustomerComponent } from './customer/register-customer/register-customer.component';
import { LoginCustomerComponent } from './customer/login-customer/login-customer.component';

const routes: Routes = [  
  { path: '', redirectTo: '/featured', pathMatch: 'full' },
  { path: 'featured', component: FeaturedProductComponent },
  { path: 'contact', component: ContactComponent },
  { path: 'register', component: RegisterCustomerComponent },
  { path: 'login', component: LoginCustomerComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
