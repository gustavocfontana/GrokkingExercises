using System.Text;

namespace GrokkingExercises.Core.Domain.ExerciseGenerator;

/// <summary>
/// Gera código de exercícios seguindo o padrão estabelecido.
/// Mantém conformidade com CLAUDE.MD e convenções do projeto.
/// </summary>
public class ExerciseCodeGenerator
{
    /// <summary>
    /// Gera a classe de exercícios completa.
    /// </summary>
    public string GenerateExerciseClass(string chapterNumber, string chapterTitle,
        List<ExerciseTemplate> exercises)
    {
        var sb = new StringBuilder();

        // Namespace e classe
        sb.AppendLine($"namespace GrokkingExercises.Core.Domain.Exercises.Chapter{chapterNumber};");
        sb.AppendLine();
        sb.AppendLine("/// <summary>");
        sb.AppendLine($"/// Exercícios do Capítulo {chapterNumber} - {chapterTitle}.");
        sb.AppendLine("/// </summary>");
        sb.AppendLine($"public class Chapter{chapterNumber}Exercises");
        sb.AppendLine("{");

        // Gera cada exercício
        foreach (var exercise in exercises)
        {
            sb.AppendLine(GenerateExerciseMethod(exercise));
        }

        sb.AppendLine("}");

        return sb.ToString();
    }

    /// <summary>
    /// Gera um método de exercício individual.
    /// </summary>
    private string GenerateExerciseMethod(ExerciseTemplate template)
    {
        var sb = new StringBuilder();

        // Comentário do exercício
        sb.AppendLine($"    // Exercicio {template.ExerciseNumber} - {template.ExerciseTitle}");
        sb.AppendLine($"    // {template.Description}");
        if (!string.IsNullOrEmpty(template.Example))
        {
            sb.AppendLine($"    // Exemplo:");
            sb.AppendLine($"    // {template.Example}");
        }

        // Assinatura do método
        var parameters = string.Join(", ",
            template.Parameters.Select(p => $"{p.Type} {p.Name}"));

        var exerciseNum = template.ExerciseNumber.Replace(".", "");
        sb.AppendLine($"    public {template.ReturnType} Exercise{exerciseNum}_{ToPascalCase(template.ExerciseTitle)}({parameters})");
        sb.AppendLine("    {");
        sb.AppendLine("        // TODO: Implementar");
        sb.AppendLine("        throw new NotImplementedException();");
        sb.AppendLine("    }");
        sb.AppendLine();

        return sb.ToString();
    }

    /// <summary>
    /// Gera classe de testes para os exercícios.
    /// </summary>
    public string GenerateTestClass(string chapterNumber, string chapterTitle,
        List<ExerciseTemplate> exercises)
    {
        var sb = new StringBuilder();

        // Using statements
        sb.AppendLine($"using GrokkingExercises.Core.Domain.Exercises.Chapter{chapterNumber};");
        sb.AppendLine("using Xunit;");
        sb.AppendLine();

        // Namespace e classe
        sb.AppendLine($"namespace GrokkingExercises.Tests.Core.Domain.Exercises.Chapter{chapterNumber};");
        sb.AppendLine();
        sb.AppendLine("/// <summary>");
        sb.AppendLine($"/// Testes automatizados para os exercícios do Capítulo {chapterNumber} - {chapterTitle}.");
        sb.AppendLine("/// Utiliza o padrão AAA (Arrange-Act-Assert) em português.");
        sb.AppendLine("/// </summary>");
        sb.AppendLine($"public class Chapter{chapterNumber}ExercisesTests");
        sb.AppendLine("{");
        sb.AppendLine($"    private readonly Chapter{chapterNumber}Exercises _exercises;");
        sb.AppendLine();
        sb.AppendLine($"    public Chapter{chapterNumber}ExercisesTests()");
        sb.AppendLine("    {");
        sb.AppendLine($"        _exercises = new Chapter{chapterNumber}Exercises();");
        sb.AppendLine("    }");
        sb.AppendLine();

        // Gera testes para cada exercício
        foreach (var exercise in exercises)
        {
            sb.AppendLine(GenerateTestRegion(exercise));
        }

        sb.AppendLine("}");

        return sb.ToString();
    }

    /// <summary>
    /// Gera uma região de testes para um exercício.
    /// </summary>
    private string GenerateTestRegion(ExerciseTemplate template)
    {
        var sb = new StringBuilder();

        sb.AppendLine($"    #region Exercício {template.ExerciseNumber} - {template.ExerciseTitle}");
        sb.AppendLine();

        // Teste básico (exemplo)
        var exerciseNum = template.ExerciseNumber.Replace(".", "");
        var methodName = $"Exercise{exerciseNum}_{ToPascalCase(template.ExerciseTitle)}";

        sb.AppendLine("    [Fact]");
        sb.AppendLine($"    public void {methodName}_WhenValidInput_ReturnsExpectedResult()");
        sb.AppendLine("    {");
        sb.AppendLine("        // Preparar (Arrange)");
        sb.AppendLine("        // TODO: Configurar dados de teste");
        sb.AppendLine();
        sb.AppendLine("        // Executar (Act)");
        sb.AppendLine($"        // var result = _exercises.{methodName}(...);");
        sb.AppendLine();
        sb.AppendLine("        // Verificar (Assert)");
        sb.AppendLine("        // Assert.Equal(expected, result);");
        sb.AppendLine("    }");
        sb.AppendLine();
        sb.AppendLine("    #endregion");
        sb.AppendLine();

        return sb.ToString();
    }

    /// <summary>
    /// Gera classe Runner para executar os exercícios no console.
    /// </summary>
    public string GenerateRunnerClass(string chapterNumber, string chapterTitle,
        List<ExerciseTemplate> exercises)
    {
        var sb = new StringBuilder();

        // Using statements
        sb.AppendLine($"using GrokkingExercises.Core.Domain.Exercises.Chapter{chapterNumber};");
        sb.AppendLine("using GrokkingExercises.Infrastructure.IO;");
        sb.AppendLine("using GrokkingExercises.Presentation.Console;");
        sb.AppendLine();

        // Namespace e classe
        sb.AppendLine("namespace GrokkingExercises.Presentation.Console.Menus;");
        sb.AppendLine();
        sb.AppendLine("/// <summary>");
        sb.AppendLine($"/// Runner para executar os exercícios do Capítulo {chapterNumber} - {chapterTitle}.");
        sb.AppendLine("/// Fornece interface console para testar interativamente cada exercício.");
        sb.AppendLine("/// </summary>");
        sb.AppendLine($"public static class Chapter{chapterNumber}Runner");
        sb.AppendLine("{");
        sb.AppendLine("    public static void Run(IConsoleIO io)");
        sb.AppendLine("    {");
        sb.AppendLine($"        var menu = new ConsoleMenu(\"Chapter {chapterNumber} - {chapterTitle}\", io)");

        // Adiciona opções do menu
        foreach (var exercise in exercises)
        {
            sb.AppendLine($"            .AddOption(\"{exercise.ExerciseNumber}\", \"{exercise.ExerciseTitle}\", " +
                         $"() => RunExercise{exercise.ExerciseNumber.Replace(".", "")}(io))");
        }

        sb.AppendLine(";");
        sb.AppendLine();
        sb.AppendLine("        menu.Run(exitKey: \"0\", exitLabel: \"Voltar\");");
        sb.AppendLine("    }");
        sb.AppendLine();

        // Gera métodos individuais para cada exercício
        foreach (var exercise in exercises)
        {
            sb.AppendLine(GenerateRunnerMethod(chapterNumber, exercise));
        }

        sb.AppendLine("}");

        return sb.ToString();
    }

    /// <summary>
    /// Gera método runner individual para um exercício.
    /// </summary>
    private string GenerateRunnerMethod(string chapterNumber, ExerciseTemplate template)
    {
        var sb = new StringBuilder();
        var exerciseNum = template.ExerciseNumber.Replace(".", "");

        sb.AppendLine($"    private static void RunExercise{exerciseNum}(IConsoleIO io)");
        sb.AppendLine("    {");
        sb.AppendLine($"        var exercises = new Chapter{chapterNumber}Exercises();");
        sb.AppendLine();
        sb.AppendLine("        // TODO: Configurar dados de entrada");
        sb.AppendLine("        // TODO: Executar exercício");
        sb.AppendLine("        // TODO: Exibir resultado");
        sb.AppendLine();
        sb.AppendLine($"        io.WriteLine(\"Exercício {template.ExerciseNumber} - {template.ExerciseTitle}\");");
        sb.AppendLine("        io.WriteLine(\"TODO: Implementar teste\");");
        sb.AppendLine("    }");
        sb.AppendLine();

        return sb.ToString();
    }

    /// <summary>
    /// Converte string para PascalCase removendo espaços e caracteres especiais.
    /// </summary>
    private string ToPascalCase(string text)
    {
        return string.Concat(text
            .Split(new[] { ' ', '-', '_' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(word => char.ToUpper(word[0]) + word.Substring(1).ToLower()));
    }
}
