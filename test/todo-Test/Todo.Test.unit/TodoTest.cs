using Microsoft.Extensions.DependencyInjection;
using TodoLib.services.todos.contracts;
using FluentAssertions;
using TodoLib;
using TodoLib.services.todos.models;
using Xunit.Abstractions;

namespace Todo.Test.unit;

public class TodoTest : IClassFixture<TodoDiSetup>
{
    private readonly TodoDiSetup _diSetup;
    private readonly ITestOutputHelper _writer;

    public TodoTest(TodoDiSetup diSetup, ITestOutputHelper writer)
    {
        _diSetup = diSetup;
        _writer = writer;
    }
    [Fact]
    public async Task TodoUpdate_Should_Pass_When_A_Valid_Id_Is_Supplied()
    {
        // Arrange
        var todoCmdService = _diSetup.DiProvider.GetRequiredService<ITodoCommandService>();
        var todoQueryService = _diSetup.DiProvider.GetRequiredService<ITodoQueryService>();
        string todoId = "001";
        string newTitle = "Updated Todo Title";
        // ACT 
        // perform update 
        var cmdResponse = await todoCmdService.UpdateTitle(new UpdateTodoTitleRequest { Title = newTitle, TodoId = todoId });

        cmdResponse.Success.Should().BeTrue("Todo Update Successful");
        
        var sampleTodo = await todoQueryService.GetTodo(todoId);

        sampleTodo.Data.Title.Should().Be(newTitle, "Testing Updated Todo Title field");
        sampleTodo.Success.Should().BeTrue("Todo with Id: {0} was found", todoId);
        _writer.WriteLine(sampleTodo.ToJson(true));
    } 
    [Fact]
    public async Task GetTodo_Should_Pass_When_A_Valid_Id_Is_Supplied()
    {
        // Arrange
        var todoQueryService = _diSetup.DiProvider.GetRequiredService<ITodoQueryService>();
        string todoId = "001";
        
        // ACT 
        var sampleTodo = await todoQueryService.GetTodo(todoId);
        
        // ASSERT
        sampleTodo.Success.Should().BeTrue("Todo with Id: {0} was found", todoId);
        _writer.WriteLine(sampleTodo.ToJson(true));
    }
}
