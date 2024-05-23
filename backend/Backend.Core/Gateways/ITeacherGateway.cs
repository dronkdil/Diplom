using Backend.Domain.Entities;

namespace Backend.Core.Gateways;

public interface ITeacherGateway
{
    Task<IEnumerable<Course>?> GetCoursesAsync(int id);
    Task<bool> AddAsync(Teacher user);
    Task<bool> RemoveAsync(int id);
    Task<IEnumerable<Teacher>> GetAllTeachers();
}