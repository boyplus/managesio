using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Managesio.Core.Entities;

[Table("project")]
public class Project
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Description { get; set; }

    [JsonIgnore]
    public User User { get; set; }
    
    [JsonIgnore]
    [Column("owner_id")]
    public Guid UserId { get; set; }
}