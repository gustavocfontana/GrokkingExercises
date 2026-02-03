# 🎓 Grokking Exercises

Aprenda algoritmos e estruturas de dados praticando com exercícios interativos!

Projeto educacional completo com **Console App**, **Modo Prática (Quiz)**, **Gerador de Exercícios** e **Interface Web (Blazor)**.

---

## 🚀 Quick Start

### Console App
```bash
cd GrokkingExercises
dotnet run
```

### Blazor Web App
```bash
cd GrokkingExercises.Web
dotnet run
```
Acesse: `https://localhost:5001`

### Testes
```bash
dotnet test
```

---

## ✨ Features

### 📱 3 Interfaces Disponíveis

| Interface | Descrição | Status |
|-----------|-----------|--------|
| **Console App** | Terminal interativo com menus | ✅ Completo |
| **Blazor Web** | Interface web moderna | ✅ MVP |
| **API REST** | Endpoints para Angular | 📅 Planejado |

### 🎯 Funcionalidades

- **Exercícios Implementados**: 7 exercícios de Binary Search
- **Modo Prática**: Quiz interativo com 6 modos diferentes
- **Gerador de Código**: Cria novos exercícios automaticamente
- **Testes Automatizados**: 41 testes com xUnit
- **Interface Web**: Dashboard e gerador visual

---

## 📂 Estrutura do Projeto

```
GrokkingExercises/
├── GrokkingExercises/          # Console App (Clean Architecture)
│   ├── Core/Domain/            # Lógica de negócio
│   ├── Presentation/Console/   # UI Console
│   └── Infrastructure/IO/      # Dependências externas
├── GrokkingExercises.Tests/    # Testes automatizados (xUnit)
├── GrokkingExercises.Web/      # Blazor Server App
│   ├── Pages/                  # Páginas Razor
│   ├── Shared/                 # Componentes compartilhados
│   └── wwwroot/                # Assets estáticos
└── Documentação/               # 1.250+ linhas de docs
```

---

## 📚 Documentação

### 🎯 Começe Aqui
- **[SUMMARY.md](SUMMARY.md)** - 📋 Resumo executivo do projeto
- **[QUICK_START_WEB.md](QUICK_START_WEB.md)** - 🚀 Como executar a versão web

### 📖 Guias de Aprendizado
- **[PRACTICE_MODE.md](PRACTICE_MODE.md)** - 🎯 Modo Prática - Quiz interativo
- **[EXERCISES_GUIDE.md](EXERCISES_GUIDE.md)** - 📚 Guia completo de exercícios

### 🔧 Desenvolvimento
- **[CONVENTIONS.md](CONVENTIONS.md)** - 📐 Convenções de código
- **[GENERATOR_GUIDE.md](GENERATOR_GUIDE.md)** - ⚙️ Como usar o gerador
- **[BLAZOR_WEB.md](BLAZOR_WEB.md)** - 🌐 Documentação do Blazor

### 📊 Técnicos
- **[TESTS.md](TESTS.md)** - 🧪 Estratégia de testes
- **[GENERATOR_SUMMARY.md](GENERATOR_SUMMARY.md)** - Resumo do gerador

---

## 🎮 Modos de Uso

### 1. Console App
```
Grokking Exercises
1 - Capítulo 01 - Binary Search
P - 🎯 Modo Prática (Quiz Interativo)
G - ⚙️ Gerador de Código
0 - Sair
```

### 2. Modo Prática (Quiz)
- **Prática Rápida**: 5 exercícios aleatórios
- **Prova Completa**: Todos os exercícios
- **Por Dificuldade**: Fácil, Médio, Difícil
- **Modo Desafio**: Contra o tempo (2 minutos)

### 3. Gerador de Exercícios
- Cria automaticamente: Classes, Testes e Runners
- Segue 100% as convenções do projeto
- Preview do código gerado
- Validação automática

### 4. Blazor Web
- Dashboard interativo
- Gerador visual com formulários
- Preview em tempo real
- Responsive design

---

## 🏗️ Arquitetura

### Clean Architecture
- **Domain**: Lógica de negócio pura
- **Application**: Casos de uso
- **Infrastructure**: Frameworks e dependências
- **Presentation**: UI (Console + Web)

### Princípios
- ✅ SOLID
- ✅ DRY
- ✅ KISS
- ✅ YAGNI
- ✅ Dependency Injection

---

## 🧪 Testes

```bash
# Rodar todos os testes
dotnet test

# Com detalhes
dotnet test --logger "console;verbosity=detailed"

# Teste específico
dotnet test --filter "FullyQualifiedName~BinarySearch"
```

**Cobertura:**
- 29 testes de exercícios
- 12 testes do gerador
- 100% dos exercícios cobertos

---

## 🛠️ Tecnologias

- **C# 12** / **.NET 10**
- **Blazor Server** - UI web
- **xUnit** - Testes
- **Bootstrap 5** - Estilos
- **Clean Architecture**

---

## 📊 Estatísticas

| Métrica | Valor |
|---------|-------|
| Exercícios implementados | 7 (Binary Search) |
| Testes automatizados | 41 |
| Linhas de documentação | 1.250+ |
| Projetos na solução | 3 |
| Modos de prática | 6 |
| Conformidade CLAUDE.MD | 100% |

---

## 🎯 Exercícios Disponíveis

### Capítulo 01 - Binary Search
1. ✅ Binary Search Básico
2. ✅ Estimativa de Tentativas
3. ✅ Primeiro Maior que X
4. ✅ Primeira Ocorrência
5. ✅ Última Ocorrência
6. ✅ Lower Bound
7. ✅ Busca em Lista Rotacionada

### Próximos Capítulos (via Gerador)
- Chapter 02 - Selection Sort
- Chapter 03 - Recursion
- Chapter 04 - Quicksort
- ... (facilmente expansível)

---

## 💡 Como Contribuir

Este é um projeto educacional. Você pode:

1. **Adicionar novos exercícios** usando o gerador
2. **Melhorar documentação** existente
3. **Criar testes adicionais**
4. **Implementar novos capítulos**
5. **Melhorar a UI Blazor**

---

## 🎓 Para Quem é Este Projeto?

- **Iniciantes** em algoritmos
- **Estudantes** de Ciência da Computação
- **Desenvolvedores** querendo revisar conceitos
- **Professores** que querem material didático
- **Entusiastas** de Clean Code e Clean Architecture

---

## 🔧 Requisitos

- **.NET 10 SDK** ou superior
- **IDE**: Rider, Visual Studio, ou VS Code
- **Git** (para clonar)

---

## 📝 Licença

Este é um projeto educacional open-source.

---

## 🌟 Destaques

### Clean Code
- Código em inglês
- Comentários em português
- Naming conventions consistentes
- Line length ≤ 120 caracteres

### Pedagogia
- Explicações passo a passo
- Exemplos visuais
- Feedback imediato
- Progressão de dificuldade

### Tecnologia
- Full-stack C#
- Reutilização de código
- 3 interfaces integradas
- Testes automatizados

---

## 🚀 Começe Agora!

```bash
# Clone o repositório
git clone https://github.com/gustavofontana/GrokkingExercises.git

# Entre na pasta
cd GrokkingExercises

# Execute o console
cd GrokkingExercises
dotnet run

# Ou execute a versão web
cd ../GrokkingExercises.Web
dotnet run
```

---

**Bons estudos!** 🎓🚀

*Projeto desenvolvido com Clean Architecture, SOLID principles e muito ❤️*
