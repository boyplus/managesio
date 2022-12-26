using Managesio.Core.Auth.Dtos;

namespace Managesio.Core.Auth.Services;
public interface IAuthService
{
    public Task RegisterUserAsync(RegisterUserRequest model);
    public Task<List<Entities.User>> GetAllUserAsync();
    public Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
    public Task<Entities.User> GetProfileAsync();
}