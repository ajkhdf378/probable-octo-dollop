import { Component, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { UserService } from '../../../core/services/user.service';
import { User, CreateUserDto } from '../../../core/models/user.model';

@Component({
  selector: 'app-users-list',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.scss']
})
export class UsersListComponent implements OnInit {
  users = signal<User[]>([]);
  isLoading = signal(false);
  showModal = signal(false);
  isEditing = signal(false);
  userForm!: FormGroup;
  selectedUserId: string | null = null;

  roles = ['Admin', 'Manager', 'Operator', 'Viewer'];

  constructor(
    private userService: UserService,
    private fb: FormBuilder
  ) {
    this.initForm();
  }

  ngOnInit(): void {
    this.loadUsers();
  }

  initForm(): void {
    this.userForm = this.fb.group({
      name: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      role: ['Viewer', [Validators.required]],
      phoneNumber: ['']
    });
  }

  loadUsers(): void {
    this.isLoading.set(true);
    this.userService.getAll().subscribe({
      next: (users) => {
        this.users.set(users);
        this.isLoading.set(false);
      },
      error: () => {
        this.isLoading.set(false);
      }
    });
  }

  openCreateModal(): void {
    this.isEditing.set(false);
    this.userForm.reset({ role: 'Viewer' });
    this.userForm.get('password')?.setValidators([Validators.required, Validators.minLength(6)]);
    this.showModal.set(true);
  }

  openEditModal(user: User): void {
    this.isEditing.set(true);
    this.selectedUserId = user.id;
    this.userForm.patchValue({
      name: user.name,
      email: user.email,
      phoneNumber: user.phoneNumber || '',
      role: user.role
    });
    this.userForm.get('password')?.clearValidators();
    this.userForm.get('password')?.updateValueAndValidity();
    this.showModal.set(true);
  }

  closeModal(): void {
    this.showModal.set(false);
    this.userForm.reset();
    this.selectedUserId = null;
  }

  onSubmit(): void {
    if (this.userForm.invalid) {
      this.userForm.markAllAsTouched();
      return;
    }

    if (this.isEditing()) {
      this.updateUser();
    } else {
      this.createUser();
    }
  }

  createUser(): void {
    const userData: CreateUserDto = this.userForm.value;
    this.userService.create(userData).subscribe({
      next: () => {
        this.loadUsers();
        this.closeModal();
      },
      error: (error) => {
        console.error('Error creating user:', error);
      }
    });
  }

  updateUser(): void {
    if (!this.selectedUserId) return;

    const { name, phoneNumber } = this.userForm.value;
    this.userService.update(this.selectedUserId, { name, phoneNumber, avatar: undefined }).subscribe({
      next: () => {
        this.loadUsers();
        this.closeModal();
      },
      error: (error) => {
        console.error('Error updating user:', error);
      }
    });
  }

  deleteUser(id: string): void {
    if (confirm('Tem certeza que deseja excluir este usuário?')) {
      this.userService.delete(id).subscribe({
        next: () => {
          this.loadUsers();
        },
        error: (error) => {
          console.error('Error deleting user:', error);
        }
      });
    }
  }
}
