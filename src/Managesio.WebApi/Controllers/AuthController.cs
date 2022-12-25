using Managesio.Core;
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
    public async Task<ActionResult<AuthenticateResponse>> AuthenticateUser([FromBody] AuthenticateRequest model)
    {
        var authenticateResponse = await _authService.Authenticate(model);
        if (authenticateResponse == null)
        {
            return Unauthorized("Email or password is incorrect");
        }
        return Ok(authenticateResponse);
    }

    [HttpGet]
    [Route("profile")]
    [Authorize]
    public async Task GetProfile()
    {
        Console.WriteLine("inside controller");
    }

    [HttpGet]
    [Route("user")]
    public async Task<List<User>> GetAllUser()
    {
        var users =await _authService.GetAllUserAsync();
        return users;
    }
}