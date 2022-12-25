using System.IdentityModel.Tokens.Jwt;
using Agoda.IoC.Core;
using AutoMapper;
using Managesio.Core.Configs;
using Managesio.Core.Dtos;
using Managesio.Core.Entities;
using Managesio.Core.Exceptions;
using Managesio.Core.Rspositories;
using Microsoft.Extensions.Options;

namespace Managesio.Core.Services;

public interface IAuthService
{
    public Task RegisterUserAsync(RegisterUserRequest model);
    public Task<List<User>> GetAllUserAsync();
    public Task<bool> Authenticate(AuthenticateRequest model);
}

[RegisterPerRequest]
public class AuthService : IAuthService
{
    private readonly IUserService _userService;
    private readonly IUserRepository _userRepository;
    private readonly Secrets _secrets;
    private readonly IMapper _mapper;
    public AuthService(IUserService userService, IUserRepository userRepository, IOptions<Secrets> secrets, IMapper mapper)
    {
        _userService = userService;
        _userRepository = userRepository;
        _secrets = secrets.Value;
        _mapper = mapper;
    }

    public async Task RegisterUserAsync(RegisterUserRequest model)
    {
        // Check whether email is already used
        var foundUser = await _userRepository.FindByEmail(model.Email);
        if (foundUser != null)
        {
            throw new AppException("Email is already registered");
        }
        
        var user = _mapper.Map<User>(model);
        
        // hash password
        user.Password = Encrypt(user.Password);
        await _userService.CreateAsync(user);
    }

    public async Task<bool> Authenticate(AuthenticateRequest model)
    {
        Console.WriteLine("secret is "+_secrets.JwtSecret);
        var user = await _userRepository.FindByEmail(model.Email);
        if (user != null && Verify(model.Password, user.Password))
        {
            return true;
        }

        return false;
    }

    public async Task<List<User>> GetAllUserAsync()
    {
        var users = await _userService.GetAllAsync();
        return users;
    }

    private string generateJwtTolen(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        return "";
        // var key = Encoding.ASCII.GetBytes();
    }

    private string Encrypt(string plainPassword)
    {
        string hashPassword = BCrypt.Net.BCrypt.HashPassword(plainPassword);
        return hashPassword;
    }

    private bool Verify(string password,string hashPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password,hashPassword);
    }
}