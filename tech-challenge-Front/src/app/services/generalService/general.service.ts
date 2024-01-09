import {Injectable, OnInit} from '@angular/core';
import { format } from 'date-fns';
import { pt } from 'date-fns/locale';
import {NgToastService} from "ng-angular-popup";
import {ToastrService} from "ngx-toastr";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";


@Injectable({
  providedIn: 'root'
})
export class GeneralService implements OnInit{
 ngOnInit() {
 }

  constructor(
    private toast: NgToastService,
    private toastr: ToastrService,
    private modalService: NgbModal,) { }

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


  showSuccess(mensagem: string) {
    this.toastr.success(mensagem, 'Sucesso!');
  }

  showError(mensagem: string) {
    this.toastr.error(mensagem, 'Atenção!');

  }

  showInfo(mensagem: string) {
    this.toastr.info(mensagem, 'Informação!');
  }

  showWarn(mensagem: string) {
    this.toastr.warning(mensagem, 'Oops!');
  }

  mensagemAlerta(mensagem: string): Promise<string> {
    return new Promise<string>((resolve, reject) => {
      const modalRef = this.modalService.open('', {
        size: 'md',
        windowClass: 'custom-modal',
      });
      modalRef.componentInstance.mensagem = mensagem;
      modalRef.result.then(
        (result) => {
          resolve(result);
        },
        (err) => {
          reject(err);
        }
      );
    });
  }
}
