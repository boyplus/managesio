using Agoda.IoC.Core;
using Managesio.Core.Entities;
using Managesio.Core.Models;

namespace Managesio.Core.Rspositories;

public interface ITodoRepository
{
    public List<Todo> GetTodos();
    public Todo GetTodo(int id);
    
    public void AddTodo(string title, string note);
    public void DeleteTodo(int id);
}

[RegisterPerRequest]
public class TodoRepository : ITodoRepository
{
    private readonly ApiDbContext _context;
    public TodoRepository(ApiDbContext context)
    {
        _context = context;
    }
    
    public List<Todo> GetTodos()
    {
        var todos = _context.Todos.ToList();
        return todos;
    }

    public Todo GetTodo(int id)
    {
        var todo = _context.Todos.Find(id);
        if (todo == null)
        {
            throw new KeyNotFoundException("Todo not found");
        }
        return todo;
    }

    public void AddTodo(string title, string note)
    {
        var todo = new Todo { Title = title, Note = note };
        _context.Todos.Add(todo);
        _context.SaveChanges();
    }

    public void DeleteTodo(int id)
    {
        var todo = GetTodo(id);
        _context.Todos.Remove(todo);
        _context.SaveChanges();
    }
}