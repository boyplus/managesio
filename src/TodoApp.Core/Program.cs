using TodoApp.Core.Rspositories;
using TodoApp.Core.Services;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
builder.Services.AddSingleton<ITodoRepository,TodoRepository>();
builder.Services.AddScoped<ITodoService, TodoService>();

app.Run();