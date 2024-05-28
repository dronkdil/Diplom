using Backend.Domain.Entities;

namespace Backend.Core.Gateways;

public interface IUserGateway
{
    Task<bool> IsExistsByEmailAsync(string email);
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByIdAsync(int id);
    Task<User?> UpdateAsync(int id, Action<User> configure);
}