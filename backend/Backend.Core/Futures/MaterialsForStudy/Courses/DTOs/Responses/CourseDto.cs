namespace Backend.Core.Futures.MaterialsForStudy.Courses.DTOs.Responses;

public class CourseDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int LimitOfStudents { get; set; }
    public IEnumerable<ModuleDto> Modules { get; set; } = null!;
}