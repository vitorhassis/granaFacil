# API

## Usuários

POST /usuarios  
Cria um novo usuário.

GET /usuarios/email  
Busca usuário por email.

---

## Contas

POST /contas  
Cria um novo registro de conta.

GET /contas  
Lista os registros de contas do usuário.

GET /contas/{id}
Lista um registro conta do usuário.

PUT /contas/{id}  
Atualiza um registro de conta.

DELETE /contas/{id}  
Remove um registro de conta.

PATCH /contas/{id}
Atualiza parcialmente um registro de conta.

---

## Entradas

POST /entradas
Cria um novo registro de entrada.

GET /entradas  
Lista os registros de entradas do usuário.

GET /entradas/{id}
Lista um registro de entrada do usuário.

PUT /entradas/{id}  
Atualiza um registro de entrada.

DELETE /entradas/{id}
Remove um registro de entrada.

---

## Gastos

POST /gastos  
Cria um novo registro de gasto.

GET /gastos  
Lista os registros de gastos do usuário.

GET /gastos/{id}
Lista um registro de gasto do usuário.

PUT /gastos/{id}  
Atualiza um registro de gasto.

DELETE /gastos/{id}
Remove um registro de gasto.

---

## Metas

POST /metas  
Cria um registro de meta do usuário.

GET /metas  
Lista os registros de metas do usuário.

GET /metas/{id}
Lista o registro de meta do usuário.

PUT /metas/{id} 
Atualiza o registro de meta do usuário.

DELETE /metas/{id}
Remove o registro de meta do usuário.
---

## Reservas

POST /reservas 
Cria um registro de reserva do usuário. 

GET /reservas  
Lista os registros de reservas do usuário.

GET /reservas/{id}
Lista um registro de reserva do usuário.

PUT /reservas/{id}  
Atualiza um registro de reserva do usuário.

DELETE /reservas/{id}
Remove um registro de reserva.
