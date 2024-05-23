using AutoMapper;
using Backend.Core.Futures.Authentication.DTOs;
using Backend.Core.Futures.Authentication.Mapper.Actions;
using Backend.Domain.Entities;
using Backend.Domain.Entities.Enums;

namespace Backend.Core.Futures.Authentication.Mapper.Profiles;

public class RegistrationStudentProfile : Profile
{
    public RegistrationStudentProfile()
    {
        CreateMap<RegistrationStudentDto, Student>()
            .AfterMap<PasswordHashAction>()
            .AfterMap((src, dest) => dest.RoleId = (int)Roles.Student);
    }
}