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

    public async Task<Response<IEnumerable<StudentInfoDto>>> GetAllAsync()
    {
        var students = await _studentGateway.GetAllAsync();
        return Response.Success(_mapper.Map<IEnumerable<StudentInfoDto>>(students));
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
}