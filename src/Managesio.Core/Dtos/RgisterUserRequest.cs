using System.ComponentModel.DataAnnotations;

namespace Managesio.Core.Dtos;

public class RegisterUserRequest
{
    [Required]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
}