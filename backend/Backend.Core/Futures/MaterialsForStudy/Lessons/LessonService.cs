using AutoMapper;
using Backend.Core.Futures.MaterialsForStudy.Lessons.DTOs.Requests;
using Backend.Core.Futures.MaterialsForStudy.Lessons.DTOs.Responses;
using Backend.Core.Futures.MaterialsForStudy.Lessons.Responses;
using Backend.Core.Futures.Notification;
using Backend.Core.Futures.Notification.DTOs.Requests;
using Backend.Core.Gateways;
using Backend.Core.Interfaces.YoutubeLink;
using Backend.Core.UserContext;
using Backend.Domain.Entities;
using Backend.Domain.Entities.Enums;
using Backend.Domain.Responses.Base;
using FluentValidation;

namespace Backend.Core.Futures.MaterialsForStudy.Lessons;

public class LessonService : ILessonService
{
    private readonly ILessonGateway _lessonGateway;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateLessonWithYoutubeDto> _createLessonValidator;
    private readonly IYoutubeLinkParser _youtubeLinkParser;
    private readonly IUserContext _userContext;
    private readonly ICourseGateway _courseGateway;
    private readonly INotificationService _notificationService;

    public LessonService(ILessonGateway lessonGateway, IMapper mapper, IValidator<CreateLessonWithYoutubeDto> createLessonValidator, IYoutubeLinkParser youtubeLinkParser, IUserContext userContext, ICourseGateway courseGateway, INotificationService notificationService)
    {
        _lessonGateway = lessonGateway;
        _mapper = mapper;
        _createLessonValidator = createLessonValidator;
        _youtubeLinkParser = youtubeLinkParser;
        _userContext = userContext;
        _courseGateway = courseGateway;
        _notificationService = notificationService;
    }

    public async Task<Response> CreateWithYoutubeAsync(CreateLessonWithYoutubeDto withYoutubeDto)
    {
        if (await _createLessonValidator.ValidateAsync(withYoutubeDto) is { IsValid: false } result)
            return Response.ValidationFailed(result.Errors);
        
        var lesson = _mapper.Map<Lesson>(withYoutubeDto);
        await _lessonGateway.AddAsync(lesson);
        return Response.Success();
    }

    public async Task<Response> RemoveAsync(RemoveLessonDto dto)
    {
        await _lessonGateway.RemoveAsync(dto.Id);
        return Response.Success();
    }

    public async Task<Response<ActualLessonDto>> UpdateTitleAsync(UpdateLessonTitleDto dto)
    {
        return await UpdateAsync(dto.LessonId, o =>
        {
            o.Title = dto.Title;
        });
    }

    public async Task<Response<ActualLessonDto>> UpdateDescriptionAsync(UpdateLessonDescriptionDto dto)
    {
        return await UpdateAsync(dto.LessonId, o =>
        {
            o.Description = dto.Description;
        });
    }

    public async Task<Response<ActualLessonDto>> UpdateVideoYoutubeAsync(UpdateLessonVideoWithYoutubeDto dto)
    {
        return await UpdateAsync(dto.LessonId, o =>
        {
            o.YoutubeVideoId = _youtubeLinkParser.GetVideoId(dto.YoutubeLink);
            o.VideoType = LessonVideoTypes.YoutubeVideo;
        });
    }

    public async Task<Response<ActualLessonDto>> UpdateHomeworkAsync(UpdateLessonHomeworkDto dto)
    {
        return await UpdateAsync(dto.LessonId, o =>
        {
            o.HomeworkDescription = dto.Description;
            o.HaveHomework = dto.Status;
        });
    }

    public async Task<Response<LessonForPageDto>> GetForPageAsync(int id)
    {
        var lesson = await _lessonGateway.GetByIdWithLessonsOfModuleAsync(id);
        return lesson == null
            ? Response.Failed<LessonForPageDto>()
            : Response.Success(_mapper.Map<LessonForPageDto>(lesson));
    }

    public async Task<Response> OnView(OnViewLessonDto dto)
    {
        await _lessonGateway.OnViewAsync(dto.LessonId, _userContext.UserId);

        var isCompleted = await _courseGateway.IsCompletedByLessonAsync(dto.LessonId, _userContext.UserId);
        var courseName = await _courseGateway.GetCourseTitleByLessonAsync(dto.LessonId);
        if (isCompleted)
            await _notificationService.SendAsync(new StudentFinishedCourseDto(courseName));
        
        return Response.Success();
    }

    private async Task<Response<ActualLessonDto>> UpdateAsync(int id, Action<Lesson> configure)
    {
        var actual = await _lessonGateway.UpdateAsync(id, configure);
        return actual == null
            ? ActualLessonResponseHelper.InvalidId()
            : Response.Success(_mapper.Map<ActualLessonDto>(actual));
    }
    
    private async Task<Response<ActualLessonDto>> UpdateWithAsyncConfigureAsync(int id, Func<Lesson, Task> configure)
    {
        var actual = await _lessonGateway.UpdateAsync(id, configure);
        return actual == null
            ? ActualLessonResponseHelper.InvalidId()
            : Response.Success(_mapper.Map<ActualLessonDto>(actual));
    }
}