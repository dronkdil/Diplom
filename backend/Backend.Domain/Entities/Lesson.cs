using Backend.Domain.Entities.Base;

namespace Backend.Domain.Entities;

public class Lesson : BaseEntity
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string VideoUrl { get; set; } = null!;
    public bool HomeworkStatus { get; set; }
    public string? HomeworkDescription { get; set; } = null!;
    
    public int ModuleId { get; set; }
    public Module Module { get; set; } = null!;
    public ICollection<Homework> Homeworks { get; set; } = null!;
}