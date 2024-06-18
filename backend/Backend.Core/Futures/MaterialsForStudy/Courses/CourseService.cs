using AutoMapper;
using Backend.Core.Futures.MaterialsForStudy.Courses.DTOs.Requests;
using Backend.Core.Futures.MaterialsForStudy.Courses.DTOs.Responses;
using Backend.Core.Futures.Users.Teachers.DTOs;
using Backend.Core.Gateways;
using Backend.Core.UserContext;
using Backend.Domain.Entities;
using Backend.Domain.Responses.Base;
using FluentValidation;

namespace Backend.Core.Futures.MaterialsForStudy.Courses;

public class CourseService : ICourseService
{
    private readonly ICourseGateway _courseGateway;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateCourseDto> _createCourseValidator;
    private readonly IValidator<UpdateCourseImageByUrlDto> _updateImageByUrlValidator;
    private readonly IUserContext _userContext;

    public CourseService(ICourseGateway courseGateway, IMapper mapper, IValidator<CreateCourseDto> createCourseValidator, IValidator<UpdateCourseImageByUrlDto> updateImageByUrlValidator, IUserContext userContext)
    {
        _courseGateway = courseGateway;
        _mapper = mapper;
        _createCourseValidator = createCourseValidator;
        _updateImageByUrlValidator = updateImageByUrlValidator;
        _userContext = userContext;
    }

    public async Task<Response> CreateAsync(CreateCourseDto dto)
    {
        if (await _createCourseValidator.ValidateAsync(dto) is { IsValid: false } validationResult)
            return Response.ValidationFailed(validationResult.Errors);
        
        var course = _mapper.Map<Course>(dto);
        var isAdded = await _courseGateway.AddAsync(course);
        return Response.Result(isAdded);
    }

    public async Task<Response> RemoveAsync(RemoveCourseDto dto)
    {
        var isRemoved = await _courseGateway.RemoveAsync(dto.Id);
        return Response.Result(isRemoved);
    }

    public async Task<Response<IEnumerable<ShortCourseDto>>> GetAllCourses()
    {
        var courses = await _courseGateway.GetAllAsync();
        return Response.Success(_mapper.Map<IEnumerable<ShortCourseDto>>(courses));
    }

    public async Task<Response<ActualCourseDto>> UpdateTitleAsync(UpdateCourseTitleDto dto)
    {
        var actual = await _courseGateway.UpdateAsync(dto.Id, o =>
        {
            o.Title = dto.Title;
        });
        return Response.Success(_mapper.Map<ActualCourseDto>(actual));
    }

    public async Task<Response<ActualCourseDto>> UpdateDescriptionAsync(UpdateCourseDescriptionDto dto)
    {
        var actual = await _courseGateway.UpdateAsync(dto.Id, o =>
        {
            o.Description = dto.Description;
        });
        return Response.Success(_mapper.Map<ActualCourseDto>(actual));
    }

    public async Task<Response<ActualCourseDto>> UpdateImageByUrlAsync(UpdateCourseImageByUrlDto dto)
    {
        if (await _updateImageByUrlValidator.ValidateAsync(dto) is { IsValid: false } result)
            return Response.ValidationFailed<ActualCourseDto>(result.Errors);
        
        var actual = await _courseGateway.UpdateAsync(dto.Id, o =>
        {
            o.ImageUrl = dto.ImageUrl;
        });
        return Response.Success(_mapper.Map<ActualCourseDto>(actual));
    }

    public async Task<Response<ActualCourseDto>> UpdateChatLinkAsync(UpdateCourseChatLinkDto dto)
    {
        var actual = await _courseGateway.UpdateAsync(dto.Id, o =>
        {
            o.ChatLink = dto.ChatLink;
        });
        return Response.Success(_mapper.Map<ActualCourseDto>(actual));
    }

    public async Task<Response<ActualCourseDto>> UpdateScheduleLinkAsync(UpdateCourseScheduleLinkDto dto)
    {
        var actual = await _courseGateway.UpdateAsync(dto.Id, o =>
        {
            o.ScheduleLink = dto.ScheduleLink;
        });
        return Response.Success(_mapper.Map<ActualCourseDto>(actual));
    }

    public async Task<Response<CoursePageDto>> GetCoursePageDataAsync(int courseId)
    {
        var course = await _courseGateway.GetByIdWithTeacherAndModulesAsync(courseId);
        if (course == null)
            Response.Failed();
        
        return Response.Success(_mapper.Map<CoursePageDto>(course));
    }

    public async Task<Response<double>> GetAverageScoreAsync(int courseId)
    {
        var score = await _courseGateway.GetAverageScoreAsync(courseId, _userContext.UserId);
        return Response.Success(score ?? 0);
    }
}