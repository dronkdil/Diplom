using Backend.Domain.Entities.Enums;

namespace Backend.Core.Futures.MaterialsForStudy.Courses.DTOs.Requests;

public class CreateCourseDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public CourseLevels Level { get; set; }
    public int TeacherId { get; set; }
    public int LimitOfStudents { get; set; }
}