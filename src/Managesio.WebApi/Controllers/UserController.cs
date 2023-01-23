using Managesio.Core.Attributes;
using Managesio.Core.Entities;
using Managesio.Core.Modules.UserModule.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Managesio.WebApi.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [Route("search")]
    [Authorize]
    [SwaggerOperation("Search_User_By_Email")]
    public async Task<ActionResult<List<User>>> SearchByEmail([FromBody] string email)
    {
        var users = await _userService.SearchByEmail(email);
        return Ok(users);
    }
}