using Agoda.IoC.Core;
using Managesio.Core.Entities;
using Managesio.Core.Modules.TodoModule.Dtos;
using Managesio.Core.Modules.TodoModule.Repositories;

namespace Managesio.Core.Modules.TodoModule.Services;

public interface ITodoService
{
    public Task<List<Todo>> GetAllAsync();
    public Task<Todo> GetByIdAsync(int id);
    public Task CreateAsync(string title, string note);
    public Task DeleteAsync(int id);
    public Task UpdateAsync(int id, UpdateTodoRequest todoRequest);
}

[RegisterPerRequest]
public class TodoService : ITodoService
{
    private readonly ITodoRepository _todoRepository;
    public TodoService(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public Task<List<Todo>> GetAllAsync()
    {
        var todos1 =  _todoRepository.GetAllAsync();
        return todos1;
    }

    public Task<Todo> GetByIdAsync(int id)
    {
        var todo = _todoRepository.GetByIdAsync(id); 
        return todo;
    }

    public Task CreateAsync(string title, string note)
    {
        return _todoRepository.CreateAsync(title,note);
    }

    public Task DeleteAsync(int id)
    {
        return _todoRepository.DeleteAsync(id);
    }

    public Task UpdateAsync(int id, UpdateTodoRequest todo)
    {
        return _todoRepository.UpdateAsync(id, todo);
    }
}