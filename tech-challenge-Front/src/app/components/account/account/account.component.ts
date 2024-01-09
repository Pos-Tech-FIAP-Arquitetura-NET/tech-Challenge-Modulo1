import {Component, OnInit} from '@angular/core';
import {AccountService} from "../../../services/account/account.service";
import {AuthServiceService} from "../../../services/authservice/auth-service.service";
import {Router} from "@angular/router";
import {UserService} from "../../../services/user/user.service";

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.sass']
})
export class AccountComponent implements OnInit{

  account:any = []
  nomeSaudacao: string ="";


  ngOnInit() {
    this.obterUsuario()
    this.getAccountInformation()
  }
  constructor(
    private authService: AuthServiceService,
    private router: Router,
    private userService: UserService,
    private accountService: AccountService) {
  }

  getAccountInformation(){
    this.accountService.getAccountInformation().subscribe((data)=>{
      this.account = data.account
    })
  }


  logout(){
    this.authService.logout()
    this.router.navigate(['/login'])
  }

  obterUsuario(){
    this.userService.retrieveUser().subscribe((data) => {
      console.log(data)
      this.nomeSaudacao = data.name
    })
  }
}
