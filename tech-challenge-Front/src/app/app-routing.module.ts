import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import {GuardGuard} from "./guards/guard.guard";
import {DashboardComponent} from "./pages/dashboard/dashboard/dashboard.component";
import {LoginComponent} from "./components/login/login/login.component";
import {CadastroComponent} from "./components/cadastro/cadastro/cadastro.component";

import {TitulosComponent} from "./components/titulos/titulos.component";
import {MeusInvestimentosComponent} from "./components/meus-investimentos/meus-investimentos.component";

import {LadingComponent} from "./components/lading/lading.component";

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    children: [
      { path: 'home', component: LadingComponent },
      { path: 'login', component: LoginComponent },
      { path: 'cadastro', component: CadastroComponent },

    ]
  },
  {
    path: 'dashboard',
    component: DashboardComponent,
    canActivate: [GuardGuard],
    children: [
      { path: 'investir', component: TitulosComponent },
      { path: 'investimentos', component: MeusInvestimentosComponent },
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
