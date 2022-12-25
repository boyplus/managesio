using Agoda.IoC.Core;
using Managesio.Core.Entities;
using Managesio.Core.Models;

namespace Managesio.Core.Rspositories;

public interface IUserRepository
{
    public List<User> GetAll();
}

[RegisterPerRequest]
public class UserRepository : IUserRepository
{
    private readonly ApiDbContext _context;

    public UserRepository(ApiDbContext context)
    {
        _context = context;
    }

    public List<User> GetAll()
    {
        return new List<User>();
        // return _context.Users.ToList();
    }
}