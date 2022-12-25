using Agoda.IoC.Core;
using Managesio.Core.Dtos;
using Managesio.Core.Entities;
using Managesio.Core.Rspositories;

namespace Managesio.Core.Services;

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

    public async Task<List<Todo>> GetAllAsync()
    {
        var todos = await _todoRepository.GetAllAsync();
        return todos;
    }

    public async Task<Todo> GetByIdAsync(int id)
    {
        var todo = await _todoRepository.GetByIdAsync(id); 
        return todo;
    }

    public async Task CreateAsync(string title, string note)
    {
        await _todoRepository.CreateAsync(title,note);
    }

    public async Task DeleteAsync(int id)
    {
        await _todoRepository.DeleteAsync(id);
    }

    public async Task UpdateAsync(int id, UpdateTodoRequest todo)
    {
        await _todoRepository.UpdateAsync(id, todo);
    }
}