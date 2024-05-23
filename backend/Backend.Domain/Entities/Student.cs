namespace Backend.Domain.Entities;

public class Student : User
{
    public DateTime Birthday { get; set; }
    public string EducationalStatus { get; set; } = null!;
    
    public ICollection<Course> Courses { get; set; } = null!;
    public ICollection<Certificate> Certificates { get; set; } = null!;
    public ICollection<Homework> Homeworks { get; set; } = null!;
}