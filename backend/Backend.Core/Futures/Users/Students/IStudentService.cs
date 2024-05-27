using Backend.Core.Futures.Users.Students.DTOs.Requests;
using Backend.Core.Futures.Users.Students.DTOs.Responses;
using Backend.Domain.Responses.Base;

namespace Backend.Core.Futures.Users.Students;

public interface IStudentService
{
    Task<Response<IEnumerable<StudentDataDto>>> GetAllAsync();
    Task<Response> JoinCourseAsync(JoinCourseDto dto);
    Task<Response<StudentDataDto>> GetMyDataAsync();
    Task<Response<IEnumerable<StudentCourseDto>>> GetCoursesAsync();
    Task<Response<bool>> AlreadyJoinedCourseAsync(int courseId);
    Task<Response> LeaveCourseAsync(LeaveCourseDto dto);
}