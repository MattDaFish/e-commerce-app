import { Component, Input, OnInit } from '@angular/core';
import { AccountApiService } from 'src/services/account-api.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-account-login',
  templateUrl: './account-login.component.html',
  styleUrls: ['./account-login.component.css']
})
export class AccountLoginComponent implements OnInit {

  form: any = {
    email: null,
    password: null
  };

  constructor(
    private service:AccountApiService, 
    private router: Router, 
    private activatedRoute: ActivatedRoute
  ) { }

  ngOnInit() : void {
  }

  //### Login user - button click method
  loginUser() : void {
   
    var data = {
      email:this.form.email,
      password:this.form.password
    }

    console.log(data);

    this.service.login(data)
    .subscribe({
        next: () => {
              // get return url from query parameters or default to home page
            //const returnUrl = this.activatedRoute.snapshot.queryParams['returnUrl'] || '/';
            this.router.navigateByUrl('/customer');
        },
        error: error => {
            //this.alertService.error(error);
            //this.loading = false;
        }
    });
  }

}
