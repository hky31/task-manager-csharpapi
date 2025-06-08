namespace TaskManager.Domain.ValueObjects;

public record TaskStatus(string value)
{
    public static readonly TaskStatus toDo = new("toDo");
    public static readonly TaskStatus inProgress = new("InProgress");
    public static readonly TaskStatus done = new("Done");

    public override string ToString() => value;
}