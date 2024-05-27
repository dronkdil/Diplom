using Backend.Core.Futures.Users.Students.DTOs.Responses;
using Backend.Domain.Responses.Base;

namespace Backend.Core.Futures.Users.Students.Responses;

public static class GetStudentByIdResponseHelper
{
    public static Response<StudentDataDto> Failed() =>
        Response.Failed<StudentDataDto>("Ітендифікатор некоректний");
}