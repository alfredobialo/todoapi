using Microsoft.Extensions.DependencyInjection;
using TodoLib.services.todos.contracts;
using TodoLib.services.todos.impl;

namespace TodoLib.services.todos.di;

public static class TodoDiRegistration
{
    public static IServiceCollection RegisterTodos(this IServiceCollection services)
    {
        services.AddScoped<ITodoQueryService, TodoService>();
        services.AddScoped<ITodoCommandService, TodoService>();
        return services;
    }
}
