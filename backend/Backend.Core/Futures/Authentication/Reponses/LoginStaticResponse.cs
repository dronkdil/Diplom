using Backend.Core.Futures.Authentication.DTOs;
using Backend.Domain.Responses.Base;

namespace Backend.Core.Futures.Authentication.Reponses;

public static class LoginStaticResponse
{
    public static Response<SuccessAuthenticationDto> Failed() => 
        Response.Failed<SuccessAuthenticationDto>("Пошта або пароль невірні");
}