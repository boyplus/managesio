using Managesio.Core.Entities;
using Managesio.Core.Modules.TodoModule.Dtos;

namespace Managesio.Core.Modules.TodoModule.Repositories;

public interface ITodoRepository
{
    public Task<List<Todo>> GetAllAsync(Guid userId);
    public Task<Todo> GetByIdAsync(Guid userId, Guid todoId);
    public Task CreateAsync(Guid userId, string title, string note);
    public Task DeleteAsync(Guid userId, Guid todoId);
    public Task UpdateAsync(Guid userId, Guid todoId, UpdateTodoRequest todo);
}