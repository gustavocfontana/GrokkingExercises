using GrokkingExercises.Infrastructure.IO;

namespace GrokkingExercises.Presentation.Console;

/// <summary>
/// Interface para opções do menu.
/// </summary>
public interface IMenuOption
{
    string Key { get; }
    string Label { get; }
    bool PauseAfterAction { get; }
    void Execute();
}

/// <summary>
/// Menu de console interativo com suporte a múltiplas opções.
/// Implementa o padrão Fluent Interface para configuração.
/// </summary>
public sealed class ConsoleMenu
{
    private readonly string _title;
    private readonly IConsoleIO _io;
    private readonly List<IMenuOption> _options = new();

    public ConsoleMenu(string title, IConsoleIO io)
    {
        _title = title;
        _io = io;
    }

    public ConsoleMenu AddOption(string key, string label, Action action, bool pauseAfterAction = true)
    {
        _options.Add(new MenuOption(key, label, action, pauseAfterAction));
        return this;
    }

    public ConsoleMenu AddOption(IMenuOption option)
    {
        _options.Add(option);
        return this;
    }

    public void Run(string exitKey = "0", string exitLabel = "Back")
    {
        while (true)
        {
            _io.WriteLine(_title);
            foreach (var option in _options)
            {
                _io.WriteLine($"{option.Key} - {option.Label}");
            }
            _io.WriteLine($"{exitKey} - {exitLabel}");
            _io.Write("Choose an option: ");

            var input = Normalize(_io.ReadLine());
            if (input == exitKey)
            {
                return;
            }

            var selected = _options.FirstOrDefault(o => o.Key == input);
            if (selected is null)
            {
                _io.WriteLine("Invalid option. Please try again.");
                Pause();
                _io.WriteLine(string.Empty);
                continue;
            }

            selected.Execute();
            if (selected.PauseAfterAction)
            {
                Pause();
            }
            _io.WriteLine(string.Empty);
        }
    }

    private string Normalize(string? value)
    {
        return (value ?? string.Empty).Trim().Replace(',', '.');
    }

    private void Pause()
    {
        _io.Write("Press Enter to continue...");
        _io.ReadLine();
    }

    private sealed record MenuOption(string Key, string Label, Action Action, bool PauseAfterAction) : IMenuOption
    {
        public void Execute() => Action();
    }
}
