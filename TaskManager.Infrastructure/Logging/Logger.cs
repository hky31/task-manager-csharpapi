using TaskManager.Application.Interfaces;

namespace TaskManager.Infrastructure.Logging;

public sealed class LoggerService : ILoggerService
{
    private static readonly LoggerService _instance = new();
    public static LoggerService Instance => _instance;

    // Constructeur privé pour empêcher l’instanciation
    private LoggerService() { }

    public void logInfo(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"[INFO] {DateTime.Now}: {message}");
        Console.ResetColor();
    }

    public void logError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"[ERROR] {DateTime.Now}: {message}");
        Console.ResetColor();
    }

    public void logDebug(string message)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"[DEBUG] {DateTime.Now}: {message}");
        Console.ResetColor();
    }
}

