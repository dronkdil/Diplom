namespace Backend.Core.Futures.MaterialsForStudy.Courses.DTOs.Requests;

public class UpdateTitleDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
}