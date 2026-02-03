namespace GrokkingExercises.Infrastructure.IO;

/// <summary>
/// Implementação concreta de IConsoleIO usando System.Console.
/// </summary>
public sealed class ConsoleIO : IConsoleIO
{
    public void Write(string value) => Console.Write(value);
    public void WriteLine(string value) => Console.WriteLine(value);
    public string? ReadLine() => Console.ReadLine();
}
