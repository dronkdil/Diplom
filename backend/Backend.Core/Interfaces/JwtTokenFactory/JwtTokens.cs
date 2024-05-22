namespace Backend.Core.Interfaces.JwtTokenFactory;

public class JwtTokens
{
    public string AccessToken { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
}