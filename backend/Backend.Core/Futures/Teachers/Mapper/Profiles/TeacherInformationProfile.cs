using AutoMapper;
using Backend.Core.Futures.Teachers.DTOs;
using Backend.Domain.Entities;

namespace Backend.Core.Futures.Teachers.Mapper.Profiles;

public class TeacherInformationProfile : Profile
{
    public TeacherInformationProfile()
    {
        CreateMap<Teacher, TeacherInformationDto>();
    }
}