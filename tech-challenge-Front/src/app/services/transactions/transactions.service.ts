import { Injectable } from '@angular/core';
import {environment} from "../../../environments/environment";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {AuthServiceService} from "../authservice/auth-service.service";

@Injectable({
  providedIn: 'root'
})
export class TransactionsService {
  baseUrl = environment.baseUrl;
  headers = new HttpHeaders().set('Authorization', 'Bearer ' + this.authService.getAccessToken());
  options = { headers: this.headers };
  constructor(private http: HttpClient,
              private authService: AuthServiceService) { }

  saveInvestiment(data: {idBound: number, value: number}) {
    return this.http.post<any>(`${this.baseUrl}investiment/saveInvestiment`, data,this.options);
  }
}
