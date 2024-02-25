# Tech Challenge Modulo1

## O Problema

Tech Challenge do Modulo 1 da Pos Tech em Arquitetura de Sistemas .NET, consiste no desenvolvimento de uma API para um portal de investimento. Foi necessário levantar os requisitos do projeto utilizando a modelagem DDD e utilizando boas práticas na separação de camadas do projetos.


* A solução deve contem teste unitários;
* Deve está configurado com logs;
* O projeto tem autenticação e tipos de permissão de usuarios;
* Foi utilizando banco de dados SQL.

## 1. Tecnologias
<div style="display: flex; flex-direction: row; gap: 5px;">
  <img align="center" alt="TS" src="https://img.shields.io/badge/Angular-DD0031?style=for-the-badge&logo=angular&logoColor=white">
   <img align="center" alt="TS" src="https://img.shields.io/badge/TypeScript-007ACC?style=for-the-badge&logo=typescript&logoColor=white">
   <img align="center" alt="TS" src="https://img.shields.io/badge/Bootstrap-563D7C?style=for-the-badge&logo=bootstrap&logoColor=white">
   <img align="center" alt="TS" src="https://img.shields.io/badge/Sass-CC6699?style=for-the-badge&logo=sass&logoColor=white">
 <img align="center" alt="TS" src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white">
<img align="center" alt="TS" src="https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white">

</div>

### Tecnologias Utilizadas FrontEnd
### Tecnologias Utilizadas BackEnd

- ASP.NET Core: Um framework de desenvolvimento da API.
- Entity Framework: O ORM para mapear objetos de domínio junto ao banco de dados.
- PostgreSQL: O banco de dados utilizado.
- Microsoft Authentication JWT Bearer: Autenticação JWT.

Testes:
- AutoMock: Biblioteca para simplificar o uso de mocks em testes.
- UnitTest: Framework de teste unitário utilizado.
- Swagger: Utilizado para a documentação do projeto.

# 2. Estrutura do Projeto
## BackEnd
- Configurations: Contém as configurações das entidades que possuem relacionamentos com o banco de dados.

- Controllers: Abriga os controladores da API, incluindo StudentsController, UserController e LoginController.

- DTO: Contém os modelos de dados das entidades, facilitando a transferência de informações entre diferentes partes da aplicação.

- Entity: Esta pasta inclui as entidades fundamentais do sistema, como User e Student.

- Enums: Define o PermitionsTypes, determinando os papéis dos usuários no projeto.

- Interface: Contém interfaces utilizadas na configuração dos repositórios.

- Logging: Configurações relacionadas a logs da aplicação.

- Migrations: Armazena as migrações do Entity Framework, utilizadas para atualizações no banco de dados.

- Repository: Responsável pela integração com o banco de dados, contém a classe ApplicationDbContext e arquivos de configuração de acesso ao banco por entidade.

- Services: Oferece serviços que auxiliam na lógica do projeto, incluindo PasswordHasher para manipulação de senhas e a geração de tokens JWT para autenticação.

## 3. Funcionalidades  e Propriedades de Classes

## 3.1 Propriedades da Classe User:

* **Id:**
  - Representa um identificador único para cada usuário.
  - Possibilita uma identificação única e inequívoca de cada instância da classe `User`.

* **Name:**
  - Armazena o nome do usuário, proporcionando uma referência mais amigável.

* **Email:**
  - Reservada para armazenar o endereço de e-mail associado a cada usuário.
  - Crucial como meio de comunicação e identificação na aplicação.

* **Password:**
  - Mantém a senha associada a cada usuário.
  - Armazenada de forma criptografada ou hash por razões de segurança.

* **Permitions:**
  - Indica os níveis de acesso ou autorizações concedidos a um usuário.
  - Controla quais recursos e operações um usuário está autorizado a acessar.
 
  ## 4. Configuração do Projeto
  Para inicializar o projeto backend, siga os passos abaixo:

Clone o repositório:

```
git clone https://github.com/annekarolle/orbita-challenge-full-stack-web.git
```
Abra o projeto:

- Navegue para o diretório do projeto backend:
```
cd orbita-challenge-full-stack-web/BackEnd
```
- Abra o projeto em sua IDE favorita. Por exemplo, utilizando o Visual Studio Code:
```
code .
```

### Configure a Connection String:

- Abra o arquivo appsettings.json no diretório do projeto.
Encontre a seção ConnectionStrings e ajuste a string de conexão para o seu banco de dados
Instale as Dependências:

- Abra um terminal no diretório do projeto e execute o seguinte comando para restaurar as dependências:
```
dotnet restore
```
- Execute as Migrações do Banco de Dados:

- Execute o seguinte comando para aplicar as migrações e criar as tabelas no banco de dados:
  

```
Update-Database
```
- Rode o Projeto:

Execute o seguinte comando para iniciar o servidor:
```
dotnet run
```
