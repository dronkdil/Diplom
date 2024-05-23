using Backend.Domain.Entities.Base;

namespace Backend.Domain.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; } = null!;
    public string? LastName { get; set; }
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;

    public int RoleId { get; set; }
    public Role Role { get; set; } = null!;
    public int? StudentAdditionalDataId { get; set; }
    public StudentAdditionalData StudentAdditionalData { get; set; } = null!;
    public int? TeacherAdditionalDataId { get; set; }
    public TeacherAdditionalData TeacherAdditionalData { get; set; } = null!;
    public ICollection<Notification> Notifications { get; set; } = null!;
}