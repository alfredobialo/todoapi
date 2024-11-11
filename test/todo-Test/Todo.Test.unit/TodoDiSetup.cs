using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using TodoLib.services.todos.contracts;
using TodoLib.services.todos.impl;
using TodoLib.services.todos.models;
using TodoLib.services.todos.repository;

namespace Todo.Test.unit;

public class TodoDiSetup  : IDisposable
{
    private IServiceProvider _serviceProvider;
    public TodoDiSetup()
    {
        var services = new ServiceCollection();
        services.AddScoped<ITodoQueryService, TodoService>();
        services.AddScoped<ITodoCommandService, TodoService>();
        services.AddScoped<ITodoDataSource, TodoTestDataSource>();
        services.AddScoped(typeof(ILogger<>), typeof(NullLogger<>));

        _serviceProvider = services.BuildServiceProvider();

    }

    public IServiceProvider DiProvider
    {
        get => _serviceProvider;
    }
    
    public void Dispose()
    {
        // TODO release managed resources here
    }
}

class TodoTestDataSource : ITodoDataSource
{
    static List<TodoItem> todos = new ()
    {
        new TodoItem() {Id = "001", Title = "Test Todo 001"},
        new TodoItem() {Id = "002", Title = "Test Todo 002"},
        new TodoItem() {Id = "003", Title = "Test Todo 003"},
        new TodoItem() {Id = "004", Title = "Test Todo 004", IsDone = true},
    };
    public List<TodoItem> TodoTable
    { get => todos; }
}
