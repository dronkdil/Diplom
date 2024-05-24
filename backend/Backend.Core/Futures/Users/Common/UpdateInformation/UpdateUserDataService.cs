using Backend.Core.Futures.Users.Common.UpdateInformation.DTOs;
using Backend.Core.Gateways;
using Backend.Core.Interfaces.PasswordHasher;
using Backend.Core.UserContext;
using Backend.Domain.Responses.Base;

namespace Backend.Core.Futures.Users.Common.UpdateInformation;

public class UpdateUserDataService : IUpdateUserDataService
{
    private readonly IUserGateway _userGateway;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserContext _userContext;

    public UpdateUserDataService(IUserGateway userGateway, IPasswordHasher passwordHasher, IUserContext userContext)
    {
        _userGateway = userGateway;
        _passwordHasher = passwordHasher;
        _userContext = userContext;
    }

    public async Task<Response> UpdateFirstLastNamesAsync(UpdateFirstLastNamesDto dto)
    {
        var isUpdated = await _userGateway.UpdateAsync(_userContext.UserId, o =>
        {
            o.FirstName = dto.FirstName;
            o.LastName = dto.LastName;
        });

        return isUpdated
            ? Response.Success()
            : Response.Failed();
    }

    public async Task<Response> UpdatePasswordAsync(UpdatePasswordDto dto)
    {
        var isUpdated = await _userGateway.UpdateAsync(_userContext.UserId, o =>
        {
            o.PasswordHash = _passwordHasher.Hash(dto.Password);
        });

        return isUpdated
            ? Response.Success()
            : Response.Failed();
    }
}