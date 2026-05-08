# FilmesAPI

Uma API RESTful desenvolvida em ASP.NET Core para o gerenciamento de catálogos de filmes, cinemas, endereços e sessões. Este projeto foca na implementação de um sistema de back-end estruturado, utilizando boas práticas de desenvolvimento e mapeamento objeto-relacional.

## Tecnologias Utilizadas

- C#
- .NET
- ASP.NET Core Web API
- Entity Framework Core (com suporte a Lazy Loading Proxies)
- AutoMapper
- Banco de Dados Relacional (PostgreSQL / SQL Server)

## Estrutura do Domínio

O projeto está organizado em torno das seguintes entidades principais:
- Filme: Registro de informações sobre os filmes.
- Cinema: Cadastro de unidades de cinema.
- Endereco: Localização detalhada dos cinemas.
- Sessao: Vinculação entre filmes e cinemas com horários de exibição.

## Pré-requisitos

Para executar este projeto localmente, é necessário ter instalado:
- [.NET SDK](https://dotnet.microsoft.com/download)
- Banco de dados relacional configurado
- Ferramenta de linha de comando do Entity Framework Core (`dotnet tool install --global dotnet-ef`)