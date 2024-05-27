using AutoMapper;
using Backend.Core.Futures.Users.Students.DTOs.Responses;
using Backend.Domain.Entities;

namespace Backend.Core.Futures.Users.Students.Mapper.Profiles;

public class StudentInfoProfile : Profile
{
    public StudentInfoProfile()
    {
        CreateMap<Student, StudentDataDto>()
            .AfterMap((src, dest) => dest.Birthday = src.Birthday.ToString("dd.MM.yyyy"))
            .AfterMap((src, dest) => dest.LastName ??= "");
    }
}