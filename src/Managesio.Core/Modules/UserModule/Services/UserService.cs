using Agoda.IoC.Core;
using Managesio.Core.Entities;
using Managesio.Core.Modules.UserModule.Repositories;

namespace Managesio.Core.Modules.UserModule.Services;
public interface IUserService
{
    public Task<User> GetByIdAsync(Guid id);
    public Task<List<User>> GetAllAsync();
    public Task CreateAsync(User user);
    public Task<List<User>> SearchByEmail(string email);
    public Task<User> FindByEmail(string email);
    public List<User> GetUsersFromEmails(List<string> emails);
}

[RegisterPerRequest]
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetByIdAsync(Guid id)
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
    
    public Task<User> FindByEmail(string email)
    {
        var user = _userRepository.FindByEmail(email);
        return user;
    }

    public Task<List<User>> SearchByEmail(string email)
    {
        var users = _userRepository.SearchByEmail(email);
        return users;
    }

    public List<User> GetUsersFromEmails(List<string> emails)
    {
        var users = emails.Select(email => _userRepository.FindByEmail(email).Result).ToList();
        return users;
    }
}