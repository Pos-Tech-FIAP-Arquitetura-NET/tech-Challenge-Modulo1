import {Component, OnInit} from '@angular/core';
import {AccountService} from "../../services/account/account.service";
import {BoundService} from "../../services/bound/bound.service";
import { format } from 'date-fns';
import { pt } from 'date-fns/locale';
import {GeneralService} from "../../services/generalService/general.service";
import {ModalInvestirComponent} from "../modal-investir/modal-investir.component";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";

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

  constructor(
    private boundService: BoundService,
    public generalService: GeneralService,
    private modalService: NgbModal) {
  }

  getFixed() {
    this.boundService.getAllBoundFixed().subscribe((data) => {
      this.fixed = data
    })
  }
  getPreFixed() {
    this.boundService.getAllBoundIndexed().subscribe((data) => {
      this.preIndexed = data
      console.log(data)
    })
  }



  investir(id : number){

    const modalRef = this.modalService.open(ModalInvestirComponent, {
      size: 'md',
      windowClass: 'custom-modal',
    });
    modalRef.componentInstance.idBound = id;
  }

}
