namespace Managesio.Core.Configs;

public class Secrets
{
    public string DbConnectionString { get; set; }
    public string JwtSecret { get; set; }
    public string SendGridApiKey { get; set; }
}