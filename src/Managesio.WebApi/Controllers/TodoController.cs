using Managesio.Core.Dtos;
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
    public ActionResult<List<Todo>> GetTodos()
    {
        return Ok(_todoService.GetTodos());
    }

    [HttpPost]
    [SwaggerOperation("Add_Todo")]
    public ActionResult AddTodo([FromBody] AddTodoRequest todo)
    {
        _todoService.AddTodo(todo.Title,todo.Note);
        return Ok();
    }
}