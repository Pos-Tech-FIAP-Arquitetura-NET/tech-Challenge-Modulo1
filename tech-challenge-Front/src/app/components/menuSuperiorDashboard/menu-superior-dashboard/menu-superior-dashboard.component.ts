import {Component, OnInit} from '@angular/core';
import {AuthServiceService} from "../../../services/authservice/auth-service.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-menu-superior-dashboard',
  templateUrl: './menu-superior-dashboard.component.html',
  styleUrls: ['./menu-superior-dashboard.component.sass']
})
export class MenuSuperiorDashboardComponent implements OnInit{

  ngOnInit() {
  }
  constructor(
    private authService: AuthServiceService,
    private router: Router) {
  }

  logout(){
    this.authService.logout()
    this.router.navigate(['/login'])
  }
}
