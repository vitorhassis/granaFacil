# Modelagem do Sistema

## 1. Introdução

Este documento descreve a **modelagem do domínio** do sistema **GranaFácil**.

A modelagem define as principais entidades do sistema e os relacionamentos entre elas, representando a estrutura lógica utilizada para organização das informações financeiras dos usuários.

O sistema foi modelado com base no conceito de **domínio centrado no usuário**, onde cada usuário possui seu próprio ambiente de controle financeiro.

---

# 2. Entidade Central do Sistema

A entidade **Usuário** é a entidade central do sistema.

Todas as demais entidades dependem diretamente dela, garantindo que os dados financeiros sejam **isolados por usuário**.

Cada registro financeiro criado no sistema deve estar associado a um usuário específico.

---

# 3. Entidades do Sistema

O domínio do sistema é composto pelas seguintes entidades principais:

- Usuário
- Conta
- Entrada
- Gasto
- Meta
- Reserva

Cada entidade representa um tipo específico de informação financeira registrada pelo usuário.

---

# 4. Relacionamentos Entre Entidades

Os relacionamentos entre as entidades do sistema são definidos da seguinte forma:

- Usuario 1:N Contas = Um **Usuario** pode possuir várias **contas**
- usuario 1:N Entradas = Um **Usuario** pode registrar várias **entradas**
- Usuario 1:N Gastos  = Um **Usuario** pode registrar vários **gastos**
- Usuario 1:1 Metas = Um **Usuario** pode possuir uma **meta** 
- Usuario 1:N Reservas = Um **Usuario** pode registrar várias **reservas**

# 5. Organização do Domínio

A estrutura do domínio foi projetada para permitir uma organização clara das informações financeiras do usuário.

Cada tipo de registro possui um propósito específico dentro do sistema,


---


# 6. Modelagem do Banco de Dados

A modelagem do banco de dados segue diretamente a estrutura das entidades do domínio. Utilizado para auxílio na estruturação do banco de dados.

Cada entidade do sistema corresponde a uma tabela no banco de dados, contendo seus respectivos atributos e relacionamentos.

Os relacionamentos entre as tabelas são implementados utilizando **chaves estrangeiras (Foreign Keys)** para garantir integridade referencial.


---

# 7. Considerações de Modelagem

Durante o processo de modelagem foram consideradas as seguintes decisões:

- O **usuário** é a entidade central do sistema
- Todas as entidades financeiras dependem do usuário
- Os registros financeiros são organizados por período mensal
- Meta 1:N Reservas = Uma meta pode possuir nenhuma ou várias reservas associadas
- Reserva 0:1 Meta = Uma reserva pode ou não estar associada a uma meta
