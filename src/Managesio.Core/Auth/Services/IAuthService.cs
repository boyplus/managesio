using Managesio.Core.Auth.Dtos;
using Managesio.Core.Entities;

namespace Managesio.Core.Auth.Services;

public interface IAuthService
{
    public Task RegisterUserAsync(RegisterUserRequest model);
    public Task<List<User>> GetAllUserAsync();
    public Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
    public Task<User> GetProfileAsync();
}