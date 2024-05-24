namespace Backend.Core.Futures.MaterialsForStudy.Modules.DTOs.Requests;

public class UpdateModuleDescriptionDto
{
    public int Id { get; set; }
    public string Description { get; set; } = null!;
}