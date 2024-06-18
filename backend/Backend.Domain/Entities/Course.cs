using Backend.Domain.Entities.Base;

namespace Backend.Domain.Entities;

public class Course : BaseEntity
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public int LimitOfStudents { get; set; }
    public string? ChatLink { get; set; }
    public string? ScheduleLink { get; set; }

    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; } = null!;
    public ICollection<Module> Modules { get; set; } = null!;
    public ICollection<Student> Students { get; set; } = null!;
}