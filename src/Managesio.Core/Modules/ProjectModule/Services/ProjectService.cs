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
    
    public async Task InviteProjectMembers(Guid projectId, List<string> emails)
    {
        Console.WriteLine("start service");
        var users = _userService.GetUsersFromEmails(emails);
        var userIds = users.Select(user => user.Id).ToList();
        Console.WriteLine("start repo");
        await _projectRepository.InviteProjectMembers(userIds, projectId);
    }
}