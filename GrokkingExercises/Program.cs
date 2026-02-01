using System;


internal class Program
{
    private static void Main()
    {
        while (true)
        {
            Console.WriteLine("Grokking Exercises");
            Console.WriteLine("1. Executar Exercício 1 (Busca Binária)");
            Console.WriteLine("2. Executar Exercício 2 (Outro)");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");
            string? opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":
                    // Código do Exercício 1 aqui
                    Console.WriteLine("Executando Busca Binária...");
                    // Exemplo: instanciar e usar BuscaBinaria
                    break;
                case "2":
                    // Código do Exercício 2 aqui
                    Console.WriteLine("Executando Outro Exercício...");
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
            Console.WriteLine(); // Linha em branco para separação
        }
    }
}