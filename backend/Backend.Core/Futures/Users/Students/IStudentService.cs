using Backend.Core.Futures.Users.Students.DTOs.Requests;
using Backend.Core.Futures.Users.Students.DTOs.Responses;
using Backend.Domain.Responses.Base;

namespace Backend.Core.Futures.Users.Students;

public interface IStudentService
{
    Task<Response<IEnumerable<StudentInfoDto>>> GetAllAsync();
    Task<Response> JoinCourseAsync(JoinCourseDto dto);
}