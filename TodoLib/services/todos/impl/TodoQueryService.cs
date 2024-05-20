using asom.lib.core;
using asom.lib.core.util;
using Microsoft.Extensions.Logging;
using TodoLib.services.todos.contracts;
using TodoLib.services.todos.models;

namespace TodoLib.services.todos.impl;

class TodoService : ITodoQueryService, ITodoCommandService
{
    private readonly ILogger<TodoService> _logger;

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

    public TodoService(ILogger<TodoService> logger)
    {
        _logger = logger;
        //_initTodoSampleData();
    }

    public Task<PagedCommandResponse<IEnumerable<TodoItem>>> GetTodos(PagedDataCriteria criteria)
    {
        _logger.LogInformation("Get Todos called with criteria : {criteria}", criteria);
        var response = new PagedCommandResponse<IEnumerable<TodoItem>>()
        {
            Success = true,
            Data = new List<TodoItem>(),
            Message = "Todos loaded",
            Code = 200
        };
        Thread.Sleep(1000);
        response.SetPagerConfig(criteria);
        response.Data = response.Paginate(todos);
        return Task.FromResult(response);
    }

    public async Task<CommandResponse<TodoItem>> GetTodo(string id)
    {
        var todo = todos.FirstOrDefault(x => x.Id == id);
        if (todo is not null)
        {
            return CommandResponse<TodoItem>.SuccessResponse($"Todo {id} Loaded", todo);
        }

        return CommandResponse<TodoItem>.FailedResponse("Todo Not Found");
    }

    private void _initTodoSampleData()
    {
        Thread.Sleep(1000);
        todos.AddRange(new[]
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
            },
        });
    }

    public Task<CommandResponse<string>> AddTodo(string todoDescription)
    {
        var task = Task.Run(() =>
        {
            var response = CommandResponse<string>.FailedResponse("We could not add your Todo at the moment!");
            if (!string.IsNullOrWhiteSpace(todoDescription))
            {
                // Create a new Todo and add to the fake Database
                TodoItem todoItem = new()
                {
                    Id = Util.NewNumericId(15),
                    Tag = todoDescription,
                    Title = todoDescription
                };

                todos.Add(todoItem);
                response.Data = todoItem.Id;
                response.Success = true;
                response.Message = $"Hurray! Todo :'{todoDescription}', added successfully";
                _logger.LogInformation("New Todo Added {response}", response);
            }
            else
            {
                response.Message = "Oops! Invalid Todo Input. Please enter a todo description";
                _logger.LogWarning("Invalid Todo Input");
            }

            return response;
        });

        return task;
    }

    public Task<CommandResponse> RemoveTodo(string todoId)
    {
        var task = Task.Run(() =>
        {
            var response = CommandResponse.Failure("Todo removal failed!, Ensure you supplied the required input");
            if (!string.IsNullOrEmpty(todoId))
            {
                var todo = todos.FirstOrDefault(x => x.Id?.ToLower() == todoId.ToLower());
                if (todo != null)
                {
                    todos.Remove(todo);
                    response.Success = true;
                    response.Message = "Todo REMOVED successfully";
                }
            }

            return response;
        });

        return task;
    }

    public Task<CommandResponse> MarkAsDone(string todoId)
    {
        var task = Task.Run(() =>
        {
            var response = CommandResponse.Failure("Todo Update failed!, Ensure you supplied the required input");
            if (!string.IsNullOrEmpty(todoId))
            {
                var todo = todos.FirstOrDefault(x => x.Id?.ToLower() == todoId.ToLower());
                if (todo != null)
                {
                    todo.IsDone = true;
                    response.Success = true;
                    response.Message = "Todo Updated to DONE";
                }
            }

            return response;
        });

        return task;
    }

    public Task<CommandResponse> UnMarkAsDone(string todoId)
    {
        var task = Task.Run(() =>
        {
            var response = CommandResponse.Failure("Todo Update failed!, Ensure you supplied the required input");
            if (!string.IsNullOrEmpty(todoId))
            {
                var todo = todos.FirstOrDefault(x => x.Id?.ToLower() == todoId.ToLower());
                if (todo != null)
                {
                    todo.IsDone = false;
                    response.Success = true;
                    response.Message = "Todo Updated to NOT DONE";
                }
            }

            return response;
        });

        return task;
    }

    public Task<CommandResponse> UnMarkAllAsDone()
    {
        var task = Task.Run(() =>
        {
            _logger.LogInformation("Un mark all todos called");
            var response = CommandResponse.Failure("Unmark all todo request failed!");
            todos.ForEach(x => x.IsDone = false);

            response.Success = true;
            response.Message = "All Todos Updated to 'NOT DONE'";
            _logger.LogInformation("Unmark all todos was Successful");

            return response;
        });

        return task;
    }

    public Task<CommandResponse> MarkAllAsDone()
    {
        var task = Task.Run(() =>
        {
            _logger.LogInformation("Mark all todos called");
            var response = CommandResponse.Failure("Mark all todo request failed!");
            todos.ForEach(x => x.IsDone = true);

            response.Success = true;
            response.Message = "All Todos Updated to 'DONE'";
            
            _logger.LogInformation("Mark all todos was Successful");

            return response;
        });

        return task;
    }
}
