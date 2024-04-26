using TodoApi;
using TodoLib.services.todos.di;

var builder = WebApplication.CreateBuilder(args);
// Register Services in DI Container
builder.Services.RegisterTodos();
// add requirements
builder.RegisterInfrastructureServices();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger().UseSwaggerUI();
}

app.UseCors("angular");
//app.UseHttpsRedirection();
app.MapControllers();
app.Run();
