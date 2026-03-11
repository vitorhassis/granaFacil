# Entidades do Sistema

## 1. Introdução

Este documento descreve as entidades que compõem o domínio do sistema **GranaFácil**.

As entidades representam os principais elementos utilizados para organizar e registrar informações financeiras dos usuários.

Cada entidade possui atributos específicos e relacionamentos com outras entidades do sistema.

---

# 2. Usuário

## Descrição

A entidade **Usuário** representa a pessoa que utiliza o sistema.

Ela é a entidade central do domínio, sendo responsável por possuir todos os registros financeiros associados.

## Atributos

- Id
- Nome
- Email
- Senha
- DataCriacao
- IsAtivo


## Relacionamentos


Usuario 1:N Contas
Usuario 1:N Entradas
Usuario 1:N Gastos
Usuario 1:N Metas
Usuario 1:N Reservas


---

# 3. Conta

## Descrição

A entidade **Conta** representa uma conta a pagar registrada pelo usuário.

Permite controlar despesas recorrentes ou contas específicas que devem ser pagas em determinada data.

## Atributos

- Id
- UsuarioId
- Nome
- Valor
- ValorPlanejado
- DataVencimento
- DataPagamento
- IsPago


## Relacionamentos


Contas N:1 Usuario


---

# 4. Entrada

## Descrição

A entidade **Entrada** representa valores recebidos pelo usuário.

Esses registros permitem acompanhar receitas financeiras ao longo do tempo.

## Atributos

- Id
- UsuarioId
- Valor
- Categoria (enum)
- DataEntrada


## Relacionamentos


Entradas N:1 Usuario


---

# 5. Gasto

## Descrição

A entidade **Gasto** representa saídas financeiras registradas pelo usuário.

Os gastos são utilizados para controlar despesas realizadas no período.

## Atributos

- Id
- UsuarioId
- Valor
- Categoria (enum)
- FormaDePagamento (enum)
- DataReferencia
- DataCriacao
- IsEssencial


## Relacionamentos


Gastos N:1 Usuario


---

# 6. Meta

## Descrição

A entidade **Meta** representa um objetivo financeiro definido pelo usuário.

As metas permitem planejar objetivos financeiros como economias ou aquisições futuras.

## Atributos

- Id
- UsuarioId
- Nome
- ValorAlvo
- ValorAcumulado
- DataCriacao
- DataPrazo


## Relacionamentos


Metas N:1 Usuario
Meta 1:N Reservas


---

# 7. Reserva

## Descrição

A entidade **Reserva** representa um valor separado pelo usuário para um objetivo específico.

Reservas podem ou não estar associadas a uma meta financeira.

## Atributos

- Id
- UsuarioId
- MetaId (opcional)
- Nome
- Valor
- Tipo (enum)
- DataCriacao

## Relacionamentos


Reservas N:1 Usuario
Reservas N:1 Meta (opcional)