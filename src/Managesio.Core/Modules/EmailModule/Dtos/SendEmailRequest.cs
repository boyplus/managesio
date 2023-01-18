using System.ComponentModel.DataAnnotations;

namespace Managesio.Core.Modules.EmailModule.Dtos;

public class SendEmailRequest
{
    [Required]
    [EmailAddress] 
    public string ToEmail { get; set; }
    
    [Required]
    public string Subject { get; set; }
    
    [Required]
    public string Content { get; set; }
}