import { Injectable } from '@angular/core';
import {environment} from "../../../environments/environment";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {AuthServiceService} from "../authservice/auth-service.service";

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment.baseUrl;
  headers = new HttpHeaders().set('Authorization', 'Bearer ' + this.authService.getAccessToken());
  options = { headers: this.headers };
  constructor(private http: HttpClient,
              private authService: AuthServiceService) { }

  getAccountInformation() {
    return this.http.get<any>(`${this.baseUrl}account/getAccountInformation`, this.options);
  }


}
