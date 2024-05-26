namespace Backend.Core.Futures.Users.Students.DTOs.Responses;

public class StudentInfoDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime Birthday { get; set; }
    public string EducationStatus { get; set; } = null!;
}