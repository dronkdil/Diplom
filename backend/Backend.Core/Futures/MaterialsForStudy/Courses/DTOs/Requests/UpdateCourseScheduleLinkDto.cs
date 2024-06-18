namespace Backend.Core.Futures.MaterialsForStudy.Courses.DTOs.Requests;

public class UpdateCourseScheduleLinkDto
{
    public int Id { get; set; }
    public string ScheduleLink { get; set; } = null!;
}