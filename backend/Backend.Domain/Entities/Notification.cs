using Backend.Domain.Entities.Base;
using Backend.Domain.Entities.Enums;

namespace Backend.Domain.Entities;

public class Notification : BaseEntity
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    
    public int UserId { get; set; }
    public User User { get; set; } = null!;
}