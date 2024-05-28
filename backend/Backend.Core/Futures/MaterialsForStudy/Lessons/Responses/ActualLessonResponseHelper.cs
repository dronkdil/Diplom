using Backend.Core.Futures.MaterialsForStudy.Lessons.DTOs.Responses;
using Backend.Domain.Responses.Base;

namespace Backend.Core.Futures.MaterialsForStudy.Lessons.Responses;

public static class ActualLessonResponseHelper
{
    public static Response<ActualLessonDto> InvalidId() =>
        Response.Failed<ActualLessonDto>("Помилковий ітендифікатор");
}