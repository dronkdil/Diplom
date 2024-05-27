using Backend.Domain.Responses.Base;

namespace Backend.Core.Futures.Users.Students.Responses;

public static class LeaveCourseResponseHelper
{
    public static Response NotJoinedCourse() =>
        Response.Failed("Ви не приєднались до цього курсу");
    
    public static Response Result(bool result) => 
        Response.Result(result, "Курс або студент не знайдені");
}