namespace Backend.Core.Futures.MaterialsForStudy.Courses.DTOs.Requests;

public class UpdateDescriptionDto
{
    public int Id { get; set; }
    public string Description { get; set; } = null!;
}