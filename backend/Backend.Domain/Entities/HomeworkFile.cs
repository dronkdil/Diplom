using Backend.Domain.Entities.Base;

namespace Backend.Domain.Entities;

public class HomeworkFile : BaseEntity
{
    public string FileUrl { get; set; } = null!;

    public int HomeworkId { get; set; }
    public Homework Homework { get; set; } = null!;
}