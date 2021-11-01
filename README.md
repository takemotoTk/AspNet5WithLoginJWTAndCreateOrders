# Modelo de Projeto com autenticação(JWT) e uma criação e consulta de Order com paginação utilizando .net 5

Tecnologias e conceitos utilizados:
- .net 5
- banco sql server
- EntityFramework Core
- Mediator
- JWT
- Unidade única de trabalho(UnitOfWork)
- Baseado em uma arquitetura hexagonal e clean architecture

Projeto .net 5 com Login Jwt implementado e um cadastro de Order com Product, utilizando o conceito de Unidade única de trabalho(UnitOfWork)

Abaixo segue o usuário e senha base para gerar os Tokens

{
  "userName": "admin",
  "password": "@Admin123"
}


Para consumir os Métodos de Order será preciso utilizar o token que será retornado no método /api/Authentication
Clique no ícone de 'cadeado', ao abrir um modal, informe o token e clique em 'Authorize', após isso pode ser consumido normalmente os métodos de Order.
![image](https://user-images.githubusercontent.com/15248263/139621067-c8efb823-6bee-4d0c-ab89-3a43b7bcfca0.png)

![image](https://user-images.githubusercontent.com/15248263/139621236-64283a70-fe87-49fa-89e3-10d36f11569a.png)
