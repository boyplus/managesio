using Managesio.Core.Entities;
using Managesio.Core.Maps;
using Microsoft.EntityFrameworkCore;

namespace Managesio.Core.Models;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options): base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new TodoMap(modelBuilder.Entity<Todo>());
        // new UserMap(modelBuilder.Entity<User>());
    }
    
    // Entities
    public DbSet<Todo> Todos { get; set; }
    // public DbSet<User> Users { get; set; }
}