# Regras de Negócio

## 1. Introdução

Este documento descreve as principais regras de negócio aplicadas no sistema **GranaFácil**.

As regras de negócio representam as restrições e validações que garantem o funcionamento correto do sistema e a consistência das informações financeiras registradas pelos usuários.

---

# 2. Regras Gerais do Sistema

### RN01 – Isolamento de Dados por Usuário
Cada usuário pode acessar apenas os seus próprios dados financeiros.

Todos os registros financeiros devem estar associados a um usuário específico.

---

### RN02 – Valores Financeiros Positivos
Registros financeiros devem possuir valores positivos.

O registro de valores negativos não é permitido para evitar inconsistência nos dados.

---

### RN03 – Associação Obrigatória ao Usuário
Todos os registros financeiros devem possuir uma associação com um usuário.

Nenhum registro pode existir sem um usuário responsável.

---

### RN04 – Organização Financeira por Período
As movimentações financeiras devem ser organizadas por período mensal, permitindo consultas por mês e ano.

---

# 3. Regras de Contas

### RN05 – Cadastro de Conta
O sistema deve permitir o registro de contas financeiras associadas a um usuário.

Cada conta registrada deve conter informações suficientes para identificação da conta, controle de valor e gerenciamento de pagamento.

---

### RN06 – Controle de Pagamento
Uma conta pode ser marcada como paga.

Após o pagamento, o status da conta deve ser atualizado para evitar duplicidade de pagamento.

---

### RN07 – Validação de Data
A data de vencimento de uma conta deve ser uma data válida.

---

# 4. Regras de Entradas Financeiras

### RN08 – Registro de Entrada
O sistema deve permitir o registro de entradas financeiras associadas a um usuário.

---

### RN09 – Consistência de Dados
Entradas financeiras devem representar apenas valores recebidos pelo usuário.

---

# 5. Regras de Gastos

### RN10 – Registro de Gasto
O sistema deve permitir o registro de gastos financeiros associados a um usuário.

---

### RN11 – Registro de Despesa
Os gastos representam saídas financeiras registradas pelo usuário.

---

# 6. Regras de Metas Financeiras

### RN12 – Definição de Meta
O sistema deve permitir que usuários definam metas financeiras para planejamento de objetivos futuros.

---

### RN13 – Objetivo Financeiro
As metas representam objetivos financeiros definidos pelo usuário para planejamento financeiro.

---

# 7. Regras de Reservas Financeiras

### RN14 – Registro de Reserva
O sistema deve permitir que o usuário registre reservas financeiras para objetivos específicos.

Uma reserva pode opcionalmente estar associada a uma meta financeira.