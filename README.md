<h2 align="center">💰 GranaFácil | Sistema de Gestão Financeira com .NET 💰</h2>

## 📌 Sobre o projeto

- O GranaFácil é uma aplicação web full stack desenvolvida com foco em organização financeira mensal por usuário, aplicando arquitetura em camadas e boas práticas no desenvolvimento de APIs REST com ASP.NET Core.
- O sistema transforma a lógica de planilhas financeiras em um backend estruturado, com regras de negócio bem definidas, separação de responsabilidades e persistência em banco relacional.
- O objetivo principal do projeto é demonstrar domínio em:
- Arquitetura em camadas
- Padrão Repository
- Service Layer
- Entity Framework Core
- Organização de código voltada para aplicações reais

---

## 🚀 Tecnologias utilizadas

- ✅ C#
- ✅ ASP.NET Core
- ✅ Entity Framework Core
- ✅ MySQL
- ✅ DTOs (Data Transfer Objects)
- ✅ Injeção de Dependência (DI)
- ✅ Padrão Repository
- ✅ API REST

---

## 🏗️ Arquitetura
O projeto segue uma estrutura organizada em camadas:

- 📂 Models → Entidades do domínio
- 📂 DTOs → Objetos de entrada e saída de dados
- 📂 Services → Regras de negócio
- 📂 Repositories → Acesso a dados
- 📂 Controllers → Endpoints da API

🔹 Separação de responsabilidades
- ✔️ Service → Contém regras de negócio e validações
- ✔️ Repository → Responsável apenas pelo acesso ao banco
- ✔️ Controllers → Mantidos enxutos
- ✔️ DTOs → Isolam o domínio da camada externa

---

## 📊 Funcionalidades Implementadas

- ✔️ Cadastro de contas
- ✔️ Validações de vencimento e valores
- ✔️ Organização por usuário
- ✔️ Filtro por mês e ano
- ✔️ Atualização de dados
- ✔️ Exclusão de registros
- ✔️ Marcação de conta como paga

## 🔐 Regras de Negócio

- Validação de datas de vencimento
- Validação de valores positivos
- Controle de pagamento (impede pagar duas vezes)
- Isolamento de dados por usuário
- Organização financeira mensal

---

## 📈 Próximas Etapas

- Implementação de autenticação com JWT
- Proteção de rotas
- Expansão para demais entidades (Entradas, Metas, Reservas)
- Integração com frontend (Vue + Tailwind)

---

## 📂 Como executar o projeto

- Certifique-se de ter o .NET SDK instalado
- Clone o repositório:
```bash
git clone https://github.com/vitorhassis/Cashflowr-web.git
cd Cashflowr
dotnet run
```
- Configure a string de conexão com o banco no appsettings.json

- Execute as migrations:
dotnet ef database update

---

## 📩 Contato

- 📧 Email: sasilva.vh@gmail.com
- 👨‍💻 GitHub: github.com/vitorhassis

<p align="center">⚡ <em>Desenvolvido por Vitor Assis</em> ⚡</p>
