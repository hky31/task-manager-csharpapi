namespace TaskManager.Application.DTOs;

using TaskManager.Domain.ValueObjects;

// public record TaskItemDto(Guid id, string title, string description, TaskStatus status, DateTime createdAt);
public record TaskItemDto
{
    public required Guid Id { get; init; }
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required TaskStatus Status { get; init; }
    public required DateTime CreatedAt { get; init; }
}
