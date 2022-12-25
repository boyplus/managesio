using Agoda.IoC.Core;
using Managesio.Core.Entities;
using Managesio.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Managesio.Core.Rspositories;

public interface IUserRepository
{
    public Task<User> GetByIdAsync(int id);
    public Task<List<User>> GetAllAsync();
    public Task CreateAsync(User user);
    public Task<User> FindByEmail(string email);
}

[RegisterPerRequest]
public class UserRepository : IUserRepository
{
    private readonly ApiDbContext _context;

    public UserRepository(ApiDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetByIdAsync(int id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        return user;
    }

    public async Task<List<User>> GetAllAsync()
    {
        var users = await _context.Users.ToListAsync();
        return users;
    }

    public async Task CreateAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User> FindByEmail(string email)
    {
        var user = await _context.Users.SingleOrDefaultAsync(x=> x.Email == email);
        return user;
    }
}