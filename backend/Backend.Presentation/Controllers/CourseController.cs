using Backend.Core.Futures.MaterialsForStudy.Courses;
using Backend.Core.Futures.MaterialsForStudy.Courses.DTOs.Requests;
using Backend.Domain.Entities.Enums;
using Backend.Domain.Responses.Base;
using Backend.Presentation.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Presentation.Controllers;

public class CourseController : Controller
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpPost("/course/create")]
    [Authorize(AuthorizationPolicies.Administrator)]
    public async Task<Response> CreateCourse([FromBody] CreateCourseDto dto)
    {
        return await _courseService.CreateAsync(dto);
    }
    
    [HttpPost("/course/remove")]
    [Authorize(AuthorizationPolicies.Administrator)]
    public async Task<Response> RemoveCourse([FromBody] RemoveCourseDto dto)
    {
        return await _courseService.RemoveAsync(dto);
    }
    
    [HttpPost("/course/all")]
    public async Task<Response> GetAllCourses()
    {
        return await _courseService.GetAllCourses();
    }
    
    [HttpPost("/course/update-title")]
    [Authorize(AuthorizationPolicies.TeacherAndHigher)]
    public async Task<Response> UpdateTitle([FromBody] UpdateTitleDto dto)
    {
        return await _courseService.UpdateTitleAsync(dto);
    }
    
    [HttpPost("/course/update-description")]
    [Authorize(AuthorizationPolicies.TeacherAndHigher)]
    public async Task<Response> GetAllCourses([FromBody] UpdateDescriptionDto dto)
    {
        return await _courseService.UpdateDescriptionAsync(dto);
    }
}