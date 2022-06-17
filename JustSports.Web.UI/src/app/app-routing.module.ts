import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ContactComponent } from './contact/contact.component';
import { CustomerComponent } from './customer/customer.component';
import { FeaturedProductComponent } from './product/featured-product/featured-product.component';
import { AccountRegisterComponent } from './account/account-register/account-register.component';
import { AccountLoginComponent } from './account/account-login/account-login.component';
import { AccountThankYouComponent } from './account/account-thank-you/account-thank-you.component';

const routes: Routes = [  
  { path: '', redirectTo: '/featured', pathMatch: 'full' },
  { path: 'contact', component: ContactComponent },
  { path: 'customer', component: CustomerComponent },
  { path: 'featured', component: FeaturedProductComponent },
  { path: 'login', component: AccountLoginComponent },
  { path: 'register', component: AccountRegisterComponent },
  { path: 'thank-you', component: AccountThankYouComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
