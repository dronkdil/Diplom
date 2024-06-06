using Backend.Core.Futures.MaterialsForStudy.Courses.DTOs.Requests;
using Backend.Core.Futures.MaterialsForStudy.Courses.DTOs.Responses;
using Backend.Domain.Responses.Base;

namespace Backend.Core.Futures.MaterialsForStudy.Courses;

public interface ICourseService
{
    Task<Response> CreateAsync(CreateCourseDto dto);
    Task<Response> RemoveAsync(RemoveCourseDto dto);
    Task<Response<IEnumerable<ShortCourseDto>>> GetAllCourses();
    Task<Response<ActualCourseDto>> UpdateTitleAsync(UpdateCourseTitleDto dto);
    Task<Response<ActualCourseDto>> UpdateDescriptionAsync(UpdateCourseDescriptionDto dto);
    Task<Response<ActualCourseDto>> UpdateImageByUrlAsync(UpdateCourseImageByUrlDto dto);
    Task<Response<ActualCourseDto>> UpdateChatLinkAsync(UpdateCourseChatLinkDto dto);
    Task<Response<CoursePageDto>> GetCoursePageDataAsync(int courseId);
    Task<Response<double>> GetAverageScoreAsync(int courseId);
}