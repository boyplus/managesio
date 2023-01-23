using System.ComponentModel.DataAnnotations;

namespace Managesio.Core.Modules.ProjectModule.Dtos;

public class CreateProjectRequest
{
    [Required] public string Name { get; set; }
    [Required] public string Description { get; set; }
}