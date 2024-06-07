namespace Backend.Core.Futures.Notification.DTOs.Requests.Base;

public class SendNotificationDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
}