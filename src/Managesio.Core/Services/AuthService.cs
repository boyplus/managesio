using Agoda.IoC.Core;

namespace Managesio.Core.Services;

public interface IAuthService
{
    public void RegisterUser();
}

[RegisterPerRequest]
public class AuthService : IAuthService
{
    public void RegisterUser()
    {
        Console.WriteLine("Register user");
    }
}