﻿using AutoMapper;
using Backend.Core.Futures.MaterialsForStudy.Lessons.DTOs.Requests;
using Backend.Core.Interfaces.YoutubeLink;
using Backend.Domain.Entities;

namespace Backend.Core.Futures.MaterialsForStudy.Lessons.Mapper.Actions;

public class YoutubeLinkParseAction : IMappingAction<CreateLessonWithYoutubeDto, Lesson>
{
    private readonly IYoutubeLinkParser _youtubeLinkParser;

    public YoutubeLinkParseAction(IYoutubeLinkParser youtubeLinkParser)
    {
        _youtubeLinkParser = youtubeLinkParser;
    }

    public void Process(CreateLessonWithYoutubeDto source, Lesson destination, ResolutionContext context)
    {
        destination.YoutubeVideoId = _youtubeLinkParser.GetVideoId();
    }
}