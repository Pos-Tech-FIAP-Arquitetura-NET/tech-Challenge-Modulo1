import {Component, OnInit} from '@angular/core';
import {AccountService} from "../../services/account/account.service";
import {InvestimentService} from "../../services/investment/investiment.service";

@Component({
  selector: 'app-investiment',
  templateUrl: './investiment.component.html',
  styleUrls: ['./investiment.component.sass']
})
export class InvestimentComponent implements OnInit {
  investment: any = []

  ngOnInit() {
    this.getinvestmentInformation()
  }

  constructor(private investmentService: InvestimentService) {
  }

  getinvestmentInformation() {
    this.investmentService.getInvestimentsInformation().subscribe((data) => {
      this.investment = data
    })
  }
}
