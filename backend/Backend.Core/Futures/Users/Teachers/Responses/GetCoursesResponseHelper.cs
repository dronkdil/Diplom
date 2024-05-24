using Backend.Core.Futures.Users.Teachers.DTOs;
using Backend.Domain.Responses.Base;

namespace Backend.Core.Futures.Users.Teachers.Responses;

public static class GetCoursesResponseHelper
{
    public static Response<IEnumerable<TeacherShortCourseDto>> Failed() =>
        Response.Failed<IEnumerable<TeacherShortCourseDto>>("Ви не можете отримати достут до курсів вчителя");
}