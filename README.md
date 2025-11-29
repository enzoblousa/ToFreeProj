# ToFree Projeto

![GitHub](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)
![GitHub](https://img.shields.io/badge/C%23-239120?logo=c-sharp&logoColor=white)
![GitHub](https://img.shields.io/badge/XUnit-2.5.0-0092E1?logo=xunit)
![GitHub](https://img.shields.io/badge/Status-%20Concluído-green)
![GitHub](https://img.shields.io/badge/Testes-100%25%20Passando-brightgreen)

Sistema de gerenciamento de freelancers desenvolvido em .NET com arquitetura limpa e testes unitários.

# 📋 Sobre o Projeto

Sistema completo para cadastro e gerenciamento de freelancers, incluindo operações CRUD (Create, Read, Update, Delete) com validações e testes unitários robustos.

  # 🏗️ Estrutura do Projeto
  ```bash
  ## ToFreeProj/
    ├── FreelancerApp/
    │ ├── Models/ # Modelos de dados
    │ ├── Services/ # Lógica de negócio
    │ └── Controllers/ # Controladores da API
    ├── FreelancerApp.Tests/ # Projeto de testes
    └── README.md
  ```

# 🚀 Funcionalidades

- ✅ Cadastro de freelancers
- ✅ Listagem de todos os freelancers
- ✅ Busca por ID
- ✅ Atualização de dados
- ✅ Exclusão de freelancers
- ✅ Validações de dados
- ✅ Testes unitários completos

# 🧪 Testes Implementados

### Suite de Testes Unitários

| Teste | Descrição |
|-------|-----------|
| `ObterTodos_QuandoNaoHaFreelancers_RetornaListaVazia` | Verifica retorno de lista vazia |
| `Criar_FreelancerValido_RetornaFreelancerComId` | Testa criação com ID gerado |
| `ObterPorId_IdExistente_RetornaFreelancer` | Valida busca por ID |
| `Atualizar_FreelancerExistente_RetornaFreelancerAtualizado` | Testa atualização de dados |
| `Excluir_FreelancerExistente_RetornaVerdadeiro` | Verifica exclusão |

### Executando os Testes

```bash
# Todos os testes
dotnet test

# Teste específico
dotnet test --filter "Criar_FreelancerValido_RetornaFreelancerComId"

# Com verbosity
dotnet test --verbosity normal
```


# 🛠️ Tecnologias Utilizadas
- .NET 8.0 - Framework principal
- C# - Linguagem de programação
- XUnit - Framework de testes
- MSTest - Assertions e testes

# 🔧 Como Executar
## Pré-requisitos
- .NET 8.0 SDK
- Visual Studio 2022 ou VS Code

```bash
# Clone o repositório
git clone https://github.com/enzoblousa/ToFreeProj.git

# Acesse o diretório
cd ToFreeProj

# Restaure as dependências
dotnet restore

# Execute os testes
dotnet test
```

// Criando um freelancer
var freelancer = new Freelancer 
{ 
    Name = "João Silva",
    Email = "joao@email.com",
    Skills = "C#, .NET, ASP.NET",
    HourlyRate = 50.0m
};

var service = new FreelancerService();
var result = service.Create(freelancer);
