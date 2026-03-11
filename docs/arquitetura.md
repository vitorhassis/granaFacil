# Arquitetura do Sistema

## 1. Introdução

Este documento descreve a arquitetura utilizada no sistema **GranaFácil**.

O projeto foi desenvolvido utilizando uma **arquitetura em camadas**, com o objetivo de separar responsabilidades, facilitar manutenção do código e permitir evolução do sistema de forma organizada.

A aplicação segue os princípios de organização comuns em APIs REST desenvolvidas com **ASP.NET Core**.

---

# 2. Arquitetura em Camadas

O sistema está estruturado nas seguintes camadas:


Cliente
   ↓
Controllers
   ↓
Services
   ↓
Repositories
   ↓
Banco de Dados


Cada camada possui responsabilidades específicas dentro da aplicação.

Futuramente será adicionada uma camada de segurança com autenticação baseada em JWT para controle de acesso às rotas da API.

---

# 3. Controllers

A camada de **Controllers** é responsável por receber as requisições HTTP feitas pelos clientes da API.

Funções principais:

- Receber requisições HTTP
- Encaminhar as requisições para a camada de Services
- Retornar respostas HTTP apropriadas

Os controllers não possuem lógica de negócio, mantendo-se enxutos e focados apenas na comunicação com o cliente.

---

# 4. Services

A camada de **Services** contém as **regras de negócio do sistema**.

Responsabilidades:

- Aplicar validações de negócio
- Executar lógica da aplicação
- Coordenar operações entre diferentes entidades
- Utilizar os repositórios para acesso aos dados

Essa camada centraliza o comportamento do sistema e evita que regras de negócio fiquem espalhadas pelo código.

---

# 5. Repositories

A camada de **Repositories** é responsável pelo acesso ao banco de dados.

Responsabilidades:

- Realizar operações de leitura e escrita no banco
- Executar consultas
- Isolar a lógica de persistência da aplicação

Essa separação permite que a lógica de acesso a dados fique desacoplada das regras de negócio.

---

# 6. DTOs (Data Transfer Objects)

O sistema utiliza **DTOs** para transferência de dados entre as camadas da aplicação.

Objetivos dos DTOs:

- Controlar quais dados são enviados e recebidos pela API
- Evitar exposição direta das entidades do domínio
- Estruturar melhor as operações de criação, leitura e atualização

Cada operação da API pode possuir DTOs específicos, como:

- DTOs de criação
- DTOs de leitura
- DTOs de atualização

---

# 7. Entity Framework Core

O projeto utiliza **Entity Framework Core** como ORM (Object Relational Mapper) para comunicação com o banco de dados.

Funções do EF Core no sistema:

- Mapear entidades para tabelas do banco
- Gerenciar relacionamentos entre entidades
- Executar consultas
- Controlar migrations para controle de versão do banco de dados

---

# 8. Injeção de Dependência

O ASP.NET Core fornece suporte nativo a **injeção de dependência (Dependency Injection)**.

Esse mecanismo é utilizado para registrar e fornecer instâncias de serviços e repositórios automaticamente para os controllers.

Benefícios:

- Redução de acoplamento entre classes
- Melhor organização do código
- Maior facilidade para testes e manutenção

---

# 9. Fluxo de uma Requisição

O fluxo de execução de uma requisição na API ocorre da seguinte forma:


Cliente → Controller → Service → Repository → Banco de Dados


1. O cliente envia uma requisição HTTP para a API.
2. O **Controller** recebe a requisição.
3. O **Service** executa as regras de negócio.
4. O **Repository** acessa o banco de dados.
5. O resultado retorna pelas camadas até chegar ao cliente.

---

# 10. Estrutura de Pastas do Projeto

A organização do projeto segue a seguinte estrutura:


- Models/
- Enums/

- Controllers/
- Services/
- Repositories/

- DTOs/
- Profile/

- Data/
- Migrations/


Essa organização facilita a manutenção e compreensão da estrutura da aplicação.
