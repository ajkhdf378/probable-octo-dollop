# Admin Panel - Sistema de Gerenciamento Administrativo

Painel administrativo moderno, seguro e escalável desenvolvido com .NET 8 e Angular 17, seguindo as melhores práticas de Clean Architecture e DDD.

## 🚀 Tecnologias

### Backend
- **.NET 8** (C#)
- **ASP.NET Core Web API**
- **Entity Framework Core 8**
- **SQL Server / PostgreSQL**
- **JWT Authentication**
- **FluentValidation**
- **BCrypt.Net** (Hash de senhas)

### Frontend
- **Angular 17** (Standalone Components)
- **TypeScript**
- **TailwindCSS**
- **RxJS**
- **Signals** (Gerenciamento de estado)

## 📁 Estrutura do Projeto

```
probable-octo-dollop/
├── backend/
│   ├── src/
│   │   ├── AdminPanel.Domain/          # Entidades, interfaces, regras de negócio
│   │   ├── AdminPanel.Application/     # DTOs, services, validações
│   │   ├── AdminPanel.Infrastructure/  # EF Core, repositórios, migrations
│   │   └── AdminPanel.API/             # Controllers, middleware, configuração
│   └── AdminPanel.sln
├── frontend/
│   ├── src/
│   │   ├── app/
│   │   │   ├── core/                   # Services, guards, interceptors, models
│   │   │   ├── features/               # Módulos funcionais (auth, users, etc.)
│   │   │   └── shared/                 # Componentes compartilhados
│   │   ├── environments/
│   │   └── styles.scss
│   ├── angular.json
│   ├── package.json
│   └── tailwind.config.js
└── README.md
```

## 🏗️ Arquitetura

### Backend - Clean Architecture + DDD

**Domain Layer (Núcleo)**
- Entidades: `User`, `Restaurant`, `Coupon`
- Value Objects e Enums
- Interfaces de repositórios
- Regras de negócio encapsuladas

**Application Layer**
- DTOs para comunicação
- Services com lógica de aplicação
- Validações com FluentValidation
- Interfaces de serviços

**Infrastructure Layer**
- Implementação de repositórios
- DbContext e configurações EF Core
- Unit of Work pattern
- Migrations

**API Layer**
- Controllers RESTful
- Autenticação JWT
- CORS configurado
- Swagger/OpenAPI

### Frontend - Modular e Reativo

- **Standalone Components** (Angular 17+)
- **Signals** para gerenciamento de estado
- **Guards** para proteção de rotas
- **Interceptors** para autenticação automática
- **Services** para comunicação com API
- **Lazy Loading** de módulos

## 🔐 Segurança

- ✅ Autenticação JWT com tokens seguros
- ✅ Hash de senhas com BCrypt
- ✅ Proteção de rotas com Guards
- ✅ Validação de dados no backend e frontend
- ✅ CORS configurado
- ✅ Soft Delete para preservação de dados
- ✅ Controle de permissões por role (Admin, Manager, Operator, Viewer)

## 📋 Funcionalidades

### Autenticação
- Login com email e senha
- Geração de tokens JWT
- Proteção de rotas autenticadas
- Logout seguro

### Gestão de Usuários
- ✅ Criar usuários com diferentes roles
- ✅ Listar usuários
- ✅ Editar perfil de usuários
- ✅ Excluir usuários (soft delete)
- ✅ Gerenciar permissões

### Gestão de Restaurantes
- Estrutura pronta para implementação CRUD completo
- Validações de horário de funcionamento
- Sistema de avaliações
- Upload de logos

### Gestão de Cupons
- Estrutura pronta para implementação CRUD completo
- Cupons de desconto percentual ou valor fixo
- Controle de validade
- Limite de uso
- Vinculação com restaurantes

### Dashboard
- Visão geral do sistema
- Estatísticas em tempo real
- Atividades recentes
- Gráficos e métricas

## 🚀 Como Executar

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Node.js 18+](https://nodejs.org/)
- [SQL Server](https://www.microsoft.com/sql-server) ou [PostgreSQL](https://www.postgresql.org/)
- [Angular CLI](https://angular.io/cli): `npm install -g @angular/cli`

### Backend

1. **Configure o banco de dados**

Edite o arquivo [backend/src/AdminPanel.API/appsettings.json](backend/src/AdminPanel.API/appsettings.json):

```json
{
  "DatabaseProvider": "SqlServer",  // ou "PostgreSQL"
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=AdminPanelDb;Trusted_Connection=True;TrustServerCertificate=True"
  },
  "Jwt": {
    "SecretKey": "ALTERE-ESTA-CHAVE-PARA-PRODUCAO-MIN-32-CARACTERES",
    "Issuer": "AdminPanelAPI",
    "Audience": "AdminPanelClient",
    "ExpirationHours": "8"
  }
}
```

2. **Instale as dependências e crie o banco**

```bash
cd backend

# Restaurar pacotes
dotnet restore

# Criar migration inicial
dotnet ef migrations add InitialCreate --project src/AdminPanel.Infrastructure --startup-project src/AdminPanel.API

# Aplicar migration no banco
dotnet ef database update --project src/AdminPanel.Infrastructure --startup-project src/AdminPanel.API
```

3. **Execute a API**

```bash
cd src/AdminPanel.API
dotnet run
```

A API estará disponível em:
- HTTP: http://localhost:5000
- HTTPS: https://localhost:5001
- Swagger: http://localhost:5000/swagger

### Frontend

1. **Instale as dependências**

```bash
cd frontend
npm install
```

2. **Execute o projeto**

```bash
npm start
# ou
ng serve
```

O frontend estará disponível em: http://localhost:4200

### Credenciais Padrão

Após rodar as migrations, você precisará criar um usuário admin manualmente no banco ou via Swagger:

**Endpoint:** `POST /api/users`

```json
{
  "name": "Administrador",
  "email": "admin@example.com",
  "password": "admin123",
  "role": "Admin",
  "phoneNumber": "+55 11 99999-9999"
}
```

Depois use estas credenciais no login:
- **Email:** admin@example.com
- **Senha:** admin123

## 🎨 Interface

### Tela de Login
- Design moderno com gradiente
- Validação de formulário em tempo real
- Feedback visual de erros
- Loading state durante autenticação

### Dashboard Administrativo
- **Sidebar fixa** com navegação
- Menu responsivo (colapsa em mobile)
- **Cards de estatísticas** com ícones
- Gráficos de progresso
- Atividades recentes

### CRUD de Usuários
- Tabela responsiva com dados completos
- Modal para criação/edição
- Confirmação antes de excluir
- Badges de status e roles
- Avatares com iniciais

## 🔧 Configurações Adicionais

### PostgreSQL

Para usar PostgreSQL, altere em [appsettings.json](backend/src/AdminPanel.API/appsettings.json):

```json
{
  "DatabaseProvider": "PostgreSQL",
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=AdminPanelDb;Username=postgres;Password=sua_senha"
  }
}
```

### Ambiente de Produção

1. **Backend:**
   - Altere `Jwt:SecretKey` para uma chave forte (mínimo 32 caracteres)
   - Configure CORS para permitir apenas domínios confiáveis
   - Use variáveis de ambiente para secrets
   - Configure HTTPS obrigatório

2. **Frontend:**
   - Atualize [environment.ts](frontend/src/environments/environment.ts) com URL de produção
   - Execute: `ng build --configuration production`

## 📦 Próximas Implementações

- [ ] Implementar CRUD completo de Restaurantes
- [ ] Implementar CRUD completo de Cupons
- [ ] Adicionar upload de imagens
- [ ] Implementar relatórios e analytics
- [ ] Adicionar testes unitários e de integração
- [ ] Implementar paginação nas listagens
- [ ] Adicionar filtros e busca avançada
- [ ] Implementar logs de auditoria
- [ ] Adicionar notificações em tempo real
- [ ] Dashboard com gráficos reais (Chart.js/ApexCharts)

## 🤝 Contribuindo

1. Fork o projeto
2. Crie uma branch para sua feature (`git checkout -b feature/MinhaFeature`)
3. Commit suas mudanças (`git commit -m 'Adiciona MinhaFeature'`)
4. Push para a branch (`git push origin feature/MinhaFeature`)
5. Abra um Pull Request

## 📝 Licença

Este projeto está sob a licença MIT. Veja o arquivo LICENSE para mais detalhes.

## 👨‍💻 Desenvolvido com

- ❤️ Paixão por código limpo
- ☕ Muito café
- 🎯 Foco em qualidade e performance
- 🚀 Vontade de aprender e evoluir

---

**Dúvidas?** Abra uma issue no repositório!
