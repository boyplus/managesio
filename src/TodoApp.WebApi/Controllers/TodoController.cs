using Microsoft.AspNetCore.Mvc;
using TodoApp.Core.Services;
using TodoApp.Core.Models;

namespace TodoApp.WebApi.Controllers;

[ApiController]
[Route("api/todo")]
public class TodoController : ControllerBase
{
    private readonly ITodoService _todoService;
    public TodoController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet]
    public List<Todo> GetTodos()
    {
        return _todoService.GetTodos();
    }

}