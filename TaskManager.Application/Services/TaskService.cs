namespace TaskManager.Application.Services;

using TaskManager.Application.Commands;
using TaskManager.Application.Common;
using TaskManager.Application.DTOs;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities;
using TaskManager.Domain.ValueObjects;

public class TaskService(ITaskRepository repository, ILoggerService logger) : ITaskService
{

    // public TaskService(ITaskRepository repository)
    // {
    //     _repository = repository;
    // }
    private readonly ITaskRepository _repository = repository;
    private readonly ILoggerService _logger = logger;

    public async Task<Result<TaskItemDto>> CreateTaskAsync(CreateTaskCommand command)
    {
        var task = new TaskItem(
            Id: Guid.NewGuid(),
            Title: command.Title,
            Description: command.Description,
            Status: TaskStatus.toDo,
            CreatedAt: DateTime.UtcNow
        );

        await _repository.AddAsync(task);

        _logger.logInfo($"Creation d'une nouvelle tache, retour ID : {task.Id}");

        // var dto = new TaskItemDto(task.id, task.title, task.description, task.status, task.createdAt);
        var dto = new TaskItemDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            Status = TaskStatus.toDo,
            CreatedAt = DateTime.UtcNow
        };
        return Result<TaskItemDto>.Success(dto);
    }

    public async Task<Result<TaskItemDto>> GetTaskByIdAsync(Guid id)
    {
        var task = await _repository.GetByIdAsync(id);

        if (task is null)
        {
            _logger.logError($"Erreur dans la recuperation d'une tache, retour ID : {id}");
            return Result<TaskItemDto>.Failure("Tâche introuvable.");   
        }

        // var dto = new TaskItemDto(task.id, task.title, task.description, task.status, task.createdAt);
        var dto = new TaskItemDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            Status = task.Status,
            CreatedAt = DateTime.UtcNow
        };

        _logger.logInfo($"Recuperation d'une tache, retour ID : {task.Id}");
        return Result<TaskItemDto>.Success(dto);
    }

    public async Task<List<TaskItemDto>> GetAllTasksAsync()
    {
        var tasks = await _repository.GetAllAsync();
        _logger.logInfo("Recuperation de toutes les taches existantes");

        return tasks.Select(task =>
            // new TaskItemDto(task.id, task.title, task.description, task.status, task.createdAt)
            new TaskItemDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                CreatedAt = DateTime.UtcNow
            }
        ).ToList();
    }

    public async Task<bool> UpdateTaskAsync(Guid id, UpdateTaskCommand command)
    {

        var existingTask = await _repository.GetByIdAsync(id);
        if (existingTask is null)
        {
            _logger.logError($"Erreur dans la recuperation d'une tache, retour ID : {id}");
            return false;
        }

        var updatedTask = existingTask with
        {
            Description = (command.Description is not null) ? command.Description : existingTask.Description,
            Title = (command.Title is not null) ? command.Title : existingTask.Title,
            Status = (command.Status is not null) ? command.Status : existingTask.Status
        };


        await _repository.UpdateAsync(updatedTask);
        _logger.logInfo($"Recuperation d'une tache, retour ID : {updatedTask.Id}");
        return true;
    }
}
