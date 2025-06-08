namespace TaskManager.Application.Commands;

public record CreateTaskCommand(string Title, string Description);

// public record CreateTaskCommand
// {
//     public required string title { get; init; }
//     public required string description { get; init; }
// }
