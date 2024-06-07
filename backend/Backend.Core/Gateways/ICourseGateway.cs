using System.Collections;
using Backend.Domain.Entities;

namespace Backend.Core.Gateways;

public interface ICourseGateway
{
    Task<bool> AddAsync(Course course);
    Task<bool> RemoveAsync(int id);
    Task<IEnumerable<Course>> GetAllAsync();
    Task<Course> UpdateAsync(int id, Action<Course> configure);
    Task<Course?> GetCourseByIdAsync(int id);
    Task<bool> HaveFreeSlotsAsync(int id);
    Task<bool> HaveStudentAsync(int userId, int courseId);
    Task<Course?> GetByIdWithTeacherAndModulesAsync(int courseId);
    Task<IEnumerable<Course>> GetStudentCoursesWithModulesAndLessonsAsync(int studentId);
    Task<double?> GetAverageScoreAsync(int courseId, int studentId);
    Task<bool> IsCompletedByLessonAsync(int lessonId, int studentId);
    Task<string> GetCourseTitleByLessonAsync(int lessonId);
}