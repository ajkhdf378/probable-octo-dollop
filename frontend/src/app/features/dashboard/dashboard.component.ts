import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent {
  stats = [
    { title: 'Total de Usuários', value: '1,234', icon: '👥', color: 'bg-blue-500' },
    { title: 'Restaurantes', value: '856', icon: '🍽️', color: 'bg-green-500' },
    { title: 'Cupons Ativos', value: '342', icon: '🎟️', color: 'bg-yellow-500' },
    { title: 'Vendas Hoje', value: 'R$ 12.5k', icon: '💰', color: 'bg-purple-500' }
  ];
}
