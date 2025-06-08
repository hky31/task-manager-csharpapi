using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Repositories;

public class InMemoryTaskStore
{
    public List<TaskItem> Tasks { get; } = new();
}

public class InMemoryTaskRepository : ITaskRepository
{
    //private readonly List<TaskItem> _tasks = new();
    private readonly InMemoryTaskStore _store;

    public InMemoryTaskRepository(InMemoryTaskStore store)
    {
        _store = store;
    }

    public Task AddAsync(TaskItem task)
    {
        // _tasks.Add(task);
        _store.Tasks.Add(task);
        return Task.CompletedTask;
    }

    public Task<TaskItem?> GetByIdAsync(Guid id)
    {
        // return Task.FromResult(_tasks.FirstOrDefault(t => t.id == id));
        return Task.FromResult(_store.Tasks.FirstOrDefault(t => t.id == id));
    }

    public Task<List<TaskItem>> GetAllAsync()
    {
        // return Task.FromResult(_tasks.ToList());
        return Task.FromResult(_store.Tasks.ToList());
    }

    public Task UpdateAsync(TaskItem task)
    {
        var index = _store.Tasks.FindIndex(t => t.id == task.id);
        if (index >= 0)
        {
            _store.Tasks[index] = task;
        }
        return Task.CompletedTask;
    }
}
