using Backend.Core.Futures.Authentication;
using Backend.Core.Futures.Authentication.DTOs;
using Backend.Domain.Options;
using Backend.Domain.Responses.Base;
using Backend.Presentation.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Backend.Presentation.Controllers;

public class AuthenticationController : Controller
{
    private readonly IAuthenticationService _authenticationService;
    private readonly JwtTokenOptions _jwtTokenOptions;

    public AuthenticationController(IAuthenticationService authenticationService, IOptions<JwtTokenOptions> jwtTokenOptions)
    {
        _authenticationService = authenticationService;
        _jwtTokenOptions = jwtTokenOptions.Value;
    }
    
    [HttpPost("student/registration")]
    public async Task<Response<SuccessAuthenticationDto>> Registration([FromBody] RegistrationStudentDto dto)
    {
        var response = await _authenticationService.RegistrationAsync(dto);
        
        if (response.Type == ResponseType.Successfully)
            AddRefreshTokenToCookie(response.Value!);
        
        return response;
    }

    [HttpPost("login")]
    public async Task<Response<SuccessAuthenticationDto>> Login([FromBody] LoginDto dto)
    {
         var response = await _authenticationService.LoginAsync(dto);
         
         if (response.Type == ResponseType.Successfully)
             AddRefreshTokenToCookie(response.Value!);
         
         return response;
    }
    
    [HttpPost("refresh")]
    public async Task<Response<SuccessAuthenticationDto>> Refresh()
    {
        if (Request.Cookies[CookieKeys.RefreshToken] == null)
            return Backend.Domain.Responses.Base.Response.Failed<SuccessAuthenticationDto>("Помилка авторизації: refresh token не знайдено");

        var response = await _authenticationService.RefreshAsync(Request.Cookies[CookieKeys.RefreshToken]!);
        if (response.Type == ResponseType.Successfully)
            AddRefreshTokenToCookie(response.Value!);
        
        return response;
    }

    [HttpPost("/logout")]
    public void Logout()
    {
        Response.Cookies.Delete(CookieKeys.RefreshToken);
    }
    
    private void AddRefreshTokenToCookie(SuccessAuthenticationDto dto)
    {
        Response.Cookies.Append(CookieKeys.RefreshToken, dto.RefreshToken, new CookieOptions
        {
            Expires = DateTime.Now.AddDays(_jwtTokenOptions.RefreshExpiresDays),
            HttpOnly = true,
            Path = "/",
            SameSite = SameSiteMode.None,
            Secure = true
        });
    }
}