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
        var todos = _todoService.GetAll();
        return Ok(todos);
    }

    [HttpGet]
    [Route("{id}")]
    [SwaggerOperation("Get_Todo")]
    public ActionResult<Todo> GetTodo([FromRoute] int id)
    {
        var todo = _todoService.GetById(id);
        return Ok(todo);
    }

    [HttpPost]
    [SwaggerOperation("Add_Todo")]
    public ActionResult AddTodo([FromBody] AddTodoRequest todo)
    {
        _todoService.Create(todo.Title,todo.Note);
        return Ok("Todo is created");
    }

    [HttpPatch]
    [Route("{id}")]
    [SwaggerOperation("Update_Todo")]
    public ActionResult UpdateTodo([FromBody] UpdateTodoRequest todo,[FromRoute] int id)
    {
        _todoService.Update(id,todo);
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    [SwaggerOperation("Delete_Todo")]
    public ActionResult DeleteTodo([FromRoute]int id)
    {
        _todoService.Delete(id);
        return Ok();
    }
}