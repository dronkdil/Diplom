namespace Backend.Core.Futures.MaterialsForStudy.Courses.DTOs.Requests;

public class UpdateCourseTitleDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
}