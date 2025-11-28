# 🌐 Cadastro de Alunos (Backend API)

Este projeto contém a **API RESTful** do sistema de Cadastro de Alunos, construída usando a plataforma **.NET 8** e a linguagem **C#**.

A API é responsável pela lógica de negócios, autenticação e persistência de dados no banco de dados.

## 🚀 Stack Tecnológico

![Stack Completo do Projeto Full Stack: ASP.NET Core, React, Entity Framework, Axios, Visual Studio, VS Code.](Anexos/tecnologias.png)

| Tecnologia | Função | Pacote (Versão) |
| :--- | :--- | :--- |
| **Framework Base** | [cite_start]**ASP.NET Core** na plataforma **.NET 8.0**. | - |
| **Autenticação** | [cite_start]Implementação de **JWT Bearer Token** e **ASP.NET Identity**. | `JwtBearer` / `Identity.EFCore` |
| **ORM** | [cite_start]**Entity Framework Core** para mapeamento objeto-relacional. | - |
| **Banco de Dados** | [cite_start]**SQL Server**. | `EFCore.SqlServer` |
| **Documentação** | [cite_start]**Swagger/OpenAPI** para documentação interativa dos endpoints. | `Swashbuckle.AspNetCore` |

---

### 🔑 Fluxo de Autenticação e Login

![Diagrama do Fluxo de Login, mostrando a comunicação do React via Axios com a API e SQL Server.](Anexos/estrutura.png)

---

## 🔑 Rotas Principais da API

A API segue o padrão REST e utiliza autenticação via **Bearer Token** (JWT) para todas as operações de gerenciamento de dados (`Alunos`).

| Rota | Método | Descrição | Status |
| :--- | :--- | :--- | :--- |
| `/api/Account/LoginUser` | `POST` | Autentica o usuário e retorna o JWT. | **PÚBLICA** |
| `/api/alunos` | `GET` | Lista todos os alunos cadastrados. | **PROTEGIDA** |
| `/api/alunos` | `POST` | Cria um novo registro de aluno. | **PROTEGIDA** |
| `/api/alunos/{id}` | `GET` | Obtém detalhes de um aluno específico. | **PROTEGIDA** |
| `/api/alunos/{id}` | `PUT` | Atualiza os dados de um aluno. | **PROTEGIDA** |
| `/api/alunos/{id}` | `DELETE` | Exclui um aluno do sistema. | **PROTEGIDA** |

## 🛡️ Autenticação

** Authorization: `Bearer SEU_TOKEN_JWT_AQUI`

---
## 🛠️ Configuração Inicial

### Pré-requisitos

* **SDK do .NET 8.0** ou superior instalado.
* **Visual Studio 2022+** (Recomendado) ou **VS Code** com as extensões C#.
* Instância local do **SQL Server**.

### 1. Configuração do Banco de Dados

1.  **String de Conexão:** Abra o arquivo `appsettings.json` (ou `appsettings.Development.json`).
2.  **Ajuste:** Localize a seção `ConnectionStrings` e atualize o valor de `DefaultConnection` para apontar para sua instância local do SQL Server.

### 2. Migrações e Atualização do Banco

Use a **CLI do .NET** para aplicar as migrações e criar/atualizar o *schema* do banco de dados:

```bash
# Navegue até o diretório do projeto da API (onde está o AlunosApi.csproj)
dotnet ef database update
