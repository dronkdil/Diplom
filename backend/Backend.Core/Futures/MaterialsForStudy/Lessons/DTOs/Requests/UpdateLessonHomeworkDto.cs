using Backend.Core.Futures.MaterialsForStudy.Lessons.DTOs.Requests.Base;

namespace Backend.Core.Futures.MaterialsForStudy.Lessons.DTOs.Requests;

public class UpdateLessonHomeworkDto : UpdateLessonDto
{
    public bool Status { get; set; }
    public string Description { get; set; } = null!;
}