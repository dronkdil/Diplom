using Backend.Domain.Entities;
using Backend.Domain.Entities.Base;

namespace Backend.Core.Gateways;

public interface IUserGateway
{
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByIdAsync(int id);
    Task<User> AddStudentAsync(User user, StudentAdditionalData data);
}