namespace Backend.Core.Futures.Users.Students.DTOs.Responses;

public class StudentDataDto
{
    public int Id { get; set; }
    public string? AvatarUrl { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string DisplayName => FirstName + ' ' + LastName;
    public string Email { get; set; } = null!;
    public string Birthday { get; set; } = null!;
    public string EducationalStatus { get; set; } = null!;
}