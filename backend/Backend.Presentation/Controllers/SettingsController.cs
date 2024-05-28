using Backend.Core.Futures.Users.Common.UpdateInformation;
using Backend.Core.Futures.Users.Common.UpdateInformation.DTOs.Requests;
using Backend.Core.Futures.Users.Common.UpdateInformation.DTOs.Responses;
using Backend.Core.Futures.Users.Students.UpdateInformation;
using Backend.Core.Futures.Users.Students.UpdateInformation.DTOs;
using Backend.Domain.Responses.Base;
using Backend.Presentation.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Presentation.Controllers;

public class SettingsController : Controller
{
    private readonly IUpdateUserDataService _updateUserDataService;
    private readonly IUpdateStudentDataService _updateStudentDataService;

    public SettingsController(IUpdateUserDataService updateUserDataService, IUpdateStudentDataService updateStudentDataService)
    {
        _updateUserDataService = updateUserDataService;
        _updateStudentDataService = updateStudentDataService;
    }

    [HttpPost("/settings/update-first-last-names")]
    [Authorize]
    public async Task<Response<ActualUserDto>> UpdateFirstLastNames([FromBody] UpdateFirstLastNamesDto dto)
    {
        return await _updateUserDataService.UpdateFirstLastNamesAsync(dto);
    }
    
    [HttpPost("/settings/update-password")]
    [Authorize]
    public async Task<Response<ActualUserDto>> UpdatePassword([FromBody] UpdatePasswordDto dto)
    {
        return await _updateUserDataService.UpdatePasswordAsync(dto);
    }
    
    [HttpPost("/settings/update-avatar-by-url")]
    [Authorize]
    public async Task<Response<ActualUserDto>> UpdateAvatarByUrl([FromBody] UpdateAvatarByUrlDto dto)
    {
        return await _updateUserDataService.UpdateAvatarByUrlAsync(dto);
    }
    
    [HttpPost("/settings/update-birthday")]
    [Authorize(AuthorizationPolicies.Student)]
    public async Task<Response> UpdateBirthday([FromBody] UpdateBirthdayDto dto)
    {
        return await _updateStudentDataService.UpdateBirthdayAsync(dto);
    }

    [HttpPost("/settings/update-educational-status")]
    [Authorize(AuthorizationPolicies.Student)]
    public async Task<Response> UpdateEducationalStatus([FromBody] UpdateEducationalStatusDto dto)
    {
        return await _updateStudentDataService.UpdateEducationalStatusAsync(dto);
    }
}