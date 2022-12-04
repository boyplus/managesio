using Agoda.IoC.Core;
using Managesio.Core.Maps;
using Microsoft.EntityFrameworkCore;

namespace Managesio.Core.Models;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options): base(options)
    {
        
    }

    public DbSet<Todo> Todos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new TodoMap(modelBuilder.Entity<Todo>());
    }
    

}