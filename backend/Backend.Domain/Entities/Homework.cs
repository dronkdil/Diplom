using Backend.Domain.Entities.Base;

namespace Backend.Domain.Entities;

public class Homework : BaseEntity
{
    public bool Delivered { get; set; }
    public int? Evaluation { get; set; }
    public string? CommentFromTeacher { get; set; } = null!;
    
    public int LessonId { get; set; }
    public Lesson Lesson { get; set; } = null!;
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;
    public ICollection<HomeworkFile> HomeworkFiles { get; set; } = null!;
}