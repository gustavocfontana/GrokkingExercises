using GrokkingExercises.Core.Domain.ExerciseGenerator;
using GrokkingExercises.Infrastructure.IO;

namespace GrokkingExercises.Presentation.Console.Menus;

/// <summary>
/// Runner para o gerador de exercícios.
/// Permite criar novos capítulos interativamente via console.
/// </summary>
public static class ExerciseGeneratorRunner
{
    public static void Run(IConsoleIO io)
    {
        var menu = new ConsoleMenu("Gerador de Exercícios", io)
            .AddOption("1", "Gerar exemplo: Capítulo 02 - Selection Sort", () => GenerateSelectionSort(io))
            .AddOption("2", "Gerar exemplo: Capítulo 03 - Recursion", () => GenerateRecursion(io))
            .AddOption("3", "Ver instruções de uso", () => ShowInstructions(io));

        menu.Run(exitKey: "0", exitLabel: "Voltar");
    }

    private static void GenerateSelectionSort(IConsoleIO io)
    {
        io.WriteLine("=== Gerando Capítulo 02 - Selection Sort ===\n");

        var exercises = new List<ExerciseTemplate>
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

        GenerateAndDisplay(io, "02", "Selection Sort", exercises);
    }

    private static void GenerateRecursion(IConsoleIO io)
    {
        io.WriteLine("=== Gerando Capítulo 03 - Recursion ===\n");

        var exercises = new List<ExerciseTemplate>
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
                    new Parameter
                    {
                        Type = "int",
                        Name = "n",
                        Description = "Número inteiro positivo"
                    }
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
                    new Parameter
                    {
                        Type = "int[]",
                        Name = "array",
                        Description = "Array de inteiros"
                    }
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
                    new Parameter
                    {
                        Type = "int[]",
                        Name = "array",
                        Description = "Array de inteiros"
                    }
                },
                ReturnType = "int",
                ReturnDescription = "Número de elementos"
            }
        };

        GenerateAndDisplay(io, "03", "Recursion", exercises);
    }

    private static void GenerateAndDisplay(IConsoleIO io, string chapterNumber,
        string chapterTitle, List<ExerciseTemplate> exercises)
    {
        var service = new ExerciseGeneratorService();

        // Valida templates
        var allValid = true;
        foreach (var exercise in exercises)
        {
            var errors = service.ValidateTemplate(exercise);
            if (errors.Any())
            {
                io.WriteLine($"❌ Erros no exercício {exercise.ExerciseNumber}:");
                foreach (var error in errors)
                {
                    io.WriteLine($"  - {error}");
                }
                allValid = false;
            }
        }

        if (!allValid)
        {
            io.WriteLine("\n⚠️ Corrija os erros antes de gerar.");
            return;
        }

        // Gera os arquivos
        var files = service.GenerateChapter(chapterNumber, chapterTitle, exercises);

        io.WriteLine($"✅ Gerado {files.Count} arquivos para Capítulo {chapterNumber}:\n");

        // Exibe cada arquivo
        foreach (var file in files)
        {
            io.WriteLine($"📄 {file.Key}");
            io.WriteLine(new string('─', 80));
            io.WriteLine(file.Value);
            io.WriteLine(new string('═', 80));
            io.WriteLine("");
        }

        io.WriteLine("\n📋 PRÓXIMOS PASSOS:");
        io.WriteLine("1. Copie os arquivos acima para as pastas apropriadas:");
        io.WriteLine($"   - Chapter{chapterNumber}Exercises.cs → Core/Domain/Exercises/Chapter{chapterNumber}/");
        io.WriteLine($"   - Chapter{chapterNumber}ExercisesTests.cs → Tests/Core/Domain/Exercises/Chapter{chapterNumber}/");
        io.WriteLine($"   - Chapter{chapterNumber}Runner.cs → Presentation/Console/Menus/");
        io.WriteLine("2. Adicione a opção do capítulo no Program.cs");
        io.WriteLine("3. Implemente os métodos (substitua NotImplementedException)");
        io.WriteLine("4. Adicione testes específicos");
        io.WriteLine("5. Implemente os runners com exemplos práticos\n");
    }

    private static void ShowInstructions(IConsoleIO io)
    {
        io.WriteLine("=== Como Usar o Gerador de Exercícios ===\n");
        io.WriteLine("O gerador cria automaticamente 3 arquivos para cada capítulo:");
        io.WriteLine("  1. ChapterXXExercises.cs - Classe com os exercícios");
        io.WriteLine("  2. ChapterXXExercisesTests.cs - Testes automatizados");
        io.WriteLine("  3. ChapterXXRunner.cs - Interface console\n");
        io.WriteLine("📐 CONVENÇÕES APLICADAS:");
        io.WriteLine("  ✅ Código em inglês");
        io.WriteLine("  ✅ Comentários em português");
        io.WriteLine("  ✅ XML comments padronizados");
        io.WriteLine("  ✅ Padrão AAA nos testes");
        io.WriteLine("  ✅ Nomenclatura consistente\n");
        io.WriteLine("📚 DOCUMENTAÇÃO:");
        io.WriteLine("  - Veja GENERATOR_GUIDE.md para guia completo");
        io.WriteLine("  - Veja CONVENTIONS.md para convenções aplicadas");
        io.WriteLine("  - Veja exemplos nos capítulos já gerados\n");
        io.WriteLine("💡 DICA:");
        io.WriteLine("  Você pode modificar os templates no código-fonte");
        io.WriteLine("  em ExerciseGeneratorRunner.cs para criar seus próprios");
        io.WriteLine("  exercícios personalizados!\n");
    }
}
