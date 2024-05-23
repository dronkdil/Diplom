using System.Collections;

namespace Backend.Core.Futures.MaterialsForStudy.Courses.DTOs.Responses;

public class ModuleDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int CompletedLessons => Lessons.Count(o => o.Completed);
    public IEnumerable<ShortLessonDto> Lessons { get; set; } = null!;
}