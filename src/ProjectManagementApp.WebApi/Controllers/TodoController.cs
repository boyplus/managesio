using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using ProjectManagementApp.Core.Services;
using ProjectManagementApp.Core.Models;

namespace ProjectManagementApp.WebApi.Controllers;

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
    [SwaggerOperation("Get_Todo_List")]
    public List<Todo> GetTodos()
    {
        return _todoService.GetTodos();
    }

}