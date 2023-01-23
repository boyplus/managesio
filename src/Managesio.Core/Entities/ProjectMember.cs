using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Managesio.Core.Entities;

[Table("project_member")]
[PrimaryKey(nameof(ProjectId), nameof(UserId))]
public class ProjectMember
{
    public Guid ProjectId { get; set; }
    public Guid UserId { get; set; }
    
    public Project Project { get; set; }
    public User User { get; set; }
    [JsonIgnore]
    public Boolean IsConfirmed { get; set; }
}