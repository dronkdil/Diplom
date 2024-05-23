using AutoMapper;
using Backend.Core.Futures.Teacher.DTOs;
using Backend.Core.Futures.Teacher.Responses;
using Backend.Core.Gateways;
using Backend.Domain.Entities;
using Backend.Domain.Responses.Base;
using FluentValidation;

namespace Backend.Core.Futures.Teacher;

public class TeacherService : ITeacherService
{
    private readonly IUserGateway _userGateway;
    private readonly ITeacherGateway _teacherGateway;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateTeacherDto> _createTeacherValidator;

    public TeacherService(IUserGateway userGateway, IMapper mapper, IValidator<CreateTeacherDto> createTeacherValidator, ITeacherGateway teacherGateway)
    {
        _userGateway = userGateway;
        _mapper = mapper;
        _createTeacherValidator = createTeacherValidator;
        _teacherGateway = teacherGateway;
    }

    public async Task<Response<bool>> CreateAsync(CreateTeacherDto dto)
    {
        var result = await _createTeacherValidator.ValidateAsync(dto);
        if (result.IsValid == false)
            return Response.ValidationFailed<bool>(result.Errors);
        
        var teacher = _mapper.Map<User>(dto);
        return Response.Success(await _userGateway.AddTeacherAsync(teacher));
    }

    public async Task<Response<IEnumerable<TeacherShortCourseDto>>> GetCourses(int userId)
    {
        var courses = await _teacherGateway.GetCoursesAsync(userId);
        return courses == null 
            ? GetCoursesResponseHelper.Failed() 
            : Response.Success(_mapper.Map<IEnumerable<TeacherShortCourseDto>>(courses));
    }
}