using Backend.Core.Futures.MaterialsForStudy.Courses.DTOs.Responses;

namespace Backend.Core.Futures.MaterialsForStudy.Modules.DTOs.Responses;

public class ModuleDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int CompletedLessons => Lessons.Count(o => o.Completed);
    public IEnumerable<CourseLessonDto> Lessons { get; set; } = null!;
}