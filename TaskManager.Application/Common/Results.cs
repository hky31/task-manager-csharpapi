namespace TaskManager.Application.Common;

public record Result<T>(bool isSuccess, T? value, string? error)
{
    public static Result<T> Success(T value) => new(true, value, null);
    public static Result<T> Failure(string error) => new(false, default, error);
}