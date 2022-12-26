using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Agoda.IoC.Core;
using AutoMapper;
using Managesio.Core.Configs;
using Managesio.Core.Exceptions;
using Managesio.Core.Modules.AuthModule.Dtos;
using Managesio.Core.Modules.UserModule.Repositories;
using Managesio.Core.Modules.UserModule.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Managesio.Core.Modules.AuthModule.Services;

[RegisterPerRequest]
public class AuthService : IAuthService
{
    private readonly IUserService _userService;
    private readonly IUserRepository _userRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly Secrets _secrets;
    private readonly IMapper _mapper;
    public AuthService(IUserService userService, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor, IOptions<Secrets> secrets, IMapper mapper)
    {
        _userService = userService;
        _userRepository = userRepository;
        _httpContextAccessor = httpContextAccessor;
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
        
        var user = _mapper.Map<Entities.User>(model);
        
        // hash password
        user.Password = Encrypt(user.Password);
        await _userService.CreateAsync(user);
    }

    public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
    {
        var user = await _userRepository.FindByEmail(model.Email);
        if (user == null || !Verify(model.Password, user.Password))
        {
            return null;
        }

        var token = GenerateJwtToken(user);
        return new AuthenticateResponse() { Jwt = token };
    }

    public async Task<Entities.User> GetProfileAsync()
    {
        var httpContext = _httpContextAccessor.HttpContext;
        var user = (Entities.User)httpContext?.Items["User"];
        return user;
    }

    public async Task<List<Entities.User>> GetAllUserAsync()
    {
        var users = await _userService.GetAllAsync();
        return users;
    }

    private string GenerateJwtToken(Entities.User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secrets.JwtSecret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]{new Claim("id",user.Id.ToString())}),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
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