import {Component, OnInit} from '@angular/core';
import {InvestimentService} from "../../services/investment/investiment.service";
import {GeneralService} from "../../services/generalService/general.service";
import {CotacaoService} from "../../services/cotacaoMoedasService/cotacao.service";

@Component({
  selector: 'app-meus-investimentos',
  template:  `
      <h4>Meus investimentos</h4>
  <section>
      <div class="investimentos" *ngFor="let item of investment">
          <button *ngIf="item.bound.availableForWithdrawal" class="sacar" ngbTooltip="Sacar">
              <i class="fa fa-exchange"></i> &nbsp;Sacar</button>
          <small>Valor investido: {{item.amount | money}}</small>
              <small *ngIf="item.bound.index && item.bound.index =='Selic'"> PreFixado Selic + {{item.bound.percent}}%</small>
              <small *ngIf="item.bound.index.length <= 0 "> PosFixado {{item.bound.percent}}% aa</small>
          <small>Disponível para saque {{ item.dueDate | date:'dd/MM/yyyy' }}</small>
          <small>Rendimento {{getRendimento(item.amount, item.aquisitionDate) | money}}</small>
      </div>
  </section>
  `,
  styleUrls: ['./meus-investimentos.component.sass']
})
export class MeusInvestimentosComponent implements OnInit {
  investment: any = []
  total: number = 0
  selic: any;

  ngOnInit() {
    this.getinvestmentInformation()
    this.getSelic()
  }

  constructor(
    private investmentService: InvestimentService,
    private generalService: GeneralService,
    private cotacaoService : CotacaoService
  ) {
  }

  getinvestmentInformation() {
    this.investmentService.getInvestimentsInformation().subscribe((data) => {
      this.investment = data

      this.total = data.reduce((accumulator: any, investment: any) => accumulator + investment.value, 0);
    })
  }

  getSelic(){
    this.cotacaoService.getSelic().subscribe((data)=>{
      this.selic = data[0].valor
    })
  }

  getRendimento(valorInvestido: number, dataInvestido: string): any {
    const taxaSelicDiaria = this.selic / 100;
    const dataInvestimento = new Date(dataInvestido);
    const dataAtual = new Date();

    const milissegundosPorDia = 24 * 60 * 60 * 1000;
    const diasDecorridos: number = Math.floor((dataAtual.getTime() - dataInvestimento.getTime()) / milissegundosPorDia);

    const rendimento = valorInvestido * (1 + taxaSelicDiaria) ** diasDecorridos - valorInvestido;
    const valorReal = valorInvestido + rendimento

    if(valorReal > valorInvestido){
      return  valorReal.toFixed(2)
    }
    else{
      return rendimento
    }

  }

}
