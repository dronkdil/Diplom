﻿using AutoMapper;
using Backend.Core.Futures.MaterialsForStudy.Courses.DTOs.Requests;
using Backend.Core.Futures.MaterialsForStudy.Courses.DTOs.Responses;
using Backend.Core.Futures.Teachers.DTOs;
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
        return isAdded
            ? Response.Success()
            : Response.Failed();
    }

    public async Task<Response> RemoveAsync(RemoveCourseDto dto)
    {
        var isRemoved = await _courseGateway.RemoveAsync(dto.Id);
        return isRemoved
            ? Response.Success()
            : Response.Failed();
    }

    public async Task<Response<IEnumerable<CourseDto>>> GetAllCourses()
    {
        var courses = await _courseGateway.GetAllAsync();
        return Response.Success(_mapper.Map<IEnumerable<CourseDto>>(courses));
    }
}