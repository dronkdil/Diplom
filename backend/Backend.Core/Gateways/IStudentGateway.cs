using Backend.Domain.Entities;

namespace Backend.Core.Gateways;

public interface IStudentGateway
{
    Task<Student> AddAsync(Student user);
    Task<bool> UpdateAsync(int id, Action<Student> configure);
    Task<IEnumerable<Student>> GetAllAsync();
    Task<bool> JoinCourse(int studentId, int courseId);
}