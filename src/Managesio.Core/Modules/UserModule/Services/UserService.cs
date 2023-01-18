using Agoda.IoC.Core;
using Managesio.Core.Entities;
using Managesio.Core.Modules.UserModule.Repositories;

namespace Managesio.Core.Modules.UserModule.Services;
public interface IUserService
{
    public Task<User> GetByIdAsync(int id);
    public Task<List<User>> GetAllAsync();
    public Task CreateAsync(User user);
}

[RegisterPerRequest]
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        return user;
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task CreateAsync(User user)
    {
        await _userRepository.CreateAsync(user);
    }
}