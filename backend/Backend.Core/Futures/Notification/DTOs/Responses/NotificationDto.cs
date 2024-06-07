using Backend.Domain.Entities;

namespace Backend.Core.Futures.Notification.DTOs.Responses;

public class NotificationDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool OnViewed { get; set; }
    
    public int NotificationTypeId { get; set; }
    public NotificationType NotificationType { get; set; } = null!;
}