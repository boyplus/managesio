using Agoda.IoC.Core;
using Managesio.Core.Entities;
using Managesio.Core.Rspositories;

namespace Managesio.Core.Services;

public interface ITodoService
{
    public List<Todo> GetTodos();
    public void AddTodo(string title, string note);
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

    public void AddTodo(string title, string note)
    {
        _todoRepository.AddTodo(title,note);
    }
}