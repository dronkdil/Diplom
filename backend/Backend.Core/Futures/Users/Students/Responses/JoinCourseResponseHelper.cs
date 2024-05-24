using Backend.Domain.Responses.Base;

namespace Backend.Core.Futures.Users.Students.Responses;

public static class JoinCourseResponseHelper
{
    public static Response HaventFreeSlots() =>
        Response.Failed("Усі місця курса заповнені");
    
    public static Response StudentAlreadyHaveCourse() =>
        Response.Failed("Ви вже маєте цей курс");
}