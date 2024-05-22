namespace Backend.Domain.DTOs;

public class RegistrationStudentDto
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string EducationalStatus { get; set; } = null!;
    public DateTime Birthday { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}