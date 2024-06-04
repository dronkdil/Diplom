namespace Backend.Core.Futures.MaterialsForStudy.Courses.DTOs.Responses;

public class CourseLessonDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool Completed { get; set; }
}