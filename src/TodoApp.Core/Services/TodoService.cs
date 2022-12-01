using TodoApp.Core.Models;
using TodoApp.Core.Rspositories;

namespace TodoApp.Core.Services;

public interface ITodoService
{
    public List<Todo> GetTodos();
}

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
}