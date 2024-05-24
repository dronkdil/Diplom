using Backend.Core.Futures.MaterialsForStudy.Courses.DTOs.Requests;
using Backend.Core.Futures.MaterialsForStudy.Modules;
using Backend.Core.Futures.MaterialsForStudy.Modules.DTOs.Requests;
using Backend.Core.Futures.MaterialsForStudy.Modules.DTOs.Responses;
using Backend.Domain.Responses.Base;
using Backend.Presentation.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Presentation.Controllers;

public class ModuleController : Controller
{
    private readonly IModuleService _moduleService;

    public ModuleController(IModuleService moduleService)
    {
        _moduleService = moduleService;
    }

    [HttpPost("module/create")]
    [Authorize(AuthorizationPolicies.Teacher)]
    public async Task<Response> CreateModule([FromBody] CreateModuleDto dto)
    {
        return await _moduleService.CreateAsync(dto);
    }
    
    [HttpPost("module/remove")]
    [Authorize(AuthorizationPolicies.Teacher)]
    public async Task<Response> RemoveModule([FromBody] RemoveModuleDto dto)
    {
        return await _moduleService.RemoveAsync(dto);
    }
    
    [HttpPost("module/update-title")]
    [Authorize(AuthorizationPolicies.Teacher)]
    public async Task<Response> UpdateTitle([FromBody] UpdateModuleTitleDto dto)
    {
        return await _moduleService.UpdateTitleAsync(dto);
    }
    
    [HttpPost("module/update-description")]
    [Authorize(AuthorizationPolicies.Teacher)]
    public async Task<Response> UpdateDescription([FromBody] UpdateModuleDescriptionDto dto)
    {
        return await _moduleService.UpdateDescriptionAsync(dto);
    }
}