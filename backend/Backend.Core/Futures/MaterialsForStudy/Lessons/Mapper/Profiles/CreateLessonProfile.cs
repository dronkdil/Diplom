using AutoMapper;
using Backend.Core.Futures.MaterialsForStudy.Lessons.DTOs.Requests;
using Backend.Domain.Entities;
using Backend.Domain.Entities.Enums;

namespace Backend.Core.Futures.MaterialsForStudy.Lessons.Mapper.Profiles;

public class CreateLessonWithYoutubeProfile : Profile
{
    public CreateLessonWithYoutubeProfile()
    {
        CreateMap<CreateLessonWithYoutubeDto, Lesson>()
            .AfterMap((src, dest) => dest.VideoType = LessonVideoTypes.YoutubeLink);
    }
}