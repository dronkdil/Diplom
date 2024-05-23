using Backend.Core.Futures.Teachers;
using Backend.Core.Futures.Teachers.DTOs;
using Backend.Domain.Responses.Base;
using Backend.Presentation.Constants;
using Backend.Presentation.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Presentation.Controllers;

public class TeacherController : Controller
{
    private readonly ITeacherService _teacherService;

    public TeacherController(ITeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    [HttpPost("teacher/create")]
    [Authorize(AuthorizationPolicies.Administrator)]
    public async Task<Response> CreateTeacher([FromBody] CreateTeacherDto dto)
    {
        return await _teacherService.CreateAsync(dto);
    }
    
    [HttpPost("teacher/remove")]
    [Authorize(AuthorizationPolicies.Administrator)]
    public async Task<Response> CreateTeacher([FromBody] RemoveTeacherDto dto)
    {
        return await _teacherService.RemoveAsync(dto);
    }

    [HttpGet("/teacher/courses")]
    [Authorize(AuthorizationPolicies.Teacher)]
    public async Task<Response<IEnumerable<TeacherShortCourseDto>>> GetCourses()
    {
        return await _teacherService.GetCoursesAsync(User.GetUserId());
    }
    
    [HttpGet("/teacher/all")]
    public async Task<Response<IEnumerable<TeacherInformationDto>>> GetAll()
    {
        return await _teacherService.GetAllTeachersAsync();
    }
}