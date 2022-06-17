import { Component, OnInit } from '@angular/core';
import { AccountApiService } from 'src/services/account-api.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-account-register',
  templateUrl: './account-register.component.html',
  styleUrls: ['./account-register.component.css']
})
export class AccountRegisterComponent implements OnInit {

  form: any = {
    email: null,
    password: null,
    confirmPassword: null
  };

  constructor(
    private service:AccountApiService, 
    private router: Router, 
    private activatedRoute: ActivatedRoute
  ) { }

  ngOnInit(): void {
  }

  //### Register user - button click method
  registerUser() : void {
   
    var data = {
      email:this.form.email,
      password:this.form.password,
      confirmPassword:this.form.confirmPassword
    }

    console.log(data);

    this.service.register(data)
    .subscribe({
        next: () => {
            this.router.navigateByUrl('/thank-you');
        },
        error: error => {
            //this.alertService.error(error);
            //this.loading = false;
        }
    });
  }  
}
