using AutoMapper;
using Backend.Core.Futures.MaterialsForStudy.Courses.DTOs.Requests;
using Backend.Domain.Entities;

namespace Backend.Core.Futures.MaterialsForStudy.Courses.Mapper.Profiles;

public class CreateCourseProfile : Profile
{
    public CreateCourseProfile()
    {
        CreateMap<CreateCourseDto, Course>();
    }
}