using Backend.Core.Futures.Authentication.DTOs;
using Backend.Domain.Responses.Base;

namespace Backend.Core.Futures.Authentication;

public interface IAuthenticationService
{
    Task<Response<SuccessAuthenticationDto>> LoginAsync(LoginDto dto);
    Task<Response<SuccessAuthenticationDto>> RegistrationAsync(RegistrationStudentDto dto);
    Task<Response<SuccessAuthenticationDto>> RefreshAsync(string refreshToken);
}