using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Managesio.Core.Entities;

[Table("todo")]
public class Todo
{
    [Key] 
    public int Id { get; set; }
    public string Title { get; set; }
    public string Note { get; set; }
}