using Backend.Domain.Entities.Base;

namespace Backend.Domain.Entities;

public class Certificate : BaseEntity
{
    public int CourseId { get; set; }
    public Course Course { get; set; } = null!;
}