using AutoMapper;
using Backend.Core.Futures.Teacher.DTOs;
using Backend.Core.Futures.Teacher.Mapper.Actions;
using Backend.Domain.Entities;

namespace Backend.Core.Futures.Teacher.Mapper.Profiles;

public class CreateTeacherProfile : Profile
{
    public CreateTeacherProfile()
    {
        CreateMap<CreateTeacherDto, User>()
            .AfterMap<PasswordHashAction>();
        // .AfterMap((src, dest) => dest.PasswordHash = passwordHasher.Hash(src.Password));
    }
}