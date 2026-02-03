namespace GrokkingExercises.Core.Domain.ExerciseGenerator;

/// <summary>
/// Serviço para gerenciar a geração de exercícios.
/// Coordena a criação de classes, testes e runners.
/// </summary>
public class ExerciseGeneratorService
{
    private readonly ExerciseCodeGenerator _codeGenerator;

    public ExerciseGeneratorService()
    {
        _codeGenerator = new ExerciseCodeGenerator();
    }

    /// <summary>
    /// Gera todos os arquivos necessários para um novo capítulo.
    /// </summary>
    /// <returns>Dicionário com nome do arquivo e conteúdo</returns>
    public Dictionary<string, string> GenerateChapter(string chapterNumber, string chapterTitle,
        List<ExerciseTemplate> exercises)
    {
        var files = new Dictionary<string, string>();

        // Gera classe de exercícios
        var exerciseClass = _codeGenerator.GenerateExerciseClass(
            chapterNumber, chapterTitle, exercises);
        files[$"Chapter{chapterNumber}Exercises.cs"] = exerciseClass;

        // Gera classe de testes
        var testClass = _codeGenerator.GenerateTestClass(
            chapterNumber, chapterTitle, exercises);
        files[$"Chapter{chapterNumber}ExercisesTests.cs"] = testClass;

        // Gera runner
        var runnerClass = _codeGenerator.GenerateRunnerClass(
            chapterNumber, chapterTitle, exercises);
        files[$"Chapter{chapterNumber}Runner.cs"] = runnerClass;

        return files;
    }

    /// <summary>
    /// Cria um template de exemplo baseado no padrão Binary Search.
    /// </summary>
    public static List<ExerciseTemplate> CreateBinarySearchExample()
    {
        return new List<ExerciseTemplate>
        {
            new ExerciseTemplate
            {
                ChapterNumber = "01",
                ChapterTitle = "Binary Search",
                ExerciseNumber = "1.1",
                ExerciseTitle = "Binary Search Básico",
                Description = "Recebe uma lista ordenada e um alvo. Retorna o índice ou -1 se não encontrado.",
                Example = "BinarySearch([1, 3, 5, 7, 9], 7) -> 3",
                Parameters = new List<Parameter>
                {
                    new Parameter { Type = "int[]", Name = "sortedList", Description = "Lista ordenada" },
                    new Parameter { Type = "int", Name = "target", Description = "Valor a buscar" }
                },
                ReturnType = "int",
                ReturnDescription = "Índice do elemento ou -1"
            },
            new ExerciseTemplate
            {
                ChapterNumber = "01",
                ChapterTitle = "Binary Search",
                ExerciseNumber = "1.2",
                ExerciseTitle = "Primeira Ocorrência",
                Description = "Em lista com duplicatas, retorna índice da primeira ocorrência.",
                Example = "FirstOccurrence([1, 2, 2, 2, 3], 2) -> 1",
                Parameters = new List<Parameter>
                {
                    new Parameter { Type = "int[]", Name = "sortedList", Description = "Lista ordenada" },
                    new Parameter { Type = "int", Name = "target", Description = "Valor a buscar" }
                },
                ReturnType = "int",
                ReturnDescription = "Índice da primeira ocorrência ou -1"
            }
        };
    }

    /// <summary>
    /// Valida se um template está completo e correto.
    /// </summary>
    public List<string> ValidateTemplate(ExerciseTemplate template)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(template.ChapterNumber))
            errors.Add("ChapterNumber é obrigatório");

        if (string.IsNullOrWhiteSpace(template.ChapterTitle))
            errors.Add("ChapterTitle é obrigatório");

        if (string.IsNullOrWhiteSpace(template.ExerciseNumber))
            errors.Add("ExerciseNumber é obrigatório");

        if (string.IsNullOrWhiteSpace(template.ExerciseTitle))
            errors.Add("ExerciseTitle é obrigatório");

        if (string.IsNullOrWhiteSpace(template.ReturnType))
            errors.Add("ReturnType é obrigatório");

        if (template.Parameters == null || template.Parameters.Count == 0)
            errors.Add("Pelo menos um parâmetro é obrigatório");

        return errors;
    }
}
