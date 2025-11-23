import { Component, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { AuthService } from '../../core/services/auth.service';

interface MenuItem {
  icon: string;
  label: string;
  route: string;
}

@Component({
  selector: 'app-layout',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss']
})
export class LayoutComponent {
  isSidebarOpen = signal(true);

  menuItems: MenuItem[] = [
    { icon: '📊', label: 'Dashboard', route: '/dashboard' },
    { icon: '👥', label: 'Usuários', route: '/users' },
    { icon: '🍽️', label: 'Restaurantes', route: '/restaurants' },
    { icon: '🎟️', label: 'Cupons', route: '/coupons' }
  ];

  constructor(public authService: AuthService) {}

  toggleSidebar(): void {
    this.isSidebarOpen.update(value => !value);
  }

  logout(): void {
    this.authService.logout();
  }
}
