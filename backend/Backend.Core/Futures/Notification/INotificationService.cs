using Backend.Core.Futures.Notification.DTOs.Requests;
using Backend.Domain.Responses.Base;

namespace Backend.Core.Futures.Notification;

public interface INotificationService
{
    Task<Response> SendAsync(SendNotificationDto dto);
    Task<Response> RemoveAsync(int notificationId);
    Task<Response> OnViewAllAsync(int userId);
    Task<Response> GetForUserAllAsync(int userId);
}