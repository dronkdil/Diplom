using AutoMapper;
using Backend.Core.Futures.Users.Common.UpdateInformation.DTOs.Responses;
using Backend.Domain.Entities;

namespace Backend.Core.Futures.Users.Common.UpdateInformation.Mapper.Profiles;

public class ActualUserProfile : Profile
{
    public ActualUserProfile()
    {
        CreateMap<User, ActualUserDto>();
    }
}