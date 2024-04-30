using asom.lib.core;
using Microsoft.AspNetCore.Mvc;
using TodoLib.services.todos.contracts;

namespace TodoApi.Controller;

[ApiController]
[Route("todos")]
public class TodoController : BaseController
{
    private readonly ITodoQueryService _todoQueryService;
    private readonly ITodoCommandService _todoCommandService;

    public TodoController(ITodoQueryService todoQueryService, ITodoCommandService todoCommandService)
    {
        _todoQueryService = todoQueryService;
        _todoCommandService = todoCommandService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetTodos([FromQuery] PagedDataCriteria criteria)
    {
        var response = await _todoQueryService.GetTodos(criteria);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTodo(string id)
    {
        var response = await _todoQueryService.GetTodo(id);
        return response.Success switch
        {
            true => Ok(response),
            false => BadRequest(response)
        };
    }

    /// <summary>
    /// Add New 'TodoItem' to the list of Todos
    /// </summary>
    /// <param name="todoItem"></param>
    /// <returns></returns>
    [HttpPost("")]
    public async Task<IActionResult> AddTodo([FromBody] NewTodoItem todo)
    {
        var response = await _todoCommandService.AddTodo(todo.Todo);
        return response.Success switch
        {
            true => Ok(response),
            false => BadRequest(response)
        };
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveTodo(string id)
    {
        var response = await _todoCommandService.RemoveTodo(id);
        return response.Success switch
        {
            true => Ok(response),
            false => BadRequest(response)
        };
    }

    [HttpPut("{id}/done")]
    public async Task<IActionResult> MarkTodoAsDone(string id)
    {
        var response = await _todoCommandService.MarkAsDone(id);
        return response.Success switch
        {
            true => Ok(response),
            false => BadRequest(response)
        };
    }

    [HttpPut("/all-done")]
    public async Task<IActionResult> MarkAllTodoAsDone()
    {
        var response = await _todoCommandService.MarkAllAsDone();
        return response.Success switch
        {
            true => Ok(response),
            false => BadRequest(response)
        };
    }

    [HttpPut("{id}/not-done")]
    public async Task<IActionResult> UnMarkTodoAsDone(string id)
    {
        var response = await _todoCommandService.UnMarkAsDone(id);
        return response.Success switch
        {
            true => Ok(response),
            false => BadRequest(response)
        };
    }

    [HttpPut("all-not-done")]
    public async Task<IActionResult> UnMarkAllTodoAsDone()
    {
        var response = await _todoCommandService.UnMarkAllAsDone();
        return response.Success switch
        {
            true => Ok(response),
            false => BadRequest(response)
        };
    }
}

public record NewTodoItem
{
    public string? Todo { get; init; }
}
