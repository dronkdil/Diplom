using Backend.Core.Futures.MaterialsForStudy.Modules.DTOs.Responses;

namespace Backend.Core.Futures.MaterialsForStudy.Courses.DTOs.Responses;

public class CoursePageDto
{
    public int Id { get; set; }
    public string ImageUrl { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int LimitOfStudents { get; set; }
    public TeacherDto Teacher { get; set; } = null!;
    public IEnumerable<ModuleDto> Modules { get; set; } = null!;
}