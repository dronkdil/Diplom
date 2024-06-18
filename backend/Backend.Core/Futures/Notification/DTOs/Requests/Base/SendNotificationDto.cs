using Backend.Domain.Entities.Enums;

namespace Backend.Core.Futures.Notification.DTOs.Requests.Base;

public class SendNotificationDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public NotificationTypes NotificationTypeEnum { get; set; }
}