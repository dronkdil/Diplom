namespace Backend.Domain.Options;

public class JwtTokenOptions
{
    public static string Name => "JWT";
    
    public int AccessExpiresMinutes { get; set; }
    public int RefreshExpiresDays { get; set; }
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;
    public string Key { get; set; } = null!;
}