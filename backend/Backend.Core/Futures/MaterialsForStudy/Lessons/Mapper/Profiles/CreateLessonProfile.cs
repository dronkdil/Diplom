using AutoMapper;
using Backend.Core.Futures.MaterialsForStudy.Lessons.DTOs.Requests;
using Backend.Core.Futures.MaterialsForStudy.Lessons.Mapper.Actions;
using Backend.Domain.Entities;
using Backend.Domain.Entities.Enums;

namespace Backend.Core.Futures.MaterialsForStudy.Lessons.Mapper.Profiles;

public class CreateLessonProfile : Profile
{
    public CreateLessonProfile()
    {
        CreateMap<CreateLessonWithYoutubeDto, Lesson>()
            .AfterMap((src, dest) => dest.VideoType = LessonVideoTypes.YoutubeVideo)
            .AfterMap<YoutubeVideoIdAction>();
    }
}