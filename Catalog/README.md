# Catalog Microservice

## Objetivo do Catalog
O microsserviço Catalog é responsável por gerenciar o catálogo de produtos, marcas e tipos disponíveis no sistema. Ele será a fonte primária de verdade para exibir produtos para os clientes e interagir com outros serviços que precisem de informações do catálogo.

## Responsabilidade
- Manter o cadastro de produtos.
- Fornecer endpoints de leitura e pesquisa (filtros, paginação) de forma eficiente.
- Garantir a integridade dos dados do catálogo através do núcleo de domínio.

## Estrutura
Este projeto segue os princípios de **Clean Architecture**, sendo dividido em:

- **Catalog.Domain**: O núcleo do negócio, contendo as entidades (ex: Produto), regras de domínio e interfaces de abstração (ex: repositórios). Não possui dependências externas.
- **Catalog.Application**: Casos de uso e regras de aplicação. Coordena a execução de tarefas utilizando o domínio e contratos externos.
- **Catalog.Infrastructure**: Implementações técnicas (persistência em banco de dados, chamadas a APIs de terceiros, cache, mensageria).
- **Catalog.API**: Ponto de entrada (Entrypoint) da aplicação. Expõe os endpoints HTTP (ASP.NET Core) e realiza a Injeção de Dependência (DI).
- **Tests**: Projetos dedicados para garantir a qualidade (`Catalog.UnitTests` e `Catalog.IntegrationTests`).

## Como executar
1. Navegue até o diretório raiz do projeto: `cd Catalog`
2. Restaure as dependências: `dotnet restore`
3. Execute o microsserviço (API): `dotnet run --project Catalog.API/Catalog.API.csproj`
4. Acesse o endpoint padrão `http://localhost:<porta>/` ou `/health`.

## Como testar
Para rodar os testes unitários e de integração existentes:
`dotnet test`

## Dependências Iniciais
- **.NET SDK**: 10.0
- **xUnit**: Para a camada de testes.

## Decisões Arquiteturais Iniciais
- **Separação Física de Projetos**: Diferente do modelo inicial do eShopOnContainers onde pastas (`Infrastructure`, `Model`) ficavam dentro do `Catalog.API`, decidimos separar fisicamente para forçar a direção das dependências e isolar o domínio.
- **Minimal API Structure**: Usaremos Minimal APIs e um `Program.cs` enxuto, tirando proveito das features modernas do .NET 10, reduzindo o boilerplate presente nos projetos mais antigos.
- **Segurança desde o Início**: Os endpoints estão sendo preparados para não hardcodar segredos. Configurações baseadas em Options serão inseridas conforme adicionarmos provedores.
- **Sem over-engineering**: Nenhum Entity Framework, MediatR ou Repository genérico foi adicionado nesta primeira etapa, apenas as fundações necessárias para evoluir.
