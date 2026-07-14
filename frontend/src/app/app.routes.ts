import { Routes } from '@angular/router';
import { LoginComponent } from './Components/login-component/login-component';
import { authGuard } from './core/guard/auth.guard';
import { HomeComponent } from './Components/home-component/home-component';


export const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent
  },
    {

    path: 'convert',

    canActivate: [authGuard],

    loadComponent: () =>
      import('./Components/currency-component/currency-component')
        .then(m => m.CurrencyComponent)

  },
  {
    path: '',
    component: HomeComponent
  },
  {

    path: '**',

    redirectTo: ''

  }
];