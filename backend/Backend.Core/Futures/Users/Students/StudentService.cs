using AutoMapper;
using Backend.Core.Futures.Users.Students.DTOs.Requests;
using Backend.Core.Futures.Users.Students.DTOs.Responses;
using Backend.Core.Futures.Users.Students.Responses;
using Backend.Core.Gateways;
using Backend.Core.UserContext;
using Backend.Domain.Responses.Base;

namespace Backend.Core.Futures.Users.Students;

public class StudentService : IStudentService
{
    private readonly IStudentGateway _studentGateway;
    private readonly ICourseGateway _courseGateway;
    private readonly IMapper _mapper;
    private readonly IUserContext _userContext;

    public StudentService(IStudentGateway studentGateway, IMapper mapper, ICourseGateway courseGateway, IUserContext userContext)
    {
        _studentGateway = studentGateway;
        _mapper = mapper;
        _courseGateway = courseGateway;
        _userContext = userContext;
    }

    public async Task<Response<IEnumerable<StudentDataDto>>> GetAllAsync()
    {
        var students = await _studentGateway.GetAllAsync();
        return Response.Success(_mapper.Map<IEnumerable<StudentDataDto>>(students));
    }

    public async Task<Response> JoinCourseAsync(JoinCourseDto dto)
    {
        if (await _courseGateway.HaveStudentAsync(_userContext.UserId, dto.CourseId))
            return JoinCourseResponseHelper.StudentAlreadyHaveCourse();
        
        if (await _courseGateway.HaveFreeSlotsAsync(dto.CourseId) == false)
            return JoinCourseResponseHelper.HaventFreeSlots();

        var isJoined = await _studentGateway.JoinCourse(_userContext.UserId, dto.CourseId);
        return Response.Result(isJoined);
    }

    public async Task<Response<StudentDataDto>> GetMyDataAsync()
    {
        var student = await _studentGateway.GetByIdAsync(_userContext.UserId);
        return student == null 
            ? GetStudentByIdResponseHelper.Failed() 
            : Response.Success(_mapper.Map<StudentDataDto>(student));
    }

    public async Task<Response<IEnumerable<StudentCourseDto>>> GetCoursesAsync()
    {
        var courses = await _courseGateway.GetStudentCoursesWithModulesAndLessonsAsync(_userContext.UserId);
        return Response.Success(_mapper.Map<IEnumerable<StudentCourseDto>>(courses));
    }

    public async Task<Response<bool>> AlreadyJoinedCourseAsync(int courseId)
    {
        return Response.Success(await _courseGateway.HaveStudentAsync(_userContext.UserId, courseId));
    }

    public async Task<Response> LeaveCourseAsync(LeaveCourseDto dto)
    {
        if (await _courseGateway.HaveStudentAsync(_userContext.UserId, dto.CourseId) == false)
            return LeaveCourseResponseHelper.NotJoinedCourse();

        var isLeaved = await _studentGateway.LeaveCourse(_userContext.UserId, dto.CourseId);
        return LeaveCourseResponseHelper.Result(isLeaved);
    }

    public async Task<Response<IEnumerable<StudentDataDto>>> GetAllByCourseAsync(int courseId)
    {
        var students = await _studentGateway.GetByCourseIdAsync(courseId);
        return Response.Success(_mapper.Map<IEnumerable<StudentDataDto>>(students));
    }
}