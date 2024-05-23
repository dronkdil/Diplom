using Backend.Domain.Entities;

namespace Backend.Core.Gateways;

public interface IStudentGateway
{
    Task<Student> AddAsync(Student user);
}