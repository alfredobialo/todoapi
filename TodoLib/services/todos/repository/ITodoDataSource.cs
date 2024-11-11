using TodoLib.services.todos.models;

namespace TodoLib.services.todos.repository;

public interface ITodoDataSource
{
    List<TodoItem> TodoTable { get; }
}
