using System.ComponentModel.DataAnnotations;

namespace Managesio.Core.Modules.AuthModule.Dtos;

public class VerifyUserRequest
{
    [Required]
    [EmailAddress] 
    public string Email { get; set; }
    
    [Required]
    public int Otp { get; set; }
}