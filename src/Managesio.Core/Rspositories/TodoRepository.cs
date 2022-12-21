using Agoda.IoC.Core;
using Managesio.Core.Entities;
using Managesio.Core.Models;

namespace Managesio.Core.Rspositories;

public interface ITodoRepository
{
    public List<Todo> GetAll();
    public Todo GetById(int id);
    
    public void Create(string title, string note);
    public void Delete(int id);
}

[RegisterPerRequest]
public class TodoRepository : ITodoRepository
{
    private readonly ApiDbContext _context;
    public TodoRepository(ApiDbContext context)
    {
        _context = context;
    }
    
    public List<Todo> GetAll()
    {
        var todos = _context.Todos.ToList();
        return todos;
    }

    public Todo GetById(int id)
    {
        var todo = _context.Todos.Find(id);
        if (todo == null)
        {
            throw new KeyNotFoundException("Todo not found");
        }
        return todo;
    }

    public void Create(string title, string note)
    {
        var todo = new Todo { Title = title, Note = note };
        _context.Todos.Add(todo);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var todo = GetById(id);
        _context.Todos.Remove(todo);
        _context.SaveChanges();
    }
}