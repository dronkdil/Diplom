using Backend.Core.Futures.Notification.DTOs.Requests;
using Backend.Core.Futures.Notification.DTOs.Requests.Base;
using Backend.Core.Futures.Notification.DTOs.Responses;
using Backend.Domain.Responses.Base;

namespace Backend.Core.Futures.Notification;

public interface INotificationService
{
    Task<Response> SendAsync(SendNotificationDto dto, int? userId = null);
    Task<Response> RemoveAsync(RemoveNotificationDto dto);
    Task<Response<IEnumerable<NotificationDto>>> GetForUserAsync(int userId);
}