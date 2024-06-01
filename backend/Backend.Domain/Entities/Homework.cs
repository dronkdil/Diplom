using Backend.Domain.Entities.Base;

namespace Backend.Domain.Entities;

public class Homework : BaseEntity
{
    public bool Сompleted { get; set; }
    public int? Appraisal { get; set; }
    public string? CommentFromTeacher { get; set; }
    public string Answer { get; set; } = null!;
    
    public int LessonId { get; set; }
    public Lesson Lesson { get; set; } = null!;
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;
}