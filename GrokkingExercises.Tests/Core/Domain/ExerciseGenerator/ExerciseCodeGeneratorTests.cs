using GrokkingExercises.Core.Domain.ExerciseGenerator;
using Xunit;

namespace GrokkingExercises.Tests.Core.Domain.ExerciseGenerator;

/// <summary>
/// Testes para o gerador de código de exercícios.
/// Garante que o código gerado segue todas as convenções.
/// </summary>
public class ExerciseCodeGeneratorTests
{
    private readonly ExerciseCodeGenerator _generator;

    public ExerciseCodeGeneratorTests()
    {
        _generator = new ExerciseCodeGenerator();
    }

    #region Testes de Geração de Classe de Exercícios

    [Fact]
    public void GenerateExerciseClass_WithValidTemplate_ContainsNamespace()
    {
        // Preparar (Arrange)
        var exercises = CreateSampleExercises();

        // Executar (Act)
        var result = _generator.GenerateExerciseClass("02", "Selection Sort", exercises);

        // Verificar (Assert)
        Assert.Contains("namespace GrokkingExercises.Core.Domain.Exercises.Chapter02", result);
    }

    [Fact]
    public void GenerateExerciseClass_WithValidTemplate_ContainsClassName()
    {
        // Preparar (Arrange)
        var exercises = CreateSampleExercises();

        // Executar (Act)
        var result = _generator.GenerateExerciseClass("02", "Selection Sort", exercises);

        // Verificar (Assert)
        Assert.Contains("public class Chapter02Exercises", result);
    }

    [Fact]
    public void GenerateExerciseClass_WithValidTemplate_ContainsXmlComments()
    {
        // Preparar (Arrange)
        var exercises = CreateSampleExercises();

        // Executar (Act)
        var result = _generator.GenerateExerciseClass("02", "Selection Sort", exercises);

        // Verificar (Assert)
        Assert.Contains("/// <summary>", result);
        Assert.Contains("/// Exercícios do Capítulo 02 - Selection Sort.", result);
    }

    [Fact]
    public void GenerateExerciseClass_WithMultipleExercises_ContainsAllMethods()
    {
        // Preparar (Arrange)
        var exercises = CreateSampleExercises();

        // Executar (Act)
        var result = _generator.GenerateExerciseClass("02", "Selection Sort", exercises);

        // Verificar (Assert)
        Assert.Contains("Exercise21_", result);
        Assert.Contains("Exercise22_", result);
    }

    [Fact]
    public void GenerateExerciseClass_WithValidTemplate_ContainsPortugueseComments()
    {
        // Preparar (Arrange)
        var exercises = CreateSampleExercises();

        // Executar (Act)
        var result = _generator.GenerateExerciseClass("02", "Selection Sort", exercises);

        // Verificar (Assert)
        Assert.Contains("// Exercicio 2.1", result);
        Assert.Contains("// TODO: Implementar", result);
    }

    #endregion

    #region Testes de Geração de Testes

    [Fact]
    public void GenerateTestClass_WithValidTemplate_ContainsUsingStatements()
    {
        // Preparar (Arrange)
        var exercises = CreateSampleExercises();

        // Executar (Act)
        var result = _generator.GenerateTestClass("02", "Selection Sort", exercises);

        // Verificar (Assert)
        Assert.Contains("using GrokkingExercises.Core.Domain.Exercises.Chapter02;", result);
        Assert.Contains("using Xunit;", result);
    }

    [Fact]
    public void GenerateTestClass_WithValidTemplate_ContainsTestClassName()
    {
        // Preparar (Arrange)
        var exercises = CreateSampleExercises();

        // Executar (Act)
        var result = _generator.GenerateTestClass("02", "Selection Sort", exercises);

        // Verificar (Assert)
        Assert.Contains("public class Chapter02ExercisesTests", result);
    }

    [Fact]
    public void GenerateTestClass_WithValidTemplate_ContainsAAAComments()
    {
        // Preparar (Arrange)
        var exercises = CreateSampleExercises();

        // Executar (Act)
        var result = _generator.GenerateTestClass("02", "Selection Sort", exercises);

        // Verificar (Assert)
        Assert.Contains("// Preparar (Arrange)", result);
        Assert.Contains("// Executar (Act)", result);
        Assert.Contains("// Verificar (Assert)", result);
    }

    [Fact]
    public void GenerateTestClass_WithValidTemplate_ContainsRegions()
    {
        // Preparar (Arrange)
        var exercises = CreateSampleExercises();

        // Executar (Act)
        var result = _generator.GenerateTestClass("02", "Selection Sort", exercises);

        // Verificar (Assert)
        Assert.Contains("#region Exercício 2.1", result);
        Assert.Contains("#endregion", result);
    }

    #endregion

    #region Testes de Geração de Runner

    [Fact]
    public void GenerateRunnerClass_WithValidTemplate_ContainsRunnerClassName()
    {
        // Preparar (Arrange)
        var exercises = CreateSampleExercises();

        // Executar (Act)
        var result = _generator.GenerateRunnerClass("02", "Selection Sort", exercises);

        // Verificar (Assert)
        Assert.Contains("public static class Chapter02Runner", result);
    }

    [Fact]
    public void GenerateRunnerClass_WithValidTemplate_ContainsRunMethod()
    {
        // Preparar (Arrange)
        var exercises = CreateSampleExercises();

        // Executar (Act)
        var result = _generator.GenerateRunnerClass("02", "Selection Sort", exercises);

        // Verificar (Assert)
        Assert.Contains("public static void Run(IConsoleIO io)", result);
    }

    [Fact]
    public void GenerateRunnerClass_WithValidTemplate_ContainsMenuOptions()
    {
        // Preparar (Arrange)
        var exercises = CreateSampleExercises();

        // Executar (Act)
        var result = _generator.GenerateRunnerClass("02", "Selection Sort", exercises);

        // Verificar (Assert)
        Assert.Contains(".AddOption(\"2.1\"", result);
        Assert.Contains("RunExercise21", result);
    }

    [Fact]
    public void GenerateRunnerClass_WithValidTemplate_ContainsPortugueseLabels()
    {
        // Preparar (Arrange)
        var exercises = CreateSampleExercises();

        // Executar (Act)
        var result = _generator.GenerateRunnerClass("02", "Selection Sort", exercises);

        // Verificar (Assert)
        Assert.Contains("\"Voltar\"", result);
    }

    #endregion

    #region Métodos Auxiliares

    private List<ExerciseTemplate> CreateSampleExercises()
    {
        return new List<ExerciseTemplate>
        {
            new ExerciseTemplate
            {
                ChapterNumber = "02",
                ChapterTitle = "Selection Sort",
                ExerciseNumber = "2.1",
                ExerciseTitle = "Implementação Básica",
                Description = "Implemente o algoritmo de selection sort",
                Example = "SelectionSort([3, 1, 4, 2]) -> [1, 2, 3, 4]",
                Parameters = new List<Parameter>
                {
                    new Parameter { Type = "int[]", Name = "array", Description = "Array a ordenar" }
                },
                ReturnType = "int[]",
                ReturnDescription = "Array ordenado"
            },
            new ExerciseTemplate
            {
                ChapterNumber = "02",
                ChapterTitle = "Selection Sort",
                ExerciseNumber = "2.2",
                ExerciseTitle = "Encontrar Menor Elemento",
                Description = "Encontre o índice do menor elemento",
                Example = "FindSmallest([3, 1, 4, 2]) -> 1",
                Parameters = new List<Parameter>
                {
                    new Parameter { Type = "int[]", Name = "array", Description = "Array de entrada" }
                },
                ReturnType = "int",
                ReturnDescription = "Índice do menor elemento"
            }
        };
    }

    #endregion
}
