﻿using Backend.Core.Futures.Users.Students;
using Backend.Core.Futures.Users.Students.DTOs.Requests;
using Backend.Core.Futures.Users.Students.DTOs.Responses;
using Backend.Domain.Responses.Base;
using Backend.Presentation.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Presentation.Controllers;

public class StudentController : Controller
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }
    
    [HttpGet("/student/all")]
    public async Task<Response<IEnumerable<StudentInfoDto>>> GetAll()
    {
        return await _studentService.GetAllAsync();
    }

    [HttpPost("/student/join-course")]
    [Authorize(AuthorizationPolicies.Student)]
    public async Task<Response> JoinCourse([FromBody] JoinCourseDto dto)
    {
        return await _studentService.JoinCourseAsync(dto);
    }
}