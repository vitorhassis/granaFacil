# Requisitos do Sistema

## 1. Introdução

Este documento descreve os requisitos funcionais e não funcionais do sistema **GranaFácil**, uma aplicação voltada para gestão financeira pessoal.

Os requisitos representam as funcionalidades e restrições que o sistema deve atender para satisfazer as necessidades dos usuários.

---

# 2. Requisitos Funcionais

Os requisitos funcionais descrevem as funcionalidades que o sistema deve executar.

### RF01 – Cadastro de Usuário
O sistema deve permitir o cadastro de novos usuários.

### RF02 – Autenticação de Usuário
O sistema deve permitir que usuários autenticados acessem suas informações financeiras.

### RF03 – Cadastro de Contas
O sistema deve permitir que o usuário registre contas financeiras.

### RF04 – Registro de Entradas
O sistema deve permitir que o usuário registre entradas de dinheiro.

### RF05 – Registro de Gastos
O sistema deve permitir que o usuário registre gastos financeiros.

### RF06 – Atualização de Registros
O sistema deve permitir que o usuário atualize registros financeiros existentes.

### RF07 – Exclusão de Registros
O sistema deve permitir que o usuário exclua registros financeiros.

### RF08 – Consulta de Registros
O sistema deve permitir que o usuário consulte seus registros financeiros.

### RF09 – Organização por Período
O sistema deve permitir a organização das movimentações financeiras por mês e ano.

### RF10 – Marcação de Pagamento
O sistema deve permitir marcar contas como pagas.

---

# 3. Requisitos Não Funcionais

Os requisitos não funcionais descrevem características de qualidade e restrições do sistema.

### RNF01 – Arquitetura
O sistema deve seguir uma arquitetura em camadas separando responsabilidades entre controllers, services e repositories.

### RNF02 – Persistência de Dados
O sistema deve utilizar banco de dados relacional para armazenamento das informações.

### RNF03 – API REST
O sistema deve expor funcionalidades através de endpoints seguindo princípios de API REST.

### RNF04 – Isolamento de Dados
O sistema deve garantir que cada usuário tenha acesso apenas aos seus próprios dados.

### RNF05 – Organização de Código
O código deve ser estruturado de forma modular para facilitar manutenção e evolução.

### RNF06 – Escalabilidade
A arquitetura deve permitir expansão futura para novas funcionalidades e integrações.