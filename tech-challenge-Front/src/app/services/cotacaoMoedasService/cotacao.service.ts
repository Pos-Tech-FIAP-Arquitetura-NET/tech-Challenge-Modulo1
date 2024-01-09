
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

  public getSelic(): Observable<any> {
    const dataInicial = new Date()
    const dataFinal = new Date()
    const options: Intl.DateTimeFormatOptions = { day: '2-digit', month: '2-digit', year: 'numeric' };

    const dataInicialFormatada = dataInicial.toLocaleDateString('pt-BR', options);
    const dataFinalFormatada = dataFinal.toLocaleDateString('pt-BR', options);

    return this.http.get(`https://api.bcb.gov.br/dados/serie/bcdata.sgs.11/dados?formato=json&dataInicial=${dataInicialFormatada}&dataFinal=${dataFinalFormatada}`)
  }







}

