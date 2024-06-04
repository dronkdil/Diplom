namespace Backend.Core.Futures.MaterialsForStudy.Lessons.DTOs.Responses;

public class ActualLessonDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string HomeworkStatus { get; set; } = null!;
    public string HomeworkDescription { get; set; } = null!;
    public string VideoType { get; set; } = null!;
}