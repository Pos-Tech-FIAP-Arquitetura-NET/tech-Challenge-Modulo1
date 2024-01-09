import {Component, OnInit} from '@angular/core';
import {AccountService} from "../../services/account/account.service";
import {InvestimentService} from "../../services/investment/investiment.service";

@Component({
  selector: 'app-investiment',
  template: `
      <div class="container-investiment">
          <label class="form-label" >Total Investido
              <h3>R$ {{  total.toFixed(2) }}</h3>
          </label>
          <button>Ver todos ....</button>
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

  constructor(private investmentService: InvestimentService) {
  }

  getinvestmentInformation() {
    this.investmentService.getInvestimentsInformation().subscribe((data) => {
      this.investment = data
      this.total = data.reduce((accumulator: any, investment: any) => accumulator + investment.value, 0);
    })
  }
}
