using Backend.Core.Futures.MaterialsForStudy.Courses.DTOs.Requests;
using Backend.Core.Futures.MaterialsForStudy.Courses.DTOs.Responses;
using Backend.Domain.Responses.Base;

namespace Backend.Core.Futures.MaterialsForStudy.Courses;

public interface ICourseService
{
    Task<Response> CreateAsync(CreateCourseDto dto);
    Task<Response> RemoveAsync(RemoveCourseDto dto);
    Task<Response<IEnumerable<ShortCourseDto>>> GetAllCourses();
    Task<Response> UpdateTitleAsync(UpdateTitleDto dto);
    Task<Response> UpdateDescriptionAsync(UpdateDescriptionDto dto);
    Task<Response<CoursePageDto>> GetCoursePageDataAsync(int courseId);
}