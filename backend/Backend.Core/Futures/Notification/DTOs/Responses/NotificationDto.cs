namespace Backend.Core.Futures.Notification.DTOs.Responses;

public class NotificationDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
}