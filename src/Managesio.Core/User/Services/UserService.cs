using Agoda.IoC.Core;
using Managesio.Core.User.Repositories;

namespace Managesio.Core.User.Services;
public interface IUserService
{
    public Task<Entities.User> GetByIdAsync(int id);
    public Task<List<Entities.User>> GetAllAsync();
    public Task CreateAsync(Entities.User user);
}

[RegisterPerRequest]
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Entities.User> GetByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        return user;
    }

    public async Task<List<Entities.User>> GetAllAsync()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task CreateAsync(Entities.User user)
    {
        await _userRepository.CreateAsync(user);
    }
}