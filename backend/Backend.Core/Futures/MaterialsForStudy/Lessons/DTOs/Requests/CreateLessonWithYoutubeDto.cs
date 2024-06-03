using Microsoft.AspNetCore.Http;

namespace Backend.Core.Futures.MaterialsForStudy.Lessons.DTOs.Requests;

public class CreateLessonDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string YoutubeLink { get; set; } = null!;
    public int ModuleId { get; set; }
}