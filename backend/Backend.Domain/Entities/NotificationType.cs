using Backend.Domain.Entities.Base;

namespace Backend.Domain.Entities;

public class NotificationType : BaseEntity
{
    public string Name { get; set; } = null!;
}