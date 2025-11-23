export interface User {
  id: string;
  name: string;
  email: string;
  role: string;
  isActive: boolean;
  phoneNumber?: string;
  avatar?: string;
  createdAt: Date;
  updatedAt?: Date;
}

export interface LoginRequest {
  email: string;
  password: string;
}

export interface LoginResponse {
  token: string;
  email: string;
  name: string;
  role: string;
  expiresAt: Date;
}

export interface CreateUserDto {
  name: string;
  email: string;
  password: string;
  role: string;
  phoneNumber?: string;
}

export interface UpdateUserDto {
  name: string;
  phoneNumber?: string;
  avatar?: string;
}
