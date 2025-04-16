using Spectre.Console;

namespace Flow.Console;

public static class Messages
{
    internal static void ShowStartingCounting()
    {
        AnsiConsole.MarkupLine("[bold green]Starting[/] counting...");
    }
    
    internal static void ShowStartingTheInterval()
    {
        AnsiConsole.MarkupLine("[bold green]Starting[/] the interval...");
    }
    
    internal static void ErrorMessage(string message)
    {
        System.Console.WriteLine();
        AnsiConsole.MarkupLine("[bold maroon]Error![/] " + message);
    }
    
    // Optional, I show a message in Program.
    internal static void FlowRule()
    {
        System.Console.Clear();
        var rule = new Rule("[teal]Flow[/]")
        {
            Justification = Justify.Left
        };
        AnsiConsole.Write(rule);
    }
    
    // Optional, I change to progress bar.
    internal static void TimeRemaining(TimeSpan time, string title)
    {
        var panel = new Panel($@"Time Remaining: [bold olive]{time:hh\:mm\:ss}[/]")
        {
            Header = new PanelHeader($"[teal]{title}[/]", Justify.Center)
        };
        AnsiConsole.Clear();
        AnsiConsole.Write(panel);
    }

    // Optional, I show a message in Program.
    internal static void CountingCompleted()
    {
        AnsiConsole.MarkupLine("[bold green]Completed![/] Press [underline]Enter[/] to [maroon]exit[/] or any other key to restart.");
        // var key = System.Console.ReadKey(true);
        //
        // if (key.Key == ConsoleKey.Enter)
        // {
        //     Environment.Exit(0);
        // }
        //
        // Process.Start(new ProcessStartInfo
        // {
        //     FileName = Process.GetCurrentProcess()?.MainModule?.FileName,
        //     UseShellExecute = true
        // });
        // Environment.Exit(0);
    }
}