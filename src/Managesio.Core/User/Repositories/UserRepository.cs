using Agoda.IoC.Core;
using Managesio.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Managesio.Core.User.Repositories;

public interface IUserRepository
{
    public Task<Entities.User> GetByIdAsync(int id);
    public Task<List<Entities.User>> GetAllAsync();
    public Task CreateAsync(Entities.User user);
    public Task<Entities.User> FindByEmail(string email);
}

[RegisterPerRequest]
public class UserRepository : IUserRepository
{
    private readonly ApiDbContext _context;

    public UserRepository(ApiDbContext context)
    {
        _context = context;
    }

    public async Task<Entities.User> GetByIdAsync(int id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        return user;
    }

    public async Task<List<Entities.User>> GetAllAsync()
    {
        var users = await _context.Users.ToListAsync();
        return users;
    }

    public async Task CreateAsync(Entities.User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<Entities.User> FindByEmail(string email)
    {
        var user = await _context.Users.SingleOrDefaultAsync(x=> x.Email == email);
        return user;
    }
}