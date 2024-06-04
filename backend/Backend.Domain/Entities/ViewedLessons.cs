using Backend.Domain.Entities.Base;

namespace Backend.Domain.Entities;

public class ViewedLessons : BaseEntity
{
    public int LessonId { get; set; }
    public Lesson Lesson { get; set; } = null!;
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;
}