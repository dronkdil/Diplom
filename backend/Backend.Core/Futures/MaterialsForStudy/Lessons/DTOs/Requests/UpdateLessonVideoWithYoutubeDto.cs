using Backend.Core.Futures.MaterialsForStudy.Lessons.DTOs.Requests.Base;
using Microsoft.AspNetCore.Http;

namespace Backend.Core.Futures.MaterialsForStudy.Lessons.DTOs.Requests;

public class UpdateLessonVideoWithYoutubeDto : UpdateLessonDto
{
    public IFormFile Video { get; set; } = null!;
}