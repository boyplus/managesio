using Agoda.IoC.Core;
using Managesio.Core.Entities;
using Managesio.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Managesio.Core.Modules.UserModule.Repositories;

public interface IUserRepository
{
    public Task<User> GetByIdAsync(Guid id);
    public Task<List<User>> GetAllAsync();
    public Task CreateAsync(User user);
    public Task<User> FindByEmail(string email);
    public Task<List<User>> SearchByEmail(string email);
    public Task SaveOtpAsync(User user, int otp, DateTime expireAt);
    public Task VerifyUser(User user);
}

[RegisterPerRequest]
public class UserRepository : IUserRepository
{
    private readonly ApiDbContext _context;

    public UserRepository(ApiDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetByIdAsync(Guid id)
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

    public Task<User> FindByEmail(string email)
    {
        var user = _context.Users.SingleOrDefaultAsync(x=> x.Email == email);
        return user;
    }

    public async Task SaveOtpAsync(User user,int otp, DateTime expireAt)
    {
        user.Otp = otp;
        user.OtpExpireAt = expireAt;
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task VerifyUser(User user)
    {
        user.IsVerified = true;
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public Task<List<User>> SearchByEmail(string email)
    {
        var users = _context.Users.Where(user => EF.Functions.Like(user.Email, $"{email}%") && user.IsVerified).ToListAsync();
        return users;
    }
}