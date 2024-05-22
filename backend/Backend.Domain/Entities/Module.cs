using Backend.Domain.Entities.Base;

namespace Backend.Domain.Entities;

public class Module : BaseEntity
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;

    public int CourseId { get; set; }
    public Course Course { get; set; } = null!;
    public IEnumerable<Lesson> Lessons { get; set; } = null!;
}