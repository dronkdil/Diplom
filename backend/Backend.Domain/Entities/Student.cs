using Backend.Domain.Entities.Base;
using Backend.Domain.Entities.Enums;

namespace Backend.Domain.Entities;

public class Student : User
{
    public DateTime Birthday { get; set; }
    public EducationalStatus EducationalStatus { get; set; }
    
    public ICollection<Course> Courses { get; set; } = null!;
    public ICollection<Certificate> Certificates { get; set; } = null!;
}