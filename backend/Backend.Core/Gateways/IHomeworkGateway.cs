using Backend.Domain.Entities;

namespace Backend.Core.Gateways;

public interface IHomeworkGateway
{
    Task AddOrUpdateAsync(Homework homework);
    Task CancelSendingAsync(int id);
    Task EvaluateAsync(int id, int? appraisal, string? comment);
    Task<IEnumerable<Homework>> GetByLessonIdWithStudentAsync(int lessonId);
    Task<Homework?> GetByStudentIdAsync(int studentId);
}