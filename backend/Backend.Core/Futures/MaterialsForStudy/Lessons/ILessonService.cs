using Backend.Core.Futures.MaterialsForStudy.Lessons.DTOs.Requests;
using Backend.Core.Futures.MaterialsForStudy.Lessons.DTOs.Responses;
using Backend.Domain.Responses.Base;

namespace Backend.Core.Futures.MaterialsForStudy.Lessons;

public interface ILessonService
{
    Task<Response> CreateAsync(CreateLessonDto dto);
    Task<Response> RemoveAsync(RemoveLessonDto dto);
    Task<Response<ActualLessonDto>> UpdateTitleAsync(UpdateLessonTitleDto dto);
    Task<Response<ActualLessonDto>> UpdateDescriptionAsync(UpdateLessonDescriptionDto dto);
    Task<Response<ActualLessonDto>> UpdateVideoByUrlAsync(UpdateLessonVideoByUrlDto dto);
    Task<Response<ActualLessonDto>> UpdateHomeworkAsync(UpdateLessonHomeworkDto dto);
    Task<Response<LessonForPageDto>> GetForPageAsync(int id);
}