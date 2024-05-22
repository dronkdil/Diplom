using Backend.Domain.Entities;
using Backend.Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.EF;

public class DataContext : DbContext
{
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Teacher> Teachers { get; set; } = null!;
    public DbSet<Notification> Notifications { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<Module> Modules { get; set; } = null!;
    public DbSet<Lesson> Lessons { get; set; } = null!;
    public DbSet<Homework> Homeworks { get; set; } = null!;
    public DbSet<Certificate> Certificates { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Notification>()
            .Property(o => o.Type)
            .HasConversion(
                o => o.ToString(), 
                o => (NotificationType)Enum.Parse(typeof(NotificationType), o));
        
        builder.Entity<Student>()
            .Property(o => o.EducationalStatus)
            .HasConversion(
                o => o.ToString(), 
                o => (EducationalStatus)Enum.Parse(typeof(EducationalStatus), o));
    }
}