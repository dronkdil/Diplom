using Backend.Core.Gateways;
using Backend.Domain.Entities;
using Backend.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Backend.Infrastructure.Gateways;

public class CourseGateway : ICourseGateway
{
    private readonly DataContext _dataContext;

    public CourseGateway(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<bool> AddAsync(Course course)
    {
        try
        {
            _dataContext.Courses.Add(course);
            await _dataContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> RemoveAsync(int id)
    {
        try
        {
            _dataContext.Courses.Remove(new Course { Id = id });
            await _dataContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<IEnumerable<Course>> GetAllAsync()
    {
        return await _dataContext.Courses
            .Include(o => o.Modules)
            .ThenInclude(o => o.Lessons)
            .ToListAsync();
    }

    public async Task<bool> UpdateAsync(int id, Action<Course> configure)
    {
        try
        {
            var course = await _dataContext.Courses.FirstOrDefaultAsync(o => o.Id == id);
            if (course == null)
                return false;

            configure(course);
            course.Id = id;
            await _dataContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<Course?> GetCourseByIdAsync(int id)
    {
        return await _dataContext.Courses.FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<bool> HaveFreeSlotsAsync(int id)
    {
        return await _dataContext.Courses
            .Include(o => o.Students)
            .AnyAsync(o => o.Id == id && o.Students.Count < o.LimitOfStudents);
    }

    public async Task<bool> HaveStudentAsync(int userId, int courseId)
    {
        return await _dataContext.Courses
            .Include(o => o.Students)
            .AnyAsync(o => o.Id == courseId && o.Students.Any(o1 => o1.Id == userId));
    }

    public async Task<Course?> GetByIdWithTeacherAndModulesAsync(int courseId)
    {
        return await _dataContext.Courses
            .Include(o => o.Teacher)
            .Include(o => o.Modules)
            .ThenInclude(o => o.Lessons)
            .FirstOrDefaultAsync(o => o.Id == courseId);
    }

    public async Task<IEnumerable<Course>> GetStudentCoursesWithModulesAndLessonsAsync(int studentId)
    {
        var student = await _dataContext.Students
            .Include(o => o.Courses)
            .ThenInclude(o => o.Modules)
            .ThenInclude(o => o.Lessons)
            .FirstAsync(o => o.Id == studentId);

        return student.Courses;
    }
}