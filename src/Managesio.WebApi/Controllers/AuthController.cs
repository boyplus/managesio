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

    [HttpPost]
    [Route("signin")]
    public async Task<ActionResult<string>> AuthenticateUser([FromBody] AuthenticateRequest model)
    {
        var authenticateStatus = await _authService.Authenticate(model);
        if (authenticateStatus)
        {
            return Ok("User is login");
        }
        return Unauthorized("Email or password is incorrect");
    }

    [HttpGet]
    [Route("user")]
    public async Task<List<User>> GetAllUser()
    {
        var users =await _authService.GetAllUserAsync();
        return users;
    }
}