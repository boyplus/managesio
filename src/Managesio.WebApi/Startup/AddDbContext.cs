using Managesio.Core.Configs;
using Managesio.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Managesio.WebApi.Startup;

public static class AddDbContext
{
    public static void AddPosgresDbConnection(this IServiceCollection serviceCollection, Secrets secrets)
    {
        var connectionString = secrets.DbConnectionString;
        Console.WriteLine("inside");
        Console.WriteLine(connectionString);
        serviceCollection.AddDbContext<ApiDbContext>(options =>
            options.UseNpgsql(
                connectionString
            )
        );
    }
}