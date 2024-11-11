using asom.lib.core;
using TodoLib.services.todos.models;

namespace TodoLib.services.todos.contracts;

public interface ITodoCommandService
{
    Task<CommandResponse<string>> AddTodo(string todoDescription);
    Task<CommandResponse> RemoveTodo(string todoId);
    Task<CommandResponse> MarkAsDone(string todoId);
    Task<CommandResponse> UpdateTitle(UpdateTodoTitleRequest request);
    Task<CommandResponse> UnMarkAsDone(string todoId);
    Task<CommandResponse> UnMarkAllAsDone();
    Task<CommandResponse> MarkAllAsDone();
}

