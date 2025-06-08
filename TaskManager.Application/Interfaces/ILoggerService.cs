namespace TaskManager.Application.Interfaces;

public interface ILoggerService
{
    void logInfo(string message);
    void logError(string message);
    void logDebug(string message);
}