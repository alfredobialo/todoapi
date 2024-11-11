using Microsoft.Extensions.DependencyInjection;
using TodoLib.services.todos.contracts;
using TodoLib.services.todos.impl;
using TodoLib.services.todos.repository;

namespace TodoLib.services.todos.di;

public static class TodoDiRegistration
{
    public static IServiceCollection RegisterTodos(this IServiceCollection services)
    {
        services.AddScoped<ITodoQueryService, TodoService>();
        services.AddScoped<ITodoCommandService, TodoService>();
        services.AddScoped<ITodoDataSource, TodoDataSource>();
        return services;
    }
}
