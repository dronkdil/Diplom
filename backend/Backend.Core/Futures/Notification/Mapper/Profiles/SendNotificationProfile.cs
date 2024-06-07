using AutoMapper;
using Backend.Core.Futures.Notification.DTOs.Requests.Base;
using Backend.Core.Futures.Notification.DTOs.Responses;

namespace Backend.Core.Futures.Notification.Mapper.Profiles;

public class SendNotificationProfile : Profile
{
    public SendNotificationProfile()
    {
        CreateMap<SendNotificationDto, Domain.Entities.Notification>();
        CreateMap<Domain.Entities.Notification, NotificationDto>();
    }
}