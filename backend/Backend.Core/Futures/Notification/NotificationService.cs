using AutoMapper;
using Backend.Core.Futures.Notification.DTOs.Requests;
using Backend.Core.Futures.Notification.DTOs.Requests.Base;
using Backend.Core.Futures.Notification.DTOs.Responses;
using Backend.Core.Gateways;
using Backend.Core.UserContext;
using Backend.Domain.Responses.Base;

namespace Backend.Core.Futures.Notification;

public class NotificationService : INotificationService
{
    private readonly INotificationGateway _notificationGateway;
    private readonly IMapper _mapper;
    private readonly IUserContext _userContext;

    public NotificationService(INotificationGateway notificationGateway, IMapper mapper, IUserContext userContext)
    {
        _notificationGateway = notificationGateway;
        _mapper = mapper;
        _userContext = userContext;
    }

    public async Task<Response> SendAsync(SendNotificationDto dto, int? userId = null)
    {
        var notification = _mapper.Map(dto, new Domain.Entities.Notification
        {
            UserId = userId ?? _userContext.UserId
        });
        await _notificationGateway.AddAsync(notification);
        return Response.Success();
    }

    public async Task<Response> RemoveAsync(RemoveNotificationDto dto)
    {
        await _notificationGateway.RemoveAsync(dto.NotificationId);
        return Response.Success();
    }

    public async Task<Response<IEnumerable<NotificationDto>>> GetForUserAsync(int userId)
    {
        var notifications = await _notificationGateway.GetForUserAsync(userId);
        return Response.Success(_mapper.Map<IEnumerable<NotificationDto>>(notifications));
    }
}