using Backend.Domain.Entities;

namespace Backend.Core.Gateways;

public interface INotificationGateway
{
    Task AddAsync(Notification notification);
    Task RemoveAsync(int id);
    Task<IEnumerable<Notification>> GetForUserAsync(int userId);
}