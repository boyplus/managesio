using Agoda.IoC.Core;
using AutoMapper;
using Managesio.Core.Entities;
using Managesio.Core.Models;
using Managesio.Core.Rspositories;

namespace Managesio.Core.Services;
public interface IUserService
{
    public List<User> GetAll();
}

[RegisterPerRequest]
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public List<User> GetAll()
    {
        return _userRepository.GetAll();
    }
}