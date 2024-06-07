using Backend.Core.Futures.Notification;
using Backend.Core.Futures.Notification.DTOs.Responses;
using Backend.Domain.Responses.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Presentation.Controllers;

public class NotificationController : Controller
{
    private readonly INotificationService _notificationService;

    public NotificationController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpGet("/notification/get-for-user")]
    [Authorize]
    public async Task<Response<IEnumerable<NotificationDto>>> GetForUser(int userId)
    {
        return await _notificationService.GetForUserAsync(userId);
    }
}