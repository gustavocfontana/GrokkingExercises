using GrokkingExercises.Infrastructure.IO;
using GrokkingExercises.Presentation.Console;
using GrokkingExercises.Presentation.Console.Menus;

namespace GrokkingExercises;

public class Program
{
    private static void Main()
    {
        var io = new ConsoleIO();
        var menu = new ConsoleMenu("Grokking Exercises", io)
            .AddOption("1", "Chapter 01 - Binary Search", () =>
                Chapter01Runner.Run(io), pauseAfterAction: false);

        menu.Run(exitKey: "0", exitLabel: "Exit");
    }
}