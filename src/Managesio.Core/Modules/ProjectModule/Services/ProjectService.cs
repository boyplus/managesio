using Agoda.IoC.Core;
using Managesio.Core.Entities;
using Managesio.Core.Modules.ProjectModule.Dtos;
using Managesio.Core.Modules.ProjectModule.Repositories;
using Managesio.Core.Modules.UserModule.Services;

namespace Managesio.Core.Modules.ProjectModule.Services;

public interface IProjectService
{
    public Task<List<Project>> GetProjects(Guid userId);
    public Task CreateAsync(Guid userId, CreateProjectRequest model);
    public Task InviteProjectMembers(Guid projectId, List<string> emails);
    public Task<bool> IsUserInvitedToProject(Guid projectId, string email);
}

[RegisterPerRequest]
public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly IUserService _userService;

    public ProjectService(IProjectRepository projectRepository, IUserService userService)
    {
        _projectRepository = projectRepository;
        _userService = userService;
    }
    
    public Task<List<Project>> GetProjects(Guid userId)
    {
        var projects = _projectRepository.GetProjects(userId);
        return projects;
    }

    public Task CreateAsync(Guid userId, CreateProjectRequest model)
    {
        return _projectRepository.CreateAsync(model.Name, model.Description, userId);
    }

    public async Task<bool> IsUserInvitedToProject(Guid projectId, string email)
    {
        var user = await _userService.FindByEmail(email);
        var member = await _projectRepository.FindMember(user.Id, projectId);
        return member != null;
    }

    public async Task InviteProjectMembers(Guid projectId, List<string> emails)
    {
        var users = _userService.GetUsersFromEmails(emails);
        var userIds = users.Select(user => user.Id).ToList();
        await _projectRepository.InviteProjectMembers(userIds, projectId);
    }
}