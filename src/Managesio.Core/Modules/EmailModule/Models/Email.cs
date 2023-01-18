namespace Managesio.Core.Modules.EmailModule.Models;

public class Email
{
    public string FromEmail { get; set; }
    public string FromName { get; set; }
    public string ToEmail { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }
}