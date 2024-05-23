using Backend.Domain.Entities.Base;

namespace Backend.Domain.Entities;

public class TeacherAdditionalData : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public IEnumerable<Course> Courses { get; set; } = null!;
}