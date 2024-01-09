import { Component } from '@angular/core';

@Component({
  selector: 'app-sub-menu',
  templateUrl: './sub-menu.component.html',
  styleUrls: ['./sub-menu.component.sass']
})
export class SubMenuComponent {
  submenu = ['Institucional', 'Atendimento','Ajuda',  'FAQ', 'Trabalhe Conosco']

}
