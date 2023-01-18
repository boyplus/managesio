using Agoda.IoC.Core;
using Managesio.Core.Modules.EmailModule.Models;

namespace Managesio.Core.Modules.EmailModule.Services;

public interface IEmailService
{
    public Task SendEmailAsync(string toEmail, string subject, string content);
}

[RegisterSingleton]
public class EmailService : IEmailService
{
    private readonly IEmailRepository _emailRepository;
    private readonly IConfiguration _configuration;

    public EmailService(IEmailRepository emailRepository, IConfiguration configuration)
    {
        _emailRepository = emailRepository;
        _configuration = configuration;
    }

    public async Task SendEmailAsync(String toEmail, String subject, String content)
    {
        string fromEmail = _configuration.GetSection("SendGridEmailSettings")
            .GetValue<string>("FromEmail");
 
        string fromName = _configuration.GetSection("SendGridEmailSettings")
            .GetValue<string>("FromName");
        
        var email = new Email
        {
            FromEmail = fromEmail,
            FromName = fromName,
            ToEmail = toEmail,
            Subject = subject,
            Content = content
        };
        await _emailRepository.SendEmailAsync(email);
    }
}