using AutoMapper;
using Agoda.IoC.Core;
using Managesio.Core.Dtos;
using Managesio.Core.Entities;
using Managesio.Core.Models;

namespace Managesio.Core.Rspositories;

public interface ITodoRepository
{
    public List<Todo> GetAll();
    public Todo GetById(int id);
    public void Create(string title, string note);
    public void Delete(int id);
    public void Update(int id, UpdateTodoRequest todo);
}

[RegisterPerRequest]
public class TodoRepository : ITodoRepository
{
    private readonly ApiDbContext _context;
    private readonly IMapper _mapper;
    public TodoRepository(ApiDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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

    public void Update(int id, UpdateTodoRequest todo)
    {
        var foundTodo = GetById(id);
        _mapper.Map(todo, foundTodo);
        _context.Todos.Update(foundTodo);
        _context.SaveChanges();
    }
}