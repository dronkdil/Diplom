namespace Backend.Domain.DTOs;

public class AuthenticationUserDto
{
    public string FirstName { get; set; } = null!;
    public string? LastName { get; set; }
    public string Email { get; set; } = null!;
    public string Role { get; set; } = null!;
}