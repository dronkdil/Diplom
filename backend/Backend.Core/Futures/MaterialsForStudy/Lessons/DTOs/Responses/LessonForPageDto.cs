using Backend.Domain.Entities.Enums;

namespace Backend.Core.Futures.MaterialsForStudy.Lessons.DTOs.Responses;

public class LessonForPageDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool HaveHomework { get; set; }
    public string HomeworkDescription { get; set; } = null!;
    public string? VideoName { get; set; }
    public string? YoutubeVideoId { get; set; }
    public LessonVideoTypes VideoType { get; set; }
    public IEnumerable<LessonForLinkDto> OtherLessons { get; set; } = null!;
}