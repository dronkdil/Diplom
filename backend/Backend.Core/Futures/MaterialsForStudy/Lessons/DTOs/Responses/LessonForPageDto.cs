namespace Backend.Core.Futures.MaterialsForStudy.Lessons.DTOs.Responses;

public class LessonForPageDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool HomeworkStatus { get; set; }
    public string HomeworkDescription { get; set; } = null!;
    public string VideoUrl { get; set; } = null!;
    public IEnumerable<LessonForLinkDto> OtherLessons { get; set; } = null!;
}