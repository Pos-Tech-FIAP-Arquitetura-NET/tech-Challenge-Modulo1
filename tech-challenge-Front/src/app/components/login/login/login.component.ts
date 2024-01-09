import {Component, CUSTOM_ELEMENTS_SCHEMA, OnInit} from '@angular/core';
import {AuthServiceService} from "../../../services/authservice/auth-service.service";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {Router} from "@angular/router";
import {NgToastModule, NgToastService} from "ng-angular-popup";
import {GeneralService} from "../../../services/generalService/general.service";

@Component({
  selector: 'app-login',
  template:`
    <div class="container-main-login">

            <img src="./../../../../assets/imagem.png">

        <form [formGroup]="loginForm" (ngSubmit)="onSubmit()">
            <h6>Login</h6>
            <div>
                <label for="email" class="form-label">Email:</label>
                <input type="email" id="email" formControlName="email" class="form-control">
            </div>

            <div>
                <label for="password" class="form-label">Password:</label>
                <input type="password" id="password" formControlName="password" class="form-control">
            </div>

            <button type="submit" [disabled]="loginForm.invalid" class="btn btn-success"
            style="background-color: var(--brand-color3); color: black">Entrar</button>
        </form>
    </div>


  `,
  styleUrls: ['./login.component.sass']
})
export class LoginComponent implements  OnInit{
  loginForm = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.minLength(6)]]
  });
  ngOnInit() {

  }
  constructor(
    private fb: FormBuilder,
    private authService: AuthServiceService,
    private router : Router,
    private generalService: GeneralService) {
  }

  onSubmit() {
    const userName = this.loginForm.value.email;
    const password = this.loginForm.value.password;
    if (this.loginForm.valid && userName && password) {
      this.authService.login(userName, password).subscribe(
        (result) => {
          if(result.user.id > 0){
           this.generalService.showSuccess("Login efetuado com sucesso!")
          this.router.navigate(["/dashboard"]);
          }

        },
        (error) => {
          console.error(error);
        });
    }

  }


}
