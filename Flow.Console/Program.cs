using Spectre.Console;
using Spectre.Console.Cli;

namespace Flow.Console;

internal abstract class Program
{
    public static async Task<int> Main(string[] args)
    {
        while (true)
        {
            int exitCode;

            System.Console.Clear();
            var rule = new Rule("[teal]Flow[/]")
            {
                Justification = Justify.Left
            };
            AnsiConsole.Write(rule);
            
            if (args.Length == 0)
            {
                await Core.DefaultPomodoroFlow();
                exitCode = 0;
            }
            else
            {
                var app = new CommandApp<FlowCommand>();
                exitCode = await app.RunAsync(args);
            }

            if (exitCode != 0)
                return 0;
            
            AnsiConsole.MarkupLine("[bold green]Completed![/] Press [underline]Enter[/] to [maroon]exit[/] or any other key to restart.");
            var key = System.Console.ReadKey(true);
            if (key.Key == ConsoleKey.Enter)
                break;
            
            System.Console.Clear();
        }

        return 0;
    }
}
