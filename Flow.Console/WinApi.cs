using System.Runtime.InteropServices;

namespace Flow.Console;

internal static class WinApi
{
    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    [DllImport("user32.dll")]
    private static extern bool SetForegroundWindow(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern bool IsIconic(IntPtr hWnd);

    [DllImport("kernel32.dll")]
    private static extern IntPtr GetConsoleWindow();

    private const int SwRestore = 9;

    public static void RestoreConsoleWindow()
    {
        var handle = GetConsoleWindow();

        if (handle == IntPtr.Zero)
            return;

        if (IsIconic(handle))
        {
            ShowWindow(handle, SwRestore);
        }

        SetForegroundWindow(handle);
    }
}