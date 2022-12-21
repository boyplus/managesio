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
    [SwaggerOperation("Get_Todos")]
    public ActionResult<List<Todo>> GetTodos()
    {
        return Ok(_todoService.GetAll());
    }

    [HttpGet]
    [Route("{id}")]
    [SwaggerOperation("Get_Todo")]
    public ActionResult<Todo> GetTodo(int id)
    {
        var todo = _todoService.GetById(id);
        return Ok(todo);
    }

    [HttpPost]
    [SwaggerOperation("Add_Todo")]
    public ActionResult AddTodo([FromBody] AddTodoRequest todo)
    {
        _todoService.Create(todo.Title,todo.Note);
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    [SwaggerOperation("Delete_Todo")]
    public ActionResult DeleteTodo(int id)
    {
        _todoService.Delete(id);
        return Ok();
    }
}