using Backend.Domain.Entities;

namespace Backend.Core.Gateways;

public interface ICourseGateway
{
    Task<bool> AddAsync(Course course);
    Task<bool> RemoveAsync(int id);
    Task<IEnumerable<Course>> GetAllAsync();
    Task<bool> UpdateAsync(int id, Action<Course> configure);
    Task<Course?> GetCourseByIdAsync(int id);
    Task<bool> HaveFreeSlotsAsync(int id);
    Task<bool> HaveStudentAsync(int userId, int courseId);
}