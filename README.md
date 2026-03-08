# Gerenciador de Empreendimentos de Santa Catarina

## Descrição da Solução

Este projeto consiste em uma API REST desenvolvida para o gerenciamento
de informações sobre empreendimentos localizados no estado de Santa
Catarina.

A aplicação permite realizar operações completas de cadastro, consulta,
atualização e remoção de empreendimentos e de seus respectivos
responsáveis, organizando os dados de forma estruturada.

O sistema foi desenvolvido como solução para o desafio prático de
software do processo seletivo da trilha **IA para DEVs**, promovido pelo
**Programa SCTEC - SENAI/SC**.

A proposta da aplicação é servir como um protótipo de sistema capaz de
organizar dados relacionados ao empreendedorismo catarinense, podendo
futuramente ser integrado a outras aplicações ou interfaces de usuário.

------------------------------------------------------------------------

# Tecnologias Utilizadas

A solução foi desenvolvida utilizando tecnologias modernas do
ecossistema .NET.

-   .NET 9
-   ASP.NET Core Web API
-   Entity Framework Core
-   SQLite
-   FluentValidation
-   Swagger / OpenAPI

Essas tecnologias foram escolhidas por oferecerem boa organização de
código, facilidade de manutenção e rápida criação de APIs REST.

------------------------------------------------------------------------

# Estrutura Geral do Projeto

O projeto segue uma estrutura organizada em camadas:

GerenciadorEmpreendimentosSc.Api

Controllers → Endpoints da API\
Models → Entidades de domínio\
Dtos → Objetos de transferência de dados\
Data → DbContext e acesso ao banco\
Migrations → Controle de versionamento do banco\
Program.cs → Configuração da aplicação

Essa separação facilita manutenção, legibilidade e evolução do sistema.

### Descrição das camadas

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

git clone

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

??????????????????????????????????????????LINK_DO_VIDEO

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
