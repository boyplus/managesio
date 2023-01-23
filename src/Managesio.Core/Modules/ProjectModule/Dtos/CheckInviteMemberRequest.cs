using System.ComponentModel.DataAnnotations;

namespace Managesio.Core.Modules.ProjectModule.Dtos;

public class CheckInviteMemberRequest
{
    [Required] public string Email { get; set; }
}