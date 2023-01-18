using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Managesio.Core.Entities;

[Table("user")]
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [JsonIgnore]
    public Guid Id { get; set; }
    
    [Required]
    public string Email { get; set; }
    
    [Required]
    public string Firstname { get; set; }
    
    [Required]
    public string Lastname { get; set; }
    
    [Required]
    public Boolean IsVerified { get; set; }
    public int? Otp { get; set; }
    public DateTime? OtpExpireAt { get; set; }

    [JsonIgnore]
    public List<Todo> Todos { get; set; }

    [JsonIgnore]
    public string Password { get; set; }
}