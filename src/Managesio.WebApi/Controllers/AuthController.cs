using Managesio.Core.Dtos;
using Managesio.Core.Entities;
using Managesio.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Managesio.WebApi.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    [Route("register")]
    public async Task RegisterUser([FromBody] RegisterUserRequest model)
    {
        await _authService.RegisterUserAsync(model);
    }

    [HttpGet]
    [Route("user")]
    public async Task<List<User>> GetAllUser()
    {
        var users =await _authService.GetAllUserAsync();
        return users;
    }
}