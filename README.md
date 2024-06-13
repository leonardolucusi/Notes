# Notes

Bem-vindo ao projeto Notes! Esta API foi desenvolvida para ajudar a organizar anotações de forma eficiente e estruturada. Abaixo você encontrará detalhes sobre a implementação, tecnologias utilizadas e como configurar o projeto.

## Tecnologias Utilizadas

- **.NET Core 8**
- **Arquitetura Limpa**
  - Core/Domain
  - Infrastructure
  - Application
  - API/Interface
- **CQRS (Command Query Responsibility Segregation)**
- **Banco de Dados SQL Server**
- **Entity Framework Core**
- **Padrão Repository**
- **Validação de Dados com FluentValidation**
- **Testes Unitários com XUnit e Moq**
- 
![notes-endpoint](https://github.com/leonardolucusi/Notes/assets/61367434/53cf4726-eedd-4ea5-8160-a54e8d7404c8)

## Estrutura do Projeto

O projeto está organizado seguindo os princípios da Arquitetura Limpa:

- **Core/Domain**: Contém as entidades, interfaces e serviços que são independentes de frameworks externos.
- **Infrastructure**: Implementa as interfaces do domínio e gerencia a comunicação com tecnologias externas, como o banco de dados.
- **Application**: Contém a lógica de aplicação e a implementação do padrão CQRS.
- **API/Interface**: Camada de apresentação que expõe os endpoints da API.

## Pré-requisitos

- .NET Core 8 SDK
- SQL Server
- Visual Studio ou qualquer IDE compatível com .NET

## Configuração

1. Clone o repositório:
   git clone https://github.com/leonardolucusi/Notes.git

2. Configure a string de conexão com o SQL Server no arquivo appsettings.json:
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=NotesDb;User Id=seu-usuario;Password=sua-senha;"
  }
}

3. Execute as migrações para criar o banco de dados:
dotnet ef database update

Testes
Os testes unitários são realizados com XUnit e Moq.

Contribuição
Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e pull requests.

Licença
Este projeto está licenciado sob a licença GPL. Veja o arquivo LICENSE para mais detalhes.
