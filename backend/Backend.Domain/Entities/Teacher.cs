using Backend.Domain.Entities.Base;

namespace Backend.Domain.Entities;

public class Teacher : User
{
    public IEnumerable<Course> Courses { get; set; } = null!;
}