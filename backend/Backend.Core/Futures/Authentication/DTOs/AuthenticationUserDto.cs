namespace Backend.Core.Futures.Authentication.DTOs;

public class AuthenticationUserDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string? LastName { get; set; }
    public string Email { get; set; } = null!;
    public string Role { get; set; } = null!;
    public string DisplayName => FirstName + ' ' + LastName;
}