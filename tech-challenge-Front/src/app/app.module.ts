import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { HomeComponent } from './pages/home/home.component';
import { DolarChartsComponent, MoneyPipe } from './components/dolar-charts/dolar-charts.component';
import { EuroChartsComponent } from './components/euro-charts/euro-charts.component';
import { HttpClientModule } from '@angular/common/http';
import { DashboardComponent } from './pages/dashboard/dashboard/dashboard.component';
import { LoginComponent } from './components/login/login/login.component';
import { CadastroComponent } from './components/cadastro/cadastro/cadastro.component';
import {NgToastModule} from "ng-angular-popup";
import {FormGroup, FormsModule, ReactiveFormsModule} from "@angular/forms";
import { AccountComponent } from './components/account/account/account.component';
import { MenuLateralComponent } from './components/menuLateral/menu-lateral/menu-lateral.component';
import { MenuSuperiorDashboardComponent } from './components/menuSuperiorDashboard/menu-superior-dashboard/menu-superior-dashboard.component';
import {NgbTooltip} from "@ng-bootstrap/ng-bootstrap";
import { InvestimentComponent } from './components/investiment/investiment.component';
import { SaldoComponent } from './components/saldo/saldo.component';
import { TitulosComponent } from './components/titulos/titulos.component';
import { SubMenuComponent } from './components/sub-menu/sub-menu.component';
import { ModalInvestirComponent } from './components/modal-investir/modal-investir.component';
import {BrowserAnimationsModule, provideAnimations} from "@angular/platform-browser/animations";
import {provideToastr, ToastrModule} from "ngx-toastr";
import { MeusInvestimentosComponent } from './components/meus-investimentos/meus-investimentos.component';
import { ExtratoComponent } from './components/extrato/extrato.component';



@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
    DolarChartsComponent,
    EuroChartsComponent,
    MoneyPipe,
    DashboardComponent,
    LoginComponent,
    CadastroComponent,
    AccountComponent,
    MenuLateralComponent,
    MenuSuperiorDashboardComponent,
    InvestimentComponent,
    SaldoComponent,
    TitulosComponent,
    SubMenuComponent,
    ModalInvestirComponent,
    MeusInvestimentosComponent,
    ExtratoComponent,

  ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        HttpClientModule,
        NgToastModule,
        ReactiveFormsModule,
        FormsModule,
        NgbTooltip,
        BrowserAnimationsModule,
        ToastrModule.forRoot(
          {
            timeOut: 10000,
            positionClass: 'toast-top-right',
            preventDuplicates: true,
          }
        ),

    ],
  providers: [
    provideAnimations(),
    provideToastr()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
