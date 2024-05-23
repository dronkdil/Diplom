using Backend.Domain.Entities;

namespace Backend.Core.Gateways;

public interface ICourseGateway
{
    Task<bool> AddAsync(Course course);
    Task<bool> RemoveAsync(int id);
    Task<IEnumerable<Course>> GetAllAsync();
}