namespace TaskManager.Domain.Entities;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }

    public List<TaskItem> Tasks { get; set; } = [];
}