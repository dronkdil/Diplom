using AutoMapper;
using Backend.Core.Futures.Users.Common.UpdateInformation.DTOs.Requests;
using Backend.Core.Futures.Users.Common.UpdateInformation.DTOs.Responses;
using Backend.Core.Gateways;
using Backend.Core.Interfaces.PasswordHasher;
using Backend.Core.UserContext;
using Backend.Domain.Responses.Base;
using FluentValidation;

namespace Backend.Core.Futures.Users.Common.UpdateInformation;

public class UpdateUserDataService : IUpdateUserDataService
{
    private readonly IUserGateway _userGateway;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserContext _userContext;
    private readonly IMapper _mapper;
    private readonly IValidator<UpdateAvatarByUrlDto> _avatarByUrlValidator;

    public UpdateUserDataService(IUserGateway userGateway, IPasswordHasher passwordHasher, IUserContext userContext, IMapper mapper, IValidator<UpdateAvatarByUrlDto> avatarByUrlValidator)
    {
        _userGateway = userGateway;
        _passwordHasher = passwordHasher;
        _userContext = userContext;
        _mapper = mapper;
        _avatarByUrlValidator = avatarByUrlValidator;
    }

    public async Task<Response<ActualUserDto>> UpdateFirstLastNamesAsync(UpdateFirstLastNamesDto dto)
    {
        var updatedUser = await _userGateway.UpdateAsync(_userContext.UserId, o =>
        {
            o.FirstName = dto.FirstName;
            o.LastName = dto.LastName;
        });

        return updatedUser == null
            ? Response.Failed<ActualUserDto>()
            : Response.Success(_mapper.Map<ActualUserDto>(updatedUser));
    }

    public async Task<Response<ActualUserDto>> UpdatePasswordAsync(UpdatePasswordDto dto)
    {
        var updatedUser = await _userGateway.UpdateAsync(_userContext.UserId, o =>
        {
            o.PasswordHash = _passwordHasher.Hash(dto.Password);
        });

        return updatedUser == null
            ? Response.Failed<ActualUserDto>()
            : Response.Success(_mapper.Map<ActualUserDto>(updatedUser));
    }

    public async Task<Response<ActualUserDto>> UpdateAvatarByUrlAsync(UpdateAvatarByUrlDto dto)
    {
        if (await _avatarByUrlValidator.ValidateAsync(dto) is { IsValid: false } result)
            return Response.ValidationFailed<ActualUserDto>(result.Errors);

        var updatedUser = await _userGateway.UpdateAsync(_userContext.UserId, o =>
        {
            o.AvatarUrl = dto.AvatarUrl;
        });

        return updatedUser == null
            ? Response.Failed<ActualUserDto>()
            : Response.Success(_mapper.Map<ActualUserDto>(updatedUser));
    }
}