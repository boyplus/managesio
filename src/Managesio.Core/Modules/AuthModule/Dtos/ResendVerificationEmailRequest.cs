using System.ComponentModel.DataAnnotations;

namespace Managesio.Core.Modules.AuthModule.Dtos;

public class ResendVerificationEmailRequest
{
    [EmailAddress] public string Email { get; set; }
}