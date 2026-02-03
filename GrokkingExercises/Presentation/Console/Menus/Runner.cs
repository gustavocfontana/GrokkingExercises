using GrokkingExercises.Core.Domain.Exercises.Chapter01;
using GrokkingExercises.Infrastructure.IO;
using GrokkingExercises.Presentation.Console;

namespace GrokkingExercises.Presentation.Console.Menus;

/// <summary>
/// Runner para executar os exercícios do Capítulo 01 - Binary Search.
/// Fornece interface console para testar interativamente cada exercício.
/// </summary>
public static class Chapter01Runner
{
    public static void Run(IConsoleIO io)
    {
        var menu = new ConsoleMenu("Chapter 01 - Binary Search", io)
            .AddOption("1.1", "Implementação básica", () => RunExercise11(io))
            .AddOption("1.2", "Estimativa (máximo de tentativas)", () => RunExercise12(io))
            .AddOption("1.3", "Primeiro maior que X", () => RunExercise13(io))
            .AddOption("1.4", "Primeira ocorrência", () => RunExercise14(io))
            .AddOption("1.5", "Última ocorrência", () => RunExercise15(io))
            .AddOption("1.6", "Lower bound", () => RunExercise16(io))
            .AddOption("1.7", "Busca rotacionada", () => RunExercise17(io));

        menu.Run(exitKey: "0", exitLabel: "Voltar");
    }

    private static void RunExercise11(IConsoleIO io)
    {
        var exercises = new BinarySearchExercises();
        var numbers = new[] { 1, 3, 5, 7, 9, 11 };
        var target = 7;
        var index = exercises.Exercise11_BinarySearch(numbers, target);

        io.WriteLine("Input: [1, 3, 5, 7, 9, 11], target = 7");
        io.WriteLine($"Result index: {index}");
    }

    private static void RunExercise12(IConsoleIO io)
    {
        var exercises = new BinarySearchExercises();
        var (binaryMax, linearMax) = exercises.Exercise12_MaxAttempts();

        io.WriteLine("Comparing search methods for 1,000,000 sorted numbers:");
        io.WriteLine($"Linear Search - Maximum attempts: {linearMax:N0}");
        io.WriteLine($"Binary Search - Maximum attempts: {binaryMax}");
        io.WriteLine($"Binary Search is ~{linearMax / binaryMax:N0}x faster!");
    }

    private static void RunExercise13(IConsoleIO io)
    {
        var exercises = new BinarySearchExercises();
        var numbers = new[] { 2, 4, 6, 8, 10, 12 };
        var x = 5;
        var index = exercises.Exercise13_FirstGreaterThanX(numbers, x);

        io.WriteLine("Input: [2, 4, 6, 8, 10, 12], X = 5");
        var valueText = index >= 0 ? numbers[index].ToString() : "-1";
        io.WriteLine($"First element greater than {x}: index {index} (value: {valueText})");

        // Teste adicional
        x = 12;
        index = exercises.Exercise13_FirstGreaterThanX(numbers, x);
        io.WriteLine($"\nInput: [2, 4, 6, 8, 10, 12], X = 12");
        var resultText = index >= 0 ? $"index {index}" : "not found";
        io.WriteLine($"First element greater than {x}: {resultText}");
    }

    private static void RunExercise14(IConsoleIO io)
    {
        var exercises = new BinarySearchExercises();
        var numbers = new[] { 1, 2, 2, 2, 3, 4 };
        var target = 2;
        var index = exercises.Exercise14_FirstOccurrence(numbers, target);

        io.WriteLine("Input: [1, 2, 2, 2, 3, 4], target = 2");
        io.WriteLine($"First occurrence of {target}: index {index}");

        // Teste adicional
        target = 5;
        index = exercises.Exercise14_FirstOccurrence(numbers, target);
        io.WriteLine($"\nInput: [1, 2, 2, 2, 3, 4], target = 5");
        var resultText = index >= 0 ? $"index {index}" : "not found";
        io.WriteLine($"First occurrence of {target}: {resultText}");
    }

    private static void RunExercise15(IConsoleIO io)
    {
        var exercises = new BinarySearchExercises();
        var numbers = new[] { 1, 2, 2, 2, 3, 4 };
        var target = 2;
        var index = exercises.Exercise15_LastOccurrence(numbers, target);

        io.WriteLine("Input: [1, 2, 2, 2, 3, 4], target = 2");
        io.WriteLine($"Last occurrence of {target}: index {index}");

        // Teste adicional
        target = 1;
        index = exercises.Exercise15_LastOccurrence(numbers, target);
        io.WriteLine($"\nInput: [1, 2, 2, 2, 3, 4], target = 1");
        io.WriteLine($"Last occurrence of {target}: index {index}");
    }

    private static void RunExercise16(IConsoleIO io)
    {
        var exercises = new BinarySearchExercises();
        var numbers = new[] { 2, 4, 6, 8, 10 };
        var x = 5;
        var index = exercises.Exercise16_LowerBound(numbers, x);

        io.WriteLine("Input: [2, 4, 6, 8, 10], X = 5");
        var valueText = index >= 0 ? numbers[index].ToString() : "-1";
        io.WriteLine($"Lower bound (>= {x}): index {index} (value: {valueText})");

        // Teste quando X está na lista
        x = 6;
        index = exercises.Exercise16_LowerBound(numbers, x);
        io.WriteLine($"\nInput: [2, 4, 6, 8, 10], X = 6");
        valueText = index >= 0 ? numbers[index].ToString() : "-1";
        io.WriteLine($"Lower bound (>= {x}): index {index} (value: {valueText})");
    }

    private static void RunExercise17(IConsoleIO io)
    {
        var exercises = new BinarySearchExercises();
        var numbers = new[] { 4, 5, 6, 7, 1, 2, 3 };
        var target = 5;
        var index = exercises.Exercise17_SearchRotated(numbers, target);

        io.WriteLine("Input: [4, 5, 6, 7, 1, 2, 3], target = 5");
        io.WriteLine($"Search result: index {index}");

        // Teste adicional
        target = 1;
        index = exercises.Exercise17_SearchRotated(numbers, target);
        io.WriteLine($"\nInput: [4, 5, 6, 7, 1, 2, 3], target = 1");
        io.WriteLine($"Search result: index {index}");

        // Teste de não encontrado
        target = 9;
        index = exercises.Exercise17_SearchRotated(numbers, target);
        io.WriteLine($"\nInput: [4, 5, 6, 7, 1, 2, 3], target = 9");
        var resultText = index >= 0 ? $"index {index}" : "not found";
        io.WriteLine($"Search result: {resultText}");
    }
}
