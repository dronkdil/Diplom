using Backend.Domain.Entities.Base;

namespace Backend.Domain.Entities;

public class Role : BaseEntity
{
    public string Name { get; set; } = null!;
}