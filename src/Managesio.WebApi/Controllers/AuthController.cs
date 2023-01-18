using Managesio.Core.Attributes;
using Managesio.Core.Entities;
using Managesio.Core.Modules.AuthModule.Dtos;
using Managesio.Core.Modules.AuthModule.Services;
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
    public ActionResult<User> GetProfile()
    {
        var profile = _authService.GetProfileAsync();
        return Ok(profile); ;
    }

    [HttpPost]
    [Route("resend-verification")]
    public async Task ResendVerificationEmail([FromBody] ResendVerificationEmailRequest model)
    {
        
    }

    [HttpGet]
    [Route("user")]
    public async Task<List<User>> GetAllUser()
    {
        var users =await _authService.GetAllUserAsync();
        return users;
    }
}