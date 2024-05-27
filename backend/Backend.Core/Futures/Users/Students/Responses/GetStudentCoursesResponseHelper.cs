using Backend.Core.Futures.Users.Students.DTOs.Responses;
using Backend.Domain.Responses.Base;

namespace Backend.Core.Futures.Users.Students.Responses;

public static class GetStudentCoursesResponseHelper
{
    public static Response<IEnumerable<StudentCourseDto>> Failed() =>
        Response.Failed<IEnumerable<StudentCourseDto>>("Помилка пошуку");
}