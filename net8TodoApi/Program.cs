using Scalar.AspNetCore;
using TodoApi;
using TodoLib.services.todos.di;

var builder = WebApplication.CreateBuilder(args);
// Register Services in DI Container
builder.Services.RegisterTodos();
// add requirements
builder.RegisterInfrastructureServices();
builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});
builder.Services.AddRequestLocalization(opt =>
{
    opt.ApplyCurrentCultureToResponseHeaders = true;
    opt.CultureInfoUseUserOverride = true;
    
});
var app = builder.Build();
/*if (app.Environment.IsDevelopment())
{*/
    app.MapOpenApi();
    app.MapScalarApiReference("todo-docs", opt =>
    {
        opt.DarkMode = true;
        opt.WithTitle( "Simple Todo Api");
    });
//}

app.UseCors("angular");
//app.UseHttpsRedirection();
app.MapControllers();
app.Run();
