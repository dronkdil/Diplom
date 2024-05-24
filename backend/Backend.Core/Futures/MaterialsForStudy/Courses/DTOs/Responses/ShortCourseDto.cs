namespace Backend.Core.Futures.MaterialsForStudy.Courses.DTOs.Responses;

public class ShortCourseDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int LimitOfStudents { get; set; }
}