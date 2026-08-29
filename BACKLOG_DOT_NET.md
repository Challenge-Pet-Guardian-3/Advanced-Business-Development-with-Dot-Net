# 📋 Backlog Master Azure Boards — Sprint 3: .NET & Observabilidade

> **Projeto Integrado:** PetGuardian / Clyvo Care (Challenge FIAP 2026 - 2º Ano ADS / 2TDSPG)  
> **Disciplina:** Advanced Business Development with .NET (FIAP — 2TDSPG)  
> **Epic Principal:** `[EPIC] Sprint 3 - .NET & Observabilidade: Plataforma .NET de Cuidado Animal Pet-Centric, Observabilidade e Testes AAA`  
> **Start Date:** `2026-08-24`  
> **Target Date:** `2026-08-29`  
> **Padrão:** Azure Boards (Scrum Process: Epic ➔ Feature ➔ PBI ➔ Task)  
> **Diretrizes Estratégicas:** 1º Refatoração CRUD (PUT) ➔ 2º Observabilidade Corporativa (Health Checks, Serilog e OpenTelemetry) ➔ 3º Suíte de Testes Automatizados no Padrão AAA (xUnit, Moq e WebApplicationFactory) ➔ 4º Documentação Técnica & README.

---

## 🎯 1. Matriz de Requisitos & Critérios de Avaliação Oficiais (Páginas 07 e 08)

| Componente / Módulo | Pontuação Oficial | Itens Obrigatórios do Edital (Páginas 07 e 08) & Mentoria Clyvo | Status no Backlog |
| :--- | :---: | :--- | :--- |
| **1ª AÇÃO: Refatoração CRUD (PUT)** | *Base Técnica & DevOps* | • Implementação de verbos HTTP `PUT` em `Pet` (com `ScoreBemEstar`, `PesoAtual`), `Usuario`, `Tarefa`, `Atendimento` e `Clinica` (24h/emergência) com métodos de negócio encapsulados.<br>• Viabiliza os testes de integração e a demonstração de Update exigida na disciplina de DevOps. | **[FEATURE 01] (10 SP)** |
| **1. Monitoramento e Observabilidade** | **40 pts** | • **Health Checks (15 pts):** `/health`, `/health/ready` (Oracle DB) e `/health/live` via `Microsoft.Extensions.Diagnostics.HealthChecks`.<br>• **Logging Estruturado (10 pts):** Serilog (Info, Warning, Error), saída Console/Arquivo com rotação diária e Correlation ID (`X-Correlation-ID`).<br>• **Tracing e Métricas (15 pts):** OpenTelemetry (Distributed Tracing entre camadas e métricas de latência/erros). | **[FEATURE 02] (15 SP)** |
| **2. Testes Automatizados (Padrão AAA)** | **50 pts** | • **Testes Unitários (20 pts):** xUnit no padrão Arrange, Act, Assert com `Moq` para Domínio e Serviços de Aplicação.<br>• **Testes de Integração (15 pts):** `WebApplicationFactory` para homologação de endpoints HTTP reais, status codes (200, 201, 204, 400, 404) e tratamento global de erros.<br>• **Cobertura & Organização (15 pts):** Projetos segregados (`UnitTests`, `IntegrationTests`), nomenclatura padronizada e Fixtures de contexto compartilhado. | **[FEATURE 03] (18 SP)** |
| **3. Atualização do README.md** | **10 pts** | • Guia completo dos endpoints de Health Check e como monitorar a API.<br>• Instruções claras de execução dos testes (`dotnet test`).<br>• Descrição arquitetural das novas funcionalidades. | **[FEATURE 04] (2 SP)** |
| **TOTAL CONSOLIDADO** | **100 pts Oficiais** | **Foco Estrito na Sprint 3** *(Requisitos de Sprint 4 como MongoDB, HATEOAS, Paginação e JWT Identity mantidos para a próxima entrega).* | **45 Story Points** |

---

## 🌳 2. Estrutura Hierárquica no Azure Boards

```text
[EPIC] Sprint 3 - .NET & Observabilidade: Plataforma .NET de Cuidado Animal Pet-Centric, Observabilidade e Testes AAA
│
├── 🏆 [FEATURE 01] Refatoração e Implementação Completa do CRUD (Operações de Update / PUT)
│   ├── 📄 [PBI-01] Implementação de Atualização (PUT) Pet-Centric para Pet e Usuário (1 pt)
│   │   ├── 🔹 Task 1.1: Atualização dos Modelos de Domínio e Invariantes (Pet & Usuario) (2.0h)
│   │   ├── 🔹 Task 1.2: Criação dos DTOs de Update e Mapeamentos (1.5h)
│   │   ├── 🔹 Task 1.3: Implementação dos Métodos de Update nos Services e Repositórios (2.0h)
│   │   └── 🔹 Task 1.4: Exposição dos Endpoints PUT nos Controllers (1.5h)
│   └── 📄 [PBI-02] Implementação de Atualização (PUT) para Atendimento, Tarefa, Clínicas 24h e Cadastros (2 pts)
│       ├── 🔹 Task 2.1: Criação dos DTOs de Update para Atendimento, Tarefa, Veterinário e Clínica (2.0h)
│       ├── 🔹 Task 2.2: Implementação dos Métodos de Atualização nas Entidades e Services (3.0h)
│       └── 🔹 Task 2.3: Adição dos Endpoints PUT nos Controllers Correspondentes (2.0h)
│
├── 🏆 [FEATURE 02] Monitoramento, Observabilidade e Diagnóstico da Aplicação
│   ├── 📄 [PBI-03] Implementação de Health Checks Corporativos (API & Oracle Database) (1 pt)
│   │   ├── 🔹 Task 3.1: Instalação de Pacotes NuGet de Health Checks (1.0h)
│   │   ├── 🔹 Task 3.2: Implementação de Health Check para Oracle DB (2.0h)
│   │   ├── 🔹 Task 3.3: Configuração dos Endpoints e Formatador JSON no Program.cs (2.0h)
│   │   └── 🔹 Task 3.4: Teste de Validação dos Health Checks em Sucesso e Falha (1.0h)
│   ├── 📄 [PBI-04] Logging Estruturado com Serilog, Níveis de Log e Correlation ID (1 pt)
│   │   ├── 🔹 Task 4.1: Instalação e Configuração dos Pacotes do Serilog (1.5h)
│   │   ├── 🔹 Task 4.2: Implementação do Middleware de Correlação (CorrelationIdMiddleware) (2.0h)
│   │   ├── 🔹 Task 4.3: Configuração de Sinks, Filtros e Rotação de Arquivos (1.5h)
│   │   └── 🔹 Task 4.4: Integração dos Logs nos Services e Tratamento Global (1.0h)
│   └── 📄 [PBI-05] Distributed Tracing e Métricas de Performance com OpenTelemetry (2 pts)
│       ├── 🔹 Task 5.1: Adição de Dependências do OpenTelemetry na API (1.5h)
│       ├── 🔹 Task 5.2: Configuração de Tracing e Métricas no Program.cs (2.5h)
│       ├── 🔹 Task 5.3: Instrumentação Customizada de Métricas de Negócio (2.0h)
│       └── 🔹 Task 5.4: Teste e Validação da Emissão de Traces e Métricas (1.0h)
│
├── 🏆 [FEATURE 03] Testes Automatizados no Padrão AAA com xUnit e WebApplicationFactory
│   ├── 📄 [PBI-06] Estruturação dos Projetos de Teste e Testes Unitários de Domínio (AAA) (1 pt)
│   │   ├── 🔹 Task 6.1: Criação e Configuração dos Projetos de Testes no .NET (1.5h)
│   │   ├── 🔹 Task 6.2: Implementação dos Testes Unitários da Entidade Pet (AAA) (2.0h)
│   │   ├── 🔹 Task 6.3: Implementação dos Testes Unitários de Usuario e Tarefa (AAA) (2.5h)
│   │   └── 🔹 Task 6.4: Implementação dos Testes Unitários de Atendimento e Clinica (AAA) (2.0h)
│   ├── 📄 [PBI-07] Testes Unitários da Camada de Aplicação com Mocking de Dependências (Moq) (1 pt)
│   │   ├── 🔹 Task 7.1: Configuração do Moq e Helpers de Teste de Serviços (1.5h)
│   │   ├── 🔹 Task 7.2: Implementação de Testes Unitários para TarefaService (2.5h)
│   │   ├── 🔹 Task 7.3: Implementação de Testes Unitários para PetService e Gamificação (2.0h)
│   │   └── 🔹 Task 7.4: Implementação de Testes Unitários para UsuarioService e ClinicaService (2.0h)
│   └── 📄 [PBI-08] Testes de Integração de Endpoints HTTP com WebApplicationFactory & Fixtures (3 pts)
│       ├── 🔹 Task 8.1: Configuração da CustomWebApplicationFactory e Banco In-Memory (2.5h)
│       ├── 🔹 Task 8.2: Criação de Test Fixtures e Coleções do xUnit (2.0h)
│       ├── 🔹 Task 8.3: Implementação dos Testes de Integração de PetController e UsuarioController (2.5h)
│       └── 🔹 Task 8.4: Implementação dos Testes de Integração de TarefaController e Erros Globais (3.0h)
│
└── 🏆 [FEATURE 04] Documentação Técnica, Guias de Execução e Atualização do README
    └── 📄 [PBI-09] Atualização da Documentação Técnica (README.md, Health Checks, Testes e OpenAPI) (1 pt)
        ├── 🔹 Task 9.1: Redação do Guia de Execução, Arquitetura e Observabilidade (1.5h)
        └── 🔹 Task 9.2: Documentação de Comandos de Testes Automatizados e Evidências (1.5h)
```

---

## 📊 3. Tabela Resumo do Backlog

| Feature Pai | ID do PBI | Título do Item de Backlog (PBI) | Pontuação Oficial | Story Points | Prioridade | Horas Estimadas |
| :--- | :--- | :--- | :---: | :---: | :---: | :---: |
| **[FEATURE 01] CRUD Update** | **PBI-01** | Implementação de Atualização (PUT) Pet-Centric para Pet e Usuário | Base / DevOps | **1 pts** | 1 - Critical | 7.0h |
| | **PBI-02** | Implementação de Atualização (PUT) para Atendimento, Tarefa e Clínicas 24h | Base / DevOps | **2 pts** | 1 - Critical | 7.0h |
| **[FEATURE 02] Observabilidade** | **PBI-03** | Implementação de Health Checks Corporativos (API & Oracle Database) | 1 pts | **1 pts** | 1 - Critical | 6.0h |
| | **PBI-04** | Logging Estruturado com Serilog, Níveis de Log e Correlation ID | 1 pts | **1 pts** | 1 - Critical | 6.0h |
| | **PBI-05** | Distributed Tracing e Métricas de Performance com OpenTelemetry | 2 pts | **2 pts** | 2 - High | 7.0h |
| **[FEATURE 03] Testes AAA** | **PBI-06** | Estruturação dos Projetos de Teste e Testes Unitários de Domínio (AAA) | 20 pts *(c/ PBI-07)* | **1 pts** | 1 - Critical | 8.0h |
| | **PBI-07** | Testes Unitários da Camada de Aplicação com Mocking (Moq) | *(incluso acima)* | **1 pts** | 1 - Critical | 8.0h |
| | **PBI-08** | Testes de Integração de Endpoints com WebApplicationFactory & Fixtures | 3 pts | **3 pts** | 1 - Critical | 10.0h |
| **[FEATURE 04] Documentação** | **PBI-09** | Atualização da Documentação Técnica (README.md, Health Checks, Testes) | 1 pts | **1 pts** | 2 - High | 3.0h |
| **TOTAL CONSOLIDADO** | **4 Features** | **9 PBIs / 31 Child Tasks Técnicas** | **13 pts** | — | **62.0h** |

---

## 📦 4. Detalhamento dos Itens de Trabalho (Épico, Features, PBIs e Tasks)

---

### 🏛️ ÉPICO
* **Work Item Type:** `Epic`
* **Title:** `[EPIC] Sprint 3 - .NET & Observabilidade: Plataforma .NET de Cuidado Animal Pet-Centric, Observabilidade e Testes AAA`
* **Tags:** `Sprint3, DotNet, CSharp, Observability, UnitTests, IntegrationTests, CleanArchitecture`
* **Start Date:** `2026-08-24`
* **Target Date:** `2026-08-29`
* **Priority:** `1 - Critical`
* **Effort (Story Points):** `13`
* **Business Value:** `100`
* **Description:** Evolução corporativa da plataforma ASP.NET Core PetGuardian iniciando pela consolidação das operações de atualização (PUT), incorporando monitoramento de saúde via Health Checks, logging estruturado correlacionado com Serilog, telemetria distribuída e métricas com OpenTelemetry, e suíte completa de testes automatizados unitários e de integração no padrão AAA.

---

### 🏆 [FEATURE 01] Refatoração e Implementação Completa do CRUD (Operações de Update / PUT)
* **Work Item Type:** `Feature`
* **Parent:** `[EPIC] Sprint 3 - .NET & Observabilidade: Plataforma .NET de Cuidado Animal Pet-Centric, Observabilidade e Testes AAA`
* **Title:** `[FEATURE 01] Refatoração e Implementação Completa do CRUD (Operações de Update / PUT)`
* **Tags:** `Sprint3, DotNet, CRUD, REST, Domain, EntityFramework`
* **Start Date:** `2026-08-24`
* **Target Date:** `2026-08-25`
* **Priority:** `1 - Critical`
* **Effort (Story Points):** `3`
* **Description:** Completar o ciclo RESTful da API fornecendo endpoints de atualização (PUT), validação de dados, métodos de negócio em entidades de domínio Pet-Centric e persistência no banco de dados Oracle via Entity Framework Core, servindo de base para os testes de integração e a disciplina integrada de DevOps.

#### 🔹 [PBI-01] Implementação de Atualização (PUT) Pet-Centric para Pet e Usuário
* **Work Item Type:** `Product Backlog Item`
* **Parent Feature:** `[FEATURE 01] Refatoração e Implementação Completa do CRUD (Operações de Update / PUT)`
* **State:** `Approved`
* **Priority:** `1 - Critical`
* **Effort (Story Points):** `1`
* **Tags:** `Sprint3, DotNet, API, CRUD, Domain, PetCentric`

##### Descrição (História de Usuário)
> **Como** tutor participante da rede familiar de cuidado animal,  
> **Eu quero** atualizar os dados cadastrais do meu perfil e as informações do meu Pet (nome, idade, porte, peso atual, score de bem-estar e castração),  
> **Para que** os dados clínicos e de gamificação do animal estejam sempre atualizados para todos os cuidadores.

##### Critérios de Aceite (Acceptance Criteria / Definition of Done)
- [ ] O endpoint `PUT /api/Pet/{id}` aceita payload com dados atualizáveis (`Nome`, `Idade`, `Porte`, `PesoAtual`, `ScoreBemEstar`, `Castrado`, `RacaId`).
- [ ] Se o Pet não existir, o endpoint retorna HTTP `404 Not Found`.
- [ ] Validações de domínio respeitadas (idade entre 0 e 99 anos, peso positivo, nome obrigatório). Em caso de violação, retornar HTTP `400 Bad Request`.
- [ ] O endpoint `PUT /api/Usuario/{id}` permite alterar `Nome` e `TelefoneId`, mantendo as regras de negócio de e-mail e hash seguro de senha.
- [ ] Resposta HTTP `200 OK` com DTO atualizado (`PetResponse`, `UsuarioResponse`).

##### Tarefas Técnicas (Child Tasks)
* **Task 1.1:** [TASK-01] Atualização dos Modelos de Domínio e Invariantes (Pet & Usuario). *(Activity: Development, Est: 2.0h)*
  * *Descrição:* Criar métodos de negócio em `Pet.cs` e `Usuario.cs` para atualizar campos de forma encapsulada com validação.
* **Task 1.2:** [TASK-02] Criação dos DTOs de Update e Mapeamentos. *(Activity: Development, Est: 1.5h)*
  * *Descrição:* Criar `PetUpdateRequest.cs` e `UsuarioUpdateRequest.cs` na camada `PetGuardian.Application.DTOs` com Data Annotations.
* **Task 1.3:** [TASK-03] Implementação dos Métodos de Update nos Services e Repositórios. *(Activity: Development, Est: 2.0h)*
  * *Descrição:* Atualizar `IPetService`, `IUsuarioService` e suas implementações persistindo via repositório EF Core.
* **Task 1.4:** [TASK-04] Exposição dos Endpoints PUT nos Controllers (`PetController` e `UsuarioController`). *(Activity: Development, Est: 1.5h)*
  * *Descrição:* Adicionar métodos `[HttpPut("{id:guid}")]` com anotações `[ProducesResponseType]`, validação de `ModelState` e Swagger.

---

#### 🔹 [PBI-02] Implementação de Atualização (PUT) para Atendimento, Tarefa, Clínicas 24h e Cadastros
* **Work Item Type:** `Product Backlog Item`
* **Parent Feature:** `[FEATURE 01] Refatoração e Implementação Completa do CRUD (Operações de Update / PUT)`
* **State:** `Approved`
* **Priority:** `1 - Critical`
* **Effort (Story Points):** `2`
* **Tags:** `Sprint3, DotNet, API, CRUD, Services, Clinica24h`

##### Descrição (História de Usuário)
> **Como** administrador ou médico veterinário,  
> **Eu quero** editar os dados de atendimentos clínicos, detalhes de tarefas da rotina do pet, e atualizar clínicas parceiras (incluindo flags de atendimento 24h e pronto-socorro),  
> **Para que** qualquer alteração de diagnóstico ou disponibilidade de emergência seja retificada no sistema.

##### Critérios de Aceite (Acceptance Criteria / Definition of Done)
- [ ] Endpoints `PUT /api/Atendimento/{id}`, `PUT /api/Tarefa/{id}`, `PUT /api/Veterinario/{id}` e `PUT /api/Clinica/{id}` implementados e funcionais.
- [ ] Suporte a flags `Atendimento24h` e `ProntoSocorro` no DTO `ClinicaUpdateRequest`.
- [ ] Validações de integridade referencial mantidas (`ClinicaId`, `VeterinarioId`, `PetId`, `TipoAtendId`).
- [ ] Retorno `200 OK` com dados atualizados.

##### Tarefas Técnicas (Child Tasks)
* **Task 2.1:** [TASK-05] Criação dos DTOs de Update para Atendimento, Tarefa, Veterinário e Clínica. *(Activity: Development, Est: 2.0h)*
  * *Descrição:* Criar `AtendimentoUpdateRequest`, `TarefaUpdateRequest`, `VeterinarioUpdateRequest` e `ClinicaUpdateRequest`.
* **Task 2.2:** [TASK-06] Implementação dos Métodos de Atualização nas Entidades e Serviços de Aplicação. *(Activity: Development, Est: 3.0h)*
  * *Descrição:* Adicionar métodos de atualização em `AtendimentoService`, `TarefaService`, `VeterinarioService` e `ClinicaService`.
* **Task 2.3:** [TASK-07] Adição dos Endpoints PUT nos Controllers Correspondentes. *(Activity: Development, Est: 2.0h)*
  * *Descrição:* Atualizar `AtendimentoController`, `TarefaController`, `VeterinarioController` e `ClinicaController` com `[HttpPut("{id:guid}")]`.

---

### 🏆 [FEATURE 02] Monitoramento, Observabilidade e Diagnóstico da Aplicação
* **Work Item Type:** `Feature`
* **Parent:** `[EPIC] Sprint 3 - .NET & Observabilidade: Plataforma .NET de Cuidado Animal Pet-Centric, Observabilidade e Testes AAA`
* **Title:** `[FEATURE 02] Monitoramento, Observabilidade e Diagnóstico da Aplicação`
* **Tags:** `Sprint3, DotNet, Observability, HealthChecks, Serilog, OpenTelemetry`
* **Start Date:** `2026-08-25`
* **Target Date:** `2026-08-27`
* **Priority:** `1 - Critical`
* **Effort (Story Points):** `4`
* **Description:** Implementar a infraestrutura completa de observabilidade corporativa incluindo verificação de saúde (Health Checks), registro em log estruturado correlacionado por requisição (Serilog) e rastreamento distribuído com métricas de desempenho (OpenTelemetry).

#### 🔹 [PBI-03] Implementação de Health Checks Corporativos (API & Oracle Database)
* **Work Item Type:** `Product Backlog Item`
* **Parent Feature:** `[FEATURE 02] Monitoramento, Observabilidade e Diagnóstico da Aplicação`
* **State:** `Approved`
* **Priority:** `1 - Critical`
* **Effort (Story Points):** `1`
* **Tags:** `Sprint3, DotNet, HealthChecks, Observability, Oracle`

##### Descrição (História de Usuário)
> **Como** engenheiro de DevOps e sustentação do sistema,  
> **Eu quero** que a API exponha endpoints padronizados de verificação de saúde (`/health`, `/health/ready`, `/health/live`),  
> **Para que** ferramentas de monitoramento e orquestradores em nuvem (como Azure App Service e ACI) possam identificar instantaneamente a disponibilidade da aplicação e do banco Oracle.

##### Critérios de Aceite (Acceptance Criteria / Definition of Done)
- [ ] Utilização do pacote oficial `Microsoft.Extensions.Diagnostics.HealthChecks`.
- [ ] Endpoint `/health` configurado retornando status HTTP `200 OK` (`Healthy`) ou `503 Service Unavailable` (`Unhealthy`).
- [ ] Verificação de conectividade ativa com o banco de dados Oracle (`PetGuardianDbContext`) com tratamento de timeout.
- [ ] Endpoints específicos:
  - **Liveness (`/health/live`):** Indica se o processo da API está ativo e respondendo.
  - **Readiness (`/health/ready`):** Valida a prontidão das dependências essenciais (conectividade com o banco Oracle).
- [ ] Resposta em formato JSON estruturado com status geral, status individual de cada dependência, duração (`duration`) e timestamp.

##### Tarefas Técnicas (Child Tasks)
* **Task 3.1:** [TASK-08] Instalação de Pacotes NuGet de Health Checks. *(Activity: Development, Est: 1.0h)*
  * *Descrição:* Adicionar `Microsoft.Extensions.Diagnostics.HealthChecks`, `Microsoft.Extensions.Diagnostics.HealthChecks.EntityFrameworkCore` e `AspNetCore.HealthChecks.UI.Client`.
* **Task 3.2:** [TASK-09] Implementação de Health Check para Oracle DB. *(Activity: Development, Est: 2.0h)*
  * *Descrição:* Configurar `AddDbContextCheck<PetGuardianDbContext>()` executando validação de conectividade leve no banco.
* **Task 3.3:** [TASK-10] Configuração dos Endpoints e Formatador JSON no `Program.cs`. *(Activity: Development, Est: 2.0h)*
  * *Descrição:* Mapear `/health`, `/health/ready` e `/health/live` com formatador JSON estruturado contendo detalhes de diagnóstico.
* **Task 3.4:** [TASK-11] Teste de Validação dos Health Checks em Sucesso e Falha. *(Activity: Testing, Est: 1.0h)*
  * *Descrição:* Validar retornos 200 OK em estado normal e 503 Service Unavailable em caso de desconexão do banco.

---

#### 🔹 [PBI-04] Logging Estruturado com Serilog, Níveis de Log e Correlation ID
* **Work Item Type:** `Product Backlog Item`
* **Parent Feature:** `[FEATURE 02] Monitoramento, Observabilidade e Diagnóstico da Aplicação`
* **State:** `Approved`
* **Priority:** `1 - Critical`
* **Effort (Story Points):** `1`
* **Tags:** `Sprint3, DotNet, Serilog, Logging, CorrelationID`

##### Descrição (História de Usuário)
> **Como** desenvolvedor e operador de infraestrutura,  
> **Eu quero** logs estruturados em formato JSON/Console/Arquivo e um Correlation ID exclusivo por requisição,  
> **Para que** eu possa rastrear todo o ciclo de vida de uma transação entre as camadas da aplicação e diagnosticar erros rapidamente em produção.

##### Critérios de Aceite (Acceptance Criteria / Definition of Done)
- [ ] Serilog configurado no `Program.cs` substituindo o provedor de log padrão do .NET.
- [ ] Suporte aos níveis de severidade: `Information`, `Warning` e `Error`.
- [ ] Saída dupla configurada: Console formatado e Arquivo com rotação diária (`logs/petguardian-.log`) e retenção configurada.
- [ ] `CorrelationIdMiddleware` implementado interceptando o cabeçalho `X-Correlation-ID` (ou gerando novo `Guid` se ausente).
- [ ] O `CorrelationId` deve ser adicionado ao `LogContext` do Serilog e retornado no cabeçalho de resposta HTTP `X-Correlation-ID`.
- [ ] O middleware de tratamento de exceções global registra falhas com nível `Error`, Correlation ID, rota e stacktrace.

##### Tarefas Técnicas (Child Tasks)
* **Task 4.1:** [TASK-12] Instalação e Configuração dos Pacotes do Serilog. *(Activity: Development, Est: 1.5h)*
  * *Descrição:* Instalar `Serilog.AspNetCore`, `Serilog.Sinks.Console`, `Serilog.Sinks.File` e `Serilog.Enrichers.Environment`.
* **Task 4.2:** [TASK-13] Implementação do Middleware de Correlação (`CorrelationIdMiddleware`). *(Activity: Development, Est: 2.0h)*
  * *Descrição:* Criar middleware interceptando `X-Correlation-ID`, injetando no `LogContext.PushProperty` e response header.
* **Task 4.3:** [TASK-14] Configuração de Sinks, Filtros e Rotação de Arquivos no `appsettings.json`. *(Activity: Development, Est: 1.5h)*
  * *Descrição:* Definir configurações de Serilog com rolling interval diário e formatação limpa.
* **Task 4.4:** [TASK-15] Integração dos Logs nos Services e Tratamento Global de Exceções. *(Activity: Development, Est: 1.0h)*
  * *Descrição:* Injetar `ILogger<T>` nos serviços essenciais (`TarefaService`, `PetService`, `AtendimentoService`).

---

#### 🔹 [PBI-05] Distributed Tracing e Métricas de Performance com OpenTelemetry
* **Work Item Type:** `Product Backlog Item`
* **Parent Feature:** `[FEATURE 02] Monitoramento, Observabilidade e Diagnóstico da Aplicação`
* **State:** `Approved`
* **Priority:** `2 - High`
* **Effort (Story Points):** `2`
* **Tags:** `Sprint3, DotNet, OpenTelemetry, Tracing, Metrics`

##### Descrição (História de Usuário)
> **Como** arquiteto de software e time de SRE,  
> **Eu quero** rastrear requisições através de Distributed Tracing e expor métricas de desempenho (tempo de resposta, taxa de erros e throughput),  
> **Para que** gargalos de performance nas consultas e chamadas de serviço sejam identificados com precisão.

##### Critérios de Aceite (Acceptance Criteria / Definition of Done)
- [ ] Pacotes `OpenTelemetry.Extensions.Hosting`, `OpenTelemetry.Instrumentation.AspNetCore` e `OpenTelemetry.Instrumentation.Http` configurados no projeto.
- [ ] Distributed Tracing instrumentando requisições HTTP de entrada e operações do Entity Framework Core.
- [ ] Métricas de desempenho expostas: tempo de resposta da requisição (`http.server.request.duration`), taxa de erros e contadores customizados.
- [ ] Exportador configurado (Console Exporter ou endpoint `/metrics`).
- [ ] Spans nomeados adequadamente refletindo a operação e as camadas executadas.

##### Tarefas Técnicas (Child Tasks)
* **Task 5.1:** [TASK-16] Adição de Dependências do OpenTelemetry na API. *(Activity: Development, Est: 1.5h)*
  * *Descrição:* Instalar pacotes NuGet do OpenTelemetry (`OpenTelemetry.Extensions.Hosting`, `OpenTelemetry.Instrumentation.AspNetCore`, `OpenTelemetry.Instrumentation.EntityFrameworkCore`).
* **Task 5.2:** [TASK-17] Configuração de Tracing e Métricas no Pipeline de Injeção de Dependências. *(Activity: Development, Est: 2.5h)*
  * *Descrição:* Configurar `builder.Services.AddOpenTelemetry()` com `.WithTracing(...)` e `.WithMetrics(...)` no `Program.cs`.
* **Task 5.3:** [TASK-18] Instrumentação Customizada de Métricas de Negócio (ActivitySource & Meter). *(Activity: Development, Est: 2.0h)*
  * *Descrição:* Criar contadores customizados (`tarefas_concluidas_total`, `atendimentos_criados_total`) para métricas de negócio.
* **Task 5.4:** [TASK-19] Teste e Validação da Emissão de Traces e Métricas. *(Activity: Testing, Est: 1.0h)*
  * *Descrição:* Executar requisições de teste na API e validar a geração correta dos spans e coleta de métricas.

---

### 🏆 [FEATURE 03] Testes Automatizados no Padrão AAA com xUnit e WebApplicationFactory
* **Work Item Type:** `Feature`
* **Parent:** `[EPIC] Sprint 3 - .NET & Observabilidade: Plataforma .NET de Cuidado Animal Pet-Centric, Observabilidade e Testes AAA`
* **Title:** `[FEATURE 03] Testes Automatizados no Padrão AAA com xUnit e WebApplicationFactory`
* **Tags:** `Sprint3, DotNet, Testing, xUnit, Moq, WebApplicationFactory, AAA`
* **Start Date:** `2026-08-27`
* **Target Date:** `2026-08-28`
* **Priority:** `1 - Critical`
* **Effort (Story Points):** `5`
* **Description:** Implementação de suíte abrangente de testes automatizados com cobertura das camadas de Domínio e Aplicação (testes unitários com Moq) e testes de integração de ponta a ponta para os endpoints da API com WebApplicationFactory e Fixtures.

#### 🔹 [PBI-06] Estruturação dos Projetos de Teste e Testes Unitários de Domínio (AAA)
* **Work Item Type:** `Product Backlog Item`
* **Parent Feature:** `[FEATURE 03] Testes Automatizados no Padrão AAA com xUnit e WebApplicationFactory`
* **State:** `Approved`
* **Priority:** `1 - Critical`
* **Effort (Story Points):** `1`
* **Tags:** `Sprint3, DotNet, xUnit, UnitTests, Domain, AAA`

##### Descrição (História de Usuário)
> **Como** desenvolvedor de software,  
> **Eu quero** projetos de teste dedicados com testes unitários cobrindo as entidades e regras de domínio no padrão AAA,  
> **Para que** as invariantes de negócio (validação de score do pet, idade, peso e regras de rotina) permaneçam protegidas contra regressões.

##### Critérios de Aceite (Acceptance Criteria / Definition of Done)
- [ ] Criação dos projetos `PetGuardian.UnitTests` e `PetGuardian.IntegrationTests` adicionados à solution `PetGuardian.sln`.
- [ ] Todos os testes unitários seguem rigorosamente o padrão **AAA (Arrange, Act, Assert)** com blocos comentados.
- [ ] Nomenclatura uniforme e padronizada: `MetodoTestado_Cenario_ResultadoEsperado`.
- [ ] Cobertura completa de entidades do Domínio (`Pet`, `Usuario`, `Tarefa`, `Atendimento`, `Clinica`, `Veterinario`).
- [ ] Testes validando fluxos de sucesso e lançamento de `DomainException` em cenários de dados inválidos (ex: pet com idade negativa, nome nulo, e-mail inválido).

##### Tarefas Técnicas (Child Tasks)
* **Task 6.1:** [TASK-20] Criação e Configuração dos Projetos de Testes no .NET. *(Activity: Development, Est: 1.5h)*
  * *Descrição:* Criar `PetGuardian.UnitTests.csproj` e `PetGuardian.IntegrationTests.csproj` com `xunit`, `FluentAssertions` e `Microsoft.NET.Test.Sdk`.
* **Task 6.2:** [TASK-21] Implementação dos Testes Unitários da Entidade `Pet` (AAA). *(Activity: Testing, Est: 2.0h)*
  * *Descrição:* Cobrir criação com dados válidos, atualização de idade, peso, score de bem-estar e lançamento de exceções.
* **Task 6.3:** [TASK-22] Implementação dos Testes Unitários da Entidade `Usuario` e `Tarefa` (AAA). *(Activity: Testing, Est: 2.5h)*
  * *Descrição:* Testar validação de e-mail, senha, métodos de conclusão de tarefas, atribuição de executor e transição de status.
* **Task 6.4:** [TASK-23] Implementação dos Testes Unitários de `Atendimento`, `Veterinario` e `Clinica` (AAA). *(Activity: Testing, Est: 2.0h)*
  * *Descrição:* Testar construtores, métodos de atualização de dados e validações de campos obrigatórios e flags 24h.

---

#### 🔹 [PBI-07] Testes Unitários da Camada de Aplicação com Mocking de Dependências (Moq)
* **Work Item Type:** `Product Backlog Item`
* **Parent Feature:** `[FEATURE 03] Testes Automatizados no Padrão AAA com xUnit e WebApplicationFactory`
* **State:** `Approved`
* **Priority:** `1 - Critical`
* **Effort (Story Points):** `1`
* **Tags:** `Sprint3, DotNet, xUnit, Moq, ApplicationServices, AAA`

##### Descrição (História de Usuário)
> **Como** desenvolvedor de software,  
> **Eu quero** testar os serviços da camada de aplicação (`PetService`, `TarefaService`, `UsuarioService`, `AtendimentoService`) utilizando mocks para os repositórios,  
> **Para que** a orquestração de regras de negócio, cálculo de scores do pet e validações de existência sejam validadas de forma isolada e ultra-rápida.

##### Critérios de Aceite (Acceptance Criteria / Definition of Done)
- [ ] Uso do framework `Moq` para simulação de todos os repositórios e dependências.
- [ ] Testes do método `TarefaService.Concluir`:
  * Usuário não cadastrado (`InvalidOperationException`).
  * Usuário não pertencente ao círculo de cuidadores do pet (`InvalidOperationException`).
  * Tarefa já concluída previamente (`InvalidOperationException`).
  * Sucesso na conclusão com crédito de pontos no `Pet` e status `CONCLUIDO`.
- [ ] Testes do método `PetService.GetScore` validando o somatório de pontos e nível de saúde do Pet.
- [ ] Testes dos métodos de `Create`, `Update`, `GetById` e `Delete` de todos os serviços.

##### Tarefas Técnicas (Child Tasks)
* **Task 7.1:** [TASK-24] Configuração do Moq e Helpers de Teste de Serviços. *(Activity: Development, Est: 1.5h)*
  * *Descrição:* Configurar pacote `Moq` no projeto de testes e criar métodos utilitários para criação rápida de mocks.
* **Task 7.2:** [TASK-25] Implementação de Testes Unitários para `TarefaService` (Cenários Críticos). *(Activity: Testing, Est: 2.5h)*
  * *Descrição:* Testar todos os ramos de decisão do método `Concluir`, criação de tarefas e filtros de busca.
* **Task 7.3:** [TASK-26] Implementação de Testes Unitários para `PetService` e Score/Gamificação. *(Activity: Testing, Est: 2.0h)*
  * *Descrição:* Testar fluxos de cadastro de pets, atualização de score de bem-estar e cálculo do nível de saúde.
* **Task 7.4:** [TASK-27] Implementação de Testes Unitários para `UsuarioService`, `ClinicaService` e `AtendimentoService`. *(Activity: Testing, Est: 2.0h)*
  * *Descrição:* Testar operações de CRUD, listagens, histórico clínico consolidado e tratamento de 404.

---

#### 🔹 [PBI-08] Testes de Integração de Endpoints HTTP com WebApplicationFactory & Fixtures
* **Work Item Type:** `Product Backlog Item`
* **Parent Feature:** `[FEATURE 03] Testes Automatizados no Padrão AAA com xUnit e WebApplicationFactory`
* **State:** `Approved`
* **Priority:** `1 - Critical`
* **Effort (Story Points):** `3`
* **Tags:** `Sprint3, DotNet, IntegrationTests, WebApplicationFactory, Fixtures`

##### Descrição (História de Usuário)
> **Como** desenvolvedor e responsável por QA,  
> **Eu quero** testes de integração ponta a ponta executando contra o pipeline HTTP real da API via `WebApplicationFactory`,  
> **Para que** todo o ciclo de vida HTTP (roteamento, validação de ModelState, injeção de dependências, tratamento de exceções global e respostas 200/201/204/400/404) seja homologado antes do deploy.

##### Critérios de Aceite (Acceptance Criteria / Definition of Done)
- [ ] Projeto `PetGuardian.IntegrationTests` configurado com `Microsoft.AspNetCore.Mvc.Testing` (`WebApplicationFactory<Program>`).
- [ ] Implementação de `CustomWebApplicationFactory` com banco em memória (`UseInMemoryDatabase` ou SQLite) para execução isolada e confiável sem dependência de banco físico externo.
- [ ] Uso de **Fixtures** e **Collection Fixtures** (`IClassFixture`, `ICollectionFixture`) para compartilhamento otimizado de contexto.
- [ ] Testes de integração cobrindo o fluxo completo:
  * `POST /api/Pet` com retorno `201 Created` e header `Location`;
  * `PUT /api/Pet/{id}` com retorno `200 OK`;
  * `GET /api/Pet/{id}` com retorno `200 OK` e `404 Not Found` para IDs inexistentes;
  * `DELETE /api/Pet/{id}` com retorno `204 No Content`;
  * `POST /api/Tarefa` e `PUT /api/Tarefa/{id}/concluir`;
  * Validação de respostas `400 Bad Request` para payloads inválidos (`ProblemDetails`).

##### Tarefas Técnicas (Child Tasks)
* **Task 8.1:** [TASK-28] Configuração da `CustomWebApplicationFactory` e Banco In-Memory. *(Activity: Development, Est: 2.5h)*
  * *Descrição:* Criar a classe `CustomWebApplicationFactory<TProgram>` customizando `ConfigureServices` para usar `InMemoryDbContext`.
* **Task 8.2:** [TASK-29] Criação de Test Fixtures e Coleções do xUnit. *(Activity: Development, Est: 2.0h)*
  * *Descrição:* Criar classes de Fixture (`IntegrationTestFixture`, `DatabaseFixture`) e anotação `[CollectionDefinition("IntegrationTests")]`.
* **Task 8.3:** [TASK-30] Implementação dos Testes de Integração de `PetController` e `UsuarioController`. *(Activity: Testing, Est: 2.5h)*
  * *Descrição:* Testar endpoints de CRUD completo (POST, GET, PUT, DELETE), validando status codes e respostas JSON.
* **Task 8.4:** [TASK-31] Implementação dos Testes de Integração de `TarefaController`, `AtendimentoController` e Erros Globais. *(Activity: Testing, Est: 3.0h)*
  * *Descrição:* Testar fluxos de conclusão de tarefa, listagens com relacionamentos e validação de `ProblemDetails`.

---

### 🏆 [FEATURE 04] Documentação Técnica, Guias de Execução e Atualização do README
* **Work Item Type:** `Feature`
* **Parent:** `[EPIC] Sprint 3 - .NET & Observabilidade: Plataforma .NET de Cuidado Animal Pet-Centric, Observabilidade e Testes AAA`
* **Title:** `[FEATURE 04] Documentação Técnica, Guias de Execução e Atualização do README`
* **Tags:** `Sprint3, DotNet, Documentation, README, OpenAPI, Swagger`
* **Start Date:** `2026-08-28`
* **Target Date:** `2026-08-29`
* **Priority:** `2 - High`
* **Effort (Story Points):** `1`
* **Description:** Estruturação e publicação da documentação técnica no README.md, incluindo instruções de build, execução de testes unitários/integração, visualização de Health Checks e endpoints OpenAPI/Swagger.

#### 🔹 [PBI-09] Atualização da Documentação Técnica (README.md, Health Checks, Testes e OpenAPI)
* **Work Item Type:** `Product Backlog Item`
* **Parent Feature:** `[FEATURE 04] Documentação Técnica, Guias de Execução e Atualização do README`
* **State:** `Approved`
* **Priority:** `2 - High`
* **Effort (Story Points):** `1`
* **Tags:** `Sprint3, DotNet, Documentation, README, OpenAPI`

##### Descrição (História de Usuário)
> **Como** professor avaliador e desenvolvedor da equipe,  
> **Eu quero** um README.md completo e detalhado no repositório GitHub,  
> **Para que** qualquer pessoa consiga clonar o repositório, executar a suíte de testes automatizados (`dotnet test`), inspecionar os endpoints no Swagger e validar os Health Checks da API.

##### Critérios de Aceite (Acceptance Criteria / Definition of Done)
- [ ] Seção detalhada sobre a arquitetura da solução (Domain-Driven Design simplificado em 4 camadas).
- [ ] Comandos para restaurar dependências, compilar e executar a API (`dotnet run --project PetGuardian.API`).
- [ ] Instruções para execução dos testes unitários e de integração (`dotnet test --verbosity normal`).
- [ ] Documentação dos endpoints de Observabilidade (`/health`, `/health/ready`, `/health/live`, `/metrics`).
- [ ] Instruções de acesso ao Swagger UI (`/swagger/index.html`).

##### Tarefas Técnicas (Child Tasks)
* **Task 9.1:** [TASK-32] Redação do Guia de Execução, Arquitetura e Observabilidade no `README.md`. *(Activity: Documentation, Est: 1.5h)*
  * *Descrição:* Detalhar arquitetura da aplicação, endpoints de monitoramento e passos para rodar localmente.
* **Task 9.2:** [TASK-33] Documentação de Comandos de Testes Automatizados e Evidências. *(Activity: Documentation, Est: 1.5h)*
  * *Descrição:* Descrever como rodar a suíte xUnit de testes unitários e de integração no terminal.

---

## 👥 5. Integrantes do Grupo e Responsabilidades (Ordem Alfabética Estrita)

| Integrante | RM | Turma | Responsabilidade Principal na Sprint 3 |
| :--- | :---: | :---: | :--- |
| **Enzo Okuizumi** | **561432** | 2TDSPG | Mobile Development (React Native), Integração TanStack Query & Coordenação Geral |
| **Gustavo Okada** | **563428** | 2TDSPG | Java Advanced (Spring Security JWT, Flyway e SOLID) & .NET Observabilidade |
| **Lucas Barros Gouveia** | **566422** | 2TDSPG | Database Advanced (PL/SQL, Funções, Procedures e Triggers DML) |
| **Luna de Carvalho Guimarães** | **562290** | 2TDSPG | Disruptive Architectures (FastAPI, IA Generativa, RAG e Chat) & Compliance |
| **Milton Marcelino** | **564836** | 2TDSPG | DevOps Tools & Cloud Computing (Azure CLI, ACR, ACI e Containers) |
