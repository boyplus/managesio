using System.ComponentModel.DataAnnotations;

namespace Managesio.Core.Dtos;

public class AuthenticateRequest
{
    [EmailAddress]
    public string Email { get; set; }
    
    [MinLength(8)]
    public string Password { get; set; }
}