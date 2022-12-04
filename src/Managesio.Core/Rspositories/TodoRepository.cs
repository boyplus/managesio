using Agoda.IoC.Core;
using Managesio.Core.Models;

namespace Managesio.Core.Rspositories;

public interface ITodoRepository
{
    public List<Todo> GetTodos();
}

[RegisterPerRequest]
public class TodoRepository : ITodoRepository
{
    private readonly List<Todo> mockTodos;
    private readonly ApiDbContext _context;
    public TodoRepository(ApiDbContext context)
    {
        _context = context;
        // mockTodos = new List<Todo>()
        // {
        //     new() {Title = "mock-title-1", Note = "mock-note-1"},
        //     new() {Title = "mock-title-2", Note = "mock-note-2"},
        //     new() {Title = "mock-title-3", Note = "mock-note-5"}
        // };
        
    }
    
    public List<Todo> GetTodos()
    {
        var todos = _context.Todos.ToList();
        return todos;
    }
}