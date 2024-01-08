import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import {GuardGuard} from "./guards/guard.guard";
import {DashboardComponent} from "./pages/dashboard/dashboard/dashboard.component";
import {LoginComponent} from "./components/login/login/login.component";
import {CadastroComponent} from "./components/cadastro/cadastro/cadastro.component";
import {AccountComponent} from "./components/account/account/account.component";

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'cadastro', component: CadastroComponent },

    ]
  },
  {
    path: 'dashboard',
    component: DashboardComponent,
    canActivate: [GuardGuard],
    children: [
      { path: 'conta', component: AccountComponent },
      { path: 'child2', component: DashboardComponent },
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
