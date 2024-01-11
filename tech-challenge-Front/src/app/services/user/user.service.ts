import { Injectable } from '@angular/core';
import {environment} from "../../../environments/environment";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {UserRequestInterface} from "../../interfaces/user-request-interface";
import {AuthServiceService} from "../authservice/auth-service.service";

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = environment.baseUrl;
  headers = new HttpHeaders().set('Authorization', 'Bearer ' + this.authService.getAccessToken());
  options = { headers: this.headers };
  constructor(private http: HttpClient,
               private authService: AuthServiceService) { }

  getAccountInformation(data : UserRequestInterface) {
    return this.http.post<any>(`${this.baseUrl}user/saveUser`, data, this.options);
  }
  retrieveUser() {

    return this.http.get<any>(`${this.baseUrl}user/retrieveUser`, this.options);
  }

  saveUser(data : UserRequestInterface) {
    return this.http.post<any>(`${this.baseUrl}user/saveUser`, data,this.options);
  }
  changeUserEmail(email : string) {
    return this.http.post<any>(`${this.baseUrl}user/changeUserEmail`, email,this.options);
  }
  changePassword(password : string) {
    return this.http.post<any>(`${this.baseUrl}user/changePassword`, password,this.options);
  }


}
