using Agoda.IoC.Core;
using Managesio.Core.Entities;
using Managesio.Core.Models;

namespace Managesio.Core.Modules.ProjectModule.Repositories;

public interface IProjectRepository
{
    public Task CreateAsync(string name, string description, Guid ownerId);
    public Task UpdateAsync(Guid id, string name, string description, Guid ownerId);
}

[RegisterPerRequest]
public class ProjectRepository : IProjectRepository
{
    private readonly ApiDbContext _context;

    public ProjectRepository(ApiDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(string name, string description, Guid ownerId)
    {
        var project = new Project { Name = name, Description = description, UserId = ownerId };
        await _context.Projects.AddAsync(project);
        await _context.SaveChangesAsync();
    }

    public Task UpdateAsync(Guid id, string name, string description, Guid ownerId)
    {
        throw new NotImplementedException();
    }
}