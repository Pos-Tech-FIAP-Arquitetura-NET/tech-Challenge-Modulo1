import {Component, OnInit} from '@angular/core';
import {AccountService} from "../../services/account/account.service";

@Component({
  selector: 'app-saldo',
  templateUrl: './saldo.component.html',
  styleUrls: ['./saldo.component.sass']
})
export class SaldoComponent  implements OnInit{
  account:any = []
  ngOnInit() {
    this.getAccountInformation()
  }
  constructor(private accountService: AccountService) {
  }

  getAccountInformation(){
    this.accountService.getAccountInformation().subscribe((data)=>{
      this.account = data.account
    })
  }
}
