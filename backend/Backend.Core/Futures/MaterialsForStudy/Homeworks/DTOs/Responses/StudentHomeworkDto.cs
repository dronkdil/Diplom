namespace Backend.Core.Futures.MaterialsForStudy.Homeworks.DTOs.Responses;

public class StudentHomeworkDto
{
    public int Id { get; set; }
    public string Answer { get; set; } = null!;
    public int? Appraisal { get; set; }
    public string? CommentFromTeacher { get; set; }
    public bool Сompleted { get; set; }
}