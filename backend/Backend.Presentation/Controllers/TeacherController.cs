using System.Collections;
using Backend.Core.Futures.Teacher;
using Backend.Core.Futures.Teacher.DTOs;
using Backend.Domain.Responses.Base;
using Backend.Presentation.Constants;
using Backend.Presentation.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

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
    public async Task<Response<bool>> CreateTeacher(CreateTeacherDto dto)
    {
        return await _teacherService.CreateAsync(dto);
    }

    [HttpGet("/teacher/courses")]
    [Authorize(AuthorizationPolicies.Teacher)]
    public async Task<Response<IEnumerable<TeacherShortCourseDto>>> GetCourses()
    {
        return await _teacherService.GetCourses(User.GetUserId());
    }
}