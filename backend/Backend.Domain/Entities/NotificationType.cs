using Backend.Domain.Entities.Base;

namespace Backend.Domain.Entities;

public class NotificationType : BaseEntity
{
    public string Slug { get; set; } = null!;
}