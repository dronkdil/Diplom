using Backend.Core.Futures.Users.Students.UpdateInformation.DTOs;
using Backend.Domain.Responses.Base;

namespace Backend.Core.Futures.Users.Students.UpdateInformation;

public interface IUpdateStudentDataService
{
    Task<Response> UpdateBirthdayAsync(UpdateBirthdayDto dto);
    Task<Response> UpdateEducationalStatusAsync(UpdateEducationalStatusDto dto);
}