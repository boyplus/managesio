using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Managesio.Core.Entities;
using Managesio.Core.Modules.TodoModule.Dtos;
using Managesio.Core.Modules.TodoModule.Services;

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
    public async Task<ActionResult<List<Todo>>> GetTodos()
    {
        var todos = await _todoService.GetAllAsync();
        Console.WriteLine("complete get todo in controller");
        return Ok(todos);
    }

    [HttpGet]
    [Route("{id}")]
    [SwaggerOperation("Get_Todo")]
    public async Task<ActionResult<Todo>> GetTodo([FromRoute] int id)
    {
        var todo = await _todoService.GetByIdAsync(id);
        return Ok(todo);
    }

    [HttpPost]
    [SwaggerOperation("Add_Todo")]
    public async Task<ActionResult> AddTodo([FromBody] AddTodoRequest todo)
    {
        await _todoService.CreateAsync(todo.Title,todo.Note);
        return Ok("Todo is created");
    }

    [HttpPatch]
    [Route("{id}")]
    [SwaggerOperation("Update_Todo")]
    public async Task<ActionResult> UpdateTodo([FromBody] UpdateTodoRequest todo,[FromRoute] int id)
    {
        await _todoService.UpdateAsync(id,todo);
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    [SwaggerOperation("Delete_Todo")]
    public async Task<ActionResult> DeleteTodo([FromRoute]int id)
    {
        await _todoService.DeleteAsync(id);
        return Ok();
    }
}