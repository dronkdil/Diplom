using Backend.Core.Futures.Users.Common.UpdateInformation.DTOs;
using Backend.Domain.Responses.Base;

namespace Backend.Core.Futures.Users.Common.UpdateInformation;

public interface IUpdateUserDataService
{
    Task<Response> UpdateFirstLastNamesAsync(UpdateFirstLastNamesDto dto);
    Task<Response> UpdatePasswordAsync(UpdatePasswordDto dto);
}