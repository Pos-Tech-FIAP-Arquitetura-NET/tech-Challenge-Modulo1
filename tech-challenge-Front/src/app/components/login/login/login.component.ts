import {Component, OnInit} from '@angular/core';
import {AuthServiceService} from "../../../services/authservice/auth-service.service";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {Router} from "@angular/router";
import {NgToastModule, NgToastService} from "ng-angular-popup";

@Component({
  selector: 'app-login',
  template:`
      <form [formGroup]="loginForm" (ngSubmit)="onSubmit()">
          <div>
              <label for="email">Email:</label>
              <input type="email" id="email" formControlName="email">
          </div>

          <div>
              <label for="password">Password:</label>
              <input type="password" id="password" formControlName="password">
          </div>

          <button type="submit" [disabled]="loginForm.invalid">Entrar</button>
      </form>


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
    private  toast: NgToastService,
    private router : Router) {
  }

  onSubmit() {
    const userName = this.loginForm.value.email;
    const password = this.loginForm.value.password;
    if (this.loginForm.valid && userName && password) {
      this.authService.login(userName, password).subscribe(
        (result) => {
          if(result){
          this.toast.success({detail:"Sucesso!",summary:'Usuário logado com sucesso!',duration:5000, position:'topRight'});
          this.router.navigate(["/dashboard"]);
          }

        },
        (error) => {
          console.error(error);
        });
    }

  }


}
