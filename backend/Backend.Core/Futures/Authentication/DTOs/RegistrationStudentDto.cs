namespace Backend.Core.Futures.Authentication.DTOs;

public class RegistrationStudentDto
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string EducationalStatus { get; set; } = null!;
    public string Birthday { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}