using AutoMapper;
using Backend.Core.Futures.Authentication.DTOs;
using Backend.Domain.Entities;

namespace Backend.Core.Futures.Authentication.Mapper.Profiles;

public class AuthenticationUserProfile : Profile
{
    public AuthenticationUserProfile()
    {
        CreateMap<User, AuthenticationUserDto>()
            .ForMember(dest => dest.Role, opt => opt.Ignore())
            .AfterMap((src, dest) => dest.Role ??= src.Role.Name);
    }
}