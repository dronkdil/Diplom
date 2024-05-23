using Backend.Domain.Entities;
using Backend.Domain.Entities.Base;

namespace Backend.Core.Gateways;

public interface IUserGateway
{
    Task<bool> IsExistsByEmailAsync(string email);
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByIdAsync(int id);
    Task<User> AddStudentAsync(User user);
    Task<bool> AddTeacherAsync(User user);
}