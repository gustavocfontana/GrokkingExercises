using GrokkingExercises.Core.Domain.Exercises.Chapter01;
using Xunit;

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

    [Fact]
    public void Exercise11_BinarySearch_WhenTargetDoesNotExist_ReturnsMinusOne()
    {
        // Preparar (Arrange)
        var numbers = new[] { 2, 4, 6, 8 };
        var target = 5;

        // Executar (Act)
        var result = _exercises.Exercise11_BinarySearch(numbers, target);

        // Verificar (Assert)
        Assert.Equal(-1, result);
    }

    [Fact]
    public void Exercise11_BinarySearch_WhenListIsEmpty_ReturnsMinusOne()
    {
        // Preparar (Arrange)
        var numbers = Array.Empty<int>();
        var target = 5;

        // Executar (Act)
        var result = _exercises.Exercise11_BinarySearch(numbers, target);

        // Verificar (Assert)
        Assert.Equal(-1, result);
    }

    [Fact]
    public void Exercise11_BinarySearch_WhenTargetIsFirstElement_ReturnsZero()
    {
        // Preparar (Arrange)
        var numbers = new[] { 1, 3, 5, 7, 9 };
        var target = 1;

        // Executar (Act)
        var result = _exercises.Exercise11_BinarySearch(numbers, target);

        // Verificar (Assert)
        Assert.Equal(0, result);
    }

    [Fact]
    public void Exercise11_BinarySearch_WhenTargetIsLastElement_ReturnsLastIndex()
    {
        // Preparar (Arrange)
        var numbers = new[] { 1, 3, 5, 7, 9 };
        var target = 9;

        // Executar (Act)
        var result = _exercises.Exercise11_BinarySearch(numbers, target);

        // Verificar (Assert)
        Assert.Equal(4, result);
    }

    #endregion

    #region Exercício 1.2 - Estimativa de Tentativas

    [Fact]
    public void Exercise12_MaxAttempts_ReturnsCorrectValues()
    {
        // Executar (Act)
        var (binaryMax, linearMax) = _exercises.Exercise12_MaxAttempts();

        // Verificar (Assert)
        Assert.Equal(20, binaryMax);
        Assert.Equal(1_000_000, linearMax);
    }

    #endregion

    #region Exercício 1.3 - Primeiro Maior que X

    [Fact]
    public void Exercise13_FirstGreaterThanX_WhenGreaterExists_ReturnsCorrectIndex()
    {
        // Preparar (Arrange)
        var numbers = new[] { 2, 4, 6, 8, 10, 12 };
        var x = 5;

        // Executar (Act)
        var result = _exercises.Exercise13_FirstGreaterThanX(numbers, x);

        // Verificar (Assert)
        Assert.Equal(2, result); // 6 is at index 2
    }

    [Fact]
    public void Exercise13_FirstGreaterThanX_WhenNoGreaterExists_ReturnsMinusOne()
    {
        // Preparar (Arrange)
        var numbers = new[] { 2, 4, 6, 8, 10, 12 };
        var x = 12;

        // Executar (Act)
        var result = _exercises.Exercise13_FirstGreaterThanX(numbers, x);

        // Verificar (Assert)
        Assert.Equal(-1, result);
    }

    [Fact]
    public void Exercise13_FirstGreaterThanX_WhenListIsEmpty_ReturnsMinusOne()
    {
        // Preparar (Arrange)
        var numbers = Array.Empty<int>();
        var x = 5;

        // Executar (Act)
        var result = _exercises.Exercise13_FirstGreaterThanX(numbers, x);

        // Verificar (Assert)
        Assert.Equal(-1, result);
    }

    [Fact]
    public void Exercise13_FirstGreaterThanX_WhenXIsNegative_ReturnsFirstElement()
    {
        // Preparar (Arrange)
        var numbers = new[] { 1, 2, 3, 4, 5 };
        var x = -1;

        // Executar (Act)
        var result = _exercises.Exercise13_FirstGreaterThanX(numbers, x);

        // Verificar (Assert)
        Assert.Equal(0, result);
    }

    #endregion

    #region Exercício 1.4 - Primeira Ocorrência

    [Fact]
    public void Exercise14_FirstOccurrence_WithDuplicates_ReturnsFirstIndex()
    {
        // Preparar (Arrange)
        var numbers = new[] { 1, 2, 2, 2, 3, 4 };
        var target = 2;

        // Executar (Act)
        var result = _exercises.Exercise14_FirstOccurrence(numbers, target);

        // Verificar (Assert)
        Assert.Equal(1, result);
    }

    [Fact]
    public void Exercise14_FirstOccurrence_WhenTargetDoesNotExist_ReturnsMinusOne()
    {
        // Preparar (Arrange)
        var numbers = new[] { 1, 2, 2, 2, 3, 4 };
        var target = 5;

        // Executar (Act)
        var result = _exercises.Exercise14_FirstOccurrence(numbers, target);

        // Verificar (Assert)
        Assert.Equal(-1, result);
    }

    [Fact]
    public void Exercise14_FirstOccurrence_WithSingleOccurrence_ReturnsCorrectIndex()
    {
        // Preparar (Arrange)
        var numbers = new[] { 1, 2, 3, 4, 5 };
        var target = 3;

        // Executar (Act)
        var result = _exercises.Exercise14_FirstOccurrence(numbers, target);

        // Verificar (Assert)
        Assert.Equal(2, result);
    }

    [Fact]
    public void Exercise14_FirstOccurrence_AllElementsSame_ReturnsZero()
    {
        // Preparar (Arrange)
        var numbers = new[] { 5, 5, 5, 5, 5 };
        var target = 5;

        // Executar (Act)
        var result = _exercises.Exercise14_FirstOccurrence(numbers, target);

        // Verificar (Assert)
        Assert.Equal(0, result);
    }

    #endregion

    #region Exercício 1.5 - Última Ocorrência

    [Fact]
    public void Exercise15_LastOccurrence_WithDuplicates_ReturnsLastIndex()
    {
        // Preparar (Arrange)
        var numbers = new[] { 1, 2, 2, 2, 3, 4 };
        var target = 2;

        // Executar (Act)
        var result = _exercises.Exercise15_LastOccurrence(numbers, target);

        // Verificar (Assert)
        Assert.Equal(3, result);
    }

    [Fact]
    public void Exercise15_LastOccurrence_WhenTargetDoesNotExist_ReturnsMinusOne()
    {
        // Preparar (Arrange)
        var numbers = new[] { 1, 2, 2, 2, 3, 4 };
        var target = 5;

        // Executar (Act)
        var result = _exercises.Exercise15_LastOccurrence(numbers, target);

        // Verificar (Assert)
        Assert.Equal(-1, result);
    }

    [Fact]
    public void Exercise15_LastOccurrence_WithSingleOccurrence_ReturnsCorrectIndex()
    {
        // Preparar (Arrange)
        var numbers = new[] { 1, 2, 3, 4, 5 };
        var target = 1;

        // Executar (Act)
        var result = _exercises.Exercise15_LastOccurrence(numbers, target);

        // Verificar (Assert)
        Assert.Equal(0, result);
    }

    [Fact]
    public void Exercise15_LastOccurrence_AllElementsSame_ReturnsLastIndex()
    {
        // Preparar (Arrange)
        var numbers = new[] { 5, 5, 5, 5, 5 };
        var target = 5;

        // Executar (Act)
        var result = _exercises.Exercise15_LastOccurrence(numbers, target);

        // Verificar (Assert)
        Assert.Equal(4, result);
    }

    #endregion

    #region Exercício 1.6 - Lower Bound (>= X)

    [Fact]
    public void Exercise16_LowerBound_WhenExactMatchExists_ReturnsMatchIndex()
    {
        // Preparar (Arrange)
        var numbers = new[] { 2, 4, 6, 8, 10 };
        var x = 6;

        // Executar (Act)
        var result = _exercises.Exercise16_LowerBound(numbers, x);

        // Verificar (Assert)
        Assert.Equal(2, result);
    }

    [Fact]
    public void Exercise16_LowerBound_WhenNoExactMatch_ReturnsNextGreater()
    {
        // Preparar (Arrange)
        var numbers = new[] { 2, 4, 6, 8, 10 };
        var x = 5;

        // Executar (Act)
        var result = _exercises.Exercise16_LowerBound(numbers, x);

        // Verificar (Assert)
        Assert.Equal(2, result); // 6 is at index 2
    }

    [Fact]
    public void Exercise16_LowerBound_WhenXIsGreaterThanAll_ReturnsMinusOne()
    {
        // Preparar (Arrange)
        var numbers = new[] { 2, 4, 6, 8, 10 };
        var x = 11;

        // Executar (Act)
        var result = _exercises.Exercise16_LowerBound(numbers, x);

        // Verificar (Assert)
        Assert.Equal(-1, result);
    }

    [Fact]
    public void Exercise16_LowerBound_WhenListIsEmpty_ReturnsMinusOne()
    {
        // Preparar (Arrange)
        var numbers = Array.Empty<int>();
        var x = 5;

        // Executar (Act)
        var result = _exercises.Exercise16_LowerBound(numbers, x);

        // Verificar (Assert)
        Assert.Equal(-1, result);
    }

    [Fact]
    public void Exercise16_LowerBound_WhenXIsLessThanAll_ReturnsFirstElement()
    {
        // Preparar (Arrange)
        var numbers = new[] { 2, 4, 6, 8, 10 };
        var x = 1;

        // Executar (Act)
        var result = _exercises.Exercise16_LowerBound(numbers, x);

        // Verificar (Assert)
        Assert.Equal(0, result);
    }

    #endregion

    #region Exercício 1.7 - Busca em Lista Rotacionada

    [Fact]
    public void Exercise17_SearchRotated_WhenTargetExists_ReturnsCorrectIndex()
    {
        // Preparar (Arrange)
        var numbers = new[] { 4, 5, 6, 7, 1, 2, 3 };
        var target = 5;

        // Executar (Act)
        var result = _exercises.Exercise17_SearchRotated(numbers, target);

        // Verificar (Assert)
        Assert.Equal(1, result);
    }

    [Fact]
    public void Exercise17_SearchRotated_WhenTargetInSecondPart_ReturnsCorrectIndex()
    {
        // Preparar (Arrange)
        var numbers = new[] { 4, 5, 6, 7, 1, 2, 3 };
        var target = 1;

        // Executar (Act)
        var result = _exercises.Exercise17_SearchRotated(numbers, target);

        // Verificar (Assert)
        Assert.Equal(4, result);
    }

    [Fact]
    public void Exercise17_SearchRotated_WhenTargetDoesNotExist_ReturnsMinusOne()
    {
        // Preparar (Arrange)
        var numbers = new[] { 4, 5, 6, 7, 1, 2, 3 };
        var target = 9;

        // Executar (Act)
        var result = _exercises.Exercise17_SearchRotated(numbers, target);

        // Verificar (Assert)
        Assert.Equal(-1, result);
    }

    [Fact]
    public void Exercise17_SearchRotated_WithNoRotation_ReturnsCorrectIndex()
    {
        // Preparar (Arrange)
        var numbers = new[] { 1, 2, 3, 4, 5, 6, 7 };
        var target = 4;

        // Executar (Act)
        var result = _exercises.Exercise17_SearchRotated(numbers, target);

        // Verificar (Assert)
        Assert.Equal(3, result);
    }

    [Fact]
    public void Exercise17_SearchRotated_WithSingleElement_ReturnsCorrectResult()
    {
        // Preparar (Arrange)
        var numbers = new[] { 5 };
        var target = 5;

        // Executar (Act)
        var result = _exercises.Exercise17_SearchRotated(numbers, target);

        // Verificar (Assert)
        Assert.Equal(0, result);
    }

    [Fact]
    public void Exercise17_SearchRotated_WithTwoElements_ReturnsCorrectIndex()
    {
        // Preparar (Arrange)
        var numbers = new[] { 2, 1 };
        var target = 1;

        // Executar (Act)
        var result = _exercises.Exercise17_SearchRotated(numbers, target);

        // Verificar (Assert)
        Assert.Equal(1, result);
    }

    #endregion
}
