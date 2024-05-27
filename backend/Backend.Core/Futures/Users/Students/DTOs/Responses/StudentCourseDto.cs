namespace Backend.Core.Futures.Users.Students.DTOs.Responses;

public class StudentCourseDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Level { get; set; } = null!;
    public int Progress { get; set; }
}