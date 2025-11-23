import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-coupons-list',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="space-y-6">
      <div>
        <h1 class="text-3xl font-bold text-gray-900">Cupons</h1>
        <p class="text-gray-600 mt-1">Gerencie os cupons de desconto</p>
      </div>

      <div class="card">
        <div class="text-center py-12">
          <span class="text-6xl">🎟️</span>
          <h3 class="mt-4 text-lg font-medium text-gray-900">Módulo de Cupons</h3>
          <p class="mt-2 text-gray-600">Implemente o CRUD completo seguindo o padrão de Usuários</p>
        </div>
      </div>
    </div>
  `
})
export class CouponsListComponent {}
