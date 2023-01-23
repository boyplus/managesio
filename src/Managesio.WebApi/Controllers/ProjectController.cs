using Managesio.Core.Attributes;
using Managesio.Core.Models;
using Managesio.Core.Modules.ProjectModule.Dtos;
using Managesio.Core.Modules.ProjectModule.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Managesio.WebApi.Controllers;

[ApiController]
[Route("api/project")]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _projectService;
    private readonly IApiContext _apiContext;

    public ProjectController(IProjectService projectService, IApiContext apiContext)
    {
        _projectService = projectService;
        _apiContext = apiContext;
    }

    [HttpPost]
    [Authorize]
    [SwaggerOperation("Create_Project")]
    public async Task<ActionResult> CreateProject([FromBody] CreateProjectRequest model)
    {
        var userId = _apiContext.User.Id;
        await _projectService.CreateAsync(userId, model);
        return Ok("Project is created");
    }
}