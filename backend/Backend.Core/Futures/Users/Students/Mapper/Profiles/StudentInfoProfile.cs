using AutoMapper;
using Backend.Core.Futures.Users.Students.DTOs.Responses;
using Backend.Domain.Entities;

namespace Backend.Core.Futures.Users.Students.Mapper.Profiles;

public class StudentInfoProfile : Profile
{
    public StudentInfoProfile()
    {
        CreateMap<Student, StudentInfoDto>();
    }
}