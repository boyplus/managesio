using Agoda.IoC.Core;
using Managesio.Core.Entities;
using Managesio.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Managesio.Core.Modules.ProjectModule.Repositories;

public interface IProjectRepository
{
    public Task<List<Project>> GetProjects(Guid userId);
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

    public Task<List<Project>> GetProjects(Guid userId)
    {
        var projects = _context.Projects.Where(project => project.UserId == userId).ToListAsync();
        return projects;
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