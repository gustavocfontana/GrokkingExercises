using GrokkingExercises.Core.Domain.ExerciseGenerator;

namespace GrokkingExercises;

/// <summary>
/// Aplicação de exemplo para usar o gerador de exercícios.
/// Demonstra como criar novos capítulos seguindo o padrão estabelecido.
/// </summary>
public class ExerciseGeneratorApp
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== Gerador de Exercícios - Grokking Algorithms ===\n");

        var service = new ExerciseGeneratorService();

        // Exemplo 1: Gerar capítulo de Selection Sort
        Console.WriteLine("Gerando Capítulo 02 - Selection Sort...\n");

        var selectionSortExercises = new List<ExerciseTemplate>
        {
            new ExerciseTemplate
            {
                ChapterNumber = "02",
                ChapterTitle = "Selection Sort",
                ExerciseNumber = "2.1",
                ExerciseTitle = "Implementação Básica",
                Description = "Implemente o algoritmo de selection sort que ordena um array.",
                Example = "SelectionSort([64, 25, 12, 22, 11]) -> [11, 12, 22, 25, 64]",
                Parameters = new List<Parameter>
                {
                    new Parameter
                    {
                        Type = "int[]",
                        Name = "array",
                        Description = "Array a ser ordenado"
                    }
                },
                ReturnType = "int[]",
                ReturnDescription = "Array ordenado em ordem crescente"
            },
            new ExerciseTemplate
            {
                ChapterNumber = "02",
                ChapterTitle = "Selection Sort",
                ExerciseNumber = "2.2",
                ExerciseTitle = "Encontrar Menor Elemento",
                Description = "Encontre o índice do menor elemento em um array.",
                Example = "FindSmallest([5, 3, 6, 2, 10]) -> 3",
                Parameters = new List<Parameter>
                {
                    new Parameter
                    {
                        Type = "int[]",
                        Name = "array",
                        Description = "Array de entrada"
                    }
                },
                ReturnType = "int",
                ReturnDescription = "Índice do menor elemento"
            },
            new ExerciseTemplate
            {
                ChapterNumber = "02",
                ChapterTitle = "Selection Sort",
                ExerciseNumber = "2.3",
                ExerciseTitle = "Ordenação Decrescente",
                Description = "Modifique o selection sort para ordenar em ordem decrescente.",
                Example = "SelectionSortDesc([64, 25, 12, 22, 11]) -> [64, 25, 22, 12, 11]",
                Parameters = new List<Parameter>
                {
                    new Parameter
                    {
                        Type = "int[]",
                        Name = "array",
                        Description = "Array a ser ordenado"
                    }
                },
                ReturnType = "int[]",
                ReturnDescription = "Array ordenado em ordem decrescente"
            }
        };

        // Gera os arquivos
        var files = service.GenerateChapter("02", "Selection Sort", selectionSortExercises);

        // Exibe os arquivos gerados
        foreach (var file in files)
        {
            Console.WriteLine($"📄 Arquivo: {file.Key}");
            Console.WriteLine(new string('-', 80));
            Console.WriteLine(file.Value);
            Console.WriteLine(new string('=', 80));
            Console.WriteLine();
        }

        // Exemplo 2: Demonstrar validação de template
        Console.WriteLine("\n=== Validação de Template ===\n");

        var invalidTemplate = new ExerciseTemplate
        {
            ChapterNumber = "03",
            // Faltam outros campos obrigatórios
        };

        var errors = service.ValidateTemplate(invalidTemplate);
        if (errors.Any())
        {
            Console.WriteLine("❌ Erros encontrados no template:");
            foreach (var error in errors)
            {
                Console.WriteLine($"  - {error}");
            }
        }

        Console.WriteLine("\n=== Geração Concluída! ===");
        Console.WriteLine("\nPróximos passos:");
        Console.WriteLine("1. Copie os arquivos gerados para as pastas apropriadas:");
        Console.WriteLine("   - *Exercises.cs → Core/Domain/Exercises/ChapterXX/");
        Console.WriteLine("   - *Tests.cs → Tests/Core/Domain/Exercises/ChapterXX/");
        Console.WriteLine("   - *Runner.cs → Presentation/Console/Menus/");
        Console.WriteLine("2. Adicione a opção do capítulo no Program.cs");
        Console.WriteLine("3. Implemente os métodos (substitua NotImplementedException)");
        Console.WriteLine("4. Adicione testes específicos");
        Console.WriteLine("5. Implemente os runners com exemplos práticos");
    }
}
