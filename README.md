# 🏗️ Construindo Microsserviços — Laboratório Vivo de Engenharia

> **Aprenda construindo. Entenda o porquê. Domine o como.**  
> Projeto prático de arquitetura de software distribuída, construído com .NET 10, Clean Architecture e princípios agnósticos de tecnologia.

---

## 🌟 Visão Geral do Repositório

Este repositório é composto por dois pilares integrados que evoluem juntos:

1. **📖 O Livro Vivo de Engenharia (`livro_vivo_de_engenharia.html`):**  
   Um guia interativo e visual que documenta o método de construção de software passo a passo. O livro possui um **Sumário Mestre** permanente de 15 capítulos organizado pela metáfora da construção de uma casa e pelo ciclo mental reutilizável de engenharia.
   
2. **💻 O Laboratório Prático (`Catalog/`):**  
   A implementação do sistema de microsserviços. Iniciamos pelo microsserviço **Catalog** utilizando .NET 10, com estrutura física limpa, testes automatizados e Minimal APIs.

---

## 🧭 O Método de Construção: A Metáfora da Casa

O objetivo deste projeto não é memorizar frameworks ou nomes fixos de entidades (`Product`, `Repository`, `Controller`). O verdadeiro aprendizado é o **processo de engenharia reutilizável**:

```
PLANTA (Cap. 1: Requisitos & Escopo)
  ↓
FUNDAÇÃO (Cap. 2: Domínio & Entidades Puras)
  ↓
ESTRUTURA (Cap. 3: Aplicação & Casos de Uso)
  ↓
PAREDES (Cap. 4: Infraestrutura & Persistência)
  ↓
INSTALAÇÕES (Cap. 5-7: API, Comunicação & Segurança)
  ↓
INSPEÇÃO (Cap. 8-9: Testes & Observabilidade)
  ↓
HABITE-SE (Cap. 10-11: Containers & CI/CD)
  ↓
REFORÇO (Cap. 12-14: Resiliência, Evolução & Decisões)
  ↓
CIDADE CONECTADA (Cap. 15: Microsserviços Integrados)
```

O mesmo método que ergue este catálogo de loja pode ser reaplicado para construir um sistema financeiro, uma farmácia, um hospital ou qualquer outro domínio. **O domínio muda; o método de construção permanece.**

---

## 📂 Estrutura do Repositório

```text
.
├── README.md                            # Documentação principal do repositório
├── .gitignore                           # Exclusão de binários e artefatos de build do .NET
├── livro_vivo_de_engenharia.html        # O Livro Vivo com o Sumário Mestre interativo
└── Catalog/                             # Microsserviço de Catálogo de Produtos
    ├── README.md                        # Documentação técnica detalhada do Catalog
    ├── Catalog.slnx                     # Solution em formato moderno (.NET 10)
    ├── Catalog.Domain/                  # Camada de Domínio pura (zero dependências)
    ├── Catalog.Application/             # Casos de uso e orquestração
    ├── Catalog.Infrastructure/          # Adaptadores técnicos, persistência e integrações
    ├── Catalog.API/                     # Ponto de entrada HTTP com Minimal APIs
    └── Tests/                           # Suíte de testes unitários e de integração
        ├── Catalog.UnitTests/
        └── Catalog.IntegrationTests/
```

---

## 📦 O Microsserviço Catalog

O **Catalog** é o primeiro microsserviço erguido no laboratório. Ele é responsável pelo catálogo de produtos, marcas e categorias:

- **Arquitetura Limpa:** Separação física de projetos para forçar o isolamento do domínio.
- **Minimal APIs:** Performance superior e ausência de boilerplate legada no `Program.cs`.
- **Health Checks:** Endpoint nativo `/health` para monitoramento e orquestração.
- **Documentação Detalhada:** Consulte o [README do Catalog](Catalog/README.md).

---

## ⚡ Como Começar

### Pré-requisitos
- [.NET SDK 10.0](https://dotnet.microsoft.com/download)
- Navegador web moderno (Edge, Chrome, Firefox) para ler o livro vivo.

### Abrir o Livro Vivo
Basta abrir o arquivo no seu navegador:
```powershell
Start-Process "livro_vivo_de_engenharia.html"
```

### Rodar o Microsserviço Catalog
```bash
cd Catalog
dotnet restore
dotnet build
dotnet test
dotnet run --project Catalog.API/Catalog.API.csproj
```

---

## 🤝 Relação com o eShopOnContainers

Usamos o clássico eShopOnContainers da Microsoft como laboratório para analisar problemas reais de sistemas distribuídos. Porém, não reproduzimos código antigo de forma cega: entendemos a necessidade, desenvolvemos a solução moderna em .NET 10, comparamos abordagens e registramos os trade-offs de engenharia.
