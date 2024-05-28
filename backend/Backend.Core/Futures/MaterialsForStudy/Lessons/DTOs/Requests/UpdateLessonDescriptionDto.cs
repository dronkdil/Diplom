using Backend.Core.Futures.MaterialsForStudy.Lessons.DTOs.Requests.Base;

namespace Backend.Core.Futures.MaterialsForStudy.Lessons.DTOs.Requests;

public class UpdateLessonDescriptionDto : UpdateLessonDto
{
    public string Description { get; set; } = null!;
}