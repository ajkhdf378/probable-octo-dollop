# Scripts Úteis para Desenvolvimento

## Backend (.NET)

### Comandos do EF Core

```bash
# Navegar para a pasta do backend
cd backend

# Criar uma nova migration
dotnet ef migrations add NomeDaMigration \
  --project src/AdminPanel.Infrastructure \
  --startup-project src/AdminPanel.API

# Aplicar migrations no banco de dados
dotnet ef database update \
  --project src/AdminPanel.Infrastructure \
  --startup-project src/AdminPanel.API

# Reverter para uma migration específica
dotnet ef database update NomeDaMigrationAnterior \
  --project src/AdminPanel.Infrastructure \
  --startup-project src/AdminPanel.API

# Remover a última migration (se ainda não foi aplicada)
dotnet ef migrations remove \
  --project src/AdminPanel.Infrastructure \
  --startup-project src/AdminPanel.API

# Gerar script SQL da migration
dotnet ef migrations script \
  --project src/AdminPanel.Infrastructure \
  --startup-project src/AdminPanel.API \
  --output migration.sql

# Deletar o banco de dados
dotnet ef database drop \
  --project src/AdminPanel.Infrastructure \
  --startup-project src/AdminPanel.API \
  --force

# Listar migrations
dotnet ef migrations list \
  --project src/AdminPanel.Infrastructure \
  --startup-project src/AdminPanel.API
```

### Build e Run

```bash
# Restaurar pacotes NuGet
dotnet restore

# Build da solution
dotnet build

# Build de um projeto específico
dotnet build src/AdminPanel.API

# Executar a API
dotnet run --project src/AdminPanel.API

# Executar em watch mode (recarrega ao salvar)
dotnet watch run --project src/AdminPanel.API

# Build para produção
dotnet publish src/AdminPanel.API -c Release -o ./publish
```

### Testes

```bash
# Executar todos os testes
dotnet test

# Executar testes com coverage
dotnet test /p:CollectCoverage=true

# Executar testes de um projeto específico
dotnet test tests/AdminPanel.Tests
```

### Adicionar Pacotes

```bash
# Adicionar pacote a um projeto
dotnet add src/AdminPanel.Application package NomeDoPacote

# Adicionar versão específica
dotnet add src/AdminPanel.Application package NomeDoPacote --version 1.0.0

# Remover pacote
dotnet remove src/AdminPanel.Application package NomeDoPacote

# Listar pacotes instalados
dotnet list package
```

## Frontend (Angular)

### Angular CLI

```bash
# Navegar para a pasta do frontend
cd frontend

# Instalar dependências
npm install

# Executar em modo desenvolvimento
npm start
# ou
ng serve

# Executar em porta específica
ng serve --port 4300

# Executar e abrir no navegador
ng serve --open

# Build para produção
ng build --configuration production

# Build com source maps (para debug)
ng build --source-map
```

### Gerar Componentes

```bash
# Gerar componente standalone
ng generate component features/nome-do-componente --standalone

# Gerar componente com routing
ng generate component features/nome --standalone --routing

# Gerar service
ng generate service core/services/nome-do-service

# Gerar guard
ng generate guard core/guards/nome-do-guard

# Gerar interceptor
ng generate interceptor core/interceptors/nome

# Gerar interface
ng generate interface core/models/nome-do-model

# Gerar pipe
ng generate pipe shared/pipes/nome-do-pipe
```

### NPM Scripts Úteis

```bash
# Limpar node_modules e reinstalar
rm -rf node_modules package-lock.json
npm install

# Atualizar dependências
npm update

# Verificar pacotes desatualizados
npm outdated

# Instalar pacote
npm install nome-do-pacote

# Instalar pacote de desenvolvimento
npm install --save-dev nome-do-pacote

# Desinstalar pacote
npm uninstall nome-do-pacote
```

## Git

### Workflow Básico

```bash
# Inicializar repositório
git init

# Adicionar arquivos
git add .

# Commit
git commit -m "feat: adiciona funcionalidade X"

# Push
git push origin main

# Pull
git pull origin main

# Criar branch
git checkout -b feature/nova-funcionalidade

# Mudar de branch
git checkout main

# Merge
git merge feature/nova-funcionalidade

# Ver status
git status

# Ver histórico
git log --oneline --graph --all
```

### Conventional Commits

```bash
# Feature
git commit -m "feat: adiciona CRUD de restaurantes"

# Bug fix
git commit -m "fix: corrige validação de email"

# Documentação
git commit -m "docs: atualiza README com instruções"

# Estilo
git commit -m "style: formata código com prettier"

# Refatoração
git commit -m "refactor: reorganiza estrutura de pastas"

# Performance
git commit -m "perf: otimiza query de listagem"

# Testes
git commit -m "test: adiciona testes para UserService"

# Build
git commit -m "build: atualiza dependências"

# CI
git commit -m "ci: configura GitHub Actions"

# Chore
git commit -m "chore: atualiza .gitignore"
```

## Docker (Opcional)

### Backend

```bash
# Build da imagem
docker build -t admin-panel-api ./backend

# Executar container
docker run -p 5000:80 admin-panel-api

# Docker Compose (criar arquivo docker-compose.yml)
docker-compose up -d

# Parar containers
docker-compose down
```

### Frontend

```bash
# Build da imagem
docker build -t admin-panel-frontend ./frontend

# Executar container
docker run -p 4200:80 admin-panel-frontend
```

## Banco de Dados

### SQL Server via Docker

```bash
# Baixar e executar SQL Server
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourStrong@Password" \
  -p 1433:1433 --name sqlserver \
  -d mcr.microsoft.com/mssql/server:2022-latest

# Connection String
Server=localhost,1433;Database=AdminPanelDb;User Id=sa;Password=YourStrong@Password;TrustServerCertificate=True
```

### PostgreSQL via Docker

```bash
# Baixar e executar PostgreSQL
docker run --name postgres \
  -e POSTGRES_PASSWORD=postgres \
  -e POSTGRES_DB=AdminPanelDb \
  -p 5432:5432 \
  -d postgres:16

# Connection String
Host=localhost;Database=AdminPanelDb;Username=postgres;Password=postgres
```

## Linting e Formatação

### Backend (dotnet format)

```bash
# Instalar dotnet format (se necessário)
dotnet tool install -g dotnet-format

# Formatar código
dotnet format

# Verificar formatação sem modificar
dotnet format --verify-no-changes
```

### Frontend (ESLint + Prettier)

```bash
# Instalar ESLint e Prettier
npm install --save-dev eslint prettier eslint-config-prettier

# Executar linter
npm run lint

# Corrigir automaticamente
npm run lint -- --fix

# Formatar com Prettier
npx prettier --write "src/**/*.{ts,html,scss}"
```

## Debugging

### Backend

```bash
# Executar com debug
dotnet run --project src/AdminPanel.API --launch-profile https

# Attach debugger no VS Code (F5)
# Ou usar Visual Studio
```

### Frontend

```bash
# Abrir DevTools do Chrome
F12

# Executar em modo debug
ng serve --source-map

# Inspecionar build
ng build --stats-json
npx webpack-bundle-analyzer dist/admin-panel/stats.json
```

## Monitoramento e Logs

### Ver logs da API

```bash
# Executar com logs detalhados
dotnet run --project src/AdminPanel.API --verbosity detailed

# Filtrar logs
dotnet run | grep "ERROR"
```

### Ver logs do Angular

```bash
# Abrir console do navegador
# Ou usar ng serve com verbose
ng serve --verbose
```

## Backup e Restore

### Backup do Banco SQL Server

```bash
# Via SQL Server Management Studio (SSMS)
# Ou via comando
sqlcmd -S localhost -U sa -P YourPassword \
  -Q "BACKUP DATABASE AdminPanelDb TO DISK='C:\backup\AdminPanelDb.bak'"
```

### Restore

```bash
sqlcmd -S localhost -U sa -P YourPassword \
  -Q "RESTORE DATABASE AdminPanelDb FROM DISK='C:\backup\AdminPanelDb.bak'"
```

## Scripts PowerShell (Windows)

### Executar Backend e Frontend

```powershell
# run-all.ps1
Start-Process powershell -ArgumentList "-NoExit", "-Command", "cd backend/src/AdminPanel.API; dotnet run"
Start-Process powershell -ArgumentList "-NoExit", "-Command", "cd frontend; npm start"
```

### Limpar e Rebuild

```powershell
# clean-rebuild.ps1
# Backend
cd backend
dotnet clean
dotnet restore
dotnet build

# Frontend
cd ../frontend
Remove-Item -Recurse -Force node_modules, .angular
npm install
```

## Scripts Bash (Linux/Mac)

### Executar Backend e Frontend

```bash
#!/bin/bash
# run-all.sh

# Abrir terminal para o backend
gnome-terminal -- bash -c "cd backend/src/AdminPanel.API && dotnet run; exec bash"

# Abrir terminal para o frontend
gnome-terminal -- bash -c "cd frontend && npm start; exec bash"
```

### Limpar e Rebuild

```bash
#!/bin/bash
# clean-rebuild.sh

# Backend
cd backend
dotnet clean
dotnet restore
dotnet build

# Frontend
cd ../frontend
rm -rf node_modules .angular
npm install
```

---

**Dica:** Salve os scripts em arquivos executáveis para facilitar o desenvolvimento diário!
