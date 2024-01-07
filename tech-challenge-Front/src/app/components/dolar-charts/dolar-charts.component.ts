import { Component, OnInit } from '@angular/core';
import { CotacaoService } from 'src/app/services/cotacaoMoedasService/cotacao.service';
import { DolarInterface, EuroInterface, PeriodoRelatorioCotacaoMoeda } from 'src/app/interfaces/cotacao-interface';
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'money'
})

export class MoneyPipe implements PipeTransform {
  transform(value: string): string {     
    return parseFloat(value).toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' });
  }
}

@Component({
  selector: 'app-dolar-charts',
  templateUrl: './dolar-charts.component.html',
  styleUrls: ['./dolar-charts.component.sass']
})
export class DolarChartsComponent implements OnInit {

  valorDolarSemana: DolarInterface[] = [];
  valorEuroSemana: EuroInterface[] = [];

  constructor(private cotacaoService: CotacaoService) {}

  

  ngOnInit() {
    this.getDolar();
    this.getEuro() ;
  }

  getDolar() {
    this.cotacaoService.getLastUpdateDolar().subscribe(
      (data) => {   
        this.valorDolarSemana.push(data);
        console.log(data)
 
      },
      (error) => {
        console.error('Erro ao obter o valor do dólar da semana:', error);
      }
    );
  }

  getEuro() {
    this.cotacaoService.getLastUpdateEuro().subscribe(
      (data) => {   
        this.valorEuroSemana.push(data);
        console.log(data)
 
      },
      (error) => {
        console.error('Erro ao obter o valor do dólar da semana:', error);
      }
    );
  }
  

 
}
