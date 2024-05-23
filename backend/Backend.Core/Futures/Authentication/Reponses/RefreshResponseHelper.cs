using Backend.Core.Futures.Authentication.DTOs;
using Backend.Domain.Responses.Base;

namespace Backend.Core.Futures.Authentication.Reponses;

public static class RefreshResponseHelper
{
    public static Response<SuccessAuthenticationDto> Failed() =>
        Response.Failed<SuccessAuthenticationDto>("Токен некоректний");
}