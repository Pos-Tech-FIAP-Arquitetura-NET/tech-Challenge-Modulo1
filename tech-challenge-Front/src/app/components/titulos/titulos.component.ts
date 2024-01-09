import {Component, OnInit} from '@angular/core';
import {AccountService} from "../../services/account/account.service";
import {BoundService} from "../../services/bound/bound.service";
import { format } from 'date-fns';
import { pt } from 'date-fns/locale';

@Component({
  selector: 'app-titulos',
  templateUrl: './titulos.component.html',
  styleUrls: ['./titulos.component.sass']
})
export class TitulosComponent implements OnInit {
  fixed: any = []
  preIndexed: any = []


  ngOnInit() {
    this.getFixed()
    this.getPreFixed()
  }

  constructor(private boundService: BoundService) {
  }

  getFixed() {
    this.boundService.getAllBoundFixed().subscribe((data) => {
      this.fixed = data
    })
  }
  getPreFixed() {
    this.boundService.getAllBoundIndexed().subscribe((data) => {
      this.preIndexed = data
    })
  }

  getLiquidity(liquidity: number): string {
    switch (liquidity) {
      case 0:
        return 'Liquidez diária';
      case 30:
        return '1 mês';
      case 60:
        return '2 meses';
      case 90:
        return '3 meses';
      case 180:
        return '6 meses';
      case 365:
        return '1 ano';
      case 730:
        return '2 anos';
      case 1825:
        return '5 anos';
      default:
        return '';
    }
  }

  getDueDate(liquidity: number): string {
    const hoje = new Date();

    switch (liquidity) {
      case 0:
        return 'Hoje';
      case 30:
        return format(new Date(hoje.setDate(hoje.getDate() + 30)), 'dd MMM yyyy', { locale: pt });
      case 60:
        return format(new Date(hoje.setDate(hoje.getDate() + 60)), 'dd MMM yyyy', { locale: pt });
      case 90:
        return format(new Date(hoje.setDate(hoje.getDate() + 90)), 'dd MMM yyyy', { locale: pt });
      case 180:
        return format(new Date(hoje.setDate(hoje.getDate() + 180)), 'dd MMM yyyy', { locale: pt });
      case 365:
        return format(new Date(hoje.setDate(hoje.getDate() + 365)), 'dd MMM yyyy', { locale: pt });
      case 730:
        return format(new Date(hoje.setDate(hoje.getDate() + 730)), 'dd MMM yyyy', { locale: pt });
      case 1825:
        return format(new Date(hoje.setDate(hoje.getDate() + 1825)), 'dd MMM yyyy', { locale: pt });
      default:
        return format(hoje, 'dd MMM yyyy', { locale: pt });
    }
  }

  investir(id : number){

  }

}
