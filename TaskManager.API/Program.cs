
using TaskManager.Application.Interfaces;
using TaskManager.Application.Services;
using TaskManager.Infrastructure.Repositories;
using TaskManager.Infrastructure.Logging;

var builder = WebApplication.CreateBuilder(args);

// Ajout de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// Injection de dépendances
builder.Services.AddScoped<ITaskService, TaskService>();
// builder.Services.AddSingleton<ITaskRepository, InMemoryTaskRepository>();
builder.Services.AddSingleton<InMemoryTaskStore>();
builder.Services.AddScoped<ITaskRepository, InMemoryTaskRepository>();

builder.Services.AddSingleton<ILoggerService>(_ => LoggerService.Instance);

var app = builder.Build();

app.UseHttpsRedirection();

// Activer Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();
