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
    public Task InviteProjectMembers(List<Guid> userIds, Guid projectId);
    public Task<ProjectMember> FindMember(Guid userId, Guid projectId);
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

    public async Task InviteProjectMembers(List<Guid> userIds, Guid projectId)
    {
        var projectMembers = userIds.Select(userId => new ProjectMember
        {
            ProjectId = projectId,
            UserId = userId,
            IsConfirmed = false
        });
        await _context.ProjectMembers.AddRangeAsync(projectMembers);
        await _context.SaveChangesAsync();
    }

    public async Task<ProjectMember> FindMember(Guid userId, Guid projectId)
    {
        var member = await _context.ProjectMembers.Where(member=>member.UserId == userId && member.ProjectId == projectId).SingleOrDefaultAsync();
        return member;
    }
}