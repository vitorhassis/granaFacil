<h2 align="center">💰 GranaFácil | Sistema de Gestão Financeira com .NET 💰</h2>

---

## 📌 Sobre o Projeto

O **GranaFácil** é uma aplicação web full stack voltada para **gestão financeira pessoal**, desenvolvida com foco em boas práticas de arquitetura e desenvolvimento de APIs REST utilizando **ASP.NET Core**.

O projeto transforma a lógica comum de controle financeiro em planilhas em um **backend estruturado**, com separação clara de responsabilidades, persistência em banco relacional e aplicação de padrões utilizados em sistemas reais.

O objetivo do projeto é demonstrar conhecimento prático em:

- Arquitetura em camadas
- Organização de projetos backend
- Desenvolvimento de APIs REST
- Modelagem de domínio
- Persistência de dados com ORM

---

## 🚀 Tecnologias Utilizadas

### Backend

- C#
- ASP.NET Core
- Entity Framework Core
- MySQL

### Arquitetura e Padrões

- DTOs (Data Transfer Objects)
- Injeção de Dependência (Dependency Injection)
- Service Layer
- Repository Pattern
- API REST

---

## 🏗️ Arquitetura do Sistema

O backend foi estruturado seguindo **arquitetura em camadas**, separando responsabilidades e facilitando manutenção e evolução do sistema.


- 📂 Controllers → Endpoints da API
- 📂 Services → Regras de negócio
- 📂 Repositories → Acesso ao banco de dados
- 📂 DTOs → Objetos de entrada e saída
- 📂 Models → Entidades do domínio
- 📂 Data → Contexto do banco e configurações


Essa estrutura mantém a aplicação organizada e próxima de padrões utilizados em projetos profissionais.

---

## 📚 Documentação do Projeto

Toda a **documentação detalhada do sistema** está disponível na pasta:


/docs


Nessa pasta estão documentados:

- 📄 Visão do projeto
- 📄 Requisitos do sistema
- 📄 Regras de negócio
- 📄 Escopo da solução
- 📄 Modelagem do sistema
- 📄 Diagramas (classes e banco de dados)
- 📄 Estrutura da arquitetura
- 📄 Descrição das entidades
- 📄 Organização da API

Essa documentação descreve a **estrutura completa do projeto**, incluindo decisões de arquitetura e modelagem do domínio.

---

## 📈 Próximas Etapas do Projeto

O projeto continuará evoluindo com as seguintes melhorias:

- Implementação de autenticação com **JWT**
- Sistema de **autorização e proteção de rotas**
- Expansão das entidades do domínio
- Integração com **frontend (Vue + Tailwind)**
- Implementação de **dashboard financeiro**
- Geração de relatórios e análises financeiras

---

## 🎯 Objetivo do Projeto

O **GranaFácil** é um projeto desenvolvido com foco em **aprendizado e demonstração de arquitetura backend**, simulando a estrutura de um sistema real de gestão financeira.

Ele serve como base para estudo de:

- Arquitetura de software
- APIs REST
- Modelagem de domínio
- Organização de projetos backend

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
