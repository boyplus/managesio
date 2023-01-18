using Agoda.IoC.Core;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Managesio.Core.Modules.EmailModule.Services;

public interface IEmailService
{
    public Task SendEmail();
}

[RegisterSingleton]
public class EmailService : IEmailService
{
    private readonly ISendGridClient _sendGridClient;
    private readonly IConfiguration _configuration;

    public EmailService(ISendGridClient sendGridClient, IConfiguration configuration)
    {
        _sendGridClient = sendGridClient;
        _configuration = configuration;
    }

    public async Task SendEmail()
    {
        string fromEmail = _configuration.GetSection("SendGridEmailSettings")
            .GetValue<string>("FromEmail");
 
        string fromName = _configuration.GetSection("SendGridEmailSettings")
            .GetValue<string>("FromName");

        var msg = new SendGridMessage()
        {
            From = new EmailAddress(fromEmail, fromName),
            Subject = "Plain Text Email",
            PlainTextContent = "Hello, WellCome. Have room"
        };
        msg.AddTo("ict224bj@gmail.com");
        var response = await _sendGridClient.SendEmailAsync(msg);
        string message = response.IsSuccessStatusCode ? "Email Send Successfully" : "Failed";
        Console.WriteLine(message);
    }
}