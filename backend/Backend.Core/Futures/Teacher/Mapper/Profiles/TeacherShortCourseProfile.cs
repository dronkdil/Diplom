using AutoMapper;
using Backend.Core.Futures.Teacher.DTOs;
using Backend.Domain.Entities;

namespace Backend.Core.Futures.Teacher.Mapper.Profiles;

public class TeacherShortCourseProfile : Profile
{
    public TeacherShortCourseProfile()
    {
        CreateMap<Course, TeacherShortCourseDto>()
            .AfterMap((src, dest) => dest.StudentCount = src.Students.Count);
    }
}