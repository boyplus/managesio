using System.ComponentModel.DataAnnotations;

namespace Managesio.Core.Modules.TodoModule.Dtos;

public class UpdateTodoRequest
{
    [Required]
    public string Title { get; set; }
    
    [Required]
    public string Note { get; set; }
}