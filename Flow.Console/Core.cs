using Spectre.Console;

namespace Flow.Console;

internal static class Core
{
    internal static async Task DefaultPomodoroFlow()
    {
        const int focusTime = 25;
        const int timeBreak = 5;
        const string focus = "Focus";
        const string pause = "Break";
        
        System.Console.WriteLine();
        
        AnsiConsole.MarkupLine($"[bold teal]{focus}[/] for [olive]{focusTime}[/] minute(s).");
        Messages.ShowStartingCounting();
        StartTimer(focusTime, focus);
        
        AnsiConsole.MarkupLine($"[bold teal]{pause}[/] for [olive]{timeBreak}[/] minute(s).");
        Messages.ShowStartingTheInterval();
        StartTimer(timeBreak, pause);
        
        await Task.CompletedTask;
    }
    
    internal static void StartTimer(int minutes, string name)
    {
        Thread.Sleep(1500);
        var totalSeconds = minutes * 60;
        
        AnsiConsole.Progress()
            .Start(ctx =>
            {
                var progressTask = ctx.AddTask($"[teal]{name}[/] Timer", true, totalSeconds);
                
                while (!progressTask.IsFinished)
                {
                    var timeElapsed = progressTask.Value;
                    var timeRemaining = TimeSpan.FromSeconds(totalSeconds - timeElapsed);
                    
                    progressTask.Description = $@"[bold olive]Time remaining:[/] {timeRemaining:hh\:mm\:ss}";
                    
                    Thread.Sleep(1000);
                    progressTask.Increment(1);
                }
            });

        WinApi.RestoreConsoleWindow();
    }
}