using Backend.Core.Futures.Teacher.DTOs;
using Backend.Domain.Responses.Base;

namespace Backend.Core.Futures.Teacher.Responses;

public static class GetCoursesResponseHelper
{
    public static Response<IEnumerable<TeacherShortCourseDto>> Failed() =>
        Response.Failed<IEnumerable<TeacherShortCourseDto>>("Ви не можете отримати достут до курсів вчителя");
}