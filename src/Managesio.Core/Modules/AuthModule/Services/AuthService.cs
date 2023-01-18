using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Agoda.IoC.Core;
using AutoMapper;
using Managesio.Core.Configs;
using Managesio.Core.Entities;
using Managesio.Core.Exceptions;
using Managesio.Core.Modules.AuthModule.Dtos;
using Managesio.Core.Modules.EmailModule.Services;
using Managesio.Core.Modules.UserModule.Repositories;
using Managesio.Core.Modules.UserModule.Services;
using Managesio.Core.Modules.UtilModule;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SendGrid.Helpers.Errors.Model;

namespace Managesio.Core.Modules.AuthModule.Services;

[RegisterPerRequest]
public class AuthService : IAuthService
{
    private readonly IUserService _userService;
    private readonly IUserRepository _userRepository;
    private readonly IOtpService _otpService;
    private readonly IEmailService _emailService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly Secrets _secrets;
    private readonly IMapper _mapper;

    public AuthService(IUserService userService, IUserRepository userRepository, IOtpService otpService,
        IEmailService emailService, IHttpContextAccessor httpContextAccessor, IOptions<Secrets> secrets, IMapper mapper)
    {
        _userService = userService;
        _userRepository = userRepository;
        _otpService = otpService;
        _emailService = emailService;
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

        var user = _mapper.Map<User>(model);

        // hash password and create user
        user.Password = Encrypt(user.Password);
        await _userService.CreateAsync(user);
        
        
        // Send verification email (with OTP)
        await SendVerificationEmail(model.Email);
    }

    public async Task SendVerificationEmail(string email)
    {
        var user = await _userRepository.FindByEmail(email);
        if (user != null && user.IsVerified)
        {
            throw new AppException("User is already verified or does not exist");
        }

        // Generate OTP and save it to user
        var otp = _otpService.Generate6DigitsOtp();
        var expireAt = DateTime.UtcNow.AddMinutes(5);
        
        await _userRepository.SaveOtpAsync(user, otp, expireAt);
        await _emailService.SendVerificationEmailAsync(email,otp);
    }

    public async Task VerifyUser(string email, int otp)
    {
        var user = await _userRepository.FindByEmail(email);
        if (user == null)
        {
            throw new AppException("User does not exist");
        }

        if (user.Otp == otp && DateTime.UtcNow <= user.OtpExpireAt)
        {
            await _userRepository.VerifyUser(user);
        }
        else
        {
            throw new AppException("OTP is invalid or expired");
        }
    }

    public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
    {
        var user = await _userRepository.FindByEmail(model.Email);
        if (user == null || !Verify(model.Password, user.Password))
        {
            throw new UnauthorizedException("Email or password is incorrect");
        }

        if (!user.IsVerified)
        {
            throw new UnauthorizedException("User is not verified. Please verify your account");
        }

        var token = GenerateJwtToken(user);
        return new AuthenticateResponse() { Jwt = token };
    }

    public User GetProfileAsync()
    {
        var httpContext = _httpContextAccessor.HttpContext;
        var user = (User)httpContext?.Items["User"];
        return user;
    }

    public async Task<List<User>> GetAllUserAsync()
    {
        var users = await _userService.GetAllAsync();
        return users;
    }

    private string GenerateJwtToken(User user)
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