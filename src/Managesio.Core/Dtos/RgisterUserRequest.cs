using System.ComponentModel.DataAnnotations;

namespace Managesio.Core.Dtos;

public class RegisterUserRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [MinLength(8)]
    public string Password { get; set; }
    
    [Required]
    public string Firstname { get; set; }
    
    [Required]
    public string Lastname { get; set; }
}