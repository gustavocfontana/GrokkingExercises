# Convenções de Código

Este documento define as convenções utilizadas no projeto GrokkingExercises.

---

## 🌍 Idiomas

### Código
- **Inglês** para todo o código (classes, métodos, variáveis, parâmetros)
- Mantém compatibilidade com padrões internacionais
- Facilita integração com bibliotecas e frameworks

```csharp
// ✅ CORRETO
public int Exercise11_BinarySearch(int[] sortedList, int target)
{
    int left = 0;
    int right = sortedList.Length - 1;
    // ...
}

// ❌ ERRADO
public int Exercicio11_BuscaBinaria(int[] listaOrdenada, int alvo)
{
    int esquerda = 0;
    int direita = listaOrdenada.Length - 1;
    // ...
}
```

### Comentários
- **Português** para todos os comentários
- Facilita compreensão para desenvolvedores brasileiros
- Inclui comentários XML (/// summary)

```csharp
// ✅ CORRETO
/// <summary>
/// Busca binária em uma lista ordenada.
/// </summary>
/// <param name="sortedList">Lista ordenada de inteiros</param>
/// <param name="target">Valor a ser buscado</param>
/// <returns>Índice do elemento ou -1 se não encontrado</returns>
public static int BinarySearch(int[] sortedList, int target)
{
    // Calcula o meio evitando overflow
    var mid = left + (right - left) / 2;
}

// ❌ ERRADO
/// <summary>
/// Binary search in a sorted list.
/// </summary>
public static int BinarySearch(int[] sortedList, int target)
{
    // Calculate middle avoiding overflow
    var mid = left + (right - left) / 2;
}
```

### Documentação
- **Português** para toda documentação (.md files)
- Guias, tutoriais e explicações em português
- Exemplos e diagramas em português

---

## 📝 Naming Conventions

### Classes e Métodos
- **PascalCase** para classes, métodos, propriedades públicas

```csharp
public class BinarySearchExercises { }
public int Exercise11_BinarySearch() { }
public string Label { get; set; }
```

### Variáveis e Parâmetros
- **camelCase** para variáveis locais e parâmetros

```csharp
int left = 0;
int right = sortedList.Length - 1;
string resultText = "success";
```

### Constantes
- **PascalCase** ou **UPPER_CASE** (preferir PascalCase)

```csharp
// Preferido
public const int MaxAttempts = 100;

// Aceitável para constantes "clássicas"
public const int MAX_ATTEMPTS = 100;
```

### Interfaces
- Prefixo **I** seguido de PascalCase

```csharp
public interface IConsoleIO { }
public interface IMenuOption { }
```

---

## 💬 Comentários

### Comentários XML (///)
Obrigatórios para:
- Classes públicas
- Métodos públicos
- Interfaces
- Propriedades públicas

```csharp
/// <summary>
/// Implementação básica de busca binária.
/// Complexidade: O(log n) - muito mais eficiente que busca linear O(n).
/// </summary>
public class BinarySearchClass
{
    /// <summary>
    /// Busca binária em uma lista ordenada.
    /// </summary>
    /// <param name="sortedList">Lista ordenada de inteiros</param>
    /// <param name="target">Valor a ser buscado</param>
    /// <returns>Índice do elemento ou -1 se não encontrado</returns>
    public static int BinarySearch(int[] sortedList, int target)
    {
        // ...
    }
}
```

### Comentários Inline (//)
- Explicam **por quê**, não **o quê**
- Utilizados para lógica não óbvia
- Português, claro e conciso

```csharp
// ✅ CORRETO - explica o raciocínio
// Calcula o meio evitando overflow em listas grandes
var mid = left + (right - left) / 2;

// ✅ CORRETO - explica decisão importante
result = mid; // Esse pode ser o resultado
right = mid - 1; // Mas vamos buscar à esquerda para ver se tem um menor índice

// ❌ ERRADO - apenas repete o código
// Define mid como left mais right menos left dividido por 2
var mid = left + (right - left) / 2;
```

### Comentários em Testes
- Padrão **AAA em português**
- Preparar (Arrange), Executar (Act), Verificar (Assert)

```csharp
[Fact]
public void Exercise11_BinarySearch_WhenTargetExists_ReturnsCorrectIndex()
{
    // Preparar (Arrange)
    var numbers = new[] { 1, 3, 5, 7, 9, 11 };
    var target = 7;

    // Executar (Act)
    var result = _exercises.Exercise11_BinarySearch(numbers, target);

    // Verificar (Assert)
    Assert.Equal(3, result);
}
```

---

## 📏 Formatação

### Indentação
- **4 espaços** para C# (nunca tabs)
- **2 espaços** para TypeScript/Angular (se aplicável)

### Line Length
- **Máximo 120 caracteres por linha**
- Quebrar linhas longas de forma legível

```csharp
// ✅ CORRETO
var valueText = index >= 0
    ? numbers[index].ToString()
    : "-1";
io.WriteLine($"Result: {valueText}");

// ❌ ERRADO - linha muito longa
io.WriteLine($"First element greater than {x}: index {index} (value: {(index >= 0 ? numbers[index] : -1)})");
```

### Chaves
- **Estilo Allman** (chaves em nova linha)

```csharp
// ✅ CORRETO
if (condition)
{
    DoSomething();
}

// ❌ ERRADO (K&R style)
if (condition) {
    DoSomething();
}
```

### Espaçamento
- Espaço após `if`, `for`, `while`, etc.
- Espaço ao redor de operadores

```csharp
// ✅ CORRETO
if (left <= right)
{
    var mid = left + (right - left) / 2;
}

// ❌ ERRADO
if(left<=right)
{
    var mid=left+(right-left)/2;
}
```

---

## 🏗️ Organização de Arquivos

### Estrutura de Pastas
```
GrokkingExercises/
├── Core/
│   └── Domain/           # Lógica de negócio (inglês)
├── Presentation/
│   └── Console/          # UI (inglês com labels em português)
├── Infrastructure/
│   └── IO/               # Dependências externas (inglês)
└── Tests/                # Testes (inglês com comentários em português)
```

### Namespaces
- Seguem estrutura de pastas
- PascalCase

```csharp
namespace GrokkingExercises.Core.Domain.Exercises.Chapter01;
namespace GrokkingExercises.Presentation.Console.Menus;
```

### Um Tipo por Arquivo
- Cada classe/interface em seu próprio arquivo
- Nome do arquivo = nome da classe

```
BinarySearchExercises.cs → class BinarySearchExercises
IConsoleIO.cs → interface IConsoleIO
```

---

## 🧪 Convenções de Testes

### Nomenclatura de Métodos
Padrão: `[MethodName]_[Scenario]_[ExpectedBehavior]`

```csharp
// ✅ Exemplos corretos
Exercise11_BinarySearch_WhenTargetExists_ReturnsCorrectIndex()
Exercise13_FirstGreaterThanX_WhenListIsEmpty_ReturnsMinusOne()
Exercise17_SearchRotated_WhenTargetDoesNotExist_ReturnsMinusOne()
```

### Regiões
- Agrupa testes por exercício
- Título em português

```csharp
#region Exercício 1.1 - Binary Search Básico
    // testes aqui
#endregion

#region Exercício 1.4 - Primeira Ocorrência
    // testes aqui
#endregion
```

---

## 📚 Documentação

### Arquivos .md
- **Português** para toda documentação
- Markdown bem formatado
- Exemplos claros e visuais

### README.md
- Instruções em português
- Comandos e código em inglês
- Links para outros documentos

### Guias e Tutoriais
- Linguagem acessível para iniciantes
- Exemplos práticos
- Diagramas e visualizações quando útil

---

## ✅ Checklist de Revisão

Antes de commitar código, verifique:

- [ ] Código em **inglês**
- [ ] Comentários em **português**
- [ ] Comentários XML em classes/métodos públicos
- [ ] PascalCase para classes/métodos
- [ ] camelCase para variáveis/parâmetros
- [ ] Linhas ≤ 120 caracteres
- [ ] Indentação: 4 espaços
- [ ] Chaves estilo Allman
- [ ] Testes seguem padrão AAA em português
- [ ] Documentação atualizada

---

## 📖 Exemplos Práticos

### Exemplo Completo de Classe

```csharp
namespace GrokkingExercises.Core.Domain.Exercises.Chapter01;

/// <summary>
/// Implementação básica de busca binária.
/// Complexidade: O(log n) - muito mais eficiente que busca linear O(n).
/// </summary>
public class BinarySearchClass
{
    /// <summary>
    /// Busca binária em uma lista ordenada.
    /// </summary>
    /// <param name="sortedList">Lista ordenada de inteiros</param>
    /// <param name="target">Valor a ser buscado</param>
    /// <returns>Índice do elemento ou -1 se não encontrado</returns>
    public static int BinarySearch(int[] sortedList, int target)
    {
        var left = 0;
        var right = sortedList.Length - 1;

        while (left <= right)
        {
            // Calcula o meio evitando overflow
            var mid = left + (right - left) / 2;

            if (sortedList[mid] == target)
            {
                return mid; // Encontrou!
            }
            else if (sortedList[mid] < target)
            {
                left = mid + 1; // Busca na metade direita
            }
            else
            {
                right = mid - 1; // Busca na metade esquerda
            }
        }

        return -1; // Não encontrado
    }
}
```

### Exemplo Completo de Teste

```csharp
namespace GrokkingExercises.Tests.Core.Domain.Exercises.Chapter01;

/// <summary>
/// Testes automatizados para os exercícios de Binary Search.
/// Utiliza o padrão AAA (Arrange-Act-Assert) em português.
/// </summary>
public class BinarySearchExercisesTests
{
    private readonly BinarySearchExercises _exercises;

    public BinarySearchExercisesTests()
    {
        _exercises = new BinarySearchExercises();
    }

    #region Exercício 1.1 - Binary Search Básico

    [Fact]
    public void Exercise11_BinarySearch_WhenTargetExists_ReturnsCorrectIndex()
    {
        // Preparar (Arrange)
        var numbers = new[] { 1, 3, 5, 7, 9, 11 };
        var target = 7;

        // Executar (Act)
        var result = _exercises.Exercise11_BinarySearch(numbers, target);

        // Verificar (Assert)
        Assert.Equal(3, result);
    }

    #endregion
}
```

---

## 🎯 Objetivos das Convenções

1. **Consistência** - Código uniforme e previsível
2. **Legibilidade** - Fácil de entender para iniciantes
3. **Manutenibilidade** - Simples de modificar e expandir
4. **Internacionalização** - Compatível com padrões globais
5. **Educação** - Comentários em português facilitam aprendizado

---

*Última atualização: 2026-02-02*
