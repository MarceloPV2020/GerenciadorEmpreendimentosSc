# Gerenciador de Empreendimentos de Santa Catarina

## Descrição da Solução

Este projeto consiste em uma **API REST para gerenciamento de empreendimentos localizados no estado de Santa Catarina**. A aplicação permite realizar operações completas de cadastro, consulta, atualização e remoção de registros relacionados a empreendimentos e seus respectivos responsáveis.

O sistema foi desenvolvido como solução para o **Desafio Prático de Software da trilha IA para DEVs**, promovido pelo **Programa SCTEC – SENAI/SC**.

A aplicação funciona como um protótipo de sistema que organiza informações sobre empreendimentos catarinenses, permitindo futuramente integração com interfaces de usuário ou outros serviços.

A API implementa operações de CRUD (Create, Read, Update e Delete) para gerenciamento dos dados, utilizando boas práticas de desenvolvimento e separação de responsabilidades entre as camadas da aplicação.

---

# Tecnologias Utilizadas

A solução foi desenvolvida utilizando tecnologias modernas do ecossistema .NET:

- **.NET 9**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQLite**
- **FluentValidation**
- **Swagger / OpenAPI**

Essas tecnologias permitem desenvolvimento rápido de APIs, boa organização de código e fácil manutenção da aplicação.

---

# Arquitetura da Aplicação

A aplicação segue uma arquitetura simples baseada em separação de responsabilidades entre camadas.

```mermaid
flowchart TD
    Client[Cliente HTTP] --> Controller[Controller API]
    Controller --> DTO[DTOs]
    Controller --> Validation[FluentValidation]
    Controller --> Model[Modelos de Domínio]
    Model --> DbContext[AppDbContext - EF Core]
    DbContext --> Database[Banco de Dados SQLite]
