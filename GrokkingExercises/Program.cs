using System;


internal class Program
{
    private static void Main()
    {
        while (true)
        {
            Console.WriteLine("Grokking Exercises");
            Console.WriteLine("1. Execute Exercise 1 `Binary Search`");
            Console.WriteLine("2. Execute Exercise 2 `Other`");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");
            string? opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":
                    Console.WriteLine("Executing binary search exercise...");
                    break;
                case "2":
                    Console.WriteLine("Executing another exercise...");
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
            Console.WriteLine();
        }
    }
}