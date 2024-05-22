using Backend.Domain.Entities.Base;

namespace Backend.Domain.Entities;

public class TeacherAdditionalData : BaseEntity
{
    public IEnumerable<Course> Courses { get; set; } = null!;
}