namespace TaskManager.Application.Commands;

using TaskManager.Domain.ValueObjects;

public record UpdateTaskCommand(string? Title, string? Description, TaskStatus? Status);
