using Backend.Core.Futures.Users.Teachers.DTOs;
using Backend.Domain.Entities;
using Backend.Domain.Entities.Enums;
using Backend.Infrastructure.Implementations.PasswordHasher;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.EF;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Teacher> Teachers { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;
    public DbSet<Notification> Notifications { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<Module> Modules { get; set; } = null!;
    public DbSet<Lesson> Lessons { get; set; } = null!;
    public DbSet<Homework> Homeworks { get; set; } = null!;
    public DbSet<HomeworkFile> HomeworkFiles { get; set; } = null!;
    public DbSet<Certificate> Certificates { get; set; } = null!;

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Notification>()
            .Property(o => o.Type)
            .HasConversion(
                o => o.ToString(),
                o => (NotificationType)Enum.Parse(typeof(NotificationType), o));

        builder.Entity<Role>()
            .HasData(Enum.GetValues(typeof(Roles)).Cast<Roles>().Select(o => new Role
            {
                Id = (int)o,
                Name = o.ToString()
            }));

        builder.Entity<User>()
            .HasData(new User
            {
                Id = 1,
                FirstName = "Admin",
                Email = "admin@admin",
                PasswordHash = new PasswordHasher().Hash("admin"),
                RoleId = (int)Domain.Entities.Enums.Roles.Administrator
            });
        
        base.OnModelCreating(builder);
    }
}