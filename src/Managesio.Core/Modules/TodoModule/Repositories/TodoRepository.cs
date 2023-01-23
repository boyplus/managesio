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
    
    public Task<List<Todo>> GetAllAsync(Guid userId)
    {
        var todos = _context.Todos.Where(todo => todo.UserId == userId).ToListAsync();
        return todos;
    }

    public async Task<Todo> GetByIdAsync(Guid userId, Guid todoId)
    {
        var todo = await _context.Todos.Where(todo => todo.Id == todoId && todo.UserId == userId)
            .SingleOrDefaultAsync();
        if (todo == null)
        {
            throw new KeyNotFoundException("Todo not found");
        }
        return todo;
    }

    public async Task CreateAsync(Guid userId, string title, string note)
    {
        var todo = new Todo { Title = title, Note = note, UserId = userId};
        await _context.Todos.AddAsync(todo);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid userId, Guid todoId)
    {
        var todo = await GetByIdAsync(userId,todoId);
        _context.Todos.Remove(todo);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Guid userId, Guid todoId, UpdateTodoRequest todo)
    {
        var foundTodo = await GetByIdAsync(userId, todoId);
        _mapper.Map(todo, foundTodo);
        _context.Todos.Update(foundTodo);
        await _context.SaveChangesAsync();
    }
}