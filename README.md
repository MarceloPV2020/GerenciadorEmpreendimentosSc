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

## Descrição das camadas

Controllers\
Responsáveis por expor os endpoints da API e receber as requisições
HTTP.

DTOs\
Objetos utilizados para entrada e saída de dados da API, evitando
exposição direta das entidades do domínio.

Models\
Representam o modelo de domínio da aplicação.

Data\
Responsável pela configuração do acesso ao banco de dados através do
Entity Framework Core.

------------------------------------------------------------------------

# Funcionalidades Implementadas

A API implementa um CRUD completo para gerenciamento de empreendimentos.

Operações disponíveis:

-   Criar empreendimento
-   Listar empreendimentos
-   Consultar empreendimento por ID
-   Atualizar empreendimento
-   Remover empreendimento

Cada empreendimento possui os seguintes campos:

-   Nome do empreendimento
-   Nome do empreendedor responsável
-   Município
-   Segmento de atuação
-   Telefone (meio de contato)
-   Status (ativo ou inativo)

Segmentos disponíveis:

-   Tecnologia
-   Comércio
-   Indústria
-   Serviços
-   Agronegócio

------------------------------------------------------------------------

# Execução do Projeto

## Pré-requisitos

Para executar o projeto é necessário possuir:

-   .NET 9 SDK instalado
-   Git instalado

## Clonar o repositório

git clone https://github.com/MarceloPV2020/GerenciadorEmpreendimentosSc.git

## Acessar o diretório do projeto

cd GerenciadorEmpreendimentosSc.Api

## Restaurar dependências

dotnet restore

## Executar a aplicação

dotnet run

------------------------------------------------------------------------

# Acessar a documentação da API

Após iniciar a aplicação, a documentação interativa estará disponível
em:

https://localhost:7021/swagger

A interface Swagger permite visualizar e testar todos os endpoints
disponíveis na API.

------------------------------------------------------------------------

# Banco de Dados

O projeto utiliza SQLite como mecanismo de persistência de dados,
configurado através do Entity Framework Core.

O banco de dados é criado automaticamente durante a execução da
aplicação caso ainda não exista.

------------------------------------------------------------------------

# Vídeo Pitch

Apresentação da solução desenvolvida:

LINK????????????????????????????????????????????????????????????????????????????

No vídeo são apresentados:

-   contexto da solução
-   tecnologias utilizadas
-   arquitetura do projeto
-   demonstração das funcionalidades principais

------------------------------------------------------------------------

# Considerações Finais

A solução atende aos requisitos propostos no desafio prático,
implementando uma API REST funcional para gerenciamento de
empreendimentos.

A arquitetura adotada permite fácil manutenção e evolução futura da
aplicação, possibilitando a integração com interfaces de usuário ou
outros serviços.
    Model --> DbContext[AppDbContext - EF Core]
    DbContext --> Database[Banco de Dados SQLite]
