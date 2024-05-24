using AutoMapper;
using Backend.Core.Futures.Users.Teachers.DTOs;
using Backend.Core.Futures.Users.Teachers.Mapper.Actions;
using Backend.Domain.Entities;
using Backend.Domain.Entities.Enums;

namespace Backend.Core.Futures.Users.Teachers.Mapper.Profiles;

public class CreateTeacherProfile : Profile
{
    public CreateTeacherProfile()
    {
        CreateMap<CreateTeacherDto, Teacher>()
            .AfterMap<PasswordHashAction>()
            .AfterMap((src, dest) => dest.RoleId = (int)Roles.Teacher);
    }
}