namespace Backend.Core.Futures.MaterialsForStudy.Courses.DTOs.Requests;

public class UpdateCourseImageByUrlDto
{
    public int Id { get; set; }
    public string ImageUrl { get; set; } = null!;
}