# BibliotecaAPI de Prompts (Prompt Management System)

## 🌟 Contexto do Projeto

Este projeto, inicialmente baseado em uma API de biblioteca, foi adaptado para funcionar como um **Sistema de Gerenciamento e Versionamento de Prompts** (Prompt Management System).

O cenário principal é o desenvolvimento de **Modelos de Inteligência Artificial (IA)**, onde a empresa necessita de uma solução para **versionar, rastrear e gerenciar** as diferentes strings de prompts utilizadas, garantindo reprodutibilidade e facilitando a experimentação e treinamento de modelos.

O recurso `Prompt` é a entidade central para rastrear: qual prompt foi usado, por quem (Autor), a qual categoria de modelo/problema ele se aplica e quando foi registrado.

---

## 💻 Estrutura e Tecnologias

O projeto é construído em **ASP.NET Core** (C#) e segue o padrão MVC/Service Layer.

### Entidades Principais

| Entidade | Descrição |
| :--- | :--- |
| **Prompt** | Objeto central que armazena a string do prompt (`Conteudo`), o `Titulo`, o `Autor` e a `Categoria`. |
| **Categoria** | Enumeração usada para classificar o tipo de modelo ou problema (ex: FICCAO, TECNICO, DIDATICO). |

### Camadas

1.  **Models (BibliotecaAPI.Models):** Contém as classes de dados (`Prompt`) e o enum (`Categoria`).
2.  **Services (BibliotecaAPI.Services):** Contém a lógica de negócios.
    * **PromptService:** Responsável por gerenciar os prompts. Atualmente usa uma **simulação em memória** (`List<Prompt>`) para armazenamento.
3.  **Controllers (BibliotecaAPI.Controllers):** Define os endpoints da API.
    * **PromptsController:** Manipula as requisições HTTP (GET, POST) para a entidade `Prompt`.

---

## 🛠️ Funcionalidades Implementadas (Endpoints)

A API expõe os seguintes recursos na rota base `/api/prompts`:

| Método | Rota | Descrição | Status Codes |
| :--- | :--- | :--- | :--- |
| **GET** | `/api/prompts` | Lista todos os prompts cadastrados na memória. | 200 OK, 204 No Content |
| **POST** | `/api/prompts` | Cadastra um novo prompt. Garante a unicidade pelo **Título**. | 201 Created, 400 Bad Request |

### Lógica de Negócio Chave

* **Unicidade do Título:** O `PromptService` implementa uma validação para garantir que não existam dois prompts com o mesmo `Título` (case-insensitive), essencial para a versão do prompt.
* **Registro de Data:** A data de cadastro (`DataCadastro`) é definida automaticamente pelo serviço no momento da criação, servindo como registro de tempo (timestamp).

---

## 🚀 Como Executar o Projeto

1.  **Pré-requisitos:**
    * .NET SDK (versão compatível com ASP.NET Core).
2.  **Compilação e Execução:**
    ```bash
    # Navegue até o diretório raiz do projeto
    cd BibliotecaAPI
    
    # Execute a aplicação
    dotnet run
    ```
3.  **Acesso à API:**
    * A API estará disponível em `https://localhost:<port>` (a porta é definida em `launchSettings.json`).
    * O Swagger/OpenAPI estará disponível em `/swagger` para testar os endpoints.

---

## 💡 Próximos Passos (Evolução)

Para transformar a simulação em um sistema robusto:

1.  **Persistência de Dados:** Substituir a lista em memória por um banco de dados real (ex: SQL Server, PostgreSQL) usando **Entity Framework Core**.
2.  **Endpoints Adicionais:** Implementar `GET` por ID/Título, `PUT` (Atualizar Versão), e `DELETE`.
3.  **Versionamento Explícito:** Adicionar um campo de número de versão (ex: `Versao: 1.0.0`) na classe `Prompt` e criar lógica de `PUT` para incrementar a versão e/ou arquivar a versão antiga.
