using Backend.Core.Futures.MaterialsForStudy.Homeworks.DTOs.Requests;
using Backend.Core.Futures.MaterialsForStudy.Homeworks.DTOs.Responses;
using Backend.Domain.Responses.Base;

namespace Backend.Core.Futures.MaterialsForStudy.Homeworks;

public interface IHomeworkService
{
    Task<Response> SendAsync(SendHomeworkDto dto);
    Task<Response> EvaluateAsync(EvaluateHomeworkDto dto);
    Task<Response<IEnumerable<CompletedHomeworkDto>>> GetByLessonAsync(int lessonId);
    Task<Response> CancelSendingAsync(CancelHomeworkDto dto);
    Task<Response<StudentHomeworkDto>> GetByStudentAsync(int studentId, int lessonId);
}