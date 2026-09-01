# 🐾 PetGuardian — Plataforma de Cuidado Colaborativo e Saúde Animal

> **Advanced Business Development with .NET** — FIAP (2º Ano ADS / 2TDSPG — Challenge 2026 - 2º Semestre)  
> API RESTful corporativa desenvolvida em **.NET 10** fundamentada em **Clean Architecture (DDD)**, princípios **SOLID**, **DRY** e **Clean Code**, camadas completas de **Monitoramento e Observabilidade** (Health Checks com `HealthCheckResponseWriter`, Logging Estruturado Serilog com `X-Correlation-ID`, OpenTelemetry Distributed Tracing e Métricas Prometheus), segurança de senhas com **BCrypt + Salt criptográfico** e suíte de **65 Testes Automatizados (Padrão AAA)** com xUnit, Moq e WebApplicationFactory.

---

## 🛠️ Tecnologias & Badges

![.NET 10](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet&logoColor=white&style=for-the-badge)
![C#](https://img.shields.io/badge/C%23-14-239120?logo=csharp&logoColor=white&style=for-the-badge)
![Entity Framework](https://img.shields.io/badge/EF%20Core-10.0-512BD4?logo=nuget&logoColor=white&style=for-the-badge)
![Oracle Database](https://img.shields.io/badge/Oracle-19c%20%2F%2021c-F80000?logo=oracle&logoColor=white&style=for-the-badge)
![Serilog](https://img.shields.io/badge/Serilog-Structured%20Logs-000000?logo=serilog&logoColor=white&style=for-the-badge)
![OpenTelemetry](https://img.shields.io/badge/OpenTelemetry-Tracing%20%26%20Metrics-4A154B?logo=opentelemetry&logoColor=white&style=for-the-badge)
![BCrypt](https://img.shields.io/badge/BCrypt-Security%20%26%20Salt-green?style=for-the-badge)
![xUnit](https://img.shields.io/badge/xUnit-65%20Tests%20Passing-brightgreen?style=for-the-badge)
![Docker](https://img.shields.io/badge/Docker-Compose-2496ED?logo=docker&logoColor=white&style=for-the-badge)

---

## 👥 Integrantes do Grupo (2TDSPG)

| Nome | RM | GitHub | LinkedIn |
| :--- | :---: | :--- | :--- |
| **Enzo Okuizumi** | **561432** | [EnzoOkuizumiFiap](https://github.com/EnzoOkuizumiFiap) | [Enzo Okuizumi](https://www.linkedin.com/in/enzo-okuizumi-b60292256/) |
| **Gustavo Okada** | **563428** | [Gdev3356](https://github.com/Gdev3356) | [Gustavo Okada](https://www.linkedin.com/in/gustavo-okada-53a3b8359/) |
| **Lucas Barros Gouveia** | **566422** | [LuzBGouveia](https://github.com/LuzBGouveia) | [Lucas Barros Gouveia](https://www.linkedin.com/in/lucas-barros-gouveia-09b147355/) |
| **Luna de Carvalho Guimarães** | **562290** | [lunaguima](https://github.com/lunaguima) | [Luna M. Guimarães](https://www.linkedin.com/in/luna-m-guimar%C3%A3es-1850ab173/) |
| **Milton Marcelino** | **564836** | [MiltonMarcelino](https://github.com/MiltonMarcelino) | [Milton Marcelino](http://linkedin.com/in/milton-marcelino-250298142) |

---

## 💡 Sobre o Projeto & Funcionalidades

O **PetGuardian** foi concebido para resolver o problema da descentralização do cuidado diário de animais domésticos quando múltiplos cuidadores, famílias ou profissionais estão envolvidos. A plataforma centraliza rotinas, registra o histórico de saúde, monitora tarefas e incentiva a realização de cuidados através de um sistema gamificado centrado no animal.

### 🌟 Destaques Arquiteturais & Negócio
1. **Rede de Cuidado Colaborativo (`UsuarioPet`):** Relação N:N entre Cuidadores (`Usuario`) e `Pet`. Suporta definição de **Responsável Principal** (`ResponPrinc`), envio de convites para novos co-cuidadores (por ID ou E-mail) e salvaguarda do animal (impede desvinculação sem um tutor ativo).
2. **Ciclo Completo de Tarefas (`Tarefa`):** Agendamento e execução de cuidados com pontuação gamificada (`PontosTarefa`). Conclusão de tarefas (`POST /api/tarefa/{id}/concluir`) audita a ação e gera automaticamente registro no histórico do pet (`TAREFA_CONCLUIDA`).
3. **Trilhas e Módulos de Aprendizado (`Trilha`, `Modulo`, `Aula`):** Sistema de capacitação dos tutores com aulas interativas, pontuação e gamificação.
4. **Histórico Consolidado do Pet (`Historico` & `GetHistorico`):** Linha do tempo unificada de eventos clínicos, marcos de saúde, vacinas e tarefas realizadas em ordem cronológica decrescente.
5. **Segurança de Senhas no Domínio (`HashHelper` + Salt):** Criptografia com BCrypt e Salt criptográfico exclusivo (`Guid.NewGuid().ToString("N")`) por usuário, prevenindo persistência de senhas em texto puro.
6. **Resolução Inteligente de Endereço via ViaCEP (`IViaCepService`):** Cadastro automatizado de endereços (`Cep`, `Numero`) resolvendo de forma transparente `Bairro`, `Cidade` e `Estado` com reaproveitamento de entidades no banco.
7. **Auditoria Completa de Atualização (CRUD com PUT):** Todos os 16 agregados e entidades implementam operações de atualização com validação de invariantes no domínio (`Atualizar(...)`) e endpoints `[HttpPut]` padronizados.
8. **Eliminação de N+1 Queries & Otimização DRY:** Consultas do EF Core executadas com expressões semânticas (`Find`, `FirstOrDefault`) e `.AsNoTracking()`, eliminando varreduras de tabela inteira em memória.

---

## 🏛️ Arquitetura da Solução (Clean Architecture & SOLID)

A solução segue estritamente a separação em camadas do **Domain-Driven Design (DDD)** e princípios **SOLID / DRY / Clean Code**:

```text
PetGuardian/
├── PetGuardian.Domain/             # Camada de Domínio: POCOs puros, Entidades, Enums e Invariantes de Negócio
│   ├── Common/                     # BaseEntity (Id Guid)
│   ├── Entities/                   # Pet, Usuario, Tarefa, Trilha, Modulo, Aula, Historico, Endereco, Bairro, Cidade, Estado, etc.
│   ├── Enums/                      # PortePet, SexoPet, RoleUsuario, StatusTarefa
│   ├── Exceptions/                 # DomainException (regras de validação do domínio)
│   └── Helpers/                    # HashHelper (BCrypt + Salt criptográfico)
│
├── PetGuardian.Application/        # Camada de Aplicação: Casos de Uso, Orquestração, DTOs e Interfaces
│   ├── DTOs/                       # Requests, UpdateRequests e Responses tipados (Records imutáveis)
│   ├── Repositories/               # Contratos IRepository<T> e interfaces especializadas
│   └── Services/                   # Interfaces e Implementações de Serviços (PetService, TarefaService, UsuarioPetService, etc.)
│
├── PetGuardian.Infrastructure/     # Camada de Infraestrutura: EF Core, Mapeamentos Oracle e Repositórios Concretos
│   └── Persistence/                # PetGuardianContext, Repositórios Especializados e Mapeamentos Fluent API
│
├── PetGuardian.API/                # Camada de Apresentação & Hosting: Controladores REST, Middlewares e Observabilidade
│   ├── Controllers/                # 16 Controllers RESTful com suporte a CRUD completo (GET, POST, PUT, DELETE)
│   ├── Exceptions/                 # GlobalExceptionHandler (RFC 7807 ProblemDetails + X-Correlation-ID)
│   ├── Extensions/                 # ServiceCollectionExtensions e ObservabilityExtensions
│   ├── Health/                     # HealthCheckResponseWriter (Serialização JSON estruturada)
│   ├── HealthChecks/               # OracleDbHealthCheck e ViaCepHealthCheck
│   └── Middleware/                 # CorrelationIdMiddleware e RequestMetricsMiddleware
│
├── PetGuardian.UnitTests/          # Suíte de Testes Unitários xUnit (Domínio + Aplicação com Moq, Padrão AAA)
│   ├── Domain/                     # Testes de invariantes, mutações e hashing de senha
│   ├── Application/                # Testes de regras de negócio com mocks Moq (Times.Once / Times.Never)
│   └── Fixtures/                   # Fixtures compartilhadas e factories de dados
│
└── PetGuardian.IntegrationTests/   # Suíte de Testes de Integração com WebApplicationFactory e InMemory DB
    ├── Endpoints/                  # Testes de requisição HTTP ponta a ponta (CRUD, PUT, Validação 400, 404, 201)
    └── Fixtures/                   # CustomWebApplicationFactory e IntegrationTestCollection
```

---

## 📊 Monitoramento e Observabilidade Corporativa

A aplicação implementa os três pilares de observabilidade:

### 1. Health Checks Estruturados (`HealthCheckResponseWriter`)
A API expõe endpoints estruturados para monitoramento de liveness e readiness de orquestradores (Docker, Kubernetes, Azure App Service / ACI):

| Endpoint | Propósito | Componentes Verificados | Status Esperado |
| :--- | :--- | :--- | :---: |
| **`/health`** | Visão geral da saúde da aplicação | API + Oracle Database + ViaCEP | `200 Healthy` |
| **`/health/ready`** | Prontidão para receber tráfego | Conectividade com Banco Oracle (`CanConnectAsync`) e API externa ViaCEP | `200 Healthy` |
| **`/health/live`** | Liveness probe básica | Processo da API ativo | `200 Healthy` |

**Exemplo de Resposta Estruturada em JSON (`GET /health`):**
```json
{
  "status": "Healthy",
  "duration": "00:00:00.0421500",
  "checks": [
    {
      "name": "oracle-database",
      "status": "Healthy",
      "description": "Conexão com o Oracle estabelecida com sucesso.",
      "duration": "00:00:00.0284000",
      "error": null
    },
    {
      "name": "external-service-viacep",
      "status": "Healthy",
      "description": "Serviço externo ViaCEP operacional.",
      "duration": "00:00:00.0137500",
      "error": null
    }
  ]
}
```

### 2. Logging Estruturado com Serilog
- **Níveis de Log:** `Information`, `Warning` e `Error` configurados via `appsettings.json`.
- **Saídas (Sinks):** 
  - **Console:** Formatação rica para ambiente de desenvolvimento e containers.
  - **Arquivo:** Gravação com rotação diária em `logs/petguardian-.log` (retenção de 14 dias).
- **Correlation ID:** Middleware `CorrelationIdMiddleware` captura ou gera o identificador `X-Correlation-ID`, injeta no `LogContext` e devolve no header de resposta HTTP para rastreabilidade de ponta a ponta.

### 3. Distributed Tracing & Métricas com OpenTelemetry
- **Distributed Tracing:** Rastreamento distribuído com instrumentação automática para `ASP.NET Core` e `HttpClient`.
- **Métricas de Performance (`RequestMetricsMiddleware`):**
  - `petguardian.http.request.duration`: Histograma do tempo de resposta (ms) categorizado por rota e status code.
  - `petguardian.http.request.total`: Contador de volume total de requisições.
  - `petguardian.http.request.errors`: Contador de requisições com status `>= 500`.

---

## 🧪 Suíte de Testes Automatizados (65 Testes / Padrão AAA)

A solução conta com **65 testes automatizados** distribuídos entre as camadas de Domínio, Aplicação e Apresentação, seguindo rigorosamente o padrão **AAA (Arrange, Act, Assert)** e convenção de nomenclatura `MetodoTestado_Cenario_ResultadoEsperado`.

### Como Executar os Testes

Para executar toda a suíte de testes (Unitários e de Integração) a partir da raiz da solução:

```powershell
# Executar todos os 65 testes da solução com relatório detalhado
dotnet test PetGuardian.sln --logger "console;verbosity=normal"
```

Para executar separadamente por projeto:

```powershell
# Executar os 53 testes unitários (Domínio + Aplicação com Moq)
dotnet test PetGuardian.UnitTests\PetGuardian.UnitTests.csproj

# Executar os 12 testes de integração (WebApplicationFactory)
dotnet test PetGuardian.IntegrationTests\PetGuardian.IntegrationTests.csproj
```

### Resumo da Execução:
```
Passed!  - Failed: 0, Passed: 53, Skipped: 0, Total: 53 - PetGuardian.UnitTests.dll (net10.0)
Passed!  - Failed: 0, Passed: 12, Skipped: 0, Total: 12 - PetGuardian.IntegrationTests.dll (net10.0)
Total Geral: 65 Testes Passando (100% de sucesso)
```

---

## 🚀 Como Executar a Aplicação Localmente

### Opção A: Execução via Docker Compose (Recomendado)

1. Navegue até a pasta da solução:
   ```bash
   cd Advanced-Business-Development-with-Dot-Net/PetGuardian
   ```
2. Suba o container da aplicação e do banco Oracle:
   ```bash
   docker compose up --build -d
   ```
3. Acesse a documentação interativa Swagger UI:
   * **URL:** `http://localhost:8080/`

---

### Opção B: Execução Local via .NET CLI

1. **Configuração de Secrets (Banco Oracle FIAP):**
   ```powershell
   dotnet user-secrets set "ConnectionStrings:PetGuardianOracle" "User Id=RMxxxxxx;Password=xxxxxx;Data Source=oracle.fiap.com.br:1521/orcl;" --project .\PetGuardian.API
   ```
2. **Executar a API:**
   ```powershell
   dotnet run --project .\PetGuardian.API
   ```
   * Swagger UI disponível diretamente na raiz: `http://localhost:5289/`

---

## 📋 Catálogo Completo de Endpoints REST (CRUD / OpenAPI)

Todas as operações de atualização (`PUT`) foram devidamente implementadas e validadas:

### 🐾 Pets & Raças
| Método | Rota | Descrição |
| :--- | :--- | :--- |
| `GET` | `/api/pet` | Lista todos os pets cadastrados |
| `GET` | `/api/pet/{id}` | Busca pet por ID |
| `GET` | `/api/pet/by-raca/{racaId}` | Busca pets por raça |
| `GET` | `/api/pet/{id}/historico` | Retorna linha do tempo consolidada do pet |
| `POST` | `/api/pet` | Cadastra um novo pet |
| `PUT` | `/api/pet/{id}` | **Atualiza dados editáveis do pet** |
| `DELETE` | `/api/pet/{id}` | Remove um pet |
| `GET` | `/api/raca` | Lista todas as raças |
| `GET` | `/api/raca/{id}` | Busca raça por ID |
| `POST` | `/api/raca` | Cadastra uma nova raça |
| `PUT` | `/api/raca/{id}` | **Atualiza nome da raça** |
| `DELETE` | `/api/raca/{id}` | Remove uma raça |

### 👥 Usuários, Telefones e Endereços
| Método | Rota | Descrição |
| :--- | :--- | :--- |
| `GET` | `/api/usuario` | Lista todos os usuários |
| `GET` | `/api/usuario/{id}` | Busca usuário por ID |
| `GET` | `/api/usuario/by-email` | Busca usuário por e-mail |
| `GET` | `/api/usuario/{id}/score` | Retorna o score gamificado do usuário |
| `POST` | `/api/usuario` | Cadastra um novo usuário com senha criptografada |
| `PUT` | `/api/usuario/{id}` | **Atualiza dados do usuário (nome, e-mail, senha com novo hash, role)** |
| `DELETE` | `/api/usuario/{id}` | Remove um usuário |
| `GET` | `/api/telefone` | Lista telefones |
| `POST` | `/api/telefone` | Cadastra telefone |
| `PUT` | `/api/telefone/{id}` | **Atualiza telefone** |
| `DELETE` | `/api/telefone/{id}` | Remove telefone |
| `GET` | `/api/endereco` | Lista endereços |
| `POST` | `/api/endereco` | Cadastra endereço com resolução automática ViaCEP |
| `PUT` | `/api/endereco/{id}` | **Atualiza endereço com re-resolução de CEP** |
| `DELETE` | `/api/endereco/{id}` | Remove endereço |
| `GET` | `/api/bairro` | Lista bairros / busca por ID |
| `PUT` | `/api/bairro/{id}` | **Atualiza bairro** |
| `GET` | `/api/cidade` | Lista cidades / busca por ID |
| `PUT` | `/api/cidade/{id}` | **Atualiza cidade** |
| `GET` | `/api/estado` | Lista estados / busca por ID |
| `PUT` | `/api/estado/{id}` | **Atualiza estado** |

### 🤝 Rede de Cuidado Colaborativo (`UsuarioPet`)
| Método | Rota | Descrição |
| :--- | :--- | :--- |
| `GET` | `/api/usuariopet` | Lista todos os vínculos de cuidadores |
| `GET` | `/api/usuariopet/by-usuario/{usuarioId}` | Lista pets vinculados a um tutor |
| `GET` | `/api/usuariopet/by-pet/{petId}` | Lista cuidadores vinculados a um pet |
| `GET` | `/api/usuariopet/rede-cuidado/{usuarioId}` | Retorna a árvore completa de cuidado colaborativo otimizada |
| `POST` | `/api/usuariopet` | Vincula tutor ao pet |
| `POST` | `/api/usuariopet/invite/by-usuario` | Convite de co-cuidador por ID (exclusivo do tutor principal) |
| `POST` | `/api/usuariopet/invite/by-email` | Convite de co-cuidador por e-mail |
| `PUT` | `/api/usuariopet/{usuarioId}/{petId}` | **Atualiza/alterna responsabilidade principal do pet** |
| `DELETE` | `/api/usuariopet/{usuarioId}/{petId}` | Desvincula cuidador (com salvaguarda do último tutor) |

### 🎮 Tarefas, Gamificação e Linha do Tempo
| Método | Rota | Descrição |
| :--- | :--- | :--- |
| `GET` | `/api/tarefa` | Lista tarefas / busca por ID, pet, usuário ou status |
| `POST` | `/api/tarefa` | Cria nova tarefa de cuidado para o pet |
| `PUT` | `/api/tarefa/{id}` | **Atualiza dados de uma tarefa não concluída** |
| `POST` | `/api/tarefa/{id}/concluir` | Conclui tarefa, computa pontuação e grava histórico |
| `DELETE` | `/api/tarefa/{id}` | Remove uma tarefa |
| `GET` | `/api/trilha` | Lista trilhas / busca por ID ou pet |
| `POST` | `/api/trilha` | Cadastra nova trilha de aprendizado |
| `PUT` | `/api/trilha/{id}` | **Atualiza trilha** |
| `GET` | `/api/modulo` | Lista módulos de trilhas |
| `POST` | `/api/modulo` | Cadastra novo módulo |
| `PUT` | `/api/modulo/{id}` | **Atualiza módulo** |
| `GET` | `/api/aula` | Lista aulas |
| `POST` | `/api/aula` | Cadastra aula |
| `PUT` | `/api/aula/{id}` | **Atualiza aula** |
| `GET` | `/api/historico` | Lista registros históricos |
| `POST` | `/api/historico` | Registra novo marco histórico |
| `PUT` | `/api/historico/{id}` | **Atualiza registro histórico** |
