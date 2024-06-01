namespace Backend.Core.Futures.MaterialsForStudy.Homeworks.DTOs.Requests;

public class SendHomeworkDto
{
    public int? Id { get; set; }
    public string Answer { get; set; } = null!;
    public int LessonId { get; set; }
    public int StudentId { get; set; }
}