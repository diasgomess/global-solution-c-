Este é um projeto de API RESTful desenvolvido com o objetivo de [Breve descrição do objetivo principal do seu projeto].

## 🚀 Status do Projeto

| Etapa | Status | Pontuação (Máx. 3.0) |
| :--- | :--- | :--- |
| **Modelagem do Domínio e Conexão** | ✅ Concluída | 3.0 |
| Próximas Etapas | ⏳ Em Andamento | N/A |

---

## 🎯 Requisitos da Etapa 6: Modelagem do Domínio

Esta primeira *branch* (documentada abaixo) foi criada para atender aos seguintes requisitos e pontos:

1. **Modelagem da Classe Prompt**: A entidade central do projeto foi modelada.
2. **Confirmação da Conexão com Banco de Dados**: Foi estabelecida e confirmada a conexão com o banco de dados utilizando a biblioteca **Dapper**.
3. **Criação de Branch Específica**: O trabalho desta etapa foi desenvolvido na *branch* `feature/modelagem-dominio`.

---

## 🛠️ Tecnologias Utilizadas

* **Linguagem:** [C# ou outra linguagem]
* **Framework:** [ASP.NET Core, Node.js/Express, etc.]
* **Banco de Dados:** [SQL Server, PostgreSQL, MySQL, etc.]
* **Mapeamento Objeto-Relacional (ORM):** **Dapper**

---

## 📂 Detalhes da Branch `feature/modelagem-dominio`

Esta seção documenta o trabalho realizado para completar a primeira etapa do projeto.

### 1. Modelagem da Classe `Prompt`

A classe **`Prompt`** foi modelada no arquivo `[Caminho do arquivo, ex: src/Models/Prompt.cs]`.

O modelo inclui os seguintes atributos:

| Atributo | Tipo | Descrição |
| :--- | :--- | :--- |
| `Id` | `[Tipo de dado]` | Identificador único do Prompt. |
| `Conteudo` | `string` | O texto principal do Prompt. |
| `DataCriacao` | `DateTime` | Data e hora em que o Prompt foi criado. |
| `[Outro Atributo]` | `[Tipo de dado]` | [Descrição] |

### 2. Conexão com Banco de Dados (Dapper)

A conexão com o banco de dados foi configurada e testada.

* **String de Conexão:** A *connection string* está armazenada e gerenciada no arquivo `[Caminho, ex: appsettings.json]`.
* **Implementação Dapper:** O Dapper foi integrado na camada de repositório (`[Caminho, ex: src/Repositories/PromptRepository.cs]`) para garantir consultas rápidas e diretas ao banco.
* **Teste de Conexão:** Uma função simples de teste (ex: `CheckConnection()` ou uma primeira consulta SELECT) foi executada com sucesso para confirmar o acesso.

### 3. Comandos Importantes da Branch

Para revisar as alterações desta etapa, você pode usar os seguintes comandos:

```bash
# Faz o checkout para a branch de modelagem
git checkout feature/modelagem-dominio

# Exibe o histórico de commits desta branch
git log feature/modelagem-dominio
