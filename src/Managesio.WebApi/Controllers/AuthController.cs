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
    public void RegisterUser([FromBody] RegisterUserRequest user)
    {
        _authService.RegisterUser(user.Email,user.Password);
    }

    [HttpGet]
    [Route("user")]
    public List<User> GetAllUser()
    {
        return _authService.GetAllUser();
    }
}