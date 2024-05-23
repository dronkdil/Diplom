using Backend.Domain.Entities;

namespace Backend.Core.Gateways;

public interface ITeacherGateway
{
    Task<IEnumerable<Course>?> GetCoursesAsync(int userId);
}