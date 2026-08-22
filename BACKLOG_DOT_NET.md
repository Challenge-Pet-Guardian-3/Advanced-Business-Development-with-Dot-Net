# 📋 Backlog Master Azure Boards — Sprint 3 (.NET & Observabilidade)

> **Projeto:** PetGuardian — Plataforma Pet-Centric de Cuidado e Saúde Animal (Challenge Clyvo 2026)  
> **Disciplina:** Advanced Business Development with .NET (FIAP — 2º Ano ADS)  
> **Sprint:** 3ª Sprint (Refatoração CRUD, Monitoramento, Observabilidade & Testes Automatizados AAA)  
> **Referência Oficial:** Manual do Challenge 2026 — Páginas 07 e 08  
> **Diretrizes da Mentoria Clyvo:** Arquitetura Pet-Centric (Score e Nível no Pet, Rotina Familiar, Clínicas 24h)  
> **Sequência Estratégica:** 1º Refatoração CRUD (PUT) ➔ 2º Observabilidade ➔ 3º Testes AAA ➔ 4º Documentação  
> **Padrão:** Scrum Process Template (Azure DevOps / Azure Boards)

---

## 🎯 1. Diagnóstico e Matriz Oficial de Avaliação da Sprint 3 (Páginas 07 e 08)

Conforme estabelecido nas **páginas 07 e 08 do manual oficial**, a sprint combina a **1ª AÇÃO de Refatoração do CRUD (PUT)** para estabilizar os contratos de dados e viabilizar os testes com os **3 pilares avaliativos oficiais (100 pontos)** da disciplina de .NET:

| Componente / Módulo | Pontuação Oficial | Itens Obrigatórios do Edital (Páginas 07 e 08) & Mentoria Clyvo | Status no Backlog |
| :--- | :---: | :--- | :--- |
| **1ª AÇÃO: Refatoração CRUD (PUT)** | *Base Técnica & DevOps* | • Implementação de verbos HTTP `PUT` em `Pet` (com `ScoreBemEstar`, `PesoAtual`), `Usuario`, `Tarefa`, `Atendimento` e `Clinica` (24h/emergência) com métodos de negócio encapsulados.<br>• Viabiliza os testes de integração e a demonstração de Update exigida na disciplina de DevOps. | **FEAT-01 (10 SP)** |
| **1. Monitoramento e Observabilidade** | **40 pts** | • **Health Checks (15 pts):** `/health`, `/health/ready` (Oracle DB) e `/health/live` via `Microsoft.Extensions.Diagnostics.HealthChecks`.<br>• **Logging Estruturado (10 pts):** Serilog (Info, Warning, Error), saída Console/Arquivo com rotação diária e Correlation ID (`X-Correlation-ID`).<br>• **Tracing e Métricas (15 pts):** OpenTelemetry (Distributed Tracing entre camadas e métricas de latência/erros). | **FEAT-02 (15 SP)** |
| **2. Testes Automatizados (Padrão AAA)** | **50 pts** | • **Testes Unitários (20 pts):** xUnit no padrão Arrange, Act, Assert com `Moq` para Domínio e Serviços de Aplicação.<br>• **Testes de Integração (15 pts):** `WebApplicationFactory` para homologação de endpoints HTTP reais, status codes (200, 201, 204, 400, 404) e tratamento global de erros.<br>• **Cobertura & Organização (15 pts):** Projetos segregados (`UnitTests`, `IntegrationTests`), nomenclatura padronizada e Fixtures de contexto compartilhado. | **FEAT-03 (18 SP)** |
| **3. Atualização do README.md** | **10 pts** | • Guia completo dos endpoints de Health Check e como monitorar a API.<br>• Instruções claras de execução dos testes (`dotnet test`).<br>• Descrição arquitetural das novas funcionalidades. | **FEAT-04 (2 SP)** |
| **TOTAL CONSOLIDADO** | **100 pts Oficiais** | **Foco Estrito na Sprint 3** *(Requisitos de Sprint 4 como MongoDB, HATEOAS, Paginação e JWT Identity mantidos para a próxima entrega).* | **45 Story Points** |

---

## 👑 2. Hierarquia Geral do Backlog no Azure Boards

```text
[EPIC-01] PetGuardian - Plataforma .NET de Cuidado Animal Pet-Centric (Sprint 3)
│
├── 🧹 [FEAT-01] Refatoração e Implementação Completa do CRUD (Operações de Update / PUT)
│   ├── [PBI-01] Implementação de Atualização (PUT) Pet-Centric para Pet e Usuário (5 pts)
│   └── [PBI-02] Implementação de Atualização (PUT) para Atendimento, Tarefa, Clínicas 24h e Cadastros (5 pts)
│
├── 🩺 [FEAT-02] Monitoramento, Observabilidade e Diagnóstico da Aplicação (40 pts)
│   ├── [PBI-03] Implementação de Health Checks Corporativos (API & Oracle Database) (5 pts)
│   ├── [PBI-04] Logging Estruturado com Serilog, Níveis de Log e Correlation ID (5 pts)
│   └── [PBI-05] Rastreamento Distribuído (Distributed Tracing) e Métricas com OpenTelemetry (5 pts)
│
├── 🧪 [FEAT-03] Testes Automatizados no Padrão AAA com xUnit e WebApplicationFactory (50 pts)
│   ├── [PBI-06] Estruturação dos Projetos de Teste e Testes Unitários de Domínio (AAA) (5 pts)
│   ├── [PBI-07] Testes Unitários da Camada de Aplicação com Mocking de Dependências (Moq) (5 pts)
│   └── [PBI-08] Testes de Integração de Endpoints HTTP com WebApplicationFactory & Fixtures (8 pts)
│
└── 📑 [FEAT-04] Documentação Técnica, Guias de Execução e Atualização do README (10 pts)
    └── [PBI-09] Atualização da Documentação Técnica (README.md, Health Checks, Testes e OpenAPI) (2 pts)
```

---

## 📊 3. Tabela Resumo do Backlog (Story Points & Prioridades)

| ID | Título do Item de Backlog (PBI) | Feature Pai | Pontuação Oficial | Story Points | Prioridade | Horas |
| :--- | :--- | :--- | :---: | :---: | :---: | :---: |
| **PBI-01** | Implementação de Atualização (PUT) Pet-Centric para Pet e Usuário | `[FEAT-01]` CRUD Update | Base / DevOps | **5 pts** | 1 - Critical | 7h |
| **PBI-02** | Implementação de Atualização (PUT) para Atendimento, Tarefa e Clínicas 24h | `[FEAT-01]` CRUD Update | Base / DevOps | **5 pts** | 1 - Critical | 7h |
| **PBI-03** | Health Checks Corporativos (API, Oracle DB e Serviços) | `[FEAT-02]` Observabilidade | 15 pts | **5 pts** | 1 - Critical | 6h |
| **PBI-04** | Logging Estruturado com Serilog, Console/Arquivo e Correlation ID | `[FEAT-02]` Observabilidade | 10 pts | **5 pts** | 1 - Critical | 6h |
| **PBI-05** | Distributed Tracing e Métricas de Performance com OpenTelemetry | `[FEAT-02]` Observabilidade | 15 pts | **5 pts** | 2 - High | 7h |
| **PBI-06** | Estruturação de Testes e Testes Unitários de Domínio (AAA) | `[FEAT-03]` Testes AAA | 20 pts *(c/ PBI-07)* | **5 pts** | 1 - Critical | 8h |
| **PBI-07** | Testes Unitários de Aplicação com Mocking (Moq / NSubstitute) | `[FEAT-03]` Testes AAA | *(incluso acima)* | **5 pts** | 1 - Critical | 8h |
| **PBI-08** | Testes de Integração de Endpoints com WebApplicationFactory & Fixtures | `[FEAT-03]` Testes AAA | 30 pts | **8 pts** | 1 - Critical | 10h |
| **PBI-09** | Atualização do README.md com Guias de Health Check, Testes e OpenAPI | `[FEAT-04]` Documentação | 10 pts | **2 pts** | 2 - High | 3h |
| **TOTAL** | **9 PBIs / 31 Child Tasks Técnicas** | **4 Features / 1 Epic** | **100 pts** | **45 pts** | — | **62h** |

---

## 📦 4. Detalhamento dos Itens de Trabalho (Épico, Features, PBIs e Tasks)

---

### 🏛️ ÉPICO
* **Work Item Type:** `Epic`
* **Title:** `[EPIC-01] PetGuardian - Plataforma .NET de Cuidado Animal Pet-Centric (Sprint 3)`
* **Description:** Evolução corporativa da plataforma ASP.NET Core PetGuardian iniciando pela consolidação das operações de atualização (PUT), incorporando monitoramento de saúde via Health Checks, logging estruturado correlacionado com Serilog, telemetria distribuída e métricas com OpenTelemetry, e suíte completa de testes automatizados unitários e de integração no padrão AAA.

---

### 🧹 FEATURE 01: Refatoração e Implementação Completa do CRUD (Operações de Update / PUT)
* **Work Item Type:** `Feature`
* **Parent:** `[EPIC-01] PetGuardian - Plataforma .NET de Cuidado Animal Pet-Centric (Sprint 3)`
* **Title:** `[FEAT-01] Refatoração e Implementação Completa do CRUD (Operações de Update / PUT)`
* **Description:** Completar o ciclo RESTful da API fornecendo endpoints de atualização (`PUT`), validação de dados, métodos de negócio em entidades de domínio Pet-Centric e persistência no banco de dados Oracle via Entity Framework Core, servindo de base para os testes de integração e a disciplina integrada de DevOps.

#### 🔹 [PBI-01] Implementação de Atualização (PUT) Pet-Centric para Pet e Usuário
* **Work Item Type:** `Product Backlog Item`
* **Parent Feature:** `[FEAT-01] Refatoração e Implementação Completa do CRUD (Operações de Update / PUT)`
* **State:** `Approved`
* **Priority:** `1 - Critical`
* **Effort (Story Points):** `5`
* **Tags:** `DotNet`, `API`, `CRUD`, `Domain`, `PetCentric`, `Sprint3`

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
* **Task 1.1: Atualização dos Modelos de Domínio e Invariantes (Pet & Usuario)** *(Estimativa: 2h)*
  * *Descrição:* Criar métodos de negócio em `Pet.cs` (`AtualizarDados(string nome, int idade, PortePet porte, bool castrado, Guid racaId)`) e `Usuario.cs` para atualizar campos de forma encapsulada com validação.
* **Task 1.2: Criação dos DTOs de Update e Mapeamentos** *(Estimativa: 1.5h)*
  * *Descrição:* Criar `PetUpdateRequest.cs` e `UsuarioUpdateRequest.cs` na camada `PetGuardian.Application.DTOs` com Data Annotations para validação de entrada.
* **Task 1.3: Implementação dos Métodos de Update nos Services e Repositórios** *(Estimativa: 2h)*
  * *Descrição:* Atualizar as interfaces `IPetService`, `IUsuarioService` e suas implementações para buscar a entidade existente, invocar o método de domínio, persistir via repositório EF Core e retornar o DTO atualizado.
* **Task 1.4: Exposição dos Endpoints PUT nos Controllers (`PetController` e `UsuarioController`)** *(Estimativa: 1.5h)*
  * *Descrição:* Adicionar métodos `[HttpPut("{id:guid}")]` com anotações `[ProducesResponseType]`, validação de `ModelState` e documentação XML comments.

---

#### 🔹 [PBI-02] Implementação de Atualização (PUT) para Atendimento, Tarefa, Clínicas 24h e Cadastros
* **Work Item Type:** `Product Backlog Item`
* **Parent Feature:** `[FEAT-01] Refatoração e Implementação Completa do CRUD (Operações de Update / PUT)`
* **State:** `Approved`
* **Priority:** `1 - Critical`
* **Effort (Story Points):** `5`
* **Tags:** `DotNet`, `API`, `CRUD`, `Services`, `Clinica24h`, `Sprint3`

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
* **Task 2.1: Criação dos DTOs de Update para Atendimento, Tarefa, Veterinário e Clínica** *(Estimativa: 2h)*
  * *Descrição:* Criar `AtendimentoUpdateRequest`, `TarefaUpdateRequest`, `VeterinarioUpdateRequest` e `ClinicaUpdateRequest` com regras de validação requeridas.
* **Task 2.2: Implementação dos Métodos de Atualização nas Entidades e Serviços de Aplicação** *(Estimativa: 3h)*
  * *Descrição:* Adicionar métodos de atualização em `AtendimentoService`, `TarefaService`, `VeterinarioService` e `ClinicaService`, validando chaves estrangeiras antes da persistência.
* **Task 2.3: Adição dos Endpoints PUT nos Controllers Correspondentes** *(Estimativa: 2h)*
  * *Descrição:* Atualizar `AtendimentoController`, `TarefaController`, `VeterinarioController` e `ClinicaController` com `[HttpPut("{id:guid}")]`, responses de Swagger e tipagens consistentes.

---

### 🩺 FEATURE 02: Monitoramento, Observabilidade e Diagnóstico da Aplicação (40 pts)
* **Work Item Type:** `Feature`
* **Parent:** `[EPIC-01] PetGuardian - Plataforma .NET de Cuidado Animal Pet-Centric (Sprint 3)`
* **Title:** `[FEAT-02] Monitoramento, Observabilidade e Diagnóstico da Aplicação`
* **Description:** Implementar a infraestrutura completa de observabilidade corporativa incluindo verificação de saúde (Health Checks), registro em log estruturado correlacionado por requisição (Serilog) e rastreamento distribuído com métricas de desempenho (OpenTelemetry).

#### 🔹 [PBI-03] Implementação de Health Checks Corporativos (API & Oracle Database)
* **Work Item Type:** `Product Backlog Item`
* **Parent Feature:** `[FEAT-02] Monitoramento, Observabilidade e Diagnóstico da Aplicação`
* **State:** `Approved`
* **Priority:** `1 - Critical`
* **Effort (Story Points):** `5`
* **Tags:** `DotNet`, `HealthChecks`, `Observability`, `Oracle`, `Sprint3`

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
* **Task 3.1: Instalação de Pacotes NuGet de Health Checks** *(Estimativa: 1h)*
  * *Descrição:* Adicionar `Microsoft.Extensions.Diagnostics.HealthChecks`, `Microsoft.Extensions.Diagnostics.HealthChecks.EntityFrameworkCore` e `AspNetCore.HealthChecks.UI.Client` no `PetGuardian.API`.
* **Task 3.2: Implementação de Health Check para Oracle DB** *(Estimativa: 2h)*
  * *Descrição:* Configurar `AddDbContextCheck<PetGuardianDbContext>()` ou `OracleDbHealthCheck` executando validação de conectividade leve no banco.
* **Task 3.3: Configuração dos Endpoints e Formatador JSON no `Program.cs`** *(Estimativa: 2h)*
  * *Descrição:* Mapear `/health`, `/health/ready` e `/health/live` com formatador JSON estruturado contendo detalhes de diagnóstico.
* **Task 3.4: Teste de Validação dos Health Checks em Sucesso e Falha** *(Estimativa: 1h)*
  * *Descrição:* Validar retornos 200 OK em estado normal e 503 Service Unavailable quando o banco for intencionalmente desconectado.

---

#### 🔹 [PBI-04] Logging Estruturado com Serilog, Níveis de Log e Correlation ID
* **Work Item Type:** `Product Backlog Item`
* **Parent Feature:** `[FEAT-02] Monitoramento, Observabilidade e Diagnóstico da Aplicação`
* **State:** `Approved`
* **Priority:** `1 - Critical`
* **Effort (Story Points):** `5`
* **Tags:** `DotNet`, `Serilog`, `Logging`, `CorrelationID`, `Sprint3`

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
* **Task 4.1: Instalação e Configuração dos Pacotes do Serilog** *(Estimativa: 1.5h)*
  * *Descrição:* Instalar `Serilog.AspNetCore`, `Serilog.Sinks.Console`, `Serilog.Sinks.File` e `Serilog.Enrichers.Environment`/`Thread`.
* **Task 4.2: Implementação do Middleware de Correlação (`CorrelationIdMiddleware`)** *(Estimativa: 2h)*
  * *Descrição:* Criar middleware interceptando `X-Correlation-ID`, injetando no `LogContext.PushProperty` e adicionando ao response header.
* **Task 4.3: Configuração de Sinks, Filtros e Rotação de Arquivos no `appsettings.json`** *(Estimativa: 1.5h)*
  * *Descrição:* Definir configurações de Serilog com rolling interval diário e formatação limpa.
* **Task 4.4: Integração dos Logs nos Services e Tratamento Global de Exceções** *(Estimativa: 1h)*
  * *Descrição:* Injetar `ILogger<T>` nos serviços essenciais (`TarefaService`, `PetService`, `AtendimentoService`) e enriquecer logs de falha.

---

#### 🔹 [PBI-05] Distributed Tracing e Métricas de Performance com OpenTelemetry
* **Work Item Type:** `Product Backlog Item`
* **Parent Feature:** `[FEAT-02] Monitoramento, Observabilidade e Diagnóstico da Aplicação`
* **State:** `Approved`
* **Priority:** `2 - High`
* **Effort (Story Points):** `5`
* **Tags:** `DotNet`, `OpenTelemetry`, `Tracing`, `Metrics`, `Sprint3`

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
* **Task 5.1: Adição de Dependências do OpenTelemetry na API** *(Estimativa: 1.5h)*
  * *Descrição:* Instalar pacotes NuGet do OpenTelemetry (`OpenTelemetry.Extensions.Hosting`, `OpenTelemetry.Instrumentation.AspNetCore`, `OpenTelemetry.Instrumentation.EntityFrameworkCore`, `OpenTelemetry.Exporter.Console`).
* **Task 5.2: Configuração de Tracing e Métricas no Pipeline de Injeção de Dependências** *(Estimativa: 2.5h)*
  * *Descrição:* Configurar `builder.Services.AddOpenTelemetry()` com `.WithTracing(...)` e `.WithMetrics(...)` no `Program.cs`.
* **Task 5.3: Instrumentação Customizada de Métricas de Negócio (ActivitySource & Meter)** *(Estimativa: 2h)*
  * *Descrição:* Criar contadores customizados (`tarefas_concluidas_total`, `atendimentos_criados_total`, `erros_negocio_total`) para métricas de negócio do PetGuardian.
* **Task 5.4: Teste e Validação da Emissão de Traces e Métricas** *(Estimativa: 1h)*
  * *Descrição:* Executar requisições de teste na API e validar a geração correta dos spans e coleta de métricas nos logs/console.

---

### 🧪 FEATURE 03: Testes Automatizados no Padrão AAA com xUnit e WebApplicationFactory (50 pts)
* **Work Item Type:** `Feature`
* **Parent:** `[EPIC-01] PetGuardian - Plataforma .NET de Cuidado Animal Pet-Centric (Sprint 3)`
* **Title:** `[FEAT-03] Testes Automatizados no Padrão AAA com xUnit e WebApplicationFactory`
* **Description:** Implementação de suíte abrangente de testes automatizados com cobertura das camadas de Domínio e Aplicação (testes unitários com Moq) e testes de integração de ponta a ponta para os endpoints da API com WebApplicationFactory e Fixtures.

#### 🔹 [PBI-06] Estruturação dos Projetos de Teste e Testes Unitários de Domínio (AAA)
* **Work Item Type:** `Product Backlog Item`
* **Parent Feature:** `[FEAT-03] Testes Automatizados no Padrão AAA com xUnit e WebApplicationFactory`
* **State:** `Approved`
* **Priority:** `1 - Critical`
* **Effort (Story Points):** `5`
* **Tags:** `DotNet`, `xUnit`, `UnitTests`, `Domain`, `AAA`, `Sprint3`

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
* **Task 6.1: Criação e Configuração dos Projetos de Testes no .NET** *(Estimativa: 1.5h)*
  * *Descrição:* Criar `PetGuardian.UnitTests.csproj` e `PetGuardian.IntegrationTests.csproj` instalando `xunit`, `xunit.runner.visualstudio`, `FluentAssertions` e `Microsoft.NET.Test.Sdk`.
* **Task 6.2: Implementação dos Testes Unitários da Entidade `Pet` (AAA)** *(Estimativa: 2h)*
  * *Descrição:* Cobrir criação com dados válidos, atualização de idade, peso, score de bem-estar e lançamento de exceções para limites inválidos.
* **Task 6.3: Implementação dos Testes Unitários da Entidade `Usuario` e `Tarefa` (AAA)** *(Estimativa: 2.5h)*
  * *Descrição:* Testar validação de e-mail, senha, métodos de conclusão de tarefas, atribuição de executor e transição de status.
* **Task 6.4: Implementação dos Testes Unitários de `Atendimento`, `Veterinario` e `Clinica` (AAA)** *(Estimativa: 2h)*
  * *Descrição:* Testar construtores, métodos de atualização de dados e validações de campos obrigatórios e flags 24h.

---

#### 🔹 [PBI-07] Testes Unitários da Camada de Aplicação com Mocking de Dependências (Moq)
* **Work Item Type:** `Product Backlog Item`
* **Parent Feature:** `[FEAT-03] Testes Automatizados no Padrão AAA com xUnit e WebApplicationFactory`
* **State:** `Approved`
* **Priority:** `1 - Critical`
* **Effort (Story Points):** `5`
* **Tags:** `DotNet`, `xUnit`, `Moq`, `ApplicationServices`, `AAA`, `Sprint3`

##### Descrição (História de Usuário)
> **Como** desenvolvedor de software,  
> **Eu quero** testar os serviços da camada de aplicação (`PetService`, `TarefaService`, `UsuarioService`, `AtendimentoService`) utilizando mocks para os repositórios,  
> **Para que** a orquestração de regras de negócio, cálculo de scores do pet e validações de existência sejam validadas de forma isolada e ultra-rápida.

##### Critérios de Aceite (Acceptance Criteria / Definition of Done)
- [ ] Uso do framework `Moq` (ou `NSubstitute`) para simulação de todos os repositórios e dependências.
- [ ] Testes do método `TarefaService.Concluir`:
  * Usuário não cadastrado (`InvalidOperationException`).
  * Usuário não pertencente ao círculo de cuidadores do pet (`InvalidOperationException`).
  * Tarefa já concluída previamente (`InvalidOperationException`).
  * Sucesso na conclusão com crédito de pontos no `Pet` e status `CONCLUIDO`.
- [ ] Testes do método `PetService.GetScore` validando o somatório de pontos e nível de saúde do Pet.
- [ ] Testes dos métodos de `Create`, `Update`, `GetById` e `Delete` de todos os serviços.

##### Tarefas Técnicas (Child Tasks)
* **Task 7.1: Configuração do Moq e Helpers de Teste de Serviços** *(Estimativa: 1.5h)*
  * *Descrição:* Configurar pacote `Moq` no projeto de testes e criar métodos utilitários/Builders para criação rápida de instâncias de teste.
* **Task 7.2: Implementação de Testes Unitários para `TarefaService` (Cenários Críticos)** *(Estimativa: 2.5h)*
  * *Descrição:* Testar todos os ramos de decisão do método `Concluir`, criação de tarefas com verificação de existência de Pet e Veterinário, e filtros de busca.
* **Task 7.3: Implementação de Testes Unitários para `PetService` e Score/Gamificação** *(Estimativa: 2h)*
  * *Descrição:* Testar fluxos de cadastro de pets, atualização de score de bem-estar e cálculo do nível de saúde.
* **Task 7.4: Implementação de Testes Unitários para `UsuarioService`, `ClinicaService` e `AtendimentoService`** *(Estimativa: 2h)*
  * *Descrição:* Testar operações de CRUD, listagens, histórico clínico consolidado e tratamento de entidades não encontradas.

---

#### 🔹 [PBI-08] Testes de Integração de Endpoints HTTP com WebApplicationFactory & Fixtures
* **Work Item Type:** `Product Backlog Item`
* **Parent Feature:** `[FEAT-03] Testes Automatizados no Padrão AAA com xUnit e WebApplicationFactory`
* **State:** `Approved`
* **Priority:** `1 - Critical`
* **Effort (Story Points):** `8`
* **Tags:** `DotNet`, `IntegrationTests`, `WebApplicationFactory`, `Fixtures`, `Sprint3`

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
* **Task 8.1: Configuração da `CustomWebApplicationFactory` e Banco In-Memory** *(Estimativa: 2.5h)*
  * *Descrição:* Criar a classe `CustomWebApplicationFactory<TProgram>` customizando `ConfigureServices` para usar `InMemoryDbContext` e semear dados básicos.
* **Task 8.2: Criação de Test Fixtures e Coleções do xUnit** *(Estimativa: 2h)*
  * *Descrição:* Criar classes de Fixture (`IntegrationTestFixture`, `DatabaseFixture`) e anotação `[CollectionDefinition("IntegrationTests")]`.
* **Task 8.3: Implementação dos Testes de Integração de `PetController` e `UsuarioController`** *(Estimativa: 2.5h)*
  * *Descrição:* Testar endpoints de CRUD completo (POST, GET, PUT, DELETE), validando status codes e corpo da resposta JSON.
* **Task 8.4: Implementação dos Testes de Integração de `TarefaController`, `AtendimentoController` e Erros Globais** *(Estimativa: 3h)*
  * *Descrição:* Testar fluxos de conclusão de tarefa, listagens com relacionamentos e validação de `ProblemDetails` para dados inválidos (400) e não encontrados (404).

---

### 📑 FEATURE 04: Documentação Técnica, Guias de Execução e Atualização do README (10 pts)
* **Work Item Type:** `Feature`
* **Parent:** `[EPIC-01] PetGuardian - Plataforma .NET de Cuidado Animal Pet-Centric (Sprint 3)`
* **Title:** `[FEAT-04] Documentação Técnica, Guias de Execução e Atualização do README`
* **Description:** Estruturação e publicação da documentação técnica no README.md, incluindo instruções de build, execução de testes unitários/integração, visualização de Health Checks e endpoints OpenAPI/Swagger.

#### 🔹 [PBI-09] Atualização da Documentação Técnica (README.md, Health Checks, Testes e OpenAPI)
* **Work Item Type:** `Product Backlog Item`
* **Parent Feature:** `[FEAT-04] Documentação Técnica, Guias de Execução e Atualização do README`
* **State:** `Approved`
* **Priority:** `2 - High`
* **Effort (Story Points):** `2`
* **Tags:** `DotNet`, `Documentation`, `README`, `OpenAPI`, `Sprint3`

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
* **Task 9.1: Redação do Guia de Execução, Arquitetura e Observabilidade no `README.md`** *(Estimativa: 1.5h)*
* **Task 9.2: Documentação de Comandos de Testes Automatizados e Evidências** *(Estimativa: 1.5h)*

---

## 🚀 5. Ordem Recomendada de Execução (Sprint Roadmap)

1. **Fase 1 — Refatoração e Operações de Update (`PUT`):** Executar `PBI-01` e `PBI-02`. Consolidar o CRUD completo no banco Oracle com as entidades Pet-Centric.
2. **Fase 2 — Camada de Observabilidade & Monitoramento (40 pts):** Executar `PBI-03` (Health Checks), `PBI-04` (Serilog + Correlation ID) e `PBI-05` (OpenTelemetry Tracing/Metrics).
3. **Fase 3 — Suíte de Testes Automatizados AAA (50 pts):** Executar `PBI-06` (Testes de Domínio), `PBI-07` (Testes de Aplicação com Moq) e `PBI-08` (Testes de Integração com WebApplicationFactory & Fixtures).
4. **Fase 4 — Documentação e Evidências (10 pts):** Executar `PBI-09` (README.md, Swagger e roteiro de execução).
