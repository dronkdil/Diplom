using AutoMapper;
using Backend.Core.Futures.Users.Teachers.DTOs;
using Backend.Domain.Entities;

namespace Backend.Core.Futures.Users.Teachers.Mapper.Profiles;

public class TeacherInformationProfile : Profile
{
    public TeacherInformationProfile()
    {
        CreateMap<Teacher, TeacherInformationDto>();
    }
}