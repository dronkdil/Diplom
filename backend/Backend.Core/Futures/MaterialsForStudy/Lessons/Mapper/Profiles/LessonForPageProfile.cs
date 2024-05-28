using AutoMapper;
using Backend.Core.Futures.MaterialsForStudy.Lessons.DTOs.Responses;
using Backend.Domain.Entities;

namespace Backend.Core.Futures.MaterialsForStudy.Lessons.Mapper.Profiles;

public class LessonForPageProfile : Profile
{
    public LessonForPageProfile()
    {
        CreateMap<Lesson, LessonForLinkDto>();
        
        CreateMap<Lesson, LessonForPageDto>()
            .AfterMap((src, dest, context) => dest.OtherLessons = context.Mapper.Map<IEnumerable<LessonForLinkDto>>(src.Module.Lessons));
    }
}