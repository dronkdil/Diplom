using System.Security.Principal;

namespace Backend.Core.Futures.MaterialsForStudy.Modules.DTOs.Requests;

public class CreateModuleDto
{
    public int CourseId { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
}