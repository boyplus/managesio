using Agoda.IoC.Core;
using Managesio.Core.Entities;
using Managesio.Core.Rspositories;

namespace Managesio.Core.Services;

public interface ITodoService
{
    public List<Todo> GetTodos();
    public Todo GetTodo(int id);
    public void AddTodo(string title, string note);
    public void DeleteTodo(int id);
}

[RegisterPerRequest]
public class TodoService : ITodoService
{
    private readonly ITodoRepository _todoRepository;
    public TodoService(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public List<Todo> GetTodos()
    {
        return _todoRepository.GetTodos();
    }

    public Todo GetTodo(int id)
    {
        return _todoRepository.GetTodo(id);
    }

    public void AddTodo(string title, string note)
    {
        _todoRepository.AddTodo(title,note);
    }

    public void DeleteTodo(int id)
    {
        _todoRepository.DeleteTodo(id);
    }
}