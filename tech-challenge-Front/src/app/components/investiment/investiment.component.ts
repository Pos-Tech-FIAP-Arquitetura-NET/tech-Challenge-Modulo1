import {Component, OnInit} from '@angular/core';
import {AccountService} from "../../services/account/account.service";
import {InvestimentService} from "../../services/investment/investiment.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-investiment',
  template: `
      <div class="container-investiment">
          <label class="form-label" >Total Investido
              <h3>{{  total.toFixed(2) | money}}</h3>
          </label>
          <button (click)="rota()">Ver todos ....</button>
      </div>
  `
   ,
  styleUrls: ['./investiment.component.sass']
})
export class InvestimentComponent implements OnInit {
  investment: any = []
  total: number = 0
  ngOnInit() {
    this.getinvestmentInformation()
  }

  constructor(
    private investmentService: InvestimentService,
    private route: Router) {
  }

  getinvestmentInformation() {
    this.investmentService.getInvestimentsInformation().subscribe((data) => {
      this.investment = data
      this.total = data.reduce((accumulator: any, investment: any) => accumulator + investment.value, 0);
    })
  }

  rota(){
    this.route.navigate(['/dashboard/investimentos'])
  }
}
