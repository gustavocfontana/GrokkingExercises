# Guia do Gerador de Exercícios

Este guia explica como usar o gerador de exercícios para criar novos capítulos seguindo o padrão estabelecido.

---

## 🎯 Objetivo

O **Gerador de Exercícios** automatiza a criação de:
- ✅ Classes de exercícios com comentários em português
- ✅ Testes automatizados com padrão AAA
- ✅ Runners para console app
- ✅ Conformidade com CLAUDE.MD e convenções do projeto

---

## 🚀 Como Usar

### Opção 1: Usar o ExerciseGeneratorApp

1. **Execute o aplicativo gerador:**
```bash
cd /Users/gustavofontana/RiderProjects/GrokkingExercises
dotnet run --project ExerciseGeneratorApp.cs
```

2. **Copie os arquivos gerados** para as pastas apropriadas

3. **Integre no projeto principal** (adicione ao Program.cs)

### Opção 2: Usar Programaticamente

```csharp
using GrokkingExercises.Core.Domain.ExerciseGenerator;

// 1. Criar o serviço
var service = new ExerciseGeneratorService();

// 2. Definir templates de exercícios
var exercises = new List<ExerciseTemplate>
{
    new ExerciseTemplate
    {
        ChapterNumber = "03",
        ChapterTitle = "Recursion",
        ExerciseNumber = "3.1",
        ExerciseTitle = "Fatorial",
        Description = "Calcule o fatorial de um número usando recursão.",
        Example = "Factorial(5) -> 120",
        Parameters = new List<Parameter>
        {
            new Parameter { Type = "int", Name = "n", Description = "Número inteiro" }
        },
        ReturnType = "int",
        ReturnDescription = "Fatorial de n"
    }
};

// 3. Gerar arquivos
var files = service.GenerateChapter("03", "Recursion", exercises);

// 4. Salvar ou exibir
foreach (var file in files)
{
    Console.WriteLine($"Arquivo: {file.Key}");
    Console.WriteLine(file.Value);
}
```

---

## 📋 Estrutura do ExerciseTemplate

### Campos Obrigatórios

```csharp
new ExerciseTemplate
{
    // Identificação do capítulo
    ChapterNumber = "02",        // Ex: "01", "02", "03"
    ChapterTitle = "Selection Sort",  // Título do capítulo

    // Identificação do exercício
    ExerciseNumber = "2.1",      // Ex: "1.1", "2.3", "10.5"
    ExerciseTitle = "Implementação Básica",  // Título curto

    // Descrição
    Description = "Implemente o algoritmo de selection sort.",

    // Exemplo de uso (opcional mas recomendado)
    Example = "SelectionSort([3, 1, 4]) -> [1, 3, 4]",

    // Parâmetros do método
    Parameters = new List<Parameter>
    {
        new Parameter
        {
            Type = "int[]",      // Tipo do parâmetro
            Name = "array",      // Nome em camelCase
            Description = "Array a ordenar"
        }
    },

    // Retorno
    ReturnType = "int[]",        // Tipo de retorno
    ReturnDescription = "Array ordenado"
}
```

### Tipos Comuns

| Tipo | Uso |
|------|-----|
| `int` | Números inteiros |
| `int[]` | Array de inteiros |
| `string` | Texto |
| `string[]` | Array de strings |
| `bool` | Verdadeiro/Falso |
| `List<int>` | Lista genérica |
| `(int, int)` | Tupla |
| `void` | Sem retorno |

---

## 📂 Arquivos Gerados

Para cada capítulo, o gerador cria 3 arquivos:

### 1. `ChapterXXExercises.cs`
**Localização:** `Core/Domain/Exercises/ChapterXX/`

```csharp
namespace GrokkingExercises.Core.Domain.Exercises.Chapter02;

/// <summary>
/// Exercícios do Capítulo 02 - Selection Sort.
/// </summary>
public class Chapter02Exercises
{
    // Exercicio 2.1 - Implementação Básica
    // Implemente o algoritmo de selection sort.
    // Exemplo:
    // SelectionSort([3, 1, 4]) -> [1, 3, 4]
    public int[] Exercise21_ImplementacaoBasica(int[] array)
    {
        // TODO: Implementar
        throw new NotImplementedException();
    }
}
```

### 2. `ChapterXXExercisesTests.cs`
**Localização:** `Tests/Core/Domain/Exercises/ChapterXX/`

```csharp
/// <summary>
/// Testes automatizados para os exercícios do Capítulo 02.
/// Utiliza o padrão AAA (Arrange-Act-Assert) em português.
/// </summary>
public class Chapter02ExercisesTests
{
    private readonly Chapter02Exercises _exercises;

    #region Exercício 2.1 - Implementação Básica

    [Fact]
    public void Exercise21_ImplementacaoBasica_WhenValidInput_ReturnsExpectedResult()
    {
        // Preparar (Arrange)
        // TODO: Configurar dados de teste

        // Executar (Act)
        // var result = _exercises.Exercise21_ImplementacaoBasica(...);

        // Verificar (Assert)
        // Assert.Equal(expected, result);
    }

    #endregion
}
```

### 3. `ChapterXXRunner.cs`
**Localização:** `Presentation/Console/Menus/`

```csharp
/// <summary>
/// Runner para executar os exercícios do Capítulo 02 - Selection Sort.
/// </summary>
public static class Chapter02Runner
{
    public static void Run(IConsoleIO io)
    {
        var menu = new ConsoleMenu("Chapter 02 - Selection Sort", io)
            .AddOption("2.1", "Implementação Básica", () => RunExercise21(io));

        menu.Run(exitKey: "0", exitLabel: "Voltar");
    }

    private static void RunExercise21(IConsoleIO io)
    {
        var exercises = new Chapter02Exercises();

        // TODO: Configurar dados de entrada
        // TODO: Executar exercício
        // TODO: Exibir resultado

        io.WriteLine("TODO: Implementar teste");
    }
}
```

---

## 🔧 Passos Após Geração

### 1. Copiar Arquivos

```bash
# Criar diretórios se necessário
mkdir -p GrokkingExercises/Core/Domain/Exercises/Chapter02
mkdir -p GrokkingExercises.Tests/Core/Domain/Exercises/Chapter02

# Copiar arquivos gerados
cp Chapter02Exercises.cs GrokkingExercises/Core/Domain/Exercises/Chapter02/
cp Chapter02ExercisesTests.cs GrokkingExercises.Tests/Core/Domain/Exercises/Chapter02/
cp Chapter02Runner.cs GrokkingExercises/Presentation/Console/Menus/
```

### 2. Integrar no Program.cs

```csharp
var menu = new ConsoleMenu("Grokking Exercises", io)
    .AddOption("1", "Capítulo 01 - Binary Search", () =>
        Chapter01Runner.Run(io), pauseAfterAction: false)
    .AddOption("2", "Capítulo 02 - Selection Sort", () =>  // ← ADICIONAR
        Chapter02Runner.Run(io), pauseAfterAction: false); // ← ADICIONAR
```

### 3. Implementar Exercícios

Substitua `throw new NotImplementedException();` pela implementação real:

```csharp
// ANTES
public int[] Exercise21_ImplementacaoBasica(int[] array)
{
    // TODO: Implementar
    throw new NotImplementedException();
}

// DEPOIS
public int[] Exercise21_ImplementacaoBasica(int[] array)
{
    for (int i = 0; i < array.Length - 1; i++)
    {
        int minIndex = FindSmallestIndex(array, i);
        (array[i], array[minIndex]) = (array[minIndex], array[i]);
    }
    return array;
}
```

### 4. Adicionar Testes Específicos

Expanda os testes com casos específicos:

```csharp
[Fact]
public void Exercise21_ImplementacaoBasica_WithUnsortedArray_ReturnsSortedArray()
{
    // Preparar (Arrange)
    var array = new[] { 64, 25, 12, 22, 11 };
    var expected = new[] { 11, 12, 22, 25, 64 };

    // Executar (Act)
    var result = _exercises.Exercise21_ImplementacaoBasica(array);

    // Verificar (Assert)
    Assert.Equal(expected, result);
}

[Fact]
public void Exercise21_ImplementacaoBasica_WithEmptyArray_ReturnsEmptyArray()
{
    // Preparar (Arrange)
    var array = Array.Empty<int>();

    // Executar (Act)
    var result = _exercises.Exercise21_ImplementacaoBasica(array);

    // Verificar (Assert)
    Assert.Empty(result);
}
```

### 5. Implementar Runners

Adicione exemplos práticos no runner:

```csharp
private static void RunExercise21(IConsoleIO io)
{
    var exercises = new Chapter02Exercises();
    var array = new[] { 64, 25, 12, 22, 11 };

    io.WriteLine("Array original: [64, 25, 12, 22, 11]");

    var sorted = exercises.Exercise21_ImplementacaoBasica(array);

    io.WriteLine($"Array ordenado: [{string.Join(", ", sorted)}]");
}
```

---

## 📊 Exemplo Completo: Capítulo de Recursão

```csharp
var recursionExercises = new List<ExerciseTemplate>
{
    new ExerciseTemplate
    {
        ChapterNumber = "03",
        ChapterTitle = "Recursion",
        ExerciseNumber = "3.1",
        ExerciseTitle = "Fatorial",
        Description = "Calcule o fatorial de um número usando recursão.",
        Example = "Factorial(5) -> 120 (5 × 4 × 3 × 2 × 1)",
        Parameters = new List<Parameter>
        {
            new Parameter { Type = "int", Name = "n", Description = "Número inteiro positivo" }
        },
        ReturnType = "int",
        ReturnDescription = "Fatorial de n"
    },
    new ExerciseTemplate
    {
        ChapterNumber = "03",
        ChapterTitle = "Recursion",
        ExerciseNumber = "3.2",
        ExerciseTitle = "Soma Recursiva",
        Description = "Calcule a soma de todos os números em um array usando recursão.",
        Example = "SumArray([1, 2, 3, 4, 5]) -> 15",
        Parameters = new List<Parameter>
        {
            new Parameter { Type = "int[]", Name = "array", Description = "Array de inteiros" }
        },
        ReturnType = "int",
        ReturnDescription = "Soma de todos os elementos"
    },
    new ExerciseTemplate
    {
        ChapterNumber = "03",
        ChapterTitle = "Recursion",
        ExerciseNumber = "3.3",
        ExerciseTitle = "Contagem de Elementos",
        Description = "Conte o número de elementos em uma lista usando recursão.",
        Example = "CountElements([1, 2, 3]) -> 3",
        Parameters = new List<Parameter>
        {
            new Parameter { Type = "int[]", Name = "array", Description = "Array de inteiros" }
        },
        ReturnType = "int",
        ReturnDescription = "Número de elementos"
    }
};

var service = new ExerciseGeneratorService();
var files = service.GenerateChapter("03", "Recursion", recursionExercises);
```

---

## ✅ Checklist de Validação

Antes de usar o código gerado, verifique:

- [ ] ChapterNumber está correto (ex: "01", "02", "03")
- [ ] ChapterTitle descreve o tópico
- [ ] ExerciseNumber segue o padrão (ex: "3.1", "3.2")
- [ ] ExerciseTitle é claro e conciso
- [ ] Description explica o que fazer
- [ ] Example mostra input → output esperado
- [ ] Parameters têm Type, Name e Description
- [ ] ReturnType está correto
- [ ] Código gerado compila sem erros
- [ ] Comentários estão em português
- [ ] Código está em inglês
- [ ] Testes seguem padrão AAA em português
- [ ] Runner tem labels em português

---

## 🎨 Convenções Mantidas

O gerador automaticamente aplica:

### Código
- ✅ Inglês para nomes de classes, métodos, variáveis
- ✅ PascalCase para classes e métodos
- ✅ camelCase para parâmetros
- ✅ Namespace seguindo estrutura de pastas

### Comentários
- ✅ Português para todos os comentários
- ✅ XML comments (`/// <summary>`) em português
- ✅ Comentários inline explicativos

### Testes
- ✅ Padrão AAA em português
- ✅ Regiões organizadas por exercício
- ✅ Nomenclatura descritiva

### Runners
- ✅ Labels do menu em português
- ✅ "Voltar" ao invés de "Back"
- ✅ Estrutura consistente

---

## 🚨 Limitações Atuais

O gerador cria **estrutura básica**. Você ainda precisa:

1. **Implementar a lógica** dos exercícios
2. **Adicionar testes específicos** (casos limites, edge cases)
3. **Implementar runners** com exemplos práticos
4. **Adicionar validações** de entrada
5. **Documentar complexidade** (Big O notation)

---

## 💡 Dicas

### Para Exercícios Complexos

Se o exercício tem múltiplos passos ou é muito complexo:

```csharp
// Crie múltiplos métodos auxiliares
public int ComplexAlgorithm(int[] input)
{
    var step1 = PreprocessData(input);
    var step2 = ProcessData(step1);
    return FinalizeResult(step2);
}
```

### Para Exercícios com Múltiplos Retornos

Use tuplas:

```csharp
ReturnType = "(int min, int max)",
ReturnDescription = "Tupla com mínimo e máximo"
```

### Para Exercícios sem Retorno

Use `void`:

```csharp
ReturnType = "void",
ReturnDescription = "Não retorna valor"
```

---

## 📚 Próximos Capítulos Sugeridos

Baseado no Grokking Algorithms:

1. ✅ **Chapter 01** - Binary Search (implementado)
2. ⭐ **Chapter 02** - Selection Sort (exemplo no guia)
3. ⭐ **Chapter 03** - Recursion (exemplo no guia)
4. **Chapter 04** - Quicksort
5. **Chapter 05** - Hash Tables
6. **Chapter 06** - Breadth-First Search (BFS)
7. **Chapter 07** - Dijkstra's Algorithm
8. **Chapter 08** - Greedy Algorithms
9. **Chapter 09** - Dynamic Programming
10. **Chapter 10** - K-Nearest Neighbors (KNN)

---

## 🎯 Exemplo de Uso Rápido

```bash
# 1. Execute o gerador
dotnet run --project ExerciseGeneratorApp.cs

# 2. Copie o output para os arquivos
# 3. Adicione ao Program.cs
# 4. Implemente os exercícios
# 5. Execute e teste!

dotnet run
dotnet test
```

---

**Bons estudos e boa geração de exercícios!** 🚀
