using Managesio.Core.Attributes;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Managesio.Core.Entities;
using Managesio.Core.Models;
using Managesio.Core.Modules.TodoModule.Dtos;
using Managesio.Core.Modules.TodoModule.Services;

namespace Managesio.WebApi.Controllers;

[ApiController]
[Route("api/todo")]
[Authorize]
public class TodoController : ControllerBase
{
    private readonly ITodoService _todoService;
    private readonly IApiContext _apiContext;
    public TodoController(ITodoService todoService, IApiContext apiContext)
    {
        _todoService = todoService;
        _apiContext = apiContext;
    }

    [HttpGet]
    [SwaggerOperation("Get_Todos")]
    public async Task<ActionResult<List<Todo>>> GetTodos()
    {
        var userId = _apiContext.User.Id;
        var todos =  await _todoService.GetAllAsync(userId);
        return Ok(todos);
    }

    [HttpGet]
    [Route("{id}")]
    [SwaggerOperation("Get_Todo")]
    public async Task<ActionResult<Todo>> GetTodo([FromRoute] Guid id)
    {
        var userId = _apiContext.User.Id;
        var todo = await _todoService.GetByIdAsync(userId, id);
        return Ok(todo);
    }

    [HttpPost]
    [SwaggerOperation("Add_Todo")]
    public async Task<ActionResult> AddTodo([FromBody] AddTodoRequest todo)
    {
        var userId = _apiContext.User.Id;
        await _todoService.CreateAsync(userId, todo.Title, todo.Note);
        return Ok("Todo is created");
    }

    [HttpPatch]
    [Route("{id}")]
    [SwaggerOperation("Update_Todo")]
    public async Task<ActionResult> UpdateTodo([FromBody] UpdateTodoRequest todo,[FromRoute] Guid id)
    {
        var userId = _apiContext.User.Id;
        await _todoService.UpdateAsync(userId, id, todo);
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    [SwaggerOperation("Delete_Todo")]
    public async Task<ActionResult> DeleteTodo([FromRoute] Guid id)
    {
        var userId = _apiContext.User.Id;
        await _todoService.DeleteAsync(userId, id);
        return Ok();
    }
}