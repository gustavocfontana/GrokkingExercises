namespace GrokkingExercises.Infrastructure.IO;

/// <summary>
/// Interface de abstração para operações de console.
/// Facilita testes e desacoplamento da infraestrutura.
/// </summary>
public interface IConsoleIO
{
    /// <summary>
    /// Escreve um texto no console sem quebra de linha.
    /// </summary>
    void Write(string value);

    /// <summary>
    /// Escreve um texto no console com quebra de linha.
    /// </summary>
    void WriteLine(string value);

    /// <summary>
    /// Lê uma linha do console.
    /// </summary>
    string? ReadLine();
}
