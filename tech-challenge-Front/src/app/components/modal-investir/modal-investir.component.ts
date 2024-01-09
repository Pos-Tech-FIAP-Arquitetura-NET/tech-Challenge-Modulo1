import {Component, Input, OnInit} from '@angular/core';
import {NgbActiveModal, NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {FormBuilder, Validators} from "@angular/forms";
import {BoundService} from "../../services/bound/bound.service";
import {GeneralService} from "../../services/generalService/general.service";
import {InvestimentService} from "../../services/investment/investiment.service";
import {AccountService} from "../../services/account/account.service";

@Component({
  selector: 'app-modal-investir',
  template: `
      <div class='modal-body'>
          <form [formGroup]="investindoForm" (ngSubmit)="onSubmit()">
              <h6>Investimento Selecionado: </h6>
              <div  class="investimento-info">
                  <small> {{bound.type == "Fixed Bound" ? 'PreFixado' : 'PosFixado'}} de {{bound.percent.toFixed(2)}}% aa </small>
                  <small>Disponível para saque, {{generalServices.getDueDate(bound.liquidityType)}}.</small>
              </div>

             <label for="valorInvestido" class="form-label">Valor:
                  <input type="number" id="valorInvestido" formControlName="valorInvestido" class="form-control" >
              </label>

              <button type="submit"  class="btn btn-success"
               style="background-color: var(--brand-color3);
               color: black;
               border: none">Investir</button>
          </form>
      </div>
  `,
  styleUrls: ['./modal-investir.component.sass']
})
export class ModalInvestirComponent implements OnInit{
  @Input() idBound = 0;
  bound: any;
  balance: any;

  investindoForm = this.fb.group({
    valorInvestido: [0, [Validators.required]],

  });
  ngOnInit() {
this.getBoundById()
    this.getAccountInformation()
  }

  constructor(
    private modalService: NgbModal,
    private fb: FormBuilder,
    private boundService: BoundService,
    public generalServices: GeneralService,
    public investimentService: InvestimentService,
    public activeModal : NgbActiveModal,
    private accountService: AccountService
    ) {
  }

  getBoundById(){
    this.boundService.getBoundById(this.idBound).subscribe((data) =>{
      this.bound = data
      console.log(data)
    })

  }

  onSubmit(){

    const valor = this.investindoForm.value.valorInvestido;
console.log("saldo" + this.balance)
if(this.balance >= 0){
  if(valor && valor >= 100){
    const data = {
      idBound: this.idBound,
      value: valor
    }
    this.investimentService.saveInvestiment(data).subscribe((response) => {
        this.generalServices.showSuccess(response.message)
        this.activeModal.close()
      },
      err =>{
        console.log(err)
      })
  }
  else{
    this.generalServices.showWarn('Valor informado menor que o aporte mínimo');
  }
} else{
  this.generalServices.showError('Você não possui esse valor disponível')
}


  }

  getAccountInformation(){
    this.accountService.getAccountInformation().subscribe((data)=>{
      this.balance = data.account.balance
    })
  }

}
