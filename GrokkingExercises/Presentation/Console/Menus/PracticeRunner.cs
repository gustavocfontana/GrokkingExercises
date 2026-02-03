using GrokkingExercises.Core.Domain.Exercises.Chapter01;
using GrokkingExercises.Infrastructure.IO;

namespace GrokkingExercises.Presentation.Console.Menus;

/// <summary>
/// Runner para modo de prática interativa.
/// Gera exercícios aleatórios para o usuário resolver no console.
/// </summary>
public static class PracticeRunner
{
    private static readonly Random _random = new Random();

    public static void Run(IConsoleIO io)
    {
        var menu = new ConsoleMenu("🎯 Modo Prática", io)
            .AddOption("1", "Prática Rápida - 5 exercícios aleatórios", () => StartQuickPractice(io))
            .AddOption("2", "Prova Completa - Todos os exercícios", () => StartFullTest(io))
            .AddOption("3", "Prática por Dificuldade - Fácil", () => StartByDifficulty(io, "Fácil"))
            .AddOption("4", "Prática por Dificuldade - Médio", () => StartByDifficulty(io, "Médio"))
            .AddOption("5", "Prática por Dificuldade - Difícil", () => StartByDifficulty(io, "Difícil"))
            .AddOption("6", "Modo Desafio - Contra o tempo", () => StartTimedChallenge(io));

        menu.Run(exitKey: "0", exitLabel: "Voltar");
    }

    private static void StartQuickPractice(IConsoleIO io)
    {
        io.WriteLine("\n=== 🎯 PRÁTICA RÁPIDA ===\n");
        io.WriteLine("Você receberá 5 exercícios aleatórios de Binary Search.");
        io.WriteLine("Digite sua resposta para cada um.\n");

        var exercises = GetRandomExercises(5);
        var score = RunExercises(io, exercises);

        ShowResults(io, score, exercises.Count);
    }

    private static void StartFullTest(IConsoleIO io)
    {
        io.WriteLine("\n=== 📝 PROVA COMPLETA ===\n");
        io.WriteLine("Todos os exercícios de Binary Search.");
        io.WriteLine("Boa sorte!\n");

        var exercises = GetAllExercises();
        var score = RunExercises(io, exercises);

        ShowResults(io, score, exercises.Count);
    }

    private static void StartByDifficulty(IConsoleIO io, string difficulty)
    {
        io.WriteLine($"\n=== 🎓 PRÁTICA - Nível {difficulty.ToUpper()} ===\n");

        var exercises = difficulty switch
        {
            "Fácil" => GetEasyExercises(),
            "Médio" => GetMediumExercises(),
            "Difícil" => GetHardExercises(),
            _ => GetAllExercises()
        };

        var score = RunExercises(io, exercises);
        ShowResults(io, score, exercises.Count);
    }

    private static void StartTimedChallenge(IConsoleIO io)
    {
        io.WriteLine("\n=== ⏱️ MODO DESAFIO - CONTRA O TEMPO ===\n");
        io.WriteLine("Você tem 2 minutos para resolver o máximo de exercícios!");
        io.WriteLine("Pressione ENTER para começar...");
        io.ReadLine();

        var startTime = DateTime.Now;
        var timeLimit = TimeSpan.FromMinutes(2);
        var exercises = GetAllExercises();
        var score = 0;
        var attempted = 0;

        foreach (var exercise in exercises)
        {
            var elapsed = DateTime.Now - startTime;
            if (elapsed >= timeLimit)
            {
                io.WriteLine("\n⏰ TEMPO ESGOTADO!");
                break;
            }

            var remaining = timeLimit - elapsed;
            io.WriteLine($"\n⏱️ Tempo restante: {remaining.Minutes:00}:{remaining.Seconds:00}");

            if (RunSingleExercise(io, exercise, attempted + 1))
            {
                score++;
            }
            attempted++;
        }

        io.WriteLine($"\n🏁 FIM DO DESAFIO!");
        io.WriteLine($"Tempo total: {(DateTime.Now - startTime).TotalSeconds:F1}s");
        ShowResults(io, score, attempted);
    }

    private static int RunExercises(IConsoleIO io, List<ExerciseQuestion> exercises)
    {
        var score = 0;

        for (int i = 0; i < exercises.Count; i++)
        {
            if (RunSingleExercise(io, exercises[i], i + 1))
            {
                score++;
            }
        }

        return score;
    }

    private static bool RunSingleExercise(IConsoleIO io, ExerciseQuestion exercise, int number)
    {
        io.WriteLine($"\n{'=',-80}");
        io.WriteLine($"📝 EXERCÍCIO {number}");
        io.WriteLine($"{'=',-80}");
        io.WriteLine($"\n{exercise.Question}");
        io.WriteLine($"\nEntrada: {exercise.Input}");

        if (!string.IsNullOrEmpty(exercise.Hint))
        {
            io.WriteLine($"💡 Dica: {exercise.Hint}");
        }

        io.Write("\n➤ Sua resposta: ");
        var userAnswer = io.ReadLine()?.Trim() ?? "";

        var isCorrect = exercise.CheckAnswer(userAnswer);

        if (isCorrect)
        {
            io.WriteLine("✅ CORRETO!");
            if (!string.IsNullOrEmpty(exercise.Explanation))
            {
                io.WriteLine($"\n📚 Explicação: {exercise.Explanation}");
            }
        }
        else
        {
            io.WriteLine($"❌ INCORRETO!");
            io.WriteLine($"   Resposta esperada: {exercise.ExpectedAnswer}");
            if (!string.IsNullOrEmpty(exercise.Explanation))
            {
                io.WriteLine($"\n📚 Explicação: {exercise.Explanation}");
            }
        }

        return isCorrect;
    }

    private static void ShowResults(IConsoleIO io, int score, int total)
    {
        io.WriteLine("\n" + new string('=', 80));
        io.WriteLine("📊 RESULTADO FINAL");
        io.WriteLine(new string('=', 80));

        var percentage = (score * 100.0) / total;
        io.WriteLine($"\nAcertos: {score}/{total} ({percentage:F1}%)");

        var emoji = percentage switch
        {
            >= 90 => "🏆 EXCELENTE!",
            >= 70 => "🎉 MUITO BOM!",
            >= 50 => "👍 BOM!",
            _ => "💪 CONTINUE PRATICANDO!"
        };

        io.WriteLine($"\n{emoji}\n");

        if (percentage < 100)
        {
            io.WriteLine("💡 Dica: Revise o EXERCISES_GUIDE.md para entender melhor os conceitos.");
        }
    }

    #region Geração de Exercícios

    private static List<ExerciseQuestion> GetRandomExercises(int count)
    {
        var all = GetAllExercises();
        return all.OrderBy(_ => _random.Next()).Take(count).ToList();
    }

    private static List<ExerciseQuestion> GetAllExercises()
    {
        var exercises = new List<ExerciseQuestion>();
        exercises.AddRange(GetEasyExercises());
        exercises.AddRange(GetMediumExercises());
        exercises.AddRange(GetHardExercises());
        return exercises;
    }

    private static List<ExerciseQuestion> GetEasyExercises()
    {
        return new List<ExerciseQuestion>
        {
            new ExerciseQuestion
            {
                Question = "Qual é o índice do número 7 no array ordenado [1, 3, 5, 7, 9, 11]?",
                Input = "[1, 3, 5, 7, 9, 11], target = 7",
                ExpectedAnswer = "3",
                Hint = "Use busca binária. Lembre que índices começam em 0.",
                Explanation = "O número 7 está na posição 3 (0-indexed): [1=0, 3=1, 5=2, 7=3, 9=4, 11=5]",
                CheckAnswer = answer => answer == "3"
            },
            new ExerciseQuestion
            {
                Question = "O número 5 existe no array [2, 4, 6, 8]? (Responda: sim ou não)",
                Input = "[2, 4, 6, 8], target = 5",
                ExpectedAnswer = "não",
                Hint = "Se não encontrar, busca binária retorna -1.",
                Explanation = "5 não está no array, então a resposta é 'não'.",
                CheckAnswer = answer => answer.ToLower() is "não" or "nao" or "n"
            },
            new ExerciseQuestion
            {
                Question = "Quantas comparações NO MÁXIMO a busca binária faz em um array de 8 elementos?",
                Input = "Array de tamanho 8",
                ExpectedAnswer = "3",
                Hint = "log₂(8) = ?",
                Explanation = "log₂(8) = 3. A cada comparação, dividimos por 2: 8→4→2→1",
                CheckAnswer = answer => answer == "3"
            }
        };
    }

    private static List<ExerciseQuestion> GetMediumExercises()
    {
        return new List<ExerciseQuestion>
        {
            new ExerciseQuestion
            {
                Question = "No array [1, 2, 2, 2, 3, 4], qual é o índice da PRIMEIRA ocorrência do número 2?",
                Input = "[1, 2, 2, 2, 3, 4], target = 2",
                ExpectedAnswer = "1",
                Hint = "Mesmo encontrando, continue buscando à esquerda.",
                Explanation = "A primeira ocorrência de 2 está no índice 1. Continue buscando à esquerda mesmo após encontrar.",
                CheckAnswer = answer => answer == "1"
            },
            new ExerciseQuestion
            {
                Question = "No array [1, 2, 2, 2, 3, 4], qual é o índice da ÚLTIMA ocorrência do número 2?",
                Input = "[1, 2, 2, 2, 3, 4], target = 2",
                ExpectedAnswer = "3",
                Hint = "Mesmo encontrando, continue buscando à direita.",
                Explanation = "A última ocorrência de 2 está no índice 3. Continue buscando à direita mesmo após encontrar.",
                CheckAnswer = answer => answer == "3"
            },
            new ExerciseQuestion
            {
                Question = "No array [2, 4, 6, 8, 10], qual é o índice do primeiro elemento MAIOR que 5?",
                Input = "[2, 4, 6, 8, 10], X = 5",
                ExpectedAnswer = "2",
                Hint = "Primeiro elemento > 5 é o 6.",
                Explanation = "6 (índice 2) é o primeiro elemento maior que 5.",
                CheckAnswer = answer => answer == "2"
            },
            new ExerciseQuestion
            {
                Question = "Busca binária em 1 milhão de elementos faz no máximo quantas comparações?",
                Input = "Array de tamanho 1.000.000",
                ExpectedAnswer = "20",
                Hint = "log₂(1.000.000) ≈ ?",
                Explanation = "log₂(1.000.000) ≈ 19.93, arredondando para cima = 20 comparações.",
                CheckAnswer = answer => answer is "20" or "19" or "19.93"
            }
        };
    }

    private static List<ExerciseQuestion> GetHardExercises()
    {
        return new List<ExerciseQuestion>
        {
            new ExerciseQuestion
            {
                Question = "No array ROTACIONADO [4, 5, 6, 7, 1, 2, 3], qual é o índice do número 5?",
                Input = "[4, 5, 6, 7, 1, 2, 3], target = 5",
                ExpectedAnswer = "1",
                Hint = "Identifique qual metade está ordenada primeiro.",
                Explanation = "Array rotacionado tem duas partes ordenadas. Identifique a metade ordenada e verifique se o target está nela. 5 está no índice 1.",
                CheckAnswer = answer => answer == "1"
            },
            new ExerciseQuestion
            {
                Question = "No array ROTACIONADO [4, 5, 6, 7, 1, 2, 3], qual é o índice do número 1?",
                Input = "[4, 5, 6, 7, 1, 2, 3], target = 1",
                ExpectedAnswer = "4",
                Hint = "1 está na segunda metade ordenada.",
                Explanation = "1 está no ponto de rotação, índice 4.",
                CheckAnswer = answer => answer == "4"
            },
            new ExerciseQuestion
            {
                Question = "No array [2, 4, 6, 8, 10], qual é o índice do LOWER BOUND de 7? (primeiro elemento >= 7)",
                Input = "[2, 4, 6, 8, 10], X = 7",
                ExpectedAnswer = "3",
                Hint = "Lower bound aceita igual OU maior. Qual é o primeiro >= 7?",
                Explanation = "Lower bound de 7 é 8 (índice 3), o primeiro elemento >= 7.",
                CheckAnswer = answer => answer == "3"
            },
            new ExerciseQuestion
            {
                Question = "Em qual caso busca binária tem MELHOR performance que busca linear? (Digite: sempre, nunca, ou depende)",
                Input = "Comparação de performance",
                ExpectedAnswer = "sempre",
                Hint = "Pense na complexidade: O(log n) vs O(n)",
                Explanation = "Busca binária SEMPRE é mais eficiente em listas ordenadas: O(log n) vs O(n) da busca linear.",
                CheckAnswer = answer => answer.ToLower() is "sempre"
            }
        };
    }

    #endregion
}

/// <summary>
/// Representa uma questão de exercício com validação de resposta.
/// </summary>
public class ExerciseQuestion
{
    public string Question { get; set; } = "";
    public string Input { get; set; } = "";
    public string ExpectedAnswer { get; set; } = "";
    public string Hint { get; set; } = "";
    public string Explanation { get; set; } = "";
    public Func<string, bool> CheckAnswer { get; set; } = _ => false;
}
