# Banco de Dados

## 1. Introdução

O sistema GranaFácil utiliza banco de dados relacional para persistência das informações financeiras dos usuários.

A comunicação com o banco é realizada através do **Entity Framework Core**, utilizando o provedor **MySQL**.

---

# 2. Tabelas do Sistema

O banco de dados é composto pelas seguintes tabelas principais:

- Usuarios
- Contas
- Entradas
- Gastos
- Metas
- Reservas

---

# 3. Relacionamentos

Os relacionamentos entre as tabelas seguem a modelagem definida no domínio do sistema.

Usuarios 1:N Contas  
Usuarios 1:N Entradas  
Usuarios 1:N Gastos  
Usuarios 1:N Metas  
Usuarios 1:N Reservas  

Metas 1:N Reservas

---

# 4. Chaves Estrangeiras

Contas.UsuarioId → Usuarios.Id  
Entradas.UsuarioId → Usuarios.Id  
Gastos.UsuarioId → Usuarios.Id  
Metas.UsuarioId → Usuarios.Id  
Reservas.UsuarioId → Usuarios.Id  
Reservas.MetaId → Metas.Id