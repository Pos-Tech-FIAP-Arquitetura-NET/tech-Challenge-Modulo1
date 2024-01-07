
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DolarInterface, EuroInterface, PeriodoRelatorioCotacaoMoeda } from 'src/app/interfaces/cotacao-interface';


@Injectable({
  providedIn: 'root'
})
export class CotacaoService {

  public url: string = "https://economia.awesomeapi.com.br";
  constructor(private http: HttpClient) { }

  public getLastUpdateDolar(): Observable<DolarInterface> {
    return this.http.get<DolarInterface>(`${this.url}/last/USD-BRL`).pipe(
      res => res,
      error => error
    )
  }

  public getLastUpdateEuro(): Observable<EuroInterface> {
    return this.http.get<EuroInterface>(`${this.url}/last/EUR-BRL`).pipe(
      res => res,
      error => error
    )
  }

 

 
 


}

