using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Managesio.Core.Services;
using Managesio.Core.Entities;

namespace Managesio.WebApi.Controllers;

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