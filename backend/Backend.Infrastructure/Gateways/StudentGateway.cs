using Backend.Core.Gateways;
using Backend.Domain.Entities;
using Backend.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Gateways;

public class StudentGateway : IStudentGateway
{
    private readonly DataContext _dataContext;

    public StudentGateway(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Student> AddAsync(Student user)
    {
        _dataContext.Students.Add(user);
        await _dataContext.SaveChangesAsync();
        return user;
    }

    public async Task<bool> UpdateAsync(int id, Action<Student> configure)
    {
        try
        {
            var student = await _dataContext.Students.FirstOrDefaultAsync(o => o.Id == id);
            if (student == null)
                return false;

            configure(student);
            await _dataContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<IEnumerable<Student>> GetAllAsync()
    {
        return await _dataContext.Students.ToListAsync();
    }

    public async Task<bool> JoinCourse(int studentId, int courseId)
    {
        var student = await _dataContext.Students
            .Include(o => o.Courses)
            .FirstOrDefaultAsync(o => o.Id == studentId);
        var course = await _dataContext.Courses
            .FirstOrDefaultAsync(o => o.Id == courseId);
        
        if (student == null || course == null)
            return false;
        
        student.Courses.Add(course);
        await _dataContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> LeaveCourse(int studentId, int courseId)
    {
        var student = await _dataContext.Students
            .Include(o => o.Courses)
            .FirstOrDefaultAsync(o => o.Id == studentId);
        var course = await _dataContext.Courses
            .FirstOrDefaultAsync(o => o.Id == courseId);
        
        if (student == null || course == null)
            return false;
        
        student.Courses.Remove(course);
        await _dataContext.SaveChangesAsync();
        return true; 
    }

    public async Task<Student?> GetByIdAsync(int studentId)
    {
        return await _dataContext.Students.FirstOrDefaultAsync(o => o.Id == studentId);
    }

    public async Task<IEnumerable<Student>> GetByCourseIdAsync(int courseId)
    {
        var course = await _dataContext.Courses
            .Include(o => o.Students)
            .FirstAsync(o => o.Id == courseId);
        return course.Students;
    }
}