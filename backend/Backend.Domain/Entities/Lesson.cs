using Backend.Domain.Entities.Base;
using Backend.Domain.Entities.Enums;

namespace Backend.Domain.Entities;

public class Lesson : BaseEntity
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? VideoName { get; set; }
    public string? YoutubeVideoId { get; set; }
    public LessonVideoTypes VideoType { get; set; }
    public bool HomeworkStatus { get; set; }
    public string? HomeworkDescription { get; set; } = null!;
    
    public int ModuleId { get; set; }
    public Module Module { get; set; } = null!;
    public ICollection<Homework> Homeworks { get; set; } = null!;
}