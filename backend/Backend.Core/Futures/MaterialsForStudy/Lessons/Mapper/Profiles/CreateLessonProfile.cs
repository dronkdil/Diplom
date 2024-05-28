using AutoMapper;
using Backend.Core.Futures.MaterialsForStudy.Lessons.DTOs.Requests;
using Backend.Domain.Entities;

namespace Backend.Core.Futures.MaterialsForStudy.Lessons.Mapper.Profiles;

public class CreateLessonProfile : Profile
{
    public CreateLessonProfile()
    {
        CreateMap<CreateLessonDto, Lesson>();
    }
}