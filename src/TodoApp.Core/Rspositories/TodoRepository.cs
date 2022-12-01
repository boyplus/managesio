using TodoApp.Core.Models;

namespace TodoApp.Core.Rspositories;

public interface ITodoRepository
{
    public List<Todo> GetTodos();
}

public class TodoRepository : ITodoRepository
{
    private readonly List<Todo> mockTodos;
    public TodoRepository()
    {
        mockTodos = new List<Todo>()
        {
            new() {Title = "mock-title-1", Note = "mock-note-1"},
            new() {Title = "mock-title-2", Note = "mock-note-2"}
        };
        
    }
    
    public List<Todo> GetTodos()
    {
        return mockTodos;
    }
}