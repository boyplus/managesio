using Agoda.IoC.Core;

namespace Managesio.Core.Services;

public interface IAuthService
{
    public void RegisterUser(string email, string password);
}

[RegisterPerRequest]
public class AuthService : IAuthService
{
    public void RegisterUser(string email, string password)
    {
        Console.WriteLine("Register user "+email+" "+password);
    }

    public string Encrypt(string plainPassword)
    {
        string hashPassword = BCrypt.Net.BCrypt.HashPassword(plainPassword);
        return hashPassword;
    }
}