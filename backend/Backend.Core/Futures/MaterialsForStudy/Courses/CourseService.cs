using AutoMapper;
using Backend.Core.Futures.MaterialsForStudy.Courses.DTOs.Requests;
using Backend.Core.Futures.MaterialsForStudy.Courses.DTOs.Responses;
using Backend.Core.Futures.Users.Teachers.DTOs;
using Backend.Core.Gateways;
using Backend.Domain.Entities;
using Backend.Domain.Responses.Base;
using FluentValidation;

namespace Backend.Core.Futures.MaterialsForStudy.Courses;

public class CourseService : ICourseService
{
    private readonly ICourseGateway _courseGateway;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateCourseDto> _createCourseValidator;
    private readonly IValidator<UpdateImageByUrlDto> _updateImageByUrlValidator;

    public CourseService(ICourseGateway courseGateway, IMapper mapper, IValidator<CreateCourseDto> createCourseValidator, IValidator<UpdateImageByUrlDto> updateImageByUrlValidator)
    {
        _courseGateway = courseGateway;
        _mapper = mapper;
        _createCourseValidator = createCourseValidator;
        _updateImageByUrlValidator = updateImageByUrlValidator;
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

    public async Task<Response<ActualCourseDto>> UpdateTitleAsync(UpdateTitleDto dto)
    {
        var actual = await _courseGateway.UpdateAsync(dto.Id, o =>
        {
            o.Title = dto.Title;
        });
        return Response.Success(_mapper.Map<ActualCourseDto>(actual));
    }

    public async Task<Response<ActualCourseDto>> UpdateDescriptionAsync(UpdateDescriptionDto dto)
    {
        var actual = await _courseGateway.UpdateAsync(dto.Id, o =>
        {
            o.Description = dto.Description;
        });
        return Response.Success(_mapper.Map<ActualCourseDto>(actual));
    }

    public async Task<Response<ActualCourseDto>> UpdateImageByUrlAsync(UpdateImageByUrlDto dto)
    {
        if (await _updateImageByUrlValidator.ValidateAsync(dto) is { IsValid: false } result)
            return Response.ValidationFailed<ActualCourseDto>(result.Errors);
        
        var actual = await _courseGateway.UpdateAsync(dto.Id, o =>
        {
            o.ImageUrl = dto.ImageUrl;
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
}