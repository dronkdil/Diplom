using Backend.Core.Futures.MaterialsForStudy.Lessons.DTOs.Requests.Base;

namespace Backend.Core.Futures.MaterialsForStudy.Lessons.DTOs.Requests;

public class UpdateLessonVideoByUrlDto : UpdateLessonDto
{
    public string VideoUrl { get; set; } = null!;
}