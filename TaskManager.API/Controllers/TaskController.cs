using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Commands;
using TaskManager.Application.Interfaces;

namespace TaskManager.API.Controllers;

[ApiController]
[Microsoft.AspNetCore.Mvc.Route("api/controller")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _taskService.GetTaskByIdAsync(id);
        if (!result.isSuccess) return NotFound(result.error);
        return Ok(result.value);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTaskCommand command)
    {
        var result = await _taskService.CreateTaskAsync(command);

        if (!result.isSuccess)
            return BadRequest(result.error);

        return CreatedAtAction(nameof(GetById), new { id = result.value }, result.value);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _taskService.GetAllTasksAsync(); // Implémenter dans ton service
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTaskCommand command)
    {
        var existing = await _taskService.GetTaskByIdAsync(id);
        if (existing is null)
            return BadRequest("Bad ID");

        var result = await _taskService.UpdateTaskAsync(id, command);
        
        return result ? NoContent() : NotFound();
    }
}