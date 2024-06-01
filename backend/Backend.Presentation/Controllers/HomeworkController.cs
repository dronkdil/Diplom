using Backend.Core.Futures.MaterialsForStudy.Homeworks;
using Backend.Core.Futures.MaterialsForStudy.Homeworks.DTOs.Requests;
using Backend.Core.Futures.MaterialsForStudy.Homeworks.DTOs.Responses;
using Backend.Domain.Responses.Base;
using Backend.Presentation.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Presentation.Controllers;

public class HomeworkController : Controller
{
    private readonly IHomeworkService _homeworkService;

    public HomeworkController(IHomeworkService homeworkService)
    {
        _homeworkService = homeworkService;
    }

    [HttpPost("homework/send")]
    [Authorize(AuthorizationPolicies.Student)]
    public async Task<Response> Send([FromBody] SendHomeworkDto dto)
    {
        return await _homeworkService.SendAsync(dto);
    }
    
    [HttpPost("homework/cancel")]
    [Authorize(AuthorizationPolicies.Student)]
    public async Task<Response> Cancel([FromBody] CancelHomeworkDto dto)
    {
        return await _homeworkService.CancelSendingAsync(dto);
    }
    
    [HttpGet("homework/get-by-student")]
    [Authorize(AuthorizationPolicies.Student)]
    public async Task<Response<StudentHomeworkDto>> GetByStudent(int id)
    {
        return await _homeworkService.GetByStudentAsync(id);
    }
    
    [HttpPost("homework/evaluate")]
    [Authorize(AuthorizationPolicies.Teacher)]
    public async Task<Response> Evaluate([FromBody] EvaluateHomeworkDto dto)
    {
        return await _homeworkService.EvaluateAsync(dto);
    }
    
    [HttpGet("homework/get-by-lesson")]
    [Authorize(AuthorizationPolicies.Teacher)]
    public async Task<Response> GetByLesson(int id)
    {
        return await _homeworkService.GetByLessonAsync(id);
    }
}