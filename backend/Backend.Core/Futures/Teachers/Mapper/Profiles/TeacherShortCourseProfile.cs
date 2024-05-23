using AutoMapper;
using Backend.Core.Futures.Teachers.DTOs;
using Backend.Domain.Entities;

namespace Backend.Core.Futures.Teachers.Mapper.Profiles;

public class TeacherShortCourseProfile : Profile
{
    public TeacherShortCourseProfile()
    {
        CreateMap<Course, TeacherShortCourseDto>()
            .AfterMap((src, dest) => dest.StudentCount = src.Students.Count);
    }
}