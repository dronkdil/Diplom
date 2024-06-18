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

    public async Task<Course> UpdateAsync(int id, Action<Course> configure)
    {
        var course = await _dataContext.Courses.FirstAsync(o => o.Id == id);
        configure(course);
        course.Id = id;
        await _dataContext.SaveChangesAsync();
        return course;
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
            .ThenInclude(o => o.Homeworks)
            .Include(o => o.Modules)
            .ThenInclude(o => o.Lessons)
            .ThenInclude(o => o.ViewedLessons)
            .FirstOrDefaultAsync(o => o.Id == courseId);
    }

    public async Task<IEnumerable<Course>> GetStudentCoursesWithModulesAndLessonsAsync(int studentId)
    {
        var student = await _dataContext.Students
            .Include(o => o.Courses)
            .ThenInclude(o => o.Modules)
            .ThenInclude(o => o.Lessons)
            .ThenInclude(o => o.Homeworks)
            .Include(o => o.Courses)
            .ThenInclude(o => o.Modules)
            .ThenInclude(o => o.Lessons)
            .ThenInclude(o => o.ViewedLessons)
            .FirstAsync(o => o.Id == studentId);

        return student.Courses;
    }

    public async Task<double?> GetAverageScoreAsync(int courseId, int studentId)
    {
        var lessons = await _dataContext.Lessons
            .Include(o => o.Module)
            .Include(o => o.Homeworks)
            .Where(o => o.Module.CourseId == courseId)
            .ToListAsync();
            
        return lessons
            .Average(o => o.Homeworks.Average(o1 => o1.Appraisal));
    }

    public async Task<bool> IsCompletedByLessonAsync(int lessonId, int studentId)
    {
        var course = await _dataContext.Courses
            .Include(o => o.Modules)
            .ThenInclude(o => o.Lessons)
            .FirstAsync(o => o.Modules
                .Any(o1 => o1.Lessons
                    .Any(o2 => o2.Id == lessonId)));

        var allLessons = course.Modules.SelectMany(o => o.Lessons).ToList();
        var allLessonsCount = allLessons.Count;
        var completedLessonsCount = allLessons.Count(o => IsLessonCompleted(o, studentId));

        return allLessonsCount == completedLessonsCount;
    }

    public async Task<string> GetCourseTitleByLessonAsync(int lessonId)
    {
        var course = await _dataContext.Courses
            .Include(o => o.Modules)
            .ThenInclude(o => o.Lessons)
            .FirstAsync(o => o.Modules
                .Any(o1 => o1.Lessons
                    .Any(o2 => o2.Id == lessonId)));

        return course.Title;
    }
    
    private bool IsLessonCompleted(Lesson lesson, int studentId)
    {
        if (lesson.HaveHomework)
        {
            var homeworkCompleted = lesson.Homeworks?.Any(o => o.StudentId == studentId && o.Appraisal != null) ?? false;
            return homeworkCompleted;
        }
        else
        {
            var lessonViewed = lesson.ViewedLessons?.Any(o => o.StudentId == studentId && o.LessonId == lesson.Id) ?? false;
            return lessonViewed;
        }
    }
}