using Spectre.Console;
using Spectre.Console.Cli;

namespace Flow.Console;

internal sealed class FlowCommand : Command<FlowCommand.Settings>
{
    public sealed class Settings : CommandSettings
    {
        [CommandArgument(0, "<name>")]
        public string Name { get; init; } = string.Empty;
        [CommandArgument(1, "<minutes>")]
        public int Minutes { get; init; } = 0;
        [CommandOption("-b|--break")]
        public int Break { get; init; } = 0;
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        if (settings.Minutes <= 0)
        {
            Messages.ErrorMessage("Minutes must be greater than zero.");
            return -1;
        }

        if (settings.Break < 0)
        {
            Messages.ErrorMessage("Break time cannot be negative.");
            return -1;
        }
        
        const string pause = "Break";
        
        System.Console.WriteLine();
        
        AnsiConsole.MarkupLine($"[bold teal]{settings.Name}[/] for [olive]{settings.Minutes}[/] minute(s).");
        Messages.ShowStartingCounting();
        Core.StartTimer(settings.Minutes, settings.Name);

        if (settings.Break <= 0) return 0;
        
        AnsiConsole.MarkupLine($"[bold teal]Break[/] for [olive]{settings.Break}[/] minute(s).");
        Messages.ShowStartingTheInterval();
        Core.StartTimer(settings.Break, pause);

        return 0;
    }
}