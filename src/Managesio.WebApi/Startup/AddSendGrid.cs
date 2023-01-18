using Managesio.Core.Configs;
using SendGrid.Extensions.DependencyInjection;

namespace Managesio.WebApi.Startup;

public static class AddSendGrid
{
    public static void AddSendGridClient(this IServiceCollection serviceCollection, Secrets secrets)
    {
        var sendgridApiKey = secrets.SendGridApiKey;
        serviceCollection.AddSendGrid(options => options.ApiKey = sendgridApiKey);
    }
}