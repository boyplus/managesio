using System.ComponentModel.DataAnnotations;

namespace Managesio.Core.Modules.ProjectModule.Dtos;

public class InviteProjectMemberRequest{
    
    [Required]
    public List<string> Emails { get; set; }
}