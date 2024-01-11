import { Component } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {UserService} from "../../../services/user/user.service";
import {GeneralService} from "../../../services/generalService/general.service";

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.sass']
})
export class CadastroComponent {
  userForm = this.fb.group({
    name: ['', Validators.required],
    cpf: ['', Validators.required],
    dateOfBirth: ['', Validators.required],
    rg: ['', Validators.required],
    dateOfIssue: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
    phoneNumber: ['', Validators.required],
    password: ['', Validators.required],
    // permitions: [1, Validators.required],
    // street: ['', Validators.required],
    // number: ['', Validators.required],
    // zipCode: ['', Validators.required],
    // city: ['', Validators.required],
    // state: ['', Validators.required],
    // country: ['', Validators.required],
  });

  constructor(
    private fb: FormBuilder,
    private userService: UserService,
    private generalService: GeneralService


  ) { }

  ngOnInit(): void {

  }

  onSubmit() {
    const data: any = {
      name: this.userForm.value.name ,
      cpf: this.userForm.value.cpf,
      dateOfBirth: this.userForm.value.dateOfBirth ,
      rg:  this.userForm.value.rg,
      dateOfIssue: this.userForm.value.dateOfIssue ,
      email:  this.userForm.value.email,
      phoneNumber: this.userForm.value.phoneNumber ,
      password: this.userForm.value.password ,
      permitions: 1,
      street:  '',
      number:  '',
      zipCode: '',
      city:  '',
      state: '' ,
      country:''
    };
  console.log(data)
    if (this.userForm.valid) {
      this.userService.saveUser(data).subscribe((data) =>{
        if(data.id > 0){
          this.generalService.showSuccess(`Conta criado com sucesso, confirmação enviada para o email: ${this.userForm.value.email}` )
        }
      },
        error => {
        this.generalService.showError(error.error)
        })

    } else {
        this.generalService.showWarn('Alguns campos sem o preenchimento')
    }
  }
}
