namespace Backend.Core.Futures.MaterialsForStudy.Modules.DTOs.Responses;

public class ShortLessonDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public bool Completed { get; set; }
}