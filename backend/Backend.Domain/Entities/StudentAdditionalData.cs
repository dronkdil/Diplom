using Backend.Domain.Entities.Base;
using Backend.Domain.Entities.Enums;

namespace Backend.Domain.Entities;

public class StudentAdditionalData : BaseEntity
{
    public DateTime Birthday { get; set; }
    public string EducationalStatus { get; set; } = null!;
    
    public ICollection<Course> Courses { get; set; } = null!;
    public ICollection<Certificate> Certificates { get; set; } = null!;
    public ICollection<Homework> Homeworks { get; set; } = null!;
}