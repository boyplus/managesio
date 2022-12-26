using Managesio.Core.Modules.AuthModule.Dtos;

namespace Managesio.Core.Modules.AuthModule.Services;
public interface IAuthService
{
    public Task RegisterUserAsync(RegisterUserRequest model);
    public Task<List<Entities.User>> GetAllUserAsync();
    public Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
    public Task<Entities.User> GetProfileAsync();
}