using Backend.Domain.Entities;

namespace Backend.Core.Gateways;

public interface ILessonGateway
{
    Task<Lesson?> GetByIdWithLessonsOfModuleAsync(int id);
    Task AddAsync(Lesson lesson);
    Task RemoveAsync(int id);
    Task<Lesson?> UpdateAsync(int id, Action<Lesson> configure);
}