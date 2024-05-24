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

    public CourseService(ICourseGateway courseGateway, IMapper mapper, IValidator<CreateCourseDto> createCourseValidator)
    {
        _courseGateway = courseGateway;
        _mapper = mapper;
        _createCourseValidator = createCourseValidator;
    }

    public async Task<Response> CreateAsync(CreateCourseDto dto)
    {
        if (await _createCourseValidator.ValidateAsync(dto) is { IsValid: false } validationResult)
            return Response.ValidationFailed(validationResult.Errors);
        
        var course = _mapper.Map(dto, new Course
        {
            ImageUrl = ""
        });
        var isAdded = await _courseGateway.AddAsync(course);
        return Response.Result(isAdded);
    }

    public async Task<Response> RemoveAsync(RemoveCourseDto dto)
    {
        var isRemoved = await _courseGateway.RemoveAsync(dto.Id);
        return Response.Result(isRemoved);
    }

    public async Task<Response<IEnumerable<CourseDto>>> GetAllCourses()
    {
        var courses = await _courseGateway.GetAllAsync();
        return Response.Success(_mapper.Map<IEnumerable<CourseDto>>(courses));
    }

    public async Task<Response> UpdateTitleAsync(UpdateTitleDto dto)
    {
        var isUpdated = await _courseGateway.UpdateAsync(dto.Id, o =>
        {
            o.Title = dto.Title;
        });

        return Response.Result(isUpdated);
    }

    public async Task<Response> UpdateDescriptionAsync(UpdateDescriptionDto dto)
    {
        var isUpdated = await _courseGateway.UpdateAsync(dto.Id, o =>
        {
            o.Description = dto.Description;
        });

        return Response.Result(isUpdated);
    }
}