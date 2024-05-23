using Backend.Core.Futures.Authentication.DTOs;
using Backend.Domain.Responses.Base;

namespace Backend.Core.Futures.Authentication;

public interface IAuthenticationService
{
    Task<Response<SuccessAuthenticationDto>> Login(LoginDto dto);
    Task<Response<SuccessAuthenticationDto>> Registration(RegistrationStudentDto dto);
    Task<Response<SuccessAuthenticationDto>> Refresh(string refreshToken);
}