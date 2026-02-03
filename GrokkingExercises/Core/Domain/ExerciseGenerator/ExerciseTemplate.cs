namespace GrokkingExercises.Core.Domain.ExerciseGenerator;

/// <summary>
/// Representa um template de exercício a ser gerado.
/// </summary>
public class ExerciseTemplate
{
    public string ChapterNumber { get; set; } = string.Empty;
    public string ChapterTitle { get; set; } = string.Empty;
    public string ExerciseNumber { get; set; } = string.Empty;
    public string ExerciseTitle { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Example { get; set; } = string.Empty;
    public List<Parameter> Parameters { get; set; } = new();
    public string ReturnType { get; set; } = "int";
    public string ReturnDescription { get; set; } = string.Empty;
}

/// <summary>
/// Representa um parâmetro de método.
/// </summary>
public class Parameter
{
    public string Type { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
