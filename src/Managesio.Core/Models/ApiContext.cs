using Agoda.IoC.Core;
using Managesio.Core.Entities;

namespace Managesio.Core.Models;


public interface IApiContext
{
    User User { get; }
}

[RegisterPerRequest]
public class ApiContext : IApiContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ApiContext(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    private User _user;

    public User User
    {
        get
        {
            if (_user != null)
            {
                return _user;
            }
            var httpContext = _httpContextAccessor.HttpContext;
            var user = (User)httpContext?.Items["User"];
            _user = user;
            return _user;
        }
    }
}