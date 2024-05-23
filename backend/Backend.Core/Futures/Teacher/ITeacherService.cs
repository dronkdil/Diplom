using Backend.Core.Futures.Teacher.DTOs;
using Backend.Domain.Responses.Base;

namespace Backend.Core.Futures.Teacher;

public interface ITeacherService
{
    Task<Response<bool>> CreateAsync(CreateTeacherDto dto);
    Task<Response<IEnumerable<TeacherShortCourseDto>>> GetCourses(int userId);
}