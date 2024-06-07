using Backend.Core.Gateways;
using Backend.Domain.Entities;
using Backend.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Gateways;

public class NotificationGateway : INotificationGateway
{
    private readonly DataContext _dataContext;

    public NotificationGateway(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task AddAsync(Notification notification)
    {
        _dataContext.Notifications.Add(notification);
        await _dataContext.SaveChangesAsync();
    }

    public async Task RemoveAsync(int id)
    {
        _dataContext.Notifications.Remove(new Notification {Id = id});
        await _dataContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Notification>> GetForUserAsync(int userId)
    {
        return await _dataContext.Notifications
            .Where(o => o.UserId == userId)
            .ToListAsync();
    }
}