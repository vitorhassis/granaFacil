# Escopo do Sistema

## 1. Escopo Geral

O **GranaFácil** é um sistema de gestão financeira pessoal que permite ao usuário registrar, organizar e acompanhar suas movimentações financeiras mensais.

O sistema foi projetado para estruturar informações financeiras em entidades organizadas, permitindo que cada usuário possua seu próprio ambiente de controle financeiro.

A aplicação segue uma arquitetura backend baseada em **API REST**, permitindo integração futura com aplicações frontend.

---

## 2. Funcionalidades do Sistema

O sistema permite que o usuário:

- cadastrar contas financeiras
- registrar entradas de dinheiro
- registrar gastos
- acompanhar registros financeiros organizados por mês
- atualizar registros existentes
- excluir registros financeiros
- marcar contas como pagas

---

## 3. Organização dos Dados

Os dados financeiros são organizados por **usuário** e **período mensal**, permitindo que cada usuário visualize suas movimentações financeiras separadamente.

Cada registro financeiro pertence exclusivamente a um usuário, garantindo isolamento de dados.

---

## 4. Entidades do Sistema

O domínio da aplicação é composto pelas seguintes entidades principais:

- Usuário
- Conta
- Entrada
- Gasto
- Meta
- Reserva

Cada entidade representa um tipo específico de informação financeira dentro do sistema.

---

## 5. Funcionalidades Fora do Escopo Atual

As seguintes funcionalidades **não fazem parte da versão atual do sistema** serão implementadas:

- autenticação e autorização de usuários
- geração de relatórios financeiros
- notificações financeiras
- exportação de dados

---

## 6. Versão Atual do Projeto (MVP) 

A versão atual do projeto foca na implementação da **estrutura base do sistema**, incluindo:

- modelagem do domínio
- criação da API REST
- persistência de dados
- implementação das principais operações de CRUD
- organização da arquitetura do projeto

Essa etapa permite validar a estrutura da aplicação antes da implementação das funcionalidades mais avançadas.