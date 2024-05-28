using Backend.Core.Futures.Users.Common.UpdateInformation.DTOs.Requests;
using Backend.Core.Futures.Users.Common.UpdateInformation.DTOs.Responses;
using Backend.Domain.Responses.Base;

namespace Backend.Core.Futures.Users.Common.UpdateInformation;

public interface IUpdateUserDataService
{
    Task<Response<ActualUserDto>> UpdateFirstLastNamesAsync(UpdateFirstLastNamesDto dto);
    Task<Response<ActualUserDto>> UpdatePasswordAsync(UpdatePasswordDto dto);
    Task<Response<ActualUserDto>> UpdateAvatarByUrlAsync(UpdateAvatarByUrlDto dto);
}