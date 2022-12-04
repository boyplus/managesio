using Managesio.Core.Configs;
using Managesio.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Managesio.WebApi.Startup;

public static class AddDbContext
{
    public static void AddDbConnection(this IServiceCollection serviceCollection, Secrets secrets)
    {
        var connectionString = secrets.DbConnectionString;
        Console.WriteLine("inside add db connection");
        Console.WriteLine(connectionString);
        serviceCollection.AddDbContext<ApiDbContext>(options =>
            options.UseNpgsql(
                connectionString
            )
        );
    }
}