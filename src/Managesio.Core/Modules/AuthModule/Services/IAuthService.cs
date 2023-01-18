using Managesio.Core.Entities;
using Managesio.Core.Modules.AuthModule.Dtos;

namespace Managesio.Core.Modules.AuthModule.Services;
public interface IAuthService
{
    public Task RegisterUserAsync(RegisterUserRequest model);
    public Task<List<User>> GetAllUserAsync();
    public Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
    public User GetProfileAsync();
    public Task SendVerificationEmail(string email);
    public Task VerifyUser(string email, int otp);
}