# Notes

Bem-vindo ao projeto Notes! Esta API foi desenvolvida para ajudar a organizar anotações de forma eficiente e estruturada. Abaixo você encontrará detalhes sobre a implementação, tecnologias utilizadas e como configurar o projeto.

## Tecnologias Utilizadas
Este projeto foi construído utilizando tecnologias modernas e seguindo as melhores práticas de desenvolvimento de software.
- **.NET Core 8**: Plataforma de desenvolvimento de alto desempenho e com suporte para construção de aplicações escaláveis.
- **Arquitetura Limpa**: Separação clara de responsabilidades com camadas distintas (Core/Domain, Infrastructure, Application, API/Interface), promovendo alta testabilidade e manutenção do código.
- **CQRS**: Separação de operações de leitura e escrita, otimizando o desempenho e a organização do código.
- **Banco de Dados SQL Server**: Utilização de banco de dados relacional confiável e eficiente.
- **Entity Framework Core**: ORM robusto para mapeamento objeto-relacional, facilitando a interação com o banco de dados.
- **Padrão Repository**: Abstração da lógica de acesso aos dados, promovendo um design desacoplado e fácil de testar.
- **Validação de Dados**: Implementação de validações consistentes com o FluentValidation, garantindo a integridade dos dados.
- **Testes Unitários**: Adoção de práticas de testes unitários utilizando XUnit e Moq para assegurar a qualidade e a confiabilidade do código.
  
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
    "DefaultConnection": "Data Source=YOURNAMECONFIG;Initial Catalog=NotesDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"
  }
}

3. Execute as migrações para criar o banco de dados:
dotnet ef database update

**Testes**
Os testes unitários são realizados com XUnit e Moq.

Contribuição
Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e pull requests.

Licença
Este projeto está licenciado sob a licença GPL. Veja o arquivo LICENSE para mais detalhes.
