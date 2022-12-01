using Agoda.IoC.Core;
using ProjectManagementApp.Core.Models;
using ProjectManagementApp.Core.Rspositories;

namespace ProjectManagementApp.Core.Services;

public interface ITodoService
{
    public List<Todo> GetTodos();
}

[RegisterSingleton]
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