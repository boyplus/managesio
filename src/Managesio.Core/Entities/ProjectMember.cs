using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Managesio.Core.Entities;

[Table("project_member")]
public class ProjectMember
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public Project Project { get; set; }
    public Guid ProjectId { get; set; }
    
    public User User { get; set; }
    public Guid UserId { get; set; }
}