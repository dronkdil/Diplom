using AutoMapper;
using Backend.Core.Futures.Users.Students.DTOs.Responses;
using Backend.Domain.Entities;

namespace Backend.Core.Futures.Users.Students.Mapper.Profiles;

public class StudentCourseProfile : Profile
{
    public StudentCourseProfile()
    {
        CreateMap<Course, StudentCourseDto>()
            .AfterMap((src, desc) => desc.Progress = 0); // TODO: change when lesson functionality completed
    }
}