using Agoda.IoC.Core;
using Managesio.Core.Modules.ProjectModule.Dtos;
using Managesio.Core.Modules.ProjectModule.Repositories;

namespace Managesio.Core.Modules.ProjectModule.Services;

public interface IProjectService
{
    public Task CreateAsync(Guid userId, CreateProjectRequest model);
}

[RegisterPerRequest]
public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectService(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public Task CreateAsync(Guid userId, CreateProjectRequest model)
    {
        return _projectRepository.CreateAsync(model.Name, model.Description, userId);
    }
}