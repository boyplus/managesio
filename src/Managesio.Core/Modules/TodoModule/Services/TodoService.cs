using Agoda.IoC.Core;
using Managesio.Core.Entities;
using Managesio.Core.Modules.TodoModule.Dtos;
using Managesio.Core.Modules.TodoModule.Repositories;

namespace Managesio.Core.Modules.TodoModule.Services;
public interface ITodoService
{
    public Task<List<Todo>> GetAllAsync(Guid userId);
    public Task<Todo> GetByIdAsync(Guid userId, Guid todoId);
    public Task CreateAsync(Guid userId, string title, string note);
    public Task DeleteAsync(Guid userId, Guid todoId);
    public Task UpdateAsync(Guid userId, Guid todoId, UpdateTodoRequest todoRequest);
}

[RegisterPerRequest]
public class TodoService : ITodoService
{
    private readonly ITodoRepository _todoRepository;
    public TodoService(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public Task<List<Todo>> GetAllAsync(Guid userId)
    {
        var todos =  _todoRepository.GetAllAsync(userId);
        return todos;
    }

    public async Task<Todo> GetByIdAsync(Guid userId, Guid todoId)
    {
        var todo = await _todoRepository.GetByIdAsync(userId, todoId); 
        return todo;
    }

    public Task CreateAsync(Guid userId, string title, string note)
    {
        return _todoRepository.CreateAsync(userId,title,note);
    }

    public Task DeleteAsync(Guid userId, Guid todoId)
    {
        return _todoRepository.DeleteAsync(userId, todoId);
    }

    public Task UpdateAsync(Guid userId, Guid todoId, UpdateTodoRequest todo)
    {
        return _todoRepository.UpdateAsync(userId, todoId, todo);
    }
}