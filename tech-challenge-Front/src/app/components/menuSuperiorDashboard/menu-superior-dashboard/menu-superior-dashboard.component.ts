import {Component, OnInit} from '@angular/core';
import {AuthServiceService} from "../../../services/authservice/auth-service.service";
import {Router} from "@angular/router";
import {UserService} from "../../../services/user/user.service";
import {AccountService} from "../../../services/account/account.service";

@Component({
  selector: 'app-menu-superior-dashboard',
  templateUrl: './menu-superior-dashboard.component.html',
  styleUrls: ['./menu-superior-dashboard.component.sass']
})
export class MenuSuperiorDashboardComponent implements OnInit{

menu= [
  {
  titulo:'Extrato',
  route:'',
  fafaIcon:"fa fa-file-text",
  color: 'var(--brand-color1)'
  },
  {
    titulo:'Transferências',
    route:'',
    fafaIcon:"fa fa-exchange",
    color: 'var(--brand-color3)'
  },
  {
    titulo:'PIX',
    route:'',
    fafaIcon:"fa fa-paste",
    color: 'var(--brand-color1)'
  },
  {
    titulo:'Meus investimentos',
    route:'',
    fafaIcon:"fa fa-line-chart",
    color: 'var(--brand-color3)'
  },
  {
    titulo:'Investir',
    route:'',
    fafaIcon:"fa fa-bar-chart",
    color: 'var(--brand-color1)'
  },
  {
    titulo:'Comprar moedas',
    route:'',
    fafaIcon:"fa fa-dollar",
    color: 'var(--brand-color3)'
  },
]


  ngOnInit() {
  }
constructor() {
}

}
