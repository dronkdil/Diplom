namespace Backend.Core.Futures.Authentication.DTOs;

public class SuccessAuthenticationDto
{
    public string AccessToken { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
    public AuthenticationUserDto User { get; set; } = null!;
}