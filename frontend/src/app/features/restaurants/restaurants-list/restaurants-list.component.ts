import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-restaurants-list',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="space-y-6">
      <div>
        <h1 class="text-3xl font-bold text-gray-900">Restaurantes</h1>
        <p class="text-gray-600 mt-1">Gerencie os restaurantes cadastrados</p>
      </div>

      <div class="card">
        <div class="text-center py-12">
          <span class="text-6xl">🍽️</span>
          <h3 class="mt-4 text-lg font-medium text-gray-900">Módulo de Restaurantes</h3>
          <p class="mt-2 text-gray-600">Implemente o CRUD completo seguindo o padrão de Usuários</p>
        </div>
      </div>
    </div>
  `
})
export class RestaurantsListComponent {}
