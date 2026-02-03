using GrokkingExercises.Infrastructure.IO;
using GrokkingExercises.Presentation.Console;
using GrokkingExercises.Presentation.Console.Menus;

namespace GrokkingExercises;

/// <summary>
/// Ponto de entrada da aplicação.
/// Aplicação console para praticar exercícios do Grokking Algorithms.
/// </summary>
public class Program
{
    private static void Main()
    {
        var io = new ConsoleIO();
        var menu = new ConsoleMenu("Grokking Exercises", io)
            .AddOption("1", "Capítulo 01 - Binary Search", () =>
                Chapter01Runner.Run(io), pauseAfterAction: false)
            .AddOption("P", "🎯 Modo Prática (Quiz Interativo)", () =>
                PracticeRunner.Run(io), pauseAfterAction: false);

        menu.Run(exitKey: "0", exitLabel: "Sair");
    }
}