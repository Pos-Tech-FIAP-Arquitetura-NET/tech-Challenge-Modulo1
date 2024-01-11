import {Component, OnInit} from '@angular/core';
import {InvestimentService} from "../../services/investment/investiment.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-lading',
  templateUrl: './lading.component.html',
  styleUrls: ['./lading.component.sass']
})
export class LadingComponent implements OnInit{
ngOnInit() {
}

  constructor(
    private investmentService: InvestimentService,
    private route: Router) {
  }
  rota(){
    this.route.navigate(['/cadastro'])
  }
}
