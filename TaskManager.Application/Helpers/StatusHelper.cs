namespace TaskManager.Application.Helpers;

using TaskManager.Domain.Entities;
using TaskManager.Domain.ValueObjects;

public static class StatusHelper
{
    public static string GetTaskStatusMessage(TaskStatus status) => status.value switch
    {
        "toDo" => "Tache a definir ou a faire",
        "inProgress" => "Tache en cours de realisation",
        "done" => "Tache terminee",
        _ => "Tache non-definie"
    };
}