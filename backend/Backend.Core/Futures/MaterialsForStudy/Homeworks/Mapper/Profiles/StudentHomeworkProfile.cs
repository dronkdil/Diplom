using AutoMapper;
using Backend.Core.Futures.MaterialsForStudy.Homeworks.DTOs.Responses;
using Backend.Domain.Entities;

namespace Backend.Core.Futures.MaterialsForStudy.Homeworks.Mapper.Profiles;

public class StudentHomeworkProfile : Profile
{
    public StudentHomeworkProfile()
    {
        CreateMap<Homework, StudentHomeworkDto>();
    }
}