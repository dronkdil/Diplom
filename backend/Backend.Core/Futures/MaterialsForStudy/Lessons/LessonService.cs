using AutoMapper;
using Backend.Core.Futures.MaterialsForStudy.Lessons.DTOs.Requests;
using Backend.Core.Futures.MaterialsForStudy.Lessons.DTOs.Responses;
using Backend.Core.Futures.MaterialsForStudy.Lessons.Responses;
using Backend.Core.Gateways;
using Backend.Domain.Entities;
using Backend.Domain.Responses.Base;
using FluentValidation;

namespace Backend.Core.Futures.MaterialsForStudy.Lessons;

public class LessonService : ILessonService
{
    private readonly ILessonGateway _lessonGateway;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateLessonDto> _createLessonValidator;

    public LessonService(ILessonGateway lessonGateway, IMapper mapper, IValidator<CreateLessonDto> createLessonValidator)
    {
        _lessonGateway = lessonGateway;
        _mapper = mapper;
        _createLessonValidator = createLessonValidator;
    }

    public async Task<Response> CreateAsync(CreateLessonDto dto)
    {
        if (await _createLessonValidator.ValidateAsync(dto) is { IsValid: false } result)
            return Response.ValidationFailed(result.Errors);

        var lesson = _mapper.Map<Lesson>(dto);
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

    public async Task<Response<ActualLessonDto>> UpdateVideoByUrlAsync(UpdateLessonVideoByUrlDto dto)
    {
        return await UpdateAsync(dto.LessonId, o =>
        {
            o.VideoUrl = dto.VideoUrl;
        });
    }

    public async Task<Response<ActualLessonDto>> UpdateHomeworkAsync(UpdateLessonHomeworkDto dto)
    {
        return await UpdateAsync(dto.LessonId, o =>
        {
            o.HomeworkDescription = dto.Description;
            o.HomeworkStatus = dto.Status;
        });
    }

    public async Task<Response<LessonForPageDto>> GetForPageAsync(int id)
    {
        var lesson = await _lessonGateway.GetByIdWithLessonsOfModuleAsync(id);
        return lesson == null
            ? Response.Failed<LessonForPageDto>()
            : Response.Success(_mapper.Map<LessonForPageDto>(lesson));
    }

    private async Task<Response<ActualLessonDto>> UpdateAsync(int id, Action<Lesson> configure)
    {
        var actual = await _lessonGateway.UpdateAsync(id, configure);
        return actual == null
            ? ActualLessonResponseHelper.InvalidId()
            : Response.Success(_mapper.Map<ActualLessonDto>(actual));
    }
}