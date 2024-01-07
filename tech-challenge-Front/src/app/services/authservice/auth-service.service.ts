import { Injectable } from '@angular/core';
import {environment} from "../../../environments/environment";
import {Router} from "@angular/router";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import { delay, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {
  private token: string ="";
  loggedIn = false;
  baseUrl = environment.baseUrl;
  constructor(private http: HttpClient, public router: Router) { }


  getLoggedUserName() {
    const user = JSON.parse(localStorage.getItem("user")!);
    return user && user.username && user.idUser;
  }

  login(email: string, password: string): Observable<any> {
    console.log("entrei no login");
    const data = {
      email: email,
      password: password,
    };
    console.log("dados passados no login" + data.email);

    return this.http.post(`${this.baseUrl}login`, data).pipe(
      tap((responseToken: any) => {
        if (responseToken) {
          this.token = responseToken.token;

          localStorage.setItem(
            "currentUser",
            JSON.stringify({
              username: responseToken.user.name,
              token: this.token,
              idUser: responseToken.user.id,
            })
          );

          this.router.navigate(['/dashboard/info']);
        }
      })
    );
  }

  logout(): void {
    this.token = "";
    localStorage.removeItem("user");
  }

  getAccessToken() {
    return this.token;
  }

  isAuthenticated(): boolean {
    if(this.token){
      return true
    }
    else {
      return false
    }

  }

}
