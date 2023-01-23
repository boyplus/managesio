using Managesio.Core.Attributes;
using Managesio.Core.Entities;
using Managesio.Core.Exceptions;
using Managesio.Core.Models;
using Managesio.Core.Modules.ProjectModule.Dtos;
using Managesio.Core.Modules.ProjectModule.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
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

    [HttpGet]
    [Authorize]
    [SwaggerOperation("Get_Project")]
    public async Task<ActionResult<List<Project>>> GetProjects()
    {
        var userId = _apiContext.User.Id;
        var projects = await _projectService.GetProjects(userId);
        return Ok(projects);
    }

    [HttpPost]
    [Authorize]
    [Route("invite/{id}")]
    [SwaggerOperation("Invite_Project_Members")]
    public async Task<ActionResult> InViteProjectMembers([FromBody] InviteProjectMemberRequest model, [FromRoute] Guid id)
    {
        try
        {
            await _projectService.InviteProjectMembers(id,model.Emails);
            return Ok("Project members are invited");
        }
        catch (DbUpdateException e)
        {
            throw new AppException("Some members are already exists");
        }
    }
}