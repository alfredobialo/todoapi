using asom.lib.core;
using TodoLib.services.todos.models;

namespace TodoLib.services.todos.contracts;

public interface ITodoQueryService
{
    Task<PagedCommandResponse<IEnumerable<TodoItem>>> GetTodos(PagedDataCriteria criteria);
    Task<CommandResponse<TodoItem>> GetTodo(string id);
}
