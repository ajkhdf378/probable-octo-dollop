import { Routes } from '@angular/router';
import { authGuard } from './core/guards/auth.guard';

export const routes: Routes = [
  {
    path: 'login',
    loadComponent: () => import('./features/auth/login/login.component').then(m => m.LoginComponent)
  },
  {
    path: '',
    canActivate: [authGuard],
    loadComponent: () => import('./features/layout/layout.component').then(m => m.LayoutComponent),
    children: [
      {
        path: '',
        redirectTo: 'dashboard',
        pathMatch: 'full'
      },
      {
        path: 'dashboard',
        loadComponent: () => import('./features/dashboard/dashboard.component').then(m => m.DashboardComponent)
      },
      {
        path: 'users',
        loadComponent: () => import('./features/users/users-list/users-list.component').then(m => m.UsersListComponent)
      },
      {
        path: 'restaurants',
        loadComponent: () => import('./features/restaurants/restaurants-list/restaurants-list.component').then(m => m.RestaurantsListComponent)
      },
      {
        path: 'coupons',
        loadComponent: () => import('./features/coupons/coupons-list/coupons-list.component').then(m => m.CouponsListComponent)
      }
    ]
  },
  {
    path: '**',
    redirectTo: ''
  }
];
