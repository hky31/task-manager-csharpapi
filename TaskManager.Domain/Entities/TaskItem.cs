namespace TaskManager.Domain.Entities;

using TaskManager.Domain.ValueObjects;

public record TaskItem(Guid Id, string Title, string Description, TaskStatus Status, DateTime CreatedAt, Guid UserId, User? User);