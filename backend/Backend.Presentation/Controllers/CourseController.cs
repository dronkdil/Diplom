using Backend.Core.Futures.MaterialsForStudy.Courses;
using Backend.Core.Futures.MaterialsForStudy.Courses.DTOs.Requests;
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
}