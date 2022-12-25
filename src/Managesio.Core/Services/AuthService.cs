using Agoda.IoC.Core;
using Managesio.Core.Entities;

namespace Managesio.Core.Services;

public interface IAuthService
{
    public void RegisterUser(string email, string password);

    public List<User> GetAllUser();
}

[RegisterPerRequest]
public class AuthService : IAuthService
{
    private readonly IUserService _userService;
    public AuthService(IUserService userService)
    {
        _userService = userService;
    }

    public void RegisterUser(string email, string password)
    {
        Console.WriteLine("Register user "+email+" "+password);
    }

    public List<User> GetAllUser()
    {
        return _userService.GetAll();
    }

    public string Encrypt(string plainPassword)
    {
        string hashPassword = BCrypt.Net.BCrypt.HashPassword(plainPassword);
        return hashPassword;
    }
}