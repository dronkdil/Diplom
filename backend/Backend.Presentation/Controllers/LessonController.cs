﻿using Backend.Core.Futures.MaterialsForStudy.Courses.DTOs.Requests;
using Backend.Core.Futures.MaterialsForStudy.Lessons;
using Backend.Core.Futures.MaterialsForStudy.Lessons.DTOs.Requests;
using Backend.Core.Futures.MaterialsForStudy.Lessons.DTOs.Responses;
using Backend.Domain.Responses.Base;
using Backend.Presentation.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Presentation.Controllers;

public class LessonController : Controller
{
    private readonly ILessonService _lessonService;

    public LessonController(ILessonService lessonService)
    {
        _lessonService = lessonService;
    }

    [HttpPost("lesson/create")]
    [Authorize(AuthorizationPolicies.Teacher)]
    public async Task<Response> Create([FromBody] CreateLessonDto dto)
    {
        return await _lessonService.CreateAsync(dto);
    }
    
    [HttpPost("lesson/remove")]
    [Authorize(AuthorizationPolicies.Teacher)]
    public async Task<Response> Remove([FromBody] RemoveLessonDto dto)
    {
        return await _lessonService.RemoveAsync(dto);
    }
    
    [HttpPost("lesson/get-for-page")]
    public async Task<Response<LessonForPageDto>> GetForPage(int id)
    {
        return await _lessonService.GetForPageAsync(id);
    }
    
    [HttpPost("lesson/update-title")]
    [Authorize(AuthorizationPolicies.Teacher)]
    public async Task<Response<ActualLessonDto>> UpdateTitle([FromBody] UpdateLessonTitleDto dto)
    {
        return await _lessonService.UpdateTitleAsync(dto);
    }
    
    [HttpPost("lesson/update-description")]
    [Authorize(AuthorizationPolicies.Teacher)]
    public async Task<Response<ActualLessonDto>> UpdateDescription([FromBody] UpdateLessonDescriptionDto dto)
    {
        return await _lessonService.UpdateDescriptionAsync(dto);
    }
    
    [HttpPost("lesson/update-video-by-id")]
    [Authorize(AuthorizationPolicies.Teacher)]
    public async Task<Response<ActualLessonDto>> UpdateVideoByUrl([FromBody] UpdateLessonVideoByUrlDto dto)
    {
        return await _lessonService.UpdateVideoByUrlAsync(dto);
    }
    
    [HttpPost("lesson/update-homework")]
    [Authorize(AuthorizationPolicies.Teacher)]
    public async Task<Response<ActualLessonDto>> UpdateHomework([FromBody] UpdateLessonHomeworkDto dto)
    {
        return await _lessonService.UpdateHomeworkAsync(dto);
    }
}