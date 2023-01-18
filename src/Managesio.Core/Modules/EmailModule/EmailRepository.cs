using Agoda.IoC.Core;
using Managesio.Core.Modules.EmailModule.Models;
using SendGrid;
using SendGrid.Helpers.Errors.Model;
using SendGrid.Helpers.Mail;

namespace Managesio.Core.Modules.EmailModule;

public interface IEmailRepository
{
    public Task SendEmailAsync(Email email);
}

[RegisterSingleton]
public class EmailRepository : IEmailRepository
{
    private readonly ISendGridClient _sendGridClient;

    public EmailRepository(ISendGridClient sendGridClient, IConfiguration configuration)
    {
        _sendGridClient = sendGridClient;
    }

    public async Task SendEmailAsync(Email email)
    {
        var msg = new SendGridMessage()
        {
            From = new EmailAddress(email.FromEmail, email.FromName),
            Subject = email.Subject,
            HtmlContent = email.Content
        };
        msg.AddTo(email.ToEmail);
        var response = await _sendGridClient.SendEmailAsync(msg);
        if (!response.IsSuccessStatusCode)
        {
            throw new SendGridInternalException();
        }
    }
}