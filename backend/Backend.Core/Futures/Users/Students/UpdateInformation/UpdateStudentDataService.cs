using Backend.Core.Futures.Users.Students.UpdateInformation.DTOs;
using Backend.Core.Gateways;
using Backend.Core.UserContext;
using Backend.Domain.Responses.Base;

namespace Backend.Core.Futures.Users.Students.UpdateInformation;

public class UpdateStudentDataService : IUpdateStudentDataService
{
    private readonly IStudentGateway _studentGateway;
    private readonly IUserContext _userContext;

    public UpdateStudentDataService(IStudentGateway studentGateway, IUserContext userContext)
    {
        _studentGateway = studentGateway;
        _userContext = userContext;
    }

    public async Task<Response> UpdateBirthdayAsync(UpdateBirthdayDto dto)
    {
        var isUpdated = await _studentGateway.UpdateAsync(_userContext.UserId, o =>
        {
            o.Birthday = dto.Birthday;
        });

        return isUpdated
            ? Response.Success()
            : Response.Failed();
    }

    public async Task<Response> UpdateEducationalStatusAsync(UpdateEducationalStatusDto dto)
    {
        var isUpdated = await _studentGateway.UpdateAsync(_userContext.UserId, o =>
        {
            o.EducationalStatus = dto.EducationalStatus;
        });

        return isUpdated
            ? Response.Success()
            : Response.Failed();
    }
}