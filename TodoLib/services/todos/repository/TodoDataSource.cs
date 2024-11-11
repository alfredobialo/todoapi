using TodoLib.services.todos.models;

namespace TodoLib.services.todos.repository;
class TodoDataSource : ITodoDataSource
{
    private static List<TodoItem> todos = new List<TodoItem>()
    {
        new TodoItem
        {
            Id = "00002",
            Title = "Learn NgRx Signal Store",
            Tag = "ngrx",
            IsDone = false
        },
        new TodoItem
        {
            Id = "001",
            Title = "Go to the Gym",
            Tag = "gym, fitness",
            IsDone = true
        },
        new TodoItem
        {
            Id = "008",
            Title = "Ask Chioma to Start learning Bootstrap 5",
            Tag = "css",
            IsDone = true
        },
        new TodoItem
        {
            Id = "002",
            Title = "Check your Outlook Mail",
            Tag = "email"
        },
        new TodoItem
        {
            Id = "003",
            Title = "Start working on Pend Task",
            Tag = "coding",
            IsDone = true
        },
        new TodoItem
        {
            Id = "004",
            Title = "Implement New Caching Invalidation Mechanism",
            Tag = "coding"
        },
        new TodoItem
        {
            Id = "005",
            Title = "Retest Caching for Transaction Limit",
            Tag = "coding"
        }
    };

    public List<TodoItem> TodoTable
    {
        get => todos; 
    }
}
