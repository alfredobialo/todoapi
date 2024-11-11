using asom.lib.core;
using asom.lib.core.util;
using Microsoft.Extensions.Logging;
using TodoLib.services.todos.contracts;
using TodoLib.services.todos.models;
using TodoLib.services.todos.repository;

namespace TodoLib.services.todos.impl;

public class TodoService : ITodoQueryService, ITodoCommandService
{
    private readonly ILogger<TodoService> _logger;
    private readonly ITodoDataSource _todoDataSource;

    private static List<TodoItem> todos = new List<TodoItem>();
   
    public TodoService(ILogger<TodoService> logger, ITodoDataSource todoDataSource)
    {
        _logger = logger;
        _todoDataSource = todoDataSource;
        todos = _todoDataSource.TodoTable;
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
        Thread.Sleep(3000);
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
                Thread.Sleep(3000);
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
                    Thread.Sleep(2000);
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
                    Thread.Sleep(2000);
                    todo.IsDone = true;
                    response.Success = true;
                    response.Message = "Todo Updated to DONE";
                }
            }

            return response;
        });

        return task;
    }

    public Task<CommandResponse> UpdateTitle(UpdateTodoTitleRequest request)
    {
        var task = Task.Run(() =>
        {
            _logger.LogInformation("Update Todo title Called with Payload : {0}", request);
            var response = CommandResponse.Failure("Could not Update Todo's Title");
            // Check if todo exist, then update the title
            var todo = todos.FirstOrDefault(x => x.Id == request.TodoId);
            if (todo is not null)
            {
                _logger.LogInformation("Updating Todo Title From => {0} to {1}", todo.Title, request.Title);
                todo.Title = request.Title;
                response.Success = true;
                response.Message = "Todo Updated successfully!";
                response.Code = 200;
            }
            else
            {
                response.Message = "Todo Record not Found!";
                _logger.LogInformation("Todo Title Update failed: reason => Todo Not found!");
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
                    Thread.Sleep(4000);
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
            Thread.Sleep(8000);
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
            Thread.Sleep(9000);
            response.Success = true;
            response.Message = "All Todos Updated to 'DONE'";
            
            _logger.LogInformation("Mark all todos was Successful");

            return response;
        });

        return task;
    }
}
