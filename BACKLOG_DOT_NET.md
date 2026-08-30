# 📋 Backlog Master Azure Boards — Sprint 3: .NET & Observabilidade

> **Projeto Integrado:** PetGuardian / Clyvo Care (Challenge FIAP 2026 - 2º Ano ADS / 2TDSPG)  
> **Disciplina:** Advanced Business Development with .NET (FIAP — 2TDSPG)  
> **Epic Principal:** `[EPIC] Sprint 3 - .NET & Observabilidade: Plataforma .NET de Cuidado Animal Pet-Centric, Observabilidade e Testes AAA`  
> **Start Date:** `2026-08-24`  
> **Target Date:** `2026-08-29`  
> **Padrão:** Azure Boards (Scrum Process: Epic ➔ Feature ➔ PBI ➔ Task)  
> **Diretrizes Estratégicas:** 1º Refatoração e Governança Pet-Centric (Alinhamento com o Modelo 3FN do Banco de Dados, CRUD Completo com PUT) ➔ 2º Monitoramento & Observabilidade Corporativa (Health Checks para API e Oracle DB, Serilog Estruturado com Correlation ID e OpenTelemetry Tracing/Métricas) ➔ 3º Suíte de Testes Automatizados no Padrão AAA (xUnit, Moq para Camada de Aplicação e WebApplicationFactory para Integração de Endpoints) ➔ 4º Documentação Técnica & README.

---

## 🎯 1. Matriz de Requisitos & Critérios de Avaliação Oficiais (Páginas 07 e 08)

| Componente / Módulo | Pontuação Oficial | Itens Obrigatórios do Edital (Páginas 07 e 08) & Alinhamento Pet-Centric 3FN | Status no Backlog |
| :--- | :---: | :--- | :--- |
| **1ª AÇÃO: Refatoração 3FN & CRUD (PUT)** | *Base Técnica & DevOps* | • Alinhamento estrito com a refatoração do banco de dados em **3FN** (`pet`, `usuario`, `usuario_pet`, `tarefa`, `status`, `raca`, `endereco`, `bairro`, `cidade`, `estado`, `telefone`, `usuario_endereco`).<br>• Implementação de verbos HTTP `PUT` em `Pet` (com integridade de porte, sexo, raça e castração), `Usuario`, `Tarefa` e `Endereco` com métodos de negócio encapsulados no Domínio.<br>• Suporte aos fluxos Pet-Centric da plataforma: Rede de Cuidado familiar N:N (`UsuarioPet`), histórico consolidado de rotina (`GetHistorico`) e gamificação por tarefas concluídas. | **[FEATURE 01] (3 SP / 14.0h)** |
| **1. Monitoramento e Observabilidade** | **40 pts** | • **Health Checks (15 pts):** `/health`, `/health/ready` (Oracle DB / `PetGuardianContext`) e `/health/live` via `Microsoft.Extensions.Diagnostics.HealthChecks` com formatação JSON estruturada.<br>• **Logging Estruturado (10 pts):** Serilog (Info, Warning, Error), saída dupla Console/Arquivo com rotação diária (`logs/petguardian-.log`) e middleware de rastreamento com Correlation ID (`X-Correlation-ID`).<br>• **Tracing e Métricas (15 pts):** OpenTelemetry (Distributed Tracing entre ASP.NET Core e EF Core, e métricas customizadas de latência e contadores de negócio com `Meter`/`ActivitySource`). | **[FEATURE 02] (4 SP / 19.0h)** |
| **2. Testes Automatizados (Padrão AAA)** | **50 pts** | • **Testes Unitários de Domínio (20 pts):** xUnit no padrão **Arrange, Act, Assert (AAA)** cobrindo entidades (`Pet`, `Usuario`, `UsuarioPet`, `Tarefa`, `Raca`, `Status`, `Endereco`) e exceções de negócio (`DomainException`).<br>• **Testes Unitários de Aplicação com Moq (15 pts):** Isolamento de serviços (`PetService`, `TarefaService`, `UsuarioPetService`, `EnderecoService`, `UsuarioService`) com simulação de repositórios via `Moq` para validar regras de conclusão, permissões e rede de cuidado.<br>• **Testes de Integração de Endpoints (15 pts):** `WebApplicationFactory` com banco in-memory / SQLite, validação de contratos HTTP (200, 201, 204, 400, 404), headers e tratamento global de erros (`ProblemDetails`). | **[FEATURE 03] (5 SP / 26.0h)** |
| **3. Atualização do README.md** | **10 pts** | • Guia completo dos endpoints de Health Checks e Observabilidade.<br>• Instruções claras de compilação e execução dos testes automatizados (`dotnet test`).<br>• Descrição arquitetural das camadas DDD, Swagger UI e fluxo de dados com o banco Oracle. | **[FEATURE 04] (1 SP / 3.0h)** |
| **TOTAL CONSOLIDADO** | **100 pts Oficiais** | **Foco Estrito na Sprint 3** *(Requisitos da Sprint 4 como MongoDB, HATEOAS, Paginação e JWT Identity mantidos para a próxima entrega).* | **13 pts / 62.0h** |

---

## 🌳 2. Estrutura Hierárquica no Azure Boards

```text
[EPIC] Sprint 3 - .NET & Observabilidade: Plataforma .NET de Cuidado Animal Pet-Centric, Observabilidade e Testes AAA
│
├── 🏆 [FEATURE 01] Refatoração e Implementação Completa do CRUD (Operações de Update / PUT)
│   ├── 📄 [PBI-01] Implementação de Atualização (PUT) e Governança Pet-Centric para Pet e Usuário (1 pt)
│   │   ├── 🔹 Task 1.1: Atualização dos Modelos de Domínio 3FN e Invariantes (Pet & Usuario) (2.0h)
│   │   ├── 🔹 Task 1.2: Criação dos DTOs de Update e Mapeamentos com Data Annotations (1.5h)
│   │   ├── 🔹 Task 1.3: Implementação dos Métodos de Update nos Services e Repositórios EF Core (2.0h)
│   │   └── 🔹 Task 1.4: Exposição dos Endpoints PUT nos Controllers (PetController & UsuarioController) (1.5h)
│   └── 📄 [PBI-02] Implementação de Atualização (PUT) para Tarefa, Endereço e Rede de Cuidado (2 pts)
│       ├── 🔹 Task 2.1: Criação dos DTOs de Update para Tarefa e Endereço (2.0h)
│       ├── 🔹 Task 2.2: Implementação dos Métodos de Atualização nas Entidades e Serviços de Aplicação (3.0h)
│       └── 🔹 Task 2.3: Adição dos Endpoints PUT nos Controllers Correspondentes e Validação Swagger (2.0h)
│
├── 🏆 [FEATURE 02] Monitoramento, Observabilidade e Diagnóstico da Aplicação
│   ├── 📄 [PBI-03] Implementação de Health Checks Corporativos (API & Oracle Database) (1 pt)
│   │   ├── 🔹 Task 3.1: Instalação e Configuração dos Pacotes NuGet de Health Checks (1.0h)
│   │   ├── 🔹 Task 3.2: Implementação de Health Check de Conectividade para Oracle DB (2.0h)
│   │   ├── 🔹 Task 3.3: Configuração dos Endpoints (/health, /health/ready, /health/live) no Program.cs (2.0h)
│   │   └── 🔹 Task 3.4: Teste de Validação dos Health Checks em Estados Saudável e Degradado (1.0h)
│   ├── 📄 [PBI-04] Logging Estruturado com Serilog, Níveis de Log e Correlation ID (1 pt)
│   │   ├── 🔹 Task 4.1: Instalação e Configuração do Serilog com Saída em Console e Arquivo Rotativo (1.5h)
│   │   ├── 🔹 Task 4.2: Implementação do Middleware de Correlação (CorrelationIdMiddleware) (2.0h)
│   │   ├── 🔹 Task 4.3: Configuração de Sinks, Filtros e Formatação Estruturada no appsettings.json (1.5h)
│   │   └── 🔹 Task 4.4: Integração dos Logs Estruturados nos Services e Middleware Global de Erros (1.0h)
│   └── 📄 [PBI-05] Distributed Tracing e Métricas de Performance com OpenTelemetry (2 pts)
│       ├── 🔹 Task 5.1: Adição das Dependências do OpenTelemetry no Projeto da API (1.5h)
│       ├── 🔹 Task 5.2: Configuração de Tracing para ASP.NET Core e EF Core no Program.cs (2.5h)
│       ├── 🔹 Task 5.3: Instrumentação Customizada de Métricas de Negócio (ActivitySource & Meter) (2.0h)
│       └── 🔹 Task 5.4: Teste e Validação da Emissão de Spans e Coleta de Métricas (1.0h)
│
├── 🏆 [FEATURE 03] Testes Automatizados no Padrão AAA com xUnit e WebApplicationFactory
│   ├── 📄 [PBI-06] Estruturação dos Projetos de Teste e Testes Unitários de Domínio (AAA) (1 pt)
│   │   ├── 🔹 Task 6.1: Criação e Configuração dos Projetos de Testes xUnit na Solution (1.5h)
│   │   ├── 🔹 Task 6.2: Implementação dos Testes Unitários da Entidade Pet e Raça (AAA) (2.0h)
│   │   ├── 🔹 Task 6.3: Implementação dos Testes Unitários de Usuario, UsuarioPet e Tarefa (AAA) (2.5h)
│   │   └── 🔹 Task 6.4: Implementação dos Testes Unitários de Endereço, Bairro, Cidade e Telefone (AAA) (2.0h)
│   ├── 📄 [PBI-07] Testes Unitários da Camada de Aplicação com Mocking de Dependências (Moq) (1 pt)
│   │   ├── 🔹 Task 7.1: Configuração do Moq e Estruturação de Fixtures de Testes de Serviços (1.5h)
│   │   ├── 🔹 Task 7.2: Implementação de Testes Unitários para TarefaService (Conclusão e Gamificação) (2.5h)
│   │   ├── 🔹 Task 7.3: Implementação de Testes Unitários para PetService e Linha do Tempo Histórica (2.0h)
│   │   └── 🔹 Task 7.4: Implementação de Testes Unitários para UsuarioPetService e EnderecoService (2.0h)
│   └── 📄 [PBI-08] Testes de Integração de Endpoints HTTP com WebApplicationFactory & Fixtures (3 pts)
│       ├── 🔹 Task 8.1: Configuração da CustomWebApplicationFactory com Banco In-Memory Isolado (2.5h)
│       ├── 🔹 Task 8.2: Criação de Test Fixtures e Coleções Compartilhadas do xUnit (2.0h)
│       ├── 🔹 Task 8.3: Implementação dos Testes de Integração de PetController e UsuarioPetController (2.5h)
│       └── 🔹 Task 8.4: Implementação dos Testes de Integração de TarefaController, EnderecoController e Erros (3.0h)
│
└── 🏆 [FEATURE 04] Documentação Técnica, Guias de Execução e Atualização do README
    └── 📄 [PBI-09] Atualização da Documentação Técnica (README.md, Health Checks, Testes e OpenAPI) (1 pt)
        ├── 🔹 Task 9.1: Redação do Guia de Execução, Arquitetura DDD 3FN e Observabilidade no README.md (1.5h)
        └── 🔹 Task 9.2: Documentação de Comandos de Testes Automatizados (dotnet test) e Evidências (1.5h)
```

---

## 📊 3. Tabela Resumo do Backlog

| Feature Pai | ID do PBI | Título do Item de Backlog (PBI) | Pontuação Oficial | Story Points | Prioridade | Horas Estimadas |
| :--- | :--- | :--- | :---: | :---: | :---: | :---: |
| **[FEATURE 01] CRUD Update** | **PBI-01** | Implementação de Atualização (PUT) e Governança Pet-Centric para Pet e Usuário | Base / DevOps | **1 pts** | 1 - Critical | 7.0h |
| | **PBI-02** | Implementação de Atualização (PUT) para Tarefa, Endereço e Rede de Cuidado | Base / DevOps | **2 pts** | 1 - Critical | 7.0h |
| **[FEATURE 02] Observabilidade** | **PBI-03** | Implementação de Health Checks Corporativos (API & Oracle Database) | 15 pts | **1 pts** | 1 - Critical | 6.0h |
| | **PBI-04** | Logging Estruturado com Serilog, Níveis de Log e Correlation ID | 10 pts | **1 pts** | 1 - Critical | 6.0h |
| | **PBI-05** | Distributed Tracing e Métricas de Performance com OpenTelemetry | 15 pts | **2 pts** | 2 - High | 7.0h |
| **[FEATURE 03] Testes AAA** | **PBI-06** | Estruturação dos Projetos de Teste e Testes Unitários de Domínio (AAA) | 20 pts | **1 pts** | 1 - Critical | 8.0h |
| | **PBI-07** | Testes Unitários da Camada de Aplicação com Mocking de Dependências (Moq) | 15 pts | **1 pts** | 1 - Critical | 8.0h |
| | **PBI-08** | Testes de Integração de Endpoints HTTP com WebApplicationFactory & Fixtures | 15 pts | **3 pts** | 1 - Critical | 10.0h |
| **[FEATURE 04] Documentação** | **PBI-09** | Atualização da Documentação Técnica (README.md, Health Checks, Testes e OpenAPI) | 10 pts | **1 pts** | 2 - High | 3.0h |
| **TOTAL CONSOLIDADO** | **4 Features** | **9 PBIs / 33 Child Tasks Técnicas** | **100 pts Oficiais** | **13 pts** | — | **62.0h** |

---

## 📦 4. Detalhamento dos Itens de Trabalho (Épico, Features, PBIs e Tasks)

---

### 🏛️ ÉPICO
* **Work Item Type:** `Epic`
* **Title:** `[EPIC] Sprint 3 - .NET & Observabilidade: Plataforma .NET de Cuidado Animal Pet-Centric, Observabilidade e Testes AAA`
* **Tags:** `Sprint3, DotNet, Observabilidade, HealthChecks, Serilog, OpenTelemetry, xUnit, WebApplicationFactory, CleanArchitecture`
* **Start Date:** `2026-08-24`
* **Target Date:** `2026-08-29`
* **Priority:** `1 - Critical`
* **Effort (Story Points):** `13`
* **Business Value:** `100`
* **Description:** Evolução corporativa da plataforma ASP.NET Core PetGuardian alinhada à refatoração do banco de dados relacional em 3FN e ao ecossistema, iniciando pela consolidação das operações de atualização (PUT), incorporando monitoramento de integridade via Health Checks, logging estruturado correlacionado com Serilog, telemetria distribuída e métricas com OpenTelemetry, e suíte completa de testes automatizados unitários e de integração no padrão AAA.

---

### 🏆 [FEATURE 01] Refatoração e Implementação Completa do CRUD (Operações de Update / PUT)
* **Work Item Type:** `Feature`
* **Parent:** `[EPIC] Sprint 3 - .NET & Observabilidade: Plataforma .NET de Cuidado Animal Pet-Centric, Observabilidade e Testes AAA`
* **Title:** `[FEATURE 01] Refatoração e Implementação Completa do CRUD (Operações de Update / PUT)`
* **Tags:** `Sprint3, DotNet, CRUD, PUT, DomainDrivenDesign, EntityFrameworkCore, 3FN`
* **Start Date:** `2026-08-24`
* **Target Date:** `2026-08-25`
* **Priority:** `1 - Critical`
* **Effort (Story Points):** `3`
* **Description:** Completar o ciclo RESTful da API fornecendo endpoints de atualização (PUT), validação de dados, métodos de negócio em entidades de domínio Pet-Centric e persistência no banco de dados Oracle via Entity Framework Core em conformidade rigorosa com o modelo 3FN refatorado, servindo de base para os testes de integração e a disciplina integrada de DevOps.

#### 🔹 [PBI-01] Implementação de Atualização (PUT) e Governança Pet-Centric para Pet e Usuário
* **Work Item Type:** `Product Backlog Item`
* **Parent Feature:** `[FEATURE 01] Refatoração e Implementação Completa do CRUD (Operações de Update / PUT)`
* **State:** `Approved`
* **Priority:** `1 - Critical`
* **Effort (Story Points):** `1`
* **Tags:** `Sprint3, DotNet, Pet, Usuario, CRUD, PUT, Domain`

##### Descrição (História de Usuário)
> **Como** tutor participante da rede familiar de cuidado animal (Care Circle),  
> **Eu quero** atualizar os dados cadastrais do meu perfil e as informações do meu Pet (nome, idade, porte, sexo, raça e castração) via verbos HTTP PUT,  
> **Para que** os dados clínicos e cadastrais do animal reflitam com precisão o modelo relacional 3FN da plataforma.

##### Critérios de Aceite (Acceptance Criteria / Definition of Done)
- [ ] O endpoint `PUT /api/Pet/{id}` aceita payload com dados atualizáveis em conformidade com o esquema 3FN (`Nome`, `Idade`, `Sexo`, `Porte`, `Castrado`, `RacaId`).
- [ ] Se o Pet não existir, o endpoint retorna HTTP 404 Not Found.
- [ ] Invariantes de domínio respeitadas em `Pet.cs`: idade entre 0 e 99 anos, nome não vazio com até 30 caracteres, raça válida, porte normalizado (`PEQUENO`, `MEDIO`, `GRANDE`) e sexo (`M`/`F`). Em caso de violação, retornar HTTP 400 Bad Request.
- [ ] O endpoint `PUT /api/Usuario/{id}` permite alterar `Nome` e `TelefoneId`, mantendo integridade do e-mail e hash seguro da senha.
- [ ] Resposta HTTP 200 OK com DTO atualizado (`PetResponse`, `UsuarioResponse`).
- [ ] Persistência mapeada com o banco Oracle via `PetGuardianContext` e configurações do EF Core.

##### Tarefas Técnicas (Child Tasks)
* **Task 1.1:** [TASK-01] Atualização dos Modelos de Domínio 3FN e Invariantes (Pet & Usuario). *(Activity: Development, Est: 2.0h)*
  * *Descrição:* Criar e validar métodos de negócio em `Pet.cs` e `Usuario.cs` para atualizar campos de forma encapsulada com proteção de invariantes.
* **Task 1.2:** [TASK-02] Criação dos DTOs de Update e Mapeamentos com Data Annotations. *(Activity: Development, Est: 1.5h)*
  * *Descrição:* Criar `PetUpdateRequest.cs` e `UsuarioUpdateRequest.cs` na camada `PetGuardian.Application.DTOs` com validações declarativas.
* **Task 1.3:** [TASK-03] Implementação dos Métodos de Update nos Services e Repositórios EF Core. *(Activity: Development, Est: 2.0h)*
  * *Descrição:* Atualizar `IPetService`, `IUsuarioService` e suas implementações persistindo alterações via Entity Framework Core.
* **Task 1.4:** [TASK-04] Exposição dos Endpoints PUT nos Controllers (PetController & UsuarioController). *(Activity: Development, Est: 1.5h)*
  * *Descrição:* Adicionar métodos `[HttpPut("{id:guid}")]` com anotações `[ProducesResponseType]`, validação de ModelState e documentação Swagger.

---

#### 🔹 [PBI-02] Implementação de Atualização (PUT) para Tarefa, Endereço e Rede de Cuidado
* **Work Item Type:** `Product Backlog Item`
* **Parent Feature:** `[FEATURE 01] Refatoração e Implementação Completa do CRUD (Operações de Update / PUT)`
* **State:** `Approved`
* **Priority:** `1 - Critical`
* **Effort (Story Points):** `2`
* **Tags:** `Sprint3, DotNet, Tarefa, Endereco, UsuarioPet, CRUD, PUT`

##### Descrição (História de Usuário)
> **Como** tutor familiar participante da Rede de Cuidado do Pet (Care Circle),  
> **Eu quero** atualizar os detalhes de tarefas da rotina do pet (título, descrição, prazo, pontos) e dados de endereço residencial via verbos HTTP PUT,  
> **Para que** o planejamento de cuidados, prazos de rotina e a localização do tutor sejam mantidos íntegros na base de dados 3FN.

##### Critérios de Aceite (Acceptance Criteria / Definition of Done)
- [ ] Endpoints `PUT /api/Tarefa/{id}`, `PUT /api/Endereco/{id}` e `PUT /api/UsuarioPet/responsavel-principal` implementados e funcionais.
- [ ] Validações de integridade referencial mantidas conforme o esquema físico 3FN (`UsuarioId`, `PetId`, `StatusId`, `BairroId`).
- [ ] Invariantes de negócio aplicadas: tarefas não podem ter prazo retroativo (`Prazo > DateTime.UtcNow`), pontos positivos (`Pontos > 0`), título (até 30 caracteres) e descrição não vazios. Tarefas com status `CONCLUIDO` ou `EXPIRADO` não podem ser alteradas. Endereço exige CEP válido (8 dígitos), rua e número.
- [ ] Retorno 200 OK com dados atualizados no formato de DTO correspondente (`TarefaResponse`, `EnderecoResponse`) e 404 Not Found caso o identificador não exista.

##### Tarefas Técnicas (Child Tasks)
* **Task 2.1:** [TASK-05] Criação dos DTOs de Update para Tarefa e Endereço. *(Activity: Development, Est: 2.0h)*
  * *Descrição:* Criar `TarefaUpdateRequest` e `EnderecoUpdateRequest` com restrições do modelo 3FN.
* **Task 2.2:** [TASK-06] Implementação dos Métodos de Atualização nas Entidades e Serviços de Aplicação. *(Activity: Development, Est: 3.0h)*
  * *Descrição:* Adicionar métodos encapsulados de atualização em `TarefaService`, `EnderecoService` e `UsuarioPetService`.
* **Task 2.3:** [TASK-07] Adição dos Endpoints PUT nos Controllers Correspondentes e Validação Swagger. *(Activity: Development, Est: 2.0h)*
  * *Descrição:* Atualizar `TarefaController`, `EnderecoController` e `UsuarioPetController` com `[HttpPut("{id:guid}")]`.

---

### 🏆 [FEATURE 02] Monitoramento, Observabilidade e Diagnóstico da Aplicação
* **Work Item Type:** `Feature`
* **Parent:** `[EPIC] Sprint 3 - .NET & Observabilidade: Plataforma .NET de Cuidado Animal Pet-Centric, Observabilidade e Testes AAA`
* **Title:** `[FEATURE 02] Monitoramento, Observabilidade e Diagnóstico da Aplicação`
* **Tags:** `Sprint3, DotNet, Observabilidade, HealthChecks, Serilog, OpenTelemetry, Metrics`
* **Start Date:** `2026-08-25`
* **Target Date:** `2026-08-27`
* **Priority:** `1 - Critical`
* **Effort (Story Points):** `4`
* **Description:** Implementar a infraestrutura completa de observabilidade corporativa exigida no edital oficial (40 pts), incluindo verificação de saúde (Health Checks para API e banco Oracle), registro em log estruturado correlacionado por requisição (Serilog com Correlation ID) e rastreamento distribuído com métricas de desempenho (OpenTelemetry).

#### 🔹 [PBI-03] Implementação de Health Checks Corporativos (API & Oracle Database)
* **Work Item Type:** `Product Backlog Item`
* **Parent Feature:** `[FEATURE 02] Monitoramento, Observabilidade e Diagnóstico da Aplicação`
* **State:** `Approved`
* **Priority:** `1 - Critical`
* **Effort (Story Points):** `1`
* **Tags:** `Sprint3, DotNet, HealthChecks, Oracle, Diagnostics, Availability`

##### Descrição (História de Usuário)
> **Como** engenheiro de DevOps e sustentação do sistema PetGuardian,  
> **Eu quero** que a API exponha endpoints padronizados de verificação de saúde (`/health`, `/health/ready`, `/health/live`),  
> **Para que** orquestradores em nuvem (Azure Container Apps, ACI, App Service) identifiquem instantaneamente a disponibilidade da aplicação e a integridade da conexão com o banco Oracle.

##### Critérios de Aceite (Acceptance Criteria / Definition of Done)
- [ ] Utilização dos pacotes oficiais `Microsoft.Extensions.Diagnostics.HealthChecks` e `Microsoft.Extensions.Diagnostics.HealthChecks.EntityFrameworkCore`.
- [ ] Endpoint `/health` configurado retornando status HTTP 200 OK (`Healthy`) ou 503 Service Unavailable (`Unhealthy`).
- [ ] Verificação de conectividade ativa com o banco de dados Oracle (`PetGuardianContext`) com timeout configurado.
- [ ] Endpoints segregados de diagnóstico: Liveness (`/health/live`) e Readiness (`/health/ready`).
- [ ] Resposta em formato JSON estruturado com status geral, status individual de cada verificação, tempo de execução (`duration`) e timestamp.

##### Tarefas Técnicas (Child Tasks)
* **Task 3.1:** [TASK-08] Instalação e Configuração dos Pacotes NuGet de Health Checks. *(Activity: Development, Est: 1.0h)*
  * *Descrição:* Adicionar `Microsoft.Extensions.Diagnostics.HealthChecks`, `Microsoft.Extensions.Diagnostics.HealthChecks.EntityFrameworkCore` e utilitários de resposta.
* **Task 3.2:** [TASK-09] Implementação de Health Check de Conectividade para Oracle DB. *(Activity: Development, Est: 2.0h)*
  * *Descrição:* Configurar `AddDbContextCheck<PetGuardianContext>()` executando validação de conectividade no banco de dados.
* **Task 3.3:** [TASK-10] Configuração dos Endpoints (/health, /health/ready, /health/live) no Program.cs. *(Activity: Development, Est: 2.0h)*
  * *Descrição:* Mapear rotas de monitoramento com formatador JSON estruturado contendo status, dependências e duração.
* **Task 3.4:** [TASK-11] Teste de Validação dos Health Checks em Estados Saudável e Degradado. *(Activity: Testing, Est: 1.0h)*
  * *Descrição:* Validar retorno 200 OK em estado operacional e 503 Service Unavailable simulando queda do banco de dados.

---

#### 🔹 [PBI-04] Logging Estruturado com Serilog, Níveis de Log e Correlation ID
* **Work Item Type:** `Product Backlog Item`
* **Parent Feature:** `[FEATURE 02] Monitoramento, Observabilidade e Diagnóstico da Aplicação`
* **State:** `Approved`
* **Priority:** `1 - Critical`
* **Effort (Story Points):** `1`
* **Tags:** `Sprint3, DotNet, Serilog, Logging, CorrelationID, StructuredLogs`

##### Descrição (História de Usuário)
> **Como** desenvolvedor backend e operador de infraestrutura,  
> **Eu quero** logs estruturados em formato JSON/Console/Arquivo e um Correlation ID exclusivo por requisição,  
> **Para que** eu possa rastrear todo o ciclo de vida de uma transação entre as camadas da aplicação e diagnosticar erros rapidamente em produção.

##### Critérios de Aceite (Acceptance Criteria / Definition of Done)
- [ ] Serilog configurado no `Program.cs` substituindo o provedor de log padrão do .NET.
- [ ] Suporte aos níveis de severidade: `Information`, `Warning` e `Error`.
- [ ] Saída dupla configurada: Console formatado e Arquivo com rotação diária (`logs/petguardian-.log`) e política de retenção configurada no `appsettings.json`.
- [ ] `CorrelationIdMiddleware` implementado interceptando o cabeçalho `X-Correlation-ID` (ou gerando novo Guid se ausente).
- [ ] O `CorrelationId` deve ser adicionado ao `LogContext` do Serilog e retornado no cabeçalho de resposta HTTP `X-Correlation-ID`.
- [ ] O middleware de tratamento de exceções global registra falhas com nível `Error`, Correlation ID, rota solicitada e stacktrace.

##### Tarefas Técnicas (Child Tasks)
* **Task 4.1:** [TASK-12] Instalação e Configuração do Serilog com Saída em Console e Arquivo Rotativo. *(Activity: Development, Est: 1.5h)*
  * *Descrição:* Instalar `Serilog.AspNetCore`, `Serilog.Sinks.Console`, `Serilog.Sinks.File` e `Serilog.Enrichers.Environment`.
* **Task 4.2:** [TASK-13] Implementação do Middleware de Correlação (CorrelationIdMiddleware). *(Activity: Development, Est: 2.0h)*
  * *Descrição:* Criar middleware interceptando `X-Correlation-ID`, injetando no `LogContext.PushProperty` e devolvendo no response header.
* **Task 4.3:** [TASK-14] Configuração de Sinks, Filtros e Formatação Estruturada no appsettings.json. *(Activity: Development, Est: 1.5h)*
  * *Descrição:* Definir configurações de Serilog com rolling interval diário e formatação limpa JSON.
* **Task 4.4:** [TASK-15] Integração dos Logs Estruturados nos Services e Middleware Global de Erros. *(Activity: Development, Est: 1.0h)*
  * *Descrição:* Injetar `ILogger<T>` nos serviços essenciais (`TarefaService`, `PetService`, `UsuarioPetService`, `EnderecoService`).

---

#### 🔹 [PBI-05] Distributed Tracing e Métricas de Performance com OpenTelemetry
* **Work Item Type:** `Product Backlog Item`
* **Parent Feature:** `[FEATURE 02] Monitoramento, Observabilidade e Diagnóstico da Aplicação`
* **State:** `Approved`
* **Priority:** `2 - High`
* **Effort (Story Points):** `2`
* **Tags:** `Sprint3, DotNet, OpenTelemetry, Tracing, Metrics, APM, ActivitySource`

##### Descrição (História de Usuário)
> **Como** arquiteto de software e engenheiro de confiabilidade (SRE),  
> **Eu quero** rastrear requisições através de Distributed Tracing e coletar métricas de desempenho (tempo de resposta, taxa de erros e throughput),  
> **Para que** gargalos de performance nas consultas e chamadas de serviço sejam identificados com precisão e transparência.

##### Critérios de Aceite (Acceptance Criteria / Definition of Done)
- [ ] Pacotes `OpenTelemetry.Extensions.Hosting`, `OpenTelemetry.Instrumentation.AspNetCore`, `OpenTelemetry.Instrumentation.Http` e `OpenTelemetry.Instrumentation.EntityFrameworkCore` configurados.
- [ ] Distributed Tracing instrumentando requisições HTTP de entrada e operações do Entity Framework Core.
- [ ] Métricas de desempenho expostas: tempo de resposta da requisição (`http.server.request.duration`), taxa de erros e contadores customizados.
- [ ] Instrumentação customizada de métricas de negócio via `Meter` e `ActivitySource` (ex: `tarefas_concluidas_total`, `pets_cadastrados_total`).
- [ ] Exportador configurado (Console Exporter ou endpoint de métricas).
- [ ] Spans nomeados adequadamente refletindo a operação e as camadas executadas.

##### Tarefas Técnicas (Child Tasks)
* **Task 5.1:** [TASK-16] Adição das Dependências do OpenTelemetry no Projeto da API. *(Activity: Development, Est: 1.5h)*
  * *Descrição:* Instalar pacotes NuGet do OpenTelemetry para ASP.NET Core, HTTP e Entity Framework Core.
* **Task 5.2:** [TASK-17] Configuração de Tracing para ASP.NET Core e EF Core no Program.cs. *(Activity: Development, Est: 2.5h)*
  * *Descrição:* Configurar `builder.Services.AddOpenTelemetry()` com `.WithTracing(...)` e `.WithMetrics(...)` no pipeline.
* **Task 5.3:** [TASK-18] Instrumentação Customizada de Métricas de Negócio (ActivitySource & Meter). *(Activity: Development, Est: 2.0h)*
  * *Descrição:* Criar contadores de métricas customizados para acompanhar tarefas concluídas e pets registrados.
* **Task 5.4:** [TASK-19] Teste e Validação da Emissão de Spans e Coleta de Métricas. *(Activity: Testing, Est: 1.0h)*
  * *Descrição:* Executar requisições de teste na API e validar a propagação correta dos spans e agregação de métricas.

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
* **Description:** Implementação de suíte abrangente de testes automatizados com cobertura rigorosa das camadas de Domínio e Aplicação (testes unitários com Moq) e testes de integração de ponta a ponta para os endpoints da API com WebApplicationFactory e Fixtures no padrão Arrange, Act, Assert (AAA).

#### 🔹 [PBI-06] Estruturação dos Projetos de Teste e Testes Unitários de Domínio (AAA)
* **Work Item Type:** `Product Backlog Item`
* **Parent Feature:** `[FEATURE 03] Testes Automatizados no Padrão AAA com xUnit e WebApplicationFactory`
* **State:** `Approved`
* **Priority:** `1 - Critical`
* **Effort (Story Points):** `1`
* **Tags:** `Sprint3, DotNet, UnitTests, Domain, AAA, xUnit, FluentAssertions`

##### Descrição (História de Usuário)
> **Como** desenvolvedor de software,  
> **Eu quero** projetos de teste dedicados com testes unitários cobrindo as entidades e regras de domínio no padrão AAA,  
> **Para que** as invariantes de negócio da arquitetura Pet-Centric 3FN (idade, nome, porte, sexo, integridade de tarefas e vínculos N:N) permaneçam protegidas contra regressões.

##### Critérios de Aceite (Acceptance Criteria / Definition of Done)
- [ ] Criação dos projetos `PetGuardian.UnitTests` e `PetGuardian.IntegrationTests` adicionados à solution `PetGuardian.sln`.
- [ ] Todos os testes unitários seguem rigorosamente o padrão AAA (Arrange, Act, Assert) com blocos comentados.
- [ ] Nomenclatura uniforme e padronizada: `MetodoTestado_Cenario_ResultadoEsperado`.
- [ ] Cobertura completa de entidades do Domínio (`Pet`, `Usuario`, `UsuarioPet`, `Tarefa`, `Raca`, `Status`, `Endereco`, `Telefone`).
- [ ] Testes validando fluxos de sucesso e lançamento de `DomainException` em cenários de dados inválidos (ex: pet com idade negativa, nome vazio, tarefa com prazo retroativo, vínculo N:N com Guid vazio).

##### Tarefas Técnicas (Child Tasks)
* **Task 6.1:** [TASK-20] Criação e Configuração dos Projetos de Testes xUnit na Solution. *(Activity: Development, Est: 1.5h)*
  * *Descrição:* Criar `PetGuardian.UnitTests.csproj` e `PetGuardian.IntegrationTests.csproj` com referências a xunit, FluentAssertions e Microsoft.NET.Test.Sdk.
* **Task 6.2:** [TASK-21] Implementação dos Testes Unitários da Entidade Pet e Raça (AAA). *(Activity: Testing, Est: 2.0h)*
  * *Descrição:* Cobrir criação com dados válidos, atualização de idade, porte, sexo, castração e lançamento de `DomainException`.
* **Task 6.3:** [TASK-22] Implementação dos Testes Unitários de Usuario, UsuarioPet e Tarefa (AAA). *(Activity: Testing, Est: 2.5h)*
  * *Descrição:* Testar validação de e-mail, senha, vínculo N:N de co-cuidadores (`UsuarioPet`), método `Concluir` de tarefas e extensão de prazos.
* **Task 6.4:** [TASK-23] Implementação dos Testes Unitários de Endereço, Bairro, Cidade e Telefone (AAA). *(Activity: Testing, Est: 2.0h)*
  * *Descrição:* Testar construtores, métodos de atualização de dados, formato de CEP e integridade de referências.

---

#### 🔹 [PBI-07] Testes Unitários da Camada de Aplicação com Mocking de Dependências (Moq)
* **Work Item Type:** `Product Backlog Item`
* **Parent Feature:** `[FEATURE 03] Testes Automatizados no Padrão AAA com xUnit e WebApplicationFactory`
* **State:** `Approved`
* **Priority:** `1 - Critical`
* **Effort (Story Points):** `1`
* **Tags:** `Sprint3, DotNet, UnitTests, ApplicationServices, Moq, Mocking`

##### Descrição (História de Usuário)
> **Como** desenvolvedor de software,  
> **Eu quero** testar os serviços da camada de aplicação (`PetService`, `TarefaService`, `UsuarioPetService`, `EnderecoService`, `UsuarioService`) utilizando mocks para os repositórios com Moq,  
> **Para que** a orquestração de regras de negócio, histórico consolidado, convites por e-mail e regras de conclusão de tarefas sejam validadas de forma isolada e rápida.

##### Critérios de Aceite (Acceptance Criteria / Definition of Done)
- [ ] Uso do framework `Moq` para simulação de todos os repositórios e dependências de acesso a dados.
- [ ] Testes abrangentes do método `TarefaService.Concluir` (usuário não cadastrado, tarefa já concluída, sucesso na conclusão com atribuição de executor e status `CONCLUIDO`).
- [ ] Testes do método `PetService.GetHistorico` validando a recuperação cronológica de tarefas concluídas e eventos do pet (`PetHistoricoItemResponse`).
- [ ] Testes do `UsuarioPetService`: convite por e-mail (`InviteByEmail`), validação de Responsável Principal e agregação da Rede de Cuidado (`GetRedeCuidadoByUsuarioId`).
- [ ] Testes de CRUD completo para `UsuarioService` e `EnderecoService`.

##### Tarefas Técnicas (Child Tasks)
* **Task 7.1:** [TASK-24] Configuração do Moq e Estruturação de Fixtures de Testes de Serviços. *(Activity: Development, Est: 1.5h)*
  * *Descrição:* Configurar pacote `Moq` no projeto de testes e criar fixtures para injeção rápida de mocks de repositórios.
* **Task 7.2:** [TASK-25] Implementação de Testes Unitários para TarefaService (Conclusão e Gamificação). *(Activity: Testing, Est: 2.5h)*
  * *Descrição:* Testar todos os ramos de decisão do método `Concluir`, validação de executores e listagens filtradas por pet/usuário/status.
* **Task 7.3:** [TASK-26] Implementação de Testes Unitários para PetService e Linha do Tempo Histórica. *(Activity: Testing, Est: 2.0h)*
  * *Descrição:* Testar fluxos de cadastro de pets, busca por raça e montagem do histórico consolidado de tarefas e eventos.
* **Task 7.4:** [TASK-27] Implementação de Testes Unitários para UsuarioPetService e EnderecoService. *(Activity: Testing, Est: 2.0h)*
  * *Descrição:* Testar convites colaborativos por e-mail, verificação de responsável principal, montagem da `RedeCuidadoResponse` e atualização de endereço.

---

#### 🔹 [PBI-08] Testes de Integração de Endpoints HTTP com WebApplicationFactory & Fixtures
* **Work Item Type:** `Product Backlog Item`
* **Parent Feature:** `[FEATURE 03] Testes Automatizados no Padrão AAA com xUnit e WebApplicationFactory`
* **State:** `Approved`
* **Priority:** `1 - Critical`
* **Effort (Story Points):** `3`
* **Tags:** `Sprint3, DotNet, IntegrationTests, WebApplicationFactory, Endpoints, HTTP`

##### Descrição (História de Usuário)
> **Como** desenvolvedor e responsável por QA,  
> **Eu quero** testes de integração ponta a ponta executando contra o pipeline HTTP real da API via `WebApplicationFactory`,  
> **Para que** todo o ciclo de vida HTTP (roteamento, validação de ModelState, injeção de dependências, tratamento de exceções global e respostas 200/201/204/400/404) seja homologado antes do deploy.

##### Critérios de Aceite (Acceptance Criteria / Definition of Done)
- [ ] Projeto `PetGuardian.IntegrationTests` configurado com `Microsoft.AspNetCore.Mvc.Testing` (`WebApplicationFactory<Program>`).
- [ ] Implementação de `CustomWebApplicationFactory` com banco em memória (`UseInMemoryDatabase` ou SQLite) para execução isolada e determinística.
- [ ] Uso de Fixtures e Collection Fixtures (`IClassFixture`, `ICollectionFixture`) para compartilhamento otimizado de contexto.
- [ ] Testes de integração cobrindo os fluxos principais (`POST /api/Pet`, `PUT /api/Pet/{id}`, `GET /api/Pet/{id}`, `GET /api/Pet/{id}/historico`, `DELETE /api/Pet/{id}`, `POST /api/UsuarioPet/invite/by-email`, `GET /api/UsuarioPet/rede-cuidado/{usuarioId}`, `POST /api/Tarefa`, `PUT /api/Tarefa/{id}`, `POST /api/Tarefa/{id}/concluir`, `PUT /api/Endereco/{id}`, `ProblemDetails`).

##### Tarefas Técnicas (Child Tasks)
* **Task 8.1:** [TASK-28] Configuração da CustomWebApplicationFactory com Banco In-Memory Isolado. *(Activity: Development, Est: 2.5h)*
  * *Descrição:* Criar a classe `CustomWebApplicationFactory<TProgram>` customizando `ConfigureServices` para substituir o DbContext por banco em memória.
* **Task 8.2:** [TASK-29] Criação de Test Fixtures e Coleções Compartilhadas do xUnit. *(Activity: Development, Est: 2.0h)*
  * *Descrição:* Criar classes de Fixture (`IntegrationTestFixture`) e anotação `[CollectionDefinition("IntegrationTests")]` para reutilização de cliente HTTP.
* **Task 8.3:** [TASK-30] Implementação dos Testes de Integração de PetController e UsuarioPetController. *(Activity: Testing, Est: 2.5h)*
  * *Descrição:* Testar endpoints de CRUD e rede de cuidado, validando status codes, headers e respostas JSON.
* **Task 8.4:** [TASK-31] Implementação dos Testes de Integração de TarefaController, EnderecoController e Erros. *(Activity: Testing, Est: 3.0h)*
  * *Descrição:* Testar fluxos de conclusão de tarefa, atualização de rotina, endereços e validação de payloads de erro `ProblemDetails`.

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
* **Description:** Estruturação e publicação da documentação técnica no `README.md`, incluindo instruções de build, execução de testes unitários/integração no padrão AAA, visualização de Health Checks, métricas OpenTelemetry e documentação interativa OpenAPI/Swagger.

#### 🔹 [PBI-09] Atualização da Documentação Técnica (README.md, Health Checks, Testes e OpenAPI)
* **Work Item Type:** `Product Backlog Item`
* **Parent Feature:** `[FEATURE 04] Documentação Técnica, Guias de Execução e Atualização do README`
* **State:** `Approved`
* **Priority:** `2 - High`
* **Effort (Story Points):** `1`
* **Tags:** `Sprint3, DotNet, Documentation, README, OpenAPI, Swagger`

##### Descrição (História de Usuário)
> **Como** professor avaliador e desenvolvedor da equipe,  
> **Eu quero** um README.md completo e detalhado no repositório GitHub,  
> **Para que** qualquer pessoa consiga clonar o repositório, executar a suíte de testes automatizados (`dotnet test`), inspecionar os endpoints no Swagger e validar os Health Checks e métricas da API.

##### Critérios de Aceite (Acceptance Criteria / Definition of Done)
- [ ] Seção detalhada sobre a arquitetura da solução (Domain-Driven Design simplificado em 4 camadas: Domain, Application, Infrastructure, API).
- [ ] Alinhamento documentado com o modelo relacional 3FN da plataforma.
- [ ] Comandos para restaurar dependências, compilar e executar a API (`dotnet run --project PetGuardian.API`).
- [ ] Instruções para execução dos testes unitários e de integração (`dotnet test --verbosity normal`).
- [ ] Documentação dos endpoints de Observabilidade (`/health`, `/health/ready`, `/health/live`, `/metrics`).
- [ ] Instruções de acesso ao Swagger UI (`/swagger/index.html`).

##### Tarefas Técnicas (Child Tasks)
* **Task 9.1:** [TASK-32] Redação do Guia de Execução, Arquitetura DDD 3FN e Observabilidade no README.md. *(Activity: Documentation, Est: 1.5h)*
  * *Descrição:* Detalhar arquitetura da aplicação em camadas, endpoints de monitoramento e passos para execução local.
* **Task 9.2:** [TASK-33] Documentação de Comandos de Testes Automatizados (dotnet test) e Evidências. *(Activity: Documentation, Est: 1.5h)*
  * *Descrição:* Descrever como rodar a suíte xUnit de testes unitários e de integração no terminal com exemplos de saída.
