namespace Backend.Core.Futures.MaterialsForStudy.Courses.DTOs.Responses;

public class TeacherDto
{
    public int Id { get; set; }
    public string ImageUrl { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
}