# 📦 Catalog Microservice

> **Microsserviço de Catálogo de Produtos e Referência Arquitetural**  
> Projeto construído junto com o livro vivo **“Construindo Microsserviços”** ([livro_vivo_de_engenharia.html](../livro_vivo_de_engenharia.html)), utilizando .NET 10, Clean Architecture e Minimal APIs.

---

## 🎯 1. Objetivo e Propósito

O microsserviço **Catalog** é a fonte primária e autoridade exclusiva da plataforma para o gerenciamento e exibição do catálogo de produtos, marcas e tipos disponíveis para comercialização.

Ele foi desenhado para atender aos seguintes requisitos centrais:
- **Alta Performance de Leitura:** Responder rapidamente às consultas da vitrine do e-commerce (listagens paginadas, filtros e buscas).
- **Integridade do Domínio:** Garantir que regras e invariantes de produtos sejam preservadas dentro do núcleo de negócio, impedindo inconsistências.
- **Autonomia Total:** Possuir ciclo de vida, persistência e deploy independentes dos demais microsserviços do ecossistema.

---

## 🗺️ 2. Bounded Context (DDD): Limites e Responsabilidades

Em sistemas distribuídos orientados pelo **Domain-Driven Design (DDD)**, um microsserviço só é autônomo se souber exatamente onde começam e terminam as suas fronteiras.

```
+-------------------------------------------------------------------+
|                     BOUNDED CONTEXT: CATALOG                      |
|                                                                   |
|   [ PRODUTOS ]  ───  [ MARCAS (BRANDS) ]  ───  [ TIPOS (TYPES) ]  |
|                                                                   |
|   - Especificações vendáveis                                      |
|   - Preço de tabela / referência                                  |
|   - Estoque físico disponível no catálogo                         |
+-------------------------------------------------------------------+
                                 │
                     A LINHA VERMELHA (NÃO PERTENCE)
                                 │
     ┌───────────────────────────┼───────────────────────────┐
     ▼                           ▼                           ▼
[ BASKET ]                  [ ORDERING ]                [ IDENTITY ]
Carrinho temporário      Fechamento de pedido,       Autenticação, tokens
e sessão de compra       faturamento e checkout      e perfis de usuário
```

### ✅ O que pertence ao Catalog:
- Cadastro, atualização e consulta de itens do catálogo (`Product`).
- Gestão de marcas parceiras ou fabricantes (`Brand`).
- Gestão de categorias/tipos de produto (`CatalogType`).
- Quantidade física base em estoque cadastrado no catálogo.
- Publicação de eventos de domínio quando itens ou preços sofrem alterações.

### ❌ O que NÃO pertence ao Catalog:
- **Carrinho de compras:** Pertence exclusivamente ao microsserviço `Basket`.
- **Processamento de checkout e pedidos:** Pertence ao microsserviço `Ordering`.
- **Autenticação e credenciais:** Pertencem ao microsserviço `Identity`.
- **Cobrança e gateway financeiro:** Pertencem ao serviço de `Payment`.

---

## 🏛️ 3. Arquitetura da Solução

O projeto segue os princípios de **Clean Architecture** (Arquitetura Limpa), separado fisicamente em projetos distintos para que o compilador proteja as fronteiras e garanta a direção correta das dependências:

```
                            ┌────────────────┐
                            │  Catalog.API   │ (Entrypoint HTTP / DI)
                            └───────┬────────┘
                                    │
                    ┌───────────────┴───────────────┐
                    ▼                               ▼
        ┌──────────────────────┐        ┌──────────────────────┐
        │ Catalog.Application  │        │Catalog.Infrastructure│
        └───────────┬──────────┘        └───────────┬──────────┘
                    │                               │
                    └───────────────┬───────────────┘
                                    ▼
                        ┌──────────────────────┐
                        │    Catalog.Domain    │ (Núcleo Puro - Zero Dependências)
                        └──────────────────────┘
```

### Detalhamento das Camadas

| Projeto | Responsabilidade | Dependências |
| :--- | :--- | :--- |
| **`Catalog.Domain`** | O coração do negócio. Contém entidades, Value Objects, invariantes e contratos de repositório. | **Nenhuma.** Class Library pura em .NET 10 sem frameworks externos. |
| **`Catalog.Application`** | Casos de uso e orquestração. Contém DTOs (Request/Response), handlers e regras de fluxo da aplicação. | Referencia apenas `Catalog.Domain`. |
| **`Catalog.Infrastructure`** | Implementações técnicas. Contém mapeamento de banco de dados, ORMs, repositórios concretos e integrações externas. | Referencia `Catalog.Domain` e `Catalog.Application`. |
| **`Catalog.API`** | Ponto de entrada (Entrypoint). Expõe endpoints HTTP via Minimal APIs, registra Dependency Injection e gerencia configurações. | Referencia `Catalog.Application` e `Catalog.Infrastructure`. |
| **`Tests`** | Garantia de qualidade com testes automatizados (`Catalog.UnitTests` e `Catalog.IntegrationTests`). | Projetos dedicados baseados em **xUnit**. |

---

## 📁 4. Estrutura de Diretórios

```text
Catalog/
├── Catalog.slnx                             # Solution file moderna (.NET 10)
├── README.md                                # Documentação técnica do microsserviço
├── Catalog.Domain/                          # Núcleo de domínio (entidades e regras puras)
│   ├── Catalog.Domain.csproj
│   └── Entities/
│       ├── Product.cs
│       ├── Brand.cs
│       └── CatalogType.cs
├── Catalog.Application/                     # Casos de uso e orquestração de aplicação
│   └── Catalog.Application.csproj
├── Catalog.Infrastructure/                  # Persistência e adaptadores de infraestrutura
│   └── Catalog.Infrastructure.csproj
├── Catalog.API/                             # Entrypoint ASP.NET Core (Minimal APIs)
│   ├── Program.cs                           # Configuração e mapeamento de rotas
│   ├── appsettings.json                     # Configurações de ambiente
│   ├── appsettings.Development.json
│   ├── Catalog.API.csproj
│   └── Properties/
│       └── launchSettings.json
└── Tests/                                   # Suíte de testes automatizados
    ├── Catalog.UnitTests/                   # Testes unitários rápidos e isolados
    │   ├── Catalog.UnitTests.csproj
    │   └── Entities/                        # Invariantes de Product, Brand e CatalogType
    └── Catalog.IntegrationTests/            # Testes de integração de infraestrutura e API
        └── Catalog.IntegrationTests.csproj
```

---

## ⚖️ 5. Decisões de Arquitetura (ADRs) vs. eShopOnContainers Legado

Usamos o **eShopOnContainers** clássico como laboratório prático de estudo, mas adotamos uma postura crítica de modernização:

1. **Separação Física vs. Pastas Internas:**
   - *Legado:* No eShop original, pastas como `Infrastructure` e `Model` ficavam muitas vezes agrupadas dentro do mesmo projeto de API, o que facilitava vazamento de dependências.
   - *Decisão Atual:* Projetos separados fisicamente (`Catalog.Domain`, `Catalog.Infrastructure`, etc.). O compilador do .NET impede que a camada de domínio acesse o banco ou a camada HTTP.
2. **Minimal APIs vs. Controllers Pesados:**
   - *Legado:* Controllers herdeiros de `ControllerBase` com grande boilerplate e sobrecarga de convenções.
   - *Decisão Atual:* Minimal APIs do .NET 10 em `Program.cs`, oferecendo maior clareza, menor alocação de memória e performance superior.
3. **Sem Over-Engineering Prematuro:**
   - *Legado:* Inserção antecipada de Repositórios Genéricos, MediatR e decorators antes da real necessidade.
   - *Decisão Atual:* Adição apenas do que é indispensável em cada etapa. O código cresce guiado pelo fluxo: `CONSTRUIR → ENTENDER → VALIDAR → DOCUMENTAR`.

---

## 🚀 6. Como Executar o Projeto

### Pré-requisitos
- [.NET SDK 10.0](https://dotnet.microsoft.com/download) instalado no ambiente.

### Passos
1. Abra o terminal e navegue até o diretório do microsserviço:
   ```bash
   cd Catalog
   ```

2. Restaure as dependências de todos os projetos da solution:
   ```bash
   dotnet restore
   ```

3. Compile a solução:
   ```bash
   dotnet build
   ```

4. Execute o microsserviço através da API:
   ```bash
   dotnet run --project Catalog.API/Catalog.API.csproj
   ```

5. O serviço estará acessível nos endpoints:
   - Raiz: `http://localhost:<porta>/` (Retorna mensagem de status)
   - Health Check: `http://localhost:<porta>/health` (Retorna `Healthy`)
   - Swagger UI (Development): `http://localhost:<porta>/swagger`

---

## 🧪 7. Como Executar os Testes

Para rodar todos os testes unitários e de integração:

```bash
dotnet test
```

Para rodar exclusivamente os testes de unidade:
```bash
dotnet test Tests/Catalog.UnitTests/Catalog.UnitTests.csproj
```

---

## 📖 8. Relação com o Livro Vivo

Este microsserviço é o laboratório de implementação dos seguintes capítulos do livro **“Construindo Microsserviços”** ([livro_vivo_de_engenharia.html](../livro_vivo_de_engenharia.html)):

- **Capítulo 1:** Entendendo o Problema (Requisitos 1.1 a 1.7)
- **Capítulo 2:** Domínio (2.1 a 2.8: projeto Domain, entidades `Product`/`Brand`/`CatalogType`, regras de negócio, decisão sobre Value Objects, relacionamentos por IDs, decisões sobre abstrações e testes unitários xUnit com padrão AAA)
- **Capítulo 3:** Aplicação (3.1 Criando o projeto Application - Próxima etapa)
- **Capítulo 4:** Infraestrutura (4.1 Criando o projeto Infrastructure)
- **Capítulo 5:** API (5.1 Criando o projeto API, Swagger em Development e 5.9 Health Check)

Conforme novas entidades, persistência com banco de dados, DTOs e eventos forem construídos, a documentação e os capítulos do livro vivo serão incrementados em tempo real.
