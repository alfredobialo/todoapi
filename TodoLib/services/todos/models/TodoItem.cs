namespace TodoLib.services.todos.models;

public record TodoItem
{
    public string? Id { get; init; }
    public string? Title { get; init; }
    public string?  Tag { get; init; }
    public bool IsDone { get; set; }
}

public record AddNewTodoRequest
{
    public string? Tag { get; init; }
    public string? Title { get; init; }
}
public record AddNewTodoResponse
{
    public string? Id { get; init; }
}
