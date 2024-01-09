import { Injectable } from '@angular/core';
import {environment} from "../../../environments/environment";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {AuthServiceService} from "../authservice/auth-service.service";

@Injectable({
  providedIn: 'root'
})
export class BoundService {

  baseUrl = environment.baseUrl;
  headers = new HttpHeaders().set('Authorization', 'Bearer ' + this.authService.getAccessToken());
  options = { headers: this.headers };
  constructor(private http: HttpClient,
              private authService: AuthServiceService) { }

  getAllBoundFixed() {
    return this.http.get<any>(`${this.baseUrl}bound/getAllBoundFixed`, this.options);
  }
  getAllBoundIndexed() {
    return this.http.get<any>(`${this.baseUrl}bound/getAllBoundIndexed`, this.options);
  }
  getBoundById(id: number) {
    return this.http.get<any>(`${this.baseUrl}bound/getBoundById/${id}`, this.options);
  }
}
