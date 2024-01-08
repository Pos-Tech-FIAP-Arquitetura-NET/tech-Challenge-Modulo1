import {Component, OnInit} from '@angular/core';
import {AuthServiceService} from "./services/authservice/auth-service.service";

@Component({
  selector: 'app-root',
  template:`
  <router-outlet></router-outlet>
  `
})
export class AppComponent implements OnInit{
  title = 'Invest Play';

  ngOnInit() {
    this.authService.initialize();
  }
  constructor(private authService : AuthServiceService) {
  }

}
