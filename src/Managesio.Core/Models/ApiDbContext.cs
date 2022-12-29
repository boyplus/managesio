using Managesio.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Managesio.Core.Models;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options): base(options)
    {
        
    }

    // Entities
    public DbSet<Todo> Todos { get; set; }
    public DbSet<User> Users { get; set; }
}