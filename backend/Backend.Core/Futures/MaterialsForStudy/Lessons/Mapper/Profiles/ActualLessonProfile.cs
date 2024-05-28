using AutoMapper;
using Backend.Core.Futures.MaterialsForStudy.Lessons.DTOs.Responses;
using Backend.Domain.Entities;

namespace Backend.Core.Futures.MaterialsForStudy.Lessons.Mapper.Profiles;

public class ActualLessonProfile : Profile
{
    public ActualLessonProfile()
    {
        CreateMap<Lesson, ActualLessonDto>();
    }
}