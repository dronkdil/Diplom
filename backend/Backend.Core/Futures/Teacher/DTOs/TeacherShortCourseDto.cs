namespace Backend.Core.Futures.Teacher.DTOs;

public class TeacherShortCourseDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int StudentCount { get; set; }
}