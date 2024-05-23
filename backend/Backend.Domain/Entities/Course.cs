using Backend.Domain.Entities.Base;

namespace Backend.Domain.Entities;

public class Course : BaseEntity
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;

    public int TeacherId { get; set; }
    public TeacherAdditionalData TeacherAdditionalData { get; set; } = null!;
    public ICollection<Module> Modules { get; set; } = null!;
    public ICollection<StudentAdditionalData> Students { get; set; } = null!;
}