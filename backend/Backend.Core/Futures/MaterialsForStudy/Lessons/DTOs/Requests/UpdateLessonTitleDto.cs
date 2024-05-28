using Backend.Core.Futures.MaterialsForStudy.Lessons.DTOs.Requests.Base;

namespace Backend.Core.Futures.MaterialsForStudy.Lessons.DTOs.Requests;

public class UpdateLessonTitleDto : UpdateLessonDto
{
    public string Title { get; set; } = null!;
}