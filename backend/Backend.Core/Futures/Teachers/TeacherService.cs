using AutoMapper;
using Backend.Core.Futures.Teachers.DTOs;
using Backend.Core.Futures.Teachers.Responses;
using Backend.Core.Gateways;
using Backend.Domain.Entities;
using Backend.Domain.Responses.Base;
using FluentValidation;

namespace Backend.Core.Futures.Teachers;

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

    public async Task<Response> CreateAsync(CreateTeacherDto dto)
    {
        var result = await _createTeacherValidator.ValidateAsync(dto);
        if (result.IsValid == false)
            return Response.ValidationFailed<bool>(result.Errors);
        
        var teacher = _mapper.Map<Teacher>(dto);
        var isAdded = await _teacherGateway.AddAsync(teacher);
        return isAdded
            ? Response.Success()
            : Response.Failed();
    }

    public async Task<Response<IEnumerable<TeacherShortCourseDto>>> GetCoursesAsync(int userId)
    {
        var courses = await _teacherGateway.GetCoursesAsync(userId);
        return courses == null 
            ? GetCoursesResponseHelper.Failed() 
            : Response.Success(_mapper.Map<IEnumerable<TeacherShortCourseDto>>(courses));
    }

    public async Task<Response> RemoveAsync(RemoveTeacherDto dto)
    {
        var isRemoved = await _teacherGateway.RemoveAsync(dto.Id);
        return isRemoved
            ? Response.Success()
            : Response.Failed();
    }

    public async Task<Response<IEnumerable<TeacherInformationDto>>> GetAllTeachersAsync()
    {
        var allTeachers = await _teacherGateway.GetAllTeachers();
        return Response.Success(_mapper.Map<IEnumerable<TeacherInformationDto>>(allTeachers));
    }
}