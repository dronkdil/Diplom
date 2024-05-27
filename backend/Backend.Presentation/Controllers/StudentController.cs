using System.Collections;
using Backend.Core.Futures.Users.Students;
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
    public async Task<Response<IEnumerable<StudentDataDto>>> GetAll()
    {
        return await _studentService.GetAllAsync();
    }

    [HttpPost("/student/join-course")]
    [Authorize(AuthorizationPolicies.Student)]
    public async Task<Response> JoinCourse([FromBody] JoinCourseDto dto)
    {
        return await _studentService.JoinCourseAsync(dto);
    }
    
    [HttpPost("/student/leave-course")]
    [Authorize(AuthorizationPolicies.Student)]
    public async Task<Response> LeaveCourse([FromBody] LeaveCourseDto dto)
    {
        return await _studentService.LeaveCourseAsync(dto);
    }
    
    [HttpGet("/student/get-my-data")]
    [Authorize(AuthorizationPolicies.Student)]
    public async Task<Response<StudentDataDto>> GetMyData()
    {
        return await _studentService.GetMyDataAsync();
    }
    
    [HttpGet("/student/courses")]
    [Authorize(AuthorizationPolicies.Student)]
    public async Task<Response<IEnumerable<StudentCourseDto>>> GetStudentCourses()
    {
        return await _studentService.GetCoursesAsync();
    }
    
    [HttpGet("/student/already-joined-course")]
    [Authorize(AuthorizationPolicies.Student)]
    public async Task<Response<bool>> AlreadyJoinedCourse(int courseId)
    {
        return await _studentService.AlreadyJoinedCourseAsync(courseId);
    }
}
