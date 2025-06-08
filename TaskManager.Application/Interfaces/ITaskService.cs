namespace TaskManager.Application.Interfaces;

using TaskManager.Application.Commands;
using TaskManager.Application.Common;
using TaskManager.Application.DTOs;

public interface ITaskService
{
    Task<Result<TaskItemDto>> CreateTaskAsync(CreateTaskCommand command);
    Task<Result<TaskItemDto>> GetTaskByIdAsync(Guid id);
    Task<List<TaskItemDto>> GetAllTasksAsync();
    Task<bool> UpdateTaskAsync(Guid id, UpdateTaskCommand command);
}