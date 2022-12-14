using Agoda.IoC.Core;
using AutoMapper;
using Managesio.Core.Entities;
using Managesio.Core.Models;
using Managesio.Core.Modules.TodoModule.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Managesio.Core.Modules.TodoModule.Repositories;

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
    
    public async Task<List<Todo>> GetAllAsync()
    {
        var todos = await _context.Todos.ToListAsync();
        Console.WriteLine("complete in repo");
        return todos;
    }

    public async Task<Todo> GetByIdAsync(int id)
    {
        var todo = await _context.Todos.FindAsync(id);
        if (todo == null)
        {
            throw new KeyNotFoundException("Todo not found");
        }
        return todo;
    }

    public async Task CreateAsync(string title, string note)
    {
        var todo = new Todo { Title = title, Note = note, UserId = 1};
        await _context.Todos.AddAsync(todo);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var todo = await GetByIdAsync(id);
        _context.Todos.Remove(todo);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, UpdateTodoRequest todo)
    {
        var foundTodo = await GetByIdAsync(id);
        _mapper.Map(todo, foundTodo);
        _context.Todos.Update(foundTodo);
        await _context.SaveChangesAsync();
    }
}