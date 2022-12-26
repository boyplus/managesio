using Managesio.Core.Modules.TodoModule.Dtos;

namespace Managesio.Core.Modules.TodoModule.Repositories;

public interface ITodoRepository
{
    public Task<List<Entities.Todo>> GetAllAsync();
    public Task<Entities.Todo> GetByIdAsync(int id);
    public Task CreateAsync(string title, string note);
    public Task DeleteAsync(int id);
    public Task UpdateAsync(int id, UpdateTodoRequest todoRequest);
}